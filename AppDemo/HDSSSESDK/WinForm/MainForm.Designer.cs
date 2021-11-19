namespace System.Data.HDSSSESDK.WinForm
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.卡类型CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m1卡MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.身份证IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.社保卡SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.银行卡BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnResetPass = new System.Windows.Forms.Button();
            this.btn_writecard = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtBlockInfo = new System.Windows.Forms.TextBox();
            this.btn_readcard = new System.Windows.Forms.Button();
            this.btn_VerifyKey = new System.Windows.Forms.Button();
            this.btn_FindCard = new System.Windows.Forms.Button();
            this.KeyBBox = new System.Windows.Forms.TextBox();
            this.KeyABox = new System.Windows.Forms.TextBox();
            this.TxtSector = new System.Windows.Forms.ComboBox();
            this.TxtPiece = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCardInfo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TxtTimeTick = new System.Windows.Forms.TextBox();
            this.BtnWriteInfo = new System.Windows.Forms.Button();
            this.TxtInfoID = new System.Windows.Forms.TextBox();
            this.TxtInfoName = new System.Windows.Forms.TextBox();
            this.TmrReadCard = new System.Windows.Forms.Timer(this.components);
            this.BtnEidtPass = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.卡类型CToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 28);
            // 
            // 卡类型CToolStripMenuItem
            // 
            this.卡类型CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m1卡MToolStripMenuItem,
            this.身份证IToolStripMenuItem,
            this.社保卡SToolStripMenuItem,
            this.银行卡BToolStripMenuItem});
            this.卡类型CToolStripMenuItem.Name = "卡类型CToolStripMenuItem";
            this.卡类型CToolStripMenuItem.Size = new System.Drawing.Size(100, 28);
            this.卡类型CToolStripMenuItem.Text = "卡类型(&C)";
            // 
            // m1卡MToolStripMenuItem
            // 
            this.m1卡MToolStripMenuItem.Name = "m1卡MToolStripMenuItem";
            this.m1卡MToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.m1卡MToolStripMenuItem.Text = "M1卡(M)";
            // 
            // 身份证IToolStripMenuItem
            // 
            this.身份证IToolStripMenuItem.Name = "身份证IToolStripMenuItem";
            this.身份证IToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.身份证IToolStripMenuItem.Text = "身份证(I)";
            // 
            // 社保卡SToolStripMenuItem
            // 
            this.社保卡SToolStripMenuItem.Name = "社保卡SToolStripMenuItem";
            this.社保卡SToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.社保卡SToolStripMenuItem.Text = "社保卡(S)";
            // 
            // 银行卡BToolStripMenuItem
            // 
            this.银行卡BToolStripMenuItem.Name = "银行卡BToolStripMenuItem";
            this.银行卡BToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.银行卡BToolStripMenuItem.Text = "银行卡(B)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 40);
            this.panel1.TabIndex = 1;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(4, 11);
            this.status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(62, 18);
            this.status.TabIndex = 17;
            this.status.Text = "未读取";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnEidtPass);
            this.panel2.Controls.Add(this.BtnResetPass);
            this.panel2.Controls.Add(this.btn_writecard);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btn_readcard);
            this.panel2.Controls.Add(this.btn_VerifyKey);
            this.panel2.Controls.Add(this.btn_FindCard);
            this.panel2.Controls.Add(this.KeyBBox);
            this.panel2.Controls.Add(this.KeyABox);
            this.panel2.Controls.Add(this.TxtSector);
            this.panel2.Controls.Add(this.TxtPiece);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 221);
            this.panel2.TabIndex = 2;
            // 
            // BtnResetPass
            // 
            this.BtnResetPass.Location = new System.Drawing.Point(448, 59);
            this.BtnResetPass.Margin = new System.Windows.Forms.Padding(4);
            this.BtnResetPass.Name = "BtnResetPass";
            this.BtnResetPass.Size = new System.Drawing.Size(136, 35);
            this.BtnResetPass.TabIndex = 20;
            this.BtnResetPass.Text = "重置扇区密钥";
            this.BtnResetPass.UseVisualStyleBackColor = true;
            this.BtnResetPass.Click += new System.EventHandler(this.BtnResetPass_Click);
            // 
            // btn_writecard
            // 
            this.btn_writecard.Location = new System.Drawing.Point(340, 59);
            this.btn_writecard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_writecard.Name = "btn_writecard";
            this.btn_writecard.Size = new System.Drawing.Size(100, 35);
            this.btn_writecard.TabIndex = 19;
            this.btn_writecard.Text = "(4)写卡";
            this.btn_writecard.UseVisualStyleBackColor = true;
            this.btn_writecard.Click += new System.EventHandler(this.btn_writecard_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBlockInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 109);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "扇区块信息";
            // 
            // TxtBlockInfo
            // 
            this.TxtBlockInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBlockInfo.Location = new System.Drawing.Point(3, 24);
            this.TxtBlockInfo.Multiline = true;
            this.TxtBlockInfo.Name = "TxtBlockInfo";
            this.TxtBlockInfo.Size = new System.Drawing.Size(772, 82);
            this.TxtBlockInfo.TabIndex = 0;
            // 
            // btn_readcard
            // 
            this.btn_readcard.Location = new System.Drawing.Point(232, 59);
            this.btn_readcard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_readcard.Name = "btn_readcard";
            this.btn_readcard.Size = new System.Drawing.Size(100, 35);
            this.btn_readcard.TabIndex = 18;
            this.btn_readcard.Text = "(3)读卡";
            this.btn_readcard.UseVisualStyleBackColor = true;
            this.btn_readcard.Click += new System.EventHandler(this.btn_readcard_Click);
            // 
            // btn_VerifyKey
            // 
            this.btn_VerifyKey.Location = new System.Drawing.Point(124, 59);
            this.btn_VerifyKey.Margin = new System.Windows.Forms.Padding(4);
            this.btn_VerifyKey.Name = "btn_VerifyKey";
            this.btn_VerifyKey.Size = new System.Drawing.Size(100, 35);
            this.btn_VerifyKey.TabIndex = 17;
            this.btn_VerifyKey.Text = "(2)认证";
            this.btn_VerifyKey.UseVisualStyleBackColor = true;
            this.btn_VerifyKey.Click += new System.EventHandler(this.btn_VerifyKey_Click);
            // 
            // btn_FindCard
            // 
            this.btn_FindCard.Location = new System.Drawing.Point(16, 59);
            this.btn_FindCard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FindCard.Name = "btn_FindCard";
            this.btn_FindCard.Size = new System.Drawing.Size(100, 35);
            this.btn_FindCard.TabIndex = 16;
            this.btn_FindCard.Text = "(1)寻卡";
            this.btn_FindCard.UseVisualStyleBackColor = true;
            this.btn_FindCard.Click += new System.EventHandler(this.btn_FindCard_Click);
            // 
            // KeyBBox
            // 
            this.KeyBBox.Location = new System.Drawing.Point(365, 16);
            this.KeyBBox.Margin = new System.Windows.Forms.Padding(4);
            this.KeyBBox.MaxLength = 12;
            this.KeyBBox.Name = "KeyBBox";
            this.KeyBBox.Size = new System.Drawing.Size(136, 28);
            this.KeyBBox.TabIndex = 15;
            this.KeyBBox.Text = "ffffffffffff";
            // 
            // KeyABox
            // 
            this.KeyABox.Location = new System.Drawing.Point(577, 16);
            this.KeyABox.Margin = new System.Windows.Forms.Padding(4);
            this.KeyABox.MaxLength = 12;
            this.KeyABox.Name = "KeyABox";
            this.KeyABox.Size = new System.Drawing.Size(136, 28);
            this.KeyABox.TabIndex = 14;
            this.KeyABox.Text = "ffffffffffff";
            // 
            // TxtSector
            // 
            this.TxtSector.FormattingEnabled = true;
            this.TxtSector.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.TxtSector.Location = new System.Drawing.Point(74, 16);
            this.TxtSector.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSector.Name = "TxtSector";
            this.TxtSector.Size = new System.Drawing.Size(68, 26);
            this.TxtSector.TabIndex = 13;
            this.TxtSector.Text = "11";
            // 
            // TxtPiece
            // 
            this.TxtPiece.FormattingEnabled = true;
            this.TxtPiece.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.TxtPiece.Location = new System.Drawing.Point(215, 16);
            this.TxtPiece.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPiece.Name = "TxtPiece";
            this.TxtPiece.Size = new System.Drawing.Size(70, 26);
            this.TxtPiece.TabIndex = 12;
            this.TxtPiece.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "块号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "扇区:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "KeyB:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "KeyA:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCardInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 161);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收信息";
            // 
            // TxtCardInfo
            // 
            this.TxtCardInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCardInfo.Location = new System.Drawing.Point(3, 24);
            this.TxtCardInfo.Multiline = true;
            this.TxtCardInfo.Name = "TxtCardInfo";
            this.TxtCardInfo.Size = new System.Drawing.Size(772, 134);
            this.TxtCardInfo.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 253);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(778, 251);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.TxtTimeTick);
            this.panel4.Controls.Add(this.BtnWriteInfo);
            this.panel4.Controls.Add(this.TxtInfoID);
            this.panel4.Controls.Add(this.TxtInfoName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(778, 90);
            this.panel4.TabIndex = 5;
            // 
            // TxtTimeTick
            // 
            this.TxtTimeTick.Location = new System.Drawing.Point(493, 33);
            this.TxtTimeTick.Name = "TxtTimeTick";
            this.TxtTimeTick.ReadOnly = true;
            this.TxtTimeTick.Size = new System.Drawing.Size(174, 28);
            this.TxtTimeTick.TabIndex = 2;
            // 
            // BtnWriteInfo
            // 
            this.BtnWriteInfo.Location = new System.Drawing.Point(673, 21);
            this.BtnWriteInfo.Name = "BtnWriteInfo";
            this.BtnWriteInfo.Size = new System.Drawing.Size(93, 49);
            this.BtnWriteInfo.TabIndex = 4;
            this.BtnWriteInfo.Text = "写入信息";
            this.BtnWriteInfo.UseVisualStyleBackColor = true;
            this.BtnWriteInfo.Click += new System.EventHandler(this.BtnWriteInfo_Click);
            // 
            // TxtInfoID
            // 
            this.TxtInfoID.Location = new System.Drawing.Point(12, 33);
            this.TxtInfoID.MaxLength = 32;
            this.TxtInfoID.Name = "TxtInfoID";
            this.TxtInfoID.Size = new System.Drawing.Size(303, 28);
            this.TxtInfoID.TabIndex = 0;
            this.TxtInfoID.Text = "404751f291d842788ad1535d54cfa5e4";
            // 
            // TxtInfoName
            // 
            this.TxtInfoName.Location = new System.Drawing.Point(321, 33);
            this.TxtInfoName.MaxLength = 16;
            this.TxtInfoName.Name = "TxtInfoName";
            this.TxtInfoName.Size = new System.Drawing.Size(166, 28);
            this.TxtInfoName.TabIndex = 1;
            this.TxtInfoName.Text = "天一生水";
            // 
            // TmrReadCard
            // 
            this.TmrReadCard.Interval = 500;
            this.TmrReadCard.Tick += new System.EventHandler(this.TmrReadCard_Tick);
            // 
            // BtnEidtPass
            // 
            this.BtnEidtPass.Location = new System.Drawing.Point(592, 59);
            this.BtnEidtPass.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEidtPass.Name = "BtnEidtPass";
            this.BtnEidtPass.Size = new System.Drawing.Size(136, 35);
            this.BtnEidtPass.TabIndex = 21;
            this.BtnEidtPass.Text = "修改扇区密钥";
            this.BtnEidtPass.UseVisualStyleBackColor = true;
            this.BtnEidtPass.Click += new System.EventHandler(this.BtnEidtPass_Click);
            // 
            // HD100CardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "HD100CardForm";
            this.Text = "HD100CardForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 卡类型CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m1卡MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 身份证IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 社保卡SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 银行卡BToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Timer TmrReadCard;
        private System.Windows.Forms.TextBox KeyBBox;
        private System.Windows.Forms.TextBox KeyABox;
        private System.Windows.Forms.ComboBox TxtSector;
        private System.Windows.Forms.ComboBox TxtPiece;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_VerifyKey;
        private System.Windows.Forms.Button btn_FindCard;
        private System.Windows.Forms.Button btn_writecard;
        private System.Windows.Forms.Button btn_readcard;
        private System.Windows.Forms.TextBox TxtCardInfo;
        private System.Windows.Forms.TextBox TxtBlockInfo;
        private System.Windows.Forms.TextBox TxtInfoID;
        private System.Windows.Forms.TextBox TxtInfoName;
        private System.Windows.Forms.Button BtnWriteInfo;
        private System.Windows.Forms.TextBox TxtTimeTick;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnResetPass;
        private System.Windows.Forms.Button BtnEidtPass;
    }
}