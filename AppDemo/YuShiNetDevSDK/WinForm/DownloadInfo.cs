using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.YuShiNetDevSDK;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeneralDef;

namespace YuShiNetDevSDK.WinForm
{
    public partial class DownloadInfo : Form
    {
        private int m_iLastCount = 0;

        public DownloadInfo()
        {
            InitializeComponent();
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void setListView(NETDEMO_UPDATE_TIME_INFO stUpdateInfo)
        {
            ListViewItem item = new ListViewItem(stUpdateInfo.strFileName);
            item.SubItems.AddRange(new String[] { getStrTime(stUpdateInfo.tBeginTime), getStrTime(stUpdateInfo.tEndTime), "0", stUpdateInfo.strFilePath });
            this.listView.Items.Add(item);
        }

        private string getStrTime(long time)
        {
            DateTime startDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            return startDateTime.AddSeconds(time).ToString("yyyy/MM/dd HH:mm:ss");
        }

        //update progress
        public void updateProgress(int index, int progressValue)
        {
            this.listView.Items[index].SubItems[3].Text = Convert.ToString(progressValue);
        }

        public int getListViewItemLastCount()
        {
            return m_iLastCount;
        }

        public int getListViewItemCount()
        {
            return this.listView.Items.Count;
        }

        public int setListViewItemLastCount()
        {
            return m_iLastCount = this.listView.Items.Count;
        }
    }
}
