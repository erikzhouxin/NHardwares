namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVPlateType
    * @brief 车牌类型 枚举定义 plate type Enumeration definition
    * @attention 无 None
    */
    public enum NETDEV_PLATE_TYPE_E
    {
        NETDEV_PLATE_TYPE_BIG_CAR_E = 0,                     /* 大型汽车号牌 */
        NETDEV_PLATE_TYPE_MINI_CAR_E = 1,                    /* 小型汽车号牌 */
        NETDEV_PLATE_TYPE_EMBASSY_CAR_E = 2,                 /* 使馆汽车号牌 */
        NETDEV_PLATE_TYPE_CONSULATE_CAR_E = 3,               /* 领馆汽车号牌 */
        NETDEV_PLATE_TYPE_OVERSEAS_CAR_E = 4,                /* 境外汽车号牌 */
        NETDEV_PLATE_TYPE_FOREIGN_CAR_E = 5,                 /* 外籍汽车号牌 */
        NETDEV_PLATE_TYPE_COMMON_MOTORBIKE_E = 6,            /* 普通摩托车号牌 */
        NETDEV_PLATE_TYPE_HANDINESS_MOTORBIKE_E = 7,         /* 轻便摩托车号牌 */
        NETDEV_PLATE_TYPE_EMBASSY_MOTORBIKE_E = 8,           /* 使馆摩托车号牌 */
        NETDEV_PLATE_TYPE_CONSULATE_MOTORBIKE_E = 9,         /* 领馆摩托车号牌 */
        NETDEV_PLATE_TYPE_OVERSEAS_MOTORBIKE_E = 10,         /* 境外摩托车号牌 */
        NETDEV_PLATE_TYPE_FOREIGN_MOTORBIKE_E = 11,          /* 外籍摩托车号牌 */
        NETDEV_PLATE_TYPE_LOW_SPEED_CAR_E = 12,              /* 低速车号牌 */
        NETDEV_PLATE_TYPE_TRACTOR_E = 13,                    /* 拖拉机号牌 */
        NETDEV_PLATE_TYPE_TRAILER_E = 14,                    /* 挂车号牌 */
        NETDEV_PLATE_TYPE_COACH_CAR_E = 15,                  /* 教练汽车号牌 */
        NETDEV_PLATE_TYPE_COACH_MOTORBIKE_E = 16,            /* 教练摩托车号牌 */
        NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_CAR_E = 17,        /* 临时入境汽车号牌 */
        NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_MOTORBIKE_E = 18,  /* 临时入境摩托车号牌 */
        NETDEV_PLATE_TYPE_TEMPORARY_DRIVING_E = 19,          /* 临时行驶车号牌 */
        NETDEV_PLATE_TYPE_POLICE_CAR_E = 20,                 /* 警用汽车号牌 */
        NETDEV_PLATE_TYPE_POLICE_MOTORBIKE_E = 21,           /* 警用摩托车号牌 */
        NETDEV_PLATE_TYPE_AGRICULTURAL_E = 22,               /* 原农机号牌 */
        NETDEV_PLATE_TYPE_HONGKONG_ENTRY_EXIT_E = 23,        /* 香港入出境号牌 */
        NETDEV_PLATE_TYPE_MACAO_ENTRY_EXIT_E = 24,           /* 澳门入出境号牌 */
        NETDEV_PLATE_TYPE_ARMED_POLICE_E = 25,               /* 武警号牌 */
        NETDEV_PLATE_TYPE_ARMY_E = 26,                       /* 军队号牌 */

        NETDEV_PLATE_TYPE_OTHER_E = 99,                      /* 其他号牌 */


        NETDEV_PLATE_TYPE_INVALID = 0xFF                     /* 无效值  Invalid value */
    }

}
