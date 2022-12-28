using System;
using System.Collections.Generic;
using System.Data.HDSSSEEXE;
using System.Runtime.InteropServices;
using System.Text;
using static System.Data.HDSSSESDK.HD100CardSdkDller;

namespace System.Data.HDSSSESDK
{
    /// <summary>
    /// SDK创建类
    /// HDSSSE的32位ICC/PICC等卡接口
    /// 不支持64位程序,请使用
    /// </summary>
    internal static class HD100CardSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "HDSSSE32.dll";
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Call(string content)
        {
            var model = PipeSwapperModel.GetModel(content);
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
    }
}
