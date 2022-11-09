using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Data.KangMeiIPGBSDK;

namespace TestIPGBNET
{
    public partial class TestIPGBNETForm : Form
    {
        // 定义用户对象
        private NETAVHSDK_USERINFO m_us = new NETAVHSDK_USERINFO();
        Int32 m_UserId; //当前用户ID
        Int32 m_GbStreamId; //当前广播流包柄
        IntPtr handler;

        #region 回调函数
        //-----------回调函数区域---------------

        //登录回调函数
        void connectOrDis(Int32 user_id, Byte is_con, NETAVHSDK_USERINFO user_info, Int64 dwUser)
        {

            TestIPGBNETForm thisForm = Form.FromHandle((IntPtr)dwUser) as TestIPGBNETForm;
            thisForm.InsertLogMessage("用户登录回调开始......\n");
            if (is_con == 0)
            {
                thisForm.InsertLogMessage("断开与服务器的连接......\n");

                thisForm.InitButtonsEnabledStatus();
            }
            else
            {
                thisForm.SetEnableLogin(true);

            }
            //同步执行用户数据
            synchronizeUserData(user_info);
            //同步执行同步终端数据
            synchronizeTerminallData(user_info);

            thisForm.InsertLogMessage("用户登录回调结束......\n");
        }



        //终端状态批量回调
        void terminalSta(Int32 UserId, NETAVHSDK_TMINFO tm_info, Int64 dwUser)
        {


            TestIPGBNETForm thisForm = Form.FromHandle((IntPtr)dwUser) as TestIPGBNETForm;
            // thisForm.InsertTerminalLogMessage("终端状态回调......\n");

            thisForm.InsertTerminalLogMessage("终端名称:" + tm_info.TmName + "  " + "终端机号:" + tm_info.TmNo + "  " + "终端IP:" + tm_info.Tmip + "  " + "终端状态:" + getTerminalContent(tm_info.TmSta) + "  " + "终端音量:" + tm_info.TmVol + "\n");
            // thisForm.InsertTerminalLogMessage("终端状态批回调结束......\n");
        }

        //终端状态批量回调
        void terminalStaBatch(Int32 UserId, NETAVHSDK_CALLBACKTMINFO batch_tm_info, Int64 dwUser)
        {


            TestIPGBNETForm thisForm = Form.FromHandle((IntPtr)dwUser) as TestIPGBNETForm;
            // thisForm.InsertTerminalLogMessage("终端状态批量回调......\n");

            if (batch_tm_info == null || batch_tm_info.m_oneTm == null || batch_tm_info.m_oneTm.Length == 0)
            {
                return;
            }

            foreach (NETAVHSDK_TMINFO tm_info in batch_tm_info.m_oneTm)
            {
                thisForm.InsertTerminalLogMessage("终端名称:" + tm_info.TmName + "  " + "终端机号:" + tm_info.TmNo + "  " + "终端IP:" + tm_info.Tmip + "  " + "终端状态:" + getTerminalContent(tm_info.TmSta) + "  " + "终端音量:" + tm_info.TmVol + "\n");
            }
            //  thisForm.InsertTerminalLogMessage("终端状态批量回调结束......\n");
        }

        //广播流状态回调
        void gbStreamSta(Int32 user_id, Int32 stream_id, Int32 stream_sta, Int64 dwUser)
        {


            TestIPGBNETForm thisForm = Form.FromHandle((IntPtr)dwUser) as TestIPGBNETForm;
            // thisForm.InsertLogMessage("广播流状态回调开始......\n");

            if (stream_id != 0)   //为新创建的广播，服务器回应是否创建成功
            {
                if (stream_sta == 0)
                {
                    thisForm.SetEnableSendGb(false);

                    thisForm.InsertLogMessage("广播创建成功......\n");
                }
                else
                {
                    thisForm.InsertLogMessage("广播创建失败......\n");
                }
            }
            else    //此广播前面已创建成功，但此广播已停止
            {
                thisForm.SetEnableSendGb(true);

                thisForm.InsertLogMessage("广播已停止......\n");
            }
            // thisForm.InsertLogMessage("广播流状态回调结束......\n");

        }

