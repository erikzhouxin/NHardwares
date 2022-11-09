using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VzClientSDKDemo
{
    public partial class QueryPicShow : Form
    {
        public QueryPicShow()
        {
            InitializeComponent();
        }

        public void SetPicPath(string picpath)
        {
            ShowPicResult(picpath);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private delegate void ShowResultPicThread();
        //触发结果显示
        public void ShowPicResult(string path)
        {
            ShowResultPicThread picDelegate = delegate()
            {
                pictureBox1.Image = Image.FromFile(path);
            };
            pictureBox1.Invoke(picDelegate);
        }
    }
}
