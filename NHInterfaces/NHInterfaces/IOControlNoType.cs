using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Linq;
using System.Text;

namespace System.Data.NHInterfaces
{
    /// <summary>
    /// IO控制器通路类型
    /// 32路/16路/8路/4路/2路/1路
    /// </summary>
    [EDisplay("IO控制器类型Max32")]
    public enum IOControlNoType : ulong
    {
        /// <summary>
        /// 未知
        /// </summary>
        [EDisplay("未知")]
        Unknown = 0,
        /// <summary>
        /// DO-1
        /// </summary>
        [EDisplay("DO-1")]
        DO_1 = 1U,
        /// <summary>
        /// DO-2
        /// </summary>
        [EDisplay("DO-2")]
        DO_2 = 2U,
        /// <summary>
        /// DO-3
        /// </summary>
        [EDisplay("DO-3")]
        DO_3 = 4U,
        /// <summary>
        /// DO-4
        /// </summary>
        [EDisplay("DO-4")]
        DO_4 = 8U,
        /// <summary>
        /// DO-5
        /// </summary>
        [EDisplay("DO-5")]
        DO_5 = 16U,
        /// <summary>
        /// DO-6
        /// </summary>
        [EDisplay("DO-6")]
        DO_6 = 32U,
        /// <summary>
        /// DO-7
        /// </summary>
        [EDisplay("DO-7")]
        DO_7 = 64U,
        /// <summary>
        /// DO-8
        /// </summary>
        [EDisplay("DO-8")]
        DO_8 = 128U,
        /// <summary>
        /// DO-9
        /// </summary>
        [EDisplay("DO-9")]
        DO_9 = 256U,
        /// <summary>
        /// DO-10
        /// </summary>
        [EDisplay("DO-10")]
        DO_10 = 512U,
        /// <summary>
        /// DO-11
        /// </summary>
        [EDisplay("DO-11")]
        DO_11 = 1024U,
        /// <summary>
        /// DO-12
        /// </summary>
        [EDisplay("DO-12")]
        DO_12 = 2048U,
        /// <summary>
        /// DO-13
        /// </summary>
        [EDisplay("DO-13")]
        DO_13 = 4096U,
        /// <summary>
        /// DO-14
        /// </summary>
        [EDisplay("DO-14")]
        DO_14 = 8192U,
        /// <summary>
        /// DO-15
        /// </summary>
        [EDisplay("DO-15")]
        DO_15 = 16384U,
        /// <summary>
        /// DO-16
        /// </summary>
        [EDisplay("DO-16")]
        DO_16 = 32768U,
        /// <summary>
        /// DO-17
        /// </summary>
        [EDisplay("DO-17")]
        DO_17 = 65536U,
        /// <summary>
        /// DO-18
        /// </summary>
        [EDisplay("DO-18")]
        DO_18 = 131072U,
        /// <summary>
        /// DO-19
        /// </summary>
        [EDisplay("DO-19")]
        DO_19 = 262144U,
        /// <summary>
        /// DO-20
        /// </summary>
        [EDisplay("DO-20")]
        DO_20 = 524288U,
        /// <summary>
        /// DO-21
        /// </summary>
        [EDisplay("DO-21")]
        DO_21 = 1048576U,
        /// <summary>
        /// DO-22
        /// </summary>
        [EDisplay("DO-22")]
        DO_22 = 2097152U,
        /// <summary>
        /// DO-23
        /// </summary>
        [EDisplay("DO-23")]
        DO_23 = 4194304U,
        /// <summary>
        /// DO-24
        /// </summary>
        [EDisplay("DO-24")]
        DO_24 = 8388608U,
        /// <summary>
        /// DO-25
        /// </summary>
        [EDisplay("DO-25")]
        DO_25 = 16777216U,
        /// <summary>
        /// DO-26
        /// </summary>
        [EDisplay("DO-26")]
        DO_26 = 33554432U,
        /// <summary>
        /// DO-27
        /// </summary>
        [EDisplay("DO-27")]
        DO_27 = 67108864U,
        /// <summary>
        /// DO-28
        /// </summary>
        [EDisplay("DO-28")]
        DO_28 = 134217728U,
        /// <summary>
        /// DO-29
        /// </summary>
        [EDisplay("DO-29")]
        DO_29 = 268435456U,
        /// <summary>
        /// DO-30
        /// </summary>
        [EDisplay("DO-30")]
        DO_30 = 536870912U,
        /// <summary>
        /// DO-31
        /// </summary>
        [EDisplay("DO-31")]
        DO_31 = 1073741824U,
        /// <summary>
        /// DO-32
        /// </summary>
        [EDisplay("DO-32")]
        DO_32 = 2147483648U,