        //消防状态回调
        void fireSta(Int32 UserId, NETAVHSDK_FIREINFO lpFireInfo, Int64 dwUser)
        {


            TestIPGBNETForm thisForm = Form.FromHandle((IntPtr)dwUser) as TestIPGBNETForm;

            // thisForm.InsertLogMessage("消防状态回调回调开始......\n");

            // thisForm.InsertLogMessage("消防状态回调回调结束......\n");

        }


        //-----------回调函数结束---------------

        //同步用户数据
        public void synchronizeUserData(NETAVHSDK_USERINFO user_info)
        {
            this.txtUserId.Text = Convert.ToString(user_info.UserID);
            //清空业务日志
            this.txtArea.Text = "";
            this.txtArea.Text = "登录成功......\n";
            this.InsertLogMessage("当前用户终端个数" + user_info.m_OneTm.Length + "......\n");
        }

        //同步终端数据
        public void synchronizeTerminallData(NETAVHSDK_USERINFO user_info)
        {
            //清空终端日志
            this.txtTerminalArea.Text = "";
            this.InsertTerminalLogMessage("=========用户登录同步终端信息开始=========" + "\n");
            foreach (NETAVHSDK_TMINFO tm_info in user_info.m_OneTm)
            {
                this.InsertTerminalLogMessage("终端名称:" + tm_info.TmName + "  " + "终端机号:" + tm_info.TmNo + "  " + "终端IP:" + tm_info.Tmip + "  " + "终端状态:" + getTerminalContent(tm_info.TmSta) + "  " + "终端音量:" + tm_info.TmVol + "\n");
            }

            this.InsertTerminalLogMessage("=========用户登录同步终端信息结束=========" + "\n");
        }

        //获取终端状态
        public String getTerminalContent(NETEM_TMSTA_TYPE enm)
        {
            string result = "";
            switch (enm)
            {
                case NETEM_TMSTA_TYPE.TMSTA_STA1:
                    result = "空闲";
                    break;
                case NETEM_TMSTA_TYPE.TMSTA_STA2:
                    result = "点播";
                    break;
                case NETEM_TMSTA_TYPE.TMSTA_STA3:
                    result = "接收广播";
                    break;
                case NETEM_TMSTA_TYPE.TMSTA_STA4:
                    result = "终端本身发起采播或文件广播";
                    break;
                case NETEM_TMSTA_TYPE.TMSTA_STA5:
                    result = "正在对讲";
                    break;
                case NETEM_TMSTA_TYPE.TMSTA_STA6:
                    result = "主叫状态";
                    break;
                case NETEM_TMSTA_TYPE.TMSTA_STA7:
                    result = "被叫状态";
                    break;

                default:
                    result = "未知";
                    break;

            }
            return result;
        }
        #endregion


        #region 按钮控制函数

        // 设置初始化状态
        void InitButtonsEnabledStatus()
        {
            this.btnLogin.Enabled = true;
            this.btnLogOut.Enabled = false;

            this.btnFileGB.Enabled = false;
            this.btnSoundCardGB.Enabled = false;
            this.btnTerminalGB.Enabled = false;
            this.btnTTSGB.Enabled = false;
            this.btnLocalFileGB.Enabled = false;
            this.btnEncTerminalGB.Enabled = false;
            this.btnThridSteamGB.Enabled = false;
            this.btnStopGB.Enabled = false;
            this.btnTerminalDJ.Enabled = false;
            this.btnControllerTerminalDJ.Enabled = false;
            this.btnStopDJ.Enabled = false;
            this.btnTiggerXF.Enabled = false;
            this.btnStopXF.Enabled = false;
            // this.btnTerminalOutVol.Enabled = false;

        }

