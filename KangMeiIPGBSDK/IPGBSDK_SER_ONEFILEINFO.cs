using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 选择广播的文件信息(服务器文件资源)
     * typedef struct  
     * {
     *   char  FilePath[IPGB_MAX_FILEPATH];//此文件所在的目录 注意ROOT为资源根目录
     *   char  FileName[IPGB_MAX_FILEPATH];//此文件名
     *   unsigned int FileSec;                    //文件时长 秒
     * }IPGBSDK_SER_ONEFILEINFO,*LPIPGBSDK_SER_ONEFILEINFO;
     **/
    public struct IPGBSDK_SER_ONEFILEINFO
    {
        /// <summary>
        /// 此文件所在的目录 注意ROOT为资源根目录
        /// </summary>
        public string FilePath;
        /// <summary>
        /// 此文件名
        /// </summary>
        public string FileName;
        /// <summary>
        /// 文件时长 秒
        /// </summary>
        public uint FileSec;
    }
    /// <summary>
    /// 选择广播的文件信息(服务器文件资源)
    /// </summary>
    public class NETAVHSDK_ONEFILEINFO
    {
        /// <summary>
        /// 此文件所在的目录 注意ROOT为资源根目录
        /// </summary>
        public string FilePath;
        /// <summary>
        /// 此文件名
        /// </summary>
        public string FileName;
        /// <summary>
        /// 文件时长 秒
        /// </summary>
        public uint FileSec;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_ONEFILEINFO(IPGBSDK_SER_ONEFILEINFO model)
        {
            return new NETAVHSDK_ONEFILEINFO
            {
                FilePath = model.FilePath,
                FileName = model.FileName,
                FileSec = model.FileSec
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_SER_ONEFILEINFO(NETAVHSDK_ONEFILEINFO model)
        {
            return new IPGBSDK_SER_ONEFILEINFO
            {
                FilePath = model.FilePath,
                FileName = model.FileName,
                FileSec = model.FileSec
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_ONEFILEINFO SetModel(IPGBSDK_SER_ONEFILEINFO model)
        {
            FilePath = model.FilePath;
            FileName = model.FileName;
            FileSec = model.FileSec;
            return this;
        }
    }
}