        /// <summary>
        /// DI-1
        /// </summary>
        [EDisplay("DI-1")]
        DI_1 = 4294967296U,
        /// <summary>
        /// DI-2
        /// </summary>
        [EDisplay("DI-2")]
        DI_2 = 8589934592U,
        /// <summary>
        /// DI-3
        /// </summary>
        [EDisplay("DI-3")]
        DI_3 = 17179869184U,
        /// <summary>
        /// DI-4
        /// </summary>
        [EDisplay("DI-4")]
        DI_4 = 34359738368U,
        /// <summary>
        /// DI-5
        /// </summary>
        [EDisplay("DI-5")]
        DI_5 = 68719476736U,
        /// <summary>
        /// DI-6
        /// </summary>
        [EDisplay("DI-6")]
        DI_6 = 137438953472U,
        /// <summary>
        /// DI-7
        /// </summary>
        [EDisplay("DI-7")]
        DI_7 = 274877906944U,
        /// <summary>
        /// DI-8
        /// </summary>
        [EDisplay("DI-8")]
        DI_8 = 549755813888U,
        /// <summary>
        /// DI-9
        /// </summary>
        [EDisplay("DI-9")]
        DI_9 = 1099511627776U,
        /// <summary>
        /// DI-10
        /// </summary>
        [EDisplay("DI-10")]
        DI_10 = 2199023255552U,
        /// <summary>
        /// DI-11
        /// </summary>
        [EDisplay("DI-11")]
        DI_11 = 4398046511104U,
        /// <summary>
        /// DI-12
        /// </summary>
        [EDisplay("DI-12")]
        DI_12 = 8796093022208U,
        /// <summary>
        /// DI-13
        /// </summary>
        [EDisplay("DI-13")]
        DI_13 = 17592186044416U,
        /// <summary>
        /// DI-14
        /// </summary>
        [EDisplay("DI-14")]
        DI_14 = 35184372088832U,
        /// <summary>
        /// DI-15
        /// </summary>
        [EDisplay("DI-15")]
        DI_15 = 70368744177664U,
        /// <summary>
        /// DI-16
        /// </summary>
        [EDisplay("DI-16")]
        DI_16 = 140737488355328U,
        /// <summary>
        /// DI-17
        /// </summary>
        [EDisplay("DI-17")]
        DI_17 = 281474976710656U,
        /// <summary>
        /// DI-18
        /// </summary>
        [EDisplay("DI-18")]
        DI_18 = 562949953421312U,
        /// <summary>
        /// DI-19
        /// </summary>
        [EDisplay("DI-19")]
        DI_19 = 1125899906842624U,
        /// <summary>
        /// DI-20
        /// </summary>
        [EDisplay("DI-20")]
        DI_20 = 2251799813685248U,
        /// <summary>
        /// DI-21
        /// </summary>
        [EDisplay("DI-21")]
        DI_21 = 4503599627370496U,
        /// <summary>
        /// DI-22
        /// </summary>
        [EDisplay("DI-22")]
        DI_22 = 9007199254740992U,
        /// <summary>
        /// DI-23
        /// </summary>
        [EDisplay("DI-23")]
        DI_23 = 18014398509481984U,
        /// <summary>
        /// DI-24
        /// </summary>
        [EDisplay("DI-24")]
        DI_24 = 36028797018963968U,
        /// <summary>
        /// DI-25
        /// </summary>
        [EDisplay("DI-25")]
        DI_25 = 72057594037927936U,
        /// <summary>
        /// DI-26
        /// </summary>
        [EDisplay("DI-26")]
        DI_26 = 144115188075855872U,
        /// <summary>
        /// DI-27
        /// </summary>
        [EDisplay("DI-27")]
        DI_27 = 288230376151711744U,
        /// <summary>
        /// DI-28
        /// </summary>
        [EDisplay("DI-28")]
        DI_28 = 576460752303423488U,
        /// <summary>
        /// DI-29
        /// </summary>
        [EDisplay("DI-29")]
        DI_29 = 1152921504606846976U,
        /// <summary>
        /// DI-30
        /// </summary>
        [EDisplay("DI-30")]
        DI_30 = 2305843009213693952U,
        /// <summary>
        /// DI-31
        /// </summary>
        [EDisplay("DI-31")]
        DI_31 = 4611686018427387904U,
        /// <summary>
        /// DI-32
        /// </summary>
        [EDisplay("DI-32")]
        DI_32 = 9223372036854775808U,
    }
}
