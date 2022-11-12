using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.YuShiNetDevSDK;

namespace YuShiNetDevSDK.WinForm
{
    public partial class Discovery : Form
    {
        static INetDevSdkProxy NETDEVSDK = NetDevSdk.Create();
        NetDemo m_oNetDemo = null;
        private List<NETDEV_DISCOVERY_DEVINFO_S> oDeviceInfoList = new List<NETDEV_DISCOVERY_DEVINFO_S>();
        private List<string> oDeviceIPList = new List<string>();
        private List<Int16> oDevicePortList = new List<short>();
        private List<string> oDeviceTypeList = new List<string>();

        public Discovery(NetDemo oNetDemo)
        {
            this.m_oNetDemo = oNetDemo;
            InitializeComponent();
        }

        //auto search
        private void AutoSearchBtn_Click(object sender, EventArgs e)
        {
            discovery("0.0.0.0", "0.0.0.0");
        }

        //segment search
        private void segmentSearchBtn_Click(object sender, EventArgs e)
        {
            string strStartIP = this.startIPext.Text;
            string strEndIP = this.endIPText.Text;
            discovery(strStartIP, strEndIP);
        }

        //add device
        private void addDeviceBtn_Click(object sender, EventArgs e)
        {
            String strUserName = this.userNameText.Text;
            String strPassword = this.passwordText.Text;
            if (strUserName == "" || strPassword == "")
            {
                return;
            }

            for (int i = 0; i < oDeviceIPList.Count() && i < oDevicePortList.Count(); i++)
            {
                NETDEMO_DEVICE_TYPE_E eDeviceType = NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR;
                if ("VMS" == oDeviceTypeList[i])
                {
                    eDeviceType = NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS;
                }
                m_oNetDemo.AddLocalDevice(oDeviceIPList[i], oDevicePortList[i], strUserName, strPassword, eDeviceType);
            }

            this.Close();
        }

        private void DeviceInfoListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.DeviceInfoListView.SelectedItems == null || this.DeviceInfoListView.SelectedItems.Count <= 0)
            {
                return;
            }

            String strIPAddr = null;
            String strDeviceType = null;
            Int16 udwPort = 0;

            oDeviceIPList.Clear();
            oDevicePortList.Clear();
            oDeviceTypeList.Clear();

            var selectedItems = this.DeviceInfoListView.SelectedItems;
            foreach (var selectedItem in selectedItems)
            {
                var item = (ListViewItem)selectedItem;
                strIPAddr = item.SubItems[1].Text;
                strDeviceType = item.SubItems[0].Text;
                try
                {
                    udwPort = Convert.ToInt16(item.SubItems[2].Text);
                    oDeviceIPList.Add(strIPAddr);
                    oDevicePortList.Add(udwPort);
                    oDeviceTypeList.Add(strDeviceType);
                }
                catch (FormatException)
                {
                    continue;
                }
                catch (OverflowException)
                {
                    continue;
                }
            }
        }

        private void discovery(String strStartIP, String strEndIP)
        {
            if (strStartIP == "" || strEndIP == "")
            {
                return;
            }

            oDeviceInfoList.Clear();
            DeviceInfoListView.Items.Clear();

            m_oNetDemo.discoveryCB = new NETDEV_DISCOVERY_CALLBACK_PF(discoveryCallBack);
            Int32 iRet = NETDEVSDK.NETDEV_SetDiscoveryCallBack(m_oNetDemo.discoveryCB, IntPtr.Zero);
            if (NetDevSdk.FALSE == iRet)
            {
                MessageBox.Show("set discovery callBack failed,the error is [" + NETDEVSDK.NETDEV_GetLastError().ToString() + "]");
                return;
            }

            iRet = NETDEVSDK.NETDEV_Discovery(strStartIP, strEndIP);
            if (NetDevSdk.FALSE == iRet)
            {
                MessageBox.Show("discovery failed,the error is [" + NETDEVSDK.NETDEV_GetLastError().ToString() + "]");
                return;
            }
        }

        //discovery callback
        private void discoveryCallBack(IntPtr pstDevInfo, IntPtr lpUserData)
        {
            NETDEV_DISCOVERY_DEVINFO_S stDevInfo = (NETDEV_DISCOVERY_DEVINFO_S)Marshal.PtrToStructure(pstDevInfo, typeof(NETDEV_DISCOVERY_DEVINFO_S));
            for (int i = 0; i < oDeviceInfoList.Count(); i++)
            {
                if (stDevInfo.szDevAddr == oDeviceInfoList[i].szDevAddr && stDevInfo.szDevSerailNum == oDeviceInfoList[i].szDevSerailNum)
                {
                    return;
                }
            }

            oDeviceInfoList.Add(stDevInfo);
            setDeviceInfoListView(stDevInfo);
        }

        private delegate void SetDeviceInfoListView(NETDEV_DISCOVERY_DEVINFO_S stDevInfo);
        private void setDeviceInfoListView(NETDEV_DISCOVERY_DEVINFO_S stDevInfo)
        {
            if (DeviceInfoListView.InvokeRequired)
            {
                SetDeviceInfoListView setInfo = new SetDeviceInfoListView(setDeviceInfoListView);
                DeviceInfoListView.Invoke(setInfo, new object[] { stDevInfo });
            }
            else
            {
                string str = null;
                switch (stDevInfo.enDevType)
                {
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_UNKNOWN:
                        str = "UNKNOWN";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC:
                        str = "IPC";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC_FISHEYE:
                        str = "IPC_DISECONOMIC_FISHEYE";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC_ECONOMIC_FISHEYE:
                        str = "IPC_ECONOMIC_FISHEYE";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_NVR:
                        str = "NVR";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_NVR_BACKUP:
                        str = "NVR_BACKUP";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_DC:
                        str = "DC";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_EC:
                        str = "EC";
                        break;
                    case NETDEV_DEVICETYPE_E.NETDEV_DTYPE_VMS:
                        str = "VMS";
                        break;
                    default:
                        str = "INVALID";
                        break;
                }

                ListViewItem oListViewItem = new ListViewItem(str);
                oListViewItem.SubItems.AddRange(new String[] { stDevInfo.szDevAddr, Convert.ToString(stDevInfo.dwDevPort), stDevInfo.szDevMac, stDevInfo.szDevSerailNum, stDevInfo.szManuFacturer });
                this.DeviceInfoListView.Items.Add(oListViewItem);
                deviceNumberLabel.Text = Convert.ToString(DeviceInfoListView.Items.Count);
                oListViewItem.EnsureVisible();
            }
        }

    }
}
