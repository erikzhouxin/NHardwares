using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.OnbonLedBxSDK;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace TestHDemoC.MSTester
{
    internal class OnbonLedSdkTestConfig
    {
        static OnbonLedSdkTestConfig()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // 注册编码格式
        }
        public const string SidePath = "C:\\Users\\Admin\\Desktop\\TestLed\\";
        public static byte[] SideFrame => ExtterCaller.GB2312Encoding.GetBytes(SidePath + "b12.png\0");
        public static byte[] FontStyle => ExtterCaller.GB2312Encoding.GetBytes("宋体\0");
        public static Tuble<int, byte[], ushort, ILedBxDualSdkProxy, Ping_data> Get()
        {
            Console.WriteLine("0.开始");
            var bxdualsdk = LedBxDualSdk.Create();
            bxdualsdk.BxDual_InitSdk();
            var address = Encoding.GetEncoding("GBK").GetBytes("192.168.0.199");
            ushort portRate = 5005;
            Console.WriteLine("1.连接LED");
            Ping_data data = new Ping_data();
            var err = bxdualsdk.BxDual_cmd_tcpPing(address, (ushort)portRate, ref data);
            if (err != 0) { return Get(err, address, portRate, bxdualsdk, data); }
            Console.WriteLine("2.连接信息");
            Console.WriteLine(data.GetJsonFormatString());
            Console.WriteLine("3.检查状态");
            ControllerStatus_G56 Status = new ControllerStatus_G56();
            err = bxdualsdk.BxDual_cmd_check_controllerStatus(address, portRate, ref Status);
            if (err != 0) { return Get(err, address, portRate, bxdualsdk, data); }
            Console.WriteLine("4.设置屏参");
            var cmb_ping_Color = LedBxDualSdk.GetEScreenColor(data.Color);
            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56(cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            if (err != 0) { return Get(err, address, portRate, bxdualsdk, data); }
            Console.WriteLine("5.删除所有节目");
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            for (int i = 0; i < 10; i++)
            {
                bxdualsdk.BxDual_program_deleteArea_G6((ushort)i);
            }
            err += bxdualsdk.BxDual_dynamicArea_DelArea_6G(address, portRate, 0xff);
            if (err != 0) { return Get(err, address, portRate, bxdualsdk, data); }
            return Get(err, address, portRate, bxdualsdk, data);
        }

        private static Tuble<int, byte[], ushort, ILedBxDualSdkProxy, Ping_data> Get(int res, byte[] address, ushort portRate, ILedBxDualSdkProxy bxdualsdk, Ping_data data)
        {
            return new Tuble<int, byte[], ushort, ILedBxDualSdkProxy, Ping_data>(res, address, portRate, bxdualsdk, data);
        }

        public static String GetPath(string file)
        {
            return SidePath + file;
        }
        public static byte[] GetBytes(string file)
        {
            return ExtterCaller.GB2312Encoding.GetBytes(file);
        }
        public static byte[] GetPaths(string file) => ExtterCaller.GB2312Encoding.GetBytes(GetPath(file));

        /// <summary>
        /// 获取字节数组的句柄
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static IntPtr GetIntPtr(byte[] bytes)
        {
            var ptr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, ptr, bytes.Length);
            return ptr;
        }
        /// <summary>
        /// 获取字节数组的句柄
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static IntPtr GetIntPtr(string bytes)
        {
            return GetIntPtr(ExtterCaller.GB2312Encoding.GetBytes(bytes));
        }
    }
}
