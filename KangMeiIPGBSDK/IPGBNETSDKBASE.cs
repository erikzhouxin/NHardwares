using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 音箱调用SDK内容
    /// </summary>
    public class IPGBNETSDKBASE
    {
        private static readonly ConcurrentDictionary<string, Delegate> _proxyDic;
        private static object _locker;
        /// <summary>
        /// 单例
        /// </summary>
        public static IPGBNETSDKBASE Instance { get; }
        static IPGBNETSDKBASE()
        {
            IPGBNETSdk.Create();
            _locker = new object();
            _proxyDic = new ConcurrentDictionary<string, Delegate>();
            Instance = new IPGBNETSDKBASE();
        }
        /// <summary>
        /// 构造
        /// </summary>
        public IPGBNETSDKBASE() { }
        /// <summary>
        /// 设置登录状态回调
        /// </summary>
        /// <param name="LogCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetLogCallBack(SDKfConnectStatus LogCallBack, long dwUser)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_SetLogCallBack(LogCallBack, dwUser);
        }
        /// <summary>
        /// 设置终端状态回调
        /// </summary>
        /// <param name="TerminalStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetTerminalStaCallBack(SDKfTerminalStatus TerminalStaCallBack, long dwUser)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_SetTerminalStaCallBack(TerminalStaCallBack, dwUser);
        }
        /// <summary>
        /// 批量设置终端状态回调
        /// </summary>
        /// <param name="BatchTerminalStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetBatchTerminalStaCallBack(SDKfBatchTerminalStatus BatchTerminalStaCallBack, long dwUser)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_SetBatchTerminalStaCallBack(BatchTerminalStaCallBack, dwUser);
        }
        /// <summary>
        /// 设置ENC终端状态回调
        /// </summary>
        /// <param name="EncTerminalStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetEncTerminalStaCallBack(SDKfEncTerminalStatus EncTerminalStaCallBack, long dwUser)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_SetEncTerminalStaCallBack(EncTerminalStaCallBack, dwUser);
        }
        /// <summary>
        /// 设置广播流状态回调
        /// </summary>
        /// <param name="GBStreamStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetGBStreamStaCallBack(SDKfGbStreamStatus GBStreamStaCallBack, long dwUser)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_SetGBStreamStaCallBack(GBStreamStaCallBack, dwUser);
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="FireStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetFireStaCallBack(SDKfFireSta FireStaCallBack, long dwUser)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_SetFireStaCallBack(FireStaCallBack, dwUser);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_Init(int port)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_Init(port);
        }
        /// <summary>
        /// 获取版本SDK
        /// </summary>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetSdkVer()
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_GetSdkVer();
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void NETIPGBNETSDK_Cleanup()
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_Cleanup();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="lpSer"></param>
        /// <param name="lpUser"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_LogIn(NETAVHSDK_LOGSERVER lpSer, ref NETAVHSDK_USERINFO lpUser)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_LogIn(lpSer, ref lpUser);
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="user_id"></param>
        public void NETIPGBNETSDK_LogOut(int user_id)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_LogOut(user_id);
        }
        /// <summary>
        /// 获取连接状态信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="lpUserInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetConnStatusInfo(int user_id, ref NETAVHSDK_USERINFO lpUserInfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_GetConnStatusInfo(user_id, ref lpUserInfo);
        }
        /// <summary>
        /// 获取一个文件信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="fdir"></param>
        /// <param name="ISFirst"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetOneSerFileInfo(int user_id, ref NETAVHSDK_ONEFILEINFO fdir, [MarshalAs(UnmanagedType.U1)] bool ISFirst)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_GetOneSerFileInfo(user_id, ref fdir, ISFirst);
        }
        /// <summary>
        /// 获取系统声卡信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string[] NETIPGBNETSDK_GetSysSoundCardInfo(ref NETAVHSDK_SOUNDCARDINFO target)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_GetSysSoundCardInfo(ref target);
        }
        /// <summary>
        /// 获取声卡混合
        /// </summary>
        /// <param name="cap_mix_name"></param>
        /// <param name="set_type"></param>
        /// <param name="mval"></param>
        public void NETIPGBNETSDK_SetSysSoundCardMix(string cap_mix_name, int set_type, int mval)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            _proxy.NETIPGBNETSDK_SetSysSoundCardMix(cap_mix_name, set_type, mval);
        }
        /// <summary>
        /// 创建文件广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateSerFileGbStream(int user_id, ref NETAVHSDK_GBSERFILEINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateSerFileGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 创建本利文件广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateLcaFileGbStream(int user_id, ref NETAVHSDK_GBLCAFILEINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateLcaFileGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 创建文本广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateTextGbStream(int user_id, ref NETAVHSDK_GBTEXTINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateTextGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 创建终端采播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateTerminalCbStream(int user_id, ref NETAVHSDK_GBTMCBINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateTerminalCbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 声卡源频道
        /// </summary>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateSoundCarSrcChannel(ref NETAVHSDK_SoundCarSrcINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateSoundCarSrcChannel(ref pGbinfo);
        }
        /// <summary>
        /// 采播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateEncTerminalCbStream(int user_id, ref NETAVHSDK_GBENCTMCBINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateEncTerminalCbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 声卡广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateSoundCarGbStream(int user_id, ref NETAVHSDK_GBSoundCarINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateSoundCarGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 第三方通道资源
        /// </summary>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateThirdRealSrcChannel(ref NETAVHSDK_ThirdRealSrcINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateThirdRealSrcChannel(ref pGbinfo);
        }
        /// <summary>
        /// 第三方文件内容
        /// </summary>
        /// <param name="aSrcId"></param>
        /// <param name="buf"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_FillDataToThirdRealSrcChannel(int aSrcId, string buf, int len)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_FillDataToThirdRealSrcChannel(aSrcId, buf, len);
        }
        /// <summary>
        /// 创建第三方音频广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateThirdRealAudioGbStream(int user_id, ref NETAVHSDK_GBTHIRDREALAUDIOINFO pGbinfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CreateThirdRealAudioGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 删除音频资源频道
        /// </summary>
        /// <param name="aSrcId"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_DelOneAudioSrcChannel(int aSrcId)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_DelOneAudioSrcChannel(aSrcId);
        }
        /// <summary>
        /// 删除一个流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="stream_id"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_DelOneStream(int user_id, int stream_id)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_DelOneStream(user_id, stream_id);
        }
        /// <summary>
        /// 设置输出音量
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pVol"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_SetTmOutVol(int user_id, ref NETAVHSDK_SET_TMVOL pVol)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_SetTmOutVol(user_id, ref pVol);
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
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_ThreeFireArm(user_id, ref pVol, pinType);
        }
        /// <summary>
        /// 分析本地MP3文件信息
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="mp3FileInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetMp3FileInfo(string file_path, ref NETAVHSDK_LCA_MP3INFO mp3FileInfo)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_GetMp3FileInfo(file_path, ref mp3FileInfo);
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
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CtrlAnyTmForCall(user_id, tm_id, ctlType);
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
            var _proxy = IPGB.NET.IPGBNET.Instance;
            return _proxy.NETIPGBNETSDK_CtrlAnyTmForCall(user_id, main_tmid, other_tmid);
        }
        /// <summary>
        /// 获取用户分区信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetUserFqInfo(int user_id, ref NETAVHSDK_USERFQINFO model)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            var obj = JsonConvertType(model, typeof(IPGB.NET.NETAVHSDK_USERFQINFO)) as IPGB.NET.NETAVHSDK_USERFQINFO;
            return _proxy.NETIPGBNETSDK_GetUserFqInfo(user_id, ref obj);
        }
        /// <summary>
        /// 获取用户分区信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ushort GetUserFqInfo(int user_id, ref NETAVHSDK_USERFQINFO model)
        {
            var _proxy = IPGB.NET.IPGBNET.Instance;
            var obj = JsonConvertType(model, typeof(IPGB.NET.NETAVHSDK_USERFQINFO)) as IPGB.NET.NETAVHSDK_USERFQINFO;
            var res = _proxy.NETIPGBNETSDK_GetUserFqInfo(user_id, ref obj);
            model = (NETAVHSDK_USERFQINFO)JsonConvertType(obj, model.GetType());
            return res;
        }
        /// <summary>
        /// 以Json为中间转换类型
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TOut JsonConvertType<TIn, TOut>(TIn source)
        {
            if (source == null) { return default(TOut); }
            var jsonString = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<TOut>(jsonString);
        }
        /// <summary>
        /// 以Json为中间转换类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="outType"></param>
        /// <returns></returns>
        public static object JsonConvertType(object source, Type outType)
        {
            if (source == null) { return null; }
            var jsonString = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject(jsonString, outType);
        }
    }
}
