using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.AccessControl;
using ProcessPrivileges;
using System.Linq;
using Microsoft.Win32.SafeHandles;
using ChangeProcessIL;

/* 
 * ВНИМАНИЕ!
 * Данную лабораторную работу по дисциплине МБКС делали ученики группы 33508/5:
 * Зубков Евгений; Полина Шимко
 * 
 * Аббревиатуры:
 * ИФ - Импортированная функция
 */

namespace MBKS_II
{
    public partial class MBKSII : Form
    {
        public MBKSII() { InitializeComponent(); }

        public const string ND_MESSAGE = "Нет данных";

        #region ИФ, определяющая, выполняется ли процесс через WOW64
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process);
        #endregion

        #region ИФ, возвращающая флаги использования технологии DEP процессом
        [DllImport("kernel32.dll")]
        public static extern int GetProcessDEPPolicy(
            [In] IntPtr hproc,
            [Out] out bool flag,
            [Out] out bool permanent);
        #endregion

        #region Определение использования технологии ASLR процессом
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_WM_READ = 0x0010;

        #region Структура, представляющая различные политики смягчения процесса
        public enum PROCESS_MITIGATION_POLICY
        {
            ProcessDEPPolicy = 0,
            ProcessASLRPolicy = 1,
            ProcessDynamicCodePolicy = 2,
            ProcessStrictHandleCheckPolicy = 3,
            ProcessSystemCallDisablePolicy = 4,
            ProcessMitigationOptionsMask = 5,
            ProcessExtensionPointDisablePolicy = 6,
            ProcessControlFlowGuardPolicy = 7,
            ProcessSignaturePolicy = 8,
            ProcessFontDisablePolicy = 9,
            ProcessImageLoadPolicy = 10,
            MaxProcessMitigationPolicy = 11
        }
        #endregion

        #region Структура, представляющая параметры политики смягчения процесса для ASLR
        public struct PROCESS_MITIGATION_ASLR_POLICY
        {
            public uint Flags;

            public bool EnableBottomUpRandomization
            {
                get { return (Flags & 1) > 0; }
            }

            public bool EnableForceRelocateImages
            {
                get { return (Flags & 2) > 0; }
            }

            public bool EnableHighEntropy
            {
                get { return (Flags & 4) > 0; }
            }

            public bool DisallowStrippedImages
            {
                get { return (Flags & 8) > 0; }
            }
        }
        #endregion

