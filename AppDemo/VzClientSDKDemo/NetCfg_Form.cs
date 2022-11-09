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
    public partial class NetCfg_Form : Form
    {
        private string m_strIP;
        private uint  m_nSL	= 0;
	    private uint  m_nSH	= 0;
        private string m_strNetmask;
        private string m_strGateway;

        public NetCfg_Form()
        {
            InitializeComponent();
        }

        public void SetNetParam(string strIP, uint SL, uint SH, string netmask, string gateway)
        {
	        m_strIP = strIP;
	        m_nSL	= SL;
	        m_nSH	= SH;
            m_strNetmask = netmask;
            m_strGateway = gateway;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strIP = txtIP.Text;

            string strNetmask = txtMask.Text;

            string strGateway = txtGateway.Text;

            int ret = VzClientSDK.VzLPRClient_UpdateNetworkParam(m_nSH, m_nSL, strIP, strGateway, strNetmask);
            if (ret == 2)
            {
                MessageBox.Show("设备IP跟网关不在同一网段，请重新输入!");
            }
            else if (ret == -1)
            {
                MessageBox.Show("修改网络参数失败，请重新输入!");
            }

            MessageBox.Show("修改网络参数成功");
        }

        private void NetCfg_Form_Load(object sender, EventArgs e)
        {
            txtIP.Text      = m_strIP;
            txtMask.Text    = m_strNetmask;
            txtGateway.Text = m_strGateway;
        }
    }
}
