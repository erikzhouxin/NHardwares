namespace YuShiNetDevSDK.WinForm
{
    partial class DownloadInfo
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
            this.hideBtn = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.fileName = new System.Windows.Forms.ColumnHeader();
            this.BeginTime = new System.Windows.Forms.ColumnHeader();
            this.EndTime = new System.Windows.Forms.ColumnHeader();
            this.Progress = new System.Windows.Forms.ColumnHeader();
            this.Path = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // hideBtn
            // 
            this.hideBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hideBtn.Location = new System.Drawing.Point(701, 232);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.Size = new System.Drawing.Size(75, 30);
            this.hideBtn.TabIndex = 0;
            this.hideBtn.Text = "Close";
            this.hideBtn.UseVisualStyleBackColor = true;
            this.hideBtn.Click += new System.EventHandler(this.hideBtn_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.BeginTime,
            this.EndTime,
            this.Progress,
            this.Path});
            this.listView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(764, 209);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // fileName
            // 
            this.fileName.Text = "File Name";
            this.fileName.Width = 125;
            // 
            // BeginTime
            // 
            this.BeginTime.Text = "Begin Time";
            this.BeginTime.Width = 142;
            // 
            // EndTime
            // 
            this.EndTime.Text = "End Time";
            this.EndTime.Width = 142;
            // 
            // Progress
            // 
            this.Progress.Text = "Progress(%)";
            this.Progress.Width = 87;
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 303;
            // 
            // DownloadInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 275);
            this.ControlBox = false;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.hideBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DownloadInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hideBtn;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader BeginTime;
        private System.Windows.Forms.ColumnHeader EndTime;
        private System.Windows.Forms.ColumnHeader Progress;
        private System.Windows.Forms.ColumnHeader Path;
    }
}