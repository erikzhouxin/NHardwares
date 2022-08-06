using System;
using System.Collections.Generic;
using System.Data.HDSSSEEXE;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.HDSSSESDK
{
    /// <summary>
    /// 创建类
    /// </summary>
    [Obsolete("替代方案:HD100CardSDK")]
    public class HD100CardBuilder
    {
        /// <summary>
        /// 创建一个实例
        /// SDK原生不支持64位,所以64位可能有性能损耗
        /// </summary>
        /// <returns></returns>
        public static IHD100CardApi Create() => HD100CardSdk.CreateApi();
    }
    /// <summary>
    /// 接口
    /// </summary>
    [Obsolete("替代方案:IHD100CardProxy")]
    public interface IHD100CardApi : IHD100CardSdkProxy { }
    /// <summary>
    /// HDSSSE的32位ICC/PICC等卡接口
    /// 不支持64位
    /// </summary>
    internal class HD100CardApi : IHD100CardSdkProxy, IHD100CardApi
    {
        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="dev_Name"></param>
        /// <returns></returns>
        public int ICC_Reader_Open(StringBuilder dev_Name) => HD100CardSdkDller.ICC_Reader_Open(dev_Name);
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int ICC_Reader_Close(int ReaderHandle) => HD100CardSdkDller.ICC_Reader_Close(ReaderHandle);
        /// <summary>
        /// 读磁条卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="track"></param>
        /// <param name="rlen"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Rcard(int ReaderHandle, byte ctime, int track, byte[] rlen, StringBuilder data) => HD100CardSdkDller.Rcard(ReaderHandle, ctime, track, rlen, data);
        /// <summary>
        /// 扫码
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="QRCodeInfo"></param>
        /// <returns></returns>
        public int ICC_Reader_ScanCode(int ReaderHandle, byte ctime, StringBuilder QRCodeInfo) => HD100CardSdkDller.ICC_Reader_ScanCode(ReaderHandle, ctime, QRCodeInfo);
        /// <summary>
        /// 蜂鸣
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int ICC_PosBeep(int ReaderHandle, byte time) => HD100CardSdkDller.ICC_PosBeep(ReaderHandle, time);
        /// <summary>
        /// 设置读typeA
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int PICC_Reader_SetTypeA(int ReaderHandle) => HD100CardSdkDller.PICC_Reader_SetTypeA(ReaderHandle);
        /// <summary>
        /// 选择卡片，41为typea,M1 42为typeb,TypeB卡片需先上电后选卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="cardtype"></param>
        /// <returns></returns>
        public int PICC_Reader_Select(int ReaderHandle, byte cardtype) => HD100CardSdkDller.PICC_Reader_Select(ReaderHandle, cardtype);
        /// <summary>
        /// typea 和 M1 请求卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int PICC_Reader_Request(int ReaderHandle) => HD100CardSdkDller.PICC_Reader_Request(ReaderHandle);
        /// <summary>
        /// 防碰撞 typea M1卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int PICC_Reader_anticoll(int ReaderHandle, byte[] uid) => HD100CardSdkDller.PICC_Reader_anticoll(ReaderHandle, uid);
        /// <summary>
        /// 注意：输入的是12位的密钥，例如12个f，但是password必须是6个字节的密钥，需要用StrToHex函数处理。
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Mode"></param>
        /// <param name="SecNr"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public int PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr, byte[] PassWord) => HD100CardSdkDller.PICC_Reader_Authentication_Pass(ReaderHandle, Mode, SecNr, PassWord);
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data) => HD100CardSdkDller.PICC_Reader_Read(ReaderHandle, Addr, Data);
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data) => HD100CardSdkDller.PICC_Reader_Write(ReaderHandle, Addr, Data);
        /// <summary>
        /// 将字符命令流转为16进制流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="len"></param>
        /// <param name="HexOut"></param>
        /// <returns></returns>
        public int StrToHex(StringBuilder strIn, int len, Byte[] HexOut) => HD100CardSdkDller.StrToHex(strIn, len, HexOut);
        /// <summary>
        /// 将16进制流命令转为字符流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="inLen"></param>
        /// <param name="strOut"></param>
        /// <returns></returns>
        public int HexToStr(Byte[] strIn, int inLen, StringBuilder strOut) => HD100CardSdkDller.HexToStr(strIn, inLen, strOut);
        /// <summary>
        /// 接触CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public int ICC_Reader_pre_PowerOn(int ReaderHandle, byte SLOT, byte[] Response) => HD100CardSdkDller.ICC_Reader_pre_PowerOn(ReaderHandle, SLOT, Response);
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        public int ICC_Reader_Application(int ReaderHandle, byte SLOT, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU) => HD100CardSdkDller.ICC_Reader_Application(ReaderHandle, SLOT, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
        /// <summary>
        /// 非接CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public int PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response) => HD100CardSdkDller.PICC_Reader_PowerOnTypeA(ReaderHandle, Response);
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        public int PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU) => HD100CardSdkDller.PICC_Reader_Application(ReaderHandle, Lenth_of_Command_APDU, Command_APDU, Response_APDU);
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
        public int PICC_Reader_SICARD(int ReaderHandle, StringBuilder sbkh, StringBuilder xm, StringBuilder xb, StringBuilder mz, StringBuilder csrq, StringBuilder shbzhm, StringBuilder fkrq, StringBuilder kyxq, StringBuilder err) => HD100CardSdkDller.PICC_Reader_SICARD(ReaderHandle, sbkh, xm, xb, mz, csrq, shbzhm, fkrq, kyxq, err);
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
        public int PICC_Reader_CardInfo(int ReaderHandle, byte[] sn, byte[] date, byte[] kh, byte[] kh_len, int iType) => HD100CardSdkDller.PICC_Reader_CardInfo(ReaderHandle, sn, date, kh, kh_len, iType);
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
        public int PICC_Reader_ReadIDMsg(int RHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg) => HD100CardSdkDller.PICC_Reader_ReadIDMsg(RHandle, pBmpFile, pName, pSex, pNation, pBirth, pAddress, pCertNo, pDepartment, pEffectData, pExpire, pErrMsg);
        /// <summary>
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int PICC_Reader_ID_ReadUID(int ReaderHandle, StringBuilder UID) => HD100CardSdkDller.PICC_Reader_ID_ReadUID(ReaderHandle, UID);
        /// <summary>
        /// 读身份证 
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public int PICC_Reader_ReadIDCard(int ReaderHandle, StringBuilder err) => HD100CardSdkDller.PICC_Reader_ReadIDCard(ReaderHandle, err);
        /// <summary>
        /// 获取证件类型
        /// </summary>
        /// <returns></returns>
        public int GetCardType() => HD100CardSdkDller.GetCardType();
        /// <summary>
        /// 姓名(类型为1时表示：外国人中文姓名)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetName(StringBuilder name) => HD100CardSdkDller.GetName(name);
        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public int GetSex(StringBuilder sex) => HD100CardSdkDller.GetSex(sex);
        /// <summary>
        /// 民族
        /// </summary>
        /// <param name="Nation"></param>
        /// <returns></returns>
        public int GetNation(StringBuilder Nation) => HD100CardSdkDller.GetNation(Nation);
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <param name="Birth"></param>
        /// <returns></returns>
        public int GetBirth(StringBuilder Birth) => HD100CardSdkDller.GetBirth(Birth);
        /// <summary>
        /// 住址
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public int GetAddress(StringBuilder Address) => HD100CardSdkDller.GetAddress(Address);
        /// <summary>
        /// 公民身份证号码(类型为1时表示：外国人居留证号码)
        /// </summary>
        /// <param name="CertNo"></param>
        /// <returns></returns>
        public int GetCertNo(StringBuilder CertNo) => HD100CardSdkDller.GetCertNo(CertNo);
        /// <summary>
        /// 签发机关
        /// </summary>
        /// <param name="Departemt"></param>
        /// <returns></returns>
        public int GetDepartemt(StringBuilder Departemt) => HD100CardSdkDller.GetDepartemt(Departemt);
        /// <summary>
        /// 有效起始日期
        /// </summary>
        /// <param name="EffectDate"></param>
        /// <returns></returns>
        public int GetEffectDate(StringBuilder EffectDate) => HD100CardSdkDller.GetEffectDate(EffectDate);
        /// <summary>
        /// 有效截止日期
        /// </summary>
        /// <param name="ExpireDate"></param>
        /// <returns></returns>
        public int GetExpireDate(StringBuilder ExpireDate) => HD100CardSdkDller.GetExpireDate(ExpireDate);
        /// <summary>
        /// 生成照片
        /// </summary>
        /// <param name="pBmpfilepath"></param>
        /// <returns></returns>
        public int GetBmpFile(StringBuilder pBmpfilepath) => HD100CardSdkDller.GetBmpFile(pBmpfilepath);
        /// <summary>
        /// 外国人英文姓名
        /// </summary>
        /// <param name="EnName"></param>
        /// <returns></returns>
        public int GetEnName(StringBuilder EnName) => HD100CardSdkDller.GetEnName(EnName);
        /// <summary>
        /// 外国人国籍代码 符合GB/T2659-2000规定
        /// </summary>
        /// <param name="NationalityCode"></param>
        /// <returns></returns>
        public int GetNationalityCode(StringBuilder NationalityCode) => HD100CardSdkDller.GetNationalityCode(NationalityCode);
        /// <summary>
        /// 港澳台通行证号码
        /// </summary>
        /// <param name="txzhm"></param>
        /// <returns></returns>
        public int GetTXZHM(StringBuilder txzhm) => HD100CardSdkDller.GetTXZHM(txzhm);
        /// <summary>
        /// 港澳台通行证签发次数
        /// </summary>
        /// <param name="txzqfcs"></param>
        /// <returns></returns>
        public int GetTXZQFCS(StringBuilder txzqfcs) => HD100CardSdkDller.GetTXZQFCS(txzqfcs);
        /// <summary>
        /// 寻卡15693
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_Inventory(int Rhandle, byte[] resp) => HD100CardSdkDller.PICC_Reader_Inventory(Rhandle, resp);
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_15693_Read(int Rhandle, byte blockAddr, byte[] resp) => HD100CardSdkDller.PICC_Reader_15693_Read(Rhandle, blockAddr, resp);
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_15693_Write(int Rhandle, byte blockAddr, byte[] data, byte[] resp) => HD100CardSdkDller.PICC_Reader_15693_Write(Rhandle, blockAddr, data, resp);
        /// <summary>
        /// AFI
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_AFI(int Rhandle, byte[] data, byte[] resp) => HD100CardSdkDller.PICC_Reader_AFI(Rhandle, data, resp);
        /// <summary>
        /// DSFID
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_DSFID(int Rhandle, byte[] data, byte[] resp) => HD100CardSdkDller.PICC_Reader_DSFID(Rhandle, data, resp);
        /// <summary>
        /// 卡片信息
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_SystemInfor(int Rhandle, byte[] resp) => HD100CardSdkDller.PICC_Reader_SystemInfor(Rhandle, resp);
        /// <summary>
        /// 锁块
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_LockDataBlock(int Rhandle, byte blockAddr, byte[] resp) => HD100CardSdkDller.PICC_Reader_LockDataBlock(Rhandle, blockAddr, resp);
    }
    /// <summary>    
    /// HDSSSE的32位ICC/PICC等卡接口
    /// 利用管道通信支持64位
    /// </summary>
    internal class HD100CardApi64 : IHD100CardSdkProxy, IHD100CardApi, IDisposable
    {
        /// <summary>
        /// 执行文件名
        /// </summary>
        public const string ExeFile = "NSystem.Data.HDSSSEEXE.exe";
        /// <summary>
        /// 执行文件全名
        /// </summary>
        public static String ExeFileName { get; } = Path.Combine(HD100CardSdkLoader.DllFullPath, ExeFile);
        /// <summary>
        /// 单一实例
        /// </summary>
        public static HD100CardApi64 Instance { get; }
        /// <summary>
        /// 静态构造
        /// </summary>
        static HD100CardApi64()
        {
            var isExists = HD100CardSdk.CompareFile(ExeFileName, Properties.Resources.X86_HDSSSEEXE);
            if (!isExists) { HD100CardSdk.WriteFile(Properties.Resources.X86_HDSSSEEXE, ExeFileName); }
            Instance = new HD100CardApi64();
        }

        private Process _process;
        private NamedPipeServerStream _piper;
        private StreamWriter _writer;
        private Lazy<StreamReader> _reader;
        private String _key;
        /// <summary>
        /// 构造
        /// </summary>
        private HD100CardApi64()
        {
            _key = Guid.NewGuid().ToString("N");
            _process = new Process();
            _process.StartInfo.FileName = ExeFileName;
            _process.StartInfo.WorkingDirectory = HD100CardSdkLoader.DllFullPath;
            _process.StartInfo.Arguments = _key;
            _process.StartInfo.CreateNoWindow = true;
            _process.StartInfo.UseShellExecute = false;
            _piper = new NamedPipeServerStream(_key, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.None);
            _process.Start();
            _piper.WaitForConnection();
            _writer = new StreamWriter(_piper, Encoding.UTF8)
            {
                AutoFlush = true
            };
            _reader = new Lazy<StreamReader>(() => new StreamReader(_piper, Encoding.UTF8), true);
        }
        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="dev_Name"></param>
        /// <returns></returns>
        public int ICC_Reader_Open(StringBuilder dev_Name)
        {
            var model = new PiperSwapModel(nameof(ICC_Reader_Open))
            {
                S1 = dev_Name,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int ICC_Reader_Close(int ReaderHandle)
        {
            var model = new PiperSwapModel(nameof(ICC_Reader_Close))
            {
                RH = ReaderHandle,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 读磁条卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="track"></param>
        /// <param name="rlen"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Rcard(int ReaderHandle, byte ctime, int track, byte[] rlen, StringBuilder data)
        {
            var model = new PiperSwapModel(nameof(Rcard))
            {
                RH = ReaderHandle,
                B1 = ctime,
                I1 = track,
                S1 = data,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            data.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 扫码
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="ctime"></param>
        /// <param name="QRCodeInfo"></param>
        /// <returns></returns>
        public int ICC_Reader_ScanCode(int ReaderHandle, byte ctime, StringBuilder QRCodeInfo)
        {
            var model = new PiperSwapModel(nameof(ICC_Reader_ScanCode))
            {
                RH = ReaderHandle,
                B1 = ctime,
                S1 = QRCodeInfo,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            QRCodeInfo.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 蜂鸣
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int ICC_PosBeep(int ReaderHandle, byte time)
        {
            var model = new PiperSwapModel(nameof(ICC_PosBeep))
            {
                RH = ReaderHandle,
                B1 = time,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 设置读typeA
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int PICC_Reader_SetTypeA(int ReaderHandle)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_SetTypeA))
            {
                RH = ReaderHandle,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 选择卡片，41为typea,M1 42为typeb,TypeB卡片需先上电后选卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="cardtype"></param>
        /// <returns></returns>
        public int PICC_Reader_Select(int ReaderHandle, byte cardtype)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_Select))
            {
                RH = ReaderHandle,
                B1 = cardtype,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// typea 和 M1 请求卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <returns></returns>
        public int PICC_Reader_Request(int ReaderHandle)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_Request))
            {
                RH = ReaderHandle,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 防碰撞 typea M1卡片
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int PICC_Reader_anticoll(int ReaderHandle, byte[] uid)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_anticoll))
            {
                RH = ReaderHandle,
                A1 = uid,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 注意：输入的是12位的密钥，例如12个f，但是password必须是6个字节的密钥，需要用StrToHex函数处理。
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Mode"></param>
        /// <param name="SecNr"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public int PICC_Reader_Authentication_Pass(int ReaderHandle, byte Mode, byte SecNr, byte[] PassWord)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_Authentication_Pass))
            {
                RH = ReaderHandle,
                B1 = Mode,
                B2 = SecNr,
                A1 = PassWord,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int PICC_Reader_Read(int ReaderHandle, byte Addr, byte[] Data)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_Read))
            {
                RH = ReaderHandle,
                B1 = Addr,
                A1 = Data,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, Data, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Addr"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int PICC_Reader_Write(int ReaderHandle, byte Addr, byte[] Data)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_Write))
            {
                RH = ReaderHandle,
                B1 = Addr,
                A1 = Data,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 将字符命令流转为16进制流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="len"></param>
        /// <param name="HexOut"></param>
        /// <returns></returns>
        public int StrToHex(StringBuilder strIn, int len, Byte[] HexOut)
        {
            var model = new PiperSwapModel(nameof(StrToHex))
            {
                S1 = strIn,
                I1 = len,
                A1 = HexOut,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, HexOut, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// 将16进制流命令转为字符流
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="inLen"></param>
        /// <param name="strOut"></param>
        /// <returns></returns>
        public int HexToStr(Byte[] strIn, int inLen, StringBuilder strOut)
        {
            var model = new PiperSwapModel(nameof(HexToStr))
            {
                S1 = strOut,
                I1 = inLen,
                A1 = strIn,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            strOut.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 接触CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public int ICC_Reader_pre_PowerOn(int ReaderHandle, byte SLOT, byte[] Response)
        {
            var model = new PiperSwapModel(nameof(ICC_Reader_pre_PowerOn))
            {
                RH = ReaderHandle,
                B1 = SLOT,
                A1 = Response,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, Response, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="SLOT"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        public int ICC_Reader_Application(int ReaderHandle, byte SLOT, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU)
        {
            var model = new PiperSwapModel(nameof(ICC_Reader_Application))
            {
                RH = ReaderHandle,
                B1 = SLOT,
                I1 = Lenth_of_Command_APDU,
                A1 = Command_APDU,
                A2 = Response_APDU,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, Command_APDU, 0, resObj.A1.Length);
            Array.Copy(resObj.A2, 0, Response_APDU, 0, resObj.A2.Length);
            return resObj.R;
        }
        /// <summary>
        /// 非接CPU
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public int PICC_Reader_PowerOnTypeA(int ReaderHandle, byte[] Response)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_PowerOnTypeA))
            {
                RH = ReaderHandle,
                A1 = Response,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, Response, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// type a/b执行apdu命令 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="Lenth_of_Command_APDU"></param>
        /// <param name="Command_APDU"></param>
        /// <param name="Response_APDU"></param>
        /// <returns></returns>
        public int PICC_Reader_Application(int ReaderHandle, int Lenth_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_Application))
            {
                RH = ReaderHandle,
                I1 = Lenth_of_Command_APDU,
                A1 = Command_APDU,
                A2 = Response_APDU,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, Command_APDU, 0, resObj.A1.Length);
            Array.Copy(resObj.A2, 0, Response_APDU, 0, resObj.A2.Length);
            return resObj.R;
        }
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
        public int PICC_Reader_SICARD(int ReaderHandle, StringBuilder sbkh, StringBuilder xm, StringBuilder xb, StringBuilder mz, StringBuilder csrq, StringBuilder shbzhm, StringBuilder fkrq, StringBuilder kyxq, StringBuilder err)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_SICARD))
            {
                RH = ReaderHandle,
                S1 = sbkh,
                S2 = xm,
                S3 = xb,
                S4 = mz,
                S5 = csrq,
                S6 = shbzhm,
                S7 = fkrq,
                S8 = kyxq,
                S9 = err,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            sbkh.Clear().Append(resObj.S1);
            xm.Clear().Append(resObj.S2);
            xb.Clear().Append(resObj.S3);
            mz.Clear().Append(resObj.S4);
            csrq.Clear().Append(resObj.S5);
            shbzhm.Clear().Append(resObj.S6);
            fkrq.Clear().Append(resObj.S7);
            kyxq.Clear().Append(resObj.S8);
            err.Clear().Append(resObj.S9);
            return resObj.R;
        }
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
        public int PICC_Reader_CardInfo(int ReaderHandle, byte[] sn, byte[] date, byte[] kh, byte[] kh_len, int iType)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_CardInfo))
            {
                RH = ReaderHandle,
                A1 = sn,
                A2 = date,
                A3 = kh,
                A4 = kh_len,
                I1 = iType,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
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
        public int PICC_Reader_ReadIDMsg(int RHandle, StringBuilder pBmpFile, StringBuilder pName, StringBuilder pSex, StringBuilder pNation, StringBuilder pBirth, StringBuilder pAddress, StringBuilder pCertNo, StringBuilder pDepartment, StringBuilder pEffectData, StringBuilder pExpire, StringBuilder pErrMsg)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_ReadIDMsg))
            {
                RH = RHandle,
                S1 = pBmpFile,
                S2 = pName,
                S3 = pSex,
                S4 = pNation,
                S5 = pBirth,
                S6 = pAddress,
                S7 = pCertNo,
                S8 = pDepartment,
                S9 = pEffectData,
                SA = pExpire,
                SB = pErrMsg,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            pBmpFile.Clear().Append(resObj.S1);
            pName.Clear().Append(resObj.S2);
            pSex.Clear().Append(resObj.S3);
            pNation.Clear().Append(resObj.S4);
            pBirth.Clear().Append(resObj.S5);
            pAddress.Clear().Append(resObj.S6);
            pCertNo.Clear().Append(resObj.S7);
            pDepartment.Clear().Append(resObj.S8);
            pEffectData.Clear().Append(resObj.S9);
            pExpire.Clear().Append(resObj.SA);
            pErrMsg.Clear().Append(resObj.SB);
            return resObj.R;
        }
        /// <summary>
        /// 上电 返回数据长度 失败小于0
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int PICC_Reader_ID_ReadUID(int ReaderHandle, StringBuilder UID)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_ID_ReadUID))
            {
                RH = ReaderHandle,
                S1 = UID,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            UID.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 读身份证 
        /// </summary>
        /// <param name="ReaderHandle"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public int PICC_Reader_ReadIDCard(int ReaderHandle, StringBuilder err)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_ReadIDCard))
            {
                RH = ReaderHandle,
                S1 = err,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            err.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 获取证件类型
        /// </summary>
        /// <returns></returns>
        public int GetCardType()
        {
            var model = new PiperSwapModel(nameof(GetCardType));
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            return resObj.R;
        }
        /// <summary>
        /// 姓名(类型为1时表示：外国人中文姓名)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetName(StringBuilder name)
        {
            var model = new PiperSwapModel(nameof(GetName))
            {
                S1 = name,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            name.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public int GetSex(StringBuilder sex)
        {
            var model = new PiperSwapModel(nameof(GetSex))
            {
                S1 = sex,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            sex.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 民族
        /// </summary>
        /// <param name="Nation"></param>
        /// <returns></returns>
        public int GetNation(StringBuilder Nation)
        {
            var model = new PiperSwapModel(nameof(GetNation))
            {
                S1 = Nation,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Nation.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <param name="Birth"></param>
        /// <returns></returns>
        public int GetBirth(StringBuilder Birth)
        {
            var model = new PiperSwapModel(nameof(GetBirth))
            {
                S1 = Birth,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Birth.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 住址
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public int GetAddress(StringBuilder Address)
        {
            var model = new PiperSwapModel(nameof(GetAddress))
            {
                S1 = Address,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Address.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 公民身份证号码(类型为1时表示：外国人居留证号码)
        /// </summary>
        /// <param name="CertNo"></param>
        /// <returns></returns>
        public int GetCertNo(StringBuilder CertNo)
        {
            var model = new PiperSwapModel(nameof(GetCertNo))
            {
                S1 = CertNo,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            CertNo.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 签发机关
        /// </summary>
        /// <param name="Departemt"></param>
        /// <returns></returns>
        public int GetDepartemt(StringBuilder Departemt)
        {
            var model = new PiperSwapModel(nameof(GetDepartemt))
            {
                S1 = Departemt,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Departemt.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 有效起始日期
        /// </summary>
        /// <param name="EffectDate"></param>
        /// <returns></returns>
        public int GetEffectDate(StringBuilder EffectDate)
        {
            var model = new PiperSwapModel(nameof(GetEffectDate))
            {
                S1 = EffectDate,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            EffectDate.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 有效截止日期
        /// </summary>
        /// <param name="ExpireDate"></param>
        /// <returns></returns>
        public int GetExpireDate(StringBuilder ExpireDate)
        {
            var model = new PiperSwapModel(nameof(GetExpireDate))
            {
                S1 = ExpireDate,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            ExpireDate.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 生成照片
        /// </summary>
        /// <param name="pBmpfilepath"></param>
        /// <returns></returns>
        public int GetBmpFile(StringBuilder pBmpfilepath)
        {
            var model = new PiperSwapModel(nameof(GetBmpFile))
            {
                S1 = pBmpfilepath,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            pBmpfilepath.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 外国人英文姓名
        /// </summary>
        /// <param name="EnName"></param>
        /// <returns></returns>
        public int GetEnName(StringBuilder EnName)
        {
            var model = new PiperSwapModel(nameof(GetEnName))
            {
                S1 = EnName,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            EnName.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 外国人国籍代码 符合GB/T2659-2000规定
        /// </summary>
        /// <param name="NationalityCode"></param>
        /// <returns></returns>
        public int GetNationalityCode(StringBuilder NationalityCode)
        {
            var model = new PiperSwapModel(nameof(GetNationalityCode))
            {
                S1 = NationalityCode,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            NationalityCode.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 港澳台通行证号码
        /// </summary>
        /// <param name="txzhm"></param>
        /// <returns></returns>
        public int GetTXZHM(StringBuilder txzhm)
        {
            var model = new PiperSwapModel(nameof(GetTXZHM))
            {
                S1 = txzhm,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            txzhm.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 港澳台通行证签发次数
        /// </summary>
        /// <param name="txzqfcs"></param>
        /// <returns></returns>
        public int GetTXZQFCS(StringBuilder txzqfcs)
        {
            var model = new PiperSwapModel(nameof(GetTXZQFCS))
            {
                S1 = txzqfcs,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            txzqfcs.Clear().Append(resObj.S1);
            return resObj.R;
        }
        /// <summary>
        /// 寻卡15693
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_Inventory(int Rhandle, byte[] resp)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_Inventory))
            {
                RH = Rhandle,
                A1 = resp,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, resp, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_15693_Read(int Rhandle, byte blockAddr, byte[] resp)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_15693_Read))
            {
                RH = Rhandle,
                B1 = blockAddr,
                A1 = resp,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, resp, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_15693_Write(int Rhandle, byte blockAddr, byte[] data, byte[] resp)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_15693_Write))
            {
                RH = Rhandle,
                B1 = blockAddr,
                A1 = data,
                A2 = resp,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, data, 0, resObj.A1.Length);
            Array.Copy(resObj.A2, 0, resp, 0, resObj.A2.Length);
            return resObj.R;
        }
        /// <summary>
        /// AFI
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_AFI(int Rhandle, byte[] data, byte[] resp)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_AFI))
            {
                RH = Rhandle,
                A1 = data,
                A2 = resp,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, data, 0, resObj.A1.Length);
            Array.Copy(resObj.A2, 0, resp, 0, resObj.A2.Length);
            return resObj.R;
        }
        /// <summary>
        /// DSFID
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="data"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_DSFID(int Rhandle, byte[] data, byte[] resp)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_DSFID))
            {
                RH = Rhandle,
                A1 = data,
                A2 = resp,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, data, 0, resObj.A1.Length);
            Array.Copy(resObj.A2, 0, resp, 0, resObj.A2.Length);
            return resObj.R;
        }
        /// <summary>
        /// 卡片信息
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_SystemInfor(int Rhandle, byte[] resp)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_SystemInfor))
            {
                RH = Rhandle,
                A1 = resp,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, resp, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// 锁块
        /// </summary>
        /// <param name="Rhandle"></param>
        /// <param name="blockAddr"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public int PICC_Reader_LockDataBlock(int Rhandle, byte blockAddr, byte[] resp)
        {
            var model = new PiperSwapModel(nameof(PICC_Reader_LockDataBlock))
            {
                RH = Rhandle,
                B1 = blockAddr,
                A1 = resp,
            };
            _writer.WriteLine(model.ToJson());
            var resObj = PiperSwapModel.GetModel(_reader.Value.ReadLine());
            Array.Copy(resObj.A1, 0, resp, 0, resObj.A1.Length);
            return resObj.R;
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            try { _process.Close(); } catch { }
            try { _piper.Dispose(); } catch { }
            try { _writer.Dispose(); } catch { }
            try { _reader.Value.Dispose(); } catch { }
        }
    }
}
