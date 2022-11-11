using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct NETDEV_PIC_DATA_S
    * @brief 交通类对外数据结构，最多包含8张照片 Struct of vehicle data
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PIC_DATA_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_TRAFFIC_PIC_MAX_NUM)]
        public IntPtr[] apcData;                 /* 数据指针 Pointer to photo data */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_TRAFFIC_PIC_MAX_NUM)]
        public Int32[] aulDataLen;               /* 数据长度 Photo data length */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_TRAFFIC_PIC_MAX_NUM)]
        public Int32[] aulPicType;              /* 照片类型,参考枚举#NETDEV_IMAGE_VEHICLE,Photo type See:IMOS_MW_IMAGE_VEHICLE */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)(ItsNetDevSdk.NETDEV_TRAFFIC_PIC_MAX_NUM * ItsNetDevSdk.NETDEV_UNIVIEW_MAX_TIME_LEN))]
        public byte[] acPassTime;               /* 经过时间, Time of passing */

        public Int32 ulPicNumber;               /* 照片张数, Number of photos (up to 8)*/
        /* 应用类型:对应相关产品 0-车辆卡口 1-电警 2-人数统计 3-泛卡口 4-违章球 */
        /* Application type: The corresponding product. 0-vehicle checkpoint 1-e-police 2-people counting 3-general checkpoint 4-violation detection dome camera */
        public Int32 lApplicationType;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_DEV_ID_MAX_LEN)]
        public byte[] szCamID;                  /*设备编号:采集设备统一编号或卡口相机编码, 不可为空  
                                                     * Device ID: unified ID of collection device or checkpoint camera ID */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_DEV_ID_MAX_LEN)]
        public byte[] szTollgateID;             /*卡口编号:产生该信息的卡口代码  
                                                     * Checkpoint ID: ID of the checkpoint where the information is generated.*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_TOLLGATE_NAME_MAX_LEN)]
        public byte[] szTollgateName;           /*卡口名称:可选字段Checkpoint name */

        public Int32 ulCameraType;             /* 相机类型 0 全景 1特性 Camera type 0-Panoramic camera, 1-Lane camera */
        public Int32 ulRecordID;               /* 车辆信息编号:由1开始自动增长(转换成字符串要求不超过16字节 
                                                    * Vehicle record ID: increases automatically from the beginning (must not exceed xxx bytes after being converted into a character string) */


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_UNIVIEW_MAX_TIME_LEN)]
        public byte[] szPassTime;              /* 经过时间:YYYYMMDDHHMMSS, 时间按24小时制 
                                                    * Pass-through time, YYYYMMDDHHMMSS, in xxx-hour format.*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_PLACE_NAME_MAX_LEN)]
        public byte[] szPlaceName;             /* 地点名称 Location name */

        public Int32 lLaneID;                  /* 车道编号:从1开始,车辆行驶方向最左车道为1,由左向右顺序编号
                                                    * Lane ID, which starts from xx, and the far left lane in the vehicle’s driving direction is the number xx lane. Lanes are numbered in sequence from left to right.*/
        public Int32 lLaneType;                /* 车道类型:0-机动车道, 1-非机动车道 
                                                    * Lane type: 0-Motor vehicle lane, 1-Non-motor vehicle lane*/
        /* 方向编号:1-东向西 2-西向东 3-南向北 4-北向南  5-东南向西北 6-西北向东南 7-东北向西南 8-西南向东北 */
        /* Direction ID: 1-East to west 2-West to east 3-South to north 4-North to south 5-Southeast to northwest 6-Northwest to southeast 7-Northeast to southwest 8-Southwest to northeast*/
        public Int32 lDirection;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_DIRECTION_NAME_MAX_LEN)]
        public byte[] szDirectionName;         /*方向名称:可选字段 Direction name: optional field */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_CAR_PLATE_MAX_LEN)]
        public byte[] szCarPlate;              /* 号牌号码:不能自动识别的用"-"表示
                                                    * Vehicle plate number, represented by “-” if the number cannot be recognized automatically*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)4)]
        public Int32[] aulLPRRect;                                       /* 车牌坐标 XL=a[0],YL=a[1], XR=a[2],YR=a[3]
                                                                              * Plate coordinates XL=a[0], YL=a[1],  XR=a[2], YR=a[3] */
        /*号牌种类（按GA24.7编码）:1-大型汽车 2-小型汽车 3-使馆汽车 4-领馆汽车 5-境外汽车 6-外籍汽车 7-两、三轮摩托车号牌 8-轻便摩托车
          9-使馆摩托车 10-领馆摩托车 11-境外摩托车 12-外籍摩托车 13-农用运输车 14-拖拉机 15-挂车 16-教练汽车 17-教练摩托车 18-试验汽车
          19-试验摩托车 20-临时入境汽车 21-临时入境摩托车 22-临时行驶车 23-警用汽车 24-警用摩托 25-原农机号牌 26-香港入出境车 27-澳门入出境车 
          28-中型车 31-武警号牌 32-军队号牌 33-行人 34-非机动车 51-大型新能源车牌 52-小型新能源车牌 99-其它 */
        public Int32 lPlateType;                                          /*号牌种类:按GA24.7编码*/

        /*0-白色 1-黄色 2-蓝色 3-黑色 4-其他 5-绿色，农用车 6-红色 7-黄绿双色 8-渐变绿色 */
        public Int32 lPlateColor;                                        /*号牌颜色, LPR currently unavailable */
        public Int32 lPlateNumber;                                       /*号牌数量, LPR currently unavailable*/

        /*0-车头和车尾号牌号码不一致 1-车头和车尾号牌号码完全一致 2-车头号牌号码无法自动识别 3-车尾号牌号码无法自动识别 4-车头和车尾号牌号码均无法自动识别 */
        public Int32 lPlateCoincide;                                     /*号牌一致, LPR currently unavailable*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_CAR_PLATE_MAX_LEN)]
        public byte[] szRearVehiclePlateID;                              /*尾部号牌号码:被查控车辆车尾号牌号码，允许车辆尾部号牌号码不全。不能自动识别的用"-"表示, LPR currently unavailable*/

        public Int32 lRearPlateColor;                                    /*尾部号牌颜色, LPR currently unavailable*/
        public Int32 lRearPlateType;                                     /*尾部号牌种类, LPR currently unavailable*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)4)]
        public Int32[] aulVehicleXY;                                     /*车辆坐标:XL=a[0], YL=a[1], XR=a[2], YR=a[3]
                                                                              * Vehicle coordinates XL=a[0], YL=a[1], XR=a[2], YR=a[3]*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_CAR_VEHICLE_BRAND_LEN)]
        public byte[] szVehicleBrand;                                    /*车辆厂牌编码，详见文档 考虑到字节对齐定义长度为4，实际使用长度为2  
                                                                              * LPR currently unavailable*/
        /* 0-未知，1-小型车 2-中型车 3-大型车 4-其它 5-行人 6-二轮车 7-三轮车 8-摩托车 9-拖拉机 10-农用货车 11-轿车 12-SUV 13-面包车 14-小货车
           15-中巴车 16-大客车 17-大货车 18-皮卡车 19-MPV商务车 20-非机动车 */
        public Int32 lVehicleBody;                                       /*车辆外型编码,  LPR currently unavailable*/
        public Int32 lVehicleType;                                       /*车辆类型, LPR currently unavailable*/
        public Int32 lVehicleLength;                                     /*车外廓长(以厘米为单位), LPR currently unavailable*/
        public Int32 lVehicleColorDept;                                  /*车身颜色深浅:0-未知，1-浅，2-深, LPR currently unavailable*/
        public byte cVehicleColor;                                       /* 车身颜色, LPR currently unavailable*/


        public byte ucPlateScore;              /* 此次识别中，整牌的置信度，100最大, Confidence of the whole plate in the current recognition. Max: 100 */
        public byte ucRearPlateScore;          /* 尾部号码置信度，100最大, Confidence of the rear plate number. Max: 100 */
        public byte ucPicType;                 /* 0:实时照片，1:历史照片, 0: real-time photo 1: historical photo */
        public Int32 lIdentifyStatus;          /* 识别状态:0－识别成功 1－不成功 2－不完整(!)  3-表示需要平台识别, Recognition status:   0-success, 1-failure, 2-incomplete(!), 3-needs recognition by the platform*/
        public Int32 lIdentifyTime;            /* 识别时间, 单位毫秒, Recognition time. Unit: ms.*/

        /*（由于一幅图片中会有多个行人，采用按位定义方式，该颜色对 应的位为1表示该图片中有该衣着颜色，bit16为1表示衣着颜色未知，此时其它 比特位
（应为0）值忽略）：bit1-bit16：红色 橙色 黄色 绿色 青色 蓝色 紫色 粉色 白色 棕色 黑色 灰色 保留 保留 保留 未知 */
        public Int32 lDressColor;              /* 行人衣着颜色(!), LPR currently unavailable*/
        public Int32 lDealTag;                 /* 处理标记:0-初始状态未校对 1-已校对和保存 2-无效信息 3-已处理和保存(!), LPR currently unavailable*/


        public Int32 lVehicleSpeed;            /*车辆速度: 单位km/h, -1-无测速功能, LPR currently unavailable*/
        public Int32 lLimitedSpeed;            /*执法限速: 车辆限速, 单位km/h, LPR currently unavailable*/
        public Int32 lMarkedSpeed;             /*标识限速, LPR currently unavailable*/

        /*0-正常 1-嫌疑 100-套牌 101-假牌 102-无牌 103-拍照遮挡 104-拍照污损 按GA408.1编码：1301-逆行 1302-不按交通信号灯通行 4602-在高速公路上逆行
1603-机动车行驶超过规定时速50等*/
        public Int32 lDriveStatus;             /*行驶状态:0-正常 1-嫌疑或按GA408.1编码, LPR currently unavailable*/


        public Int32 lRedLightTime;                                  /*红灯时间, LPR currently unavailable*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_UNIVIEW_MAX_TIME_LEN)]
        public byte[] szRedLightStartTime;  /*红灯开始时间:YYYYMMDDHHMMSS, 精确到毫秒, 时间按24小时制, LPR currently unavailable*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_UNIVIEW_MAX_TIME_LEN)]
        public byte[] szRedLightEndTime;    /*红灯结束时间:YYYYMMDDHHMMSS, 精确到毫秒, 时间按24小时制, LPR currently unavailable*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_PECCANCYTYPE_CODE_MAX_NUM + 4)]
        public byte[] szDriveStatus;        /*行驶状态:0-正常 1-嫌疑或按GA408.1编码, 支持字符串，为了兼容不删除lDriveStatus, LPR currently unavailable*/

        public Int32 lTriggerType;          /*抓拍类型 参考NETDEV_CAPTURE_TYPE_E, Capture type. See #NETDEV_CAPTURE_TYPE_E */
        public Int32 lParkStatus;           /*车位状态信息*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_8 + ItsNetDevSdk.NETDEV_LEN_4)]
        public byte[] cReserved1;            /*保留字段1 后续扩展用 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] cReserved2;            /*保留字段1 后续扩展用 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] cReserved3;            /*保留字段1 后续扩展用 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] cReserved4;            /*保留字段1 后续扩展用 */

    };

}
