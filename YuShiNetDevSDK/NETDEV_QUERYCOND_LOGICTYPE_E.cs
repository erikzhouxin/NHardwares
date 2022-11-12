namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVQueryCondLogic
     * @brief 查询条件逻辑类型
     * @attention 无 None
     */
    public enum NETDEV_QUERYCOND_LOGICTYPE_E
    {
        NETDEV_QUERYCOND_LOGIC_EQUAL = 0,                /* 查询条件逻辑类型：等于 */
        NETDEV_QUERYCOND_LOGIC_GREATER = 1,                /* 查询条件逻辑类型：大于 */
        NETDEV_QUERYCOND_LOGIC_LESS = 2,                /* 查询条件逻辑类型：小于 */
        NETDEV_QUERYCOND_LOGIC_NO_LESS = 3,                /* 查询条件逻辑类型：不小于 */
        NETDEV_QUERYCOND_LOGIC_NO_GREATER = 4,                /* 查询条件逻辑类型：不大于 */
        NETDEV_QUERYCOND_LOGIC_NO_EQUAL = 5,                /* 查询条件逻辑类型：不等于 */
        NETDEV_QUERYCOND_LOGIC_DIM_QUERY = 6,                /* 查询条件逻辑类型：模糊查询 */
        NETDEV_QUERYCOND_LOGIC_CONTAIN = 7,                /* 查询条件逻辑类型：包括 */
        NETDEV_QUERYCOND_LOGIC_ASC_ORDER = 8,                /* 查询条件逻辑类型：升序 */
        NETDEV_QUERYCOND_LOGIC_DESC_ORDER = 9                 /* 查询条件逻辑类型：降序 */
    }

}
