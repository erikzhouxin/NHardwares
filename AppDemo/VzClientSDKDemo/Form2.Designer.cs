namespace VzClientSDKDemo
{
    partial class Form2
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
            this.addbt = new System.Windows.Forms.Button();
            this.changebt = new System.Windows.Forms.Button();
            this.deletebt = new System.Windows.Forms.Button();
            this.searchtext = new System.Windows.Forms.TextBox();
            this.searchbt = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // addbt
            // 
            this.addbt.Location = new System.Drawing.Point(27, 25);
            this.addbt.Name = "addbt";
            this.addbt.Size = new System.Drawing.Size(75, 23);
            this.addbt.TabIndex = 0;
            this.addbt.Text = "添加";
            this.addbt.UseVisualStyleBackColor = true;
            this.addbt.Click += new System.EventHandler(this.addbt_Click);
            // 
            // changebt
            // 
            this.changebt.Location = new System.Drawing.Point(118, 25);
            this.changebt.Name = "changebt";
            this.changebt.Size = new System.Drawing.Size(75, 23);
            this.changebt.TabIndex = 1;
            this.changebt.Text = "修改";
            this.changebt.UseVisualStyleBackColor = true;
            this.changebt.Click += new System.EventHandler(this.changebt_Click);
            // 
            // deletebt
            // 
            this.deletebt.Location = new System.Drawing.Point(209, 25);
            this.deletebt.Name = "deletebt";
            this.deletebt.Size = new System.Drawing.Size(75, 23);
            this.deletebt.TabIndex = 2;
            this.deletebt.Text = "删除";
            this.deletebt.UseVisualStyleBackColor = true;
            this.deletebt.Click += new System.EventHandler(this.deletebt_Click);
            // 
            // searchtext
            // 
            this.searchtext.Location = new System.Drawing.Point(319, 26);
            this.searchtext.Name = "searchtext";
            this.searchtext.Size = new System.Drawing.Size(98, 21);
            this.searchtext.TabIndex = 3;
            // 
            // searchbt
            // 
            this.searchbt.Location = new System.Drawing.Point(433, 24);
            this.searchbt.Name = "searchbt";
            this.searchbt.Size = new System.Drawing.Size(53, 23);
            this.searchbt.TabIndex = 4;
            this.searchbt.Text = "查询";
            this.searchbt.UseVisualStyleBackColor = true;
            this.searchbt.Click += new System.EventHandler(this.searchbt_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(27, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(459, 252);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 361);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.searchbt);
            this.Controls.Add(this.searchtext);
            this.Controls.Add(this.deletebt);
            this.Controls.Add(this.changebt);
            this.Controls.Add(this.addbt);
            this.Name = "Form2";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.listView1.Columns.Add("车牌 ID");
            this.listView1.Columns.Add("车牌号");
            this.listView1.Columns.Add("是否启用");
            this.listView1.Columns.Add("过期时间");
            this.listView1.Columns.Add("是否报警");
            this.listView1.View = System.Windows.Forms.View.Details;
            listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            //listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            listView1.Columns[0].Width = 70;
            listView1.Columns[1].Width = 90;
            listView1.Columns[2].Width = 70;
            listView1.Columns[3].Width = 155;
            listView1.Columns[4].Width = 70;


            

        }

        #endregion

        private System.Windows.Forms.Button addbt;
        private System.Windows.Forms.Button changebt;
        private System.Windows.Forms.Button deletebt;
        private System.Windows.Forms.TextBox searchtext;
        private System.Windows.Forms.Button searchbt;
        private System.Windows.Forms.ListView listView1;

    }
}