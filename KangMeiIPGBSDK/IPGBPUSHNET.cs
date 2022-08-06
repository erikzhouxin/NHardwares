using System;
using System.Runtime.InteropServices;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 文件推流
    /// </summary>
    public class IPGBPUSHNET
    {
        private static IPGBPUSHNET s_IPGBPUSHNET;
        private static object s_lock = new object();
        /// <summary>
        /// 实例
        /// </summary>
        public static IPGBPUSHNET Instance
        {
            get
            {
                if (null == s_IPGBPUSHNET)
                {
                    lock (s_lock)
                    {
                        if (null == s_IPGBPUSHNET)
                        {
                            s_IPGBPUSHNET = new IPGBPUSHNET();
                        }
                    }
                }
                return s_IPGBPUSHNET;
            }
        }
        #region // 委托定义
        /// <summary>
        /// 推流状态回调函数原形
        /// </summary>
        /// <param name="PID">推流ID</param>
        /// <param name="PSta">推流状态</param>
        /// <param name="dwUser">用户类指针</param>
        public delegate void NETfGBStreamSta(int PID, int PSta, long dwUser);
        #endregion
        IIPGBPUSHSdkProxy _proxy;
        /// <summary>
        /// 
        /// </summary>
        public IPGBPUSHNET()
        {
            _proxy = IPGBPUSHSdk.Create();
        }
        public void NETIPGBPUSHNETSDK_SetGBStreamStaCallBack(NETfGBStreamSta GBStreamStaCallBack, long dwUser)
        {
            var func = IPGBNET.GetConvertFunc(GBStreamStaCallBack, () => new SDKfPushStatus((iPID, iPSta, idwUser) => GBStreamStaCallBack.Invoke(iPID, (int)iPSta, idwUser)));
            _proxy.IPGBPUSHSTREAM_SetCallBackPushStatus(func, dwUser);
        }

        public ushort NETIPGBPUSHNETSDK_Init()
        {
            return (ushort)((_proxy.IPGBPUSHSTREAM_Init() != 0) ? 0 : 1);
        }

        public void NETIPGBPUSHNETSDK_Cleanup()
        {
            _proxy.IPGBPUSHSTREAM_Cleanup();
        }

        public string[] NETIPGBPUSHNETSDK_GetSysSoundCardINFO(ref NETPUSHSDK_SOUNDCARDINFO target)
        {
            IPGBPUSH_SOUNDCARDINFO ipgbpush_SOUNDCARDINFO = (IPGBPUSH_SOUNDCARDINFO)target;
            _proxy.IPGBPUSHSTREAM_GetSysSoundCardINFO(out ipgbpush_SOUNDCARDINFO);
            target.SetModel(ipgbpush_SOUNDCARDINFO);
            return target.SOUNDNODES.SelectArray(s => s.CapMixName);
        }

        public void NETIPGBPUSHNETSDK_SetSysSoundCardVol(string cap_mix_name, int mval)
        {
            _proxy.IPGBPUSHSTREAM_SetSysSoundCardVol(cap_mix_name, (ushort)mval);
        }

        public ushort NETIPGBPUSHNETSDK_CreateSoundCardPushStream(ref NETPUSHSDK_SoundCarPushStream pSrcinfo)
        {
            IPGBPUSH_SoundCarPushStream ipgbpush_SoundCarPushStream = (IPGBPUSH_SoundCarPushStream)pSrcinfo;
            var num = _proxy.IPGBPUSHSTREAM_CreateSoundCardPushStream(ipgbpush_SoundCarPushStream);
            return (ushort)num;
        }

        public ushort NETIPGBPUSHNETSDK_CreateThirdPushStream(ref NETPUSHSDK_ThirdPushStream pSrcinfo)
        {
            IPGBPUSH_ThirdPushStream ipgbpush_ThirdPushStream = pSrcinfo;
            return (ushort)_proxy.IPGBPUSHSTREAM_CreateThirdPushStream(ipgbpush_ThirdPushStream);
        }

        public ushort NETIPGBPUSHNETSDK_FillDataToThirdStream(int StreamId, string buf, int len)
        {
            return (ushort)_proxy.IPGBPUSHSTREAM_FillDataToThirdStream((ushort)StreamId, buf, len);
        }

        public ushort NETIPGBPUSHNETSDK_DelOnePushStream(int StreamId)
        {
            _proxy.IPGBPUSHSTREAM_DelOnePushStream((ushort)StreamId);
            return 0;
        }

        public ushort NETIPGBPUSHNETSDK_GetMp3FileInfo(string file_path, ref NETPUSHSDK_LCA_MP3INFO mp3FileInfo)
        {
            IPGBPUSH_LCA_MP3INFO fileSec = mp3FileInfo;
            var res = _proxy.IPGBPUSHSTREAM_GetMp3FileInfo(file_path, out fileSec);
            mp3FileInfo.SetModel(fileSec);
            return (ushort)res;
        }
    }
}
