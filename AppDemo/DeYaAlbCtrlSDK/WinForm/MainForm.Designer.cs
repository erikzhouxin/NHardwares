namespace ALBDLLTester
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Btn_open = new System.Windows.Forms.Button();
            this.Btn_close = new System.Windows.Forms.Button();
            this.Btn_Raise = new System.Windows.Forms.Button();
            this.Btn_Fall = new System.Windows.Forms.Button();
            this.Btn_Getstate = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Btn_RegisEvent = new System.Windows.Forms.Button();
            this.Btn_ResgisMsg = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_q = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // Btn_open
            // 
            this.Btn_open.Location = new System.Drawing.Point(160, 12);
            this.Btn_open.Name = "Btn_open";
            this.Btn_open.Size = new System.Drawing.Size(48, 23);
            this.Btn_open.TabIndex = 2;
            this.Btn_open.Text = "打开";
            this.Btn_open.UseVisualStyleBackColor = true;
            this.Btn_open.Click += new System.EventHandler(this.Btn_open_Click);
            // 
            // Btn_close
            // 
            this.Btn_close.Location = new System.Drawing.Point(214, 12);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(40, 23);
            this.Btn_close.TabIndex = 3;
            this.Btn_close.Text = "关闭";
            this.Btn_close.UseVisualStyleBackColor = true;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Btn_Raise
            // 
            this.Btn_Raise.Location = new System.Drawing.Point(24, 163);
            this.Btn_Raise.Name = "Btn_Raise";
            this.Btn_Raise.Size = new System.Drawing.Size(75, 23);
            this.Btn_Raise.TabIndex = 4;
            this.Btn_Raise.Text = "抬杆";
            this.Btn_Raise.UseVisualStyleBackColor = true;
            this.Btn_Raise.Click += new System.EventHandler(this.Btn_Raise_Click);
            // 
            // Btn_Fall
            // 
            this.Btn_Fall.Location = new System.Drawing.Point(24, 192);
            this.Btn_Fall.Name = "Btn_Fall";
            this.Btn_Fall.Size = new System.Drawing.Size(75, 23);
            this.Btn_Fall.TabIndex = 5;
            this.Btn_Fall.Text = "落杆";
            this.Btn_Fall.UseVisualStyleBackColor = true;
            this.Btn_Fall.Click += new System.EventHandler(this.Btn_Fall_Click);
            // 
            // Btn_Getstate
            // 
            this.Btn_Getstate.Location = new System.Drawing.Point(24, 221);
            this.Btn_Getstate.Name = "Btn_Getstate";
            this.Btn_Getstate.Size = new System.Drawing.Size(75, 23);
            this.Btn_Getstate.TabIndex = 6;
            this.Btn_Getstate.Text = "获取状态";
            this.Btn_Getstate.UseVisualStyleBackColor = true;
            this.Btn_Getstate.Click += new System.EventHandler(this.Btn_Getstate_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 223);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 21);
            this.textBox2.TabIndex = 7;
            // 
            // Btn_RegisEvent
            // 
            this.Btn_RegisEvent.Location = new System.Drawing.Point(24, 105);
            this.Btn_RegisEvent.Name = "Btn_RegisEvent";
            this.Btn_RegisEvent.Size = new System.Drawing.Size(75, 23);
            this.Btn_RegisEvent.TabIndex = 8;
            this.Btn_RegisEvent.Text = "注册回调";
            this.Btn_RegisEvent.UseVisualStyleBackColor = true;
            this.Btn_RegisEvent.Click += new System.EventHandler(this.Btn_RegisEvent_Click);
            // 
            // Btn_ResgisMsg
            // 
            this.Btn_ResgisMsg.Location = new System.Drawing.Point(24, 134);
            this.Btn_ResgisMsg.Name = "Btn_ResgisMsg";
            this.Btn_ResgisMsg.Size = new System.Drawing.Size(75, 23);
            this.Btn_ResgisMsg.TabIndex = 9;
            this.Btn_ResgisMsg.Text = "注册消息";
            this.Btn_ResgisMsg.UseVisualStyleBackColor = true;
            this.Btn_ResgisMsg.Click += new System.EventHandler(this.Btn_ResgisMsg_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(26, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(306, 260);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "事件或消息";
            this.columnHeader2.Width = 240;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(172, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 293);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "事件或消息列表：";
            // 
            // button_q
            // 
            this.button_q.Location = new System.Drawing.Point(22, 291);
            this.button_q.Name = "button_q";
            this.button_q.Size = new System.Drawing.Size(75, 23);
            this.button_q.TabIndex = 14;
            this.button_q.Text = "启动队列";
            this.button_q.UseVisualStyleBackColor = true;
            this.button_q.Click += new System.EventHandler(this.button_q_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 385);
            this.Controls.Add(this.button_q);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_ResgisMsg);
            this.Controls.Add(this.Btn_RegisEvent);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Btn_Getstate);
            this.Controls.Add(this.Btn_Fall);
            this.Controls.Add(this.Btn_Raise);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.Btn_open);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALBDLLTester";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btn_open;
        private System.Windows.Forms.Button Btn_close;
        private System.Windows.Forms.Button Btn_Raise;
        private System.Windows.Forms.Button Btn_Fall;
        private System.Windows.Forms.Button Btn_Getstate;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Btn_RegisEvent;
        private System.Windows.Forms.Button Btn_ResgisMsg;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_q;
    }
}

