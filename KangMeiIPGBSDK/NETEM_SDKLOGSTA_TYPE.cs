using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
	* 登录状态类型
	* typedef enum __EM_SDKLOGSTA_TYPE
	* {
	* 	LOG_OK = 0,   //登录成功
	* 	LOG_ING, //正在登录中
	* 	LOG_NOBACK, //服务器没回应，超时
	* 	LOG_USER_ERR1,//用户名和密码出错误
	* 	LOG_USER_ERR2, //此用户已在服务器上登陆
	* 	LOG_USER_ERR3,//无此用户ID
	* 	LOG_ANY_ERROR //其它错误
	* }EM_SDKLOGSTA_TYPE;
	**/
    public enum NETEM_SDKLOGSTA_TYPE
    {
		/// <summary>
		/// 其它错误
		/// </summary>
		LOG_ANY_ERROR = 6,
		/// <summary>
		/// 无此用户ID
		/// </summary>
		LOG_USER_ERR3 = 5,
		/// <summary>
		/// 此用户已在服务器上登陆
		/// </summary>
		LOG_USER_ERR2 = 4,
		/// <summary>
		/// 用户名和密码出错误
		/// </summary>
		LOG_USER_ERR1 = 3,
		/// <summary>
		/// 服务器没回应，超时
		/// </summary>
		LOG_NOBACK = 2,
		/// <summary>
		/// 正在登录中
		/// </summary>
		LOG_ING = 1,
		/// <summary>
		/// 登录成功
		/// </summary>
		LOG_OK = 0
    }
}
