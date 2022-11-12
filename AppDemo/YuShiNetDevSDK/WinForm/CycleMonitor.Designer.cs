namespace YuShiNetDevSDK.WinForm
{
    partial class CycleMonitor
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
            this.startMonitorBtn = new System.Windows.Forms.Button();
            this.cycleMonitorTypeCobBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cycleMonitorWinNoCobBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.monitorIntervalText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.unmonitorListView = new System.Windows.Forms.ListView();
            this.Device = new System.Windows.Forms.ColumnHeader();
            this.Channel = new System.Windows.Forms.ColumnHeader();
            this.stopMonitorBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.delOneMonitorBtn = new System.Windows.Forms.Button();
            this.delAllMonitorBtn = new System.Windows.Forms.Button();
            this.addAllMonitorBtn = new System.Windows.Forms.Button();
            this.addOneMonitorBtn = new System.Windows.Forms.Button();
            this.monitorListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // startMonitorBtn
            // 
            this.startMonitorBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startMonitorBtn.Location = new System.Drawing.Point(176, 355);
            this.startMonitorBtn.Name = "startMonitorBtn";
            this.startMonitorBtn.Size = new System.Drawing.Size(75, 30);
            this.startMonitorBtn.TabIndex = 0;
            this.startMonitorBtn.Text = "Start";
            this.startMonitorBtn.UseVisualStyleBackColor = true;
            this.startMonitorBtn.Click += new System.EventHandler(this.startMonitorBtn_Click);
            // 
            // cycleMonitorTypeCobBox
            // 
            this.cycleMonitorTypeCobBox.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cycleMonitorTypeCobBox.FormattingEnabled = true;
            this.cycleMonitorTypeCobBox.Items.AddRange(new object[] {
            "Single Screen",
            "All Screen"});
            this.cycleMonitorTypeCobBox.Location = new System.Drawing.Point(69, 21);
            this.cycleMonitorTypeCobBox.Name = "cycleMonitorTypeCobBox";
            this.cycleMonitorTypeCobBox.Size = new System.Drawing.Size(121, 24);
            this.cycleMonitorTypeCobBox.TabIndex = 1;
            this.cycleMonitorTypeCobBox.Text = "Single Screen";
            this.cycleMonitorTypeCobBox.SelectedIndexChanged += new System.EventHandler(this.cycleMonitorTypeCobBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type";
            // 
            // cycleMonitorWinNoCobBox
            // 
            this.cycleMonitorWinNoCobBox.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cycleMonitorWinNoCobBox.FormattingEnabled = true;
            this.cycleMonitorWinNoCobBox.Items.AddRange(new object[] {
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
            "15",
            "16"});
            this.cycleMonitorWinNoCobBox.Location = new System.Drawing.Point(268, 21);
            this.cycleMonitorWinNoCobBox.Name = "cycleMonitorWinNoCobBox";
            this.cycleMonitorWinNoCobBox.Size = new System.Drawing.Size(85, 24);
            this.cycleMonitorWinNoCobBox.TabIndex = 1;
            this.cycleMonitorWinNoCobBox.Text = "1";
            this.cycleMonitorWinNoCobBox.SelectedIndexChanged += new System.EventHandler(this.cycleMonitorWinNoCobBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(219, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Win No";
            // 
            // monitorIntervalText
            // 
            this.monitorIntervalText.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.monitorIntervalText.Location = new System.Drawing.Point(446, 21);
            this.monitorIntervalText.Name = "monitorIntervalText";
            this.monitorIntervalText.Size = new System.Drawing.Size(100, 22);
            this.monitorIntervalText.TabIndex = 4;
            this.monitorIntervalText.Text = "20";
            this.monitorIntervalText.TextChanged += new System.EventHandler(this.monitorIntervalText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(381, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Interval(s)";
            // 
            // unmonitorListView
            // 
            this.unmonitorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Device,
            this.Channel});
            this.unmonitorListView.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unmonitorListView.FullRowSelect = true;
            this.unmonitorListView.GridLines = true;
            this.unmonitorListView.HideSelection = false;
            this.unmonitorListView.Location = new System.Drawing.Point(19, 64);
            this.unmonitorListView.Name = "unmonitorListView";
            this.unmonitorListView.Size = new System.Drawing.Size(208, 266);
            this.unmonitorListView.TabIndex = 2;
            this.unmonitorListView.UseCompatibleStateImageBehavior = false;
            this.unmonitorListView.View = System.Windows.Forms.View.Details;
            this.unmonitorListView.SelectedIndexChanged += new System.EventHandler(this.unmonitorListView_SelectedIndexChanged);
            // 
            // Device
            // 
            this.Device.Text = "Device";
            this.Device.Width = 100;
            // 
            // Channel
            // 
            this.Channel.Text = "Channel";
            // 
            // stopMonitorBtn
            // 
            this.stopMonitorBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopMonitorBtn.Location = new System.Drawing.Point(263, 355);
            this.stopMonitorBtn.Name = "stopMonitorBtn";
            this.stopMonitorBtn.Size = new System.Drawing.Size(75, 30);
            this.stopMonitorBtn.TabIndex = 0;
            this.stopMonitorBtn.Text = "Stop";
            this.stopMonitorBtn.UseVisualStyleBackColor = true;
            this.stopMonitorBtn.Click += new System.EventHandler(this.stopMonitorBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelBtn.Location = new System.Drawing.Point(354, 355);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 30);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // delOneMonitorBtn
            // 
            this.delOneMonitorBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delOneMonitorBtn.Location = new System.Drawing.Point(259, 238);
            this.delOneMonitorBtn.Name = "delOneMonitorBtn";
            this.delOneMonitorBtn.Size = new System.Drawing.Size(75, 30);
            this.delOneMonitorBtn.TabIndex = 0;
            this.delOneMonitorBtn.Text = "<";
            this.delOneMonitorBtn.UseVisualStyleBackColor = true;
            this.delOneMonitorBtn.Click += new System.EventHandler(this.delOneMonitorBtn_Click);
            // 
            // delAllMonitorBtn
            // 
            this.delAllMonitorBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delAllMonitorBtn.Location = new System.Drawing.Point(259, 276);
            this.delAllMonitorBtn.Name = "delAllMonitorBtn";
            this.delAllMonitorBtn.Size = new System.Drawing.Size(75, 30);
            this.delAllMonitorBtn.TabIndex = 0;
            this.delAllMonitorBtn.Text = "< <";
            this.delAllMonitorBtn.UseVisualStyleBackColor = true;
            this.delAllMonitorBtn.Click += new System.EventHandler(this.delAllMonitorBtn_Click);
            // 
            // addAllMonitorBtn
            // 
            this.addAllMonitorBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addAllMonitorBtn.Location = new System.Drawing.Point(259, 101);
            this.addAllMonitorBtn.Name = "addAllMonitorBtn";
            this.addAllMonitorBtn.Size = new System.Drawing.Size(75, 30);
            this.addAllMonitorBtn.TabIndex = 0;
            this.addAllMonitorBtn.Text = "> >";
            this.addAllMonitorBtn.UseVisualStyleBackColor = true;
            this.addAllMonitorBtn.Click += new System.EventHandler(this.addAllMonitorBtn_Click);
            // 
            // addOneMonitorBtn
            // 
            this.addOneMonitorBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addOneMonitorBtn.Location = new System.Drawing.Point(259, 139);
            this.addOneMonitorBtn.Name = "addOneMonitorBtn";
            this.addOneMonitorBtn.Size = new System.Drawing.Size(75, 30);
            this.addOneMonitorBtn.TabIndex = 0;
            this.addOneMonitorBtn.Text = ">";
            this.addOneMonitorBtn.UseVisualStyleBackColor = true;
            this.addOneMonitorBtn.Click += new System.EventHandler(this.addOneMonitorBtn_Click);
            // 
            // monitorListView
            // 
            this.monitorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.monitorListView.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.monitorListView.FullRowSelect = true;
            this.monitorListView.GridLines = true;
            this.monitorListView.HideSelection = false;
            this.monitorListView.Location = new System.Drawing.Point(364, 64);
            this.monitorListView.Name = "monitorListView";
            this.monitorListView.Size = new System.Drawing.Size(208, 266);
            this.monitorListView.TabIndex = 2;
            this.monitorListView.UseCompatibleStateImageBehavior = false;
            this.monitorListView.View = System.Windows.Forms.View.Details;
            this.monitorListView.SelectedIndexChanged += new System.EventHandler(this.monitorListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Channel";
            // 
            // CycleMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 406);
            this.ControlBox = false;
            this.Controls.Add(this.monitorIntervalText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monitorListView);
            this.Controls.Add(this.unmonitorListView);
            this.Controls.Add(this.cycleMonitorWinNoCobBox);
            this.Controls.Add(this.cycleMonitorTypeCobBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addOneMonitorBtn);
            this.Controls.Add(this.delAllMonitorBtn);
            this.Controls.Add(this.addAllMonitorBtn);
            this.Controls.Add(this.delOneMonitorBtn);
            this.Controls.Add(this.stopMonitorBtn);
            this.Controls.Add(this.startMonitorBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CycleMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cycle Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startMonitorBtn;
        private System.Windows.Forms.ComboBox cycleMonitorTypeCobBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cycleMonitorWinNoCobBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox monitorIntervalText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView unmonitorListView;
        private System.Windows.Forms.Button stopMonitorBtn;
        private System.Windows.Forms.ColumnHeader Device;
        private System.Windows.Forms.ColumnHeader Channel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button delOneMonitorBtn;
        private System.Windows.Forms.Button delAllMonitorBtn;
        private System.Windows.Forms.Button addAllMonitorBtn;
        private System.Windows.Forms.Button addOneMonitorBtn;
        private System.Windows.Forms.ListView monitorListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}