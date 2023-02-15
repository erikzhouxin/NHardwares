using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// BX-5/BX-6的SDK
    /// </summary>
    public static class LedBxDualSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "bx_sdk_dual.dll";
        /// <summary>
        /// 服务SDK文件名称
        /// </summary>
        public const string ServerFileName = "bx_sdk_dual_server.dll";
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\onbonledbxsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String BaseServerFullName { get; } = Path.GetFullPath(ServerFileName);
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String ServerFullName { get; } = Path.Combine(DllFullPath, ServerFileName);
        static Lazy<ILedBxDualSdkProxy> _bxDualSdk = new Lazy<ILedBxDualSdkProxy>(() => new LedBxDualSdkLoader(), true);
        static Lazy<ILedBxServerSdkProxy> _bxServerSdk = new Lazy<ILedBxServerSdkProxy>(() => new LedBxServerSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static LedBxDualSdk()
        {
            Directory.CreateDirectory(DllFullPath);
            if (Environment.Is64BitProcess)
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X64_bx_sdk_dual))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_bx_sdk_dual, Path.Combine(DllFullPath, "bx_sdk_dual.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_bx_sdk_dual_server, Path.Combine(DllFullPath, "bx_sdk_dual_server.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_cairo_1_14_6, Path.Combine(DllFullPath, "cairo-1.14.6.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_freetype265, Path.Combine(DllFullPath, "freetype265.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libpng16, Path.Combine(DllFullPath, "libpng16.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_pixman_0_34_0, Path.Combine(DllFullPath, "pixman-0.34.0.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_zlibwapi, Path.Combine(DllFullPath, "zlibwapi.dll"));
                }
            }
            else
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X86_bx_sdk_dual))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_bx_sdk_dual, Path.Combine(DllFullPath, "bx_sdk_dual.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_bx_sdk_dual_server, Path.Combine(DllFullPath, "bx_sdk_dual_server.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_cairo_1_14_6, Path.Combine(DllFullPath, "cairo-1.14.6.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_freetype, Path.Combine(DllFullPath, "freetype.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_freetype265, Path.Combine(DllFullPath, "freetype265.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_libpng16, Path.Combine(DllFullPath, "libpng16.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_zlibwapi, Path.Combine(DllFullPath, "zlibwapi.dll"));

                    //SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcp100, Path.Combine(DllFullPath, "msvcp100.dll"));
                    //SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcp100d, Path.Combine(DllFullPath, "msvcp100d.dll"));
                    //SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcr100, Path.Combine(DllFullPath, "msvcr100.dll"));
                    //SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcr110, Path.Combine(DllFullPath, "msvcr110.dll"));
                }
            }
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static ILedBxDualSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _bxDualSdk.Value; }
            if (!File.Exists(BaseDllFullName))
            { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return LedBxDualSdkDller.Instance;
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static ILedBxServerSdkProxy CreateServer(bool isBase = false)
        {
            if (!isBase) { return _bxServerSdk.Value; }
            if (!File.Exists(BaseServerFullName)) { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return LedBxServerSdkDller.Instance;
        }

        #region // 辅助方法
        /// <summary>
        /// struct转换为byte[]
        /// </summary>
        /// <param name="structObj"></param>
        /// <returns></returns>
        public static byte[] StructToBytes(object structObj)
        {
            int size = Marshal.SizeOf(structObj);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structObj, buffer, false);
                byte[] bytes = new byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        /// <summary>
        /// byte[]转换为Intptr
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static IntPtr BytesToIntptr(byte[] bytes)
        {
            GCHandle hObject = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();
            if (hObject.IsAllocated) { hObject.Free(); }
            return pObject;
        }
        /// <summary>
        /// byte[]转换为string  回读数据使用
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] bytes)
        {
            string str = "";
            for (int a = 0; a < bytes.Length; a++)
            {
                if (a == 0)
                {
                    str = Convert.ToUInt16(bytes[a]).ToString();
                }
                else
                {
                    str += "." + Convert.ToUInt16(bytes[a]).ToString();
                }
            }
            return str;
        }
        /// <summary>
        /// byte转换为BCD码
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static byte ConvertBCD(byte b)
        {
            //高四位  
            byte b1 = (byte)(b / 10);
            //低四位  
            byte b2 = (byte)(b % 10);
            return (byte)((b1 << 4) | b2);
        }
        /// <summary>  
        /// 将BCD一字节数据转换到byte 十进制数据  
        /// </summary>  
        /// <param name="b" />字节数  
        /// <returns>返回转换后的BCD码</returns>  
        public static byte ConvertBCDToInt(byte b)
        {
            //高四位  
            byte b1 = (byte)((b >> 4) & 0xF);
            //低四位  
            byte b2 = (byte)(b & 0xF);

            return (byte)(b1 * 10 + b2);
        }
        /// <summary>
        /// 生成字符
        /// </summary>
        /// <param name="b">是否有复杂字符</param>
        /// <param name="n">生成的字符串长度</param>
        /// <returns></returns>
        public static string GetStr(bool b, int n)
        {

            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (b == true)
            {
                str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";//复杂字符
            }
            StringBuilder SB = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                SB.Append(str.Substring(rd.Next(0, str.Length), 1));
            }
            return SB.ToString();

        }
        /// <summary>
        /// 错误类型
        /// </summary>
        public enum ErrorType
        {
            ERR_NO = 0,
            ERR_OUTOFGROUP = 1,
            ERR_NOCMD = 2,
            ERR_BUSY = 3,
            ERR_MEMORYVOLUME = 4,
            ERR_CHECKSUM = 5,
            ERR_FILENOTEXIST = 6,
            ERR_FLASH = 7,
            ERR_FILE_DOWNLOAD = 8,
            ERR_FILE_NAME = 9,
            ERR_FILE_TYPE = 10,
            ERR_FILE_CRC16 = 11,
            ERR_FONT_NOT_EXIST = 12,
            ERR_FIRMWARE_TYPE = 13,
            ERR_DATE_TIME_FORMAT = 14,
            ERR_FILE_EXIST = 15,
            ERR_FILE_BLOCK_NUM = 16,
            ERR_CONTROLLER_TYPE = 17,
            ERR_SCREEN_PARA = 18,
            ERR_CONTROLLER_ID = 19,
            ERR_USER_SECRET = 20,
            ERR_OLD_USER_SECRET = 21,
            ERR_PHY1_NO_SECRET = 22,
            ERR_PHY1_USE_SECRET = 23,
            ERR_RTC = 24,
            ERR_CMD_PARA = 25,
            ERR_CASCADE_COMM = 26,
            ERR_NO_BATTLE_AREA = 27,
            ERR_NO_TIMER_AREA = 28,
            ERR_FPGA_COMM = 29,
            ERR_SET_MODBUS_PARA = 60,

            ERR_TCP = -1,
        }
        /// <summary>
        /// 获取错误
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public static string GetError(int err)
        {
            switch ((ErrorType)err)
            {
                case ErrorType.ERR_TCP: return "通讯错误";
                case ErrorType.ERR_NO: return "没有错误";
                case ErrorType.ERR_OUTOFGROUP: return "命令组错误";
                case ErrorType.ERR_NOCMD: return "此命令不存在";
                case ErrorType.ERR_BUSY: return "控制器忙";
                case ErrorType.ERR_MEMORYVOLUME: return "存储器容量越界";
                case ErrorType.ERR_CHECKSUM: return "数据包 CRC 校验错误";
                case ErrorType.ERR_FILENOTEXIST: return "此文件不存在";
                case ErrorType.ERR_FLASH: return "Flash 访问错误";
                case ErrorType.ERR_FILE_DOWNLOAD: return "文件下载错误";
                case ErrorType.ERR_FILE_NAME: return "文件名错误";
                case ErrorType.ERR_FILE_TYPE: return "文件类型错误";
                case ErrorType.ERR_FILE_CRC16: return "文件校验错误";
                case ErrorType.ERR_FONT_NOT_EXIST: return "字库文件不存在";
                case ErrorType.ERR_FIRMWARE_TYPE: return "Firmware 与控制器类型不匹配";
                case ErrorType.ERR_DATE_TIME_FORMAT: return "日期时间格式错误 ";
                case ErrorType.ERR_FILE_EXIST: return "此文件已存在";
                case ErrorType.ERR_FILE_BLOCK_NUM: return "文件 Block 号错误";
                case ErrorType.ERR_CONTROLLER_TYPE: return "控制器类型不匹配";
                case ErrorType.ERR_SCREEN_PARA: return "控制器参数越界或错误";
                case ErrorType.ERR_CONTROLLER_ID: return "控制器 ID 错误";
                case ErrorType.ERR_USER_SECRET: return "用户密码错误";
                case ErrorType.ERR_OLD_USER_SECRET: return "设置新密码时，输入的旧密码不正确";
                case ErrorType.ERR_PHY1_NO_SECRET: return "底层无密码，上位机有密码";
                case ErrorType.ERR_PHY1_USE_SECRET: return " 底层有密码，上位机无密码";
                case ErrorType.ERR_RTC: return "时钟芯片故障";
                case ErrorType.ERR_CMD_PARA: return "命令参数错误";
                case ErrorType.ERR_CASCADE_COMM: return "级联系统通讯故障";
                case ErrorType.ERR_NO_BATTLE_AREA: return "无战斗时间区域";
                case ErrorType.ERR_NO_TIMER_AREA: return "无秒表区域";
                case ErrorType.ERR_FPGA_COMM: return "与后级扫描模块通讯故障";
                case ErrorType.ERR_SET_MODBUS_PARA: return "设置 MODBUS 参数错误";
                default: return "未知错误：" + err;
            }
        }
        /// <summary>
        /// 获取错误
        /// </summary>
        /// <param name="errorType"></param>
        /// <returns></returns>
        public static string GetError(this ErrorType errorType) => GetError((int)errorType);
        /// <summary>
        /// byte数组中取int数值，本方法适用于(低位在前，高位在后)的顺序，和和intToBytes（）配套使用
        /// </summary>
        /// <param name="src">byte数组</param>
        /// <param name="offset">从数组的第offset位开始 </param>
        /// <returns>int数值 </returns>
        public static int BytesToInt(byte[] src, int offset)
        {
            int value;
            value = (int)((src[offset] & 0xFF)
                    | ((src[offset + 1] & 0xFF) << 8)
                    | ((src[offset + 2] & 0xFF) << 16)
                    | ((src[offset + 3] & 0xFF) << 24));
            return value;
        }
        /// <summary>
        /// byte数组中取int数值，本方法适用于(低位在后，高位在前)的顺序。和intToBytes2（）配套使用
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int BytesToInt2(byte[] src, int offset)
        {
            int value;
            value = (int)(((src[offset] & 0xFF) << 24)
                    | ((src[offset + 1] & 0xFF) << 16)
                    | ((src[offset + 2] & 0xFF) << 8)
                    | (src[offset + 3] & 0xFF));
            return value;
        }
        #endregion
    }

}
