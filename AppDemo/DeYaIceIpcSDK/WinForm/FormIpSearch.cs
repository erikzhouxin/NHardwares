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
    public partial class FormIpSearch : Form
    {
        static IIceIpcSdkProxy ipcsdk = IceIpcSdk.Create();
        public FormIpSearch()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            textBoxDev.Text = "mac                ip\r\n";
            StringBuilder strResult = new StringBuilder(4096);
            ipcsdk.ICE_IPCSDK_SearchDev(strResult);//设备搜索
            textBoxDev.Text += strResult;
            strResult = null;
            textBoxDev.Text += "\r\n搜索完成！";
        }
    }
}
