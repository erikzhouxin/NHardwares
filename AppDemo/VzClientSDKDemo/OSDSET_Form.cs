using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VzClientSDKDemo
{
    public partial class OSDSET_Form : Form
    {

        private int m_hLPRClient = 0;
        private int m_nDateX;
        private int m_nDateY;
        private int m_nTimeX;
        private int m_nTimeY;
        private int m_nTextX;
        private int m_nTextY;
        private int m_hwType;
        VzClientSDK.VZ_LPRC_OSD_Param osdParam = new VzClientSDK.VZ_LPRC_OSD_Param();

        public OSDSET_Form()
        {
            InitializeComponent();
            m_hwType = 0;
        }

        public int get_ivs_i2s(int val1, int val2)
        {
            int result = (val1 << 14) / val2;
            return result;
        }

        public int get_ivs_s2i(int val1, int val2)
        {
            int result = (val1 * val2 + (1 << 13)) >> 14;
            return result;
        }

        public void SetLPRHandle(int m_hLPRClient_)
        {
            m_hLPRClient = m_hLPRClient_;

            int ret = VzClientSDK.VzLPRClient_GetHwBoardType(m_hLPRClient, ref m_hwType);

            int size = Marshal.SizeOf(osdParam);
            IntPtr intptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(osdParam, intptr, true);
            VzClientSDK.VzLPRClient_GetOsdParam(m_hLPRClient, intptr);
            osdParam = (VzClientSDK.VZ_LPRC_OSD_Param)Marshal.PtrToStructure(intptr, typeof(VzClientSDK.VZ_LPRC_OSD_Param));

            daystylecheck.Checked = (int)osdParam.dstampenable == 0 ? false : true;
            timestylecheck.Checked = (int)osdParam.tstampenable == 0 ? false : true;
            textcheck.Checked = (int)osdParam.nTextEnable == 0 ? false : true;

            m_nDateX = osdParam.datePosX;
            m_nDateY = osdParam.datePosY;
            m_nTimeX = osdParam.timePosX;
            m_nTimeY = osdParam.timePosY;
            m_nTextX = osdParam.nTextPositionX;
            m_nTextY = osdParam.nTextPositionY;

            int width = 0;
            if (m_hwType == 2)
            {
                width = 720;
            }
            else if (m_hwType == 3)
            {
                width = 704;
            }
            else
            {
                width = 704;
            }

            m_nDateX = get_ivs_s2i(get_ivs_i2s(m_nDateX, width), 100);
            m_nDateY = get_ivs_s2i(get_ivs_i2s(m_nDateY, 576), 100);
            m_nTimeX = get_ivs_s2i(get_ivs_i2s(m_nTimeX, width), 100);
            m_nTimeY = get_ivs_s2i(get_ivs_i2s(m_nTimeY, 576), 100);
            m_nTextX = get_ivs_s2i(get_ivs_i2s(m_nTextX, width), 100);
            m_nTextY = get_ivs_s2i(get_ivs_i2s(m_nTextY, 576), 100);

            daypointx.Text = m_nDateX.ToString();
            daypointy.Text = m_nDateY.ToString();
            timepointx.Text = m_nTimeX.ToString();
            timepointy.Text = m_nTimeY.ToString();
            textpointx.Text = m_nTextX.ToString();
            textpointy.Text = m_nTextY.ToString();
            textedit.Text = osdParam.overlaytext;

            int nDataFormat = osdParam.dateFormat;
            if(nDataFormat >= 0 && nDataFormat < 3)
            {
                daycombobox.SelectedIndex = nDataFormat;
            }
            else
            {
                daycombobox.SelectedIndex = 0;
            }
            int nTimeFormat = osdParam.timeFormat;
            if(nTimeFormat == 0 || nTimeFormat == 1)
            {
                timecombobox.SelectedIndex = nTimeFormat;
            }
            else
            {
                timecombobox.SelectedIndex = 0;
            }
            Marshal.FreeHGlobal(intptr);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            osdParam.dstampenable = daystylecheck.Checked ? (byte)1 : (byte)0;
            osdParam.tstampenable = timestylecheck.Checked ? (byte)1 : (byte)0;
            osdParam.nTextEnable = textcheck.Checked ? (byte)1 : (byte)0;

            m_nDateX = Int32.Parse(daypointx.Text);
            m_nDateY = Int32.Parse(daypointy.Text);
            m_nTimeX = Int32.Parse(timepointx.Text);
            m_nTimeY = Int32.Parse(timepointy.Text);
            m_nTextX = Int32.Parse(textpointx.Text);
            m_nTextY = Int32.Parse(textpointy.Text);

            bool value = false;

            do
            {
                if (m_nDateX < 0 || m_nDateX > 100)
                {
                    break;
                }

                if (m_nDateY < 0 || m_nDateY > 100)
                {
                    break;
                }

                if (m_nTimeX < 0 || m_nTimeX > 100)
                {
                    break;
                }

                if (m_nTimeY < 0 || m_nTimeY > 100)
                {
                    break;
                }

                if (m_nTextX < 0 || m_nTextX > 100)
                {
                    break;
                }

                if (m_nTextY < 0 || m_nTextY > 100)
                {
                    break;
                }

                value = true;
            } while (false);

            if (!value)
            {
                MessageBox.Show("比例在0-100之间，请重新输入。");
                return;
            }

            int width = 0;
            if (m_hwType == 1)
            {
                width = 704;
            }
            else if (m_hwType == 2)
            {
                width = 720;
            }
            else if (m_hwType == 3)
            {
                width = 704;
            }

            osdParam.datePosX = get_ivs_s2i(get_ivs_i2s(m_nDateX, 100), width);
            osdParam.datePosY = get_ivs_s2i(get_ivs_i2s(m_nDateY, 100), 576);
            osdParam.timePosX = get_ivs_s2i(get_ivs_i2s(m_nTimeX, 100), width);
            osdParam.timePosY = get_ivs_s2i(get_ivs_i2s(m_nTimeY, 100), 576);
            osdParam.nTextPositionX = get_ivs_s2i(get_ivs_i2s(m_nTextX, 100), width);
            osdParam.nTextPositionY = get_ivs_s2i(get_ivs_i2s(m_nTextY, 100), 576);

            osdParam.overlaytext = textedit.Text.ToString();

            osdParam.dateFormat = daycombobox.SelectedIndex;
            osdParam.timeFormat = timecombobox.SelectedIndex;

            int size = Marshal.SizeOf(osdParam);
            IntPtr intptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(osdParam, intptr, true);
            int temp = VzClientSDK.VzLPRClient_SetOsdParam(m_hLPRClient, intptr);
            Marshal.FreeHGlobal(intptr);

            if (timesetcheck.Checked)
            {
                VzClientSDK.VZ_DATE_TIME_INFO TimeInfo = new VzClientSDK.VZ_DATE_TIME_INFO();

                TimeInfo.uYear = (uint)dayupdate.Value.Year;
                TimeInfo.uMonth = (uint)dayupdate.Value.Month;
                TimeInfo.uMDay = (uint)dayupdate.Value.Day;
                TimeInfo.uHour = (uint)timeupdate.Value.Hour;
                TimeInfo.uMin = (uint)timeupdate.Value.Minute;
                TimeInfo.uSec = (uint)timeupdate.Value.Second;

                int timesize = Marshal.SizeOf(TimeInfo);
                IntPtr timeptr = Marshal.AllocHGlobal(timesize);
                Marshal.StructureToPtr(TimeInfo, timeptr, true);
                int timetemp = VzClientSDK.VzLPRClient_SetDateTime(m_hLPRClient, timeptr);
                if(temp == 0 && timetemp == 0)
                {
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    MessageBox.Show("修改失败!");
                }
                Marshal.FreeHGlobal(timeptr);
            }
            else if(temp == 0)
            {
                MessageBox.Show("修改成功!");
            }
            else
            {
                MessageBox.Show("修改失败!");
            }
            this.Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
