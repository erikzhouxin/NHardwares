namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVPersonMonitorOptResCode
     * @brief 人脸布控操作结果错误码
     * @attention 仅VMS支持
     */
    public enum NETDEV_PERSON_MONITOR_OPT_RES_CODE_E
    {
        NETDEV_PERSON_MONITOR_CODE_INIT_DETECT_FAIL = 11702,           /* 初始化检测失败 */
        NETDEV_PERSON_MONITOR_CODE_FACE_DETECT_FAIL = 11703,           /* 人脸检测失败 */
        NETDEV_PERSON_MONITOR_CODE_IMAGE_NOT_FIND_FACE = 11704,           /* 图片未检测到人脸 */
        NETDEV_PERSON_MONITOR_CODE_JPEG_PARSE_FAIL = 11705,           /* jpeg照片解码失败 */
        NETDEV_PERSON_MONITOR_CODE_IMAGE_MASS_NOT_ENOUGH = 11706,           /* 人脸图片质量分数不满足 */
        NETDEV_PERSON_MONITOR_CODE_IMAGE_ZOOM_FAIL = 11707,           /* 图片缩放失败 */
        NETDEV_PERSON_MONITOR_CODE_NOT_START_SMART = 11708,           /* 未启用智能 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_TOO_SMALL = 11709,           /* 导入图片过小 */
        NETDEV_PERSON_MONITOR_CODE_CREATE_FACE_LIB_FAIL = 11710,           /* 创建人脸库失败 */
        NETDEV_PERSON_MONITOR_CODE_CREATE_MONITOR_FAIL = 11711,           /* 创建布控任务失败 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_TOO_LARGE = 11714,           /* 导入图片过大 */
        NETDEV_PERSON_MONITOR_CODE_RESOLUTION_TOO_LARGE = 11715,           /* 导入图片分辨率超过1920*1080 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_NON_EXISTENT = 11716,           /* 导入图片不存在 */
        NETDEV_PERSON_MONITOR_CODE_FACE_ELEMENTS_LIMIT = 11717,           /* 人脸元素个数已达到上限 */
        NETDEV_PERSON_MONITOR_CODE_INTELLECT_MODULE_MISMATCH = 11718,           /* 智能棒算法模型不匹配 */
        NETDEV_PERSON_MONITOR_CODE_DOCUMENT_ID_INVLID = 11719,           /* 人脸导入库成员证件号非法 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_FORMAT_ERROR = 11720,           /* 人脸导入库成员图片格式错误 */
        NETDEV_PERSON_MONITOR_CODE_MONITOR_DEVICE_LIMIT = 11721,           /* 通道布控已达设备能力上限 */
        NETDEV_PERSON_MONITOR_CODE_FACE_LIBRARY_LOCKED = 11722,           /* 其它客户端正在进行操作人脸库 */
        NETDEV_PERSON_MONITOR_CODE_FACE_LIBRARY_UPDATING = 11723,           /* 人脸库文件正在更新中 */
        NETDEV_PERSON_MONITOR_CODE_JSON_DESERIALIZE_FAIL = 11724,           /* Json反序列化失败 */
        NETDEV_PERSON_MONITOR_CODE_BASE64_DECODE_FAIL = 11725,           /* Base64解码失败 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_SIZE_MISMATCH = 11726            /* 人脸照片，编码后的大小和实际接收到的长度不一致 */
    }

}
