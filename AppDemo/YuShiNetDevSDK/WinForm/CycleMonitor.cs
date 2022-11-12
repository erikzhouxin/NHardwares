using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.YuShiNetDevSDK;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YuShiNetDevSDK.WinForm
{
    public partial class CycleMonitor : Form
    {
        NetDemo m_oNetDemo = null;

        NETDEMO_MONITOR_TYPE_E m_iMonitorType = 0;
        int m_iIntervalTime = 20;
        int m_iPanelNo = 0;

        int m_iUnmonitorLVSelectedIndex = 0;
        int m_iMonitorLVSelectedIndex = 0;

        //cycle monitor
        public CycleMonitor(NetDemo oNetDemo)
        {
            InitializeComponent();

            m_oNetDemo = oNetDemo;
            int k = 0;
            for (int i = 0; i < m_oNetDemo.getDeviceInfoList().Count; i++)
            {
                //int correctValue = 0;
                for(int j = 0; j < m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList.Count; j++)
                {
                    if (m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList[j].m_devVideoChlInfo.enStatus == (int)NETDEV_CHANNEL_STATUS_E.NETDEV_CHL_STATUS_ONLINE)
                    {
                        if (m_oNetDemo.m_cycleMonitorInfo != null)
                        {
                            if (k < m_oNetDemo.m_cycleMonitorInfo.monitorCount)
                            {
                                ListViewItem oListViewItem = null;
                                if (m_oNetDemo.m_cycleMonitorInfo.channelInfoList[k].channelID == m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList[j].m_devVideoChlInfo.dwChannelID
                                    && m_oNetDemo.m_cycleMonitorInfo.channelInfoList[k].devhandle == m_oNetDemo.getDeviceInfoList()[i].m_lpDevHandle)
                                {
                                    oListViewItem = new ListViewItem(m_oNetDemo.getDeviceInfoList()[i].m_ip);
                                    oListViewItem.SubItems.Add(Convert.ToString(m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList[j].m_devVideoChlInfo.dwChannelID));

                                    this.monitorListView.Items.Add(oListViewItem);
                                    oListViewItem.EnsureVisible();
                                    k++;
                                }
                                else
                                {
                                    oListViewItem = new ListViewItem(m_oNetDemo.getDeviceInfoList()[i].m_ip);
                                    oListViewItem.SubItems.Add(Convert.ToString(m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList[j].m_devVideoChlInfo.dwChannelID));

                                    this.unmonitorListView.Items.Add(oListViewItem);
                                    oListViewItem.EnsureVisible();
                                }
                            }
                            else
                            {
                                ListViewItem oListViewItem = new ListViewItem(m_oNetDemo.getDeviceInfoList()[i].m_ip);
                                oListViewItem.SubItems.Add(Convert.ToString(m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList[j].m_devVideoChlInfo.dwChannelID));

                                this.unmonitorListView.Items.Add(oListViewItem);
                                oListViewItem.EnsureVisible();
                            }

                        }
                        else
                        {
                            ListViewItem oListViewItem = new ListViewItem(m_oNetDemo.getDeviceInfoList()[i].m_ip);
                            oListViewItem.SubItems.Add(Convert.ToString(m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList[j].m_devVideoChlInfo.dwChannelID));
                            this.unmonitorListView.Items.Add(oListViewItem);
                            oListViewItem.EnsureVisible();
                        }
                    }
                }
            }

            if (m_oNetDemo.m_cycleMonitorInfo != null)
            {
                this.cycleMonitorTypeCobBox.SelectedIndex = (int)m_oNetDemo.m_cycleMonitorInfo.monitorType;
                this.cycleMonitorWinNoCobBox.SelectedIndex = m_oNetDemo.m_cycleMonitorInfo.panelNo;
                this.monitorIntervalText.Text = Convert.ToString(m_oNetDemo.m_cycleMonitorInfo.intervalTime);

                this.startMonitorBtn.Enabled = false;
                this.addAllMonitorBtn.Enabled = false;
                this.addOneMonitorBtn.Enabled = false;
                this.delAllMonitorBtn.Enabled = false;
                this.delOneMonitorBtn.Enabled = false;
            }
            else
            {
                this.stopMonitorBtn.Enabled = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cycleMonitorTypeCobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == (sender as ComboBox).SelectedIndex)
            {
                m_iMonitorType = NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_SINGLE_SCREEN;
                //m_netDemo.getCycleMonitorInfo().monitorType = GeneralDef.NetDevSdk.NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_SINGLE_SCREEN;
                cycleMonitorWinNoCobBox.Enabled = true;
            }
            else
            {
                m_iMonitorType = NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_ALL_SCREEN;
                //m_netDemo.m_cycleMonitorInfo.monitorType = GeneralDef.NetDevSdk.NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_ALL_SCREEN;
                cycleMonitorWinNoCobBox.Enabled = false;
            }
        }

        private void monitorIntervalText_TextChanged(object sender, EventArgs e)
        {
            int iIntervalTime = 20;
            try
            {
                iIntervalTime = Convert.ToInt32(monitorIntervalText.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Incorrect time intervel type");
                return;
            }

            m_iIntervalTime = iIntervalTime;
            //m_netDemo.m_cycleMonitorInfo.intervalTime = intervalTime;
        }

        private void cycleMonitorWinNoCobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_iPanelNo = (sender as ComboBox).SelectedIndex;
        }

        private void startMonitorBtn_Click(object sender, EventArgs e)
        {
            if (monitorListView.Items.Count == 0)
            {
                return;
            }

            m_oNetDemo.m_cycleMonitorInfo = new NETDEMO_CycleMonitorInfo();
            this.stopMonitorBtn.Enabled = true;
            this.startMonitorBtn.Enabled = false;

            this.startMonitorBtn.Enabled = false;
            this.addAllMonitorBtn.Enabled = false;
            this.addOneMonitorBtn.Enabled = false;
            this.delAllMonitorBtn.Enabled = false;
            this.delOneMonitorBtn.Enabled = false;

            foreach (ListViewItem item in monitorListView.Items)
            {
                string strIP = item.SubItems[0].Text;
                int iChannelID = Convert.ToInt32(item.SubItems[1].Text);

                for (int i = 0; i < m_oNetDemo.getDeviceInfoList().Count; i++)
                {
                    if (strIP != m_oNetDemo.getDeviceInfoList()[i].m_ip)
                    {
                        continue;
                    }

                    for (int j = 0; j < m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList.Count; j++)
                    {
                        if (iChannelID == m_oNetDemo.getDeviceInfoList()[i].m_channelInfoList[j].m_devVideoChlInfo.dwChannelID)
                        {
                            NETDEMO_CycleMonitorInfo.CYCLE_MONITOR_CHANNEL_INFO_S cycleMonitorChannelInfo;
                            cycleMonitorChannelInfo.channelID = iChannelID;
                            cycleMonitorChannelInfo.devhandle = m_oNetDemo.getDeviceInfoList()[i].m_lpDevHandle;
                            cycleMonitorChannelInfo.deviceIndex = i;
                            m_oNetDemo.m_cycleMonitorInfo.channelInfoList.Add(cycleMonitorChannelInfo);
                            break;
                        }
                    }

                    break;// Not Found
                }
            }

            m_oNetDemo.m_cycleMonitorInfo.monitorCount = monitorListView.Items.Count;
            m_oNetDemo.m_cycleMonitorInfo.monitorType = m_iMonitorType;
            m_oNetDemo.m_cycleMonitorInfo.intervalTime = m_iIntervalTime;
            m_oNetDemo.m_cycleMonitorInfo.panelNo = m_iPanelNo;

            m_oNetDemo.startCycleMonitorThread();
        }

        //stop monitor thread
        private void stopMonitorBtn_Click(object sender, EventArgs e)
        {
            m_oNetDemo.stopCycleMonitorThread();

            m_oNetDemo.m_cycleMonitorInfo = null;

            foreach (ListViewItem item in monitorListView.Items)
            {
                this.unmonitorListView.Items.Add((ListViewItem)item.Clone());
            }

            this.monitorListView.Items.Clear();

            this.stopMonitorBtn.Enabled = false;
            this.startMonitorBtn.Enabled = true;

            this.startMonitorBtn.Enabled = true;
            this.addAllMonitorBtn.Enabled = true;
            this.addOneMonitorBtn.Enabled = true;
            this.delAllMonitorBtn.Enabled = true;
            this.delOneMonitorBtn.Enabled = true;
        }

        private void addAllMonitorBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.unmonitorListView.Items.Count; i++)
            {
                monitorListView.Items.Add((ListViewItem)unmonitorListView.Items[i].Clone());
            }

            this.unmonitorListView.Items.Clear();
        }

        //add one monitor
        private void addOneMonitorBtn_Click(object sender, EventArgs e)
        {
            if (0 != unmonitorListView.Items.Count)
            {
                this.monitorListView.Items.Add((ListViewItem)this.unmonitorListView.Items[m_iUnmonitorLVSelectedIndex].Clone());
                this.unmonitorListView.Items.Remove(this.unmonitorListView.Items[m_iUnmonitorLVSelectedIndex]);
                m_iUnmonitorLVSelectedIndex = 0;
            }
        }

        //delete one monitor
        private void delOneMonitorBtn_Click(object sender, EventArgs e)
        {
            if (0 != monitorListView.Items.Count)
            {
                this.unmonitorListView.Items.Add((ListViewItem)this.monitorListView.Items[m_iMonitorLVSelectedIndex].Clone());
                this.monitorListView.Items.Remove(this.monitorListView.Items[m_iMonitorLVSelectedIndex]);
                m_iMonitorLVSelectedIndex = 0;
            }
        }

        //delete all monitor
        private void delAllMonitorBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in monitorListView.Items)
            {
                this.unmonitorListView.Items.Add((ListViewItem)item.Clone());
            }

            monitorListView.Items.Clear();
        }

        private void unmonitorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unmonitorListView.SelectedItems.Count != 0)
            {
                m_iUnmonitorLVSelectedIndex = this.unmonitorListView.SelectedIndices[0];
            }
        }

        private void monitorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (monitorListView.SelectedItems.Count != 0)
            {
                m_iMonitorLVSelectedIndex = this.monitorListView.SelectedIndices[0];
            }
        }
    }
}
