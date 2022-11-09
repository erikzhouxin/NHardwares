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
    public partial class RVideoCfg_Form : Form
    {
        public class ComboxItem
        {
            private string text;
            private string values;

            public string Text
            {
                get { return this.text; }
                set { this.text = value; }
            }

            public string Values
            {
                get { return this.values; }
                set { this.values = value; }
            }

            public ComboxItem(string _Text, string _Values)
            {
                Text = _Text;
                Values = _Values;
            }


            public override string ToString()
            {
                return Text;
            }
        } 

        private int m_hLPRClient = 0;
        private int m_nMinDataRate;
        private int m_nMaxDataRate;
        private VzClientSDK.VZ_LPRC_R_VIDEO_PARAM m_video_param = new VzClientSDK.VZ_LPRC_R_VIDEO_PARAM();

        public RVideoCfg_Form()
        {
            InitializeComponent();
        }

        public void SetLPRHandle(int hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }

        private void LoadVideoCfg()
        {
            VzClientSDK.VZ_LPRC_R_ENCODE_PARAM encode_param = new VzClientSDK.VZ_LPRC_R_ENCODE_PARAM();

            VzClientSDK.VzLPRClient_RGet_Encode_Param(m_hLPRClient, 0, ref encode_param);
            m_cmbStreamType.SelectedIndex = encode_param.default_stream;

            LoadStreamParam(encode_param.default_stream);
        }

        private void LoadStreamParam(int stream_index)
        {
            int modeval = 0;

            VzClientSDK.VZ_LPRC_R_ENCODE_PARAM encode_param = new VzClientSDK.VZ_LPRC_R_ENCODE_PARAM();
            VzClientSDK.VzLPRClient_RGet_Encode_Param(m_hLPRClient, stream_index, ref encode_param);

            bool sub_stream = false;

            // 加载子码流参数
            if (stream_index == 1)
            {
                sub_stream = true;
            }

            int index = 0;

            VzClientSDK.VZ_LPRC_R_ENCODE_PARAM_PROPERTY param_property = new VzClientSDK.VZ_LPRC_R_ENCODE_PARAM_PROPERTY();
            VzClientSDK.VzLPRClient_RGet_Encode_Param_Property(m_hLPRClient, ref param_property);

            cmb_frame_size.Items.Clear();
            int resolution_cur = encode_param.resolution;

            m_nMinDataRate = param_property.data_rate_min;
            m_nMaxDataRate = param_property.data_rate_max;

            while (param_property.resolution[index].resolution_type > 0)
            {
                cmb_frame_size.Items.Add(new ComboxItem(param_property.resolution[index].resolution_content,param_property.resolution[index].resolution_type.ToString()));

                if (resolution_cur == param_property.resolution[index].resolution_type)
                {
                    cmb_frame_size.SelectedIndex = index;
                }

                index++;

                if (sub_stream && index >= 3)
                {
                    break;
                }
            }

            if (encode_param.frame_rate >= 1 && encode_param.frame_rate <= 25)
            {
                cmb_frame_rate.SelectedIndex  = encode_param.frame_rate - 1;
            }

            if (encode_param.video_quality >= 0 && encode_param.video_quality <= 6)
            {
                cmb_img_quality.SelectedIndex = encode_param.video_quality;
            }
            else
            {
                cmb_img_quality.SelectedIndex = 3;
            }

            int rateval = encode_param.data_rate / 1000;
            txt_rateval.Text = rateval.ToString();

            //码流控制
            modeval = encode_param.rate_type;
            cmb_compress_mode.SelectedIndex  = modeval;

            cmb_encode_type.SelectedIndex = 0;

            txt_rateval.Enabled = (modeval == 0) ? true : false;
            cmb_img_quality.Enabled = (modeval == 0) ? false : true;
        }

        private void LoadVideoSource( )
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

            ret = VzClientSDK.VzLPRClient_RGet_Video_Param(m_hLPRClient, ref m_video_param);
            if (ret == 0)
            {
                tbar_definition.Value = m_video_param.max_gain;
            }

            int flip = 0;
            ret = VzClientSDK.VzLPRClient_GetFlip(m_hLPRClient, ref flip);
            if (ret == 0)
            {
                cmb_img_pos.SelectedIndex = flip;
            }
            else
            {
                cmb_img_pos.SelectedIndex = 0;
            }

            int shutter = 0;
            ret = VzClientSDK.VzLPRClient_GetShutter(m_hLPRClient, ref shutter);

            if (shutter >= 1)
            {
                cmb_exposure_time.SelectedIndex = shutter - 1;
            }
            else
            {
                cmb_exposure_time.SelectedIndex = 0;
            }
        }

        private void RVideoCfg_Form_Load(object sender, EventArgs e)
        {
            LoadVideoCfg();

            LoadVideoSource();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int stream_type = m_cmbStreamType.SelectedIndex;

            VzClientSDK.VZ_LPRC_R_ENCODE_PARAM encode_param = new VzClientSDK.VZ_LPRC_R_ENCODE_PARAM();
            encode_param.default_stream = stream_type;

            int frame_size = cmb_frame_size.SelectedIndex;

            string strFrameType = ((ComboxItem)cmb_frame_size.Items[frame_size]).Values;
            int frame_type = int.Parse(strFrameType);
            encode_param.resolution = frame_type;

            encode_param.frame_rate = cmb_frame_rate.SelectedIndex + 1;

            encode_param.rate_type = cmb_compress_mode.SelectedIndex;

            encode_param.video_quality = cmb_img_quality.SelectedIndex;


            string sRateVal = txt_rateval.Text.ToString();
            int nRate = int.Parse(sRateVal) * 1000;

            if (nRate < m_nMinDataRate || nRate > m_nMaxDataRate)
            {
                int min_rate = m_nMinDataRate / 1000;
                int max_rate = m_nMaxDataRate / 1000;
                string msgInfo = "码流范围为" + min_rate + "-" + max_rate + "，请重新输入！";

                MessageBox.Show(msgInfo);
                return;
            }

            encode_param.data_rate = nRate;

            int ret = VzClientSDK.VzLPRClient_RSet_Encode_Param(m_hLPRClient, stream_type, ref encode_param);
            if (ret != 0)
            {
                MessageBox.Show("设置视频参数失败，请重试！");
            }

            MessageBox.Show("设置视频参数成功！");
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            int brt = 50;
            int cst = 50;
            int sat = 50;

            tbar_bright.Value = brt;
            tbar_contrast.Value = cst;
            tbar_saturation.Value = sat;
            tbar_definition.Value = 50;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();
            lblDefinition.Text = "50";

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, 50);

            int max_gain = 50;

            m_video_param.max_gain = max_gain;
            m_video_param.brightness = brt;
            m_video_param.contrast = cst;
            m_video_param.saturation = sat;
            m_video_param.hue = 50;
            VzClientSDK.VzLPRClient_RSet_Video_Param(m_hLPRClient, ref m_video_param);

            VzClientSDK.VzLPRClient_SetShutter(m_hLPRClient, 3);
            cmb_exposure_time.SelectedIndex = 2;

            VzClientSDK.VzLPRClient_SetFlip(m_hLPRClient, 0);
            cmb_img_pos.SelectedIndex = 0;
        }

        private void m_cmbStreamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cur_sel = m_cmbStreamType.SelectedIndex;
            LoadStreamParam(cur_sel);
        }

        private void cmb_img_pos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int flip = cmb_img_pos.SelectedIndex;
            int ret = VzClientSDK.VzLPRClient_SetFlip(m_hLPRClient, flip);
        }

        private void cmb_exposure_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            int shutter = cmb_exposure_time.SelectedIndex;
            int ret = VzClientSDK.VzLPRClient_SetShutter(m_hLPRClient, shutter + 1);
        }

        private void tbar_bright_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int hue = 50;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);
        }

        private void tbar_contrast_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int hue = 50;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);
        }

        private void tbar_saturation_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int hue = 50;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();

            VzClientSDK.VzLPRClient_SetVideoPara(m_hLPRClient, brt, cst, sat, hue);
        }

        private void tbar_definition_MouseUp(object sender, MouseEventArgs e)
        {
            int brt = tbar_bright.Value;
            int cst = tbar_contrast.Value;
            int sat = tbar_saturation.Value;
            int max_gain = tbar_definition.Value;

            lblBright.Text = brt.ToString();
            lblContrast.Text = cst.ToString();
            lblSaturation.Text = sat.ToString();
            lblDefinition.Text = max_gain.ToString();

            m_video_param.brightness = brt;
            m_video_param.contrast = cst;
            m_video_param.saturation = sat;
            m_video_param.max_gain = max_gain;
            VzClientSDK.VzLPRClient_RSet_Video_Param(m_hLPRClient, ref m_video_param);
        }
    }
}
