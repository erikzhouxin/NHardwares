using System;
using System.Collections.Concurrent;
using System.Data.Mabber;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IPGBPUSH.NET
{
    /// <summary>
    /// 原生命名空间调用类
    /// </summary>
    public class IPGBPUSHNET : System.Data.KangMeiIPGBSDK.IPGBPUSHNET { }
}
namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 文件推流
    /// </summary>
    public class IPGBPUSHNET
    {
        private static readonly object _pLocker;
        private static readonly Assembly _pAssembly;
        private static readonly Type _pType;
        private static readonly ConcurrentDictionary<string, Type> _pTypes;
        private static readonly ConcurrentDictionary<string, MethodInfo> _pMethods;
        /// <summary>
        /// 文件名称
        /// </summary>
        public const String DllFileName = "IPGBNETPush.dll";
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
        public static IPGBPUSHNET Instance { get; }
        static IPGBPUSHNET()
        {
            _pLocker = new object();
            IPGBNETSdk.Create();
            DllFullPath = IPGBPUSHSdkLoader.DllFullPath;
            DllFullName = Path.Combine(DllFullPath, DllFileName);
            if (!File.Exists(DllFullName))
            {
                if (Environment.Is64BitProcess)
                {
                    IPGBNETSdk.WriteFile(Properties.Resources.X64_IPGBNETPush, DllFullName);
                }
                else
                {
                    IPGBNETSdk.WriteFile(Properties.Resources.X86_IPGBNETPush, DllFullName);
                }
            }
            Instance = new IPGBPUSHNET();
            _pTypes = new ConcurrentDictionary<string, Type>();
            _pMethods = new ConcurrentDictionary<string, MethodInfo>();
            _pAssembly = Assembly.LoadFile(DllFullName);
            _pType = _pAssembly.GetType(typeof(IPGBPUSH.NET.IPGBPUSHNET).FullName);
        }
        private readonly object _pModel;
        internal IPGBPUSHNET(object model) { _pModel = model; }
        /// <summary>
        /// 构造
        /// </summary>
        public IPGBPUSHNET() { _pModel = Activator.CreateInstance(_pType); }
        /// <summary>
        /// 设置回调
        /// </summary>
        /// <param name="GBStreamStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBPUSHNETSDK_SetGBStreamStaCallBack(SDKfGBStreamSta GBStreamStaCallBack, long dwUser)
        {
            GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_SetGBStreamStaCallBack), GBStreamStaCallBack, dwUser);
            //_proxy.NETIPGBPUSHNETSDK_SetGBStreamStaCallBack(GBStreamStaCallBack, dwUser);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_Init()
        {
            return (ushort)GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_Init));
            //return _proxy.NETIPGBPUSHNETSDK_Init();
        }
        /// <summary>
        /// 清除
        /// </summary>
        public void NETIPGBPUSHNETSDK_Cleanup()
        {
            GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_Cleanup));
            //_proxy.NETIPGBPUSHNETSDK_Cleanup();
        }
        /// <summary>
        /// 获取系统声卡信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string[] NETIPGBPUSHNETSDK_GetSysSoundCardINFO(ref NETPUSHSDK_SOUNDCARDINFO target)
        {
            var model = ChangeModelType(target, nameof(NETPUSHSDK_SOUNDCARDINFO));
            return (string[])GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_GetSysSoundCardINFO), model);
            //return _proxy.NETIPGBPUSHNETSDK_GetSysSoundCardINFO(ref target);
        }
        /// <summary>
        /// 设置声卡信息
        /// </summary>
        /// <param name="cap_mix_name"></param>
        /// <param name="mval"></param>
        public void NETIPGBPUSHNETSDK_SetSysSoundCardVol(string cap_mix_name, int mval)
        {
            GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_SetSysSoundCardVol), cap_mix_name, mval);
            //_proxy.NETIPGBPUSHNETSDK_SetSysSoundCardVol(cap_mix_name, mval);
        }
        /// <summary>
        /// 创建声卡推流
        /// </summary>
        /// <param name="pSrcinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_CreateSoundCardPushStream(ref NETPUSHSDK_SoundCarPushStream pSrcinfo)
        {
            var model = ChangeModelType(pSrcinfo, nameof(NETPUSHSDK_SoundCarPushStream));
            return (ushort)GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_CreateSoundCardPushStream), model);
            //return _proxy.NETIPGBPUSHNETSDK_CreateSoundCardPushStream(ref pSrcinfo);
        }
        /// <summary>
        /// 创建第三方推流
        /// </summary>
        /// <param name="pSrcinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_CreateThirdPushStream(ref NETPUSHSDK_ThirdPushStream pSrcinfo)
        {
            var model = ChangeModelType(pSrcinfo, nameof(NETPUSHSDK_ThirdPushStream));
            return (ushort)GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_CreateThirdPushStream), model);
            //return _proxy.NETIPGBPUSHNETSDK_CreateThirdPushStream(ref pSrcinfo);
        }
        /// <summary>
        /// 填充数据第三方推流
        /// </summary>
        /// <param name="StreamId"></param>
        /// <param name="buf"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_FillDataToThirdStream(int StreamId, string buf, int len)
        {
            return (ushort)GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_FillDataToThirdStream), StreamId, buf, len);
            //return _proxy.NETIPGBPUSHNETSDK_FillDataToThirdStream(StreamId, buf, len);
        }
        /// <summary>
        /// 删除一个推流
        /// </summary>
        /// <param name="StreamId"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_DelOnePushStream(int StreamId)
        {
            return (ushort)GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_DelOnePushStream), StreamId);
            //return _proxy.NETIPGBPUSHNETSDK_DelOnePushStream(StreamId);
        }
        /// <summary>
        /// 获取MP3文件信息
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="mp3FileInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_GetMp3FileInfo(string file_path, ref NETPUSHSDK_LCA_MP3INFO mp3FileInfo)
        {
            var model = ChangeModelType(mp3FileInfo, nameof(NETPUSHSDK_LCA_MP3INFO));
            return (ushort)GetMethodInvoke(nameof(NETIPGBPUSHNETSDK_GetMp3FileInfo), file_path, model);
            //return _proxy.NETIPGBPUSHNETSDK_GetMp3FileInfo(file_path, ref mp3FileInfo);
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
