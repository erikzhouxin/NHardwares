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
    public partial class InAndOut_Form : Form
    {
        public InAndOut_Form()
        {
            InitializeComponent();
        }
        private int m_hLPRClient = 0;
        public void SetLPRHandle(int hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }

        private VzClientSDK.VZ_OutputConfigInfo m_oOutputInfo = new VzClientSDK.VZ_OutputConfigInfo();
        private void button2_Click(object sender, EventArgs e)
        {
            int nRet = VzClientSDK.VzLPRClient_SetOutputConfig(m_hLPRClient, ref m_oOutputInfo);
            if (nRet != 0)
                MessageBox.Show("设置输出配置失败！");
            else
                MessageBox.Show("设置输出配置成功！");
        }

        private Int32 ConvertToInt(object sender)
        {
            return Convert.ToInt32(((CheckBox)sender).Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout1 = ConvertToInt(sender);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout2 = ConvertToInt(sender);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout3 = ConvertToInt(sender);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout4 = ConvertToInt(sender);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].levelout1 = ConvertToInt(sender);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].levelout2 = ConvertToInt(sender);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].rs485out1 = ConvertToInt(sender);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nWhiteList;
            m_oOutputInfo.oConfigInfo[nType].rs485out2 = ConvertToInt(sender);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout1 = ConvertToInt(sender);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout2 = ConvertToInt(sender);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout3 = ConvertToInt(sender);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].switchout4 = ConvertToInt(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nDelay = Convert.ToInt32(m_txtDelay.Text.Trim());
            int nRet = VzClientSDK.VzLPRClient_SetTriggerDelay(m_hLPRClient, nDelay);
            if (nRet != 0)
                MessageBox.Show("设置触发延迟时间失败！");
            else
                MessageBox.Show("设置触发延迟时间成功！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int nType = 0;
            if (m_rdOffineAuto.Checked)
                nType = 0;
            else if (m_rdStart.Checked)
                nType = 1;
            else if (m_rdStop.Checked)
                nType = 2;

            int nRet = VzClientSDK.VzLPRClient_SetWLCheckMethod(m_hLPRClient, nType);
            if (nRet != 0)
                MessageBox.Show("设置白名单启用条件失败！");
            else
                MessageBox.Show("设置白名单启用条件成功！");
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            int nType = 0;
            if (m_rdAllMatch.Checked)
                nType = 0;
            else if (m_rdPartMatch.Checked)
                nType = 1;
            else if (m_rdFuccyMatch.Checked)
                nType = 2;

            int nLen = 0;
            if (m_rdLen1.Checked)
                nLen = 1;
            else if (m_rdLen2.Checked)
                nLen = 2;
            else if (m_rdLen3.Checked)
                nLen = 3;

            bool bIgnore = m_ckIgnore.Checked;
            int nRet = VzClientSDK.VzLPRClient_SetWLFuzzy(m_hLPRClient, nType, nLen, bIgnore);
            if (nRet != 0)
                MessageBox.Show("设置模糊查询方式失败！");
            else
                MessageBox.Show("设置模糊查询方式成功！");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int nSerialPort = m_cmbSerialPort.SelectedIndex;
            VzClientSDK.VZ_SERIAL_PARAMETER oSerialParam = new VzClientSDK.VZ_SERIAL_PARAMETER();
            oSerialParam.uBaudRate = Convert.ToUInt32(m_cmbBound.Text);
            int nParity = m_cmbParity.SelectedIndex;
            oSerialParam.uParity = Convert.ToUInt32(nParity);
            oSerialParam.uDataBits = Convert.ToUInt32(m_cmbDataBit.Text);
            oSerialParam.uStopBit = Convert.ToUInt32(m_cmbStop.Text);
            int nRet = VzClientSDK.VzLPRClient_SetSerialParameter(m_hLPRClient, nSerialPort, ref oSerialParam);
            if (nRet != 0)
                MessageBox.Show("设置串口参数失败！");
            else
                MessageBox.Show("设置串口参数成功！");
        }

        private void initDelay()
        {
            int nDelay = 0;
            VzClientSDK.VzLPRClient_GetTriggerDelay(m_hLPRClient, ref nDelay);
            m_txtDelay.Text = Convert.ToString(nDelay);
        }

        private void initWL()
        {
            int nType = 0;
            VzClientSDK.VzLPRClient_GetWLCheckMethod(m_hLPRClient, ref nType);
            if (nType == 0)
                m_rdOffineAuto.Checked = true;
            else if (nType == 1)
                m_rdStart.Checked = true;
            else if (nType == 2)
                m_rdStop.Checked = true;
        }

        private void initMatch()
        {
            int nType = 0, nLen = 0;
            bool bIgnore = false;
            VzClientSDK.VzLPRClient_GetWLFuzzy(m_hLPRClient, ref nType, ref nLen, ref bIgnore);
            if (nType == 0)
                m_rdAllMatch.Checked = true;
            else if (nType == 1)
                m_rdPartMatch.Checked = true;
            else if (nType == 2)
                m_rdFuccyMatch.Checked = true;

            if (nLen == 1)
                m_rdLen1.Checked = true;
            else if (nLen == 2)
                m_rdLen2.Checked = true;
            else if (nLen == 3)
                m_rdLen3.Checked = true;

            m_ckIgnore.Checked = bIgnore;
        }

        private void initSerialParam(int nPort)
        {
            if (!(nPort >= 0))
                return;
            
            m_cmbSerialPort.SelectedIndex = m_cmbSerialPort.FindString(Convert.ToString(nPort + 1)); 
            VzClientSDK.VZ_SERIAL_PARAMETER oSerialParam = new VzClientSDK.VZ_SERIAL_PARAMETER();
            int ret = VzClientSDK.VzLPRClient_GetSerialParameter(m_hLPRClient, nPort, ref oSerialParam);
            if (ret == 0 && oSerialParam.uBaudRate > 0)
            {
                m_cmbBound.SelectedIndex = m_cmbBound.FindString(Convert.ToString(oSerialParam.uBaudRate));
                if (oSerialParam.uParity == 0)
                    m_cmbParity.SelectedIndex = m_cmbParity.FindString("无校验");
                else if (oSerialParam.uParity == 1)
                    m_cmbParity.SelectedIndex = m_cmbParity.FindString("奇校验");
                else if (oSerialParam.uParity == 2)
                    m_cmbParity.SelectedIndex = m_cmbParity.FindString("偶校验");
                m_cmbStop.SelectedIndex = m_cmbStop.FindString(Convert.ToString(oSerialParam.uStopBit));
                m_cmbDataBit.SelectedIndex = m_cmbDataBit.FindString(Convert.ToString(oSerialParam.uDataBits));
            }
            else
            {
                m_cmbBound.SelectedIndex = m_cmbBound.FindString(Convert.ToString(9600));
                m_cmbParity.SelectedIndex = m_cmbParity.FindString("无校验");
                m_cmbStop.SelectedIndex = m_cmbStop.FindString(Convert.ToString(1));
                m_cmbDataBit.SelectedIndex = m_cmbDataBit.FindString(Convert.ToString(8));
            }
            
        }

        private void initOutput()
        {
            VzClientSDK.VzLPRClient_GetOutputConfig(m_hLPRClient, ref m_oOutputInfo);

            //识别通过
            checkBox1.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].switchout1);
            checkBox2.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].switchout2);
            checkBox3.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].switchout3);
            checkBox4.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].switchout4);
            checkBox5.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].levelout1);
            checkBox6.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].levelout1);
            checkBox7.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].rs485out1);
            checkBox8.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[0].rs485out2);

            //识别不通过
            checkBox16.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].switchout1); 
            checkBox15.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].switchout2); 
            checkBox14.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].switchout3); 
            checkBox13.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].switchout4); 
            checkBox12.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].levelout1);
            checkBox11.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].levelout1);
            checkBox10.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].rs485out1);
            checkBox9.Checked  = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[1].rs485out2);

            //无车牌
            checkBox24.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].switchout1);
            checkBox23.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].switchout2);
            checkBox22.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].switchout3);
            checkBox21.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].switchout4);
            checkBox20.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].levelout1);
            checkBox19.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].levelout1);
            checkBox18.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].rs485out1);
            checkBox17.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[2].rs485out2);

            //黑名单
            checkBox32.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].switchout1);
            checkBox31.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].switchout2);
            checkBox30.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].switchout3);
            checkBox29.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].switchout4);
            checkBox28.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].levelout1);
            checkBox27.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].levelout1);
            checkBox26.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].rs485out1);
            checkBox25.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[3].rs485out2);

            //开关量/电平输入 1
            checkBox40.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[4].switchout1);
            checkBox39.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[4].switchout2);
            checkBox38.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[4].switchout3);
            checkBox37.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[4].switchout4);
            checkBox36.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[4].levelout1);
            checkBox35.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[4].levelout1);

            //开关量/电平输入 2
            checkBox48.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[5].switchout1);
            checkBox47.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[5].switchout2);
            checkBox46.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[5].switchout3);
            checkBox45.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[5].switchout4);
            checkBox44.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[5].levelout1);
            checkBox43.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[5].levelout1);

            //开关量/电平输入 3
            checkBox56.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[6].switchout1);
            checkBox55.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[6].switchout2);
            checkBox54.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[6].switchout3);
            checkBox53.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[6].switchout4);
            checkBox52.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[6].levelout1);
            checkBox51.Checked = Convert.ToBoolean(m_oOutputInfo.oConfigInfo[6].levelout1);
        }
        private void InAndOut_Form_Load(object sender, EventArgs e)
        {
            initOutput();
            initDelay();
            initWL();
            initMatch();
            initSerialParam(0);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].levelout1 = ConvertToInt(sender);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].levelout2 = ConvertToInt(sender);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].rs485out1 = ConvertToInt(sender);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNotWhiteList;
            m_oOutputInfo.oConfigInfo[nType].rs485out2 = ConvertToInt(sender);
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].switchout1 = ConvertToInt(sender);
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].switchout2 = ConvertToInt(sender);
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].switchout3 = ConvertToInt(sender);
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].switchout4 = ConvertToInt(sender);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].levelout1 = ConvertToInt(sender);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].levelout2 = ConvertToInt(sender);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].rs485out1 = ConvertToInt(sender);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nNoLicence;
            m_oOutputInfo.oConfigInfo[nType].rs485out2 = ConvertToInt(sender);
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].switchout1 = ConvertToInt(sender);
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].switchout2 = ConvertToInt(sender);
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].switchout3 = ConvertToInt(sender);
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].switchout4 = ConvertToInt(sender);
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].levelout1 = ConvertToInt(sender);
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].levelout2 = ConvertToInt(sender);
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].rs485out1 = ConvertToInt(sender);
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nBlackList;
            m_oOutputInfo.oConfigInfo[nType].rs485out2 = ConvertToInt(sender);
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl1;
            m_oOutputInfo.oConfigInfo[nType].switchout1 = ConvertToInt(sender);
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl1;
            m_oOutputInfo.oConfigInfo[nType].switchout2 = ConvertToInt(sender);
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl1;
            m_oOutputInfo.oConfigInfo[nType].switchout3 = ConvertToInt(sender);
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl1;
            m_oOutputInfo.oConfigInfo[nType].switchout4 = ConvertToInt(sender);
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl1;
            m_oOutputInfo.oConfigInfo[nType].levelout1 = ConvertToInt(sender);
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl1;
            m_oOutputInfo.oConfigInfo[nType].levelout2 = ConvertToInt(sender);
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl2;
            m_oOutputInfo.oConfigInfo[nType].switchout1 = ConvertToInt(sender);
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl2;
            m_oOutputInfo.oConfigInfo[nType].switchout2 = ConvertToInt(sender);
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl2;
            m_oOutputInfo.oConfigInfo[nType].switchout3 = ConvertToInt(sender);
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl2;
            m_oOutputInfo.oConfigInfo[nType].switchout4 = ConvertToInt(sender);
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl2;
            m_oOutputInfo.oConfigInfo[nType].levelout1 = ConvertToInt(sender);
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl2;
            m_oOutputInfo.oConfigInfo[nType].levelout2 = ConvertToInt(sender);
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl3;
            m_oOutputInfo.oConfigInfo[nType].switchout1 = ConvertToInt(sender);
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl3;
            m_oOutputInfo.oConfigInfo[nType].switchout2 = ConvertToInt(sender);
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl3;
            m_oOutputInfo.oConfigInfo[nType].switchout3 = ConvertToInt(sender);
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl3;
            m_oOutputInfo.oConfigInfo[nType].switchout4 = ConvertToInt(sender);
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl3;
            m_oOutputInfo.oConfigInfo[nType].levelout1 = ConvertToInt(sender);
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            int nType = (int)VzClientSDK.VZ_InputType.nExtIoctl3;
            m_oOutputInfo.oConfigInfo[nType].levelout2 = ConvertToInt(sender);
        }

        private void m_cmbSerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nPort = m_cmbSerialPort.SelectedIndex;
            initSerialParam(nPort);
        }
    }
}
