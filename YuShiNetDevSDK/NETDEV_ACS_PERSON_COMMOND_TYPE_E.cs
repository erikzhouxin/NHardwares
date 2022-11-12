namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVACSPersonCommondType
     * @brief 门禁人员管理命令(添加和删除使用批量接口)
     * @attention
     */
    public enum NETDEV_ACS_PERSON_COMMOND_TYPE_E
    {
        NETDEV_ACS_PERSON_COMMOND_TYPE_GET = 0,                /* 获取 */
        NETDEV_ACS_PERSON_COMMOND_TYPE_MOD = 1,                /* 修改 */

        NETDEV_ACS_PERSON_COMMOND_TYPE_INVALID = 0xFF              /* 无效值 */
    }

}
