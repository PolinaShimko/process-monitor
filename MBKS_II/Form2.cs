using System;
using System.IO;
using System.Windows.Forms;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace MBKS_II
{
    public partial class Change_params : Form
    {
        public Change_params() {InitializeComponent();}

        public string FILE_UNC = null;
        public string New_Owner = null;
        public int IL = -1;

        #region Функция диалогового окна
        public bool Get_file()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Текстовые документы .txt|*.txt|Исполняемые файлы .exe|*.exe";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FILE_UNC = OPF.FileName;
                return true;
            }
            return false;
        }
        #endregion

        #region ИФ, определяющая текущий уровень целостности
        [DllImport("C:\\IntegrityLevelx64.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFileIntegrityLevel(string FileName);
        #endregion

        #region ИФ, устанавливающая новый уровень целостности
        [DllImport("C:\\IntegrityLevelx64.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetFileIntegrityLevel(int level, string FileName);
        #endregion

        #region Код, необходимый для установки привелегии на восстановление объектов ФС
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        // Use this signature if you do not want the previous state
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AdjustTokenPrivileges(IntPtr tokenHandle,
            [MarshalAs(UnmanagedType.Bool)]bool disableAllPrivileges,
            ref TOKEN_PRIVILEGES newState,
            UInt32 bufferLength,
            IntPtr previousState,
            IntPtr returnLength);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern bool OpenProcessToken
            (IntPtr processHandle, int desiredAccess, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool LookupPrivilegeValue(string host, string name, ref LUID lpLuid);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct TOKEN_PRIVILEGES
        {
            public UInt32 PrivilegeCount;
            public LUID Luid;
            public UInt32 Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }

        const int SE_PRIVILEGE_ENABLED = 0x00000002;
        const int TOKEN_QUERY = 0x00000008;
        const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        const string SE_RESTORE_PRIVILEGE = "SeRestorePrivilege";

        public static void GiveRestorePrivilege()
        {
            TOKEN_PRIVILEGES tokenPrivileges;
            tokenPrivileges.PrivilegeCount = 1;
            tokenPrivileges.Luid = new LUID();
            tokenPrivileges.Attributes = SE_PRIVILEGE_ENABLED;

            IntPtr tokenHandle = RetrieveProcessToken();

            try
            {
                bool success = LookupPrivilegeValue
                            (null, SE_RESTORE_PRIVILEGE, ref tokenPrivileges.Luid);
                if (success == false)
                {
                    int lastError = Marshal.GetLastWin32Error();
                    throw new Exception(
                        string.Format("Could not find privilege {0}. Error {1}",
                                            SE_RESTORE_PRIVILEGE, lastError));
                }

                success = AdjustTokenPrivileges(tokenHandle, false,
                                                ref tokenPrivileges, 0,
                                                IntPtr.Zero, IntPtr.Zero);
                if (success == false)
                {
                    int lastError = Marshal.GetLastWin32Error();
                    throw new Exception(
                        string.Format("Could not assign privilege {0}. Error {1}",
                                        SE_RESTORE_PRIVILEGE, lastError));
                }
            }
            finally
            {
                CloseHandle(tokenHandle);
            }

        }

        static IntPtr RetrieveProcessToken()
        {
            IntPtr processHandle = GetCurrentProcess();
            IntPtr tokenHandle = IntPtr.Zero;
            bool success = OpenProcessToken(processHandle,
                                            TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY,
                                            ref tokenHandle);
            if (success == false)
            {
                int lastError = Marshal.GetLastWin32Error();
                throw new Exception(
                    string.Format("Could not retrieve process token. Error {0}", lastError));
            }
            return tokenHandle;
        }
        #endregion

        #region Функция - обработчик ACE
        public string GetAceInformation(FileSystemAccessRule ace)
        {
            string rights = null;
            rights += string.Format("Группы и пользователи: {0}" + Environment.NewLine, ace.IdentityReference.Value);
            rights += string.Format("Тип: {0}" + Environment.NewLine, ace.AccessControlType);
            rights += string.Format("Права: {0}" + Environment.NewLine, ace.FileSystemRights);
            rights += string.Format("Наследуемые: {0}" + Environment.NewLine + Environment.NewLine, ace.IsInherited);
            return rights;
        }
        #endregion

        #region Владелец файла - оформление
        private void Change_params_Load(object sender, EventArgs e) { }
        private void FileUNC_label_Click(object sender, EventArgs e) { }
        private void CurrentOwner_label_Click(object sender, EventArgs e) { }
        private void NewOwner_label_Click(object sender, EventArgs e){ }
        private void FileUNC_textBox_TextChanged(object sender, EventArgs e) { }
        private void CurrentOwner_textBox_TextChanged(object sender, EventArgs e) { }
        private void NewOwner_textBox_TextChanged(object sender, EventArgs e){ New_Owner = NewOwner_textBox.Text; }
        #endregion

        #region IL - оформление
        public void FileIL_label_Click(object sender, EventArgs e) { }
        public void ILTypes_comboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        #endregion

        #region ACL - оформление
        private void ACL_label_Click(object sender, EventArgs e) { }
        private void AllACL_textBox_TextChanged(object sender, EventArgs e) { AllACL_textBox.ScrollBars = ScrollBars.Vertical; }
        private void TypesACL_label_Click(object sender, EventArgs e) { }
        private void FullControl_label_Click(object sender, EventArgs e) { }
        private void Modify_label_Click(object sender, EventArgs e) { }
        private void RaE_label_Click(object sender, EventArgs e) { }
        private void Read_label_Click(object sender, EventArgs e) { }
        private void Write_label_Click(object sender, EventArgs e) { }
        private void ALLOW_label_Click(object sender, EventArgs e) { }
        private void DENY_label_Click(object sender, EventArgs e) { }
        #endregion

        #region Все возможные разрешения
        private void FullControl_ALLOW_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FullControl_ALLOW_checkBox.Checked)
            {
                FullControl_DENY_checkBox.Checked = false;
                Modify_DENY_checkBox.Checked = false;
                RaE_DENY_checkBox.Checked = false;
                Read_DENY_checkBox.Checked = false;
                Write_DENY_checkBox.Checked = false;
            }
        }
        private void Modify_ALLOW_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Modify_ALLOW_checkBox.Checked)
            {
                FullControl_DENY_checkBox.Checked = false;
                Modify_DENY_checkBox.Checked = false;
                RaE_DENY_checkBox.Checked = false;
                Read_DENY_checkBox.Checked = false;
                Write_DENY_checkBox.Checked = false;
            }
        }
        private void RaE_ALLOW_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RaE_ALLOW_checkBox.Checked)
            {
                FullControl_DENY_checkBox.Checked = false;
                Modify_DENY_checkBox.Checked = false;
                RaE_DENY_checkBox.Checked = false;
                Read_DENY_checkBox.Checked = false;
                Write_DENY_checkBox.Checked = false;
            }
        }
        private void Read_ALLOW_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Read_ALLOW_checkBox.Checked)
            {
                FullControl_DENY_checkBox.Checked = false;
                Modify_DENY_checkBox.Checked = false;
                RaE_DENY_checkBox.Checked = false;
                Read_DENY_checkBox.Checked = false;
                Write_DENY_checkBox.Checked = false;
            }
        }
        private void Write_ALLOW_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Write_ALLOW_checkBox.Checked)
            {
                FullControl_DENY_checkBox.Checked = false;
                Modify_DENY_checkBox.Checked = false;
                RaE_DENY_checkBox.Checked = false;
                Read_DENY_checkBox.Checked = false;
                Write_DENY_checkBox.Checked = false;
            }
        }
        #endregion

        #region Все возможные запреты
        private void FullControl_DENY_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FullControl_DENY_checkBox.Checked)
            {
                FullControl_ALLOW_checkBox.Checked = false;
                Modify_ALLOW_checkBox.Checked = false;
                RaE_ALLOW_checkBox.Checked = false;
                Read_ALLOW_checkBox.Checked = false;
                Write_ALLOW_checkBox.Checked = false;
            }
        }
        private void Modify_DENY_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Modify_DENY_checkBox.Checked)
            {
                FullControl_ALLOW_checkBox.Checked = false;
                Modify_ALLOW_checkBox.Checked = false;
                RaE_ALLOW_checkBox.Checked = false;
                Read_ALLOW_checkBox.Checked = false;
                Write_ALLOW_checkBox.Checked = false;
            }
        }
        private void RaE_DENY_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RaE_DENY_checkBox.Checked)
            {
                FullControl_ALLOW_checkBox.Checked = false;
                Modify_ALLOW_checkBox.Checked = false;
                RaE_ALLOW_checkBox.Checked = false;
                Read_ALLOW_checkBox.Checked = false;
                Write_ALLOW_checkBox.Checked = false;
            }
        }
        private void Read_DENY_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Read_DENY_checkBox.Checked)
            {
                FullControl_ALLOW_checkBox.Checked = false;
                Modify_ALLOW_checkBox.Checked = false;
                RaE_ALLOW_checkBox.Checked = false;
                Read_ALLOW_checkBox.Checked = false;
                Write_ALLOW_checkBox.Checked = false;
            }
        }
        private void Write_DENY_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Write_DENY_checkBox.Checked)
            {
                FullControl_ALLOW_checkBox.Checked = false;
                Modify_ALLOW_checkBox.Checked = false;
                RaE_ALLOW_checkBox.Checked = false;
                Read_ALLOW_checkBox.Checked = false;
                Write_ALLOW_checkBox.Checked = false;
            }
        }
        #endregion

        #region Определение текущего уровня целостности и его вывод в FileIL_label
        public void GetCurrentFileIL()
        {
            IL = GetFileIntegrityLevel(FILE_UNC);
            if (IL == 0)
                FileIL_label.Text = "Текущий уровень целостности:" + Environment.NewLine + "Ненадежный";
            else if (IL == 1)
                FileIL_label.Text = "Текущий уровень целостности:" + Environment.NewLine + "Низкий";
            else if (IL == 2)
                FileIL_label.Text = "Текущий уровень целостности:" + Environment.NewLine + "Средний";
            else if (IL == 3)
                FileIL_label.Text = "Текущий уровень целостности:" + Environment.NewLine + "Высокий";
        }
        #endregion

        #region Кнопка "Открыть файл"
        public void Open_file_button_Click(object sender, EventArgs e)
        {
            bool res = Get_file();
            if (res == true)
            {
                GetCurrentOwner_button_Click(sender, e);
                GetACL_button_Click(sender, e);
                GetCurrentFileIL();
            }
            else { FILE_UNC = null; }
        }
        #endregion

        #region Кнопка "Определить владельца"
        private void GetCurrentOwner_button_Click(object sender, EventArgs e)
        {
            FileUNC_textBox.Clear();
            FileUNC_textBox.Text = FILE_UNC.ToString();
            try
            {
                CurrentOwner_textBox.Clear();
                var File_security = File.GetAccessControl(FILE_UNC);
                var SID = File_security.GetOwner(typeof(SecurityIdentifier));
                var ntAccount = SID.Translate(typeof(NTAccount));
                CurrentOwner_textBox.Text = ntAccount.ToString(); // <домен>\<имя_пользователя>
            }
            catch (Exception err)
            {
                string error_message = "Функция: Текущий владелец файла" + Environment.NewLine +
                                       "Исключение: " + err.Message + Environment.NewLine;

                StreamWriter Log_file = new StreamWriter("Exceptions_LOG.txt", true);
                Log_file.WriteLine(error_message);
                Log_file.Close();
            }
        }
        #endregion

        #region Кнопка "Задать нового владельца"
        private void SetNewOwner_button_Click(object sender, EventArgs e)
        {
            GiveRestorePrivilege();
            try
            {
                var Full_New_Owner = new NTAccount(/*"Home", */NewOwner_textBox.Text.ToString());
                var File_Security = File.GetAccessControl(FILE_UNC);
                File_Security.SetOwner(Full_New_Owner);
                File.SetAccessControl(FILE_UNC, File_Security);
                GetCurrentOwner_button_Click(sender, e);
            }
            catch (Exception err)
            {
                string error_message = "Функция: Установка нового владельца файла" + Environment.NewLine +
                                       "Исключение: " + err.Message + Environment.NewLine;

                StreamWriter Log_file = new StreamWriter("Exceptions_LOG.txt", true);
                Log_file.WriteLine(error_message);
                Log_file.Close();
            }
        }
        #endregion

        #region Кнопка "Определить ACL"
        private void GetACL_button_Click(object sender, EventArgs e)
        {
            try
            {
                AllACL_textBox.Clear();
                string ACE_str = null;
                FileSecurity File_Security = File.GetAccessControl(FILE_UNC);
                AuthorizationRuleCollection ACL = File_Security.GetAccessRules(true, true, typeof(NTAccount));
                foreach (FileSystemAccessRule ACE in ACL)
                {
                    ACE_str = GetAceInformation(ACE);
                    AllACL_textBox.Text += ACE_str;
                }
            }
            catch (Exception err)
            {
                string error_message = "Функция: Считывание ACL" + Environment.NewLine +
                       "Исключение: " + err.Message + Environment.NewLine;

                StreamWriter Log_file = new StreamWriter("Exceptions_LOG.txt", true);
                Log_file.WriteLine(error_message);
                Log_file.Close();
            }
        }
        #endregion

        #region Функция, устанавливающая новые ACE
        public void SETACL(string Username, FileSystemRights Rule, AccessControlType t)
        {
            var t_inv = AccessControlType.Deny;
            if (t_inv == t)
                t_inv = AccessControlType.Allow;
            else { }

            try
            {
                if (true)
                {
                    var accessRule_remove = new FileSystemAccessRule(Username,
                                             fileSystemRights: Rule,
                                             inheritanceFlags: InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                             propagationFlags: PropagationFlags.None,
                                             type: t_inv);

                    var directoryInfo_remove = new DirectoryInfo(FILE_UNC);

                    DirectorySecurity dSecurity_remove = directoryInfo_remove.GetAccessControl();
                    dSecurity_remove.RemoveAccessRule(accessRule_remove);
                    directoryInfo_remove.SetAccessControl(dSecurity_remove);
                }

                var accessRule = new FileSystemAccessRule(Username,
                                     fileSystemRights: Rule,
                                     inheritanceFlags: InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                     propagationFlags: PropagationFlags.None,
                                     type: t);

                var directoryInfo = new DirectoryInfo(FILE_UNC);

                DirectorySecurity dSecurity = directoryInfo.GetAccessControl();
                dSecurity.AddAccessRule(accessRule);
                directoryInfo.SetAccessControl(dSecurity);
            }
            catch (Exception err)
            {
                string error_message = "Функция: Установка ACL" + Environment.NewLine +
                                       "Исключение: " + err.Message + Environment.NewLine;

                StreamWriter Log_file = new StreamWriter("Exceptions_LOG.txt", true);
                Log_file.WriteLine(error_message);
                Log_file.Close();
            }
        }
        #endregion

        #region Кнопка "Добавить права"
        private void AddACE_button_Click(object sender, EventArgs e)
        {
            string User = NewOwner_textBox.Text;

            var RequiredRule_0 = FileSystemRights.ReadData;
            var RequiredRule_1 = FileSystemRights.ReadData;

            var Type_0 = AccessControlType.Deny;
            var Type_1 = AccessControlType.Deny;

            //RSPACL(User, FileSystemRights.ChangePermissions, AccessControlType.Allow);
            //RSPACL(User, FileSystemRights.ChangePermissions, AccessControlType.Deny);

            //RSPACL(User, FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Allow);
            //RSPACL(User, FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Deny);

            //RSPACL(User, FileSystemRights.TakeOwnership, AccessControlType.Allow);
            //RSPACL(User, FileSystemRights.TakeOwnership, AccessControlType.Deny);

            //RSPACL(User, FileSystemRights.Synchronize, AccessControlType.Allow);
            //RSPACL(User, FileSystemRights.Synchronize, AccessControlType.Deny);

            if ((FullControl_ALLOW_checkBox.Checked) &&
                (!FullControl_DENY_checkBox.Checked && !Modify_DENY_checkBox.Checked && !RaE_DENY_checkBox.Checked &&
                 !Read_DENY_checkBox.Checked && !Write_DENY_checkBox.Checked))
            {
                RequiredRule_0 = FileSystemRights.FullControl;
                Type_0 = AccessControlType.Allow;
                SETACL(User, RequiredRule_0, Type_0);
            }
            
            else if ((Modify_ALLOW_checkBox.Checked) &&
                     (!FullControl_DENY_checkBox.Checked && !Modify_DENY_checkBox.Checked && !RaE_DENY_checkBox.Checked &&
                      !Read_DENY_checkBox.Checked && !Write_DENY_checkBox.Checked))
            {
                RequiredRule_0 = FileSystemRights.Modify;
                Type_0 = AccessControlType.Allow;
                SETACL(User, RequiredRule_0, Type_0);
            }

            else if ((RaE_ALLOW_checkBox.Checked) &&
                     (!FullControl_DENY_checkBox.Checked && !Modify_DENY_checkBox.Checked && !RaE_DENY_checkBox.Checked &&
                      !Read_DENY_checkBox.Checked && !Write_DENY_checkBox.Checked))
            {
                RequiredRule_0 = FileSystemRights.ReadAndExecute;
                Type_0 = AccessControlType.Allow;
                SETACL(User, RequiredRule_0, Type_0);
            }

            else if ((Read_ALLOW_checkBox.Checked) &&
                     (!FullControl_DENY_checkBox.Checked && !Modify_DENY_checkBox.Checked && !RaE_DENY_checkBox.Checked &&
                      !Read_DENY_checkBox.Checked && !Write_DENY_checkBox.Checked))
            {
                RequiredRule_0 = FileSystemRights.Read;
                Type_0 = AccessControlType.Allow;
                SETACL(User, RequiredRule_0, Type_0);
            }

            else if ((Write_ALLOW_checkBox.Checked) &&
                     (!FullControl_DENY_checkBox.Checked && !Modify_DENY_checkBox.Checked && !RaE_DENY_checkBox.Checked &&
                      !Read_DENY_checkBox.Checked && !Write_DENY_checkBox.Checked))
            {
                RequiredRule_0 = FileSystemRights.Write;
                Type_0 = AccessControlType.Allow;
                SETACL(User, RequiredRule_0, Type_0);
            }

            else if ((FullControl_DENY_checkBox.Checked) &&
                (!FullControl_ALLOW_checkBox.Checked && !Modify_ALLOW_checkBox.Checked && !RaE_ALLOW_checkBox.Checked &&
                 !Read_ALLOW_checkBox.Checked && !Write_ALLOW_checkBox.Checked))
            {
                RequiredRule_1 = FileSystemRights.FullControl;
                Type_1 = AccessControlType.Deny;
                SETACL(User, RequiredRule_1, Type_1);
            }

            else if ((Modify_DENY_checkBox.Checked) &&
                     (!FullControl_ALLOW_checkBox.Checked && !Modify_ALLOW_checkBox.Checked && !RaE_ALLOW_checkBox.Checked &&
                      !Read_ALLOW_checkBox.Checked && !Write_ALLOW_checkBox.Checked))
            {
                RequiredRule_1 = FileSystemRights.Modify;
                Type_1 = AccessControlType.Deny;
                SETACL(User, RequiredRule_1, Type_1);
            }

            else if ((RaE_DENY_checkBox.Checked) &&
                     (!FullControl_ALLOW_checkBox.Checked && !Modify_ALLOW_checkBox.Checked && !RaE_ALLOW_checkBox.Checked &&
                      !Read_ALLOW_checkBox.Checked && !Write_ALLOW_checkBox.Checked))
            {
                RequiredRule_1 = FileSystemRights.ReadAndExecute;
                Type_1 = AccessControlType.Deny;
                SETACL(User, RequiredRule_1, Type_1);
            }

            else if ((Read_DENY_checkBox.Checked) &&
                    (!FullControl_ALLOW_checkBox.Checked && !Modify_ALLOW_checkBox.Checked && !RaE_ALLOW_checkBox.Checked &&
                     !Read_ALLOW_checkBox.Checked && !Write_ALLOW_checkBox.Checked))
            {
                RequiredRule_1 = FileSystemRights.Read;
                Type_1 = AccessControlType.Deny;
                SETACL(User, RequiredRule_1, Type_1);
            }

            else if ((Write_DENY_checkBox.Checked) &&
                     (!FullControl_ALLOW_checkBox.Checked && !Modify_ALLOW_checkBox.Checked && !RaE_ALLOW_checkBox.Checked &&
                      !Read_ALLOW_checkBox.Checked && !Write_ALLOW_checkBox.Checked))
            {
                RequiredRule_1 = FileSystemRights.Write;
                Type_1 = AccessControlType.Deny;
                SETACL(User, RequiredRule_1, Type_1);
            }
        }
        #endregion

        #region Кнопка "Изменить уровень целостности"
        private void ChangeIL_button_Click(object sender, EventArgs e)
        {
            string IntLev = ILTypes_comboBox.Text;
            if (IntLev == "Низкий")
                SetFileIntegrityLevel(0, FILE_UNC);
            else if (IntLev == "Средний")
                SetFileIntegrityLevel(1, FILE_UNC);
            else if (IntLev == "Высокий")
                SetFileIntegrityLevel(2, FILE_UNC);

            GetCurrentFileIL();
        }
        #endregion

        //public void RSPACL(string Username, FileSystemRights Rule, AccessControlType t)
        //{
        //    try
        //    {
        //        var accessRule = new FileSystemAccessRule(Username,
        //                             Rule,
        //                             inheritanceFlags: InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
        //                             propagationFlags: PropagationFlags.None,
        //                             type: t);

        //        var directoryInfo = new DirectoryInfo(FILE_UNC);
        //        DirectorySecurity dSecurity = directoryInfo.GetAccessControl();
        //        dSecurity.RemoveAccessRule(accessRule);
        //        directoryInfo.SetAccessControl(dSecurity);
        //    }
        //    catch (Exception err)
        //    {
        //        string error_message = "Функция: RSPACL" + Environment.NewLine +
        //                               "Исключение: " + err.Message + Environment.NewLine;

        //        StreamWriter Log_file = new StreamWriter("Exceptions_LOG.txt", true);
        //        Log_file.WriteLine(error_message);
        //        Log_file.Close();
        //    }
        //}
    }
}