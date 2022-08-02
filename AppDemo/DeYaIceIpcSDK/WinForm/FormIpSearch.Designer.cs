namespace TestDll
{
    partial class FormIpSearch
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
            this.textBoxDev = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDev
            // 
            this.textBoxDev.Location = new System.Drawing.Point(12, 12);
            this.textBoxDev.Multiline = true;
            this.textBoxDev.Name = "textBoxDev";
            this.textBoxDev.ReadOnly = true;
            this.textBoxDev.Size = new System.Drawing.Size(333, 461);
            this.textBoxDev.TabIndex = 0;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(366, 22);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 1;
            this.button_search.Text = "搜索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // FormIpSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 501);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBoxDev);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIpSearch";
            this.Text = "FormIpSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDev;
        private System.Windows.Forms.Button button_search;
    }
}