using System;
using System.Runtime.InteropServices;
using static IPGBPUSH.NET.IPGBPUSHNET;

namespace IPGBPUSH.NET
{
    /// <summary>
    /// 文件推流
    /// </summary>
    public class IPGBPUSHNETSDK
    {
        private static readonly IPGBPUSHNET _proxy;
        /// <summary>
        /// 实例
        /// </summary>
        public static IPGBPUSHNETSDK Instance { get; }
        static IPGBPUSHNETSDK()
        {
            System.Data.KangMeiIPGBSDK.IPGBPUSHSdk.Create(true);
            _proxy = IPGBPUSHNET.Instance;
            Instance = new IPGBPUSHNETSDK();
        }
        /// <summary>
        /// 构造
        /// </summary>
        public IPGBPUSHNETSDK() { }
        /// <summary>
        /// 设置回调
        /// </summary>
        /// <param name="GBStreamStaCallBack"></param>
        /// <param name="dwUser"></param>
        public void NETIPGBPUSHNETSDK_SetGBStreamStaCallBack(NETfGBStreamSta GBStreamStaCallBack, long dwUser)
        {
            _proxy.NETIPGBPUSHNETSDK_SetGBStreamStaCallBack(GBStreamStaCallBack, dwUser);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_Init()
        {
            return _proxy.NETIPGBPUSHNETSDK_Init();
        }
        /// <summary>
        /// 清除
        /// </summary>
        public void NETIPGBPUSHNETSDK_Cleanup()
        {
            _proxy.NETIPGBPUSHNETSDK_Cleanup();
        }
        /// <summary>
        /// 获取系统声卡信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string[] NETIPGBPUSHNETSDK_GetSysSoundCardINFO(ref NETPUSHSDK_SOUNDCARDINFO target)
        {
            return _proxy.NETIPGBPUSHNETSDK_GetSysSoundCardINFO(ref target);
        }
        /// <summary>
        /// 设置声卡信息
        /// </summary>
        /// <param name="cap_mix_name"></param>
        /// <param name="mval"></param>
        public void NETIPGBPUSHNETSDK_SetSysSoundCardVol(string cap_mix_name, int mval)
        {
            _proxy.NETIPGBPUSHNETSDK_SetSysSoundCardVol(cap_mix_name, mval);
        }
        /// <summary>
        /// 创建声卡推流
        /// </summary>
        /// <param name="pSrcinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_CreateSoundCardPushStream(ref NETPUSHSDK_SoundCarPushStream pSrcinfo)
        {
            return _proxy.NETIPGBPUSHNETSDK_CreateSoundCardPushStream(ref pSrcinfo);
        }
        /// <summary>
        /// 创建第三方推流
        /// </summary>
        /// <param name="pSrcinfo"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_CreateThirdPushStream(ref NETPUSHSDK_ThirdPushStream pSrcinfo)
        {
            return _proxy.NETIPGBPUSHNETSDK_CreateThirdPushStream(ref pSrcinfo);
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
            return _proxy.NETIPGBPUSHNETSDK_FillDataToThirdStream(StreamId, buf, len);
        }
        /// <summary>
        /// 删除一个推流
        /// </summary>
        /// <param name="StreamId"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_DelOnePushStream(int StreamId)
        {
            return _proxy.NETIPGBPUSHNETSDK_DelOnePushStream(StreamId);
        }
        /// <summary>
        /// 获取MP3文件信息
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="mp3FileInfo"></param>
        /// <returns></returns>
        public ushort NETIPGBPUSHNETSDK_GetMp3FileInfo(string file_path, ref NETPUSHSDK_LCA_MP3INFO mp3FileInfo)
        {
            return _proxy.NETIPGBPUSHNETSDK_GetMp3FileInfo(file_path, ref mp3FileInfo);
        }
    }
}
