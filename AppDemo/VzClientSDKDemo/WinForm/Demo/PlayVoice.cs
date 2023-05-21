using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.VzClientSDK;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VzClientSDK.WinForm
{
    public partial class PlayVoice : Form
    {
        static IVzClientSdkProxy VzClientSDK = VzClientSdk.Create();
        private IntPtr m_hLPRClient = IntPtr.Zero;

        public PlayVoice()
        {
            InitializeComponent();
        }

        public void SetLPRHandle(IntPtr hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }

        private void btnPlayVoice_Click(object sender, EventArgs e)
        {
            if (m_hLPRClient != IntPtr.Zero)
            {
                int ret = VzClientSDK.VzLPRClient_PlayVoice(m_hLPRClient, txtContent.Text, 0, 100, 1);
            }
        }
    }
}
