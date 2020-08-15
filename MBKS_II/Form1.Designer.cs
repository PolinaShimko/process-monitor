namespace MBKS_II
{
    partial class MBKSII
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Print_data_button = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.DataGridView();
            this.DLLBox = new System.Windows.Forms.TextBox();
            this.Change_window_button = new System.Windows.Forms.Button();
            this.ID_label = new System.Windows.Forms.Label();
            this.Privelegeslabel = new System.Windows.Forms.Label();
            this.Priveleges_dataGridView = new System.Windows.Forms.DataGridView();
            this.Priv_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priv_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangePrivileges_button = new System.Windows.Forms.Button();
            this.Privilege_comboBox = new System.Windows.Forms.ComboBox();
            this.State_comboBox = new System.Windows.Forms.ComboBox();
            this.Privilege_label = new System.Windows.Forms.Label();
            this.Status_label = new System.Windows.Forms.Label();
            this.ProcessIL_label = new System.Windows.Forms.Label();
            this.ProcessIL_comboBox = new System.Windows.Forms.ComboBox();
            this.ChangeProcessIL_button = new System.Windows.Forms.Button();
            this.Номер = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Имя = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parent_process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parent_process_PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_name_SID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Using_DEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usind_ASLR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Priveleges_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Print_data_button
            // 
            this.Print_data_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Print_data_button.Location = new System.Drawing.Point(1118, 654);
            this.Print_data_button.Name = "Print_data_button";
            this.Print_data_button.Size = new System.Drawing.Size(120, 30);
            this.Print_data_button.TabIndex = 3;
            this.Print_data_button.Text = "Обновить";
            this.Print_data_button.UseVisualStyleBackColor = true;
            this.Print_data_button.Click += new System.EventHandler(this.Refresh_button_Click);
            // 
            // Table
            // 
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Номер,
            this.Имя,
            this.PID,
            this.Exec,
            this.Parent_process,
            this.Parent_process_PID,
            this.User_name,
            this.User_name_SID,
            this.Column1,
            this.Using_DEP,
            this.Usind_ASLR,
            this.IL,
            this.Priority,
            this.Exception});
            this.Table.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Table.Location = new System.Drawing.Point(12, 12);
            this.Table.Name = "Table";
            this.Table.RowTemplate.Height = 24;
            this.Table.Size = new System.Drawing.Size(1391, 281);
            this.Table.TabIndex = 4;
            this.Table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellClick);
            this.Table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellContentClick_1);
            // 
            // DLLBox
            // 
            this.DLLBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DLLBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DLLBox.Location = new System.Drawing.Point(12, 339);
            this.DLLBox.Multiline = true;
            this.DLLBox.Name = "DLLBox";
            this.DLLBox.Size = new System.Drawing.Size(485, 345);
            this.DLLBox.TabIndex = 8;
            this.DLLBox.TextChanged += new System.EventHandler(this.DLLBox_TextChanged);
            // 
            // Change_window_button
            // 
            this.Change_window_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Change_window_button.Location = new System.Drawing.Point(1244, 632);
            this.Change_window_button.Name = "Change_window_button";
            this.Change_window_button.Size = new System.Drawing.Size(159, 52);
            this.Change_window_button.TabIndex = 16;
            this.Change_window_button.Text = "Окно объектов (файлов)";
            this.Change_window_button.UseVisualStyleBackColor = true;
            this.Change_window_button.Click += new System.EventHandler(this.Change_window_button_Click);
            // 
            // ID_label
            // 
            this.ID_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ID_label.AutoSize = true;
            this.ID_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ID_label.Location = new System.Drawing.Point(12, 309);
            this.ID_label.Name = "ID_label";
            this.ID_label.Size = new System.Drawing.Size(263, 20);
            this.ID_label.TabIndex = 5;
            this.ID_label.Text = "Используемые процессом DLL";
            this.ID_label.Click += new System.EventHandler(this.DLLList_label_Click);
            // 
            // Privelegeslabel
            // 
            this.Privelegeslabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Privelegeslabel.AutoSize = true;
            this.Privelegeslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Privelegeslabel.Location = new System.Drawing.Point(516, 309);
            this.Privelegeslabel.Name = "Privelegeslabel";
            this.Privelegeslabel.Size = new System.Drawing.Size(193, 20);
            this.Privelegeslabel.TabIndex = 17;
            this.Privelegeslabel.Text = "Привилегии процесса";
            this.Privelegeslabel.Click += new System.EventHandler(this.Privilegeslabel_Click);
            // 
            // Priveleges_dataGridView
            // 
            this.Priveleges_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Priveleges_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Priveleges_dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Priveleges_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Priveleges_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Priv_name,
            this.Priv_status});
            this.Priveleges_dataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Priveleges_dataGridView.Location = new System.Drawing.Point(520, 339);
            this.Priveleges_dataGridView.Name = "Priveleges_dataGridView";
            this.Priveleges_dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Priveleges_dataGridView.RowTemplate.Height = 24;
            this.Priveleges_dataGridView.Size = new System.Drawing.Size(418, 345);
            this.Priveleges_dataGridView.TabIndex = 18;
            this.Priveleges_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Privileges_dataGridView_CellContentClick);
            // 
            // Priv_name
            // 
            this.Priv_name.HeaderText = "Имя привелегии";
            this.Priv_name.Name = "Priv_name";
            // 
            // Priv_status
            // 
            this.Priv_status.HeaderText = "Статус";
            this.Priv_status.Name = "Priv_status";
            // 
            // ChangePrivileges_button
            // 
            this.ChangePrivileges_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangePrivileges_button.Location = new System.Drawing.Point(953, 369);
            this.ChangePrivileges_button.Name = "ChangePrivileges_button";
            this.ChangePrivileges_button.Size = new System.Drawing.Size(248, 49);
            this.ChangePrivileges_button.TabIndex = 19;
            this.ChangePrivileges_button.Text = "Изменить привелегии";
            this.ChangePrivileges_button.UseVisualStyleBackColor = true;
            this.ChangePrivileges_button.Click += new System.EventHandler(this.ChangePrivileges_button_Click);
            // 
            // Privilege_comboBox
            // 
            this.Privilege_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Privilege_comboBox.FormattingEnabled = true;
            this.Privilege_comboBox.Items.AddRange(new object[] {
            "AssignPrimaryToken",
            "Audit",
            "Backup",
            "ChangeNotify",
            "CreateGlobal",
            "CreatePageFile,",
            "CreatePermanent",
            "CreateSymbolicLink",
            "CreateToken",
            "Debug",
            "EnableDelegation",
            "Impersonate",
            "IncreaseBasePriority",
            "IncreaseQuota",
            "IncreaseWorkingSet",
            "LoadDriver",
            "LockMemory",
            "MachineAccount",
            "ManageVolume",
            "ProfileSingleProcess",
            "Relabel",
            "RemoteShutdown",
            "Restore",
            "Security",
            "Shutdown",
            "SyncAgent",
            "SystemEnvironment",
            "SystemProfile",
            "SystemTime",
            "TakeOwnership",
            "TrustedComputerBase",
            "TimeZone",
            "TrustedCredentialManagerAccess",
            "Undock",
            "UnsolicitedInput"});
            this.Privilege_comboBox.Location = new System.Drawing.Point(953, 339);
            this.Privilege_comboBox.Name = "Privilege_comboBox";
            this.Privilege_comboBox.Size = new System.Drawing.Size(121, 24);
            this.Privilege_comboBox.TabIndex = 20;
            this.Privilege_comboBox.SelectedIndexChanged += new System.EventHandler(this.Privilege_comboBox_SelectedIndexChanged);
            // 
            // State_comboBox
            // 
            this.State_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.State_comboBox.FormattingEnabled = true;
            this.State_comboBox.Items.AddRange(new object[] {
            "Disabled",
            "Enabled",
            "Removed"});
            this.State_comboBox.Location = new System.Drawing.Point(1080, 339);
            this.State_comboBox.Name = "State_comboBox";
            this.State_comboBox.Size = new System.Drawing.Size(121, 24);
            this.State_comboBox.TabIndex = 21;
            this.State_comboBox.SelectedIndexChanged += new System.EventHandler(this.State_comboBox_SelectedIndexChanged);
            // 
            // Privilege_label
            // 
            this.Privilege_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Privilege_label.AutoSize = true;
            this.Privilege_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Privilege_label.Location = new System.Drawing.Point(949, 309);
            this.Privilege_label.Name = "Privilege_label";
            this.Privilege_label.Size = new System.Drawing.Size(110, 20);
            this.Privilege_label.TabIndex = 22;
            this.Privilege_label.Text = "Привилегия";
            this.Privilege_label.Click += new System.EventHandler(this.Privilege_label_Click);
            // 
            // Status_label
            // 
            this.Status_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Status_label.AutoSize = true;
            this.Status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Status_label.Location = new System.Drawing.Point(1081, 309);
            this.Status_label.Name = "Status_label";
            this.Status_label.Size = new System.Drawing.Size(68, 20);
            this.Status_label.TabIndex = 23;
            this.Status_label.Text = "Статус";
            this.Status_label.Click += new System.EventHandler(this.Status_label_Click);
            // 
            // ProcessIL_label
            // 
            this.ProcessIL_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessIL_label.AutoSize = true;
            this.ProcessIL_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProcessIL_label.Location = new System.Drawing.Point(1203, 309);
            this.ProcessIL_label.Name = "ProcessIL_label";
            this.ProcessIL_label.Size = new System.Drawing.Size(193, 20);
            this.ProcessIL_label.TabIndex = 24;
            this.ProcessIL_label.Text = "Уровень целостности";
            // 
            // ProcessIL_comboBox
            // 
            this.ProcessIL_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessIL_comboBox.FormattingEnabled = true;
            this.ProcessIL_comboBox.Items.AddRange(new object[] {
            "Ненадежный",
            "Низкий",
            "Средний"});
            this.ProcessIL_comboBox.Location = new System.Drawing.Point(1207, 339);
            this.ProcessIL_comboBox.Name = "ProcessIL_comboBox";
            this.ProcessIL_comboBox.Size = new System.Drawing.Size(189, 24);
            this.ProcessIL_comboBox.TabIndex = 25;
            this.ProcessIL_comboBox.SelectedIndexChanged += new System.EventHandler(this.ProcessIL_comboBox_SelectedIndexChanged);
            // 
            // ChangeProcessIL_button
            // 
            this.ChangeProcessIL_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeProcessIL_button.Location = new System.Drawing.Point(1207, 369);
            this.ChangeProcessIL_button.Name = "ChangeProcessIL_button";
            this.ChangeProcessIL_button.Size = new System.Drawing.Size(195, 49);
            this.ChangeProcessIL_button.TabIndex = 26;
            this.ChangeProcessIL_button.Text = "Изменить уровень целостности";
            this.ChangeProcessIL_button.UseVisualStyleBackColor = true;
            this.ChangeProcessIL_button.Click += new System.EventHandler(this.ChangeProcessIL_button_Click);
            // 
            // Номер
            // 
            this.Номер.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Номер.HeaderText = "Номер";
            this.Номер.Name = "Номер";
            this.Номер.Width = 80;
            // 
            // Имя
            // 
            this.Имя.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Имя.HeaderText = "Имя процесса";
            this.Имя.Name = "Имя";
            this.Имя.Width = 130;
            // 
            // PID
            // 
            this.PID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PID.HeaderText = "ID";
            this.PID.Name = "PID";
            this.PID.Width = 50;
            // 
            // Exec
            // 
            this.Exec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Exec.HeaderText = "Исполняемый файл";
            this.Exec.Name = "Exec";
            this.Exec.Width = 154;
            // 
            // Parent_process
            // 
            this.Parent_process.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Parent_process.HeaderText = "Родительский процесс";
            this.Parent_process.Name = "Parent_process";
            this.Parent_process.Width = 172;
            // 
            // Parent_process_PID
            // 
            this.Parent_process_PID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Parent_process_PID.HeaderText = "ID родительского процесса";
            this.Parent_process_PID.Name = "Parent_process_PID";
            this.Parent_process_PID.Width = 198;
            // 
            // User_name
            // 
            this.User_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.User_name.HeaderText = "Имя пользователя владельца процесса";
            this.User_name.Name = "User_name";
            this.User_name.Width = 217;
            // 
            // User_name_SID
            // 
            this.User_name_SID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.User_name_SID.HeaderText = "SID пользователя владельца процесса";
            this.User_name_SID.Name = "User_name_SID";
            this.User_name_SID.Width = 212;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Тип процесса";
            this.Column1.Name = "Column1";
            this.Column1.Width = 118;
            // 
            // Using_DEP
            // 
            this.Using_DEP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Using_DEP.HeaderText = "Использование DEP";
            this.Using_DEP.Name = "Using_DEP";
            this.Using_DEP.Width = 156;
            // 
            // Usind_ASLR
            // 
            this.Usind_ASLR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Usind_ASLR.HeaderText = "Использование ASLR";
            this.Usind_ASLR.Name = "Usind_ASLR";
            this.Usind_ASLR.Width = 163;
            // 
            // IL
            // 
            this.IL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IL.HeaderText = "Уровень целостности";
            this.IL.Name = "IL";
            this.IL.Width = 164;
            // 
            // Priority
            // 
            this.Priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Priority.HeaderText = "Приоритет";
            this.Priority.Name = "Priority";
            this.Priority.Width = 109;
            // 
            // Exception
            // 
            this.Exception.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Exception.HeaderText = "Исключение";
            this.Exception.Name = "Exception";
            this.Exception.Width = 119;
            // 
            // MBKSII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1415, 696);
            this.Controls.Add(this.ChangeProcessIL_button);
            this.Controls.Add(this.ProcessIL_comboBox);
            this.Controls.Add(this.ProcessIL_label);
            this.Controls.Add(this.Status_label);
            this.Controls.Add(this.Privilege_label);
            this.Controls.Add(this.State_comboBox);
            this.Controls.Add(this.Privilege_comboBox);
            this.Controls.Add(this.ChangePrivileges_button);
            this.Controls.Add(this.Priveleges_dataGridView);
            this.Controls.Add(this.Privelegeslabel);
            this.Controls.Add(this.Change_window_button);
            this.Controls.Add(this.DLLBox);
            this.Controls.Add(this.ID_label);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.Print_data_button);
            this.MinimumSize = new System.Drawing.Size(1433, 743);
            this.Name = "MBKSII";
            this.Text = "ПРОЦЕССЫ";
            this.Load += new System.EventHandler(this.MBKSII_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Priveleges_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Print_data_button;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.TextBox DLLBox;
        private System.Windows.Forms.Button Change_window_button;
        private System.Windows.Forms.Label ID_label;
        private System.Windows.Forms.Label Privelegeslabel;
        private System.Windows.Forms.DataGridView Priveleges_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priv_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priv_status;
        private System.Windows.Forms.Button ChangePrivileges_button;
        private System.Windows.Forms.ComboBox Privilege_comboBox;
        private System.Windows.Forms.ComboBox State_comboBox;
        private System.Windows.Forms.Label Privilege_label;
        private System.Windows.Forms.Label Status_label;
        private System.Windows.Forms.Label ProcessIL_label;
        private System.Windows.Forms.ComboBox ProcessIL_comboBox;
        private System.Windows.Forms.Button ChangeProcessIL_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер;
        private System.Windows.Forms.DataGridViewTextBoxColumn Имя;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parent_process;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parent_process_PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_name_SID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Using_DEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usind_ASLR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exception;
    }
}