        #region ИФ, отрывающая процесс и возвращающая его дескриптор
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
            int dwDesiredAccess,
            bool bInheritHandle,
            int dwProcessId);
        #endregion

        #region ИФ, возвращающая структуру политики смягчения процесса для заданного параметра
        [DllImport("kernel32.dll")]
        static extern bool GetProcessMitigationPolicy(
            IntPtr hProcess,
            PROCESS_MITIGATION_POLICY mitigationPolicy,
            ref PROCESS_MITIGATION_ASLR_POLICY lpBuffer,
            int dwLength);
        #endregion

        #endregion

        #region Определение имени родительского процесса
        private static string FindIndexedProcessName(int pid)
        {
            var processName = Process.GetProcessById(pid).ProcessName;         
            var processesByName = Process.GetProcessesByName(processName);
            string processIndexdName = null;

            for (var index = 0; index < processesByName.Length; index++)
            {
                processIndexdName = index == 0 ? processName : processName + "#" + index;
                var processId = new PerformanceCounter("Process", "ID Process", processIndexdName);
                if ((int)processId.NextValue() == pid)
                {
                    return processIndexdName;
                }
            }
            return processIndexdName;
        }
        #endregion

        #region Определение ID родительского процесса
        private static Process FindPidFromIndexedProcessName(string indexedProcessName)
        {
            var parentId = new PerformanceCounter("Process", "Creating Process ID", indexedProcessName);
            return Process.GetProcessById((int)parentId.NextValue());
        }
        #endregion

        #region Определение имени владельца процесса

        #region ИФ, возвращающая имя владельца процесса (в байтах)
        [DllImport("Wtsapi32.dll")]
        public static extern bool WTSQuerySessionInformationW(
                                  IntPtr hServer,
                                  int SessionId,
                                  int WTSInfoClass,
                                  out IntPtr ppBuffer,
                                  out uint pBytesReturned);
        #endregion

        internal static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        internal static int WTS_UserName = 5;
        private static string GetUserName(Process proc)
        {
            string userName = ND_MESSAGE;
            IntPtr AnswerBytes;
            uint AnswerCount;

            if (WTSQuerySessionInformationW(WTS_CURRENT_SERVER_HANDLE,
                                            proc.SessionId,
                                            WTS_UserName,
                                            out AnswerBytes,
                                            out AnswerCount))
            {
                userName = Marshal.PtrToStringUni(AnswerBytes);
                return userName;
            }
            else
            {
                return userName;
            }
        }
        #endregion

        #region Определение уровня целостности процесса
        public static uint dwError = 0;
        public string ShowProcessIntegrityLevel(int ID)
        {
            Process proc = Process.GetProcessById(ID);
            IntPtr hProcess = proc.Handle;
            IntPtr hToken;
            OpenProcessToken(hProcess, TokenAccessLevels.MaximumAllowed, out hToken);
            string IL = ND_MESSAGE;

            try
            {
                uint dwLengthNeeded;
                if (GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, IntPtr.Zero, 0, out dwLengthNeeded))
                {
                    uint dwError = (uint)Marshal.GetLastWin32Error();
                }

                IntPtr pTIL = Marshal.AllocHGlobal((int)dwLengthNeeded);
                try
                {
                    if (!GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel,
                                             pTIL, dwLengthNeeded, out dwLengthNeeded))
                    {
                        return IL;
                    }

                    TOKEN_MANDATORY_LABEL TIL = (TOKEN_MANDATORY_LABEL)Marshal.PtrToStructure(pTIL,
                                                 typeof(TOKEN_MANDATORY_LABEL));

                    IntPtr SubAuthorityCount = GetSidSubAuthorityCount(TIL.Label.Sid);

                    IntPtr IntegrityLevelPtr = GetSidSubAuthority(TIL.Label.Sid,
                                                                  Marshal.ReadByte(SubAuthorityCount) - 1);

                    int dwIntegrityLevel = Marshal.ReadInt32(IntegrityLevelPtr);

                    if (dwIntegrityLevel >= SECURITY_MANDATORY_UNTRUSTED_RID &&
                        dwIntegrityLevel < SECURITY_MANDATORY_LOW_RID)
                    {
                        IL = "Ненадежный";
                    }

                    else if (dwIntegrityLevel >= SECURITY_MANDATORY_LOW_RID &&
                             dwIntegrityLevel < SECURITY_MANDATORY_MEDIUM_RID)
                    {
                        IL = "Низкий";
                    }

                    else if (dwIntegrityLevel >= SECURITY_MANDATORY_MEDIUM_RID &&
                             dwIntegrityLevel < SECURITY_MANDATORY_MEDIUM_PLUS_RID)
                    {
                        IL = "Средний";
                    }

                    else if (dwIntegrityLevel >= SECURITY_MANDATORY_MEDIUM_PLUS_RID &&
                             dwIntegrityLevel < SECURITY_MANDATORY_HIGH_RID)
                    {
                        IL = "Средний+";
                    }
                    else if (dwIntegrityLevel >= SECURITY_MANDATORY_HIGH_RID &&
                             dwIntegrityLevel < SECURITY_MANDATORY_SYSTEM_RID)
                    {
                        IL = "Высокий";
                    }
                    else if (dwIntegrityLevel >= SECURITY_MANDATORY_SYSTEM_RID &&
                             dwIntegrityLevel < SECURITY_MANDATORY_PROTECTED_PROCESS_RID)
                    {
                        IL = "Системный";
                    }
                    else if (dwIntegrityLevel >= SECURITY_MANDATORY_PROTECTED_PROCESS_RID)
                    {
                        IL = "Защищенный";
                    }
                }
                catch(Exception err)
                {
                    #region Запись в файл "Exeptions_LOG.txt" исключений, возникающих в ходе работы программы
                    string error_message = "Имя: " + proc.ProcessName + Environment.NewLine +
                                           "Исключение: " + err.Message.ToString() + Environment.NewLine + Environment.NewLine;

                    StreamWriter file = new StreamWriter("Исключение.txt", true);
                    file.WriteLine(error_message);
                    file.Close();
                    #endregion

                    Marshal.FreeHGlobal(pTIL);
                    return IL;
                }
            }
            catch(Exception err)
            {
                #region Запись в файл "Exeptions_LOG.txt" исключений, возникающих в ходе работы программы
                string error_message = "Имя: " + proc.ProcessName + Environment.NewLine +
                       "Исключение: " + err.Message.ToString() + Environment.NewLine + Environment.NewLine;

                StreamWriter file = new StreamWriter("Исключение.txt", true);
                file.WriteLine(error_message);
                file.Close();
                #endregion

                CloseHandle(hToken);
                return IL;
            }
            return IL;
        }

        #region Промежутки уровней целостности
        const long SECURITY_MANDATORY_UNTRUSTED_RID = 0x00000000L;
        const long SECURITY_MANDATORY_LOW_RID = 0x00001000L;
        const long SECURITY_MANDATORY_MEDIUM_RID = 0x00002000L;
        const long SECURITY_MANDATORY_MEDIUM_PLUS_RID = SECURITY_MANDATORY_MEDIUM_RID + 0x100;
        const long SECURITY_MANDATORY_HIGH_RID = 0x00003000L;
        const long SECURITY_MANDATORY_SYSTEM_RID = 0x00004000L;
        const long SECURITY_MANDATORY_PROTECTED_PROCESS_RID = 0x00005000L;
        #endregion

        #region Структура, отобращающая данные, которые можно считать из маркера доступа
        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups = 2,
            TokenPrivileges = 3,
            TokenOwner = 4,
            TokenPrimaryGroup = 5,
            TokenDefaultDacl = 6,
            TokenSource = 7,
            TokenType = 8,
            TokenImpersonationLevel = 9,
            TokenStatistics = 10,
            TokenRestrictedSids = 11,
            TokenSessionId = 12,
            TokenGroupsAndPrivileges = 13,
            TokenSessionReference = 14,
            TokenSandBoxInert = 15,
            TokenAuditPolicy = 16,
            TokenOrigin = 17,
            TokenElevationType = 18,
            TokenLinkedToken = 19,
            TokenElevation = 20,
            TokenHasRestrictions = 21,
            TokenAccessInformation = 22,
            TokenVirtualizationAllowed = 23,
            TokenVirtualizationEnabled = 24,
            TokenIntegrityLevel = 25,
            TokenUIAccess = 26,
            TokenMandatoryPolicy = 27,
            TokenLogonSid = 28,
            MaxTokenInfoClass = 29
        }
        #endregion

        #region Cтруктура, определяющая уровень целостности для маркера доступа
        [StructLayout(LayoutKind.Sequential)]
        struct TOKEN_MANDATORY_LABEL
        {
            public SID_AND_ATTRIBUTES Label;
        }
        #endregion

        #region Структура, представляющая собой идентификатор безопасности (SID) и его атрибуты
        [StructLayout(LayoutKind.Sequential)]
        struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public int Attributes;
        }
        #endregion

        #region ИФ, которая закрывает маркер доступа, связанного с процессом
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        #endregion

        #region ИФ, которая открывает маркер доступа, связанного с процессом
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle,
            TokenAccessLevels DesiredAccess,
            out IntPtr TokenHandle);
        #endregion

        #region ИФ, которая возвращает информацию маркера доступа
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            uint TokenInformationLength,
            out uint ReturnLength);
        #endregion

        #region ИФ, которая возвращает относительный идентификатор безопасности
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthority(IntPtr pSid, int nSubAuthority);
        #endregion

        #region ИФ, которая возвращает количество отностительных идентификаторов безопасности
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthorityCount(IntPtr pSid);
        #endregion
        #endregion

        /*private static string GetPadding(int length, int maxLength)
        {
            int paddingLength = maxLength - length;
            char[] padding = new char[paddingLength];
            for (int i = 0; i < paddingLength; i++)
            {
                padding[i] = ' ';
            }

            return new string(padding);
        }*/

        #region Элементы окна
        private void MBKSII_Load(object sender, EventArgs e) {Refresh_button_Click(sender, e);}
        private void Table_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void PIDBox_TextChanged(object sender, EventArgs e) { }
        private void DLLList_label_Click(object sender, EventArgs e) { }
        private void DLLBox_TextChanged(object sender, EventArgs e) { DLLBox.ScrollBars = ScrollBars.Both; }
        private void Privilegeslabel_Click(object sender, EventArgs e) { DLLBox.ScrollBars = ScrollBars.Both; }
        private void Privileges_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Privilege_comboBox_SelectedIndexChanged(object sender, EventArgs e) { string p = this.Text; }
        private void State_comboBox_SelectedIndexChanged(object sender, EventArgs e) { string s = this.Text; }
        private void Privilege_label_Click(object sender, EventArgs e) { }
        private void Status_label_Click(object sender, EventArgs e) { }
        private void ProcessIL_comboBox_SelectedIndexChanged(object sender, EventArgs e) { string il = this.Text; }
        #endregion

        #region Событие "Одиночный клик на ячейку" - вывод DLL и привелегий
        private void Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int PID = 0;
            try
            {
                #region Получение DLL и вывод в TextBox
                PID = Int32.Parse(Table.CurrentCell.Value.ToString());
                DLLBox.Clear();
                Process proc = Process.GetProcessById(PID);

                DLLBox.Text += "Процесс: " + proc.ProcessName + Environment.NewLine;
                foreach (ProcessModule module in proc.Modules)
                {
                    DLLBox.Text += module.FileName + Environment.NewLine;
                }
                #endregion

                #region Получение привелегий процесса
                Priveleges_dataGridView.Rows.Clear();

                PrivilegeAndAttributesCollection privileges = proc.GetPrivileges();

                //int maxPrivilegeLength = privileges.Max(privilege => privilege.Privilege.ToString().Length);

                foreach (PrivilegeAndAttributes privilegeAndAttributes in privileges)
                {
                    Privilege privilege = privilegeAndAttributes.Privilege;

                    PrivilegeState privilegeState = privilegeAndAttributes.PrivilegeState;

                    Priveleges_dataGridView.Rows.Add(privilege /*+ GetPadding(privilege.ToString().Length, maxPrivilegeLength)*/, privilegeState);
                }
                #endregion
            }
            catch (Win32Exception) { }
            catch (ArgumentException) { }
            catch (FormatException) { }
            catch (InvalidOperationException) { }
        }
        #endregion

        #region Кнопка "Обновить"
        public void Refresh_button_Click(object sender, EventArgs e)
        {
            Process[] process_list = Process.GetProcesses();
            Table.Rows.Clear();

            #region Объявление переменных, в которые будут записываться получаемые данные
            int count = 1;
            string Exec_file = ND_MESSAGE;                  // Исполняемый файл
            string capacity = ND_MESSAGE;                   // Разрядность
            string Parent_process_name = ND_MESSAGE;        // Имя родительского процесса
            string Parent_process_ID = ND_MESSAGE;          // ID родительского процесса
            string User_name = ND_MESSAGE;                  // Имя владельца процесса
            string SID = ND_MESSAGE;                        // SID владельца процесса
            string Using_DEP = ND_MESSAGE;                  // Использование DEP
            string Using_ASLR = ND_MESSAGE;                 // Использование ASLR
            string IL = ND_MESSAGE;                         // Уровень целостности процесса
            string priority = "4";                          // Приоритет процесса
            #endregion

            foreach (Process current_process in process_list)
            {
                
                #region Обнуление получаемых параметров
                Exec_file = ND_MESSAGE;
                capacity = ND_MESSAGE;
                Parent_process_name = ND_MESSAGE;
                Parent_process_ID = ND_MESSAGE;
                User_name = ND_MESSAGE;
                SID = ND_MESSAGE;
                Using_DEP = ND_MESSAGE;
                Using_ASLR = ND_MESSAGE;
                IL = ND_MESSAGE;
                #endregion

                try
                {
                    #region Определение параметров родительского процесса
                    //Parent_process_name = FindIndexedProcessName(current_process.Id);
                    Process Parent_process = FindPidFromIndexedProcessName(FindIndexedProcessName(current_process.Id));
                    Parent_process_ID = Parent_process.Id.ToString();
                    Parent_process_name = Process.GetProcessById(Int32.Parse(Parent_process_ID)).ProcessName;
                    #endregion

                    #region Определение владельца процесса
                    User_name = GetUserName(current_process);
                    if (User_name == "")
                    {
                        User_name = ND_MESSAGE;
                    }
                    else
                    {
                        var account = new NTAccount(User_name);
                        var SID_not_string = (SecurityIdentifier)account.Translate(typeof(SecurityIdentifier));
                        SID = SID_not_string.ToString();
                    }
                    #endregion

                    #region Определение разрядности (типа) процесса
                    bool ans;
                    if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                         Environment.OSVersion.Version.Major >= 6)
                    {
                        bool retVal;
                        if (!IsWow64Process(current_process.Handle, out retVal)) { ans = false; }
                        else { ans = retVal; }
                    }
                    else { ans = false; }

                    if (ans == false)
                        capacity = "64-bit";
                    else
                        capacity = "32-bit";
                    #endregion

                    #region Определение использования технологии DEP процессом
                    bool flag = false, permanent = false;
                    if (capacity == "64-bit") { Using_DEP = "DEP включен (постоянный)"; }
                    else
                    {
                        int DEP = GetProcessDEPPolicy(current_process.Handle, out flag, out permanent);
                        if (flag == true && permanent == true)
                        { Using_DEP = "DEP включен (постоянный)"; }
                        else{ Using_DEP = "DEP отключен"; }
                    }
                    #endregion

                    #region Определение использования технологии ASLR процессом
                    IntPtr hProc = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, current_process.Id);
                    PROCESS_MITIGATION_ASLR_POLICY PMAP = new PROCESS_MITIGATION_ASLR_POLICY();
                    bool ASLR = GetProcessMitigationPolicy(hProc, PROCESS_MITIGATION_POLICY.ProcessASLRPolicy, ref PMAP, Marshal.SizeOf(PMAP));
                    if (PMAP.DisallowStrippedImages == false &&
                        PMAP.EnableBottomUpRandomization == true &&
                        PMAP.EnableForceRelocateImages == false &&
                        PMAP.EnableHighEntropy == false)
                    {
                        Using_ASLR = "ASLR включен";
                    }
                    else { Using_ASLR = "ASLR отключен"; }
                    #endregion

                    #region Определение уровня целостности процесса
                    IL = ShowProcessIntegrityLevel(current_process.Id);
                    #endregion

                    #region Определение исполняемого файла
                    Exec_file = current_process.MainModule.FileName;
                    #endregion

                    priority = current_process.BasePriority.ToString();

                    #region Заполнение таблицы полученными данными
                    Table.Rows.Add(count,                                // Порядковый номер
                                   current_process.ProcessName,          // Имя процесса
                                   current_process.Id,                   // PID процесса
                                   Exec_file,                            // Исполняемый файл
                                   Parent_process_name,                  // Имя родительского процесса
                                   Parent_process_ID,                    // ID родительского процесса
                                   User_name,                            // Имя пользователя-владельца
                                   SID,                                  // SID пользователя-владельца
                                   capacity,                             // Тип процесса
                                   Using_DEP,                            // Использование DEP процессом
                                   Using_ASLR,                           // Использование ASLR процессом
                                   IL,                                   // Уровень целостности процесса
                                   priority,                             // Приоритет процесса
                                   "Нет");
                    #endregion
                    count++;
                }
                catch (Exception err)
                {
                    #region Запись в файл "Exeptions_LOG.txt" исключений, возникающих в ходе работы программы
                    string error_message = "№ " + count + Environment.NewLine +
                                           "Имя процесса: " + current_process.ProcessName + Environment.NewLine +
                                           "Исключение: " + err.Message.ToString() + Environment.NewLine + Environment.NewLine;

                    StreamWriter Log_file = new StreamWriter("Exceptions_LOG.txt", false);
                    Log_file.WriteLine(error_message);
                    Log_file.Close();
                    #endregion

                    #region Заполнение таблицы полученными данными
                    Table.Rows.Add(count,
                                   current_process.ProcessName,
                                   current_process.Id,
                                   Exec_file,
                                   Parent_process_name,
                                   Parent_process_ID,
                                   User_name,
                                   SID,
                                   capacity,
                                   Using_DEP,
                                   Using_ASLR,
                                   IL,
                                   priority,
                                   "Да: " + err.Message);
                    #endregion

                    count++;
                }
            }
        }
        #endregion

        #region Кнопка "Окно объектов (файлов)"
        private void Change_window_button_Click(object sender, EventArgs e)
        {
            Form F2 = new Change_params();
            F2.ShowDialog();
        }
        #endregion

        #region Изменение привелегий процесса
        private void ChangePrivileges_button_Click(object sender, EventArgs e)
        {
            int PID = Int32.Parse(Table.CurrentCell.Value.ToString());
            Process proc = Process.GetProcessById(PID);

            string p = Privilege_comboBox.Text.ToString();
            string s = State_comboBox.Text;

            Privilege privilege = (Privilege)Enum.Parse(typeof(Privilege), p);

            PrivilegeState state = (PrivilegeState)Enum.Parse(typeof(PrivilegeState), s);

            if (state == PrivilegeState.Disabled)
                proc.DisablePrivilege(privilege);
            else if (state == PrivilegeState.Enabled)
                proc.EnablePrivilege(privilege);
            else if (state == PrivilegeState.Removed)
                proc.RemovePrivilege(privilege);
        }
        #endregion

        #region Установка нового уровня целостности для процесса
        private void ChangeProcessIL_button_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Table.CurrentCell.Value.ToString());
            string IL_str = ProcessIL_comboBox.Text.ToString();
            int IL = 0x00000000;

            if (IL_str == "Ненадежный")
                IL = 0x00000000;
            else if (IL_str == "Низкий")
                IL = 0x00001000;
            else if (IL_str == "Средний")
                IL = 0x00002000;

            SafeTokenHandle hToken = null;
            IntPtr pIntegritySid = IntPtr.Zero;
            int cbTokenInfo = 0;
            IntPtr pTokenInfo = IntPtr.Zero;

            try
            {
                if (!NativeMethod.OpenProcessToken(Process.GetProcessById(ID).Handle,
                    NativeMethod.TOKEN_DUPLICATE | NativeMethod.TOKEN_ADJUST_DEFAULT |
                    NativeMethod.TOKEN_QUERY | NativeMethod.TOKEN_ASSIGN_PRIMARY,
                    out hToken))
                {
                    throw new Win32Exception();
                }

                // Распределение памяти под идентификатор безопасности
                // и инициализация его полей
                if (!NativeMethod.AllocateAndInitializeSid(
                    ref NativeMethod.SECURITY_MANDATORY_LABEL_AUTHORITY, 1,
                    IL,
                    0, 0, 0, 0, 0, 0, 0, out pIntegritySid))
                {
                    throw new Win32Exception();
                }

                TOKEN_MANDATORY_LABEL tml;
                tml.Label.Attributes = NativeMethod.SE_GROUP_INTEGRITY;
                tml.Label.Sid = pIntegritySid;

                cbTokenInfo = Marshal.SizeOf(tml);
                pTokenInfo = Marshal.AllocHGlobal(cbTokenInfo);
                Marshal.StructureToPtr(tml, pTokenInfo, false);

                if (!NativeMethod.SetTokenInformation(hToken,
                    ChangeProcessIL.TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenInfo,
                    cbTokenInfo + NativeMethod.GetLengthSid(pIntegritySid)))
                {
                    throw new Win32Exception();
                }
            }
            catch (Exception err)
            {
                string error_message = "Функция: изменение уровня целостности" + Environment.NewLine +
                                       "Имя процесса: " + Process.GetProcessById(ID).ProcessName + Environment.NewLine +
                                       "Исключение: " + err.Message.ToString() + Environment.NewLine + Environment.NewLine;

                StreamWriter Log_file = new StreamWriter("Exceptions_LOG.txt", false);
                Log_file.WriteLine(error_message);
                Log_file.Close();
            }
            finally
            {
                if (hToken != null)
                {
                    hToken.Close();
                    hToken = null;
                }
                if (pIntegritySid != IntPtr.Zero)
                {
                    NativeMethod.FreeSid(pIntegritySid);
                    pIntegritySid = IntPtr.Zero;
                }
                if (pTokenInfo != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pTokenInfo);
                    pTokenInfo = IntPtr.Zero;
                    cbTokenInfo = 0;
                }
            }
        }
        #endregion
    }
}

