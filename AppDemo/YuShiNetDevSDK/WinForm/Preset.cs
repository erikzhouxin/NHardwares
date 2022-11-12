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
    public partial class Preset : Form
    {
        static INetDevSdkProxy NETDEVSDK = NetDevSdk.Create();
        NetDemo m_oNetDemo;
        public Preset(NetDemo netDemo)
        {
            InitializeComponent();
            this.m_oNetDemo = netDemo;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (m_oNetDemo.getChannelID() == -1)
            {
                return;
            }

            int dwChannelID = m_oNetDemo.getChannelID();
            IntPtr lpHandle = m_oNetDemo.getDeviceInfoList()[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            
            if (IntPtr.Zero == lpHandle)
            {
                MessageBox.Show("Device Handle is 0 ","warning");
                return;
            }

            String szPresetName;

            Int32 lPresetID = -1;
            try
            {
                lPresetID = Convert.ToInt32(this.presetIDText.Text);
            }
            catch (FormatException)
            {
                return;
            }

            szPresetName = this.presetNameText.Text;

            if(0 >= lPresetID || lPresetID > NetDevSdk.NETDEV_MAX_PRESET_NUM)
            {
                MessageBox.Show("Preset ID invalid.","warning");
                return;
            }

            byte[] byPresetName;
            GetUTF8Buffer(szPresetName, NetDevSdk.NETDEV_LEN_32, out byPresetName);

            int bRet = NETDEVSDK.NETDEV_PTZPreset_Other(lpHandle, dwChannelID, (int)NETDEV_PTZ_PRESETCMD_E.NETDEV_PTZ_SET_PRESET, byPresetName, lPresetID);
            if (NetDevSdk.TRUE != bRet)
            {
                m_oNetDemo.showFailLogInfo(m_oNetDemo.getDeviceInfoList()[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Set preset", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                m_oNetDemo.showSuccessLogInfo(m_oNetDemo.getDeviceInfoList()[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Set preset");

                m_oNetDemo.presetGetBtn_Click(null, null);
                this.Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetUTF8Buffer(string inputString, int bufferLen, out byte[] utf8Buffer)
        {
            utf8Buffer = new byte[bufferLen];
            byte[] tempBuffer = System.Text.Encoding.UTF8.GetBytes(inputString);
            for (int i = 0; i < tempBuffer.Length; ++i)
            {
                utf8Buffer[i] = tempBuffer[i];
            }
        }
    }
}
