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
    public partial class VideoCfg_Form : Form
    {
        private int m_hLPRClient = 0;
        private int m_board_type = 0;

        public VideoCfg_Form()
        {
            InitializeComponent();
        }

        public void SetLPRHandle(int hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }

        private void LoadVideoSource( )
        {
            if(m_board_type == 2)
            {
                tbar_bright.SetRange(0, 255);
                tbar_contrast.SetRange(0, 255);
                tbar_saturation.SetRange(0, 255);
                tbar_definition.SetRange(0, 255);

                int brt = 0, cst = 0, sat = 0, hue = 0;
                int ret = VzClientSDK.VzLPRClient_GetVideoPara(m_hLPRClient, ref brt, ref cst, ref sat, ref hue);
                if (ret == 0)
                {
                    tbar_bright.Value = brt;
                    tbar_contrast.Value = cst;
                    tbar_saturation.Value = sat;
                    tbar_definition.Value = hue;

                    lblBright.Text = brt.ToString();
                    lblContrast.Text = cst.ToString();
                    lblSaturation.Text = sat.ToString();
                    lblDefinition.Text = hue.ToString();
                }

                label14.Visible             = false;
                cmb_video_standard.Visible  = false;

                cmb_exposure_time.Items.Clear();
                cmb_exposure_time.Items.Add("0~3ms");
                cmb_exposure_time.Items.Add("0~2ms");
                cmb_exposure_time.Items.Add("0~1ms");

                int shutter = 0;
                ret = VzClientSDK.VzLPRClient_GetShutter(m_hLPRClient, ref shutter);
                if (ret == 0)
                {
                    if (shutter == 96)
                    {
                        cmb_exposure_time.SelectedIndex  = 0;
                    }
                    else if (shutter == 64)
                    {
                        cmb_exposure_time.SelectedIndex = 1;
                    }
                    else if (shutter == 32)
                    {
                        cmb_exposure_time.SelectedIndex = 2;
                    }
                }

                int flip = 0;
                ret = VzClientSDK.VzLPRClient_GetFlip(m_hLPRClient, ref flip);
                if (ret == 0)
                {
                    cmb_img_pos.SelectedIndex = flip;
                }
               
                int nMode = 0, nStrength = 0;
                int nRet = VzClientSDK.VzLPRClient_GetDenoise(m_hLPRClient, ref nMode, ref nStrength);
                if (nMode >= 0 && nStrength >= 0)
                {
                    m_cmbDeNoiseMode.SelectedIndex  = nMode;
                    m_cmbDeNoiseLenth.SelectedIndex = nStrength;
                }
            }
            else
            {
                int brt = 0, cst = 0, sat = 0, hue = 0;
                int ret = VzClientSDK.VzLPRClient_GetVideoPara(m_hLPRClient, ref brt, ref cst, ref sat, ref hue);
                if (ret == 0)
                {
                    tbar_bright.Value = brt;
                    tbar_contrast.Value = cst;
                    tbar_saturation.Value = sat;
                    tbar_definition.Value = hue;

                    lblBright.Text = brt.ToString();
                    lblContrast.Text = cst.ToString();
                    lblSaturation.Text = sat.ToString();
                    lblDefinition.Text = hue.ToString();
                }

                int frequency = 0;
                ret = VzClientSDK.VzLPRClient_GetFrequency(m_hLPRClient, ref frequency);
                if (ret == 0)
                {
                    cmb_video_standard.SelectedIndex = frequency;
                }

                int shutter = 0;
                ret = VzClientSDK.VzLPRClient_GetShutter(m_hLPRClient, ref shutter);
                if (ret == 0)
                {
                    if (shutter == 2)
                    {
                        cmb_exposure_time.SelectedIndex = 0;
                    }
                    else if (shutter == 3)
                    {
                        cmb_exposure_time.SelectedIndex = 1;
                    }
                    else if (shutter == 4)
                    {
                        cmb_exposure_time.SelectedIndex = 2;
                    }
                }

                int flip = 0;
                ret = VzClientSDK.VzLPRClient_GetFlip(m_hLPRClient, ref flip);
                if (ret == 0)
                {
                    cmb_img_pos.SelectedIndex = flip;
                }
            }
        }

        private void LoadVideoCfg()
        {
            string strRateval = "512";

            if (m_hLPRClient > 0)
            {
                int nSizeVal = 0, nRateval = 0, nEncodeType = 0, modeval = 0, bitval = 0, ratelist = 0, levelval = 0;
                int ret = -1; 

                if (m_board_type == 2)
                {
                    cmb_frame_size.Items.Clear();
                    cmb_frame_size.Items.Add("640x360");
                    cmb_frame_size.Items.Add("720x576");
                    cmb_frame_size.Items.Add("1280x720");
                    cmb_frame_size.Items.Add("1920x1080");

                    ret = VzClientSDK.VzLPRClient_GetVideoFrameSizeIndexEx(m_hLPRClient, ref nSizeVal);

                    if (nSizeVal == 41943400)
                    {
                        cmb_frame_size.SelectedIndex = 0;
                    }
                    else if (nSizeVal == 47186496)
                    {
                        cmb_frame_size.SelectedIndex = 1;
                    }
                    else if (nSizeVal == 83886800)
                    {
                        cmb_frame_size.SelectedIndex = 2;
                    }
                    else if (nSizeVal == 125830200)
                    {
                        cmb_frame_size.SelectedIndex = 3;
                    }
                    else
                    {
                        cmb_frame_size.SelectedIndex = 0;
                    }

                    cmb_encode_type.SelectedIndex = 0;
                    cmb_encode_type.Items.RemoveAt(1);
                }
                else
                {
                    ret = VzClientSDK.VzLPRClient_GetVideoEncodeType(m_hLPRClient, ref nEncodeType);
                    if (ret == 0)
                    {
                        if (nEncodeType == 0)
                        {
                            cmb_encode_type.SelectedIndex = 0;
                            cmb_compress_mode.Enabled = true;
                        }
                        else
                        {
                            cmb_encode_type.SelectedIndex = 1;
                            cmb_compress_mode.Enabled = false;
                        }
                    }

                    ret = VzClientSDK.VzLPRClient_GetVideoFrameSizeIndex(m_hLPRClient, ref nSizeVal);

                    if (ret == 0)
                    {
                        if (nSizeVal == 0)
                        {
                            cmb_frame_size.SelectedIndex = 1;
                        }
                        else if (nSizeVal == 1)
                        {
                            cmb_frame_size.SelectedIndex = 0;
                        }
                        else
                        {
                            cmb_frame_size.SelectedIndex = nSizeVal;
                        }
                    }
                }

                ret = VzClientSDK.VzLPRClient_GetVideoFrameRate(m_hLPRClient, ref nRateval);
                if (ret == 0 && nRateval > 0)
                {
                    cmb_frame_rate.SelectedIndex = nRateval - 1;
                }

                ret = VzClientSDK.VzLPRClient_GetVideoCompressMode(m_hLPRClient, ref modeval);
                if (ret == 0)
                {
                    cmb_compress_mode.SelectedIndex = modeval;

                    if (modeval == 0)
                    {
                        txt_rateval.Enabled = true;
                    }
                    else
                    {
                        txt_rateval.Enabled = false;
                    }
                }

                ret = VzClientSDK.VzLPRClient_GetVideoCBR(m_hLPRClient, ref bitval, ref ratelist);
                if (ret == 0)
                {
                    strRateval = bitval.ToString();
                }

                ret = VzClientSDK.VzLPRClient_GetVideoVBR(m_hLPRClient, ref levelval);
                if (ret == 0)
                {
                    cmb_img_quality.SelectedIndex = levelval;
                }
            }

            txt_rateval.Text = strRateval;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sRateVal = txt_rateval.Text.ToString();
            int nRate = Int32.Parse(sRateVal);

            int ret = -1;

            int nSizeVal = cmb_frame_size.SelectedIndex;

            if (m_board_type == 2)
            {
                if (nRate < 512 || nRate > 5000)
                {
                    MessageBox.Show("码流范围为512-5000，请重新输入！");
                    return;
                }

                switch (nSizeVal)
                {
                    case 0:
                        nSizeVal = 41943400; break;
                    case 1:
                        nSizeVal = 47186496; break;
                    case 2:
                        nSizeVal = 83886800; break;
                    case 3:
                        nSizeVal = 125830200; break;
                    default:
                        break;
                }

                ret = VzClientSDK.VzLPRClient_SetVideoFrameSizeIndexEx(m_hLPRClient, nSizeVal);
                if (ret != 0)
                {
                    MessageBox.Show("设置分辨率失败，请重试！");
                    return;
                }
            }
            else
            {
                if (nRate <= 99 || nRate > 5000)
                {
                    MessageBox.Show("码流范围为100-5000，请重新输入！");
                    return;
                }

                if (nSizeVal == 0)
                {
                    nSizeVal = 1;
                }
                else if (nSizeVal == 1)
                {
                    nSizeVal = 0;
                }


                ret = VzClientSDK.VzLPRClient_SetVideoFrameSizeIndex(m_hLPRClient, nSizeVal);
                if (ret != 0)
                {
                    MessageBox.Show("设置分辨率失败，请重试！");
                    return;
                }
            }
            
            int nRateval = cmb_frame_rate.SelectedIndex + 1;
            ret = VzClientSDK.VzLPRClient_SetVideoFrameRate(m_hLPRClient, nRateval);
            if (ret != 0)
            {
                MessageBox.Show("设置帧率失败，请重试！");
                return;
            }

            int nEncodeType = (cmb_encode_type.SelectedIndex == 0) ? 0 : 2;
            ret = VzClientSDK.VzLPRClient_SetVideoEncodeType(m_hLPRClient, nEncodeType);
            if (ret != 0)
            {
                MessageBox.Show("设置编码方式失败，请重试！");
                return;
            }

            if (cmb_compress_mode.Enabled)
            {
                int modeval = cmb_compress_mode.SelectedIndex;
                ret = VzClientSDK.VzLPRClient_SetVideoCompressMode(m_hLPRClient, modeval);
                if (ret != 0)
                {
                    MessageBox.Show("设置码流控制失败，请重试！");
                    return;
                }
            }

            int level = cmb_img_quality.SelectedIndex;
            ret = VzClientSDK.VzLPRClient_SetVideoVBR(m_hLPRClient, level);
            if (ret != 0)
            {
                MessageBox.Show("设置图像质量失败，请重试！");
                return;
            }

            if (txt_rateval.Enabled)
            {
                ret = VzClientSDK.VzLPRClient_SetVideoCBR(m_hLPRClient, nRate);
                if (ret != 0)
                {
                    MessageBox.Show("设置码流上限失败，请重试！");
                    return;
                }
            }

            MessageBox.Show("设置成功！");
        }

        private void VideoCfg_Form_Load(object sender, EventArgs e)
        {
            VzClientSDK.VzLPRClient_GetHwBoardType(m_hLPRClient, ref m_board_type);
            
            LoadVideoCfg();

            LoadVideoSource();
        }

        private void cmb_encode_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nCurSel = cmb_encode_type.SelectedIndex;
            if (nCurSel == 0)
            {
                cmb_compress_mode.Enabled = true;
            }
            else
            {
                cmb_compress_mode.Enabled = false;
            }
        }

        private void cmb_compress_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_compress_mode.Enabled)
            {
                int nCurSel = cmb_compress_mode.SelectedIndex;
                if (nCurSel == 0)
                {
                    txt_rateval.Enabled = true;
                }
                else
                {
                    txt_rateval.Enabled = false;
                }
            }
            else
            {
                txt_rateval.Enabled = false;
            }
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            if (m_board_type == 2)
            {
                int brt = 128;
                tbar_bright.Value = brt;

                int cst = 138;
                tbar_contrast.Value = cst;

                int sat = 128;
                tbar_saturation.Value = sat;

                int hue = 140;
                tbar_definition.Value = hue;

                VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);

                VzClientSDK.VzLPRClient_SetShutter(m_hLPRClient, 96);
                cmb_exposure_time.SelectedIndex = 0;

                VzClientSDK.VzLPRClient_SetFlip(m_hLPRClient, 0);
                cmb_img_pos.SelectedIndex = 0;

                VzClientSDK.VzLPRClient_SetDenoise(m_hLPRClient, 3, 2);
                m_cmbDeNoiseMode.SelectedIndex = 3;
                m_cmbDeNoiseLenth.SelectedIndex = 2;

                lblBright.Text = brt.ToString();
                lblContrast.Text = cst.ToString();
                lblSaturation.Text = sat.ToString();
                lblDefinition.Text = hue.ToString();
            }
            else
            {
                int brt = 50;
                tbar_bright.Value = brt;

                int cst = 40;
                tbar_contrast.Value = cst;

                int sat = 30;
                tbar_saturation.Value = sat;

                int hue = 50;
                tbar_definition.Value = hue;
                VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);

                VzClientSDK.VzLPRClient_SetFrequency(m_hLPRClient, 1);
                cmb_video_standard.SelectedIndex = 1;

                VzClientSDK.VzLPRClient_SetShutter(m_hLPRClient, 3);
                cmb_exposure_time.SelectedIndex = 1;

                VzClientSDK.VzLPRClient_SetFlip(m_hLPRClient, 0);
                cmb_img_pos.SelectedIndex = 0;

                lblBright.Text = brt.ToString();
                lblContrast.Text = cst.ToString();
                lblSaturation.Text = sat.ToString();
                lblDefinition.Text = hue.ToString();
            }
        }

        private void tbar_bright_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int hue = tbar_definition.Value;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();
            lblDefinition.Text = hue.ToString();

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);
        }

        private void tbar_contrast_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int hue = tbar_definition.Value;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();
            lblDefinition.Text = hue.ToString();

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);
        }

        private void tbar_saturation_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int hue = tbar_definition.Value;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();
            lblDefinition.Text = hue.ToString();

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);
        }

        private void tbar_definition_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int hue = tbar_definition.Value;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();
            lblDefinition.Text = hue.ToString();

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);
        }

        private void cmb_video_standard_SelectedIndexChanged(object sender, EventArgs e)
        {
            int frequency = cmb_video_standard.SelectedIndex;
            int ret = VzClientSDK.VzLPRClient_SetFrequency(m_hLPRClient, frequency);
        }

        private void cmb_exposure_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_board_type == 2)
            {
                int shutter = 0;
                int curSel = cmb_exposure_time.SelectedIndex;
                if (curSel == 0)
                {
                    shutter = 96;
                }
                else if (curSel == 1)
                {
                    shutter = 64;
                }
                else if (curSel == 2)
                {
                    shutter = 32;
                }

                int ret = VzClientSDK.VzLPRClient_SetShutter(m_hLPRClient, shutter);
            }
            else
            {
                int shutter = 0;
                int curSel = cmb_exposure_time.SelectedIndex;
                if (curSel == 0)
                {
                    shutter = 2;
                }
                else if (curSel == 1)
                {
                    shutter = 3;
                }
                else if (curSel == 2)
                {
                    shutter = 4;
                }

                int ret = VzClientSDK.VzLPRClient_SetShutter(m_hLPRClient, shutter);
            }
        }

        private void cmb_img_pos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int flip = cmb_img_pos.SelectedIndex;
            int ret = VzClientSDK.VzLPRClient_SetFlip(m_hLPRClient, flip);
        }

        private void m_cmbDeNoiseMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mode = m_cmbDeNoiseMode.SelectedIndex;
            int strength = m_cmbDeNoiseLenth.SelectedIndex;
            int ret = VzClientSDK.VzLPRClient_SetDenoise(m_hLPRClient, mode, strength);	
        }

        private void m_cmbDeNoiseLenth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mode = m_cmbDeNoiseMode.SelectedIndex;
            int strength = m_cmbDeNoiseLenth.SelectedIndex;
            int ret = VzClientSDK.VzLPRClient_SetDenoise(m_hLPRClient, mode, strength);	
        }
    }
}
