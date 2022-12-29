using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HDSSSESDK
{
    /// <summary>
    /// SDK代理接口
    /// </summary>
    public interface IHD100CardSdkProxy
    {
        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="dev_Name"></param>
        /// <returns></returns>
        int ICC_Reader_Open(StringBuilder dev_Name);
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        int ICC_Reader_Close(int ReaderHandle);
        /// <summary>
        /// 读磁条卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="track"></param>
        /// <param name="rlen"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        int Rcard(int ReaderHandle, byte ctime, int track, byte[] rlen, StringBuilder data);
        /// <summary>
        /// 扫码
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="QRCodeInfo"></param>
        /// <returns></returns>
        int ICC_Reader_ScanCode(int ReaderHandle, byte ctime, StringBuilder QRCodeInfo);
        /// <summary>
        /// 蜂鸣
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        int ICC_PosBeep(int ReaderHandle, byte time);
        /// <summary>
        /// 设置读typeA
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        int PICC_Reader_SetTypeA(int ReaderHandle);
        /// <summary>
        /// 选择卡片，41为typea,M1 42为typeb,TypeB卡片需先上电后选卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="cardtype"></param>
        /// <returns></returns>
        int PICC_Reader_Select(int ReaderHandle, byte cardtype);
        /// <summary>
        /// typea 和 M1 请求卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        int PICC_Reader_Request(int ReaderHandle);
        /// <summary>
        /// 防碰撞 typea M1卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        int PICC_Reader_anticoll(int ReaderHandle, byte[] uid);
        /// <summary>
        /// 注意：输入的是12位的密钥，例如12个f，但是password必须是6个字节的密钥，需要用StrToHex函数处理。
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Mode"></param>
        /// <param name="SecNr"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        int PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr, byte[] PassWord);
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        int PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data);
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        int PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data);
        /// <summary>
        /// 将字符命令流转为16进制流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="len"></param>
        /// <param name="HexOut"></param>
        /// <returns></returns>
        int StrToHex(StringBuilder strIn, int len, Byte[] HexOut);
        /// <summary>
        /// 将16进制流命令转为字符流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="inLen"></param>
        /// <param name="strOut"></param>
        /// <returns></returns>
        int HexToStr(Byte[] strIn, int inLen, StringBuilder strOut);
        /// <summary>
        /// 接触CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        int ICC_Reader_pre_PowerOn(int ReaderHandle, byte SLOT, byte[] Response);
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        int ICC_Reader_Application(int ReaderHandle, byte SLOT, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU);
        /// <summary>
        /// 非接CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        int PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response);
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        int PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU);
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
        int PICC_Reader_SICARD(int ReaderHandle, StringBuilder sbkh, StringBuilder xm, StringBuilder xb, StringBuilder mz, StringBuilder csrq, StringBuilder shbzhm, StringBuilder fkrq, StringBuilder kyxq, StringBuilder err);
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
        int PICC_Reader_CardInfo(int ReaderHandle, byte[] sn, byte[] date, byte[] kh, byte[] kh_len, int iType);
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
        int PICC_Reader_ReadIDMsg(int RHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg);
        /// <summary>
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        int PICC_Reader_ID_ReadUID(int ReaderHandle, StringBuilder UID);
        /// <summary>
        /// 读身份证 
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        int PICC_Reader_ReadIDCard(int ReaderHandle, StringBuilder err);
        /// <summary>
        /// 获取证件类型
        /// </summary>
        /// <returns></returns>
        int GetCardType();
        /// <summary>
        /// 姓名(类型为1时表示：外国人中文姓名)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetName(StringBuilder name);
        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        int GetSex(StringBuilder sex);
        /// <summary>
        /// 民族
        /// </summary>
        /// <param name="Nation"></param>
        /// <returns></returns>
        int GetNation(StringBuilder Nation);
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <param name="Birth"></param>
        /// <returns></returns>
        int GetBirth(StringBuilder Birth);
        /// <summary>
        /// 住址
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        int GetAddress(StringBuilder Address);
        /// <summary>
        /// 公民身份证号码(类型为1时表示：外国人居留证号码)
        /// </summary>
        /// <param name="CertNo"></param>
        /// <returns></returns>
        int GetCertNo(StringBuilder CertNo);
        /// <summary>
        /// 签发机关
        /// </summary>
        /// <param name="Departemt"></param>
        /// <returns></returns>
        int GetDepartemt(StringBuilder Departemt);
        /// <summary>
        /// 有效起始日期
        /// </summary>
        /// <param name="EffectDate"></param>
        /// <returns></returns>
        int GetEffectDate(StringBuilder EffectDate);
        /// <summary>
        /// 有效截止日期
        /// </summary>
        /// <param name="ExpireDate"></param>
        /// <returns></returns>
        int GetExpireDate(StringBuilder ExpireDate);
        /// <summary>
        /// 生成照片
        /// </summary>
        /// <param name="pBmpfilepath"></param>
        /// <returns></returns>
        int GetBmpFile(StringBuilder pBmpfilepath);
        /// <summary>
        /// 外国人英文姓名
        /// </summary>
        /// <param name="EnName"></param>
        /// <returns></returns>
        int GetEnName(StringBuilder EnName);
        /// <summary>
        /// 外国人国籍代码 符合GB/T2659-2000规定
        /// </summary>
        /// <param name="NationalityCode"></param>
        /// <returns></returns>
        int GetNationalityCode(StringBuilder NationalityCode);
        /// <summary>
        /// 港澳台通行证号码
        /// </summary>
        /// <param name="txzhm"></param>
        /// <returns></returns>
        int GetTXZHM(StringBuilder txzhm);
        /// <summary>
        /// 港澳台通行证签发次数
        /// </summary>
        /// <param name="txzqfcs"></param>
        /// <returns></returns>
        int GetTXZQFCS(StringBuilder txzqfcs);
        /// <summary>
        /// 寻卡15693
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        int PICC_Reader_Inventory(int Rhandle, byte[] resp);
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        int PICC_Reader_15693_Read(int Rhandle, byte blockAddr, byte[] resp);
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        int PICC_Reader_15693_Write(int Rhandle, byte blockAddr, byte[] data, byte[] resp);
        /// <summary>
        /// AFI
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        int PICC_Reader_AFI(int Rhandle, byte[] data, byte[] resp);
        /// <summary>
        /// DSFID
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        int PICC_Reader_DSFID(int Rhandle, byte[] data, byte[] resp);
        /// <summary>
        /// 卡片信息
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        int PICC_Reader_SystemInfor(int Rhandle, byte[] resp);
        /// <summary>
        /// 锁块
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        int PICC_Reader_LockDataBlock(int Rhandle, byte blockAddr, byte[] resp);
    }
    internal partial class HD100CardSdkDller : IHD100CardSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static HD100CardSdkDller Instance { get; } = new HD100CardSdkDller();
        private HD100CardSdkDller() { }
        #region // 显示实现
        int IHD100CardSdkProxy.GetAddress(StringBuilder Address) => GetAddress(Address);
        int IHD100CardSdkProxy.GetBirth(StringBuilder Birth) => GetBirth(Birth);
        int IHD100CardSdkProxy.GetBmpFile(StringBuilder pBmpfilepath) => GetBmpFile(pBmpfilepath);
        int IHD100CardSdkProxy.GetCardType() => GetCardType();
        int IHD100CardSdkProxy.GetCertNo(StringBuilder CertNo) => GetCertNo(CertNo);
        int IHD100CardSdkProxy.GetDepartemt(StringBuilder Departemt) => GetDepartemt(Departemt);
        int IHD100CardSdkProxy.GetEffectDate(StringBuilder EffectDate) => GetEffectDate(EffectDate);
        int IHD100CardSdkProxy.GetEnName(StringBuilder EnName) => GetEnName(EnName);
        int IHD100CardSdkProxy.GetExpireDate(StringBuilder ExpireDate) => GetExpireDate(ExpireDate);
        int IHD100CardSdkProxy.GetName(StringBuilder name) => GetName(name);
        int IHD100CardSdkProxy.GetNation(StringBuilder Nation) => GetNation(Nation);
        int IHD100CardSdkProxy.GetNationalityCode(StringBuilder NationalityCode) => GetNationalityCode(NationalityCode);
        int IHD100CardSdkProxy.GetSex(StringBuilder sex) => GetSex(sex);
        int IHD100CardSdkProxy.GetTXZHM(StringBuilder txzhm) => GetTXZHM(txzhm);
        int IHD100CardSdkProxy.GetTXZQFCS(StringBuilder txzqfcs) => GetTXZQFCS(txzqfcs);
        int IHD100CardSdkProxy.HexToStr(byte[] strIn, int inLen, StringBuilder strOut) => HexToStr(strIn, inLen, strOut);
        int IHD100CardSdkProxy.ICC_PosBeep(int ReaderHandle, byte time) => ICC_PosBeep(ReaderHandle, time);
        int IHD100CardSdkProxy.ICC_Reader_Application(int ReaderHandle, byte SLOT, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU) => ICC_Reader_Application(ReaderHandle, SLOT, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
        int IHD100CardSdkProxy.ICC_Reader_Close(int ReaderHandle) => ICC_Reader_Close(ReaderHandle);
        int IHD100CardSdkProxy.ICC_Reader_Open(StringBuilder dev_Name) => ICC_Reader_Open(dev_Name);
        int IHD100CardSdkProxy.ICC_Reader_pre_PowerOn(int ReaderHandle, byte SLOT, byte[] Response) => ICC_Reader_pre_PowerOn(ReaderHandle, SLOT, Response);
        int IHD100CardSdkProxy.ICC_Reader_ScanCode(int ReaderHandle, byte ctime, StringBuilder QRCodeInfo) => ICC_Reader_ScanCode(ReaderHandle, ctime, QRCodeInfo);
        int IHD100CardSdkProxy.PICC_Reader_15693_Read(int Rhandle, byte blockAddr, byte[] resp) => PICC_Reader_15693_Read(Rhandle, blockAddr, resp);
        int IHD100CardSdkProxy.PICC_Reader_15693_Write(int Rhandle, byte blockAddr, byte[] data, byte[] resp) => PICC_Reader_15693_Write(Rhandle, blockAddr, data, resp);
        int IHD100CardSdkProxy.PICC_Reader_AFI(int Rhandle, byte[] data, byte[] resp) => PICC_Reader_AFI(Rhandle, data, resp);
        int IHD100CardSdkProxy.PICC_Reader_anticoll(int ReaderHandle, byte[] uid) => PICC_Reader_anticoll(ReaderHandle, uid);
        int IHD100CardSdkProxy.PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU)
            => PICC_Reader_Application(ReaderHandle, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
        int IHD100CardSdkProxy.PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr, byte[] PassWord)
            => PICC_Reader_Authentication_Pass(ReaderHandle, Mode, SecNr, PassWord);
        int IHD100CardSdkProxy.PICC_Reader_CardInfo(int ReaderHandle, byte[] sn, byte[] date, byte[] kh, byte[] kh_len, int iType)
            => PICC_Reader_CardInfo(ReaderHandle, sn, date, kh, kh_len, iType);
        int IHD100CardSdkProxy.PICC_Reader_DSFID(int Rhandle, byte[] data, byte[] resp) => PICC_Reader_DSFID(Rhandle, data, resp);
        int IHD100CardSdkProxy.PICC_Reader_ID_ReadUID(int ReaderHandle, StringBuilder UID) => PICC_Reader_ID_ReadUID(ReaderHandle, UID);
        int IHD100CardSdkProxy.PICC_Reader_Inventory(int Rhandle, byte[] resp) => PICC_Reader_Inventory(Rhandle, resp);
        int IHD100CardSdkProxy.PICC_Reader_LockDataBlock(int Rhandle, byte blockAddr, byte[] resp) => PICC_Reader_LockDataBlock(Rhandle, blockAddr, resp);
        int IHD100CardSdkProxy.PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response) => PICC_Reader_PowerOnTypeA(ReaderHandle, Response);
        int IHD100CardSdkProxy.PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data) => PICC_Reader_Read(ReaderHandle, Addr, Data);
        int IHD100CardSdkProxy.PICC_Reader_ReadIDCard(int ReaderHandle, StringBuilder err) => PICC_Reader_ReadIDCard(ReaderHandle, err);
        int IHD100CardSdkProxy.PICC_Reader_ReadIDMsg(int RHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg)
            => PICC_Reader_ReadIDMsg(RHandle, pBmpFile, pName, pSex, pNation, pBirth, pAddress, pCertNo, pDepartment, pEffectData, pExpire, pErrMsg);
        int IHD100CardSdkProxy.PICC_Reader_Request(int ReaderHandle) => PICC_Reader_Request(ReaderHandle);
        int IHD100CardSdkProxy.PICC_Reader_Select(int ReaderHandle, byte cardtype) => PICC_Reader_Select(ReaderHandle, cardtype);
        int IHD100CardSdkProxy.PICC_Reader_SetTypeA(int ReaderHandle) => PICC_Reader_SetTypeA(ReaderHandle);
        int IHD100CardSdkProxy.PICC_Reader_SICARD(int ReaderHandle, StringBuilder sbkh, StringBuilder xm, StringBuilder xb, StringBuilder mz, StringBuilder csrq, StringBuilder shbzhm, StringBuilder fkrq, StringBuilder kyxq, StringBuilder err)
            => PICC_Reader_SICARD(ReaderHandle, sbkh, xm, xb, mz, csrq, shbzhm, fkrq, kyxq, err);
        int IHD100CardSdkProxy.PICC_Reader_SystemInfor(int Rhandle, byte[] resp) => PICC_Reader_SystemInfor(Rhandle, resp);
        int IHD100CardSdkProxy.PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data) => PICC_Reader_Write(ReaderHandle, Addr, Data);
        int IHD100CardSdkProxy.Rcard(int ReaderHandle, byte ctime, int track, byte[] rlen, StringBuilder data) => Rcard(ReaderHandle, ctime, track, rlen, data);
        int IHD100CardSdkProxy.StrToHex(StringBuilder strIn, int len, byte[] HexOut) => StrToHex(strIn, len, HexOut);
        #endregion
    }
    internal class HD100CardSdkLoader : ASdkDynamicLoader, IHD100CardSdkProxy
    {
        #region // 委托定义
        private DCreater.ICC_Reader_Open _ICC_Reader_Open;
        private DCreater.ICC_Reader_Close _ICC_Reader_Close;
        private DCreater.Rcard _Rcard;
        private DCreater.ICC_Reader_ScanCode _ICC_Reader_ScanCode;
        private DCreater.ICC_PosBeep _ICC_PosBeep;
        private DCreater.PICC_Reader_SetTypeA _PICC_Reader_SetTypeA;
        private DCreater.PICC_Reader_Select _PICC_Reader_Select;
        private DCreater.PICC_Reader_Request _PICC_Reader_Request;
        private DCreater.PICC_Reader_anticoll _PICC_Reader_anticoll;
        private DCreater.PICC_Reader_Authentication_Pass _PICC_Reader_Authentication_Pass;
        private DCreater.PICC_Reader_Read _PICC_Reader_Read;
        private DCreater.PICC_Reader_Write _PICC_Reader_Write;
        private DCreater.StrToHex _StrToHex;
        private DCreater.HexToStr _HexToStr;
        private DCreater.ICC_Reader_pre_PowerOn _ICC_Reader_pre_PowerOn;
        private DCreater.ICC_Reader_Application _ICC_Reader_Application;
        private DCreater.PICC_Reader_PowerOnTypeA _PICC_Reader_PowerOnTypeA;
        private DCreater.PICC_Reader_Application _PICC_Reader_Application;
        private DCreater.PICC_Reader_SICARD _PICC_Reader_SICARD;
        private DCreater.PICC_Reader_CardInfo _PICC_Reader_CardInfo;
        private DCreater.PICC_Reader_ReadIDMsg _PICC_Reader_ReadIDMsg;
        private DCreater.PICC_Reader_ID_ReadUID _PICC_Reader_ID_ReadUID;
        private DCreater.PICC_Reader_ReadIDCard _PICC_Reader_ReadIDCard;
        private DCreater.GetCardType _GetCardType;
        private DCreater.GetName _GetName;
        private DCreater.GetSex _GetSex;
        private DCreater.GetNation _GetNation;
        private DCreater.GetBirth _GetBirth;
        private DCreater.GetAddress _GetAddress;
        private DCreater.GetCertNo _GetCertNo;
        private DCreater.GetDepartemt _GetDepartemt;
        private DCreater.GetEffectDate _GetEffectDate;
        private DCreater.GetExpireDate _GetExpireDate;
        private DCreater.GetBmpFile _GetBmpFile;
        private DCreater.GetEnName _GetEnName;
        private DCreater.GetNationalityCode _GetNationalityCode;
        private DCreater.GetTXZHM _GetTXZHM;
        private DCreater.GetTXZQFCS _GetTXZQFCS;
        private DCreater.PICC_Reader_Inventory _PICC_Reader_Inventory;
        private DCreater.PICC_Reader_15693_Read _PICC_Reader_15693_Read;
        private DCreater.PICC_Reader_15693_Write _PICC_Reader_15693_Write;
        private DCreater.PICC_Reader_AFI _PICC_Reader_AFI;
        private DCreater.PICC_Reader_DSFID _PICC_Reader_DSFID;
        private DCreater.PICC_Reader_SystemInfor _PICC_Reader_SystemInfor;
        private DCreater.PICC_Reader_LockDataBlock _PICC_Reader_LockDataBlock;
        #endregion
        public HD100CardSdkLoader()
        {
            _ICC_Reader_Open = GetDelegate<DCreater.ICC_Reader_Open>(nameof(DCreater.ICC_Reader_Open));
            _ICC_Reader_Close = GetDelegate<DCreater.ICC_Reader_Close>(nameof(DCreater.ICC_Reader_Close));
            _Rcard = GetDelegate<DCreater.Rcard>(nameof(DCreater.Rcard));
            _ICC_Reader_ScanCode = GetDelegate<DCreater.ICC_Reader_ScanCode>(nameof(DCreater.ICC_Reader_ScanCode));
            _ICC_PosBeep = GetDelegate<DCreater.ICC_PosBeep>(nameof(DCreater.ICC_PosBeep));
            _PICC_Reader_SetTypeA = GetDelegate<DCreater.PICC_Reader_SetTypeA>(nameof(DCreater.PICC_Reader_SetTypeA));
            _PICC_Reader_Select = GetDelegate<DCreater.PICC_Reader_Select>(nameof(DCreater.PICC_Reader_Select));
            _PICC_Reader_Request = GetDelegate<DCreater.PICC_Reader_Request>(nameof(DCreater.PICC_Reader_Request));
            _PICC_Reader_anticoll = GetDelegate<DCreater.PICC_Reader_anticoll>(nameof(DCreater.PICC_Reader_anticoll));
            _PICC_Reader_Authentication_Pass = GetDelegate<DCreater.PICC_Reader_Authentication_Pass>(nameof(DCreater.PICC_Reader_Authentication_Pass));
            _PICC_Reader_Read = GetDelegate<DCreater.PICC_Reader_Read>(nameof(DCreater.PICC_Reader_Read));
            _PICC_Reader_Write = GetDelegate<DCreater.PICC_Reader_Write>(nameof(DCreater.PICC_Reader_Write));
            _StrToHex = GetDelegate<DCreater.StrToHex>(nameof(DCreater.StrToHex));
            _HexToStr = GetDelegate<DCreater.HexToStr>(nameof(DCreater.HexToStr));
            _ICC_Reader_pre_PowerOn = GetDelegate<DCreater.ICC_Reader_pre_PowerOn>(nameof(DCreater.ICC_Reader_pre_PowerOn));
            _ICC_Reader_Application = GetDelegate<DCreater.ICC_Reader_Application>(nameof(DCreater.ICC_Reader_Application));
            _PICC_Reader_PowerOnTypeA = GetDelegate<DCreater.PICC_Reader_PowerOnTypeA>(nameof(DCreater.PICC_Reader_PowerOnTypeA));
            _PICC_Reader_Application = GetDelegate<DCreater.PICC_Reader_Application>(nameof(DCreater.PICC_Reader_Application));
            _PICC_Reader_SICARD = GetDelegate<DCreater.PICC_Reader_SICARD>(nameof(DCreater.PICC_Reader_SICARD));
            _PICC_Reader_CardInfo = GetDelegate<DCreater.PICC_Reader_CardInfo>(nameof(DCreater.PICC_Reader_CardInfo));
            _PICC_Reader_ReadIDMsg = GetDelegate<DCreater.PICC_Reader_ReadIDMsg>(nameof(DCreater.PICC_Reader_ReadIDMsg));
            _PICC_Reader_ID_ReadUID = GetDelegate<DCreater.PICC_Reader_ID_ReadUID>(nameof(DCreater.PICC_Reader_ID_ReadUID));
            _PICC_Reader_ReadIDCard = GetDelegate<DCreater.PICC_Reader_ReadIDCard>(nameof(DCreater.PICC_Reader_ReadIDCard));
            _GetCardType = GetDelegate<DCreater.GetCardType>(nameof(DCreater.GetCardType));
            _GetName = GetDelegate<DCreater.GetName>(nameof(DCreater.GetName));
            _GetSex = GetDelegate<DCreater.GetSex>(nameof(DCreater.GetSex));
            _GetNation = GetDelegate<DCreater.GetNation>(nameof(DCreater.GetNation));
            _GetBirth = GetDelegate<DCreater.GetBirth>(nameof(DCreater.GetBirth));
            _GetAddress = GetDelegate<DCreater.GetAddress>(nameof(DCreater.GetAddress));
            _GetCertNo = GetDelegate<DCreater.GetCertNo>(nameof(DCreater.GetCertNo));
            _GetDepartemt = GetDelegate<DCreater.GetDepartemt>(nameof(DCreater.GetDepartemt));
            _GetEffectDate = GetDelegate<DCreater.GetEffectDate>(nameof(DCreater.GetEffectDate));
            _GetExpireDate = GetDelegate<DCreater.GetExpireDate>(nameof(DCreater.GetExpireDate));
            _GetBmpFile = GetDelegate<DCreater.GetBmpFile>(nameof(DCreater.GetBmpFile));
            _GetEnName = GetDelegate<DCreater.GetEnName>(nameof(DCreater.GetEnName));
            _GetNationalityCode = GetDelegate<DCreater.GetNationalityCode>(nameof(DCreater.GetNationalityCode));
            _GetTXZHM = GetDelegate<DCreater.GetTXZHM>(nameof(DCreater.GetTXZHM));
            _GetTXZQFCS = GetDelegate<DCreater.GetTXZQFCS>(nameof(DCreater.GetTXZQFCS));
            _PICC_Reader_Inventory = GetDelegate<DCreater.PICC_Reader_Inventory>(nameof(DCreater.PICC_Reader_Inventory));
            _PICC_Reader_15693_Read = GetDelegate<DCreater.PICC_Reader_15693_Read>(nameof(DCreater.PICC_Reader_15693_Read));
            _PICC_Reader_15693_Write = GetDelegate<DCreater.PICC_Reader_15693_Write>(nameof(DCreater.PICC_Reader_15693_Write));
            _PICC_Reader_AFI = GetDelegate<DCreater.PICC_Reader_AFI>(nameof(DCreater.PICC_Reader_AFI));
            _PICC_Reader_DSFID = GetDelegate<DCreater.PICC_Reader_DSFID>(nameof(DCreater.PICC_Reader_DSFID));
            _PICC_Reader_SystemInfor = GetDelegate<DCreater.PICC_Reader_SystemInfor>(nameof(DCreater.PICC_Reader_SystemInfor));
            _PICC_Reader_LockDataBlock = GetDelegate<DCreater.PICC_Reader_LockDataBlock>(nameof(DCreater.PICC_Reader_LockDataBlock));
        }
        public override string GetFileFullName()
        {
            return HD100CardSdk.DllFullName;
        }
        #region // 显示实现
        int IHD100CardSdkProxy.GetAddress(StringBuilder Address) => _GetAddress.Invoke(Address);
        int IHD100CardSdkProxy.GetBirth(StringBuilder Birth) => _GetBirth.Invoke(Birth);
        int IHD100CardSdkProxy.GetBmpFile(StringBuilder pBmpfilepath) => _GetBmpFile.Invoke(pBmpfilepath);
        int IHD100CardSdkProxy.GetCardType() => _GetCardType.Invoke();
        int IHD100CardSdkProxy.GetCertNo(StringBuilder CertNo) => _GetCertNo.Invoke(CertNo);
        int IHD100CardSdkProxy.GetDepartemt(StringBuilder Departemt) => _GetDepartemt.Invoke(Departemt);
        int IHD100CardSdkProxy.GetEffectDate(StringBuilder EffectDate) => _GetEffectDate.Invoke(EffectDate);
        int IHD100CardSdkProxy.GetEnName(StringBuilder EnName) => _GetEnName.Invoke(EnName);
        int IHD100CardSdkProxy.GetExpireDate(StringBuilder ExpireDate) => _GetExpireDate.Invoke(ExpireDate);
        int IHD100CardSdkProxy.GetName(StringBuilder name) => _GetName.Invoke(name);
        int IHD100CardSdkProxy.GetNation(StringBuilder Nation) => _GetNation.Invoke(Nation);
        int IHD100CardSdkProxy.GetNationalityCode(StringBuilder NationalityCode) => _GetNationalityCode.Invoke(NationalityCode);
        int IHD100CardSdkProxy.GetSex(StringBuilder sex) => _GetSex.Invoke(sex);
        int IHD100CardSdkProxy.GetTXZHM(StringBuilder txzhm) => _GetTXZHM.Invoke(txzhm);
        int IHD100CardSdkProxy.GetTXZQFCS(StringBuilder txzqfcs) => _GetTXZQFCS.Invoke(txzqfcs);
        int IHD100CardSdkProxy.HexToStr(byte[] strIn, int inLen, StringBuilder strOut) => _HexToStr.Invoke(strIn, inLen, strOut);
        int IHD100CardSdkProxy.ICC_PosBeep(int ReaderHandle, byte time) => _ICC_PosBeep.Invoke(ReaderHandle, time);
        int IHD100CardSdkProxy.ICC_Reader_Application(int ReaderHandle, byte SLOT, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU) => _ICC_Reader_Application.Invoke(ReaderHandle, SLOT, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
        int IHD100CardSdkProxy.ICC_Reader_Close(int ReaderHandle) => _ICC_Reader_Close.Invoke(ReaderHandle);
        int IHD100CardSdkProxy.ICC_Reader_Open(StringBuilder dev_Name) => _ICC_Reader_Open.Invoke(dev_Name);
        int IHD100CardSdkProxy.ICC_Reader_pre_PowerOn(int ReaderHandle, byte SLOT, byte[] Response) => _ICC_Reader_pre_PowerOn.Invoke(ReaderHandle, SLOT, Response);
        int IHD100CardSdkProxy.ICC_Reader_ScanCode(int ReaderHandle, byte ctime, StringBuilder QRCodeInfo) => _ICC_Reader_ScanCode.Invoke(ReaderHandle, ctime, QRCodeInfo);
        int IHD100CardSdkProxy.PICC_Reader_15693_Read(int Rhandle, byte blockAddr, byte[] resp) => _PICC_Reader_15693_Read.Invoke(Rhandle, blockAddr, resp);
        int IHD100CardSdkProxy.PICC_Reader_15693_Write(int Rhandle, byte blockAddr, byte[] data, byte[] resp) => _PICC_Reader_15693_Write.Invoke(Rhandle, blockAddr, data, resp);
        int IHD100CardSdkProxy.PICC_Reader_AFI(int Rhandle, byte[] data, byte[] resp) => _PICC_Reader_AFI.Invoke(Rhandle, data, resp);
        int IHD100CardSdkProxy.PICC_Reader_anticoll(int ReaderHandle, byte[] uid) => _PICC_Reader_anticoll.Invoke(ReaderHandle, uid);
        int IHD100CardSdkProxy.PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU)
            => _PICC_Reader_Application.Invoke(ReaderHandle, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
        int IHD100CardSdkProxy.PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr, byte[] PassWord)
            => _PICC_Reader_Authentication_Pass.Invoke(ReaderHandle, Mode, SecNr, PassWord);
        int IHD100CardSdkProxy.PICC_Reader_CardInfo(int ReaderHandle, byte[] sn, byte[] date, byte[] kh, byte[] kh_len, int iType)
            => _PICC_Reader_CardInfo.Invoke(ReaderHandle, sn, date, kh, kh_len, iType);
        int IHD100CardSdkProxy.PICC_Reader_DSFID(int Rhandle, byte[] data, byte[] resp) => _PICC_Reader_DSFID.Invoke(Rhandle, data, resp);
        int IHD100CardSdkProxy.PICC_Reader_ID_ReadUID(int ReaderHandle, StringBuilder UID) => _PICC_Reader_ID_ReadUID.Invoke(ReaderHandle, UID);
        int IHD100CardSdkProxy.PICC_Reader_Inventory(int Rhandle, byte[] resp) => _PICC_Reader_Inventory.Invoke(Rhandle, resp);
        int IHD100CardSdkProxy.PICC_Reader_LockDataBlock(int Rhandle, byte blockAddr, byte[] resp) => _PICC_Reader_LockDataBlock.Invoke(Rhandle, blockAddr, resp);
        int IHD100CardSdkProxy.PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response) => _PICC_Reader_PowerOnTypeA.Invoke(ReaderHandle, Response);
        int IHD100CardSdkProxy.PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data) => _PICC_Reader_Read.Invoke(ReaderHandle, Addr, Data);
        int IHD100CardSdkProxy.PICC_Reader_ReadIDCard(int ReaderHandle, StringBuilder err) => _PICC_Reader_ReadIDCard.Invoke(ReaderHandle, err);
        int IHD100CardSdkProxy.PICC_Reader_ReadIDMsg(int RHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg)
            => _PICC_Reader_ReadIDMsg.Invoke(RHandle, pBmpFile, pName, pSex, pNation, pBirth, pAddress, pCertNo, pDepartment, pEffectData, pExpire, pErrMsg);
        int IHD100CardSdkProxy.PICC_Reader_Request(int ReaderHandle) => _PICC_Reader_Request.Invoke(ReaderHandle);
        int IHD100CardSdkProxy.PICC_Reader_Select(int ReaderHandle, byte cardtype) => _PICC_Reader_Select.Invoke(ReaderHandle, cardtype);
        int IHD100CardSdkProxy.PICC_Reader_SetTypeA(int ReaderHandle) => _PICC_Reader_SetTypeA.Invoke(ReaderHandle);
        int IHD100CardSdkProxy.PICC_Reader_SICARD(int ReaderHandle, StringBuilder sbkh, StringBuilder xm, StringBuilder xb, StringBuilder mz, StringBuilder csrq, StringBuilder shbzhm, StringBuilder fkrq, StringBuilder kyxq, StringBuilder err)
            => _PICC_Reader_SICARD.Invoke(ReaderHandle, sbkh, xm, xb, mz, csrq, shbzhm, fkrq, kyxq, err);
        int IHD100CardSdkProxy.PICC_Reader_SystemInfor(int Rhandle, byte[] resp) => _PICC_Reader_SystemInfor.Invoke(Rhandle, resp);
        int IHD100CardSdkProxy.PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data) => _PICC_Reader_Write.Invoke(ReaderHandle, Addr, Data);
        int IHD100CardSdkProxy.Rcard(int ReaderHandle, byte ctime, int track, byte[] rlen, StringBuilder data) => _Rcard.Invoke(ReaderHandle, ctime, track, rlen, data);
        int IHD100CardSdkProxy.StrToHex(StringBuilder strIn, int len, byte[] HexOut) => _StrToHex.Invoke(strIn, len, HexOut);
        #endregion
    }
}
