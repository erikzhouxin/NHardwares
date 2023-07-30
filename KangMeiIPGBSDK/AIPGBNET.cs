using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.Data.Mabber;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IPGB.NET
{
    /// <summary>
    /// 原生命名空间调用类
    /// </summary>
    public class IPGBNET : System.Data.KangMeiIPGBSDK.IPGBNET { }
}
namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 康美音柱源提供程序调用方式
    /// </summary>
    public class IPGBNET
    {
        #region // 内部定义
        /// <summary>
        /// 连接状态委托回调
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ISConn"></param>
        /// <param name="lpUserInfo"></param>
        /// <param name="dwUser"></param>
        public delegate void NETfConnectOrDis(int UserId, byte ISConn, NETAVHSDK_USERINFO lpUserInfo, long dwUser);
        /// <summary>
        /// 终端状态回调
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="lpTmInfo"></param>
        /// <param name="dwUser"></param>
        public delegate void NETfTerminalSta(int UserId, NETAVHSDK_TMINFO lpTmInfo, long dwUser);
        /// <summary>
        /// 批量终端状态回调
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="lpTmInfo"></param>
        /// <param name="dwUser"></param>
        public delegate void NETfBatchTerminalSta(int UserId, NETAVHSDK_CALLBACKTMINFO lpTmInfo, long dwUser);
        /// <summary>
        /// ENC终端状态回调
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="lpTmInfo"></param>
        /// <param name="dwUser"></param>
        public delegate void NETfEncTerminalSta(int UserId, NETAVHSDK_ENCTMINFO lpTmInfo, long dwUser);
        /// <summary>
        /// 广播流状态回调
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="StreamId"></param>
        /// <param name="StreamSta"></param>
        /// <param name="dwUser"></param>
        public delegate void NETfGBStreamSta(int UserId, int StreamId, int StreamSta, long dwUser);
        /// <summary>
        /// 警报状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="lpFireInfo"></param>
        /// <param name="dwUser"></param>
        public delegate void NETfFireSta(int UserId, NETAVHSDK_FIREINFO lpFireInfo, long dwUser);
        #endregion
        private static readonly object _pLocker;
        private static readonly Assembly _pAssembly;
        private static readonly Type _pType;
        private static readonly MethodInfo _pDelegate;
        private static readonly ConcurrentDictionary<string, Type> _pTypes;
        private static readonly ConcurrentDictionary<string, MethodInfo> _pMethods;
        /// <summary>
        /// 文件名称
        /// </summary>
        public const String DllFileName = "IPGBNET.dll";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{IPGBNETSdk.DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// x64的dll目录
        /// </summary>
        public const String DllFileNameX64 = $@".\{IPGBNETSdk.DllVirtualPath}\x64\{DllFileName}";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; }
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public static String DllNamespace { get => _pType.Namespace; }
        /// <summary>
        /// 单例
        /// </summary>
        public static IPGBNET Instance { get; }
        static IPGBNET()
        {
            _pLocker = new object();
            IPGBNETSdk.Create();
            DllFullName = Path.GetFullPath(Environment.Is64BitProcess ? DllFileNameX64 : DllFileNameX86);
            DllFullPath = Path.GetDirectoryName(DllFullName);
            _pAssembly = Assembly.LoadFile(DllFullName);
            _pType = _pAssembly.GetType(typeof(IPGB.NET.IPGBNET).FullName);
            Instance = new IPGBNET(_pType.GetProperty(nameof(Instance)).GetValue(null, null));

            _pTypes = new ConcurrentDictionary<string, Type>();
            _pMethods = new ConcurrentDictionary<string, MethodInfo>();

            _pDelegate = typeof(IPGBNET).GetMethod(nameof(ChangeTargetType), BindingFlags.Static | BindingFlags.NonPublic);
        }

        private readonly object _pModel;
        internal IPGBNET(object model) { _pModel = model; }
        /// <summary>
        /// 构造
        /// </summary>
        public IPGBNET() { _pModel = Activator.CreateInstance(_pType); }
        private NETfConnectOrDis _logCallback;
        private Delegate _rlogCallback;
        private bool _isLogCallback;
        /// <summary>
        /// 设置登录状态回调
        /// </summary>
        /// <param name="LogCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetLogCallBack(NETfConnectOrDis LogCallBack, long dwUser)
        {
            this._logCallback = LogCallBack;
            if (!_isLogCallback)
            {
                _isLogCallback = true;
                var userId = Expression.Parameter(typeof(int));
                var isConn = Expression.Parameter(typeof(byte));
                var userInfo = Expression.Parameter(GetModelType(nameof(NETAVHSDK_USERINFO)));
                var typechagne = Expression.Constant(typeof(NETAVHSDK_USERINFO));
                var userInfoRes = Expression.Call(null, _pDelegate, userInfo, typechagne);
                var userInfoObj = Expression.Convert(userInfoRes, typeof(NETAVHSDK_USERINFO));
                var tmId = Expression.Parameter(typeof(long));
                var thisVal = Expression.Constant(this);
                var delegateModel = GetModelDelegate(nameof(NETfConnectOrDis));
                var callMethod = Expression.Call(thisVal, typeof(IPGBNET).GetMethod(nameof(ConnectOrDis), BindingFlags.Instance | BindingFlags.NonPublic), userId, isConn, userInfoObj, tmId);
                var _elogCallback = Expression.Lambda(delegateModel, callMethod, userId, isConn, userInfo, tmId);
                GetMethodInvoke(nameof(NETIPGBNETSDK_SetLogCallBack), _rlogCallback = _elogCallback.Compile(), dwUser);
            }
            //_pModel.NETIPGBNETSDK_SetLogCallBack(LogCallBack, dwUser);
        }
        private void ConnectOrDis(int UserId, byte ISConn, NETAVHSDK_USERINFO lpUserInfo, long dwUser)
        {
            _logCallback?.Invoke(UserId, ISConn, lpUserInfo, dwUser);
        }
        private NETfTerminalSta _tmstaCallback;
        private Delegate _rtmstaCallback;
        private bool _isTmstaCallback;
        /// <summary>
        /// 设置终端状态回调
        /// </summary>
        /// <param name="TerminalStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetTerminalStaCallBack(NETfTerminalSta TerminalStaCallBack, long dwUser)
        {
            this._tmstaCallback = TerminalStaCallBack;
            if (!_isTmstaCallback)
            {
                _isTmstaCallback = true;
                var userId = Expression.Parameter(typeof(int));
                var userInfo = Expression.Parameter(GetModelType(nameof(NETAVHSDK_TMINFO)));
                var typechagne = Expression.Constant(typeof(NETAVHSDK_TMINFO));
                var userInfoRes = Expression.Call(null, _pDelegate, userInfo, typechagne);
                var userInfoObj = Expression.Convert(userInfoRes, typeof(NETAVHSDK_TMINFO));
                var tmId = Expression.Parameter(typeof(long));
                var thisVal = Expression.Constant(this);
                var delegateModel = GetModelDelegate(nameof(NETfTerminalSta));
                var callMethod = Expression.Call(thisVal, typeof(IPGBNET).GetMethod(nameof(TeminalSta), BindingFlags.Instance | BindingFlags.NonPublic), userId, userInfoObj, tmId);
                var _etmstaCallback = Expression.Lambda(delegateModel, callMethod, userId, userInfo, tmId);
                GetMethodInvoke(nameof(NETIPGBNETSDK_SetTerminalStaCallBack), _rtmstaCallback = _etmstaCallback.Compile(), dwUser);
            }
            //_pModel.NETIPGBNETSDK_SetTerminalStaCallBack(TerminalStaCallBack, dwUser);
        }
        private void TeminalSta(int UserId, NETAVHSDK_TMINFO lpTmInfo, long dwUser)
        {
            _tmstaCallback?.Invoke(UserId, lpTmInfo, dwUser);
        }
        private NETfBatchTerminalSta _btmstaCallback;
        private Delegate _rbtmstaCallback;
        private bool _isBTmstaCallback;
        /// <summary>
        /// 批量设置终端状态回调
        /// </summary>
        /// <param name="BatchTerminalStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetBatchTerminalStaCallBack(NETfBatchTerminalSta BatchTerminalStaCallBack, long dwUser)
        {
            this._btmstaCallback = BatchTerminalStaCallBack;
            if (!_isBTmstaCallback)
            {
                _isBTmstaCallback = true;
                var userId = Expression.Parameter(typeof(int));
                var userInfo = Expression.Parameter(GetModelType(nameof(NETAVHSDK_CALLBACKTMINFO)));
                var typechagne = Expression.Constant(typeof(NETAVHSDK_CALLBACKTMINFO));
                var userInfoRes = Expression.Call(null, _pDelegate, userInfo, typechagne);
                var userInfoObj = Expression.Convert(userInfoRes, typeof(NETAVHSDK_CALLBACKTMINFO));
                var tmId = Expression.Parameter(typeof(long));
                var thisVal = Expression.Constant(this);
                var delegateModel = GetModelDelegate(nameof(NETfBatchTerminalSta));
                var callMethod = Expression.Call(thisVal, typeof(IPGBNET).GetMethod(nameof(BatchTerminalSta), BindingFlags.Instance | BindingFlags.NonPublic), userId, userInfoObj, tmId);
                var _ebtmstaCallback = Expression.Lambda(delegateModel, callMethod, userId, userInfo, tmId);
                GetMethodInvoke(nameof(NETIPGBNETSDK_SetBatchTerminalStaCallBack), _rbtmstaCallback = _ebtmstaCallback.Compile(), dwUser);
            }
            //_pModel.NETIPGBNETSDK_SetBatchTerminalStaCallBack(BatchTerminalStaCallBack, dwUser);
        }
        private void BatchTerminalSta(int UserId, NETAVHSDK_CALLBACKTMINFO lpTmInfo, long dwUser)
        {
            _btmstaCallback?.Invoke(UserId, lpTmInfo, dwUser);
        }
        private NETfEncTerminalSta _etmstaCallback;
        private Delegate _retmstaCallback;
        private bool _isETmstaCallback;
        /// <summary>
        /// 设置ENC终端状态回调
        /// </summary>
        /// <param name="EncTerminalStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetEncTerminalStaCallBack(NETfEncTerminalSta EncTerminalStaCallBack, long dwUser)
        {
            this._etmstaCallback = EncTerminalStaCallBack;
            if (!_isETmstaCallback)
            {
                _isETmstaCallback = true;
                var userId = Expression.Parameter(typeof(int));
                var userInfo = Expression.Parameter(GetModelType(nameof(NETAVHSDK_ENCTMINFO)));
                var typechagne = Expression.Constant(typeof(NETAVHSDK_ENCTMINFO));
                var userInfoRes = Expression.Call(null, _pDelegate, userInfo, typechagne);
                var userInfoObj = Expression.Convert(userInfoRes, typeof(NETAVHSDK_ENCTMINFO));
                var tmId = Expression.Parameter(typeof(long));
                var thisVal = Expression.Constant(this);
                var delegateModel = GetModelDelegate(nameof(NETfEncTerminalSta));
                var callMethod = Expression.Call(thisVal, typeof(IPGBNET).GetMethod(nameof(EncTerminalSta), BindingFlags.Instance | BindingFlags.NonPublic), userId, userInfoObj, tmId);
                var _eetmstaCallback = Expression.Lambda(delegateModel, callMethod, userId, userInfo, tmId);
                GetMethodInvoke(nameof(NETIPGBNETSDK_SetEncTerminalStaCallBack), _retmstaCallback = _eetmstaCallback.Compile(), dwUser);
            }
            //_pModel.NETIPGBNETSDK_SetEncTerminalStaCallBack(EncTerminalStaCallBack, dwUser);
        }
        private void EncTerminalSta(int UserId, NETAVHSDK_ENCTMINFO lpTmInfo, long dwUser)
        {
            _etmstaCallback?.Invoke(UserId, lpTmInfo, dwUser);
        }
        private NETfGBStreamSta _gbstaCallback;
        private Delegate _rgbstaCallback;
        private bool _isGbstaCallback;
        /// <summary>
        /// 设置广播流状态回调
        /// </summary>
        /// <param name="GBStreamStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetGBStreamStaCallBack(NETfGBStreamSta GBStreamStaCallBack, long dwUser)
        {
            this._gbstaCallback = GBStreamStaCallBack;
            if (!_isGbstaCallback)
            {
                _isGbstaCallback = true;
                var userId = Expression.Parameter(typeof(int));
                var streamId = Expression.Parameter(typeof(int));
                var streamSta = Expression.Parameter(typeof(int));
                var tmId = Expression.Parameter(typeof(long));
                var thisVal = Expression.Constant(this);
                var delegateModel = GetModelDelegate(nameof(NETfGBStreamSta));
                var callMethod = Expression.Call(thisVal, typeof(IPGBNET).GetMethod(nameof(GBStreamSta), BindingFlags.Instance | BindingFlags.NonPublic), userId, streamId, streamSta, tmId);
                var _egbstaCallback = Expression.Lambda(delegateModel, callMethod, userId, streamId, streamSta, tmId);
                GetMethodInvoke(nameof(NETIPGBNETSDK_SetGBStreamStaCallBack), _rgbstaCallback = _egbstaCallback.Compile(), dwUser);
            }
            //_pModel.NETIPGBNETSDK_SetGBStreamStaCallBack(GBStreamStaCallBack, dwUser);
        }
        private void GBStreamSta(int UserId, int StreamId, int StreamSta, long dwUser)
        {
            _gbstaCallback?.Invoke(UserId, StreamId, StreamSta, dwUser);
        }
        private NETfFireSta _fstaCallback;
        private Delegate _rfstaCallback;
        private bool _isFstaCallback;
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="FireStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBNETSDK_SetFireStaCallBack(NETfFireSta FireStaCallBack, long dwUser)
        {
            this._fstaCallback = FireStaCallBack;
            if (!_isFstaCallback)
            {
                _isFstaCallback = true;
                var userId = Expression.Parameter(typeof(int));
                var userInfo = Expression.Parameter(GetModelType(nameof(NETAVHSDK_FIREINFO)));
                var typechagne = Expression.Constant(typeof(NETAVHSDK_FIREINFO));
                var userInfoRes = Expression.Call(null, _pDelegate, userInfo, typechagne);
                var userInfoObj = Expression.Convert(userInfoRes, typeof(NETAVHSDK_FIREINFO));
                var tmId = Expression.Parameter(typeof(long));
                var thisVal = Expression.Constant(this);
                var delegateModel = GetModelDelegate(nameof(NETfFireSta));
                var callMethod = Expression.Call(thisVal, typeof(IPGBNET).GetMethod(nameof(FireSta), BindingFlags.Instance | BindingFlags.NonPublic), userId, userInfoObj, tmId);
                var _efstaCallback = Expression.Lambda(delegateModel, callMethod, userId, userInfo, tmId);
                GetMethodInvoke(nameof(NETIPGBNETSDK_SetFireStaCallBack), _rfstaCallback = _efstaCallback.Compile(), dwUser);
            }
            //_pModel.NETIPGBNETSDK_SetFireStaCallBack(FireStaCallBack, dwUser);
        }
        private void FireSta(int UserId, NETAVHSDK_FIREINFO lpFireInfo, long dwUser)
        {
            _fstaCallback?.Invoke(UserId, lpFireInfo, dwUser);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_Init(Int32 port)
        {
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_Init), port);
            //return _pModel.NETIPGBNETSDK_Init(port);
        }
        /// <summary>
        /// 获取版本SDK
        /// </summary>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetSdkVer()
        {
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_GetSdkVer));
            //return _pModel.NETIPGBNETSDK_GetSdkVer();
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void NETIPGBNETSDK_Cleanup()
        {
            GetMethodInvoke(nameof(NETIPGBNETSDK_Cleanup));
            //_pModel.NETIPGBNETSDK_Cleanup();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="lpSer"></param>
        /// <param name="lpUser"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_LogIn(NETAVHSDK_LOGSERVER lpSer, ref NETAVHSDK_USERINFO lpUser)
        {
            var server = ChangeModelType(lpSer, nameof(NETAVHSDK_LOGSERVER));
            var model = ChangeModelType(lpUser, nameof(NETAVHSDK_USERINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_LogIn), server, model);
            //return _pModel.NETIPGBNETSDK_LogIn(lpSer, ref lpUser);
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="user_id"></param>
        public void NETIPGBNETSDK_LogOut(int user_id)
        {
            GetMethodInvoke(nameof(NETIPGBNETSDK_LogOut), user_id);
            //_pModel.NETIPGBNETSDK_LogOut(user_id);
        }
        /// <summary>
        /// 获取连接状态信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="lpUserInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetConnStatusInfo(int user_id, ref NETAVHSDK_USERINFO lpUserInfo)
        {
            var model = ChangeModelType(lpUserInfo, nameof(NETAVHSDK_USERINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_GetConnStatusInfo), user_id, model);
            //return _pModel.NETIPGBNETSDK_GetConnStatusInfo(user_id, ref lpUserInfo);
        }
        /// <summary>
        /// 获取一个文件信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="fdir"></param>
        /// <param name="ISFirst"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetOneSerFileInfo(int user_id, ref NETAVHSDK_ONEFILEINFO fdir, bool ISFirst)
        {
            var model = ChangeModelType(fdir, nameof(NETAVHSDK_ONEFILEINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_GetOneSerFileInfo), user_id, model, ISFirst);
            //return _pModel.NETIPGBNETSDK_GetOneSerFileInfo(user_id, ref fdir, ISFirst);
        }
        /// <summary>
        /// 获取系统声卡信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string[] NETIPGBNETSDK_GetSysSoundCardInfo(ref NETAVHSDK_SOUNDCARDINFO target)
        {
            var model = ChangeModelType(target, nameof(NETAVHSDK_SOUNDCARDINFO));
            return (string[])GetMethodInvoke(nameof(NETIPGBNETSDK_GetSysSoundCardInfo), model);
            //return _pModel.NETIPGBNETSDK_GetSysSoundCardInfo(ref target);
        }
        /// <summary>
        /// 获取声卡混合
        /// </summary>
        /// <param name="cap_mix_name"></param>
        /// <param name="set_type"></param>
        /// <param name="mval"></param>
        public void NETIPGBNETSDK_SetSysSoundCardMix(string cap_mix_name, int set_type, int mval)
        {
            GetMethodInvoke(nameof(NETIPGBNETSDK_SetSysSoundCardMix), cap_mix_name, set_type, mval);
            //_pModel.NETIPGBNETSDK_SetSysSoundCardMix(cap_mix_name, set_type, mval);
        }
        /// <summary>
        /// 创建文件广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateSerFileGbStream(int user_id, ref NETAVHSDK_GBSERFILEINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_GBSERFILEINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateSerFileGbStream), user_id, model);
            //return _pModel.NETIPGBNETSDK_CreateSerFileGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 创建本利文件广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateLcaFileGbStream(int user_id, ref NETAVHSDK_GBLCAFILEINFO pGbinfo)
        {

            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_GBLCAFILEINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateLcaFileGbStream), user_id, model);
            // return _pModel.NETIPGBNETSDK_CreateLcaFileGbStream(user_id, ref model);
        }
        /// <summary>
        /// 创建文本广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateTextGbStream(int user_id, ref NETAVHSDK_GBTEXTINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_GBTEXTINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateTextGbStream), user_id, model);
            //return _pModel.NETIPGBNETSDK_CreateTextGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 创建终端采播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateTerminalCbStream(int user_id, ref NETAVHSDK_GBTMCBINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_GBTMCBINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateTerminalCbStream), user_id, model);
            //return _pModel.NETIPGBNETSDK_CreateTerminalCbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 声卡源频道
        /// </summary>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateSoundCarSrcChannel(ref NETAVHSDK_SoundCarSrcINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_SoundCarSrcINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateSoundCarSrcChannel), model);
            //return _pModel.NETIPGBNETSDK_CreateSoundCarSrcChannel(ref pGbinfo);
        }
        /// <summary>
        /// 采播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateEncTerminalCbStream(int user_id, ref NETAVHSDK_GBENCTMCBINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_GBENCTMCBINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateEncTerminalCbStream), user_id, model);
            //return _pModel.NETIPGBNETSDK_CreateEncTerminalCbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 声卡广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateSoundCarGbStream(int user_id, ref NETAVHSDK_GBSoundCarINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_GBSoundCarINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateSoundCarGbStream), user_id, model);
            //return _pModel.NETIPGBNETSDK_CreateSoundCarGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 第三方通道资源
        /// </summary>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateThirdRealSrcChannel(ref NETAVHSDK_ThirdRealSrcINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_ThirdRealSrcINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateThirdRealSrcChannel), model);
            //return _pModel.NETIPGBNETSDK_CreateThirdRealSrcChannel(ref pGbinfo);
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
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_FillDataToThirdRealSrcChannel), aSrcId, buf, len);
            //return _pModel.NETIPGBNETSDK_FillDataToThirdRealSrcChannel(aSrcId, buf, len);
        }
        /// <summary>
        /// 创建第三方音频广播流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pGbinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_CreateThirdRealAudioGbStream(int user_id, ref NETAVHSDK_GBTHIRDREALAUDIOINFO pGbinfo)
        {
            var model = ChangeModelType(pGbinfo, nameof(NETAVHSDK_GBTHIRDREALAUDIOINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_CreateThirdRealAudioGbStream), user_id, model);
            //return _pModel.NETIPGBNETSDK_CreateThirdRealAudioGbStream(user_id, ref pGbinfo);
        }
        /// <summary>
        /// 删除音频资源频道
        /// </summary>
        /// <param name="aSrcId"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_DelOneAudioSrcChannel(int aSrcId)
        {
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_DelOneAudioSrcChannel), aSrcId);
            //return _pModel.NETIPGBNETSDK_DelOneAudioSrcChannel(aSrcId);
        }
        /// <summary>
        /// 删除一个流
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="stream_id"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_DelOneStream(int user_id, int stream_id)
        {
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_DelOneStream), user_id, stream_id);
            //return _pModel.NETIPGBNETSDK_DelOneStream(user_id, stream_id);
        }
        /// <summary>
        /// 设置输出音量
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pVol"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_SetTmOutVol(int user_id, ref NETAVHSDK_SET_TMVOL pVol)
        {
            var model = ChangeModelType(pVol, nameof(NETAVHSDK_SET_TMVOL));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_SetTmOutVol), user_id, model);
            //return _pModel.NETIPGBNETSDK_SetTmOutVol(user_id, ref pVol);
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
            var model = ChangeModelType(pVol, nameof(NETAVHSDK_THREEFIRINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_ThreeFireArm), user_id, model, pinType);
            //return _pModel.NETIPGBNETSDK_ThreeFireArm(user_id, ref pVol, pinType);
        }
        /// <summary>
        /// 分析本地MP3文件信息
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="mp3FileInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetMp3FileInfo(string file_path, ref NETAVHSDK_LCA_MP3INFO mp3FileInfo)
        {
            var model = ChangeModelType(mp3FileInfo, nameof(NETAVHSDK_LCA_MP3INFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_GetMp3FileInfo), file_path, model);
            // return _pModel.NETIPGBNETSDK_GetMp3FileInfo(file_path, ref mp3FileInfo);
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
            return (ushort)GetMethodInvoke2(nameof(NETIPGBNETSDK_CtrlAnyTmForCall), new Type[] { typeof(int), typeof(int), typeof(byte) }, user_id, tm_id, ctlType);
            //return _pModel.NETIPGBNETSDK_CtrlAnyTmForCall(user_id, tm_id, ctlType);
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
            return (ushort)GetMethodInvoke2(nameof(NETIPGBNETSDK_CtrlAnyTmForCall), new Type[] { typeof(int), typeof(uint), typeof(int) }, user_id, main_tmid, other_tmid);
            // return _pModel.NETIPGBNETSDK_CtrlAnyTmForCall(user_id, main_tmid, other_tmid);
        }
        /// <summary>
        /// 获取用户分区信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="pFqInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBNETSDK_GetUserFqInfo(int user_id, ref NETAVHSDK_USERFQINFO pFqInfo)
        {
            var model = ChangeModelType(pFqInfo, nameof(NETAVHSDK_USERFQINFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBNETSDK_GetUserFqInfo), user_id, model);
            // return _pModel.NETIPGBNETSDK_GetUserFqInfo(user_id, ref pFqInfo);
        }
        private object GetMethodInvoke(string name, params object[] args)
        {
            MethodInfo method;
            if (!_pMethods.TryGetValue(name, out method))
            {
                lock (_pLocker) { method = _pMethods[name] = _pType.GetMethod(name); }
            }
            return method.Invoke(_pModel, args);
        }
        private object GetMethodInvoke2(string name, Type[] types, params object[] args)
        {
            var key = $"{name}({string.Join(",", types.Select(s => s.Name))})";
            MethodInfo method;
            if (!_pMethods.TryGetValue(key, out method))
            {
                lock (_pLocker) { method = _pMethods[key] = _pType.GetMethod(name, types); }
            }
            return method.Invoke(_pModel, args);
        }
        private static object ChangeModelType(object srcObject, string name)
        {
            return ChangeTargetType(srcObject, GetModelType(name));
        }
        private static object ChangeTargetType(object srcObject, Type tagType)
        {
            Type srcType = srcObject.GetType();
            TinyMapper.Bind(srcType, tagType);
            return TinyMapper.Map(srcType, tagType, srcObject);
        }
        private static Type GetModelDelegate(string name)
        {
            var key = $"{_pType.FullName}+{name}";
            Type type;
            if (!_pTypes.TryGetValue(key, out type))
            {
                lock (_pLocker) { type = _pTypes[key] = _pAssembly.GetType(key); }
            }
            return type;
        }
        private static Type GetModelType(string name)
        {
            var key = $"{DllNamespace}.{name}";
            Type type;
            if (!_pTypes.TryGetValue(key, out type))
            {
                lock (_pLocker) { type = _pTypes[key] = _pAssembly.GetType(key); }
            }
            return type;
        }
    }
}