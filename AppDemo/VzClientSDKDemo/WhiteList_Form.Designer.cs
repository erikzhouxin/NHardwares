namespace VzClientSDKDemo
{
    partial class WhiteList_Form
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
            this.btnImportWL = new System.Windows.Forms.Button();
            this.btnClearWL = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrePage = new System.Windows.Forms.Button();
            this.lblCountMsg = new System.Windows.Forms.Label();
            this.lblPageMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addbt
            // 
            this.addbt.Location = new System.Drawing.Point(27, 25);
            this.addbt.Name = "addbt";
            this.addbt.Size = new System.Drawing.Size(56, 23);
            this.addbt.TabIndex = 0;
            this.addbt.Text = "添加";
            this.addbt.UseVisualStyleBackColor = true;
            this.addbt.Click += new System.EventHandler(this.addbt_Click);
            // 
            // changebt
            // 
            this.changebt.Location = new System.Drawing.Point(104, 24);
            this.changebt.Name = "changebt";
            this.changebt.Size = new System.Drawing.Size(52, 24);
            this.changebt.TabIndex = 1;
            this.changebt.Text = "修改";
            this.changebt.UseVisualStyleBackColor = true;
            this.changebt.Click += new System.EventHandler(this.changebt_Click);
            // 
            // deletebt
            // 
            this.deletebt.Location = new System.Drawing.Point(178, 24);
            this.deletebt.Name = "deletebt";
            this.deletebt.Size = new System.Drawing.Size(50, 24);
            this.deletebt.TabIndex = 2;
            this.deletebt.Text = "删除";
            this.deletebt.UseVisualStyleBackColor = true;
            this.deletebt.Click += new System.EventHandler(this.deletebt_Click);
            // 
            // searchtext
            // 
            this.searchtext.Location = new System.Drawing.Point(322, 26);
            this.searchtext.Name = "searchtext";
            this.searchtext.Size = new System.Drawing.Size(95, 21);
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
            this.listView1.Location = new System.Drawing.Point(22, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(474, 353);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnImportWL
            // 
            this.btnImportWL.Location = new System.Drawing.Point(22, 441);
            this.btnImportWL.Name = "btnImportWL";
            this.btnImportWL.Size = new System.Drawing.Size(79, 23);
            this.btnImportWL.TabIndex = 6;
            this.btnImportWL.Text = "批量导入";
            this.btnImportWL.UseVisualStyleBackColor = true;
            this.btnImportWL.Click += new System.EventHandler(this.btnImportWL_Click);
            // 
            // btnClearWL
            // 
            this.btnClearWL.Location = new System.Drawing.Point(245, 24);
            this.btnClearWL.Name = "btnClearWL";
            this.btnClearWL.Size = new System.Drawing.Size(53, 24);
            this.btnClearWL.TabIndex = 7;
            this.btnClearWL.Text = "清空";
            this.btnClearWL.UseVisualStyleBackColor = true;
            this.btnClearWL.Click += new System.EventHandler(this.btnClearWL_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(194, 441);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(45, 23);
            this.btnFirstPage.TabIndex = 8;
            this.btnFirstPage.Text = "首页";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(372, 441);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(50, 23);
            this.btnLastPage.TabIndex = 9;
            this.btnLastPage.Text = "尾页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(309, 441);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(57, 23);
            this.btnNextPage.TabIndex = 10;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrePage
            // 
            this.btnPrePage.Location = new System.Drawing.Point(245, 441);
            this.btnPrePage.Name = "btnPrePage";
            this.btnPrePage.Size = new System.Drawing.Size(58, 23);
            this.btnPrePage.TabIndex = 11;
            this.btnPrePage.Text = "上一页";
            this.btnPrePage.UseVisualStyleBackColor = true;
            this.btnPrePage.Click += new System.EventHandler(this.btnPrePage_Click);
            // 
            // lblCountMsg
            // 
            this.lblCountMsg.AutoSize = true;
            this.lblCountMsg.Location = new System.Drawing.Point(428, 446);
            this.lblCountMsg.Name = "lblCountMsg";
            this.lblCountMsg.Size = new System.Drawing.Size(0, 12);
            this.lblCountMsg.TabIndex = 14;
            // 
            // lblPageMsg
            // 
            this.lblPageMsg.AutoSize = true;
            this.lblPageMsg.Location = new System.Drawing.Point(133, 447);
            this.lblPageMsg.Name = "lblPageMsg";
            this.lblPageMsg.Size = new System.Drawing.Size(0, 12);
            this.lblPageMsg.TabIndex = 15;
            // 
            // WhiteList_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 476);
            this.Controls.Add(this.lblPageMsg);
            this.Controls.Add(this.lblCountMsg);
            this.Controls.Add(this.btnPrePage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.btnClearWL);
            this.Controls.Add(this.btnImportWL);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.searchbt);
            this.Controls.Add(this.searchtext);
            this.Controls.Add(this.deletebt);
            this.Controls.Add(this.changebt);
            this.Controls.Add(this.addbt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WhiteList_Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "白名单";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addbt;
        private System.Windows.Forms.Button changebt;
        private System.Windows.Forms.Button deletebt;
        private System.Windows.Forms.TextBox searchtext;
        private System.Windows.Forms.Button searchbt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnImportWL;
        private System.Windows.Forms.Button btnClearWL;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrePage;
        private System.Windows.Forms.Label lblCountMsg;
        private System.Windows.Forms.Label lblPageMsg;

    }
}