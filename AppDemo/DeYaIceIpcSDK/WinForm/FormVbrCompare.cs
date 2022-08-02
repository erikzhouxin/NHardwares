using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.DeYaIceIpcSDK;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDll
{
    public partial class FormVbrCompare : Form
    {
        static IIceIpcSdkProxy ipcsdk = IceIpcSdk.Create();
        public FormVbrCompare()
        {
            InitializeComponent();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            string[] strData1 = textBoxVbrData1.Text.Split(' ');
            string[] strData2 = textBoxVbrData2.Text.Split(' ');
            float[] fvbr1 = new float[20];
            float[] fvbr2 = new float[20];
            for (int i = 0; i < strData1.Length; i++)
                float.TryParse(strData1[i], out fvbr1[i]);
            for (int i = 0; i < strData2.Length; i++)
                float.TryParse(strData2[i], out fvbr2[i]);

            float fResult = ipcsdk.ICE_IPCSDK_VBR_CompareFeat(fvbr1, 20, fvbr2, 20);
            textBoxResult.Text = fResult.ToString();
        }
    }
}
