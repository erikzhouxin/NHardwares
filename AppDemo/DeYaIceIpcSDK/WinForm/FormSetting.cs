using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.DeYaIceIpcSDK;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDll
{
    public partial class FormSetting : Form
    {
        static IIceIpcSdkProxy ipcsdk = IceIpcSdk.Create();
        public FormSetting()
        {
            InitializeComponent();
        }

        T_SnapOsdCfg tSnapOsdCfg = new T_SnapOsdCfg();
        public IntPtr pUid = IntPtr.Zero;
        private void FormSetting_Load(object sender, EventArgs e)
        {
            tSnapOsdCfg.tOsdInfoCfg = new T_OsdInfoCfg[6];
            for (int i = 0; i < 6; i++)
                tSnapOsdCfg.tOsdInfoCfg[i].acCustomInfo = new byte[64];
            comboBox_bgColor.SelectedIndex = 0;
            comboBox_dateMode.SelectedIndex = 0;
            comboBox_fontSize.SelectedIndex = 0;
            comboBox_infoMode.SelectedIndex = 0;

            comboBox_location1.SelectedIndex = 0;
            comboBox_type1.SelectedIndex = 2;

            comboBox_location2.SelectedIndex = 0;
            comboBox_type2.SelectedIndex = 3;

            comboBox_location3.SelectedIndex = 4;
            comboBox_type3.SelectedIndex = 4;

            comboBox_location4.SelectedIndex = 5;
            comboBox_type4.SelectedIndex = 5;

            comboBox_location5.SelectedIndex = 0;
            comboBox_type5.SelectedIndex = 6;

            comboBox_location6.SelectedIndex = 0;
            comboBox_type6.SelectedIndex = 6;
        }

        private string get_uft8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }

        private string get_unicode(string utf8String)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            Byte[] encodedBytes = unicode.GetBytes(utf8String);
            String decodedString = unicode.GetString(encodedBytes);
            return decodedString;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            tSnapOsdCfg.ibgColorMode = comboBox_bgColor.SelectedIndex;
            tSnapOsdCfg.iDateMode = comboBox_dateMode.SelectedIndex;
            tSnapOsdCfg.iFontSize = comboBox_fontSize.SelectedIndex;
            tSnapOsdCfg.iLineMode = comboBox_infoMode.SelectedIndex;
            int nLocation = -1;

            tSnapOsdCfg.tOsdInfoCfg[0].iEnable = Convert.ToInt32(checkBox_line1.Checked);
            tSnapOsdCfg.tOsdInfoCfg[0].iLocation = comboBox_location1.SelectedIndex;
            if (1 == tSnapOsdCfg.iLineMode && 1 == tSnapOsdCfg.tOsdInfoCfg[0].iEnable)
            {
                if (0 != tSnapOsdCfg.tOsdInfoCfg[0].iLocation && 3 != tSnapOsdCfg.tOsdInfoCfg[0].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }
                        
                nLocation = tSnapOsdCfg.tOsdInfoCfg[0].iLocation;
            }

            tSnapOsdCfg.tOsdInfoCfg[0].iType = comboBox_type1.SelectedIndex;
            tSnapOsdCfg.tOsdInfoCfg[0].acCustomInfo = Encoding.UTF8.GetBytes(textBox_customInfo1.Text.PadRight(64, '\0'));

            tSnapOsdCfg.tOsdInfoCfg[1].iEnable = Convert.ToInt32(checkBox_line2.Checked);
            tSnapOsdCfg.tOsdInfoCfg[1].iLocation = comboBox_location2.SelectedIndex;
            if (1 == tSnapOsdCfg.iLineMode && 1 == tSnapOsdCfg.tOsdInfoCfg[1].iEnable)
            {
                if (0 != tSnapOsdCfg.tOsdInfoCfg[1].iLocation && 3 != tSnapOsdCfg.tOsdInfoCfg[1].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                if ((-1 != nLocation) && nLocation != tSnapOsdCfg.tOsdInfoCfg[1].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                nLocation = tSnapOsdCfg.tOsdInfoCfg[1].iLocation;
            }

            tSnapOsdCfg.tOsdInfoCfg[1].iType = comboBox_type2.SelectedIndex;
            tSnapOsdCfg.tOsdInfoCfg[1].acCustomInfo = Encoding.UTF8.GetBytes(textBox_customInfo2.Text.PadRight(64, '\0'));

            tSnapOsdCfg.tOsdInfoCfg[2].iEnable = Convert.ToInt32(checkBox_line3.Checked);
            tSnapOsdCfg.tOsdInfoCfg[2].iLocation = comboBox_location3.SelectedIndex;
            if (1 == tSnapOsdCfg.iLineMode && 1 == tSnapOsdCfg.tOsdInfoCfg[2].iEnable)
            {
                if (0 != tSnapOsdCfg.tOsdInfoCfg[2].iLocation && 3 != tSnapOsdCfg.tOsdInfoCfg[2].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                if ((-1 != nLocation) && nLocation != tSnapOsdCfg.tOsdInfoCfg[2].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                nLocation = tSnapOsdCfg.tOsdInfoCfg[2].iLocation;
            }

            tSnapOsdCfg.tOsdInfoCfg[2].iType = comboBox_type3.SelectedIndex;
            tSnapOsdCfg.tOsdInfoCfg[2].acCustomInfo = Encoding.UTF8.GetBytes(textBox_customInfo3.Text.PadRight(64, '\0'));

            tSnapOsdCfg.tOsdInfoCfg[3].iEnable = Convert.ToInt32(checkBox_line4.Checked);
            tSnapOsdCfg.tOsdInfoCfg[3].iLocation = comboBox_location4.SelectedIndex;
            if (1 == tSnapOsdCfg.iLineMode && 1 == tSnapOsdCfg.tOsdInfoCfg[3].iEnable)
            {
                if (0 != tSnapOsdCfg.tOsdInfoCfg[3].iLocation && 3 != tSnapOsdCfg.tOsdInfoCfg[3].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                if ((-1 != nLocation) && nLocation != tSnapOsdCfg.tOsdInfoCfg[3].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                nLocation = tSnapOsdCfg.tOsdInfoCfg[3].iLocation;
            }

            tSnapOsdCfg.tOsdInfoCfg[3].iType = comboBox_type4.SelectedIndex;
            tSnapOsdCfg.tOsdInfoCfg[3].acCustomInfo = Encoding.UTF8.GetBytes(textBox_customInfo4.Text.PadRight(64, '\0'));

            tSnapOsdCfg.tOsdInfoCfg[4].iEnable = Convert.ToInt32(checkBox_line5.Checked);
            tSnapOsdCfg.tOsdInfoCfg[4].iLocation = comboBox_location5.SelectedIndex;
            if (1 == tSnapOsdCfg.iLineMode && 1 == tSnapOsdCfg.tOsdInfoCfg[4].iEnable)
            {
                if (0 != tSnapOsdCfg.tOsdInfoCfg[4].iLocation && 3 != tSnapOsdCfg.tOsdInfoCfg[4].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                if ((-1 != nLocation) && nLocation != tSnapOsdCfg.tOsdInfoCfg[4].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                nLocation = tSnapOsdCfg.tOsdInfoCfg[4].iLocation;
            }

            tSnapOsdCfg.tOsdInfoCfg[4].iType = comboBox_type5.SelectedIndex;
            tSnapOsdCfg.tOsdInfoCfg[4].acCustomInfo = Encoding.UTF8.GetBytes(textBox_customInfo5.Text.PadRight(64, '\0'));

            tSnapOsdCfg.tOsdInfoCfg[5].iEnable = Convert.ToInt32(checkBox_line6.Checked);
            tSnapOsdCfg.tOsdInfoCfg[5].iLocation = comboBox_location6.SelectedIndex;
            if (1 == tSnapOsdCfg.iLineMode && 1 == tSnapOsdCfg.tOsdInfoCfg[5].iEnable)
            {
                if (0 != tSnapOsdCfg.tOsdInfoCfg[5].iLocation && 3 != tSnapOsdCfg.tOsdInfoCfg[5].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                if ((-1 != nLocation) && nLocation != tSnapOsdCfg.tOsdInfoCfg[5].iLocation)
                {
                    MessageBox.Show("单行显示时，需要显示的行叠加位置只能为左上或者左下，且需一致，请重新选择");
                    return;
                }

                nLocation = tSnapOsdCfg.tOsdInfoCfg[5].iLocation;
            }

            tSnapOsdCfg.tOsdInfoCfg[5].iType = comboBox_type6.SelectedIndex;
            tSnapOsdCfg.tOsdInfoCfg[5].acCustomInfo = Encoding.UTF8.GetBytes(textBox_customInfo6.Text.PadRight(64, '\0'));
            //tSnapOsdCfg.tOsdInfoCfg[5].acCustomInfo = get_uft8(textBox_customInfo6.Text);

            uint ret = ipcsdk.ICE_IPCSDK_SetSnapOsdCfg(pUid, ref tSnapOsdCfg);
            if (2 == ret)
            {
                MessageBox.Show("相机版本不支持此功能");
            }
            else if (0 == ret)
            {
                MessageBox.Show("设置失败");
            }
            else if (1 == ret)
            {
                MessageBox.Show("设置成功");
            }
        }

        private void button_cancle_Click(object sender, EventArgs e)
        {
            uint ret = ipcsdk.ICE_IPCSDK_GetSnapOsdCfg(pUid, ref tSnapOsdCfg);
            if (2 == ret)
            {
                MessageBox.Show("相机版本不支持此功能");
                return;
            }
            else if (0 == ret)
            {
                MessageBox.Show("获取失败");
                return;
            }

            //不使能的
            //单行
            int lineMode = 0;
            if (1 == tSnapOsdCfg.iLineMode)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (1 == tSnapOsdCfg.tOsdInfoCfg[i].iEnable)
                    {
                        lineMode = tSnapOsdCfg.tOsdInfoCfg[i].iLocation;
                        break;
                    }
                        
                }
            }

            if (0 == tSnapOsdCfg.tOsdInfoCfg[0].iEnable)
            {
                if (0 == tSnapOsdCfg.iLineMode)
                    tSnapOsdCfg.tOsdInfoCfg[0].iLocation = 0;
                else
                    tSnapOsdCfg.tOsdInfoCfg[0].iLocation = lineMode;
                tSnapOsdCfg.tOsdInfoCfg[0].iType = 2;
            }
            if (0 == tSnapOsdCfg.tOsdInfoCfg[1].iEnable)
            {
                if (0 == tSnapOsdCfg.iLineMode)
                    tSnapOsdCfg.tOsdInfoCfg[1].iLocation = 0;
                else
                    tSnapOsdCfg.tOsdInfoCfg[1].iLocation = lineMode;
                tSnapOsdCfg.tOsdInfoCfg[1].iType = 3;
            }
            if (0 == tSnapOsdCfg.tOsdInfoCfg[2].iEnable)
            {
                if (0 == tSnapOsdCfg.iLineMode)
                    tSnapOsdCfg.tOsdInfoCfg[2].iLocation = 4;
                else
                    tSnapOsdCfg.tOsdInfoCfg[2].iLocation = lineMode;
                tSnapOsdCfg.tOsdInfoCfg[2].iType = 4;
            }
            if (0 == tSnapOsdCfg.tOsdInfoCfg[3].iEnable)
            {
                if (0 == tSnapOsdCfg.iLineMode)
                    tSnapOsdCfg.tOsdInfoCfg[3].iLocation = 5;
                else
                    tSnapOsdCfg.tOsdInfoCfg[3].iLocation = lineMode;
                tSnapOsdCfg.tOsdInfoCfg[3].iType = 5;
            }
            if (0 == tSnapOsdCfg.tOsdInfoCfg[4].iEnable)
            {
                if (0 == tSnapOsdCfg.iLineMode)
                    tSnapOsdCfg.tOsdInfoCfg[4].iLocation = 0;
                else
                    tSnapOsdCfg.tOsdInfoCfg[4].iLocation = lineMode;
                tSnapOsdCfg.tOsdInfoCfg[4].iType = 6;
            }
            if (0 == tSnapOsdCfg.tOsdInfoCfg[5].iEnable)
            {
                if (0 == tSnapOsdCfg.iLineMode)
                    tSnapOsdCfg.tOsdInfoCfg[5].iLocation = 0;
                else
                    tSnapOsdCfg.tOsdInfoCfg[5].iLocation = lineMode;
                tSnapOsdCfg.tOsdInfoCfg[5].iType = 6;
            }

            comboBox_bgColor.SelectedIndex = tSnapOsdCfg.ibgColorMode;
            comboBox_dateMode.SelectedIndex = tSnapOsdCfg.iDateMode;
            comboBox_fontSize.SelectedIndex = tSnapOsdCfg.iFontSize;
            comboBox_infoMode.SelectedIndex = tSnapOsdCfg.iLineMode;

            checkBox_line1.Checked = Convert.ToBoolean(tSnapOsdCfg.tOsdInfoCfg[0].iEnable);
            comboBox_location1.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[0].iLocation;
            comboBox_type1.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[0].iType;
            textBox_customInfo1.Text = System.Text.Encoding.UTF8.GetString(tSnapOsdCfg.tOsdInfoCfg[0].acCustomInfo);

            checkBox_line2.Checked = Convert.ToBoolean(tSnapOsdCfg.tOsdInfoCfg[1].iEnable);
            comboBox_location2.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[1].iLocation;
            comboBox_type2.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[1].iType;
            textBox_customInfo2.Text = System.Text.Encoding.UTF8.GetString(tSnapOsdCfg.tOsdInfoCfg[1].acCustomInfo);

            checkBox_line3.Checked = Convert.ToBoolean(tSnapOsdCfg.tOsdInfoCfg[2].iEnable);
            comboBox_location3.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[2].iLocation;
            comboBox_type3.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[2].iType;
            textBox_customInfo3.Text = System.Text.Encoding.UTF8.GetString(tSnapOsdCfg.tOsdInfoCfg[2].acCustomInfo);

            checkBox_line4.Checked = Convert.ToBoolean(tSnapOsdCfg.tOsdInfoCfg[3].iEnable);
            comboBox_location4.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[3].iLocation;
            comboBox_type4.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[3].iType;
            textBox_customInfo4.Text = System.Text.Encoding.UTF8.GetString(tSnapOsdCfg.tOsdInfoCfg[3].acCustomInfo);

            checkBox_line5.Checked = Convert.ToBoolean(tSnapOsdCfg.tOsdInfoCfg[4].iEnable);
            comboBox_location5.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[4].iLocation;
            comboBox_type5.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[4].iType;
            textBox_customInfo5.Text = System.Text.Encoding.UTF8.GetString(tSnapOsdCfg.tOsdInfoCfg[4].acCustomInfo);

            checkBox_line6.Checked = Convert.ToBoolean(tSnapOsdCfg.tOsdInfoCfg[5].iEnable);
            comboBox_location6.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[5].iLocation;
            comboBox_type6.SelectedIndex = tSnapOsdCfg.tOsdInfoCfg[5].iType;
            textBox_customInfo6.Text = System.Text.Encoding.UTF8.GetString(tSnapOsdCfg.tOsdInfoCfg[5].acCustomInfo);
        }

        private void FormSetting_Shown(object sender, EventArgs e)
        {
            button_cancle_Click(sender, e);
        }

        private void textChanged(TextBox textbox)
        {
            String text = textbox.Text;
            int len = System.Text.Encoding.UTF8.GetByteCount(text);
            if (len <= 60)
            {
                return;
            }

            int lineLen = 0;
            while (len > 60)
            {
                lineLen = text.Length;
                //删除输入行多余的字符
                text = text.Remove(lineLen - 1);
                textbox.Text = "";

                len = System.Text.Encoding.UTF8.GetByteCount(text);
            }

            //设置新文本
            textbox.Text = text;
            int textLen = text.Length;
            //设置光标
            textbox.Select(textLen + lineLen - 1, 0);
        }

        private void textBox_customInfo1_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox_customInfo1);
        }

        private void textBox_customInfo2_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox_customInfo2);
        }

        private void textBox_customInfo3_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox_customInfo3);
        }

        private void textBox_customInfo4_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox_customInfo4);
        }

        private void textBox_customInfo5_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox_customInfo5);
        }

        private void textBox_customInfo6_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox_customInfo6);
        }

        private void comboBox_type1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_type1.SelectedIndex;
            if (6 == nSel)
                textBox_customInfo1.Enabled = true;
            else
                textBox_customInfo1.Enabled = false;
        }

        private void comboBox_type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_type2.SelectedIndex;
            if (6 == nSel)
                textBox_customInfo2.Enabled = true;
            else
                textBox_customInfo2.Enabled = false;
        }

        private void comboBox_type3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_type3.SelectedIndex;
            if (6 == nSel)
                textBox_customInfo3.Enabled = true;
            else
                textBox_customInfo3.Enabled = false;
        }

        private void comboBox_type4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_type4.SelectedIndex;
            if (6 == nSel)
                textBox_customInfo4.Enabled = true;
            else
                textBox_customInfo4.Enabled = false;
        }

        private void comboBox_type5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_type5.SelectedIndex;
            if (6 == nSel)
                textBox_customInfo5.Enabled = true;
            else
                textBox_customInfo5.Enabled = false;
        }

        private void comboBox_type6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_type6.SelectedIndex;
            if (6 == nSel)
                textBox_customInfo6.Enabled = true;
            else
                textBox_customInfo6.Enabled = false;
        }
    }
}
