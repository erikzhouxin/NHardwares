using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 单个终端分区信息
     * typedef struct
     * {
     *     char FqName[IPGB_MAX_FQNAME_LEN];//此分区名
     *     WORD FqId;                       //此分区ID
     *     WORD FqTmCout;                   //此分区包含的终端个数
     *     WORD FqTmNo[IPGB_MAX_SDKTMCOUT]; //此分区终端ID数组
     * }IPGBSDK_ONEFQINFO,*LPIPGBSDK_ONEFQINFO;
     **/
    public struct IPGBSDK_ONEFQINFO
    {
        /// <summary>
        /// 此分区名
        /// </summary>
        public string FqName;
        /// <summary>
        /// 此分区ID
        /// </summary>
        public ushort FqId;
        /// <summary>
        /// 此分区包含的终端个数
        /// </summary>
        public ushort FqTmCout;
        /// <summary>
        /// 此分区包含的终端个数
        /// </summary>
        public ushort[] FqTmNo;
    }
    /// <summary>
    /// 单个终端分区信息
    /// </summary>
    public class NETAVHSDK_ONEFQINFO
    {
        /// <summary>
        /// 此分区名
        /// </summary>
        public string FqName;
        /// <summary>
        /// 此分区ID
        /// </summary>
        public ushort FqId;
        /// <summary>
        /// 此分区包含的终端个数
        /// </summary>
        public ushort FqTmCout;
        /// <summary>
        /// 此分区包含的终端个数
        /// </summary>
        public ushort[] FqTmNo;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_ONEFQINFO(NETAVHSDK_ONEFQINFO model)
        {
            return new IPGBSDK_ONEFQINFO
            {
                FqId = model.FqId,
                FqName = model.FqName,
                FqTmCout = model.FqTmCout,
                FqTmNo = model.FqTmNo,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_ONEFQINFO(IPGBSDK_ONEFQINFO model)
        {
            return new NETAVHSDK_ONEFQINFO
            {
                FqId = model.FqId,
                FqName = model.FqName,
                FqTmCout = model.FqTmCout,
                FqTmNo = model.FqTmNo,
            };
        }
    }
}
