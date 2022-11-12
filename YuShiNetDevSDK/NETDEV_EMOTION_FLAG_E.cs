namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVEmotionFlag
     * @brief 情绪情况
     * @attention 
     */
    public enum NETDEV_EMOTION_FLAG_E
    {
        NETDEV_EMOTION_FLAG_UNKNOW = 0,                 /* 未知 */
        NETDEV_EMOTION_FLAG_ANGER = 1,                 /* 生气的 */
        NETDEV_EMOTION_FLAG_CALM = 2,                 /* 平静的 */
        NETDEV_EMOTION_FLAG_CONFUSED = 3,                 /* 迷茫的 */
        NETDEV_EMOTION_FLAG_ABHORRENT = 4,                 /* 厌恶的 */
        NETDEV_EMOTION_FLAG_HAPPY = 5,                 /* 高兴的 */
        NETDEV_EMOTION_FLAG_SAD = 6,                 /* 悲伤的 */
        NETDEV_EMOTION_FLAG_AFRAID = 7,                 /* 害怕的 */
        NETDEV_EMOTION_FLAG_AMAZED = 8,                 /* 吃惊的 */
        NETDEV_EMOTION_FLAG_SQUINT = 9,                 /* 眯眼的 */
        NETDEV_EMOTION_FLAG_SCREAM = 10,                /* 尖叫的 */
        NETDEV_EMOTION_FLAG_OTHER = 11,                /* 其他 */
        NETDEV_EMOTION_FLAG_INVALID = 0xFF               /* 无效值 */
    }

}
