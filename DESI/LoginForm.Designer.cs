namespace DESI
{
    partial class LoginForm
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
            this.groupBox_OpenSession = new System.Windows.Forms.GroupBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.maskedTextBox_Password = new System.Windows.Forms.MaskedTextBox();
            this.comboBox_User = new System.Windows.Forms.ComboBox();
            this.comboBox_DB = new System.Windows.Forms.ComboBox();
            this.button_Open = new System.Windows.Forms.Button();
            this.label_User = new System.Windows.Forms.Label();
            this.label_Block = new System.Windows.Forms.Label();
            this.groupBox_OpenSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_OpenSession
            // 
            this.groupBox_OpenSession.Controls.Add(this.label_Password);
            this.groupBox_OpenSession.Controls.Add(this.maskedTextBox_Password);
            this.groupBox_OpenSession.Controls.Add(this.comboBox_User);
            this.groupBox_OpenSession.Controls.Add(this.comboBox_DB);
            this.groupBox_OpenSession.Controls.Add(this.button_Open);
            this.groupBox_OpenSession.Controls.Add(this.label_User);
            this.groupBox_OpenSession.Controls.Add(this.label_Block);
            this.groupBox_OpenSession.Enabled = false;
            this.groupBox_OpenSession.Location = new System.Drawing.Point(12, 52);
            this.groupBox_OpenSession.Name = "groupBox_OpenSession";
            this.groupBox_OpenSession.Size = new System.Drawing.Size(285, 100);
            this.groupBox_OpenSession.TabIndex = 3;
            this.groupBox_OpenSession.TabStop = false;
            this.groupBox_OpenSession.Text = "Открытие сеанса (сессии)";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Password.Location = new System.Drawing.Point(8, 75);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(45, 13);
            this.label_Password.TabIndex = 13;
            this.label_Password.Text = "Пароль";
            // 
            // maskedTextBox_Password
            // 
            this.maskedTextBox_Password.Location = new System.Drawing.Point(94, 72);
            this.maskedTextBox_Password.Name = "maskedTextBox_Password";
            this.maskedTextBox_Password.PasswordChar = '*';
            this.maskedTextBox_Password.Size = new System.Drawing.Size(70, 20);
            this.maskedTextBox_Password.TabIndex = 12;
            this.maskedTextBox_Password.Text = "ni01";
            // 
            // comboBox_User
            // 
            this.comboBox_User.FormattingEnabled = true;
            this.comboBox_User.Items.AddRange(new object[] {
            "NI01",
            "DB06",
            "EQADM",
            "BTPV",
            "BTDA",
            "BTUE",
            "BTYZ",
            "DS01",
            "EDKM"});
            this.comboBox_User.Location = new System.Drawing.Point(94, 45);
            this.comboBox_User.MaxLength = 10;
            this.comboBox_User.Name = "comboBox_User";
            this.comboBox_User.Size = new System.Drawing.Size(70, 21);
            this.comboBox_User.TabIndex = 11;
            this.comboBox_User.Text = "NI01";
            // 
            // comboBox_DB
            // 
            this.comboBox_DB.FormattingEnabled = true;
            this.comboBox_DB.Items.AddRange(new object[] {
            "ABO",
            "AB2",
            "AB3",
            "MI1",
            "MI2",
            "MI3",
            "TS5",
            "TS7",
            "TS8",
            "TS9"});
            this.comboBox_DB.Location = new System.Drawing.Point(94, 19);
            this.comboBox_DB.MaxLength = 3;
            this.comboBox_DB.Name = "comboBox_DB";
            this.comboBox_DB.Size = new System.Drawing.Size(70, 21);
            this.comboBox_DB.TabIndex = 10;
            this.comboBox_DB.Text = "AB2";
            // 
            // button_Open
            // 
            this.button_Open.ImageIndex = 12;
            this.button_Open.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_Open.Location = new System.Drawing.Point(170, 22);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(100, 23);
            this.button_Open.TabIndex = 9;
            this.button_Open.Text = "Открыть";
            this.button_Open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Open.UseVisualStyleBackColor = true;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_User.Location = new System.Drawing.Point(8, 48);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(80, 13);
            this.label_User.TabIndex = 8;
            this.label_User.Text = "Пользователь";
            // 
            // label_Block
            // 
            this.label_Block.AutoSize = true;
            this.label_Block.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Block.Location = new System.Drawing.Point(8, 22);
            this.label_Block.Name = "label_Block";
            this.label_Block.Size = new System.Drawing.Size(57, 13);
            this.label_Block.TabIndex = 7;
            this.label_Block.Text = "Блок (БД)";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 204);
            this.Controls.Add(this.groupBox_OpenSession);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.groupBox_OpenSession.ResumeLayout(false);
            this.groupBox_OpenSession.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_OpenSession;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Password;
        private System.Windows.Forms.ComboBox comboBox_User;
        private System.Windows.Forms.ComboBox comboBox_DB;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Label label_Block;
    }
}