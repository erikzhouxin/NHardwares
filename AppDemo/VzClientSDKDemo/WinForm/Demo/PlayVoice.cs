﻿using System;
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
        private int m_hLPRClient = 0;

        public PlayVoice()
        {
            InitializeComponent();
        }

        public void SetLPRHandle(int hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }

        private void btnPlayVoice_Click(object sender, EventArgs e)
        {
            if (m_hLPRClient > 0)
            {
                int ret = VzClientSDK.VzLPRClient_PlayVoice(m_hLPRClient, txtContent.Text, 0, 100, 1);
            }
        }
    }
}
