using System;

namespace System.Data.KangMeiIPGBSDK
{
	/**
	 * 终端工作状态
	 * typedef enum __EM_TMSTA_TYPE 
	 * {
	 *   TMSTA_STA1=0,//空闲
	 *   TMSTA_STA2,//点播文件
	 *   TMSTA_STA3,//接收广播
	 *   TMSTA_STA4,//终端本身发起采播或文件广播
	 *   TMSTA_STA5,//正在对讲
	 *   TMSTA_STA6, //主叫状态
	 *   TMSTA_STA7  //被叫状态
	 * }EM_TMSTA_TYPE;
	 **/
	public enum NETEM_TMSTA_TYPE
	{
		/// <summary>
		/// 被叫状态
		/// </summary>
		TMSTA_STA7 = 6,
		/// <summary>
		/// 主叫状态
		/// </summary>
		TMSTA_STA6 = 5,
		/// <summary>
		/// 正在对讲
		/// </summary>
		TMSTA_STA5 = 4,
		/// <summary>
		/// 终端本身发起采播或文件广播
		/// </summary>
		TMSTA_STA4 = 3,
		/// <summary>
		/// 接收广播
		/// </summary>
		TMSTA_STA3 = 2,
		/// <summary>
		/// 点播文件
		/// </summary>
		TMSTA_STA2 = 1,
		/// <summary>
		/// 空闲
		/// </summary>
		TMSTA_STA1 = 0
	}
}