        // 设置登录成功状态
        void SetEnableLogin(bool enable)
        {
            this.btnLogin.Enabled = !enable;
            this.btnLogOut.Enabled = enable;

            this.btnFileGB.Enabled = enable;
            this.btnSoundCardGB.Enabled = enable;
            this.btnTerminalGB.Enabled = enable;
            this.btnTTSGB.Enabled = enable;
            this.btnLocalFileGB.Enabled = enable;
            this.btnEncTerminalGB.Enabled = enable;
            this.btnThridSteamGB.Enabled = enable;
            this.btnStopGB.Enabled = !enable;
            this.btnTerminalDJ.Enabled = enable;
            this.btnControllerTerminalDJ.Enabled = enable;
            this.btnStopDJ.Enabled = !enable;
            this.btnTiggerXF.Enabled = enable;
            this.btnStopXF.Enabled = !enable;

        }

        //设置广播停止状态
        void SetEnableSendGb(bool enable)
        {
            this.btnFileGB.Enabled = enable;
            this.btnSoundCardGB.Enabled = enable;
            this.btnTerminalGB.Enabled = enable;
            this.btnTTSGB.Enabled = enable;
            this.btnLocalFileGB.Enabled = enable;
            this.btnEncTerminalGB.Enabled = enable;
            this.btnThridSteamGB.Enabled = enable;
            this.btnStopGB.Enabled = !enable;
            this.btnTerminalDJ.Enabled = enable;
            this.btnControllerTerminalDJ.Enabled = enable;
            this.btnStopDJ.Enabled = false;
            this.btnTiggerXF.Enabled = enable;
            this.btnStopXF.Enabled = false;
        }

        // 设置对讲停止状态
        void SetEnableSendDJ(bool enable)
        {
            this.btnFileGB.Enabled = enable;
            this.btnSoundCardGB.Enabled = enable;
            this.btnTerminalGB.Enabled = enable;
            this.btnTTSGB.Enabled = enable;
            this.btnLocalFileGB.Enabled = enable;
            this.btnEncTerminalGB.Enabled = enable;
            this.btnThridSteamGB.Enabled = enable;
            this.btnStopGB.Enabled = false;
            this.btnTerminalDJ.Enabled = enable;
            this.btnControllerTerminalDJ.Enabled = enable;
            this.btnStopDJ.Enabled = !enable;
            this.btnTiggerXF.Enabled = enable;
            this.btnStopXF.Enabled = false;
        }

        // 设置消防停止状态
        void SetEnableSendXF(bool enable)
        {
            this.btnFileGB.Enabled = enable;
            this.btnSoundCardGB.Enabled = enable;
            this.btnTerminalGB.Enabled = enable;
            this.btnTTSGB.Enabled = enable;
            this.btnLocalFileGB.Enabled = enable;
            this.btnEncTerminalGB.Enabled = enable;
            this.btnThridSteamGB.Enabled = enable;
            this.btnStopGB.Enabled = false;
            this.btnTerminalDJ.Enabled = enable;
            this.btnControllerTerminalDJ.Enabled = enable;
            this.btnStopDJ.Enabled = false;
            this.btnTiggerXF.Enabled = enable;
            this.btnStopXF.Enabled = !enable;
        }
        #endregion


        // 构造函数初始化
        public TestIPGBNETForm()
        {
            InitializeComponent();
        }

        // 窗体加载程序
        private void TestIPGBNETForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            this.txtUserName.Text = "108";

            this.txtPassWord.Text = "123";

            this.txtIp.Text = "192.168.1.9";

            this.txtPort.Text = "3960";

            this.txtTagertTerminalId.Text = "108";

            this.txtSourceTerminalId.Text = "108";

            this.txtOutVol.Text = "50";

            this.txtThridSteamPort.Text = "2893";

            this.txtThridSteamType.Text = "1";

            // 初始化按钮状态
            InitButtonsEnabledStatus();

