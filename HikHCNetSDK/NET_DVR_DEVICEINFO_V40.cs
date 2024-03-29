﻿using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_DVR_DEVICEINFO_V40
    {
        public NET_DVR_DEVICEINFO_V30 struDeviceV30;
        public byte bySupportLock;        //设备支持锁定功能，该字段由SDK根据设备返回值来赋值的。bySupportLock为1时，dwSurplusLockTime和byRetryLoginTime有效
        public byte byRetryLoginTime;       //剩余可尝试登陆的次数，用户名，密码错误时，此参数有效
        public byte byPasswordLevel;      //admin密码安全等级0-无效，1-默认密码，2-有效密码,3-风险较高的密码。当用户的密码为出厂默认密码（12345）或者风险较高的密码时，上层客户端需要提示用户更改密码。      
        public byte byProxyType;//代理类型，0-不使用代理, 1-使用socks5代理, 2-使用EHome代理
        public uint dwSurplusLockTime;  //剩余时间，单位秒，用户锁定时，此参数有效
        public byte byCharEncodeType;     //字符编码类型（SDK所有接口返回的字符串编码类型，透传接口除外）：0- 无字符编码信息(老设备)，1- GB2312(简体中文)，2- GBK，3- BIG5(繁体中文)，4- Shift_JIS(日文)，5- EUC-KR(韩文)，6- UTF-8，7- ISO8859-1，8- ISO8859-2，9- ISO8859-3，…，依次类推，21- ISO8859-15(西欧) 
        public byte bySupportDev5;//支持v50版本的设备参数获取，设备名称和设备类型名称长度扩展为64字节
        public byte bySupport;  //能力集扩展，位与结果：0- 不支持，1- 支持
                                // bySupport & 0x1:  保留
                                // bySupport & 0x2:  0-不支持变化上报 1-支持变化上报
        public byte byLoginMode; //登录模式 0-Private登录 1-ISAPI登录
        public int dwOEMCode;
        public int iResidualValidity;   //该用户密码剩余有效天数，单位：天，返回负值，表示密码已经超期使用，例如“-3表示密码已经超期使用3天”
        public byte byResidualValidity; // iResidualValidity字段是否有效，0-无效，1-有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 243, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
