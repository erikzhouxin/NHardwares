using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.DeYaIceIpcSDK;

namespace TestDll
{
    public partial class FormNetwork : Form
    {
        public FormNetwork()
        {
            InitializeComponent();
        }
        //网络参数和开关量输出参数配置界面
        public string[] strIP = new string[4];
        public string[] strMask = new string[4];
        public string[] strGateway = new string[4];

        public uint uIp = 0;
        public uint uMask = 0;
        public uint uGateway = 0;
        public int nChanged = 0;
        public Boolean nUartChange = false;
        public Boolean bLoopChange = false;

        public uint pu32IdleState = 0;
        public uint pu32DelayTime = 0;

        public uint u32TriggerMode = 0;
        public ICE_UART_PARAM uart_param = new ICE_UART_PARAM();

        private TextBox[] textBoxIP = new TextBox[4];
        private TextBox[] textBoxMask = new TextBox[4];
        private TextBox[] textBoxGateway = new TextBox[4];

        private string[] strPPI = new string[5]{"1080P(1920 x 1080)", "900P(1600 x 900)", 
                                      "720P(1280 x 720)", "540P(960 x 540)", "D1(704 x 396)"};

        public uint nWidth = 0;
        public uint nHeight = 0;
        public uint nLeftx = 0;
        public uint nLefty = 0;
        public uint nRightx = 0;
        public uint nRighty = 0;

        public int nFilterByPlate = 0, nEnableNoPlateBrand = 0, nEnableBrand = 0;

