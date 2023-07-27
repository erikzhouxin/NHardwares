using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    internal class VzClientSdkDllerX64 : IVzClientSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IVzClientSdkProxy Instance { get; } = new VzClientSdkDllerX64();
        private VzClientSdkDllerX64() { }
        /// <summary>
        /// 复制内存
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <param name="Length"></param>
        [DllImport("kernel32.dll")]
        public static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
        #region // 函数导入
        /**
        *  @brief 全局初始化，在所有接口调用之前调用
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_Setup();

        /**
        *  @brief 全局释放
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern void VzLPRClient_Cleanup();

        /**
        *  @brief 设置设备连接反馈结果相关的回调函数
        *  @param  [IN] func 设备连接结果和状态，通过该回调函数返回
        *  @param [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 打开一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @param [IN] wPort 设备的端口号
        *  @param  [IN] pStrUserName 访问设备所需用户名
        *  @param [IN] pStrPassword 访问设备所需密码
        *  @return 返回设备的操作句柄，当打开失败时，返回-1
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern IntPtr VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword);

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
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern IntPtr VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn);

        /**
        *  @brief 关闭一个设备
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_Close(IntPtr handle);

        /**
        *  @brief 通过IP地址关闭一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_CloseByIP(string pStrIP);

        /**
        *  @brief 获取连接状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param[IN/OUT] pStatus 输入获取状态的变量地址，输出内容为 1已连上，0未连上
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_IsConnected(IntPtr handle, ref byte pStatus);

        /**
        *  @brief 根据句柄获取设备的IP
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] ip  相机IP
        *  @param [IN] max_count IP传入长度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetDeviceIP(IntPtr handle, ref byte ip, int max_count);

        /**
        *  @brief 播放实时视频
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 播放句柄，小于0表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern IntPtr VzLPRClient_StartRealPlay(IntPtr handle, IntPtr hWnd);

        /**
        *  @brief 停止正在播放的窗口上的实时视频
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StopRealPlay(IntPtr hRealHandle);

        /**
        *  @brief 设置识别结果的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64, CallingConvention = CallingConvention.StdCall)]
        public static extern int VzLPRClient_SetPlateInfoCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage);

        /**
        *  @brief 设置实时图像数据的回调函数
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64, CallingConvention = CallingConvention.StdCall)]
        public static extern int VzLPRClient_SetVideoFrameCallBack(IntPtr handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData);
        /// <summary>
        /// 发送软件触发信号，强制处理当前时刻的数据并输出结果
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>0表示成功，-1表示失败</returns>
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_ForceTrigger(IntPtr handle);

        /**
        *  @brief 设置虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的识别区域
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pROI 识别区域的结构体指针
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetRegionOfInterestEx(IntPtr handle, ref VZ_LPRC_ROI_EX pROI);

        /**
        *  @brief 获取已设置的预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pProvInfo 预设省份信息指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetSupportedProvinces(IntPtr handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo);

        /**
        *  @brief 设置预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nIndex 设置预设省份的序号，序号需要参考VZ_LPRC_PROVINCE_INFO::strProvinces中的顺序，从0开始，如果小于0，则表示不设置预设省份
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_PresetProvinceIndex(IntPtr handle, int nIndex);

        /**
        *  @brief 将图像保存为JPEG到指定路径
        *  @param  [IN] pImgInfo 图像结构体，目前只支持默认的格式，即ImageFormatRGB
        *  @param  [IN] pFullPathName 设带绝对路径和JPG后缀名的文件名字符串
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return 0表示成功，-1表示失败
        *  @note   给定的文件名中的路径需要存在
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality);
        /// <summary>
        /// 将图像保存为JPEG到指定路径，可指定图像尺寸的模式
        /// </summary>
        /// <param name="pImgInfo">图像结构体，目前只支持默认的格式，即ImageFormatRGB</param>
        /// <param name="pFullPathName">设带绝对路径和JPG后缀名的文件名字符串</param>
        /// <param name="nQuality">JPEG压缩的质量，取值范围1~100</param>
        /// <param name="sizeMode">图像大小的模式</param>
        /// <returns></returns>
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_ImageSaveToJpegEx(VZ_LPRC_IMAGE_INFO pImgInfo, string pFullPathName, int nQuality, IMG_SIZE_MODE sizeMode);

        /**
        *  @brief 读出设备序列号，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pSN 用于存放读到的设备序列号，详见定义 VZ_DEV_SERIAL_NUM
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetSerialNumber(IntPtr handle, ref VZ_DEV_SERIAL_NUM pSN);

        /**
        *  @brief 保存正在播放的视频的当前帧的截图到指定路径
        *  @param  [IN] nPlayHandle 播放的句柄
        *  @param  [IN] pFullPathName 设带绝对路径和JPG后缀名的文件名字符串
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return 0表示成功，-1表示失败
        *  @note   使用的文件名中的路径需要存在
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetSnapShootToJpeg2(IntPtr nPlayHandle, string pFullPathName, int nQuality);

        /// <summary>
        /// 保存抓图数据到Jpeg文件
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pFullPathName">图片路径</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败</returns>
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SaveSnapImageToJpeg(IntPtr handle, string pFullPathName);

        /**
        *  @brief 开启透明通道
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] func 接收数据的回调函数
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *  @return 返回透明通道句柄，0表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern IntPtr VzLPRClient_SerialStart(IntPtr handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 透明通道发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @param [IN] pData 将要传输的数据块的首地址
        *  @param [IN] uSizeData 将要传输的数据块的字节数
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SerialSend(IntPtr nSerialHandle, IntPtr pData, int uSizeData);

        /**
        *  @brief 透明通道停止发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SerialStop(IntPtr nSerialHandle);

        /**
        *  @brief 设置IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] nOutput 将要设置的IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetIOOutput(IntPtr handle, int uChnId, int nOutput);

        /**
        *  @brief 获取IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] pOutput IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetIOOutput(IntPtr handle, int uChnId, ref int pOutput);

        /**
        *  @brief 获取GPIO的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] gpioIn 数据为0或1
        *  @param  [OUT] value 0代表短路，1代表开路
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, out int value);

        /**
        *  @brief 根据ID获取车牌图片
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] id     车牌记录的ID
        *  @param  [IN] pdata  存储图片的内存
        *  @param  [IN][OUT] size 为传入传出值，传入为图片内存的大小，返回的是获取到jpg图片内存的大小
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_LoadImageById(IntPtr handle, int id, IntPtr pdata, IntPtr size);

        /**
        *  @brief 向白名单表导入客户和车辆记录
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] rowcount 记录的条数
        *  @param  [IN] pRowDatas 记录的内容数组的地址
        *  @param  [OUT] results 每条数据是否导入成功
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListImportRows(IntPtr handle,
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
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListDeleteVehicle(IntPtr handle, string strPlateID);

        /**
        *  @brief 清空数据库客户信息和车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListClearCustomersAndVehicles(IntPtr handle);

        /**
        *  @brief 获取白名单表中所有车辆信息记录的条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return >=0表示所有车辆信息记录的总数，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListGetVehicleCount(IntPtr handle, ref uint pCount,
                                                                 ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 查询白名单表车辆记录数据
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pLoadCondition 查询条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListLoadVehicle(IntPtr handle,
                                                            ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition);

        /**
        *  @brief 设置白名单表和客户信息表的查询结果回调
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 查询结果回调函数
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListSetQueryCallBack(IntPtr handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 往白名单表中更新一个车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVehicle 将要更新的车辆信息，详见结构体定义VZ_LPR_WLIST_VEHICLE
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListUpdateVehicleByID(IntPtr handle, ref VZ_LPR_WLIST_VEHICLE pVehicle);

        /**
        *  @brief 查询白名单表客户和车辆记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pCount 记录的条数
        *  @param  [IN] search_constraints 搜索的条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WhiteListGetRowCount(IntPtr handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 设置LED控制模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] eCtrl 控制LED开关模式，详见定义 VZ_LED_CTRL
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetLEDLightControlMode(IntPtr handle, VZ_LED_CTRL eCtrl);
        /**
        *  @brief 获取LED当前亮度等级和最大亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pLevelNow 用于输出当前亮度等级的地址
        *  @param [OUT] pLevelMax 用于输出最高亮度等级的地址
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetLEDLightStatus(IntPtr handle, ref int pLevelNow, ref int pLevelMax);

        /**
        *  @brief 设置LED亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nLevel，LED亮度等级
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetLEDLightLevel(IntPtr handle, int nLevel);

        /**
        *  @brief 开始录像功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sFileName 录像文件的路径
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SaveRealData(IntPtr handle, string sFileName);

        /**
        *  @brief 停止录像
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StopSaveRealData(IntPtr handle);

        /**
        *  @brief 开启脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetOfflineCheck(IntPtr handle);

        /**
        *  @brief 关闭脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_CancelOfflineCheck(IntPtr handle);

        /**
        *  @brief 开始查找设备
        *  @param  [IN] func 找到的设备通过该回调函数返回
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 停止查找设备
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VZLPRClient_StopFindDevice();

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
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_QueryRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword);

        /**
        *  @brief 根据时间和车牌号查询记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pStartTime 起始时间，格式如"2015-01-02 12:20:30"
        *  @param  [IN] pEndTime   起始时间，格式如"2015-01-02 19:20:30"
        *  @param  [IN] keyword    车牌号关键字, 如"川"
        *  @return 返回值为0表示失败，大于0表示记录条数
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_QueryCountByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword);

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
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_QueryPageRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword, int start, int end);

        /**
        *  @brief 设置查询车牌记录的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数，如果为NULL，则表示关闭该回调函数的功能
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetQueryPlateCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置设备的日期时间
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDTInfo 将要设置的设备日期时间信息，详见定义 VZ_DATE_TIME_INFO
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetDateTime(IntPtr handle, IntPtr IntpDTInfo);

        /**
        *  @brief 读出用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pBuffer 用于存放读到的用户数据
        *  @param [IN] uSizeBuf 用户数据缓冲区的最小尺寸，不小于128字节
        *  @return 返回值为实际用户数据的字节数，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_ReadUserData(IntPtr handle, IntPtr pBuffer, uint uSizeBuf);

        /**
        *  @brief 写入用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pUserData 用户数据
        *  @param [IN] uSizeData 用户数据的长度，最大128字节
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_WriteUserData(IntPtr handle, IntPtr pUserData, uint uSizeData);

        /**
        *  @brief 将图像编码为JPEG，保存到指定内存
        *  @param  [IN] pImgInfo 图像结构体，目前只支持默认的格式，即ImageFormatRGB
        *  @param  [IN/OUT] pDstBuf JPEG数据的目的存储首地址
        *  @param  [IN] uSizeBuf JPEG数据地址的内存的最大尺寸；
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return >0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality);

        /**
        *  @brief 设置IO输出，并自动复位
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [IN] nDuration 延时时间，取值范围[500, 5000]毫秒
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetIOOutputAuto(IntPtr handle, int uChnId, int nDuration);

        /**
        *  @brief 获取实时视频帧，图像数据通过回调函数到用户层，用户可改动图像内容，并且显示到窗口
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd		窗口的句柄，如果为有效值，则视频图像会显示到该窗口上，如果为空，则不显示视频图像
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 播放的句柄，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr VzLPRClient_StartRealPlayFrameCallBack(IntPtr handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 获取已设置的允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsTrigType 允许的车牌识别触发类型按位或的变量的地址，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetPlateTrigType(IntPtr handle, ref int pBitsTrigType);

        /**
        *  @brief 设置允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] uBitsTrigType 允许的车牌识别触发类型按位或的值，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        *  @note  如果设置不允许某种类型的触发，那么该种类型的触发结果也不会保存在设备的SD卡中
        *  @note  默认输出稳定触发和虚拟线圈触发
        *  @note  不会影响手动触发和IO输入触发
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetPlateTrigType(IntPtr handle, UInt32 uBitsTrigType);

        /**
        *  @brief 获取智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 设置智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 获取已设置的需要识别的车牌类型位
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsRecType 需要识别的车牌类型按位或的变量的地址，车牌类型位详见定义VZ_LPRC_REC_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetPlateRecType(IntPtr handle, ref int pBitsRecType);

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
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetPlateRecType(IntPtr handle, UInt32 uBitsRecType);

        /**
        *  @brief 获取输出配置0
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置输出配置
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetTriggerDelay(IntPtr handle, int nDelay);

        /**
        *  @brief 获取车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetTriggerDelay(IntPtr handle, ref int nDelay);

        /**
        *  @brief 设置白名单验证模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetWLCheckMethod(IntPtr handle, int nType);

        /**
        *  @brief 获取白名单验证模式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT]	nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetWLCheckMethod(IntPtr handle, ref int nType);

        /**
        *  @brief 设置白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetWLFuzzy(IntPtr handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC);

        /**
        *  @brief 获取白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetWLFuzzy(IntPtr handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC);

        /**
        *  @brief 设置串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] pParameter 将要设置的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetSerialParameter(IntPtr handle, int nSerialPort,
                                                         ref VZ_SERIAL_PARAMETER pParameter);

        /**
        *  @brief 获取串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [OUT] pParameter 将要获取的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter);
        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoFrameSizeIndex(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoFrameSizeIndex(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoFrameSizeIndexEx(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoFrameSizeIndexEx(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流帧率
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoFrameRate(IntPtr handle, ref int Rateval);//1-25

        /**
        *  @brief 设置主码流帧率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoFrameRate(IntPtr handle, int Rateval);//1-25

        /**
        *  @brief 获取主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoCompressMode(IntPtr handle, ref int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 设置主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoCompressMode(IntPtr handle, int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 获取主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @param [OUT] ratelist 暂时不用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoCBR(IntPtr handle, ref int rateval/*Kbps*/, ref int ratelist);

        /**
        *  @brief 设置主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoCBR(IntPtr handle, int rateval/*Kbps*/);

        /**
        *  @brief 获取视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] brt 亮度
        *  @param [OUT] cst 对比度
        *  @param [OUT] sat 饱和度
        *  @param [OUT] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoPara(IntPtr handle, ref int brt, ref int cst, ref int sat, ref int hue);

        /**
        *  @brief 设置视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] brt 亮度
        *  @param [IN] cst 对比度
        *  @param [IN] sat 饱和度
        *  @param [IN] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoPara(IntPtr handle, int brt, int cst, int sat, int hue);

        /**
        *  @brief 设置通道主码流编码方式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] cmd    返回的编码方式, 0->H264  1->MPEG4  2->JPEG  其他->错误
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoEncodeType(IntPtr handle, int cmd);

        /**
        *  @brief 获取视频的编码方式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pEncType	返回的编码方式, 0:H264  1:MPEG4  2:JPEG  其他:错误
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoEncodeType(IntPtr handle, ref int pEncType);

        /**
        *  @brief 获取视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetVideoVBR(IntPtr handle, ref int levelval);

        /**
        *  @brief 设置视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetVideoVBR(IntPtr handle, int levelval);

        /**
        *  @brief 获取视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetFrequency(IntPtr handle, ref int frequency);

        /**
        *  @brief 设置视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetFrequency(IntPtr handle, int frequency);

        /**
        *  @brief 获取曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetShutter(IntPtr handle, ref int shutter);

        /**
        *  @brief 设置曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetShutter(IntPtr handle, int shutter);

        /**
        *  @brief 获取图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetFlip(IntPtr handle, ref int flip);

        /**
        *  @brief 设置图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetFlip(IntPtr handle, int flip);

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
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_UpdateNetworkParam(uint sh, uint sl, string strNewIP, string strGateway, string strNetmask);

        /**
        *  @brief 获取设备序列号；
        *  @param [IN] ip ip统一使用字符串的形式传入
        *  @param [IN] port 使用和登录时相同的端口
        *  @param [OUT] SerHi 序列号高位
        *  @param [OUT] SerLo 序列号低位
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo);

        /**
        *  @brief 开始实时图像数据流，用于实时获取图像数据
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StartRealPlayDecData(IntPtr handle);

        /**
        *  @brief 停止实时图像数据流
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StopRealPlayDecData(IntPtr handle);

        /**
        *  @brief 从解码流中获取JPEG图像，保存到指定内存
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN/OUT] pDstBuf JPEG数据的目的存储首地址
        *  @param  [IN] uSizeBuf JPEG数据地址的内存的最大尺寸；
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return >0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetJpegStreamFromRealPlayDec(IntPtr handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality);

        /**
        *  @brief 设置是否输出实时结果
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] bOutput 是否输出
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetIsOutputRealTimeResult(IntPtr handle, bool bOutput);

        /**
        *  @brief 获取设备加密类型和当前加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pData 加密信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetEMS(IntPtr handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData);
        /**
        *  @brief 设置设备加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] nEncyptId	修改的加密类型ID 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetEncrypt(IntPtr handle, IntPtr pCurrentKey, UInt32 nEncyptId);

        /**
        *  @brief 修改设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_ChangeEncryptKey(IntPtr handle, IntPtr pCurrentKey, IntPtr pNewKey);

        /**
        *  @brief 重置设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pPrimeKey 当前设备主密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_ResetEncryptKey(IntPtr handle, IntPtr pPrimeKey, IntPtr pNewKey);

        /**
        *  @brief 语音播放功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] voice 播放的语音文字
        *  @param [IN] interval 语音文件的播放间隔(0-5000)
        *  @param [IN] volume 声音大小(0-100)
        *  @param [IN] male 声音类型(男声0，女生1)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_PlayVoice(IntPtr handle, string voice, int interval, int volume, int male);

        //**************************************************************
        // 中心服务器配置
        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 获取中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 设置中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 获取中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 设置中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 获取中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 获取中心服务器网络端口触发信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerGionin  中心服务器端口触发信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 设置中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 获取中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 设置中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetCenterServerHostBak(IntPtr handle, string pCenterServerHostBak);

        /**
        *  @brief 获取中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetCenterServerHostBak(IntPtr handle, ref string pCenterServerHostBak);

        /**
        *  @brief 获取设备硬件信息
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_version  设备类型
        *  @param [OUT] exdataSize 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetHwBoardVersion(IntPtr handle, ref int board_version, ref Int64 exdataSize);

        /**
        *  @brief 获取设备硬件类型
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_type  设备类型(0:3730,1:6446,2:8127)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetHwBoardType(IntPtr handle, ref int board_type);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetAlgResultParam(IntPtr handle, ref int reco_dis);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetAlgResultParam(IntPtr handle, int reco_dis);

        /**
        *  @brief 获取图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetDenoise(IntPtr handle, ref int mode, ref int strength);

        /**
        *  @brief 设置图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetDenoise(IntPtr handle, int mode, int strength);

        /**
        *  @brief 获取R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流 
        *  @param [OUT] param 编码参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_RGet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 设置R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_RSet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 获取R相机支持的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_RGet_Encode_Param_Property(IntPtr handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] param 视频参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_RGet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_RSet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 开始喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] client_win_size 客户端窗口大小
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StartTalk(IntPtr handle, int client_win_size);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetRequestTalkCallBack(IntPtr handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 停止喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] device_ip 设备IP
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StopTalk(IntPtr handle);

        /**
        *  @brief 开始录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] file_path 音频文件路径
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StartRecordAudio(IntPtr handle, string file_path);

        /**
        *  @brief 停止录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_StopRecordAudio(IntPtr handle);

        /**
        *  @brief 设置车牌图片里是否显示车牌框
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] bShow 是否显示车牌框，输入值(0或1)，1代表显示，0代表不显示
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetIsShowPlateRect(IntPtr handle, int bShow);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_SetGPIORecvCallBack(IntPtr handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取相机参数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] command 命令类型
        *  @param [IN] channel 通道号，默认为0
        *  @param [OUT] pOutBuffer 返回的数据
        *  @param [IN] dwOutBufferSize 数据的长度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX64)]
        public static extern int VzLPRClient_GetCameraConfig(IntPtr handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize);
        #endregion // 函数导入
        #region // 显示实现
        void IVzClientSdkProxy.CopyMemory(IntPtr Destination, IntPtr Source, int Length) => CopyMemory(Destination, Source, Length);
        int IVzClientSdkProxy.VzLPRClient_CancelOfflineCheck(IntPtr handle) => VzLPRClient_CancelOfflineCheck(handle);
        int IVzClientSdkProxy.VzLPRClient_ChangeEncryptKey(IntPtr handle, IntPtr pCurrentKey, IntPtr pNewKey) => VzLPRClient_ChangeEncryptKey(handle, pCurrentKey, pNewKey);
        void IVzClientSdkProxy.VzLPRClient_Cleanup() => VzLPRClient_Cleanup();
        int IVzClientSdkProxy.VzLPRClient_Close(IntPtr handle) => VzLPRClient_Close(handle);
        int IVzClientSdkProxy.VzLPRClient_CloseByIP(string pStrIP) => VzLPRClient_CloseByIP(pStrIP);
        int IVzClientSdkProxy.VzLPRClient_ForceTrigger(IntPtr handle) => VzLPRClient_ForceTrigger(handle);
        int IVzClientSdkProxy.VzLPRClient_GetAlgResultParam(IntPtr handle, ref int reco_dis) => VzLPRClient_GetAlgResultParam(handle, ref reco_dis);
        int IVzClientSdkProxy.VzLPRClient_GetCameraConfig(IntPtr handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize) => VzLPRClient_GetCameraConfig(handle, command, channel, pOutBuffer, dwOutBufferSize);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg) => VzLPRClient_GetCenterServerDeviceReg(handle, ref pCenterServerDeviceReg);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin) => VzLPRClient_GetCenterServerGionin(handle, ref pCenterServerGionin);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerHostBak(IntPtr handle, ref string pCenterServerHostBak) => VzLPRClient_GetCenterServerHostBak(handle, ref pCenterServerHostBak);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet) => VzLPRClient_GetCenterServerNet(handle, ref pCenterServerNet);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate) => VzLPRClient_GetCenterServerPlate(handle, ref pCenterServerPlate);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial) => VzLPRClient_GetCenterServerSerial(handle, ref pCenterServerSerial);
        int IVzClientSdkProxy.VzLPRClient_GetDenoise(IntPtr handle, ref int mode, ref int strength) => VzLPRClient_GetDenoise(handle, ref mode, ref strength);
        int IVzClientSdkProxy.VzLPRClient_GetDeviceIP(IntPtr handle, ref byte ip, int max_count) => VzLPRClient_GetDeviceIP(handle, ref ip, max_count);
        int IVzClientSdkProxy.VzLPRClient_GetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode) => VzLPRClient_GetDrawMode(handle, ref pDrawMode);
        int IVzClientSdkProxy.VzLPRClient_GetEMS(IntPtr handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData) => VzLPRClient_GetEMS(handle, ref pData);
        int IVzClientSdkProxy.VzLPRClient_GetFlip(IntPtr handle, ref int flip) => VzLPRClient_GetFlip(handle, ref flip);
        int IVzClientSdkProxy.VzLPRClient_GetFrequency(IntPtr handle, ref int frequency) => VzLPRClient_GetFrequency(handle, ref frequency);
        int IVzClientSdkProxy.VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, out int value) => VzLPRClient_GetGPIOValue(handle, gpioIn, out value);
        int IVzClientSdkProxy.VzLPRClient_GetHwBoardType(IntPtr handle, ref int board_type) => VzLPRClient_GetHwBoardType(handle, ref board_type);
        int IVzClientSdkProxy.VzLPRClient_GetHwBoardVersion(IntPtr handle, ref int board_version, ref long exdataSize) => VzLPRClient_GetHwBoardVersion(handle, ref board_version, ref exdataSize);
        int IVzClientSdkProxy.VzLPRClient_GetIOOutput(IntPtr handle, int uChnId, ref int pOutput) => VzLPRClient_GetIOOutput(handle, uChnId, ref pOutput);
        int IVzClientSdkProxy.VzLPRClient_GetJpegStreamFromRealPlayDec(IntPtr handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality) => VzLPRClient_GetJpegStreamFromRealPlayDec(handle, pDstBuf, uSizeBuf, nQuality);
        int IVzClientSdkProxy.VzLPRClient_GetLEDLightStatus(IntPtr handle, ref int pLevelNow, ref int pLevelMax) => VzLPRClient_GetLEDLightStatus(handle, ref pLevelNow, ref pLevelMax);
        int IVzClientSdkProxy.VzLPRClient_GetOsdParam(IntPtr handle, IntPtr pParam) => VzLPRClient_GetOsdParam(handle, pParam);
        int IVzClientSdkProxy.VzLPRClient_GetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo) => VzLPRClient_GetOutputConfig(handle, ref pOutputConfigInfo);
        int IVzClientSdkProxy.VzLPRClient_GetPlateRecType(IntPtr handle, ref int pBitsRecType) => VzLPRClient_GetPlateRecType(handle, ref pBitsRecType);
        int IVzClientSdkProxy.VzLPRClient_GetPlateTrigType(IntPtr handle, ref int pBitsTrigType) => VzLPRClient_GetPlateTrigType(handle, ref pBitsTrigType);
        int IVzClientSdkProxy.VzLPRClient_GetRegionOfInterestEx(IntPtr handle, ref VZ_LPRC_ROI_EX pROI) => VzLPRClient_GetRegionOfInterestEx(handle, ref pROI);
        int IVzClientSdkProxy.VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo) => VzLPRClient_GetSerialNo(ip, port, ref SerHi, ref SerLo);
        int IVzClientSdkProxy.VzLPRClient_GetSerialNumber(IntPtr handle, ref VZ_DEV_SERIAL_NUM pSN) => VzLPRClient_GetSerialNumber(handle, ref pSN);
        int IVzClientSdkProxy.VzLPRClient_GetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter) => VzLPRClient_GetSerialParameter(handle, nSerialPort, ref pParameter);
        int IVzClientSdkProxy.VzLPRClient_GetShutter(IntPtr handle, ref int shutter) => VzLPRClient_GetShutter(handle, ref shutter);
        int IVzClientSdkProxy.VzLPRClient_GetSnapShootToJpeg2(IntPtr nPlayHandle, string pFullPathName, int nQuality) => VzLPRClient_GetSnapShootToJpeg2(nPlayHandle, pFullPathName, nQuality);
        int IVzClientSdkProxy.VzLPRClient_SaveSnapImageToJpeg(IntPtr handle, string pFullPathName) => VzLPRClient_SaveSnapImageToJpeg(handle, pFullPathName);
        int IVzClientSdkProxy.VzLPRClient_GetSupportedProvinces(IntPtr handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo) => VzLPRClient_GetSupportedProvinces(handle, ref pProvInfo);
        int IVzClientSdkProxy.VzLPRClient_GetTriggerDelay(IntPtr handle, ref int nDelay) => VzLPRClient_GetTriggerDelay(handle, ref nDelay);
        int IVzClientSdkProxy.VzLPRClient_GetVideoCBR(IntPtr handle, ref int rateval, ref int ratelist) => VzLPRClient_GetVideoCBR(handle, ref rateval, ref ratelist);
        int IVzClientSdkProxy.VzLPRClient_GetVideoCompressMode(IntPtr handle, ref int modeval) => VzLPRClient_GetVideoCompressMode(handle, ref modeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoEncodeType(IntPtr handle, ref int pEncType) => VzLPRClient_GetVideoEncodeType(handle, ref pEncType);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameRate(IntPtr handle, ref int Rateval) => VzLPRClient_GetVideoFrameRate(handle, ref Rateval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameSizeIndex(IntPtr handle, ref int sizeval) => VzLPRClient_GetVideoFrameSizeIndex(handle, ref sizeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameSizeIndexEx(IntPtr handle, ref int sizeval) => VzLPRClient_GetVideoFrameSizeIndexEx(handle, ref sizeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoPara(IntPtr handle, ref int brt, ref int cst, ref int sat, ref int hue) => VzLPRClient_GetVideoPara(handle, ref brt, ref cst, ref sat, ref hue);
        int IVzClientSdkProxy.VzLPRClient_GetVideoVBR(IntPtr handle, ref int levelval) => VzLPRClient_GetVideoVBR(handle, ref levelval);
        int IVzClientSdkProxy.VzLPRClient_GetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops) => VzLPRClient_GetVirtualLoop(handle, ref pVirtualLoops);
        int IVzClientSdkProxy.VzLPRClient_GetWLCheckMethod(IntPtr handle, ref int nType) => VzLPRClient_GetWLCheckMethod(handle, ref nType);
        int IVzClientSdkProxy.VzLPRClient_GetWLFuzzy(IntPtr handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC) => VzLPRClient_GetWLFuzzy(handle, ref nFuzzyType, ref nFuzzyLen, ref bFuzzyCC);
        int IVzClientSdkProxy.VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality) => VzLPRClient_ImageEncodeToJpeg(pImgInfo, pDstBuf, uSizeBuf, nQuality);
        int IVzClientSdkProxy.VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality) => VzLPRClient_ImageSaveToJpeg(pImgInfo, pFullPathName, nQuality);
        int IVzClientSdkProxy.VzLPRClient_ImageSaveToJpegEx(VZ_LPRC_IMAGE_INFO pImgInfo, string pFullPathName, int nQuality, IMG_SIZE_MODE sizeMode) => VzLPRClient_ImageSaveToJpegEx(pImgInfo, pFullPathName, nQuality, sizeMode);
        int IVzClientSdkProxy.VzLPRClient_IsConnected(IntPtr handle, ref byte pStatus) => VzLPRClient_IsConnected(handle, ref pStatus);
        int IVzClientSdkProxy.VzLPRClient_LoadImageById(IntPtr handle, int id, IntPtr pdata, IntPtr size) => VzLPRClient_LoadImageById(handle, id, pdata, size);
        IntPtr IVzClientSdkProxy.VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword) => VzLPRClient_Open(pStrIP, wPort, pStrUserName, pStrPassword);
        IntPtr IVzClientSdkProxy.VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn) => VzLPRClient_OpenV2(pStrIP, wPort, pStrUserName, pStrPassword, wRtspPort, network_type, sn);
        int IVzClientSdkProxy.VzLPRClient_PlayVoice(IntPtr handle, string voice, int interval, int volume, int male) => VzLPRClient_PlayVoice(handle, voice, interval, volume, male);
        int IVzClientSdkProxy.VzLPRClient_PresetProvinceIndex(IntPtr handle, int nIndex) => VzLPRClient_PresetProvinceIndex(handle, nIndex);
        int IVzClientSdkProxy.VzLPRClient_QueryCountByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword) => VzLPRClient_QueryCountByTimeAndPlate(handle, pStartTime, pEndTime, keyword);
        int IVzClientSdkProxy.VzLPRClient_QueryPageRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword, int start, int end) => VzLPRClient_QueryPageRecordByTimeAndPlate(handle, pStartTime, pEndTime, keyword, start, end);
        int IVzClientSdkProxy.VzLPRClient_QueryRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword) => VzLPRClient_QueryRecordByTimeAndPlate(handle, pStartTime, pEndTime, keyword);
        int IVzClientSdkProxy.VzLPRClient_ReadUserData(IntPtr handle, IntPtr pBuffer, uint uSizeBuf) => VzLPRClient_ReadUserData(handle, pBuffer, uSizeBuf);
        int IVzClientSdkProxy.VzLPRClient_ResetEncryptKey(IntPtr handle, IntPtr pPrimeKey, IntPtr pNewKey) => VzLPRClient_ResetEncryptKey(handle, pPrimeKey, pNewKey);
        int IVzClientSdkProxy.VzLPRClient_RGet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param) => VzLPRClient_RGet_Encode_Param(handle, stream, ref param);
        int IVzClientSdkProxy.VzLPRClient_RGet_Encode_Param_Property(IntPtr handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param) => VzLPRClient_RGet_Encode_Param_Property(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_RGet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param) => VzLPRClient_RGet_Video_Param(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_RSet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param) => VzLPRClient_RSet_Encode_Param(handle, stream, ref param);
        int IVzClientSdkProxy.VzLPRClient_RSet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param) => VzLPRClient_RSet_Video_Param(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_SaveRealData(IntPtr handle, string sFileName) => VzLPRClient_SaveRealData(handle, sFileName);
        int IVzClientSdkProxy.VzLPRClient_SerialSend(IntPtr nSerialHandle, IntPtr pData, int uSizeData) => VzLPRClient_SerialSend(nSerialHandle, pData, uSizeData);
        IntPtr IVzClientSdkProxy.VzLPRClient_SerialStart(IntPtr handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData) => VzLPRClient_SerialStart(handle, nSerialPort, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SerialStop(IntPtr nSerialHandle) => VzLPRClient_SerialStop(nSerialHandle);
        int IVzClientSdkProxy.VzLPRClient_SetAlgResultParam(IntPtr handle, int reco_dis) => VzLPRClient_SetAlgResultParam(handle, reco_dis);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg) => VzLPRClient_SetCenterServerDeviceReg(handle, ref pCenterServerDeviceReg);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin) => VzLPRClient_SetCenterServerGionin(handle, ref pCenterServerGionin);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerHostBak(IntPtr handle, string pCenterServerHostBak) => VzLPRClient_SetCenterServerHostBak(handle, pCenterServerHostBak);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet) => VzLPRClient_SetCenterServerNet(handle, ref pCenterServerNet);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate) => VzLPRClient_SetCenterServerPlate(handle, ref pCenterServerPlate);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial) => VzLPRClient_SetCenterServerSerial(handle, ref pCenterServerSerial);
        int IVzClientSdkProxy.VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData) => VZLPRClient_SetCommonNotifyCallBack(func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetDateTime(IntPtr handle, IntPtr IntpDTInfo) => VzLPRClient_SetDateTime(handle, IntpDTInfo);
        int IVzClientSdkProxy.VzLPRClient_SetDenoise(IntPtr handle, int mode, int strength) => VzLPRClient_SetDenoise(handle, mode, strength);
        int IVzClientSdkProxy.VzLPRClient_SetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode) => VzLPRClient_SetDrawMode(handle, ref pDrawMode);
        int IVzClientSdkProxy.VzLPRClient_SetEncrypt(IntPtr handle, IntPtr pCurrentKey, uint nEncyptId) => VzLPRClient_SetEncrypt(handle, pCurrentKey, nEncyptId);
        int IVzClientSdkProxy.VzLPRClient_SetFlip(IntPtr handle, int flip) => VzLPRClient_SetFlip(handle, flip);
        int IVzClientSdkProxy.VzLPRClient_SetFrequency(IntPtr handle, int frequency) => VzLPRClient_SetFrequency(handle, frequency);
        int IVzClientSdkProxy.VzLPRClient_SetGPIORecvCallBack(IntPtr handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData) => VzLPRClient_SetGPIORecvCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetIOOutput(IntPtr handle, int uChnId, int nOutput) => VzLPRClient_SetIOOutput(handle, uChnId, nOutput);
        int IVzClientSdkProxy.VzLPRClient_SetIOOutputAuto(IntPtr handle, int uChnId, int nDuration) => VzLPRClient_SetIOOutputAuto(handle, uChnId, nDuration);
        int IVzClientSdkProxy.VzLPRClient_SetIsOutputRealTimeResult(IntPtr handle, bool bOutput) => VzLPRClient_SetIsOutputRealTimeResult(handle, bOutput);
        int IVzClientSdkProxy.VzLPRClient_SetIsShowPlateRect(IntPtr handle, int bShow) => VzLPRClient_SetIsShowPlateRect(handle, bShow);
        int IVzClientSdkProxy.VzLPRClient_SetLEDLightControlMode(IntPtr handle, VZ_LED_CTRL eCtrl) => VzLPRClient_SetLEDLightControlMode(handle, eCtrl);
        int IVzClientSdkProxy.VzLPRClient_SetLEDLightLevel(IntPtr handle, int nLevel) => VzLPRClient_SetLEDLightLevel(handle, nLevel);
        int IVzClientSdkProxy.VzLPRClient_SetOfflineCheck(IntPtr handle) => VzLPRClient_SetOfflineCheck(handle);
        int IVzClientSdkProxy.VzLPRClient_SetOsdParam(IntPtr handle, IntPtr pParam) => VzLPRClient_SetOsdParam(handle, pParam);
        int IVzClientSdkProxy.VzLPRClient_SetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo) => VzLPRClient_SetOutputConfig(handle, ref pOutputConfigInfo);
        int IVzClientSdkProxy.VzLPRClient_SetPlateInfoCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage) => VzLPRClient_SetPlateInfoCallBack(handle, func, pUserData, bEnableImage);
        int IVzClientSdkProxy.VzLPRClient_SetPlateRecType(IntPtr handle, uint uBitsRecType) => VzLPRClient_SetPlateRecType(handle, uBitsRecType);
        int IVzClientSdkProxy.VzLPRClient_SetPlateTrigType(IntPtr handle, uint uBitsTrigType) => VzLPRClient_SetPlateTrigType(handle, uBitsTrigType);
        int IVzClientSdkProxy.VzLPRClient_SetQueryPlateCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData) => VzLPRClient_SetQueryPlateCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetRequestTalkCallBack(IntPtr handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData) => VzLPRClient_SetRequestTalkCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter) => VzLPRClient_SetSerialParameter(handle, nSerialPort, ref pParameter);
        int IVzClientSdkProxy.VzLPRClient_SetShutter(IntPtr handle, int shutter) => VzLPRClient_SetShutter(handle, shutter);
        int IVzClientSdkProxy.VzLPRClient_SetTriggerDelay(IntPtr handle, int nDelay) => VzLPRClient_SetTriggerDelay(handle, nDelay);
        int IVzClientSdkProxy.VzLPRClient_Setup() => VzLPRClient_Setup();
        int IVzClientSdkProxy.VzLPRClient_SetVideoCBR(IntPtr handle, int rateval) => VzLPRClient_SetVideoCBR(handle, rateval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoCompressMode(IntPtr handle, int modeval) => VzLPRClient_SetVideoCompressMode(handle, modeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoEncodeType(IntPtr handle, int cmd) => VzLPRClient_SetVideoEncodeType(handle, cmd);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameCallBack(IntPtr handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData) => VzLPRClient_SetVideoFrameCallBack(handle, pFunc, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameRate(IntPtr handle, int Rateval) => VzLPRClient_SetVideoFrameRate(handle, Rateval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameSizeIndex(IntPtr handle, int sizeval) => VzLPRClient_SetVideoFrameSizeIndex(handle, sizeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameSizeIndexEx(IntPtr handle, int sizeval) => VzLPRClient_SetVideoFrameSizeIndexEx(handle, sizeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoPara(IntPtr handle, int brt, int cst, int sat, int hue) => VzLPRClient_SetVideoPara(handle, brt, cst, sat, hue);
        int IVzClientSdkProxy.VzLPRClient_SetVideoVBR(IntPtr handle, int levelval) => VzLPRClient_SetVideoVBR(handle, levelval);
        int IVzClientSdkProxy.VzLPRClient_SetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops) => VzLPRClient_SetVirtualLoop(handle, ref pVirtualLoops);
        int IVzClientSdkProxy.VzLPRClient_SetWLCheckMethod(IntPtr handle, int nType) => VzLPRClient_SetWLCheckMethod(handle, nType);
        int IVzClientSdkProxy.VzLPRClient_SetWLFuzzy(IntPtr handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC) => VzLPRClient_SetWLFuzzy(handle, nFuzzyType, nFuzzyLen, bFuzzyCC);
        int IVzClientSdkProxy.VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData) => VZLPRClient_StartFindDeviceEx(func, pUserData);
        IntPtr IVzClientSdkProxy.VzLPRClient_StartRealPlay(IntPtr handle, IntPtr hWnd) => VzLPRClient_StartRealPlay(handle, hWnd);
        int IVzClientSdkProxy.VzLPRClient_StartRealPlayDecData(IntPtr handle) => VzLPRClient_StartRealPlayDecData(handle);
        IntPtr IVzClientSdkProxy.VzLPRClient_StartRealPlayFrameCallBack(IntPtr handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData) => VzLPRClient_StartRealPlayFrameCallBack(handle, hWnd, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_StartRecordAudio(IntPtr handle, string file_path) => VzLPRClient_StartRecordAudio(handle, file_path);
        int IVzClientSdkProxy.VzLPRClient_StartTalk(IntPtr handle, int client_win_size) => VzLPRClient_StartTalk(handle, client_win_size);
        int IVzClientSdkProxy.VZLPRClient_StopFindDevice() => VZLPRClient_StopFindDevice();
        int IVzClientSdkProxy.VzLPRClient_StopRealPlay(IntPtr hRealHandle) => VzLPRClient_StopRealPlay(hRealHandle);
        int IVzClientSdkProxy.VzLPRClient_StopRealPlayDecData(IntPtr handle) => VzLPRClient_StopRealPlayDecData(handle);
        int IVzClientSdkProxy.VzLPRClient_StopRecordAudio(IntPtr handle) => VzLPRClient_StopRecordAudio(handle);
        int IVzClientSdkProxy.VzLPRClient_StopSaveRealData(IntPtr handle) => VzLPRClient_StopSaveRealData(handle);
        int IVzClientSdkProxy.VzLPRClient_StopTalk(IntPtr handle) => VzLPRClient_StopTalk(handle);
        int IVzClientSdkProxy.VzLPRClient_UpdateNetworkParam(uint sh, uint sl, string strNewIP, string strGateway, string strNetmask) => VzLPRClient_UpdateNetworkParam(sh, sl, strNewIP, strGateway, strNetmask);
        int IVzClientSdkProxy.VzLPRClient_WhiteListClearCustomersAndVehicles(IntPtr handle) => VzLPRClient_WhiteListClearCustomersAndVehicles(handle);
        int IVzClientSdkProxy.VzLPRClient_WhiteListDeleteVehicle(IntPtr handle, string strPlateID) => VzLPRClient_WhiteListDeleteVehicle(handle, strPlateID);
        int IVzClientSdkProxy.VzLPRClient_WhiteListGetRowCount(IntPtr handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere) => VzLPRClient_WhiteListGetRowCount(handle, ref count, ref pSearchWhere);
        int IVzClientSdkProxy.VzLPRClient_WhiteListGetVehicleCount(IntPtr handle, ref uint pCount, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere) => VzLPRClient_WhiteListGetVehicleCount(handle, ref pCount, ref pSearchWhere);
        int IVzClientSdkProxy.VzLPRClient_WhiteListImportRows(IntPtr handle, uint rowcount, ref VZ_LPR_WLIST_ROW pRowDatas, ref VZ_LPR_WLIST_IMPORT_RESULT pResults) => VzLPRClient_WhiteListImportRows(handle, rowcount, ref pRowDatas, ref pResults);
        int IVzClientSdkProxy.VzLPRClient_WhiteListLoadVehicle(IntPtr handle, ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition) => VzLPRClient_WhiteListLoadVehicle(handle, ref pLoadCondition);
        int IVzClientSdkProxy.VzLPRClient_WhiteListSetQueryCallBack(IntPtr handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData) => VzLPRClient_WhiteListSetQueryCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_WhiteListUpdateVehicleByID(IntPtr handle, ref VZ_LPR_WLIST_VEHICLE pVehicle) => VzLPRClient_WhiteListUpdateVehicleByID(handle, ref pVehicle);
        int IVzClientSdkProxy.VzLPRClient_WriteUserData(IntPtr handle, IntPtr pUserData, uint uSizeData) => VzLPRClient_WriteUserData(handle, pUserData, uSizeData);
        #endregion 显示实现
    }
    internal class VzClientSdkDllerX86 : IVzClientSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IVzClientSdkProxy Instance { get; } = new VzClientSdkDllerX86();
        private VzClientSdkDllerX86() { }
        /// <summary>
        /// 复制内存
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <param name="Length"></param>
        [DllImport("kernel32.dll")]
        public static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
        #region // 函数导入
        /**
        *  @brief 全局初始化，在所有接口调用之前调用
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_Setup();

        /**
        *  @brief 全局释放
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern void VzLPRClient_Cleanup();

        /**
        *  @brief 设置设备连接反馈结果相关的回调函数
        *  @param  [IN] func 设备连接结果和状态，通过该回调函数返回
        *  @param [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 打开一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @param [IN] wPort 设备的端口号
        *  @param  [IN] pStrUserName 访问设备所需用户名
        *  @param [IN] pStrPassword 访问设备所需密码
        *  @return 返回设备的操作句柄，当打开失败时，返回-1
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern IntPtr VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword);

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
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern IntPtr VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn);

        /**
        *  @brief 关闭一个设备
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_Close(IntPtr handle);

        /**
        *  @brief 通过IP地址关闭一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_CloseByIP(string pStrIP);

        /**
        *  @brief 获取连接状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param[IN/OUT] pStatus 输入获取状态的变量地址，输出内容为 1已连上，0未连上
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_IsConnected(IntPtr handle, ref byte pStatus);

        /**
        *  @brief 根据句柄获取设备的IP
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] ip  相机IP
        *  @param [IN] max_count IP传入长度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetDeviceIP(IntPtr handle, ref byte ip, int max_count);

        /**
        *  @brief 播放实时视频
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 播放句柄，小于0表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern IntPtr VzLPRClient_StartRealPlay(IntPtr handle, IntPtr hWnd);

        /**
        *  @brief 停止正在播放的窗口上的实时视频
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StopRealPlay(IntPtr hRealHandle);

        /**
        *  @brief 设置识别结果的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86, CallingConvention = CallingConvention.StdCall)]
        public static extern int VzLPRClient_SetPlateInfoCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage);

        /**
        *  @brief 设置实时图像数据的回调函数
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86, CallingConvention = CallingConvention.StdCall)]
        public static extern int VzLPRClient_SetVideoFrameCallBack(IntPtr handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData);
        /// <summary>
        /// 发送软件触发信号，强制处理当前时刻的数据并输出结果
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>0表示成功，-1表示失败</returns>
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_ForceTrigger(IntPtr handle);

        /**
        *  @brief 设置虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的识别区域
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pROI 识别区域的结构体指针
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetRegionOfInterestEx(IntPtr handle, ref VZ_LPRC_ROI_EX pROI);

        /**
        *  @brief 获取已设置的预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pProvInfo 预设省份信息指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetSupportedProvinces(IntPtr handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo);

        /**
        *  @brief 设置预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nIndex 设置预设省份的序号，序号需要参考VZ_LPRC_PROVINCE_INFO::strProvinces中的顺序，从0开始，如果小于0，则表示不设置预设省份
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_PresetProvinceIndex(IntPtr handle, int nIndex);

        /**
        *  @brief 将图像保存为JPEG到指定路径
        *  @param  [IN] pImgInfo 图像结构体，目前只支持默认的格式，即ImageFormatRGB
        *  @param  [IN] pFullPathName 设带绝对路径和JPG后缀名的文件名字符串
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return 0表示成功，-1表示失败
        *  @note   给定的文件名中的路径需要存在
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality);
        /// <summary>
        /// 将图像保存为JPEG到指定路径，可指定图像尺寸的模式
        /// </summary>
        /// <param name="pImgInfo">图像结构体，目前只支持默认的格式，即ImageFormatRGB</param>
        /// <param name="pFullPathName">设带绝对路径和JPG后缀名的文件名字符串</param>
        /// <param name="nQuality">JPEG压缩的质量，取值范围1~100</param>
        /// <param name="sizeMode">图像大小的模式</param>
        /// <returns></returns>
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_ImageSaveToJpegEx(VZ_LPRC_IMAGE_INFO pImgInfo, string pFullPathName, int nQuality, IMG_SIZE_MODE sizeMode);

        /**
        *  @brief 读出设备序列号，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pSN 用于存放读到的设备序列号，详见定义 VZ_DEV_SERIAL_NUM
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetSerialNumber(IntPtr handle, ref VZ_DEV_SERIAL_NUM pSN);

        /**
        *  @brief 保存正在播放的视频的当前帧的截图到指定路径
        *  @param  [IN] nPlayHandle 播放的句柄
        *  @param  [IN] pFullPathName 设带绝对路径和JPG后缀名的文件名字符串
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return 0表示成功，-1表示失败
        *  @note   使用的文件名中的路径需要存在
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetSnapShootToJpeg2(IntPtr nPlayHandle, string pFullPathName, int nQuality);

        /// <summary>
        /// 保存抓图数据到Jpeg文件
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pFullPathName">图片路径</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败</returns>
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SaveSnapImageToJpeg(IntPtr handle, string pFullPathName);

        /**
        *  @brief 开启透明通道
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] func 接收数据的回调函数
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *  @return 返回透明通道句柄，0表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern IntPtr VzLPRClient_SerialStart(IntPtr handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 透明通道发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @param [IN] pData 将要传输的数据块的首地址
        *  @param [IN] uSizeData 将要传输的数据块的字节数
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SerialSend(IntPtr nSerialHandle, IntPtr pData, int uSizeData);

        /**
        *  @brief 透明通道停止发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SerialStop(IntPtr nSerialHandle);

        /**
        *  @brief 设置IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] nOutput 将要设置的IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetIOOutput(IntPtr handle, int uChnId, int nOutput);

        /**
        *  @brief 获取IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] pOutput IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetIOOutput(IntPtr handle, int uChnId, ref int pOutput);

        /**
        *  @brief 获取GPIO的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] gpioIn 数据为0或1
        *  @param  [OUT] value 0代表短路，1代表开路
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, out int value);

        /**
        *  @brief 根据ID获取车牌图片
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] id     车牌记录的ID
        *  @param  [IN] pdata  存储图片的内存
        *  @param  [IN][OUT] size 为传入传出值，传入为图片内存的大小，返回的是获取到jpg图片内存的大小
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_LoadImageById(IntPtr handle, int id, IntPtr pdata, IntPtr size);

        /**
        *  @brief 向白名单表导入客户和车辆记录
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] rowcount 记录的条数
        *  @param  [IN] pRowDatas 记录的内容数组的地址
        *  @param  [OUT] results 每条数据是否导入成功
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListImportRows(IntPtr handle,
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
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListDeleteVehicle(IntPtr handle, string strPlateID);

        /**
        *  @brief 清空数据库客户信息和车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListClearCustomersAndVehicles(IntPtr handle);

        /**
        *  @brief 获取白名单表中所有车辆信息记录的条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return >=0表示所有车辆信息记录的总数，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListGetVehicleCount(IntPtr handle, ref uint pCount,
                                                                 ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 查询白名单表车辆记录数据
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pLoadCondition 查询条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListLoadVehicle(IntPtr handle,
                                                            ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition);

        /**
        *  @brief 设置白名单表和客户信息表的查询结果回调
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 查询结果回调函数
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListSetQueryCallBack(IntPtr handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 往白名单表中更新一个车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVehicle 将要更新的车辆信息，详见结构体定义VZ_LPR_WLIST_VEHICLE
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListUpdateVehicleByID(IntPtr handle, ref VZ_LPR_WLIST_VEHICLE pVehicle);

        /**
        *  @brief 查询白名单表客户和车辆记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pCount 记录的条数
        *  @param  [IN] search_constraints 搜索的条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WhiteListGetRowCount(IntPtr handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 设置LED控制模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] eCtrl 控制LED开关模式，详见定义 VZ_LED_CTRL
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetLEDLightControlMode(IntPtr handle, VZ_LED_CTRL eCtrl);
        /**
        *  @brief 获取LED当前亮度等级和最大亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pLevelNow 用于输出当前亮度等级的地址
        *  @param [OUT] pLevelMax 用于输出最高亮度等级的地址
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetLEDLightStatus(IntPtr handle, ref int pLevelNow, ref int pLevelMax);

        /**
        *  @brief 设置LED亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nLevel，LED亮度等级
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetLEDLightLevel(IntPtr handle, int nLevel);

        /**
        *  @brief 开始录像功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sFileName 录像文件的路径
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SaveRealData(IntPtr handle, string sFileName);

        /**
        *  @brief 停止录像
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StopSaveRealData(IntPtr handle);

        /**
        *  @brief 开启脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetOfflineCheck(IntPtr handle);

        /**
        *  @brief 关闭脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_CancelOfflineCheck(IntPtr handle);

        /**
        *  @brief 开始查找设备
        *  @param  [IN] func 找到的设备通过该回调函数返回
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 停止查找设备
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VZLPRClient_StopFindDevice();

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
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_QueryRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword);

        /**
        *  @brief 根据时间和车牌号查询记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pStartTime 起始时间，格式如"2015-01-02 12:20:30"
        *  @param  [IN] pEndTime   起始时间，格式如"2015-01-02 19:20:30"
        *  @param  [IN] keyword    车牌号关键字, 如"川"
        *  @return 返回值为0表示失败，大于0表示记录条数
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_QueryCountByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword);

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
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_QueryPageRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword, int start, int end);

        /**
        *  @brief 设置查询车牌记录的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数，如果为NULL，则表示关闭该回调函数的功能
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetQueryPlateCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置设备的日期时间
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDTInfo 将要设置的设备日期时间信息，详见定义 VZ_DATE_TIME_INFO
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetDateTime(IntPtr handle, IntPtr IntpDTInfo);

        /**
        *  @brief 读出用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pBuffer 用于存放读到的用户数据
        *  @param [IN] uSizeBuf 用户数据缓冲区的最小尺寸，不小于128字节
        *  @return 返回值为实际用户数据的字节数，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_ReadUserData(IntPtr handle, IntPtr pBuffer, uint uSizeBuf);

        /**
        *  @brief 写入用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pUserData 用户数据
        *  @param [IN] uSizeData 用户数据的长度，最大128字节
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_WriteUserData(IntPtr handle, IntPtr pUserData, uint uSizeData);

        /**
        *  @brief 将图像编码为JPEG，保存到指定内存
        *  @param  [IN] pImgInfo 图像结构体，目前只支持默认的格式，即ImageFormatRGB
        *  @param  [IN/OUT] pDstBuf JPEG数据的目的存储首地址
        *  @param  [IN] uSizeBuf JPEG数据地址的内存的最大尺寸；
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return >0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality);

        /**
        *  @brief 设置IO输出，并自动复位
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [IN] nDuration 延时时间，取值范围[500, 5000]毫秒
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetIOOutputAuto(IntPtr handle, int uChnId, int nDuration);

        /**
        *  @brief 获取实时视频帧，图像数据通过回调函数到用户层，用户可改动图像内容，并且显示到窗口
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd		窗口的句柄，如果为有效值，则视频图像会显示到该窗口上，如果为空，则不显示视频图像
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 播放的句柄，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr VzLPRClient_StartRealPlayFrameCallBack(IntPtr handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 获取已设置的允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsTrigType 允许的车牌识别触发类型按位或的变量的地址，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetPlateTrigType(IntPtr handle, ref int pBitsTrigType);

        /**
        *  @brief 设置允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] uBitsTrigType 允许的车牌识别触发类型按位或的值，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        *  @note  如果设置不允许某种类型的触发，那么该种类型的触发结果也不会保存在设备的SD卡中
        *  @note  默认输出稳定触发和虚拟线圈触发
        *  @note  不会影响手动触发和IO输入触发
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetPlateTrigType(IntPtr handle, UInt32 uBitsTrigType);

        /**
        *  @brief 获取智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 设置智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 获取已设置的需要识别的车牌类型位
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsRecType 需要识别的车牌类型按位或的变量的地址，车牌类型位详见定义VZ_LPRC_REC_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetPlateRecType(IntPtr handle, ref int pBitsRecType);

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
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetPlateRecType(IntPtr handle, UInt32 uBitsRecType);

        /**
        *  @brief 获取输出配置0
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置输出配置
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetTriggerDelay(IntPtr handle, int nDelay);

        /**
        *  @brief 获取车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetTriggerDelay(IntPtr handle, ref int nDelay);

        /**
        *  @brief 设置白名单验证模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetWLCheckMethod(IntPtr handle, int nType);

        /**
        *  @brief 获取白名单验证模式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT]	nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetWLCheckMethod(IntPtr handle, ref int nType);

        /**
        *  @brief 设置白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetWLFuzzy(IntPtr handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC);

        /**
        *  @brief 获取白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetWLFuzzy(IntPtr handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC);

        /**
        *  @brief 设置串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] pParameter 将要设置的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetSerialParameter(IntPtr handle, int nSerialPort,
                                                         ref VZ_SERIAL_PARAMETER pParameter);

        /**
        *  @brief 获取串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [OUT] pParameter 将要获取的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter);
        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoFrameSizeIndex(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoFrameSizeIndex(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoFrameSizeIndexEx(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoFrameSizeIndexEx(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流帧率
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoFrameRate(IntPtr handle, ref int Rateval);//1-25

        /**
        *  @brief 设置主码流帧率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoFrameRate(IntPtr handle, int Rateval);//1-25

        /**
        *  @brief 获取主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoCompressMode(IntPtr handle, ref int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 设置主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoCompressMode(IntPtr handle, int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 获取主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @param [OUT] ratelist 暂时不用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoCBR(IntPtr handle, ref int rateval/*Kbps*/, ref int ratelist);

        /**
        *  @brief 设置主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoCBR(IntPtr handle, int rateval/*Kbps*/);

        /**
        *  @brief 获取视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] brt 亮度
        *  @param [OUT] cst 对比度
        *  @param [OUT] sat 饱和度
        *  @param [OUT] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoPara(IntPtr handle, ref int brt, ref int cst, ref int sat, ref int hue);

        /**
        *  @brief 设置视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] brt 亮度
        *  @param [IN] cst 对比度
        *  @param [IN] sat 饱和度
        *  @param [IN] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoPara(IntPtr handle, int brt, int cst, int sat, int hue);

        /**
        *  @brief 设置通道主码流编码方式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] cmd    返回的编码方式, 0->H264  1->MPEG4  2->JPEG  其他->错误
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoEncodeType(IntPtr handle, int cmd);

        /**
        *  @brief 获取视频的编码方式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pEncType	返回的编码方式, 0:H264  1:MPEG4  2:JPEG  其他:错误
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoEncodeType(IntPtr handle, ref int pEncType);

        /**
        *  @brief 获取视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetVideoVBR(IntPtr handle, ref int levelval);

        /**
        *  @brief 设置视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetVideoVBR(IntPtr handle, int levelval);

        /**
        *  @brief 获取视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetFrequency(IntPtr handle, ref int frequency);

        /**
        *  @brief 设置视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetFrequency(IntPtr handle, int frequency);

        /**
        *  @brief 获取曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetShutter(IntPtr handle, ref int shutter);

        /**
        *  @brief 设置曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetShutter(IntPtr handle, int shutter);

        /**
        *  @brief 获取图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetFlip(IntPtr handle, ref int flip);

        /**
        *  @brief 设置图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetFlip(IntPtr handle, int flip);

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
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_UpdateNetworkParam(uint sh, uint sl, string strNewIP, string strGateway, string strNetmask);

        /**
        *  @brief 获取设备序列号；
        *  @param [IN] ip ip统一使用字符串的形式传入
        *  @param [IN] port 使用和登录时相同的端口
        *  @param [OUT] SerHi 序列号高位
        *  @param [OUT] SerLo 序列号低位
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo);

        /**
        *  @brief 开始实时图像数据流，用于实时获取图像数据
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StartRealPlayDecData(IntPtr handle);

        /**
        *  @brief 停止实时图像数据流
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StopRealPlayDecData(IntPtr handle);

        /**
        *  @brief 从解码流中获取JPEG图像，保存到指定内存
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN/OUT] pDstBuf JPEG数据的目的存储首地址
        *  @param  [IN] uSizeBuf JPEG数据地址的内存的最大尺寸；
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return >0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetJpegStreamFromRealPlayDec(IntPtr handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality);

        /**
        *  @brief 设置是否输出实时结果
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] bOutput 是否输出
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetIsOutputRealTimeResult(IntPtr handle, bool bOutput);

        /**
        *  @brief 获取设备加密类型和当前加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pData 加密信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetEMS(IntPtr handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData);
        /**
        *  @brief 设置设备加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] nEncyptId	修改的加密类型ID 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetEncrypt(IntPtr handle, IntPtr pCurrentKey, UInt32 nEncyptId);

        /**
        *  @brief 修改设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_ChangeEncryptKey(IntPtr handle, IntPtr pCurrentKey, IntPtr pNewKey);

        /**
        *  @brief 重置设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pPrimeKey 当前设备主密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_ResetEncryptKey(IntPtr handle, IntPtr pPrimeKey, IntPtr pNewKey);

        /**
        *  @brief 语音播放功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] voice 播放的语音文字
        *  @param [IN] interval 语音文件的播放间隔(0-5000)
        *  @param [IN] volume 声音大小(0-100)
        *  @param [IN] male 声音类型(男声0，女生1)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_PlayVoice(IntPtr handle, string voice, int interval, int volume, int male);

        //**************************************************************
        // 中心服务器配置
        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 获取中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 设置中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 获取中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 设置中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 获取中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 获取中心服务器网络端口触发信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerGionin  中心服务器端口触发信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 设置中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 获取中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 设置中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetCenterServerHostBak(IntPtr handle, string pCenterServerHostBak);

        /**
        *  @brief 获取中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetCenterServerHostBak(IntPtr handle, ref string pCenterServerHostBak);

        /**
        *  @brief 获取设备硬件信息
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_version  设备类型
        *  @param [OUT] exdataSize 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetHwBoardVersion(IntPtr handle, ref int board_version, ref Int64 exdataSize);

        /**
        *  @brief 获取设备硬件类型
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_type  设备类型(0:3730,1:6446,2:8127)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetHwBoardType(IntPtr handle, ref int board_type);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetAlgResultParam(IntPtr handle, ref int reco_dis);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetAlgResultParam(IntPtr handle, int reco_dis);

        /**
        *  @brief 获取图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetDenoise(IntPtr handle, ref int mode, ref int strength);

        /**
        *  @brief 设置图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetDenoise(IntPtr handle, int mode, int strength);

        /**
        *  @brief 获取R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流 
        *  @param [OUT] param 编码参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_RGet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 设置R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_RSet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 获取R相机支持的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_RGet_Encode_Param_Property(IntPtr handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] param 视频参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_RGet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_RSet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 开始喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] client_win_size 客户端窗口大小
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StartTalk(IntPtr handle, int client_win_size);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetRequestTalkCallBack(IntPtr handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 停止喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] device_ip 设备IP
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StopTalk(IntPtr handle);

        /**
        *  @brief 开始录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] file_path 音频文件路径
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StartRecordAudio(IntPtr handle, string file_path);

        /**
        *  @brief 停止录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_StopRecordAudio(IntPtr handle);

        /**
        *  @brief 设置车牌图片里是否显示车牌框
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] bShow 是否显示车牌框，输入值(0或1)，1代表显示，0代表不显示
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetIsShowPlateRect(IntPtr handle, int bShow);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_SetGPIORecvCallBack(IntPtr handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取相机参数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] command 命令类型
        *  @param [IN] channel 通道号，默认为0
        *  @param [OUT] pOutBuffer 返回的数据
        *  @param [IN] dwOutBufferSize 数据的长度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileNameX86)]
        public static extern int VzLPRClient_GetCameraConfig(IntPtr handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize);
        #endregion // 函数导入
        #region // 显示实现
        void IVzClientSdkProxy.CopyMemory(IntPtr Destination, IntPtr Source, int Length) => CopyMemory(Destination, Source, Length);
        int IVzClientSdkProxy.VzLPRClient_CancelOfflineCheck(IntPtr handle) => VzLPRClient_CancelOfflineCheck(handle);
        int IVzClientSdkProxy.VzLPRClient_ChangeEncryptKey(IntPtr handle, IntPtr pCurrentKey, IntPtr pNewKey) => VzLPRClient_ChangeEncryptKey(handle, pCurrentKey, pNewKey);
        void IVzClientSdkProxy.VzLPRClient_Cleanup() => VzLPRClient_Cleanup();
        int IVzClientSdkProxy.VzLPRClient_Close(IntPtr handle) => VzLPRClient_Close(handle);
        int IVzClientSdkProxy.VzLPRClient_CloseByIP(string pStrIP) => VzLPRClient_CloseByIP(pStrIP);
        int IVzClientSdkProxy.VzLPRClient_ForceTrigger(IntPtr handle) => VzLPRClient_ForceTrigger(handle);
        int IVzClientSdkProxy.VzLPRClient_GetAlgResultParam(IntPtr handle, ref int reco_dis) => VzLPRClient_GetAlgResultParam(handle, ref reco_dis);
        int IVzClientSdkProxy.VzLPRClient_GetCameraConfig(IntPtr handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize) => VzLPRClient_GetCameraConfig(handle, command, channel, pOutBuffer, dwOutBufferSize);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg) => VzLPRClient_GetCenterServerDeviceReg(handle, ref pCenterServerDeviceReg);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin) => VzLPRClient_GetCenterServerGionin(handle, ref pCenterServerGionin);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerHostBak(IntPtr handle, ref string pCenterServerHostBak) => VzLPRClient_GetCenterServerHostBak(handle, ref pCenterServerHostBak);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet) => VzLPRClient_GetCenterServerNet(handle, ref pCenterServerNet);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate) => VzLPRClient_GetCenterServerPlate(handle, ref pCenterServerPlate);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial) => VzLPRClient_GetCenterServerSerial(handle, ref pCenterServerSerial);
        int IVzClientSdkProxy.VzLPRClient_GetDenoise(IntPtr handle, ref int mode, ref int strength) => VzLPRClient_GetDenoise(handle, ref mode, ref strength);
        int IVzClientSdkProxy.VzLPRClient_GetDeviceIP(IntPtr handle, ref byte ip, int max_count) => VzLPRClient_GetDeviceIP(handle, ref ip, max_count);
        int IVzClientSdkProxy.VzLPRClient_GetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode) => VzLPRClient_GetDrawMode(handle, ref pDrawMode);
        int IVzClientSdkProxy.VzLPRClient_GetEMS(IntPtr handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData) => VzLPRClient_GetEMS(handle, ref pData);
        int IVzClientSdkProxy.VzLPRClient_GetFlip(IntPtr handle, ref int flip) => VzLPRClient_GetFlip(handle, ref flip);
        int IVzClientSdkProxy.VzLPRClient_GetFrequency(IntPtr handle, ref int frequency) => VzLPRClient_GetFrequency(handle, ref frequency);
        int IVzClientSdkProxy.VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, out int value) => VzLPRClient_GetGPIOValue(handle, gpioIn, out value);
        int IVzClientSdkProxy.VzLPRClient_GetHwBoardType(IntPtr handle, ref int board_type) => VzLPRClient_GetHwBoardType(handle, ref board_type);
        int IVzClientSdkProxy.VzLPRClient_GetHwBoardVersion(IntPtr handle, ref int board_version, ref long exdataSize) => VzLPRClient_GetHwBoardVersion(handle, ref board_version, ref exdataSize);
        int IVzClientSdkProxy.VzLPRClient_GetIOOutput(IntPtr handle, int uChnId, ref int pOutput) => VzLPRClient_GetIOOutput(handle, uChnId, ref pOutput);
        int IVzClientSdkProxy.VzLPRClient_GetJpegStreamFromRealPlayDec(IntPtr handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality) => VzLPRClient_GetJpegStreamFromRealPlayDec(handle, pDstBuf, uSizeBuf, nQuality);
        int IVzClientSdkProxy.VzLPRClient_GetLEDLightStatus(IntPtr handle, ref int pLevelNow, ref int pLevelMax) => VzLPRClient_GetLEDLightStatus(handle, ref pLevelNow, ref pLevelMax);
        int IVzClientSdkProxy.VzLPRClient_GetOsdParam(IntPtr handle, IntPtr pParam) => VzLPRClient_GetOsdParam(handle, pParam);
        int IVzClientSdkProxy.VzLPRClient_GetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo) => VzLPRClient_GetOutputConfig(handle, ref pOutputConfigInfo);
        int IVzClientSdkProxy.VzLPRClient_GetPlateRecType(IntPtr handle, ref int pBitsRecType) => VzLPRClient_GetPlateRecType(handle, ref pBitsRecType);
        int IVzClientSdkProxy.VzLPRClient_GetPlateTrigType(IntPtr handle, ref int pBitsTrigType) => VzLPRClient_GetPlateTrigType(handle, ref pBitsTrigType);
        int IVzClientSdkProxy.VzLPRClient_GetRegionOfInterestEx(IntPtr handle, ref VZ_LPRC_ROI_EX pROI) => VzLPRClient_GetRegionOfInterestEx(handle, ref pROI);
        int IVzClientSdkProxy.VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo) => VzLPRClient_GetSerialNo(ip, port, ref SerHi, ref SerLo);
        int IVzClientSdkProxy.VzLPRClient_GetSerialNumber(IntPtr handle, ref VZ_DEV_SERIAL_NUM pSN) => VzLPRClient_GetSerialNumber(handle, ref pSN);
        int IVzClientSdkProxy.VzLPRClient_GetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter) => VzLPRClient_GetSerialParameter(handle, nSerialPort, ref pParameter);
        int IVzClientSdkProxy.VzLPRClient_GetShutter(IntPtr handle, ref int shutter) => VzLPRClient_GetShutter(handle, ref shutter);
        int IVzClientSdkProxy.VzLPRClient_GetSnapShootToJpeg2(IntPtr nPlayHandle, string pFullPathName, int nQuality) => VzLPRClient_GetSnapShootToJpeg2(nPlayHandle, pFullPathName, nQuality);
        int IVzClientSdkProxy.VzLPRClient_SaveSnapImageToJpeg(IntPtr handle, string pFullPathName) => VzLPRClient_SaveSnapImageToJpeg(handle, pFullPathName);
        int IVzClientSdkProxy.VzLPRClient_GetSupportedProvinces(IntPtr handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo) => VzLPRClient_GetSupportedProvinces(handle, ref pProvInfo);
        int IVzClientSdkProxy.VzLPRClient_GetTriggerDelay(IntPtr handle, ref int nDelay) => VzLPRClient_GetTriggerDelay(handle, ref nDelay);
        int IVzClientSdkProxy.VzLPRClient_GetVideoCBR(IntPtr handle, ref int rateval, ref int ratelist) => VzLPRClient_GetVideoCBR(handle, ref rateval, ref ratelist);
        int IVzClientSdkProxy.VzLPRClient_GetVideoCompressMode(IntPtr handle, ref int modeval) => VzLPRClient_GetVideoCompressMode(handle, ref modeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoEncodeType(IntPtr handle, ref int pEncType) => VzLPRClient_GetVideoEncodeType(handle, ref pEncType);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameRate(IntPtr handle, ref int Rateval) => VzLPRClient_GetVideoFrameRate(handle, ref Rateval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameSizeIndex(IntPtr handle, ref int sizeval) => VzLPRClient_GetVideoFrameSizeIndex(handle, ref sizeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameSizeIndexEx(IntPtr handle, ref int sizeval) => VzLPRClient_GetVideoFrameSizeIndexEx(handle, ref sizeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoPara(IntPtr handle, ref int brt, ref int cst, ref int sat, ref int hue) => VzLPRClient_GetVideoPara(handle, ref brt, ref cst, ref sat, ref hue);
        int IVzClientSdkProxy.VzLPRClient_GetVideoVBR(IntPtr handle, ref int levelval) => VzLPRClient_GetVideoVBR(handle, ref levelval);
        int IVzClientSdkProxy.VzLPRClient_GetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops) => VzLPRClient_GetVirtualLoop(handle, ref pVirtualLoops);
        int IVzClientSdkProxy.VzLPRClient_GetWLCheckMethod(IntPtr handle, ref int nType) => VzLPRClient_GetWLCheckMethod(handle, ref nType);
        int IVzClientSdkProxy.VzLPRClient_GetWLFuzzy(IntPtr handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC) => VzLPRClient_GetWLFuzzy(handle, ref nFuzzyType, ref nFuzzyLen, ref bFuzzyCC);
        int IVzClientSdkProxy.VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality) => VzLPRClient_ImageEncodeToJpeg(pImgInfo, pDstBuf, uSizeBuf, nQuality);
        int IVzClientSdkProxy.VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality) => VzLPRClient_ImageSaveToJpeg(pImgInfo, pFullPathName, nQuality);
        int IVzClientSdkProxy.VzLPRClient_ImageSaveToJpegEx(VZ_LPRC_IMAGE_INFO pImgInfo, string pFullPathName, int nQuality, IMG_SIZE_MODE sizeMode) => VzLPRClient_ImageSaveToJpegEx(pImgInfo, pFullPathName, nQuality, sizeMode);
        int IVzClientSdkProxy.VzLPRClient_IsConnected(IntPtr handle, ref byte pStatus) => VzLPRClient_IsConnected(handle, ref pStatus);
        int IVzClientSdkProxy.VzLPRClient_LoadImageById(IntPtr handle, int id, IntPtr pdata, IntPtr size) => VzLPRClient_LoadImageById(handle, id, pdata, size);
        IntPtr IVzClientSdkProxy.VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword) => VzLPRClient_Open(pStrIP, wPort, pStrUserName, pStrPassword);
        IntPtr IVzClientSdkProxy.VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn) => VzLPRClient_OpenV2(pStrIP, wPort, pStrUserName, pStrPassword, wRtspPort, network_type, sn);
        int IVzClientSdkProxy.VzLPRClient_PlayVoice(IntPtr handle, string voice, int interval, int volume, int male) => VzLPRClient_PlayVoice(handle, voice, interval, volume, male);
        int IVzClientSdkProxy.VzLPRClient_PresetProvinceIndex(IntPtr handle, int nIndex) => VzLPRClient_PresetProvinceIndex(handle, nIndex);
        int IVzClientSdkProxy.VzLPRClient_QueryCountByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword) => VzLPRClient_QueryCountByTimeAndPlate(handle, pStartTime, pEndTime, keyword);
        int IVzClientSdkProxy.VzLPRClient_QueryPageRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword, int start, int end) => VzLPRClient_QueryPageRecordByTimeAndPlate(handle, pStartTime, pEndTime, keyword, start, end);
        int IVzClientSdkProxy.VzLPRClient_QueryRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword) => VzLPRClient_QueryRecordByTimeAndPlate(handle, pStartTime, pEndTime, keyword);
        int IVzClientSdkProxy.VzLPRClient_ReadUserData(IntPtr handle, IntPtr pBuffer, uint uSizeBuf) => VzLPRClient_ReadUserData(handle, pBuffer, uSizeBuf);
        int IVzClientSdkProxy.VzLPRClient_ResetEncryptKey(IntPtr handle, IntPtr pPrimeKey, IntPtr pNewKey) => VzLPRClient_ResetEncryptKey(handle, pPrimeKey, pNewKey);
        int IVzClientSdkProxy.VzLPRClient_RGet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param) => VzLPRClient_RGet_Encode_Param(handle, stream, ref param);
        int IVzClientSdkProxy.VzLPRClient_RGet_Encode_Param_Property(IntPtr handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param) => VzLPRClient_RGet_Encode_Param_Property(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_RGet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param) => VzLPRClient_RGet_Video_Param(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_RSet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param) => VzLPRClient_RSet_Encode_Param(handle, stream, ref param);
        int IVzClientSdkProxy.VzLPRClient_RSet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param) => VzLPRClient_RSet_Video_Param(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_SaveRealData(IntPtr handle, string sFileName) => VzLPRClient_SaveRealData(handle, sFileName);
        int IVzClientSdkProxy.VzLPRClient_SerialSend(IntPtr nSerialHandle, IntPtr pData, int uSizeData) => VzLPRClient_SerialSend(nSerialHandle, pData, uSizeData);
        IntPtr IVzClientSdkProxy.VzLPRClient_SerialStart(IntPtr handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData) => VzLPRClient_SerialStart(handle, nSerialPort, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SerialStop(IntPtr nSerialHandle) => VzLPRClient_SerialStop(nSerialHandle);
        int IVzClientSdkProxy.VzLPRClient_SetAlgResultParam(IntPtr handle, int reco_dis) => VzLPRClient_SetAlgResultParam(handle, reco_dis);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg) => VzLPRClient_SetCenterServerDeviceReg(handle, ref pCenterServerDeviceReg);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin) => VzLPRClient_SetCenterServerGionin(handle, ref pCenterServerGionin);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerHostBak(IntPtr handle, string pCenterServerHostBak) => VzLPRClient_SetCenterServerHostBak(handle, pCenterServerHostBak);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet) => VzLPRClient_SetCenterServerNet(handle, ref pCenterServerNet);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate) => VzLPRClient_SetCenterServerPlate(handle, ref pCenterServerPlate);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial) => VzLPRClient_SetCenterServerSerial(handle, ref pCenterServerSerial);
        int IVzClientSdkProxy.VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData) => VZLPRClient_SetCommonNotifyCallBack(func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetDateTime(IntPtr handle, IntPtr IntpDTInfo) => VzLPRClient_SetDateTime(handle, IntpDTInfo);
        int IVzClientSdkProxy.VzLPRClient_SetDenoise(IntPtr handle, int mode, int strength) => VzLPRClient_SetDenoise(handle, mode, strength);
        int IVzClientSdkProxy.VzLPRClient_SetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode) => VzLPRClient_SetDrawMode(handle, ref pDrawMode);
        int IVzClientSdkProxy.VzLPRClient_SetEncrypt(IntPtr handle, IntPtr pCurrentKey, uint nEncyptId) => VzLPRClient_SetEncrypt(handle, pCurrentKey, nEncyptId);
        int IVzClientSdkProxy.VzLPRClient_SetFlip(IntPtr handle, int flip) => VzLPRClient_SetFlip(handle, flip);
        int IVzClientSdkProxy.VzLPRClient_SetFrequency(IntPtr handle, int frequency) => VzLPRClient_SetFrequency(handle, frequency);
        int IVzClientSdkProxy.VzLPRClient_SetGPIORecvCallBack(IntPtr handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData) => VzLPRClient_SetGPIORecvCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetIOOutput(IntPtr handle, int uChnId, int nOutput) => VzLPRClient_SetIOOutput(handle, uChnId, nOutput);
        int IVzClientSdkProxy.VzLPRClient_SetIOOutputAuto(IntPtr handle, int uChnId, int nDuration) => VzLPRClient_SetIOOutputAuto(handle, uChnId, nDuration);
        int IVzClientSdkProxy.VzLPRClient_SetIsOutputRealTimeResult(IntPtr handle, bool bOutput) => VzLPRClient_SetIsOutputRealTimeResult(handle, bOutput);
        int IVzClientSdkProxy.VzLPRClient_SetIsShowPlateRect(IntPtr handle, int bShow) => VzLPRClient_SetIsShowPlateRect(handle, bShow);
        int IVzClientSdkProxy.VzLPRClient_SetLEDLightControlMode(IntPtr handle, VZ_LED_CTRL eCtrl) => VzLPRClient_SetLEDLightControlMode(handle, eCtrl);
        int IVzClientSdkProxy.VzLPRClient_SetLEDLightLevel(IntPtr handle, int nLevel) => VzLPRClient_SetLEDLightLevel(handle, nLevel);
        int IVzClientSdkProxy.VzLPRClient_SetOfflineCheck(IntPtr handle) => VzLPRClient_SetOfflineCheck(handle);
        int IVzClientSdkProxy.VzLPRClient_SetOsdParam(IntPtr handle, IntPtr pParam) => VzLPRClient_SetOsdParam(handle, pParam);
        int IVzClientSdkProxy.VzLPRClient_SetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo) => VzLPRClient_SetOutputConfig(handle, ref pOutputConfigInfo);
        int IVzClientSdkProxy.VzLPRClient_SetPlateInfoCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage) => VzLPRClient_SetPlateInfoCallBack(handle, func, pUserData, bEnableImage);
        int IVzClientSdkProxy.VzLPRClient_SetPlateRecType(IntPtr handle, uint uBitsRecType) => VzLPRClient_SetPlateRecType(handle, uBitsRecType);
        int IVzClientSdkProxy.VzLPRClient_SetPlateTrigType(IntPtr handle, uint uBitsTrigType) => VzLPRClient_SetPlateTrigType(handle, uBitsTrigType);
        int IVzClientSdkProxy.VzLPRClient_SetQueryPlateCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData) => VzLPRClient_SetQueryPlateCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetRequestTalkCallBack(IntPtr handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData) => VzLPRClient_SetRequestTalkCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter) => VzLPRClient_SetSerialParameter(handle, nSerialPort, ref pParameter);
        int IVzClientSdkProxy.VzLPRClient_SetShutter(IntPtr handle, int shutter) => VzLPRClient_SetShutter(handle, shutter);
        int IVzClientSdkProxy.VzLPRClient_SetTriggerDelay(IntPtr handle, int nDelay) => VzLPRClient_SetTriggerDelay(handle, nDelay);
        int IVzClientSdkProxy.VzLPRClient_Setup() => VzLPRClient_Setup();
        int IVzClientSdkProxy.VzLPRClient_SetVideoCBR(IntPtr handle, int rateval) => VzLPRClient_SetVideoCBR(handle, rateval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoCompressMode(IntPtr handle, int modeval) => VzLPRClient_SetVideoCompressMode(handle, modeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoEncodeType(IntPtr handle, int cmd) => VzLPRClient_SetVideoEncodeType(handle, cmd);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameCallBack(IntPtr handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData) => VzLPRClient_SetVideoFrameCallBack(handle, pFunc, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameRate(IntPtr handle, int Rateval) => VzLPRClient_SetVideoFrameRate(handle, Rateval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameSizeIndex(IntPtr handle, int sizeval) => VzLPRClient_SetVideoFrameSizeIndex(handle, sizeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameSizeIndexEx(IntPtr handle, int sizeval) => VzLPRClient_SetVideoFrameSizeIndexEx(handle, sizeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoPara(IntPtr handle, int brt, int cst, int sat, int hue) => VzLPRClient_SetVideoPara(handle, brt, cst, sat, hue);
        int IVzClientSdkProxy.VzLPRClient_SetVideoVBR(IntPtr handle, int levelval) => VzLPRClient_SetVideoVBR(handle, levelval);
        int IVzClientSdkProxy.VzLPRClient_SetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops) => VzLPRClient_SetVirtualLoop(handle, ref pVirtualLoops);
        int IVzClientSdkProxy.VzLPRClient_SetWLCheckMethod(IntPtr handle, int nType) => VzLPRClient_SetWLCheckMethod(handle, nType);
        int IVzClientSdkProxy.VzLPRClient_SetWLFuzzy(IntPtr handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC) => VzLPRClient_SetWLFuzzy(handle, nFuzzyType, nFuzzyLen, bFuzzyCC);
        int IVzClientSdkProxy.VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData) => VZLPRClient_StartFindDeviceEx(func, pUserData);
        IntPtr IVzClientSdkProxy.VzLPRClient_StartRealPlay(IntPtr handle, IntPtr hWnd) => VzLPRClient_StartRealPlay(handle, hWnd);
        int IVzClientSdkProxy.VzLPRClient_StartRealPlayDecData(IntPtr handle) => VzLPRClient_StartRealPlayDecData(handle);
        IntPtr IVzClientSdkProxy.VzLPRClient_StartRealPlayFrameCallBack(IntPtr handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData) => VzLPRClient_StartRealPlayFrameCallBack(handle, hWnd, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_StartRecordAudio(IntPtr handle, string file_path) => VzLPRClient_StartRecordAudio(handle, file_path);
        int IVzClientSdkProxy.VzLPRClient_StartTalk(IntPtr handle, int client_win_size) => VzLPRClient_StartTalk(handle, client_win_size);
        int IVzClientSdkProxy.VZLPRClient_StopFindDevice() => VZLPRClient_StopFindDevice();
        int IVzClientSdkProxy.VzLPRClient_StopRealPlay(IntPtr hRealHandle) => VzLPRClient_StopRealPlay(hRealHandle);
        int IVzClientSdkProxy.VzLPRClient_StopRealPlayDecData(IntPtr handle) => VzLPRClient_StopRealPlayDecData(handle);
        int IVzClientSdkProxy.VzLPRClient_StopRecordAudio(IntPtr handle) => VzLPRClient_StopRecordAudio(handle);
        int IVzClientSdkProxy.VzLPRClient_StopSaveRealData(IntPtr handle) => VzLPRClient_StopSaveRealData(handle);
        int IVzClientSdkProxy.VzLPRClient_StopTalk(IntPtr handle) => VzLPRClient_StopTalk(handle);
        int IVzClientSdkProxy.VzLPRClient_UpdateNetworkParam(uint sh, uint sl, string strNewIP, string strGateway, string strNetmask) => VzLPRClient_UpdateNetworkParam(sh, sl, strNewIP, strGateway, strNetmask);
        int IVzClientSdkProxy.VzLPRClient_WhiteListClearCustomersAndVehicles(IntPtr handle) => VzLPRClient_WhiteListClearCustomersAndVehicles(handle);
        int IVzClientSdkProxy.VzLPRClient_WhiteListDeleteVehicle(IntPtr handle, string strPlateID) => VzLPRClient_WhiteListDeleteVehicle(handle, strPlateID);
        int IVzClientSdkProxy.VzLPRClient_WhiteListGetRowCount(IntPtr handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere) => VzLPRClient_WhiteListGetRowCount(handle, ref count, ref pSearchWhere);
        int IVzClientSdkProxy.VzLPRClient_WhiteListGetVehicleCount(IntPtr handle, ref uint pCount, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere) => VzLPRClient_WhiteListGetVehicleCount(handle, ref pCount, ref pSearchWhere);
        int IVzClientSdkProxy.VzLPRClient_WhiteListImportRows(IntPtr handle, uint rowcount, ref VZ_LPR_WLIST_ROW pRowDatas, ref VZ_LPR_WLIST_IMPORT_RESULT pResults) => VzLPRClient_WhiteListImportRows(handle, rowcount, ref pRowDatas, ref pResults);
        int IVzClientSdkProxy.VzLPRClient_WhiteListLoadVehicle(IntPtr handle, ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition) => VzLPRClient_WhiteListLoadVehicle(handle, ref pLoadCondition);
        int IVzClientSdkProxy.VzLPRClient_WhiteListSetQueryCallBack(IntPtr handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData) => VzLPRClient_WhiteListSetQueryCallBack(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_WhiteListUpdateVehicleByID(IntPtr handle, ref VZ_LPR_WLIST_VEHICLE pVehicle) => VzLPRClient_WhiteListUpdateVehicleByID(handle, ref pVehicle);
        int IVzClientSdkProxy.VzLPRClient_WriteUserData(IntPtr handle, IntPtr pUserData, uint uSizeData) => VzLPRClient_WriteUserData(handle, pUserData, uSizeData);
        #endregion 显示实现
    }
}
