using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceAttr
     * @brief 人脸属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ATTR_S
    {
        public UInt32 udwGender;                                     /* 性别 详见 NETDEV_GENDER_TYPE_E */
        public UInt32 udwAgeRange;                                   /* 年龄段 详见 NETDEV_AGE_RANGE_E */
        public UInt32 udwGlassFlag;                                  /* 是否戴眼镜标志 详见 NETDEV_GLASS_FLAG_E */
        public UInt32 udwGlassesStyle;                               /* 眼镜款式 详见 NETDEV_GLASSES_STYLE_E */
        public UInt32 udwMask;                                       /* 口罩 详见 NETDEV_MASK_FLAG_E */
        public float fTemperature;                                   /* 体温 单位：摄氏度 精度：小数点后2位 */
        public UInt32 udwEmotion;                                    /* 情绪情况，未检测时可选 参见 NETDEV_EMOTION_FLAG_E */
        public UInt32 udwSmile;                                      /* 是否微笑，未检测时可选 详见 NETDEV_SMILE_FLAG_E */
        public UInt32 udwAttractive;                                 /* 颜值，未检测时可选 数值范围[0~100] */
        public UInt32 udwSkinColor;                                  /* 肤色，未检测时可选 详见 NETDEV_SKINCOLOR_TYPE_E */
        public UInt32 udwBeard;                                      /* 胡子，未检测时可选 详见 NETDEV_BEARD_FLAG_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 112)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
