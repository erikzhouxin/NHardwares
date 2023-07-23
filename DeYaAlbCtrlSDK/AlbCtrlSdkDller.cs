using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaAlbCtrlSDK
{
    internal class AlbCtrlSdkDllerX86 : IAlbCtrlSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IAlbCtrlSdkProxy Instance { get; } = new AlbCtrlSdkDllerX86();
        private AlbCtrlSdkDllerX86() { }
        /*
        * 功能：打开并连接设备
        * 参数：string pcIP
        *      使用网络和栏杆机通讯时，参数为栏杆机控制器的IP地址字符串
        *      使用串口时，为连接栏杆机控制器串口的串口号字符串（例："COM3"）
        * 返回：IntPtr类型
        *      启动成功时返回设备句柄 IntPtr
        *      启动失败返回NULL 
        */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_Open", CallingConvention = CallingConvention.Winapi)]
        public static extern System.IntPtr DEV_Open([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);
        /*
         * 功能：关闭设备连接
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_Close", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_Close(System.IntPtr hSDK);
        /*
         * 功能：道闸机栏杆控制
         * 参数：Intptr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      bool bOpen
         *      控制栏杆指令，true为发栏杆起杆指令，false为控制栏杆落杆指令
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_ALB_Ctrl", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_ALB_Ctrl(System.IntPtr hSDK, bool bOpen);
        /*
         * 功能：设置道闸机状态改变时的处理事件
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      pCallBack
         *      处理事件委托，具体见 DEVEventCallBack 定义
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_SetEventHandle", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_SetEventHandle(System.IntPtr hSDK, DEVEventCallBack pCallBack);

        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_EnableEventMessageEx", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID);
        /*
         * 功能：获取道闸机状态
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      uint dwStatus
         *      需要转化为32位二进制形式进行解析
         * 返回：BOOl类型，成功返回true,失败返回false
         * 设备状态描述：
         *      Bit位数(从右往左)    状态值(转Int后)   状态含义
         *      --------------------------------------------------------
         *      bit0 - bit3        0                未知状态
         *                         1                落杆中
         *                         2                落至水平位置
         *                         3                抬杆中
         *                         4                抬至竖直位置
         *      --------------------------------------------------------
         *      bit4               0                前线圈(抓拍线圈)无车
         *                         1                前线圈(抓拍线圈)有车
         *      --------------------------------------------------------
         *      bit5               0                后线圈(栏杆线圈)无车
         *                         1                后线圈(栏杆线圈)有车
         *      --------------------------------------------------------
         *      bit6               0                设备离线
         *                         1                设备在线
         *      --------------------------------------------------------
         *      bit7 - bit31                        预留位置
         */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_GetStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_GetStatus(System.IntPtr hSDK, out uint dwStatus);
        /*
         * 功能：获取道闸机故障码
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      out long nErroMsg
         *      设备故障码(使用int类型接收，将其转化为二进制格式,判断前五位状态)
         * 返回：BOOl类型，成功返回true,失败返回false
         * 故障代码对应表：
         *      故障位数        故障说明
         *      -------------------------------------------------------
         *      bit0           角度传感器远大于正常范围置1，否则为 0
         *      -------------------------------------------------------
         *      bit1           角度传感器远小于正常范围置1，否则为 0
         *      -------------------------------------------------------
         *      bit2           角度传感器在抬落杆过程中无变化置1，否则为 0
         *      -------------------------------------------------------
         *      bit3           抬杆到位接近开关故障置1，否则为 0
         *      -------------------------------------------------------
         *      bit4           落杆到位接近开关故障置1，否则为 0
         *      -------------------------------------------------------
         *      bit5 - bit32   保留
         * 注：在状态改变回调函数中，状态参数为4时调用，获取故障码
         */
        //[Obsolete("替代方案:[DEV_GetStatus]此方法已弃用去除")]
        //[DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_GetFaultBits", CallingConvention = CallingConvention.Winapi)]
        //public static extern bool DEV_GetFaultBits(System.IntPtr hSDK, int nErroMsg);
        /*
         * 功能：打开/关闭日志记录
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      bool nEnable
         *      是否打开,true打开，false关闭
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_EnableLog", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_EnableLog(System.IntPtr hSDK, bool nEnable);
        /*
         * 功能：设置日志保存路径
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      string logPath
         *      日志路径字符串，只到文件夹，不用指定文件名称
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_SetLogPath", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_SetLogPath(System.IntPtr hSDK, string logPath);
        /*
         * 功能：获取道闸机版本
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      out long nVersion
         *      设备版本号(使用long类型接收，将其转化为二进制格式，按照8位对照ascii码格式获取版本号)
         * 返回：BOOl类型，成功返回true,失败返回false
         * 版本号示例：
         *      3.2.3
         * 获取long类型值：
         *      219818372659
         * 转化为64位二进制：
         *    00000000 00000000 00000000 00110011 00101110 00110010 00101110 00110011
         * 按照每8位转化为整数:
         *           0        0        0       51       46       50       46       51
         * 对应ASCII码：
         *                                      3        .        2        .        3
         */
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_GetVersion", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_GetVersion(System.IntPtr hSDK, out long nVersion);
        /// <summary>
        /// 启用队列
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bOpen">True启用,False关闭</param>
        /// <returns></returns>
        [DllImport(AlbCtrlSdk.DllFileNameX86, EntryPoint = "DEV_Queue", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_Queue(IntPtr h, Boolean bOpen);
        #region // 显示实现
        IntPtr IAlbCtrlSdkProxy.DEV_Open(string strIP) => DEV_Open(strIP);
        bool IAlbCtrlSdkProxy.DEV_Close(IntPtr h) => DEV_Close(h);
        bool IAlbCtrlSdkProxy.DEV_ALB_Ctrl(IntPtr h, bool bOpen) => DEV_ALB_Ctrl(h, bOpen);
        bool IAlbCtrlSdkProxy.DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback) => DEV_SetEventHandle(h, pCallback);
        bool IAlbCtrlSdkProxy.DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID) => DEV_EnableEventMessageEx(h, hWnd, MsgID);
        bool IAlbCtrlSdkProxy.DEV_GetStatus(IntPtr h, out uint dwStatus) => DEV_GetStatus(h, out dwStatus);
        bool IAlbCtrlSdkProxy.DEV_GetFaultBits(IntPtr h, int dwFaultBits) => throw new NotSupportedException("替代方案:[DEV_GetStatus]此方法已弃用去除");
        bool IAlbCtrlSdkProxy.DEV_EnableLog(IntPtr h, bool bEnable) => DEV_EnableLog(h, bEnable);
        bool IAlbCtrlSdkProxy.DEV_SetLogPath(IntPtr h, string Path) => DEV_SetLogPath(h, Path);
        bool IAlbCtrlSdkProxy.DEV_GetVersion(IntPtr h, out long Version) => DEV_GetVersion(h, out Version);
        bool IAlbCtrlSdkProxy.DEV_Queue(IntPtr h, bool bOpen) => DEV_Queue(h, bOpen);
        #endregion
    }
    internal class AlbCtrlSdkDllerX64 : IAlbCtrlSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IAlbCtrlSdkProxy Instance { get; } = new AlbCtrlSdkDllerX64();
        private AlbCtrlSdkDllerX64() { }
        /*
        * 功能：打开并连接设备
        * 参数：string pcIP
        *      使用网络和栏杆机通讯时，参数为栏杆机控制器的IP地址字符串
        *      使用串口时，为连接栏杆机控制器串口的串口号字符串（例："COM3"）
        * 返回：IntPtr类型
        *      启动成功时返回设备句柄 IntPtr
        *      启动失败返回NULL 
        */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_Open", CallingConvention = CallingConvention.Winapi)]
        public static extern System.IntPtr DEV_Open([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);
        /*
         * 功能：关闭设备连接
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_Close", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_Close(System.IntPtr hSDK);
        /*
         * 功能：道闸机栏杆控制
         * 参数：Intptr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      bool bOpen
         *      控制栏杆指令，true为发栏杆起杆指令，false为控制栏杆落杆指令
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_ALB_Ctrl", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_ALB_Ctrl(System.IntPtr hSDK, bool bOpen);
        /*
         * 功能：设置道闸机状态改变时的处理事件
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      pCallBack
         *      处理事件委托，具体见 DEVEventCallBack 定义
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_SetEventHandle", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_SetEventHandle(System.IntPtr hSDK, DEVEventCallBack pCallBack);

        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_EnableEventMessageEx", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID);
        /*
         * 功能：获取道闸机状态
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      uint dwStatus
         *      需要转化为32位二进制形式进行解析
         * 返回：BOOl类型，成功返回true,失败返回false
         * 设备状态描述：
         *      Bit位数(从右往左)    状态值(转Int后)   状态含义
         *      --------------------------------------------------------
         *      bit0 - bit3        0                未知状态
         *                         1                落杆中
         *                         2                落至水平位置
         *                         3                抬杆中
         *                         4                抬至竖直位置
         *      --------------------------------------------------------
         *      bit4               0                前线圈(抓拍线圈)无车
         *                         1                前线圈(抓拍线圈)有车
         *      --------------------------------------------------------
         *      bit5               0                后线圈(栏杆线圈)无车
         *                         1                后线圈(栏杆线圈)有车
         *      --------------------------------------------------------
         *      bit6               0                设备离线
         *                         1                设备在线
         *      --------------------------------------------------------
         *      bit7 - bit31                        预留位置
         */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_GetStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_GetStatus(System.IntPtr hSDK, out uint dwStatus);
        /*
         * 功能：获取道闸机故障码
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      out long nErroMsg
         *      设备故障码(使用int类型接收，将其转化为二进制格式,判断前五位状态)
         * 返回：BOOl类型，成功返回true,失败返回false
         * 故障代码对应表：
         *      故障位数        故障说明
         *      -------------------------------------------------------
         *      bit0           角度传感器远大于正常范围置1，否则为 0
         *      -------------------------------------------------------
         *      bit1           角度传感器远小于正常范围置1，否则为 0
         *      -------------------------------------------------------
         *      bit2           角度传感器在抬落杆过程中无变化置1，否则为 0
         *      -------------------------------------------------------
         *      bit3           抬杆到位接近开关故障置1，否则为 0
         *      -------------------------------------------------------
         *      bit4           落杆到位接近开关故障置1，否则为 0
         *      -------------------------------------------------------
         *      bit5 - bit32   保留
         * 注：在状态改变回调函数中，状态参数为4时调用，获取故障码
         */
        //[Obsolete("替代方案:[DEV_GetStatus]此方法已弃用去除")]
        //[DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_GetFaultBits", CallingConvention = CallingConvention.Winapi)]
        //public static extern bool DEV_GetFaultBits(System.IntPtr hSDK, int nErroMsg);
        /*
         * 功能：打开/关闭日志记录
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      bool nEnable
         *      是否打开,true打开，false关闭
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_EnableLog", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_EnableLog(System.IntPtr hSDK, bool nEnable);
        /*
         * 功能：设置日志保存路径
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      string logPath
         *      日志路径字符串，只到文件夹，不用指定文件名称
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_SetLogPath", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_SetLogPath(System.IntPtr hSDK, string logPath);
        /*
         * 功能：获取道闸机版本
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      out long nVersion
         *      设备版本号(使用long类型接收，将其转化为二进制格式，按照8位对照ascii码格式获取版本号)
         * 返回：BOOl类型，成功返回true,失败返回false
         * 版本号示例：
         *      3.2.3
         * 获取long类型值：
         *      219818372659
         * 转化为64位二进制：
         *    00000000 00000000 00000000 00110011 00101110 00110010 00101110 00110011
         * 按照每8位转化为整数:
         *           0        0        0       51       46       50       46       51
         * 对应ASCII码：
         *                                      3        .        2        .        3
         */
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_GetVersion", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_GetVersion(System.IntPtr hSDK, out long nVersion);
        /// <summary>
        /// 启用队列
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bOpen">True启用,False关闭</param>
        /// <returns></returns>
        [DllImport(AlbCtrlSdk.DllFileNameX64, EntryPoint = "DEV_Queue", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_Queue(IntPtr h, Boolean bOpen);
        #region // 显示实现
        IntPtr IAlbCtrlSdkProxy.DEV_Open(string strIP) => DEV_Open(strIP);
        bool IAlbCtrlSdkProxy.DEV_Close(IntPtr h) => DEV_Close(h);
        bool IAlbCtrlSdkProxy.DEV_ALB_Ctrl(IntPtr h, bool bOpen) => DEV_ALB_Ctrl(h, bOpen);
        bool IAlbCtrlSdkProxy.DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback) => DEV_SetEventHandle(h, pCallback);
        bool IAlbCtrlSdkProxy.DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID) => DEV_EnableEventMessageEx(h, hWnd, MsgID);
        bool IAlbCtrlSdkProxy.DEV_GetStatus(IntPtr h, out uint dwStatus) => DEV_GetStatus(h, out dwStatus);
        bool IAlbCtrlSdkProxy.DEV_GetFaultBits(IntPtr h, int dwFaultBits) => throw new NotSupportedException("替代方案:[DEV_GetStatus]此方法已弃用去除");
        bool IAlbCtrlSdkProxy.DEV_EnableLog(IntPtr h, bool bEnable) => DEV_EnableLog(h, bEnable);
        bool IAlbCtrlSdkProxy.DEV_SetLogPath(IntPtr h, string Path) => DEV_SetLogPath(h, Path);
        bool IAlbCtrlSdkProxy.DEV_GetVersion(IntPtr h, out long Version) => DEV_GetVersion(h, out Version);
        bool IAlbCtrlSdkProxy.DEV_Queue(IntPtr h, bool bOpen) => DEV_Queue(h, bOpen);
        #endregion
    }
}
