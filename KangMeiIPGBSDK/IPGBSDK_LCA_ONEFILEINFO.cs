using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 选择广播的文件信息(本地文件资源)
     * typedef struct  
     * {
     *   char   FilePath[IPGB_MAX_LCA_FILEPATH];//此文件所在的目录 (只支持mp3文件且位速率为cbr 128kb/s)
     * }IPGBSDK_LCA_ONEFILEINFO,*LPIPGBSDK_LCA_ONEFILEINFO;
     **/
    public struct IPGBSDK_LCA_ONEFILEINFO
    {
        /// <summary>
        /// 此文件所在的目录 (只支持mp3文件且位速率为cbr 128kb/s)
        /// </summary>
        public string FilePath;
    }
    /// <summary>
    /// 选择广播的文件信息(本地文件资源)
    /// </summary>
    public class NETAVHSDK_LCA_ONEFILEINFO
    {
        /// <summary>
        /// 此文件所在的目录 (只支持mp3文件且位速率为cbr 128kb/s)
        /// </summary>
        public string FilePath;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_LCA_ONEFILEINFO(IPGBSDK_LCA_ONEFILEINFO model)
        {
            return new NETAVHSDK_LCA_ONEFILEINFO { FilePath = model.FilePath };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_LCA_ONEFILEINFO(NETAVHSDK_LCA_ONEFILEINFO model)
        {
            return new IPGBSDK_LCA_ONEFILEINFO() { FilePath = model.FilePath };
        }
    }
}
