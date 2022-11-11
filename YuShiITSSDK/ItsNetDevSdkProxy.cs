using System;
using System.Collections.Generic;
using System.Data.HardwareInterfaces;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.YuShiITSSDK
{
    /// <summary>
    /// SDK代理
    /// </summary>
    public interface IItsNetDevSdkProxy
    {
        /// <summary>
        /// 内存复制
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="src"></param>
        /// <param name="count"></param>
        void MemCopy(byte[] dest, IntPtr src, int count);
        void OutputDebugString(string message);

        Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        /**
        * SDK 初始化  SDK initialization
        * @return 1 表示成功,其他表示失败 1 means success, and any other value means failure.
        * @note 线程不安全 Thread not safe
        */
        Int32 NETDEV_Init();

        /**
         * SDK 清理  SDK cleaning
         * @return 1 表示成功,其他表示失败 1 means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_Cleanup();

        Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        IntPtr NETDEV_LoginCloud(String pszCloudSrvUrl, String pszUserName, String pszPassWord);

        IntPtr NETDEV_LoginCloudDevice_V30(IntPtr lpUserID, ref NETDEV_CLOUD_DEV_LOGIN_INFO_S pstCloudInfo);

        IntPtr NETDEV_FindCloudDevListEx(IntPtr lpUserID);

        Int32 NETDEV_FindNextCloudDevInfoEx(IntPtr lpFindHandle, ref NETDEV_CLOUD_DEV_BASIC_INFO_S pstDevInfo);

        Int32 NETDEV_FindCloseCloudDevListEx(IntPtr lpFindHandle);

        /**
        * 设备发现 先注册设备发现相关的回调,再调用此接口发现设备,发现的设备信息在回调中反映
        * This interface is used for device discovery. Please first register callback functions related to device discovery and use this interface for device discovery. Discovered device info will be included in the callback function.
        * @param [IN]   pszBeginIP                 起始IP地址
        * @param [IN]   pszEndIP                   结束IP地址
        * @return 1 表示成功,其他表示失败
        * @note 若pszBeginIP和pszEndIP都是"0.0.0.0",则搜索本网段设备
        */
        Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        /**
         * 启动实时预览  Start live preview
         * @param [IN]  lpUserID             用户登录句柄 User login ID
         * @param [IN]  pstPreviewInfo       预览参数,参考枚举：NETDEV_PROTOCAL_E,NETDEV_LIVE_STREAM_INDEX_E. Preview parameter, see enumeration: NETDEV_PROTOCAL_E, NETDEV_LIVE_STREAM_INDEX_E.
         * @param [IN]  cbRealDataCallBack   码流数据回调函数指针 Pointer to callback function of stream data
         * @param [IN]  lpUserData           用户数据 User data
         * @return 返回的用户登录句柄,返回 0 表示失败,其他值表示返回的用户登录句柄值. Returned live Handle. 0 indicates failure, and other values indicate the user ID.
         * @note
         */
        IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        /**
        * 停止实时预览  Stop live preview
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @return 1 表示成功,其他表示失败 1 means success, and any other value means failure.
        * @note 对应关闭NETDEV_RealPlay开启的实况 Stop the live view started by NETDEV_RealPlay
        */
        Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        /**
        * 获取窗口码率  Get window bit rate
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwBitRate       获取的码率指针 Pointer to obtained bit rate
        * @return 1表示成功,其他表示失败 1 means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        /*
        * 获取窗口帧率  Get window frame rate
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwFrameRate     获取的帧率指针 Pointer to obtained frame rate
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        /**
        * 获取窗口编码格式  Get window encoding format
        * @param [IN]  lpPlayHandle         预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwVideoEncFmt       获取的视频编码格式指针,参见NETDEV_VIDEO_CODE_TYPE_E  Pointer to obtained encoding format, see NETDEV_VIDEO_CODE_TYPE_E
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        /**
        * 获取视频分辨率  Get video resolution
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwWidth         获取的分辨率-宽度指针 Pointer to obtained resolution – width
        * @param [OUT] pdwHeight        获取的分辨率-高度指针 Pointer to obtained resolution – height
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        /**
        * 获取窗口丢包率  Get window packet loss rate
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pulRecvPktNum    接收的数据包数量指针 Pointer to number of received packets
        * @param [OUT] pulLostPktNum    丢失的数据包数量指针 Pointer to number of lost packets
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        /**
        * 实况抓拍  Live view snapshot
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [IN]  pszFileName      保存图像的文件路径（包括文件名） File path to save images (including file name)
        * @param [IN]  dwCaptureMode    保存图像格式,参见#NETDEV_PICTURE_FORMAT_E   Image saving format, see #NETDEV_PICTURE_FORMAT_E
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 文件名中可以不携带抓拍格式的后缀名 File format suffix is not required in the file name
        */
        Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);

        /**
        * 本地录像  Local recording
        * @param [IN]  lpPlayHandle         预览句柄 Preview handle
        * @param [IN]  pszSaveFileName      保存的文件名 Name of saved file
        * @param [IN]  dwFormat             Format of saved file, see #NETDEV_MEDIA_FILE_FORMAT_E 
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        /**
        * 停止本地录像 Stop local recording
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        /**
        * 根据文件类型.时间查找设备录像文件  Query recording files according to file type and time
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @param [IN]  pstFindCond    录像查询条件 Search condition
        * @return 录像查询业务号,返回0表示失败,其他值作为NETDEV_FindClose等函数的参数.
        Recording search service number. 0 means failure. Other values are used as the handle parameters of functions like NETDEV_FindClose.
        * @note 此函数返回值为录像查询业务号,若返回值为非0,则查询录像文件成功：
        *         一.将上述业务号作为NETDEV_FindNextFile函数的入参lpFindHandle,多次调用NETDEV_FindNextFile函数,以逐个获取详细录像文件信息.
        *         二.查询结束后,必须以上述业务号作为NETDEV_FindClose函数的入参lpFindHandle,调用NETDEV_FindClose函数,以释放资源,关闭查找.
        */
        IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        /**
        * 逐个获取查找到的文件信息  Obtain the information of found files one by one.
        * @param [IN]  lpFindHandle     文件查找句柄 File search handle
        * @param [OUT] pstFindData       保存文件信息的指针 Pointer to save file information
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        /**
        * 关闭文件查找,释放资源  Close file search and release resources
        * @param [IN] lpFindHandle  文件查找句柄 File search handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        /**
        * 控制录像回放的状态  Control recording playback status.
        * @param [IN]  lpPlayHandle     回放或下载句柄 Playback or download handle
        * @param [IN]  dwControlCode    控制录像回放状态命令 参考枚举：NETDEV_VOD_PLAY_CTRL_E Command for controlling recording playback status, see NETDEV_VOD_PLAY_CTRL_E
        * @param [INOUT]  lpBuffer     指向输入/输出参数的指针, 播放速度参考枚举：NETDEV_VOD_PLAY_STATUS_E,播放时间参数类型为：INT64 Pointer to input/output parameters. For playing speed, see NETDEV_VOD_PLAY_STATUS_E. The type of playing time: INT64.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 开始.暂停.恢复播放时,lpBuffer置为NULL When playing, pause or resume videos, set IpBuffer as NULL.
        */
        Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        /**
        * 按时间下载录像文件 Download recordings by time
        * @param [IN]  lpUserID                用户登录句柄 User login ID
        * @param [IN]  pstPlayBackCond   按时间录像回放结构体指针,参考 LPNETDEV_PLAYBACKCOND_S Pointer to playback-by-time structure, see LPNETDEV_PLAYBACKCOND_S
        * @param [IN]  *pszSaveFileName        下载后保存到PC机的文件路径,需为绝对路径（包括文件名） Downloaded file save path on PC, must be an absolute path (including file name)
        * @param [IN]  dwFormat                录像文件保存格式 Recording file saving format
        * @return 下载句柄, 返回0表示失败,其他值作为NETDEV_StopGetFile等函数的参数. Download handle. 0 means failure. Other values are used as the handle parameters of functions like NETDEV_StopGetFile.
        * @note
        */
        IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        /**
         * 停止下载录像文件 Stop downloading recording files
         * @param [IN]  lpPlayHandle  回放句柄 Playback handle
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);

        Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        /**
        * 设置设备的配置信息  Modify device configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CONFIG_COMMAND_E  Device configuration commands, see #NETDEV_CONFIG_COMMAND_E
        * @param [IN]   index               输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        /**
        * 设置透雾模式信息  Set defogging info
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_DEFOGGINGINFO  Device configuration commands, see #NETDEV_SET_DEFOGGINGINFO
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        /**
        * 获取透雾模式信息  Get defogging info
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_DEFOGGINGINFO  Device configuration commands, see #NETDEV_GET_DEFOGGINGINFO
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置运动检测告警信息  Set motion alarm configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_MOTIONALARM  Device configuration commands, see #NETDEV_SET_MOTIONALARM
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取运动检测告警信息  Get motion alarm configuration information
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_MOTIONALARM  Device configuration commands, see #NETDEV_GET_MOTIONALARM
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取遮挡检测告警信息   Get tamper alarm configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_TAMPERALARM  Device configuration commands, see #NETDEV_SET_MOTIONALARM
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置遮挡检测告警信息   Set tamper alarm configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_TAMPERALARM  Device configuration commands, see #NETDEV_SET_MOTIONALARM
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 设置NTP参数   Get NTP parameter
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_NTPCFG_EX  Device configuration commands, see #NETDEV_SET_NTPCFG_EX
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取OSD参数能力集   OSD parameter capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_OSD  Device configuration commands, see #NETDEV_CAP_OSD
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取视频编码能力集   Video encoding capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_VIDEO_ENCODE_EX  Device configuration commands, see #NETDEV_CAP_VIDEO_ENCODE_EX
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取OSD参数能力集   OSD parameter capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_OSD  Device configuration commands, see #NETDEV_CAP_OSD
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDeviceCapability(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取视频编码能力集   Video encoding capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_VIDEO_ENCODE_EX  Device configuration commands, see #NETDEV_CAP_VIDEO_ENCODE_EX
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDeviceCapability(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取客流量统计 Obtain traffic statistic
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [OUT]  pstPeopleCounter        客流量统计列表 People counting list
        * @return TRUE表示成功,其他表示失败 TRUE means success, any other value indicates failure.
        * @note无
        */
        Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        /**
        * 设置保活参数 Set keep-alive parameters
        * @param [IN]  dwWaitTime            间隔等待时间  Waiting time
        * @param [IN]  dwTrytimes            尝试连接次数  Connecting attempts
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);

        /**
        * 设置流畅性优先 Set pictuer fluency
        * @param [IN] lpPlayHandle         预览\回放句柄 Preview\playback handle
        * @param [IN] dwFluency           图像播放流畅性优先类型,参见枚举#NETDEV_PICTURE_FLUENCY_E
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle, Int32 dwFluency);

        /**
        * 动态产生一个关键帧 Dynamically create an I frame 
        * @param [IN] lpUserID       用户登录句柄  User login ID
        * @param [IN] dwChannelID    通道号  Channel ID
        * @param [IN] dwStreamType   参考枚举NETDEV_LIVE_STREAM_INDEX_E  See enumeration NETDEV_LIVE_STREAM_INDEX_E
        * @return NETDEV_E_SUCCEED   表示成功,其他表示失败  NETDEV_E_SUCCEED means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);

        /**
        * 获取扬声器音量 Get sound volume
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @param [IN]  pdwVolume        音量 Volume
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);

        /**
         * 调节扬声器音量 Control sound volume
         * @param [IN]  lpPlayHandle   预览句柄 Preview handle
         * @param [IN]  dwVolume       音量 Volume
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        /**
        * 获取麦克风音量 Get mic volume
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @param [IN]  pdwVolume        音量 Volume
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        /**
         * 调节麦克风音量  Adjust sound volume of microphone
         * @param [IN]  lpPlayHandle     预览句柄 Preview handle 
         * @param [IN]  dwVolume             音量 Sound volume
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        /**
         * 开启麦克风 Turn on microphone
         * @param [IN]  lpPlayHandle   预览句柄 Preview handle
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        /**
        * 关闭麦克风 Turn off microphone
        * @param [IN]  lpPlayHandle   预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        /**
        * 开启输入语音数据服务
        * @param [IN]  lpUserID                 用户ID
        * @param [IN]  dwChannelID              通道号
        * @param [IN]  cbRealDataCallBack       码流数据回调函数指针
        * @param [IN]  lpUserData               用户数据
        * @return 返回的语音对讲句柄,返回 0 表示失败
        * @note
        */
        IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        /**
        * 关闭输入语音数据服务
        * @param [IN]  lpVoiceComHandle   对讲句柄
        * @return TRUE表示成功,其他表示失败
        * @note
        */
        Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        /**
        * 输入语音数据
        * @param [IN]  lpVoiceComHandle         对讲句柄
        * @param [IN] lpDataBuf                 语音数据地址
        * @param [IN] dwDataLen                 语音数据长度
        * @param [IN] pstVoiceParam             语音参数
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        //         //  Int32 NETDEV_GetPARKVersion(IntPtr lpszVersion);

        /* interface function end */

        Int32 NETDEV_GetSDKVersion();

        /**
        * 用户登录  User login
        * @param [IN]  pszDevIP         设备IP Device IP
        * @param [IN]  wDevPort         设备服务器端口 Device server port
        * @param [IN]  pszUserName      用户名 Username
        * @param [IN]  pszPassword      密码 Password
        * @param [OUT] pstDevInfo       设备信息结构体指针 Pointer to device information structure
        * @return 返回的用户登录句柄,返回 0 表示失败,其他值表示返回的用户登录句柄值. Returned user login ID. 0 indicates failure, and other values indicate the user ID.
        * @note
        */
        IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        /**
        * 用户注销  User logout
        * @param [IN] lpUserID    用户登录句柄 User login ID
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_Logout(IntPtr lpUserID);

        Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        /**
        * 重置窗口丢包率  Reset window packet loss rate
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        /**
        * 非预览下抓拍  Snapshot without preview
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  dwStreamType;        码流类型,参见枚举#NETDEV_LIVE_STREAM_INDEX_E  Stream type, see enumeration #NETDEV_LIVE_STREAM_INDEX_E 
        * @param [IN]  pszFileName          保存图像的文件路径（包括文件名） File path to save images (including file name)
        * @param [IN]  dwCaptureMode        保存图像格式,参见#NETDEV_PICTURE_FORMAT_E   Image saving format, see #NETDEV_PICTURE_FORMAT_E
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
                仅支持JPG格式.
                Only JPG format is supported.
        */
        Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        /**
        * 设置视频图像显示比例  Modify image display ratio
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN]  enRenderScale  视频图像的显示比例 Image display ratio
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        /**
        * 按名称回放录像文件  Play back recording files by name
        * @param [IN] lpUserID          用户登录句柄 User login ID
        * @param [IN] pstPlayBackInfo   录像回放结构体指针,参考 LPNETDEV_PLAYBACKINFO_S Pointer to recording playback structure, see LPNETDEV_PLAYBACKINFO_S
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        /**
        * 按时间回放录像文件  Play back recording by time. 
        * @param [IN] lpUserID          用户登录句柄 User login ID
        * @param [IN] pstPlayBackCond   按时间录像回放结构体指针  参考 LPNETDEV_PLAYBACKCOND_S Pointer to playback-by-time structure, see LPNETDEV_PLAYBACKCOND_S
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        /**
        * 停止回放业务  Stop playback service
        * @param [IN] lpPlayHandle  回放句柄 Playback handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        /**
        * 按文件名下载录像文件 Download recordings by file name
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  pstPlayBackInfo      录像回放结构体指针,参考 LPNETDEV_PLAYBACKINFO_S Pointer to recording playback structure, see LPNETDEV_PLAYBACKINFO_S
        * @param [IN]  *pszSaveFileName     下载后保存到PC机的文件路径,需为绝对路径（包括文件名） Downloaded file save path on PC, must be an absolute path (including file name)
        * @param [IN]  dwFormat             录像文件保存格式 Recording file saving format
        * @return 下载句柄, 返回0表示失败,其他值作为NETDEV_StopGetFile等函数的参数. Download handle. 0 means failure. Other values are used as the handle parameters of functions like NETDEV_StopGetFile.
        * @note
        */
        IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        /**
        * 云台预置位操作(需先启动预览)  PTZ preset operation (preview required)
        * @param [IN]  lpPlayHandle         实时预览句柄 Live preview handle
        * @param [IN]  dwPTZPresetCmd       操作云台预置位命令,参考枚举NETDEV_PTZ_PRESETCMD_E  PTZ preset operation commands, see NETDEV_PTZ_PRESETCMD_E
        * @param [IN]  pszPresetName        预置位的名称 Preset name
        * @param [IN]  dwPresetID           预置位的序号（从1开始）,最多支持255个预置位 Preset number (starting from 1). Up to 255 presets are supported.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        /**
        * 获取设备的配置信息  Get configuration information of device
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_CONFIG_COMMAND_E  Device configuration commands, see #NETDEV_CONFIG_COMMAND_E
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 1.巡航路径ID不可修改.  Route ID cannot be modified.
        * - 2.新增巡航路径时,默认按顺序新增.  New routes are added one after another.
        * - 3.删除.开始.停止巡航路径时,pstCruiseInfo中只需要填写巡航路径ID即可.  When deleting, starting or stoping a patrol route, enter route ID in pstCruiseInfo.
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置设备的配置信息  Modify device configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CONFIG_COMMAND_E  Device configuration commands, see #NETDEV_CONFIG_COMMAND_E
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        /**
         * 重启设备  Reboot Device
         * Restart device
         * @param [IN]  lpUserID     用户登录句柄 User login ID
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         */
        Int32 NETDEV_Reboot(IntPtr lpUserID);

        /**
        * 开启声音  Enable sound
        * @param [IN]  lpPlayHandle   预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        /**
        * 关闭声音 Mute
        * @param [IN]  lpPlayHandle   预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        /**
        * 获取错误码  Get error codes
        * @return 错误码 Error codes
        */
        Int32 NETDEV_GetLastError();

        /**
        * 拉框放大.缩小(不需要启动预览)   Drag to zoom in and out(preview not required)
        * @param lpUserID                   用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  pstPtzOperateArea    拉框放大结构体信息 Drag-to-zoom structure information
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 在我司NVR下,需通过私有协议连接我司IPC才支持该接口  In our NVR, this interface is supported only when our camera is connected through private protocol.
        */
        Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        /**
        * 设备登录
        * @param [IN]  pstDevLoginInfo  设备登录信息
        * @param [OUT] pstSELogInfo     安全登录信息，包含登录失败次数及下次登录时间
        * @return 返回值为用户ID。
        * @note 安全登录信息此字段仅适用于使用LAPI协议登录的设备
        * -
        */
        IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        /**
        * 查询组织信息列表
        * @param [IN] lpUserID          用户登录ID
        * @param [IN] pstFindCond       查找组织信息列表条件
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextOrgInfo、NETDEV_FindCloseOrgInfo等函数的参数。
        * @note
        */
        IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        /**
        * 逐个获取查找到的组织信息
        * @param [IN]  lpFindHandle                 查找句柄 
        * @param [OUT] pstOrgInfo                   保存组织信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        /**
        * 关闭查找 组织信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        /**
        * 添加组织
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] pstOrgInfo            组织信息指针
        * @param [OUT] dwOrgID             组织ID
        * @return TRUE           表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        /**
        * 修改组织
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] dwOrgID              组织ID
        * @param [IN] pstOrgInfo            组织信息指针
        * @return TRUE           表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        /**
        * 批量删除组织
        * @param [IN] lpUserID             用户登录ID
        * @param [IN] pstOrgDelInfo       待删除组织信息指针
        * @param [OUT] pstOrgDelResultInfo  删除组织响应信息指针
        * @return TRUE           表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        /**
        * 通过 设备类型 查询 设备列表
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] dwDevType             设备类型 参见#NETDEV_DEVICE_MAIN_TYPE_E
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextOrgInfo、NETDEV_FindCloseOrgInfo等函数的参数。
        * @note
        */
        IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        /**
        * 逐个获取查找到的 设备信息
        * @param [IN]  lpFindHandle                 查找句柄 
        * @param [OUT] pstDevBasicInfo              保存 设备详细信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        /**
        * 关闭查找 设备信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        /**
        * 通过设备ID或通道类型 查询通道信息列表
        * @param [IN] lpUserID          用户登录ID
        * @param [IN] dwDevID           设备ID
        * @param [IN] dwChnType         通道类型，参见# NETDEV_CHN_TYPE_E
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextDevChn、NETDEV_FindCloseDevChn等函数的参数。
        * @note     1、只根据通道类型查询时，将设备ID设置为0.
        */
        IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        /**
        * 逐个获取查找到的 设备通道 信息
        * @param [IN]  lpFindHandle         查找句柄 
        * @param [OUT] lpOutBuffer          接收数据的缓冲指针
        * @param [IN] dwOutBufferSize       接收数据的缓冲长度(以字节为单位)，不能为0
        * @param [OUT] pdwBytesReturned     实际收到的数据长度指针，不能为NUL
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 关闭查找 设备通道信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        /**
        * 获取设备信息        GetDeviceInfos
        * @param [IN] lpUserID          用户登录句柄 User login handle
        * @param [OUT] pstDevInfo       设备信息结构体指针 Pointer to device information structure
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        /**
        * 查询设备详细信息   GetDeviceInfo_V30
        * @param [IN] lpUserID              用户登录ID     User login handle
        * @param [IN] dwDevID               设备ID         Device ID
        * @param [OUT]  pstDevDetailInfo    设备详细信息   Pointer to device information structure
        * @return TRUE表示成功，其他表示失败         TRUE means success, and any other value means failure.
        * @note
        * -
        */
        Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        /**
        * 获取通道类型
        * @param [IN] lpUserID              用户登录ID     User login ID
        * @param [IN] dwChnID               通道ID         channel ID
        * @param [OUT] pdwChnType           设备通道类型 参见# NETDEV_CHN_TYPE_E  See# NETDEV_CHN_TYPE_E
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        /**
        * 根据通道类型和通道ID获取通道详细信息  GetChnDetailByChnType
        * @param [IN] lpUserID              用户登录ID   user login id 
        * @param [IN] dwChnID               通道ID       channle ID
        * @param [IN] dwChnType             通道类型,参见# NETDEV_CHN_TYPE_E    See # NETDEV_CHN_TYPE_E
        * @param [INOUT] lpOutBuffer        接收数据的缓冲指针                  Point to out data buffer
        * @param [IN] dwOutBufferSize       接收数据的缓冲长度(以字节为单位)，不能为0     recv buffer date
        * @param [OUT] pdwBytesReturned     实际收到的数据长度指针，不能为NULL
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 一体机
        */
        Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID, Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取云台预置位巡航路径  Get PTZ preset patrol route
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [OUT]  pstCruiseList        巡航路径列表 Patrol route list
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        /**
        * 云台预置位巡航操作(不需要启动预览)  PTZ preset patrol operation (preview not required)
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  dwPTZCruiseCmd       操作云台巡航命令,参考#NETDEV_PTZ_CRUISECMD_E  PTZ patrol operation commands, see #NETDEV_PTZ_CRUISECMD_E
        * @param [IN]  pstCruiseInfo         云台巡航路径信息,参考#LPNETDEV_CRUISE_INFO_S  PTZ patrol route information, see #LPNETDEV_CRUISE_INFO_S
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 1.巡航路径,最多支持16条路径（序号从1开始） Patrol route. Up to 16 routes are supported (starting from 1).
        * - 2.巡航点,最多支持32个点（序号从1开始） Patrol point. Up to 32 points are supported (starting from 1).
        * - 3.预置位(最大255).时间(最大255).速度(最大40)  Preset (max 255), time (max 255) and speed (max 40).
        */
        Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        /**
        * 获取云台轨迹巡航路径  Get PTZ patrol route
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [OUT]  pstTrackCruiseInfo        巡航路径列表,参考#LPNETDEV_PTZ_TRACK_INFO_S  Patrol route list, see #LPNETDEV_PTZ_TRACK_INFO_S
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        /**
        * 云台轨迹巡航操作(不需要启动预览)   PTZ route patrol operation (preview not required)
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  dwPTZCruiseCmd       操作云台轨迹巡航命令,参考#NETDEV_PTZ_TRACKCMD_E  PTZ route patrol operation commands, see #NETDEV_PTZ_TRACKCMD_E
        * @param [INOUT]  pszTrackCruiseName         轨迹巡航名称,建议长度#NETDEV_LEN_64  Route patrol name, suggested length #NETDEV_LEN_64
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 1.巡航轨迹路径,最多支持1条路径  Only one patrol route allowed.
        */
        Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        /**
         * 设置视频编码参数  Set video encoding parameter
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_STREAMCFG  Device configuration commands, see #NETDEV_SET_STREAMCFG
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取云台状态  Get PTZ status
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_PTZSTATUS  Device configuration commands, see #NETDEV_GET_PTZSTATUS
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PTZ_STATUS_S lpInBuffer, Int32 dwInBufferSize, ref int pdwBytesReturned);

        /**
        * 云台标定 PTZ Calibrate
        * @param [IN]  lpUserID                      用户登录句柄 User login ID
        * @param [IN]  dwChannelID                   通道号 Channel ID
        * @param [IN]  pstOrientationInfo            云台方位信息 PTZ Orientation info
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        /**
        * 获取视频编码参数  Get video encoding parameter
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_STREAMCFG  Device configuration commands, see #NETDEV_GET_STREAMCFG
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置图像配置信息  Set image configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_IMAGECFG  Device configuration commands, see #NETDEV_SET_IMAGECFG
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取图像配置信息  Get image configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_IMAGECFG  Device configuration commands, see #NETDEV_GET_IMAGECFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置NTP参数   Set NTP parameter
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_NTPCFG   Device configuration commands, see #NETDEV_SET_NTPCFG 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取NTP参数  Get NTP parameter
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_NTPCFG  Device configuration commands, see #NETDEV_GET_NTPCFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置网络配置信息  Set network configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_NETWORKCFG   Device configuration commands, see #NETDEV_SET_NETWORKCFG 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取网络配置信息  Get network configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_NETWORKCFG  Device configuration commands, see #NETDEV_GET_NETWORKCFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置开关量输出配置信息  Set boolean configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_ALARM_OUTPUTCFG   Device configuration commands, see #NETDEV_SET_ALARM_OUTPUTCFG 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取开关量输出配置信息  Get boolean configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_ALARM_OUTPUTCFG  Device configuration commands, see #NETDEV_GET_ALARM_OUTPUTCFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置录像计划配置信息   Set support NVR VMS
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_ALARM_OUTPUTCFG   Device configuration commands, see #NETDEV_SET_ALARM_OUTPUTCFG 
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
       * 获取录像计划配置信息 Get support NVR VMS
       * @param [IN]   lpUserID            用户登录句柄 User login ID
       * @param [IN]   dwChannelID         通道号 Channel ID
       * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_RECORDPLANINFO
       * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
       * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
       * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
       * @note
       */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 触发开关量  Trigger boolean
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_TRIGGER_ALARM_OUTPUT_S see #NETDEV_TRIGGER_ALARM_OUTPUT_S 
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        /**
       * 触发开关量（暂不支持）  Trigger boolean
       * @param [IN]   lpUserID            用户登录句柄 User login ID
       * @param [IN]   dwChannelID         通道号 Channel ID
       * @param [IN]   dwCommand           设备配置命令,参见#
       * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
       * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
       * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
       * @note
       */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
       * 设置OSD配置信息  Set OSD configuration information
       * @param [IN]   lpUserID            用户登录句柄 User login ID
       * @param [IN]   dwChannelID         通道号 Channel ID
       * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_VIDEO_OSD_CFG_S see #NETDEV_VIDEO_OSD_CFG_S 
       * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
       * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
       * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
       * @note
       */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
         * 获取OSD配置信息  Get OSD configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_VIDEO_OSD_CFG_S  see #NETDEV_VIDEO_OSD_CFG_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取开关量输入数量 Get the number of boolean inputs
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_ALARM_INPUT_LIST_S  see #NETDEV_ALARM_INPUT_LIST_S 
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置开关量输出配置信息  Set boolean configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_ALARM_OUTPUT_LIST_S see #NETDEV_ALARM_OUTPUT_LIST_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 获取设备信息  Get device information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_DEVICE_BASICINFO_S see #NETDEV_DEVICE_BASICINFO_S 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取隐私遮盖配置信息  Get privacy mask configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_PRIVACY_MASK_CFG_S see #NETDEV_PRIVACY_MASK_CFG_S
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置隐私遮盖配置信息  Set privacy mask configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_PRIVACY_MASK_CFG_S see #NETDEV_PRIVACY_MASK_CFG_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
         * 获取NTP参数   Get NTP parameter
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SYSTEM_NTP_INFO_S see #NETDEV_SYSTEM_NTP_INFO_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取通道的图像曝光参数   get image Exposure configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IMAGE_EXPOSURE_S see #NETDEV_IMAGE_EXPOSURE_S
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置通道的图像曝光参数  Set image Exposure configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IMAGE_EXPOSURE_S see #NETDEV_IMAGE_EXPOSURE_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        /**
          * 获取昼夜模式信息  Get IRcut filter info
          * @param [IN]   lpUserID            用户登录句柄 User login ID
          * @param [IN]   dwChannelID         通道号 Channel ID
          * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IRCUT_FILTER_INFO_S see #NETDEV_IRCUT_FILTER_INFO_S
          * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
          * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
          * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
          * @note
          */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置昼夜模式信息  Set IRcut filter info
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IRCUT_FILTER_INFO_S see #NETDEV_IRCUT_FILTER_INFO_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
          * 获取车位信息
          * @param [IN]   lpUserID            用户登录句柄 User login ID
          * @param [IN]   dwChannelID         通道号 Channel ID
          * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_ITS_PARKING_DETECTION_S see #NETDEV_ITS_PARKING_DETECTION_S
          * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
          * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
          * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
          * @note
          */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ITS_PARKING_DETECTION_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
          * 获取OSD内容样式  Get OSD content style
          * @param [IN]   lpUserID            用户登录句柄     User login ID
          * @param [IN]   dwChannelID         通道号           Channel ID
          * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_OSD_CONTENT_STYLE_S   see #NETDEV_OSD_CONTENT_STYLE_S
          * @param [IN]   lpInBuffer          输入数据的缓冲指针   Pointer to buffer of input data
          * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位)  Length of input data buffer (byte)
          * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
          * @note
          */
        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置OSD内容样式 Set OSD content style
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_OSD_CONTENT_STYLE_S see #NETDEV_OSD_CONTENT_STYLE_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 恢复出厂设置  Restore to factory default settings
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 保留网络配置和用户配置,其他参数恢复到出厂设置. Restore all parameters to factory settings, except network settings and user settings.
        */
        Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        /**
        * 影像参数获取,只获取当前画面参数  Get the current image info
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN]  pstImageInfo   图像信息列表 Image information list
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        /**
        * 影像调节,只改变当前画面  Adjust the current image
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN]  pstImageInfo   图像信息列表 Image information list
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        /**
        * 设置数字放大  Set Digital zoom
        * @param [IN] lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN] hWnd           窗口句柄  window handle 
        * @param [IN] pstRect        矩形区域 Rectangle Area
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note pstRect为空时,显示全部画面,即退出数字放大 All images will be displayed with digital zoom disabled when pstRect is null
        */
        Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        /**
        * 获取映射端口 Get UPnP net state info
        * @param [IN]   lpUserID     用户登录句柄 User login ID
        * @param [IN]   pstNatState  网络端口号状态信息 UPnP nat state info
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        /**
        * 修改设备名称 Set device name
        * @param [IN] lpUserID         用户登录句柄 User login ID
        * @param [IN] pszDeviceName    设备名称  Device name
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        /**
        * 设置日志路径业务 Set log path
        * @param [IN]   pszLogPath  日志路径(不包含文件名)  Log path (file name not included)
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetLogPath(String strLogPath);

        /**
        * 设置日志文件大小和数量 Set log file size and number
        * @param [IN] dwLogFileSize     单个日志文件大小(单位字节) The size of single log file
        * @param [IN] dwLogFileNum      日志文件个数  Log file number
        * @return TRUE表示成功,其他表示失败 TRUE means success, any other value indicates failure.
        * @note
        */
        Int32 NETDEV_ConfigLogFile(Int32 dwLogFileSize, Int32 dwLogFileNum);

        /**
        * 获取设备系统时间配置 Get device System time configuration
        * @param [IN]  pstSystemTimeInfo    时间配置结构体指针  Pointer to time configuration structure
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        */
        Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        /**
        * 设置设备系统时间配置 Set device system time configuration
        * @param [IN]  pstSystemTimeInfo    时间配置结构体指针  Pointer to time configuration structure
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        */
        Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        /**
        * 设置超时时间 Set timeout
        * @param [IN]  pstRevTimeout         超时时间指针 Pointer to timeout
        * @return TRUE表示成功,其他表示失败    TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        /**
        * 注册实时码流回调函数：解码后视频媒体流数据  Callback function to register live stream (decoded media stream data)
        * @param [IN]  lpPlayHandle                 预览\回放句柄 Preview\playback handle
        * @param [IN]  cbPlayDecodeVideoCALLBACK    数据回调函数 Data callback function
        * @param [IN]  bContinue                    是否继续进行后面的显示操作 Whether to continue to following displaying operations.
        * @param [IN]  lpUserData                   用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 若关闭回调函数,将第二个参数置为NULL.
        * - To shut the callback function, set the second parameter as NULL.
        */
        Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, ref NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);
        // Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, IntPtr cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        /**
        * 注册码流回调函数:原始码流  Callback function to register streams (original stream)
        * @param [IN]  lpPlayHandle               实时预览句柄 Live preview handle
        * @param [IN]  cbSourceDataCallBack       码流数据回调函数 Callback function for stream data
        * @param [IN]  bContinue                  是否继续进行后面的拼帧.解码和显示操作 Whether to continue to following framing, decoding and displaying operations.
        * @param [IN]  lpUser                     用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        /**
        * 设置显示后数据回调  Modify displayed data callback
        * @param [IN]  lpPlayHandle             预览\回放句柄 Preview\playback handle
        * @param [IN]  cbPlayDisplayCallBack    数据回调函数 Data callback function
        * @param [IN]  lpUserData               用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 若关闭回调函数,将第二个参数置为NULL.
        * - To shut the callback function, set the second parameter as NULL.
        */
        Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        /**
        * 注册实况码流回调函数:拼帧后码流数据  Callback function to register live stream (framed stream data)
        * @param [IN]  lpPlayHandle              预览\回放句柄 Preview\playback handle
        * @param [IN]  cbParsePlayDataCallBack   数据回调函数 Data callback function
        * @param [IN]  bContinue                 是否继续进行后面的解码和显示操作 Whether to continue to following decoding and displaying operations.
        * @param [IN]  lpUserData                用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 若关闭回调函数,将第二个参数置为NULL.
        * - To shut the callback function, set the second parameter as NULL.
        */
        Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, ref NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);
        //Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        /**
        * 开启语音对讲 Start two-way audio
        * @param [IN]  lpUserID                 用户登录句柄  User ID
        * @param [IN]  dwChannelID              通道号  Channel ID
        * @param [IN]  cbRealDataCallBack       码流数据回调函数指针  Pointer to callback function of the stream data 
        * @param [IN]  lpUserData               用户数据   User data
        * @return 返回的用户登录句柄,返回 0 表示失败,其他值表示返回的用户登录句柄值 Returned user ID. 0 means failure, and any other value is a user ID.
        * @note
        */
        IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        /**
        * 关闭语音对讲 Stop two-way audio
        * @param [IN]  lpPlayHandle   对讲句柄 Two-way audio handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, any other value indicates failure.
        * @note
        */
        Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);

        Int32 NETDEV_GetCloudDevInfoByName(IntPtr lpUserID, String pszRegisterCode, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo);

        Int32 NETDEV_GetCloudDevInfoByRegCode(IntPtr lpUserID, String pszRegisterName, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo);

        /**
        * 获取所有用户全部信息  GetUserDetailList
        * @param [IN]   lpUserID                    用户登录ID     User login ID
        * @param [OUT]   pstUserDetailList          用户信息 请参见结构体#LPNETDEV_USER_DETAIL_LIST_S   See #LPNETDEV_USER_DETAIL_LIST_S
        * @return TRUE表示成功,其他表示失败     TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        /**
        * 删除用户信息  Delete User Info
        * @param [IN]   lpUserID                用户登录ID   User login ID
        * @param [IN]   pszUserName             用户名       User name
        * @return TRUE表示成功,其他表示失败     TRUE means success, and any other value means failure.
        * @note 无 None
        */
        Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        /**
        * 创建用户信息  CreateUser
        * @param [IN]   lpUserID                      用户登录ID      User login ID
        * @param [IN]   pstUserDetailInfo             用户信息请参见结构体#NETDEV_USER_DETAIL_INFO_S    See #NETDEV_USER_DETAIL_INFO_S
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        /**
        * 修改用户信息  ModifyUser
        * @param [IN]   lpUserID                用户登录ID        User login ID
        * @param [IN]   pstUserInfo             用户信息请参见结构体#NETDEV_USER_INFO_S    User modify info See#NETDEV_USER_INFO_S 
        * @return TRUE表示成功,其他表示失败
        * @note
            1、仅管理员用户支持修改权限，管理员用户修改其他用户信息不需要携带旧密码
            2、操作员及普通用户只能修改自己的密码
        */
        Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        /**
        * 获取设备电子罗盘信息 Obtain compass info
        * @param [IN]   lpUserID                用户登录ID      User login ID
        * @param [IN]   dwChannelID             通道号          Channel ID
        * @param [OUT]  pfCompassInfo           电子罗盘信息（与正北的夹角）   Electronic compass info
        * @return TRUE表示成功,其他表示失败     TRUE means success, and any other value means failure.
        * @note无
        */
        Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        /**
        * 获取设备定位信息 Obtain geolocation info
        * @param [IN]   lpUserID                用户登录ID User login ID
        * @param [IN]   dwChannelID             通道号  Channel ID
        * @param [OUT]  pstGPSInfo              定位信息 Geolocation info
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note无
        */
        Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        /**
        * 导出配置文件业务    GetConfigFile
        * @param [IN]   lpUserID                  用户登录ID User login ID
        * @param [IN]   pszConfigPath             配置文件路径（包含文件名称,后缀名为tgz）  cfg file path（tgz）
        * @return TRUE表示成功,其他表示失败       TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        /**  
        * 导入配置文件业务                        SetConfigFile
        * @param [IN]   lpUserID                  用户登录ID        User login ID
        * @param [IN]   pszConfigPath             配置文件路径（包含文件名称,命名格式：设备型号_IP地址_config.tgz, 如：HIC5621E-L-U_192.168.3.112_config.tgz）
        *                                         EX：HIC5621E-L-U_192.168.3.112_config.tgz）
        * @return TRUE表示成功,其他表示失败       TRUE means success, and any other value means failure
        * @note
        */
        Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        /**
        * 元数据处理
        * @param [IN] lpPlayHandle              播放句柄
        * @param [IN] bEnableIVA                是否添加元数据
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        /**
        * 设置元数据绘图显示类型参数
        * @param [IN] dwShowParam              元数据显示类型参数，参见# NETDEV_IVA_SHOW_RULE_E
        * @return TRUE表示成功,其他表示失败
        * @note
        * -    1.该接口函数仅支持Windows.
        * -    2.请将规则进行组合,比如显示规则线框和触发规则目标框,下发的ulShowParam = NETDEV_IVA_SHOW_RULE|NETDEV_IVA_SHOW_RESULT_TOUTH_RULE；以此类推
        * -    3.已最后一次设置的显示类型为准,之前设置的显示操作取消
        */
        Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        /**
        * 查询所有人员库的容量信息
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @param [IN]   dwTimeOut              连接超时时间
        * @param [OUT]  pstCapacityList   所有人员库的容量信息
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID, Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        /**
        * 创建人员库信息                                Create Person libraries information
        * @param [IN]  lpUserID                         用户登录句柄 User login ID
        * @param [IN]  pstLibraryList                   人员库信息 Person library information
        * @param [OUT]  *pudwID                         创建库生成的库ID create library generated libry ID
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref UInt32 pudwID);

        /**
        * 查询所有已创建的人员库信息 Get all Person libraries information
        * @param [IN]  lpUserID         用户登录句柄 User login ID
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextPersonLibInfo、NETDEV_FindClosePersonLibList等函数的参数。
        * @note无
        */
        IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        /**
        * 逐个获取查找到的 人脸库 信息
        * @param [IN]  lpFindHandle           查找句柄 
        * @param [OUT] pstPersonLibInfo       保存 人脸库 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        /**
        * 关闭查找 人脸库，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        /**
        * 修改人员库信息  Modify Person libraries information
        * @param [IN]  lpUserID         用户登录句柄 User login ID
        * @param [IN]  pstLibraryList   人员库信息 Person library information
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        /**
        * 删除指定的人员库    Delete designated Person libraries information
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @param [IN]  udwPersonLibID   人员库ID Person library ID
        * @param [IN]  pstFlagInfo   人员库删除标志
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        /**
        * 条件查询人员信息
        * @param [IN] lpUserID 用户登录句柄
        * @param [IN] udwPersonLibID 人员库ID
        * @param [IN] pstQueryInfo 人脸信息查询条件
        * @param [OUT] pstQueryResultInfo 人脸信息查询返回结果
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextPersonInfo、NETDEV_FindClosePersonInfoList等函数的参数
        * @note
        */
        IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        /**
        * 逐个获取查找到的 人员 信息
        * @param [IN]  lpFindHandle            查找句柄 
        * @param [OUT] pstPersonInfo          保存 人员信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        /**
        * 关闭查找 人员信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);

        Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        /**
        * 新增指定的人员信息 Add designated Person information
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  udwPersonLibID       人员库ID Person library ID
        * @param [IN]  pstPersonInfoList    人员信息列表 Person information list
        * @param [OUT]  pstPersonResultList 人员信息结果列表 Person information result list
        * @return TRUE表示成功,其他表示失败
        * @note pstPersonResultList->pstPersonList need malloc by caller
                keep pstPersonResultList->udwNum == pstPersonInfoList->udwNum
        */
        Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        /**
        * 修改指定的人员信息 Modify designated Person information
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  udwPersonLibID       人员库ID Person library ID
        * @param [IN]  pstPersonInfoList    人员信息列表 Person information list
        * @param [OUT]  pstPersonResultList 人员信息结果列表 Person information result list
        * @return TRUE表示成功,其他表示失败
        * @note pstPersonResultList->pstPersonList need malloc by caller
                keep pstPersonResultList->udwNum == pstPersonInfoList->udwNum
        */
        Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        /**
         * 删除指定的人员信息 Delete designated Person information
         * @param [IN]  lpUserID         用户登录句柄 User login ID
         * @param [IN]  udwPersonLibID   人员库ID Person library ID
         * @param [IN]  udwPersonID      人员ID Person ID
         * @param [IN]  udwLastChange    最后修改时间 Last modify time
         * @return TRUE表示成功,其他表示失败
         * @note无
         */
        Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);

        /**
        * 批量删除人员信息
        * @param [IN] lpUserID             用户登录ID
        * @param [IN] udwPersonLibID       人脸库ID
        * @param [IN] pstIDList            人脸成员列表
        * @param [OUT] pstBatchList        批量操作返回信息
        * @return 查询句柄,返回0表示失败，
        * @note 仅VMS支持
        */
        Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        /**
        * 查询人脸识别记录
        * @param [IN]  lpUserID                   用户登录ID 
        * @param [IN]  pstFindCond                查询条件
        * @param [OUT] pstResultInfo              人脸识别记录信息
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindFaceNextRecordDetail、NETDEV_FindFaceCloseRecordDetail等函数的参数。
        * @note     查询完成之后需要保证调用NETDEV_FindFaceNextRecordDetail将所有数据取出，否则会造成内存泄露
        */
        IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        /**
        * 逐个获取查找到的 人脸识别记录信息
        * @param [IN]  lpFindHandle                    查找句柄 
        * @param [OUT] pstRecordInfo                   保存 人脸识别记录 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        /**
        * 关闭查找 人脸识别记录，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        /**
        * 查询单个人脸识别记录的人脸图片信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN] udwRecordID                  人脸识别告警记录ID
        * @param [IN] udwFaceImageType              人脸通行记录类型
        * @param [OUT] pstFileInfo                 人脸图片信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note pstFileInfo中人脸图片内存由使用者维护，入参时需指定udwSize大小，内存不够调用失败时，udwSize会返回实际需要大小
        */
        Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        /**
        * 查询所有人脸布控任务
        * @param [IN]  lpUserID              用户登录ID
        * @param [IN]  udwChannelID          通道ID，仅NVR查询通道布控信息时使用
        * @param [IN]  pstQueryInfo          查询条件，仅NVR支持
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextPersonMonitorInfo、NETDEV_FindCloseMonitorInfo等函数的参数。
        * @note    
        */
        IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        /**
        * 逐个获取查找到的 布控任务 信息
        * @param [IN]  lpFindHandle            查找句柄 
        * @param [OUT] pstMonitorInfo          保存 布控任务 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        *.      返回NETDEV_E_NEED_MORE_MEMORY说明分配不足，并返回实际应申请的内存大小；涉及的数据：pstMonitorInfo->udwLinkStrategyNum、
                 pstMonitorInfo->stMonitorRuleInfo.udwChannelNum
        */
        Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        /**
        * 关闭查找 布控任务，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        /**
        * 新增单个人脸布控任务 
        * @param [IN]    lpUserID                      用户登录ID 
        * @param [INOUT]    pstMonitorInfo                保存 布控任务 信息的指针  成功返回布控任务序号
        * @param [INOUT] pstMonitorResultInfo          添加布控后设备返回的实际布控结果
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  pstMonitorResultInfo->udwChannelNum不应小于pstMonitorInfo stMonitorRuleInfo.udwChannelNum
                 pstMonitorResultInfo->udwChannelNum must be Greater thanpstMonitorInfo stMonitorRuleInfo.udwChannelNum    
        */
        Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        /**
        * 批量删除人脸布控任务 
        * @param [IN]  lpUserID                      用户登录ID 
        * @param [INOUT] pstResultList               返回信息列表  输入布控要删除的所有布控ID
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        /**
        * 查询单个人脸布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID 
        * @param [INOUT] pstMonitorInfo            保存 布控任务 信息的指针，输入布控ID，成功返回配置信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note pudwMonitorChlIDList由上层申请；接口失败(NETDEV_E_NEED_MORE_MEMORY)时通过udwChannelNum判断是否内存申请过小
        */
        Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        /**
        * 设置单个人脸布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID 
        * @param [IN] pstMonitorInfo               保存 布控任务 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        IntPtr NETDEV_FindMonitorDevResult(IntPtr lpUserID, ref UInt32 pudwDevNum);

        Int32 NETDEV_FindNextMonitorDevResult(IntPtr lpFindHandle, ref NETDEV_MONITOR_DEV_RESULT_INFO_S pstMonitorDevResultInfo);

        Int32 NETDEV_FindCloseMonitorDevResult(IntPtr lpFindHandle);

        IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        /**
        * 查询全部车辆库信息列表
        * @param [IN] lpUserID          用户登录ID
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextVehicleLibInfo、NETDEV_FindCloseVehicleLibList等函数的参数。
        * @note     
        */
        IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        /**
        * 逐个获取查找到的 车辆库 信息
        * @param [IN]  lpFindHandle           查找句柄 
        * @param [OUT] pstVehicleLibInfo      保存 车辆库 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        /**
        * 关闭查找 车辆库，释放资源
        close finding vehicleDB Release resources
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        /**
        * 新增单个车辆库信息
        * add vehicleDB information
        * @param [IN] lpUserID                   用户登录ID User login ID
        * @param [INOUT] pstVehicleLibInfo       车库信息VehicleDB info
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        /**
        * 修改指定的车辆库信息
        * Modify the specified vehicleDB information
        * @param [IN] lpUserID                  用户登录ID User login ID
        * @param [IN] pstVehicleLibList         车辆库列表 Vehicle Lib List
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        /**
        * 删除指定的车辆库信息
        * delete the specified vehicleDB information
        * @param [IN] lpUserID                   用户登录ID User login ID
        * @param [IN] udwVehicleLibID            车辆库ID Vehicle DB ID 
        * @param [IN] pstDelLibFlag              删除库信息的标志位
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        /**
        * 批量添加车辆成员信息
        * @param [IN] lpUserID                用户登录ID
        * @param [IN] udwLibID                车辆库ID
        * @param [IN] pstVehicleMemberList    车辆信息列表
        * @param [OUT] pstResultList          批量添加返回结果信息列表
        * @return 查询句柄,返回0表示失败，
        * @note    
        */
        Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        /**
        * 修改指定车辆库中车辆信息
        * modify vehicleDB information
        * @param [IN] lpUserID                        用户登录ID User login ID
        * @param [IN] udwVehicleLibID                 车辆库IDVehicle ID
        * @param [IN] pstVehicleDetailInfo            车辆详细信息 Vehicle Detail info  
        * @param [OUT] pstResultList                  批量操作返回信息 Batch operate result info
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        /**
        * 批量删除车辆成员信息
        * @param [IN] lpUserID                  用户登录ID
        * @param [IN] udwLib                    库序号
        * @param [IN] pstVehicleMemberList      车辆成员列表
        * @param [OUT] pstBatchList             批量操作返回信息
        * @return 查询句柄,返回0表示失败，
        * @note    
        */
        Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        /**
         * 条件查询车辆成员详细信息
         * @param [IN]  lpUserID         用户登录ID
         * @param [IN]  udwVehicleLibID  库序号
         * @param [IN]  pstFindCond      查询条件
         * @param [OUT] pstFaceDBList    人脸库基本信息
         * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextVehicleMemberDetail、NETDEV_FindCloseVehicleMemberDetail等函数的参数。
         * @note    1、人脸库中成员的基本信息由NETDEV_FindNextVehicleMemberDetail查询返回，pstFaceDBList只带回成员的基本信息
         *@           2、调用成功后需要调用NETDEV_FindNextVehicleMemberDetail将数据取完，否则会出现内存泄露
         */
        IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        /**
        * 逐个获取查找到的 车辆成员 信息
        * @param [IN]  lpFindHandle           查找句柄 
        * @param [OUT] pstFaceMemberInfo      保存 车辆库中成员 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        /**
        * 关闭查找 车辆成员，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        /**
        * 条件查询车辆识别记录的详细信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN] pstFindCond                  查询条件
        * @param [OUT] pstResultInfo               查询的记录信息
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindVehicleNextRecordInfo、NETDEV_FindVehicleCloseRecordInfo等函数的参数。
        * @note
        */
        IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        /**
        * 逐个获取查找到的车辆识别记录信息
        * @param [IN]  lpFindHandle                    查找句柄
        * @param [OUT] pstRecordInfo                   保存车辆识别记录信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
            图片数据需要取出另存，否则在调用NETDEV_FindVehicleCloseRecordInfo接口后内存将被释放
        */
        Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        /**
        * 关闭查找车辆识别记录，释放资源
        * @param [IN] lpFindHandle  文件查找句柄
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        /**
        * 查询单个车辆识别记录的车辆图片信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN] udwRecordID                  车辆识别记录ID
        * @param [INOUT] pstFileInfo                 车辆图片信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  pstFileInfo内存由使用者维护，入参时需指定udwSize大小，内存不够调用失败时，udwSize会返回实际需要大小
        对应错误码：NETDEV_E_NEED_MORE_MEMORY   用户分配内存不够；
        */
        Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        /**
        * 向指定的车辆库中批量划归车辆成员
        * .Batch assigned to the vehicle member in the specified database
        * @param [IN] lpUserID                  用户登录ID User login ID
        * @param [IN] udwVehicleLibID           车辆库ID CaVehicleLibID 
        * @param [IN] pstMemberList             批量划归车辆成员ID信息 Batch assigned vehicle member ID information
        * @param [OUT] pstBatchResultList               批量划归车辆信息返回结果 Batch assigned vehicle member ID result
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        /**
         * 批量取消指定的车辆库中车辆成员划归
         * .Batch cancellation to the vehicle member in the specified database
         * @param [IN] lpUserID                  用户登录ID User login ID
         * @param [IN] udwVehicleLibID           车辆库ID VehicleLibID 
         * @param [IN] pstMemberList             批量取消车辆成员ID信息 Batch cancellation vehicle member ID information
         * @param [OUT] pstBatchResultList               批量取消车辆信息返回结果 Batch cancellation vehicle member ID result
         * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        /**
        * 新增单个车辆布控任务
        * @param [IN]  lpUserID                      用户登录ID
        * @param [INOUT]  pstMonitorInfo                布控任务信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 车辆布控比对照片不超过2M,内存由使用者维护
                udwMonitorID 车辆布控任务序号此处作为出参使用，其余参数为入参
        */
        Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        /**
        * 批量删除车辆布控任务
        * @param [IN]  lpUserID用户登录ID
        * @param [INOUT] pstBatchList              信息列表
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        /**
        * 查询车辆识别的所有布控任务
        * @param [IN]  lpUserID              用户登录ID
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextVehicleMonitorInfo、NETDEV_FindCloseVehicleMonitorInfo等函数的参数。
        * @note
        */
        IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        /**
        * 逐个获取查找到的车辆布控任务信息
        * @param [IN]  lpFindHandle            查找句柄
        * @param [OUT] pstMonitorInfo          保存 布控任务 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  车辆布控比对照片内存由使用者维护，入参时，需要指定接收图片缓存大小，失败时会返回实际需要的大小
                如果没有布控图片时，布控图片的大小将会被置为0;
                图片数据需要取出另存，否则在调用NETDEV_FindVehicleCloseRecordInfo接口后内存将被释放;
        */
        Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        /**
        * 关闭查找车辆布控任务，释放资源
        * @param [IN] lpFindHandle  文件查找句柄
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        /**
        * 查询单个车辆布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN]  udwID                       车辆布控ID
        * @param [INOUT] pstMonitorInfo            布控任务信息 输入布控ID,成功时返回配置信息
                                                    udwMonitorID 车辆布控任务序号 IN
                                                    stMonitorRuleInfo 车辆布控任务配置信息 OUT
                                                    stMonitorRuleInfo.stVehicleImage.udwSize 文件大小 INOUT
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 车辆布控比对照片内存由使用者维护，入参时，需要指定接收图片缓存大小，失败时会返回实际需要的大小
        对应错误码：NETDEV_E_NEED_MORE_MEMORY   用户分配内存不够；
        如果没有布控图片时，布控图片的大小将会被置为0;
        */
        Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        /**
        * 设置单个车辆布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN]  udwID                       车辆布控ID
        * @param [INOUT] pstMonitorInfo            布控任务信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 车辆布控比对照片不超过2M,内存由使用者维护
        */
        Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        /**
        * 订阅智能事件
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] pstSubscribeInfo      订阅信息
        * @param [INOUT] pstSmartInfo       智能事件信息，成功返回订阅ID
        * @return TRUE表示成功，其他表示失败
        * @note   订阅前需要先调用NETDEV_SetAlarmCallBack接口注册回调函数
        * -
        */
        Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        /**
        * 取消订阅智能事件
        * @param [IN] lpUserID            用户登录ID
        * @param [IN] pstSmartInfo         智能事件
        * @return TRUE表示成功，其他表示失败
        * @note
        * -
        */
        Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        /**
        * LAPI告警订阅
        * @param [IN] lpUserID                                      用户登录句柄
        * @param IN LPNETDEV_LAPI_SUB_INFO_S   pstSubInfo           告警订阅请求
        * @param OUT LPNETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo  订阅成功返回信息
        * @return TRUE表示成功,其他表示失败 
        * @note Type字段指定订阅类型
        */
        Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        /**
        * 取消LAPI告警订阅
        * @param [IN] lpUserID               用户登录句柄
        * @param [IN] UINT32 udwID           告警订阅ID
        * @return TRUE表示成功,其他表示失败 
        * @note
        */
        Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        /**
        * 获取门禁人员信息列表
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstQueryCond                                  门禁人员查询条件
        * @param [OUT] pstResultInfo                                返回信息
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSPersonInfo,NETDEV_FindCloseACSPersonInfo等函数的参数
        */
        IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一个门禁人员信息
        * @param [IN] lpFindHandle                                  门禁人员信息列表句柄
        * @param [OUT] pstACSPersonInfo                             门禁人员信息
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        /**
        * 关闭门禁人员信息列表资源
        * @param [IN] lpFindHandle                                      门禁人员信息列表句柄
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        /**
        * 门禁人员管理
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] dwCommand                                     门禁人员管理命令可参考#NETDEV_ACS_PERSON_COMMOND_TYPE_E
        * @param [INOUT] pstACSPersonInfo                           门禁人员信息
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        /**
        * 批量添加人员信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstACSPersonList         人员列表   其中单张图片大小为2M
        * @param [OUT] pstResultList           返回列表
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList);

        /**
        * 批量删除门禁人员信息
        * @param [IN] lpUserID                                      用户登录ID
        * @param [INOUT] pstBatchCtrlInfo                           批量控制信息
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        /**
        * 查看门禁授权组列表
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstFindCond                                   查询条件
        * @param [OUT] pstResultInfo                                实际查询结果
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSPermissionGroupInfo,NETDEV_FindCloseACSPermissionGroupInfo等函数的参数
        * @note 查询之后需要调用NETDEV_FindNextACSPermissionGroupInfo和NETDEV_FindCloseACSPermissionGroupInfo将数据获取完，否则会造成内存泄露
        */
        IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一条记录
        * @param [IN] lpFindHandle                              门禁授权组列表信息列表句柄
        * @param [OUT] pstACSPermissionInfo                     门禁授权组列表信息
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        /**
        * 关闭查询记录资源
        * @param [IN] lpFindHandle                                  门禁授权组列表句柄
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        /**
        * 添加人员授权组信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstPermissionGroupInfo        授权组信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        */
        Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);

        /**
        * 修改人员授权组信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstPermissionInfo        授权组信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        */
        Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);

        /**
        * 删除人员授权组信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstPermissionIDList      权限ID数组
        * @param [INOUT] 
        * @param [OUT] 
        * @return 
        */
        Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        /**
        * 获取单个授权组信息
        * @param [IN] lpUserID                                              用户登录ID
        * @param [IN] udwPermissionGroupID                                  授权组id
        * @param [INOUT] pstAcsPerssionInfo                                   权限组信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        /**
        * 获取指定人员授权信息
        * @param [IN] lpUserID                       用户登录ID
        * @param [IN] udwPersonID                    人员ID
        * @param [INOUT] pstPermissionInfo           人员授权信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        /**
        * 设置指定人员授权信息
        * @param [IN] lpUserID                       用户登录ID
        * @param [IN] pstPermissionInfo              人员授权信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        /**
        * 门禁通道控制
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] dwChannelID                                   通道号
        * @param [IN] dwCommand                                     门禁通道控制命令可参考#NETDEV_DOORCTRL_ACTION_TYPE_E
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        /**
        * 门禁通道批量控制
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] dwCommand                                     门禁通道控制命令可参考#NETDEV_DOORCTRL_ACTION_TYPE_E
        * @param [IN] pstBatchCtrlInfo                              批量控制信息
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        /**
        * 查询访客记录
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstFindCond                                   访客记录查询条件
        * @param [OUT] pstResultInfo                                访客记录实际总条数
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSVisitLog,NETDEV_FindCloseACSVisitLog等函数的参数
        */
        IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一条访客记录
        * @param [IN] lpFindHandle                              出入记录信息列表句柄
        * @param [OUT] pstACSLogInfo                            出入记录信息
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        /**
        * 关闭查询访客记录资源
        * @param [IN] lpFindHandle                                  出入记录信息列表句柄
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        /**
        * 获取访客黑名单列表
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstFindCond                                   查询条件
        * @param [OUT] pstResultInfo                                实际查询结果
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSPersonBlackList,NETDEV_FindCloseACSPersonBlackList等函数的参数
        * @note 查询之后需要调用NETDEV_FindNextACSPersonBlackList和NETDEV_FindCloseACSPersonBlackList将数据获取完，否则会造成内存泄露
        */
        IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一条记录  FindNextACSPersonBlackListInfo
        * @param [IN] lpFindHandle                              访客黑名单列表信息列表句柄
        * @param [OUT] pstACSPermissionInfo                     访客黑名单列表信息        
        * @return TRUE表示成功，其他表示失败
        */
        Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        /**
        * 关闭查询记录资源                                  FindCloseACSAttendanceLogList
        * @param [IN] lpFindHandle  访客黑名单列表句柄
        * @return TRUE表示成功，其他表示失败                TRUE means success, and any other value means failure.
        */
        Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        /**
        * 添加访客黑名单                        AddACSPersonBlackList
        * @param [IN] lpUserID                  用户登录ID           user login ID
        * @param [IN] pstBlackListInfo          黑名单信息           BlackList Info
        * @return 
        */
        Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        /**
        * 删除访客黑名单     DeleteACSPersonBlackList
        * @param [IN] lpUserID                   用户登录ID       user login ID
        * @param [IN] pstBlackList               黑名单信息列表   BlackList Info
        * @param [INOUT] 
        * @param [OUT] 
        * @return 
        */
        Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        /**
        * 修改访客黑名单信息  ModifyACSPersonBlackList
        * @param [IN] lpUserID                  用户登录ID     user login ID
        * @param [IN] pstBlackListInfo          黑名单信息     BlackList Info
        * @return 
        */
        Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        /**
        * GetACSPersonBlackList                 获取指定访客黑名单信息
        * @param [IN] lpUserID                  用户登录ID   user login ID
        * @param [IN] pstBlackListInfo          黑名单信息，其中udwBlackListID作为入参传入   BlackList Info
        * @param [INOUT] 
        * @param [OUT] 
        * @return 
        */
        Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        /**
        * 查询出入记录
        * @param [IN] lpUserID                                      用户登录ID             user login ID
        * @param [IN] pstFindCond                                   出入记录查询条件
        * @param [OUT] pstResultInfo                                出入记录实际总条数
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSAttendanceLog,NETDEV_FindCloseACSAttendanceLogList等函数的参数
        * @note 查询之后需要调用NETDEV_FindNextACSAttendanceLog和NETDEV_FindCloseACSAttendanceLogList将数据获取完，否则会造成内存泄露
        */
        IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * FindNextACSAttendanceLog
        * @param [IN] lpFindHandle                              出入记录信息列表句柄
        * @param [OUT] pstACSLogInfo                            出入记录信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        */
        Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        /**
        * 关闭查询出入记录资源                             FindCloseACSAttendanceLogList
        * @param [IN] lpFindHandle  出入记录信息列表句柄
        * @return  TRUE means success, and any other value means failure.
        */
        Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        /**
        * 获取系统图片信息                          
        * @param [IN]   lpUserID                     用户登录ID     User login ID
        * @param [IN]   pszURL                       图片URL        picture url
        * @param [IN]   udwSize                      加密前数据大小   
        * @param [OUT]   pszdata                     图片数据(需动态分配内存)   picture data
        * @return TRUE表示成功，其他表示失败
        * @note无
        */
        Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        /**
        * Get SDK version
        * @param [IN]  pszVersion  Version Info (Lenth: 64 BYTE)
        * @return TRUE 表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note pszVersion内存由调用者申请释放
        */
        Int32 NETDEV_GetPARKVersion(byte[] strVersion);

        /* 设置SDK与设备连接异常/恢复信息数据上报回调函数  Set status callback.(NEW)
       * @param [IN] lpUserID          用户登录句柄 User login ID
       * @param [IN] cbItsStatusReportCallBack     SDK与设备连接异常/恢复信息数据上报回调函数的指针  Pointer to callback function if Status data.
       * @param [IN]  lpUserData       用户数据     User Data.
       * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
       * @note  
       */
        Int32 NETDEV_SetParkStatusCallBack(IntPtr lpUserID, NETDEV_ParkStatusReportCallBack_PF cbParkStatusReportCallBack, IntPtr lpUserData);

        /**
        * 启动照片流 Start Photo stream.
        * @param [IN]  lpUserID          用户登录ID   User login ID
        * @param [IN]  hPlayWnd          过车图片显示播放窗口句柄,如果为0不显示   Play window handle. NULL means not play
        * @param [IN]  bReTran           是否断网重传:TRUE表示断网重传（照片服务器开启，历史数据同步上传）,FALSE表示断网不重传（仅上报实时数据）
        *                                Whether retransmit. TRUE means use retransmission mode, FALSE means not use retransmission mode.
        * @param [IN]  pcReTranIP        若第二各参数为TRUE，此参数重传码流接收端IP地址; 若第二各参数为FALSE，不重传填空,""
        *                                If retransmission is enabled, fill in this field with the IP address of the PC that hosts the SDK program; otherwise, this field is empty.
        * @param [IN]  pfnPicDataCBFun   过车抓拍识别数据回调函数指针
        *                                Pointer to callback function of Vehicle data.
        * 
        * @param [IN]  lpUserData        用户数据  User Data.
        * @return  返回的照片流句柄,返回 0 表示失败.  Return Stream startup handle, 0 means failure.
        * @note 
        */
        IntPtr NETDEV_StartPicStream(IntPtr lpUserID, IntPtr hPlayWnd, bool bReTran, string pcReTranIP, NETDEV_PIC_UPLOAD_PF pfnPicDataCBFun, IntPtr lpUserData);

        /**
         * 停止照片流  Stop Photo stream.
         * @param [IN]  lpPlayHandle   照片流句柄  Current Photo stream handle
         * @return TRUE表示成功,其他表示失败.  TRUE means success, otherwise means failure.
         * @note 对应关闭NETDEV_StartPicStream开启的照片流 Stop the  Photo stream started by NETDEV_StartPicStream
         */
        Int32 NETDEV_StopPicStream(IntPtr lpPlayHandle);

        /**
        * 手动前端抓拍(异步)  Asynchronous capture in image preview.
        * @param [IN]  lpFindHandle   用户登录ID User login ID
        * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note None
        */
        Int32 NETDEV_Trigger(IntPtr lpFindHandle);

        /**
        * 手动前端抓拍(同步)  Synchronous capture in image preview.
        * @param [IN]  lpFindHandle   用户登录ID, User login ID
        * @param [IN]  ppstPicData    指向获取的抓拍车辆信息数据的指针  ppstPicData Pointer to the obtained image info
        * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note None
        */
        Int32 NETDEV_TriggerSync(IntPtr lpFindHandle, ref IntPtr ppstPicData);

        /**
        * 输出开关量
        * @param [IN]  lpFindHandle   用户登录ID
        * @return TRUE表示成功,其他表示失败
        * @note PARK出入口接入道闸，可采用此接口命令开闸
        */
        Int32 NETDEV_SetOutputSwitchStatusCfg(IntPtr lpFindHandle);

        /**
         * 批量上传出入口设备白名单信息（已废弃） Batch import blacklists or whitelists 
         * @param [IN]  lpFindHandle   用户登录句柄  User login ID
         * @param [IN]  pcFile         文件保存路径(包含csv文件名)  Path to the file.
         * @return INT32 0 表示成功，其他见详见错误码  INT32 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 文件路径示例:“C:\车辆设备黑白名单模板\ GateBlacklist.csv”,黑名单文件命名(GateBlacklist.csv),白名单文件命名(GateWhitelist.csv)
         * Example: “C:\blacklist or whitelist template\ GateBlacklist.csv”,blacklist filename(GateBlacklist.csv),whitelist filename(GateWhitelist.csv)
         */
        Int32 NETDEV_ImportBlackWhiteListFile(IntPtr lpFindHandle, String pcFile);

        /**
         * 批量下载出入口设备白名单信息（已废弃）\n  Batch export blacklists or whitelists
         * @param [IN]  lpFindHandle   用户登录句柄
         * @param [IN]  pcFile     文件保存路径(包含csv文件名)
         * @return INT32 0 表示成功，其他见详见错误码
         * @note 文件路径示例:“C:\车辆设备黑白名单模板\ GateBlacklist.csv”,黑名单文件命名(GateBlacklist.csv),白名单文件命名(GateWhitelist.csv)
         */
        Int32 NETDEV_ExportBlackWhiteListFile(IntPtr lpFindHandle, String pcFile);

        /**
         * 添加黑白名单车辆信息操作  Add vehicle info to allowlist/blocklist 
         * @param [IN]  lpFindHandle 用户登录设备ID   User login ID
         * @param [IN]  pstVehicleRecordExtern  增加名单项内容
         * @return INT32 0表示成功，其他见相关错误码  NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无 None
         */
        Int32 NETDEV_AddVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_EXTERN_S pstVehicleRecordExtern);

        /*
         * 修改白名单车辆成员信息操作   Modify vehicle info to allowlist 
         * @param [IN]  lpFindHandle 用户登录设备ID  User login ID
         * @param [IN]  pstVehicleRecords 修改名单项内容
         * @return INT32 0表示成功，其他见相关错误码  NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无 None
         */
        Int32 NETDEV_ModifyAllowVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern);

        /*
         * 修改黑名单车辆成员信息操作 Modify vehicle info to blocklist 
         * @param [IN]  lpFindHandle 用户登录设备ID  User login ID
         * @param [IN]  pstVehicleRecords 修改名单项内容
         * @return INT32 0表示成功，其他见相关错误码  NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无 None
         */
        Int32 NETDEV_ModifyBlockVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern);

        /*
         * 删除白名单车辆成员信息操作 Delete vehicle info to allowlist 
         * @param [IN]  lpFindHandle 用户登录设备ID   User login ID
         * @param [IN]  ulRecordID 删除名单项ID
         * @return INT32 0表示成功，其他见相关错误码 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无
         */
        Int32 NETDEV_DeleteAllowVehicleRecord(IntPtr lpFindHandle, Int32 ulRecordID);

        /*
         * 删除黑名单车辆成员信息操作 Delete vehicle info to blocklist 
         * @param [IN]  lpFindHandle 用户登录设备ID User login ID
         * @param [IN]  ulRecordID 删除名单项ID
         * @return INT32 0表示成功，其他见相关错误码 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无
         */
        Int32 NETDEV_DeleteBlockVehicleRecord(IntPtr lpFindHandle, Int32 ulRecordID);

        /* 
         * 设置出入口设备Led显示内容 set Led 
         * @param [IN]  lpFindHandle      用户登录ID
         * @param [IN]  pstLedListCfgs    LED屏显示配置
         * @return INT32 0表示成功，其他见相关错误码 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note   时间实时显示可下发内容“#T”,由设备自行控制显示
         */
        Int32 NETDEV_setDeviceLedCfg(IntPtr lpFindHandle, ref NETDEV_LED_LIST_CFG_S pstLedListCfgs);

        /**
        * 车位检测器内置灯状态获取\n
        * @param [IN]   lpFindHandle
        * @param [OUT]  pstuCarportControlled  SDK车位内置指示灯控制参数
        * @return 0 表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note 
        */
        Int32 NETDEV_GetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled);

        /**
        * 车位检测器内置灯控制 
        * @param [IN]  lpFindHandle   用户登录ID
        * @param [IN]  pstuCarportControlled 车位内置指示灯控制参数
        * @return 0 表示成功,其他表示失败  TRUE means success, otherwise means failure.
        * @note 
        */
        Int32 NETDEV_SetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled);

        /**
         * 车牌编码格式UTF-8 
         * @param [OUT] bEnable      0-GBK , 1-UTF-8 (默认UTF-8)  Sets the format of vehicle license contents reported. 0: GBK, 1: UTF-8. Default: UTF-8
         * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
         * @note None
         */
        Int32 NETDEV_EnableCarplate(Int32 bEnable);

        /**
        * 车位状态信息数据回调函数设置  set parking space status callback function 
        * @param [IN]  lpFindHandle             用户登录ID   User login ID
        * @param [IN]  pfnParkStatusCBFun   车位状态信息数据回调函数指针  Pointer to the buffer storing Parking space status data  
        * @param [IN]  lpUserData           用户数据  User data 
        * @return  TRUE表示成功,其他表示失败  TRUE means success, otherwise means failure.
        * @note  
        */
        Int32 NETDEV_SetParkingStatusCB(IntPtr lpFindHandle, NETDEV_PARKING_STATUS_PF pfnParkStatusCBFun, IntPtr lpUserData);
    }
    internal class ItsNetDevSdkDller : IItsNetDevSdkProxy
    {
        public static IItsNetDevSdkProxy Instance { get; } = new ItsNetDevSdkDller();
        private ItsNetDevSdkDller() { }
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void MemCopy(byte[] dest, IntPtr src, int count);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        /**
        * SDK 初始化  SDK initialization
        * @return 1 表示成功,其他表示失败 1 means success, and any other value means failure.
        * @note 线程不安全 Thread not safe
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Init();

        /**
         * SDK 清理  SDK cleaning
         * @return 1 表示成功,其他表示失败 1 means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Cleanup();

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_LoginCloud(String pszCloudSrvUrl, String pszUserName, String pszPassWord);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_LoginCloudDevice_V30(IntPtr lpUserID, ref NETDEV_CLOUD_DEV_LOGIN_INFO_S pstCloudInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindCloudDevListEx(IntPtr lpUserID);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextCloudDevInfoEx(IntPtr lpFindHandle, ref NETDEV_CLOUD_DEV_BASIC_INFO_S pstDevInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseCloudDevListEx(IntPtr lpFindHandle);

        /**
        * 设备发现 先注册设备发现相关的回调,再调用此接口发现设备,发现的设备信息在回调中反映
        * This interface is used for device discovery. Please first register callback functions related to device discovery and use this interface for device discovery. Discovered device info will be included in the callback function.
        * @param [IN]   pszBeginIP                 起始IP地址
        * @param [IN]   pszEndIP                   结束IP地址
        * @return 1 表示成功,其他表示失败
        * @note 若pszBeginIP和pszEndIP都是"0.0.0.0",则搜索本网段设备
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        /**
         * 启动实时预览  Start live preview
         * @param [IN]  lpUserID             用户登录句柄 User login ID
         * @param [IN]  pstPreviewInfo       预览参数,参考枚举：NETDEV_PROTOCAL_E,NETDEV_LIVE_STREAM_INDEX_E. Preview parameter, see enumeration: NETDEV_PROTOCAL_E, NETDEV_LIVE_STREAM_INDEX_E.
         * @param [IN]  cbRealDataCallBack   码流数据回调函数指针 Pointer to callback function of stream data
         * @param [IN]  lpUserData           用户数据 User data
         * @return 返回的用户登录句柄,返回 0 表示失败,其他值表示返回的用户登录句柄值. Returned live Handle. 0 indicates failure, and other values indicate the user ID.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        /**
        * 停止实时预览  Stop live preview
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @return 1 表示成功,其他表示失败 1 means success, and any other value means failure.
        * @note 对应关闭NETDEV_RealPlay开启的实况 Stop the live view started by NETDEV_RealPlay
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        /**
        * 获取窗口码率  Get window bit rate
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwBitRate       获取的码率指针 Pointer to obtained bit rate
        * @return 1表示成功,其他表示失败 1 means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        /*
        * 获取窗口帧率  Get window frame rate
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwFrameRate     获取的帧率指针 Pointer to obtained frame rate
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        /**
        * 获取窗口编码格式  Get window encoding format
        * @param [IN]  lpPlayHandle         预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwVideoEncFmt       获取的视频编码格式指针,参见NETDEV_VIDEO_CODE_TYPE_E  Pointer to obtained encoding format, see NETDEV_VIDEO_CODE_TYPE_E
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        /**
        * 获取视频分辨率  Get video resolution
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pdwWidth         获取的分辨率-宽度指针 Pointer to obtained resolution – width
        * @param [OUT] pdwHeight        获取的分辨率-高度指针 Pointer to obtained resolution – height
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        /**
        * 获取窗口丢包率  Get window packet loss rate
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [OUT] pulRecvPktNum    接收的数据包数量指针 Pointer to number of received packets
        * @param [OUT] pulLostPktNum    丢失的数据包数量指针 Pointer to number of lost packets
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        /**
        * 实况抓拍  Live view snapshot
        * @param [IN]  lpPlayHandle     预览\回放句柄 Preview\playback handle
        * @param [IN]  pszFileName      保存图像的文件路径（包括文件名） File path to save images (including file name)
        * @param [IN]  dwCaptureMode    保存图像格式,参见#NETDEV_PICTURE_FORMAT_E   Image saving format, see #NETDEV_PICTURE_FORMAT_E
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 文件名中可以不携带抓拍格式的后缀名 File format suffix is not required in the file name
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);

        /**
        * 本地录像  Local recording
        * @param [IN]  lpPlayHandle         预览句柄 Preview handle
        * @param [IN]  pszSaveFileName      保存的文件名 Name of saved file
        * @param [IN]  dwFormat             Format of saved file, see #NETDEV_MEDIA_FILE_FORMAT_E 
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        /**
        * 停止本地录像 Stop local recording
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        /**
        * 根据文件类型.时间查找设备录像文件  Query recording files according to file type and time
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @param [IN]  pstFindCond    录像查询条件 Search condition
        * @return 录像查询业务号,返回0表示失败,其他值作为NETDEV_FindClose等函数的参数.
        Recording search service number. 0 means failure. Other values are used as the handle parameters of functions like NETDEV_FindClose.
        * @note 此函数返回值为录像查询业务号,若返回值为非0,则查询录像文件成功：
        *         一.将上述业务号作为NETDEV_FindNextFile函数的入参lpFindHandle,多次调用NETDEV_FindNextFile函数,以逐个获取详细录像文件信息.
        *         二.查询结束后,必须以上述业务号作为NETDEV_FindClose函数的入参lpFindHandle,调用NETDEV_FindClose函数,以释放资源,关闭查找.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        /**
        * 逐个获取查找到的文件信息  Obtain the information of found files one by one.
        * @param [IN]  lpFindHandle     文件查找句柄 File search handle
        * @param [OUT] pstFindData       保存文件信息的指针 Pointer to save file information
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        /**
        * 关闭文件查找,释放资源  Close file search and release resources
        * @param [IN] lpFindHandle  文件查找句柄 File search handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        /**
        * 控制录像回放的状态  Control recording playback status.
        * @param [IN]  lpPlayHandle     回放或下载句柄 Playback or download handle
        * @param [IN]  dwControlCode    控制录像回放状态命令 参考枚举：NETDEV_VOD_PLAY_CTRL_E Command for controlling recording playback status, see NETDEV_VOD_PLAY_CTRL_E
        * @param [INOUT]  lpBuffer     指向输入/输出参数的指针, 播放速度参考枚举：NETDEV_VOD_PLAY_STATUS_E,播放时间参数类型为：INT64 Pointer to input/output parameters. For playing speed, see NETDEV_VOD_PLAY_STATUS_E. The type of playing time: INT64.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 开始.暂停.恢复播放时,lpBuffer置为NULL When playing, pause or resume videos, set IpBuffer as NULL.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        /**
        * 按时间下载录像文件 Download recordings by time
        * @param [IN]  lpUserID                用户登录句柄 User login ID
        * @param [IN]  pstPlayBackCond   按时间录像回放结构体指针,参考 LPNETDEV_PLAYBACKCOND_S Pointer to playback-by-time structure, see LPNETDEV_PLAYBACKCOND_S
        * @param [IN]  *pszSaveFileName        下载后保存到PC机的文件路径,需为绝对路径（包括文件名） Downloaded file save path on PC, must be an absolute path (including file name)
        * @param [IN]  dwFormat                录像文件保存格式 Recording file saving format
        * @return 下载句柄, 返回0表示失败,其他值作为NETDEV_StopGetFile等函数的参数. Download handle. 0 means failure. Other values are used as the handle parameters of functions like NETDEV_StopGetFile.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        /**
         * 停止下载录像文件 Stop downloading recording files
         * @param [IN]  lpPlayHandle  回放句柄 Playback handle
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        /**
        * 设置设备的配置信息  Modify device configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CONFIG_COMMAND_E  Device configuration commands, see #NETDEV_CONFIG_COMMAND_E
        * @param [IN]   index               输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        /**
        * 设置透雾模式信息  Set defogging info
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_DEFOGGINGINFO  Device configuration commands, see #NETDEV_SET_DEFOGGINGINFO
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        /**
        * 获取透雾模式信息  Get defogging info
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_DEFOGGINGINFO  Device configuration commands, see #NETDEV_GET_DEFOGGINGINFO
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置运动检测告警信息  Set motion alarm configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_MOTIONALARM  Device configuration commands, see #NETDEV_SET_MOTIONALARM
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取运动检测告警信息  Get motion alarm configuration information
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_MOTIONALARM  Device configuration commands, see #NETDEV_GET_MOTIONALARM
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取遮挡检测告警信息   Get tamper alarm configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_TAMPERALARM  Device configuration commands, see #NETDEV_SET_MOTIONALARM
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置遮挡检测告警信息   Set tamper alarm configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_TAMPERALARM  Device configuration commands, see #NETDEV_SET_MOTIONALARM
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 设置NTP参数   Get NTP parameter
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_NTPCFG_EX  Device configuration commands, see #NETDEV_SET_NTPCFG_EX
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取OSD参数能力集   OSD parameter capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_OSD  Device configuration commands, see #NETDEV_CAP_OSD
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取视频编码能力集   Video encoding capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_VIDEO_ENCODE_EX  Device configuration commands, see #NETDEV_CAP_VIDEO_ENCODE_EX
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取OSD参数能力集   OSD parameter capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_OSD  Device configuration commands, see #NETDEV_CAP_OSD
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceCapability(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取视频编码能力集   Video encoding capability
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CAP_VIDEO_ENCODE_EX  Device configuration commands, see #NETDEV_CAP_VIDEO_ENCODE_EX
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceCapability(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取客流量统计 Obtain traffic statistic
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [OUT]  pstPeopleCounter        客流量统计列表 People counting list
        * @return TRUE表示成功,其他表示失败 TRUE means success, any other value indicates failure.
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        /**
        * 设置保活参数 Set keep-alive parameters
        * @param [IN]  dwWaitTime            间隔等待时间  Waiting time
        * @param [IN]  dwTrytimes            尝试连接次数  Connecting attempts
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);

        /**
        * 设置流畅性优先 Set pictuer fluency
        * @param [IN] lpPlayHandle         预览\回放句柄 Preview\playback handle
        * @param [IN] dwFluency           图像播放流畅性优先类型,参见枚举#NETDEV_PICTURE_FLUENCY_E
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle, Int32 dwFluency);

        /**
        * 动态产生一个关键帧 Dynamically create an I frame 
        * @param [IN] lpUserID       用户登录句柄  User login ID
        * @param [IN] dwChannelID    通道号  Channel ID
        * @param [IN] dwStreamType   参考枚举NETDEV_LIVE_STREAM_INDEX_E  See enumeration NETDEV_LIVE_STREAM_INDEX_E
        * @return NETDEV_E_SUCCEED   表示成功,其他表示失败  NETDEV_E_SUCCEED means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);

        /**
        * 获取扬声器音量 Get sound volume
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @param [IN]  pdwVolume        音量 Volume
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);

        /**
         * 调节扬声器音量 Control sound volume
         * @param [IN]  lpPlayHandle   预览句柄 Preview handle
         * @param [IN]  dwVolume       音量 Volume
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        /**
        * 获取麦克风音量 Get mic volume
        * @param [IN]  lpPlayHandle     预览句柄 Preview handle
        * @param [IN]  pdwVolume        音量 Volume
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        /**
         * 调节麦克风音量  Adjust sound volume of microphone
         * @param [IN]  lpPlayHandle     预览句柄 Preview handle 
         * @param [IN]  dwVolume             音量 Sound volume
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        /**
         * 开启麦克风 Turn on microphone
         * @param [IN]  lpPlayHandle   预览句柄 Preview handle
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        /**
        * 关闭麦克风 Turn off microphone
        * @param [IN]  lpPlayHandle   预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        /**
        * 开启输入语音数据服务
        * @param [IN]  lpUserID                 用户ID
        * @param [IN]  dwChannelID              通道号
        * @param [IN]  cbRealDataCallBack       码流数据回调函数指针
        * @param [IN]  lpUserData               用户数据
        * @return 返回的语音对讲句柄,返回 0 表示失败
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        /**
        * 关闭输入语音数据服务
        * @param [IN]  lpVoiceComHandle   对讲句柄
        * @return TRUE表示成功,其他表示失败
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        /**
        * 输入语音数据
        * @param [IN]  lpVoiceComHandle         对讲句柄
        * @param [IN] lpDataBuf                 语音数据地址
        * @param [IN] dwDataLen                 语音数据长度
        * @param [IN] pstVoiceParam             语音参数
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        // [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //  public static extern Int32 NETDEV_GetPARKVersion(IntPtr lpszVersion);

        /* interface function end */

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSDKVersion();

        /**
        * 用户登录  User login
        * @param [IN]  pszDevIP         设备IP Device IP
        * @param [IN]  wDevPort         设备服务器端口 Device server port
        * @param [IN]  pszUserName      用户名 Username
        * @param [IN]  pszPassword      密码 Password
        * @param [OUT] pstDevInfo       设备信息结构体指针 Pointer to device information structure
        * @return 返回的用户登录句柄,返回 0 表示失败,其他值表示返回的用户登录句柄值. Returned user login ID. 0 indicates failure, and other values indicate the user ID.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        /**
        * 用户注销  User logout
        * @param [IN] lpUserID    用户登录句柄 User login ID
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Logout(IntPtr lpUserID);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        /**
        * 重置窗口丢包率  Reset window packet loss rate
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        /**
        * 非预览下抓拍  Snapshot without preview
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  dwStreamType;        码流类型,参见枚举#NETDEV_LIVE_STREAM_INDEX_E  Stream type, see enumeration #NETDEV_LIVE_STREAM_INDEX_E 
        * @param [IN]  pszFileName          保存图像的文件路径（包括文件名） File path to save images (including file name)
        * @param [IN]  dwCaptureMode        保存图像格式,参见#NETDEV_PICTURE_FORMAT_E   Image saving format, see #NETDEV_PICTURE_FORMAT_E
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
                仅支持JPG格式.
                Only JPG format is supported.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        /**
        * 设置视频图像显示比例  Modify image display ratio
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN]  enRenderScale  视频图像的显示比例 Image display ratio
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        /**
        * 按名称回放录像文件  Play back recording files by name
        * @param [IN] lpUserID          用户登录句柄 User login ID
        * @param [IN] pstPlayBackInfo   录像回放结构体指针,参考 LPNETDEV_PLAYBACKINFO_S Pointer to recording playback structure, see LPNETDEV_PLAYBACKINFO_S
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        /**
        * 按时间回放录像文件  Play back recording by time. 
        * @param [IN] lpUserID          用户登录句柄 User login ID
        * @param [IN] pstPlayBackCond   按时间录像回放结构体指针  参考 LPNETDEV_PLAYBACKCOND_S Pointer to playback-by-time structure, see LPNETDEV_PLAYBACKCOND_S
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        /**
        * 停止回放业务  Stop playback service
        * @param [IN] lpPlayHandle  回放句柄 Playback handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        /**
        * 按文件名下载录像文件 Download recordings by file name
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  pstPlayBackInfo      录像回放结构体指针,参考 LPNETDEV_PLAYBACKINFO_S Pointer to recording playback structure, see LPNETDEV_PLAYBACKINFO_S
        * @param [IN]  *pszSaveFileName     下载后保存到PC机的文件路径,需为绝对路径（包括文件名） Downloaded file save path on PC, must be an absolute path (including file name)
        * @param [IN]  dwFormat             录像文件保存格式 Recording file saving format
        * @return 下载句柄, 返回0表示失败,其他值作为NETDEV_StopGetFile等函数的参数. Download handle. 0 means failure. Other values are used as the handle parameters of functions like NETDEV_StopGetFile.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        /**
        * 云台预置位操作(需先启动预览)  PTZ preset operation (preview required)
        * @param [IN]  lpPlayHandle         实时预览句柄 Live preview handle
        * @param [IN]  dwPTZPresetCmd       操作云台预置位命令,参考枚举NETDEV_PTZ_PRESETCMD_E  PTZ preset operation commands, see NETDEV_PTZ_PRESETCMD_E
        * @param [IN]  pszPresetName        预置位的名称 Preset name
        * @param [IN]  dwPresetID           预置位的序号（从1开始）,最多支持255个预置位 Preset number (starting from 1). Up to 255 presets are supported.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        /**
        * 获取设备的配置信息  Get configuration information of device
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_CONFIG_COMMAND_E  Device configuration commands, see #NETDEV_CONFIG_COMMAND_E
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 1.巡航路径ID不可修改.  Route ID cannot be modified.
        * - 2.新增巡航路径时,默认按顺序新增.  New routes are added one after another.
        * - 3.删除.开始.停止巡航路径时,pstCruiseInfo中只需要填写巡航路径ID即可.  When deleting, starting or stoping a patrol route, enter route ID in pstCruiseInfo.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置设备的配置信息  Modify device configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_CONFIG_COMMAND_E  Device configuration commands, see #NETDEV_CONFIG_COMMAND_E
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        /**
         * 重启设备  Reboot Device
         * Restart device
         * @param [IN]  lpUserID     用户登录句柄 User login ID
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Reboot(IntPtr lpUserID);

        /**
        * 开启声音  Enable sound
        * @param [IN]  lpPlayHandle   预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        /**
        * 关闭声音 Mute
        * @param [IN]  lpPlayHandle   预览句柄 Preview handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        /**
        * 获取错误码  Get error codes
        * @return 错误码 Error codes
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLastError();

        /**
        * 拉框放大.缩小(不需要启动预览)   Drag to zoom in and out(preview not required)
        * @param lpUserID                   用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  pstPtzOperateArea    拉框放大结构体信息 Drag-to-zoom structure information
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 在我司NVR下,需通过私有协议连接我司IPC才支持该接口  In our NVR, this interface is supported only when our camera is connected through private protocol.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        /**
        * 设备登录
        * @param [IN]  pstDevLoginInfo  设备登录信息
        * @param [OUT] pstSELogInfo     安全登录信息，包含登录失败次数及下次登录时间
        * @return 返回值为用户ID。
        * @note 安全登录信息此字段仅适用于使用LAPI协议登录的设备
        * -
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        /**
        * 查询组织信息列表
        * @param [IN] lpUserID          用户登录ID
        * @param [IN] pstFindCond       查找组织信息列表条件
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextOrgInfo、NETDEV_FindCloseOrgInfo等函数的参数。
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        /**
        * 逐个获取查找到的组织信息
        * @param [IN]  lpFindHandle                 查找句柄 
        * @param [OUT] pstOrgInfo                   保存组织信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        /**
        * 关闭查找 组织信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        /**
        * 添加组织
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] pstOrgInfo            组织信息指针
        * @param [OUT] dwOrgID             组织ID
        * @return TRUE           表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        /**
        * 修改组织
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] dwOrgID              组织ID
        * @param [IN] pstOrgInfo            组织信息指针
        * @return TRUE           表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        /**
        * 批量删除组织
        * @param [IN] lpUserID             用户登录ID
        * @param [IN] pstOrgDelInfo       待删除组织信息指针
        * @param [OUT] pstOrgDelResultInfo  删除组织响应信息指针
        * @return TRUE           表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        /**
        * 通过 设备类型 查询 设备列表
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] dwDevType             设备类型 参见#NETDEV_DEVICE_MAIN_TYPE_E
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextOrgInfo、NETDEV_FindCloseOrgInfo等函数的参数。
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        /**
        * 逐个获取查找到的 设备信息
        * @param [IN]  lpFindHandle                 查找句柄 
        * @param [OUT] pstDevBasicInfo              保存 设备详细信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        /**
        * 关闭查找 设备信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        /**
        * 通过设备ID或通道类型 查询通道信息列表
        * @param [IN] lpUserID          用户登录ID
        * @param [IN] dwDevID           设备ID
        * @param [IN] dwChnType         通道类型，参见# NETDEV_CHN_TYPE_E
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextDevChn、NETDEV_FindCloseDevChn等函数的参数。
        * @note     1、只根据通道类型查询时，将设备ID设置为0.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        /**
        * 逐个获取查找到的 设备通道 信息
        * @param [IN]  lpFindHandle         查找句柄 
        * @param [OUT] lpOutBuffer          接收数据的缓冲指针
        * @param [IN] dwOutBufferSize       接收数据的缓冲长度(以字节为单位)，不能为0
        * @param [OUT] pdwBytesReturned     实际收到的数据长度指针，不能为NUL
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 关闭查找 设备通道信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        /**
        * 获取设备信息        GetDeviceInfos
        * @param [IN] lpUserID          用户登录句柄 User login handle
        * @param [OUT] pstDevInfo       设备信息结构体指针 Pointer to device information structure
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        /**
        * 查询设备详细信息   GetDeviceInfo_V30
        * @param [IN] lpUserID              用户登录ID     User login handle
        * @param [IN] dwDevID               设备ID         Device ID
        * @param [OUT]  pstDevDetailInfo    设备详细信息   Pointer to device information structure
        * @return TRUE表示成功，其他表示失败         TRUE means success, and any other value means failure.
        * @note
        * -
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        /**
        * 获取通道类型
        * @param [IN] lpUserID              用户登录ID     User login ID
        * @param [IN] dwChnID               通道ID         channel ID
        * @param [OUT] pdwChnType           设备通道类型 参见# NETDEV_CHN_TYPE_E  See# NETDEV_CHN_TYPE_E
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        /**
        * 根据通道类型和通道ID获取通道详细信息  GetChnDetailByChnType
        * @param [IN] lpUserID              用户登录ID   user login id 
        * @param [IN] dwChnID               通道ID       channle ID
        * @param [IN] dwChnType             通道类型,参见# NETDEV_CHN_TYPE_E    See # NETDEV_CHN_TYPE_E
        * @param [INOUT] lpOutBuffer        接收数据的缓冲指针                  Point to out data buffer
        * @param [IN] dwOutBufferSize       接收数据的缓冲长度(以字节为单位)，不能为0     recv buffer date
        * @param [OUT] pdwBytesReturned     实际收到的数据长度指针，不能为NULL
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 一体机
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID, Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取云台预置位巡航路径  Get PTZ preset patrol route
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [OUT]  pstCruiseList        巡航路径列表 Patrol route list
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        /**
        * 云台预置位巡航操作(不需要启动预览)  PTZ preset patrol operation (preview not required)
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  dwPTZCruiseCmd       操作云台巡航命令,参考#NETDEV_PTZ_CRUISECMD_E  PTZ patrol operation commands, see #NETDEV_PTZ_CRUISECMD_E
        * @param [IN]  pstCruiseInfo         云台巡航路径信息,参考#LPNETDEV_CRUISE_INFO_S  PTZ patrol route information, see #LPNETDEV_CRUISE_INFO_S
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 1.巡航路径,最多支持16条路径（序号从1开始） Patrol route. Up to 16 routes are supported (starting from 1).
        * - 2.巡航点,最多支持32个点（序号从1开始） Patrol point. Up to 32 points are supported (starting from 1).
        * - 3.预置位(最大255).时间(最大255).速度(最大40)  Preset (max 255), time (max 255) and speed (max 40).
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        /**
        * 获取云台轨迹巡航路径  Get PTZ patrol route
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [OUT]  pstTrackCruiseInfo        巡航路径列表,参考#LPNETDEV_PTZ_TRACK_INFO_S  Patrol route list, see #LPNETDEV_PTZ_TRACK_INFO_S
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        /**
        * 云台轨迹巡航操作(不需要启动预览)   PTZ route patrol operation (preview not required)
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  dwChannelID          通道号 Channel ID
        * @param [IN]  dwPTZCruiseCmd       操作云台轨迹巡航命令,参考#NETDEV_PTZ_TRACKCMD_E  PTZ route patrol operation commands, see #NETDEV_PTZ_TRACKCMD_E
        * @param [INOUT]  pszTrackCruiseName         轨迹巡航名称,建议长度#NETDEV_LEN_64  Route patrol name, suggested length #NETDEV_LEN_64
        * @return  TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 1.巡航轨迹路径,最多支持1条路径  Only one patrol route allowed.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        /**
         * 设置视频编码参数  Set video encoding parameter
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_STREAMCFG  Device configuration commands, see #NETDEV_SET_STREAMCFG
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取云台状态  Get PTZ status
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_PTZSTATUS  Device configuration commands, see #NETDEV_GET_PTZSTATUS
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PTZ_STATUS_S lpInBuffer, Int32 dwInBufferSize, ref int pdwBytesReturned);

        /**
        * 云台标定 PTZ Calibrate
        * @param [IN]  lpUserID                      用户登录句柄 User login ID
        * @param [IN]  dwChannelID                   通道号 Channel ID
        * @param [IN]  pstOrientationInfo            云台方位信息 PTZ Orientation info
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        /**
        * 获取视频编码参数  Get video encoding parameter
        * @param [IN]   lpUserID                用户登录句柄 User login ID
        * @param [IN]   dwChannelID             通道号 Channel ID
        * @param [IN]   dwCommand               设备配置命令,参见# NETDEV_GET_STREAMCFG  Device configuration commands, see #NETDEV_GET_STREAMCFG
        * @param [INOUT]  lpOutBuffer           接收数据的缓冲指针 Pointer to buffer that receives data
        * @param [OUT]  dwOutBufferSize         接收数据的缓冲长度(以字节为单位),不能为0 Length (in byte) of buffer that receives data, cannot be 0.
        * @param [OUT]  pdwBytesReturned        实际收到的数据长度指针,不能为NULL  Pointer to length of received data, cannot be NULL.
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置图像配置信息  Set image configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_IMAGECFG  Device configuration commands, see #NETDEV_SET_IMAGECFG
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取图像配置信息  Get image configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_IMAGECFG  Device configuration commands, see #NETDEV_GET_IMAGECFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置NTP参数   Set NTP parameter
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_NTPCFG   Device configuration commands, see #NETDEV_SET_NTPCFG 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取NTP参数  Get NTP parameter
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_NTPCFG  Device configuration commands, see #NETDEV_GET_NTPCFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置网络配置信息  Set network configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_NETWORKCFG   Device configuration commands, see #NETDEV_SET_NETWORKCFG 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取网络配置信息  Get network configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_NETWORKCFG  Device configuration commands, see #NETDEV_GET_NETWORKCFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置开关量输出配置信息  Set boolean configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_ALARM_OUTPUTCFG   Device configuration commands, see #NETDEV_SET_ALARM_OUTPUTCFG 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 获取开关量输出配置信息  Get boolean configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_ALARM_OUTPUTCFG  Device configuration commands, see #NETDEV_GET_ALARM_OUTPUTCFG
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 设置录像计划配置信息   Set support NVR VMS
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SET_ALARM_OUTPUTCFG   Device configuration commands, see #NETDEV_SET_ALARM_OUTPUTCFG 
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        /**
       * 获取录像计划配置信息 Get support NVR VMS
       * @param [IN]   lpUserID            用户登录句柄 User login ID
       * @param [IN]   dwChannelID         通道号 Channel ID
       * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_GET_RECORDPLANINFO
       * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
       * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
       * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
       * @note
       */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 触发开关量  Trigger boolean
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_TRIGGER_ALARM_OUTPUT_S see #NETDEV_TRIGGER_ALARM_OUTPUT_S 
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        /**
       * 触发开关量（暂不支持）  Trigger boolean
       * @param [IN]   lpUserID            用户登录句柄 User login ID
       * @param [IN]   dwChannelID         通道号 Channel ID
       * @param [IN]   dwCommand           设备配置命令,参见#
       * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
       * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
       * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
       * @note
       */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
       * 设置OSD配置信息  Set OSD configuration information
       * @param [IN]   lpUserID            用户登录句柄 User login ID
       * @param [IN]   dwChannelID         通道号 Channel ID
       * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_VIDEO_OSD_CFG_S see #NETDEV_VIDEO_OSD_CFG_S 
       * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
       * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
       * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
       * @note
       */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
         * 获取OSD配置信息  Get OSD configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_VIDEO_OSD_CFG_S  see #NETDEV_VIDEO_OSD_CFG_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取开关量输入数量 Get the number of boolean inputs
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_ALARM_INPUT_LIST_S  see #NETDEV_ALARM_INPUT_LIST_S 
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置开关量输出配置信息  Set boolean configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_ALARM_OUTPUT_LIST_S see #NETDEV_ALARM_OUTPUT_LIST_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 获取设备信息  Get device information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_DEVICE_BASICINFO_S see #NETDEV_DEVICE_BASICINFO_S 
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取隐私遮盖配置信息  Get privacy mask configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_PRIVACY_MASK_CFG_S see #NETDEV_PRIVACY_MASK_CFG_S
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置隐私遮盖配置信息  Set privacy mask configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_PRIVACY_MASK_CFG_S see #NETDEV_PRIVACY_MASK_CFG_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
         * 获取NTP参数   Get NTP parameter
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_SYSTEM_NTP_INFO_S see #NETDEV_SYSTEM_NTP_INFO_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
        * 获取通道的图像曝光参数   get image Exposure configuration information
        * @param [IN]   lpUserID            用户登录句柄 User login ID
        * @param [IN]   dwChannelID         通道号 Channel ID
        * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IMAGE_EXPOSURE_S see #NETDEV_IMAGE_EXPOSURE_S
        * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
        * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置通道的图像曝光参数  Set image Exposure configuration information
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IMAGE_EXPOSURE_S see #NETDEV_IMAGE_EXPOSURE_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        /**
          * 获取昼夜模式信息  Get IRcut filter info
          * @param [IN]   lpUserID            用户登录句柄 User login ID
          * @param [IN]   dwChannelID         通道号 Channel ID
          * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IRCUT_FILTER_INFO_S see #NETDEV_IRCUT_FILTER_INFO_S
          * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
          * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
          * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
          * @note
          */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置昼夜模式信息  Set IRcut filter info
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_IRCUT_FILTER_INFO_S see #NETDEV_IRCUT_FILTER_INFO_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, Int32 dwInBufferSize);

        /**
          * 获取车位信息
          * @param [IN]   lpUserID            用户登录句柄 User login ID
          * @param [IN]   dwChannelID         通道号 Channel ID
          * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_ITS_PARKING_DETECTION_S see #NETDEV_ITS_PARKING_DETECTION_S
          * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
          * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
          * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
          * @note
          */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ITS_PARKING_DETECTION_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
          * 获取OSD内容样式  Get OSD content style
          * @param [IN]   lpUserID            用户登录句柄     User login ID
          * @param [IN]   dwChannelID         通道号           Channel ID
          * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_OSD_CONTENT_STYLE_S   see #NETDEV_OSD_CONTENT_STYLE_S
          * @param [IN]   lpInBuffer          输入数据的缓冲指针   Pointer to buffer of input data
          * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位)  Length of input data buffer (byte)
          * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
          * @note
          */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        /**
         * 设置OSD内容样式 Set OSD content style
         * @param [IN]   lpUserID            用户登录句柄 User login ID
         * @param [IN]   dwChannelID         通道号 Channel ID
         * @param [IN]   dwCommand           设备配置命令,参见#NETDEV_OSD_CONTENT_STYLE_S see #NETDEV_OSD_CONTENT_STYLE_S
         * @param [IN]   lpInBuffer          输入数据的缓冲指针 Pointer to buffer of input data
         * @param [IN]   dwInBufferSize      输入数据的缓冲长度(以字节为单位) Length of input data buffer (byte)
         * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, Int32 dwInBufferSize);

        /**
        * 恢复出厂设置  Restore to factory default settings
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note 保留网络配置和用户配置,其他参数恢复到出厂设置. Restore all parameters to factory settings, except network settings and user settings.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        /**
        * 影像参数获取,只获取当前画面参数  Get the current image info
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN]  pstImageInfo   图像信息列表 Image information list
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        /**
        * 影像调节,只改变当前画面  Adjust the current image
        * @param [IN]  lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN]  pstImageInfo   图像信息列表 Image information list
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        /**
        * 设置数字放大  Set Digital zoom
        * @param [IN] lpPlayHandle   预览\回放句柄 Preview\playback handle
        * @param [IN] hWnd           窗口句柄  window handle 
        * @param [IN] pstRect        矩形区域 Rectangle Area
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note pstRect为空时,显示全部画面,即退出数字放大 All images will be displayed with digital zoom disabled when pstRect is null
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        /**
        * 获取映射端口 Get UPnP net state info
        * @param [IN]   lpUserID     用户登录句柄 User login ID
        * @param [IN]   pstNatState  网络端口号状态信息 UPnP nat state info
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        /**
        * 修改设备名称 Set device name
        * @param [IN] lpUserID         用户登录句柄 User login ID
        * @param [IN] pszDeviceName    设备名称  Device name
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        /**
        * 设置日志路径业务 Set log path
        * @param [IN]   pszLogPath  日志路径(不包含文件名)  Log path (file name not included)
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetLogPath(String strLogPath);

        /**
        * 设置日志文件大小和数量 Set log file size and number
        * @param [IN] dwLogFileSize     单个日志文件大小(单位字节) The size of single log file
        * @param [IN] dwLogFileNum      日志文件个数  Log file number
        * @return TRUE表示成功,其他表示失败 TRUE means success, any other value indicates failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ConfigLogFile(Int32 dwLogFileSize, Int32 dwLogFileNum);

        /**
        * 获取设备系统时间配置 Get device System time configuration
        * @param [IN]  pstSystemTimeInfo    时间配置结构体指针  Pointer to time configuration structure
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        /**
        * 设置设备系统时间配置 Set device system time configuration
        * @param [IN]  pstSystemTimeInfo    时间配置结构体指针  Pointer to time configuration structure
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        /**
        * 设置超时时间 Set timeout
        * @param [IN]  pstRevTimeout         超时时间指针 Pointer to timeout
        * @return TRUE表示成功,其他表示失败    TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        /**
        * 注册实时码流回调函数：解码后视频媒体流数据  Callback function to register live stream (decoded media stream data)
        * @param [IN]  lpPlayHandle                 预览\回放句柄 Preview\playback handle
        * @param [IN]  cbPlayDecodeVideoCALLBACK    数据回调函数 Data callback function
        * @param [IN]  bContinue                    是否继续进行后面的显示操作 Whether to continue to following displaying operations.
        * @param [IN]  lpUserData                   用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 若关闭回调函数,将第二个参数置为NULL.
        * - To shut the callback function, set the second parameter as NULL.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, ref NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);
        // public static extern Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, IntPtr cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        /**
        * 注册码流回调函数:原始码流  Callback function to register streams (original stream)
        * @param [IN]  lpPlayHandle               实时预览句柄 Live preview handle
        * @param [IN]  cbSourceDataCallBack       码流数据回调函数 Callback function for stream data
        * @param [IN]  bContinue                  是否继续进行后面的拼帧.解码和显示操作 Whether to continue to following framing, decoding and displaying operations.
        * @param [IN]  lpUser                     用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        /**
        * 设置显示后数据回调  Modify displayed data callback
        * @param [IN]  lpPlayHandle             预览\回放句柄 Preview\playback handle
        * @param [IN]  cbPlayDisplayCallBack    数据回调函数 Data callback function
        * @param [IN]  lpUserData               用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 若关闭回调函数,将第二个参数置为NULL.
        * - To shut the callback function, set the second parameter as NULL.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        /**
        * 注册实况码流回调函数:拼帧后码流数据  Callback function to register live stream (framed stream data)
        * @param [IN]  lpPlayHandle              预览\回放句柄 Preview\playback handle
        * @param [IN]  cbParsePlayDataCallBack   数据回调函数 Data callback function
        * @param [IN]  bContinue                 是否继续进行后面的解码和显示操作 Whether to continue to following decoding and displaying operations.
        * @param [IN]  lpUserData                用户数据 User data
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note
        * - 若关闭回调函数,将第二个参数置为NULL.
        * - To shut the callback function, set the second parameter as NULL.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, ref NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);
        //public static extern Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        /**
        * 开启语音对讲 Start two-way audio
        * @param [IN]  lpUserID                 用户登录句柄  User ID
        * @param [IN]  dwChannelID              通道号  Channel ID
        * @param [IN]  cbRealDataCallBack       码流数据回调函数指针  Pointer to callback function of the stream data 
        * @param [IN]  lpUserData               用户数据   User data
        * @return 返回的用户登录句柄,返回 0 表示失败,其他值表示返回的用户登录句柄值 Returned user ID. 0 means failure, and any other value is a user ID.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        /**
        * 关闭语音对讲 Stop two-way audio
        * @param [IN]  lpPlayHandle   对讲句柄 Two-way audio handle
        * @return TRUE表示成功,其他表示失败 TRUE means success, any other value indicates failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCloudDevInfoByName(IntPtr lpUserID, String pszRegisterCode, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCloudDevInfoByRegCode(IntPtr lpUserID, String pszRegisterName, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo);

        /**
        * 获取所有用户全部信息  GetUserDetailList
        * @param [IN]   lpUserID                    用户登录ID     User login ID
        * @param [OUT]   pstUserDetailList          用户信息 请参见结构体#LPNETDEV_USER_DETAIL_LIST_S   See #LPNETDEV_USER_DETAIL_LIST_S
        * @return TRUE表示成功,其他表示失败     TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        /**
        * 删除用户信息  Delete User Info
        * @param [IN]   lpUserID                用户登录ID   User login ID
        * @param [IN]   pszUserName             用户名       User name
        * @return TRUE表示成功,其他表示失败     TRUE means success, and any other value means failure.
        * @note 无 None
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        /**
        * 创建用户信息  CreateUser
        * @param [IN]   lpUserID                      用户登录ID      User login ID
        * @param [IN]   pstUserDetailInfo             用户信息请参见结构体#NETDEV_USER_DETAIL_INFO_S    See #NETDEV_USER_DETAIL_INFO_S
        * @return TRUE表示成功,其他表示失败  TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        /**
        * 修改用户信息  ModifyUser
        * @param [IN]   lpUserID                用户登录ID        User login ID
        * @param [IN]   pstUserInfo             用户信息请参见结构体#NETDEV_USER_INFO_S    User modify info See#NETDEV_USER_INFO_S 
        * @return TRUE表示成功,其他表示失败
        * @note
            1、仅管理员用户支持修改权限，管理员用户修改其他用户信息不需要携带旧密码
            2、操作员及普通用户只能修改自己的密码
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        /**
        * 获取设备电子罗盘信息 Obtain compass info
        * @param [IN]   lpUserID                用户登录ID      User login ID
        * @param [IN]   dwChannelID             通道号          Channel ID
        * @param [OUT]  pfCompassInfo           电子罗盘信息（与正北的夹角）   Electronic compass info
        * @return TRUE表示成功,其他表示失败     TRUE means success, and any other value means failure.
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        /**
        * 获取设备定位信息 Obtain geolocation info
        * @param [IN]   lpUserID                用户登录ID User login ID
        * @param [IN]   dwChannelID             通道号  Channel ID
        * @param [OUT]  pstGPSInfo              定位信息 Geolocation info
        * @return TRUE表示成功,其他表示失败 TRUE means success, and any other value means failure.
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        /**
        * 导出配置文件业务    GetConfigFile
        * @param [IN]   lpUserID                  用户登录ID User login ID
        * @param [IN]   pszConfigPath             配置文件路径（包含文件名称,后缀名为tgz）  cfg file path（tgz）
        * @return TRUE表示成功,其他表示失败       TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        /**  
        * 导入配置文件业务                        SetConfigFile
        * @param [IN]   lpUserID                  用户登录ID        User login ID
        * @param [IN]   pszConfigPath             配置文件路径（包含文件名称,命名格式：设备型号_IP地址_config.tgz, 如：HIC5621E-L-U_192.168.3.112_config.tgz）
        *                                         EX：HIC5621E-L-U_192.168.3.112_config.tgz）
        * @return TRUE表示成功,其他表示失败       TRUE means success, and any other value means failure
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        /**
        * 元数据处理
        * @param [IN] lpPlayHandle              播放句柄
        * @param [IN] bEnableIVA                是否添加元数据
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        /**
        * 设置元数据绘图显示类型参数
        * @param [IN] dwShowParam              元数据显示类型参数，参见# NETDEV_IVA_SHOW_RULE_E
        * @return TRUE表示成功,其他表示失败
        * @note
        * -    1.该接口函数仅支持Windows.
        * -    2.请将规则进行组合,比如显示规则线框和触发规则目标框,下发的ulShowParam = NETDEV_IVA_SHOW_RULE|NETDEV_IVA_SHOW_RESULT_TOUTH_RULE；以此类推
        * -    3.已最后一次设置的显示类型为准,之前设置的显示操作取消
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        /**
        * 查询所有人员库的容量信息
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @param [IN]   dwTimeOut              连接超时时间
        * @param [OUT]  pstCapacityList   所有人员库的容量信息
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID, Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        /**
        * 创建人员库信息                                Create Person libraries information
        * @param [IN]  lpUserID                         用户登录句柄 User login ID
        * @param [IN]  pstLibraryList                   人员库信息 Person library information
        * @param [OUT]  *pudwID                         创建库生成的库ID create library generated libry ID
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref UInt32 pudwID);

        /**
        * 查询所有已创建的人员库信息 Get all Person libraries information
        * @param [IN]  lpUserID         用户登录句柄 User login ID
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextPersonLibInfo、NETDEV_FindClosePersonLibList等函数的参数。
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        /**
        * 逐个获取查找到的 人脸库 信息
        * @param [IN]  lpFindHandle           查找句柄 
        * @param [OUT] pstPersonLibInfo       保存 人脸库 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        /**
        * 关闭查找 人脸库，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        /**
        * 修改人员库信息  Modify Person libraries information
        * @param [IN]  lpUserID         用户登录句柄 User login ID
        * @param [IN]  pstLibraryList   人员库信息 Person library information
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        /**
        * 删除指定的人员库    Delete designated Person libraries information
        * @param [IN]  lpUserID     用户登录句柄 User login ID
        * @param [IN]  udwPersonLibID   人员库ID Person library ID
        * @param [IN]  pstFlagInfo   人员库删除标志
        * @return TRUE表示成功,其他表示失败
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        /**
        * 条件查询人员信息
        * @param [IN] lpUserID 用户登录句柄
        * @param [IN] udwPersonLibID 人员库ID
        * @param [IN] pstQueryInfo 人脸信息查询条件
        * @param [OUT] pstQueryResultInfo 人脸信息查询返回结果
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextPersonInfo、NETDEV_FindClosePersonInfoList等函数的参数
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        /**
        * 逐个获取查找到的 人员 信息
        * @param [IN]  lpFindHandle            查找句柄 
        * @param [OUT] pstPersonInfo          保存 人员信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        /**
        * 关闭查找 人员信息，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        /**
        * 新增指定的人员信息 Add designated Person information
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  udwPersonLibID       人员库ID Person library ID
        * @param [IN]  pstPersonInfoList    人员信息列表 Person information list
        * @param [OUT]  pstPersonResultList 人员信息结果列表 Person information result list
        * @return TRUE表示成功,其他表示失败
        * @note pstPersonResultList->pstPersonList need malloc by caller
                keep pstPersonResultList->udwNum == pstPersonInfoList->udwNum
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        /**
        * 修改指定的人员信息 Modify designated Person information
        * @param [IN]  lpUserID             用户登录句柄 User login ID
        * @param [IN]  udwPersonLibID       人员库ID Person library ID
        * @param [IN]  pstPersonInfoList    人员信息列表 Person information list
        * @param [OUT]  pstPersonResultList 人员信息结果列表 Person information result list
        * @return TRUE表示成功,其他表示失败
        * @note pstPersonResultList->pstPersonList need malloc by caller
                keep pstPersonResultList->udwNum == pstPersonInfoList->udwNum
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        /**
         * 删除指定的人员信息 Delete designated Person information
         * @param [IN]  lpUserID         用户登录句柄 User login ID
         * @param [IN]  udwPersonLibID   人员库ID Person library ID
         * @param [IN]  udwPersonID      人员ID Person ID
         * @param [IN]  udwLastChange    最后修改时间 Last modify time
         * @return TRUE表示成功,其他表示失败
         * @note无
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);

        /**
        * 批量删除人员信息
        * @param [IN] lpUserID             用户登录ID
        * @param [IN] udwPersonLibID       人脸库ID
        * @param [IN] pstIDList            人脸成员列表
        * @param [OUT] pstBatchList        批量操作返回信息
        * @return 查询句柄,返回0表示失败，
        * @note 仅VMS支持
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        /**
        * 查询人脸识别记录
        * @param [IN]  lpUserID                   用户登录ID 
        * @param [IN]  pstFindCond                查询条件
        * @param [OUT] pstResultInfo              人脸识别记录信息
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindFaceNextRecordDetail、NETDEV_FindFaceCloseRecordDetail等函数的参数。
        * @note     查询完成之后需要保证调用NETDEV_FindFaceNextRecordDetail将所有数据取出，否则会造成内存泄露
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        /**
        * 逐个获取查找到的 人脸识别记录信息
        * @param [IN]  lpFindHandle                    查找句柄 
        * @param [OUT] pstRecordInfo                   保存 人脸识别记录 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        /**
        * 关闭查找 人脸识别记录，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        /**
        * 查询单个人脸识别记录的人脸图片信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN] udwRecordID                  人脸识别告警记录ID
        * @param [IN] udwFaceImageType              人脸通行记录类型
        * @param [OUT] pstFileInfo                 人脸图片信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note pstFileInfo中人脸图片内存由使用者维护，入参时需指定udwSize大小，内存不够调用失败时，udwSize会返回实际需要大小
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        /**
        * 查询所有人脸布控任务
        * @param [IN]  lpUserID              用户登录ID
        * @param [IN]  udwChannelID          通道ID，仅NVR查询通道布控信息时使用
        * @param [IN]  pstQueryInfo          查询条件，仅NVR支持
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextPersonMonitorInfo、NETDEV_FindCloseMonitorInfo等函数的参数。
        * @note    
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        /**
        * 逐个获取查找到的 布控任务 信息
        * @param [IN]  lpFindHandle            查找句柄 
        * @param [OUT] pstMonitorInfo          保存 布控任务 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        *.      返回NETDEV_E_NEED_MORE_MEMORY说明分配不足，并返回实际应申请的内存大小；涉及的数据：pstMonitorInfo->udwLinkStrategyNum、
                 pstMonitorInfo->stMonitorRuleInfo.udwChannelNum
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        /**
        * 关闭查找 布控任务，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        /**
        * 新增单个人脸布控任务 
        * @param [IN]    lpUserID                      用户登录ID 
        * @param [INOUT]    pstMonitorInfo                保存 布控任务 信息的指针  成功返回布控任务序号
        * @param [INOUT] pstMonitorResultInfo          添加布控后设备返回的实际布控结果
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  pstMonitorResultInfo->udwChannelNum不应小于pstMonitorInfo stMonitorRuleInfo.udwChannelNum
                 pstMonitorResultInfo->udwChannelNum must be Greater thanpstMonitorInfo stMonitorRuleInfo.udwChannelNum    
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        /**
        * 批量删除人脸布控任务 
        * @param [IN]  lpUserID                      用户登录ID 
        * @param [INOUT] pstResultList               返回信息列表  输入布控要删除的所有布控ID
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        /**
        * 查询单个人脸布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID 
        * @param [INOUT] pstMonitorInfo            保存 布控任务 信息的指针，输入布控ID，成功返回配置信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note pudwMonitorChlIDList由上层申请；接口失败(NETDEV_E_NEED_MORE_MEMORY)时通过udwChannelNum判断是否内存申请过小
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        /**
        * 设置单个人脸布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID 
        * @param [IN] pstMonitorInfo               保存 布控任务 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindMonitorDevResult(IntPtr lpUserID, ref UInt32 pudwDevNum);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextMonitorDevResult(IntPtr lpFindHandle, ref NETDEV_MONITOR_DEV_RESULT_INFO_S pstMonitorDevResultInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseMonitorDevResult(IntPtr lpFindHandle);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        /**
        * 查询全部车辆库信息列表
        * @param [IN] lpUserID          用户登录ID
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextVehicleLibInfo、NETDEV_FindCloseVehicleLibList等函数的参数。
        * @note     
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        /**
        * 逐个获取查找到的 车辆库 信息
        * @param [IN]  lpFindHandle           查找句柄 
        * @param [OUT] pstVehicleLibInfo      保存 车辆库 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        /**
        * 关闭查找 车辆库，释放资源
        close finding vehicleDB Release resources
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        /**
        * 新增单个车辆库信息
        * add vehicleDB information
        * @param [IN] lpUserID                   用户登录ID User login ID
        * @param [INOUT] pstVehicleLibInfo       车库信息VehicleDB info
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        /**
        * 修改指定的车辆库信息
        * Modify the specified vehicleDB information
        * @param [IN] lpUserID                  用户登录ID User login ID
        * @param [IN] pstVehicleLibList         车辆库列表 Vehicle Lib List
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        /**
        * 删除指定的车辆库信息
        * delete the specified vehicleDB information
        * @param [IN] lpUserID                   用户登录ID User login ID
        * @param [IN] udwVehicleLibID            车辆库ID Vehicle DB ID 
        * @param [IN] pstDelLibFlag              删除库信息的标志位
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        /**
        * 批量添加车辆成员信息
        * @param [IN] lpUserID                用户登录ID
        * @param [IN] udwLibID                车辆库ID
        * @param [IN] pstVehicleMemberList    车辆信息列表
        * @param [OUT] pstResultList          批量添加返回结果信息列表
        * @return 查询句柄,返回0表示失败，
        * @note    
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        /**
        * 修改指定车辆库中车辆信息
        * modify vehicleDB information
        * @param [IN] lpUserID                        用户登录ID User login ID
        * @param [IN] udwVehicleLibID                 车辆库IDVehicle ID
        * @param [IN] pstVehicleDetailInfo            车辆详细信息 Vehicle Detail info  
        * @param [OUT] pstResultList                  批量操作返回信息 Batch operate result info
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        /**
        * 批量删除车辆成员信息
        * @param [IN] lpUserID                  用户登录ID
        * @param [IN] udwLib                    库序号
        * @param [IN] pstVehicleMemberList      车辆成员列表
        * @param [OUT] pstBatchList             批量操作返回信息
        * @return 查询句柄,返回0表示失败，
        * @note    
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        /**
         * 条件查询车辆成员详细信息
         * @param [IN]  lpUserID         用户登录ID
         * @param [IN]  udwVehicleLibID  库序号
         * @param [IN]  pstFindCond      查询条件
         * @param [OUT] pstFaceDBList    人脸库基本信息
         * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextVehicleMemberDetail、NETDEV_FindCloseVehicleMemberDetail等函数的参数。
         * @note    1、人脸库中成员的基本信息由NETDEV_FindNextVehicleMemberDetail查询返回，pstFaceDBList只带回成员的基本信息
         *@           2、调用成功后需要调用NETDEV_FindNextVehicleMemberDetail将数据取完，否则会出现内存泄露
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        /**
        * 逐个获取查找到的 车辆成员 信息
        * @param [IN]  lpFindHandle           查找句柄 
        * @param [OUT] pstFaceMemberInfo      保存 车辆库中成员 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        /**
        * 关闭查找 车辆成员，释放资源
        * @param [IN] lpFindHandle  文件查找句柄 
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        /**
        * 条件查询车辆识别记录的详细信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN] pstFindCond                  查询条件
        * @param [OUT] pstResultInfo               查询的记录信息
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindVehicleNextRecordInfo、NETDEV_FindVehicleCloseRecordInfo等函数的参数。
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        /**
        * 逐个获取查找到的车辆识别记录信息
        * @param [IN]  lpFindHandle                    查找句柄
        * @param [OUT] pstRecordInfo                   保存车辆识别记录信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 返回失败说明查询结束 A returned failure indicates the end of search.
            图片数据需要取出另存，否则在调用NETDEV_FindVehicleCloseRecordInfo接口后内存将被释放
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        /**
        * 关闭查找车辆识别记录，释放资源
        * @param [IN] lpFindHandle  文件查找句柄
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        /**
        * 查询单个车辆识别记录的车辆图片信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN] udwRecordID                  车辆识别记录ID
        * @param [INOUT] pstFileInfo                 车辆图片信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  pstFileInfo内存由使用者维护，入参时需指定udwSize大小，内存不够调用失败时，udwSize会返回实际需要大小
        对应错误码：NETDEV_E_NEED_MORE_MEMORY   用户分配内存不够；
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        /**
        * 向指定的车辆库中批量划归车辆成员
        * .Batch assigned to the vehicle member in the specified database
        * @param [IN] lpUserID                  用户登录ID User login ID
        * @param [IN] udwVehicleLibID           车辆库ID CaVehicleLibID 
        * @param [IN] pstMemberList             批量划归车辆成员ID信息 Batch assigned vehicle member ID information
        * @param [OUT] pstBatchResultList               批量划归车辆信息返回结果 Batch assigned vehicle member ID result
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        /**
         * 批量取消指定的车辆库中车辆成员划归
         * .Batch cancellation to the vehicle member in the specified database
         * @param [IN] lpUserID                  用户登录ID User login ID
         * @param [IN] udwVehicleLibID           车辆库ID VehicleLibID 
         * @param [IN] pstMemberList             批量取消车辆成员ID信息 Batch cancellation vehicle member ID information
         * @param [OUT] pstBatchResultList               批量取消车辆信息返回结果 Batch cancellation vehicle member ID result
         * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
         * @note
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        /**
        * 新增单个车辆布控任务
        * @param [IN]  lpUserID                      用户登录ID
        * @param [INOUT]  pstMonitorInfo                布控任务信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 车辆布控比对照片不超过2M,内存由使用者维护
                udwMonitorID 车辆布控任务序号此处作为出参使用，其余参数为入参
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        /**
        * 批量删除车辆布控任务
        * @param [IN]  lpUserID用户登录ID
        * @param [INOUT] pstBatchList              信息列表
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        /**
        * 查询车辆识别的所有布控任务
        * @param [IN]  lpUserID              用户登录ID
        * @return 查询句柄,返回0表示失败，其他值作为NETDEV_FindNextVehicleMonitorInfo、NETDEV_FindCloseVehicleMonitorInfo等函数的参数。
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        /**
        * 逐个获取查找到的车辆布控任务信息
        * @param [IN]  lpFindHandle            查找句柄
        * @param [OUT] pstMonitorInfo          保存 布控任务 信息的指针
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note  车辆布控比对照片内存由使用者维护，入参时，需要指定接收图片缓存大小，失败时会返回实际需要的大小
                如果没有布控图片时，布控图片的大小将会被置为0;
                图片数据需要取出另存，否则在调用NETDEV_FindVehicleCloseRecordInfo接口后内存将被释放;
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        /**
        * 关闭查找车辆布控任务，释放资源
        * @param [IN] lpFindHandle  文件查找句柄
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        /**
        * 查询单个车辆布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN]  udwID                       车辆布控ID
        * @param [INOUT] pstMonitorInfo            布控任务信息 输入布控ID,成功时返回配置信息
                                                    udwMonitorID 车辆布控任务序号 IN
                                                    stMonitorRuleInfo 车辆布控任务配置信息 OUT
                                                    stMonitorRuleInfo.stVehicleImage.udwSize 文件大小 INOUT
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 车辆布控比对照片内存由使用者维护，入参时，需要指定接收图片缓存大小，失败时会返回实际需要的大小
        对应错误码：NETDEV_E_NEED_MORE_MEMORY   用户分配内存不够；
        如果没有布控图片时，布控图片的大小将会被置为0;
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        /**
        * 设置单个车辆布控任务配置信息
        * @param [IN]  lpUserID                    用户登录ID
        * @param [IN]  udwID                       车辆布控ID
        * @param [INOUT] pstMonitorInfo            布控任务信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 车辆布控比对照片不超过2M,内存由使用者维护
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        /**
        * 订阅智能事件
        * @param [IN] lpUserID              用户登录ID
        * @param [IN] pstSubscribeInfo      订阅信息
        * @param [INOUT] pstSmartInfo       智能事件信息，成功返回订阅ID
        * @return TRUE表示成功，其他表示失败
        * @note   订阅前需要先调用NETDEV_SetAlarmCallBack接口注册回调函数
        * -
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        /**
        * 取消订阅智能事件
        * @param [IN] lpUserID            用户登录ID
        * @param [IN] pstSmartInfo         智能事件
        * @return TRUE表示成功，其他表示失败
        * @note
        * -
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        /**
        * LAPI告警订阅
        * @param [IN] lpUserID                                      用户登录句柄
        * @param IN LPNETDEV_LAPI_SUB_INFO_S   pstSubInfo           告警订阅请求
        * @param OUT LPNETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo  订阅成功返回信息
        * @return TRUE表示成功,其他表示失败 
        * @note Type字段指定订阅类型
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        /**
        * 取消LAPI告警订阅
        * @param [IN] lpUserID               用户登录句柄
        * @param [IN] UINT32 udwID           告警订阅ID
        * @return TRUE表示成功,其他表示失败 
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        /**
        * 获取门禁人员信息列表
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstQueryCond                                  门禁人员查询条件
        * @param [OUT] pstResultInfo                                返回信息
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSPersonInfo,NETDEV_FindCloseACSPersonInfo等函数的参数
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一个门禁人员信息
        * @param [IN] lpFindHandle                                  门禁人员信息列表句柄
        * @param [OUT] pstACSPersonInfo                             门禁人员信息
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        /**
        * 关闭门禁人员信息列表资源
        * @param [IN] lpFindHandle                                      门禁人员信息列表句柄
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        /**
        * 门禁人员管理
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] dwCommand                                     门禁人员管理命令可参考#NETDEV_ACS_PERSON_COMMOND_TYPE_E
        * @param [INOUT] pstACSPersonInfo                           门禁人员信息
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        /**
        * 批量添加人员信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstACSPersonList         人员列表   其中单张图片大小为2M
        * @param [OUT] pstResultList           返回列表
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList);

        /**
        * 批量删除门禁人员信息
        * @param [IN] lpUserID                                      用户登录ID
        * @param [INOUT] pstBatchCtrlInfo                           批量控制信息
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        /**
        * 查看门禁授权组列表
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstFindCond                                   查询条件
        * @param [OUT] pstResultInfo                                实际查询结果
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSPermissionGroupInfo,NETDEV_FindCloseACSPermissionGroupInfo等函数的参数
        * @note 查询之后需要调用NETDEV_FindNextACSPermissionGroupInfo和NETDEV_FindCloseACSPermissionGroupInfo将数据获取完，否则会造成内存泄露
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一条记录
        * @param [IN] lpFindHandle                              门禁授权组列表信息列表句柄
        * @param [OUT] pstACSPermissionInfo                     门禁授权组列表信息
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        /**
        * 关闭查询记录资源
        * @param [IN] lpFindHandle                                  门禁授权组列表句柄
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        /**
        * 添加人员授权组信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstPermissionGroupInfo        授权组信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);

        /**
        * 修改人员授权组信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstPermissionInfo        授权组信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);

        /**
        * 删除人员授权组信息
        * @param [IN] lpUserID                 用户登录ID
        * @param [IN] pstPermissionIDList      权限ID数组
        * @param [INOUT] 
        * @param [OUT] 
        * @return 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        /**
        * 获取单个授权组信息
        * @param [IN] lpUserID                                              用户登录ID
        * @param [IN] udwPermissionGroupID                                  授权组id
        * @param [INOUT] pstAcsPerssionInfo                                   权限组信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        /**
        * 获取指定人员授权信息
        * @param [IN] lpUserID                       用户登录ID
        * @param [IN] udwPersonID                    人员ID
        * @param [INOUT] pstPermissionInfo           人员授权信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        /**
        * 设置指定人员授权信息
        * @param [IN] lpUserID                       用户登录ID
        * @param [IN] pstPermissionInfo              人员授权信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        /**
        * 门禁通道控制
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] dwChannelID                                   通道号
        * @param [IN] dwCommand                                     门禁通道控制命令可参考#NETDEV_DOORCTRL_ACTION_TYPE_E
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        /**
        * 门禁通道批量控制
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] dwCommand                                     门禁通道控制命令可参考#NETDEV_DOORCTRL_ACTION_TYPE_E
        * @param [IN] pstBatchCtrlInfo                              批量控制信息
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        /**
        * 查询访客记录
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstFindCond                                   访客记录查询条件
        * @param [OUT] pstResultInfo                                访客记录实际总条数
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSVisitLog,NETDEV_FindCloseACSVisitLog等函数的参数
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一条访客记录
        * @param [IN] lpFindHandle                              出入记录信息列表句柄
        * @param [OUT] pstACSLogInfo                            出入记录信息
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        /**
        * 关闭查询访客记录资源
        * @param [IN] lpFindHandle                                  出入记录信息列表句柄
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        /**
        * 获取访客黑名单列表
        * @param [IN] lpUserID                                      用户登录ID
        * @param [IN] pstFindCond                                   查询条件
        * @param [OUT] pstResultInfo                                实际查询结果
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSPersonBlackList,NETDEV_FindCloseACSPersonBlackList等函数的参数
        * @note 查询之后需要调用NETDEV_FindNextACSPersonBlackList和NETDEV_FindCloseACSPersonBlackList将数据获取完，否则会造成内存泄露
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * 获取下一条记录  FindNextACSPersonBlackListInfo
        * @param [IN] lpFindHandle                              访客黑名单列表信息列表句柄
        * @param [OUT] pstACSPermissionInfo                     访客黑名单列表信息        
        * @return TRUE表示成功，其他表示失败
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        /**
        * 关闭查询记录资源                                  FindCloseACSAttendanceLogList
        * @param [IN] lpFindHandle  访客黑名单列表句柄
        * @return TRUE表示成功，其他表示失败                TRUE means success, and any other value means failure.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        /**
        * 添加访客黑名单                        AddACSPersonBlackList
        * @param [IN] lpUserID                  用户登录ID           user login ID
        * @param [IN] pstBlackListInfo          黑名单信息           BlackList Info
        * @return 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        /**
        * 删除访客黑名单     DeleteACSPersonBlackList
        * @param [IN] lpUserID                   用户登录ID       user login ID
        * @param [IN] pstBlackList               黑名单信息列表   BlackList Info
        * @param [INOUT] 
        * @param [OUT] 
        * @return 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        /**
        * 修改访客黑名单信息  ModifyACSPersonBlackList
        * @param [IN] lpUserID                  用户登录ID     user login ID
        * @param [IN] pstBlackListInfo          黑名单信息     BlackList Info
        * @return 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        /**
        * GetACSPersonBlackList                 获取指定访客黑名单信息
        * @param [IN] lpUserID                  用户登录ID   user login ID
        * @param [IN] pstBlackListInfo          黑名单信息，其中udwBlackListID作为入参传入   BlackList Info
        * @param [INOUT] 
        * @param [OUT] 
        * @return 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        /**
        * 查询出入记录
        * @param [IN] lpUserID                                      用户登录ID             user login ID
        * @param [IN] pstFindCond                                   出入记录查询条件
        * @param [OUT] pstResultInfo                                出入记录实际总条数
        * @return 查询句柄，返回NULL表示失败，其他作为NETDEV_FindNextACSAttendanceLog,NETDEV_FindCloseACSAttendanceLogList等函数的参数
        * @note 查询之后需要调用NETDEV_FindNextACSAttendanceLog和NETDEV_FindCloseACSAttendanceLogList将数据获取完，否则会造成内存泄露
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        /**
        * FindNextACSAttendanceLog
        * @param [IN] lpFindHandle                              出入记录信息列表句柄
        * @param [OUT] pstACSLogInfo                            出入记录信息
        * @return TRUE表示成功，其他表示失败 TRUE means success, and any other value means failure.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        /**
        * 关闭查询出入记录资源                             FindCloseACSAttendanceLogList
        * @param [IN] lpFindHandle  出入记录信息列表句柄
        * @return  TRUE means success, and any other value means failure.
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        /**
        * 获取系统图片信息                          
        * @param [IN]   lpUserID                     用户登录ID     User login ID
        * @param [IN]   pszURL                       图片URL        picture url
        * @param [IN]   udwSize                      加密前数据大小   
        * @param [OUT]   pszdata                     图片数据(需动态分配内存)   picture data
        * @return TRUE表示成功，其他表示失败
        * @note无
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        /**
        * Get SDK version
        * @param [IN]  pszVersion  Version Info (Lenth: 64 BYTE)
        * @return TRUE 表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note pszVersion内存由调用者申请释放
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPARKVersion(byte[] strVersion);

        /* 设置SDK与设备连接异常/恢复信息数据上报回调函数  Set status callback.(NEW)
       * @param [IN] lpUserID          用户登录句柄 User login ID
       * @param [IN] cbItsStatusReportCallBack     SDK与设备连接异常/恢复信息数据上报回调函数的指针  Pointer to callback function if Status data.
       * @param [IN]  lpUserData       用户数据     User Data.
       * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
       * @note  
       */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetParkStatusCallBack(IntPtr lpUserID, NETDEV_ParkStatusReportCallBack_PF cbParkStatusReportCallBack, IntPtr lpUserData);        /**
        * 启动照片流 Start Photo stream.
        * @param [IN]  lpUserID          用户登录ID   User login ID
        * @param [IN]  hPlayWnd          过车图片显示播放窗口句柄,如果为0不显示   Play window handle. NULL means not play
        * @param [IN]  bReTran           是否断网重传:TRUE表示断网重传（照片服务器开启，历史数据同步上传）,FALSE表示断网不重传（仅上报实时数据）
        *                                Whether retransmit. TRUE means use retransmission mode, FALSE means not use retransmission mode.
        * @param [IN]  pcReTranIP        若第二各参数为TRUE，此参数重传码流接收端IP地址; 若第二各参数为FALSE，不重传填空,""
        *                                If retransmission is enabled, fill in this field with the IP address of the PC that hosts the SDK program; otherwise, this field is empty.
        * @param [IN]  pfnPicDataCBFun   过车抓拍识别数据回调函数指针
        *                                Pointer to callback function of Vehicle data.
        * 
        * @param [IN]  lpUserData        用户数据  User Data.
        * @return  返回的照片流句柄,返回 0 表示失败.  Return Stream startup handle, 0 means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartPicStream(IntPtr lpUserID, IntPtr hPlayWnd, bool bReTran, string pcReTranIP, NETDEV_PIC_UPLOAD_PF pfnPicDataCBFun, IntPtr lpUserData);

        /**
         * 停止照片流  Stop Photo stream.
         * @param [IN]  lpPlayHandle   照片流句柄  Current Photo stream handle
         * @return TRUE表示成功,其他表示失败.  TRUE means success, otherwise means failure.
         * @note 对应关闭NETDEV_StartPicStream开启的照片流 Stop the  Photo stream started by NETDEV_StartPicStream
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPicStream(IntPtr lpPlayHandle);

        /**
        * 手动前端抓拍(异步)  Asynchronous capture in image preview.
        * @param [IN]  lpFindHandle   用户登录ID User login ID
        * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note None
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Trigger(IntPtr lpFindHandle);

        /**
        * 手动前端抓拍(同步)  Synchronous capture in image preview.
        * @param [IN]  lpFindHandle   用户登录ID, User login ID
        * @param [IN]  ppstPicData    指向获取的抓拍车辆信息数据的指针  ppstPicData Pointer to the obtained image info
        * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note None
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_TriggerSync(IntPtr lpFindHandle, ref IntPtr ppstPicData);

        /**
        * 输出开关量
        * @param [IN]  lpFindHandle   用户登录ID
        * @return TRUE表示成功,其他表示失败
        * @note PARK出入口接入道闸，可采用此接口命令开闸
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetOutputSwitchStatusCfg(IntPtr lpFindHandle);

        /**
         * 批量上传出入口设备白名单信息（已废弃） Batch import blacklists or whitelists 
         * @param [IN]  lpFindHandle   用户登录句柄  User login ID
         * @param [IN]  pcFile         文件保存路径(包含csv文件名)  Path to the file.
         * @return INT32 0 表示成功，其他见详见错误码  INT32 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 文件路径示例:“C:\车辆设备黑白名单模板\ GateBlacklist.csv”,黑名单文件命名(GateBlacklist.csv),白名单文件命名(GateWhitelist.csv)
         * Example: “C:\blacklist or whitelist template\ GateBlacklist.csv”,blacklist filename(GateBlacklist.csv),whitelist filename(GateWhitelist.csv)
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ImportBlackWhiteListFile(IntPtr lpFindHandle, String pcFile);

        /**
         * 批量下载出入口设备白名单信息（已废弃）\n  Batch export blacklists or whitelists
         * @param [IN]  lpFindHandle   用户登录句柄
         * @param [IN]  pcFile     文件保存路径(包含csv文件名)
         * @return INT32 0 表示成功，其他见详见错误码
         * @note 文件路径示例:“C:\车辆设备黑白名单模板\ GateBlacklist.csv”,黑名单文件命名(GateBlacklist.csv),白名单文件命名(GateWhitelist.csv)
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ExportBlackWhiteListFile(IntPtr lpFindHandle, String pcFile);

        /**
         * 添加黑白名单车辆信息操作  Add vehicle info to allowlist/blocklist 
         * @param [IN]  lpFindHandle 用户登录设备ID   User login ID
         * @param [IN]  pstVehicleRecordExtern  增加名单项内容
         * @return INT32 0表示成功，其他见相关错误码  NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无 None
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_EXTERN_S pstVehicleRecordExtern);

        /*
         * 修改白名单车辆成员信息操作   Modify vehicle info to allowlist 
         * @param [IN]  lpFindHandle 用户登录设备ID  User login ID
         * @param [IN]  pstVehicleRecords 修改名单项内容
         * @return INT32 0表示成功，其他见相关错误码  NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无 None
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyAllowVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern);

        /*
         * 修改黑名单车辆成员信息操作 Modify vehicle info to blocklist 
         * @param [IN]  lpFindHandle 用户登录设备ID  User login ID
         * @param [IN]  pstVehicleRecords 修改名单项内容
         * @return INT32 0表示成功，其他见相关错误码  NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无 None
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyBlockVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern);

        /*
         * 删除白名单车辆成员信息操作 Delete vehicle info to allowlist 
         * @param [IN]  lpFindHandle 用户登录设备ID   User login ID
         * @param [IN]  ulRecordID 删除名单项ID
         * @return INT32 0表示成功，其他见相关错误码 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteAllowVehicleRecord(IntPtr lpFindHandle, Int32 ulRecordID);

        /*
         * 删除黑名单车辆成员信息操作 Delete vehicle info to blocklist 
         * @param [IN]  lpFindHandle 用户登录设备ID User login ID
         * @param [IN]  ulRecordID 删除名单项ID
         * @return INT32 0表示成功，其他见相关错误码 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note 无
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteBlockVehicleRecord(IntPtr lpFindHandle, Int32 ulRecordID);

        /* 
         * 设置出入口设备Led显示内容 set Led 
         * @param [IN]  lpFindHandle      用户登录ID
         * @param [IN]  pstLedListCfgs    LED屏显示配置
         * @return INT32 0表示成功，其他见相关错误码 NETVMS_E_SUCCEED means success, otherwise means failure.
         * @note   时间实时显示可下发内容“#T”,由设备自行控制显示
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_setDeviceLedCfg(IntPtr lpFindHandle, ref NETDEV_LED_LIST_CFG_S pstLedListCfgs);

        /**
        * 车位检测器内置灯状态获取\n
        * @param [IN]   lpFindHandle
        * @param [OUT]  pstuCarportControlled  SDK车位内置指示灯控制参数
        * @return 0 表示成功,其他表示失败 TRUE means success, otherwise means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled);

        /**
        * 车位检测器内置灯控制 
        * @param [IN]  lpFindHandle   用户登录ID
        * @param [IN]  pstuCarportControlled 车位内置指示灯控制参数
        * @return 0 表示成功,其他表示失败  TRUE means success, otherwise means failure.
        * @note 
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled);

        /**
         * 车牌编码格式UTF-8 
         * @param [OUT] bEnable      0-GBK , 1-UTF-8 (默认UTF-8)  Sets the format of vehicle license contents reported. 0: GBK, 1: UTF-8. Default: UTF-8
         * @return TRUE表示成功,其他表示失败 TRUE means success, otherwise means failure.
         * @note None
         */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_EnableCarplate(Int32 bEnable);

        /**
        * 车位状态信息数据回调函数设置  set parking space status callback function 
        * @param [IN]  lpFindHandle             用户登录ID   User login ID
        * @param [IN]  pfnParkStatusCBFun   车位状态信息数据回调函数指针  Pointer to the buffer storing Parking space status data  
        * @param [IN]  lpUserData           用户数据  User data 
        * @return  TRUE表示成功,其他表示失败  TRUE means success, otherwise means failure.
        * @note  
        */
        [DllImport(ItsNetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetParkingStatusCB(IntPtr lpFindHandle, NETDEV_PARKING_STATUS_PF pfnParkStatusCBFun, IntPtr lpUserData);
        #region // 显示实现
        void IItsNetDevSdkProxy.MemCopy(byte[] dest, IntPtr src, int count) => MemCopy(dest, src, count);
        void IItsNetDevSdkProxy.OutputDebugString(string message) => OutputDebugString(message);
        int IItsNetDevSdkProxy.NETDEV_ACSPersonCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo) => NETDEV_ACSPersonCtrl(lpUserID, dwCommand, ref pstACSPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref uint pUdwBlackListID) => NETDEV_AddACSPersonBlackList(lpUserID, ref pstBlackListInfo, ref pUdwBlackListID);
        int IItsNetDevSdkProxy.NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList) => NETDEV_AddACSPersonList(lpUserID, ref pstACSPersonList, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref uint pUdwGroupID) => NETDEV_AddACSPersonPermissionGroup(lpUserID, ref pstPermissionGroupInfo, ref pUdwGroupID);
        int IItsNetDevSdkProxy.NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref int pdwOrgID) => NETDEV_AddOrgInfo(lpUserID, ref pstOrgInfo, ref pdwOrgID);
        int IItsNetDevSdkProxy.NETDEV_AddPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => NETDEV_AddPersonInfo(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int IItsNetDevSdkProxy.NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo) => NETDEV_AddPersonMonitorInfo(lpUserID, ref pstMonitorInfo, ref pstMonitorResultInfo);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => NETDEV_AddVehicleLibInfo(lpUserID, ref pstVehicleLibInfo);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => NETDEV_AddVehicleLibMember(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleMemberList(IntPtr lpUserID, uint udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => NETDEV_AddVehicleMemberList(lpUserID, udwLibID, ref pstVehicleMemberList, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_AddVehicleMonitorInfo(lpUserID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_EXTERN_S pstVehicleRecordExtern) => NETDEV_AddVehicleRecord(lpFindHandle, ref pstVehicleRecordExtern);
        int IItsNetDevSdkProxy.NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo) => NETDEV_BatchDeleteOrgInfo(lpUserID, ref pstOrgDelInfo, ref pstOrgDelResultInfo);
        int IItsNetDevSdkProxy.NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => NETDEV_BatchDeletePersonMonitorInfo(lpUserID, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_CaptureNoPreview(IntPtr lpUserID, int dwChannelID, int dwStreamType, string szFileName, int dwCaptureMode) => NETDEV_CaptureNoPreview(lpUserID, dwChannelID, dwStreamType, szFileName, dwCaptureMode);
        int IItsNetDevSdkProxy.NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, int dwCaptureMode) => NETDEV_CapturePicture(lpRealHandle, szFileName, dwCaptureMode);
        int IItsNetDevSdkProxy.NETDEV_Cleanup() => NETDEV_Cleanup();
        int IItsNetDevSdkProxy.NETDEV_CloseMic(IntPtr lpPlayHandle) => NETDEV_CloseMic(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_CloseSound(IntPtr lpRealHandle) => NETDEV_CloseSound(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_ConfigLogFile(int dwLogFileSize, int dwLogFileNum) => NETDEV_ConfigLogFile(dwLogFileSize, dwLogFileNum);
        int IItsNetDevSdkProxy.NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref uint pudwID) => NETDEV_CreatePersonLibInfo(lpUserID, ref pstPersonLibInfo, ref pudwID);
        int IItsNetDevSdkProxy.NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo) => NETDEV_CreateUser(lpUserID, stUserInfo);
        int IItsNetDevSdkProxy.NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList) => NETDEV_DeleteACSPersonBlackList(lpUserID, ref pstBlackList);
        int IItsNetDevSdkProxy.NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo) => NETDEV_DeleteACSPersonList(lpUserID, ref pstBatchCtrlInfo);
        int IItsNetDevSdkProxy.NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => NETDEV_DeleteACSPersonPermissionGroup(lpUserID, ref pstPermissionIDList, ref pstResutList);
        int IItsNetDevSdkProxy.NETDEV_DeleteAllowVehicleRecord(IntPtr lpFindHandle, int ulRecordID) => NETDEV_DeleteAllowVehicleRecord(lpFindHandle, ulRecordID);
        int IItsNetDevSdkProxy.NETDEV_DeleteBlockVehicleRecord(IntPtr lpFindHandle, int ulRecordID) => NETDEV_DeleteBlockVehicleRecord(lpFindHandle, ulRecordID);
        int IItsNetDevSdkProxy.NETDEV_DeletePersonInfo(IntPtr lpUserID, uint udwPersonLibID, uint udwPersonID, uint udwLastChange) => NETDEV_DeletePersonInfo(lpUserID, udwPersonLibID, udwPersonID, udwLastChange);
        int IItsNetDevSdkProxy.NETDEV_DeletePersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => NETDEV_DeletePersonInfoList(lpUserID, udwPersonLibID, ref pstIDList, ref pstResutList);
        int IItsNetDevSdkProxy.NETDEV_DeletePersonLibInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo) => NETDEV_DeletePersonLibInfo(lpUserID, udwPersonLibID, ref pstFlagInfo);
        int IItsNetDevSdkProxy.NETDEV_DeleteUser(IntPtr lpUserID, string strUserName) => NETDEV_DeleteUser(lpUserID, strUserName);
        int IItsNetDevSdkProxy.NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag) => NETDEV_DeleteVehicleLibInfo(lpUserID, udwVehicleLibID, ref pstDelLibFlag);
        int IItsNetDevSdkProxy.NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => NETDEV_DeleteVehicleLibMember(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int IItsNetDevSdkProxy.NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => NETDEV_DeleteVehicleMonitorInfo(lpUserID, ref pstBatchList);
        int IItsNetDevSdkProxy.NETDEV_DelVehicleMemberList(IntPtr lpUserID, uint udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => NETDEV_DelVehicleMemberList(lpUserID, udwLib, ref pstVehicleMemberList, ref pstBatchList);
        int IItsNetDevSdkProxy.NETDEV_Discovery(string pszBeginIP, string pszEndIP) => NETDEV_Discovery(pszBeginIP, pszEndIP);
        int IItsNetDevSdkProxy.NETDEV_DoorBatchCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo) => NETDEV_DoorBatchCtrl(lpUserID, dwCommand, ref pstBatchCtrlInfo);
        int IItsNetDevSdkProxy.NETDEV_DoorCtrl(IntPtr lpUserID, int dwChannelID, int dwCommand) => NETDEV_DoorCtrl(lpUserID, dwChannelID, dwCommand);
        int IItsNetDevSdkProxy.NETDEV_EnableCarplate(int bEnable) => NETDEV_EnableCarplate(bEnable);
        int IItsNetDevSdkProxy.NETDEV_ExportBlackWhiteListFile(IntPtr lpFindHandle, string pcFile) => NETDEV_ExportBlackWhiteListFile(lpFindHandle, pcFile);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSAttendanceLogList(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSPermissionGroupList(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSPersonBlackList(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSPersonList(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSVisitLogList(lpUserID, ref pstFindCond, ref pstResultInfo);
        int IItsNetDevSdkProxy.NETDEV_FindClose(IntPtr lpFindHandle) => NETDEV_FindClose(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle) => NETDEV_FindCloseACSAttendanceLogList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle) => NETDEV_FindCloseACSPermissionGroupList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle) => NETDEV_FindCloseACSPersonBlackList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle) => NETDEV_FindCloseACSPersonInfo(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle) => NETDEV_FindCloseACSVisitLog(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseCloudDevListEx(IntPtr lpFindHandle) => NETDEV_FindCloseCloudDevListEx(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseDevChn(IntPtr lpFindHandle) => NETDEV_FindCloseDevChn(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseDevInfo(IntPtr lpFindHandle) => NETDEV_FindCloseDevInfo(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle) => NETDEV_FindCloseFaceRecordDetail(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseMonitorDevResult(IntPtr lpFindHandle) => NETDEV_FindCloseMonitorDevResult(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle) => NETDEV_FindCloseMonitorStatusList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle) => NETDEV_FindCloseOrgInfo(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePermStatusList(IntPtr lpFindHandle) => NETDEV_FindClosePermStatusList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle) => NETDEV_FindClosePersonInfoList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePersonLibList(IntPtr lpFindHandle) => NETDEV_FindClosePersonLibList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle) => NETDEV_FindClosePersonMonitorList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleLibList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleMemberDetail(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleMonitorList(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleRecordList(lpFindHandle);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindCloudDevListEx(IntPtr lpUserID) => NETDEV_FindCloudDevListEx(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindDevChnList(IntPtr lpUserID, int dwDevID, int dwChnType) => NETDEV_FindDevChnList(lpUserID, dwDevID, dwChnType);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindDevList(IntPtr lpUserID, int dwDevType) => NETDEV_FindDevList(lpUserID, dwDevType);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => NETDEV_FindFaceRecordDetailList(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond) => NETDEV_FindFile(lpUserID, ref pFindCond);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindMonitorDevResult(IntPtr lpUserID, ref uint pudwDevNum) => NETDEV_FindMonitorDevResult(lpUserID, ref pudwDevNum);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindMonitorStatusList(IntPtr lpUserID, int enType, ref uint udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList) => NETDEV_FindMonitorStatusList(lpUserID, enType, ref udwMonitorID, ref pstFindLimit, ref pstList);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo) => NETDEV_FindNextACSAttendanceLog(lpFindHandle, ref pstACSLogInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo) => NETDEV_FindNextACSPermissionGroupInfo(lpFindHandle, ref pstACSPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => NETDEV_FindNextACSPersonBlackListInfo(lpFindHandle, ref pstBlackListInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo) => NETDEV_FindNextACSPersonInfo(lpFindHandle, ref pstACSPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo) => NETDEV_FindNextACSVisitLog(lpFindHandle, ref pstACSLogInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextCloudDevInfoEx(IntPtr lpFindHandle, ref NETDEV_CLOUD_DEV_BASIC_INFO_S pstDevInfo) => NETDEV_FindNextCloudDevInfoEx(lpFindHandle, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_FindNextDevChn(lpFindHandle, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo) => NETDEV_FindNextDevInfo(lpFindHandle, ref pstDevBasicInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo) => NETDEV_FindNextFaceRecordDetail(lpFindHandle, ref pstRecordInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData) => NETDEV_FindNextFile(lpFindHandle, ref lpFindData);
        int IItsNetDevSdkProxy.NETDEV_FindNextMonitorDevResult(IntPtr lpFindHandle, ref NETDEV_MONITOR_DEV_RESULT_INFO_S pstMonitorDevResultInfo) => NETDEV_FindNextMonitorDevResult(lpFindHandle, ref pstMonitorDevResultInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats) => NETDEV_FindNextMonitorStatusInfo(lpFindHandle, ref pstMonitorStats);
        int IItsNetDevSdkProxy.NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo) => NETDEV_FindNextOrgInfo(lpFindHandle, ref pstOrgInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus) => NETDEV_FindNextPermStatusInfo(lpFindHandle, ref pstACSPermStatus);
        int IItsNetDevSdkProxy.NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo) => NETDEV_FindNextPersonInfo(lpFindHandle, ref pstPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo) => NETDEV_FindNextPersonLibInfo(lpFindHandle, ref pstPersonLibInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_FindNextPersonMonitorInfo(lpFindHandle, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => NETDEV_FindNextVehicleLibInfo(lpFindHandle, ref pstVehicleLibInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo) => NETDEV_FindNextVehicleMemberDetail(lpFindHandle, ref pstVehicleMemberInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo) => NETDEV_FindNextVehicleMonitorInfo(lpFindHandle, ref pstVehicleMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo) => NETDEV_FindNextVehicleRecordInfo(lpFindHandle, ref pstRecordInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond) => NETDEV_FindOrgInfoList(lpUserID, ref pstFindCond);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPermStatusList(IntPtr lpUserID, ref uint udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindPermStatusList(lpUserID, ref udwPermGroupID, ref pstQueryInfo, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo) => NETDEV_FindPersonInfoList(lpUserID, udwPersonLibID, ref pstQueryInfo, ref pstQueryResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPersonLibList(IntPtr lpUserID) => NETDEV_FindPersonLibList(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPersonMonitorList(IntPtr lpUserID, uint udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo) => NETDEV_FindPersonMonitorList(lpUserID, udwChannelID, ref pstQueryInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleLibList(IntPtr lpUserID) => NETDEV_FindVehicleLibList(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList) => NETDEV_FindVehicleMemberDetailList(lpUserID, udwVehicleLibID, ref pstFindCond, ref pstDBMemberList);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleMonitorList(IntPtr lpUserID) => NETDEV_FindVehicleMonitorList(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => NETDEV_FindVehicleRecordInfoList(lpUserID, ref pstFindCond, ref pstResultInfo);
        int IItsNetDevSdkProxy.NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => NETDEV_GetACSPersonBlackList(lpUserID, ref pstBlackListInfo);
        int IItsNetDevSdkProxy.NETDEV_GetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => NETDEV_GetACSPersonPermission(lpUserID, udwPersonID, ref pstPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate) => NETDEV_GetBitRate(lpRealHandle, ref pdwBitRate);
        int IItsNetDevSdkProxy.NETDEV_GetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled) => NETDEV_GetBuiltinIndicatorCtrl(lpFindHandle, ref pstuCarportControlled);
        int IItsNetDevSdkProxy.NETDEV_GetChnDetailByChnType(IntPtr lpUserID, int dwChnID, int dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetChnDetailByChnType(lpUserID, dwChnID, dwChnType, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetChnType(IntPtr lpUserID, int dwChnID, ref int pdwChnType) => NETDEV_GetChnType(lpUserID, dwChnID, ref pdwChnType);
        int IItsNetDevSdkProxy.NETDEV_GetCloudDevInfoByName(IntPtr lpUserID, string pszRegisterCode, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo) => NETDEV_GetCloudDevInfoByName(lpUserID, pszRegisterCode, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetCloudDevInfoByRegCode(IntPtr lpUserID, string pszRegisterName, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo) => NETDEV_GetCloudDevInfoByRegCode(lpUserID, pszRegisterName, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetCompassInfo(IntPtr lpUserID, int dwChannelID, ref float fCompassInfo) => NETDEV_GetCompassInfo(lpUserID, dwChannelID, ref fCompassInfo);
        int IItsNetDevSdkProxy.NETDEV_GetConfigFile(IntPtr lpUserID, string strConfigPath) => NETDEV_GetConfigFile(lpUserID, strConfigPath);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PTZ_STATUS_S lpInBuffer, int dwInBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ITS_PARKING_DETECTION_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceCapability(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDeviceCapability(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceCapability(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDeviceCapability(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo) => NETDEV_GetDeviceInfo(lpUserID, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, int dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo) => NETDEV_GetDeviceInfo_V30(lpUserID, dwDevID, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, uint udwRecordID, uint udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo) => NETDEV_GetFaceRecordImageInfo(lpUserID, udwRecordID, udwFaceImageType, ref pstFileInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, string szSaveFileName, int dwFormat) => NETDEV_GetFileByName(lpUserID, ref pstPlayBackInfo, szSaveFileName, dwFormat);
        IntPtr IItsNetDevSdkProxy.NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, int dwFormat) => NETDEV_GetFileByTime(lpUserID, ref pstPlayBackCond, pszSaveFileName, dwFormat);
        int IItsNetDevSdkProxy.NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate) => NETDEV_GetFrameRate(lpRealHandle, ref pdwFrameRate);
        int IItsNetDevSdkProxy.NETDEV_GetGeolocationInfo(IntPtr lpUserID, int dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo) => NETDEV_GetGeolocationInfo(lpUserID, dwChannelID, ref pstGPSInfo);
        int IItsNetDevSdkProxy.NETDEV_GetLastError() => NETDEV_GetLastError();
        int IItsNetDevSdkProxy.NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum) => NETDEV_GetLostPacketRate(lpRealHandle, ref pulRecvPktNum, ref pulLostPktNum);
        int IItsNetDevSdkProxy.NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref int dwVolume) => NETDEV_GetMicVolume(lpPlayHandle, ref dwVolume);
        int IItsNetDevSdkProxy.NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList) => NETDEV_GetMonitorCapacity(lpUserID, ref pstCapacityInfo, ref pstCapacityList);
        int IItsNetDevSdkProxy.NETDEV_GetMonitorProgress(IntPtr lpUserID, ref uint pudwProgressRate) => NETDEV_GetMonitorProgress(lpUserID, ref pudwProgressRate);
        int IItsNetDevSdkProxy.NETDEV_GetPARKVersion(byte[] strVersion) => NETDEV_GetPARKVersion(strVersion);
        int IItsNetDevSdkProxy.NETDEV_GetPersonLibCapacity(IntPtr lpUserID, int dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList) => NETDEV_GetPersonLibCapacity(lpUserID, dwTimeOut, ref pstCapacityList);
        int IItsNetDevSdkProxy.NETDEV_GetPersonMemberInfo(IntPtr lpUserID, uint udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo) => NETDEV_GetPersonMemberInfo(lpUserID, udwPersonID, ref pstPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_GetPersonMonitorRuleInfo(lpUserID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_GetPTZPresetList(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer) => NETDEV_GetPTZPresetList(lpUserID, dwChannelID, ref lpOutBuffer);
        int IItsNetDevSdkProxy.NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight) => NETDEV_GetResolution(lpRealHandle, ref pdwWidth, ref pdwHeight);
        int IItsNetDevSdkProxy.NETDEV_GetSDKVersion() => NETDEV_GetSDKVersion();
        int IItsNetDevSdkProxy.NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, uint udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo) => NETDEV_GetSinglePermGroupInfo(lpUserID, udwPermissionGroupID, ref pstAcsPerssionInfo);
        int IItsNetDevSdkProxy.NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref int pdwVolume) => NETDEV_GetSoundVolume(lpPlayHandle, ref pdwVolume);
        int IItsNetDevSdkProxy.NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, uint udwSize, IntPtr pszdata) => NETDEV_GetSystemPicture(lpUserID, pszURL, udwSize, pszdata);
        int IItsNetDevSdkProxy.NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => NETDEV_GetSystemTimeCfg(lpUserID, ref pstSystemTimeInfo);
        int IItsNetDevSdkProxy.NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, int dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo) => NETDEV_GetTimeTemplateInfo(lpUserID, dwTemplateID, ref pstTimeTemplateInfo);
        int IItsNetDevSdkProxy.NETDEV_GetTimeTemplateList(IntPtr lpUserID, int dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList) => NETDEV_GetTimeTemplateList(lpUserID, dwTamplateType, ref pstTemplateList);
        int IItsNetDevSdkProxy.NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic) => NETDEV_GetTrafficStatistic(lpUserID, ref pstStatisticCond, ref pstTrafficStatistic);
        int IItsNetDevSdkProxy.NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => NETDEV_GetUpnpNatState(lpUserID, ref pstNatState);
        int IItsNetDevSdkProxy.NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList) => NETDEV_GetUserDetailList(lpUserID, pstUserDetailList);
        int IItsNetDevSdkProxy.NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => NETDEV_GetVehicleMonitorInfo(lpUserID, udwID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, uint udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo) => NETDEV_GetVehicleRecordImageInfo(lpUserID, udwRecordID, ref pstFileInfo);
        int IItsNetDevSdkProxy.NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => NETDEV_GetVideoEffect(lpRealHandle, ref pstImageInfo);
        int IItsNetDevSdkProxy.NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt) => NETDEV_GetVideoEncodeFmt(lpRealHandle, ref pdwVideoEncFmt);
        int IItsNetDevSdkProxy.NETDEV_ImportBlackWhiteListFile(IntPtr lpFindHandle, string pcFile) => NETDEV_ImportBlackWhiteListFile(lpFindHandle, pcFile);
        int IItsNetDevSdkProxy.NETDEV_Init() => NETDEV_Init();
        int IItsNetDevSdkProxy.NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, int dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam) => NETDEV_InputVoiceData(lpUserID, lpDataBuf, dwDataLen, ref pstVoiceParam);
        IntPtr IItsNetDevSdkProxy.NETDEV_Login(string szDevIP, short wDevPort, string szUserName, string szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo) => NETDEV_Login(szDevIP, wDevPort, szUserName, szPassword, ref pstDevInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_LoginCloud(string pszCloudSrvUrl, string pszUserName, string pszPassWord) => NETDEV_LoginCloud(pszCloudSrvUrl, pszUserName, pszPassWord);
        IntPtr IItsNetDevSdkProxy.NETDEV_LoginCloudDevice_V30(IntPtr lpUserID, ref NETDEV_CLOUD_DEV_LOGIN_INFO_S pstCloudInfo) => NETDEV_LoginCloudDevice_V30(lpUserID, ref pstCloudInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo) => NETDEV_Login_V30(ref pstDevLoginInfo, ref pstSELogInfo);
        int IItsNetDevSdkProxy.NETDEV_Logout(IntPtr lpUserID) => NETDEV_Logout(lpUserID);
        int IItsNetDevSdkProxy.NETDEV_MakeKeyFrame(IntPtr lpUserID, int dwChannelID, int dwStreamType) => NETDEV_MakeKeyFrame(lpUserID, dwChannelID, dwStreamType);
        int IItsNetDevSdkProxy.NETDEV_MicVolumeControl(IntPtr lpPlayHandle, int dwVolume) => NETDEV_MicVolumeControl(lpPlayHandle, dwVolume);
        int IItsNetDevSdkProxy.NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => NETDEV_ModifyACSPersonBlackList(lpUserID, ref pstBlackListInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo) => NETDEV_ModifyACSPersonPermissionGroup(lpUserID, ref pstPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyAllowVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern) => NETDEV_ModifyAllowVehicleRecord(lpFindHandle, ref pstVehicleRecordExtern);
        int IItsNetDevSdkProxy.NETDEV_ModifyBlockVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern) => NETDEV_ModifyBlockVehicleRecord(lpFindHandle, ref pstVehicleRecordExtern);
        int IItsNetDevSdkProxy.NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName) => NETDEV_ModifyDeviceName(lpUserID, strDeviceName);
        int IItsNetDevSdkProxy.NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo) => NETDEV_ModifyOrgInfo(lpUserID, ref pstOrgInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => NETDEV_ModifyPersonInfo(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int IItsNetDevSdkProxy.NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList) => NETDEV_ModifyPersonLibInfo(lpUserID, ref pstPersonLibList);
        int IItsNetDevSdkProxy.NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo) => NETDEV_ModifyUser(lpUserID, pstUserInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList) => NETDEV_ModifyVehicleLibInfo(lpUserID, ref pstVehicleLibList);
        int IItsNetDevSdkProxy.NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => NETDEV_ModifyVehicleMemberInfo(lpUserID, udwVehicleLibID, ref pstVehicleMemberList, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_OpenMic(IntPtr lpPlayHandle) => NETDEV_OpenMic(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_OpenSound(IntPtr lpRealHandle) => NETDEV_OpenSound(lpRealHandle);
        IntPtr IItsNetDevSdkProxy.NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo) => NETDEV_PlayBackByName(lpUserID, ref pstPlayBackInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo) => NETDEV_PlayBackByTime(lpUserID, ref pstPlayBackInfo);
        int IItsNetDevSdkProxy.NETDEV_PlayBackControl(IntPtr lpPlayHandle, int dwControlCode, ref long pdwBuffer) => NETDEV_PlayBackControl(lpPlayHandle, dwControlCode, ref pdwBuffer);
        int IItsNetDevSdkProxy.NETDEV_PlaySound(IntPtr lpRealHandle) => NETDEV_PlaySound(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_PTZCalibrate(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo) => NETDEV_PTZCalibrate(lpUserID, dwChannelID, ref pstOrientationInfo);
        int IItsNetDevSdkProxy.NETDEV_PTZControl(IntPtr lpPlayHandle, int dwPTZCommand, int dwSpeed) => NETDEV_PTZControl(lpPlayHandle, dwPTZCommand, dwSpeed);
        int IItsNetDevSdkProxy.NETDEV_PTZControl_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCommand, int dwSpeed) => NETDEV_PTZControl_Other(lpUserID, dwChannelID, dwPTZCommand, dwSpeed);
        int IItsNetDevSdkProxy.NETDEV_PTZCruise_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo) => NETDEV_PTZCruise_Other(lpUserID, dwChannelID, dwPTZCruiseCmd, ref pstCruiseInfo);
        int IItsNetDevSdkProxy.NETDEV_PTZGetCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList) => NETDEV_PTZGetCruise(lpUserID, dwChannelID, ref pstCruiseList);
        int IItsNetDevSdkProxy.NETDEV_PTZGetTrackCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo) => NETDEV_PTZGetTrackCruise(lpUserID, dwChannelID, ref pstTrackCruiseInfo);
        int IItsNetDevSdkProxy.NETDEV_PTZPreset(IntPtr lpPlayHandle, int dwPTZPresetCmd, string pszPresetName, int dwPresetID) => NETDEV_PTZPreset(lpPlayHandle, dwPTZPresetCmd, pszPresetName, dwPresetID);
        int IItsNetDevSdkProxy.NETDEV_PTZPreset_Other(IntPtr lpUserID, int dwChannelID, int dwPTZPresetCmd, byte[] szPresetName, int dwPresetID) => NETDEV_PTZPreset_Other(lpUserID, dwChannelID, dwPTZPresetCmd, szPresetName, dwPresetID);
        int IItsNetDevSdkProxy.NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea) => NETDEV_PTZSelZoomIn_Other(lpUserID, dwChannelID, ref pstPtzOperateArea);
        int IItsNetDevSdkProxy.NETDEV_PTZTrackCruise(IntPtr lpUserID, int dwChannelID, int dwPTZTrackCruiseCmd, string pszTrackCruiseName) => NETDEV_PTZTrackCruise(lpUserID, dwChannelID, dwPTZTrackCruiseCmd, pszTrackCruiseName);
        int IItsNetDevSdkProxy.NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList) => NETDEV_QueryVideoChlDetailList(lpUserID, ref pdwChlCount, pstVideoChlList);
        IntPtr IItsNetDevSdkProxy.NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => NETDEV_RealPlay(lpUserID, ref pstPreviewInfo, cbPlayDataCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_Reboot(IntPtr lpUserID) => NETDEV_Reboot(lpUserID);
        int IItsNetDevSdkProxy.NETDEV_ResetLostPacketRate(IntPtr lpRealHandle) => NETDEV_ResetLostPacketRate(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_RestoreConfig(IntPtr lpUserID) => NETDEV_RestoreConfig(lpUserID);
        int IItsNetDevSdkProxy.NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, int dwFormat) => NETDEV_SaveRealData(lpRealHandle, szSaveFileName, dwFormat);
        int IItsNetDevSdkProxy.NETDEV_SetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => NETDEV_SetACSPersonPermission(lpUserID, udwPersonID, ref pstPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetAlarmCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetAlarmCallBack_V30(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetAlarmFGCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled) => NETDEV_SetBuiltinIndicatorCtrl(lpFindHandle, ref pstuCarportControlled);
        int IItsNetDevSdkProxy.NETDEV_SetConfigFile(IntPtr lpUserID, string strConfigPath) => NETDEV_SetConfigFile(lpUserID, strConfigPath);
        int IItsNetDevSdkProxy.NETDEV_SetConnectTime(int dwWaitTime, int dwTrytimes) => NETDEV_SetConnectTime(dwWaitTime, dwTrytimes);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref int index, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref index, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, lpInBuffer, ref dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_setDeviceLedCfg(IntPtr lpFindHandle, ref NETDEV_LED_LIST_CFG_S pstLedListCfgs) => NETDEV_setDeviceLedCfg(lpFindHandle, ref pstLedListCfgs);
        int IItsNetDevSdkProxy.NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect) => NETDEV_SetDigitalZoom(lpRealHandle, hWnd, pstRect);
        int IItsNetDevSdkProxy.NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData) => NETDEV_SetDiscoveryCallBack(cbDiscoveryCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData) => NETDEV_SetExceptionCallBack(cbExceptionCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData) => NETDEV_SetFaceSnapshotCallBack(lpUserID, cbFaceSnapshotCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetIVAEnable(IntPtr lpUserID, int dwEnableIVA) => NETDEV_SetIVAEnable(lpUserID, dwEnableIVA);
        int IItsNetDevSdkProxy.NETDEV_SetIVAShowParam(int dwShowParam) => NETDEV_SetIVAShowParam(dwShowParam);
        int IItsNetDevSdkProxy.NETDEV_SetLogPath(string strLogPath) => NETDEV_SetLogPath(strLogPath);
        int IItsNetDevSdkProxy.NETDEV_SetOutputSwitchStatusCfg(IntPtr lpFindHandle) => NETDEV_SetOutputSwitchStatusCfg(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_SetParkingStatusCB(IntPtr lpFindHandle, NETDEV_PARKING_STATUS_PF pfnParkStatusCBFun, IntPtr lpUserData) => NETDEV_SetParkingStatusCB(lpFindHandle, pfnParkStatusCBFun, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetParkStatusCallBack(IntPtr lpUserID, NETDEV_ParkStatusReportCallBack_PF cbParkStatusReportCallBack, IntPtr lpUserData) => NETDEV_SetParkStatusCallBack(lpUserID, cbParkStatusReportCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData) => NETDEV_SetPassengerFlowStatisticCallBack(lpUserID, cbPassengerFlowStatisticCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetPersonAlarmCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_SetPersonMonitorRuleInfo(lpUserID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_SetPictureFluency(IntPtr lpPlayHandle, int dwFluency) => NETDEV_SetPictureFluency(lpPlayHandle, dwFluency);
        int IItsNetDevSdkProxy.NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, int bContinue, IntPtr lpUserData) => NETDEV_SetPlayDataCallBack(lpRealHandle, cbPlayDataCallBack, bContinue, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, ref NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, int bContinue, IntPtr lpUserData) => NETDEV_SetPlayDecodeVideoCB(lpRealHandle, ref cbPlayDecodeVideoCallBack, bContinue, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData) => NETDEV_SetPlayDisplayCB(lpRealHandle, cbPlayDisplayCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPlayParseCB(IntPtr lpRealHandle, ref NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF cbPlayParseCallBack, int bContinue, IntPtr lpUserData) => NETDEV_SetPlayParseCB(lpRealHandle, ref cbPlayParseCallBack, bContinue, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetRenderScale(IntPtr lpRealHandle, int enRenderScale) => NETDEV_SetRenderScale(lpRealHandle, enRenderScale);
        int IItsNetDevSdkProxy.NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout) => NETDEV_SetRevTimeOut(ref pstRevTimeout);
        int IItsNetDevSdkProxy.NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetStructAlarmCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => NETDEV_SetSystemTimeCfg(lpUserID, ref pstSystemTimeInfo);
        int IItsNetDevSdkProxy.NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => NETDEV_SetUpnpNatState(lpUserID, ref pstNatState);
        int IItsNetDevSdkProxy.NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetVehicleAlarmCallBack(lpUserID, cbVehicleAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => NETDEV_SetVehicleMonitorInfo(lpUserID, udwID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => NETDEV_SetVideoEffect(lpRealHandle, ref pstImageInfo);
        int IItsNetDevSdkProxy.NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, int dwVolume) => NETDEV_SoundVolumeControl(lpPlayHandle, dwVolume);
        IntPtr IItsNetDevSdkProxy.NETDEV_StartInputVoiceSrv(IntPtr lpUserID, int dwChannelID) => NETDEV_StartInputVoiceSrv(lpUserID, dwChannelID);
        IntPtr IItsNetDevSdkProxy.NETDEV_StartPicStream(IntPtr lpUserID, IntPtr hPlayWnd, bool bReTran, string pcReTranIP, NETDEV_PIC_UPLOAD_PF pfnPicDataCBFun, IntPtr lpUserData) => NETDEV_StartPicStream(lpUserID, hPlayWnd, bReTran, pcReTranIP, pfnPicDataCBFun, lpUserData);
        IntPtr IItsNetDevSdkProxy.NETDEV_StartVoiceCom(IntPtr lpUserID, int dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => NETDEV_StartVoiceCom(lpUserID, dwChannelID, cbPlayDataCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_StopGetFile(IntPtr lpPlayHandle) => NETDEV_StopGetFile(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle) => NETDEV_StopInputVoiceSrv(lpVoiceComHandle);
        int IItsNetDevSdkProxy.NETDEV_StopPicStream(IntPtr lpPlayHandle) => NETDEV_StopPicStream(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_StopPlayBack(IntPtr lpPlayHandle) => NETDEV_StopPlayBack(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_StopPlaySound(IntPtr lpRealHandle) => NETDEV_StopPlaySound(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_StopRealPlay(IntPtr lpRealHandle) => NETDEV_StopRealPlay(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_StopSaveRealData(IntPtr lpRealHandle) => NETDEV_StopSaveRealData(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle) => NETDEV_StopVoiceCom(lpVoiceComHandle);
        int IItsNetDevSdkProxy.NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo) => NETDEV_SubscibeLapiAlarm(lpUserID, ref pstSubInfo, ref pstSubSuccInfo);
        int IItsNetDevSdkProxy.NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo) => NETDEV_SubscribeSmart(lpUserID, ref pstSubscribeInfo, ref pstSmartInfo);
        int IItsNetDevSdkProxy.NETDEV_Trigger(IntPtr lpFindHandle) => NETDEV_Trigger(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_TriggerSync(IntPtr lpFindHandle, ref IntPtr ppstPicData) => NETDEV_TriggerSync(lpFindHandle, ref ppstPicData);
        int IItsNetDevSdkProxy.NETDEV_UnSubLapiAlarm(IntPtr lpUserID, uint udwID) => NETDEV_UnSubLapiAlarm(lpUserID, udwID);
        int IItsNetDevSdkProxy.NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo) => NETDEV_UnsubscribeSmart(lpUserID, ref pstSmartInfo);
        #endregion 显示实现
    }
    internal class ItsNetDevSdkLoader : ASdkDynamicLoader, IItsNetDevSdkProxy
    {
        #region // 委托定义
        private DCreater.MemCopy _MemCopy;
        private DCreater.NETDEV_ACSPersonCtrl _NETDEV_ACSPersonCtrl;
        private DCreater.NETDEV_AddACSPersonBlackList _NETDEV_AddACSPersonBlackList;
        private DCreater.NETDEV_AddACSPersonList _NETDEV_AddACSPersonList;
        private DCreater.NETDEV_AddACSPersonPermissionGroup _NETDEV_AddACSPersonPermissionGroup;
        private DCreater.NETDEV_AddOrgInfo _NETDEV_AddOrgInfo;
        private DCreater.NETDEV_AddPersonInfo _NETDEV_AddPersonInfo;
        private DCreater.NETDEV_AddPersonMonitorInfo _NETDEV_AddPersonMonitorInfo;
        private DCreater.NETDEV_AddVehicleLibInfo _NETDEV_AddVehicleLibInfo;
        private DCreater.NETDEV_AddVehicleLibMember _NETDEV_AddVehicleLibMember;
        private DCreater.NETDEV_AddVehicleMemberList _NETDEV_AddVehicleMemberList;
        private DCreater.NETDEV_AddVehicleMonitorInfo _NETDEV_AddVehicleMonitorInfo;
        private DCreater.NETDEV_AddVehicleRecord _NETDEV_AddVehicleRecord;
        private DCreater.NETDEV_BatchDeleteOrgInfo _NETDEV_BatchDeleteOrgInfo;
        private DCreater.NETDEV_BatchDeletePersonMonitorInfo _NETDEV_BatchDeletePersonMonitorInfo;
        private DCreater.NETDEV_CaptureNoPreview _NETDEV_CaptureNoPreview;
        private DCreater.NETDEV_CapturePicture _NETDEV_CapturePicture;
        private DCreater.NETDEV_Cleanup _NETDEV_Cleanup;
        private DCreater.NETDEV_CloseMic _NETDEV_CloseMic;
        private DCreater.NETDEV_CloseSound _NETDEV_CloseSound;
        private DCreater.NETDEV_ConfigLogFile _NETDEV_ConfigLogFile;
        private DCreater.NETDEV_CreatePersonLibInfo _NETDEV_CreatePersonLibInfo;
        private DCreater.NETDEV_CreateUser _NETDEV_CreateUser;
        private DCreater.NETDEV_DeleteACSPersonBlackList _NETDEV_DeleteACSPersonBlackList;
        private DCreater.NETDEV_DeleteACSPersonList _NETDEV_DeleteACSPersonList;
        private DCreater.NETDEV_DeleteACSPersonPermissionGroup _NETDEV_DeleteACSPersonPermissionGroup;
        private DCreater.NETDEV_DeleteAllowVehicleRecord _NETDEV_DeleteAllowVehicleRecord;
        private DCreater.NETDEV_DeleteBlockVehicleRecord _NETDEV_DeleteBlockVehicleRecord;
        private DCreater.NETDEV_DeletePersonInfo _NETDEV_DeletePersonInfo;
        private DCreater.NETDEV_DeletePersonInfoList _NETDEV_DeletePersonInfoList;
        private DCreater.NETDEV_DeletePersonLibInfo _NETDEV_DeletePersonLibInfo;
        private DCreater.NETDEV_DeleteUser _NETDEV_DeleteUser;
        private DCreater.NETDEV_DeleteVehicleLibInfo _NETDEV_DeleteVehicleLibInfo;
        private DCreater.NETDEV_DeleteVehicleLibMember _NETDEV_DeleteVehicleLibMember;
        private DCreater.NETDEV_DeleteVehicleMonitorInfo _NETDEV_DeleteVehicleMonitorInfo;
        private DCreater.NETDEV_DelVehicleMemberList _NETDEV_DelVehicleMemberList;
        private DCreater.NETDEV_Discovery _NETDEV_Discovery;
        private DCreater.NETDEV_DoorBatchCtrl _NETDEV_DoorBatchCtrl;
        private DCreater.NETDEV_DoorCtrl _NETDEV_DoorCtrl;
        private DCreater.NETDEV_EnableCarplate _NETDEV_EnableCarplate;
        private DCreater.NETDEV_ExportBlackWhiteListFile _NETDEV_ExportBlackWhiteListFile;
        private DCreater.NETDEV_FindACSAttendanceLogList _NETDEV_FindACSAttendanceLogList;
        private DCreater.NETDEV_FindACSPermissionGroupList _NETDEV_FindACSPermissionGroupList;
        private DCreater.NETDEV_FindACSPersonBlackList _NETDEV_FindACSPersonBlackList;
        private DCreater.NETDEV_FindACSPersonList _NETDEV_FindACSPersonList;
        private DCreater.NETDEV_FindACSVisitLogList _NETDEV_FindACSVisitLogList;
        private DCreater.NETDEV_FindClose _NETDEV_FindClose;
        private DCreater.NETDEV_FindCloseACSAttendanceLogList _NETDEV_FindCloseACSAttendanceLogList;
        private DCreater.NETDEV_FindCloseACSPermissionGroupList _NETDEV_FindCloseACSPermissionGroupList;
        private DCreater.NETDEV_FindCloseACSPersonBlackList _NETDEV_FindCloseACSPersonBlackList;
        private DCreater.NETDEV_FindCloseACSPersonInfo _NETDEV_FindCloseACSPersonInfo;
        private DCreater.NETDEV_FindCloseACSVisitLog _NETDEV_FindCloseACSVisitLog;
        private DCreater.NETDEV_FindCloseCloudDevListEx _NETDEV_FindCloseCloudDevListEx;
        private DCreater.NETDEV_FindCloseDevChn _NETDEV_FindCloseDevChn;
        private DCreater.NETDEV_FindCloseDevInfo _NETDEV_FindCloseDevInfo;
        private DCreater.NETDEV_FindCloseFaceRecordDetail _NETDEV_FindCloseFaceRecordDetail;
        private DCreater.NETDEV_FindCloseMonitorDevResult _NETDEV_FindCloseMonitorDevResult;
        private DCreater.NETDEV_FindCloseMonitorStatusList _NETDEV_FindCloseMonitorStatusList;
        private DCreater.NETDEV_FindCloseOrgInfo _NETDEV_FindCloseOrgInfo;
        private DCreater.NETDEV_FindClosePermStatusList _NETDEV_FindClosePermStatusList;
        private DCreater.NETDEV_FindClosePersonInfoList _NETDEV_FindClosePersonInfoList;
        private DCreater.NETDEV_FindClosePersonLibList _NETDEV_FindClosePersonLibList;
        private DCreater.NETDEV_FindClosePersonMonitorList _NETDEV_FindClosePersonMonitorList;
        private DCreater.NETDEV_FindCloseVehicleLibList _NETDEV_FindCloseVehicleLibList;
        private DCreater.NETDEV_FindCloseVehicleMemberDetail _NETDEV_FindCloseVehicleMemberDetail;
        private DCreater.NETDEV_FindCloseVehicleMonitorList _NETDEV_FindCloseVehicleMonitorList;
        private DCreater.NETDEV_FindCloseVehicleRecordList _NETDEV_FindCloseVehicleRecordList;
        private DCreater.NETDEV_FindCloudDevListEx _NETDEV_FindCloudDevListEx;
        private DCreater.NETDEV_FindDevChnList _NETDEV_FindDevChnList;
        private DCreater.NETDEV_FindDevList _NETDEV_FindDevList;
        private DCreater.NETDEV_FindFaceRecordDetailList _NETDEV_FindFaceRecordDetailList;
        private DCreater.NETDEV_FindFile _NETDEV_FindFile;
        private DCreater.NETDEV_FindMonitorDevResult _NETDEV_FindMonitorDevResult;
        private DCreater.NETDEV_FindMonitorStatusList _NETDEV_FindMonitorStatusList;
        private DCreater.NETDEV_FindNextACSAttendanceLog _NETDEV_FindNextACSAttendanceLog;
        private DCreater.NETDEV_FindNextACSPermissionGroupInfo _NETDEV_FindNextACSPermissionGroupInfo;
        private DCreater.NETDEV_FindNextACSPersonBlackListInfo _NETDEV_FindNextACSPersonBlackListInfo;
        private DCreater.NETDEV_FindNextACSPersonInfo _NETDEV_FindNextACSPersonInfo;
        private DCreater.NETDEV_FindNextACSVisitLog _NETDEV_FindNextACSVisitLog;
        private DCreater.NETDEV_FindNextCloudDevInfoEx _NETDEV_FindNextCloudDevInfoEx;
        private DCreater.NETDEV_FindNextDevChn _NETDEV_FindNextDevChn;
        private DCreater.NETDEV_FindNextDevInfo _NETDEV_FindNextDevInfo;
        private DCreater.NETDEV_FindNextFaceRecordDetail _NETDEV_FindNextFaceRecordDetail;
        private DCreater.NETDEV_FindNextFile _NETDEV_FindNextFile;
        private DCreater.NETDEV_FindNextMonitorDevResult _NETDEV_FindNextMonitorDevResult;
        private DCreater.NETDEV_FindNextMonitorStatusInfo _NETDEV_FindNextMonitorStatusInfo;
        private DCreater.NETDEV_FindNextOrgInfo _NETDEV_FindNextOrgInfo;
        private DCreater.NETDEV_FindNextPermStatusInfo _NETDEV_FindNextPermStatusInfo;
        private DCreater.NETDEV_FindNextPersonInfo _NETDEV_FindNextPersonInfo;
        private DCreater.NETDEV_FindNextPersonLibInfo _NETDEV_FindNextPersonLibInfo;
        private DCreater.NETDEV_FindNextPersonMonitorInfo _NETDEV_FindNextPersonMonitorInfo;
        private DCreater.NETDEV_FindNextVehicleLibInfo _NETDEV_FindNextVehicleLibInfo;
        private DCreater.NETDEV_FindNextVehicleMemberDetail _NETDEV_FindNextVehicleMemberDetail;
        private DCreater.NETDEV_FindNextVehicleMonitorInfo _NETDEV_FindNextVehicleMonitorInfo;
        private DCreater.NETDEV_FindNextVehicleRecordInfo _NETDEV_FindNextVehicleRecordInfo;
        private DCreater.NETDEV_FindOrgInfoList _NETDEV_FindOrgInfoList;
        private DCreater.NETDEV_FindPermStatusList _NETDEV_FindPermStatusList;
        private DCreater.NETDEV_FindPersonInfoList _NETDEV_FindPersonInfoList;
        private DCreater.NETDEV_FindPersonLibList _NETDEV_FindPersonLibList;
        private DCreater.NETDEV_FindPersonMonitorList _NETDEV_FindPersonMonitorList;
        private DCreater.NETDEV_FindVehicleLibList _NETDEV_FindVehicleLibList;
        private DCreater.NETDEV_FindVehicleMemberDetailList _NETDEV_FindVehicleMemberDetailList;
        private DCreater.NETDEV_FindVehicleMonitorList _NETDEV_FindVehicleMonitorList;
        private DCreater.NETDEV_FindVehicleRecordInfoList _NETDEV_FindVehicleRecordInfoList;
        private DCreater.NETDEV_GetACSPersonBlackList _NETDEV_GetACSPersonBlackList;
        private DCreater.NETDEV_GetACSPersonPermission _NETDEV_GetACSPersonPermission;
        private DCreater.NETDEV_GetBitRate _NETDEV_GetBitRate;
        private DCreater.NETDEV_GetBuiltinIndicatorCtrl _NETDEV_GetBuiltinIndicatorCtrl;
        private DCreater.NETDEV_GetChnDetailByChnType _NETDEV_GetChnDetailByChnType;
        private DCreater.NETDEV_GetChnType _NETDEV_GetChnType;
        private DCreater.NETDEV_GetCloudDevInfoByName _NETDEV_GetCloudDevInfoByName;
        private DCreater.NETDEV_GetCloudDevInfoByRegCode _NETDEV_GetCloudDevInfoByRegCode;
        private DCreater.NETDEV_GetCompassInfo _NETDEV_GetCompassInfo;
        private DCreater.NETDEV_GetConfigFile _NETDEV_GetConfigFile;
        private DCreater.NETDEV_GetDevConfig1 _NETDEV_GetDevConfig1;
        private DCreater.NETDEV_GetDevConfig2 _NETDEV_GetDevConfig2;
        private DCreater.NETDEV_GetDevConfig3 _NETDEV_GetDevConfig3;
        private DCreater.NETDEV_GetDevConfig4 _NETDEV_GetDevConfig4;
        private DCreater.NETDEV_GetDevConfig5 _NETDEV_GetDevConfig5;
        private DCreater.NETDEV_GetDevConfig6 _NETDEV_GetDevConfig6;
        private DCreater.NETDEV_GetDevConfig7 _NETDEV_GetDevConfig7;
        private DCreater.NETDEV_GetDevConfig8 _NETDEV_GetDevConfig8;
        private DCreater.NETDEV_GetDevConfig9 _NETDEV_GetDevConfig9;
        private DCreater.NETDEV_GetDevConfigA _NETDEV_GetDevConfigA;
        private DCreater.NETDEV_GetDevConfigB _NETDEV_GetDevConfigB;
        private DCreater.NETDEV_GetDevConfigC _NETDEV_GetDevConfigC;
        private DCreater.NETDEV_GetDevConfigD _NETDEV_GetDevConfigD;
        private DCreater.NETDEV_GetDevConfigE _NETDEV_GetDevConfigE;
        private DCreater.NETDEV_GetDevConfigF _NETDEV_GetDevConfigF;
        private DCreater.NETDEV_GetDevConfigG _NETDEV_GetDevConfigG;
        private DCreater.NETDEV_GetDevConfigH _NETDEV_GetDevConfigH;
        private DCreater.NETDEV_GetDevConfigI _NETDEV_GetDevConfigI;
        private DCreater.NETDEV_GetDevConfigJ _NETDEV_GetDevConfigJ;
        private DCreater.NETDEV_GetDevConfigK _NETDEV_GetDevConfigK;
        private DCreater.NETDEV_GetDevConfigL _NETDEV_GetDevConfigL;
        private DCreater.NETDEV_GetDevConfigM _NETDEV_GetDevConfigM;
        private DCreater.NETDEV_GetDevConfigN _NETDEV_GetDevConfigN;
        private DCreater.NETDEV_GetDevConfigO _NETDEV_GetDevConfigO;
        private DCreater.NETDEV_GetDevConfigP _NETDEV_GetDevConfigP;
        private DCreater.NETDEV_GetDevConfigQ _NETDEV_GetDevConfigQ;
        private DCreater.NETDEV_GetDeviceCapability1 _NETDEV_GetDeviceCapability1;
        private DCreater.NETDEV_GetDeviceCapability2 _NETDEV_GetDeviceCapability2;
        private DCreater.NETDEV_GetDeviceInfo _NETDEV_GetDeviceInfo;
        private DCreater.NETDEV_GetDeviceInfo_V30 _NETDEV_GetDeviceInfo_V30;
        private DCreater.NETDEV_GetFaceRecordImageInfo _NETDEV_GetFaceRecordImageInfo;
        private DCreater.NETDEV_GetFileByName _NETDEV_GetFileByName;
        private DCreater.NETDEV_GetFileByTime _NETDEV_GetFileByTime;
        private DCreater.NETDEV_GetFrameRate _NETDEV_GetFrameRate;
        private DCreater.NETDEV_GetGeolocationInfo _NETDEV_GetGeolocationInfo;
        private DCreater.NETDEV_GetLastError _NETDEV_GetLastError;
        private DCreater.NETDEV_GetLostPacketRate _NETDEV_GetLostPacketRate;
        private DCreater.NETDEV_GetMicVolume _NETDEV_GetMicVolume;
        private DCreater.NETDEV_GetMonitorCapacity _NETDEV_GetMonitorCapacity;
        private DCreater.NETDEV_GetMonitorProgress _NETDEV_GetMonitorProgress;
        private DCreater.NETDEV_GetPARKVersion _NETDEV_GetPARKVersion;
        private DCreater.NETDEV_GetPersonLibCapacity _NETDEV_GetPersonLibCapacity;
        private DCreater.NETDEV_GetPersonMemberInfo _NETDEV_GetPersonMemberInfo;
        private DCreater.NETDEV_GetPersonMonitorRuleInfo _NETDEV_GetPersonMonitorRuleInfo;
        private DCreater.NETDEV_GetPTZPresetList _NETDEV_GetPTZPresetList;
        private DCreater.NETDEV_GetResolution _NETDEV_GetResolution;
        private DCreater.NETDEV_GetSDKVersion _NETDEV_GetSDKVersion;
        private DCreater.NETDEV_GetSinglePermGroupInfo _NETDEV_GetSinglePermGroupInfo;
        private DCreater.NETDEV_GetSoundVolume _NETDEV_GetSoundVolume;
        private DCreater.NETDEV_GetSystemPicture _NETDEV_GetSystemPicture;
        private DCreater.NETDEV_GetSystemTimeCfg _NETDEV_GetSystemTimeCfg;
        private DCreater.NETDEV_GetTimeTemplateInfo _NETDEV_GetTimeTemplateInfo;
        private DCreater.NETDEV_GetTimeTemplateList _NETDEV_GetTimeTemplateList;
        private DCreater.NETDEV_GetTrafficStatistic _NETDEV_GetTrafficStatistic;
        private DCreater.NETDEV_GetUpnpNatState _NETDEV_GetUpnpNatState;
        private DCreater.NETDEV_GetUserDetailList _NETDEV_GetUserDetailList;
        private DCreater.NETDEV_GetVehicleMonitorInfo _NETDEV_GetVehicleMonitorInfo;
        private DCreater.NETDEV_GetVehicleRecordImageInfo _NETDEV_GetVehicleRecordImageInfo;
        private DCreater.NETDEV_GetVideoEffect _NETDEV_GetVideoEffect;
        private DCreater.NETDEV_GetVideoEncodeFmt _NETDEV_GetVideoEncodeFmt;
        private DCreater.NETDEV_ImportBlackWhiteListFile _NETDEV_ImportBlackWhiteListFile;
        private DCreater.NETDEV_Init _NETDEV_Init;
        private DCreater.NETDEV_InputVoiceData _NETDEV_InputVoiceData;
        private DCreater.NETDEV_Login _NETDEV_Login;
        private DCreater.NETDEV_LoginCloud _NETDEV_LoginCloud;
        private DCreater.NETDEV_LoginCloudDevice_V30 _NETDEV_LoginCloudDevice_V30;
        private DCreater.NETDEV_Login_V30 _NETDEV_Login_V30;
        private DCreater.NETDEV_Logout _NETDEV_Logout;
        private DCreater.NETDEV_MakeKeyFrame _NETDEV_MakeKeyFrame;
        private DCreater.NETDEV_MicVolumeControl _NETDEV_MicVolumeControl;
        private DCreater.NETDEV_ModifyACSPersonBlackList _NETDEV_ModifyACSPersonBlackList;
        private DCreater.NETDEV_ModifyACSPersonPermissionGroup _NETDEV_ModifyACSPersonPermissionGroup;
        private DCreater.NETDEV_ModifyAllowVehicleRecord _NETDEV_ModifyAllowVehicleRecord;
        private DCreater.NETDEV_ModifyBlockVehicleRecord _NETDEV_ModifyBlockVehicleRecord;
        private DCreater.NETDEV_ModifyDeviceName _NETDEV_ModifyDeviceName;
        private DCreater.NETDEV_ModifyOrgInfo _NETDEV_ModifyOrgInfo;
        private DCreater.NETDEV_ModifyPersonInfo _NETDEV_ModifyPersonInfo;
        private DCreater.NETDEV_ModifyPersonLibInfo _NETDEV_ModifyPersonLibInfo;
        private DCreater.NETDEV_ModifyUser _NETDEV_ModifyUser;
        private DCreater.NETDEV_ModifyVehicleLibInfo _NETDEV_ModifyVehicleLibInfo;
        private DCreater.NETDEV_ModifyVehicleMemberInfo _NETDEV_ModifyVehicleMemberInfo;
        private DCreater.NETDEV_OpenMic _NETDEV_OpenMic;
        private DCreater.NETDEV_OpenSound _NETDEV_OpenSound;
        private DCreater.NETDEV_PlayBackByName _NETDEV_PlayBackByName;
        private DCreater.NETDEV_PlayBackByTime _NETDEV_PlayBackByTime;
        private DCreater.NETDEV_PlayBackControl _NETDEV_PlayBackControl;
        private DCreater.NETDEV_PlaySound _NETDEV_PlaySound;
        private DCreater.NETDEV_PTZCalibrate _NETDEV_PTZCalibrate;
        private DCreater.NETDEV_PTZControl _NETDEV_PTZControl;
        private DCreater.NETDEV_PTZControl_Other _NETDEV_PTZControl_Other;
        private DCreater.NETDEV_PTZCruise_Other _NETDEV_PTZCruise_Other;
        private DCreater.NETDEV_PTZGetCruise _NETDEV_PTZGetCruise;
        private DCreater.NETDEV_PTZGetTrackCruise _NETDEV_PTZGetTrackCruise;
        private DCreater.NETDEV_PTZPreset _NETDEV_PTZPreset;
        private DCreater.NETDEV_PTZPreset_Other _NETDEV_PTZPreset_Other;
        private DCreater.NETDEV_PTZSelZoomIn_Other _NETDEV_PTZSelZoomIn_Other;
        private DCreater.NETDEV_PTZTrackCruise _NETDEV_PTZTrackCruise;
        private DCreater.NETDEV_QueryVideoChlDetailList _NETDEV_QueryVideoChlDetailList;
        private DCreater.NETDEV_RealPlay _NETDEV_RealPlay;
        private DCreater.NETDEV_Reboot _NETDEV_Reboot;
        private DCreater.NETDEV_ResetLostPacketRate _NETDEV_ResetLostPacketRate;
        private DCreater.NETDEV_RestoreConfig _NETDEV_RestoreConfig;
        private DCreater.NETDEV_SaveRealData _NETDEV_SaveRealData;
        private DCreater.NETDEV_SetACSPersonPermission _NETDEV_SetACSPersonPermission;
        private DCreater.NETDEV_SetAlarmCallBack _NETDEV_SetAlarmCallBack;
        private DCreater.NETDEV_SetAlarmCallBack_V30 _NETDEV_SetAlarmCallBack_V30;
        private DCreater.NETDEV_SetAlarmFGCallBack _NETDEV_SetAlarmFGCallBack;
        private DCreater.NETDEV_SetBuiltinIndicatorCtrl _NETDEV_SetBuiltinIndicatorCtrl;
        private DCreater.NETDEV_SetConfigFile _NETDEV_SetConfigFile;
        private DCreater.NETDEV_SetConnectTime _NETDEV_SetConnectTime;
        private DCreater.NETDEV_SetDevConfig1 _NETDEV_SetDevConfig1;
        private DCreater.NETDEV_SetDevConfig2 _NETDEV_SetDevConfig2;
        private DCreater.NETDEV_SetDevConfig3 _NETDEV_SetDevConfig3;
        private DCreater.NETDEV_SetDevConfig4 _NETDEV_SetDevConfig4;
        private DCreater.NETDEV_SetDevConfig5 _NETDEV_SetDevConfig5;
        private DCreater.NETDEV_SetDevConfig6 _NETDEV_SetDevConfig6;
        private DCreater.NETDEV_SetDevConfig7 _NETDEV_SetDevConfig7;
        private DCreater.NETDEV_SetDevConfig8 _NETDEV_SetDevConfig8;
        private DCreater.NETDEV_SetDevConfig9 _NETDEV_SetDevConfig9;
        private DCreater.NETDEV_SetDevConfigA _NETDEV_SetDevConfigA;
        private DCreater.NETDEV_SetDevConfigB _NETDEV_SetDevConfigB;
        private DCreater.NETDEV_SetDevConfigC _NETDEV_SetDevConfigC;
        private DCreater.NETDEV_SetDevConfigD _NETDEV_SetDevConfigD;
        private DCreater.NETDEV_SetDevConfigE _NETDEV_SetDevConfigE;
        private DCreater.NETDEV_SetDevConfigF _NETDEV_SetDevConfigF;
        private DCreater.NETDEV_SetDevConfigG _NETDEV_SetDevConfigG;
        private DCreater.NETDEV_SetDevConfigH _NETDEV_SetDevConfigH;
        private DCreater.NETDEV_SetDevConfigI _NETDEV_SetDevConfigI;
        private DCreater.NETDEV_SetDevConfigJ _NETDEV_SetDevConfigJ;
        private DCreater.NETDEV_setDeviceLedCfg _NETDEV_setDeviceLedCfg;
        private DCreater.NETDEV_SetDigitalZoom _NETDEV_SetDigitalZoom;
        private DCreater.NETDEV_SetDiscoveryCallBack _NETDEV_SetDiscoveryCallBack;
        private DCreater.NETDEV_SetExceptionCallBack _NETDEV_SetExceptionCallBack;
        private DCreater.NETDEV_SetFaceSnapshotCallBack _NETDEV_SetFaceSnapshotCallBack;
        private DCreater.NETDEV_SetIVAEnable _NETDEV_SetIVAEnable;
        private DCreater.NETDEV_SetIVAShowParam _NETDEV_SetIVAShowParam;
        private DCreater.NETDEV_SetLogPath _NETDEV_SetLogPath;
        private DCreater.NETDEV_SetOutputSwitchStatusCfg _NETDEV_SetOutputSwitchStatusCfg;
        private DCreater.NETDEV_SetParkingStatusCB _NETDEV_SetParkingStatusCB;
        private DCreater.NETDEV_SetParkStatusCallBack _NETDEV_SetParkStatusCallBack;
        private DCreater.NETDEV_SetPassengerFlowStatisticCallBack _NETDEV_SetPassengerFlowStatisticCallBack;
        private DCreater.NETDEV_SetPersonAlarmCallBack _NETDEV_SetPersonAlarmCallBack;
        private DCreater.NETDEV_SetPersonMonitorRuleInfo _NETDEV_SetPersonMonitorRuleInfo;
        private DCreater.NETDEV_SetPictureFluency _NETDEV_SetPictureFluency;
        private DCreater.NETDEV_SetPlayDataCallBack _NETDEV_SetPlayDataCallBack;
        private DCreater.NETDEV_SetPlayDecodeVideoCB _NETDEV_SetPlayDecodeVideoCB;
        private DCreater.NETDEV_SetPlayDisplayCB _NETDEV_SetPlayDisplayCB;
        private DCreater.NETDEV_SetPlayParseCB _NETDEV_SetPlayParseCB;
        private DCreater.NETDEV_SetRenderScale _NETDEV_SetRenderScale;
        private DCreater.NETDEV_SetRevTimeOut _NETDEV_SetRevTimeOut;
        private DCreater.NETDEV_SetStructAlarmCallBack _NETDEV_SetStructAlarmCallBack;
        private DCreater.NETDEV_SetSystemTimeCfg _NETDEV_SetSystemTimeCfg;
        private DCreater.NETDEV_SetUpnpNatState _NETDEV_SetUpnpNatState;
        private DCreater.NETDEV_SetVehicleAlarmCallBack _NETDEV_SetVehicleAlarmCallBack;
        private DCreater.NETDEV_SetVehicleMonitorInfo _NETDEV_SetVehicleMonitorInfo;
        private DCreater.NETDEV_SetVideoEffect _NETDEV_SetVideoEffect;
        private DCreater.NETDEV_SoundVolumeControl _NETDEV_SoundVolumeControl;
        private DCreater.NETDEV_StartInputVoiceSrv _NETDEV_StartInputVoiceSrv;
        private DCreater.NETDEV_StartPicStream _NETDEV_StartPicStream;
        private DCreater.NETDEV_StartVoiceCom _NETDEV_StartVoiceCom;
        private DCreater.NETDEV_StopGetFile _NETDEV_StopGetFile;
        private DCreater.NETDEV_StopInputVoiceSrv _NETDEV_StopInputVoiceSrv;
        private DCreater.NETDEV_StopPicStream _NETDEV_StopPicStream;
        private DCreater.NETDEV_StopPlayBack _NETDEV_StopPlayBack;
        private DCreater.NETDEV_StopPlaySound _NETDEV_StopPlaySound;
        private DCreater.NETDEV_StopRealPlay _NETDEV_StopRealPlay;
        private DCreater.NETDEV_StopSaveRealData _NETDEV_StopSaveRealData;
        private DCreater.NETDEV_StopVoiceCom _NETDEV_StopVoiceCom;
        private DCreater.NETDEV_SubscibeLapiAlarm _NETDEV_SubscibeLapiAlarm;
        private DCreater.NETDEV_SubscribeSmart _NETDEV_SubscribeSmart;
        private DCreater.NETDEV_Trigger _NETDEV_Trigger;
        private DCreater.NETDEV_TriggerSync _NETDEV_TriggerSync;
        private DCreater.NETDEV_UnSubLapiAlarm _NETDEV_UnSubLapiAlarm;
        private DCreater.NETDEV_UnsubscribeSmart _NETDEV_UnsubscribeSmart;
        private DCreater.OutputDebugString _OutputDebugString;
        #endregion 委托定义
        public ItsNetDevSdkLoader()
        {
            _NETDEV_ACSPersonCtrl = GetDelegate<DCreater.NETDEV_ACSPersonCtrl>(nameof(DCreater.NETDEV_ACSPersonCtrl));
            _NETDEV_AddACSPersonBlackList = GetDelegate<DCreater.NETDEV_AddACSPersonBlackList>(nameof(DCreater.NETDEV_AddACSPersonBlackList));
            _NETDEV_AddACSPersonList = GetDelegate<DCreater.NETDEV_AddACSPersonList>(nameof(DCreater.NETDEV_AddACSPersonList));
            _NETDEV_AddACSPersonPermissionGroup = GetDelegate<DCreater.NETDEV_AddACSPersonPermissionGroup>(nameof(DCreater.NETDEV_AddACSPersonPermissionGroup));
            _NETDEV_AddOrgInfo = GetDelegate<DCreater.NETDEV_AddOrgInfo>(nameof(DCreater.NETDEV_AddOrgInfo));
            _NETDEV_AddPersonInfo = GetDelegate<DCreater.NETDEV_AddPersonInfo>(nameof(DCreater.NETDEV_AddPersonInfo));
            _NETDEV_AddPersonMonitorInfo = GetDelegate<DCreater.NETDEV_AddPersonMonitorInfo>(nameof(DCreater.NETDEV_AddPersonMonitorInfo));
            _NETDEV_AddVehicleLibInfo = GetDelegate<DCreater.NETDEV_AddVehicleLibInfo>(nameof(DCreater.NETDEV_AddVehicleLibInfo));
            _NETDEV_AddVehicleLibMember = GetDelegate<DCreater.NETDEV_AddVehicleLibMember>(nameof(DCreater.NETDEV_AddVehicleLibMember));
            _NETDEV_AddVehicleMemberList = GetDelegate<DCreater.NETDEV_AddVehicleMemberList>(nameof(DCreater.NETDEV_AddVehicleMemberList));
            _NETDEV_AddVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_AddVehicleMonitorInfo>(nameof(DCreater.NETDEV_AddVehicleMonitorInfo));
            _NETDEV_AddVehicleRecord = GetDelegate<DCreater.NETDEV_AddVehicleRecord>(nameof(DCreater.NETDEV_AddVehicleRecord));
            _NETDEV_BatchDeleteOrgInfo = GetDelegate<DCreater.NETDEV_BatchDeleteOrgInfo>(nameof(DCreater.NETDEV_BatchDeleteOrgInfo));
            _NETDEV_BatchDeletePersonMonitorInfo = GetDelegate<DCreater.NETDEV_BatchDeletePersonMonitorInfo>(nameof(DCreater.NETDEV_BatchDeletePersonMonitorInfo));
            _NETDEV_CaptureNoPreview = GetDelegate<DCreater.NETDEV_CaptureNoPreview>(nameof(DCreater.NETDEV_CaptureNoPreview));
            _NETDEV_CapturePicture = GetDelegate<DCreater.NETDEV_CapturePicture>(nameof(DCreater.NETDEV_CapturePicture));
            _NETDEV_Cleanup = GetDelegate<DCreater.NETDEV_Cleanup>(nameof(DCreater.NETDEV_Cleanup));
            _NETDEV_CloseMic = GetDelegate<DCreater.NETDEV_CloseMic>(nameof(DCreater.NETDEV_CloseMic));
            _NETDEV_CloseSound = GetDelegate<DCreater.NETDEV_CloseSound>(nameof(DCreater.NETDEV_CloseSound));
            _NETDEV_ConfigLogFile = GetDelegate<DCreater.NETDEV_ConfigLogFile>(nameof(DCreater.NETDEV_ConfigLogFile));
            _NETDEV_CreatePersonLibInfo = GetDelegate<DCreater.NETDEV_CreatePersonLibInfo>(nameof(DCreater.NETDEV_CreatePersonLibInfo));
            _NETDEV_CreateUser = GetDelegate<DCreater.NETDEV_CreateUser>(nameof(DCreater.NETDEV_CreateUser));
            _NETDEV_DeleteACSPersonBlackList = GetDelegate<DCreater.NETDEV_DeleteACSPersonBlackList>(nameof(DCreater.NETDEV_DeleteACSPersonBlackList));
            _NETDEV_DeleteACSPersonList = GetDelegate<DCreater.NETDEV_DeleteACSPersonList>(nameof(DCreater.NETDEV_DeleteACSPersonList));
            _NETDEV_DeleteACSPersonPermissionGroup = GetDelegate<DCreater.NETDEV_DeleteACSPersonPermissionGroup>(nameof(DCreater.NETDEV_DeleteACSPersonPermissionGroup));
            _NETDEV_DeleteAllowVehicleRecord = GetDelegate<DCreater.NETDEV_DeleteAllowVehicleRecord>(nameof(DCreater.NETDEV_DeleteAllowVehicleRecord));
            _NETDEV_DeleteBlockVehicleRecord = GetDelegate<DCreater.NETDEV_DeleteBlockVehicleRecord>(nameof(DCreater.NETDEV_DeleteBlockVehicleRecord));
            _NETDEV_DeletePersonInfo = GetDelegate<DCreater.NETDEV_DeletePersonInfo>(nameof(DCreater.NETDEV_DeletePersonInfo));
            _NETDEV_DeletePersonInfoList = GetDelegate<DCreater.NETDEV_DeletePersonInfoList>(nameof(DCreater.NETDEV_DeletePersonInfoList));
            _NETDEV_DeletePersonLibInfo = GetDelegate<DCreater.NETDEV_DeletePersonLibInfo>(nameof(DCreater.NETDEV_DeletePersonLibInfo));
            _NETDEV_DeleteUser = GetDelegate<DCreater.NETDEV_DeleteUser>(nameof(DCreater.NETDEV_DeleteUser));
            _NETDEV_DeleteVehicleLibInfo = GetDelegate<DCreater.NETDEV_DeleteVehicleLibInfo>(nameof(DCreater.NETDEV_DeleteVehicleLibInfo));
            _NETDEV_DeleteVehicleLibMember = GetDelegate<DCreater.NETDEV_DeleteVehicleLibMember>(nameof(DCreater.NETDEV_DeleteVehicleLibMember));
            _NETDEV_DeleteVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_DeleteVehicleMonitorInfo>(nameof(DCreater.NETDEV_DeleteVehicleMonitorInfo));
            _NETDEV_DelVehicleMemberList = GetDelegate<DCreater.NETDEV_DelVehicleMemberList>(nameof(DCreater.NETDEV_DelVehicleMemberList));
            _NETDEV_Discovery = GetDelegate<DCreater.NETDEV_Discovery>(nameof(DCreater.NETDEV_Discovery));
            _NETDEV_DoorBatchCtrl = GetDelegate<DCreater.NETDEV_DoorBatchCtrl>(nameof(DCreater.NETDEV_DoorBatchCtrl));
            _NETDEV_DoorCtrl = GetDelegate<DCreater.NETDEV_DoorCtrl>(nameof(DCreater.NETDEV_DoorCtrl));
            _NETDEV_EnableCarplate = GetDelegate<DCreater.NETDEV_EnableCarplate>(nameof(DCreater.NETDEV_EnableCarplate));
            _NETDEV_ExportBlackWhiteListFile = GetDelegate<DCreater.NETDEV_ExportBlackWhiteListFile>(nameof(DCreater.NETDEV_ExportBlackWhiteListFile));
            _NETDEV_FindACSAttendanceLogList = GetDelegate<DCreater.NETDEV_FindACSAttendanceLogList>(nameof(DCreater.NETDEV_FindACSAttendanceLogList));
            _NETDEV_FindACSPermissionGroupList = GetDelegate<DCreater.NETDEV_FindACSPermissionGroupList>(nameof(DCreater.NETDEV_FindACSPermissionGroupList));
            _NETDEV_FindACSPersonBlackList = GetDelegate<DCreater.NETDEV_FindACSPersonBlackList>(nameof(DCreater.NETDEV_FindACSPersonBlackList));
            _NETDEV_FindACSPersonList = GetDelegate<DCreater.NETDEV_FindACSPersonList>(nameof(DCreater.NETDEV_FindACSPersonList));
            _NETDEV_FindACSVisitLogList = GetDelegate<DCreater.NETDEV_FindACSVisitLogList>(nameof(DCreater.NETDEV_FindACSVisitLogList));
            _NETDEV_FindClose = GetDelegate<DCreater.NETDEV_FindClose>(nameof(DCreater.NETDEV_FindClose));
            _NETDEV_FindCloseACSAttendanceLogList = GetDelegate<DCreater.NETDEV_FindCloseACSAttendanceLogList>(nameof(DCreater.NETDEV_FindCloseACSAttendanceLogList));
            _NETDEV_FindCloseACSPermissionGroupList = GetDelegate<DCreater.NETDEV_FindCloseACSPermissionGroupList>(nameof(DCreater.NETDEV_FindCloseACSPermissionGroupList));
            _NETDEV_FindCloseACSPersonBlackList = GetDelegate<DCreater.NETDEV_FindCloseACSPersonBlackList>(nameof(DCreater.NETDEV_FindCloseACSPersonBlackList));
            _NETDEV_FindCloseACSPersonInfo = GetDelegate<DCreater.NETDEV_FindCloseACSPersonInfo>(nameof(DCreater.NETDEV_FindCloseACSPersonInfo));
            _NETDEV_FindCloseACSVisitLog = GetDelegate<DCreater.NETDEV_FindCloseACSVisitLog>(nameof(DCreater.NETDEV_FindCloseACSVisitLog));
            _NETDEV_FindCloseCloudDevListEx = GetDelegate<DCreater.NETDEV_FindCloseCloudDevListEx>(nameof(DCreater.NETDEV_FindCloseCloudDevListEx));
            _NETDEV_FindCloseDevChn = GetDelegate<DCreater.NETDEV_FindCloseDevChn>(nameof(DCreater.NETDEV_FindCloseDevChn));
            _NETDEV_FindCloseDevInfo = GetDelegate<DCreater.NETDEV_FindCloseDevInfo>(nameof(DCreater.NETDEV_FindCloseDevInfo));
            _NETDEV_FindCloseFaceRecordDetail = GetDelegate<DCreater.NETDEV_FindCloseFaceRecordDetail>(nameof(DCreater.NETDEV_FindCloseFaceRecordDetail));
            _NETDEV_FindCloseMonitorDevResult = GetDelegate<DCreater.NETDEV_FindCloseMonitorDevResult>(nameof(DCreater.NETDEV_FindCloseMonitorDevResult));
            _NETDEV_FindCloseMonitorStatusList = GetDelegate<DCreater.NETDEV_FindCloseMonitorStatusList>(nameof(DCreater.NETDEV_FindCloseMonitorStatusList));
            _NETDEV_FindCloseOrgInfo = GetDelegate<DCreater.NETDEV_FindCloseOrgInfo>(nameof(DCreater.NETDEV_FindCloseOrgInfo));
            _NETDEV_FindClosePermStatusList = GetDelegate<DCreater.NETDEV_FindClosePermStatusList>(nameof(DCreater.NETDEV_FindClosePermStatusList));
            _NETDEV_FindClosePersonInfoList = GetDelegate<DCreater.NETDEV_FindClosePersonInfoList>(nameof(DCreater.NETDEV_FindClosePersonInfoList));
            _NETDEV_FindClosePersonLibList = GetDelegate<DCreater.NETDEV_FindClosePersonLibList>(nameof(DCreater.NETDEV_FindClosePersonLibList));
            _NETDEV_FindClosePersonMonitorList = GetDelegate<DCreater.NETDEV_FindClosePersonMonitorList>(nameof(DCreater.NETDEV_FindClosePersonMonitorList));
            _NETDEV_FindCloseVehicleLibList = GetDelegate<DCreater.NETDEV_FindCloseVehicleLibList>(nameof(DCreater.NETDEV_FindCloseVehicleLibList));
            _NETDEV_FindCloseVehicleMemberDetail = GetDelegate<DCreater.NETDEV_FindCloseVehicleMemberDetail>(nameof(DCreater.NETDEV_FindCloseVehicleMemberDetail));
            _NETDEV_FindCloseVehicleMonitorList = GetDelegate<DCreater.NETDEV_FindCloseVehicleMonitorList>(nameof(DCreater.NETDEV_FindCloseVehicleMonitorList));
            _NETDEV_FindCloseVehicleRecordList = GetDelegate<DCreater.NETDEV_FindCloseVehicleRecordList>(nameof(DCreater.NETDEV_FindCloseVehicleRecordList));
            _NETDEV_FindCloudDevListEx = GetDelegate<DCreater.NETDEV_FindCloudDevListEx>(nameof(DCreater.NETDEV_FindCloudDevListEx));
            _NETDEV_FindDevChnList = GetDelegate<DCreater.NETDEV_FindDevChnList>(nameof(DCreater.NETDEV_FindDevChnList));
            _NETDEV_FindDevList = GetDelegate<DCreater.NETDEV_FindDevList>(nameof(DCreater.NETDEV_FindDevList));
            _NETDEV_FindFaceRecordDetailList = GetDelegate<DCreater.NETDEV_FindFaceRecordDetailList>(nameof(DCreater.NETDEV_FindFaceRecordDetailList));
            _NETDEV_FindFile = GetDelegate<DCreater.NETDEV_FindFile>(nameof(DCreater.NETDEV_FindFile));
            _NETDEV_FindMonitorDevResult = GetDelegate<DCreater.NETDEV_FindMonitorDevResult>(nameof(DCreater.NETDEV_FindMonitorDevResult));
            _NETDEV_FindMonitorStatusList = GetDelegate<DCreater.NETDEV_FindMonitorStatusList>(nameof(DCreater.NETDEV_FindMonitorStatusList));
            _NETDEV_FindNextACSAttendanceLog = GetDelegate<DCreater.NETDEV_FindNextACSAttendanceLog>(nameof(DCreater.NETDEV_FindNextACSAttendanceLog));
            _NETDEV_FindNextACSPermissionGroupInfo = GetDelegate<DCreater.NETDEV_FindNextACSPermissionGroupInfo>(nameof(DCreater.NETDEV_FindNextACSPermissionGroupInfo));
            _NETDEV_FindNextACSPersonBlackListInfo = GetDelegate<DCreater.NETDEV_FindNextACSPersonBlackListInfo>(nameof(DCreater.NETDEV_FindNextACSPersonBlackListInfo));
            _NETDEV_FindNextACSPersonInfo = GetDelegate<DCreater.NETDEV_FindNextACSPersonInfo>(nameof(DCreater.NETDEV_FindNextACSPersonInfo));
            _NETDEV_FindNextACSVisitLog = GetDelegate<DCreater.NETDEV_FindNextACSVisitLog>(nameof(DCreater.NETDEV_FindNextACSVisitLog));
            _NETDEV_FindNextCloudDevInfoEx = GetDelegate<DCreater.NETDEV_FindNextCloudDevInfoEx>(nameof(DCreater.NETDEV_FindNextCloudDevInfoEx));
            _NETDEV_FindNextDevChn = GetDelegate<DCreater.NETDEV_FindNextDevChn>(nameof(DCreater.NETDEV_FindNextDevChn));
            _NETDEV_FindNextDevInfo = GetDelegate<DCreater.NETDEV_FindNextDevInfo>(nameof(DCreater.NETDEV_FindNextDevInfo));
            _NETDEV_FindNextFaceRecordDetail = GetDelegate<DCreater.NETDEV_FindNextFaceRecordDetail>(nameof(DCreater.NETDEV_FindNextFaceRecordDetail));
            _NETDEV_FindNextFile = GetDelegate<DCreater.NETDEV_FindNextFile>(nameof(DCreater.NETDEV_FindNextFile));
            _NETDEV_FindNextMonitorDevResult = GetDelegate<DCreater.NETDEV_FindNextMonitorDevResult>(nameof(DCreater.NETDEV_FindNextMonitorDevResult));
            _NETDEV_FindNextMonitorStatusInfo = GetDelegate<DCreater.NETDEV_FindNextMonitorStatusInfo>(nameof(DCreater.NETDEV_FindNextMonitorStatusInfo));
            _NETDEV_FindNextOrgInfo = GetDelegate<DCreater.NETDEV_FindNextOrgInfo>(nameof(DCreater.NETDEV_FindNextOrgInfo));
            _NETDEV_FindNextPermStatusInfo = GetDelegate<DCreater.NETDEV_FindNextPermStatusInfo>(nameof(DCreater.NETDEV_FindNextPermStatusInfo));
            _NETDEV_FindNextPersonInfo = GetDelegate<DCreater.NETDEV_FindNextPersonInfo>(nameof(DCreater.NETDEV_FindNextPersonInfo));
            _NETDEV_FindNextPersonLibInfo = GetDelegate<DCreater.NETDEV_FindNextPersonLibInfo>(nameof(DCreater.NETDEV_FindNextPersonLibInfo));
            _NETDEV_FindNextPersonMonitorInfo = GetDelegate<DCreater.NETDEV_FindNextPersonMonitorInfo>(nameof(DCreater.NETDEV_FindNextPersonMonitorInfo));
            _NETDEV_FindNextVehicleLibInfo = GetDelegate<DCreater.NETDEV_FindNextVehicleLibInfo>(nameof(DCreater.NETDEV_FindNextVehicleLibInfo));
            _NETDEV_FindNextVehicleMemberDetail = GetDelegate<DCreater.NETDEV_FindNextVehicleMemberDetail>(nameof(DCreater.NETDEV_FindNextVehicleMemberDetail));
            _NETDEV_FindNextVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_FindNextVehicleMonitorInfo>(nameof(DCreater.NETDEV_FindNextVehicleMonitorInfo));
            _NETDEV_FindNextVehicleRecordInfo = GetDelegate<DCreater.NETDEV_FindNextVehicleRecordInfo>(nameof(DCreater.NETDEV_FindNextVehicleRecordInfo));
            _NETDEV_FindOrgInfoList = GetDelegate<DCreater.NETDEV_FindOrgInfoList>(nameof(DCreater.NETDEV_FindOrgInfoList));
            _NETDEV_FindPermStatusList = GetDelegate<DCreater.NETDEV_FindPermStatusList>(nameof(DCreater.NETDEV_FindPermStatusList));
            _NETDEV_FindPersonInfoList = GetDelegate<DCreater.NETDEV_FindPersonInfoList>(nameof(DCreater.NETDEV_FindPersonInfoList));
            _NETDEV_FindPersonLibList = GetDelegate<DCreater.NETDEV_FindPersonLibList>(nameof(DCreater.NETDEV_FindPersonLibList));
            _NETDEV_FindPersonMonitorList = GetDelegate<DCreater.NETDEV_FindPersonMonitorList>(nameof(DCreater.NETDEV_FindPersonMonitorList));
            _NETDEV_FindVehicleLibList = GetDelegate<DCreater.NETDEV_FindVehicleLibList>(nameof(DCreater.NETDEV_FindVehicleLibList));
            _NETDEV_FindVehicleMemberDetailList = GetDelegate<DCreater.NETDEV_FindVehicleMemberDetailList>(nameof(DCreater.NETDEV_FindVehicleMemberDetailList));
            _NETDEV_FindVehicleMonitorList = GetDelegate<DCreater.NETDEV_FindVehicleMonitorList>(nameof(DCreater.NETDEV_FindVehicleMonitorList));
            _NETDEV_FindVehicleRecordInfoList = GetDelegate<DCreater.NETDEV_FindVehicleRecordInfoList>(nameof(DCreater.NETDEV_FindVehicleRecordInfoList));
            _NETDEV_GetACSPersonBlackList = GetDelegate<DCreater.NETDEV_GetACSPersonBlackList>(nameof(DCreater.NETDEV_GetACSPersonBlackList));
            _NETDEV_GetACSPersonPermission = GetDelegate<DCreater.NETDEV_GetACSPersonPermission>(nameof(DCreater.NETDEV_GetACSPersonPermission));
            _NETDEV_GetBitRate = GetDelegate<DCreater.NETDEV_GetBitRate>(nameof(DCreater.NETDEV_GetBitRate));
            _NETDEV_GetBuiltinIndicatorCtrl = GetDelegate<DCreater.NETDEV_GetBuiltinIndicatorCtrl>(nameof(DCreater.NETDEV_GetBuiltinIndicatorCtrl));
            _NETDEV_GetChnDetailByChnType = GetDelegate<DCreater.NETDEV_GetChnDetailByChnType>(nameof(DCreater.NETDEV_GetChnDetailByChnType));
            _NETDEV_GetChnType = GetDelegate<DCreater.NETDEV_GetChnType>(nameof(DCreater.NETDEV_GetChnType));
            _NETDEV_GetCloudDevInfoByName = GetDelegate<DCreater.NETDEV_GetCloudDevInfoByName>(nameof(DCreater.NETDEV_GetCloudDevInfoByName));
            _NETDEV_GetCloudDevInfoByRegCode = GetDelegate<DCreater.NETDEV_GetCloudDevInfoByRegCode>(nameof(DCreater.NETDEV_GetCloudDevInfoByRegCode));
            _NETDEV_GetCompassInfo = GetDelegate<DCreater.NETDEV_GetCompassInfo>(nameof(DCreater.NETDEV_GetCompassInfo));
            _NETDEV_GetConfigFile = GetDelegate<DCreater.NETDEV_GetConfigFile>(nameof(DCreater.NETDEV_GetConfigFile));
            _NETDEV_GetDevConfig1 = GetDelegate<DCreater.NETDEV_GetDevConfig1>(nameof(DCreater.NETDEV_GetDevConfig1));
            _NETDEV_GetDevConfig2 = GetDelegate<DCreater.NETDEV_GetDevConfig2>(nameof(DCreater.NETDEV_GetDevConfig2));
            _NETDEV_GetDevConfig3 = GetDelegate<DCreater.NETDEV_GetDevConfig3>(nameof(DCreater.NETDEV_GetDevConfig3));
            _NETDEV_GetDevConfig4 = GetDelegate<DCreater.NETDEV_GetDevConfig4>(nameof(DCreater.NETDEV_GetDevConfig4));
            _NETDEV_GetDevConfig5 = GetDelegate<DCreater.NETDEV_GetDevConfig5>(nameof(DCreater.NETDEV_GetDevConfig5));
            _NETDEV_GetDevConfig6 = GetDelegate<DCreater.NETDEV_GetDevConfig6>(nameof(DCreater.NETDEV_GetDevConfig6));
            _NETDEV_GetDevConfig7 = GetDelegate<DCreater.NETDEV_GetDevConfig7>(nameof(DCreater.NETDEV_GetDevConfig7));
            _NETDEV_GetDevConfig8 = GetDelegate<DCreater.NETDEV_GetDevConfig8>(nameof(DCreater.NETDEV_GetDevConfig8));
            _NETDEV_GetDevConfig9 = GetDelegate<DCreater.NETDEV_GetDevConfig9>(nameof(DCreater.NETDEV_GetDevConfig9));
            _NETDEV_GetDevConfigA = GetDelegate<DCreater.NETDEV_GetDevConfigA>(nameof(DCreater.NETDEV_GetDevConfigA));
            _NETDEV_GetDevConfigB = GetDelegate<DCreater.NETDEV_GetDevConfigB>(nameof(DCreater.NETDEV_GetDevConfigB));
            _NETDEV_GetDevConfigC = GetDelegate<DCreater.NETDEV_GetDevConfigC>(nameof(DCreater.NETDEV_GetDevConfigC));
            _NETDEV_GetDevConfigD = GetDelegate<DCreater.NETDEV_GetDevConfigD>(nameof(DCreater.NETDEV_GetDevConfigD));
            _NETDEV_GetDevConfigE = GetDelegate<DCreater.NETDEV_GetDevConfigE>(nameof(DCreater.NETDEV_GetDevConfigE));
            _NETDEV_GetDevConfigF = GetDelegate<DCreater.NETDEV_GetDevConfigF>(nameof(DCreater.NETDEV_GetDevConfigF));
            _NETDEV_GetDevConfigG = GetDelegate<DCreater.NETDEV_GetDevConfigG>(nameof(DCreater.NETDEV_GetDevConfigG));
            _NETDEV_GetDevConfigH = GetDelegate<DCreater.NETDEV_GetDevConfigH>(nameof(DCreater.NETDEV_GetDevConfigH));
            _NETDEV_GetDevConfigI = GetDelegate<DCreater.NETDEV_GetDevConfigI>(nameof(DCreater.NETDEV_GetDevConfigI));
            _NETDEV_GetDevConfigJ = GetDelegate<DCreater.NETDEV_GetDevConfigJ>(nameof(DCreater.NETDEV_GetDevConfigJ));
            _NETDEV_GetDevConfigK = GetDelegate<DCreater.NETDEV_GetDevConfigK>(nameof(DCreater.NETDEV_GetDevConfigK));
            _NETDEV_GetDevConfigL = GetDelegate<DCreater.NETDEV_GetDevConfigL>(nameof(DCreater.NETDEV_GetDevConfigL));
            _NETDEV_GetDevConfigM = GetDelegate<DCreater.NETDEV_GetDevConfigM>(nameof(DCreater.NETDEV_GetDevConfigM));
            _NETDEV_GetDevConfigN = GetDelegate<DCreater.NETDEV_GetDevConfigN>(nameof(DCreater.NETDEV_GetDevConfigN));
            _NETDEV_GetDevConfigO = GetDelegate<DCreater.NETDEV_GetDevConfigO>(nameof(DCreater.NETDEV_GetDevConfigO));
            _NETDEV_GetDevConfigP = GetDelegate<DCreater.NETDEV_GetDevConfigP>(nameof(DCreater.NETDEV_GetDevConfigP));
            _NETDEV_GetDevConfigQ = GetDelegate<DCreater.NETDEV_GetDevConfigQ>(nameof(DCreater.NETDEV_GetDevConfigQ));
            _NETDEV_GetDeviceCapability1 = GetDelegate<DCreater.NETDEV_GetDeviceCapability1>(nameof(DCreater.NETDEV_GetDeviceCapability1));
            _NETDEV_GetDeviceCapability2 = GetDelegate<DCreater.NETDEV_GetDeviceCapability2>(nameof(DCreater.NETDEV_GetDeviceCapability2));
            _NETDEV_GetDeviceInfo = GetDelegate<DCreater.NETDEV_GetDeviceInfo>(nameof(DCreater.NETDEV_GetDeviceInfo));
            _NETDEV_GetDeviceInfo_V30 = GetDelegate<DCreater.NETDEV_GetDeviceInfo_V30>(nameof(DCreater.NETDEV_GetDeviceInfo_V30));
            _NETDEV_GetFaceRecordImageInfo = GetDelegate<DCreater.NETDEV_GetFaceRecordImageInfo>(nameof(DCreater.NETDEV_GetFaceRecordImageInfo));
            _NETDEV_GetFileByName = GetDelegate<DCreater.NETDEV_GetFileByName>(nameof(DCreater.NETDEV_GetFileByName));
            _NETDEV_GetFileByTime = GetDelegate<DCreater.NETDEV_GetFileByTime>(nameof(DCreater.NETDEV_GetFileByTime));
            _NETDEV_GetFrameRate = GetDelegate<DCreater.NETDEV_GetFrameRate>(nameof(DCreater.NETDEV_GetFrameRate));
            _NETDEV_GetGeolocationInfo = GetDelegate<DCreater.NETDEV_GetGeolocationInfo>(nameof(DCreater.NETDEV_GetGeolocationInfo));
            _NETDEV_GetLastError = GetDelegate<DCreater.NETDEV_GetLastError>(nameof(DCreater.NETDEV_GetLastError));
            _NETDEV_GetLostPacketRate = GetDelegate<DCreater.NETDEV_GetLostPacketRate>(nameof(DCreater.NETDEV_GetLostPacketRate));
            _NETDEV_GetMicVolume = GetDelegate<DCreater.NETDEV_GetMicVolume>(nameof(DCreater.NETDEV_GetMicVolume));
            _NETDEV_GetMonitorCapacity = GetDelegate<DCreater.NETDEV_GetMonitorCapacity>(nameof(DCreater.NETDEV_GetMonitorCapacity));
            _NETDEV_GetMonitorProgress = GetDelegate<DCreater.NETDEV_GetMonitorProgress>(nameof(DCreater.NETDEV_GetMonitorProgress));
            _NETDEV_GetPARKVersion = GetDelegate<DCreater.NETDEV_GetPARKVersion>(nameof(DCreater.NETDEV_GetPARKVersion));
            _NETDEV_GetPersonLibCapacity = GetDelegate<DCreater.NETDEV_GetPersonLibCapacity>(nameof(DCreater.NETDEV_GetPersonLibCapacity));
            _NETDEV_GetPersonMemberInfo = GetDelegate<DCreater.NETDEV_GetPersonMemberInfo>(nameof(DCreater.NETDEV_GetPersonMemberInfo));
            _NETDEV_GetPersonMonitorRuleInfo = GetDelegate<DCreater.NETDEV_GetPersonMonitorRuleInfo>(nameof(DCreater.NETDEV_GetPersonMonitorRuleInfo));
            _NETDEV_GetPTZPresetList = GetDelegate<DCreater.NETDEV_GetPTZPresetList>(nameof(DCreater.NETDEV_GetPTZPresetList));
            _NETDEV_GetResolution = GetDelegate<DCreater.NETDEV_GetResolution>(nameof(DCreater.NETDEV_GetResolution));
            _NETDEV_GetSDKVersion = GetDelegate<DCreater.NETDEV_GetSDKVersion>(nameof(DCreater.NETDEV_GetSDKVersion));
            _NETDEV_GetSinglePermGroupInfo = GetDelegate<DCreater.NETDEV_GetSinglePermGroupInfo>(nameof(DCreater.NETDEV_GetSinglePermGroupInfo));
            _NETDEV_GetSoundVolume = GetDelegate<DCreater.NETDEV_GetSoundVolume>(nameof(DCreater.NETDEV_GetSoundVolume));
            _NETDEV_GetSystemPicture = GetDelegate<DCreater.NETDEV_GetSystemPicture>(nameof(DCreater.NETDEV_GetSystemPicture));
            _NETDEV_GetSystemTimeCfg = GetDelegate<DCreater.NETDEV_GetSystemTimeCfg>(nameof(DCreater.NETDEV_GetSystemTimeCfg));
            _NETDEV_GetTimeTemplateInfo = GetDelegate<DCreater.NETDEV_GetTimeTemplateInfo>(nameof(DCreater.NETDEV_GetTimeTemplateInfo));
            _NETDEV_GetTimeTemplateList = GetDelegate<DCreater.NETDEV_GetTimeTemplateList>(nameof(DCreater.NETDEV_GetTimeTemplateList));
            _NETDEV_GetTrafficStatistic = GetDelegate<DCreater.NETDEV_GetTrafficStatistic>(nameof(DCreater.NETDEV_GetTrafficStatistic));
            _NETDEV_GetUpnpNatState = GetDelegate<DCreater.NETDEV_GetUpnpNatState>(nameof(DCreater.NETDEV_GetUpnpNatState));
            _NETDEV_GetUserDetailList = GetDelegate<DCreater.NETDEV_GetUserDetailList>(nameof(DCreater.NETDEV_GetUserDetailList));
            _NETDEV_GetVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_GetVehicleMonitorInfo>(nameof(DCreater.NETDEV_GetVehicleMonitorInfo));
            _NETDEV_GetVehicleRecordImageInfo = GetDelegate<DCreater.NETDEV_GetVehicleRecordImageInfo>(nameof(DCreater.NETDEV_GetVehicleRecordImageInfo));
            _NETDEV_GetVideoEffect = GetDelegate<DCreater.NETDEV_GetVideoEffect>(nameof(DCreater.NETDEV_GetVideoEffect));
            _NETDEV_GetVideoEncodeFmt = GetDelegate<DCreater.NETDEV_GetVideoEncodeFmt>(nameof(DCreater.NETDEV_GetVideoEncodeFmt));
            _NETDEV_ImportBlackWhiteListFile = GetDelegate<DCreater.NETDEV_ImportBlackWhiteListFile>(nameof(DCreater.NETDEV_ImportBlackWhiteListFile));
            _NETDEV_Init = GetDelegate<DCreater.NETDEV_Init>(nameof(DCreater.NETDEV_Init));
            _NETDEV_InputVoiceData = GetDelegate<DCreater.NETDEV_InputVoiceData>(nameof(DCreater.NETDEV_InputVoiceData));
            _NETDEV_Login = GetDelegate<DCreater.NETDEV_Login>(nameof(DCreater.NETDEV_Login));
            _NETDEV_LoginCloud = GetDelegate<DCreater.NETDEV_LoginCloud>(nameof(DCreater.NETDEV_LoginCloud));
            _NETDEV_LoginCloudDevice_V30 = GetDelegate<DCreater.NETDEV_LoginCloudDevice_V30>(nameof(DCreater.NETDEV_LoginCloudDevice_V30));
            _NETDEV_Login_V30 = GetDelegate<DCreater.NETDEV_Login_V30>(nameof(DCreater.NETDEV_Login_V30));
            _NETDEV_Logout = GetDelegate<DCreater.NETDEV_Logout>(nameof(DCreater.NETDEV_Logout));
            _NETDEV_MakeKeyFrame = GetDelegate<DCreater.NETDEV_MakeKeyFrame>(nameof(DCreater.NETDEV_MakeKeyFrame));
            _NETDEV_MicVolumeControl = GetDelegate<DCreater.NETDEV_MicVolumeControl>(nameof(DCreater.NETDEV_MicVolumeControl));
            _NETDEV_ModifyACSPersonBlackList = GetDelegate<DCreater.NETDEV_ModifyACSPersonBlackList>(nameof(DCreater.NETDEV_ModifyACSPersonBlackList));
            _NETDEV_ModifyACSPersonPermissionGroup = GetDelegate<DCreater.NETDEV_ModifyACSPersonPermissionGroup>(nameof(DCreater.NETDEV_ModifyACSPersonPermissionGroup));
            _NETDEV_ModifyAllowVehicleRecord = GetDelegate<DCreater.NETDEV_ModifyAllowVehicleRecord>(nameof(DCreater.NETDEV_ModifyAllowVehicleRecord));
            _NETDEV_ModifyBlockVehicleRecord = GetDelegate<DCreater.NETDEV_ModifyBlockVehicleRecord>(nameof(DCreater.NETDEV_ModifyBlockVehicleRecord));
            _NETDEV_ModifyDeviceName = GetDelegate<DCreater.NETDEV_ModifyDeviceName>(nameof(DCreater.NETDEV_ModifyDeviceName));
            _NETDEV_ModifyOrgInfo = GetDelegate<DCreater.NETDEV_ModifyOrgInfo>(nameof(DCreater.NETDEV_ModifyOrgInfo));
            _NETDEV_ModifyPersonInfo = GetDelegate<DCreater.NETDEV_ModifyPersonInfo>(nameof(DCreater.NETDEV_ModifyPersonInfo));
            _NETDEV_ModifyPersonLibInfo = GetDelegate<DCreater.NETDEV_ModifyPersonLibInfo>(nameof(DCreater.NETDEV_ModifyPersonLibInfo));
            _NETDEV_ModifyUser = GetDelegate<DCreater.NETDEV_ModifyUser>(nameof(DCreater.NETDEV_ModifyUser));
            _NETDEV_ModifyVehicleLibInfo = GetDelegate<DCreater.NETDEV_ModifyVehicleLibInfo>(nameof(DCreater.NETDEV_ModifyVehicleLibInfo));
            _NETDEV_ModifyVehicleMemberInfo = GetDelegate<DCreater.NETDEV_ModifyVehicleMemberInfo>(nameof(DCreater.NETDEV_ModifyVehicleMemberInfo));
            _NETDEV_OpenMic = GetDelegate<DCreater.NETDEV_OpenMic>(nameof(DCreater.NETDEV_OpenMic));
            _NETDEV_OpenSound = GetDelegate<DCreater.NETDEV_OpenSound>(nameof(DCreater.NETDEV_OpenSound));
            _NETDEV_PlayBackByName = GetDelegate<DCreater.NETDEV_PlayBackByName>(nameof(DCreater.NETDEV_PlayBackByName));
            _NETDEV_PlayBackByTime = GetDelegate<DCreater.NETDEV_PlayBackByTime>(nameof(DCreater.NETDEV_PlayBackByTime));
            _NETDEV_PlayBackControl = GetDelegate<DCreater.NETDEV_PlayBackControl>(nameof(DCreater.NETDEV_PlayBackControl));
            _NETDEV_PlaySound = GetDelegate<DCreater.NETDEV_PlaySound>(nameof(DCreater.NETDEV_PlaySound));
            _NETDEV_PTZCalibrate = GetDelegate<DCreater.NETDEV_PTZCalibrate>(nameof(DCreater.NETDEV_PTZCalibrate));
            _NETDEV_PTZControl = GetDelegate<DCreater.NETDEV_PTZControl>(nameof(DCreater.NETDEV_PTZControl));
            _NETDEV_PTZControl_Other = GetDelegate<DCreater.NETDEV_PTZControl_Other>(nameof(DCreater.NETDEV_PTZControl_Other));
            _NETDEV_PTZCruise_Other = GetDelegate<DCreater.NETDEV_PTZCruise_Other>(nameof(DCreater.NETDEV_PTZCruise_Other));
            _NETDEV_PTZGetCruise = GetDelegate<DCreater.NETDEV_PTZGetCruise>(nameof(DCreater.NETDEV_PTZGetCruise));
            _NETDEV_PTZGetTrackCruise = GetDelegate<DCreater.NETDEV_PTZGetTrackCruise>(nameof(DCreater.NETDEV_PTZGetTrackCruise));
            _NETDEV_PTZPreset = GetDelegate<DCreater.NETDEV_PTZPreset>(nameof(DCreater.NETDEV_PTZPreset));
            _NETDEV_PTZPreset_Other = GetDelegate<DCreater.NETDEV_PTZPreset_Other>(nameof(DCreater.NETDEV_PTZPreset_Other));
            _NETDEV_PTZSelZoomIn_Other = GetDelegate<DCreater.NETDEV_PTZSelZoomIn_Other>(nameof(DCreater.NETDEV_PTZSelZoomIn_Other));
            _NETDEV_PTZTrackCruise = GetDelegate<DCreater.NETDEV_PTZTrackCruise>(nameof(DCreater.NETDEV_PTZTrackCruise));
            _NETDEV_QueryVideoChlDetailList = GetDelegate<DCreater.NETDEV_QueryVideoChlDetailList>(nameof(DCreater.NETDEV_QueryVideoChlDetailList));
            _NETDEV_RealPlay = GetDelegate<DCreater.NETDEV_RealPlay>(nameof(DCreater.NETDEV_RealPlay));
            _NETDEV_Reboot = GetDelegate<DCreater.NETDEV_Reboot>(nameof(DCreater.NETDEV_Reboot));
            _NETDEV_ResetLostPacketRate = GetDelegate<DCreater.NETDEV_ResetLostPacketRate>(nameof(DCreater.NETDEV_ResetLostPacketRate));
            _NETDEV_RestoreConfig = GetDelegate<DCreater.NETDEV_RestoreConfig>(nameof(DCreater.NETDEV_RestoreConfig));
            _NETDEV_SaveRealData = GetDelegate<DCreater.NETDEV_SaveRealData>(nameof(DCreater.NETDEV_SaveRealData));
            _NETDEV_SetACSPersonPermission = GetDelegate<DCreater.NETDEV_SetACSPersonPermission>(nameof(DCreater.NETDEV_SetACSPersonPermission));
            _NETDEV_SetAlarmCallBack = GetDelegate<DCreater.NETDEV_SetAlarmCallBack>(nameof(DCreater.NETDEV_SetAlarmCallBack));
            _NETDEV_SetAlarmCallBack_V30 = GetDelegate<DCreater.NETDEV_SetAlarmCallBack_V30>(nameof(DCreater.NETDEV_SetAlarmCallBack_V30));
            _NETDEV_SetAlarmFGCallBack = GetDelegate<DCreater.NETDEV_SetAlarmFGCallBack>(nameof(DCreater.NETDEV_SetAlarmFGCallBack));
            _NETDEV_SetBuiltinIndicatorCtrl = GetDelegate<DCreater.NETDEV_SetBuiltinIndicatorCtrl>(nameof(DCreater.NETDEV_SetBuiltinIndicatorCtrl));
            _NETDEV_SetConfigFile = GetDelegate<DCreater.NETDEV_SetConfigFile>(nameof(DCreater.NETDEV_SetConfigFile));
            _NETDEV_SetConnectTime = GetDelegate<DCreater.NETDEV_SetConnectTime>(nameof(DCreater.NETDEV_SetConnectTime));
            _NETDEV_SetDevConfig1 = GetDelegate<DCreater.NETDEV_SetDevConfig1>(nameof(DCreater.NETDEV_SetDevConfig1));
            _NETDEV_SetDevConfig2 = GetDelegate<DCreater.NETDEV_SetDevConfig2>(nameof(DCreater.NETDEV_SetDevConfig2));
            _NETDEV_SetDevConfig3 = GetDelegate<DCreater.NETDEV_SetDevConfig3>(nameof(DCreater.NETDEV_SetDevConfig3));
            _NETDEV_SetDevConfig4 = GetDelegate<DCreater.NETDEV_SetDevConfig4>(nameof(DCreater.NETDEV_SetDevConfig4));
            _NETDEV_SetDevConfig5 = GetDelegate<DCreater.NETDEV_SetDevConfig5>(nameof(DCreater.NETDEV_SetDevConfig5));
            _NETDEV_SetDevConfig6 = GetDelegate<DCreater.NETDEV_SetDevConfig6>(nameof(DCreater.NETDEV_SetDevConfig6));
            _NETDEV_SetDevConfig7 = GetDelegate<DCreater.NETDEV_SetDevConfig7>(nameof(DCreater.NETDEV_SetDevConfig7));
            _NETDEV_SetDevConfig8 = GetDelegate<DCreater.NETDEV_SetDevConfig8>(nameof(DCreater.NETDEV_SetDevConfig8));
            _NETDEV_SetDevConfig9 = GetDelegate<DCreater.NETDEV_SetDevConfig9>(nameof(DCreater.NETDEV_SetDevConfig9));
            _NETDEV_SetDevConfigA = GetDelegate<DCreater.NETDEV_SetDevConfigA>(nameof(DCreater.NETDEV_SetDevConfigA));
            _NETDEV_SetDevConfigB = GetDelegate<DCreater.NETDEV_SetDevConfigB>(nameof(DCreater.NETDEV_SetDevConfigB));
            _NETDEV_SetDevConfigC = GetDelegate<DCreater.NETDEV_SetDevConfigC>(nameof(DCreater.NETDEV_SetDevConfigC));
            _NETDEV_SetDevConfigD = GetDelegate<DCreater.NETDEV_SetDevConfigD>(nameof(DCreater.NETDEV_SetDevConfigD));
            _NETDEV_SetDevConfigE = GetDelegate<DCreater.NETDEV_SetDevConfigE>(nameof(DCreater.NETDEV_SetDevConfigE));
            _NETDEV_SetDevConfigF = GetDelegate<DCreater.NETDEV_SetDevConfigF>(nameof(DCreater.NETDEV_SetDevConfigF));
            _NETDEV_SetDevConfigG = GetDelegate<DCreater.NETDEV_SetDevConfigG>(nameof(DCreater.NETDEV_SetDevConfigG));
            _NETDEV_SetDevConfigH = GetDelegate<DCreater.NETDEV_SetDevConfigH>(nameof(DCreater.NETDEV_SetDevConfigH));
            _NETDEV_SetDevConfigI = GetDelegate<DCreater.NETDEV_SetDevConfigI>(nameof(DCreater.NETDEV_SetDevConfigI));
            _NETDEV_SetDevConfigJ = GetDelegate<DCreater.NETDEV_SetDevConfigJ>(nameof(DCreater.NETDEV_SetDevConfigJ));
            _NETDEV_setDeviceLedCfg = GetDelegate<DCreater.NETDEV_setDeviceLedCfg>(nameof(DCreater.NETDEV_setDeviceLedCfg));
            _NETDEV_SetDigitalZoom = GetDelegate<DCreater.NETDEV_SetDigitalZoom>(nameof(DCreater.NETDEV_SetDigitalZoom));
            _NETDEV_SetDiscoveryCallBack = GetDelegate<DCreater.NETDEV_SetDiscoveryCallBack>(nameof(DCreater.NETDEV_SetDiscoveryCallBack));
            _NETDEV_SetExceptionCallBack = GetDelegate<DCreater.NETDEV_SetExceptionCallBack>(nameof(DCreater.NETDEV_SetExceptionCallBack));
            _NETDEV_SetFaceSnapshotCallBack = GetDelegate<DCreater.NETDEV_SetFaceSnapshotCallBack>(nameof(DCreater.NETDEV_SetFaceSnapshotCallBack));
            _NETDEV_SetIVAEnable = GetDelegate<DCreater.NETDEV_SetIVAEnable>(nameof(DCreater.NETDEV_SetIVAEnable));
            _NETDEV_SetIVAShowParam = GetDelegate<DCreater.NETDEV_SetIVAShowParam>(nameof(DCreater.NETDEV_SetIVAShowParam));
            _NETDEV_SetLogPath = GetDelegate<DCreater.NETDEV_SetLogPath>(nameof(DCreater.NETDEV_SetLogPath));
            _NETDEV_SetOutputSwitchStatusCfg = GetDelegate<DCreater.NETDEV_SetOutputSwitchStatusCfg>(nameof(DCreater.NETDEV_SetOutputSwitchStatusCfg));
            _NETDEV_SetParkingStatusCB = GetDelegate<DCreater.NETDEV_SetParkingStatusCB>(nameof(DCreater.NETDEV_SetParkingStatusCB));
            _NETDEV_SetParkStatusCallBack = GetDelegate<DCreater.NETDEV_SetParkStatusCallBack>(nameof(DCreater.NETDEV_SetParkStatusCallBack));
            _NETDEV_SetPassengerFlowStatisticCallBack = GetDelegate<DCreater.NETDEV_SetPassengerFlowStatisticCallBack>(nameof(DCreater.NETDEV_SetPassengerFlowStatisticCallBack));
            _NETDEV_SetPersonAlarmCallBack = GetDelegate<DCreater.NETDEV_SetPersonAlarmCallBack>(nameof(DCreater.NETDEV_SetPersonAlarmCallBack));
            _NETDEV_SetPersonMonitorRuleInfo = GetDelegate<DCreater.NETDEV_SetPersonMonitorRuleInfo>(nameof(DCreater.NETDEV_SetPersonMonitorRuleInfo));
            _NETDEV_SetPictureFluency = GetDelegate<DCreater.NETDEV_SetPictureFluency>(nameof(DCreater.NETDEV_SetPictureFluency));
            _NETDEV_SetPlayDataCallBack = GetDelegate<DCreater.NETDEV_SetPlayDataCallBack>(nameof(DCreater.NETDEV_SetPlayDataCallBack));
            _NETDEV_SetPlayDecodeVideoCB = GetDelegate<DCreater.NETDEV_SetPlayDecodeVideoCB>(nameof(DCreater.NETDEV_SetPlayDecodeVideoCB));
            _NETDEV_SetPlayDisplayCB = GetDelegate<DCreater.NETDEV_SetPlayDisplayCB>(nameof(DCreater.NETDEV_SetPlayDisplayCB));
            _NETDEV_SetPlayParseCB = GetDelegate<DCreater.NETDEV_SetPlayParseCB>(nameof(DCreater.NETDEV_SetPlayParseCB));
            _NETDEV_SetRenderScale = GetDelegate<DCreater.NETDEV_SetRenderScale>(nameof(DCreater.NETDEV_SetRenderScale));
            _NETDEV_SetRevTimeOut = GetDelegate<DCreater.NETDEV_SetRevTimeOut>(nameof(DCreater.NETDEV_SetRevTimeOut));
            _NETDEV_SetStructAlarmCallBack = GetDelegate<DCreater.NETDEV_SetStructAlarmCallBack>(nameof(DCreater.NETDEV_SetStructAlarmCallBack));
            _NETDEV_SetSystemTimeCfg = GetDelegate<DCreater.NETDEV_SetSystemTimeCfg>(nameof(DCreater.NETDEV_SetSystemTimeCfg));
            _NETDEV_SetUpnpNatState = GetDelegate<DCreater.NETDEV_SetUpnpNatState>(nameof(DCreater.NETDEV_SetUpnpNatState));
            _NETDEV_SetVehicleAlarmCallBack = GetDelegate<DCreater.NETDEV_SetVehicleAlarmCallBack>(nameof(DCreater.NETDEV_SetVehicleAlarmCallBack));
            _NETDEV_SetVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_SetVehicleMonitorInfo>(nameof(DCreater.NETDEV_SetVehicleMonitorInfo));
            _NETDEV_SetVideoEffect = GetDelegate<DCreater.NETDEV_SetVideoEffect>(nameof(DCreater.NETDEV_SetVideoEffect));
            _NETDEV_SoundVolumeControl = GetDelegate<DCreater.NETDEV_SoundVolumeControl>(nameof(DCreater.NETDEV_SoundVolumeControl));
            _NETDEV_StartInputVoiceSrv = GetDelegate<DCreater.NETDEV_StartInputVoiceSrv>(nameof(DCreater.NETDEV_StartInputVoiceSrv));
            _NETDEV_StartPicStream = GetDelegate<DCreater.NETDEV_StartPicStream>(nameof(DCreater.NETDEV_StartPicStream));
            _NETDEV_StartVoiceCom = GetDelegate<DCreater.NETDEV_StartVoiceCom>(nameof(DCreater.NETDEV_StartVoiceCom));
            _NETDEV_StopGetFile = GetDelegate<DCreater.NETDEV_StopGetFile>(nameof(DCreater.NETDEV_StopGetFile));
            _NETDEV_StopInputVoiceSrv = GetDelegate<DCreater.NETDEV_StopInputVoiceSrv>(nameof(DCreater.NETDEV_StopInputVoiceSrv));
            _NETDEV_StopPicStream = GetDelegate<DCreater.NETDEV_StopPicStream>(nameof(DCreater.NETDEV_StopPicStream));
            _NETDEV_StopPlayBack = GetDelegate<DCreater.NETDEV_StopPlayBack>(nameof(DCreater.NETDEV_StopPlayBack));
            _NETDEV_StopPlaySound = GetDelegate<DCreater.NETDEV_StopPlaySound>(nameof(DCreater.NETDEV_StopPlaySound));
            _NETDEV_StopRealPlay = GetDelegate<DCreater.NETDEV_StopRealPlay>(nameof(DCreater.NETDEV_StopRealPlay));
            _NETDEV_StopSaveRealData = GetDelegate<DCreater.NETDEV_StopSaveRealData>(nameof(DCreater.NETDEV_StopSaveRealData));
            _NETDEV_StopVoiceCom = GetDelegate<DCreater.NETDEV_StopVoiceCom>(nameof(DCreater.NETDEV_StopVoiceCom));
            _NETDEV_SubscibeLapiAlarm = GetDelegate<DCreater.NETDEV_SubscibeLapiAlarm>(nameof(DCreater.NETDEV_SubscibeLapiAlarm));
            _NETDEV_SubscribeSmart = GetDelegate<DCreater.NETDEV_SubscribeSmart>(nameof(DCreater.NETDEV_SubscribeSmart));
            _NETDEV_Trigger = GetDelegate<DCreater.NETDEV_Trigger>(nameof(DCreater.NETDEV_Trigger));
            _NETDEV_TriggerSync = GetDelegate<DCreater.NETDEV_TriggerSync>(nameof(DCreater.NETDEV_TriggerSync));
            _NETDEV_UnSubLapiAlarm = GetDelegate<DCreater.NETDEV_UnSubLapiAlarm>(nameof(DCreater.NETDEV_UnSubLapiAlarm));
            _NETDEV_UnsubscribeSmart = GetDelegate<DCreater.NETDEV_UnsubscribeSmart>(nameof(DCreater.NETDEV_UnsubscribeSmart));

        }
        public override string GetFileFullName()
        {
            return ItsNetDevSdk.DllFullName;
        }
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void MemCopy(byte[] dest, IntPtr src, int count);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);
        #region // 显示实现
        void IItsNetDevSdkProxy.MemCopy(byte[] dest, IntPtr src, int count) => MemCopy(dest, src, count);
        void IItsNetDevSdkProxy.OutputDebugString(string message) => OutputDebugString(message);
        int IItsNetDevSdkProxy.NETDEV_ACSPersonCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo) => _NETDEV_ACSPersonCtrl.Invoke(lpUserID, dwCommand, ref pstACSPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref uint pUdwBlackListID) => _NETDEV_AddACSPersonBlackList.Invoke(lpUserID, ref pstBlackListInfo, ref pUdwBlackListID);
        int IItsNetDevSdkProxy.NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList) => _NETDEV_AddACSPersonList.Invoke(lpUserID, ref pstACSPersonList, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref uint pUdwGroupID) => _NETDEV_AddACSPersonPermissionGroup.Invoke(lpUserID, ref pstPermissionGroupInfo, ref pUdwGroupID);
        int IItsNetDevSdkProxy.NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref int pdwOrgID) => _NETDEV_AddOrgInfo.Invoke(lpUserID, ref pstOrgInfo, ref pdwOrgID);
        int IItsNetDevSdkProxy.NETDEV_AddPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => _NETDEV_AddPersonInfo.Invoke(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int IItsNetDevSdkProxy.NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo) => _NETDEV_AddPersonMonitorInfo.Invoke(lpUserID, ref pstMonitorInfo, ref pstMonitorResultInfo);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => _NETDEV_AddVehicleLibInfo.Invoke(lpUserID, ref pstVehicleLibInfo);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => _NETDEV_AddVehicleLibMember.Invoke(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleMemberList(IntPtr lpUserID, uint udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => _NETDEV_AddVehicleMemberList.Invoke(lpUserID, udwLibID, ref pstVehicleMemberList, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_AddVehicleMonitorInfo.Invoke(lpUserID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_AddVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_EXTERN_S pstVehicleRecordExtern) => _NETDEV_AddVehicleRecord.Invoke(lpFindHandle, ref pstVehicleRecordExtern);
        int IItsNetDevSdkProxy.NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo) => _NETDEV_BatchDeleteOrgInfo.Invoke(lpUserID, ref pstOrgDelInfo, ref pstOrgDelResultInfo);
        int IItsNetDevSdkProxy.NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => _NETDEV_BatchDeletePersonMonitorInfo.Invoke(lpUserID, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_CaptureNoPreview(IntPtr lpUserID, int dwChannelID, int dwStreamType, string szFileName, int dwCaptureMode) => _NETDEV_CaptureNoPreview.Invoke(lpUserID, dwChannelID, dwStreamType, szFileName, dwCaptureMode);
        int IItsNetDevSdkProxy.NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, int dwCaptureMode) => _NETDEV_CapturePicture.Invoke(lpRealHandle, szFileName, dwCaptureMode);
        int IItsNetDevSdkProxy.NETDEV_Cleanup() => _NETDEV_Cleanup.Invoke();
        int IItsNetDevSdkProxy.NETDEV_CloseMic(IntPtr lpPlayHandle) => _NETDEV_CloseMic.Invoke(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_CloseSound(IntPtr lpRealHandle) => _NETDEV_CloseSound.Invoke(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_ConfigLogFile(int dwLogFileSize, int dwLogFileNum) => _NETDEV_ConfigLogFile.Invoke(dwLogFileSize, dwLogFileNum);
        int IItsNetDevSdkProxy.NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref uint pudwID) => _NETDEV_CreatePersonLibInfo.Invoke(lpUserID, ref pstPersonLibInfo, ref pudwID);
        int IItsNetDevSdkProxy.NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo) => _NETDEV_CreateUser.Invoke(lpUserID, stUserInfo);
        int IItsNetDevSdkProxy.NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList) => _NETDEV_DeleteACSPersonBlackList.Invoke(lpUserID, ref pstBlackList);
        int IItsNetDevSdkProxy.NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo) => _NETDEV_DeleteACSPersonList.Invoke(lpUserID, ref pstBatchCtrlInfo);
        int IItsNetDevSdkProxy.NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => _NETDEV_DeleteACSPersonPermissionGroup.Invoke(lpUserID, ref pstPermissionIDList, ref pstResutList);
        int IItsNetDevSdkProxy.NETDEV_DeleteAllowVehicleRecord(IntPtr lpFindHandle, int ulRecordID) => _NETDEV_DeleteAllowVehicleRecord.Invoke(lpFindHandle, ulRecordID);
        int IItsNetDevSdkProxy.NETDEV_DeleteBlockVehicleRecord(IntPtr lpFindHandle, int ulRecordID) => _NETDEV_DeleteBlockVehicleRecord.Invoke(lpFindHandle, ulRecordID);
        int IItsNetDevSdkProxy.NETDEV_DeletePersonInfo(IntPtr lpUserID, uint udwPersonLibID, uint udwPersonID, uint udwLastChange) => _NETDEV_DeletePersonInfo.Invoke(lpUserID, udwPersonLibID, udwPersonID, udwLastChange);
        int IItsNetDevSdkProxy.NETDEV_DeletePersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => _NETDEV_DeletePersonInfoList.Invoke(lpUserID, udwPersonLibID, ref pstIDList, ref pstResutList);
        int IItsNetDevSdkProxy.NETDEV_DeletePersonLibInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo) => _NETDEV_DeletePersonLibInfo.Invoke(lpUserID, udwPersonLibID, ref pstFlagInfo);
        int IItsNetDevSdkProxy.NETDEV_DeleteUser(IntPtr lpUserID, string strUserName) => _NETDEV_DeleteUser.Invoke(lpUserID, strUserName);
        int IItsNetDevSdkProxy.NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag) => _NETDEV_DeleteVehicleLibInfo.Invoke(lpUserID, udwVehicleLibID, ref pstDelLibFlag);
        int IItsNetDevSdkProxy.NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => _NETDEV_DeleteVehicleLibMember.Invoke(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int IItsNetDevSdkProxy.NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => _NETDEV_DeleteVehicleMonitorInfo.Invoke(lpUserID, ref pstBatchList);
        int IItsNetDevSdkProxy.NETDEV_DelVehicleMemberList(IntPtr lpUserID, uint udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => _NETDEV_DelVehicleMemberList.Invoke(lpUserID, udwLib, ref pstVehicleMemberList, ref pstBatchList);
        int IItsNetDevSdkProxy.NETDEV_Discovery(string pszBeginIP, string pszEndIP) => _NETDEV_Discovery.Invoke(pszBeginIP, pszEndIP);
        int IItsNetDevSdkProxy.NETDEV_DoorBatchCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo) => _NETDEV_DoorBatchCtrl.Invoke(lpUserID, dwCommand, ref pstBatchCtrlInfo);
        int IItsNetDevSdkProxy.NETDEV_DoorCtrl(IntPtr lpUserID, int dwChannelID, int dwCommand) => _NETDEV_DoorCtrl.Invoke(lpUserID, dwChannelID, dwCommand);
        int IItsNetDevSdkProxy.NETDEV_EnableCarplate(int bEnable) => _NETDEV_EnableCarplate.Invoke(bEnable);
        int IItsNetDevSdkProxy.NETDEV_ExportBlackWhiteListFile(IntPtr lpFindHandle, string pcFile) => _NETDEV_ExportBlackWhiteListFile.Invoke(lpFindHandle, pcFile);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSAttendanceLogList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSPermissionGroupList.Invoke(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSPersonBlackList.Invoke(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSPersonList.Invoke(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSVisitLogList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        int IItsNetDevSdkProxy.NETDEV_FindClose(IntPtr lpFindHandle) => _NETDEV_FindClose.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle) => _NETDEV_FindCloseACSAttendanceLogList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle) => _NETDEV_FindCloseACSPermissionGroupList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle) => _NETDEV_FindCloseACSPersonBlackList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle) => _NETDEV_FindCloseACSPersonInfo.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle) => _NETDEV_FindCloseACSVisitLog.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseCloudDevListEx(IntPtr lpFindHandle) => _NETDEV_FindCloseCloudDevListEx.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseDevChn(IntPtr lpFindHandle) => _NETDEV_FindCloseDevChn.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseDevInfo(IntPtr lpFindHandle) => _NETDEV_FindCloseDevInfo.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle) => _NETDEV_FindCloseFaceRecordDetail.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseMonitorDevResult(IntPtr lpFindHandle) => _NETDEV_FindCloseMonitorDevResult.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle) => _NETDEV_FindCloseMonitorStatusList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle) => _NETDEV_FindCloseOrgInfo.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePermStatusList(IntPtr lpFindHandle) => _NETDEV_FindClosePermStatusList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle) => _NETDEV_FindClosePersonInfoList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePersonLibList(IntPtr lpFindHandle) => _NETDEV_FindClosePersonLibList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle) => _NETDEV_FindClosePersonMonitorList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleLibList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleMemberDetail.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleMonitorList.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleRecordList.Invoke(lpFindHandle);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindCloudDevListEx(IntPtr lpUserID) => _NETDEV_FindCloudDevListEx.Invoke(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindDevChnList(IntPtr lpUserID, int dwDevID, int dwChnType) => _NETDEV_FindDevChnList.Invoke(lpUserID, dwDevID, dwChnType);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindDevList(IntPtr lpUserID, int dwDevType) => _NETDEV_FindDevList.Invoke(lpUserID, dwDevType);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => _NETDEV_FindFaceRecordDetailList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond) => _NETDEV_FindFile.Invoke(lpUserID, ref pFindCond);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindMonitorDevResult(IntPtr lpUserID, ref uint pudwDevNum) => _NETDEV_FindMonitorDevResult.Invoke(lpUserID, ref pudwDevNum);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindMonitorStatusList(IntPtr lpUserID, int enType, ref uint udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList) => _NETDEV_FindMonitorStatusList.Invoke(lpUserID, enType, ref udwMonitorID, ref pstFindLimit, ref pstList);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo) => _NETDEV_FindNextACSAttendanceLog.Invoke(lpFindHandle, ref pstACSLogInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo) => _NETDEV_FindNextACSPermissionGroupInfo.Invoke(lpFindHandle, ref pstACSPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => _NETDEV_FindNextACSPersonBlackListInfo.Invoke(lpFindHandle, ref pstBlackListInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo) => _NETDEV_FindNextACSPersonInfo.Invoke(lpFindHandle, ref pstACSPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo) => _NETDEV_FindNextACSVisitLog.Invoke(lpFindHandle, ref pstACSLogInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextCloudDevInfoEx(IntPtr lpFindHandle, ref NETDEV_CLOUD_DEV_BASIC_INFO_S pstDevInfo) => _NETDEV_FindNextCloudDevInfoEx.Invoke(lpFindHandle, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_FindNextDevChn.Invoke(lpFindHandle, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo) => _NETDEV_FindNextDevInfo.Invoke(lpFindHandle, ref pstDevBasicInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo) => _NETDEV_FindNextFaceRecordDetail.Invoke(lpFindHandle, ref pstRecordInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData) => _NETDEV_FindNextFile.Invoke(lpFindHandle, ref lpFindData);
        int IItsNetDevSdkProxy.NETDEV_FindNextMonitorDevResult(IntPtr lpFindHandle, ref NETDEV_MONITOR_DEV_RESULT_INFO_S pstMonitorDevResultInfo) => _NETDEV_FindNextMonitorDevResult.Invoke(lpFindHandle, ref pstMonitorDevResultInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats) => _NETDEV_FindNextMonitorStatusInfo.Invoke(lpFindHandle, ref pstMonitorStats);
        int IItsNetDevSdkProxy.NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo) => _NETDEV_FindNextOrgInfo.Invoke(lpFindHandle, ref pstOrgInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus) => _NETDEV_FindNextPermStatusInfo.Invoke(lpFindHandle, ref pstACSPermStatus);
        int IItsNetDevSdkProxy.NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo) => _NETDEV_FindNextPersonInfo.Invoke(lpFindHandle, ref pstPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo) => _NETDEV_FindNextPersonLibInfo.Invoke(lpFindHandle, ref pstPersonLibInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_FindNextPersonMonitorInfo.Invoke(lpFindHandle, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => _NETDEV_FindNextVehicleLibInfo.Invoke(lpFindHandle, ref pstVehicleLibInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo) => _NETDEV_FindNextVehicleMemberDetail.Invoke(lpFindHandle, ref pstVehicleMemberInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo) => _NETDEV_FindNextVehicleMonitorInfo.Invoke(lpFindHandle, ref pstVehicleMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo) => _NETDEV_FindNextVehicleRecordInfo.Invoke(lpFindHandle, ref pstRecordInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond) => _NETDEV_FindOrgInfoList.Invoke(lpUserID, ref pstFindCond);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPermStatusList(IntPtr lpUserID, ref uint udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindPermStatusList.Invoke(lpUserID, ref udwPermGroupID, ref pstQueryInfo, ref pstResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo) => _NETDEV_FindPersonInfoList.Invoke(lpUserID, udwPersonLibID, ref pstQueryInfo, ref pstQueryResultInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPersonLibList(IntPtr lpUserID) => _NETDEV_FindPersonLibList.Invoke(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindPersonMonitorList(IntPtr lpUserID, uint udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo) => _NETDEV_FindPersonMonitorList.Invoke(lpUserID, udwChannelID, ref pstQueryInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleLibList(IntPtr lpUserID) => _NETDEV_FindVehicleLibList.Invoke(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList) => _NETDEV_FindVehicleMemberDetailList.Invoke(lpUserID, udwVehicleLibID, ref pstFindCond, ref pstDBMemberList);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleMonitorList(IntPtr lpUserID) => _NETDEV_FindVehicleMonitorList.Invoke(lpUserID);
        IntPtr IItsNetDevSdkProxy.NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => _NETDEV_FindVehicleRecordInfoList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        int IItsNetDevSdkProxy.NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => _NETDEV_GetACSPersonBlackList.Invoke(lpUserID, ref pstBlackListInfo);
        int IItsNetDevSdkProxy.NETDEV_GetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => _NETDEV_GetACSPersonPermission.Invoke(lpUserID, udwPersonID, ref pstPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate) => _NETDEV_GetBitRate.Invoke(lpRealHandle, ref pdwBitRate);
        int IItsNetDevSdkProxy.NETDEV_GetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled) => _NETDEV_GetBuiltinIndicatorCtrl.Invoke(lpFindHandle, ref pstuCarportControlled);
        int IItsNetDevSdkProxy.NETDEV_GetChnDetailByChnType(IntPtr lpUserID, int dwChnID, int dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetChnDetailByChnType.Invoke(lpUserID, dwChnID, dwChnType, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetChnType(IntPtr lpUserID, int dwChnID, ref int pdwChnType) => _NETDEV_GetChnType.Invoke(lpUserID, dwChnID, ref pdwChnType);
        int IItsNetDevSdkProxy.NETDEV_GetCloudDevInfoByName(IntPtr lpUserID, string pszRegisterCode, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo) => _NETDEV_GetCloudDevInfoByName.Invoke(lpUserID, pszRegisterCode, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetCloudDevInfoByRegCode(IntPtr lpUserID, string pszRegisterName, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo) => _NETDEV_GetCloudDevInfoByRegCode.Invoke(lpUserID, pszRegisterName, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetCompassInfo(IntPtr lpUserID, int dwChannelID, ref float fCompassInfo) => _NETDEV_GetCompassInfo.Invoke(lpUserID, dwChannelID, ref fCompassInfo);
        int IItsNetDevSdkProxy.NETDEV_GetConfigFile(IntPtr lpUserID, string strConfigPath) => _NETDEV_GetConfigFile.Invoke(lpUserID, strConfigPath);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig1.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig2.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig3.Invoke(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig4.Invoke(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig5.Invoke(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig6.Invoke(lpUserID, dwChannelID, dwCommand, lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PTZ_STATUS_S lpInBuffer, int dwInBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig7.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig8.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig9.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigA.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigB.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigC.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigD.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigE.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigQ.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigF.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigG.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigH.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigI.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigJ.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigK.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigL.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigM.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigN.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ITS_PARKING_DETECTION_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigO.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigP.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceCapability(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CAP_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDeviceCapability1.Invoke(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceCapability(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_CAP_EX_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDeviceCapability2.Invoke(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo) => _NETDEV_GetDeviceInfo.Invoke(lpUserID, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, int dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo) => _NETDEV_GetDeviceInfo_V30.Invoke(lpUserID, dwDevID, ref pstDevInfo);
        int IItsNetDevSdkProxy.NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, uint udwRecordID, uint udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo) => _NETDEV_GetFaceRecordImageInfo.Invoke(lpUserID, udwRecordID, udwFaceImageType, ref pstFileInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, string szSaveFileName, int dwFormat) => _NETDEV_GetFileByName.Invoke(lpUserID, ref pstPlayBackInfo, szSaveFileName, dwFormat);
        IntPtr IItsNetDevSdkProxy.NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, int dwFormat) => _NETDEV_GetFileByTime.Invoke(lpUserID, ref pstPlayBackCond, pszSaveFileName, dwFormat);
        int IItsNetDevSdkProxy.NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate) => _NETDEV_GetFrameRate.Invoke(lpRealHandle, ref pdwFrameRate);
        int IItsNetDevSdkProxy.NETDEV_GetGeolocationInfo(IntPtr lpUserID, int dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo) => _NETDEV_GetGeolocationInfo.Invoke(lpUserID, dwChannelID, ref pstGPSInfo);
        int IItsNetDevSdkProxy.NETDEV_GetLastError() => _NETDEV_GetLastError.Invoke();
        int IItsNetDevSdkProxy.NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum) => _NETDEV_GetLostPacketRate.Invoke(lpRealHandle, ref pulRecvPktNum, ref pulLostPktNum);
        int IItsNetDevSdkProxy.NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref int dwVolume) => _NETDEV_GetMicVolume.Invoke(lpPlayHandle, ref dwVolume);
        int IItsNetDevSdkProxy.NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList) => _NETDEV_GetMonitorCapacity.Invoke(lpUserID, ref pstCapacityInfo, ref pstCapacityList);
        int IItsNetDevSdkProxy.NETDEV_GetMonitorProgress(IntPtr lpUserID, ref uint pudwProgressRate) => _NETDEV_GetMonitorProgress.Invoke(lpUserID, ref pudwProgressRate);
        int IItsNetDevSdkProxy.NETDEV_GetPARKVersion(byte[] strVersion) => _NETDEV_GetPARKVersion.Invoke(strVersion);
        int IItsNetDevSdkProxy.NETDEV_GetPersonLibCapacity(IntPtr lpUserID, int dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList) => _NETDEV_GetPersonLibCapacity.Invoke(lpUserID, dwTimeOut, ref pstCapacityList);
        int IItsNetDevSdkProxy.NETDEV_GetPersonMemberInfo(IntPtr lpUserID, uint udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo) => _NETDEV_GetPersonMemberInfo.Invoke(lpUserID, udwPersonID, ref pstPersonInfo);
        int IItsNetDevSdkProxy.NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_GetPersonMonitorRuleInfo.Invoke(lpUserID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_GetPTZPresetList(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer) => _NETDEV_GetPTZPresetList.Invoke(lpUserID, dwChannelID, ref lpOutBuffer);
        int IItsNetDevSdkProxy.NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight) => _NETDEV_GetResolution.Invoke(lpRealHandle, ref pdwWidth, ref pdwHeight);
        int IItsNetDevSdkProxy.NETDEV_GetSDKVersion() => _NETDEV_GetSDKVersion.Invoke();
        int IItsNetDevSdkProxy.NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, uint udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo) => _NETDEV_GetSinglePermGroupInfo.Invoke(lpUserID, udwPermissionGroupID, ref pstAcsPerssionInfo);
        int IItsNetDevSdkProxy.NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref int pdwVolume) => _NETDEV_GetSoundVolume.Invoke(lpPlayHandle, ref pdwVolume);
        int IItsNetDevSdkProxy.NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, uint udwSize, IntPtr pszdata) => _NETDEV_GetSystemPicture.Invoke(lpUserID, pszURL, udwSize, pszdata);
        int IItsNetDevSdkProxy.NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => _NETDEV_GetSystemTimeCfg.Invoke(lpUserID, ref pstSystemTimeInfo);
        int IItsNetDevSdkProxy.NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, int dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo) => _NETDEV_GetTimeTemplateInfo.Invoke(lpUserID, dwTemplateID, ref pstTimeTemplateInfo);
        int IItsNetDevSdkProxy.NETDEV_GetTimeTemplateList(IntPtr lpUserID, int dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList) => _NETDEV_GetTimeTemplateList.Invoke(lpUserID, dwTamplateType, ref pstTemplateList);
        int IItsNetDevSdkProxy.NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic) => _NETDEV_GetTrafficStatistic.Invoke(lpUserID, ref pstStatisticCond, ref pstTrafficStatistic);
        int IItsNetDevSdkProxy.NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => _NETDEV_GetUpnpNatState.Invoke(lpUserID, ref pstNatState);
        int IItsNetDevSdkProxy.NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList) => _NETDEV_GetUserDetailList.Invoke(lpUserID, pstUserDetailList);
        int IItsNetDevSdkProxy.NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => _NETDEV_GetVehicleMonitorInfo.Invoke(lpUserID, udwID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, uint udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo) => _NETDEV_GetVehicleRecordImageInfo.Invoke(lpUserID, udwRecordID, ref pstFileInfo);
        int IItsNetDevSdkProxy.NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => _NETDEV_GetVideoEffect.Invoke(lpRealHandle, ref pstImageInfo);
        int IItsNetDevSdkProxy.NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt) => _NETDEV_GetVideoEncodeFmt.Invoke(lpRealHandle, ref pdwVideoEncFmt);
        int IItsNetDevSdkProxy.NETDEV_ImportBlackWhiteListFile(IntPtr lpFindHandle, string pcFile) => _NETDEV_ImportBlackWhiteListFile.Invoke(lpFindHandle, pcFile);
        int IItsNetDevSdkProxy.NETDEV_Init() => _NETDEV_Init.Invoke();
        int IItsNetDevSdkProxy.NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, int dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam) => _NETDEV_InputVoiceData.Invoke(lpUserID, lpDataBuf, dwDataLen, ref pstVoiceParam);
        IntPtr IItsNetDevSdkProxy.NETDEV_Login(string szDevIP, short wDevPort, string szUserName, string szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo) => _NETDEV_Login.Invoke(szDevIP, wDevPort, szUserName, szPassword, ref pstDevInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_LoginCloud(string pszCloudSrvUrl, string pszUserName, string pszPassWord) => _NETDEV_LoginCloud.Invoke(pszCloudSrvUrl, pszUserName, pszPassWord);
        IntPtr IItsNetDevSdkProxy.NETDEV_LoginCloudDevice_V30(IntPtr lpUserID, ref NETDEV_CLOUD_DEV_LOGIN_INFO_S pstCloudInfo) => _NETDEV_LoginCloudDevice_V30.Invoke(lpUserID, ref pstCloudInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo) => _NETDEV_Login_V30.Invoke(ref pstDevLoginInfo, ref pstSELogInfo);
        int IItsNetDevSdkProxy.NETDEV_Logout(IntPtr lpUserID) => _NETDEV_Logout.Invoke(lpUserID);
        int IItsNetDevSdkProxy.NETDEV_MakeKeyFrame(IntPtr lpUserID, int dwChannelID, int dwStreamType) => _NETDEV_MakeKeyFrame.Invoke(lpUserID, dwChannelID, dwStreamType);
        int IItsNetDevSdkProxy.NETDEV_MicVolumeControl(IntPtr lpPlayHandle, int dwVolume) => _NETDEV_MicVolumeControl.Invoke(lpPlayHandle, dwVolume);
        int IItsNetDevSdkProxy.NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => _NETDEV_ModifyACSPersonBlackList.Invoke(lpUserID, ref pstBlackListInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo) => _NETDEV_ModifyACSPersonPermissionGroup.Invoke(lpUserID, ref pstPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyAllowVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern) => _NETDEV_ModifyAllowVehicleRecord.Invoke(lpFindHandle, ref pstVehicleRecordExtern);
        int IItsNetDevSdkProxy.NETDEV_ModifyBlockVehicleRecord(IntPtr lpFindHandle, ref NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecordExtern) => _NETDEV_ModifyBlockVehicleRecord.Invoke(lpFindHandle, ref pstVehicleRecordExtern);
        int IItsNetDevSdkProxy.NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName) => _NETDEV_ModifyDeviceName.Invoke(lpUserID, strDeviceName);
        int IItsNetDevSdkProxy.NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo) => _NETDEV_ModifyOrgInfo.Invoke(lpUserID, ref pstOrgInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => _NETDEV_ModifyPersonInfo.Invoke(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int IItsNetDevSdkProxy.NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList) => _NETDEV_ModifyPersonLibInfo.Invoke(lpUserID, ref pstPersonLibList);
        int IItsNetDevSdkProxy.NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo) => _NETDEV_ModifyUser.Invoke(lpUserID, pstUserInfo);
        int IItsNetDevSdkProxy.NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList) => _NETDEV_ModifyVehicleLibInfo.Invoke(lpUserID, ref pstVehicleLibList);
        int IItsNetDevSdkProxy.NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => _NETDEV_ModifyVehicleMemberInfo.Invoke(lpUserID, udwVehicleLibID, ref pstVehicleMemberList, ref pstResultList);
        int IItsNetDevSdkProxy.NETDEV_OpenMic(IntPtr lpPlayHandle) => _NETDEV_OpenMic.Invoke(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_OpenSound(IntPtr lpRealHandle) => _NETDEV_OpenSound.Invoke(lpRealHandle);
        IntPtr IItsNetDevSdkProxy.NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo) => _NETDEV_PlayBackByName.Invoke(lpUserID, ref pstPlayBackInfo);
        IntPtr IItsNetDevSdkProxy.NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo) => _NETDEV_PlayBackByTime.Invoke(lpUserID, ref pstPlayBackInfo);
        int IItsNetDevSdkProxy.NETDEV_PlayBackControl(IntPtr lpPlayHandle, int dwControlCode, ref long pdwBuffer) => _NETDEV_PlayBackControl.Invoke(lpPlayHandle, dwControlCode, ref pdwBuffer);
        int IItsNetDevSdkProxy.NETDEV_PlaySound(IntPtr lpRealHandle) => _NETDEV_PlaySound.Invoke(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_PTZCalibrate(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo) => _NETDEV_PTZCalibrate.Invoke(lpUserID, dwChannelID, ref pstOrientationInfo);
        int IItsNetDevSdkProxy.NETDEV_PTZControl(IntPtr lpPlayHandle, int dwPTZCommand, int dwSpeed) => _NETDEV_PTZControl.Invoke(lpPlayHandle, dwPTZCommand, dwSpeed);
        int IItsNetDevSdkProxy.NETDEV_PTZControl_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCommand, int dwSpeed) => _NETDEV_PTZControl_Other.Invoke(lpUserID, dwChannelID, dwPTZCommand, dwSpeed);
        int IItsNetDevSdkProxy.NETDEV_PTZCruise_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo) => _NETDEV_PTZCruise_Other.Invoke(lpUserID, dwChannelID, dwPTZCruiseCmd, ref pstCruiseInfo);
        int IItsNetDevSdkProxy.NETDEV_PTZGetCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList) => _NETDEV_PTZGetCruise.Invoke(lpUserID, dwChannelID, ref pstCruiseList);
        int IItsNetDevSdkProxy.NETDEV_PTZGetTrackCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo) => _NETDEV_PTZGetTrackCruise.Invoke(lpUserID, dwChannelID, ref pstTrackCruiseInfo);
        int IItsNetDevSdkProxy.NETDEV_PTZPreset(IntPtr lpPlayHandle, int dwPTZPresetCmd, string pszPresetName, int dwPresetID) => _NETDEV_PTZPreset.Invoke(lpPlayHandle, dwPTZPresetCmd, pszPresetName, dwPresetID);
        int IItsNetDevSdkProxy.NETDEV_PTZPreset_Other(IntPtr lpUserID, int dwChannelID, int dwPTZPresetCmd, byte[] szPresetName, int dwPresetID) => _NETDEV_PTZPreset_Other.Invoke(lpUserID, dwChannelID, dwPTZPresetCmd, szPresetName, dwPresetID);
        int IItsNetDevSdkProxy.NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea) => _NETDEV_PTZSelZoomIn_Other.Invoke(lpUserID, dwChannelID, ref pstPtzOperateArea);
        int IItsNetDevSdkProxy.NETDEV_PTZTrackCruise(IntPtr lpUserID, int dwChannelID, int dwPTZTrackCruiseCmd, string pszTrackCruiseName) => _NETDEV_PTZTrackCruise.Invoke(lpUserID, dwChannelID, dwPTZTrackCruiseCmd, pszTrackCruiseName);
        int IItsNetDevSdkProxy.NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList) => _NETDEV_QueryVideoChlDetailList.Invoke(lpUserID, ref pdwChlCount, pstVideoChlList);
        IntPtr IItsNetDevSdkProxy.NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => _NETDEV_RealPlay.Invoke(lpUserID, ref pstPreviewInfo, cbPlayDataCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_Reboot(IntPtr lpUserID) => _NETDEV_Reboot.Invoke(lpUserID);
        int IItsNetDevSdkProxy.NETDEV_ResetLostPacketRate(IntPtr lpRealHandle) => _NETDEV_ResetLostPacketRate.Invoke(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_RestoreConfig(IntPtr lpUserID) => _NETDEV_RestoreConfig.Invoke(lpUserID);
        int IItsNetDevSdkProxy.NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, int dwFormat) => _NETDEV_SaveRealData.Invoke(lpRealHandle, szSaveFileName, dwFormat);
        int IItsNetDevSdkProxy.NETDEV_SetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => _NETDEV_SetACSPersonPermission.Invoke(lpUserID, udwPersonID, ref pstPermissionInfo);
        int IItsNetDevSdkProxy.NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetAlarmCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetAlarmCallBack_V30.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetAlarmFGCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetBuiltinIndicatorCtrl(IntPtr lpFindHandle, ref NETDEV_CARPORT_CONTROLLED_S pstuCarportControlled) => _NETDEV_SetBuiltinIndicatorCtrl.Invoke(lpFindHandle, ref pstuCarportControlled);
        int IItsNetDevSdkProxy.NETDEV_SetConfigFile(IntPtr lpUserID, string strConfigPath) => _NETDEV_SetConfigFile.Invoke(lpUserID, strConfigPath);
        int IItsNetDevSdkProxy.NETDEV_SetConnectTime(int dwWaitTime, int dwTrytimes) => _NETDEV_SetConnectTime.Invoke(dwWaitTime, dwTrytimes);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref int index, int dwInBufferSize) => _NETDEV_SetDevConfig1.Invoke(lpUserID, dwChannelID, dwCommand, ref index, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig2.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig3.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig4.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig5.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize) => _NETDEV_SetDevConfig6.Invoke(lpUserID, dwChannelID, dwCommand, lpInBuffer, ref dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig7.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig8.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig9.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigA.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigB.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigC.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigD.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigE.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigF.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize) => _NETDEV_SetDevConfigG.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigH.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_INFORELEASE_CFG_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigI.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_OSD_CONTENT_STYLE_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigJ.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int IItsNetDevSdkProxy.NETDEV_setDeviceLedCfg(IntPtr lpFindHandle, ref NETDEV_LED_LIST_CFG_S pstLedListCfgs) => _NETDEV_setDeviceLedCfg.Invoke(lpFindHandle, ref pstLedListCfgs);
        int IItsNetDevSdkProxy.NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect) => _NETDEV_SetDigitalZoom.Invoke(lpRealHandle, hWnd, pstRect);
        int IItsNetDevSdkProxy.NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData) => _NETDEV_SetDiscoveryCallBack.Invoke(cbDiscoveryCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData) => _NETDEV_SetExceptionCallBack.Invoke(cbExceptionCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData) => _NETDEV_SetFaceSnapshotCallBack.Invoke(lpUserID, cbFaceSnapshotCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetIVAEnable(IntPtr lpUserID, int dwEnableIVA) => _NETDEV_SetIVAEnable.Invoke(lpUserID, dwEnableIVA);
        int IItsNetDevSdkProxy.NETDEV_SetIVAShowParam(int dwShowParam) => _NETDEV_SetIVAShowParam.Invoke(dwShowParam);
        int IItsNetDevSdkProxy.NETDEV_SetLogPath(string strLogPath) => _NETDEV_SetLogPath.Invoke(strLogPath);
        int IItsNetDevSdkProxy.NETDEV_SetOutputSwitchStatusCfg(IntPtr lpFindHandle) => _NETDEV_SetOutputSwitchStatusCfg.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_SetParkingStatusCB(IntPtr lpFindHandle, NETDEV_PARKING_STATUS_PF pfnParkStatusCBFun, IntPtr lpUserData) => _NETDEV_SetParkingStatusCB.Invoke(lpFindHandle, pfnParkStatusCBFun, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetParkStatusCallBack(IntPtr lpUserID, NETDEV_ParkStatusReportCallBack_PF cbParkStatusReportCallBack, IntPtr lpUserData) => _NETDEV_SetParkStatusCallBack.Invoke(lpUserID, cbParkStatusReportCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData) => _NETDEV_SetPassengerFlowStatisticCallBack.Invoke(lpUserID, cbPassengerFlowStatisticCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetPersonAlarmCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_SetPersonMonitorRuleInfo.Invoke(lpUserID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_SetPictureFluency(IntPtr lpPlayHandle, int dwFluency) => _NETDEV_SetPictureFluency.Invoke(lpPlayHandle, dwFluency);
        int IItsNetDevSdkProxy.NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, int bContinue, IntPtr lpUserData) => _NETDEV_SetPlayDataCallBack.Invoke(lpRealHandle, cbPlayDataCallBack, bContinue, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, ref NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, int bContinue, IntPtr lpUserData) => _NETDEV_SetPlayDecodeVideoCB.Invoke(lpRealHandle, ref cbPlayDecodeVideoCallBack, bContinue, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData) => _NETDEV_SetPlayDisplayCB.Invoke(lpRealHandle, cbPlayDisplayCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetPlayParseCB(IntPtr lpRealHandle, ref NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF cbPlayParseCallBack, int bContinue, IntPtr lpUserData) => _NETDEV_SetPlayParseCB.Invoke(lpRealHandle, ref cbPlayParseCallBack, bContinue, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetRenderScale(IntPtr lpRealHandle, int enRenderScale) => _NETDEV_SetRenderScale.Invoke(lpRealHandle, enRenderScale);
        int IItsNetDevSdkProxy.NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout) => _NETDEV_SetRevTimeOut.Invoke(ref pstRevTimeout);
        int IItsNetDevSdkProxy.NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetStructAlarmCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => _NETDEV_SetSystemTimeCfg.Invoke(lpUserID, ref pstSystemTimeInfo);
        int IItsNetDevSdkProxy.NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => _NETDEV_SetUpnpNatState.Invoke(lpUserID, ref pstNatState);
        int IItsNetDevSdkProxy.NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetVehicleAlarmCallBack.Invoke(lpUserID, cbVehicleAlarmMessCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => _NETDEV_SetVehicleMonitorInfo.Invoke(lpUserID, udwID, ref pstMonitorInfo);
        int IItsNetDevSdkProxy.NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => _NETDEV_SetVideoEffect.Invoke(lpRealHandle, ref pstImageInfo);
        int IItsNetDevSdkProxy.NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, int dwVolume) => _NETDEV_SoundVolumeControl.Invoke(lpPlayHandle, dwVolume);
        IntPtr IItsNetDevSdkProxy.NETDEV_StartInputVoiceSrv(IntPtr lpUserID, int dwChannelID) => _NETDEV_StartInputVoiceSrv.Invoke(lpUserID, dwChannelID);
        IntPtr IItsNetDevSdkProxy.NETDEV_StartPicStream(IntPtr lpUserID, IntPtr hPlayWnd, bool bReTran, string pcReTranIP, NETDEV_PIC_UPLOAD_PF pfnPicDataCBFun, IntPtr lpUserData) => _NETDEV_StartPicStream.Invoke(lpUserID, hPlayWnd, bReTran, pcReTranIP, pfnPicDataCBFun, lpUserData);
        IntPtr IItsNetDevSdkProxy.NETDEV_StartVoiceCom(IntPtr lpUserID, int dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => _NETDEV_StartVoiceCom.Invoke(lpUserID, dwChannelID, cbPlayDataCallBack, lpUserData);
        int IItsNetDevSdkProxy.NETDEV_StopGetFile(IntPtr lpPlayHandle) => _NETDEV_StopGetFile.Invoke(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle) => _NETDEV_StopInputVoiceSrv.Invoke(lpVoiceComHandle);
        int IItsNetDevSdkProxy.NETDEV_StopPicStream(IntPtr lpPlayHandle) => _NETDEV_StopPicStream.Invoke(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_StopPlayBack(IntPtr lpPlayHandle) => _NETDEV_StopPlayBack.Invoke(lpPlayHandle);
        int IItsNetDevSdkProxy.NETDEV_StopPlaySound(IntPtr lpRealHandle) => _NETDEV_StopPlaySound.Invoke(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_StopRealPlay(IntPtr lpRealHandle) => _NETDEV_StopRealPlay.Invoke(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_StopSaveRealData(IntPtr lpRealHandle) => _NETDEV_StopSaveRealData.Invoke(lpRealHandle);
        int IItsNetDevSdkProxy.NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle) => _NETDEV_StopVoiceCom.Invoke(lpVoiceComHandle);
        int IItsNetDevSdkProxy.NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo) => _NETDEV_SubscibeLapiAlarm.Invoke(lpUserID, ref pstSubInfo, ref pstSubSuccInfo);
        int IItsNetDevSdkProxy.NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo) => _NETDEV_SubscribeSmart.Invoke(lpUserID, ref pstSubscribeInfo, ref pstSmartInfo);
        int IItsNetDevSdkProxy.NETDEV_Trigger(IntPtr lpFindHandle) => _NETDEV_Trigger.Invoke(lpFindHandle);
        int IItsNetDevSdkProxy.NETDEV_TriggerSync(IntPtr lpFindHandle, ref IntPtr ppstPicData) => _NETDEV_TriggerSync.Invoke(lpFindHandle, ref ppstPicData);
        int IItsNetDevSdkProxy.NETDEV_UnSubLapiAlarm(IntPtr lpUserID, uint udwID) => _NETDEV_UnSubLapiAlarm.Invoke(lpUserID, udwID);
        int IItsNetDevSdkProxy.NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo) => _NETDEV_UnsubscribeSmart.Invoke(lpUserID, ref pstSmartInfo);
        #endregion 显示实现
    }
}
