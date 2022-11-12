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
    public partial class LocalDeviceAttribute : Form
    {
        //DeviceInfo deviceInfo;

        public LocalDeviceAttribute(NETDEMO_DeviceInfo deviceInfo)
        {
            InitializeComponent();
            this.IPText.Text = deviceInfo.m_ip;
            this.portText.Text = Convert.ToString(deviceInfo.m_port);
            this.userNameText.Text = deviceInfo.m_userName;
            this.passwordText.Text = deviceInfo.m_password;

            this.channelNumText.Text = Convert.ToString(deviceInfo.m_channelNumber);

            String str;
            switch (deviceInfo.m_stDevInfo.dwDevType)
            {
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_UNKNOWN:
                    str = "UNKNOWN";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC:
                    str = "IPC";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC_FISHEYE:
                    str = "IPC_DISECONOMIC_FISHEYE";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC_ECONOMIC_FISHEYE:
                    str = "IPC_ECONOMIC_FISHEYE";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_NVR:
                    str = "NVR";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_NVR_BACKUP:
                    str = "NVR_BACKUP";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_DC:
                    str = "DC";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_EC:
                    str = "EC";
                    break;
                case (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_VMS:
                    str = "VMS";
                    break;
                default:
                    str = "INVALID";
                    break;
            }
            this.deviceTypeText.Text = str;
            this.alarmInputNumText.Text = Convert.ToString(deviceInfo.m_stDevInfo.wAlarmInputNum);
            this.alarmOutputNumText.Text = Convert.ToString(deviceInfo.m_stDevInfo.wAlarmOutputNum);
        }
    }
}
