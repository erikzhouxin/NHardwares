using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using System.Data.NHInterfaces;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// SDK代理
    /// </summary>
    public interface IVzClientSdkProxy
    {
        /// <summary>
        /// 复制内存
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <param name="Length"></param>
        void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
        /// <summary>
        /// 全局初始化，在所有接口调用之前调用
        /// </summary>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_Setup();
        /// <summary>
        /// 全局释放
        /// </summary>
        void VzLPRClient_Cleanup();
        /// <summary>
        /// 设置设备连接反馈结果相关的回调函数
        /// </summary>
        /// <param name="func">设备连接结果和状态，通过该回调函数返回</param>
        /// <param name="pUserData">回调函数中的上下文</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData);
        /// <summary>
        /// 打开一个设备
        /// </summary>
        /// <param name="pStrIP">设备的IP地址</param>
        /// <param name="wPort">设备的端口号</param>
        /// <param name="pStrUserName">访问设备所需用户名</param>
        /// <param name="pStrPassword">访问设备所需密码</param>
        /// <returns>返回设备的操作句柄，当打开失败时，返回-1</returns>
        IntPtr VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword);
        /// <summary>
        /// 打开一个设备
        /// </summary>
        /// <param name="pStrIP">设备的IP地址</param>
        /// <param name="wPort">设备的端口号</param>
        /// <param name="pStrUserName">访问设备所需用户名</param>
        /// <param name="pStrPassword">访问设备所需密码</param>
        /// <param name="wRtspPort">流媒体的端口号,默认为8557(如果为0表示使用默认端口）</param>
        /// <param name="network_type">网络类型(0局域网,1外网-PDNS方式)</param>
        /// <param name="sn">设备序列号</param>
        /// <returns>返回设备的操作句柄，当打开失败时，返回-1</returns>
        IntPtr VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn);
        /// <summary>
        /// 关闭一个设备
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_Close(IntPtr handle);
        /// <summary>
        /// 通过IP地址关闭一个设备
        /// </summary>
        /// <param name="pStrIP">设备的IP地址</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_CloseByIP(string pStrIP);
        /// <summary>
        /// 获取连接状态
        /// </summary>
        /// <param name="handle">handle 由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pStatus">输入获取状态的变量地址，输出内容为 1已连上，0未连上</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_IsConnected(IntPtr handle, ref byte pStatus);
        /// <summary>
        /// 根据句柄获取设备的IP
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="ip">相机IP</param>
        /// <param name="max_count">IP传入长度</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败</returns>
        int VzLPRClient_GetDeviceIP(IntPtr handle, ref byte ip, int max_count);
        /// <summary>
        /// 播放实时视频
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="hWnd">窗口的句柄</param>
        /// <returns>播放句柄，小于0表示失败</returns>
        IntPtr VzLPRClient_StartRealPlay(IntPtr handle, IntPtr hWnd);
        /// <summary>
        /// 停止正在播放的窗口上的实时视频
        /// </summary>
        /// <param name="hRealHandle">窗口的句柄</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_StopRealPlay(IntPtr hRealHandle);
        /// <summary>
        /// 设置识别结果的回调函数
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="func">识别结果回调函数</param>
        /// <param name="pUserData">回调函数中的上下文</param>
        /// <param name="bEnableImage">指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_SetPlateInfoCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage);
        /// <summary>
        /// 设置实时图像数据的回调函数
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pFunc">实时图像数据函数</param>
        /// <param name="pUserData">回调函数中的上下文</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_SetVideoFrameCallBack(IntPtr handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData);
        /// <summary>
        /// 发送软件触发信号，强制处理当前时刻的数据并输出结果
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_ForceTrigger(IntPtr handle);
        /// <summary>
        /// 设置虚拟线圈
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pVirtualLoops">虚拟线圈的结构体指针</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_SetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);
        /// <summary>
        /// 获取已设置的虚拟线圈
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pVirtualLoops">虚拟线圈的结构体指针</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_GetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);
        /// <summary>
        /// 获取已设置的识别区域
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pROI">识别区域的结构体指针</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_GetRegionOfInterestEx(IntPtr handle, ref VZ_LPRC_ROI_EX pROI);
        /// <summary>
        /// 获取已设置的预设省份
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pProvInfo">预设省份信息指针</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_GetSupportedProvinces(IntPtr handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo);
        /// <summary>
        /// 设置预设省份
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="nIndex">设置预设省份的序号，序号需要参考VZ_LPRC_PROVINCE_INFO::strProvinces中的顺序，从0开始，如果小于0，则表示不设置预设省份</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_PresetProvinceIndex(IntPtr handle, int nIndex);
        /// <summary>
        /// 将图像保存为JPEG到指定路径
        /// </summary>
        /// <param name="pImgInfo">图像结构体，目前只支持默认的格式，即ImageFormatRGB</param>
        /// <param name="pFullPathName">设带绝对路径和JPG后缀名的文件名字符串,给定的文件名中的路径需要存在</param>
        /// <param name="nQuality">JPEG压缩的质量，取值范围1~100；</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality);
        /// <summary>
        /// 读出设备序列号，可用于二次加密
        /// @ingroup group_device
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pSN">用于存放读到的设备序列号，详见定义 VZ_DEV_SERIAL_NUM</param>
        /// <returns>返回值为0表示成功，返回-1表示失败</returns>
        int VzLPRClient_GetSerialNumber(IntPtr handle, ref VZ_DEV_SERIAL_NUM pSN);
        /// <summary>
        /// 保存正在播放的视频的当前帧的截图到指定路径
        /// @ingroup group_device
        /// </summary>
        /// <param name="nPlayHandle">播放的句柄</param>
        /// <param name="pFullPathName">设带绝对路径和JPG后缀名的文件名字符串,使用的文件名中的路径需要存在</param>
        /// <param name="nQuality">JPEG压缩的质量，取值范围1~100；</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_GetSnapShootToJpeg2(IntPtr nPlayHandle, string pFullPathName, int nQuality);
        /// <summary>
        /// 保存抓图数据到Jpeg文件
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pFullPathName">图片路径</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败</returns>
        int VzLPRClient_SaveSnapImageToJpeg(IntPtr handle, string pFullPathName);
        /// <summary>
        /// 开启透明通道
        /// @ingroup group_device
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="nSerialPort">指定使用设备的串口序号：0表示第一个串口，1表示第二个串口</param>
        /// <param name="func">接收数据的回调函数</param>
        /// <param name="pUserData">接收数据回调函数的上下文</param>
        /// <returns>返回透明通道句柄，0表示失败</returns>
        IntPtr VzLPRClient_SerialStart(IntPtr handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData);
        /// <summary>
        /// 透明通道发送数据
        /// @ingroup group_device
        /// </summary>
        /// <param name="nSerialHandle">由VzLPRClient_SerialStart函数获得的句柄</param>
        /// <param name="pData">将要传输的数据块的首地址</param>
        /// <param name="uSizeData">将要传输的数据块的字节数</param>
        /// <returns>0表示成功，其他值表示失败</returns>
        int VzLPRClient_SerialSend(IntPtr nSerialHandle, IntPtr pData, int uSizeData);
        /// <summary>
        /// 透明通道停止发送数据
        /// </summary>
        /// <param name="nSerialHandle">由VzLPRClient_SerialStart函数获得的句柄</param>
        /// <returns>0表示成功，其他值表示失败</returns>
        int VzLPRClient_SerialStop(IntPtr nSerialHandle);
        /// <summary>
        /// 设置IO输出的状态
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="uChnId">IO输出的通道号，从0开始</param>
        /// <param name="nOutput">将要设置的IO输出的状态，0表示继电器开路，1表示继电器闭路</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_SetIOOutput(IntPtr handle, int uChnId, int nOutput);
        /// <summary>
        /// 获取IO输出的状态
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="uChnId">IO输出的通道号，从0开始</param>
        /// <param name="pOutput">IO输出的状态，0表示继电器开路，1表示继电器闭路</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_GetIOOutput(IntPtr handle, int uChnId, ref int pOutput);
        /// <summary>
        /// 获取GPIO的状态
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="gpioIn">数据为0或1</param>
        /// <param name="value">0代表短路，1代表开路</param>
        /// <returns>返回值为0表示成功，返回-1表示失败</returns>
        int VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, IntPtr value);
        /// <summary>
        /// 根据ID获取车牌图片
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="id">车牌记录的ID</param>
        /// <param name="pdata">存储图片的内存</param>
        /// <param name="size">为传入传出值，传入为图片内存的大小，返回的是获取到jpg图片内存的大小</param>
        /// <returns>返回值为0表示成功，返回-1表示失败</returns>
        int VzLPRClient_LoadImageById(IntPtr handle, int id, IntPtr pdata, IntPtr size);
        /// <summary>
        /// 向白名单表导入客户和车辆记录
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="rowcount">记录的条数</param>
        /// <param name="pRowDatas">记录的内容数组的地址</param>
        /// <param name="pResults">每条数据是否导入成功</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_WhiteListImportRows(IntPtr handle, uint rowcount, ref VZ_LPR_WLIST_ROW pRowDatas, ref VZ_LPR_WLIST_IMPORT_RESULT pResults);
        /// <summary>
        /// 从数据库删除车辆信息
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="strPlateID">车牌号码</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_WhiteListDeleteVehicle(IntPtr handle, string strPlateID);
        /// <summary>
        /// 清空数据库客户信息和车辆信息
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_WhiteListClearCustomersAndVehicles(IntPtr handle);
        /// <summary>
        /// 获取白名单表中所有车辆信息记录的条数
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pCount"></param>
        /// <param name="pSearchWhere"></param>
        /// <returns>>=0表示所有车辆信息记录的总数，-1表示失败</returns>
        int VzLPRClient_WhiteListGetVehicleCount(IntPtr handle, ref uint pCount, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);
        /// <summary>
        /// 查询白名单表车辆记录数据
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pLoadCondition">查询条件</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_WhiteListLoadVehicle(IntPtr handle, ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition);
        /// <summary>
        /// 设置白名单表和客户信息表的查询结果回调
        /// group_database
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="func">查询结果回调函数</param>
        /// <param name="pUserData">回调函数中的上下文</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_WhiteListSetQueryCallBack(IntPtr handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 往白名单表中更新一个车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVehicle 将要更新的车辆信息，详见结构体定义VZ_LPR_WLIST_VEHICLE
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        int VzLPRClient_WhiteListUpdateVehicleByID(IntPtr handle, ref VZ_LPR_WLIST_VEHICLE pVehicle);

        /**
        *  @brief 查询白名单表客户和车辆记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pCount 记录的条数
        *  @param  [IN] search_constraints 搜索的条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        int VzLPRClient_WhiteListGetRowCount(IntPtr handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 设置LED控制模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] eCtrl 控制LED开关模式，详见定义 VZ_LED_CTRL
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SetLEDLightControlMode(IntPtr handle, VZ_LED_CTRL eCtrl);
        /**
        *  @brief 获取LED当前亮度等级和最大亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pLevelNow 用于输出当前亮度等级的地址
        *  @param [OUT] pLevelMax 用于输出最高亮度等级的地址
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_GetLEDLightStatus(IntPtr handle, ref int pLevelNow, ref int pLevelMax);

        /**
        *  @brief 设置LED亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nLevel，LED亮度等级
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SetLEDLightLevel(IntPtr handle, int nLevel);

        /**
        *  @brief 开始录像功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sFileName 录像文件的路径
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SaveRealData(IntPtr handle, string sFileName);

        /**
        *  @brief 停止录像
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_StopSaveRealData(IntPtr handle);

        /**
        *  @brief 开启脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SetOfflineCheck(IntPtr handle);

        /**
        *  @brief 关闭脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_CancelOfflineCheck(IntPtr handle);
        /// <summary>
        /// 开始查找设备
        /// @ingroup group_global
        /// </summary>
        /// <param name="func">找到的设备通过该回调函数返回</param>
        /// <param name="pUserData">回调函数中的上下文</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 停止查找设备
        *  @ingroup group_global
        */
        int VZLPRClient_StopFindDevice();

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
        int VzLPRClient_QueryRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword);

        /**
        *  @brief 根据时间和车牌号查询记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pStartTime 起始时间，格式如"2015-01-02 12:20:30"
        *  @param  [IN] pEndTime   起始时间，格式如"2015-01-02 19:20:30"
        *  @param  [IN] keyword    车牌号关键字, 如"川"
        *  @return 返回值为0表示失败，大于0表示记录条数
        *  @ingroup group_device
        */
        int VzLPRClient_QueryCountByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword);

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
        int VzLPRClient_QueryPageRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword, int start, int end);

        /**
        *  @brief 设置查询车牌记录的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数，如果为NULL，则表示关闭该回调函数的功能
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SetQueryPlateCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_GetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置设备的日期时间
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDTInfo 将要设置的设备日期时间信息，详见定义 VZ_DATE_TIME_INFO
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SetDateTime(IntPtr handle, IntPtr IntpDTInfo);

        /**
        *  @brief 读出用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pBuffer 用于存放读到的用户数据
        *  @param [IN] uSizeBuf 用户数据缓冲区的最小尺寸，不小于128字节
        *  @return 返回值为实际用户数据的字节数，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_ReadUserData(IntPtr handle, IntPtr pBuffer, uint uSizeBuf);

        /**
        *  @brief 写入用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pUserData 用户数据
        *  @param [IN] uSizeData 用户数据的长度，最大128字节
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_WriteUserData(IntPtr handle, IntPtr pUserData, uint uSizeData);
        /// <summary>
        /// 将图像编码为JPEG，保存到指定内存
        /// </summary>
        /// <param name="pImgInfo">图像结构体，目前只支持默认的格式，即ImageFormatRGB</param>
        /// <param name="pDstBuf">JPEG数据的目的存储首地址</param>
        /// <param name="uSizeBuf">JPEG数据地址的内存的最大尺寸；</param>
        /// <param name="nQuality">JPEG压缩的质量，取值范围1~100；</param>
        /// <returns>0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大</returns>
        int VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality);
        /// <summary>
        /// 设置IO输出，并自动复位
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="uChnId">IO输出的通道号，从0开始</param>
        /// <param name="nDuration">延时时间，取值范围[500, 5000]毫秒</param>
        /// <returns>0表示成功，-1表示失败</returns>
        int VzLPRClient_SetIOOutputAuto(IntPtr handle, int uChnId, int nDuration);

        /**
        *  @brief 获取实时视频帧，图像数据通过回调函数到用户层，用户可改动图像内容，并且显示到窗口
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd		窗口的句柄，如果为有效值，则视频图像会显示到该窗口上，如果为空，则不显示视频图像
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 播放的句柄，-1表示失败
        *  @ingroup group_device
        */
        IntPtr VzLPRClient_StartRealPlayFrameCallBack(IntPtr handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 获取已设置的允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsTrigType 允许的车牌识别触发类型按位或的变量的地址，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        int VzLPRClient_GetPlateTrigType(IntPtr handle, ref int pBitsTrigType);

        /**
        *  @brief 设置允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] uBitsTrigType 允许的车牌识别触发类型按位或的值，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        *  @note  如果设置不允许某种类型的触发，那么该种类型的触发结果也不会保存在设备的SD卡中
        *  @note  默认输出稳定触发和虚拟线圈触发
        *  @note  不会影响手动触发和IO输入触发
        */
        int VzLPRClient_SetPlateTrigType(IntPtr handle, UInt32 uBitsTrigType);

        /**
        *  @brief 获取智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 设置智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 获取已设置的需要识别的车牌类型位
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsRecType 需要识别的车牌类型按位或的变量的地址，车牌类型位详见定义VZ_LPRC_REC_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        int VzLPRClient_GetPlateRecType(IntPtr handle, ref int pBitsRecType);

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
        int VzLPRClient_SetPlateRecType(IntPtr handle, UInt32 uBitsRecType);

        /**
        *  @brief 获取输出配置0
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置输出配置
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetTriggerDelay(IntPtr handle, int nDelay);

        /**
        *  @brief 获取车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetTriggerDelay(IntPtr handle, ref int nDelay);

        /**
        *  @brief 设置白名单验证模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetWLCheckMethod(IntPtr handle, int nType);

        /**
        *  @brief 获取白名单验证模式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT]	nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetWLCheckMethod(IntPtr handle, ref int nType);

        /**
        *  @brief 设置白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetWLFuzzy(IntPtr handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC);

        /**
        *  @brief 获取白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetWLFuzzy(IntPtr handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC);

        /**
        *  @brief 设置串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] pParameter 将要设置的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_SetSerialParameter(IntPtr handle, int nSerialPort,
                                                        ref VZ_SERIAL_PARAMETER pParameter);

        /**
        *  @brief 获取串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [OUT] pParameter 将要获取的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_GetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter);
        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetVideoFrameSizeIndex(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoFrameSizeIndex(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetVideoFrameSizeIndexEx(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoFrameSizeIndexEx(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流帧率
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetVideoFrameRate(IntPtr handle, ref int Rateval);//1-25

        /**
        *  @brief 设置主码流帧率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoFrameRate(IntPtr handle, int Rateval);//1-25

        /**
        *  @brief 获取主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetVideoCompressMode(IntPtr handle, ref int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 设置主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoCompressMode(IntPtr handle, int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 获取主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @param [OUT] ratelist 暂时不用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetVideoCBR(IntPtr handle, ref int rateval/*Kbps*/, ref int ratelist);

        /**
        *  @brief 设置主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoCBR(IntPtr handle, int rateval/*Kbps*/);

        /**
        *  @brief 获取视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] brt 亮度
        *  @param [OUT] cst 对比度
        *  @param [OUT] sat 饱和度
        *  @param [OUT] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetVideoPara(IntPtr handle, ref int brt, ref int cst, ref int sat, ref int hue);

        /**
        *  @brief 设置视频参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] brt 亮度
        *  @param [IN] cst 对比度
        *  @param [IN] sat 饱和度
        *  @param [IN] hue 色度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoPara(IntPtr handle, int brt, int cst, int sat, int hue);

        /**
        *  @brief 设置通道主码流编码方式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] cmd    返回的编码方式, 0->H264  1->MPEG4  2->JPEG  其他->错误
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoEncodeType(IntPtr handle, int cmd);

        /**
        *  @brief 获取视频的编码方式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pEncType	返回的编码方式, 0:H264  1:MPEG4  2:JPEG  其他:错误
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        int VzLPRClient_GetVideoEncodeType(IntPtr handle, ref int pEncType);

        /**
        *  @brief 获取视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetVideoVBR(IntPtr handle, ref int levelval);

        /**
        *  @brief 设置视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetVideoVBR(IntPtr handle, int levelval);

        /**
        *  @brief 获取视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetFrequency(IntPtr handle, ref int frequency);

        /**
        *  @brief 设置视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetFrequency(IntPtr handle, int frequency);

        /**
        *  @brief 获取曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetShutter(IntPtr handle, ref int shutter);

        /**
        *  @brief 设置曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetShutter(IntPtr handle, int shutter);

        /**
        *  @brief 获取图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetFlip(IntPtr handle, ref int flip);

        /**
        *  @brief 设置图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetFlip(IntPtr handle, int flip);

        /// <summary>
        /// 修改网络参数 原方法有误
        /// </summary>
        /// <param name="sh">设备序列号低位字节</param>
        /// <param name="sl">设备序列号高位字节</param>
        /// <param name="strNewIP">新IP     格式如"192.168.3.109"</param>
        /// <param name="strGateway">网关     格式如"192.168.3.1"</param>
        /// <param name="strNetmask">子网掩码 格式如"255.255.255.0"</param>
        /// <returns></returns>
        int VzLPRClient_UpdateNetworkParam(uint sh, uint sl, string strNewIP, string strGateway, string strNetmask);

        /**
        *  @brief 获取设备序列号；
        *  @param [IN] ip ip统一使用字符串的形式传入
        *  @param [IN] port 使用和登录时相同的端口
        *  @param [OUT] SerHi 序列号高位
        *  @param [OUT] SerLo 序列号低位
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo);

        /**
        *  @brief 开始实时图像数据流，用于实时获取图像数据
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        int VzLPRClient_StartRealPlayDecData(IntPtr handle);

        /**
        *  @brief 停止实时图像数据流
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        int VzLPRClient_StopRealPlayDecData(IntPtr handle);

        /**
        *  @brief 从解码流中获取JPEG图像，保存到指定内存
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN/OUT] pDstBuf JPEG数据的目的存储首地址
        *  @param  [IN] uSizeBuf JPEG数据地址的内存的最大尺寸；
        *  @param  [IN] nQuality JPEG压缩的质量，取值范围1~100；
        *  @return >0表示成功，即编码后的尺寸，-1表示失败，-2表示给定的压缩数据的内存尺寸不够大
        *  @ingroup group_global
        */
        int VzLPRClient_GetJpegStreamFromRealPlayDec(IntPtr handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality);

        /**
        *  @brief 设置是否输出实时结果
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] bOutput 是否输出
        *  @return 0表示成功，-1表示失败
        */
        int VzLPRClient_SetIsOutputRealTimeResult(IntPtr handle, bool bOutput);

        /**
        *  @brief 获取设备加密类型和当前加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pData 加密信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetEMS(IntPtr handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData);
        /**
        *  @brief 设置设备加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] nEncyptId	修改的加密类型ID 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetEncrypt(IntPtr handle, IntPtr pCurrentKey, UInt32 nEncyptId);

        /**
        *  @brief 修改设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_ChangeEncryptKey(IntPtr handle, IntPtr pCurrentKey, IntPtr pNewKey);

        /**
        *  @brief 重置设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pPrimeKey 当前设备主密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_ResetEncryptKey(IntPtr handle, IntPtr pPrimeKey, IntPtr pNewKey);

        /**
        *  @brief 语音播放功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] voice 播放的语音文字
        *  @param [IN] interval 语音文件的播放间隔(0-5000)
        *  @param [IN] volume 声音大小(0-100)
        *  @param [IN] male 声音类型(男声0，女生1)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_PlayVoice(IntPtr handle, string voice, int interval, int volume, int male);

        // 中心服务器配置
        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 获取中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 设置中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 获取中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 设置中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 获取中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 获取中心服务器网络端口触发信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerGionin  中心服务器端口触发信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 设置中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 获取中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 设置中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetCenterServerHostBak(IntPtr handle, string pCenterServerHostBak);

        /**
        *  @brief 获取中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetCenterServerHostBak(IntPtr handle, ref string pCenterServerHostBak);

        /**
        *  @brief 获取设备硬件信息
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_version  设备类型
        *  @param [OUT] exdataSize 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetHwBoardVersion(IntPtr handle, ref int board_version, ref Int64 exdataSize);

        /**
        *  @brief 获取设备硬件类型
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_type  设备类型(0:3730,1:6446,2:8127)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetHwBoardType(IntPtr handle, ref int board_type);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetAlgResultParam(IntPtr handle, ref int reco_dis);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetAlgResultParam(IntPtr handle, int reco_dis);

        /**
        *  @brief 获取图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_GetDenoise(IntPtr handle, ref int mode, ref int strength);

        /**
        *  @brief 设置图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetDenoise(IntPtr handle, int mode, int strength);

        /**
        *  @brief 获取R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流 
        *  @param [OUT] param 编码参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_RGet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 设置R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_RSet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 获取R相机支持的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_RGet_Encode_Param_Property(IntPtr handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] param 视频参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_RGet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_RSet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 开始喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] client_win_size 客户端窗口大小
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_StartTalk(IntPtr handle, int client_win_size);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        int VzLPRClient_SetRequestTalkCallBack(IntPtr handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData);
        /// <summary>
        /// 停止喊话
        /// ?device_ip 设备IP
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败。</returns>
        int VzLPRClient_StopTalk(IntPtr handle);
        /// <summary>
        /// 开始录音
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="file_path">音频文件路径</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败。</returns>
        int VzLPRClient_StartRecordAudio(IntPtr handle, string file_path);
        /// <summary>
        /// 停止录音
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败。</returns>
        int VzLPRClient_StopRecordAudio(IntPtr handle);
        /// <summary>
        /// 设置车牌图片里是否显示车牌框
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="bShow">是否显示车牌框，输入值(0或1)，1代表显示，0代表不显示</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败。</returns>
        int VzLPRClient_SetIsShowPlateRect(IntPtr handle, int bShow);
        /// <summary>
        /// 设置GPIO输入回调函数
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="func"> GPIO输入回调函数</param>
        /// <param name="pUserData">用户自定义数据</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败。</returns>
        int VzLPRClient_SetGPIORecvCallBack(IntPtr handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData);
        /// <summary>
        /// 获取相机参数
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="command">命令类型</param>
        /// <param name="channel">通道号，默认为0</param>
        /// <param name="pOutBuffer">返回的数据</param>
        /// <param name="dwOutBufferSize">数据的长度</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败。</returns>
        int VzLPRClient_GetCameraConfig(IntPtr handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize);
    }
    internal class VzClientSdkDller : IVzClientSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IVzClientSdkProxy Instance { get; } = new VzClientSdkDller();
        private VzClientSdkDller() { }
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_Setup();

        /**
        *  @brief 全局释放
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern void VzLPRClient_Cleanup();

        /**
        *  @brief 设置设备连接反馈结果相关的回调函数
        *  @param  [IN] func 设备连接结果和状态，通过该回调函数返回
        *  @param [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 打开一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @param [IN] wPort 设备的端口号
        *  @param  [IN] pStrUserName 访问设备所需用户名
        *  @param [IN] pStrPassword 访问设备所需密码
        *  @return 返回设备的操作句柄，当打开失败时，返回-1
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern IntPtr VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn);

        /**
        *  @brief 关闭一个设备
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_Close(IntPtr handle);

        /**
        *  @brief 通过IP地址关闭一个设备
        *  @param  [IN] pStrIP 设备的IP地址
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_CloseByIP(string pStrIP);

        /**
        *  @brief 获取连接状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param[IN/OUT] pStatus 输入获取状态的变量地址，输出内容为 1已连上，0未连上
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_IsConnected(IntPtr handle, ref byte pStatus);

        /**
        *  @brief 根据句柄获取设备的IP
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] ip  相机IP
        *  @param [IN] max_count IP传入长度
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetDeviceIP(IntPtr handle, ref byte ip, int max_count);

        /**
        *  @brief 播放实时视频
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 播放句柄，小于0表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern IntPtr VzLPRClient_StartRealPlay(IntPtr handle, IntPtr hWnd);

        /**
        *  @brief 停止正在播放的窗口上的实时视频
        *  @param  [IN] hWnd 窗口的句柄
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_StopRealPlay(IntPtr hRealHandle);

        /**
        *  @brief 设置识别结果的回调函数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func 识别结果回调函数
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @param  [IN] bEnableImage 指定识别结果的回调是否需要包含截图信息：1为需要，0为不需要
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName, CallingConvention = CallingConvention.StdCall)]
        public static extern int VzLPRClient_SetPlateInfoCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage);

        /**
        *  @brief 设置实时图像数据的回调函数
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] func		实时图像数据函数
        *  @param  [IN] pUserData	回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName, CallingConvention = CallingConvention.StdCall)]
        public static extern int VzLPRClient_SetVideoFrameCallBack(IntPtr handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData);
        /// <summary>
        /// 发送软件触发信号，强制处理当前时刻的数据并输出结果
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <returns>0表示成功，-1表示失败</returns>
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_ForceTrigger(IntPtr handle);

        /**
        *  @brief 设置虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的虚拟线圈
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVirtualLoops 虚拟线圈的结构体指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

        /**
        *  @brief 获取已设置的识别区域
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pROI 识别区域的结构体指针
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetRegionOfInterestEx(IntPtr handle, ref VZ_LPRC_ROI_EX pROI);

        /**
        *  @brief 获取已设置的预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pProvInfo 预设省份信息指针
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetSupportedProvinces(IntPtr handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo);

        /**
        *  @brief 设置预设省份
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nIndex 设置预设省份的序号，序号需要参考VZ_LPRC_PROVINCE_INFO::strProvinces中的顺序，从0开始，如果小于0，则表示不设置预设省份
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality);

        /**
        *  @brief 读出设备序列号，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pSN 用于存放读到的设备序列号，详见定义 VZ_DEV_SERIAL_NUM
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetSnapShootToJpeg2(IntPtr nPlayHandle, string pFullPathName, int nQuality);

        /// <summary>
        /// 保存抓图数据到Jpeg文件
        /// </summary>
        /// <param name="handle">由VzLPRClient_Open函数获得的句柄</param>
        /// <param name="pFullPathName">图片路径</param>
        /// <returns>返回值为0表示成功，返回其他值表示失败</returns>
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern IntPtr VzLPRClient_SerialStart(IntPtr handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 透明通道发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @param [IN] pData 将要传输的数据块的首地址
        *  @param [IN] uSizeData 将要传输的数据块的字节数
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SerialSend(IntPtr nSerialHandle, IntPtr pData, int uSizeData);

        /**
        *  @brief 透明通道停止发送数据
        *  @param [IN] nSerialHandle 由VzLPRClient_SerialStart函数获得的句柄
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SerialStop(IntPtr nSerialHandle);

        /**
        *  @brief 设置IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] nOutput 将要设置的IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetIOOutput(IntPtr handle, int uChnId, int nOutput);

        /**
        *  @brief 获取IO输出的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [OUT] pOutput IO输出的状态，0表示继电器开路，1表示继电器闭路
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetIOOutput(IntPtr handle, int uChnId, ref int pOutput);

        /**
        *  @brief 获取GPIO的状态
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] gpioIn 数据为0或1
        *  @param  [OUT] value 0代表短路，1代表开路
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, IntPtr value);

        /**
        *  @brief 根据ID获取车牌图片
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] id     车牌记录的ID
        *  @param  [IN] pdata  存储图片的内存
        *  @param  [IN][OUT] size 为传入传出值，传入为图片内存的大小，返回的是获取到jpg图片内存的大小
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_WhiteListDeleteVehicle(IntPtr handle, string strPlateID);

        /**
        *  @brief 清空数据库客户信息和车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_WhiteListClearCustomersAndVehicles(IntPtr handle);

        /**
        *  @brief 获取白名单表中所有车辆信息记录的条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return >=0表示所有车辆信息记录的总数，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_WhiteListGetVehicleCount(IntPtr handle, ref uint pCount,
                                                                 ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 查询白名单表车辆记录数据
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pLoadCondition 查询条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_WhiteListSetQueryCallBack(IntPtr handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 往白名单表中更新一个车辆信息
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pVehicle 将要更新的车辆信息，详见结构体定义VZ_LPR_WLIST_VEHICLE
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_WhiteListUpdateVehicleByID(IntPtr handle, ref VZ_LPR_WLIST_VEHICLE pVehicle);

        /**
        *  @brief 查询白名单表客户和车辆记录条数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pCount 记录的条数
        *  @param  [IN] search_constraints 搜索的条件
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_database
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_WhiteListGetRowCount(IntPtr handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

        /**
        *  @brief 设置LED控制模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] eCtrl 控制LED开关模式，详见定义 VZ_LED_CTRL
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetLEDLightControlMode(IntPtr handle, VZ_LED_CTRL eCtrl);
        /**
        *  @brief 获取LED当前亮度等级和最大亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pLevelNow 用于输出当前亮度等级的地址
        *  @param [OUT] pLevelMax 用于输出最高亮度等级的地址
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetLEDLightStatus(IntPtr handle, ref int pLevelNow, ref int pLevelMax);

        /**
        *  @brief 设置LED亮度等级
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nLevel，LED亮度等级
        *  @return 0表示成功，其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetLEDLightLevel(IntPtr handle, int nLevel);

        /**
        *  @brief 开始录像功能
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sFileName 录像文件的路径
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SaveRealData(IntPtr handle, string sFileName);

        /**
        *  @brief 停止录像
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_StopSaveRealData(IntPtr handle);

        /**
        *  @brief 开启脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetOfflineCheck(IntPtr handle);

        /**
        *  @brief 关闭脱机功能
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] pUserData 接收数据回调函数的上下文
        *   @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_CancelOfflineCheck(IntPtr handle);

        /**
        *  @brief 开始查找设备
        *  @param  [IN] func 找到的设备通过该回调函数返回
        *  @param  [IN] pUserData 回调函数中的上下文
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 停止查找设备
        *  @ingroup group_global
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetQueryPlateCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 获取视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置视频OSD参数；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetOsdParam(IntPtr handle, IntPtr pParam);

        /**
        *  @brief 设置设备的日期时间
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDTInfo 将要设置的设备日期时间信息，详见定义 VZ_DATE_TIME_INFO
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetDateTime(IntPtr handle, IntPtr IntpDTInfo);

        /**
        *  @brief 读出用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN/OUT] pBuffer 用于存放读到的用户数据
        *  @param [IN] uSizeBuf 用户数据缓冲区的最小尺寸，不小于128字节
        *  @return 返回值为实际用户数据的字节数，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_ReadUserData(IntPtr handle, IntPtr pBuffer, uint uSizeBuf);

        /**
        *  @brief 写入用户私有数据，可用于二次加密
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pUserData 用户数据
        *  @param [IN] uSizeData 用户数据的长度，最大128字节
        *  @return 返回值为0表示成功，返回其他值表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality);

        /**
        *  @brief 设置IO输出，并自动复位
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] uChnId IO输出的通道号，从0开始
        *  @param  [IN] nDuration 延时时间，取值范围[500, 5000]毫秒
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr VzLPRClient_StartRealPlayFrameCallBack(IntPtr handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData);

        /**
        *  @brief 获取已设置的允许的车牌识别触发类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsTrigType 允许的车牌识别触发类型按位或的变量的地址，允许触发类型位详见定义VZ_LPRC_TRIG_ENABLE_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetPlateTrigType(IntPtr handle, UInt32 uBitsTrigType);

        /**
        *  @brief 获取智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 设置智能视频显示模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pDrawMode 显示模式，参考VZ_LPRC_DRAWMODE
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode);

        /**
        *  @brief 获取已设置的需要识别的车牌类型位
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] pBitsRecType 需要识别的车牌类型按位或的变量的地址，车牌类型位详见定义VZ_LPRC_REC_XXX
        *  @return 返回值：返回值为0表示成功，返回其他值表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetPlateRecType(IntPtr handle, UInt32 uBitsRecType);

        /**
        *  @brief 获取输出配置0
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置输出配置
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pOutputConfig 输出配置
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

        /**
        *  @brief 设置车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetTriggerDelay(IntPtr handle, int nDelay);

        /**
        *  @brief 获取车牌识别触发延迟时间
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] nDelay 触发延迟时间,时间范围[0, 10000)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetTriggerDelay(IntPtr handle, ref int nDelay);

        /**
        *  @brief 设置白名单验证模式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetWLCheckMethod(IntPtr handle, int nType);

        /**
        *  @brief 获取白名单验证模式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT]	nType 0 脱机自动启用;1 启用;2 不启用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetWLCheckMethod(IntPtr handle, ref int nType);

        /**
        *  @brief 设置白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetWLFuzzy(IntPtr handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC);

        /**
        *  @brief 获取白名单模糊匹配
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] nFuzzyType 0  精确匹配;1 相似字符匹配;2 普通字符模糊匹配
        *  @param [IN] nFuzzyLen  允许误识别长度
        *  @param [IN] nFuzzyType 忽略汉字
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetWLFuzzy(IntPtr handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC);

        /**
        *  @brief 设置串口参数
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] nSerialPort 指定使用设备的串口序号：0表示第一个串口，1表示第二个串口
        *  @param  [IN] pParameter 将要设置的串口参数，详见定义 VZ_SERIAL_PARAMETER
        *  @return 0表示成功，-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter);
        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVideoFrameSizeIndex(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 详见VZDEV_FRAMESIZE_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVideoFrameSizeIndex(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVideoFrameSizeIndexEx(IntPtr handle, ref int sizeval);

        /**
        *  @brief 设置主码流分辨率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] sizeval 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVideoFrameSizeIndexEx(IntPtr handle, int sizeval);

        /**
        *  @brief 获取主码流帧率
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVideoFrameRate(IntPtr handle, ref int Rateval);//1-25

        /**
        *  @brief 设置主码流帧率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] Rateval 帧率，范围1-25
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVideoFrameRate(IntPtr handle, int Rateval);//1-25

        /**
        *  @brief 获取主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVideoCompressMode(IntPtr handle, ref int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 设置主码流压缩模式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] modeval 详见VZDEV_VIDEO_COMPRESS_宏定义
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVideoCompressMode(IntPtr handle, int modeval);//VZDEV_VIDEO_COMPRESS_XXX

        /**
        *  @brief 获取主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @param [OUT] ratelist 暂时不用
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVideoCBR(IntPtr handle, ref int rateval/*Kbps*/, ref int ratelist);

        /**
        *  @brief 设置主码流比特率；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] rateval 当前视频比特率
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVideoPara(IntPtr handle, int brt, int cst, int sat, int hue);

        /**
        *  @brief 设置通道主码流编码方式
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] cmd    返回的编码方式, 0->H264  1->MPEG4  2->JPEG  其他->错误
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVideoEncodeType(IntPtr handle, int cmd);

        /**
        *  @brief 获取视频的编码方式
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [OUT] pEncType	返回的编码方式, 0:H264  1:MPEG4  2:JPEG  其他:错误
        *  @return 返回值为0表示成功，返回-1表示失败
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVideoEncodeType(IntPtr handle, ref int pEncType);

        /**
        *  @brief 获取视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetVideoVBR(IntPtr handle, ref int levelval);

        /**
        *  @brief 设置视频图像质量；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] levelval //0~6，6最好
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetVideoVBR(IntPtr handle, int levelval);

        /**
        *  @brief 获取视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetFrequency(IntPtr handle, ref int frequency);

        /**
        *  @brief 设置视频制式；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] frequency 0:MaxOrZero, 1: 50Hz, 2:60Hz
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetFrequency(IntPtr handle, int frequency);

        /**
        *  @brief 获取曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetShutter(IntPtr handle, ref int shutter);

        /**
        *  @brief 设置曝光时间；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] shutter 2:>0~8ms 停车场推荐, 3: 0~4ms, 4:0~2ms 卡口推荐
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetShutter(IntPtr handle, int shutter);

        /**
        *  @brief 获取图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetFlip(IntPtr handle, ref int flip);

        /**
        *  @brief 设置图像翻转；
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] flip, 0: 原始图像, 1:上下翻转, 2:左右翻转, 3:中心翻转
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_UpdateNetworkParam(uint sh, uint sl, string strNewIP, string strGateway, string strNetmask);

        /**
        *  @brief 获取设备序列号；
        *  @param [IN] ip ip统一使用字符串的形式传入
        *  @param [IN] port 使用和登录时相同的端口
        *  @param [OUT] SerHi 序列号高位
        *  @param [OUT] SerLo 序列号低位
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo);

        /**
        *  @brief 开始实时图像数据流，用于实时获取图像数据
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_StartRealPlayDecData(IntPtr handle);

        /**
        *  @brief 停止实时图像数据流
        *  @param  [IN] handle		由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        *  @ingroup group_device
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetJpegStreamFromRealPlayDec(IntPtr handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality);

        /**
        *  @brief 设置是否输出实时结果
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param  [IN] bOutput 是否输出
        *  @return 0表示成功，-1表示失败
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetIsOutputRealTimeResult(IntPtr handle, bool bOutput);

        /**
        *  @brief 获取设备加密类型和当前加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pData 加密信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetEMS(IntPtr handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData);
        /**
        *  @brief 设置设备加密类型
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] nEncyptId	修改的加密类型ID 
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetEncrypt(IntPtr handle, IntPtr pCurrentKey, UInt32 nEncyptId);

        /**
        *  @brief 修改设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCurrentKey 当前识别密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_ChangeEncryptKey(IntPtr handle, IntPtr pCurrentKey, IntPtr pNewKey);

        /**
        *  @brief 重置设备识别密码
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pPrimeKey 当前设备主密码
        *  @param [IN] pNewKey	新识别密码
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_PlayVoice(IntPtr handle, string voice, int interval, int volume, int male);

        //**************************************************************
        // 中心服务器配置
        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 获取中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

        /**
        *  @brief 设置中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 获取中心服务器设备注册
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerDeviceReg  中心服务器注册结构
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

        /**
        *  @brief 设置中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 获取中心服务器网络车牌推送信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerPlate  中心服务器车牌推送信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

        /**
        *  @brief 设置中心服务器网络
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerNet  中心服务器信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 获取中心服务器网络端口触发信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerGionin  中心服务器端口触发信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

        /**
        *  @brief 设置中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 获取中心服务器网络串口信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerSerial  中心服务器串口信息
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

        /**
        *  @brief 设置中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetCenterServerHostBak(IntPtr handle, string pCenterServerHostBak);

        /**
        *  @brief 获取中心服务器网络主机备份信息
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] pCenterServerHostBak  中心服务器主机备份信息  例如:"192.168.3.5;192.168.3.6"
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetCenterServerHostBak(IntPtr handle, ref string pCenterServerHostBak);

        /**
        *  @brief 获取设备硬件信息
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_version  设备类型
        *  @param [OUT] exdataSize 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetHwBoardVersion(IntPtr handle, ref int board_version, ref Int64 exdataSize);

        /**
        *  @brief 获取设备硬件类型
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] board_type  设备类型(0:3730,1:6446,2:8127)
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetHwBoardType(IntPtr handle, ref int board_type);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetAlgResultParam(IntPtr handle, ref int reco_dis);

        /**
        *  @brief 获取定焦版本相机安装距离
        *  @param [IN] iUserID VZC_Login函数返回的用户ID
        *  @param [OUT] reco_dis安装距离 0:2-4米, 2: 4-6米, 1: 6-8米
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetAlgResultParam(IntPtr handle, int reco_dis);

        /**
        *  @brief 获取图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_GetDenoise(IntPtr handle, ref int mode, ref int strength);

        /**
        *  @brief 设置图像增强配置
        *  @param [IN]  handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] mode  设备类型
        *  @param [OUT] strength 额外数据长度。
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetDenoise(IntPtr handle, int mode, int strength);

        /**
        *  @brief 获取R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流 
        *  @param [OUT] param 编码参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_RGet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 设置R相机的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_RSet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

        /**
        *  @brief 获取R相机支持的编码参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @param [IN] stream 0主码流 1子码流
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_RGet_Encode_Param_Property(IntPtr handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [OUT] param 视频参数
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_RGet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 获取R相机的视频参数；
        *  @param  [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] iChannel 通道号
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_RSet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param);

        /**
        *  @brief 开始喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] client_win_size 客户端窗口大小
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_StartTalk(IntPtr handle, int client_win_size);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetRequestTalkCallBack(IntPtr handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData);

        /**
        *  @brief 停止喊话
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] device_ip 设备IP
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_StopTalk(IntPtr handle);

        /**
        *  @brief 开始录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @parmm [IN] file_path 音频文件路径
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_StartRecordAudio(IntPtr handle, string file_path);

        /**
        *  @brief 停止录音
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_StopRecordAudio(IntPtr handle);

        /**
        *  @brief 设置车牌图片里是否显示车牌框
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] bShow 是否显示车牌框，输入值(0或1)，1代表显示，0代表不显示
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
        public static extern int VzLPRClient_SetIsShowPlateRect(IntPtr handle, int bShow);

        /**
        *  @brief 设置GPIO输入回调函数
        *  @param [IN] handle 由VzLPRClient_Open函数获得的句柄
        *  @param [IN] func GPIO输入回调函数
        *  @param [IN] pUserData 用户自定义数据
        *  @return 返回值为0表示成功，返回其他值表示失败。
        */
        [DllImport(VzClientSdk.DllFileName)]
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
        [DllImport(VzClientSdk.DllFileName)]
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
        int IVzClientSdkProxy.VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, IntPtr value) => VzLPRClient_GetGPIOValue(handle, gpioIn, value);
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
    internal class VzClientSdkLoader : ASdkDynamicLoader, IVzClientSdkProxy
    {
        #region // 委托定义
        private DCreater.VzLPRClient_CancelOfflineCheck _VzLPRClient_CancelOfflineCheck;
        private DCreater.VzLPRClient_ChangeEncryptKey _VzLPRClient_ChangeEncryptKey;
        private DCreater.VzLPRClient_Cleanup _VzLPRClient_Cleanup;
        private DCreater.VzLPRClient_Close _VzLPRClient_Close;
        private DCreater.VzLPRClient_CloseByIP _VzLPRClient_CloseByIP;
        private DCreater.VzLPRClient_ForceTrigger _VzLPRClient_ForceTrigger;
        private DCreater.VzLPRClient_GetAlgResultParam _VzLPRClient_GetAlgResultParam;
        private DCreater.VzLPRClient_GetCameraConfig _VzLPRClient_GetCameraConfig;
        private DCreater.VzLPRClient_GetCenterServerDeviceReg _VzLPRClient_GetCenterServerDeviceReg;
        private DCreater.VzLPRClient_GetCenterServerGionin _VzLPRClient_GetCenterServerGionin;
        private DCreater.VzLPRClient_GetCenterServerHostBak _VzLPRClient_GetCenterServerHostBak;
        private DCreater.VzLPRClient_GetCenterServerNet _VzLPRClient_GetCenterServerNet;
        private DCreater.VzLPRClient_GetCenterServerPlate _VzLPRClient_GetCenterServerPlate;
        private DCreater.VzLPRClient_GetCenterServerSerial _VzLPRClient_GetCenterServerSerial;
        private DCreater.VzLPRClient_GetDenoise _VzLPRClient_GetDenoise;
        private DCreater.VzLPRClient_GetDeviceIP _VzLPRClient_GetDeviceIP;
        private DCreater.VzLPRClient_GetDrawMode _VzLPRClient_GetDrawMode;
        private DCreater.VzLPRClient_GetEMS _VzLPRClient_GetEMS;
        private DCreater.VzLPRClient_GetFlip _VzLPRClient_GetFlip;
        private DCreater.VzLPRClient_GetFrequency _VzLPRClient_GetFrequency;
        private DCreater.VzLPRClient_GetGPIOValue _VzLPRClient_GetGPIOValue;
        private DCreater.VzLPRClient_GetHwBoardType _VzLPRClient_GetHwBoardType;
        private DCreater.VzLPRClient_GetHwBoardVersion _VzLPRClient_GetHwBoardVersion;
        private DCreater.VzLPRClient_GetIOOutput _VzLPRClient_GetIOOutput;
        private DCreater.VzLPRClient_GetJpegStreamFromRealPlayDec _VzLPRClient_GetJpegStreamFromRealPlayDec;
        private DCreater.VzLPRClient_GetLEDLightStatus _VzLPRClient_GetLEDLightStatus;
        private DCreater.VzLPRClient_GetOsdParam _VzLPRClient_GetOsdParam;
        private DCreater.VzLPRClient_GetOutputConfig _VzLPRClient_GetOutputConfig;
        private DCreater.VzLPRClient_GetPlateRecType _VzLPRClient_GetPlateRecType;
        private DCreater.VzLPRClient_GetPlateTrigType _VzLPRClient_GetPlateTrigType;
        private DCreater.VzLPRClient_GetRegionOfInterestEx _VzLPRClient_GetRegionOfInterestEx;
        private DCreater.VzLPRClient_GetSerialNo _VzLPRClient_GetSerialNo;
        private DCreater.VzLPRClient_GetSerialNumber _VzLPRClient_GetSerialNumber;
        private DCreater.VzLPRClient_GetSerialParameter _VzLPRClient_GetSerialParameter;
        private DCreater.VzLPRClient_GetShutter _VzLPRClient_GetShutter;
        private DCreater.VzLPRClient_GetSnapShootToJpeg2 _VzLPRClient_GetSnapShootToJpeg2;
        private DCreater.VzLPRClient_SaveSnapImageToJpeg _VzLPRClient_SaveSnapImageToJpeg;
        private DCreater.VzLPRClient_GetSupportedProvinces _VzLPRClient_GetSupportedProvinces;
        private DCreater.VzLPRClient_GetTriggerDelay _VzLPRClient_GetTriggerDelay;
        private DCreater.VzLPRClient_GetVideoCBR _VzLPRClient_GetVideoCBR;
        private DCreater.VzLPRClient_GetVideoCompressMode _VzLPRClient_GetVideoCompressMode;
        private DCreater.VzLPRClient_GetVideoEncodeType _VzLPRClient_GetVideoEncodeType;
        private DCreater.VzLPRClient_GetVideoFrameRate _VzLPRClient_GetVideoFrameRate;
        private DCreater.VzLPRClient_GetVideoFrameSizeIndex _VzLPRClient_GetVideoFrameSizeIndex;
        private DCreater.VzLPRClient_GetVideoFrameSizeIndexEx _VzLPRClient_GetVideoFrameSizeIndexEx;
        private DCreater.VzLPRClient_GetVideoPara _VzLPRClient_GetVideoPara;
        private DCreater.VzLPRClient_GetVideoVBR _VzLPRClient_GetVideoVBR;
        private DCreater.VzLPRClient_GetVirtualLoop _VzLPRClient_GetVirtualLoop;
        private DCreater.VzLPRClient_GetWLCheckMethod _VzLPRClient_GetWLCheckMethod;
        private DCreater.VzLPRClient_GetWLFuzzy _VzLPRClient_GetWLFuzzy;
        private DCreater.VzLPRClient_ImageEncodeToJpeg _VzLPRClient_ImageEncodeToJpeg;
        private DCreater.VzLPRClient_ImageSaveToJpeg _VzLPRClient_ImageSaveToJpeg;
        private DCreater.VzLPRClient_IsConnected _VzLPRClient_IsConnected;
        private DCreater.VzLPRClient_LoadImageById _VzLPRClient_LoadImageById;
        private DCreater.VzLPRClient_Open _VzLPRClient_Open;
        private DCreater.VzLPRClient_OpenV2 _VzLPRClient_OpenV2;
        private DCreater.VzLPRClient_PlayVoice _VzLPRClient_PlayVoice;
        private DCreater.VzLPRClient_PresetProvinceIndex _VzLPRClient_PresetProvinceIndex;
        private DCreater.VzLPRClient_QueryCountByTimeAndPlate _VzLPRClient_QueryCountByTimeAndPlate;
        private DCreater.VzLPRClient_QueryPageRecordByTimeAndPlate _VzLPRClient_QueryPageRecordByTimeAndPlate;
        private DCreater.VzLPRClient_QueryRecordByTimeAndPlate _VzLPRClient_QueryRecordByTimeAndPlate;
        private DCreater.VzLPRClient_ReadUserData _VzLPRClient_ReadUserData;
        private DCreater.VzLPRClient_ResetEncryptKey _VzLPRClient_ResetEncryptKey;
        private DCreater.VzLPRClient_RGet_Encode_Param _VzLPRClient_RGet_Encode_Param;
        private DCreater.VzLPRClient_RGet_Encode_Param_Property _VzLPRClient_RGet_Encode_Param_Property;
        private DCreater.VzLPRClient_RGet_Video_Param _VzLPRClient_RGet_Video_Param;
        private DCreater.VzLPRClient_RSet_Encode_Param _VzLPRClient_RSet_Encode_Param;
        private DCreater.VzLPRClient_RSet_Video_Param _VzLPRClient_RSet_Video_Param;
        private DCreater.VzLPRClient_SaveRealData _VzLPRClient_SaveRealData;
        private DCreater.VzLPRClient_SerialSend _VzLPRClient_SerialSend;
        private DCreater.VzLPRClient_SerialStart _VzLPRClient_SerialStart;
        private DCreater.VzLPRClient_SerialStop _VzLPRClient_SerialStop;
        private DCreater.VzLPRClient_SetAlgResultParam _VzLPRClient_SetAlgResultParam;
        private DCreater.VzLPRClient_SetCenterServerDeviceReg _VzLPRClient_SetCenterServerDeviceReg;
        private DCreater.VzLPRClient_SetCenterServerGionin _VzLPRClient_SetCenterServerGionin;
        private DCreater.VzLPRClient_SetCenterServerHostBak _VzLPRClient_SetCenterServerHostBak;
        private DCreater.VzLPRClient_SetCenterServerNet _VzLPRClient_SetCenterServerNet;
        private DCreater.VzLPRClient_SetCenterServerPlate _VzLPRClient_SetCenterServerPlate;
        private DCreater.VzLPRClient_SetCenterServerSerial _VzLPRClient_SetCenterServerSerial;
        private DCreater.VZLPRClient_SetCommonNotifyCallBack _VZLPRClient_SetCommonNotifyCallBack;
        private DCreater.VzLPRClient_SetDateTime _VzLPRClient_SetDateTime;
        private DCreater.VzLPRClient_SetDenoise _VzLPRClient_SetDenoise;
        private DCreater.VzLPRClient_SetDrawMode _VzLPRClient_SetDrawMode;
        private DCreater.VzLPRClient_SetEncrypt _VzLPRClient_SetEncrypt;
        private DCreater.VzLPRClient_SetFlip _VzLPRClient_SetFlip;
        private DCreater.VzLPRClient_SetFrequency _VzLPRClient_SetFrequency;
        private DCreater.VzLPRClient_SetGPIORecvCallBack _VzLPRClient_SetGPIORecvCallBack;
        private DCreater.VzLPRClient_SetIOOutput _VzLPRClient_SetIOOutput;
        private DCreater.VzLPRClient_SetIOOutputAuto _VzLPRClient_SetIOOutputAuto;
        private DCreater.VzLPRClient_SetIsOutputRealTimeResult _VzLPRClient_SetIsOutputRealTimeResult;
        private DCreater.VzLPRClient_SetIsShowPlateRect _VzLPRClient_SetIsShowPlateRect;
        private DCreater.VzLPRClient_SetLEDLightControlMode _VzLPRClient_SetLEDLightControlMode;
        private DCreater.VzLPRClient_SetLEDLightLevel _VzLPRClient_SetLEDLightLevel;
        private DCreater.VzLPRClient_SetOfflineCheck _VzLPRClient_SetOfflineCheck;
        private DCreater.VzLPRClient_SetOsdParam _VzLPRClient_SetOsdParam;
        private DCreater.VzLPRClient_SetOutputConfig _VzLPRClient_SetOutputConfig;
        private DCreater.VzLPRClient_SetPlateInfoCallBack _VzLPRClient_SetPlateInfoCallBack;
        private DCreater.VzLPRClient_SetPlateRecType _VzLPRClient_SetPlateRecType;
        private DCreater.VzLPRClient_SetPlateTrigType _VzLPRClient_SetPlateTrigType;
        private DCreater.VzLPRClient_SetQueryPlateCallBack _VzLPRClient_SetQueryPlateCallBack;
        private DCreater.VzLPRClient_SetRequestTalkCallBack _VzLPRClient_SetRequestTalkCallBack;
        private DCreater.VzLPRClient_SetSerialParameter _VzLPRClient_SetSerialParameter;
        private DCreater.VzLPRClient_SetShutter _VzLPRClient_SetShutter;
        private DCreater.VzLPRClient_SetTriggerDelay _VzLPRClient_SetTriggerDelay;
        private DCreater.VzLPRClient_Setup _VzLPRClient_Setup;
        private DCreater.VzLPRClient_SetVideoCBR _VzLPRClient_SetVideoCBR;
        private DCreater.VzLPRClient_SetVideoCompressMode _VzLPRClient_SetVideoCompressMode;
        private DCreater.VzLPRClient_SetVideoEncodeType _VzLPRClient_SetVideoEncodeType;
        private DCreater.VzLPRClient_SetVideoFrameCallBack _VzLPRClient_SetVideoFrameCallBack;
        private DCreater.VzLPRClient_SetVideoFrameRate _VzLPRClient_SetVideoFrameRate;
        private DCreater.VzLPRClient_SetVideoFrameSizeIndex _VzLPRClient_SetVideoFrameSizeIndex;
        private DCreater.VzLPRClient_SetVideoFrameSizeIndexEx _VzLPRClient_SetVideoFrameSizeIndexEx;
        private DCreater.VzLPRClient_SetVideoPara _VzLPRClient_SetVideoPara;
        private DCreater.VzLPRClient_SetVideoVBR _VzLPRClient_SetVideoVBR;
        private DCreater.VzLPRClient_SetVirtualLoop _VzLPRClient_SetVirtualLoop;
        private DCreater.VzLPRClient_SetWLCheckMethod _VzLPRClient_SetWLCheckMethod;
        private DCreater.VzLPRClient_SetWLFuzzy _VzLPRClient_SetWLFuzzy;
        private DCreater.VZLPRClient_StartFindDeviceEx _VZLPRClient_StartFindDeviceEx;
        private DCreater.VzLPRClient_StartRealPlay _VzLPRClient_StartRealPlay;
        private DCreater.VzLPRClient_StartRealPlayDecData _VzLPRClient_StartRealPlayDecData;
        private DCreater.VzLPRClient_StartRealPlayFrameCallBack _VzLPRClient_StartRealPlayFrameCallBack;
        private DCreater.VzLPRClient_StartRecordAudio _VzLPRClient_StartRecordAudio;
        private DCreater.VzLPRClient_StartTalk _VzLPRClient_StartTalk;
        private DCreater.VZLPRClient_StopFindDevice _VZLPRClient_StopFindDevice;
        private DCreater.VzLPRClient_StopRealPlay _VzLPRClient_StopRealPlay;
        private DCreater.VzLPRClient_StopRealPlayDecData _VzLPRClient_StopRealPlayDecData;
        private DCreater.VzLPRClient_StopRecordAudio _VzLPRClient_StopRecordAudio;
        private DCreater.VzLPRClient_StopSaveRealData _VzLPRClient_StopSaveRealData;
        private DCreater.VzLPRClient_StopTalk _VzLPRClient_StopTalk;
        private DCreater.VzLPRClient_UpdateNetworkParam _VzLPRClient_UpdateNetworkParam;
        private DCreater.VzLPRClient_WhiteListClearCustomersAndVehicles _VzLPRClient_WhiteListClearCustomersAndVehicles;
        private DCreater.VzLPRClient_WhiteListDeleteVehicle _VzLPRClient_WhiteListDeleteVehicle;
        private DCreater.VzLPRClient_WhiteListGetRowCount _VzLPRClient_WhiteListGetRowCount;
        private DCreater.VzLPRClient_WhiteListGetVehicleCount _VzLPRClient_WhiteListGetVehicleCount;
        private DCreater.VzLPRClient_WhiteListImportRows _VzLPRClient_WhiteListImportRows;
        private DCreater.VzLPRClient_WhiteListLoadVehicle _VzLPRClient_WhiteListLoadVehicle;
        private DCreater.VzLPRClient_WhiteListSetQueryCallBack _VzLPRClient_WhiteListSetQueryCallBack;
        private DCreater.VzLPRClient_WhiteListUpdateVehicleByID _VzLPRClient_WhiteListUpdateVehicleByID;
        private DCreater.VzLPRClient_WriteUserData _VzLPRClient_WriteUserData;
        #endregion 委托定义
        public VzClientSdkLoader()
        {
            _VzLPRClient_CancelOfflineCheck = GetDelegate<DCreater.VzLPRClient_CancelOfflineCheck>(nameof(DCreater.VzLPRClient_CancelOfflineCheck));
            _VzLPRClient_ChangeEncryptKey = GetDelegate<DCreater.VzLPRClient_ChangeEncryptKey>(nameof(DCreater.VzLPRClient_ChangeEncryptKey));
            _VzLPRClient_Cleanup = GetDelegate<DCreater.VzLPRClient_Cleanup>(nameof(DCreater.VzLPRClient_Cleanup));
            _VzLPRClient_Close = GetDelegate<DCreater.VzLPRClient_Close>(nameof(DCreater.VzLPRClient_Close));
            _VzLPRClient_CloseByIP = GetDelegate<DCreater.VzLPRClient_CloseByIP>(nameof(DCreater.VzLPRClient_CloseByIP));
            _VzLPRClient_ForceTrigger = GetDelegate<DCreater.VzLPRClient_ForceTrigger>(nameof(DCreater.VzLPRClient_ForceTrigger));
            _VzLPRClient_GetAlgResultParam = GetDelegate<DCreater.VzLPRClient_GetAlgResultParam>(nameof(DCreater.VzLPRClient_GetAlgResultParam));
            _VzLPRClient_GetCameraConfig = GetDelegate<DCreater.VzLPRClient_GetCameraConfig>(nameof(DCreater.VzLPRClient_GetCameraConfig));
            _VzLPRClient_GetCenterServerDeviceReg = GetDelegate<DCreater.VzLPRClient_GetCenterServerDeviceReg>(nameof(DCreater.VzLPRClient_GetCenterServerDeviceReg));
            _VzLPRClient_GetCenterServerGionin = GetDelegate<DCreater.VzLPRClient_GetCenterServerGionin>(nameof(DCreater.VzLPRClient_GetCenterServerGionin));
            _VzLPRClient_GetCenterServerHostBak = GetDelegate<DCreater.VzLPRClient_GetCenterServerHostBak>(nameof(DCreater.VzLPRClient_GetCenterServerHostBak));
            _VzLPRClient_GetCenterServerNet = GetDelegate<DCreater.VzLPRClient_GetCenterServerNet>(nameof(DCreater.VzLPRClient_GetCenterServerNet));
            _VzLPRClient_GetCenterServerPlate = GetDelegate<DCreater.VzLPRClient_GetCenterServerPlate>(nameof(DCreater.VzLPRClient_GetCenterServerPlate));
            _VzLPRClient_GetCenterServerSerial = GetDelegate<DCreater.VzLPRClient_GetCenterServerSerial>(nameof(DCreater.VzLPRClient_GetCenterServerSerial));
            _VzLPRClient_GetDenoise = GetDelegate<DCreater.VzLPRClient_GetDenoise>(nameof(DCreater.VzLPRClient_GetDenoise));
            _VzLPRClient_GetDeviceIP = GetDelegate<DCreater.VzLPRClient_GetDeviceIP>(nameof(DCreater.VzLPRClient_GetDeviceIP));
            _VzLPRClient_GetDrawMode = GetDelegate<DCreater.VzLPRClient_GetDrawMode>(nameof(DCreater.VzLPRClient_GetDrawMode));
            _VzLPRClient_GetEMS = GetDelegate<DCreater.VzLPRClient_GetEMS>(nameof(DCreater.VzLPRClient_GetEMS));
            _VzLPRClient_GetFlip = GetDelegate<DCreater.VzLPRClient_GetFlip>(nameof(DCreater.VzLPRClient_GetFlip));
            _VzLPRClient_GetFrequency = GetDelegate<DCreater.VzLPRClient_GetFrequency>(nameof(DCreater.VzLPRClient_GetFrequency));
            _VzLPRClient_GetGPIOValue = GetDelegate<DCreater.VzLPRClient_GetGPIOValue>(nameof(DCreater.VzLPRClient_GetGPIOValue));
            _VzLPRClient_GetHwBoardType = GetDelegate<DCreater.VzLPRClient_GetHwBoardType>(nameof(DCreater.VzLPRClient_GetHwBoardType));
            _VzLPRClient_GetHwBoardVersion = GetDelegate<DCreater.VzLPRClient_GetHwBoardVersion>(nameof(DCreater.VzLPRClient_GetHwBoardVersion));
            _VzLPRClient_GetIOOutput = GetDelegate<DCreater.VzLPRClient_GetIOOutput>(nameof(DCreater.VzLPRClient_GetIOOutput));
            _VzLPRClient_GetJpegStreamFromRealPlayDec = GetDelegate<DCreater.VzLPRClient_GetJpegStreamFromRealPlayDec>(nameof(DCreater.VzLPRClient_GetJpegStreamFromRealPlayDec));
            _VzLPRClient_GetLEDLightStatus = GetDelegate<DCreater.VzLPRClient_GetLEDLightStatus>(nameof(DCreater.VzLPRClient_GetLEDLightStatus));
            _VzLPRClient_GetOsdParam = GetDelegate<DCreater.VzLPRClient_GetOsdParam>(nameof(DCreater.VzLPRClient_GetOsdParam));
            _VzLPRClient_GetOutputConfig = GetDelegate<DCreater.VzLPRClient_GetOutputConfig>(nameof(DCreater.VzLPRClient_GetOutputConfig));
            _VzLPRClient_GetPlateRecType = GetDelegate<DCreater.VzLPRClient_GetPlateRecType>(nameof(DCreater.VzLPRClient_GetPlateRecType));
            _VzLPRClient_GetPlateTrigType = GetDelegate<DCreater.VzLPRClient_GetPlateTrigType>(nameof(DCreater.VzLPRClient_GetPlateTrigType));
            _VzLPRClient_GetRegionOfInterestEx = GetDelegate<DCreater.VzLPRClient_GetRegionOfInterestEx>(nameof(DCreater.VzLPRClient_GetRegionOfInterestEx));
            _VzLPRClient_GetSerialNo = GetDelegate<DCreater.VzLPRClient_GetSerialNo>(nameof(DCreater.VzLPRClient_GetSerialNo));
            _VzLPRClient_GetSerialNumber = GetDelegate<DCreater.VzLPRClient_GetSerialNumber>(nameof(DCreater.VzLPRClient_GetSerialNumber));
            _VzLPRClient_GetSerialParameter = GetDelegate<DCreater.VzLPRClient_GetSerialParameter>(nameof(DCreater.VzLPRClient_GetSerialParameter));
            _VzLPRClient_GetShutter = GetDelegate<DCreater.VzLPRClient_GetShutter>(nameof(DCreater.VzLPRClient_GetShutter));
            _VzLPRClient_GetSnapShootToJpeg2 = GetDelegate<DCreater.VzLPRClient_GetSnapShootToJpeg2>(nameof(DCreater.VzLPRClient_GetSnapShootToJpeg2));
            _VzLPRClient_SaveSnapImageToJpeg = GetDelegate<DCreater.VzLPRClient_SaveSnapImageToJpeg>(nameof(DCreater.VzLPRClient_SaveSnapImageToJpeg));
            _VzLPRClient_GetSupportedProvinces = GetDelegate<DCreater.VzLPRClient_GetSupportedProvinces>(nameof(DCreater.VzLPRClient_GetSupportedProvinces));
            _VzLPRClient_GetTriggerDelay = GetDelegate<DCreater.VzLPRClient_GetTriggerDelay>(nameof(DCreater.VzLPRClient_GetTriggerDelay));
            _VzLPRClient_GetVideoCBR = GetDelegate<DCreater.VzLPRClient_GetVideoCBR>(nameof(DCreater.VzLPRClient_GetVideoCBR));
            _VzLPRClient_GetVideoCompressMode = GetDelegate<DCreater.VzLPRClient_GetVideoCompressMode>(nameof(DCreater.VzLPRClient_GetVideoCompressMode));
            _VzLPRClient_GetVideoEncodeType = GetDelegate<DCreater.VzLPRClient_GetVideoEncodeType>(nameof(DCreater.VzLPRClient_GetVideoEncodeType));
            _VzLPRClient_GetVideoFrameRate = GetDelegate<DCreater.VzLPRClient_GetVideoFrameRate>(nameof(DCreater.VzLPRClient_GetVideoFrameRate));
            _VzLPRClient_GetVideoFrameSizeIndex = GetDelegate<DCreater.VzLPRClient_GetVideoFrameSizeIndex>(nameof(DCreater.VzLPRClient_GetVideoFrameSizeIndex));
            _VzLPRClient_GetVideoFrameSizeIndexEx = GetDelegate<DCreater.VzLPRClient_GetVideoFrameSizeIndexEx>(nameof(DCreater.VzLPRClient_GetVideoFrameSizeIndexEx));
            _VzLPRClient_GetVideoPara = GetDelegate<DCreater.VzLPRClient_GetVideoPara>(nameof(DCreater.VzLPRClient_GetVideoPara));
            _VzLPRClient_GetVideoVBR = GetDelegate<DCreater.VzLPRClient_GetVideoVBR>(nameof(DCreater.VzLPRClient_GetVideoVBR));
            _VzLPRClient_GetVirtualLoop = GetDelegate<DCreater.VzLPRClient_GetVirtualLoop>(nameof(DCreater.VzLPRClient_GetVirtualLoop));
            _VzLPRClient_GetWLCheckMethod = GetDelegate<DCreater.VzLPRClient_GetWLCheckMethod>(nameof(DCreater.VzLPRClient_GetWLCheckMethod));
            _VzLPRClient_GetWLFuzzy = GetDelegate<DCreater.VzLPRClient_GetWLFuzzy>(nameof(DCreater.VzLPRClient_GetWLFuzzy));
            _VzLPRClient_ImageEncodeToJpeg = GetDelegate<DCreater.VzLPRClient_ImageEncodeToJpeg>(nameof(DCreater.VzLPRClient_ImageEncodeToJpeg));
            _VzLPRClient_ImageSaveToJpeg = GetDelegate<DCreater.VzLPRClient_ImageSaveToJpeg>(nameof(DCreater.VzLPRClient_ImageSaveToJpeg));
            _VzLPRClient_IsConnected = GetDelegate<DCreater.VzLPRClient_IsConnected>(nameof(DCreater.VzLPRClient_IsConnected));
            _VzLPRClient_LoadImageById = GetDelegate<DCreater.VzLPRClient_LoadImageById>(nameof(DCreater.VzLPRClient_LoadImageById));
            _VzLPRClient_Open = GetDelegate<DCreater.VzLPRClient_Open>(nameof(DCreater.VzLPRClient_Open));
            _VzLPRClient_OpenV2 = GetDelegate<DCreater.VzLPRClient_OpenV2>(nameof(DCreater.VzLPRClient_OpenV2));
            _VzLPRClient_PlayVoice = GetDelegate<DCreater.VzLPRClient_PlayVoice>(nameof(DCreater.VzLPRClient_PlayVoice));
            _VzLPRClient_PresetProvinceIndex = GetDelegate<DCreater.VzLPRClient_PresetProvinceIndex>(nameof(DCreater.VzLPRClient_PresetProvinceIndex));
            _VzLPRClient_QueryCountByTimeAndPlate = GetDelegate<DCreater.VzLPRClient_QueryCountByTimeAndPlate>(nameof(DCreater.VzLPRClient_QueryCountByTimeAndPlate));
            _VzLPRClient_QueryPageRecordByTimeAndPlate = GetDelegate<DCreater.VzLPRClient_QueryPageRecordByTimeAndPlate>(nameof(DCreater.VzLPRClient_QueryPageRecordByTimeAndPlate));
            _VzLPRClient_QueryRecordByTimeAndPlate = GetDelegate<DCreater.VzLPRClient_QueryRecordByTimeAndPlate>(nameof(DCreater.VzLPRClient_QueryRecordByTimeAndPlate));
            _VzLPRClient_ReadUserData = GetDelegate<DCreater.VzLPRClient_ReadUserData>(nameof(DCreater.VzLPRClient_ReadUserData));
            _VzLPRClient_ResetEncryptKey = GetDelegate<DCreater.VzLPRClient_ResetEncryptKey>(nameof(DCreater.VzLPRClient_ResetEncryptKey));
            _VzLPRClient_RGet_Encode_Param = GetDelegate<DCreater.VzLPRClient_RGet_Encode_Param>(nameof(DCreater.VzLPRClient_RGet_Encode_Param));
            _VzLPRClient_RGet_Encode_Param_Property = GetDelegate<DCreater.VzLPRClient_RGet_Encode_Param_Property>(nameof(DCreater.VzLPRClient_RGet_Encode_Param_Property));
            _VzLPRClient_RGet_Video_Param = GetDelegate<DCreater.VzLPRClient_RGet_Video_Param>(nameof(DCreater.VzLPRClient_RGet_Video_Param));
            _VzLPRClient_RSet_Encode_Param = GetDelegate<DCreater.VzLPRClient_RSet_Encode_Param>(nameof(DCreater.VzLPRClient_RSet_Encode_Param));
            _VzLPRClient_RSet_Video_Param = GetDelegate<DCreater.VzLPRClient_RSet_Video_Param>(nameof(DCreater.VzLPRClient_RSet_Video_Param));
            _VzLPRClient_SaveRealData = GetDelegate<DCreater.VzLPRClient_SaveRealData>(nameof(DCreater.VzLPRClient_SaveRealData));
            _VzLPRClient_SerialSend = GetDelegate<DCreater.VzLPRClient_SerialSend>(nameof(DCreater.VzLPRClient_SerialSend));
            _VzLPRClient_SerialStart = GetDelegate<DCreater.VzLPRClient_SerialStart>(nameof(DCreater.VzLPRClient_SerialStart));
            _VzLPRClient_SerialStop = GetDelegate<DCreater.VzLPRClient_SerialStop>(nameof(DCreater.VzLPRClient_SerialStop));
            _VzLPRClient_SetAlgResultParam = GetDelegate<DCreater.VzLPRClient_SetAlgResultParam>(nameof(DCreater.VzLPRClient_SetAlgResultParam));
            _VzLPRClient_SetCenterServerDeviceReg = GetDelegate<DCreater.VzLPRClient_SetCenterServerDeviceReg>(nameof(DCreater.VzLPRClient_SetCenterServerDeviceReg));
            _VzLPRClient_SetCenterServerGionin = GetDelegate<DCreater.VzLPRClient_SetCenterServerGionin>(nameof(DCreater.VzLPRClient_SetCenterServerGionin));
            _VzLPRClient_SetCenterServerHostBak = GetDelegate<DCreater.VzLPRClient_SetCenterServerHostBak>(nameof(DCreater.VzLPRClient_SetCenterServerHostBak));
            _VzLPRClient_SetCenterServerNet = GetDelegate<DCreater.VzLPRClient_SetCenterServerNet>(nameof(DCreater.VzLPRClient_SetCenterServerNet));
            _VzLPRClient_SetCenterServerPlate = GetDelegate<DCreater.VzLPRClient_SetCenterServerPlate>(nameof(DCreater.VzLPRClient_SetCenterServerPlate));
            _VzLPRClient_SetCenterServerSerial = GetDelegate<DCreater.VzLPRClient_SetCenterServerSerial>(nameof(DCreater.VzLPRClient_SetCenterServerSerial));
            _VZLPRClient_SetCommonNotifyCallBack = GetDelegate<DCreater.VZLPRClient_SetCommonNotifyCallBack>(nameof(DCreater.VZLPRClient_SetCommonNotifyCallBack));
            _VzLPRClient_SetDateTime = GetDelegate<DCreater.VzLPRClient_SetDateTime>(nameof(DCreater.VzLPRClient_SetDateTime));
            _VzLPRClient_SetDenoise = GetDelegate<DCreater.VzLPRClient_SetDenoise>(nameof(DCreater.VzLPRClient_SetDenoise));
            _VzLPRClient_SetDrawMode = GetDelegate<DCreater.VzLPRClient_SetDrawMode>(nameof(DCreater.VzLPRClient_SetDrawMode));
            _VzLPRClient_SetEncrypt = GetDelegate<DCreater.VzLPRClient_SetEncrypt>(nameof(DCreater.VzLPRClient_SetEncrypt));
            _VzLPRClient_SetFlip = GetDelegate<DCreater.VzLPRClient_SetFlip>(nameof(DCreater.VzLPRClient_SetFlip));
            _VzLPRClient_SetFrequency = GetDelegate<DCreater.VzLPRClient_SetFrequency>(nameof(DCreater.VzLPRClient_SetFrequency));
            _VzLPRClient_SetGPIORecvCallBack = GetDelegate<DCreater.VzLPRClient_SetGPIORecvCallBack>(nameof(DCreater.VzLPRClient_SetGPIORecvCallBack));
            _VzLPRClient_SetIOOutput = GetDelegate<DCreater.VzLPRClient_SetIOOutput>(nameof(DCreater.VzLPRClient_SetIOOutput));
            _VzLPRClient_SetIOOutputAuto = GetDelegate<DCreater.VzLPRClient_SetIOOutputAuto>(nameof(DCreater.VzLPRClient_SetIOOutputAuto));
            _VzLPRClient_SetIsOutputRealTimeResult = GetDelegate<DCreater.VzLPRClient_SetIsOutputRealTimeResult>(nameof(DCreater.VzLPRClient_SetIsOutputRealTimeResult));
            _VzLPRClient_SetIsShowPlateRect = GetDelegate<DCreater.VzLPRClient_SetIsShowPlateRect>(nameof(DCreater.VzLPRClient_SetIsShowPlateRect));
            _VzLPRClient_SetLEDLightControlMode = GetDelegate<DCreater.VzLPRClient_SetLEDLightControlMode>(nameof(DCreater.VzLPRClient_SetLEDLightControlMode));
            _VzLPRClient_SetLEDLightLevel = GetDelegate<DCreater.VzLPRClient_SetLEDLightLevel>(nameof(DCreater.VzLPRClient_SetLEDLightLevel));
            _VzLPRClient_SetOfflineCheck = GetDelegate<DCreater.VzLPRClient_SetOfflineCheck>(nameof(DCreater.VzLPRClient_SetOfflineCheck));
            _VzLPRClient_SetOsdParam = GetDelegate<DCreater.VzLPRClient_SetOsdParam>(nameof(DCreater.VzLPRClient_SetOsdParam));
            _VzLPRClient_SetOutputConfig = GetDelegate<DCreater.VzLPRClient_SetOutputConfig>(nameof(DCreater.VzLPRClient_SetOutputConfig));
            _VzLPRClient_SetPlateInfoCallBack = GetDelegate<DCreater.VzLPRClient_SetPlateInfoCallBack>(nameof(DCreater.VzLPRClient_SetPlateInfoCallBack));
            _VzLPRClient_SetPlateRecType = GetDelegate<DCreater.VzLPRClient_SetPlateRecType>(nameof(DCreater.VzLPRClient_SetPlateRecType));
            _VzLPRClient_SetPlateTrigType = GetDelegate<DCreater.VzLPRClient_SetPlateTrigType>(nameof(DCreater.VzLPRClient_SetPlateTrigType));
            _VzLPRClient_SetQueryPlateCallBack = GetDelegate<DCreater.VzLPRClient_SetQueryPlateCallBack>(nameof(DCreater.VzLPRClient_SetQueryPlateCallBack));
            _VzLPRClient_SetRequestTalkCallBack = GetDelegate<DCreater.VzLPRClient_SetRequestTalkCallBack>(nameof(DCreater.VzLPRClient_SetRequestTalkCallBack));
            _VzLPRClient_SetSerialParameter = GetDelegate<DCreater.VzLPRClient_SetSerialParameter>(nameof(DCreater.VzLPRClient_SetSerialParameter));
            _VzLPRClient_SetShutter = GetDelegate<DCreater.VzLPRClient_SetShutter>(nameof(DCreater.VzLPRClient_SetShutter));
            _VzLPRClient_SetTriggerDelay = GetDelegate<DCreater.VzLPRClient_SetTriggerDelay>(nameof(DCreater.VzLPRClient_SetTriggerDelay));
            _VzLPRClient_Setup = GetDelegate<DCreater.VzLPRClient_Setup>(nameof(DCreater.VzLPRClient_Setup));
            _VzLPRClient_SetVideoCBR = GetDelegate<DCreater.VzLPRClient_SetVideoCBR>(nameof(DCreater.VzLPRClient_SetVideoCBR));
            _VzLPRClient_SetVideoCompressMode = GetDelegate<DCreater.VzLPRClient_SetVideoCompressMode>(nameof(DCreater.VzLPRClient_SetVideoCompressMode));
            _VzLPRClient_SetVideoEncodeType = GetDelegate<DCreater.VzLPRClient_SetVideoEncodeType>(nameof(DCreater.VzLPRClient_SetVideoEncodeType));
            _VzLPRClient_SetVideoFrameCallBack = GetDelegate<DCreater.VzLPRClient_SetVideoFrameCallBack>(nameof(DCreater.VzLPRClient_SetVideoFrameCallBack));
            _VzLPRClient_SetVideoFrameRate = GetDelegate<DCreater.VzLPRClient_SetVideoFrameRate>(nameof(DCreater.VzLPRClient_SetVideoFrameRate));
            _VzLPRClient_SetVideoFrameSizeIndex = GetDelegate<DCreater.VzLPRClient_SetVideoFrameSizeIndex>(nameof(DCreater.VzLPRClient_SetVideoFrameSizeIndex));
            _VzLPRClient_SetVideoFrameSizeIndexEx = GetDelegate<DCreater.VzLPRClient_SetVideoFrameSizeIndexEx>(nameof(DCreater.VzLPRClient_SetVideoFrameSizeIndexEx));
            _VzLPRClient_SetVideoPara = GetDelegate<DCreater.VzLPRClient_SetVideoPara>(nameof(DCreater.VzLPRClient_SetVideoPara));
            _VzLPRClient_SetVideoVBR = GetDelegate<DCreater.VzLPRClient_SetVideoVBR>(nameof(DCreater.VzLPRClient_SetVideoVBR));
            _VzLPRClient_SetVirtualLoop = GetDelegate<DCreater.VzLPRClient_SetVirtualLoop>(nameof(DCreater.VzLPRClient_SetVirtualLoop));
            _VzLPRClient_SetWLCheckMethod = GetDelegate<DCreater.VzLPRClient_SetWLCheckMethod>(nameof(DCreater.VzLPRClient_SetWLCheckMethod));
            _VzLPRClient_SetWLFuzzy = GetDelegate<DCreater.VzLPRClient_SetWLFuzzy>(nameof(DCreater.VzLPRClient_SetWLFuzzy));
            _VZLPRClient_StartFindDeviceEx = GetDelegate<DCreater.VZLPRClient_StartFindDeviceEx>(nameof(DCreater.VZLPRClient_StartFindDeviceEx));
            _VzLPRClient_StartRealPlay = GetDelegate<DCreater.VzLPRClient_StartRealPlay>(nameof(DCreater.VzLPRClient_StartRealPlay));
            _VzLPRClient_StartRealPlayDecData = GetDelegate<DCreater.VzLPRClient_StartRealPlayDecData>(nameof(DCreater.VzLPRClient_StartRealPlayDecData));
            _VzLPRClient_StartRealPlayFrameCallBack = GetDelegate<DCreater.VzLPRClient_StartRealPlayFrameCallBack>(nameof(DCreater.VzLPRClient_StartRealPlayFrameCallBack));
            _VzLPRClient_StartRecordAudio = GetDelegate<DCreater.VzLPRClient_StartRecordAudio>(nameof(DCreater.VzLPRClient_StartRecordAudio));
            _VzLPRClient_StartTalk = GetDelegate<DCreater.VzLPRClient_StartTalk>(nameof(DCreater.VzLPRClient_StartTalk));
            _VZLPRClient_StopFindDevice = GetDelegate<DCreater.VZLPRClient_StopFindDevice>(nameof(DCreater.VZLPRClient_StopFindDevice));
            _VzLPRClient_StopRealPlay = GetDelegate<DCreater.VzLPRClient_StopRealPlay>(nameof(DCreater.VzLPRClient_StopRealPlay));
            _VzLPRClient_StopRealPlayDecData = GetDelegate<DCreater.VzLPRClient_StopRealPlayDecData>(nameof(DCreater.VzLPRClient_StopRealPlayDecData));
            _VzLPRClient_StopRecordAudio = GetDelegate<DCreater.VzLPRClient_StopRecordAudio>(nameof(DCreater.VzLPRClient_StopRecordAudio));
            _VzLPRClient_StopSaveRealData = GetDelegate<DCreater.VzLPRClient_StopSaveRealData>(nameof(DCreater.VzLPRClient_StopSaveRealData));
            _VzLPRClient_StopTalk = GetDelegate<DCreater.VzLPRClient_StopTalk>(nameof(DCreater.VzLPRClient_StopTalk));
            _VzLPRClient_UpdateNetworkParam = GetDelegate<DCreater.VzLPRClient_UpdateNetworkParam>(nameof(DCreater.VzLPRClient_UpdateNetworkParam));
            _VzLPRClient_WhiteListClearCustomersAndVehicles = GetDelegate<DCreater.VzLPRClient_WhiteListClearCustomersAndVehicles>(nameof(DCreater.VzLPRClient_WhiteListClearCustomersAndVehicles));
            _VzLPRClient_WhiteListDeleteVehicle = GetDelegate<DCreater.VzLPRClient_WhiteListDeleteVehicle>(nameof(DCreater.VzLPRClient_WhiteListDeleteVehicle));
            _VzLPRClient_WhiteListGetRowCount = GetDelegate<DCreater.VzLPRClient_WhiteListGetRowCount>(nameof(DCreater.VzLPRClient_WhiteListGetRowCount));
            _VzLPRClient_WhiteListGetVehicleCount = GetDelegate<DCreater.VzLPRClient_WhiteListGetVehicleCount>(nameof(DCreater.VzLPRClient_WhiteListGetVehicleCount));
            _VzLPRClient_WhiteListImportRows = GetDelegate<DCreater.VzLPRClient_WhiteListImportRows>(nameof(DCreater.VzLPRClient_WhiteListImportRows));
            _VzLPRClient_WhiteListLoadVehicle = GetDelegate<DCreater.VzLPRClient_WhiteListLoadVehicle>(nameof(DCreater.VzLPRClient_WhiteListLoadVehicle));
            _VzLPRClient_WhiteListSetQueryCallBack = GetDelegate<DCreater.VzLPRClient_WhiteListSetQueryCallBack>(nameof(DCreater.VzLPRClient_WhiteListSetQueryCallBack));
            _VzLPRClient_WhiteListUpdateVehicleByID = GetDelegate<DCreater.VzLPRClient_WhiteListUpdateVehicleByID>(nameof(DCreater.VzLPRClient_WhiteListUpdateVehicleByID));
            _VzLPRClient_WriteUserData = GetDelegate<DCreater.VzLPRClient_WriteUserData>(nameof(DCreater.VzLPRClient_WriteUserData));
        }
        public override string GetFileFullName()
        {
            return VzClientSdk.DllFullName;
        }
        /// <summary>
        /// 复制内存
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <param name="Length"></param>
        [DllImport("kernel32.dll")]
        public static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
        #region // 显示实现
        void IVzClientSdkProxy.CopyMemory(IntPtr Destination, IntPtr Source, int Length) => CopyMemory(Destination, Source, Length);
        int IVzClientSdkProxy.VzLPRClient_CancelOfflineCheck(IntPtr handle) => _VzLPRClient_CancelOfflineCheck.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_ChangeEncryptKey(IntPtr handle, IntPtr pCurrentKey, IntPtr pNewKey) => _VzLPRClient_ChangeEncryptKey.Invoke(handle, pCurrentKey, pNewKey);
        void IVzClientSdkProxy.VzLPRClient_Cleanup() => _VzLPRClient_Cleanup.Invoke();
        int IVzClientSdkProxy.VzLPRClient_Close(IntPtr handle) => _VzLPRClient_Close.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_CloseByIP(string pStrIP) => _VzLPRClient_CloseByIP.Invoke(pStrIP);
        int IVzClientSdkProxy.VzLPRClient_ForceTrigger(IntPtr handle) => _VzLPRClient_ForceTrigger.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_GetAlgResultParam(IntPtr handle, ref int reco_dis) => _VzLPRClient_GetAlgResultParam.Invoke(handle, ref reco_dis);
        int IVzClientSdkProxy.VzLPRClient_GetCameraConfig(IntPtr handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize) => _VzLPRClient_GetCameraConfig.Invoke(handle, command, channel, pOutBuffer, dwOutBufferSize);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg) => _VzLPRClient_GetCenterServerDeviceReg.Invoke(handle, ref pCenterServerDeviceReg);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin) => _VzLPRClient_GetCenterServerGionin.Invoke(handle, ref pCenterServerGionin);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerHostBak(IntPtr handle, ref string pCenterServerHostBak) => _VzLPRClient_GetCenterServerHostBak.Invoke(handle, ref pCenterServerHostBak);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet) => _VzLPRClient_GetCenterServerNet.Invoke(handle, ref pCenterServerNet);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate) => _VzLPRClient_GetCenterServerPlate.Invoke(handle, ref pCenterServerPlate);
        int IVzClientSdkProxy.VzLPRClient_GetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial) => _VzLPRClient_GetCenterServerSerial.Invoke(handle, ref pCenterServerSerial);
        int IVzClientSdkProxy.VzLPRClient_GetDenoise(IntPtr handle, ref int mode, ref int strength) => _VzLPRClient_GetDenoise.Invoke(handle, ref mode, ref strength);
        int IVzClientSdkProxy.VzLPRClient_GetDeviceIP(IntPtr handle, ref byte ip, int max_count) => _VzLPRClient_GetDeviceIP.Invoke(handle, ref ip, max_count);
        int IVzClientSdkProxy.VzLPRClient_GetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode) => _VzLPRClient_GetDrawMode.Invoke(handle, ref pDrawMode);
        int IVzClientSdkProxy.VzLPRClient_GetEMS(IntPtr handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData) => _VzLPRClient_GetEMS.Invoke(handle, ref pData);
        int IVzClientSdkProxy.VzLPRClient_GetFlip(IntPtr handle, ref int flip) => _VzLPRClient_GetFlip.Invoke(handle, ref flip);
        int IVzClientSdkProxy.VzLPRClient_GetFrequency(IntPtr handle, ref int frequency) => _VzLPRClient_GetFrequency.Invoke(handle, ref frequency);
        int IVzClientSdkProxy.VzLPRClient_GetGPIOValue(IntPtr handle, int gpioIn, IntPtr value) => _VzLPRClient_GetGPIOValue.Invoke(handle, gpioIn, value);
        int IVzClientSdkProxy.VzLPRClient_GetHwBoardType(IntPtr handle, ref int board_type) => _VzLPRClient_GetHwBoardType.Invoke(handle, ref board_type);
        int IVzClientSdkProxy.VzLPRClient_GetHwBoardVersion(IntPtr handle, ref int board_version, ref long exdataSize) => _VzLPRClient_GetHwBoardVersion.Invoke(handle, ref board_version, ref exdataSize);
        int IVzClientSdkProxy.VzLPRClient_GetIOOutput(IntPtr handle, int uChnId, ref int pOutput) => _VzLPRClient_GetIOOutput.Invoke(handle, uChnId, ref pOutput);
        int IVzClientSdkProxy.VzLPRClient_GetJpegStreamFromRealPlayDec(IntPtr handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality) => _VzLPRClient_GetJpegStreamFromRealPlayDec.Invoke(handle, pDstBuf, uSizeBuf, nQuality);
        int IVzClientSdkProxy.VzLPRClient_GetLEDLightStatus(IntPtr handle, ref int pLevelNow, ref int pLevelMax) => _VzLPRClient_GetLEDLightStatus.Invoke(handle, ref pLevelNow, ref pLevelMax);
        int IVzClientSdkProxy.VzLPRClient_GetOsdParam(IntPtr handle, IntPtr pParam) => _VzLPRClient_GetOsdParam.Invoke(handle, pParam);
        int IVzClientSdkProxy.VzLPRClient_GetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo) => _VzLPRClient_GetOutputConfig.Invoke(handle, ref pOutputConfigInfo);
        int IVzClientSdkProxy.VzLPRClient_GetPlateRecType(IntPtr handle, ref int pBitsRecType) => _VzLPRClient_GetPlateRecType.Invoke(handle, ref pBitsRecType);
        int IVzClientSdkProxy.VzLPRClient_GetPlateTrigType(IntPtr handle, ref int pBitsTrigType) => _VzLPRClient_GetPlateTrigType.Invoke(handle, ref pBitsTrigType);
        int IVzClientSdkProxy.VzLPRClient_GetRegionOfInterestEx(IntPtr handle, ref VZ_LPRC_ROI_EX pROI) => _VzLPRClient_GetRegionOfInterestEx.Invoke(handle, ref pROI);
        int IVzClientSdkProxy.VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo) => _VzLPRClient_GetSerialNo.Invoke(ip, port, ref SerHi, ref SerLo);
        int IVzClientSdkProxy.VzLPRClient_GetSerialNumber(IntPtr handle, ref VZ_DEV_SERIAL_NUM pSN) => _VzLPRClient_GetSerialNumber.Invoke(handle, ref pSN);
        int IVzClientSdkProxy.VzLPRClient_GetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter) => _VzLPRClient_GetSerialParameter.Invoke(handle, nSerialPort, ref pParameter);
        int IVzClientSdkProxy.VzLPRClient_GetShutter(IntPtr handle, ref int shutter) => _VzLPRClient_GetShutter.Invoke(handle, ref shutter);
        int IVzClientSdkProxy.VzLPRClient_GetSnapShootToJpeg2(IntPtr nPlayHandle, string pFullPathName, int nQuality) => _VzLPRClient_GetSnapShootToJpeg2.Invoke(nPlayHandle, pFullPathName, nQuality);
        int IVzClientSdkProxy.VzLPRClient_SaveSnapImageToJpeg(IntPtr handle, string pFullPathName) => _VzLPRClient_SaveSnapImageToJpeg.Invoke(handle, pFullPathName);
        int IVzClientSdkProxy.VzLPRClient_GetSupportedProvinces(IntPtr handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo) => _VzLPRClient_GetSupportedProvinces.Invoke(handle, ref pProvInfo);
        int IVzClientSdkProxy.VzLPRClient_GetTriggerDelay(IntPtr handle, ref int nDelay) => _VzLPRClient_GetTriggerDelay.Invoke(handle, ref nDelay);
        int IVzClientSdkProxy.VzLPRClient_GetVideoCBR(IntPtr handle, ref int rateval, ref int ratelist) => _VzLPRClient_GetVideoCBR.Invoke(handle, ref rateval, ref ratelist);
        int IVzClientSdkProxy.VzLPRClient_GetVideoCompressMode(IntPtr handle, ref int modeval) => _VzLPRClient_GetVideoCompressMode.Invoke(handle, ref modeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoEncodeType(IntPtr handle, ref int pEncType) => _VzLPRClient_GetVideoEncodeType.Invoke(handle, ref pEncType);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameRate(IntPtr handle, ref int Rateval) => _VzLPRClient_GetVideoFrameRate.Invoke(handle, ref Rateval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameSizeIndex(IntPtr handle, ref int sizeval) => _VzLPRClient_GetVideoFrameSizeIndex.Invoke(handle, ref sizeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoFrameSizeIndexEx(IntPtr handle, ref int sizeval) => _VzLPRClient_GetVideoFrameSizeIndexEx.Invoke(handle, ref sizeval);
        int IVzClientSdkProxy.VzLPRClient_GetVideoPara(IntPtr handle, ref int brt, ref int cst, ref int sat, ref int hue) => _VzLPRClient_GetVideoPara.Invoke(handle, ref brt, ref cst, ref sat, ref hue);
        int IVzClientSdkProxy.VzLPRClient_GetVideoVBR(IntPtr handle, ref int levelval) => _VzLPRClient_GetVideoVBR.Invoke(handle, ref levelval);
        int IVzClientSdkProxy.VzLPRClient_GetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops) => _VzLPRClient_GetVirtualLoop.Invoke(handle, ref pVirtualLoops);
        int IVzClientSdkProxy.VzLPRClient_GetWLCheckMethod(IntPtr handle, ref int nType) => _VzLPRClient_GetWLCheckMethod.Invoke(handle, ref nType);
        int IVzClientSdkProxy.VzLPRClient_GetWLFuzzy(IntPtr handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC) => _VzLPRClient_GetWLFuzzy.Invoke(handle, ref nFuzzyType, ref nFuzzyLen, ref bFuzzyCC);
        int IVzClientSdkProxy.VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality) => _VzLPRClient_ImageEncodeToJpeg.Invoke(pImgInfo, pDstBuf, uSizeBuf, nQuality);
        int IVzClientSdkProxy.VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality) => _VzLPRClient_ImageSaveToJpeg.Invoke(pImgInfo, pFullPathName, nQuality);
        int IVzClientSdkProxy.VzLPRClient_IsConnected(IntPtr handle, ref byte pStatus) => _VzLPRClient_IsConnected.Invoke(handle, ref pStatus);
        int IVzClientSdkProxy.VzLPRClient_LoadImageById(IntPtr handle, int id, IntPtr pdata, IntPtr size) => _VzLPRClient_LoadImageById.Invoke(handle, id, pdata, size);
        IntPtr IVzClientSdkProxy.VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword) => _VzLPRClient_Open.Invoke(pStrIP, wPort, pStrUserName, pStrPassword);
        IntPtr IVzClientSdkProxy.VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn) => _VzLPRClient_OpenV2.Invoke(pStrIP, wPort, pStrUserName, pStrPassword, wRtspPort, network_type, sn);
        int IVzClientSdkProxy.VzLPRClient_PlayVoice(IntPtr handle, string voice, int interval, int volume, int male) => _VzLPRClient_PlayVoice.Invoke(handle, voice, interval, volume, male);
        int IVzClientSdkProxy.VzLPRClient_PresetProvinceIndex(IntPtr handle, int nIndex) => _VzLPRClient_PresetProvinceIndex.Invoke(handle, nIndex);
        int IVzClientSdkProxy.VzLPRClient_QueryCountByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword) => _VzLPRClient_QueryCountByTimeAndPlate.Invoke(handle, pStartTime, pEndTime, keyword);
        int IVzClientSdkProxy.VzLPRClient_QueryPageRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword, int start, int end) => _VzLPRClient_QueryPageRecordByTimeAndPlate.Invoke(handle, pStartTime, pEndTime, keyword, start, end);
        int IVzClientSdkProxy.VzLPRClient_QueryRecordByTimeAndPlate(IntPtr handle, string pStartTime, string pEndTime, string keyword) => _VzLPRClient_QueryRecordByTimeAndPlate.Invoke(handle, pStartTime, pEndTime, keyword);
        int IVzClientSdkProxy.VzLPRClient_ReadUserData(IntPtr handle, IntPtr pBuffer, uint uSizeBuf) => _VzLPRClient_ReadUserData.Invoke(handle, pBuffer, uSizeBuf);
        int IVzClientSdkProxy.VzLPRClient_ResetEncryptKey(IntPtr handle, IntPtr pPrimeKey, IntPtr pNewKey) => _VzLPRClient_ResetEncryptKey.Invoke(handle, pPrimeKey, pNewKey);
        int IVzClientSdkProxy.VzLPRClient_RGet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param) => _VzLPRClient_RGet_Encode_Param.Invoke(handle, stream, ref param);
        int IVzClientSdkProxy.VzLPRClient_RGet_Encode_Param_Property(IntPtr handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param) => _VzLPRClient_RGet_Encode_Param_Property.Invoke(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_RGet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param) => _VzLPRClient_RGet_Video_Param.Invoke(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_RSet_Encode_Param(IntPtr handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param) => _VzLPRClient_RSet_Encode_Param.Invoke(handle, stream, ref param);
        int IVzClientSdkProxy.VzLPRClient_RSet_Video_Param(IntPtr handle, ref VZ_LPRC_R_VIDEO_PARAM param) => _VzLPRClient_RSet_Video_Param.Invoke(handle, ref param);
        int IVzClientSdkProxy.VzLPRClient_SaveRealData(IntPtr handle, string sFileName) => _VzLPRClient_SaveRealData.Invoke(handle, sFileName);
        int IVzClientSdkProxy.VzLPRClient_SerialSend(IntPtr nSerialHandle, IntPtr pData, int uSizeData) => _VzLPRClient_SerialSend.Invoke(nSerialHandle, pData, uSizeData);
        IntPtr IVzClientSdkProxy.VzLPRClient_SerialStart(IntPtr handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData) => _VzLPRClient_SerialStart.Invoke(handle, nSerialPort, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SerialStop(IntPtr nSerialHandle) => _VzLPRClient_SerialStop.Invoke(nSerialHandle);
        int IVzClientSdkProxy.VzLPRClient_SetAlgResultParam(IntPtr handle, int reco_dis) => _VzLPRClient_SetAlgResultParam.Invoke(handle, reco_dis);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerDeviceReg(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg) => _VzLPRClient_SetCenterServerDeviceReg.Invoke(handle, ref pCenterServerDeviceReg);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerGionin(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin) => _VzLPRClient_SetCenterServerGionin.Invoke(handle, ref pCenterServerGionin);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerHostBak(IntPtr handle, string pCenterServerHostBak) => _VzLPRClient_SetCenterServerHostBak.Invoke(handle, pCenterServerHostBak);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerNet(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet) => _VzLPRClient_SetCenterServerNet.Invoke(handle, ref pCenterServerNet);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerPlate(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate) => _VzLPRClient_SetCenterServerPlate.Invoke(handle, ref pCenterServerPlate);
        int IVzClientSdkProxy.VzLPRClient_SetCenterServerSerial(IntPtr handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial) => _VzLPRClient_SetCenterServerSerial.Invoke(handle, ref pCenterServerSerial);
        int IVzClientSdkProxy.VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData) => _VZLPRClient_SetCommonNotifyCallBack.Invoke(func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetDateTime(IntPtr handle, IntPtr IntpDTInfo) => _VzLPRClient_SetDateTime.Invoke(handle, IntpDTInfo);
        int IVzClientSdkProxy.VzLPRClient_SetDenoise(IntPtr handle, int mode, int strength) => _VzLPRClient_SetDenoise.Invoke(handle, mode, strength);
        int IVzClientSdkProxy.VzLPRClient_SetDrawMode(IntPtr handle, ref VZ_LPRC_DRAWMODE pDrawMode) => _VzLPRClient_SetDrawMode.Invoke(handle, ref pDrawMode);
        int IVzClientSdkProxy.VzLPRClient_SetEncrypt(IntPtr handle, IntPtr pCurrentKey, uint nEncyptId) => _VzLPRClient_SetEncrypt.Invoke(handle, pCurrentKey, nEncyptId);
        int IVzClientSdkProxy.VzLPRClient_SetFlip(IntPtr handle, int flip) => _VzLPRClient_SetFlip.Invoke(handle, flip);
        int IVzClientSdkProxy.VzLPRClient_SetFrequency(IntPtr handle, int frequency) => _VzLPRClient_SetFrequency.Invoke(handle, frequency);
        int IVzClientSdkProxy.VzLPRClient_SetGPIORecvCallBack(IntPtr handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData) => _VzLPRClient_SetGPIORecvCallBack.Invoke(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetIOOutput(IntPtr handle, int uChnId, int nOutput) => _VzLPRClient_SetIOOutput.Invoke(handle, uChnId, nOutput);
        int IVzClientSdkProxy.VzLPRClient_SetIOOutputAuto(IntPtr handle, int uChnId, int nDuration) => _VzLPRClient_SetIOOutputAuto.Invoke(handle, uChnId, nDuration);
        int IVzClientSdkProxy.VzLPRClient_SetIsOutputRealTimeResult(IntPtr handle, bool bOutput) => _VzLPRClient_SetIsOutputRealTimeResult.Invoke(handle, bOutput);
        int IVzClientSdkProxy.VzLPRClient_SetIsShowPlateRect(IntPtr handle, int bShow) => _VzLPRClient_SetIsShowPlateRect.Invoke(handle, bShow);
        int IVzClientSdkProxy.VzLPRClient_SetLEDLightControlMode(IntPtr handle, VZ_LED_CTRL eCtrl) => _VzLPRClient_SetLEDLightControlMode.Invoke(handle, eCtrl);
        int IVzClientSdkProxy.VzLPRClient_SetLEDLightLevel(IntPtr handle, int nLevel) => _VzLPRClient_SetLEDLightLevel.Invoke(handle, nLevel);
        int IVzClientSdkProxy.VzLPRClient_SetOfflineCheck(IntPtr handle) => _VzLPRClient_SetOfflineCheck.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_SetOsdParam(IntPtr handle, IntPtr pParam) => _VzLPRClient_SetOsdParam.Invoke(handle, pParam);
        int IVzClientSdkProxy.VzLPRClient_SetOutputConfig(IntPtr handle, ref VZ_OutputConfigInfo pOutputConfigInfo) => _VzLPRClient_SetOutputConfig.Invoke(handle, ref pOutputConfigInfo);
        int IVzClientSdkProxy.VzLPRClient_SetPlateInfoCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage) => _VzLPRClient_SetPlateInfoCallBack.Invoke(handle, func, pUserData, bEnableImage);
        int IVzClientSdkProxy.VzLPRClient_SetPlateRecType(IntPtr handle, uint uBitsRecType) => _VzLPRClient_SetPlateRecType.Invoke(handle, uBitsRecType);
        int IVzClientSdkProxy.VzLPRClient_SetPlateTrigType(IntPtr handle, uint uBitsTrigType) => _VzLPRClient_SetPlateTrigType.Invoke(handle, uBitsTrigType);
        int IVzClientSdkProxy.VzLPRClient_SetQueryPlateCallBack(IntPtr handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData) => _VzLPRClient_SetQueryPlateCallBack.Invoke(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetRequestTalkCallBack(IntPtr handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData) => _VzLPRClient_SetRequestTalkCallBack.Invoke(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetSerialParameter(IntPtr handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter) => _VzLPRClient_SetSerialParameter.Invoke(handle, nSerialPort, ref pParameter);
        int IVzClientSdkProxy.VzLPRClient_SetShutter(IntPtr handle, int shutter) => _VzLPRClient_SetShutter.Invoke(handle, shutter);
        int IVzClientSdkProxy.VzLPRClient_SetTriggerDelay(IntPtr handle, int nDelay) => _VzLPRClient_SetTriggerDelay.Invoke(handle, nDelay);
        int IVzClientSdkProxy.VzLPRClient_Setup() => _VzLPRClient_Setup.Invoke();
        int IVzClientSdkProxy.VzLPRClient_SetVideoCBR(IntPtr handle, int rateval) => _VzLPRClient_SetVideoCBR.Invoke(handle, rateval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoCompressMode(IntPtr handle, int modeval) => _VzLPRClient_SetVideoCompressMode.Invoke(handle, modeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoEncodeType(IntPtr handle, int cmd) => _VzLPRClient_SetVideoEncodeType.Invoke(handle, cmd);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameCallBack(IntPtr handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData) => _VzLPRClient_SetVideoFrameCallBack.Invoke(handle, pFunc, pUserData);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameRate(IntPtr handle, int Rateval) => _VzLPRClient_SetVideoFrameRate.Invoke(handle, Rateval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameSizeIndex(IntPtr handle, int sizeval) => _VzLPRClient_SetVideoFrameSizeIndex.Invoke(handle, sizeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoFrameSizeIndexEx(IntPtr handle, int sizeval) => _VzLPRClient_SetVideoFrameSizeIndexEx.Invoke(handle, sizeval);
        int IVzClientSdkProxy.VzLPRClient_SetVideoPara(IntPtr handle, int brt, int cst, int sat, int hue) => _VzLPRClient_SetVideoPara.Invoke(handle, brt, cst, sat, hue);
        int IVzClientSdkProxy.VzLPRClient_SetVideoVBR(IntPtr handle, int levelval) => _VzLPRClient_SetVideoVBR.Invoke(handle, levelval);
        int IVzClientSdkProxy.VzLPRClient_SetVirtualLoop(IntPtr handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops) => _VzLPRClient_SetVirtualLoop.Invoke(handle, ref pVirtualLoops);
        int IVzClientSdkProxy.VzLPRClient_SetWLCheckMethod(IntPtr handle, int nType) => _VzLPRClient_SetWLCheckMethod.Invoke(handle, nType);
        int IVzClientSdkProxy.VzLPRClient_SetWLFuzzy(IntPtr handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC) => _VzLPRClient_SetWLFuzzy.Invoke(handle, nFuzzyType, nFuzzyLen, bFuzzyCC);
        int IVzClientSdkProxy.VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData) => _VZLPRClient_StartFindDeviceEx.Invoke(func, pUserData);
        IntPtr IVzClientSdkProxy.VzLPRClient_StartRealPlay(IntPtr handle, IntPtr hWnd) => _VzLPRClient_StartRealPlay.Invoke(handle, hWnd);
        int IVzClientSdkProxy.VzLPRClient_StartRealPlayDecData(IntPtr handle) => _VzLPRClient_StartRealPlayDecData.Invoke(handle);
        IntPtr IVzClientSdkProxy.VzLPRClient_StartRealPlayFrameCallBack(IntPtr handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData) => _VzLPRClient_StartRealPlayFrameCallBack.Invoke(handle, hWnd, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_StartRecordAudio(IntPtr handle, string file_path) => _VzLPRClient_StartRecordAudio.Invoke(handle, file_path);
        int IVzClientSdkProxy.VzLPRClient_StartTalk(IntPtr handle, int client_win_size) => _VzLPRClient_StartTalk.Invoke(handle, client_win_size);
        int IVzClientSdkProxy.VZLPRClient_StopFindDevice() => _VZLPRClient_StopFindDevice.Invoke();
        int IVzClientSdkProxy.VzLPRClient_StopRealPlay(IntPtr hRealHandle) => _VzLPRClient_StopRealPlay.Invoke(hRealHandle);
        int IVzClientSdkProxy.VzLPRClient_StopRealPlayDecData(IntPtr handle) => _VzLPRClient_StopRealPlayDecData.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_StopRecordAudio(IntPtr handle) => _VzLPRClient_StopRecordAudio.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_StopSaveRealData(IntPtr handle) => _VzLPRClient_StopSaveRealData.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_StopTalk(IntPtr handle) => _VzLPRClient_StopTalk.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_UpdateNetworkParam(uint sh, uint sl, string strNewIP, string strGateway, string strNetmask) => _VzLPRClient_UpdateNetworkParam.Invoke(sh, sl, strNewIP, strGateway, strNetmask);
        int IVzClientSdkProxy.VzLPRClient_WhiteListClearCustomersAndVehicles(IntPtr handle) => _VzLPRClient_WhiteListClearCustomersAndVehicles.Invoke(handle);
        int IVzClientSdkProxy.VzLPRClient_WhiteListDeleteVehicle(IntPtr handle, string strPlateID) => _VzLPRClient_WhiteListDeleteVehicle.Invoke(handle, strPlateID);
        int IVzClientSdkProxy.VzLPRClient_WhiteListGetRowCount(IntPtr handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere) => _VzLPRClient_WhiteListGetRowCount.Invoke(handle, ref count, ref pSearchWhere);
        int IVzClientSdkProxy.VzLPRClient_WhiteListGetVehicleCount(IntPtr handle, ref uint pCount, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere) => _VzLPRClient_WhiteListGetVehicleCount.Invoke(handle, ref pCount, ref pSearchWhere);
        int IVzClientSdkProxy.VzLPRClient_WhiteListImportRows(IntPtr handle, uint rowcount, ref VZ_LPR_WLIST_ROW pRowDatas, ref VZ_LPR_WLIST_IMPORT_RESULT pResults) => _VzLPRClient_WhiteListImportRows.Invoke(handle, rowcount, ref pRowDatas, ref pResults);
        int IVzClientSdkProxy.VzLPRClient_WhiteListLoadVehicle(IntPtr handle, ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition) => _VzLPRClient_WhiteListLoadVehicle.Invoke(handle, ref pLoadCondition);
        int IVzClientSdkProxy.VzLPRClient_WhiteListSetQueryCallBack(IntPtr handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData) => _VzLPRClient_WhiteListSetQueryCallBack.Invoke(handle, func, pUserData);
        int IVzClientSdkProxy.VzLPRClient_WhiteListUpdateVehicleByID(IntPtr handle, ref VZ_LPR_WLIST_VEHICLE pVehicle) => _VzLPRClient_WhiteListUpdateVehicleByID.Invoke(handle, ref pVehicle);
        int IVzClientSdkProxy.VzLPRClient_WriteUserData(IntPtr handle, IntPtr pUserData, uint uSizeData) => _VzLPRClient_WriteUserData.Invoke(handle, pUserData, uSizeData);
        #endregion 显示实现
    }
}
