namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVFaceMemberIDType
     * @brief 人脸成员证件类型
     * @attention 无 None
     */
    public enum NETDEV_FACE_MEMBER_ID_TYPE_E
    {
        NETDEV_FACE_MEMBER_ID_TYPE_ID_CARD = 0,               /* 身份证 */
        NETDEV_FACE_MEMBER_ID_TYPE_IC_CARD = 1,               /* IC卡 */
        NETDEV_FACE_MEMBER_ID_TYPE_PASSPORT = 2,               /* 护照 */
        NETDEV_FACE_MEMBER_ID_TYPE_DRIVING = 3,               /* 驾照 */
        NETDEV_FACE_MEMBER_ID_TYPE_OTHER = 99,              /* 其他 */

        NETDEV_FACE_MEMBER_ID_TYPE_INVALID = 0xFF             /* 无效值 */
    }

}
