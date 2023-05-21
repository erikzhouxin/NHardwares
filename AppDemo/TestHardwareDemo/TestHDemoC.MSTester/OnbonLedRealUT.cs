using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.OnbonLedBxSDK;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace TestHDemoC.MSTester
{
    /// <summary>
    /// 仰邦LED真实测试
    /// </summary>
    [TestClass]
    public class OnbonLedRealUT
    {
        static OnbonLedRealUT()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // 注册编码格式
        }
        static byte[] SideFrame => Encoding.Default.GetBytes("C:\\Users\\Admin\\Desktop\\b10.png\0");
        [TestMethod]
        public void TestPicture()
        {
            Console.WriteLine("0.开始");
            var bxdualsdk = LedBxDualSdk.Create();
            bxdualsdk.BxDual_InitSdk();
            var address = Encoding.GetEncoding("GBK").GetBytes("192.168.0.199");
            ushort portRate = 5005;
            Ping_data data = new Ping_data();
            Console.WriteLine("1.连接LED");
            var err = bxdualsdk.BxDual_cmd_tcpPing(address, (ushort)portRate, ref data);
            if (err != 0) { return; }
            Console.WriteLine("2.连接信息");
            Console.WriteLine(data.GetJsonFormatString());
            Console.WriteLine("3.检查状态");
            ControllerStatus_G56 Status = new ControllerStatus_G56();
            err = bxdualsdk.BxDual_cmd_check_controllerStatus(address, portRate, ref Status);
            if (err != 0) { return; }
            Console.WriteLine("4.设置屏参");
            var cmb_ping_Color = LedBxDualSdk.GetEScreenColor(data.Color);
            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56(cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            if (err != 0) { return; }
            Console.WriteLine("5.删除所有节目");
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            err += bxdualsdk.BxDual_dynamicArea_DelArea_6G(address, portRate, 0);
            if (err != 0) { return; }
            Console.WriteLine("6.添加节目");
            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header = new EQprogramHeader_G6
            {
                FileType = 0x00,
                ProgramID = 0,
                ProgramStyle = 0x00,
                ProgramPriority = 0x00,
                ProgramPlayTimes = 1,
                ProgramTimeSpan = 600,
                SpecialFlag = 0,
                CommExtendParaLen = 0x00,
                ScheduNum = 0,
                LoopValue = 0,
                Intergrate = 0x00,
                TimeAttributeNum = 0x00,
                TimeAttribute0Offset = 0x0000,
                ProgramWeek = 0xff,
                ProgramLifeSpan_sy = 0xffff,
                ProgramLifeSpan_sm = 0x03,
                ProgramLifeSpan_sd = 0x14,
                ProgramLifeSpan_ey = 0xffff,
                ProgramLifeSpan_em = 0x13,
                ProgramLifeSpan_ed = 0x14,
                PlayPeriodGrpNum = 0,
            };
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            if (err != 0) { return; }
            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader = new EQareaHeader_G6
            {
                AreaType = 0x00,
                AreaX = 4,
                AreaY = 4,
                AreaWidth = (ushort)(data.ScreenWidth - 8),
                AreaHeight = 20,
                BackGroundFlag = 0x00,
                Transparency = 0,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G { SoundData = IntPtr.Zero }, //该语音属性在节目无效
            };
            Console.WriteLine("8.添加节目区域");
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
            if (err != 0) { return; }
            //err = AddProgramFrame(bxdualsdk); // 添加边框
            if (err != 0) { return; }
            Console.WriteLine("A.添加图文区域文本");
            //第四步，添加显示内容，此处为图文分区0添加字符串
            EQpageHeader_G6 pheader = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = (byte)E_DisplayMode.MoveLefts,//移动模式
                ClearMode = 0x00,
                Speed = 30,//速度
                StayTime = 600,//停留时间
                RepeatTime = 1,
                ValidLen = 0,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eMULTILINE,
                fontSize = 16,
                color = (uint)0x01,
                fontBold = 1,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 2,
                Halign = 2,
            };
            var fontStyle = Encoding.GetEncoding("GB2312").GetBytes("宋体\0");
            var txtBytes = Encoding.GetEncoding("GB2312").GetBytes("123456\0");
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(0, txtBytes, fontStyle, ref pheader);
            if (err != 0) { return; }
            Console.WriteLine("B.开始发送节目");
            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            if (err != 0) { return; }
            Console.WriteLine("C.删除其他节目");
            //err = bxdualsdk.BxDual_program_deleteProgram_G6();
            if (err != 0) { return; }
            Console.WriteLine("D.开始写文件");
            //err = bxdualsdk.BxDual_set_packetLen(20480);
            err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(address, portRate);
            if (err != 0) { return; }
            Console.WriteLine("D.写文件到控制");
            err = bxdualsdk.BxDual_cmd_ofsWriteFile(address, portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
            if (err != 0) { return; }
            Console.WriteLine("D.写文件到控制");
            err = bxdualsdk.BxDual_cmd_ofsWriteFile(address, portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            if (err != 0) { return; }
            Console.WriteLine("D.结束写文件");
            err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            if (err != 0) { return; }
            Console.WriteLine("E.释放缓冲区");
            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            if (err != 0) { return; }
            Console.WriteLine("F.结束");
        }

        private static int AddProgramFrame(ILedBxDualSdkProxy bxdualsdk)
        {
            Console.WriteLine("7.添加节目边框");
            Console.WriteLine("9.添加区域边框");
            EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
            {
                FrameDispStype = (byte)E_FrameDisplayMode.Clockwise,    //边框显示方式
                FrameDispSpeed = 0x10,    //边框显示速度
                FrameMoveStep = 0x01,     //边框移动步长
                FrameUnitLength = 2,   //边框组元长度
                FrameUnitWidth = 2,    //边框组元宽度
                FrameDirectDispBit = 0, //上下左右边框显示标志位，目前只支持6QX-M卡 
            };
            //bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, SideFrame);

            //EQareaframeHeader afheader = new EQareaframeHeader
            //{
            //    AreaFFlag = 0x01,
            //    AreaFDispStyle = (int)E_FrameDisplayMode.Blink,
            //    AreaFDispSpeed = 0x10,
            //    AreaFMoveStep = 0x01,
            //    AreaFWidth = 0,
            //    AreaFBackup = 0,
            //};
            //return bxdualsdk.BxDual_program_picturesAreaAddFrame(0, ref afheader, SideFrame);

            return bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, SideFrame);
        }

        /// <summary>
        /// 一次向一个动态区发送/更新多条信息（文字或图片）及语音
        /// </summary>
        [TestMethod]
        public void DynamicArea_pages_1()
        {
            Console.WriteLine("0.开始");
            var bxdualsdk = LedBxDualSdk.Create();
            bxdualsdk.BxDual_InitSdk();
            var address = Encoding.GetEncoding("GBK").GetBytes("192.168.0.199");
            ushort portRate = 5005;
            //5E系列支持 0-3，6E，6Q系列支持 0-31
            byte AreaId = 0;

            byte RunMode = 0;
            ushort Timeout = 10;
            byte RelateAllPro = 0;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = new ushort[] { 0 };
            byte ImmePlay = 1;
            //动态区域左上角在LED显示屏的位置/坐标；
            ushort AreaX = 0;
            ushort AreaY = 0;
            //动态区域的宽度，高度
            ushort Width = 128;
            ushort Height = 96;

            int err = 0;
            byte DisplayMode = 2;
            byte Speed = 1;
            ushort StayTime = 100;
            byte RepeatTime = 0;
            E_arrMode arrMode = 0;
            ushort fontSize = 10;
            uint color = 1;
            byte fontBold = 0;
            byte fontItalic = 0;
            E_txtDirection tdirection = 0;
            ushort txtSpace = 0;
            byte Valign = 1;
            byte Halign = 1;
            EQSound_6G stSoundData = new EQSound_6G();

            EQscreenframeHeader_G6 oFrame = new EQscreenframeHeader_G6
            {
                FrameDispStype = 0x03,    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
                FrameDispSpeed = 0x10,    //边框显示速度
                FrameMoveStep = 0x01,     //边框移动步长，单位为点，此参 数范围为 1~16 
                FrameUnitLength = 2,   //边框组元长度
                FrameUnitWidth = 2,    //边框组元宽度
                FrameDirectDispBit = 0//上下左右边框显示标志位，目前只支持6QX-M卡 
            };//暂时不支持
            BxAreaFrmae_Dynamic_G6 Frame = new BxAreaFrmae_Dynamic_G6
            {
                AreaFFlag = 0,
                oAreaFrame = oFrame,
                pStrFramePathFile = Encoding.Default.GetBytes("C:\\Users\\Admin\\Desktop\\b10.png\0"),
            };
            DynamicAreaBaseInfo_5G pheader = new DynamicAreaBaseInfo_5G
            {
                nType = 0x01,
                DisplayMode = DisplayMode,
                ClearMode = 0x01,
                Speed = Speed,
                StayTime = StayTime,
                RepeatTime = RepeatTime
            };
            var oFont = new EQfontData()
            {
                arrMode = arrMode,
                fontSize = fontSize,
                color = color,
                fontBold = fontBold,
                fontItalic = fontItalic,
                tdirection = tdirection,
                txtSpace = txtSpace,
                Valign = Valign,
                Halign = Halign,
            };
            pheader.oFont = oFont;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader.fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("123456789");
            pheader.strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, pheader.strAreaTxtContent, str.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("C:\\Users\\Admin\\Desktop\\b11.png\0");
            pheader.filePath = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, pheader.filePath, img.Length);
            var Params = new DynamicAreaBaseInfo_5G[1];
            Params[0] = pheader;
            bxdualsdk.BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            //网口
            err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_6G_V2(address, portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId, RunMode, Timeout, RelateAllPro,
         RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, Params, ref stSoundData);

            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
        }
        /// <summary>
        /// 单区域图片，能设置特效
        /// </summary>
        [TestMethod]
        public void dynamicArea_png_1()
        {
            Console.WriteLine("0.开始");
            var bxdualsdk = LedBxDualSdk.Create();
            bxdualsdk.BxDual_InitSdk();
            var address = Encoding.GetEncoding("GBK").GetBytes("192.168.0.199");
            ushort portRate = 5005;

            int err = 0;
            //5E系列支持 0-3，6E，6Q系列支持 0-31
            byte AreaId = 0;
            //动态区域左上角在LED显示屏的位置/坐标；
            ushort AreaX = 0;
            ushort AreaY = 0;
            ushort Width = 128;
            ushort Height = 96;
            //要显示的文本内容
            IntPtr strAreaTxtContent = IntPtr.Zero;

            EQpageHeader_G6 pheader = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = 7,
                ClearMode = 0x00,
                Speed = 15,
                StayTime = 600,
                RepeatTime = 1,
                ValidLen = 0,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eSINGLELINE,
                fontSize = 12,
                color = (uint)0x01,
                fontBold = 0,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 1,
                Halign = 1
            };
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("C:\\Users\\Admin\\Desktop\\b11.png\0");
            var img = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, img, str.Length);
            Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
            //网口
            //动态区优先播放，节目停止播放
            err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_6G(address, portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId, AreaX, AreaY,
                                                      Width, Height, ref pheader, img);
        }
    }
}
