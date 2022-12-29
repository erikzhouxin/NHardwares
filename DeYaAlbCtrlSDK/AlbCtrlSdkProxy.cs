using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaAlbCtrlSDK
{
    /// <summary>
    /// 德亚道闸SDK代理
    /// </summary>
    public interface IAlbCtrlSdkProxy
    {
        /// <summary>
        /// 打开并连接设备
        /// </summary>
        /// <param name="strIP">
        /// A.使用网线和栏杆机控制器通信时，strIP 为栏杆机控制器的 IP 地址字符串，
        ///   例如“192.168.1.101”。?pcIP
        /// B.使用串口和栏杆机控制器通信时，strIP 为连接栏杆机控制器的串口号，
        ///   例如使用串口 3 连接栏杆机控制器，则 strIP 为”COM3”，注意大小写。
        /// </param>
        /// <returns>成功：返回设备的句柄。失败：返回 NULL。</returns>
        IntPtr DEV_Open(string strIP);
        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_Close(IntPtr h);
        /// <summary>
        /// 控制设备抬杆或落杆
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bOpen">TRUE 为控制抬杆，FALSE 为控制落杆。</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_ALB_Ctrl(IntPtr h, Boolean bOpen);
        /// <summary>
        /// 注册设备状态变化事件处理函数
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="pCallback">
        /// 设备状态变化事件处理函数指针
        /// (1)设备事件列表
        /// <![CDATA[
        /// nEventId   nParam            说明
        /// 1          BalustradeStatus  栏杆的状态，BalustradeStatus 有以下几种情况：
        ///                              0： 未知状态
        ///                              1： 落杆中
        ///                              2： 落到水平位置
        ///                              3： 抬杆中
        ///                              4： 抬到竖直位置
        /// 2          FCoilStatus       前线圈(抓拍线圈)的状态，FCoilStatus有以下2种情况：
        ///                              0： 线圈无车
        ///                              1： 线圈有车
        /// 3          BCoilStatus       后线圈(栏杆线圈)的状态，BCoilStatus有以下2种情况：
        ///                              0： 线圈无车
        ///                              1： 线圈有车
        /// 4          FaultBits         栏杆机故障标志位（详见DEV_GetFaultBits接口中的描述）
        /// 96                           设备接受连接
        /// 97                           设备拒绝连接
        /// 98                           与设备建立连线
        /// 99                           与设备连线断开
        /// ]]>
        /// (2)此接口和 DEV_EnableEventMessageEx 接口只能 2 选 1，如果都调用的话，
        /// 那么当有事件发生时，动态库使用 DEV_SetEventHandle 接口注册的事件回掉函数通知上位机。
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback);
        /// <summary>
        /// 注册接设备状态变化事件的句柄和消息 ID。
        /// 说明:
        /// (1)上位机收到设备消息时，消息的 wParam 为发生事件的设备句柄（即，调用DEV_Open 返回的句柄）
        /// (2)上位机收到设备消息时，消息的 lParam 为事件编号+事件参数，
        /// 其中 lParam 的低8位（即，Bit0~Bit7）为事件参数，
        /// lParam 的 8 到 16 位为事件编号（即，Bit8~Bit15）
        /// <![CDATA[
        /// (lParam >> 8) & 0xFF              lParam & 0xFF                 说明
        /// 1                                 栏杆状态，有以下几种情况：    栏杆状态变化事件
        ///                                   0：未知状态落杆
        ///                                   1：中落到水平位
        ///                                   2：置抬杆中抬到
        ///                                   3：竖直位置
        ///                                   4：
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 2                                前线圈(抓拍线圈)状态，        前线圈(抓拍线圈)状态变化事件
        ///                                  有以下 2 种情况：
        ///                                  0： 线圈无车
        ///                                  1： 线圈有车
        /// 3                                后线圈(栏杆线圈)状态，        后线圈(栏杆线圈)状态变化事件
        ///                                  有以下 2 种情况：
        ///                                  0： 线圈无车
        ///                                  1： 线圈有车
        /// 4                                栏杆机故障标志位（详见
        ///                                  DEV_GetFaultBits接口中的描述）栏杆机故障位变化事件
        /// 96                               无                            设备接受连接事件
        /// 97                               无                            设备拒绝连接事件
        /// 98                               无                            与设备建立连线事件
        /// 99                               无                            与设备连线断开事件
        /// ]]>
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="hWnd">用于接收设备消息的窗口句柄</param>
        /// <param name="MsgID">设备消息编号</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID);
        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="dwStatus">
        /// 用于存放设备状态的变量地址
        /// dwStatus 为 4 字节（32 位）的变量地址，设备状态描述如下
        /// <![CDATA[
        /// bit              含义
        /// bit0 ~bit3       栏杆机状态：
        ///                  0： 未知状态
        ///                  1： 落杆中
        ///                  2： 落到水平位置
        ///                  3： 抬杆中
        ///                  4： 抬到竖直位置
        /// bit4             前线圈(抓拍线圈)状态: 
        ///                  0： 线圈无车
        ///                  1： 线圈有车
        /// bit5             后线圈(栏杆线圈)状态：
        ///                  0： 线圈无车
        ///                  1： 线圈有车
        /// bit6             设备在线状态：
        ///                  0：设备离线
        ///                  1：设备在线
        /// bit7 ~bit31      保留
        /// ]]>
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_GetStatus(IntPtr h, out uint dwStatus);
        /// <summary>
        /// 获取设备故障位
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="dwFaultBits">
        /// 用于存放设备故障位的变量地址
        /// dwFaultBits 为 4 字节（32 位）的变量地址，设备故障位描述如下
        /// <![CDATA[
        /// bit          含义
        /// bit0         角度传感器远大于正常范围置 1，否则为 0
        /// bit1         角度传感器远小于正常范围置 1，否则为 0
        /// bit2         角度传感器在抬落杆过程中无变化置 1，否则为 0
        /// bit3         抬杆到位接近开关故障置 1，否则为 0
        /// bit4         落杆到位接近开关故障置 1，否则为 0
        /// bit5 ~bit31  保留
        /// ]]>
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        [Obsolete("替代方案:[DEV_GetStatus]此方法已弃用去除")]
        Boolean DEV_GetFaultBits(IntPtr h, int dwFaultBits);
        /// <summary>
        /// 打开/关闭日志记录
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bEnable">打开或关闭日志</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_EnableLog(IntPtr h, Boolean bEnable);
        /// <summary>
        /// 设置日志路径
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="Path">日志路径字符串，只到文件夹，不用指定文件名称</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_SetLogPath(IntPtr h, String Path);
        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="Version">
        /// 用于存放控制器版本号的地址
        /// 设备版本号(使用long类型接收，将其转化为二进制格式，按照8位对照ascii码格式获取版本号)
        /// <![CDATA[
        /// 版本号示例：
        ///      3.2.3
        /// 获取long类型值：
        ///      219818372659
        /// 转化为64位二进制：
        ///    00000000 00000000 00000000 00110011 00101110 00110010 00101110 00110011
        /// 按照每8位转化为整数:
        ///           0        0        0       51       46       50       46       51
        /// 对应ASCII码：
        ///                                      3        .        2        .        3
        /// ]]>
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_GetVersion(IntPtr h, out long Version);
        /// <summary>
        /// 启用队列
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bOpen">TRUE 为启用，FALSE 为关闭。</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_Queue(IntPtr h, Boolean bOpen);
    }

    internal class AlbCtrlSdkDller : IAlbCtrlSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IAlbCtrlSdkProxy Instance { get; } = new AlbCtrlSdkDller();
        private AlbCtrlSdkDller() { }
        /*
        * 功能：打开并连接设备
        * 参数：string pcIP
        *      使用网络和栏杆机通讯时，参数为栏杆机控制器的IP地址字符串
        *      使用串口时，为连接栏杆机控制器串口的串口号字符串（例："COM3"）
        * 返回：IntPtr类型
        *      启动成功时返回设备句柄 IntPtr
        *      启动失败返回NULL 
        */
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_Open", CallingConvention = CallingConvention.Winapi)]
        public static extern System.IntPtr DEV_Open([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);
        /*
         * 功能：关闭设备连接
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_Close", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_Close(System.IntPtr hSDK);
        /*
         * 功能：道闸机栏杆控制
         * 参数：Intptr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      bool bOpen
         *      控制栏杆指令，true为发栏杆起杆指令，false为控制栏杆落杆指令
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_ALB_Ctrl", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_ALB_Ctrl(System.IntPtr hSDK, bool bOpen);
        /*
         * 功能：设置道闸机状态改变时的处理事件
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      pCallBack
         *      处理事件委托，具体见 DEVEventCallBack 定义
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_SetEventHandle", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_SetEventHandle(System.IntPtr hSDK, DEVEventCallBack pCallBack);

        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_EnableEventMessageEx", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
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
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_GetStatus", CallingConvention = CallingConvention.Winapi)]
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
        //[DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_GetFaultBits", CallingConvention = CallingConvention.Winapi)]
        //public static extern bool DEV_GetFaultBits(System.IntPtr hSDK, int nErroMsg);
        /*
         * 功能：打开/关闭日志记录
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      bool nEnable
         *      是否打开,true打开，false关闭
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_EnableLog", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_EnableLog(System.IntPtr hSDK, bool nEnable);
        /*
         * 功能：设置日志保存路径
         * 参数：IntPtr hSDK
         *      设备句柄，即在调用DEV_Open时返回的句柄
         *      string logPath
         *      日志路径字符串，只到文件夹，不用指定文件名称
         * 返回：BOOl类型，成功返回true,失败返回false
         */
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_SetLogPath", CallingConvention = CallingConvention.Winapi)]
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
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_GetVersion", CallingConvention = CallingConvention.Winapi)]
        public static extern bool DEV_GetVersion(System.IntPtr hSDK, out long nVersion);
        /// <summary>
        /// 启用队列
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bOpen">True启用,False关闭</param>
        /// <returns></returns>
        [DllImport(AlbCtrlSdk.DllFileName, EntryPoint = "DEV_Queue", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
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
    internal class AlbCtrlSdkLoader : ASdkDynamicLoader, IAlbCtrlSdkProxy
    {
        #region // 委托定义        
        private DCreater.DEV_Open _DEV_Open;
        private DCreater.DEV_Close _DEV_Close;
        private DCreater.DEV_ALB_Ctrl _DEV_ALB_Ctrl;
        private DCreater.DEV_SetEventHandle _DEV_SetEventHandle;
        private DCreater.DEV_EnableEventMessageEx _DEV_EnableEventMessageEx;
        private DCreater.DEV_GetStatus _DEV_GetStatus;
        //private DCreater.DEV_GetFaultBits _DEV_GetFaultBits;
        private DCreater.DEV_EnableLog _DEV_EnableLog;
        private DCreater.DEV_SetLogPath _DEV_SetLogPath;
        private DCreater.DEV_GetVersion _DEV_GetVersion;
        private DCreater.DEV_Queue _DEV_Queue;
        #endregion
        public AlbCtrlSdkLoader()
        {
            _DEV_Open = GetDelegate<DCreater.DEV_Open>(nameof(DCreater.DEV_Open));
            _DEV_Close = GetDelegate<DCreater.DEV_Close>(nameof(DCreater.DEV_Close));
            _DEV_ALB_Ctrl = GetDelegate<DCreater.DEV_ALB_Ctrl>(nameof(DCreater.DEV_ALB_Ctrl));
            _DEV_SetEventHandle = GetDelegate<DCreater.DEV_SetEventHandle>(nameof(DCreater.DEV_SetEventHandle));
            _DEV_EnableEventMessageEx = GetDelegate<DCreater.DEV_EnableEventMessageEx>(nameof(DCreater.DEV_EnableEventMessageEx));
            _DEV_GetStatus = GetDelegate<DCreater.DEV_GetStatus>(nameof(DCreater.DEV_GetStatus));
            //_DEV_GetFaultBits = GetDelegate<DCreater.DEV_GetFaultBits>(nameof(DCreater.DEV_GetFaultBits));
            _DEV_EnableLog = GetDelegate<DCreater.DEV_EnableLog>(nameof(DCreater.DEV_EnableLog));
            _DEV_SetLogPath = GetDelegate<DCreater.DEV_SetLogPath>(nameof(DCreater.DEV_SetLogPath));
            _DEV_GetVersion = GetDelegate<DCreater.DEV_GetVersion>(nameof(DCreater.DEV_GetVersion));
            _DEV_Queue = GetDelegate<DCreater.DEV_Queue>(nameof(DCreater.DEV_Queue));
        }
        public override string GetFileFullName()
        {
            return AlbCtrlSdk.DllFullName;
        }
        #region // 显示实现
        IntPtr IAlbCtrlSdkProxy.DEV_Open(string strIP) => _DEV_Open.Invoke(strIP);
        bool IAlbCtrlSdkProxy.DEV_Close(IntPtr h) => _DEV_Close.Invoke(h);
        bool IAlbCtrlSdkProxy.DEV_ALB_Ctrl(IntPtr h, bool bOpen) => _DEV_ALB_Ctrl.Invoke(h, bOpen);
        bool IAlbCtrlSdkProxy.DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback) => _DEV_SetEventHandle.Invoke(h, pCallback);
        bool IAlbCtrlSdkProxy.DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID) => _DEV_EnableEventMessageEx.Invoke(h, hWnd, MsgID);
        bool IAlbCtrlSdkProxy.DEV_GetStatus(IntPtr h, out uint dwStatus) => _DEV_GetStatus.Invoke(h, out dwStatus);
        bool IAlbCtrlSdkProxy.DEV_GetFaultBits(IntPtr h, int dwFaultBits) => throw new NotSupportedException("替代方案:[DEV_GetStatus]此方法已弃用去除");
        bool IAlbCtrlSdkProxy.DEV_EnableLog(IntPtr h, bool bEnable) => _DEV_EnableLog.Invoke(h, bEnable);
        bool IAlbCtrlSdkProxy.DEV_SetLogPath(IntPtr h, string Path) => _DEV_SetLogPath.Invoke(h, Path);
        bool IAlbCtrlSdkProxy.DEV_GetVersion(IntPtr h, out long Version) => _DEV_GetVersion.Invoke(h, out Version);
        bool IAlbCtrlSdkProxy.DEV_Queue(IntPtr h, bool bOpen) => _DEV_Queue.Invoke(h, bOpen);
        #endregion
    }
}
