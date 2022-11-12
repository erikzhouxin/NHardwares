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
    public partial class AddDevice : Form
    {
        private NetDemo m_oNetDemo = null;

        public AddDevice(NetDemo oNetDemo)
        {
            this.m_oNetDemo = oNetDemo;
            InitializeComponent();
        }

        private void CannelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            NETDEMO_DEVICE_TYPE_E eDeviceType = NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR;
            if (1 == this.DeviceTypeCmb.SelectedIndex)
            {
                eDeviceType = NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS;
            }
            
            String strIPAddr = this.ipDomainNameText.Text;
            Int32 sPort = 0;
            try
            {
                sPort = Convert.ToInt32(this.portText.Text);
            }
            catch (FormatException)
            {
                return;
            }
            catch (OverflowException)
            {
                return;
            }

            String strUserName = this.userNameText.Text;
            String strPassword = this.passwordText.Text;

            m_oNetDemo.AddLocalDevice(strIPAddr, sPort, strUserName, strPassword, eDeviceType);
            this.Close();
        }
    }
}
