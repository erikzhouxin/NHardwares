namespace VzClientSDKDemo
{
    partial class PlateQuery_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.starttimeday = new System.Windows.Forms.DateTimePicker();
            this.starttimehour = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.endtimeday = new System.Windows.Forms.DateTimePicker();
            this.endtimehour = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.plateedit = new System.Windows.Forms.TextBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.prepage = new System.Windows.Forms.Button();
            this.nextpage = new System.Windows.Forms.Button();
            this.platemsglabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间";
            // 
            // starttimeday
            // 
            this.starttimeday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.starttimeday.Location = new System.Drawing.Point(69, 13);
            this.starttimeday.Name = "starttimeday";
            this.starttimeday.Size = new System.Drawing.Size(83, 21);
            this.starttimeday.TabIndex = 8;
            // 
            // starttimehour
            // 
            this.starttimehour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.starttimehour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.starttimehour.Location = new System.Drawing.Point(155, 13);
            this.starttimehour.Name = "starttimehour";
            this.starttimehour.ShowUpDown = true;
            this.starttimehour.Size = new System.Drawing.Size(83, 21);
            this.starttimehour.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间";
            // 
            // endtimeday
            // 
            this.endtimeday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endtimeday.Location = new System.Drawing.Point(314, 13);
            this.endtimeday.Name = "endtimeday";
            this.endtimeday.Size = new System.Drawing.Size(79, 21);
            this.endtimeday.TabIndex = 4;
            // 
            // endtimehour
            // 
            this.endtimehour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endtimehour.Location = new System.Drawing.Point(397, 13);
            this.endtimehour.Name = "endtimehour";
            this.endtimehour.ShowUpDown = true;
            this.endtimehour.Size = new System.Drawing.Size(85, 21);
            this.endtimehour.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(15, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(505, 271);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "车牌号";
            // 
            // plateedit
            // 
            this.plateedit.Location = new System.Drawing.Point(69, 40);
            this.plateedit.Name = "plateedit";
            this.plateedit.Size = new System.Drawing.Size(83, 21);
            this.plateedit.TabIndex = 1;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(159, 40);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(52, 20);
            this.searchbtn.TabIndex = 9;
            this.searchbtn.Text = "查询";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // prepage
            // 
            this.prepage.Location = new System.Drawing.Point(381, 351);
            this.prepage.Name = "prepage";
            this.prepage.Size = new System.Drawing.Size(54, 23);
            this.prepage.TabIndex = 10;
            this.prepage.Text = "上一页";
            this.prepage.UseVisualStyleBackColor = true;
            this.prepage.Click += new System.EventHandler(this.prepage_Click);
            // 
            // nextpage
            // 
            this.nextpage.Location = new System.Drawing.Point(465, 351);
            this.nextpage.Name = "nextpage";
            this.nextpage.Size = new System.Drawing.Size(54, 23);
            this.nextpage.TabIndex = 11;
            this.nextpage.Text = "下一页";
            this.nextpage.UseVisualStyleBackColor = true;
            this.nextpage.Click += new System.EventHandler(this.nextpage_Click);
            // 
            // platemsglabel
            // 
            this.platemsglabel.AutoSize = true;
            this.platemsglabel.Location = new System.Drawing.Point(28, 356);
            this.platemsglabel.Name = "platemsglabel";
            this.platemsglabel.Size = new System.Drawing.Size(0, 12);
            this.platemsglabel.TabIndex = 12;
            // 
            // PlateQuery_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 381);
            this.Controls.Add(this.platemsglabel);
            this.Controls.Add(this.nextpage);
            this.Controls.Add(this.prepage);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.plateedit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.endtimehour);
            this.Controls.Add(this.endtimeday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.starttimehour);
            this.Controls.Add(this.starttimeday);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlateQuery_Form";
            this.Text = "PlateQuery_Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker starttimeday;
        private System.Windows.Forms.DateTimePicker starttimehour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endtimeday;
        private System.Windows.Forms.DateTimePicker endtimehour;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox plateedit;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Button prepage;
        private System.Windows.Forms.Button nextpage;
        private System.Windows.Forms.Label platemsglabel;
    }
}