        private void textBox_ip1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_ip1.Text.Length == 3) && (int.Parse(textBox_ip1.Text) > 255))
            {
                textBox_ip1.Text = "255";
            }
            nChanged = 1;
        }

        private void textBox_ip1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)8) && !(char.IsNumber(e.KeyChar)))//(char)8为退格键的键值
                e.Handled = true;
        }

        private void textBox_ip2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_ip2.Text.Length == 3) && (int.Parse(textBox_ip2.Text) > 255))
                textBox_ip2.Text = "255";
            nChanged = 1;
        }

        private void textBox_ip3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_ip3.Text.Length == 3) && (int.Parse(textBox_ip3.Text) > 255))
                textBox_ip3.Text = "255";
            nChanged = 1;
        }

        private void textBox_ip4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_ip4.Text.Length == 3) && (int.Parse(textBox_ip4.Text) > 255))
                textBox_ip4.Text = "255";
            nChanged = 1;
        }

        private void textBox_mask1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_mask1.Text.Length == 3) && (int.Parse(textBox_mask1.Text) > 255))
                textBox_mask1.Text = "255";
            nChanged = 1;
        }

        private void textBox_mask2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_mask2.Text.Length == 3) && (int.Parse(textBox_mask2.Text) > 255))
                textBox_mask2.Text = "255";
            nChanged = 1;
        }

        private void textBox_mask3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_mask3.Text.Length == 3) && (int.Parse(textBox_mask3.Text) > 255))
                textBox_mask3.Text = "255";
            nChanged = 1;
        }

        private void textBox_mask4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_mask4.Text.Length == 3) && (int.Parse(textBox_mask4.Text) > 255))
                textBox_mask4.Text = "255";
            nChanged = 1;
        }

        private void textBox_gateway1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_gateway1.Text.Length == 3) && (int.Parse(textBox_gateway1.Text) > 255))
                textBox_gateway1.Text = "255";
            nChanged = 1;
        }

        private void textBox_gateway2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_gateway2.Text.Length == 3) && (int.Parse(textBox_gateway2.Text) > 255))
                textBox_gateway2.Text = "255";
            nChanged = 1;
        }

        private void textBox_gateway3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_gateway3.Text.Length == 3) && (int.Parse(textBox_gateway3.Text) > 255))
                textBox_gateway3.Text = "255";
            nChanged = 1;
        }

        private void textBox_gateway4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_gateway4.Text.Length == 3) && (int.Parse(textBox_gateway4.Text) > 255))
                textBox_gateway4.Text = "255";
            nChanged = 1;
        }

        private void textBox_mask1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void textBox_mask2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void textBox_mask3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void textBox_mask4_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void textBox_gateway1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void textBox_gateway2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void textBox_gateway3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void textBox_gateway4_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_ip1_KeyPress(sender, e);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            byte[] btIp = new byte[4];
            byte[] btMask = new byte[4];
            byte[] btGateway = new byte[4];
            int tmp = -1;

            for (int i = 0; i < 4; i++)
            {
                btIp[i] = (byte)int.Parse(textBoxIP[i].Text);
                btMask[i] = (byte)int.Parse(textBoxMask[i].Text);
                btGateway[i] = (byte)int.Parse(textBoxGateway[i].Text);
            }

            //获取网络参数
            uIp = BitConverter.ToUInt32(btIp, 0);
            uMask = BitConverter.ToUInt32(btMask, 0);
            uGateway = BitConverter.ToUInt32(btGateway, 0);

            //获取开关量输出参数
            if (Convert.ToInt32(textBoxOutputTime.Text) < 0)
                pu32DelayTime = (uint)tmp;
            else
                pu32DelayTime = (uint)Convert.ToInt32(textBoxOutputTime.Text);

            if (radioButtonOpen.Checked)
                pu32IdleState = 0;
            else
                pu32IdleState = 1;

            u32TriggerMode = (uint)comboBox_TriggerMode.SelectedIndex;

            updateUartParam();//串口参数

            //识别区域
            if (textBox_leftx.Text != "")
                nLeftx = Convert.ToUInt32(textBox_leftx.Text);
            if (textBox_lefty.Text != "")
                nLefty = Convert.ToUInt32(textBox_lefty.Text);
            if (textBox_rightx.Text != "")
                nRightx = Convert.ToUInt32(textBox_rightx.Text);
            if (textBox_righty.Text != "")
                nRighty = Convert.ToUInt32(textBox_righty.Text);

            //车款识别
            nFilterByPlate = checkBox_EnableNoPlate.Checked == true ? 0 : 1;
            nEnableNoPlateBrand = checkBox_EnableNoPlate_Brand.Checked == true ? 1 : 0;
            nEnableBrand = checkBox_EnableBrand.Checked == true ? 1 : 0;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormNetwork_Load(object sender, EventArgs e)
        {
            int i = 0;
            comboBox_TriggerMode.Items.Add("线圈触发");
            comboBox_TriggerMode.Items.Add("视频触发");

            //串口设置
            comboBox_uart.Items.Add("RS485");
            comboBox_uart.Items.Add("RS232");
            comboBox_uartMode.Items.Add("车牌协议1");
            comboBox_uartMode.Items.Add("透明串口");
            comboBox_uartMode.Items.Add("LED屏控制");
            comboBox_uartMode.Items.Add("混合模式");
            comboBox_uartMode.Items.Add("车牌协议2");
            comboBox_uartMode.Items.Add("车牌协议3");
            comboBox_uartMode.Items.Add("车牌协议4");

            int nBaudrate = 1200;
            for (; nBaudrate <= 38400; nBaudrate *= 2)
                comboBox_baudrate.Items.Add(nBaudrate.ToString());
            comboBox_baudrate.Items.Add("115200");

            for (int nDataBits = 5; nDataBits <= 8; nDataBits++)
                comboBox_databits.Items.Add(nDataBits.ToString());

            comboBox_parity.Items.Add("无");
            comboBox_parity.Items.Add("奇校验");
            comboBox_parity.Items.Add("偶校验");
            comboBox_parity.Items.Add("标记");
            comboBox_parity.Items.Add("空格");

            comboBox_stopbits.Items.Add("1");
            comboBox_stopbits.Items.Add("2");

            comboBox_flowctrl.Items.Add("无");
            comboBox_flowctrl.Items.Add("硬件");
            comboBox_flowctrl.Items.Add("Xon/Xoff");

            //识别区域
            for (i = 0; i < 5; i++)
                comboBox_settingPPI.Items.Add(strPPI[i]);

            comboBox_settingPPI.SelectedIndex = getIndex();
            textBox_leftx.Text = nLeftx.ToString();
            textBox_lefty.Text = nLefty.ToString();
            textBox_rightx.Text = nRightx.ToString();
            textBox_righty.Text = nRighty.ToString();


            textBoxIP[0] = textBox_ip1;
            textBoxIP[1] = textBox_ip2;
            textBoxIP[2] = textBox_ip3;
            textBoxIP[3] = textBox_ip4;

            textBoxMask[0] = textBox_mask1;
            textBoxMask[1] = textBox_mask2;
            textBoxMask[2] = textBox_mask3;
            textBoxMask[3] = textBox_mask4;

            textBoxGateway[0] = textBox_gateway1;
            textBoxGateway[1] = textBox_gateway2;
            textBoxGateway[2] = textBox_gateway3;
            textBoxGateway[3] = textBox_gateway4;

            if (u32TriggerMode > 1)
                u32TriggerMode = 0;
            comboBox_TriggerMode.SelectedIndex = (int)u32TriggerMode;

            for (i = 0; i < 4; i++ )
            {
                textBoxIP[i].Text = strIP[i];
                textBoxMask[i].Text = strMask[i];
                textBoxGateway[i].Text = strGateway[i];
            }

            if (0 == pu32IdleState)
                radioButtonOpen.Checked = true;
            else
                radioButtonClose.Checked = true;
            textBoxOutputTime.Text = ((int)pu32DelayTime).ToString();

            //串口设置
            comboBox_uart.SelectedIndex = 0;
            comboBox_uartMode.SelectedIndex = uart_param.uart_param[0].uartWorkMode;
            comboBox_baudrate.SelectedIndex = uart_param.uart_param[0].baudRate;
            comboBox_databits.SelectedIndex = uart_param.uart_param[0].dataBits;
            comboBox_parity.SelectedIndex = uart_param.uart_param[0].parity;
            comboBox_stopbits.SelectedIndex = uart_param.uart_param[0].stopBits;
            comboBox_flowctrl.SelectedIndex = uart_param.uart_param[0].flowControl;
            checkBox_enableUart.Checked = Convert.ToBoolean(uart_param.uart_param[0].uartEn);

            //车款识别
            if (nFilterByPlate == 1)
            {
                nEnableNoPlateBrand = 0;
                checkBox_EnableNoPlate_Brand.Enabled = false;
            }

            checkBox_EnableNoPlate.Checked = nFilterByPlate == 0 ? true : false;
            checkBox_EnableNoPlate_Brand.Checked = nEnableNoPlateBrand == 1 ? true : false;
            checkBox_EnableBrand.Checked = nEnableBrand == 1 ? true : false;

            if (comboBox_TriggerMode.SelectedIndex == 0)
                checkBox_EnableNoPlate.Checked = true;
            checkBox_EnableNoPlate_Brand.Enabled = checkBox_EnableNoPlate.Checked;
            checkBox_EnableNoPlate.Enabled = comboBox_TriggerMode.SelectedIndex == 1 ? true : false;
        }

        private void updateUartParam()
        {
            int index = comboBox_uart.SelectedIndex;
            uart_param.uart_param[index].uartWorkMode = comboBox_uartMode.SelectedIndex;
            uart_param.uart_param[index].baudRate = comboBox_baudrate.SelectedIndex;
            uart_param.uart_param[index].dataBits = comboBox_databits.SelectedIndex;
            uart_param.uart_param[index].parity = comboBox_parity.SelectedIndex;
            uart_param.uart_param[index].stopBits = comboBox_stopbits.SelectedIndex;
            uart_param.uart_param[index].flowControl = comboBox_flowctrl.SelectedIndex;
            uart_param.uart_param[index].uartEn = Convert.ToInt32(checkBox_enableUart.Checked);
        }

        private void comboBox_uart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_uart.SelectedIndex;
            comboBox_uartMode.SelectedIndex = uart_param.uart_param[index].uartWorkMode;
            comboBox_baudrate.SelectedIndex = uart_param.uart_param[index].baudRate;
            comboBox_databits.SelectedIndex = uart_param.uart_param[index].dataBits;
            comboBox_parity.SelectedIndex = uart_param.uart_param[index].parity;
            comboBox_stopbits.SelectedIndex = uart_param.uart_param[index].stopBits;
            comboBox_flowctrl.SelectedIndex = uart_param.uart_param[index].flowControl;
            checkBox_enableUart.Checked = Convert.ToBoolean(uart_param.uart_param[index].uartEn);
        }

        private void comboBox_uart_Click(object sender, EventArgs e)
        {
            updateUartParam();
        }

        private void checkBox_enableUart_Click(object sender, EventArgs e)
        {
            nUartChange = true;
        }

        private void comboBox_uartMode_Click(object sender, EventArgs e)
        {
            nUartChange = true;
        }

        private void comboBox_baudrate_Click(object sender, EventArgs e)
        {
            nUartChange = true;
        }

        private void comboBox_databits_Click(object sender, EventArgs e)
        {
            nUartChange = true;
        }

        private void comboBox_parity_Click(object sender, EventArgs e)
        {
            nUartChange = true;
        }

        private void comboBox_stopbits_Click(object sender, EventArgs e)
        {
            nUartChange = true;
        }

        private void comboBox_flowctrl_Click(object sender, EventArgs e)
        {
            nUartChange = true;
        }

        private void textBox_leftx_KeyPress(object sender, KeyPressEventArgs e)
        {
            bLoopChange = true;
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }

        private void textBox_righty_KeyPress(object sender, KeyPressEventArgs e)
        {
            bLoopChange = true;
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }

        private void textBox_rightx_KeyPress(object sender, KeyPressEventArgs e)
        {
            bLoopChange = true;
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }

        private void textBox_lefty_KeyPress(object sender, KeyPressEventArgs e)
        {
            bLoopChange = true;
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }

        private void textBox_leftx_Leave(object sender, EventArgs e)
        {
            if ((textBox_leftx.Text != "") && (Convert.ToInt32(textBox_leftx.Text) > nWidth))
                textBox_leftx.Text = (nWidth - 10).ToString();
        }

        private void textBox_righty_Leave(object sender, EventArgs e)
        {
            if ((textBox_righty.Text != "") && (Convert.ToInt32(textBox_righty.Text) > nHeight))
                textBox_righty.Text = (nHeight - 10).ToString();
        }

        private void textBox_rightx_Leave(object sender, EventArgs e)
        {
            if ((textBox_rightx.Text != "") && (Convert.ToInt32(textBox_rightx.Text) > nWidth))
                textBox_rightx.Text = (nWidth - 10).ToString();
        }

        private void textBox_lefty_Leave(object sender, EventArgs e)
        {
            if ((textBox_lefty.Text != "") && (Convert.ToInt32(textBox_lefty.Text) > nHeight))
                textBox_lefty.Text = (nHeight - 10).ToString();
        }

        private int getIndex()
        {
            int nIndex = 0;
            if ((nWidth == 1920) && (nHeight == 1080))
                nIndex = 0;
            else if ((nWidth == 1600) && (nHeight == 900))
                nIndex = 1;
            else if ((nWidth == 1280) && (nHeight == 720))
                nIndex = 2;
            else if ((nWidth == 960) && (nHeight == 540))
                nIndex = 3;
            else if ((nWidth == 704) && (nHeight == 396))
                nIndex = 4;

            return nIndex;
        }

        private void getPPI(int nIndex)
        {
            if (nIndex < 0)
                return;
            switch (nIndex)
            {
                case 0:
                    nWidth = 1920;
                    nHeight = 1080;
                    break;
                case 1:
                    nWidth = 1600;
                    nHeight = 900;
                    break;
                case 2:
                    nWidth = 1280;
                    nHeight = 720;
                    break;
                case 3:
                    nWidth = 960;
                    nHeight = 540;
                    break;
                case 4:
                    nWidth = 704;
                    nHeight = 396;
                    break;
            }
        }

        private void comboBox_settingPPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint width = nWidth;
            uint height = nHeight;
            getPPI(comboBox_settingPPI.SelectedIndex);
            float rx = (float)nWidth / width;
            float ry = (float)nHeight / height;

            nLeftx = (uint)(nLeftx * rx);
            nLefty = (uint)(nLefty * ry);
            nRightx = (uint)(nRightx * rx);
            nRighty = (uint)(nRighty * rx);

            textBox_leftx.Text = nLeftx.ToString();
            textBox_lefty.Text = nLefty.ToString();
            textBox_rightx.Text = nRightx.ToString();
            textBox_righty.Text = nRighty.ToString();
        }

        private void checkBox_EnableNoPlate_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_EnableNoPlate.Checked)
                checkBox_EnableNoPlate_Brand.Checked = checkBox_EnableNoPlate.Checked;
            checkBox_EnableNoPlate_Brand.Enabled = checkBox_EnableNoPlate.Checked;
        }

        private void comboBox_TriggerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_TriggerMode.SelectedIndex == 0)
                checkBox_EnableNoPlate.Checked = true;
            checkBox_EnableNoPlate_Brand.Enabled = checkBox_EnableNoPlate.Checked;
            checkBox_EnableNoPlate.Enabled = comboBox_TriggerMode.SelectedIndex == 1 ? true : false;
        }
    }
}
