using System;
using System.Linq;

namespace System.Data.KangMeiIPGBSDK
{
    /**
	 * 用户信息(SDK支持多用户多服务器登陆)
	 * typedef struct
	 * {
	 *     WORD  UserID;    //此用户的ID
	 *     WORD  Userlevel;//用户的权限
	 *     WORD  TmCout;//用户可以控制终端个数
	 *     IPGBSDK_TMINFO m_OneTm[IPGB_MAX_SDKTMCOUT]; //用户当前控制终端数组列表
	 *     WORD  EncTmCout;//用户可以控制编码终端个数
	 *     IPGBSDK_ENCTMINFO  m_oneEncTm[IPGB_MAX_SDKENCTMCOUT]; //用户当前控制编码终端数组列表
	 *     }IPGBSDK_USERINFO,*LPIPGBSDK_USERINFO;
	 **/
    public struct IPGBSDK_USERINFO
    {
        /// <summary>
        /// 此用户的ID
        /// </summary>
        public uint UserID;
        /// <summary>
        /// 用户的权限
        /// </summary>
        public uint Userlevel;
        /// <summary>
        /// 用户可以控制终端个数
        /// </summary>
        public uint TmCout;
        /// <summary>
        /// 用户当前控制终端数组列表
        /// </summary>
        public IPGBSDK_TMINFO[] m_OneTm;
        /// <summary>
        /// 用户可以控制编码终端个数
        /// </summary>
        public uint EncTmCout;
        /// <summary>
        /// 用户当前控制编码终端数组列表
        /// </summary>
        public IPGBSDK_TMINFO[] m_oneEncTm;
    }
    /// <summary>
    /// 用户信息(SDK支持多用户多服务器登陆)
    /// </summary>
    public class NETAVHSDK_USERINFO
    {
        /// <summary>
        /// 此用户的ID
        /// </summary>
        public uint UserID;
        /// <summary>
        /// 用户的权限
        /// </summary>
        public uint Userlevel;
        /// <summary>
        /// 用户可以控制终端个数
        /// </summary>
        public uint TmCout;
        /// <summary>
        /// 用户当前控制终端数组列表
        /// </summary>
        public NETAVHSDK_TMINFO[] m_OneTm;
        /// <summary>
        /// 用户可以控制编码终端个数
        /// </summary>
        public uint EncTmCout;
        /// <summary>
        /// 用户当前控制编码终端数组列表
        /// </summary>
        public NETAVHSDK_TMINFO[] m_oneEncTm;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="userInfo"></param>
        public static implicit operator NETAVHSDK_USERINFO(IPGBSDK_USERINFO userInfo)
        {
            return new NETAVHSDK_USERINFO
            {
                UserID = userInfo.UserID,
                Userlevel = userInfo.Userlevel,
                TmCout = userInfo.TmCout,
                m_OneTm = userInfo.m_OneTm.SelectArray(s => (NETAVHSDK_TMINFO)s),
                EncTmCout = userInfo.EncTmCout,
                m_oneEncTm = userInfo.m_oneEncTm.SelectArray(s => (NETAVHSDK_TMINFO)s)
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="userInfo"></param>
        public static implicit operator IPGBSDK_USERINFO(NETAVHSDK_USERINFO userInfo)
        {
            return new IPGBSDK_USERINFO
            {
                UserID = userInfo.UserID,
                Userlevel = userInfo.Userlevel,
                TmCout = userInfo.TmCout,
                m_OneTm = userInfo.m_OneTm.SelectArray(s => (IPGBSDK_TMINFO)s),
                EncTmCout = userInfo.EncTmCout,
                m_oneEncTm = userInfo.m_oneEncTm.SelectArray(s => (IPGBSDK_TMINFO)s)
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_USERINFO SetModel(IPGBSDK_USERINFO model)
        {
            this.UserID = model.UserID;
            this.Userlevel = model.Userlevel;
            this.TmCout = model.TmCout;
            this.m_OneTm = model.m_OneTm.SelectArray(s => (NETAVHSDK_TMINFO)s);
            this.EncTmCout = model.EncTmCout;
            this.m_oneEncTm = model.m_oneEncTm.SelectArray(s => (NETAVHSDK_TMINFO)s);
            return this;
        }
    }
}
