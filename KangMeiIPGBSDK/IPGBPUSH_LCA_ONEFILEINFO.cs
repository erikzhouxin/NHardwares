using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 选择推流的文件信息(本地文件资源)
    /// typedef struct  
    /// {
    ///   char   FilePath[IPGBPUSH_MAX_LCAFILEPATHLEN];//此文件所在的目录 (只支持mp3文件且位速率为cbr 128kb/s)
    /// }IPGBPUSH_LCA_ONEFILEINFO,*LPIPGBPUSH_LCA_ONEFILEINFO;
    /// </summary>
    public struct IPGBPUSH_LCA_ONEFILEINFO
    {
        /// <summary>
        /// 此文件所在的目录 (只支持mp3文件且位速率为cbr 128kb/s)
        /// </summary>
        public string FilePath;
    }
    /// <summary>
    /// 选择推流的文件信息(本地文件资源)
    /// </summary>
    public class NETPUSHSDK_LCA_ONEFILEINFO
    {
        /// <summary>
        /// 此文件所在的目录 (只支持mp3文件且位速率为cbr 128kb/s)
        /// </summary>
        public string FilePath;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETPUSHSDK_LCA_ONEFILEINFO(IPGBPUSH_LCA_ONEFILEINFO model)
        {
            return new NETPUSHSDK_LCA_ONEFILEINFO { FilePath = model.FilePath };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBPUSH_LCA_ONEFILEINFO(NETPUSHSDK_LCA_ONEFILEINFO model)
        {
            return new IPGBPUSH_LCA_ONEFILEINFO { FilePath = model.FilePath };
        }
    }
}
