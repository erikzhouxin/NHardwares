using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    #region // 公共委托
    /// <summary>
    /// 通过该回调函数获得实时识别数据
    /// </summary>
    /// <param name="pvParam">用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（与设置此回调接口的最后一个参数相同）</param>
    /// <param name="pcIP">相机ip</param>
    /// <param name="pcNumber">车牌号</param>
    /// <param name="pcColor">车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）</param>
    /// <param name="pcPicData">全景数据</param>
    /// <param name="u32PicLen">全景数据长度</param>
    /// <param name="pcCloseUpPicData">车牌数据</param>
    /// <param name="u32CloseUpPicLen">车牌数据长度</param>
    /// <param name="nSpeed">车辆速度</param>
    /// <param name="nVehicleType">车辆类型（0:未知,1轿车,2面包车,3大型客车,4中型客车,5皮卡,6非机动车,7SUV,8MPV,9微型货车,10轻型货车,11中型货车,12重型货车)</param>
    /// <param name="nReserved1">预留参数1</param>
    /// <param name="nReserved2">预留参数2</param>
    /// <param name="fPlateConfidence">车牌打分值（SDK输出的范围大于IE界面设置的车牌阈值，上限是28，例如：IE设置的是10，范围：10-28）</param>
    /// <param name="u32VehicleColor">车身颜色（车辆特征码相机版本：(-1:未知,0:黑色,1:蓝色,2:灰色,3:棕色,4:绿色,5:夜间深色,6:紫色,7:红色,8:白色,9:黄色)其它相机版本：(0:未知,1:红色,2:绿色,3:蓝色,4:黄色,5:白色,6:灰色,7:黑色,8:紫色,9:棕色,10:粉色)）</param>
    /// <param name="u32PlateType">车牌类型，详见车牌类型ICE_PLATETYPE_E枚举值</param>
    /// <param name="u32VehicleDir">车辆方向（0:车头方向,1:车尾方向,2:车头和车尾方向）</param>
    /// <param name="u32AlarmType">报警输出，详见报警输出ICE_VDC_ALARM_TYPE枚举值</param>
    /// <param name="u32SerialNum">抓拍的序号（从相机第一次抓拍开始计数，相机重启后才清零）</param>
    /// <param name="uCapTime">实时抓拍时间，从1970年1月1日零点开始的秒数</param>
    /// <param name="u32ResultHigh">车牌识别数据结构体（ICE_VDC_PICTRUE_INFO_S）指针高8位（64位sdk时需要使用）</param>
    /// <param name="u32ResultLow">车牌识别数据结构体（ICE_VDC_PICTRUE_INFO_S）指针低8位</param>
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void ICE_IPCSDK_OnPlate(
                IntPtr pvParam,
                [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
                [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcNumber,
                [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcColor,
                IntPtr pcPicData,
                uint u32PicLen,
                IntPtr pcCloseUpPicData,
                uint u32CloseUpPicLen,
                short nSpeed,
                short nVehicleType,
                short nReserved1,
                short nReserved2,
                float fPlateConfidence,
                uint u32VehicleColor,
                uint u32PlateType,
                uint u32VehicleDir,
                uint u32AlarmType,
                uint u32SerialNum,
                uint uCapTime,
                uint u32ResultHigh,
                uint u32ResultLow);
    /// <summary>
    /// 通过该回调函数获得断网识别数据
    /// </summary>
    /// <param name="pvParam">用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetPastPlateCallBack传入的最后一个参数）</param>
    /// <param name="pcIP">相机ip</param>
    /// <param name="u32CapTime">抓拍时间</param>
    /// <param name="pcNumber">车牌号</param>
    /// <param name="pcColor">车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）</param>
    /// <param name="pcPicData">全景数据</param>
    /// <param name="u32PicLen">全景数据长度</param>
    /// <param name="pcCloseUpPicData">车牌数据</param>
    /// <param name="u32CloseUpPicLen">车牌数据长度</param>
    /// <param name="s16PlatePosLeft">车牌区域左上角横坐标</param>
    /// <param name="s16PlatePosTop">车牌区域左上角纵坐标</param>
    /// <param name="s16PlatePosRight">车牌区域右下角横坐标</param>
    /// <param name="s16PlatePosBottom">车牌区域右下角纵坐标</param>
    /// <param name="fPlateConfidence">车牌打分值（SDK输出的范围大于IE界面设置的车牌阈值，上限是28，例如：IE设置的是10，范围：10-28）</param>
    /// <param name="u32VehicleColor">车身颜色（0:未知,1:红色,2:绿色,3:蓝色,4:黄色,5:白色,6:灰色,7:黑色,8:紫色,9:棕色,10:粉色）</param>
    /// <param name="u32PlateType">车牌类型，详见车牌类型ICE_PLATETYPE_E枚举值</param>
    /// <param name="u32VehicleDir">车辆方向（0:车头方向,1:车尾方向,2:车头和车尾方向）</param>
    /// <param name="u32AlarmType">报警输出，详见报警输出ICE_VDC_ALARM_TYPE枚举值</param>
    /// <param name="u32Reserved1">预留参数1</param>
    /// <param name="u32Reserved2">预留参数2</param>
    /// <param name="u32Reserved3">预留参数3</param>
    /// <param name="u32Reserved4">预留参数4</param>
    public delegate void ICE_IPCSDK_OnPastPlate(
        IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32CapTime,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcNumber,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcColor,
        IntPtr pcPicData,
        uint u32PicLen,
        IntPtr pcCloseUpPicData,
        uint u32CloseUpPicLen,
        short s16PlatePosLeft,
        short s16PlatePosTop,
        short s16PlatePosRight,
        short s16PlatePosBottom,
        float fPlateConfidence,
        uint u32VehicleColor,
        uint u32PlateType,
        uint u32VehicleDir,
        uint u32AlarmType,
        uint u32Reserved1,
        uint u32Reserved2,
        uint u32Reserved3,
        uint u32Reserved4);
    /// <summary>
    /// 通过该回调函数获得RS485数据
    /// </summary>
    /// <param name="pvParam">用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetSerialPortCallBack传入的最后一个参数）</param>
    /// <param name="pcIP">相机ip</param>
    /// <param name="pcData">串口数据首地址</param>
    /// <param name="u32Len">串口数据长度</param>
    public delegate void ICE_IPCSDK_OnSerialPort(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        IntPtr pcData, uint u32Len);
    /// <summary>
    /// 通过该回调函数获得RS232数据
    /// </summary>
    /// <param name="pvParam">用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetSerialPortCallBack_RS232传入的最后一个参数）</param>
    /// <param name="pcIP">相机ip</param>
    /// <param name="pcData">串口数据首地址</param>
    /// <param name="u32Len">串口数据长度</param>
    public delegate void ICE_IPCSDK_OnSerialPort_RS232(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        IntPtr pcData, uint u32Len);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pvParam"></param>
    /// <param name="pcIP"></param>
    /// <param name="u32EventType"></param>
    /// <param name="u32EventData1"></param>
    /// <param name="u32EventData2"></param>
    /// <param name="u32EventData3"></param>
    /// <param name="u32EventData4"></param>
    public delegate void ICE_IPCSDK_OnDeviceEvent(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32EventType, uint u32EventData1, uint u32EventData2, uint u32EventData3, uint u32EventData4);
    /// <summary>
    /// 通过该回调函数获取相机的对讲状态变化
    /// </summary>
    /// <param name="pvParam">相机连接回调参数, 用于区分不同相机对讲事件(ICE_IPCSDK_SetTalkEventCallBack传入的最后一个参数)</param>
    /// <param name="pcIP">相机ip</param>
    /// <param name="u32EventType">事件类型 0：普通非对讲状态 1：触发对讲 2：正在对讲 3:相机端发起对讲后，被某个管理端拒绝通话 4:通话中断</param>
    /// <param name="pcTalkIp">事件类型为2时，表示与相机端接通的管理端ip；事件类型为3时，表示拒绝与相机通话的管理端ip</param>
    /// <param name="u32Reserve1">预留1</param>
    /// <param name="u32Reserve2">预留2</param>
    /// <param name="u32Reserve3">预留3</param>
    /// <param name="u32Reserve4">预留4</param>
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void ICE_IPCSDK_OnTalkEvent(IntPtr pvParam, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32EventType, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcTalkIp,
        uint u32Reserve1, uint u32Reserve2, uint u32Reserve3, uint u32Reserve4);
    /// <summary>
    /// 通过该回调函数获得解码出的一帧图像
    /// </summary>
    /// <param name="pvParam">用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetFrameCallback传入的最后一个参数）</param>
    /// <param name="u32Timestamp">时间戳</param>
    /// <param name="pu8DataY">y帧数据地址</param>
    /// <param name="pu8DataU">U帧数据地址</param>
    /// <param name="pu8DataV">V帧数据地址</param>
    /// <param name="s32LinesizeY">y帧数据每扫描行长度</param>
    /// <param name="s32LinesizeU">U帧数据每扫描行长度</param>
    /// <param name="s32LinesizeV">V帧数据每扫描行长度</param>
    /// <param name="s32Width">图像宽度</param>
    /// <param name="s32Height">图像高度</param>
    public delegate void ICE_IPCSDK_OnFrame_Planar(IntPtr pvParam, uint u32Timestamp,
                                                    IntPtr pu8DataY, IntPtr pu8DataU,
                                                    IntPtr pu8DataV, int s32LinesizeY,
                                                    int s32LinesizeU, int s32LinesizeV, int s32Width, int s32Height);
    /// <summary>
    /// 通过该回调函数获取相机的IO状态变化
    /// </summary>
    /// <param name="pvParam">相机连接回调参数, 用于区分不同相机IO事件(ICE_IPCSDK_SetIOEventCallBack传入的最后一个参数)</param>
    /// <param name="pcIP">相机ip</param>
    /// <param name="u32EventType">事件类型 0：IO变化</param>
    /// <param name="u32IOData1">事件数据1 事件类型为0时，代表IO1的状态;）</param>
    /// <param name="u32IOData2">事件数据2 （事件类型为0时，代表IO2的状态）</param>
    /// <param name="u32IOData3">事件数据3 （事件类型为0时，代表IO3的状态）</param>
    /// <param name="u32IOData4">事件数据4 （事件类型为0时，代表IO4的状态）</param>
    public delegate void ICE_IPCSDK_OnIOEvent(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32EventType, uint u32IOData1, uint u32IOData2, uint u32IOData3, uint u32IOData4);
    #endregion
    #region // 内部委托
    /// <summary>
    /// 委托创建者
    /// </summary>
    internal class DCreater
    {
        internal delegate void ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam);
        internal delegate void ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate, IntPtr pvPastPlateParam);
        internal delegate void ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort, IntPtr pvSerialPortParam);
        internal delegate void ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort, IntPtr pvSerialPortParam);
        internal delegate void ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam);
        internal delegate void ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam);
        internal delegate void ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam);
        internal delegate void ICE_IPCSDK_Init();
        internal delegate void ICE_IPCSDK_Fini();
        internal delegate IntPtr ICE_IPCSDK_OpenPreview([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);
        internal delegate IntPtr ICE_IPCSDK_OpenPreview_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, [MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);
        internal delegate IntPtr ICE_IPCSDK_OpenDevice([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);
        internal delegate IntPtr ICE_IPCSDK_OpenDevice_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd);
        internal delegate IntPtr ICE_IPCSDK_Open([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);
        internal delegate IntPtr ICE_IPCSDK_Open_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);
        internal delegate void ICE_IPCSDK_Close(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd);
        internal delegate void ICE_IPCSDK_StopStream(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_OpenGate(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index);
        internal delegate uint ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState, ref uint pu32DelayTime, ref uint pu32Reserve);
        internal delegate uint ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState, uint u32DelayTime, uint u32Reserve);
        internal delegate uint ICE_IPCSDK_BeginTalk(IntPtr hSDK);
        internal delegate void ICE_IPCSDK_EndTalk(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);
        internal delegate uint ICE_IPCSDK_TriggerExt(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);
        internal delegate uint ICE_IPCSDK_GetStatus(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_Reboot(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day, byte u8Hour, byte u8Min, byte u8Sec);
        internal delegate uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len);
        internal delegate uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len);
        internal delegate uint ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID);
        internal delegate uint ICE_IPCSDK_StartRecord(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcFileName);
        internal delegate void ICE_IPCSDK_StopRecord(IntPtr hSDK);
        internal delegate uint ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr);
        internal delegate uint ICE_IPCSDK_WriteUserData(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData);
        internal delegate uint ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize);
        internal delegate uint ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData, uint nOffset, uint nLen);
        internal delegate uint ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData, uint nSize, uint nOffset, uint nLen);
        internal delegate uint ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway);
        internal delegate uint ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway);
        internal delegate void ICE_IPCSDK_SearchDev(StringBuilder szDevs);
        internal delegate void ICE_IPCSDK_LogConfig(int openLog, string logPath);
        internal delegate uint ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex);
        internal delegate uint ICE_IPCSDK_BroadcastGroup(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIndex);
        internal delegate uint ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index);
        internal delegate float ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len, float[] _pfReaFeat2, uint _iFeat2Len);
        internal delegate uint ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight);
        internal delegate uint ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight);
        internal delegate uint ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode);
        internal delegate uint ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode);
        internal delegate uint ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo);
        internal delegate uint ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);
        internal delegate uint ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);
        internal delegate uint ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2);
        internal delegate uint ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen);
        internal delegate uint ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen);
        internal delegate void ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam);
        internal delegate uint ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand);
        internal delegate uint ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand);
        internal delegate uint ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);
        internal delegate uint ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);
        internal delegate uint ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics);
        internal delegate uint ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license);
        internal delegate uint ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd);
        internal delegate uint ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd);
        internal delegate uint ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd);
        internal delegate uint ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len);
        internal delegate uint ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, String szFilePath, int s32Type);
        internal delegate uint ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
        internal delegate uint ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
    }
    #endregion
}
