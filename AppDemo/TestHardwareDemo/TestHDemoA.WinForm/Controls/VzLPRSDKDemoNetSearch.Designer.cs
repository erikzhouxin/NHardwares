namespace TestHardwareDemo.WinForm.Controls
{
    partial class VzLPRSDKDemoNetSearch
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GrbNetContent = new System.Windows.Forms.GroupBox();
            this.PnlBtnContent = new System.Windows.Forms.Panel();
            this.TxtNetAddress = new System.Windows.Forms.TextBox();
            this.BtnChange = new System.Windows.Forms.Button();
            this.TxtNetGateway = new System.Windows.Forms.TextBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.LblNetAddress = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.LblNetGate = new System.Windows.Forms.Label();
            this.LblNetMask = new System.Windows.Forms.Label();
            this.TxtNetMask = new System.Windows.Forms.TextBox();
            this.TvwSearchRes = new System.Windows.Forms.TreeView();
            this.GrbNetContent.SuspendLayout();
            this.PnlBtnContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrbNetContent
            // 
            this.GrbNetContent.Controls.Add(this.PnlBtnContent);
            this.GrbNetContent.Controls.Add(this.TvwSearchRes);
            this.GrbNetContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbNetContent.Location = new System.Drawing.Point(0, 0);
            this.GrbNetContent.Margin = new System.Windows.Forms.Padding(4);
            this.GrbNetContent.MinimumSize = new System.Drawing.Size(300, 150);
            this.GrbNetContent.Name = "GrbNetContent";
            this.GrbNetContent.Padding = new System.Windows.Forms.Padding(4);
            this.GrbNetContent.Size = new System.Drawing.Size(620, 463);
            this.GrbNetContent.TabIndex = 1;
            this.GrbNetContent.TabStop = false;
            this.GrbNetContent.Text = "查找设备";
            // 
            // PnlBtnContent
            // 
            this.PnlBtnContent.Controls.Add(this.TxtNetAddress);
            this.PnlBtnContent.Controls.Add(this.BtnChange);
            this.PnlBtnContent.Controls.Add(this.TxtNetGateway);
            this.PnlBtnContent.Controls.Add(this.BtnStop);
            this.PnlBtnContent.Controls.Add(this.LblNetAddress);
            this.PnlBtnContent.Controls.Add(this.BtnStart);
            this.PnlBtnContent.Controls.Add(this.LblNetGate);
            this.PnlBtnContent.Controls.Add(this.LblNetMask);
            this.PnlBtnContent.Controls.Add(this.TxtNetMask);
            this.PnlBtnContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBtnContent.Location = new System.Drawing.Point(4, 309);
            this.PnlBtnContent.MinimumSize = new System.Drawing.Size(0, 150);
            this.PnlBtnContent.Name = "PnlBtnContent";
            this.PnlBtnContent.Size = new System.Drawing.Size(612, 150);
            this.PnlBtnContent.TabIndex = 14;
            // 
            // TxtNetAddress
            // 
            this.TxtNetAddress.Location = new System.Drawing.Point(95, 24);
            this.TxtNetAddress.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNetAddress.Name = "TxtNetAddress";
            this.TxtNetAddress.Size = new System.Drawing.Size(116, 23);
            this.TxtNetAddress.TabIndex = 9;
            this.TxtNetAddress.Text = "192.168.1.101";
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(245, 96);
            this.BtnChange.Margin = new System.Windows.Forms.Padding(4);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(80, 33);
            this.BtnChange.TabIndex = 3;
            this.BtnChange.Text = "修改IP";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // TxtNetGateway
            // 
            this.TxtNetGateway.Location = new System.Drawing.Point(95, 100);
            this.TxtNetGateway.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNetGateway.Name = "TxtNetGateway";
            this.TxtNetGateway.Size = new System.Drawing.Size(116, 23);
            this.TxtNetGateway.TabIndex = 13;
            this.TxtNetGateway.Text = "192.168.1.1";
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(245, 53);
            this.BtnStop.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(80, 33);
            this.BtnStop.TabIndex = 2;
            this.BtnStop.Text = "停止搜索";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // LblNetAddress
            // 
            this.LblNetAddress.AutoSize = true;
            this.LblNetAddress.Location = new System.Drawing.Point(17, 28);
            this.LblNetAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNetAddress.Name = "LblNetAddress";
            this.LblNetAddress.Size = new System.Drawing.Size(43, 17);
            this.LblNetAddress.TabIndex = 8;
            this.LblNetAddress.Text = "IP地址";
            // 
            // BtnStart
            // 
            this.BtnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStart.Location = new System.Drawing.Point(245, 12);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(80, 33);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "开始搜索";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblNetGate
            // 
            this.LblNetGate.AutoSize = true;
            this.LblNetGate.Location = new System.Drawing.Point(17, 105);
            this.LblNetGate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNetGate.Name = "LblNetGate";
            this.LblNetGate.Size = new System.Drawing.Size(56, 17);
            this.LblNetGate.TabIndex = 12;
            this.LblNetGate.Text = "默认网关";
            // 
            // LblNetMask
            // 
            this.LblNetMask.AutoSize = true;
            this.LblNetMask.Location = new System.Drawing.Point(17, 66);
            this.LblNetMask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNetMask.Name = "LblNetMask";
            this.LblNetMask.Size = new System.Drawing.Size(56, 17);
            this.LblNetMask.TabIndex = 10;
            this.LblNetMask.Text = "子网掩码";
            // 
            // TxtNetMask
            // 
            this.TxtNetMask.Location = new System.Drawing.Point(95, 62);
            this.TxtNetMask.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNetMask.Name = "TxtNetMask";
            this.TxtNetMask.Size = new System.Drawing.Size(116, 23);
            this.TxtNetMask.TabIndex = 11;
            this.TxtNetMask.Text = "255.255.255.0";
            // 
            // TvwSearchRes
            // 
            this.TvwSearchRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvwSearchRes.Location = new System.Drawing.Point(4, 20);
            this.TvwSearchRes.Margin = new System.Windows.Forms.Padding(4);
            this.TvwSearchRes.Name = "TvwSearchRes";
            this.TvwSearchRes.Size = new System.Drawing.Size(612, 439);
            this.TvwSearchRes.TabIndex = 0;
            this.TvwSearchRes.DoubleClick += new System.EventHandler(this.TvwSearchRes_DoubleClick);
            // 
            // VzLPRSDKDemoNetSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrbNetContent);
            this.Name = "VzLPRSDKDemoNetSearch";
            this.Size = new System.Drawing.Size(620, 463);
            this.GrbNetContent.ResumeLayout(false);
            this.PnlBtnContent.ResumeLayout(false);
            this.PnlBtnContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrbNetContent;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TreeView TvwSearchRes;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.TextBox TxtNetGateway;
        private System.Windows.Forms.Label LblNetGate;
        private System.Windows.Forms.TextBox TxtNetMask;
        private System.Windows.Forms.Label LblNetMask;
        private System.Windows.Forms.TextBox TxtNetAddress;
        private System.Windows.Forms.Label LblNetAddress;
        private System.Windows.Forms.Panel PnlBtnContent;
    }
}
