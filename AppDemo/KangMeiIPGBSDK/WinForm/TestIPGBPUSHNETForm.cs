using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using IPGBPUSH.NET;

namespace TestIPGBNETPush
{
    public partial class TestIPGBPUSHNETForm : Form
    {
        Int32 m_GbStreamId; //当前广播流包柄
        #region 回调函数

        //广播流状态回调
        void gbStreamSta(Int32 stream_id, int stream_sta, Int64 dwUser)
        {

            TestIPGBPUSHNETForm thisForm = Form.FromHandle((IntPtr)dwUser) as TestIPGBPUSHNETForm;
            if (stream_id != 0)   //为新创建的广播，服务器回应是否创建成功
            {
                if (stream_sta == 0)
                {
                    thisForm.SetEnableSendGb(false);
                    thisForm.InsertLogMessage("推流ID:" + stream_id + "  " + "推流状态:成功" + "\n");
                }
                else
                {
                    thisForm.InsertLogMessage("推流状态:" + getStreanContent(stream_sta) + "\n");
                }
            }
            else    //此广播前面已创建成功，但此广播已停止
            {

                thisForm.InsertLogMessage("推流已停止......\n");
            }

        }

        //获取推流状态
        public String getStreanContent(int enm)
        {
            string result = "";
            switch (enm)
            {
                case 0:
                    result = "正在推流";
                    break;
                case 1:
                    result = "正在连接";
                    break;
                case 2:
                    result = "接收广播";
                    break;
                case 3:
                    result = "连接服务器失败";
                    break;
                case 4:
                    result = "非法连接";
                    break;
                case 5:
                    result = "断开连接";
                    break;
                default:
                    result = "未知";
                    break;

            }
            return result;
        }

        #endregion

        // 构造函数初始化
        public TestIPGBPUSHNETForm()
        {
            InitializeComponent();
        }

        // 设置初始化状态
        void InitButtonsEnabledStatus()
        {
            this.buttonStop.Enabled = false;
        }

        //设置广播停止状态
        void SetEnableSendGb(bool enable)
        {
            this.buttonSound.Enabled = enable;
            this.buttonThrid.Enabled = enable;
            this.buttonFile.Enabled = enable;
            this.buttonStop.Enabled = !enable;
        }


        // 窗体加载程序
        private void TestIPGBPUSHNETForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            this.txtIP.Text = "192.168.1.63";

            this.txtPort.Text = "2893";
            this.txtEncType.Text = "1";

            // 初始化按钮状态
            InitButtonsEnabledStatus();

            IPGBPUSHNETSDK.Instance.NETIPGBPUSHNETSDK_Init();
            IPGBPUSHNETSDK.Instance.NETIPGBPUSHNETSDK_SetGBStreamStaCallBack(gbStreamSta, this.Handle.ToInt64());             //广播流状态回调
            InsertLogMessage("SDK初始化......");
        }

        // 窗体关闭
        private void TestIPGBPUSHNETForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IPGBPUSHNETSDK.Instance.NETIPGBPUSHNETSDK_Cleanup();
        }

        // 显示业务日志消息函数
        private void InsertLogMessage(string sLog)
        {
            string sMsg = string.Format("{0}\r\n", sLog);
            txtArea.Text = txtArea.Text.Insert(0, sMsg);
        }

        //声卡推流的点击事件
        private void buttonSound_Click(object sender, EventArgs e)
        {
            NETPUSHSDK_SOUNDCARDINFO cardPubInfo = new NETPUSHSDK_SOUNDCARDINFO();
            // 第1步 获取声卡信息
            String[] card_list = IPGBPUSHNETSDK.Instance.NETIPGBPUSHNETSDK_GetSysSoundCardINFO(ref cardPubInfo);
            String cardNo = card_list.Length > 1 ? card_list[1] : card_list[0];

            // 构造请求对象
            NETPUSHSDK_SoundCarPushStream pSrcinfo = new NETPUSHSDK_SoundCarPushStream();
            pSrcinfo.EncType = Convert.ToUInt16(txtEncType.Text.ToString()); ; //编码类型
            pSrcinfo.ASerSrcId = Convert.ToUInt16(txtChannelId.Text.ToString());
            pSrcinfo.LogType = 0;
            pSrcinfo.Sport = Convert.ToUInt16(txtPort.Text.ToString());
            pSrcinfo.Sip = txtIP.Text.ToString();
            pSrcinfo.Sdomain = "";
            pSrcinfo.Sdes = txtBuf.Text.ToString();


            // 声卡对象
            NETPUSHSDK_CBSOUNDNODE capMixInfo = new NETPUSHSDK_CBSOUNDNODE();
            capMixInfo.CapMixVol = 50;
            capMixInfo.CapMixName = cardNo;
            pSrcinfo.CapMixInfo = capMixInfo;

            m_GbStreamId = IPGBPUSHNETSDK.Instance.NETIPGBPUSHNETSDK_CreateSoundCardPushStream(ref pSrcinfo);
            if (m_GbStreamId != 0)
            {
                InsertLogMessage("声卡推流id=" + m_GbStreamId + "\n");
            }
        }
        // 第三方实时推流点击
        private void buttonThrid_Click(object sender, EventArgs e)
        {

        }

        // 文件实时推流点击
        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Title = "请选择文件路径";
            fd.Filter = "mp3文件|*.mp3";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string fileName = fd.FileName;
                InsertLogMessage("文件实时推流选择路径=" + fileName + "\n");


                //构造请求对象
                NETPUSHSDK_ThirdPushStream pGbinfo = new NETPUSHSDK_ThirdPushStream();
                pGbinfo.EncType = Convert.ToUInt16(txtEncType.Text.ToString()); ; //编码类型
                pGbinfo.StreamType = 2;
                pGbinfo.ASerSrcId = Convert.ToUInt16(txtChannelId.Text.ToString());
                pGbinfo.LogType = 0;
                pGbinfo.LcaFile_loop = 1;
                pGbinfo.LcaFile_PlayLen = 0;
                pGbinfo.LcaFileCout = 1;
                pGbinfo.Sport = Convert.ToUInt16(txtPort.Text.ToString());
                pGbinfo.Sip = txtIP.Text.ToString();//服务器IP
                pGbinfo.Sdomain = "";
                pGbinfo.Sdes = txtBuf.Text.ToString();

                NETPUSHSDK_LCA_ONEFILEINFO f_inifo = new NETPUSHSDK_LCA_ONEFILEINFO();
                f_inifo.FilePath = fileName;

                NETPUSHSDK_LCA_ONEFILEINFO[] files = new NETPUSHSDK_LCA_ONEFILEINFO[1];
                files[0] = f_inifo;
                pGbinfo.LcaFileInfo = files;
                InsertLogMessage("本地文件认证加密的内容=======" + pGbinfo.Sdes);
                m_GbStreamId = IPGBPUSHNETSDK.Instance.NETIPGBPUSHNETSDK_CreateThirdPushStream(ref pGbinfo);
                if (m_GbStreamId != 0)
                {
                    InsertLogMessage("本地文件实时推流id=" + m_GbStreamId + "\n");
                }



            }

        }
        //停止推流的点击事件
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (IPGBPUSHNETSDK.Instance.NETIPGBPUSHNETSDK_DelOnePushStream(m_GbStreamId) == 0)
            {
                InsertLogMessage("停止推流......\n");
                SetEnableSendGb(true);
            }

        }
    }
}
