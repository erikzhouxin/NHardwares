using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人体特征识别结果结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_HUMAN_FEATURE
    {
        public byte byAgeGroup;    //年龄段,参见 HUMAN_AGE_GROUP_ENUM
        public byte bySex;         //性别, 0-表示“未知”（算法不支持）,1 – 男 , 2 – 女, 0xff-算法支持，但是没有识别出来
        public byte byEyeGlass;    //是否戴眼镜 0-表示“未知”（算法不支持）,1 – 不戴, 2 – 戴,0xff-算法支持，但是没有识别出来
                                   //抓拍图片人脸年龄的使用方式，如byAge为15,byAgeDeviation为1,表示，实际人脸图片年龄的为14-16之间
        public byte byAge;//年龄 0-表示“未知”（算法不支持）,0xff-算法支持，但是没有识别出来
        public byte byAgeDeviation;//年龄误差值
        public byte byEthnic;   //字段预留,暂不开放
        public byte byMask;       //是否戴口罩 0-表示“未知”（算法不支持）,1 – 不戴, 2 –戴普通眼镜, 3 –戴墨镜,0xff-算法支持，但是没有识别出来
        public byte bySmile;      //是否微笑 0-表示“未知”（算法不支持）,1 – 不微笑, 2 – 微笑, 0xff-算法支持，但是没有识别出来
        public byte byFaceExpression;    /*表情,参见FACE_EXPRESSION_GROUP_ENUM*/
        public byte byBeard;  //胡子, 0-不支持，1-没有胡子，2-有胡子，0xff-unknow表示未知,算法支持未检出
        public byte byRes2;
        public byte byHat;   //帽子, 0-不支持,1-不戴帽子,2-戴帽子,0xff-unknow表示未知,算法支持未检出
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
