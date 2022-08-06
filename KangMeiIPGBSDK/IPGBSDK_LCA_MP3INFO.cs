using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 分析本地MP3文件信息
     * typedef struct  
     * {
     *   unsigned int FileSec;                    //文件时长 秒
     *   unsigned int IsUseGb;                   //是否可用于本地文件广播资源
     * }IPGBSDK_LCA_MP3INFO,*LPIPGBSDK_LCA_MP3INFO;
     **/
    public struct IPGBSDK_LCA_MP3INFO
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
    public class NETAVHSDK_LCA_MP3INFO
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
        /// 设置模型
        /// </summary>
        /// <param name="pMp3Info"></param>
        /// <returns></returns>
        public NETAVHSDK_LCA_MP3INFO SetModel(IPGBSDK_LCA_MP3INFO pMp3Info)
        {
            this.FileSec = pMp3Info.FileSec;
            this.IsUseGb = pMp3Info.IsUseGb;
            return this;
        }
    }
}
