using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// 车牌类型枚举值
    /// </summary>
    public enum ICE_PLATETYPE_E
    {
        /// <summary>
        /// 不确定的
        /// </summary>
        ICE_PLATE_UNCERTAIN = 0,
        /// <summary>
        /// 蓝牌车
        /// </summary>
        ICE_PLATE_BLUE = 1,
        /// <summary>
        /// 单层黄牌车
        /// </summary>
        ICE_PLATE_YELLOW = 2,
        /// <summary>
        /// 警车
        /// </summary>
        ICE_PLATE_POL = 4,
        /// <summary>
        /// 武警车辆
        /// </summary>
        ICE_PLATE_WUJING = 8,
        /// <summary>
        /// 双层黄牌
        /// </summary>
        ICE_PLATE_DBYELLOW = 16,
        /// <summary>
        /// 摩托车
        /// </summary>
        ICE_PLATE_MOTOR = 32,
        /// <summary>
        /// 教练车
        /// </summary>
        ICE_PLATE_INSTRUCTIONCAR = 64,
        /// <summary>
        /// 军车
        /// </summary>
        ICE_PLATE_MILITARY = 128,
        /// <summary>
        /// 个性化车
        /// </summary>
        ICE_PLATE_PERSONAL = 256,
        /// <summary>
        /// 港澳车
        /// </summary>
        ICE_PLATE_GANGAO = 512,
        /// <summary>
        /// 使馆车
        /// </summary>
        ICE_PLATE_EMBASSY = 1024,
        /// <summary>
        /// 老式车牌(不反光)
        /// </summary>
        ICE_PLATE_NONGLARE = 2048,
        /// <summary>
        /// 2+2模型；
        /// </summary>
        ICE_PLATE_WHITE_TWOTWO = 0x10000001,
        /// <summary>
        /// 2+3模型；
        /// </summary>
        ICE_PLATE_WHITE_TWOTHR = 0x10000002,
        /// <summary>
        /// 3+2模型；
        /// </summary>
        ICE_PLATE_WHITE_THRTWO = 0x10000004,
        /// <summary>
        /// 3+3模型；
        /// </summary>
        ICE_PLATE_WHITE_THRTHR = 0x10000008,
        /// <summary>
        /// 3+4模型；
        /// </summary>
        ICE_PLATE_WHITE_THRFOR = 0x10000010,
        /// <summary>
        /// 3+2模型；
        /// </summary>
        ICE_PLATE_BLACK_THRTWO = 0x10000020,
        /// <summary>
        /// 2+3模型；
        /// </summary>
        ICE_PLATE_BLACK_TWOTHR = 0x10000040,
        /// <summary>
        /// 3+3模型；
        /// </summary>
        ICE_PLATE_BLACK_THRTHR = 0x10000080,
        /// <summary>
        /// 2+4模型；
        /// </summary>
        ICE_PLATE_BLACK_TWOFOR = 0x10000100,
        /// <summary>
        /// 4+2模型；
        /// </summary>
        ICE_PLATE_BLACK_FORTWO = 0x10000200,
        /// <summary>
        /// 3+4模型；
        /// </summary>
        ICE_PLATE_BLACK_THRFOR = 0x10000400,
    }
}
