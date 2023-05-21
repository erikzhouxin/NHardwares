using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.VzClientSDK;

namespace VzClientSDK.WinForm
{
    public partial class AlgResultParamCfg : Form
    {
        static IVzClientSdkProxy VzClientSDK = VzClientSdk.Create();
        private IntPtr m_hLPRClient = IntPtr.Zero;

        public void SetLPRHandle(IntPtr hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }

        public AlgResultParamCfg()
        {
            InitializeComponent();
        }

        private void AlgResultParamCfg_Load(object sender, EventArgs e)
        {

            int reco_dis = 0;

            VzClientSDK.VzLPRClient_GetAlgResultParam(m_hLPRClient, ref reco_dis);

            if (reco_dis == 0)
            {
                radled2.Select();
            }
            else if (reco_dis == 1)
            {
                radled6.Select();
            }
            else if (reco_dis == 2)
            {
                radled4.Select();
            }
        }

        private void radled2_CheckedChanged(object sender, EventArgs e)
        {
            VzClientSDK.VzLPRClient_SetAlgResultParam(m_hLPRClient, 0);
        }

        private void radled4_CheckedChanged(object sender, EventArgs e)
        {
            VzClientSDK.VzLPRClient_SetAlgResultParam(m_hLPRClient, 2);
        }

        private void radled6_CheckedChanged(object sender, EventArgs e)
        {
            VzClientSDK.VzLPRClient_SetAlgResultParam(m_hLPRClient, 1);
        }
    }
}
