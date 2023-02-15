using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestHardwareDemo.WinForm.Controls
{
    public partial class VzLPRSDKDemoNetIOValue : UserControl
    {
        /// <summary>
        /// 获取或设置IO值
        /// arg1 => 功能{true:设置,false:获取}
        /// arg2 => 序号{true:1   ,false:0   }
        /// arg3 => 开关{true:1   ,false:0   }
        /// arg4 => 返回{true:1   ,false:0   }
        /// </summary>
        public Func<bool, bool, bool, bool> GetSetIOValue { get; set; }

        public VzLPRSDKDemoNetIOValue()
        {
            InitializeComponent();
        }

        private void VzLPRSDKDemoNetIOValue_Load(object sender, EventArgs e)
        {
            this.ChkIONum1.Checked = GetSetIOValue?.Invoke(false, false, false) ?? false;
            this.ChkIONum2.Checked = GetSetIOValue?.Invoke(false, true, false) ?? false;
            this.ChkInputNum1.Checked = GetSetIOValue?.Invoke(false, false, true) ?? false;
            this.ChkInputNum2.Checked = GetSetIOValue?.Invoke(false, true, true) ?? false;
        }

        private void BtnGetIONum1_Click(object sender, EventArgs e)
        {
            this.ChkIONum1.Checked = GetSetIOValue?.Invoke(false, false, false) ?? false;
            this.ChkInputNum1.Checked = GetSetIOValue?.Invoke(false, false, true) ?? false;
        }

        private void BtnGetIONum2_Click(object sender, EventArgs e)
        {
            this.ChkIONum2.Checked = GetSetIOValue?.Invoke(false, true, false) ?? false;
            this.ChkInputNum2.Checked = GetSetIOValue?.Invoke(false, true, true) ?? false;
        }

        private void BtnSetIONum1_Click(object sender, EventArgs e)
        {
            GetSetIOValue?.Invoke(true, false, this.ChkIONum1.Checked);
        }

        private void BtnSetIONum2_Click(object sender, EventArgs e)
        {
            GetSetIOValue?.Invoke(true, true, this.ChkIONum2.Checked);
        }

        private void ChkIONum1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIONum1.Checked) { ChkIONum1.Text = "闭路"; }
            else { ChkIONum1.Text = "开路"; }
            GetSetIOValue?.Invoke(false, false, false);
        }

        private void ChkIONum2_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIONum2.Checked) { ChkIONum2.Text = "闭路"; }
            else { ChkIONum2.Text = "开路"; }
            GetSetIOValue?.Invoke(false, true, false);
        }

        private void ChkInputNum1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkInputNum1.Checked) { ChkInputNum1.Text = "闭路"; }
            else { ChkInputNum1.Text = "开路"; }
            GetSetIOValue?.Invoke(false, false, true);
        }

        private void ChkInputNum2_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkInputNum2.Checked) { ChkInputNum2.Text = "闭路"; }
            else { ChkInputNum2.Text = "开路"; }
            GetSetIOValue?.Invoke(false, true, true);
        }
    }
}
