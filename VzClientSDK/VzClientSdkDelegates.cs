using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 统一通知回调
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="pUserData"></param>
    /// <param name="eNotify"></param>
    /// <param name="pStrDetail"></param>
    public delegate void VZLPRC_COMMON_NOTIFY_CALLBACK(int handle, IntPtr pUserData, VZ_LPRC_COMMON_NOTIFY eNotify, string pStrDetail);
    /// <summary>
    /// 车牌信息回调
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="pUserData"></param>
    /// <param name="pResult"></param>
    /// <param name="uNumPlates"></param>
    /// <param name="eResultType"></param>
    /// <param name="pImgFull"></param>
    /// <param name="pImgPlateClip"></param>
    /// <returns></returns>
    public delegate int VZLPRC_PLATE_INFO_CALLBACK(int handle, IntPtr pUserData,
                                                IntPtr pResult, uint uNumPlates,
                                                VZ_LPRC_RESULT_TYPE eResultType,
                                                IntPtr pImgFull,
                                                IntPtr pImgPlateClip);

    /**
    *  @brief  通过该回调函数获得实时图像数据
    *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
    *  @param  [IN] pUserData	回调函数的上下文
    *  @param  [IN] pFrame		图像帧信息，详见结构体定义VzYUV420P
    *  @return 0表示成功，-1表示失败
    *  @ingroup group_callback
    */
    public delegate void VZLPRC_VIDEO_FRAME_CALLBACK(int handle, IntPtr pUserData, ref VzYUV420P pFrame);

    /**
    *  @brief 通过该回调函数获得透明通道接收的数据
    *  @param  [IN] nSerialHandle VzLPRClient_SerialStart返回的句柄
    *  @param  [IN] pStrIPAddr	设备IP地址
    *  @param  [IN] usPort1		设备端口号
    *  @param  [IN] usPort2		预留
    *  @param  [IN] pUserData	回调函数上下文
    *  @ingroup group_global
    */
    public delegate int VZDEV_SERIAL_RECV_DATA_CALLBACK(int nSerialHandle, IntPtr pRecvData, int uRecvSize, IntPtr pUserData);
    /// <summary>
    /// 查询回调
    /// </summary>
    /// <param name="type"></param>
    /// <param name="pLP"></param>
    /// <param name="pCustomer"></param>
    /// <param name="pUserData"></param>
    public delegate void VZLPRC_WLIST_QUERY_CALLBACK(VZLPRC_WLIST_CB_TYPE type, IntPtr pLP,
                                                     IntPtr pCustomer,
                                                     IntPtr pUserData);
    /**
    *  @brief 通过该回调函数获得找到的设备基本信息
    *  @param  [IN] pStrDevName 设备名称
    *  @param  [IN] pStrIPAddr	设备IP地址
    *  @param  [IN] usPort1		设备端口号
    *  @param  [IN] usPort2		预留
    *  @param  [IN] pUserData	回调函数上下文
    *  @ingroup group_callback
    */
    public delegate void VZLPRC_FIND_DEVICE_CALLBACK_EX(string pStrDevName, string pStrIPAddr, ushort usPort1, ushort usPort2, uint SL, uint SH, string netmask, string gateway, IntPtr pUserData);
    /// <summary>
    /// 视频帧回调
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="pUserData"></param>
    /// <param name="pFrame"></param>
    public delegate void VZLPRC_VIDEO_FRAME_CALLBACK_EX(int handle, IntPtr pUserData, ref VZ_LPRC_IMAGE_INFO pFrame);

    /**
    *  @brief 喊话广播消息
    *  @param [OUT] state 状态值
    *  @param [OUT] error_msg	错误信息
    *  @param [OUT] pUserData 用户自定义数据
    */
    public delegate void VZLPRC_REQUEST_TALK_CALLBACK(int handle, int state, string error_msg, IntPtr pUserData);

    /**
    *  @brief GPIO输入回调函数
    *  @param [IN] nGPIOId GPIO输入ID
    *  @param [IN] nVal	GPIO输入值
    *  @param [IN] pUserData 用户自定义数据
    */
    public delegate void VZLPRC_GPIO_RECV_CALLBACK(int handle, int nGPIOId, int nVal, IntPtr pUserData);

    internal class DCreater
    {
        /// <summary>
        /// 复制内存
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <param name="Length"></param>
        public delegate void CopyMemory(IntPtr Destination, IntPtr Source, int Length);

        /**
        *  @brief 全局初始化，在所有接口调用之前调用
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_Setup();

        /**
        *  @brief 全局释放
        */
        public delegate void VzLPRClient_Cleanup();

        /**
        *  @brief 设置设备连接反馈结果相关的回调函数
        *  @param  [IN] func 设备连接结果和状态，通过该回调函数返回
        *  @param [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 打开一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @param [IN] wPort 设备的端口号
        *  @param  [IN] pStrUserName 访问设备所需用户名
        *  @param [IN] pStrPassword 访问设备所需密码
        *  @return 返回设备的操作句柄，当打开失败时，返回-1
        */
        public delegate int VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword);

        /**
         *  @brief 打开一个设备
         *  @param  [IN] pStrIP 设备的IP地址
         *  @param  [IN] wPort 设备的端口号
         *  @param  [IN] pStrUserName 访问设备所需用户名
         *  @param  [IN] pStrPassword 访问设备所需密码
         *  @param  [IN] wRtspPort 流媒体的端口号,默认为8557(如果为0表示使用默认端口）
         *  @param  [IN] network_type 网络类型(0局域网,1外网-PDNS方式)
         *  @param  [IN] sn 设备序列号
         *  @return 返回设备的操作句柄，当打开失败时，返回-1
         */
        public delegate int VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn);

        /**
        *  @brief 关闭一个设备
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_Close(int handle);

        /**
        *  @brief 通过IP地址关闭一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_CloseByIP(string pStrIP);

        /**
        *  @brief 获取连接状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param[IN/OUT] pStatus 输入获取状态的变量地址，输出内容为 1已连上，0未连上
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_IsConnected(int handle, ref byte pStatus);

        /**
        *  @brief 根据句柄获取设备的IP
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] ip  相机IP
        *  @param [IN] max_count IP传入长度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetDeviceIP(int handle, ref byte ip, int max_count);

        /**
        *  @brief 播放实时视频
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 播放句柄，小于0表示失败
        */
        public delegate int VzLPRClient_StartRealPlay(int handle, IntPtr hWnd);

        /**
        *  @brief 停止正在播放的窗口上的实时视频
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_StopRealPlay(int hRealHandle);

        /**
        *  @brief 设置识别结果的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_SetPlateInfoCallBack(int handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage);

        /**
        *  @brief 设置实时图像数据的回调函数
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetVideoFrameCallBack(int handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData);

        /**
        *  @brief 发送软件触发信号，强制处理当前时刻的数据并输出结果
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_ForceTrigger(int handle);

        /**
        *  @brief 设置虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_SetVirtualLoop(int handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_GetVirtualLoop(int handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的识别区域
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pROI 识别区域的结构体指针
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetRegionOfInterestEx(int handle, ref VZ_LPRC_ROI_EX pROI);

        /**
        *  @brief 获取已设置的预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pProvInfo 预设省份信息指针
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_GetSupportedProvinces(int handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo);

        /**
        *  @brief 设置预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nIndex 设置预设省份的序号，序号需要参考VZ_LPRC_PROVINCE_INFO::strProvinces中的顺序，从0开始，如果小于0，则表示不设置预设省份
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_PresetProvinceIndex(int handle, int nIndex);

        /**
        *  @brief 将图像保存为JPEG到指定路径
        *  @param  [IN] pImgInfo 图像结构体，目前只支持默认的格式，即ImageFormatRGB
        *  @param  [IN] pFullPathName 设带绝对路径和JPG后缀名的文件名字符串
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return 0表示成功，-1表示失败
        *  @note   给定的文件名中的路径需要存在
        *  @ingroup group_global
        */
        public delegate int VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality);

        /**
        *  @brief 读出设备序列号，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pSN 用于存放读到的设备序列号，详见定义 VZ_DEV_SERIAL_NUM
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetSerialNumber(int handle, ref VZ_DEV_SERIAL_NUM pSN);

        /**
        *  @brief 保存正在播放的视频的当前帧的截图到指定路径
        *  @param  [IN] nPlayHandle 播放的句柄
        *  @param  [IN] pFullPathName 设带绝对路径和JPG后缀名的文件名字符串
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return 0表示成功，-1表示失败
        *  @note   使用的文件名中的路径需要存在
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetSnapShootToJpeg2(int nPlayHandle, string pFullPathName, int nQuality);

        /**
        *  @brief 开启透明通道
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] func 接收数据的回调函数
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *  @return 返回透明通道句柄，0表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SerialStart(int handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 透明通道发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @param [IN] pData 将要传输的数据块的首地址
        *  @param [IN] uSizeData 将要传输的数据块的字节数
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SerialSend(int nSerialHandle, IntPtr pData, int uSizeData);

        /**
        *  @brief 透明通道停止发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SerialStop(int nSerialHandle);

        /**
        *  @brief 设置IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] nOutput 将要设置的IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetIOOutput(int handle, int uChnId, int nOutput);

        /**
        *  @brief 获取IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] pOutput IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetIOOutput(int handle, int uChnId, ref int pOutput);

        /**
        *  @brief 获取GPIO的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] gpioIn 数据为0或1
        *  @param  [OUT] value 0代表短路，1代表开路
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetGPIOValue(int handle, int gpioIn, IntPtr value);

        /**
        *  @brief 根据ID获取车牌图片
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] id     车牌记录的ID
        *  @param  [IN] pdata  存储图片的内存
        *  @param  [IN][OUT] size 为传入传出值，传入为图片内存的大小，返回的是获取到jpg图片内存的大小
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_LoadImageById(int handle, int id, IntPtr pdata, IntPtr size);

        /**
        *  @brief 向白名单表导入客户和车辆记录
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] rowcount 记录的条数
        *  @param  [IN] pRowDatas 记录的内容数组的地址
        *  @param  [OUT] results 每条数据是否导入成功
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListImportRows(int handle,
                                                          uint rowcount,
                                                          ref VZ_LPR_WLIST_ROW pRowDatas,
                                                          ref VZ_LPR_WLIST_IMPORT_RESULT pResults);

        /**
        *  @brief 从数据库删除车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] strPlateID 车牌号码
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListDeleteVehicle(int handle, string strPlateID);

        /**
        *  @brief 清空数据库客户信息和车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListClearCustomersAndVehicles(int handle);

        /**
        *  @brief 获取白名单表中所有车辆信息记录的条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return >=0表示所有车辆信息记录的总数，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListGetVehicleCount(int handle, ref uint pCount,
                                                         ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 查询白名单表车辆记录数据
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pLoadCondition 查询条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListLoadVehicle(int handle,
                                                    ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition);

        /**
        *  @brief 设置白名单表和客户信息表的查询结果回调
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 查询结果回调函数
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListSetQueryCallBack(int handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 往白名单表中更新一个车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVehicle 将要更新的车辆信息，详见结构体定义VZ_LPR_WLIST_VEHICLE
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListUpdateVehicleByID(int handle, ref VZ_LPR_WLIST_VEHICLE pVehicle);

        /**
        *  @brief 查询白名单表客户和车辆记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pCount 记录的条数
        *  @param  [IN] search_constraints 搜索的条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        public delegate int VzLPRClient_WhiteListGetRowCount(int handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 设置LED控制模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] eCtrl 控制LED开关模式，详见定义 VZ_LED_CTRL
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetLEDLightControlMode(int handle, VZ_LED_CTRL eCtrl);
        /**
        *  @brief 获取LED当前亮度等级和最大亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pLevelNow 用于输出当前亮度等级的地址
        *  @param [OUT] pLevelMax 用于输出最高亮度等级的地址
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetLEDLightStatus(int handle, ref int pLevelNow, ref int pLevelMax);

        /**
        *  @brief 设置LED亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nLevel，LED亮度等级
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetLEDLightLevel(int handle, int nLevel);

        /**
        *  @brief 开始录像功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sFileName 录像文件的路径
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SaveRealData(int handle, string sFileName);

        /**
        *  @brief 停止录像
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_StopSaveRealData(int handle);

        /**
        *  @brief 开启脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetOfflineCheck(int handle);

        /**
        *  @brief 关闭脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_CancelOfflineCheck(int handle);

        /**
        *  @brief 开始查找设备
        *  @param  [IN] func 找到的设备通过该回调函数返回
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_global
        */
        public delegate int VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 停止查找设备
        *  @ingroup group_global
        */
        public delegate int VZLPRClient_StopFindDevice();

        /**
        *  @brief 根据起始时间和车牌关键字查询记录
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pStartTime 起始时间，格式如"2015-01-02 12:20:30"
        *  @param  [IN] pEndTime   起始时间，格式如"2015-01-02 19:20:30"
        *  @param  [IN] keyword    车牌号关键字, 如"川"
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @说明   通过回调返回数据，最多返回100条数据，超过时请调用分页查询的接口
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_QueryRecordByTimeAndPlate(int handle, string pStartTime, string pEndTime, string keyword);

        /**
        *  @brief 根据时间和车牌号查询记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pStartTime 起始时间，格式如"2015-01-02 12:20:30"
        *  @param  [IN] pEndTime   起始时间，格式如"2015-01-02 19:20:30"
        *  @param  [IN] keyword    车牌号关键字, 如"川"
        *  @return 返回值为0表示失败，大于0表示记录条数
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_QueryCountByTimeAndPlate(int handle, string pStartTime, string pEndTime, string keyword);

        /**
        *  @brief 根据时间和车牌号查询分页查询记录
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pStartTime 起始时间，格式如"2015-01-02 12:20:30"
        *  @param  [IN] pEndTime   起始时间，格式如"2015-01-02 19:20:30"
        *  @param  [IN] keyword    车牌号关键字, 如"川"
        *  @param  [IN] start      起始位置大于0,小于结束位置
        *  @param  [IN] end        结束位置大于0,大于起始位置，获取记录条数不能大于100
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_QueryPageRecordByTimeAndPlate(int handle, string pStartTime, string pEndTime, string keyword, int start, int end);

        /**
        *  @brief 设置查询车牌记录的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数，如果为NULL，则表示关闭该回调函数的功能
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetQueryPlateCallBack(int handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetOsdParam(int handle, IntPtr pParam);

        /**
        *  @brief 设置视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetOsdParam(int handle, IntPtr pParam);

        /**
        *  @brief 设置设备的日期时间
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDTInfo 将要设置的设备日期时间信息，详见定义 VZ_DATE_TIME_INFO
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetDateTime(int handle, IntPtr IntpDTInfo);

        /**
        *  @brief 读出用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pBuffer 用于存放读到的用户数据
        *  @param [IN] uSizeBuf 用户数据缓冲区的最小尺寸，不小于128字节
        *  @return 返回值为实际用户数据的字节数，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_ReadUserData(int handle, IntPtr pBuffer, uint uSizeBuf);

        /**
        *  @brief 写入用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pUserData 用户数据
        *  @param [IN] uSizeData 用户数据的长度，最大128字节
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_WriteUserData(int handle, IntPtr pUserData, uint uSizeData);

        /**
        *  @brief 将图像编码为JPEG，保存到指定内存
        *  @param  [IN] pImgInfo 图像结构体，目前只支持默认的格式，即ImageFormatRGB
        *  @param  [IN/OUT] pDstBuf JPEG数据的目的存储首地址
        *  @param  [IN] uSizeBuf JPEG数据地址的内存的最大尺寸；
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return >0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大
        *  @ingroup group_global
        */
        public delegate int VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality);

        /**
        *  @brief 设置IO输出，并自动复位
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [IN] nDuration 延时时间，取值范围[500, 5000]毫秒
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetIOOutputAuto(int handle, int uChnId, int nDuration);

        /**
        *  @brief 获取实时视频帧，图像数据通过回调函数到用户层，用户可改动图像内容，并且显示到窗口
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd		窗口的句柄，如果为有效值，则视频图像会显示到该窗口上，如果为空，则不显示视频图像
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 播放的句柄，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_StartRealPlayFrameCallBack(int handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 获取已设置的允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsTrigType 允许的车牌识别触发类型按位或的变量的地址，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        public delegate int VzLPRClient_GetPlateTrigType(int handle, ref int pBitsTrigType);

        /**
        *  @brief 设置允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] uBitsTrigType 允许的车牌识别触发类型按位或的值，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        *  @note  如果设置不允许某种类型的触发，那么该种类型的触发结果也不会保存在设备的SD卡中
        *  @note  默认输出稳定触发和虚拟线圈触发
        *  @note  不会影响手动触发和IO输入触发
        */
        public delegate int VzLPRClient_SetPlateTrigType(int handle, UInt32 uBitsTrigType);

        /**
        *  @brief 获取智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetDrawMode(int handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 设置智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetDrawMode(int handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 获取已设置的需要识别的车牌类型位
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsRecType 需要识别的车牌类型按位或的变量的地址，车牌类型位详见定义VZ_LPRC_REC_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        public delegate int VzLPRClient_GetPlateRecType(int handle, ref int pBitsRecType);

        /**
        *  @brief 设置需要识别的车牌类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] uBitsRecType 需要识别的车牌类型按位或的值，车牌类型位详见定义VZ_LPRC_REC_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        *  @note  在需要识别特定车牌时，调用该接口来设置，将不同类型的车牌位定义取或，得到的结果作为参数传入；
        *  @note  在不必要的情况下，使用最少的车牌识别类型，将最大限度提高识别率；
        *  @note  默认识别蓝牌和黄牌；
        *  @note  例如，需要识别蓝牌、黄牌、警牌，那么输入参数uBitsRecType = VZ_LPRC_REC_BLUE|VZ_LPRC_REC_YELLOW|VZ_LPRC_REC_POLICE
        */
        public delegate int VzLPRClient_SetPlateRecType(int handle, UInt32 uBitsRecType);

        /**
        *  @brief 获取输出配置0
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetOutputConfig(int handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置输出配置
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetOutputConfig(int handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetTriggerDelay(int handle, int nDelay);

        /**
        *  @brief 获取车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetTriggerDelay(int handle, ref int nDelay);

        /**
        *  @brief 设置白名单验证模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetWLCheckMethod(int handle, int nType);

        /**
        *  @brief 获取白名单验证模式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT]	nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetWLCheckMethod(int handle, ref int nType);

        /**
        *  @brief 设置白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetWLFuzzy(int handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC);

        /**
        *  @brief 获取白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetWLFuzzy(int handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC);

        /**
        *  @brief 设置串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] pParameter 将要设置的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_SetSerialParameter(int handle, int nSerialPort,
                                                 ref VZ_SERIAL_PARAMETER pParameter);

        /**
        *  @brief 获取串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [OUT] pParameter 将要获取的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetSerialParameter(int handle, int nSerialPort,
                                                 ref VZ_SERIAL_PARAMETER pParameter);

        //        /**
        //        *  @brief 保存正在播放的视频的当前帧的截图到指定路径
        //        *  @param  [IN] nPlayHandle 播放的句柄
        //        *  @param  [IN] pFullPathName 设带绝对路径和JPG后缀名的文件名字符串
        //        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        //        *  @return 0表示成功，-1表示失败
        //        *  @note   使用的文件名中的路径需要存在
        //        *  @ingroup group_device
        //        */
        //        public delegate int VzLPRClient_GetSnapShootToJpeg2(int nPlayHandle, string pFullPathName, int nQuality);

        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetVideoFrameSizeIndex(int handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoFrameSizeIndex(int handle, int sizeval);

        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetVideoFrameSizeIndexEx(int handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoFrameSizeIndexEx(int handle, int sizeval);

        /**
        *  @brief 获取主码流帧率
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetVideoFrameRate(int handle, ref int Rateval);//1-25

        /**
        *  @brief 设置主码流帧率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoFrameRate(int handle, int Rateval);//1-25

        /**
        *  @brief 获取主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetVideoCompressMode(int handle, ref int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 设置主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoCompressMode(int handle, int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 获取主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @param [OUT] ratelist 暂时不用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetVideoCBR(int handle, ref int rateval/*Kbps*/, ref int ratelist);

        /**
        *  @brief 设置主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoCBR(int handle, int rateval/*Kbps*/);

        /**
        *  @brief 获取视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] brt 亮度
        *  @param [OUT] cst 对比度
        *  @param [OUT] sat 饱和度
        *  @param [OUT] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetVideoPara(int handle, ref int brt, ref int cst, ref int sat, ref int hue);

        /**
        *  @brief 设置视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] brt 亮度
        *  @param [IN] cst 对比度
        *  @param [IN] sat 饱和度
        *  @param [IN] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoPara(int handle, int brt, int cst, int sat, int hue);

        /**
        *  @brief 设置通道主码流编码方式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] cmd    返回的编码方式, 0->H264  1->MPEG4  2->JPEG  其他->错误
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoEncodeType(int handle, int cmd);

        /**
        *  @brief 获取视频的编码方式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pEncType	返回的编码方式, 0:H264  1:MPEG4  2:JPEG  其他:错误
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_GetVideoEncodeType(int handle, ref int pEncType);

        /**
        *  @brief 获取视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetVideoVBR(int handle, ref int levelval);

        /**
        *  @brief 设置视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetVideoVBR(int handle, int levelval);

        /**
        *  @brief 获取视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetFrequency(int handle, ref int frequency);

        /**
        *  @brief 设置视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetFrequency(int handle, int frequency);

        /**
        *  @brief 获取曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetShutter(int handle, ref int shutter);

        /**
        *  @brief 设置曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetShutter(int handle, int shutter);

        /**
        *  @brief 获取图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetFlip(int handle, ref int flip);

        /**
        *  @brief 设置图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetFlip(int handle, int flip);

        /**
        *  @brief 修改网络参数
        *  @param  [IN] SL        设备序列号低位字节
        *  @param  [IN] SH		  设备序列号高位字节	
        *  @param [IN] strNewIP   新IP     格式如"192.168.3.109"
        *  @param [IN] strGateway 网关     格式如"192.168.3.1"
        *  @param [IN] strNetmask 子网掩码 格式如"255.255.255.0"
        *  @note 可以用来实现跨网段修改IP的功能
        *  @ingroup group_global
        */
        public delegate int VzLPRClient_UpdateNetworkParam(uint SL, uint SH, string strNewIP, string strGateway, string strNetmask);

        /**
        *  @brief 获取设备序列号；
        *  @param [IN] ip ip统一使用字符串的形式传入
        *  @param [IN] port 使用和登录时相同的端口
        *  @param [OUT] SerHi 序列号高位
        *  @param [OUT] SerLo 序列号低位
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo);

        /**
        *  @brief 开始实时图像数据流，用于实时获取图像数据
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_StartRealPlayDecData(int handle);

        /**
        *  @brief 停止实时图像数据流
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        public delegate int VzLPRClient_StopRealPlayDecData(int handle);

        /**
        *  @brief 从解码流中获取JPEG图像，保存到指定内存
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN/OUT] pDstBuf JPEG数据的目的存储首地址
        *  @param  [IN] uSizeBuf JPEG数据地址的内存的最大尺寸；
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return >0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大
        *  @ingroup group_global
        */
        public delegate int VzLPRClient_GetJpegStreamFromRealPlayDec(int handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality);

        /**
        *  @brief 设置是否输出实时结果
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] bOutput 是否输出
        *  @return 0表示成功，-1表示失败
        */
        public delegate int VzLPRClient_SetIsOutputRealTimeResult(int handle, bool bOutput);

        /**
        *  @brief 获取设备加密类型和当前加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pData 加密信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetEMS(int handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData);
        /**
        *  @brief 设置设备加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] nEncyptId	修改的加密类型ID 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetEncrypt(int handle, IntPtr pCurrentKey, UInt32 nEncyptId);

        /**
        *  @brief 修改设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_ChangeEncryptKey(int handle, IntPtr pCurrentKey, IntPtr pNewKey);

        /**
        *  @brief 重置设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pPrimeKey 当前设备主密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_ResetEncryptKey(int handle, IntPtr pPrimeKey, IntPtr pNewKey);

        /**
        *  @brief 语音播放功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] voice 播放的语音文字
        *  @param [IN] interval 语音文件的播放间隔(0-5000)
        *  @param [IN] volume 声音大小(0-100)
        *  @param [IN] male 声音类型(男声0，女生1)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_PlayVoice(int handle, string voice, int interval, int volume, int male);

        //**************************************************************
        // 中心服务器配置
        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetCenterServerNet(int handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 获取中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetCenterServerNet(int handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 设置中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetCenterServerDeviceReg(int handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 获取中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetCenterServerDeviceReg(int handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 设置中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetCenterServerPlate(int handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 获取中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetCenterServerPlate(int handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetCenterServerGionin(int handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 获取中心服务器网络端口触发信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerGionin  中心服务器端口触发信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetCenterServerGionin(int handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 设置中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetCenterServerSerial(int handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 获取中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetCenterServerSerial(int handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 设置中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetCenterServerHostBak(int handle, string pCenterServerHostBak);

        /**
        *  @brief 获取中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetCenterServerHostBak(int handle, ref string pCenterServerHostBak);

        /**
        *  @brief 获取设备硬件信息
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_version  设备类型
        *  @param [OUT] exdataSize 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetHwBoardVersion(int handle, ref int board_version, ref Int64 exdataSize);

        /**
        *  @brief 获取设备硬件类型
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_type  设备类型(0:3730,1:6446,2:8127)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetHwBoardType(int handle, ref int board_type);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetAlgResultParam(int handle, ref int reco_dis);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetAlgResultParam(int handle, int reco_dis);

        /**
        *  @brief 获取图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetDenoise(int handle, ref int mode, ref int strength);

        /**
        *  @brief 设置图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetDenoise(int handle, int mode, int strength);

        /**
        *  @brief 获取R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流 
        *  @param [OUT] param 编码参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_RGet_Encode_Param(int handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 设置R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_RSet_Encode_Param(int handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 获取R相机支持的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_RGet_Encode_Param_Property(int handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] param 视频参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_RGet_Video_Param(int handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_RSet_Video_Param(int handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 开始喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] client_win_size 客户端窗口大小
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_StartTalk(int handle, int client_win_size);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetRequestTalkCallBack(int handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 停止喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] device_ip 设备IP
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_StopTalk(int handle);

        /**
        *  @brief 开始录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] file_path 音频文件路径
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_StartRecordAudio(int handle, string file_path);

        /**
        *  @brief 停止录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_StopRecordAudio(int handle);

        /**
        *  @brief 设置车牌图片里是否显示车牌框
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] bShow 是否显示车牌框，输入值(0或1)，1代表显示，0代表不显示
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetIsShowPlateRect(int handle, int bShow);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_SetGPIORecvCallBack(int handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取相机参数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] command 命令类型
        *  @param [IN] channel 通道号，默认为0
        *  @param [OUT] pOutBuffer 返回的数据
        *  @param [IN] dwOutBufferSize 数据的长度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        public delegate int VzLPRClient_GetCameraConfig(int handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize);
    }
}
