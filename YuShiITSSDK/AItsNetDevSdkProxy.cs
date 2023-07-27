using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpRealHandle"></param>
        /// <returns></returns>
        [Obsolete("SDK中未找到对应函数")]
        Int32 NETDEV_PlaySound(IntPtr lpRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpRealHandle"></param>
        /// <returns></returns>
        [Obsolete("SDK中未找到对应函数")]
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpUserID"></param>
        /// <param name="pszRegisterCode"></param>
        /// <param name="pstDevInfo"></param>
        /// <returns></returns>
        [Obsolete("SDK中未找到对应函数")]
        Int32 NETDEV_GetCloudDevInfoByName(IntPtr lpUserID, String pszRegisterCode, ref NETDEV_CLOUD_DEV_INFO_S pstDevInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpUserID"></param>
        /// <param name="pszRegisterName"></param>
        /// <param name="pstDevInfo"></param>
        /// <returns></returns>
        [Obsolete("SDK中未找到对应函数")]
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
}
