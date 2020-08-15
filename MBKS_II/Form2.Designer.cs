namespace MBKS_II
{
    partial class Change_params
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileUNC_label = new System.Windows.Forms.Label();
            this.CurrentOwner_label = new System.Windows.Forms.Label();
            this.CurrentOwner_textBox = new System.Windows.Forms.TextBox();
            this.NewOwner_label = new System.Windows.Forms.Label();
            this.NewOwner_textBox = new System.Windows.Forms.TextBox();
            this.GetCurrentOwner_button = new System.Windows.Forms.Button();
            this.SetNewOwner_button = new System.Windows.Forms.Button();
            this.FileUNC_textBox = new System.Windows.Forms.TextBox();
            this.Open_file_button = new System.Windows.Forms.Button();
            this.ACL_label = new System.Windows.Forms.Label();
            this.AllACL_textBox = new System.Windows.Forms.TextBox();
            this.GetACL_button = new System.Windows.Forms.Button();
            this.TypesACL_label = new System.Windows.Forms.Label();
            this.FullControl_label = new System.Windows.Forms.Label();
            this.Modify_label = new System.Windows.Forms.Label();
            this.RaE_label = new System.Windows.Forms.Label();
            this.Read_label = new System.Windows.Forms.Label();
            this.Write_label = new System.Windows.Forms.Label();
            this.FullControl_ALLOW_checkBox = new System.Windows.Forms.CheckBox();
            this.Modify_ALLOW_checkBox = new System.Windows.Forms.CheckBox();
            this.RaE_ALLOW_checkBox = new System.Windows.Forms.CheckBox();
            this.Read_ALLOW_checkBox = new System.Windows.Forms.CheckBox();
            this.Write_ALLOW_checkBox = new System.Windows.Forms.CheckBox();
            this.ALLOW_label = new System.Windows.Forms.Label();
            this.DENY_label = new System.Windows.Forms.Label();
            this.Write_DENY_checkBox = new System.Windows.Forms.CheckBox();
            this.Read_DENY_checkBox = new System.Windows.Forms.CheckBox();
            this.RaE_DENY_checkBox = new System.Windows.Forms.CheckBox();
            this.Modify_DENY_checkBox = new System.Windows.Forms.CheckBox();
            this.FullControl_DENY_checkBox = new System.Windows.Forms.CheckBox();
            this.AddACE_button = new System.Windows.Forms.Button();
            this.FileIL_label = new System.Windows.Forms.Label();
            this.ILTypes_comboBox = new System.Windows.Forms.ComboBox();
            this.ChangeIL_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileUNC_label
            // 
            this.FileUNC_label.AutoSize = true;
            this.FileUNC_label.Location = new System.Drawing.Point(12, 64);
            this.FileUNC_label.Name = "FileUNC_label";
            this.FileUNC_label.Size = new System.Drawing.Size(156, 17);
            this.FileUNC_label.TabIndex = 8;
            this.FileUNC_label.Text = "Расположение файла:";
            this.FileUNC_label.Click += new System.EventHandler(this.FileUNC_label_Click);
            // 
            // CurrentOwner_label
            // 
            this.CurrentOwner_label.AutoSize = true;
            this.CurrentOwner_label.Location = new System.Drawing.Point(12, 98);
            this.CurrentOwner_label.Name = "CurrentOwner_label";
            this.CurrentOwner_label.Size = new System.Drawing.Size(137, 17);
            this.CurrentOwner_label.TabIndex = 10;
            this.CurrentOwner_label.Text = "Текущий владелец:";
            this.CurrentOwner_label.Click += new System.EventHandler(this.CurrentOwner_label_Click);
            // 
            // CurrentOwner_textBox
            // 
            this.CurrentOwner_textBox.Location = new System.Drawing.Point(188, 95);
            this.CurrentOwner_textBox.Name = "CurrentOwner_textBox";
            this.CurrentOwner_textBox.Size = new System.Drawing.Size(244, 22);
            this.CurrentOwner_textBox.TabIndex = 11;
            this.CurrentOwner_textBox.TextChanged += new System.EventHandler(this.CurrentOwner_textBox_TextChanged);
            // 
            // NewOwner_label
            // 
            this.NewOwner_label.AutoSize = true;
            this.NewOwner_label.Location = new System.Drawing.Point(12, 131);
            this.NewOwner_label.Name = "NewOwner_label";
            this.NewOwner_label.Size = new System.Drawing.Size(161, 17);
            this.NewOwner_label.TabIndex = 12;
            this.NewOwner_label.Text = "Имя нового владельца:";
            this.NewOwner_label.Click += new System.EventHandler(this.NewOwner_label_Click);
            // 
            // NewOwner_textBox
            // 
            this.NewOwner_textBox.Location = new System.Drawing.Point(188, 128);
            this.NewOwner_textBox.Name = "NewOwner_textBox";
            this.NewOwner_textBox.Size = new System.Drawing.Size(244, 22);
            this.NewOwner_textBox.TabIndex = 13;
            this.NewOwner_textBox.TextChanged += new System.EventHandler(this.NewOwner_textBox_TextChanged);
            // 
            // GetCurrentOwner_button
            // 
            this.GetCurrentOwner_button.Location = new System.Drawing.Point(12, 174);
            this.GetCurrentOwner_button.Name = "GetCurrentOwner_button";
            this.GetCurrentOwner_button.Size = new System.Drawing.Size(192, 34);
            this.GetCurrentOwner_button.TabIndex = 14;
            this.GetCurrentOwner_button.Text = "Определить владельца";
            this.GetCurrentOwner_button.UseVisualStyleBackColor = true;
            this.GetCurrentOwner_button.Click += new System.EventHandler(this.GetCurrentOwner_button_Click);
            // 
            // SetNewOwner_button
            // 
            this.SetNewOwner_button.Location = new System.Drawing.Point(240, 174);
            this.SetNewOwner_button.Name = "SetNewOwner_button";
            this.SetNewOwner_button.Size = new System.Drawing.Size(192, 34);
            this.SetNewOwner_button.TabIndex = 15;
            this.SetNewOwner_button.Text = "Задать нового владельца";
            this.SetNewOwner_button.UseVisualStyleBackColor = true;
            this.SetNewOwner_button.Click += new System.EventHandler(this.SetNewOwner_button_Click);
            // 
            // FileUNC_textBox
            // 
            this.FileUNC_textBox.Location = new System.Drawing.Point(188, 64);
            this.FileUNC_textBox.Name = "FileUNC_textBox";
            this.FileUNC_textBox.Size = new System.Drawing.Size(244, 22);
            this.FileUNC_textBox.TabIndex = 9;
            this.FileUNC_textBox.TextChanged += new System.EventHandler(this.FileUNC_textBox_TextChanged);
            // 
            // Open_file_button
            // 
            this.Open_file_button.Location = new System.Drawing.Point(12, 12);
            this.Open_file_button.Name = "Open_file_button";
            this.Open_file_button.Size = new System.Drawing.Size(422, 37);
            this.Open_file_button.TabIndex = 16;
            this.Open_file_button.Text = "Открыть файл";
            this.Open_file_button.UseVisualStyleBackColor = true;
            this.Open_file_button.Click += new System.EventHandler(this.Open_file_button_Click);
            // 
            // ACL_label
            // 
            this.ACL_label.AutoSize = true;
            this.ACL_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ACL_label.Location = new System.Drawing.Point(440, 15);
            this.ACL_label.Name = "ACL_label";
            this.ACL_label.Size = new System.Drawing.Size(279, 26);
            this.ACL_label.TabIndex = 17;
            this.ACL_label.Text = "Списки контроля доступа:";
            this.ACL_label.Click += new System.EventHandler(this.ACL_label_Click);
            // 
            // AllACL_textBox
            // 
            this.AllACL_textBox.Location = new System.Drawing.Point(445, 63);
            this.AllACL_textBox.Multiline = true;
            this.AllACL_textBox.Name = "AllACL_textBox";
            this.AllACL_textBox.Size = new System.Drawing.Size(499, 255);
            this.AllACL_textBox.TabIndex = 18;
            this.AllACL_textBox.TextChanged += new System.EventHandler(this.AllACL_textBox_TextChanged);
            // 
            // GetACL_button
            // 
            this.GetACL_button.Location = new System.Drawing.Point(445, 334);
            this.GetACL_button.Name = "GetACL_button";
            this.GetACL_button.Size = new System.Drawing.Size(192, 30);
            this.GetACL_button.TabIndex = 19;
            this.GetACL_button.Text = "Определить ACL";
            this.GetACL_button.UseVisualStyleBackColor = true;
            this.GetACL_button.Click += new System.EventHandler(this.GetACL_button_Click);
            // 
            // TypesACL_label
            // 
            this.TypesACL_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TypesACL_label.AutoSize = true;
            this.TypesACL_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypesACL_label.Location = new System.Drawing.Point(984, 14);
            this.TypesACL_label.Name = "TypesACL_label";
            this.TypesACL_label.Size = new System.Drawing.Size(209, 26);
            this.TypesACL_label.TabIndex = 20;
            this.TypesACL_label.Text = "Виды прав доступа";
            this.TypesACL_label.Click += new System.EventHandler(this.TypesACL_label_Click);
            // 
            // FullControl_label
            // 
            this.FullControl_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FullControl_label.AutoSize = true;
            this.FullControl_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullControl_label.Location = new System.Drawing.Point(984, 83);
            this.FullControl_label.Name = "FullControl_label";
            this.FullControl_label.Size = new System.Drawing.Size(116, 18);
            this.FullControl_label.TabIndex = 21;
            this.FullControl_label.Text = "Полный доступ";
            this.FullControl_label.Click += new System.EventHandler(this.FullControl_label_Click);
            // 
            // Modify_label
            // 
            this.Modify_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Modify_label.AutoSize = true;
            this.Modify_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Modify_label.Location = new System.Drawing.Point(984, 116);
            this.Modify_label.Name = "Modify_label";
            this.Modify_label.Size = new System.Drawing.Size(86, 18);
            this.Modify_label.TabIndex = 22;
            this.Modify_label.Text = "Изменение";
            this.Modify_label.Click += new System.EventHandler(this.Modify_label_Click);
            // 
            // RaE_label
            // 
            this.RaE_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RaE_label.AutoSize = true;
            this.RaE_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RaE_label.Location = new System.Drawing.Point(984, 149);
            this.RaE_label.Name = "RaE_label";
            this.RaE_label.Size = new System.Drawing.Size(158, 18);
            this.RaE_label.TabIndex = 23;
            this.RaE_label.Text = "Чтение и выполнение";
            this.RaE_label.Click += new System.EventHandler(this.RaE_label_Click);
            // 
            // Read_label
            // 
            this.Read_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Read_label.AutoSize = true;
            this.Read_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Read_label.Location = new System.Drawing.Point(984, 182);
            this.Read_label.Name = "Read_label";
            this.Read_label.Size = new System.Drawing.Size(57, 18);
            this.Read_label.TabIndex = 24;
            this.Read_label.Text = "Чтение";
            this.Read_label.Click += new System.EventHandler(this.Read_label_Click);
            // 
            // Write_label
            // 
            this.Write_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Write_label.AutoSize = true;
            this.Write_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Write_label.Location = new System.Drawing.Point(984, 215);
            this.Write_label.Name = "Write_label";
            this.Write_label.Size = new System.Drawing.Size(58, 18);
            this.Write_label.TabIndex = 25;
            this.Write_label.Text = "Запись";
            this.Write_label.Click += new System.EventHandler(this.Write_label_Click);
            // 
            // FullControl_ALLOW_checkBox
            // 
            this.FullControl_ALLOW_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FullControl_ALLOW_checkBox.AutoSize = true;
            this.FullControl_ALLOW_checkBox.Location = new System.Drawing.Point(1154, 84);
            this.FullControl_ALLOW_checkBox.Name = "FullControl_ALLOW_checkBox";
            this.FullControl_ALLOW_checkBox.Size = new System.Drawing.Size(18, 17);
            this.FullControl_ALLOW_checkBox.TabIndex = 26;
            this.FullControl_ALLOW_checkBox.UseVisualStyleBackColor = true;
            this.FullControl_ALLOW_checkBox.CheckedChanged += new System.EventHandler(this.FullControl_ALLOW_checkBox_CheckedChanged);
            // 
            // Modify_ALLOW_checkBox
            // 
            this.Modify_ALLOW_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Modify_ALLOW_checkBox.AutoSize = true;
            this.Modify_ALLOW_checkBox.Location = new System.Drawing.Point(1154, 116);
            this.Modify_ALLOW_checkBox.Name = "Modify_ALLOW_checkBox";
            this.Modify_ALLOW_checkBox.Size = new System.Drawing.Size(18, 17);
            this.Modify_ALLOW_checkBox.TabIndex = 27;
            this.Modify_ALLOW_checkBox.UseVisualStyleBackColor = true;
            this.Modify_ALLOW_checkBox.CheckedChanged += new System.EventHandler(this.Modify_ALLOW_checkBox_CheckedChanged);
            // 
            // RaE_ALLOW_checkBox
            // 
            this.RaE_ALLOW_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RaE_ALLOW_checkBox.AutoSize = true;
            this.RaE_ALLOW_checkBox.Location = new System.Drawing.Point(1154, 149);
            this.RaE_ALLOW_checkBox.Name = "RaE_ALLOW_checkBox";
            this.RaE_ALLOW_checkBox.Size = new System.Drawing.Size(18, 17);
            this.RaE_ALLOW_checkBox.TabIndex = 28;
            this.RaE_ALLOW_checkBox.UseVisualStyleBackColor = true;
            this.RaE_ALLOW_checkBox.CheckedChanged += new System.EventHandler(this.RaE_ALLOW_checkBox_CheckedChanged);
            // 
            // Read_ALLOW_checkBox
            // 
            this.Read_ALLOW_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Read_ALLOW_checkBox.AutoSize = true;
            this.Read_ALLOW_checkBox.Location = new System.Drawing.Point(1154, 182);
            this.Read_ALLOW_checkBox.Name = "Read_ALLOW_checkBox";
            this.Read_ALLOW_checkBox.Size = new System.Drawing.Size(18, 17);
            this.Read_ALLOW_checkBox.TabIndex = 29;
            this.Read_ALLOW_checkBox.UseVisualStyleBackColor = true;
            this.Read_ALLOW_checkBox.CheckedChanged += new System.EventHandler(this.Read_ALLOW_checkBox_CheckedChanged);
            // 
            // Write_ALLOW_checkBox
            // 
            this.Write_ALLOW_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Write_ALLOW_checkBox.AutoSize = true;
            this.Write_ALLOW_checkBox.Location = new System.Drawing.Point(1154, 215);
            this.Write_ALLOW_checkBox.Name = "Write_ALLOW_checkBox";
            this.Write_ALLOW_checkBox.Size = new System.Drawing.Size(18, 17);
            this.Write_ALLOW_checkBox.TabIndex = 30;
            this.Write_ALLOW_checkBox.UseVisualStyleBackColor = true;
            this.Write_ALLOW_checkBox.CheckedChanged += new System.EventHandler(this.Write_ALLOW_checkBox_CheckedChanged);
            // 
            // ALLOW_label
            // 
            this.ALLOW_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ALLOW_label.AutoSize = true;
            this.ALLOW_label.Location = new System.Drawing.Point(1151, 54);
            this.ALLOW_label.Name = "ALLOW_label";
            this.ALLOW_label.Size = new System.Drawing.Size(81, 17);
            this.ALLOW_label.TabIndex = 31;
            this.ALLOW_label.Text = "Разрешить";
            this.ALLOW_label.Click += new System.EventHandler(this.ALLOW_label_Click);
            // 
            // DENY_label
            // 
            this.DENY_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DENY_label.AutoSize = true;
            this.DENY_label.Location = new System.Drawing.Point(1260, 54);
            this.DENY_label.Name = "DENY_label";
            this.DENY_label.Size = new System.Drawing.Size(78, 17);
            this.DENY_label.TabIndex = 37;
            this.DENY_label.Text = "Запретить";
            this.DENY_label.Click += new System.EventHandler(this.DENY_label_Click);
            // 
            // Write_DENY_checkBox
            // 
            this.Write_DENY_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Write_DENY_checkBox.AutoSize = true;
            this.Write_DENY_checkBox.Location = new System.Drawing.Point(1263, 215);
            this.Write_DENY_checkBox.Name = "Write_DENY_checkBox";
            this.Write_DENY_checkBox.Size = new System.Drawing.Size(18, 17);
            this.Write_DENY_checkBox.TabIndex = 36;
            this.Write_DENY_checkBox.UseVisualStyleBackColor = true;
            this.Write_DENY_checkBox.CheckedChanged += new System.EventHandler(this.Write_DENY_checkBox_CheckedChanged);
            // 
            // Read_DENY_checkBox
            // 
            this.Read_DENY_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Read_DENY_checkBox.AutoSize = true;
            this.Read_DENY_checkBox.Location = new System.Drawing.Point(1263, 182);
            this.Read_DENY_checkBox.Name = "Read_DENY_checkBox";
            this.Read_DENY_checkBox.Size = new System.Drawing.Size(18, 17);
            this.Read_DENY_checkBox.TabIndex = 35;
            this.Read_DENY_checkBox.UseVisualStyleBackColor = true;
            this.Read_DENY_checkBox.CheckedChanged += new System.EventHandler(this.Read_DENY_checkBox_CheckedChanged);
            // 
            // RaE_DENY_checkBox
            // 
            this.RaE_DENY_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RaE_DENY_checkBox.AutoSize = true;
            this.RaE_DENY_checkBox.Location = new System.Drawing.Point(1263, 149);
            this.RaE_DENY_checkBox.Name = "RaE_DENY_checkBox";
            this.RaE_DENY_checkBox.Size = new System.Drawing.Size(18, 17);
            this.RaE_DENY_checkBox.TabIndex = 34;
            this.RaE_DENY_checkBox.UseVisualStyleBackColor = true;
            this.RaE_DENY_checkBox.CheckedChanged += new System.EventHandler(this.RaE_DENY_checkBox_CheckedChanged);
            // 
            // Modify_DENY_checkBox
            // 
            this.Modify_DENY_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Modify_DENY_checkBox.AutoSize = true;
            this.Modify_DENY_checkBox.Location = new System.Drawing.Point(1263, 116);
            this.Modify_DENY_checkBox.Name = "Modify_DENY_checkBox";
            this.Modify_DENY_checkBox.Size = new System.Drawing.Size(18, 17);
            this.Modify_DENY_checkBox.TabIndex = 33;
            this.Modify_DENY_checkBox.UseVisualStyleBackColor = true;
            this.Modify_DENY_checkBox.CheckedChanged += new System.EventHandler(this.Modify_DENY_checkBox_CheckedChanged);
            // 
            // FullControl_DENY_checkBox
            // 
            this.FullControl_DENY_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FullControl_DENY_checkBox.AutoSize = true;
            this.FullControl_DENY_checkBox.Location = new System.Drawing.Point(1263, 84);
            this.FullControl_DENY_checkBox.Name = "FullControl_DENY_checkBox";
            this.FullControl_DENY_checkBox.Size = new System.Drawing.Size(18, 17);
            this.FullControl_DENY_checkBox.TabIndex = 32;
            this.FullControl_DENY_checkBox.UseVisualStyleBackColor = true;
            this.FullControl_DENY_checkBox.CheckedChanged += new System.EventHandler(this.FullControl_DENY_checkBox_CheckedChanged);
            // 
            // AddACE_button
            // 
            this.AddACE_button.Location = new System.Drawing.Point(987, 250);
            this.AddACE_button.Name = "AddACE_button";
            this.AddACE_button.Size = new System.Drawing.Size(348, 28);
            this.AddACE_button.TabIndex = 38;
            this.AddACE_button.Text = "Добавить права";
            this.AddACE_button.UseVisualStyleBackColor = true;
            this.AddACE_button.Click += new System.EventHandler(this.AddACE_button_Click);
            // 
            // FileIL_label
            // 
            this.FileIL_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileIL_label.AutoSize = true;
            this.FileIL_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileIL_label.Location = new System.Drawing.Point(12, 224);
            this.FileIL_label.Name = "FileIL_label";
            this.FileIL_label.Size = new System.Drawing.Size(335, 26);
            this.FileIL_label.TabIndex = 40;
            this.FileIL_label.Text = "Текущий уровень целостности: ";
            this.FileIL_label.Click += new System.EventHandler(this.FileIL_label_Click);
            // 
            // ILTypes_comboBox
            // 
            this.ILTypes_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ILTypes_comboBox.FormattingEnabled = true;
            this.ILTypes_comboBox.Items.AddRange(new object[] {
            "Низкий",
            "Средний",
            "Высокий"});
            this.ILTypes_comboBox.Location = new System.Drawing.Point(15, 294);
            this.ILTypes_comboBox.Name = "ILTypes_comboBox";
            this.ILTypes_comboBox.Size = new System.Drawing.Size(121, 24);
            this.ILTypes_comboBox.TabIndex = 41;
            this.ILTypes_comboBox.SelectedIndexChanged += new System.EventHandler(this.ILTypes_comboBox_SelectedIndexChanged);
            // 
            // ChangeIL_button
            // 
            this.ChangeIL_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangeIL_button.Location = new System.Drawing.Point(15, 334);
            this.ChangeIL_button.Name = "ChangeIL_button";
            this.ChangeIL_button.Size = new System.Drawing.Size(192, 56);
            this.ChangeIL_button.TabIndex = 42;
            this.ChangeIL_button.Text = "Изменить уровень целостности";
            this.ChangeIL_button.UseVisualStyleBackColor = true;
            this.ChangeIL_button.Click += new System.EventHandler(this.ChangeIL_button_Click);
            // 
            // Change_params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1347, 485);
            this.Controls.Add(this.ChangeIL_button);
            this.Controls.Add(this.ILTypes_comboBox);
            this.Controls.Add(this.FileIL_label);
            this.Controls.Add(this.AddACE_button);
            this.Controls.Add(this.DENY_label);
            this.Controls.Add(this.Write_DENY_checkBox);
            this.Controls.Add(this.Read_DENY_checkBox);
            this.Controls.Add(this.RaE_DENY_checkBox);
            this.Controls.Add(this.Modify_DENY_checkBox);
            this.Controls.Add(this.FullControl_DENY_checkBox);
            this.Controls.Add(this.ALLOW_label);
            this.Controls.Add(this.Write_ALLOW_checkBox);
            this.Controls.Add(this.Read_ALLOW_checkBox);
            this.Controls.Add(this.RaE_ALLOW_checkBox);
            this.Controls.Add(this.Modify_ALLOW_checkBox);
            this.Controls.Add(this.FullControl_ALLOW_checkBox);
            this.Controls.Add(this.Write_label);
            this.Controls.Add(this.Read_label);
            this.Controls.Add(this.RaE_label);
            this.Controls.Add(this.Modify_label);
            this.Controls.Add(this.FullControl_label);
            this.Controls.Add(this.TypesACL_label);
            this.Controls.Add(this.GetACL_button);
            this.Controls.Add(this.AllACL_textBox);
            this.Controls.Add(this.ACL_label);
            this.Controls.Add(this.Open_file_button);
            this.Controls.Add(this.SetNewOwner_button);
            this.Controls.Add(this.GetCurrentOwner_button);
            this.Controls.Add(this.NewOwner_textBox);
            this.Controls.Add(this.NewOwner_label);
            this.Controls.Add(this.CurrentOwner_textBox);
            this.Controls.Add(this.CurrentOwner_label);
            this.Controls.Add(this.FileUNC_textBox);
            this.Controls.Add(this.FileUNC_label);
            this.MinimumSize = new System.Drawing.Size(1365, 532);
            this.Name = "Change_params";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ФАЙЛЫ";
            this.Load += new System.EventHandler(this.Change_params_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FileUNC_label;
        private System.Windows.Forms.Label CurrentOwner_label;
        private System.Windows.Forms.TextBox CurrentOwner_textBox;
        private System.Windows.Forms.Label NewOwner_label;
        private System.Windows.Forms.TextBox NewOwner_textBox;
        private System.Windows.Forms.Button GetCurrentOwner_button;
        private System.Windows.Forms.Button SetNewOwner_button;
        private System.Windows.Forms.TextBox FileUNC_textBox;
        private System.Windows.Forms.Button Open_file_button;
        private System.Windows.Forms.Label ACL_label;
        private System.Windows.Forms.TextBox AllACL_textBox;
        private System.Windows.Forms.Button GetACL_button;
        private System.Windows.Forms.Label TypesACL_label;
        private System.Windows.Forms.Label FullControl_label;
        private System.Windows.Forms.Label Modify_label;
        private System.Windows.Forms.Label RaE_label;
        private System.Windows.Forms.Label Read_label;
        private System.Windows.Forms.Label Write_label;
        private System.Windows.Forms.CheckBox FullControl_ALLOW_checkBox;
        private System.Windows.Forms.CheckBox Modify_ALLOW_checkBox;
        private System.Windows.Forms.CheckBox RaE_ALLOW_checkBox;
        private System.Windows.Forms.CheckBox Read_ALLOW_checkBox;
        private System.Windows.Forms.CheckBox Write_ALLOW_checkBox;
        private System.Windows.Forms.Label ALLOW_label;
        private System.Windows.Forms.Label DENY_label;
        private System.Windows.Forms.CheckBox Write_DENY_checkBox;
        private System.Windows.Forms.CheckBox Read_DENY_checkBox;
        private System.Windows.Forms.CheckBox RaE_DENY_checkBox;
        private System.Windows.Forms.CheckBox Modify_DENY_checkBox;
        private System.Windows.Forms.CheckBox FullControl_DENY_checkBox;
        private System.Windows.Forms.Button AddACE_button;
        private System.Windows.Forms.ComboBox ILTypes_comboBox;
        private System.Windows.Forms.Button ChangeIL_button;
        public System.Windows.Forms.Label FileIL_label;
    }
}