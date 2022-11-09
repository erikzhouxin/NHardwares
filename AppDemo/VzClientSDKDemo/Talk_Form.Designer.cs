namespace VzClientSDKDemo
{
    partial class Talk_Form
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
            this.button_TalkRecive = new System.Windows.Forms.Button();
            this.button_TalkClose = new System.Windows.Forms.Button();
            this.button_Record = new System.Windows.Forms.Button();
            this.treeView_Talk = new System.Windows.Forms.TreeView();
            this.timer_call = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button_TalkRecive
            // 
            this.button_TalkRecive.Location = new System.Drawing.Point(14, 212);
            this.button_TalkRecive.Name = "button_TalkRecive";
            this.button_TalkRecive.Size = new System.Drawing.Size(75, 23);
            this.button_TalkRecive.TabIndex = 1;
            this.button_TalkRecive.Text = "呼叫/接听";
            this.button_TalkRecive.UseVisualStyleBackColor = true;
            this.button_TalkRecive.Click += new System.EventHandler(this.button_TalkRecive_Click);
            // 
            // button_TalkClose
            // 
            this.button_TalkClose.Location = new System.Drawing.Point(107, 212);
            this.button_TalkClose.Name = "button_TalkClose";
            this.button_TalkClose.Size = new System.Drawing.Size(75, 23);
            this.button_TalkClose.TabIndex = 1;
            this.button_TalkClose.Text = "挂断";
            this.button_TalkClose.UseVisualStyleBackColor = true;
            this.button_TalkClose.Click += new System.EventHandler(this.button_TalkClose_Click);
            // 
            // button_Record
            // 
            this.button_Record.Location = new System.Drawing.Point(197, 212);
            this.button_Record.Name = "button_Record";
            this.button_Record.Size = new System.Drawing.Size(75, 23);
            this.button_Record.TabIndex = 1;
            this.button_Record.Text = "开始录音";
            this.button_Record.UseVisualStyleBackColor = true;
            this.button_Record.Click += new System.EventHandler(this.button_Record_Click);
            // 
            // treeView_Talk
            // 
            this.treeView_Talk.Location = new System.Drawing.Point(14, 13);
            this.treeView_Talk.Name = "treeView_Talk";
            this.treeView_Talk.Size = new System.Drawing.Size(258, 193);
            this.treeView_Talk.TabIndex = 2;
            // 
            // timer_call
            // 
            this.timer_call.Interval = 1000;
            this.timer_call.Tick += new System.EventHandler(this.timer_call_Tick);
            // 
            // Talk_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.treeView_Talk);
            this.Controls.Add(this.button_Record);
            this.Controls.Add(this.button_TalkClose);
            this.Controls.Add(this.button_TalkRecive);
            this.Name = "Talk_Form";
            this.Text = "对讲功能";
            this.Load += new System.EventHandler(this.Talk_Form_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Talk_Form_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_TalkRecive;
        private System.Windows.Forms.Button button_TalkClose;
        private System.Windows.Forms.Button button_Record;
        private System.Windows.Forms.TreeView treeView_Talk;
        private System.Windows.Forms.Timer timer_call;
    }
}