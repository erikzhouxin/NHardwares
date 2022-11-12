namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVCoatTexture
     * @brief 上衣纹理
     * @attention 无 None
     */
    public enum NETDEV_CLOTHES_TEXTURE_E
    {
        NETDEV_CLOTHES_TEXTURE_NO_PATTERNS = 1,         /* 无花纹 */
        NETDEV_CLOTHES_TEXTURE_EXIST_PATTERNS = 2,         /* 有花纹 */
        NETDEV_CLOTHES_TEXTURE_UNKNOW = 255,       /* 未知 */
        NETDEV_CLOTHES_TEXTURE_INVALIDP = 0xFFFF     /* 无效值 */
    }

}
