namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVPersonResultCode
    * @brief 人脸处理结果状态码
    * @attention 无 None
    */
    public enum NETDEV_PERSON_RESULT_CODE_E
    {
        NETDEV_PERSON_CODE_SUCCEED = 0,               /* 成功 */
        NETDEV_PERSON_CODE_COMMON_FAIL = 1,               /* 通用执行失败 */
        NETDEV_PERSON_CODE_SENDING = 2,               /* 下发中 */
        NETDEV_PERSON_CODE_DEV_NOT_SUPPORT = 4,               /* 设备不支持 */
        NETDEV_PERSON_CODE_ARGORITHM_INIT_FAIL = 1000,            /* 算法初始化失败 */
        NETDEV_PERSON_CODE_FACE_DETECT_FAIL = 1001,            /* 人脸检测失败 */
        NETDEV_PERSON_CODE_PICTURE_NO_FACE = 1002,            /* 图片未检测到人脸 */
        NETDEV_PERSON_CODE_JPEG_DECODE_FAIL = 1003,            /* jpeg照片解码失败 */
        NETDEV_PERSON_CODE_PICTURE_QUALITY_LOW = 1004,            /* 图片质量分数不满足 */
        NETDEV_PERSON_CODE_PICTURE_ZOOM_FAIL = 1005,            /* 图片缩放失败 */
        NETDEV_PERSON_CODE_INTELLECT_DISABLE = 1006,            /* 未启用智能 */
        NETDEV_PERSON_CODE_PICTURE_TOO_SMALL = 1007,            /* 导入图片过小 */
        NETDEV_PERSON_CODE_PICTURE_TOO_LARGE = 1008,            /* 导入图片过大 */
        NETDEV_PERSON_CODE_RESOLUTION_TOO_LARGE = 1009,            /* 导入图片分辨率超过1920*1080 */
        NETDEV_PERSON_CODE_PICTURE_NON_EXISTENT = 1010,            /* 导入图片不存在 */
        NETDEV_PERSON_CODE_FACE_ELEMENTS_LIMIT = 1011,            /* 人脸元素个数已达到上限 */
        NETDEV_PERSON_CODE_INTELLECT_MODULE_MISMATCH = 1012,            /* 智能棒算法模型不匹配 */
        NETDEV_PERSON_CODE_DOCUMENT_ID_INVLID = 1013,            /* 人脸导入库成员证件号非法 */
        NETDEV_PERSON_CODE_PICTURE_FORMAT_ERROR = 1014,            /* 人脸导入库成员图片格式错误 */
        NETDEV_PERSON_CODE_MONITOR_DEVICE_LIMIT = 1015,            /* 通道布控已达设备能力上限 */
        NETDEV_PERSON_CODE_FACE_LIBRARY_LOCKED = 1016,            /* 其它客户端正在进行操作人脸库 */
        NETDEV_PERSON_CODE_FACE_LIBRARY_UPDATING = 1017,            /* 人脸库文件正在更新中 */
        NETDEV_PERSON_CODE_JSON_DESERIALIZE_FAIL = 1018,            /* Json反序列化失败 */
        NETDEV_PERSON_CODE_BASE64_DECODE_FAIL = 1019,            /* Base64解码失败 */
        NETDEV_PERSON_CODE_PICTURE_SIZE_MISMATCH = 1020,            /* 人脸照片，编码后的大小和实际接收到的长度不一致 */
        NETDEV_PERSON_CODE_DEV_PROTOCOL_DIFFER = 1021,            /* 布控任务只能选择相同图片接入协议的设备 */
        NETDEV_PERSON_CODE_INVALID = 0xff             /* 无效值 */
    }

}
