namespace YouRenIoTNetIO.WinForm.Views
{
    partial class TestScanFlew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestScanFlew));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNetOper = new System.Windows.Forms.ToolStripButton();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.SplContent = new System.Windows.Forms.SplitContainer();
            this.TxtLogger = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.PnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplContent)).BeginInit();
            this.SplContent.Panel2.SuspendLayout();
            this.SplContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNetOper});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(758, 60);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNetOper
            // 
            this.BtnNetOper.Image = ((System.Drawing.Image)(resources.GetObject("BtnNetOper.Image")));
            this.BtnNetOper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnNetOper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNetOper.Name = "BtnNetOper";
            this.BtnNetOper.Size = new System.Drawing.Size(84, 57);
            this.BtnNetOper.Text = "通过网络操作";
            this.BtnNetOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // PnlContent
            // 
            this.PnlContent.Controls.Add(this.SplContent);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 60);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(758, 571);
            this.PnlContent.TabIndex = 1;
            // 
            // SplContent
            // 
            this.SplContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplContent.Location = new System.Drawing.Point(0, 0);
            this.SplContent.Name = "SplContent";
            // 
            // SplContent.Panel1
            // 
            this.SplContent.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplContent.Panel2
            // 
            this.SplContent.Panel2.Controls.Add(this.TxtLogger);
            this.SplContent.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplContent.Size = new System.Drawing.Size(758, 571);
            this.SplContent.SplitterDistance = 502;
            this.SplContent.TabIndex = 0;
            // 
            // TxtLogger
            // 
            this.TxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLogger.Location = new System.Drawing.Point(0, 0);
            this.TxtLogger.Name = "TxtLogger";
            this.TxtLogger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TxtLogger.Size = new System.Drawing.Size(252, 571);
            this.TxtLogger.TabIndex = 0;
            this.TxtLogger.Text = "";
            // 
            // TestScanFlew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlContent);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TestScanFlew";
            this.Size = new System.Drawing.Size(758, 631);
            this.Load += new System.EventHandler(this.TestScanner_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PnlContent.ResumeLayout(false);
            this.SplContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplContent)).EndInit();
            this.SplContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNetOper;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.SplitContainer SplContent;
        private System.Windows.Forms.RichTextBox TxtLogger;
    }
}
