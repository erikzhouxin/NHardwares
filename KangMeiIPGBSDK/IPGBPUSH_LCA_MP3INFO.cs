using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 分析本地MP3文件信息
    /// typedef struct  
    /// {
    ///   unsigned int FileSec;                    //文件时长 秒
    ///   unsigned int IsUseGb;                   //是否可用于本地文件广播资源
    /// }IPGBPUSH_LCA_MP3INFO,*LPIPGBPUSH_LCA_MP3INFO;
    /// </summary>
    public struct IPGBPUSH_LCA_MP3INFO
    {
        /// <summary>
        /// 文件时长 秒
        /// </summary>
        public ushort FileSec;
        /// <summary>
        /// 是否可用于本地文件广播资源
        /// </summary>
        public ushort IsUseGb;
    }
    /// <summary>
    /// 分析本地MP3文件信息
    /// </summary>
    public class NETPUSHSDK_LCA_MP3INFO
    {
        /// <summary>
        /// 文件时长 秒
        /// </summary>
        public ushort FileSec;
        /// <summary>
        /// 是否可用于本地文件广播资源
        /// </summary>
        public ushort IsUseGb;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETPUSHSDK_LCA_MP3INFO(IPGBPUSH_LCA_MP3INFO model)
        {
            return new NETPUSHSDK_LCA_MP3INFO
            {
                FileSec = model.FileSec,
                IsUseGb = model.IsUseGb,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBPUSH_LCA_MP3INFO(NETPUSHSDK_LCA_MP3INFO model)
        {
            return new IPGBPUSH_LCA_MP3INFO
            {
                FileSec = model.FileSec,
                IsUseGb = model.IsUseGb,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETPUSHSDK_LCA_MP3INFO SetModel(IPGBPUSH_LCA_MP3INFO model)
        {
            FileSec = model.FileSec;
            IsUseGb = model.IsUseGb;
            return this;
        }
    }
}