// Пространство имен, необходимое для корректной обработки дескриптора процесса
// и дальнейшего изменения его уровня целостности
namespace ChangeProcessIL
{
    #region Структура маркеров доступа
    internal enum TOKEN_INFORMATION_CLASS
    {
        TokenUser = 1,
        TokenGroups,
        TokenPrivileges,
        TokenOwner,
        TokenPrimaryGroup,
        TokenDefaultDacl,
        TokenSource,
        TokenType,
        TokenImpersonationLevel,
        TokenStatistics,
        TokenRestrictedSids,
        TokenSessionId,
        TokenGroupsAndPrivileges,
        TokenSessionReference,
        TokenSandBoxInert,
        TokenAuditPolicy,
        TokenOrigin,
        TokenElevationType,
        TokenLinkedToken,
        TokenElevation,
        TokenHasRestrictions,
        TokenAccessInformation,
        TokenVirtualizationAllowed,
        TokenVirtualizationEnabled,
        TokenIntegrityLevel,
        TokenUIAccess,
        TokenMandatoryPolicy,
        TokenLogonSid,
        MaxTokenInfoClass
    }
    #endregion

    #region Структура SID'а и его атрибутов
    [StructLayout(LayoutKind.Sequential)]
    internal struct SID_AND_ATTRIBUTES
    {
        public IntPtr Sid;
        public UInt32 Attributes;
    }
    #endregion

