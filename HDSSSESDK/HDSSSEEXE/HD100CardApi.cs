using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HDSSSEEXE
{
    /// <summary>
    /// HDSSSE的32位ICC/PICC等卡接口
    /// 不支持64位程序,请使用
    /// </summary>
    internal class HD100CardApi
    {
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Call(string content)
        {
            var model = PiperSwapModel.GetModel(content);
            switch (model.Cmd)
            {
                // 打开端口
                case nameof(ICC_Reader_Open):
                    {
                        model.R = ICC_Reader_Open(model.S1);
                        break;
                    }
                // 关闭端口
                case nameof(ICC_Reader_Close):
                    {
                        model.R = ICC_Reader_Close(model.RH);
                        break;
                    }
                // 读磁条卡
                case nameof(Rcard):
                    {
                        model.R = Rcard(model.RH, model.B1, model.I1, model.A1, model.S1);
                        break;
                    }
                // 扫码
                case nameof(ICC_Reader_ScanCode):
                    {
                        model.R = ICC_Reader_ScanCode(model.RH, model.B1, model.S1);
                        break;
                    }
                // 蜂鸣
                case nameof(ICC_PosBeep):
                    {
                        model.R = ICC_PosBeep(model.RH, model.B1);
                        break;
                    }
                // 设置读typeA
                case nameof(PICC_Reader_SetTypeA):
                    {
                        model.R = PICC_Reader_SetTypeA(model.RH);
                        break;
                    }
                // 选择卡片，41为typea,M1 42为typeb,TypeB卡片需先上电后选卡
                case nameof(PICC_Reader_Select):
                    {
                        model.R = PICC_Reader_Select(model.RH, model.B1);
                        break;
                    }
                // typea 和 M1 请求卡片
                case nameof(PICC_Reader_Request):
                    {
                        model.R = PICC_Reader_Request(model.RH);
                        break;
                    }
                // 防碰撞 typea M1卡片
                case nameof(PICC_Reader_anticoll):
                    {
                        model.R = PICC_Reader_anticoll(model.RH, model.A1);
                        break;
                    }
                // 注意：输入的是12位的密钥，例如12个f，但是password必须是6个字节的密钥，需要用StrToHex函数处理。
                case nameof(PICC_Reader_Authentication_Pass):
                    {
                        model.R = PICC_Reader_Authentication_Pass(model.RH, model.B1, model.B2, model.A1);
                        break;
                    }
                // 读卡
                case nameof(PICC_Reader_Read):
                    {
                        model.R = PICC_Reader_Read(model.RH, model.B1, model.A1);
                        break;
                    }
                // 写卡
                case nameof(PICC_Reader_Write):
                    {
                        model.R = PICC_Reader_Write(model.RH, model.B1, model.A1);
                        break;
                    }
                // 将字符命令流转为16进制流
                case nameof(StrToHex):
                    {
                        model.R = StrToHex(model.S1, model.I1, model.A1);
                        break;
                    }
                // 将16进制流命令转为字符流
                case nameof(HexToStr):
                    {
                        model.R = HexToStr(model.A1, model.I1, model.S1);
                        break;
                    }
                // 接触CPU
                // 上电 返回数据长度 失败小于0
                case nameof(ICC_Reader_pre_PowerOn):
                    {
                        model.R = ICC_Reader_pre_PowerOn(model.RH, model.B1, model.A1);
                        break;
                    }
                // type a/b执行apdu命令 返回数据长度 失败小于0
                case nameof(ICC_Reader_Application):
                    {
                        model.R = ICC_Reader_Application(model.RH, model.B1, model.I1, model.A1, model.A2);
                        break;
                    }
                // 非接CPU
                // 上电 返回数据长度 失败小于0
                case nameof(PICC_Reader_PowerOnTypeA):
                    {
                        model.R = PICC_Reader_PowerOnTypeA(model.RH, model.A1);
                        break;
                    }
                // type a/b执行apdu命令 返回数据长度 失败小于0
                case nameof(PICC_Reader_Application):
                    {
                        model.R = PICC_Reader_Application(model.RH, model.I1, model.A1, model.A2);
                        break;
                    }
                // 社保卡
                case nameof(PICC_Reader_SICARD):
                    {
                        model.R = PICC_Reader_SICARD(model.RH, model.S1, model.S2, model.S3, model.S4, model.S5, model.S6, model.S7, model.S8, model.S9);
                        break;
                    }
                // 银行卡
                case nameof(PICC_Reader_CardInfo):
                    {
                        model.R = PICC_Reader_CardInfo(model.RH, model.A1, model.A2, model.A3, model.A4, model.I1);
                        break;
                    }
                // 身份证
                case nameof(PICC_Reader_ReadIDMsg):
                    {
                        model.R = PICC_Reader_ReadIDMsg(model.RH, model.S1, model.S2, model.S3, model.S4, model.S5, model.S6, model.S7, model.S8, model.S9, model.SA, model.SB);
                        break;
                    }
                // 上电 返回数据长度 失败小于0
                case nameof(PICC_Reader_ID_ReadUID):
                    {
                        model.R = PICC_Reader_ID_ReadUID(model.RH, model.S1);
                        break;
                    }
                // 读身份证 
                case nameof(PICC_Reader_ReadIDCard):
                    {
                        model.R = PICC_Reader_ReadIDCard(model.RH, model.S1);
                        break;
                    }
                // 获取证件类型
                case nameof(GetCardType):
                    {
                        model.R = GetCardType();
                        break;
                    }
                // 姓名(类型为1时表示：外国人中文姓名)
                case nameof(GetName):
                    {
                        model.R = GetName(model.S1);
                        break;
                    }
                // 性别
                case nameof(GetSex):
                    {
                        model.R = GetSex(model.S1);
                        break;
                    }
                // 民族
                case nameof(GetNation):
                    {
                        model.R = GetNation(model.S1);
                        break;
                    }
                // 出生日期
                case nameof(GetBirth):
                    {
                        model.R = GetBirth(model.S1);
                        break;
                    }
                // 住址
                case nameof(GetAddress):
                    {
                        model.R = GetAddress(model.S1);
                        break;
                    }
                // 公民身份证号码(类型为1时表示：外国人居留证号码)
                case nameof(GetCertNo):
                    {
                        model.R = GetCertNo(model.S1);
                        break;
                    }
                // 签发机关
                case nameof(GetDepartemt):
                    {
                        model.R = GetDepartemt(model.S1);
                        break;
                    }
                // 有效起始日期
                case nameof(GetEffectDate):
                    {
                        model.R = GetEffectDate(model.S1);
                        break;
                    }
                // 有效截止日期
                case nameof(GetExpireDate):
                    {
                        model.R = GetExpireDate(model.S1);
                        break;
                    }
                // 生成照片
                case nameof(GetBmpFile):
                    {
                        model.R = GetBmpFile(model.S1);
                        break;
                    }
                // 外国人英文姓名
                case nameof(GetEnName):
                    {
                        model.R = GetEnName(model.S1);
                        break;
                    }
                // 外国人国籍代码 符合GB/T2659-2000规定
                case nameof(GetNationalityCode):
                    {
                        model.R = GetNationalityCode(model.S1);
                        break;
                    }
                // 港澳台通行证号码
                case nameof(GetTXZHM):
                    {
                        model.R = GetTXZHM(model.S1);
                        break;
                    }
                // 港澳台通行证签发次数
                case nameof(GetTXZQFCS):
                    {
                        model.R = GetTXZQFCS(model.S1);
                        break;
                    }
                // 寻卡15693
                case nameof(PICC_Reader_Inventory):
                    {
                        model.R = PICC_Reader_Inventory(model.RH, model.A1);
                        break;
                    }
                // 读卡
                case nameof(PICC_Reader_15693_Read):
                    {
                        model.R = PICC_Reader_15693_Read(model.RH, model.B1, model.A1);
                        break;
                    }
                // 写卡
                case nameof(PICC_Reader_15693_Write):
                    {
                        model.R = PICC_Reader_15693_Write(model.RH, model.B1, model.A1, model.A2);
                        break;
                    }
                // AFI
                case nameof(PICC_Reader_AFI):
                    {
                        model.R = PICC_Reader_AFI(model.RH, model.A1, model.A2);
                        break;
                    }
                // DSFID
                case nameof(PICC_Reader_DSFID):
                    {
                        model.R = PICC_Reader_DSFID(model.RH, model.A1, model.A2);
                        break;
                    }
                // 卡片信息
                case nameof(PICC_Reader_SystemInfor):
                    {
                        model.R = PICC_Reader_SystemInfor(model.RH, model.A1);
                        break;
                    }
                // 锁块
                case nameof(PICC_Reader_LockDataBlock):
                    {
                        model.R = PICC_Reader_LockDataBlock(model.RH, model.B1, model.A1);
                        break;
                    }
                default:
                    break;
            }
            model.IT = true;
            return model.ToJson();
        }

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
