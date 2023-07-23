using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    internal class IceIpcSdkDllerX86 : IIceIpcSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IIceIpcSdkProxy Instance { get; } = new IceIpcSdkDllerX86();
        private IceIpcSdkDllerX86() { }
        /**
         *  @brief  设置获得实时识别数据的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPlate  实时识别数据，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetPlateCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam);

        /**
         *  @brief  设置获得断网识别数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPastPlate      断网识别数据，通过该回调获得
         *  @param  [IN] pvPastPlateParam   回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetPastPlateCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate,
                                                                  IntPtr pvPastPlateParam);

        /**
         *  @brief  设置获得RS485数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS485数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetSerialPortCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort,
                                                                   IntPtr pvSerialPortParam);

        /**
         *  @brief  设置获得RS232数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS232数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetSerialPortCallBack_RS232", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort,
                                                                         IntPtr pvSerialPortParam);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetDeviceEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam);

        /**
        *  @brief  设置相机对讲状态变化回调事件
        *  @param  [IN] hSDK                     连接相机时返回的sdk句柄
        *  @param  [IN] pfOnIOEvent              对讲事件回调
        *  @param  [IN] pvIOEventParam           对讲事件回调参数,用于区分不同对讲变化事件
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetTalkEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam);

        /**
         *  @brief  设置获得解码出的一帧图像的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnFrame  解码出的一帧图像，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetFrameCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam);

        /**
         *  @brief  全局初始化
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Init();

        /**
         *  @brief  全局释放
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Fini", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Fini();

        /**
         *  @brief  连接相机并接入视频（推荐使用）
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_OpenPreview", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenPreview(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  使用密码连接相机并接入视频
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_OpenPreview_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenPreview_Passwd(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
            byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  连接相机，不带视频流
         *  @param  [IN] pcIP   相机ip
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_OpenDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenDevice([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);

        /**
         *  @brief  使用密码连接相机，不带视频流
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_OpenDevice_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenDevice_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd);

        /**
         *  @brief  连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Open", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_Open(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort,
            ushort u16OnvifPort, byte u8MainStream, uint pfOnStream,
            IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  使用密码连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Open_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_Open_Passwd(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
            byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream,
            uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  断开连接
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Close(IntPtr hSDK);

        /**
         *  @brief  连接视频
         *  @param  [IN] hSDK           连接相机时返回的句柄值
         *  @param  [IN] u8MainStream   是否请求主码流（1：主码流 0：子码流）
         *  @param  [IN] hWnd           预览视频的窗口句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_StartStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd);

        /**
         *  @brief  断开视频
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_StopStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_StopStream(IntPtr hSDK);

        /**
         *  @brief   打开道闸
         *  @param   [IN] hSDK 由连接相机接口获得的句柄
         *  @return  1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_OpenGate", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_OpenGate(IntPtr hSDK);

        /**
         *  @brief   控制开关量输出
         *  @param   [IN] hSDK      由连接相机接口获得的句柄
         *  @param   [IN] u32Index  控制的IO口(0:表示IO1 1:表示IO2)
         *  @return  1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_ControlAlarmOut", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  获取开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [OUT] pu32IdleState   常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [OUT] pu32DelayTime   切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [OUT] pu32Reserve     预留参数
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetAlarmOutConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState,
                                                                ref uint pu32DelayTime, ref uint pu32Reserve);

        /**
         *  @brief  设置开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [IN] pu32IdleState    常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [IN] pu32DelayTime    切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [IN] pu32Reserve      预留参数
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetAlarmOutConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState,
                                                                uint u32DelayTime, uint u32Reserve);
        /**
         *  @brief  开始对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_BeginTalk", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BeginTalk(IntPtr hSDK);

        /**
         *  @brief  结束对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_EndTalk", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_EndTalk(IntPtr hSDK);

        /**
         *  @brief  软触发
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcNumber      车牌号
         *  @param  [OUT] pcColor       车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Trigger", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor,
                                                    byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  软触发扩展接口
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_TriggerExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_TriggerExt(IntPtr hSDK);

        /**
         *  @brief  手动抓拍，不做识别，直接抓拍一张码流的图片
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Capture", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  获取相机连接状态
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示在线，0表示离线
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetStatus(IntPtr hSDK);

        /**
         *  @brief  重启相机
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Reboot", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Reboot(IntPtr hSDK);

        /**
         *  @brief  时间同步
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @param  [IN] u16Year    年
         *  @param  [IN] u8Month    月
         *  @param  [IN] u8Day      日
         *  @param  [IN] u8Hour     时
         *  @param  [IN] u8Min      分
         *  @param  [IN] u8Sec      秒
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SyncTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day,
                                                        byte u8Hour, byte u8Min, byte u8Sec);

        /**
         *  @brief  发送RS485串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS485串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_TransSerialPort", CallingConvention = CallingConvention.Cdecl)]
        //public static extern uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, String pcData, uint u32Len);
        public static extern uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  发送RS232串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS232串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_TransSerialPort_RS232", CallingConvention = CallingConvention.Cdecl)]
        //public static extern uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, string pcData, uint u32Len);
        public static extern uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  获取相机mac地址
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [OUT] szDevID  相机mac地址
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetDevID", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID);

        /**
         *  @brief  开始录像
         *  @param  [IN] hSDK        由连接相机接口获得的句柄
         *  @param  [IN] pcFileName  保存录像的文件名
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_StartRecord", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_StartRecord(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcFileName);

        /**
         *  @brief  结束录像
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_StopRecord", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_StopRecord(IntPtr hSDK);

        /**
         *  @brief  设置OSD参数
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pstOSDAttr OSD参数结构体地址，详见ICE_OSDAttr_S
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetOSDCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr);

        /**
         *  @brief  写入用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_WriteUserData", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_WriteUserData(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData);

        /**
         *  @brief  读取用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_ReadUserData", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize);

        /**
         *  @brief  写入二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @parame [IN] nOffset    偏移量
         *  @parame [IN] nLen       写入数据的长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_WriteUserData_Binary", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData,
            uint nOffset, uint nLen);

        /**
         *  @brief  读取二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @param  [IN] nOffset    读数据的偏移量
         *  @param  [IN] nLen       需要读出的数据的大小
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_ReadUserData_Binary", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData,
                                                                 uint nSize, uint nOffset, uint nLen);
        /**
         *  @brief  获取相机网络参数
         *  @param  [IN] hSDK          由连接相机接口获得的句柄
         *  @parame [OUT] pu32IP       相机ip
         *  @param  [OUT] pu32Mask     相机掩码
         *  @param  [OUT] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetIPAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway);

        /**
         *  @brief  设置相机网络参数
         *  @param  [IN] hSDK         由连接相机接口获得的句柄
         *  @parame [IN] pu32IP       相机ip
         *  @param  [IN] pu32Mask     相机掩码
         *  @param  [IN] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetIPAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway);

        /**
         *  @brief  搜索区域网内相机
         *  @param  [OUT] szDevs   设备mac地址和ip地址的字符串
         *                         设备mac地址和ip地址的字符串，格式为：mac地址 ip地址 例如：00-00-00-00-00-00 192.168.55.150\r\n
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SearchDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SearchDev(StringBuilder szDevs);

        /**
         *  @brief  记录日志配置
         *  @param  [IN] openLog    是否开启日志，0：不开启 1：开启
         *  @parame [IN] logPath    日志路径，默认为D:\
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_LogConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_LogConfig(int openLog, string logPath);

        /**
         *  @brief  语音播放，单条语音
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_Broadcast", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex);

        /**
         *  @brief  语音组播
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    包含语音序号的字符串  注：中间可以用, ; \t \n或者空格分开；如：1 2 3 4或者1,2,3,4
         *                         语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_BroadcastGroup", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BroadcastGroup(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIndex);

        /**
         *  @brief  设置优先城市
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] u32Index  优先城市的索引号
         *  优先城市列表：（0  全国；1  北京；2  上海；3  天津；4  重庆；5  黑龙江；6  吉林；7  辽宁；8  内蒙古；9  河北；10 山东
                         11 山西；12 安徽；13 江苏；14 浙江；15 福建；16 广东；17 河南；18 江西；19 湖南；20 湖北；21 广西
                         22 海南；23 云南；24 贵州；25 四川；26 陕西；27 甘肃；28 宁夏；29 青海；30 西藏；31 新疆）

         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetCity", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  特征码比较
         *  @param  [IN] _pfResFeat1    需要比较的特征码1
         *  @param  [IN] _iFeat1Len     特征码1的长度，目前需输入20
         *  @param  [IN] _pfReaFeat2    需要比较的特征码2
         *  @param  [IN] _iFeat2Len     特征码2的长度，目前需输入20
         *  @return  匹配度，范围：0-1，值越大越匹配
         */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_VBR_CompareFeat", CallingConvention = CallingConvention.Cdecl)]
        public static extern float ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len,
                                                              float[] _pfReaFeat2, uint _iFeat2Len);

        /**
        *  @brief  设置识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [IN] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [IN] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [IN] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [IN] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [IN] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，高为720）
        *  @rerun 设置状态 1 设置成功 0 设置失败
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  获取识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [OUT] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [OUT] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [OUT] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [OUT] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [OUT] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，宽为720）
        *  @rerun 设置状态 1 获取成功 0 获取失败
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  设置触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetTriggerMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode);

        /**
        *  @brief  获取触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetTriggerMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode);

        /**
        *  @brief  获取系统版本
        *  @param  [IN] hSDK        连接相机时返回的sdk句柄
        *  @param  [IN] pstSysVersion       系统版本信息
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetCameraInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo);

        /**
        *  @brief  获取串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数结构体(ICE_UART_PARAM)
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetUARTCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  设置串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetUARTCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  获取IO状态
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [IN]  u32Index         IO序列号（0: IO1 1:IO2 2:IO3 3:IO4）
        *  @param  [OUT] pu32IOState      IO状态 （0：有数据 1：无数据）
        *  @param  [OUT] pu32Reserve1     预留参数1
        *  @param  [OUT] pu32Reserve2     预留参数2
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetIOState", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       车辆在场信息缓冲区地址 
        *  @param  [IN] u32PicSize			 车辆在场信息缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         车辆在场信息实际长度
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_getOfflineVehicleInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       脱机计费数据缓冲区地址 
        *  @param  [IN] u32PicSize			 脱机计费数据缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         脱机计费数据实际长度
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_getPayInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /**
        *  @brief  设置相机连接状态回调事件
        *  @param  [IN] hSDK                     连接相机时返回的sdk句柄
        *  @param  [IN] pfOnIOEvent              IO事件回调
        *  @param  [IN] pvIOEventParam           IO事件回调参数,用于区分不同IO变化事件
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetIOEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam);

        /**
        *  @brief  设置无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [IN] s32FilterByPlate				是否输出无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetVehicleBrand", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand);

        /**
        *  @brief  获取无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [OUT] s32FilterByPlate				是否过滤无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetVehicleBrand", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetLedCreen_Config", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetLedCreen_Config", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetLicense", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_CheckLicense", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_EnableEnc", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_ModifyEncPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetDecPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_BroadcastWav", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_UpdateWhiteListBatch", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, String szFilePath, int s32Type);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_GetSnapOsdCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);

        [DllImport(IceIpcSdk.DllFileNameX86, EntryPoint = "ICE_IPCSDK_SetSnapOsdCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
        #region // 显示实现接口
        uint IIceIpcSdkProxy.ICE_IPCSDK_BeginTalk(IntPtr hSDK) => ICE_IPCSDK_BeginTalk(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex) => ICE_IPCSDK_Broadcast(hSDK, nIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastGroup(IntPtr hSDK, string pcIndex) => ICE_IPCSDK_BroadcastGroup(hSDK, pcIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_BroadcastWav(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => ICE_IPCSDK_Capture(hSDK, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license) => ICE_IPCSDK_CheckLicense(hSDK, license);
        void IIceIpcSdkProxy.ICE_IPCSDK_Close(IntPtr hSDK) => ICE_IPCSDK_Close(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index) => ICE_IPCSDK_ControlAlarmOut(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd) => ICE_IPCSDK_EnableEnc(hSDK, u32EncId, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_EndTalk(IntPtr hSDK) => ICE_IPCSDK_EndTalk(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_Fini() => ICE_IPCSDK_Fini();
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState, ref uint pu32DelayTime, ref uint pu32Reserve) => ICE_IPCSDK_GetAlarmOutConfig(hSDK, u32Index, ref pu32IdleState, ref pu32DelayTime, ref pu32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo) => ICE_IPCSDK_GetCameraInfo(hSDK, ref pstCameraInfo);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID) => ICE_IPCSDK_GetDevID(hSDK, szDevID);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2) => ICE_IPCSDK_GetIOState(hSDK, u32Index, ref pu32IOState, ref pu32Reserve1, ref pu32Reserve2);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway) => ICE_IPCSDK_GetIPAddr(hSDK, ref pu32IP, ref pu32Mask, ref pu32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => ICE_IPCSDK_GetLedCreen_Config(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight) => ICE_IPCSDK_GetLoop(hSDK, ref nLeft, ref nBottom, ref nRight, ref nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen) => ICE_IPCSDK_getOfflineVehicleInfo(hSDK, pcVehicleInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen) => ICE_IPCSDK_getPayInfo(hSDK, pcPayInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => ICE_IPCSDK_GetSnapOsdCfg(hSDK, ref pstParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetStatus(IntPtr hSDK) => ICE_IPCSDK_GetStatus(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode) => ICE_IPCSDK_GetTriggerMode(hSDK, ref pu32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => ICE_IPCSDK_GetUARTCfg(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand) => ICE_IPCSDK_GetVehicleBrand(hSDK, ref s32FilterByPlate, ref s32EnableNoPlateVehicleBrand, ref s32EnableVehicleBrand);
        void IIceIpcSdkProxy.ICE_IPCSDK_Init() => ICE_IPCSDK_Init();
        void IIceIpcSdkProxy.ICE_IPCSDK_LogConfig(int openLog, string logPath) => ICE_IPCSDK_LogConfig(openLog, logPath);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd) => ICE_IPCSDK_ModifyEncPwd(hSDK, szOldPwd, szNewPwd);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open(string pcIP, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => ICE_IPCSDK_Open(pcIP, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice(string pcIP) => ICE_IPCSDK_OpenDevice(pcIP);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice_Passwd(string pcIP, string pcPasswd) => ICE_IPCSDK_OpenDevice_Passwd(pcIP, pcPasswd);
        uint IIceIpcSdkProxy.ICE_IPCSDK_OpenGate(IntPtr hSDK) => ICE_IPCSDK_OpenGate(hSDK);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview(string pcIP, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => ICE_IPCSDK_OpenPreview(pcIP, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => ICE_IPCSDK_OpenPreview_Passwd(pcIP, pcPasswd, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => ICE_IPCSDK_Open_Passwd(pcIP, pcPasswd, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize) => ICE_IPCSDK_ReadUserData(hSDK, pcData, nSize);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData, uint nSize, uint nOffset, uint nLen) => ICE_IPCSDK_ReadUserData_Binary(hSDK, pcData, nSize, nOffset, nLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Reboot(IntPtr hSDK) => ICE_IPCSDK_Reboot(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_SearchDev(StringBuilder szDevs) => ICE_IPCSDK_SearchDev(szDevs);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState, uint u32DelayTime, uint u32Reserve) => ICE_IPCSDK_SetAlarmOutConfig(hSDK, u32Index, u32IdleState, u32DelayTime, u32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index) => ICE_IPCSDK_SetCity(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd) => ICE_IPCSDK_SetDecPwd(hSDK, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam) => ICE_IPCSDK_SetDeviceEventCallBack(hSDK, pfOnDeviceEvent, pvDeviceEventParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam) => ICE_IPCSDK_SetFrameCallback(hSDK, pfOnFrame, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam) => ICE_IPCSDK_SetIOEventCallBack(hSDK, pfOnIOEvent, pvIOEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway) => ICE_IPCSDK_SetIPAddr(hSDK, u32IP, u32Mask, u32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => ICE_IPCSDK_SetLedCreen_Config(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics) => ICE_IPCSDK_SetLicense(hSDK, old_lics, new_lics);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight) => ICE_IPCSDK_SetLoop(hSDK, nLeft, nBottom, nRight, nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr) => ICE_IPCSDK_SetOSDCfg(hSDK, ref pstOSDAttr);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate, IntPtr pvPastPlateParam) => ICE_IPCSDK_SetPastPlateCallBack(hSDK, pfOnPastPlate, pvPastPlateParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam) => ICE_IPCSDK_SetPlateCallback(hSDK, pfOnPlate, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort, IntPtr pvSerialPortParam) => ICE_IPCSDK_SetSerialPortCallBack(hSDK, pfOnSerialPort, pvSerialPortParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort, IntPtr pvSerialPortParam) => ICE_IPCSDK_SetSerialPortCallBack_RS232(hSDK, pfOnSerialPort, pvSerialPortParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => ICE_IPCSDK_SetSnapOsdCfg(hSDK, ref pstParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam) => ICE_IPCSDK_SetTalkEventCallBack(hSDK, pfOnTalkEvent, pvTalkEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode) => ICE_IPCSDK_SetTriggerMode(hSDK, u32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => ICE_IPCSDK_SetUARTCfg(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand) => ICE_IPCSDK_SetVehicleBrand(hSDK, s32FilterByPlate, s32EnableNoPlateVehicleBrand, s32EnableVehicleBrand);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartRecord(IntPtr hSDK, string pcFileName) => ICE_IPCSDK_StartRecord(hSDK, pcFileName);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd) => ICE_IPCSDK_StartStream(hSDK, u8MainStream, hWnd);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopRecord(IntPtr hSDK) => ICE_IPCSDK_StopRecord(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopStream(IntPtr hSDK) => ICE_IPCSDK_StopStream(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day, byte u8Hour, byte u8Min, byte u8Sec) => ICE_IPCSDK_SyncTime(hSDK, u16Year, u8Month, u8Day, u8Hour, u8Min, u8Sec);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_TransSerialPort(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_TransSerialPort_RS232(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => ICE_IPCSDK_Trigger(hSDK, pcNumber, pcColor, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TriggerExt(IntPtr hSDK) => ICE_IPCSDK_TriggerExt(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, string szFilePath, int s32Type) => ICE_IPCSDK_UpdateWhiteListBatch(hSDK, szFilePath, s32Type);
        float IIceIpcSdkProxy.ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len, float[] _pfReaFeat2, uint _iFeat2Len) => ICE_IPCSDK_VBR_CompareFeat(_pfResFeat1, _iFeat1Len, _pfReaFeat2, _iFeat2Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData(IntPtr hSDK, string pcData) => ICE_IPCSDK_WriteUserData(hSDK, pcData);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK, string pcData, uint nOffset, uint nLen) => ICE_IPCSDK_WriteUserData_Binary(hSDK, pcData, nOffset, nLen);
        #endregion
    }
    internal class IceIpcSdkDllerX64 : IIceIpcSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IIceIpcSdkProxy Instance { get; } = new IceIpcSdkDllerX64();
        private IceIpcSdkDllerX64() { }
        /**
         *  @brief  设置获得实时识别数据的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPlate  实时识别数据，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetPlateCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam);

        /**
         *  @brief  设置获得断网识别数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPastPlate      断网识别数据，通过该回调获得
         *  @param  [IN] pvPastPlateParam   回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetPastPlateCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate,
                                                                  IntPtr pvPastPlateParam);

        /**
         *  @brief  设置获得RS485数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS485数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetSerialPortCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort,
                                                                   IntPtr pvSerialPortParam);

        /**
         *  @brief  设置获得RS232数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS232数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetSerialPortCallBack_RS232", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort,
                                                                         IntPtr pvSerialPortParam);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetDeviceEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam);

        /**
        *  @brief  设置相机对讲状态变化回调事件
        *  @param  [IN] hSDK                     连接相机时返回的sdk句柄
        *  @param  [IN] pfOnIOEvent              对讲事件回调
        *  @param  [IN] pvIOEventParam           对讲事件回调参数,用于区分不同对讲变化事件
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetTalkEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam);

        /**
         *  @brief  设置获得解码出的一帧图像的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnFrame  解码出的一帧图像，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetFrameCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam);

        /**
         *  @brief  全局初始化
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Init();

        /**
         *  @brief  全局释放
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Fini", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Fini();

        /**
         *  @brief  连接相机并接入视频（推荐使用）
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_OpenPreview", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenPreview(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  使用密码连接相机并接入视频
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_OpenPreview_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenPreview_Passwd(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
            byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  连接相机，不带视频流
         *  @param  [IN] pcIP   相机ip
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_OpenDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenDevice([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);

        /**
         *  @brief  使用密码连接相机，不带视频流
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_OpenDevice_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenDevice_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd);

        /**
         *  @brief  连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Open", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_Open(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort,
            ushort u16OnvifPort, byte u8MainStream, uint pfOnStream,
            IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  使用密码连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Open_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_Open_Passwd(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
            byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream,
            uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  断开连接
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Close(IntPtr hSDK);

        /**
         *  @brief  连接视频
         *  @param  [IN] hSDK           连接相机时返回的句柄值
         *  @param  [IN] u8MainStream   是否请求主码流（1：主码流 0：子码流）
         *  @param  [IN] hWnd           预览视频的窗口句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_StartStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd);

        /**
         *  @brief  断开视频
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_StopStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_StopStream(IntPtr hSDK);

        /**
         *  @brief   打开道闸
         *  @param   [IN] hSDK 由连接相机接口获得的句柄
         *  @return  1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_OpenGate", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_OpenGate(IntPtr hSDK);

        /**
         *  @brief   控制开关量输出
         *  @param   [IN] hSDK      由连接相机接口获得的句柄
         *  @param   [IN] u32Index  控制的IO口(0:表示IO1 1:表示IO2)
         *  @return  1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_ControlAlarmOut", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  获取开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [OUT] pu32IdleState   常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [OUT] pu32DelayTime   切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [OUT] pu32Reserve     预留参数
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetAlarmOutConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState,
                                                                ref uint pu32DelayTime, ref uint pu32Reserve);

        /**
         *  @brief  设置开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [IN] pu32IdleState    常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [IN] pu32DelayTime    切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [IN] pu32Reserve      预留参数
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetAlarmOutConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState,
                                                                uint u32DelayTime, uint u32Reserve);
        /**
         *  @brief  开始对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_BeginTalk", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BeginTalk(IntPtr hSDK);

        /**
         *  @brief  结束对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_EndTalk", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_EndTalk(IntPtr hSDK);

        /**
         *  @brief  软触发
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcNumber      车牌号
         *  @param  [OUT] pcColor       车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Trigger", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor,
                                                    byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  软触发扩展接口
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_TriggerExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_TriggerExt(IntPtr hSDK);

        /**
         *  @brief  手动抓拍，不做识别，直接抓拍一张码流的图片
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Capture", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  获取相机连接状态
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示在线，0表示离线
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetStatus(IntPtr hSDK);

        /**
         *  @brief  重启相机
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Reboot", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Reboot(IntPtr hSDK);

        /**
         *  @brief  时间同步
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @param  [IN] u16Year    年
         *  @param  [IN] u8Month    月
         *  @param  [IN] u8Day      日
         *  @param  [IN] u8Hour     时
         *  @param  [IN] u8Min      分
         *  @param  [IN] u8Sec      秒
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SyncTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day,
                                                        byte u8Hour, byte u8Min, byte u8Sec);

        /**
         *  @brief  发送RS485串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS485串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_TransSerialPort", CallingConvention = CallingConvention.Cdecl)]
        //public static extern uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, String pcData, uint u32Len);
        public static extern uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  发送RS232串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS232串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_TransSerialPort_RS232", CallingConvention = CallingConvention.Cdecl)]
        //public static extern uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, string pcData, uint u32Len);
        public static extern uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  获取相机mac地址
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [OUT] szDevID  相机mac地址
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetDevID", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID);

        /**
         *  @brief  开始录像
         *  @param  [IN] hSDK        由连接相机接口获得的句柄
         *  @param  [IN] pcFileName  保存录像的文件名
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_StartRecord", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_StartRecord(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcFileName);

        /**
         *  @brief  结束录像
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_StopRecord", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_StopRecord(IntPtr hSDK);

        /**
         *  @brief  设置OSD参数
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pstOSDAttr OSD参数结构体地址，详见ICE_OSDAttr_S
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetOSDCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr);

        /**
         *  @brief  写入用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_WriteUserData", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_WriteUserData(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData);

        /**
         *  @brief  读取用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_ReadUserData", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize);

        /**
         *  @brief  写入二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @parame [IN] nOffset    偏移量
         *  @parame [IN] nLen       写入数据的长度
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_WriteUserData_Binary", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData,
            uint nOffset, uint nLen);

        /**
         *  @brief  读取二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @param  [IN] nOffset    读数据的偏移量
         *  @param  [IN] nLen       需要读出的数据的大小
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_ReadUserData_Binary", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData,
                                                                 uint nSize, uint nOffset, uint nLen);
        /**
         *  @brief  获取相机网络参数
         *  @param  [IN] hSDK          由连接相机接口获得的句柄
         *  @parame [OUT] pu32IP       相机ip
         *  @param  [OUT] pu32Mask     相机掩码
         *  @param  [OUT] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetIPAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway);

        /**
         *  @brief  设置相机网络参数
         *  @param  [IN] hSDK         由连接相机接口获得的句柄
         *  @parame [IN] pu32IP       相机ip
         *  @param  [IN] pu32Mask     相机掩码
         *  @param  [IN] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetIPAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway);

        /**
         *  @brief  搜索区域网内相机
         *  @param  [OUT] szDevs   设备mac地址和ip地址的字符串
         *                         设备mac地址和ip地址的字符串，格式为：mac地址 ip地址 例如：00-00-00-00-00-00 192.168.55.150\r\n
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SearchDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SearchDev(StringBuilder szDevs);

        /**
         *  @brief  记录日志配置
         *  @param  [IN] openLog    是否开启日志，0：不开启 1：开启
         *  @parame [IN] logPath    日志路径，默认为D:\
         *  @return void
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_LogConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_LogConfig(int openLog, string logPath);

        /**
         *  @brief  语音播放，单条语音
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_Broadcast", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex);

        /**
         *  @brief  语音组播
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    包含语音序号的字符串  注：中间可以用, ; \t \n或者空格分开；如：1 2 3 4或者1,2,3,4
         *                         语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_BroadcastGroup", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BroadcastGroup(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIndex);

        /**
         *  @brief  设置优先城市
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] u32Index  优先城市的索引号
         *  优先城市列表：（0  全国；1  北京；2  上海；3  天津；4  重庆；5  黑龙江；6  吉林；7  辽宁；8  内蒙古；9  河北；10 山东
                         11 山西；12 安徽；13 江苏；14 浙江；15 福建；16 广东；17 河南；18 江西；19 湖南；20 湖北；21 广西
                         22 海南；23 云南；24 贵州；25 四川；26 陕西；27 甘肃；28 宁夏；29 青海；30 西藏；31 新疆）

         *  @return 1表示成功，0表示失败
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetCity", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  特征码比较
         *  @param  [IN] _pfResFeat1    需要比较的特征码1
         *  @param  [IN] _iFeat1Len     特征码1的长度，目前需输入20
         *  @param  [IN] _pfReaFeat2    需要比较的特征码2
         *  @param  [IN] _iFeat2Len     特征码2的长度，目前需输入20
         *  @return  匹配度，范围：0-1，值越大越匹配
         */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_VBR_CompareFeat", CallingConvention = CallingConvention.Cdecl)]
        public static extern float ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len,
                                                              float[] _pfReaFeat2, uint _iFeat2Len);

        /**
        *  @brief  设置识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [IN] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [IN] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [IN] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [IN] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [IN] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，高为720）
        *  @rerun 设置状态 1 设置成功 0 设置失败
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  获取识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [OUT] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [OUT] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [OUT] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [OUT] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [OUT] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，宽为720）
        *  @rerun 设置状态 1 获取成功 0 获取失败
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  设置触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetTriggerMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode);

        /**
        *  @brief  获取触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetTriggerMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode);

        /**
        *  @brief  获取系统版本
        *  @param  [IN] hSDK        连接相机时返回的sdk句柄
        *  @param  [IN] pstSysVersion       系统版本信息
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetCameraInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo);

        /**
        *  @brief  获取串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数结构体(ICE_UART_PARAM)
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetUARTCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  设置串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetUARTCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  获取IO状态
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [IN]  u32Index         IO序列号（0: IO1 1:IO2 2:IO3 3:IO4）
        *  @param  [OUT] pu32IOState      IO状态 （0：有数据 1：无数据）
        *  @param  [OUT] pu32Reserve1     预留参数1
        *  @param  [OUT] pu32Reserve2     预留参数2
        *  @return 0 失败 1 成功
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetIOState", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       车辆在场信息缓冲区地址 
        *  @param  [IN] u32PicSize			 车辆在场信息缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         车辆在场信息实际长度
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_getOfflineVehicleInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       脱机计费数据缓冲区地址 
        *  @param  [IN] u32PicSize			 脱机计费数据缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         脱机计费数据实际长度
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_getPayInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /**
        *  @brief  设置相机连接状态回调事件
        *  @param  [IN] hSDK                     连接相机时返回的sdk句柄
        *  @param  [IN] pfOnIOEvent              IO事件回调
        *  @param  [IN] pvIOEventParam           IO事件回调参数,用于区分不同IO变化事件
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetIOEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam);

        /**
        *  @brief  设置无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [IN] s32FilterByPlate				是否输出无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetVehicleBrand", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand);

        /**
        *  @brief  获取无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [OUT] s32FilterByPlate				是否过滤无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetVehicleBrand", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetLedCreen_Config", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetLedCreen_Config", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetLicense", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_CheckLicense", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_EnableEnc", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_ModifyEncPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetDecPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_BroadcastWav", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_UpdateWhiteListBatch", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, String szFilePath, int s32Type);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_GetSnapOsdCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);

        [DllImport(IceIpcSdk.DllFileNameX64, EntryPoint = "ICE_IPCSDK_SetSnapOsdCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
        #region // 显示实现接口
        uint IIceIpcSdkProxy.ICE_IPCSDK_BeginTalk(IntPtr hSDK) => ICE_IPCSDK_BeginTalk(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex) => ICE_IPCSDK_Broadcast(hSDK, nIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastGroup(IntPtr hSDK, string pcIndex) => ICE_IPCSDK_BroadcastGroup(hSDK, pcIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_BroadcastWav(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => ICE_IPCSDK_Capture(hSDK, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license) => ICE_IPCSDK_CheckLicense(hSDK, license);
        void IIceIpcSdkProxy.ICE_IPCSDK_Close(IntPtr hSDK) => ICE_IPCSDK_Close(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index) => ICE_IPCSDK_ControlAlarmOut(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd) => ICE_IPCSDK_EnableEnc(hSDK, u32EncId, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_EndTalk(IntPtr hSDK) => ICE_IPCSDK_EndTalk(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_Fini() => ICE_IPCSDK_Fini();
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState, ref uint pu32DelayTime, ref uint pu32Reserve) => ICE_IPCSDK_GetAlarmOutConfig(hSDK, u32Index, ref pu32IdleState, ref pu32DelayTime, ref pu32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo) => ICE_IPCSDK_GetCameraInfo(hSDK, ref pstCameraInfo);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID) => ICE_IPCSDK_GetDevID(hSDK, szDevID);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2) => ICE_IPCSDK_GetIOState(hSDK, u32Index, ref pu32IOState, ref pu32Reserve1, ref pu32Reserve2);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway) => ICE_IPCSDK_GetIPAddr(hSDK, ref pu32IP, ref pu32Mask, ref pu32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => ICE_IPCSDK_GetLedCreen_Config(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight) => ICE_IPCSDK_GetLoop(hSDK, ref nLeft, ref nBottom, ref nRight, ref nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen) => ICE_IPCSDK_getOfflineVehicleInfo(hSDK, pcVehicleInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen) => ICE_IPCSDK_getPayInfo(hSDK, pcPayInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => ICE_IPCSDK_GetSnapOsdCfg(hSDK, ref pstParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetStatus(IntPtr hSDK) => ICE_IPCSDK_GetStatus(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode) => ICE_IPCSDK_GetTriggerMode(hSDK, ref pu32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => ICE_IPCSDK_GetUARTCfg(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand) => ICE_IPCSDK_GetVehicleBrand(hSDK, ref s32FilterByPlate, ref s32EnableNoPlateVehicleBrand, ref s32EnableVehicleBrand);
        void IIceIpcSdkProxy.ICE_IPCSDK_Init() => ICE_IPCSDK_Init();
        void IIceIpcSdkProxy.ICE_IPCSDK_LogConfig(int openLog, string logPath) => ICE_IPCSDK_LogConfig(openLog, logPath);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd) => ICE_IPCSDK_ModifyEncPwd(hSDK, szOldPwd, szNewPwd);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open(string pcIP, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => ICE_IPCSDK_Open(pcIP, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice(string pcIP) => ICE_IPCSDK_OpenDevice(pcIP);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice_Passwd(string pcIP, string pcPasswd) => ICE_IPCSDK_OpenDevice_Passwd(pcIP, pcPasswd);
        uint IIceIpcSdkProxy.ICE_IPCSDK_OpenGate(IntPtr hSDK) => ICE_IPCSDK_OpenGate(hSDK);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview(string pcIP, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => ICE_IPCSDK_OpenPreview(pcIP, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => ICE_IPCSDK_OpenPreview_Passwd(pcIP, pcPasswd, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => ICE_IPCSDK_Open_Passwd(pcIP, pcPasswd, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize) => ICE_IPCSDK_ReadUserData(hSDK, pcData, nSize);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData, uint nSize, uint nOffset, uint nLen) => ICE_IPCSDK_ReadUserData_Binary(hSDK, pcData, nSize, nOffset, nLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Reboot(IntPtr hSDK) => ICE_IPCSDK_Reboot(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_SearchDev(StringBuilder szDevs) => ICE_IPCSDK_SearchDev(szDevs);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState, uint u32DelayTime, uint u32Reserve) => ICE_IPCSDK_SetAlarmOutConfig(hSDK, u32Index, u32IdleState, u32DelayTime, u32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index) => ICE_IPCSDK_SetCity(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd) => ICE_IPCSDK_SetDecPwd(hSDK, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam) => ICE_IPCSDK_SetDeviceEventCallBack(hSDK, pfOnDeviceEvent, pvDeviceEventParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam) => ICE_IPCSDK_SetFrameCallback(hSDK, pfOnFrame, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam) => ICE_IPCSDK_SetIOEventCallBack(hSDK, pfOnIOEvent, pvIOEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway) => ICE_IPCSDK_SetIPAddr(hSDK, u32IP, u32Mask, u32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => ICE_IPCSDK_SetLedCreen_Config(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics) => ICE_IPCSDK_SetLicense(hSDK, old_lics, new_lics);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight) => ICE_IPCSDK_SetLoop(hSDK, nLeft, nBottom, nRight, nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr) => ICE_IPCSDK_SetOSDCfg(hSDK, ref pstOSDAttr);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate, IntPtr pvPastPlateParam) => ICE_IPCSDK_SetPastPlateCallBack(hSDK, pfOnPastPlate, pvPastPlateParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam) => ICE_IPCSDK_SetPlateCallback(hSDK, pfOnPlate, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort, IntPtr pvSerialPortParam) => ICE_IPCSDK_SetSerialPortCallBack(hSDK, pfOnSerialPort, pvSerialPortParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort, IntPtr pvSerialPortParam) => ICE_IPCSDK_SetSerialPortCallBack_RS232(hSDK, pfOnSerialPort, pvSerialPortParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => ICE_IPCSDK_SetSnapOsdCfg(hSDK, ref pstParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam) => ICE_IPCSDK_SetTalkEventCallBack(hSDK, pfOnTalkEvent, pvTalkEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode) => ICE_IPCSDK_SetTriggerMode(hSDK, u32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => ICE_IPCSDK_SetUARTCfg(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand) => ICE_IPCSDK_SetVehicleBrand(hSDK, s32FilterByPlate, s32EnableNoPlateVehicleBrand, s32EnableVehicleBrand);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartRecord(IntPtr hSDK, string pcFileName) => ICE_IPCSDK_StartRecord(hSDK, pcFileName);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd) => ICE_IPCSDK_StartStream(hSDK, u8MainStream, hWnd);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopRecord(IntPtr hSDK) => ICE_IPCSDK_StopRecord(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopStream(IntPtr hSDK) => ICE_IPCSDK_StopStream(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day, byte u8Hour, byte u8Min, byte u8Sec) => ICE_IPCSDK_SyncTime(hSDK, u16Year, u8Month, u8Day, u8Hour, u8Min, u8Sec);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_TransSerialPort(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_TransSerialPort_RS232(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => ICE_IPCSDK_Trigger(hSDK, pcNumber, pcColor, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TriggerExt(IntPtr hSDK) => ICE_IPCSDK_TriggerExt(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, string szFilePath, int s32Type) => ICE_IPCSDK_UpdateWhiteListBatch(hSDK, szFilePath, s32Type);
        float IIceIpcSdkProxy.ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len, float[] _pfReaFeat2, uint _iFeat2Len) => ICE_IPCSDK_VBR_CompareFeat(_pfResFeat1, _iFeat1Len, _pfReaFeat2, _iFeat2Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData(IntPtr hSDK, string pcData) => ICE_IPCSDK_WriteUserData(hSDK, pcData);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK, string pcData, uint nOffset, uint nLen) => ICE_IPCSDK_WriteUserData_Binary(hSDK, pcData, nOffset, nLen);
        #endregion
    }
}
