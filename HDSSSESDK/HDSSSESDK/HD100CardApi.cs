using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HDSSSESDK
{
    /// <summary>
    /// HDSSSE的32位ICC/PICC等卡接口
    /// 不支持64位
    /// </summary>
    internal class HD100CardApi : IHD100CardApi
    {
        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="dev_Name"></param>
        /// <returns></returns>
        public int ICC_Reader_Open(StringBuilder dev_Name) => NativeMethod.ICC_Reader_Open(dev_Name);
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int ICC_Reader_Close(int ReaderHandle) => NativeMethod.ICC_Reader_Close(ReaderHandle);
        /// <summary>
        /// 读磁条卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="track"></param>
        /// <param name="rlen"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Rcard(int ReaderHandle, byte ctime, int track, byte[] rlen, StringBuilder data) => NativeMethod.Rcard(ReaderHandle, ctime, track, rlen, data);
        /// <summary>
        /// 扫码
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="QRCodeInfo"></param>
        /// <returns></returns>
        public int ICC_Reader_ScanCode(int ReaderHandle, byte ctime, StringBuilder QRCodeInfo) => NativeMethod.ICC_Reader_ScanCode(ReaderHandle, ctime, QRCodeInfo);
        /// <summary>
        /// 蜂鸣
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int ICC_PosBeep(int ReaderHandle, byte time) => NativeMethod.ICC_PosBeep(ReaderHandle, time);
        /// <summary>
        /// 设置读typeA
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int PICC_Reader_SetTypeA(int ReaderHandle) => NativeMethod.PICC_Reader_SetTypeA(ReaderHandle);
        /// <summary>
        /// 选择卡片，41为typea,M1 42为typeb,TypeB卡片需先上电后选卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="cardtype"></param>
        /// <returns></returns>
        public int PICC_Reader_Select(int ReaderHandle, byte cardtype) => NativeMethod.PICC_Reader_Select(ReaderHandle, cardtype);
        /// <summary>
        /// typea 和 M1 请求卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int PICC_Reader_Request(int ReaderHandle) => NativeMethod.PICC_Reader_Request(ReaderHandle);
        /// <summary>
        /// 防碰撞 typea M1卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int PICC_Reader_anticoll(int ReaderHandle, byte[] uid) => NativeMethod.PICC_Reader_anticoll(ReaderHandle, uid);
        /// <summary>
        /// 注意：输入的是12位的密钥，例如12个f，但是password必须是6个字节的密钥，需要用StrToHex函数处理。
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Mode"></param>
        /// <param name="SecNr"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public int PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr, byte[] PassWord) => NativeMethod.PICC_Reader_Authentication_Pass(ReaderHandle, Mode, SecNr, PassWord);
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data) => NativeMethod.PICC_Reader_Read(ReaderHandle, Addr, Data);
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data) => NativeMethod.PICC_Reader_Write(ReaderHandle, Addr, Data);
        /// <summary>
        /// 将字符命令流转为16进制流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="len"></param>
        /// <param name="HexOut"></param>
        /// <returns></returns>
        public int StrToHex(StringBuilder strIn, int len, Byte[] HexOut) => NativeMethod.StrToHex(strIn, len, HexOut);
        /// <summary>
        /// 将16进制流命令转为字符流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="inLen"></param>
        /// <param name="strOut"></param>
        /// <returns></returns>
        public int HexToStr(Byte[] strIn, int inLen, StringBuilder strOut) => NativeMethod.HexToStr(strIn, inLen, strOut);
        /// <summary>
        /// 接触CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public int ICC_Reader_pre_PowerOn(int ReaderHandle, byte SLOT, byte[] Response) => NativeMethod.ICC_Reader_pre_PowerOn(ReaderHandle, SLOT, Response);
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        public int ICC_Reader_Application(int ReaderHandle, byte SLOT, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU) => NativeMethod.ICC_Reader_Application(ReaderHandle, SLOT, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
        /// <summary>
        /// 非接CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public int PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response) => NativeMethod.PICC_Reader_PowerOnTypeA(ReaderHandle, Response);
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        public int PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU) => NativeMethod.PICC_Reader_Application(ReaderHandle, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
        /// <summary>
        /// 社保卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="sbkh"></param>
        /// <param name="xm"></param>
        /// <param name="xb"></param>
        /// <param name="mz"></param>
        /// <param name="csrq"></param>
        /// <param name="shbzhm"></param>
        /// <param name="fkrq"></param>
        /// <param name="kyxq"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public int PICC_Reader_SICARD(int ReaderHandle, StringBuilder sbkh, StringBuilder xm, StringBuilder xb, StringBuilder mz, StringBuilder csrq, StringBuilder shbzhm, StringBuilder fkrq, StringBuilder kyxq, StringBuilder err) => NativeMethod.PICC_Reader_SICARD(ReaderHandle, sbkh, xm, xb, mz, csrq, shbzhm, fkrq, kyxq, err);
        /// <summary>
        /// 银行卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="sn"></param>
        /// <param name="date"></param>
        /// <param name="kh"></param>
        /// <param name="kh_len"></param>
        /// <param name="iType"></param>
        /// <returns></returns>
        public int PICC_Reader_CardInfo(int ReaderHandle, byte[] sn, byte[] date, byte[] kh, byte[] kh_len, int iType) => NativeMethod.PICC_Reader_CardInfo(ReaderHandle, sn, date, kh, kh_len, iType);
        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="RHandle"></param>
        /// <param name="pBmpFile"></param>
        /// <param name="pName"></param>
        /// <param name="pSex"></param>
        /// <param name="pNation"></param>
        /// <param name="pBirth"></param>
        /// <param name="pAddress"></param>
        /// <param name="pCertNo"></param>
        /// <param name="pDepartment"></param>
        /// <param name="pEffectData"></param>
        /// <param name="pExpire"></param>
        /// <param name="pErrMsg"></param>
        /// <returns></returns>
        public int PICC_Reader_ReadIDMsg(int RHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg) => NativeMethod.PICC_Reader_ReadIDMsg(RHandle, pBmpFile, pName, pSex, pNation, pBirth, pAddress, pCertNo, pDepartment, pEffectData, pExpire, pErrMsg);
        /// <summary>
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int PICC_Reader_ID_ReadUID(int ReaderHandle, StringBuilder UID) => NativeMethod.PICC_Reader_ID_ReadUID(ReaderHandle, UID);
        /// <summary>
        /// 读身份证 
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public int PICC_Reader_ReadIDCard(int ReaderHandle, StringBuilder err) => NativeMethod.PICC_Reader_ReadIDCard(ReaderHandle, err);
        /// <summary>
        /// 获取证件类型
        /// </summary>
        /// <returns></returns>
        public int GetCardType() => NativeMethod.GetCardType();
        /// <summary>
        /// 姓名(类型为1时表示：外国人中文姓名)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetName(StringBuilder name) => NativeMethod.GetName(name);
        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public int GetSex(StringBuilder sex) => NativeMethod.GetSex(sex);
        /// <summary>
        /// 民族
        /// </summary>
        /// <param name="Nation"></param>
        /// <returns></returns>
        public int GetNation(StringBuilder Nation) => NativeMethod.GetNation(Nation);
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <param name="Birth"></param>
        /// <returns></returns>
        public int GetBirth(StringBuilder Birth) => NativeMethod.GetBirth(Birth);
        /// <summary>
        /// 住址
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public int GetAddress(StringBuilder Address) => NativeMethod.GetAddress(Address);
        /// <summary>
        /// 公民身份证号码(类型为1时表示：外国人居留证号码)
        /// </summary>
        /// <param name="CertNo"></param>
        /// <returns></returns>
        public int GetCertNo(StringBuilder CertNo) => NativeMethod.GetCertNo(CertNo);
        /// <summary>
        /// 签发机关
        /// </summary>
        /// <param name="Departemt"></param>
        /// <returns></returns>
        public int GetDepartemt(StringBuilder Departemt) => NativeMethod.GetDepartemt(Departemt);
        /// <summary>
        /// 有效起始日期
        /// </summary>
        /// <param name="EffectDate"></param>
        /// <returns></returns>
        public int GetEffectDate(StringBuilder EffectDate) => NativeMethod.GetEffectDate(EffectDate);
        /// <summary>
        /// 有效截止日期
        /// </summary>
        /// <param name="ExpireDate"></param>
        /// <returns></returns>
        public int GetExpireDate(StringBuilder ExpireDate) => NativeMethod.GetExpireDate(ExpireDate);
        /// <summary>
        /// 生成照片
        /// </summary>
        /// <param name="pBmpfilepath"></param>
        /// <returns></returns>
        public int GetBmpFile(StringBuilder pBmpfilepath) => NativeMethod.GetBmpFile(pBmpfilepath);
        /// <summary>
        /// 外国人英文姓名
        /// </summary>
        /// <param name="EnName"></param>
        /// <returns></returns>
        public int GetEnName(StringBuilder EnName) => NativeMethod.GetEnName(EnName);
        /// <summary>
        /// 外国人国籍代码 符合GB/T2659-2000规定
        /// </summary>
        /// <param name="NationalityCode"></param>
        /// <returns></returns>
        public int GetNationalityCode(StringBuilder NationalityCode) => NativeMethod.GetNationalityCode(NationalityCode);
        /// <summary>
        /// 港澳台通行证号码
        /// </summary>
        /// <param name="txzhm"></param>
        /// <returns></returns>
        public int GetTXZHM(StringBuilder txzhm) => NativeMethod.GetTXZHM(txzhm);
        /// <summary>
        /// 港澳台通行证签发次数
        /// </summary>
        /// <param name="txzqfcs"></param>
        /// <returns></returns>
        public int GetTXZQFCS(StringBuilder txzqfcs) => NativeMethod.GetTXZQFCS(txzqfcs);
        /// <summary>
        /// 寻卡15693
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_Inventory(int Rhandle, byte[] resp) => NativeMethod.PICC_Reader_Inventory(Rhandle, resp);
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_15693_Read(int Rhandle, byte blockAddr, byte[] resp) => NativeMethod.PICC_Reader_15693_Read(Rhandle, blockAddr, resp);
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_15693_Write(int Rhandle, byte blockAddr, byte[] data, byte[] resp) => NativeMethod.PICC_Reader_15693_Write(Rhandle, blockAddr, data, resp);
        /// <summary>
        /// AFI
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_AFI(int Rhandle, byte[] data, byte[] resp) => NativeMethod.PICC_Reader_AFI(Rhandle, data, resp);
        /// <summary>
        /// DSFID
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_DSFID(int Rhandle, byte[] data, byte[] resp) => NativeMethod.PICC_Reader_DSFID(Rhandle, data, resp);
        /// <summary>
        /// 卡片信息
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_SystemInfor(int Rhandle, byte[] resp) => NativeMethod.PICC_Reader_SystemInfor(Rhandle, resp);
        /// <summary>
        /// 锁块
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_LockDataBlock(int Rhandle, byte blockAddr, byte[] resp) => NativeMethod.PICC_Reader_LockDataBlock(Rhandle, blockAddr, resp);

        private class NativeMethod
        {
            /// <summary>
            /// 打开端口
            /// </summary>
            /// <param name="dev_Name"></param>
            /// <returns></returns>
            [DllImport(@"HDSSSE32.dll", EntryPoint = "ICC_Reader_Open")]
            public static extern int ICC_Reader_Open(StringBuilder dev_Name);
            /// <summary>
            /// 关闭端口
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "ICC_Reader_Close")]
            public static extern int ICC_Reader_Close(int ReaderHandle);
            /// <summary>
            /// 读磁条卡
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="ctime"></param>
            /// <param name="track"></param>
            /// <param name="rlen"></param>
            /// <param name="data"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "Rcard")]
            public static extern int Rcard(int ReaderHandle, byte ctime, int track, byte[] rlen, StringBuilder data);
            /// <summary>
            /// 扫码
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="ctime"></param>
            /// <param name="QRCodeInfo"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "ICC_Reader_ScanCode")]
            public static extern int ICC_Reader_ScanCode(int ReaderHandle, byte ctime, StringBuilder QRCodeInfo);
            /// <summary>
            /// 蜂鸣
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="time"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "ICC_PosBeep")]
            public static extern int ICC_PosBeep(int ReaderHandle, byte time);
            /// <summary>
            /// 设置读typeA
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_SetTypeA")]
            public static extern int PICC_Reader_SetTypeA(int ReaderHandle);
            /// <summary>
            /// 选择卡片，41为typea,M1 42为typeb,TypeB卡片需先上电后选卡
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="cardtype"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_Select")]
            public static extern int PICC_Reader_Select(int ReaderHandle, byte cardtype);
            /// <summary>
            /// typea 和 M1 请求卡片
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_Request")]
            public static extern int PICC_Reader_Request(int ReaderHandle);
            /// <summary>
            /// 防碰撞 typea M1卡片
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="uid"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_anticoll")]
            public static extern int PICC_Reader_anticoll(int ReaderHandle, byte[] uid);
            /// <summary>
            /// 注意：输入的是12位的密钥，例如12个f，但是password必须是6个字节的密钥，需要用StrToHex函数处理。
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="Mode"></param>
            /// <param name="SecNr"></param>
            /// <param name="PassWord"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_Authentication_Pass")]
            public static extern int PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr, byte[] PassWord);
            /// <summary>
            /// 读卡
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="Addr"></param>
            /// <param name="Data"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_Read")]
            public static extern int PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data);
            /// <summary>
            /// 写卡
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="Addr"></param>
            /// <param name="Data"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_Write")]
            public static extern int PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data);
            /// <summary>
            /// 将字符命令流转为16进制流
            /// </summary>
            /// <param name="strIn"></param>
            /// <param name="len"></param>
            /// <param name="HexOut"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "StrToHex")]
            public static extern int StrToHex(StringBuilder strIn, int len, Byte[] HexOut);
            /// <summary>
            /// 将16进制流命令转为字符流
            /// </summary>
            /// <param name="strIn"></param>
            /// <param name="inLen"></param>
            /// <param name="strOut"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "HexToStr")]
            public static extern int HexToStr(Byte[] strIn, int inLen, StringBuilder strOut);
            /// <summary>
            /// 接触CPU
            /// 上电 返回数据长度 失败小于0
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="SLOT"></param>
            /// <param name="Response"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "ICC_Reader_pre_PowerOn")]
            public static extern int ICC_Reader_pre_PowerOn(int ReaderHandle, byte SLOT, byte[] Response);
            /// <summary>
            /// type a/b执行apdu命令 返回数据长度 失败小于0
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="SLOT"></param>
            /// <param name="Lenth_of_Command_APDU"></param>
            /// <param name="Command_APDU"></param>
            /// <param name="Response_APDU"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "ICC_Reader_Application")]
            public static extern int ICC_Reader_Application(int ReaderHandle, byte SLOT, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU);
            /// <summary>
            /// 非接CPU
            /// 上电 返回数据长度 失败小于0
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="Response"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_PowerOnTypeA")]
            public static extern int PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response);
            /// <summary>
            /// type a/b执行apdu命令 返回数据长度 失败小于0
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="Lenth_of_Command_APDU"></param>
            /// <param name="Command_APDU"></param>
            /// <param name="Response_APDU"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_Application")]
            public static extern int PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU);
            /// <summary>
            /// 社保卡
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="sbkh"></param>
            /// <param name="xm"></param>
            /// <param name="xb"></param>
            /// <param name="mz"></param>
            /// <param name="csrq"></param>
            /// <param name="shbzhm"></param>
            /// <param name="fkrq"></param>
            /// <param name="kyxq"></param>
            /// <param name="err"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_SICARD")]
            public static extern int PICC_Reader_SICARD(int ReaderHandle, StringBuilder sbkh, StringBuilder xm, StringBuilder xb, StringBuilder mz, StringBuilder csrq, StringBuilder shbzhm, StringBuilder fkrq, StringBuilder kyxq, StringBuilder err);
            /// <summary>
            /// 银行卡
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="sn"></param>
            /// <param name="date"></param>
            /// <param name="kh"></param>
            /// <param name="kh_len"></param>
            /// <param name="iType"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_CardInfo")]
            public static extern int PICC_Reader_CardInfo(int ReaderHandle, byte[] sn, byte[] date, byte[] kh, byte[] kh_len, int iType);
            /// <summary>
            /// 身份证
            /// </summary>
            /// <param name="RHandle"></param>
            /// <param name="pBmpFile"></param>
            /// <param name="pName"></param>
            /// <param name="pSex"></param>
            /// <param name="pNation"></param>
            /// <param name="pBirth"></param>
            /// <param name="pAddress"></param>
            /// <param name="pCertNo"></param>
            /// <param name="pDepartment"></param>
            /// <param name="pEffectData"></param>
            /// <param name="pExpire"></param>
            /// <param name="pErrMsg"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_ReadIDMsg")]
            public static extern int PICC_Reader_ReadIDMsg(int RHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg);
            /// <summary>
            /// 上电 返回数据长度 失败小于0
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="UID"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_ID_ReadUID")]
            public static extern int PICC_Reader_ID_ReadUID(int ReaderHandle, StringBuilder UID);
            /// <summary>
            /// 读身份证 
            /// </summary>
            /// <param name="ReaderHandle"></param>
            /// <param name="err"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_ReadIDCard")]
            public static extern int PICC_Reader_ReadIDCard(int ReaderHandle, StringBuilder err);
            /// <summary>
            /// 获取证件类型
            /// </summary>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetCardType", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetCardType();
            /// <summary>
            /// 姓名(类型为1时表示：外国人中文姓名)
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetName", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetName(StringBuilder name);
            /// <summary>
            /// 性别
            /// </summary>
            /// <param name="sex"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetSex", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetSex(StringBuilder sex);
            /// <summary>
            /// 民族
            /// </summary>
            /// <param name="Nation"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetNation", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetNation(StringBuilder Nation);
            /// <summary>
            /// 出生日期
            /// </summary>
            /// <param name="Birth"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetBirth", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetBirth(StringBuilder Birth);
            /// <summary>
            /// 住址
            /// </summary>
            /// <param name="Address"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetAddress", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetAddress(StringBuilder Address);
            /// <summary>
            /// 公民身份证号码(类型为1时表示：外国人居留证号码)
            /// </summary>
            /// <param name="CertNo"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetCertNo", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetCertNo(StringBuilder CertNo);
            /// <summary>
            /// 签发机关
            /// </summary>
            /// <param name="Departemt"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetDepartemt", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetDepartemt(StringBuilder Departemt);
            /// <summary>
            /// 有效起始日期
            /// </summary>
            /// <param name="EffectDate"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetEffectDate", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetEffectDate(StringBuilder EffectDate);
            /// <summary>
            /// 有效截止日期
            /// </summary>
            /// <param name="ExpireDate"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetExpireDate", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetExpireDate(StringBuilder ExpireDate);
            /// <summary>
            /// 生成照片
            /// </summary>
            /// <param name="pBmpfilepath"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetBmpFile", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetBmpFile(StringBuilder pBmpfilepath);
            /// <summary>
            /// 外国人英文姓名
            /// </summary>
            /// <param name="EnName"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetEnName", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetEnName(StringBuilder EnName);
            /// <summary>
            /// 外国人国籍代码 符合GB/T2659-2000规定
            /// </summary>
            /// <param name="NationalityCode"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetNationalityCode", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetNationalityCode(StringBuilder NationalityCode);
            /// <summary>
            /// 港澳台通行证号码
            /// </summary>
            /// <param name="txzhm"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetTXZHM", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetTXZHM(StringBuilder txzhm);
            /// <summary>
            /// 港澳台通行证签发次数
            /// </summary>
            /// <param name="txzqfcs"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "GetTXZQFCS", CallingConvention = CallingConvention.StdCall)]
            public static extern int GetTXZQFCS(StringBuilder txzqfcs);
            /// <summary>
            /// 寻卡15693
            /// </summary>
            /// <param name="Rhandle"></param>
            /// <param name="resp"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_Inventory", CallingConvention = CallingConvention.StdCall)]
            public static extern int PICC_Reader_Inventory(int Rhandle, byte[] resp);
            /// <summary>
            /// 读卡
            /// </summary>
            /// <param name="Rhandle"></param>
            /// <param name="blockAddr"></param>
            /// <param name="resp"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_15693_Read", CallingConvention = CallingConvention.StdCall)]
            public static extern int PICC_Reader_15693_Read(int Rhandle, byte blockAddr, byte[] resp);
            /// <summary>
            /// 写卡
            /// </summary>
            /// <param name="Rhandle"></param>
            /// <param name="blockAddr"></param>
            /// <param name="data"></param>
            /// <param name="resp"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_15693_Write", CallingConvention = CallingConvention.StdCall)]
            public static extern int PICC_Reader_15693_Write(int Rhandle, byte blockAddr, byte[] data, byte[] resp);
            /// <summary>
            /// AFI
            /// </summary>
            /// <param name="Rhandle"></param>
            /// <param name="data"></param>
            /// <param name="resp"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_AFI", CallingConvention = CallingConvention.StdCall)]
            public static extern int PICC_Reader_AFI(int Rhandle, byte[] data, byte[] resp);
            /// <summary>
            /// DSFID
            /// </summary>
            /// <param name="Rhandle"></param>
            /// <param name="data"></param>
            /// <param name="resp"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_DSFID", CallingConvention = CallingConvention.StdCall)]
            public static extern int PICC_Reader_DSFID(int Rhandle, byte[] data, byte[] resp);
            /// <summary>
            /// 卡片信息
            /// </summary>
            /// <param name="Rhandle"></param>
            /// <param name="resp"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_SystemInfor", CallingConvention = CallingConvention.StdCall)]
            public static extern int PICC_Reader_SystemInfor(int Rhandle, byte[] resp);
            /// <summary>
            /// 锁块
            /// </summary>
            /// <param name="Rhandle"></param>
            /// <param name="blockAddr"></param>
            /// <param name="resp"></param>
            /// <returns></returns>
            [DllImport("HDSSSE32.dll", EntryPoint = "PICC_Reader_LockDataBlock", CallingConvention = CallingConvention.StdCall)]
            public static extern int PICC_Reader_LockDataBlock(int Rhandle, byte blockAddr, byte[] resp);
        }
    }
}