    #region Структура SID'a уровня "Система"
    [StructLayout(LayoutKind.Sequential)]
    internal struct SID_IDENTIFIER_AUTHORITY
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6,
            ArraySubType = UnmanagedType.I1)]
        public byte[] Value;

        public SID_IDENTIFIER_AUTHORITY(byte[] value)
        {
            this.Value = value;
        }
    }
    #endregion

    #region Структура, определяеющая уровень обязательной целостности для маркера доступа
    [StructLayout(LayoutKind.Sequential)]
    internal struct TOKEN_MANDATORY_LABEL
    {
        public SID_AND_ATTRIBUTES Label;
    }
    #endregion

    #region SafeTokenHandle
    internal class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        internal SafeTokenHandle(IntPtr handle)
            : base(true)
        {
            base.SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            return NativeMethod.CloseHandle(base.handle);
        }
    }
    #endregion

    internal class NativeMethod
    {
        #region Маркеры доступа
        public const UInt32 STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        public const UInt32 STANDARD_RIGHTS_READ = 0x00020000;
        public const UInt32 TOKEN_ASSIGN_PRIMARY = 0x0001;
        public const UInt32 TOKEN_DUPLICATE = 0x0002;
        public const UInt32 TOKEN_IMPERSONATE = 0x0004;
        public const UInt32 TOKEN_QUERY = 0x0008;
        public const UInt32 TOKEN_QUERY_SOURCE = 0x0010;
        public const UInt32 TOKEN_ADJUST_PRIVILEGES = 0x0020;
        public const UInt32 TOKEN_ADJUST_GROUPS = 0x0040;
        public const UInt32 TOKEN_ADJUST_DEFAULT = 0x0080;
        public const UInt32 TOKEN_ADJUST_SESSIONID = 0x0100;
        public const UInt32 TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
        public const UInt32 TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED |
            TOKEN_ASSIGN_PRIMARY | TOKEN_DUPLICATE | TOKEN_IMPERSONATE |
            TOKEN_QUERY | TOKEN_QUERY_SOURCE | TOKEN_ADJUST_PRIVILEGES |
            TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT | TOKEN_ADJUST_SESSIONID);
        #endregion

        #region Уровни целостности
        public static SID_IDENTIFIER_AUTHORITY SECURITY_MANDATORY_LABEL_AUTHORITY =
            new SID_IDENTIFIER_AUTHORITY(new byte[] { 0, 0, 0, 0, 0, 16 });
        public const Int32 SECURITY_MANDATORY_UNTRUSTED_RID = 0x00000000;
        public const Int32 SECURITY_MANDATORY_LOW_RID = 0x00001000;
        public const Int32 SECURITY_MANDATORY_MEDIUM_RID = 0x00002000;
        public const Int32 SECURITY_MANDATORY_HIGH_RID = 0x00003000;
        public const Int32 SECURITY_MANDATORY_SYSTEM_RID = 0x00004000;
        #endregion

        // Group related SID Attributes
        #region Атрибуты SID'a
        public const UInt32 SE_GROUP_MANDATORY = 0x00000001;
        public const UInt32 SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002;
        public const UInt32 SE_GROUP_ENABLED = 0x00000004;
        public const UInt32 SE_GROUP_OWNER = 0x00000008;
        public const UInt32 SE_GROUP_USE_FOR_DENY_ONLY = 0x00000010;
        public const Int32 SE_GROUP_INTEGRITY = 0x00000020;
        public const UInt32 SE_GROUP_INTEGRITY_ENABLED = 0x00000040;
        public const UInt32 SE_GROUP_LOGON_ID = 0xC0000000;
        public const UInt32 SE_GROUP_RESOURCE = 0x20000000;
        public const UInt32 SE_GROUP_VALID_ATTRIBUTES = (SE_GROUP_MANDATORY |
            SE_GROUP_ENABLED_BY_DEFAULT | SE_GROUP_ENABLED | SE_GROUP_OWNER |
            SE_GROUP_USE_FOR_DENY_ONLY | SE_GROUP_LOGON_ID | SE_GROUP_RESOURCE |
            SE_GROUP_INTEGRITY | SE_GROUP_INTEGRITY_ENABLED);
        #endregion

        #region ИФ, открывающая дескриптор процесса с определенными маркерами доступа
        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(
            IntPtr hProcess,
            UInt32 desiredAccess,
            out SafeTokenHandle hToken);
        #endregion

        #region ИФ, устанавливающая различные типы информации для указанного маркера доступа
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetTokenInformation(
            SafeTokenHandle hToken,
            TOKEN_INFORMATION_CLASS tokenInfoClass,
            IntPtr pTokenInfo,
            Int32 tokenInfoLength);
        #endregion

        #region ИФ, выделяющая и инициализирующая новый идентификатор безопасности 
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocateAndInitializeSid(
            ref SID_IDENTIFIER_AUTHORITY pIdentifierAuthority,
            byte nSubAuthorityCount,
            int dwSubAuthority0, int dwSubAuthority1,
            int dwSubAuthority2, int dwSubAuthority3,
            int dwSubAuthority4, int dwSubAuthority5,
            int dwSubAuthority6, int dwSubAuthority7,
            out IntPtr pSid);
        #endregion

        #region ИФ, освобождающая память от идентификатора безопасности
        [DllImport("advapi32.dll")]
        public static extern IntPtr FreeSid(IntPtr pSid);
        #endregion

        #region ИФ, получающая длину идентификатора безопасности
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetLengthSid(IntPtr pSID);
        #endregion

        #region ИФ, закрывающая дескриптор связанного процесса
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr handle);
        #endregion
    }
}