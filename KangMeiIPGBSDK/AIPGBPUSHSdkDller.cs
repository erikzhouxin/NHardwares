using System.Runtime.InteropServices;

namespace System.Data.KangMeiIPGBSDK
{
    internal class IPGBPUSHSdkDllerX64 : IIPGBPUSHSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IIPGBPUSHSdkProxy Instance { get; } = new IPGBPUSHSdkDllerX64();
        private IPGBPUSHSdkDllerX64() { }
        /**
         * 设置推流状态回调函数
         * @param  pFunc               (in)   回调函数地址
         * @param  puser               (in)   用户类指针
         * @return  
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern void IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser);
        /**
         * SDK初始化
         * @return ->返回0成功
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern int IPGBPUSHSTREAM_Init();
        /**
         * SDK退出清理
         * @return 
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern void IPGBPUSHSTREAM_Cleanup();
        /**
         * 获取得到系统的声卡信息
         * @param  SoundInfo           (out)   输出系统声卡混音接口
         * @return  
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern void IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo);
        /**
         * 设置系统声卡混音接口音量
         * @param  CapMixName              (in)    混音接口名
         * @param  MVal                    (in)    音量值 0-100
         * @return   
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern void IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal);
        /**
         * 创建实时声卡采集推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern int IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo);
        /**
         * 创建本地第三方音频流推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern int IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo);
        /**
         * 向本地第三方音频流推流通道输入相应格式的音频数据(注意：只对StreamType=1有效)
         * @param  StreamId        (in)    推流ID
         * @param  buf             (in)    音频数据
         * @param  len             (in)    音频数据长度
         * @return   ->成功返回等于len
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern int IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len);
        /**
         * 删除一个推流
         * @param  StreamId             (in)    推流ID
         * @return 
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern void IPGBPUSHSTREAM_DelOnePushStream(uint StreamId);
        /**
         * 分析本地MP3文件信息
         * @param  FilePath              (in)      本地MP3文件目录
         * @param  pMp3Fileinfo          (out)     输出文件信息
         * @return   ->成功返回0
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX64)]
        public static extern int IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo);
        #region // 显示实现
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Cleanup() => IPGBPUSHSTREAM_Cleanup();
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo) => IPGBPUSHSTREAM_CreateSoundCardPushStream(pSrcinfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo) => IPGBPUSHSTREAM_CreateThirdPushStream(pSrcinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_DelOnePushStream(uint StreamId) => IPGBPUSHSTREAM_DelOnePushStream(StreamId);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len) => IPGBPUSHSTREAM_FillDataToThirdStream(StreamId, buf, len);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo) => IPGBPUSHSTREAM_GetMp3FileInfo(FilePath, out pMp3Fileinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo) => IPGBPUSHSTREAM_GetSysSoundCardINFO(out SoundInfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Init() => IPGBPUSHSTREAM_Init();
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser) => IPGBPUSHSTREAM_SetCallBackPushStatus(pFunc, puser);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal) => IPGBPUSHSTREAM_SetSysSoundCardVol(CapMixName, MVal);
        #endregion
    }
    internal class IPGBPUSHSdkDllerX86 : IIPGBPUSHSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IIPGBPUSHSdkProxy Instance { get; } = new IPGBPUSHSdkDllerX86();
        private IPGBPUSHSdkDllerX86() { }
        /**
         * 设置推流状态回调函数
         * @param  pFunc               (in)   回调函数地址
         * @param  puser               (in)   用户类指针
         * @return  
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern void IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser);
        /**
         * SDK初始化
         * @return ->返回0成功
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern int IPGBPUSHSTREAM_Init();
        /**
         * SDK退出清理
         * @return 
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern void IPGBPUSHSTREAM_Cleanup();
        /**
         * 获取得到系统的声卡信息
         * @param  SoundInfo           (out)   输出系统声卡混音接口
         * @return  
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern void IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo);
        /**
         * 设置系统声卡混音接口音量
         * @param  CapMixName              (in)    混音接口名
         * @param  MVal                    (in)    音量值 0-100
         * @return   
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern void IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal);
        /**
         * 创建实时声卡采集推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern int IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo);
        /**
         * 创建本地第三方音频流推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern int IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo);
        /**
         * 向本地第三方音频流推流通道输入相应格式的音频数据(注意：只对StreamType=1有效)
         * @param  StreamId        (in)    推流ID
         * @param  buf             (in)    音频数据
         * @param  len             (in)    音频数据长度
         * @return   ->成功返回等于len
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern int IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len);
        /**
         * 删除一个推流
         * @param  StreamId             (in)    推流ID
         * @return 
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern void IPGBPUSHSTREAM_DelOnePushStream(uint StreamId);
        /**
         * 分析本地MP3文件信息
         * @param  FilePath              (in)      本地MP3文件目录
         * @param  pMp3Fileinfo          (out)     输出文件信息
         * @return   ->成功返回0
         **/
        [DllImport(IPGBPUSHSdk.DllFileNameX86)]
        public static extern int IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo);
        #region // 显示实现
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Cleanup() => IPGBPUSHSTREAM_Cleanup();
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo) => IPGBPUSHSTREAM_CreateSoundCardPushStream(pSrcinfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo) => IPGBPUSHSTREAM_CreateThirdPushStream(pSrcinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_DelOnePushStream(uint StreamId) => IPGBPUSHSTREAM_DelOnePushStream(StreamId);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len) => IPGBPUSHSTREAM_FillDataToThirdStream(StreamId, buf, len);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo) => IPGBPUSHSTREAM_GetMp3FileInfo(FilePath, out pMp3Fileinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo) => IPGBPUSHSTREAM_GetSysSoundCardINFO(out SoundInfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Init() => IPGBPUSHSTREAM_Init();
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser) => IPGBPUSHSTREAM_SetCallBackPushStatus(pFunc, puser);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal) => IPGBPUSHSTREAM_SetSysSoundCardVol(CapMixName, MVal);
        #endregion
    }
}
