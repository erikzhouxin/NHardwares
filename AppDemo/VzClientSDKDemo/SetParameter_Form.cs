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
    public partial class SetParameter_Form : Form
    {

        private int m_hLPRClient = 0;
        public SetParameter_Form()
        {
            InitializeComponent();
        }
        public void SetLPRHandle(int m_hLPRClient_)
        {
            m_hLPRClient = m_hLPRClient_;
            preprovince.Items.Add("无");
            VzClientSDK.VZ_LPRC_PROVINCE_INFO struProvInfo = new VzClientSDK.VZ_LPRC_PROVINCE_INFO();
            int provtemp = VzClientSDK.VzLPRClient_GetSupportedProvinces(m_hLPRClient, ref struProvInfo);
            if(provtemp == 0)
            {
                char[] strProv0 = new char[2];
                int nProvNum = Marshal.SizeOf(struProvInfo) / 4 - 2;
                int offset = 0;
                for(int i = 0;i < nProvNum;i++)
                {
                    System.Buffer.BlockCopy(struProvInfo.strProvinces, offset, strProv0, 0, 2);
                    offset += 2;
                    string strprov = new string(strProv0);
                    preprovince.Items.Add(strprov);
                }
                if(struProvInfo.nCurrIndex >= 0 && struProvInfo.nCurrIndex < nProvNum)
                {
                    preprovince.SelectedIndex = struProvInfo.nCurrIndex + 1;
                }
                else
                {
                    preprovince.SelectedIndex = 0;
                }
            }

        }
        private void savebtn_Click(object sender, EventArgs e)
        {

        }

        private void preprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = preprovince.SelectedIndex;
            int rt = VzClientSDK.VzLPRClient_PresetProvinceIndex(m_hLPRClient, idx - 1);
            if(rt != 0)
            {
                MessageBox.Show("默认省份设置失败");
            }
        }
    }
}
