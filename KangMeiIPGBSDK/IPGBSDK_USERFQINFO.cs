using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 用户终端分区信息
     * typedef struct  
     * {
     *      WORD  FqCout;//用户可以控制的终端分区个数据
     *      IPGBSDK_ONEFQINFO  m_OneFq[IPGB_MAX_SDKFQCOUT];//用户可以控制的分区数组信息
     * }IPGBSDK_USERFQINFO,*LPIPGBSDK_USERFQINFO;
     **/
    public struct IPGBSDK_USERFQINFO
    {
        /// <summary>
        /// 用户可以控制的终端分区个数据
        /// </summary>
        public uint FqCout;
        /// <summary>
        /// 用户可以控制的分区数组信息
        /// </summary>
        public IPGBSDK_ONEFQINFO[] m_OneFq;
    }
    /// <summary>
    /// 用户终端分区信息
    /// </summary>
    public class NETAVHSDK_USERFQINFO
    {
        /// <summary>
        /// 用户可以控制的终端分区个数据
        /// </summary>
        public uint FqCout;
        /// <summary>
        /// 用户可以控制的分区数组信息
        /// </summary>
        public NETAVHSDK_ONEFQINFO[] m_OneFq;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_USERFQINFO(NETAVHSDK_USERFQINFO model)
        {
            return new IPGBSDK_USERFQINFO()
            {
                FqCout = model.FqCout,
                m_OneFq = model.m_OneFq.SelectArray(s => (IPGBSDK_ONEFQINFO)s)
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_USERFQINFO(IPGBSDK_USERFQINFO model)
        {
            return new NETAVHSDK_USERFQINFO()
            {
                FqCout = model.FqCout,
                m_OneFq = model.m_OneFq.SelectArray(s => (NETAVHSDK_ONEFQINFO)s),
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_USERFQINFO SetModel(IPGBSDK_USERFQINFO model)
        {
            FqCout = model.FqCout;
            m_OneFq = model.m_OneFq.SelectArray(s => (NETAVHSDK_ONEFQINFO)s);
            return this;
        }
    }
}
