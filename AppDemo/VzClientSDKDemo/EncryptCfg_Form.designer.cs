namespace VzClientSDKDemo
{
    partial class EncryptCfg_Form
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
            this.groupEncryptType = new System.Windows.Forms.GroupBox();
            this.textBoxUserword = new System.Windows.Forms.TextBox();
            this.btnEncryptSave = new System.Windows.Forms.Button();
            this.labelUserPassword = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelEncryptType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxChangeWord = new System.Windows.Forms.GroupBox();
            this.textBoxConfirmWord = new System.Windows.Forms.TextBox();
            this.textBoxNewWord = new System.Windows.Forms.TextBox();
            this.textBoxUserword2 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChangeWordSave = new System.Windows.Forms.Button();
            this.radioBtnKeyWord = new System.Windows.Forms.RadioButton();
            this.radioBtnUserWord = new System.Windows.Forms.RadioButton();
            this.labelOkWord = new System.Windows.Forms.Label();
            this.labelNewWord = new System.Windows.Forms.Label();
            this.labelUserWord = new System.Windows.Forms.Label();
            this.labelChangeType = new System.Windows.Forms.Label();
            this.groupEncryptType.SuspendLayout();
            this.groupBoxChangeWord.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupEncryptType
            // 
            this.groupEncryptType.Controls.Add(this.textBoxUserword);
            this.groupEncryptType.Controls.Add(this.btnEncryptSave);
            this.groupEncryptType.Controls.Add(this.labelUserPassword);
            this.groupEncryptType.Controls.Add(this.comboBox1);
            this.groupEncryptType.Controls.Add(this.labelEncryptType);
            this.groupEncryptType.Location = new System.Drawing.Point(32, 13);
            this.groupEncryptType.Name = "groupEncryptType";
            this.groupEncryptType.Size = new System.Drawing.Size(233, 113);
            this.groupEncryptType.TabIndex = 0;
            this.groupEncryptType.TabStop = false;
            this.groupEncryptType.Text = "选择加密方式";
            // 
            // textBoxUserword
            // 
            this.textBoxUserword.Location = new System.Drawing.Point(83, 57);
            this.textBoxUserword.Name = "textBoxUserword";
            this.textBoxUserword.PasswordChar = '*';
            this.textBoxUserword.Size = new System.Drawing.Size(138, 21);
            this.textBoxUserword.TabIndex = 4;
            // 
            // btnEncryptSave
            // 
            this.btnEncryptSave.Location = new System.Drawing.Point(158, 84);
            this.btnEncryptSave.Name = "btnEncryptSave";
            this.btnEncryptSave.Size = new System.Drawing.Size(46, 23);
            this.btnEncryptSave.TabIndex = 3;
            this.btnEncryptSave.Text = "保存";
            this.btnEncryptSave.UseVisualStyleBackColor = true;
            this.btnEncryptSave.Click += new System.EventHandler(this.btnEncryptSave_Click);
            // 
            // labelUserPassword
            // 
            this.labelUserPassword.AutoSize = true;
            this.labelUserPassword.Location = new System.Drawing.Point(18, 60);
            this.labelUserPassword.Name = "labelUserPassword";
            this.labelUserPassword.Size = new System.Drawing.Size(59, 12);
            this.labelUserPassword.TabIndex = 2;
            this.labelUserPassword.Text = "用户密码:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(83, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // labelEncryptType
            // 
            this.labelEncryptType.AutoSize = true;
            this.labelEncryptType.Location = new System.Drawing.Point(18, 29);
            this.labelEncryptType.Name = "labelEncryptType";
            this.labelEncryptType.Size = new System.Drawing.Size(59, 12);
            this.labelEncryptType.TabIndex = 0;
            this.labelEncryptType.Text = "加密方式:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // groupBoxChangeWord
            // 
            this.groupBoxChangeWord.Controls.Add(this.textBoxConfirmWord);
            this.groupBoxChangeWord.Controls.Add(this.textBoxNewWord);
            this.groupBoxChangeWord.Controls.Add(this.textBoxUserword2);
            this.groupBoxChangeWord.Controls.Add(this.btnCancel);
            this.groupBoxChangeWord.Controls.Add(this.btnChangeWordSave);
            this.groupBoxChangeWord.Controls.Add(this.radioBtnKeyWord);
            this.groupBoxChangeWord.Controls.Add(this.radioBtnUserWord);
            this.groupBoxChangeWord.Controls.Add(this.labelOkWord);
            this.groupBoxChangeWord.Controls.Add(this.labelNewWord);
            this.groupBoxChangeWord.Controls.Add(this.labelUserWord);
            this.groupBoxChangeWord.Controls.Add(this.labelChangeType);
            this.groupBoxChangeWord.Location = new System.Drawing.Point(32, 146);
            this.groupBoxChangeWord.Name = "groupBoxChangeWord";
            this.groupBoxChangeWord.Size = new System.Drawing.Size(233, 181);
            this.groupBoxChangeWord.TabIndex = 2;
            this.groupBoxChangeWord.TabStop = false;
            this.groupBoxChangeWord.Text = "修改密码";
            // 
            // textBoxConfirmWord
            // 
            this.textBoxConfirmWord.Location = new System.Drawing.Point(83, 99);
            this.textBoxConfirmWord.Name = "textBoxConfirmWord";
            this.textBoxConfirmWord.PasswordChar = '*';
            this.textBoxConfirmWord.Size = new System.Drawing.Size(138, 21);
            this.textBoxConfirmWord.TabIndex = 10;
            // 
            // textBoxNewWord
            // 
            this.textBoxNewWord.Location = new System.Drawing.Point(83, 72);
            this.textBoxNewWord.Name = "textBoxNewWord";
            this.textBoxNewWord.PasswordChar = '*';
            this.textBoxNewWord.Size = new System.Drawing.Size(138, 21);
            this.textBoxNewWord.TabIndex = 9;
            // 
            // textBoxUserword2
            // 
            this.textBoxUserword2.Location = new System.Drawing.Point(84, 44);
            this.textBoxUserword2.Name = "textBoxUserword2";
            this.textBoxUserword2.PasswordChar = '*';
            this.textBoxUserword2.Size = new System.Drawing.Size(137, 21);
            this.textBoxUserword2.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(158, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(46, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChangeWordSave
            // 
            this.btnChangeWordSave.Location = new System.Drawing.Point(72, 141);
            this.btnChangeWordSave.Name = "btnChangeWordSave";
            this.btnChangeWordSave.Size = new System.Drawing.Size(47, 23);
            this.btnChangeWordSave.TabIndex = 6;
            this.btnChangeWordSave.Text = "保存";
            this.btnChangeWordSave.UseVisualStyleBackColor = true;
            this.btnChangeWordSave.Click += new System.EventHandler(this.btnChangeWordSave_Click);
            // 
            // radioBtnKeyWord
            // 
            this.radioBtnKeyWord.AutoSize = true;
            this.radioBtnKeyWord.Location = new System.Drawing.Point(162, 20);
            this.radioBtnKeyWord.Name = "radioBtnKeyWord";
            this.radioBtnKeyWord.Size = new System.Drawing.Size(59, 16);
            this.radioBtnKeyWord.TabIndex = 5;
            this.radioBtnKeyWord.TabStop = true;
            this.radioBtnKeyWord.Text = "主密码";
            this.radioBtnKeyWord.UseVisualStyleBackColor = true;
            this.radioBtnKeyWord.CheckedChanged += new System.EventHandler(this.radioBtnKeyWord_CheckedChanged);
            // 
            // radioBtnUserWord
            // 
            this.radioBtnUserWord.AutoSize = true;
            this.radioBtnUserWord.Location = new System.Drawing.Point(84, 21);
            this.radioBtnUserWord.Name = "radioBtnUserWord";
            this.radioBtnUserWord.Size = new System.Drawing.Size(71, 16);
            this.radioBtnUserWord.TabIndex = 4;
            this.radioBtnUserWord.TabStop = true;
            this.radioBtnUserWord.Text = "用户密码";
            this.radioBtnUserWord.UseVisualStyleBackColor = true;
            this.radioBtnUserWord.CheckedChanged += new System.EventHandler(this.radioBtnUserWord_CheckedChanged);
            // 
            // labelOkWord
            // 
            this.labelOkWord.AutoSize = true;
            this.labelOkWord.Location = new System.Drawing.Point(18, 99);
            this.labelOkWord.Name = "labelOkWord";
            this.labelOkWord.Size = new System.Drawing.Size(59, 12);
            this.labelOkWord.TabIndex = 3;
            this.labelOkWord.Text = "确认密码:";
            // 
            // labelNewWord
            // 
            this.labelNewWord.AutoSize = true;
            this.labelNewWord.Location = new System.Drawing.Point(18, 72);
            this.labelNewWord.Name = "labelNewWord";
            this.labelNewWord.Size = new System.Drawing.Size(59, 12);
            this.labelNewWord.TabIndex = 2;
            this.labelNewWord.Text = "新 密 码:";
            // 
            // labelUserWord
            // 
            this.labelUserWord.AutoSize = true;
            this.labelUserWord.Location = new System.Drawing.Point(18, 46);
            this.labelUserWord.Name = "labelUserWord";
            this.labelUserWord.Size = new System.Drawing.Size(59, 12);
            this.labelUserWord.TabIndex = 1;
            this.labelUserWord.Text = "用户密码:";
            // 
            // labelChangeType
            // 
            this.labelChangeType.AutoSize = true;
            this.labelChangeType.Location = new System.Drawing.Point(20, 21);
            this.labelChangeType.Name = "labelChangeType";
            this.labelChangeType.Size = new System.Drawing.Size(59, 12);
            this.labelChangeType.TabIndex = 0;
            this.labelChangeType.Text = "修改方式:";
            // 
            // EncryptCfg_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 339);
            this.Controls.Add(this.groupBoxChangeWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupEncryptType);
            this.Name = "EncryptCfg_Form";
            this.Text = "加密配置";
            this.Load += new System.EventHandler(this.EncryptCfg_Form_Load);
            this.groupEncryptType.ResumeLayout(false);
            this.groupEncryptType.PerformLayout();
            this.groupBoxChangeWord.ResumeLayout(false);
            this.groupBoxChangeWord.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupEncryptType;
        private System.Windows.Forms.Label labelUserPassword;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelEncryptType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxChangeWord;
        private System.Windows.Forms.Label labelUserWord;
        private System.Windows.Forms.Label labelChangeType;
        private System.Windows.Forms.Label labelOkWord;
        private System.Windows.Forms.Label labelNewWord;
        private System.Windows.Forms.Button btnEncryptSave;
        private System.Windows.Forms.RadioButton radioBtnKeyWord;
        private System.Windows.Forms.RadioButton radioBtnUserWord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChangeWordSave;
        private System.Windows.Forms.TextBox textBoxUserword;
        private System.Windows.Forms.TextBox textBoxConfirmWord;
        private System.Windows.Forms.TextBox textBoxNewWord;
        private System.Windows.Forms.TextBox textBoxUserword2;
    }
}