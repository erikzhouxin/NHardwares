using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 康美音柱源提供程序调用方式
    /// </summary>
    public class IPGBNET
    {
        private static Dictionary<Delegate, Delegate> funcDic = new Dictionary<Delegate, Delegate>();
        private static IPGBNET s_IPGBNET;
        private static object s_lock = new object();
        private static object s_funcLock = new object();
        /// <summary>
        /// 单例
        /// </summary>
        public static IPGBNET Instance
        {
            get
            {
                if (null == s_IPGBNET)
                {
                    lock (s_lock)
                    {
                        if (null == s_IPGBNET)
                        {
                            s_IPGBNET = new IPGBNET();
                        }
                    }
                }
                return s_IPGBNET;
            }
        }
        #region // IPGBNET内部委托
        /**
           * 登录状态回调函数原形
           * @param  UserId              (out)   用户ID
           * @param  ISConn              (out)   连接或断开  (1:连接,0:断开)
           * @param  lpUserInfo          (out)   当连接成功时输出用户信息    
           * @param  dwuser              (out)   用户类指针
           * @return   
        **/
        public delegate void NETfConnectOrDis(int UserId, byte ISConn, NETAVHSDK_USERINFO lpUserInfo, long dwUser);
        /**
           * 单个终端状态回调函数原形
           * @param  UserId              (out)   用户ID
           * @param  lpTmInfo            (out)   单个终端状态信息
           * @param  dwuser              (out)   用户类指针
           * @return   
        **/
        public delegate void NETfTerminalSta(int UserId, NETAVHSDK_TMINFO lpTmInfo, long dwUser);
        /**
           * 批量终端状态回调函数原形
           * @param  UserId              (out)   用户ID
           * @param  lpTmInfo            (out)   批量终端状态信息
           * @param  dwuser              (out)   用户类指针
           * @return   
        **/
        public delegate void NETfBatchTerminalSta(int UserId, NETAVHSDK_CALLBACKTMINFO lpTmInfo, long dwUser);
        /**
           * 编码类型终端状态回调函数原形
           * @param  UserId              (out)   用户ID
           * @param  lpTmInfo            (out)   单个终端状态信息
           * @param  dwuser              (out)   用户类指针
           * @return   
        **/
        public delegate void NETfEncTerminalSta(int UserId, NETAVHSDK_ENCTMINFO lpTmInfo, long dwUser);
        /**
           * 广播流状态回调函数原形
           * @param  UserId              (out)   用户ID
           * @param  StreamId            (out)   流ID
           * @param  StreamSta           (out)   流状态
           * @param  dwuser              (out)   用户类指针
           * @return   
        **/
        public delegate void NETfGBStreamSta(int UserId, int StreamId, int StreamSta, long dwUser);
        /**
           * 消防状态回调函数原形
           * @param  UserId              (out)   用户ID
           * @param  lpFireInfo          (out)   触发的消防信息
           * @param  dwuser              (out)   用户类指针
           * @return   
        **/
        public delegate void NETfFireSta(int UserId, NETAVHSDK_FIREINFO lpFireInfo, long dwUser);
        #endregion
        private IIPGBNETSdkProxy _proxy;
        /// <summary>
        /// 构造
        /// </summary>
        public IPGBNET() : this(false) { }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="isBase"></param>
        public IPGBNET(bool isBase)
        {
            _proxy = IPGBNETSdk.Create(isBase);
        }
        /// <summary>
        /// 设置登录状态回调
        /// </summary>
        /// <param name="LogCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetLogCallBack(NETfConnectOrDis LogCallBack, long dwUser)
        {
            var func = GetConvertFunc(LogCallBack, () => new SDKfConnectStatus((iUserId, iISConn, ilpUserInfo, idwUser) => LogCallBack.Invoke(iUserId, iISConn, ilpUserInfo, idwUser)));
            _proxy.IPGBNETSDK_SetConnStatusCallBack(func, dwUser);
        }

        public void NETIPGBNETSDK_SetTerminalStaCallBack(NETfTerminalSta TerminalStaCallBack, long dwUser)
        {
            var func = GetConvertFunc(TerminalStaCallBack, () => new SDKfTerminalStatus((iUserId, ilpTmInfo, idwUser) => TerminalStaCallBack.Invoke(iUserId, ilpTmInfo, idwUser)));
            _proxy.IPGBNETSDK_SetTerminalStatusCallBack(func, dwUser);
        }

        public void NETIPGBNETSDK_SetBatchTerminalStaCallBack(NETfBatchTerminalSta BatchTerminalStaCallBack, long dwUser)
        {
            var func = GetConvertFunc(BatchTerminalStaCallBack, () => new SDKfBatchTerminalStatus((iUserId, ilpTmInfo, idwUser) => BatchTerminalStaCallBack.Invoke(iUserId, ilpTmInfo, idwUser)));
            _proxy.IPGBNETSDK_SetBatchTerminalStatusCallBack(func, dwUser);
        }

        public void NETIPGBNETSDK_SetEncTerminalStaCallBack(NETfEncTerminalSta EncTerminalStaCallBack, long dwUser)
        {
            var func = GetConvertFunc(EncTerminalStaCallBack, () => new SDKfEncTerminalStatus((iUserId, ilpTmInfo, idwUser) => EncTerminalStaCallBack.Invoke(iUserId, ilpTmInfo, idwUser)));
            _proxy.IPGBNETSDK_SetEncTerminalStatusCallBack(func, dwUser);
        }

        public void NETIPGBNETSDK_SetGBStreamStaCallBack(NETfGBStreamSta GBStreamStaCallBack, long dwUser)
        {
            var func = GetConvertFunc(GBStreamStaCallBack, () => new SDKfGbStreamStatus((iUserId, iStreamId, iStreamSta, idwUser) => GBStreamStaCallBack.Invoke(iUserId, iStreamId, iStreamSta, idwUser)));
            _proxy.IPGBNETSDK_SetGbStreamStatusCallBack(func, dwUser);
        }

        public void NETIPGBNETSDK_SetFireStaCallBack(NETfFireSta FireStaCallBack, long dwUser)
        {
            var func = GetConvertFunc(FireStaCallBack, () => new SDKfFireSta((iUserId, iFirInfo, idwUser) => FireStaCallBack.Invoke(iUserId, iFirInfo, idwUser)));
            _proxy.IPGBNETSDK_SetFireStaCallBack(func, dwUser);
        }

        public ushort NETIPGBNETSDK_Init(int port)
        {
            return (ushort)_proxy.IPGBNETSDK_Init((ushort)port);
        }

        public ushort NETIPGBNETSDK_GetSdkVer()
        {
            return (ushort)_proxy.IPGBNETSDK_GetSdkVer();
        }

        public void NETIPGBNETSDK_Cleanup()
        {
            _proxy.IPGBNETSDK_Cleanup();
        }

        public ushort NETIPGBNETSDK_LogIn(NETAVHSDK_LOGSERVER lpSer, ref NETAVHSDK_USERINFO lpUser)
        {
            IPGBSDK_LOGSERVER ipgbsdk_LOGSERVER = (IPGBSDK_LOGSERVER)lpSer;
            int num = _proxy.IPGBNETSDK_LogIn(ipgbsdk_LOGSERVER);
            if (num > 0)
            {
                return NETIPGBNETSDK_GetConnStatusInfo(num, ref lpUser);
            }
            return (ushort)num;
        }

        public void NETIPGBNETSDK_LogOut(int user_id)
        {
            _proxy.IPGBNETSDK_LogOut((ushort)user_id);
        }

        public ushort NETIPGBNETSDK_GetConnStatusInfo(int user_id, ref NETAVHSDK_USERINFO lpUserInfo)
        {
            IPGBSDK_USERINFO ipgbsdk_USERINFO = (IPGBSDK_USERINFO)lpUserInfo;
            int num = (int)_proxy.IPGBNETSDK_GetConnStatusInfo((ushort)user_id, out ipgbsdk_USERINFO);
            lpUserInfo.SetModel(ipgbsdk_USERINFO);
            return (ushort)num;
        }

        public ushort NETIPGBNETSDK_GetOneSerFileInfo(int user_id, ref NETAVHSDK_ONEFILEINFO fdir, [MarshalAs(UnmanagedType.U1)] bool ISFirst)
        {
            IPGBSDK_SER_ONEFILEINFO ipgbsdk_SER_ONEFILEINFO;
            int num = _proxy.IPGBNETSDK_GetOneSerFileInfo((ushort)user_id, out ipgbsdk_SER_ONEFILEINFO, ISFirst);
            fdir.SetModel(ipgbsdk_SER_ONEFILEINFO);
            return (ushort)num;
        }

        public string[] NETIPGBNETSDK_GetSysSoundCardInfo(ref NETAVHSDK_SOUNDCARDINFO target)
        {
            IPGBSDK_SOUNDCARDINFO ipgbsdk_SOUNDCARDINFO;
            _proxy.IPGBNETSDK_GetSysSoundCardINFO(out ipgbsdk_SOUNDCARDINFO);
            return ipgbsdk_SOUNDCARDINFO.SOUNDNODES?.Select(s => s.CapMixName).ToArray();
        }

        public void NETIPGBNETSDK_SetSysSoundCardMix(string cap_mix_name, int set_type, int mval)
        {
            _proxy.IPGBNETSDK_SetSysSoundCardMix(cap_mix_name, (byte)set_type, (ushort)mval);
        }

        public ushort NETIPGBNETSDK_CreateSerFileGbStream(int user_id, ref NETAVHSDK_GBSERFILEINFO pGbinfo)
        {
            IPGBSDK_GBSERFILEINFO ipgbsdk_GBSERFILEINFO = (IPGBSDK_GBSERFILEINFO)pGbinfo;
            var res = (ushort)_proxy.IPGBNETSDK_CreateSerFileGbStream((ushort)user_id, ipgbsdk_GBSERFILEINFO);
            pGbinfo.SetModel(ipgbsdk_GBSERFILEINFO);
            return res;
        }

        public ushort NETIPGBNETSDK_CreateLcaFileGbStream(int user_id, ref NETAVHSDK_GBLCAFILEINFO pGbinfo)
        {
            IPGBSDK_GBLCAFILEINFO ipgbsdk_GBLCAFILEINFO = (IPGBSDK_GBLCAFILEINFO)pGbinfo;
            var res = _proxy.IPGBNETSDK_CreateLcaFileGbStream((ushort)user_id, ipgbsdk_GBLCAFILEINFO);
            pGbinfo.SetModel(ipgbsdk_GBLCAFILEINFO);
            return (ushort)res;
        }

        public ushort NETIPGBNETSDK_CreateTextGbStream(int user_id, ref NETAVHSDK_GBTEXTINFO pGbinfo)
        {
            IPGBSDK_GBTEXTINFO ipgbsdk_GBTEXTINFO = (IPGBSDK_GBTEXTINFO)pGbinfo;
            var res = _proxy.IPGBNETSDK_CreateTextGbStream((ushort)user_id, ipgbsdk_GBTEXTINFO);
            pGbinfo.SetModel(ipgbsdk_GBTEXTINFO);
            return (ushort)res;
        }

        public ushort NETIPGBNETSDK_CreateTerminalCbStream(int user_id, ref NETAVHSDK_GBTMCBINFO pGbinfo)
        {
            IPGBSDK_GBTMCBINFO ipgbsdk_GBTMCBINFO = (IPGBSDK_GBTMCBINFO)pGbinfo;
            var res = _proxy.IPGBNETSDK_CreateTerminalCbStream((ushort)user_id, ipgbsdk_GBTMCBINFO);
            pGbinfo.SetModel(ipgbsdk_GBTMCBINFO);
            return (ushort)res;
        }

        public ushort NETIPGBNETSDK_CreateSoundCarSrcChannel(ref NETAVHSDK_SoundCarSrcINFO pGbinfo)
        {
            IPGBSDK_SoundCarSrcINFO ipgbsdk_SoundCarSrcINFO = (IPGBSDK_SoundCarSrcINFO)pGbinfo;
            var res = _proxy.IPGBNETSDK_CreateSoundCarSrcChannel(ipgbsdk_SoundCarSrcINFO);
            pGbinfo.SetModel(ipgbsdk_SoundCarSrcINFO);
            return (ushort)res;
        }

        public ushort NETIPGBNETSDK_CreateEncTerminalCbStream(int user_id, ref NETAVHSDK_GBENCTMCBINFO pGbinfo)
        {
            IPGBSDK_GBENCTMCBINFO ipgbsdk_GBENCTMCBINFO = (IPGBSDK_GBENCTMCBINFO)pGbinfo;
            var res = _proxy.IPGBNETSDK_CreateEncTerminalCbStream((ushort)user_id, ipgbsdk_GBENCTMCBINFO);
            pGbinfo.SetModel(ipgbsdk_GBENCTMCBINFO);
            return (ushort)res;
        }

        public ushort NETIPGBNETSDK_CreateSoundCarGbStream(int user_id, ref NETAVHSDK_GBSoundCarINFO pGbinfo)
        {
            IPGBSDK_GBSoundCarINFO ipgbsdk_GBSoundCarINFO = (IPGBSDK_GBSoundCarINFO)pGbinfo;
            var res = _proxy.IPGBNETSDK_CreateSoundCarGbStream((ushort)user_id, ipgbsdk_GBSoundCarINFO);
            pGbinfo.SetModel(ipgbsdk_GBSoundCarINFO);
            return (ushort)res;
        }

        public ushort NETIPGBNETSDK_CreateThirdRealSrcChannel(ref NETAVHSDK_ThirdRealSrcINFO pGbinfo)
        {
            IPGBSDK_ThirdRealSrcINFO ipgbsdk_ThirdRealSrcINFO = (IPGBSDK_ThirdRealSrcINFO)pGbinfo;
            int result = _proxy.IPGBNETSDK_CreateThirdRealSrcChannel(ipgbsdk_ThirdRealSrcINFO, out string outdesb);
            pGbinfo.buf = outdesb;
            return (ushort)result;
        }

        public ushort NETIPGBNETSDK_FillDataToThirdRealSrcChannel(int aSrcId, string buf, int len)
        {
            return (ushort)_proxy.IPGBNETSDK_FillDataToThirdRealSrcChannel((ushort)aSrcId, buf, len);
        }

        public ushort NETIPGBNETSDK_CreateThirdRealAudioGbStream(int user_id, ref NETAVHSDK_GBTHIRDREALAUDIOINFO pGbinfo)
        {
            IPGBSDK_GBTHIRDREALAUDIOINFO ipgbsdk_GBTHIRDREALAUDIOINFO = (IPGBSDK_GBTHIRDREALAUDIOINFO)pGbinfo;
            var res = _proxy.IPGBNETSDK_CreateThirdRealAudioGbStream((ushort)user_id, ipgbsdk_GBTHIRDREALAUDIOINFO);
            pGbinfo.SetModel(ipgbsdk_GBTHIRDREALAUDIOINFO);
            return (ushort)res;
        }

        public ushort NETIPGBNETSDK_DelOneAudioSrcChannel(int aSrcId)
        {
            return (ushort)_proxy.IPGBNETSDK_DelOneAudioSrcChannel((ushort)aSrcId);
        }

        public ushort NETIPGBNETSDK_DelOneStream(int user_id, int stream_id)
        {
            return (ushort)_proxy.IPGBNETSDK_DelOneStream((ushort)user_id, (ushort)stream_id);
        }

        public ushort NETIPGBNETSDK_SetTmOutVol(int user_id, ref NETAVHSDK_SET_TMVOL pVol)
        {
            IPGBSDK_SET_TMVOL ipgbsdk_SET_TMVOL = (IPGBSDK_SET_TMVOL)pVol;
            var res = _proxy.IPGBNETSDK_SetTmOutVol((ushort)user_id, ipgbsdk_SET_TMVOL);
            pVol.SetModel(ipgbsdk_SET_TMVOL);
            return (ushort)res;
        }
        /// <summary>
        /// 触发第三方消防系统接口信号   (需要用户权限为18级)
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pVol"></param>
        /// <param name="pinType"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_ThreeFireArm(int user_id, ref NETAVHSDK_THREEFIRINFO pVol, byte pinType)
        {
            IPGBSDK_THREEFIRINFO threeFirInfo = (IPGBSDK_THREEFIRINFO)pVol;
            var res = _proxy.IPGBNETSDK_ThreeFireArm((ushort)user_id, threeFirInfo, pinType);
            pVol.SetModel(threeFirInfo);
            return (ushort)res;
        }
        /// <summary>
        /// 分析本地MP3文件信息
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="mp3FileInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetMp3FileInfo(string file_path, ref NETAVHSDK_LCA_MP3INFO mp3FileInfo)
        {
            var res = _proxy.IPGBNETSDK_GetMp3FileInfo(file_path, out IPGBSDK_LCA_MP3INFO pMp3Info);
            mp3FileInfo.SetModel(pMp3Info);
            return (ushort)res;
        }
        /// <summary>
        /// 控制终端断开呼叫对讲或接通呼叫对讲
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="tm_id"></param>
        /// <param name="ctlType"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CtrlAnyTmForCall(int user_id, int tm_id, byte ctlType)
        {
            return (ushort)_proxy.IPGBNETSDK_CtrlAnyTmTalkStatus((ushort)user_id, (ushort)tm_id, ctlType);
        }
        /// <summary>
        /// 控制两个终端建立对讲(终端只能在一个服务器节点内)
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="main_tmid"></param>
        /// <param name="other_tmid"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CtrlAnyTmForCall(int user_id, uint main_tmid, int other_tmid)
        {
            return (ushort)_proxy.IPGBNETSDK_CtrlAnyTmForCall((uint)user_id, main_tmid, (uint)other_tmid);
        }
        internal static TR GetConvertFunc<TM, TR>(TM callback, Func<TR> create)
            where TM : Delegate
            where TR : Delegate
        {
            if (!funcDic.TryGetValue(callback, out var func))
            {
                lock (s_funcLock)
                {
                    if (!funcDic.TryGetValue(callback, out func))
                    {
                        funcDic[callback] = create();
                    }
                }
            }
            return (TR)func;
        }
        public ushort NETIPGBNETSDK_GetUserFqInfo(int user_id, ref NETAVHSDK_USERFQINFO pFqInfo)
        {
            IPGBSDK_USERFQINFO ipgbsdk_USERFQINFO;
            var num = _proxy.IPGBNETSDK_GetUserFqInfo((ushort)user_id, out ipgbsdk_USERFQINFO);
            pFqInfo.SetModel(ipgbsdk_USERFQINFO);
            return (ushort)num;
        }
    }
}