            //初始化SDK
            IPGBNET.Instance.NETIPGBNETSDK_Init(Convert.ToInt32(txtThridSteamPort.Text));
            //IPGBNET.Instance.NETIPGBNETSDK_SetLogCallBack(connectOrDis, this.Handle.ToInt64());                    //登录回调
            ////IPGBNET.Instance.NETIPGBNETSDK_SetTerminalStaCallBack(terminalSta, this.Handle.ToInt64());	 //终端状态回调
            //IPGBNET.Instance.NETIPGBNETSDK_SetBatchTerminalStaCallBack(terminalStaBatch, this.Handle.ToInt64());	 //终端状态批量回调
            //IPGBNET.Instance.NETIPGBNETSDK_SetGBStreamStaCallBack(gbStreamSta, this.Handle.ToInt64());             //广播流状态回调
            //IPGBNET.Instance.NETIPGBNETSDK_SetFireStaCallBack(fireSta, this.Handle.ToInt64());                     //消防状态回调
            InsertLogMessage("SDK初始化......");

        }
        // 窗体关闭
        private void TestIPGBNETForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IPGBNET.Instance.NETIPGBNETSDK_Cleanup();

        }


        // 显示业务日志消息函数
        private void InsertLogMessage(string sLog)
        {
            string sMsg = string.Format("{0}\r\n", sLog);
            txtArea.Text = txtArea.Text.Insert(0, sMsg);
        }

        // 显示终端日志消息函数
        private void InsertTerminalLogMessage(string sLog)
        {
            string sMsg = string.Format("{0}\r\n", sLog);
            txtTerminalArea.Text = txtTerminalArea.Text.Insert(0, sMsg);
        }


        //登录点击事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            NETAVHSDK_LOGSERVER Logs = new NETAVHSDK_LOGSERVER();

            Logs.LogType = 0;      //IP登录

            Logs.SIp = txtIp.Text;//服务器IP

            Logs.Sdomain = "";     //域名

            Logs.SCmdport = (ushort)Convert.ToInt32(txtPort.Text); //服务器端口

            Logs.UserName = txtUserName.Text; //用户名称

            Logs.UPass = txtPassWord.Text; //用户密码

            int res = IPGBNET.Instance.NETIPGBNETSDK_LogIn(Logs, ref m_us);
            if (res > 0)
            {
                m_GbStreamId = 0;
                m_UserId = res;
                this.txtUserId.Text = Convert.ToString(m_UserId);
                InsertLogMessage("登陆成功......");
                this.SetEnableLogin(true);
            }
            else
            {
                InsertLogMessage("登陆失败......");
            }

        }

        //登出事件
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //当前用户ID
            int user_id = Convert.ToInt32(txtUserId.Text);
            IPGBNET.Instance.NETIPGBNETSDK_LogOut(user_id);
            InsertLogMessage("登出成功......");
            InitButtonsEnabledStatus();
        }

        // 服务器文件广播点击事件
        private void btnFileGB_Click(object sender, EventArgs e)
        {
            //当前用户ID
            int user_id = Convert.ToInt32(txtUserId.Text);
            //获取服务器文件资源
            NETAVHSDK_ONEFILEINFO file = new NETAVHSDK_ONEFILEINFO();
            if (IPGBNET.Instance.NETIPGBNETSDK_GetOneSerFileInfo(user_id, ref file, true) == 0)
            {

                //构造请求对象
                NETAVHSDK_GBSERFILEINFO pGbinfo = new NETAVHSDK_GBSERFILEINFO();
                pGbinfo.GBlevel = 18;
                pGbinfo.GBVol = 75;

                //目标终端
                String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
                pGbinfo.TmID = new UInt16[1];
                pGbinfo.TmID[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端
                pGbinfo.TmCout = 1;

                pGbinfo.PlayLoop = 1;
                pGbinfo.PlaySec = 0;
                pGbinfo.FileCout = 1;

                NETAVHSDK_ONEFILEINFO[] files = new NETAVHSDK_ONEFILEINFO[1];
                files[0] = file;
                pGbinfo.m_OneFile = files;

                //创建服务器文件广播
                m_GbStreamId = IPGBNET.Instance.NETIPGBNETSDK_CreateSerFileGbStream(user_id, ref pGbinfo);

                if (m_GbStreamId > 0)
                {

                    this.SetEnableSendGb(false);
                    InsertLogMessage("服务器文件广播流id=" + m_GbStreamId + "\n");
                    return;
                }
                else
                {
                    InsertLogMessage("广播创建失败......\n");
                }


            }
        }

        // 声卡广播点击事件
        private void btnSoundCardGB_Click(object sender, EventArgs e)
        {
            NETAVHSDK_SOUNDCARDINFO cardPubInfo = new NETAVHSDK_SOUNDCARDINFO();
            //第1步 获取声卡信息
            String[] card_list = IPGBNET.Instance.NETIPGBNETSDK_GetSysSoundCardInfo(ref cardPubInfo);
            if (card_list != null && card_list.Length > 0)
            {
                String cardNo = card_list.Length > 1 ? card_list[1] : card_list[0];
                InsertLogMessage("当前的选择声卡......\n" + cardNo);

                //第2步 创建本地声卡采集编码源通道
                NETAVHSDK_SoundCarSrcINFO pSrcinfo = new NETAVHSDK_SoundCarSrcINFO();//混音接口音量
                pSrcinfo.EncType = 1; //编码类型
                pSrcinfo.SoundCarMixName = cardNo; //声卡采集混音接口名
                pSrcinfo.SoundCarMixVol = 80;   //声卡采集混音接口音量

                int audioSrcChId = IPGBNET.Instance.NETIPGBNETSDK_CreateSoundCarSrcChannel(ref pSrcinfo);

                //第3步 发送声卡广播请求
                //构造请求对象
                NETAVHSDK_GBSoundCarINFO pGbinfo = new NETAVHSDK_GBSoundCarINFO();
                pGbinfo.GBlevel =  18; //配置此广播的级别,（1-18 18为高级别，以区分此用户创建的所有广播流级别控制，高打断低，同级不可打断)
                pGbinfo.GBVol = 75; //接收终端音量
                pGbinfo.EncType = 1; //编码格式


                //目标终端
                String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
                pGbinfo.TmID = new UInt16[1];
                pGbinfo.TmID[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端
                pGbinfo.TmCout = 1;

                pGbinfo.PlaySec = 0; //暂不支持
                pGbinfo.AudioSrcChId = (ushort)audioSrcChId; //声卡音频采集编码源通道ID句柄
                //创建声卡广播
                m_GbStreamId = IPGBNET.Instance.NETIPGBNETSDK_CreateSoundCarGbStream(m_UserId, ref pGbinfo);
                if (m_GbStreamId > 0)
                {

                    this.SetEnableSendGb(false);
                    InsertLogMessage("声卡广播流id=" + m_GbStreamId + "\n");
                    return;
                }
            }
        }

        // 终端广播点击事件
        private void btnTerminalGB_Click(object sender, EventArgs e)
        {
            //构造请求对象
            NETAVHSDK_GBTMCBINFO pGbinfo = new NETAVHSDK_GBTMCBINFO();
            pGbinfo.GBlevel =  18; //配置此广播的级别,（1-18 18为高级别，以区分此用户创建的所有广播流级别控制，高打断低，同级不可打断)
            pGbinfo.GBVol = 75; //接收终端音量
            pGbinfo.CBVol = 21; //采播输入音量
            pGbinfo.EncType = 1; //编码格式

            //发起终端
            String str_tfSourceTerminal = txtSourceTerminalId.Text.ToString();
            ushort main_tmid = Convert.ToUInt16(str_tfSourceTerminal);
            pGbinfo.CbSrcTmNo = main_tmid;

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            pGbinfo.TmID = new UInt16[1];
            pGbinfo.TmID[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端
            pGbinfo.TmCout = 1;

            pGbinfo.PlaySec = 0; //暂不支持

            m_GbStreamId = IPGBNET.Instance.NETIPGBNETSDK_CreateTerminalCbStream(m_UserId, ref pGbinfo);

            if (m_GbStreamId > 0)
            {

                this.SetEnableSendGb(false);
                InsertLogMessage("终端广播流id=" + m_GbStreamId + "\n");
                return;
            }

        }

        // 文本广播点击事件
        private void btnTTSGB_Click(object sender, EventArgs e)
        {
            //构造请求对象
            NETAVHSDK_GBTEXTINFO pGbinfo = new NETAVHSDK_GBTEXTINFO();
            pGbinfo.GBlevel =  18; //配置此广播的级别,（1-18 18为高级别，以区分此用户创建的所有广播流级别控制，高打断低，同级不可打断)
            pGbinfo.GBVol = 75; //接收终端音量

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            pGbinfo.TmID = new UInt16[1];
            pGbinfo.TmID[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端
            pGbinfo.TmCout = 1;

            pGbinfo.PlaySec = 0; //暂不支持

            NETAVHSDK_TTSTEXTIINFO mText = new NETAVHSDK_TTSTEXTIINFO();
            mText.TTStype = 1;
            mText.TTSPlayCout = 6;
            mText.TEXT = "现在开始对IP网络广播系统，文本广播测试.";
            mText.TextLen = (ushort)mText.TEXT.Length;
            pGbinfo.m_TEXT = mText;

            //创建文本广播
            m_GbStreamId = IPGBNET.Instance.NETIPGBNETSDK_CreateTextGbStream(m_UserId, ref pGbinfo);
            if (m_GbStreamId != 0)
            {
                InsertLogMessage("文本广播广播流id=" + m_GbStreamId + "\n");
                return;
            }

        }

        // 本地文件广播点击事件
        private void btnLocalFileGB_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Title = "请选择文件路径";
            fd.Filter = "mp3文件|*.mp3";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string fileName = fd.FileName;
                InsertLogMessage("文本广播选择路径=" + fileName + "\n");


                //构造请求对象
                NETAVHSDK_GBLCAFILEINFO pGbinfo = new NETAVHSDK_GBLCAFILEINFO();
                pGbinfo.GBlevel = 18;
                pGbinfo.GBVol = 75;

                //目标终端
                String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
                pGbinfo.TmID = new UInt16[1];
                pGbinfo.TmID[0] = Convert.ToUInt16(str_tfTagerTerminal); //接收广播的终端ID数组,此处为ID为1的终端
                pGbinfo.TmCout = 1;

                pGbinfo.PlayLoop = 1;
                pGbinfo.PlaySec = 0;
                pGbinfo.FileCout = 1;

                NETAVHSDK_LCA_ONEFILEINFO f_inifo = new NETAVHSDK_LCA_ONEFILEINFO();
                f_inifo.FilePath = fileName;

                NETAVHSDK_LCA_ONEFILEINFO[] files = new NETAVHSDK_LCA_ONEFILEINFO[1];
                files[0] = f_inifo;
                pGbinfo.m_LcaOneFile = files;
                //创建本地文件广播
                m_GbStreamId = IPGBNET.Instance.NETIPGBNETSDK_CreateLcaFileGbStream(m_UserId, ref pGbinfo);

                if (m_GbStreamId > 0)
                {
                    InsertLogMessage("创建本地文件广播流id=" + m_GbStreamId + "\n");
                    return;
                }

            }

        }

        // 编码终端广播点击事件
        private void btnEncTerminalGB_Click(object sender, EventArgs e)
        {
            //构造请求对象
            NETAVHSDK_GBENCTMCBINFO pGbinfo = new NETAVHSDK_GBENCTMCBINFO();
            pGbinfo.GBlevel =  18; //配置此广播的级别,（1-18 18为高级别，以区分此用户创建的所有广播流级别控制，高打断低，同级不可打断)
            pGbinfo.GBVol = 75; //接收终端音量
            pGbinfo.CBVol = 21; //采播输入音量
            pGbinfo.EncType = 1; //编码格式

            //发起终端
            String str_tfSourceTerminal = txtSourceTerminalId.Text.ToString();
            ushort main_tmid = Convert.ToUInt16(str_tfSourceTerminal);
            pGbinfo.CbSrcTmNo = main_tmid;

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            pGbinfo.TmID = new UInt16[1];
            pGbinfo.TmID[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端
            pGbinfo.TmCout = 1;

            pGbinfo.PlaySec = 0; //暂不支持

            pGbinfo.POWType = 0;
            pGbinfo.POWVal = 1;

            m_GbStreamId = IPGBNET.Instance.NETIPGBNETSDK_CreateEncTerminalCbStream(m_UserId, ref pGbinfo);

            if (m_GbStreamId > 0)
            {
                InsertLogMessage("编码终端广播流id=" + m_GbStreamId + "\n");
                return;
            }

        }

        // 第三方实时流广播点击事件
        private void btnThridSteamGB_Click(object sender, EventArgs e)
        {
            //第1步 创建第三方实时流编码源通道
            NETAVHSDK_ThirdRealSrcINFO pSrcinfo = new NETAVHSDK_ThirdRealSrcINFO();//混音接口音量
            pSrcinfo.EncType = 1; //编码格式
            pSrcinfo.ADataInputType = 2;
            pSrcinfo.buf = "";

            //认证内容
            String buf = "";
            int audioSrcChId = IPGBNET.Instance.NETIPGBNETSDK_CreateThirdRealSrcChannel(ref pSrcinfo);
            if (audioSrcChId <= 0)
            {
                InsertLogMessage("创建第三方实时流编码源通道失败" + "\n");
                return;
            }
            txtThridSteamChannel.Text = Convert.ToString(audioSrcChId);
            txtThridSteamType.Text = "1";
            txtThridSteamContent.Text = pSrcinfo.buf;

            //构造请求对象
            NETAVHSDK_GBTHIRDREALAUDIOINFO pGbinfo = new NETAVHSDK_GBTHIRDREALAUDIOINFO();
            pGbinfo.GBlevel =  18; //配置此广播的级别,（1-18 18为高级别，以区分此用户创建的所有广播流级别控制，高打断低，同级不可打断)
            pGbinfo.GBVol = 75;   //接收终端音量
            pGbinfo.EncType = Convert.ToUInt16(txtThridSteamType.Text.ToString());


            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            pGbinfo.TmID = new UInt16[1];
            pGbinfo.TmID[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端
            pGbinfo.TmCout = 1;

            pGbinfo.PlaySec = 0; //暂不支持
            pGbinfo.AudioSrcChId = (ushort)audioSrcChId; //声卡音频采集编码源通道ID句柄
            m_GbStreamId = IPGBNET.Instance.NETIPGBNETSDK_CreateThirdRealAudioGbStream(m_UserId, ref pGbinfo);
            if (m_GbStreamId != 0)
            {
                InsertLogMessage("第三方实时流广播流id=" + m_GbStreamId + "\n");
                return;
            }

        }

        // 停止广播点击事件
        private void btnStopGB_Click(object sender, EventArgs e)
        {
            IPGBNET.Instance.NETIPGBNETSDK_DelOneStream(m_UserId, m_GbStreamId);
            this.SetEnableSendGb(true);
            InsertLogMessage("广播已停止......\n");

        }

        // 终端对讲点击事件
        private void btnTerminalDJ_Click(object sender, EventArgs e)
        {
            //发起终端
            String str_tfSourceTerminal = txtSourceTerminalId.Text.ToString();
            ushort main_tmid = Convert.ToUInt16(str_tfSourceTerminal);

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            ushort call_tmid = Convert.ToUInt16(str_tfTagerTerminal);

            //终端对讲
            int result = IPGBNET.Instance.NETIPGBNETSDK_CtrlAnyTmForCall(m_UserId, main_tmid, call_tmid);
            if (result == 0)
            {
                InsertLogMessage("终端对讲成功\n");
                SetEnableSendDJ(false);
            }

        }

        // 控制终端对讲点击事件
        private void btnControllerTerminalDJ_Click(object sender, EventArgs e)
        {
            //发起终端
            String str_tfSourceTerminal = txtSourceTerminalId.Text.ToString();
            ushort main_tmid = Convert.ToUInt16(str_tfSourceTerminal);

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            ushort call_tmid = Convert.ToUInt16(str_tfTagerTerminal);

            byte ctlType = 1;

            //控制绑定终端对讲
            int result = IPGBNET.Instance.NETIPGBNETSDK_CtrlAnyTmForCall(m_UserId, call_tmid, ctlType);
            if (result == 0)
            {
                InsertLogMessage("控制终端对讲成功\n");
                SetEnableSendDJ(false);
            }

        }

        // 停止对讲点击事件
        private void btnStopDJ_Click(object sender, EventArgs e)
        {
            //发起终端
            String str_tfSourceTerminal = txtSourceTerminalId.Text.ToString();
            ushort main_tmid = Convert.ToUInt16(str_tfSourceTerminal);

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            ushort call_tmid = Convert.ToUInt16(str_tfTagerTerminal);

            byte ctlType = 2;

            //控制绑定终端对讲
            int result = IPGBNET.Instance.NETIPGBNETSDK_CtrlAnyTmForCall(m_UserId, call_tmid, ctlType);
            if (result == 0)
            {
                InsertLogMessage("控制终端对讲成功\n");
                SetEnableSendDJ(true);
            }

        }

        // 消防报警点击事件
        private void btnTiggerXF_Click(object sender, EventArgs e)
        {
            NETAVHSDK_THREEFIRINFO pVol = new NETAVHSDK_THREEFIRINFO();
            pVol.PinCout = 1;

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            pVol.PinNO = new UInt16[1];
            pVol.PinNO[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端


            //触发类型
            byte pinType = 1;
            //触发第三方消防系统接口信号
            int result = IPGBNET.Instance.NETIPGBNETSDK_ThreeFireArm(m_UserId, ref pVol, pinType);
            if (result == 0)
            {
                InsertLogMessage("创建触发第三方消防系统接口信号\n");
                SetEnableSendXF(false);
            }
        }

        // 停止消防点击事件
        private void btnStopXF_Click(object sender, EventArgs e)
        {
            NETAVHSDK_THREEFIRINFO pVol = new NETAVHSDK_THREEFIRINFO();
            pVol.PinCout = 1;

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            pVol.PinNO = new UInt16[1];
            pVol.PinNO[0] = Convert.ToUInt16(str_tfTagerTerminal); ;//接收广播的终端ID数组,此处为ID为1的终端

            //触发类型
            byte pinType = 2;
            //触发第三方消防系统接口信号
            int result = IPGBNET.Instance.NETIPGBNETSDK_ThreeFireArm(m_UserId, ref pVol, pinType);
            if (result == 0)
            {
                InsertLogMessage("删除触发第三方消防系统接口信号");
                SetEnableSendXF(true);
            }

        }

        // 调节终端音量点击事件
        private void btnTerminalOutVol_Click(object sender, EventArgs e)
        {
            //构造请求对象
            NETAVHSDK_SET_TMVOL pVol = new NETAVHSDK_SET_TMVOL();

            //目标终端
            String str_tfTagerTerminal = this.txtTagertTerminalId.Text.ToString();
            pVol.TmId = new UInt16[1];
            pVol.TmId[0] = Convert.ToUInt16(str_tfTagerTerminal); //接收广播的终端ID数组,此处为ID为1的终端
            pVol.TmCout = 1;

            //终端音量
            String str_tfTerminalOutVol = this.txtOutVol.Text.ToString();
            pVol.TmVol = Convert.ToUInt16(str_tfTerminalOutVol);
            pVol.SetType = 2;

            //调节终端输出音量事件
            int result = IPGBNET.Instance.NETIPGBNETSDK_SetTmOutVol(m_UserId, ref pVol);
            InsertLogMessage($"调节终端输出音量{(result == 0 ? "成功" : "失败")} \n");
        }

        //获取用户分区
        private void userPartionBtn_Click(object sender, EventArgs e)
        {
            int user_id = Convert.ToInt32(txtUserId.Text);
            NETAVHSDK_USERFQINFO pFqInfo = new NETAVHSDK_USERFQINFO();
            int res = IPGBNET.Instance.NETIPGBNETSDK_GetUserFqInfo(user_id, ref pFqInfo);
            InsertLogMessage("用户分区个数:" + pFqInfo.FqCout);
            foreach (NETAVHSDK_ONEFQINFO fq in pFqInfo.m_OneFq)
            {
                String str = "分区名称:" + fq.FqName + "   " + "分区终端个数:" + fq.FqTmCout + "   ";
                StringBuilder s = new StringBuilder();
                if (fq.FqTmCout > 0)
                {
                    foreach (short tm in fq.FqTmNo)
                    {
                        s.Append("分区终端:" + tm + ",");
                    }
                    // s.Remove(s.Length - 1, s.Length);
                }
                InsertLogMessage(str + s.ToString());
            }

        }
    }
}
