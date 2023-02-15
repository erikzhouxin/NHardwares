using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 控制器类型
    /// </summary>
    public class BxDualControlType
    {
        // 控制器类型
        public const ushort BX_5AT = 0x0051;
        public const ushort BX_5A0 = 0x0151;
        public const ushort BX_5A1 = 0x0251;
        public const ushort BX_5A2 = 0x0351;
        public const ushort BX_5A3 = 0x0451;
        public const ushort BX_5A4 = 0x0551;
        public const ushort BX_5A1_WIFI = 0x0651;
        public const ushort BX_5A2_WIFI = 0x0751;
        public const ushort BX_5A4_WIFI = 0x0851;
        public const ushort BX_5A = 0x0951;
        public const ushort BX_5A2_RF = 0x1351;
        public const ushort BX_5A4_RF = 0x1551;
        public const ushort BX_5AT_WIFI = 0x1651;
        public const ushort BX_5AL = 0x1851;

        public const ushort AX_AT = 0x2051;
        public const ushort AX_A0 = 0x2151;
        
        public const ushort BX_5MT = 0x0552;
        public const ushort BX_5M1 = 0x0052;
        public const ushort BX_5M1X = 0x0152;
        public const ushort BX_5M2 = 0x0252;
        public const ushort BX_5M3 = 0x0352;
        public const ushort BX_5M4 = 0x0452;

        public const ushort BX_5E1 = 0x0154;
        public const ushort BX_5E2 = 0x0254;
        public const ushort BX_5E3 = 0x0354;

        public const ushort BX_5UT = 0x0055;
        public const ushort BX_5U0 = 0x0155;
        public const ushort BX_5U1 = 0x0255;
        public const ushort BX_5U2 = 0x0355;
        public const ushort BX_5U3 = 0x0455;
        public const ushort BX_5U4 = 0x0555;
        public const ushort BX_5U5 = 0x0655;
        public const ushort BX_5U = 0x0755;
        public const ushort BX_5UL = 0x0855;
        
        public const ushort AX_UL = 0x2055;
        public const ushort AX_UT = 0x2155;
        public const ushort AX_U0 = 0x2255;
        public const ushort AX_U1 = 0x2355;
        public const ushort AX_U2 = 0x2455;

        public const ushort BX_5Q0 = 0x0056;
        public const ushort BX_5Q1 = 0x0156;
        public const ushort BX_5Q2 = 0x0256;
        public const ushort BX_5Q0P = 0x1056;
        public const ushort BX_5Q1P = 0x1156;
        public const ushort BX_5Q2P = 0x1256;
        public const ushort BX_5QL = 0x1356;

        public const ushort BX_5QS1 = 0x0157;
        public const ushort BX_5QS2 = 0x0257;
        public const ushort BX_5QS = 0x0357;
        public const ushort BX_5QS1P = 0x1157;
        public const ushort BX_5QS2P = 0x1257;
        public const ushort BX_5QSP = 0x1357;

        public const ushort BX_6M0 = 0x0062;
        public const ushort BX_6M1 = 0x0162;
        public const ushort BX_6M2 = 0x0262;
        public const ushort BX_6M3 = 0x0362;
        public const ushort BX_6M = 0x0462;
        public const ushort BX_6MT = 0x0562;
        public const ushort BX_6M2JT = 0x3262;
        public const ushort BX_6M0P = 0x0062;
        public const ushort BX_6M1P = 0x0162;
        public const ushort BX_6M2P = 0x4262;
        public const ushort BX_6M3P = 0x4362;
        public const ushort BX_6M4P = 0x4462;

        public const ushort BX_6M0_YY = 0x1062;
        public const ushort BX_6M1_YY = 0x1162;
        public const ushort BX_6M2_YY = 0x1262;
        public const ushort BX_6M3_YY = 0x1362;
        public const ushort BX_6M_YY = 0x1462;

        public const ushort BX_6X1 = 0x2162;
        public const ushort BX_6X2 = 0x2262;
        public const ushort BX_6X3 = 0x2362;

        public const ushort BX_6U0 = 0x0063;
        public const ushort BX_6U1 = 0x0163;
        public const ushort BX_6U2 = 0x0263;
        public const ushort BX_6U3 = 0x0363;
        public const ushort BX_6U = 0x0463;
        public const ushort BX_6UT = 0x0563;

        public const ushort BX_6U0_YY = 0x1063;
        public const ushort BX_6U1_YY = 0x1163;
        public const ushort BX_6U2_YY = 0x1263;
        public const ushort BX_6U3_YY = 0x1363;
        public const ushort BX_6U_YY = 0x1463;

        public const ushort BX_6A0 = 0x2063;
        public const ushort BX_6A1 = 0x2163;
        public const ushort BX_6A2 = 0x2263;
        public const ushort BX_6A3 = 0x2363;
        public const ushort BX_6A = 0x2463;

        public const ushort BX_6A0_YY = 0x3063;
        public const ushort BX_6A1_YY = 0x3163;
        public const ushort BX_6A2_YY = 0x3263;
        public const ushort BX_6A3_YY = 0x3363;
        public const ushort BX_6A_YY = 0x3463;

        public const ushort BX_6A0_G = 0x4063;
        public const ushort BX_6A1_G = 0x4163;
        public const ushort BX_6A2_G = 0x4263;
        public const ushort BX_6A3_G = 0x4363;
        public const ushort BX_6AT_G = 0x4463;

        public const ushort BX_6S1 = 0x5163;
        public const ushort BX_6S2 = 0x5263;
        public const ushort BX_6S3 = 0x5363;

        public const ushort BX_6W0 = 0x0064;
        public const ushort BX_6W1 = 0x0164;
        public const ushort BX_6W2 = 0x0264;
        public const ushort BX_6W3 = 0x0364;
        public const ushort BX_6W = 0x0464;
        public const ushort BX_6WT = 0x0564;

        public const ushort BX_6E1 = 0x0174;
        public const ushort BX_6E2 = 0x0274;
        public const ushort BX_6E3 = 0x0374;
        public const ushort BX_6E1X = 0x0474;
        public const ushort BX_6E2X = 0x0574;
        public const ushort BX_6E1XP = 0x0674;
        public const ushort BX_6E2XP = 0x0774;
        public const ushort BX_6E3P = 0x0974;

        public const ushort BX_6Q0 = 0x0066;
        public const ushort BX_6Q1 = 0x0166;
        public const ushort BX_6Q2 = 0x0266;
        public const ushort BX_6Q2L = 0x0466;
        public const ushort BX_6Q3 = 0x0366;
        public const ushort BX_6Q3L = 0x0566;
        /// <summary>
        /// 控制器类型列表
        /// </summary>
        public static ushort[] ControlTypes = new ushort[111] { BX_5AT, BX_5A0, BX_5A1, BX_5A2, BX_5A3, BX_5A4, BX_5A1_WIFI, BX_5A2_WIFI,BX_5A4_WIFI,BX_5A,
                                        BX_5A2_RF,BX_5A4_RF,BX_5AT_WIFI,BX_5AL,AX_AT,AX_A0,BX_5MT,BX_5M1,BX_5M1X,BX_5M2,BX_5M3,BX_5M4,
                                        BX_5E1,BX_5E2,BX_5E3,BX_5UT,BX_5U0,BX_5U1,BX_5U2,BX_5U3,BX_5U4,BX_5U5,BX_5U,BX_5UL,
                                        AX_UL,AX_UT,AX_U0,AX_U1,AX_U2,BX_5Q0,BX_5Q1,BX_5Q2,BX_5Q0P,BX_5Q1P,BX_5Q2P,BX_5QL,BX_5QS1,
                                        BX_5QS2,BX_5QS,BX_5QS1P,BX_5QS2P,BX_5QSP,
                                        BX_6M0,BX_6M1,BX_6M2,BX_6M3,BX_6M,BX_6MT,BX_6M0_YY,BX_6M1_YY,BX_6M2_YY,BX_6M3_YY,BX_6M_YY,BX_6X1,BX_6X2,BX_6X3,
                                        BX_6U0,BX_6U1,BX_6U2,BX_6U3,BX_6U,BX_6UT,BX_6U0_YY,BX_6U1_YY,BX_6U2_YY,BX_6U3_YY,BX_6U_YY,
                                        BX_6A0,BX_6A1,BX_6A2,BX_6A3,BX_6A,BX_6A0_YY,BX_6A1_YY,BX_6A2_YY,BX_6A3_YY,BX_6A_YY,BX_6A0_G,BX_6A1_G,BX_6A2_G,BX_6A3_G,BX_6AT_G,
                                        BX_6S1,BX_6S2,BX_6S3,BX_6W0,BX_6W1,BX_6W2,BX_6W3,BX_6W,BX_6WT,
                                        BX_6E1,BX_6E2,BX_6E3,BX_6E1X,BX_6E2X,BX_6Q1,BX_6Q2,BX_6Q2L,BX_6Q3,BX_6Q3L};
    }
}
