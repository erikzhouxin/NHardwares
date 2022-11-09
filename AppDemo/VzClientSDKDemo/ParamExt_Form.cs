using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VzClientSDKDemo
{
    public partial class ParamExt_Form : Form
    {
        private uint VZ_LPRC_USER_DATA_MAX_LEN = 128;
        private int m_hLPRClient = 0;
        public ParamExt_Form()
        {
            InitializeComponent();
        }
        public void SetLPRHandle(int m_hLPRClient_)
        {
            m_hLPRClient = m_hLPRClient_;
        }
        private void setbtn_Click(object sender, EventArgs e)
        {
            byte[] strUserData = System.Text.Encoding.Default.GetBytes(setedit.Text);
            GCHandle hObject = GCHandle.Alloc(strUserData, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();
            int rt = VzClientSDK.VzLPRClient_WriteUserData(m_hLPRClient, pObject, (uint)setedit.Text.Length);
            if(rt != 0)
            {
                MessageBox.Show("设置用户私有数据失败");
            }
            if (hObject.IsAllocated)
                hObject.Free();
        }

        private void getbtn_Click(object sender, EventArgs e)
        {
            byte[] strUserData = new byte[VZ_LPRC_USER_DATA_MAX_LEN + 1];
            GCHandle hObject = GCHandle.Alloc(strUserData, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();

            int nSizeData = VzClientSDK.VzLPRClient_ReadUserData(m_hLPRClient, pObject, VZ_LPRC_USER_DATA_MAX_LEN);
            if(nSizeData <= 0)
            {
                MessageBox.Show("获取用户私有数据失败");
            }
            getedit.Text = System.Text.Encoding.Default.GetString(strUserData);
            VzClientSDK.VZ_DEV_SERIAL_NUM struSN = new VzClientSDK.VZ_DEV_SERIAL_NUM();

            int rt = VzClientSDK.VzLPRClient_GetSerialNumber(m_hLPRClient, ref struSN);
            if(rt < 0)
            {
                MessageBox.Show("获取设备序列号失败");
                return;
            }

            snedit.Text = struSN.uHi.ToString("X8") + "-" + struSN.uLo.ToString("X8");

            if (hObject.IsAllocated)
                hObject.Free();
        }
    }
}
