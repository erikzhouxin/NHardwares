using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * SDK登陆信息
     * typedef struct  
     * {
     *   char UserName[IPGB_MAX_USERNAME_LEN];//登录用户名
     *   char UPass[IPGB_MAX_USERPASS_LEN];   //登录密码
     *   char SIp[IPGB_MAX_IPADR_LEN];        //服务器IP
     *   char Sdomain[IPGB_MAX_DOMAIN_LEN];   //服务器域名
     *   WORD SCmdport;                      //服务器命令端口
     *   WORD LogType;                       //0:使用IP登录;1:使用域名登陆
     * }IPGBSDK_LOGSERVER,*LPIPGBSDK_LOGSERVER;
     **/
    public struct IPGBSDK_LOGSERVER
    {
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName;
        /// <summary>
        /// 登录密码
        /// </summary>
        public string UPass;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string SIp;
        /// <summary>
        /// 服务器域名
        /// </summary>
        public string Sdomain;
        /// <summary>
        /// 服务器命令端口
        /// </summary>
        public ushort SCmdport;
        /// <summary>
        /// 0:使用IP登录;1:使用域名登陆
        /// </summary>
        public ushort LogType;
    }
    /// <summary>
    /// SDK登陆信息
    /// </summary>
    public class NETAVHSDK_LOGSERVER
    {
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName;
        /// <summary>
        /// 登录密码
        /// </summary>
        public string UPass;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string SIp;
        /// <summary>
        /// 服务器域名
        /// </summary>
        public string Sdomain;
        /// <summary>
        /// 服务器命令端口
        /// </summary>
        public ushort SCmdport;
        /// <summary>
        /// 0:使用IP登录;1:使用域名登陆
        /// </summary>
        public ushort LogType;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_LOGSERVER(IPGBSDK_LOGSERVER model)
        {
            return new NETAVHSDK_LOGSERVER()
            {
                UserName = model.UserName,
                UPass = model.UPass,
                SIp = model.SIp,
                Sdomain = model.Sdomain,
                SCmdport = model.SCmdport,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_LOGSERVER(NETAVHSDK_LOGSERVER model)
        {
            return new IPGBSDK_LOGSERVER()
            {
                UserName = model.UserName,
                UPass = model.UPass,
                SIp = model.SIp,
                Sdomain = model.Sdomain,
                SCmdport = model.SCmdport,
            };
        }
    }
}
