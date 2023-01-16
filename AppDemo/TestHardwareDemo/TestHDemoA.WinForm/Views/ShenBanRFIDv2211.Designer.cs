namespace TestHardwareDemo.WinForm.Views
{
    partial class ShenBanRFIDv2211
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
            this.Tlp = new System.Windows.Forms.TableLayoutPanel();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.PnlTabCnt1 = new System.Windows.Forms.Panel();
            this.PnlTabCnt2 = new System.Windows.Forms.Panel();
            this.PnlTabCnt3 = new System.Windows.Forms.Panel();
            this.PnlTabCnt4 = new System.Windows.Forms.Panel();
            this.Tlp.SuspendLayout();
            this.PnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tlp
            // 
            this.Tlp.ColumnCount = 2;
            this.Tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.Controls.Add(this.PnlTabCnt1, 0, 0);
            this.Tlp.Controls.Add(this.PnlTabCnt2, 1, 0);
            this.Tlp.Controls.Add(this.PnlTabCnt3, 0, 1);
            this.Tlp.Controls.Add(this.PnlTabCnt4, 1, 1);
            this.Tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tlp.Location = new System.Drawing.Point(0, 0);
            this.Tlp.Name = "Tlp";
            this.Tlp.RowCount = 2;
            this.Tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.Size = new System.Drawing.Size(878, 716);
            this.Tlp.TabIndex = 0;
            // 
            // PnlContent
            // 
            this.PnlContent.Controls.Add(this.Tlp);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 0);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(878, 716);
            this.PnlContent.TabIndex = 1;
            // 
            // PnlTabCnt1
            // 
            this.PnlTabCnt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt1.Location = new System.Drawing.Point(3, 3);
            this.PnlTabCnt1.Name = "PnlTabCnt1";
            this.PnlTabCnt1.Size = new System.Drawing.Size(433, 352);
            this.PnlTabCnt1.TabIndex = 0;
            // 
            // PnlTabCnt2
            // 
            this.PnlTabCnt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt2.Location = new System.Drawing.Point(442, 3);
            this.PnlTabCnt2.Name = "PnlTabCnt2";
            this.PnlTabCnt2.Size = new System.Drawing.Size(433, 352);
            this.PnlTabCnt2.TabIndex = 1;
            // 
            // PnlTabCnt3
            // 
            this.PnlTabCnt3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt3.Location = new System.Drawing.Point(3, 361);
            this.PnlTabCnt3.Name = "PnlTabCnt3";
            this.PnlTabCnt3.Size = new System.Drawing.Size(433, 352);
            this.PnlTabCnt3.TabIndex = 2;
            // 
            // PnlTabCnt4
            // 
            this.PnlTabCnt4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt4.Location = new System.Drawing.Point(442, 361);
            this.PnlTabCnt4.Name = "PnlTabCnt4";
            this.PnlTabCnt4.Size = new System.Drawing.Size(433, 352);
            this.PnlTabCnt4.TabIndex = 3;
            // 
            // ShenBanRFIDv2211
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlContent);
            this.Name = "ShenBanRFIDv2211";
            this.Size = new System.Drawing.Size(878, 716);
            this.Tlp.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Tlp;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.Panel PnlTabCnt1;
        private System.Windows.Forms.Panel PnlTabCnt2;
        private System.Windows.Forms.Panel PnlTabCnt3;
        private System.Windows.Forms.Panel PnlTabCnt4;
    }
}
