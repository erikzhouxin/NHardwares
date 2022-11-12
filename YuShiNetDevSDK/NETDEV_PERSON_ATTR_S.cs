using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPersonAttr
     * @brief 人员属性
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_ATTR_S
    {
        public UInt32 udwGender;                                     /* 性别 详见 NETDEV_GENDER_TYPE_E */
        public UInt32 udwAgeRange;                                   /* 年龄段 详见 NETDEV_AGE_RANGE_E */
        public UInt32 udwSleevesLength;                              /* 上衣长短款式 详见 NETDEV_SLEEVES_LENGTH_E */
        public UInt32 udwCoatColor;                                  /* 上衣颜色 详见 NETDEV_CLOTHES_COLOR_E */
        public UInt32 udwTrousersLength;                             /* 下衣长短款式 详见 NETDEV_TROUSERS_STYLE_E */
        public UInt32 udwTrousersColor;                              /* 下衣颜色 详见 NETDEV_CLOTHES_COLOR_E */
        public UInt32 udwBodyToward;                                 /* 身体抓怕朝向 详见 NETDEV_BODY_TOWARD_E */
        public UInt32 udwShoesTubeLength;                            /* 鞋子长短款式 详见 NETDEV_SHOES_TUBE_LENGTH_E */
        public UInt32 udwHairLength;                                 /* 发型长短 详见 NETDEV_HAIR_LENGTH_E */
        public UInt32 udwBagFlag;                                    /* 是否携包标志 详见 NETDEV_BAG_FLAG_E */
        public float fTemperature;                                  /* 体温 单位：摄氏度 精度：小数点后2位 */
        public UInt32 udwMask;                                       /* 口罩 详见 NETDEV_PERSON_MASK_FLAG_E */
        public UInt32 udwCoatTexture;                                /* 上衣纹理 详见 NETDEV_CLOTHES_TEXTURE_E */
        public UInt32 udwMovingDirection;                            /* 人员运动方向 详见 NETDEV_MOVE_DIRECTION_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[] byRes;                                    /* 保留字段 详见 */
    }

}
