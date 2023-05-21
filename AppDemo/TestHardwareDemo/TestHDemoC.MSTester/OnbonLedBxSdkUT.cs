using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.OnbonLedBxSDK;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace TestHDemoC.MSTester
{
    [TestClass]
    public class OnbonLedBxSdkUT
    {
        static ILedBxDualSdkProxy bxdualsdk;
        //控制卡IP
        public static byte[] address;
        //控制卡端口
        public static ushort portRate;
        //通讯方式  true=网口  false=串口
        public static Boolean isNetwork;

        static OnbonLedBxSdkUT()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // 注册编码格式
            bxdualsdk = LedBxDualSdk.Create();
            isNetwork = true;
            if (isNetwork)
            {
                address = Encoding.GetEncoding("GBK").GetBytes("192.168.0.199");
                portRate = 5005;
            }
            else
            {
                //串口号 "COM1",大于9以上做特殊处理，如"\\\\.\\COM17"
                address = Encoding.GetEncoding("GBK").GetBytes("COM3");
                //串口波特率 1：9600  2：57600
                portRate = 2;
            }
            int err = bxdualsdk.BxDual_InitSdk();
            if (err != 0) { throw new Exception($"LED的SDK初始化失败{err}"); }
        }
        [TestMethod]
        public void TestInitialServer()
        {
            Console.WriteLine(TestTry.IsDebugMode);
            Console.WriteLine(Environment.Is64BitProcess);
            var proxy = LedBxDualSdk.CreateServer();
            proxy.BxDual_InitSdk();
        }
        /// <summary>
        /// BX-6代控制卡发送节目文本
        /// </summary>
        [TestMethod]
        public void TestSendProgramTxt6()
        {
            //Send_program_txt_6(); // 发送节目文本
            //Send_program_areas_6(); // 多区域发送节目文本
            Send_program_txt_6_1();
        }
        /// <summary>
        /// BX-6代控制卡发送节目文本
        /// </summary>
        public static void Send_program_txt_6()
        {
            Console.WriteLine("开始编辑节目" + DateTime.Now.ToString());
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = 0;
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);
            }
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            Console.WriteLine("\r\n");
            if (err != 0) { return; }

            var cmb_ping_Color = LedBxDualSdk.GetEScreenColor(data.Color);
            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56(cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);

            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header = new EQprogramHeader_G6
            {
                FileType = 0x00,
                ProgramID = 0,
                ProgramStyle = 0x00,
                ProgramPriority = 0x00,
                ProgramPlayTimes = 1,
                ProgramTimeSpan = 0,
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
                ProgramLifeSpan_em = 0x03,
                ProgramLifeSpan_ed = 0x14,
                PlayPeriodGrpNum = 0
            };
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);
            //节目添加播放时段,目前仅支持一组时间，多组不支持
            if (false)
            {
                EQprogrampTime_G56 Time = new EQprogrampTime_G56
                {
                    StartHour = 0x17,
                    StartMinute = 0x29,
                    StartSecond = 0x00,
                    EndHour = 0x17,
                    EndMinute = 0x30,
                    EndSecond = 0x00
                };

                EQprogramppGrp_G56 headerGrp;
                headerGrp.playTimeGrpNum = 1;
                headerGrp.timeGrp0 = Time;
                headerGrp.timeGrp1 = Time;
                headerGrp.timeGrp2 = Time;
                headerGrp.timeGrp3 = Time;
                headerGrp.timeGrp4 = Time;
                headerGrp.timeGrp5 = Time;
                headerGrp.timeGrp6 = Time;
                headerGrp.timeGrp7 = Time;
                err = bxdualsdk.BxDual_program_addPlayPeriodGrp_G6(ref headerGrp);
                Console.WriteLine("program_addPlayPeriodGrp:" + err);
            }
            //节目添加边框
            if (true)
            {
                EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
                {
                    FrameDispStype = 0x01,    //边框显示方式
                    FrameDispSpeed = 0x3B,    //边框显示速度
                    FrameMoveStep = 0x01,     //边框移动步长
                    FrameUnitLength = 2,   //边框组元长度
                    FrameUnitWidth = 2,    //边框组元宽度
                    FrameDirectDispBit = 0//上下左右边框显示标志位，目前只支持6QX-M卡 
                };
                byte[] img = Encoding.Default.GetBytes("F:\\cenIdea.git\\drive-pc\\LED显示SDK\\BX_05_06_SDK_20221107\\bx.dual.C#\\lib\\黄10.png\0");
                bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, img);
            }

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader = new EQareaHeader_G6
            {
                AreaType = 0,
                AreaX = 0,
                AreaY = 0,
                AreaWidth = data.ScreenWidth,
                AreaHeight = data.ScreenHeight,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G { SoundData = IntPtr.Zero }, //该语音属性在节目无效
            };
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //区域添加边框
            if (false)
            {
                EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
                {
                    FrameDispStype = 0x01,    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
                    FrameDispSpeed = 0x10,    //边框显示速度
                    FrameMoveStep = 0x01,     //边框移动步长，单位为点，此参 数范围为 1~16 
                    FrameUnitLength = 2,   //边框组元长度
                    FrameUnitWidth = 2,    //边框组元宽度
                    FrameDirectDispBit = 0//上下左右边框显示标志位，目前只支持6QX-M卡 
                };
                byte[] img = Encoding.Default.GetBytes("F:\\cenIdea.git\\drive-pc\\LED显示SDK\\BX_05_06_SDK_20221107\\bx.dual.C#\\lib\\黄10.png\0");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }

            //第四步，添加显示内容，此处为图文分区0添加字符串
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体\0");
            IntPtr font = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, font, Font.Length);
            byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("测试发送1\0");
            IntPtr str = Marshal.AllocHGlobal(strAreaTxtContent.Length);
            Marshal.Copy(strAreaTxtContent, 0, str, strAreaTxtContent.Length);
            EQpageHeader_G6 pheader = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = 0x4,//移动模式
                ClearMode = 0x01,
                Speed = 60,//速度
                StayTime = 0,//停留时间
                RepeatTime = 1,
                ValidLen = 0,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eSINGLELINE,
                fontSize = 50,
                color = (uint)0x01,
                fontBold = 1,
                fontItalic = 0,
                tdirection = E_txtDirection.pROTATERIGHT,
                txtSpace = 0,
                Valign = 0,
                Halign = 0
            };
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(0, strAreaTxtContent, Font, ref pheader);
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);

            //添加语音,该功能仅部分控制卡支持，一个节目只能在一个图文区添加语音播报
            if (false)
            {
                byte[] soundstr = Encoding.GetEncoding("gb2312").GetBytes("请张三到1号窗口取药");
                EQPicAreaSoundHeader_G6 psoundheader;
                psoundheader.SoundPerson = 3;
                psoundheader.SoundVolum = 5;
                psoundheader.SoundSpeed = 5;
                psoundheader.SoundDataMode = 0;
                psoundheader.SoundReplayTimes = 0;
                psoundheader.SoundReplayDelay = 1000;
                psoundheader.SoundReservedParaLen = 3;
                psoundheader.Soundnumdeal = 1;
                psoundheader.Soundlanguages = 1;
                psoundheader.Soundwordstyle = 1;
                err = bxdualsdk.BxDual_program_pictureAreaEnableSound_G6(0, psoundheader, soundstr);
                Console.WriteLine("program_pictureAreaEnableSound_G6:" + err);
            }

            Console.WriteLine("开始发送节目" + DateTime.Now.ToString());
            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            //err = bxdualsdk.BxDual_set_packetLen(20480);
            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                if (err != 0) { return; }
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                if (err != 0) { return; }
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                if (err != 0) { return; }
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                if (err != 0) { return; }
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                if (err != 0) { return; }
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                if (err != 0) { return; }
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                if (err != 0) { return; }
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                if (err != 0) { return; }
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                if (err != 0) { return; }
            }

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
            Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
        }
        /// <summary>
        /// BX-6代控制卡发送节目文本
        /// </summary>
        public static void Send_program_txt_6_1()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = 0;
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);
            }
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            Console.WriteLine("\r\n");

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);
            //节目添加播放时段,目前仅支持一组时间，多组不支持
            if (false)
            {
                EQprogrampTime_G56 Time;
                Time.StartHour = 0x17;
                Time.StartMinute = 0x29;
                Time.StartSecond = 0x00;
                Time.EndHour = 0x17;
                Time.EndMinute = 0x30;
                Time.EndSecond = 0x00;

                EQprogramppGrp_G56 headerGrp;
                headerGrp.playTimeGrpNum = 1;
                headerGrp.timeGrp0 = Time;
                headerGrp.timeGrp1 = Time;
                headerGrp.timeGrp2 = Time;
                headerGrp.timeGrp3 = Time;
                headerGrp.timeGrp4 = Time;
                headerGrp.timeGrp5 = Time;
                headerGrp.timeGrp6 = Time;
                headerGrp.timeGrp7 = Time;
                err = bxdualsdk.BxDual_program_addPlayPeriodGrp_G6(ref headerGrp);
                Console.WriteLine("program_addPlayPeriodGrp:" + err);
            }
            //节目添加边框
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
                bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, img);
            }

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 32;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();//该语音属性在节目无效
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            byte[] t = new byte[1];
            t[0] = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //区域添加边框
            if (true)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长，单位为点，此参 数范围为 1~16 
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("E:\\黄10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }

            //第四步，添加显示内容，此处为图文分区0添加字符串
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            IntPtr font = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, font, Font.Length);
            byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("123456\0");
            IntPtr str = Marshal.AllocHGlobal(strAreaTxtContent.Length);
            Marshal.Copy(strAreaTxtContent, 0, str, strAreaTxtContent.Length);
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;//移动模式
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;//速度
            pheader.StayTime = 0;//停留时间
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 0;
            pheader.Halign = 0;
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(0, strAreaTxtContent, Font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);
            EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0;
            aheader1.AreaX = 32;
            aheader1.AreaY = 0;
            aheader1.AreaWidth = 32;
            aheader1.AreaHeight = 32;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            aheader1.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(1, ref aheader1);  //添加图文区域
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //区域添加边框
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长，单位为点，此参 数范围为 1~16 
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("E:\\黄10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(1, ref sfheader, img);
            }

            //第四步，添加显示内容，此处为图文分区0添加字符串
            EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x02;//移动模式
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 10;//速度
            pheader1.StayTime = 0;//停留时间
            pheader1.RepeatTime = 1;
            pheader1.ValidLen = 0;
            pheader1.CartoonFrameRate = 0x00;
            pheader1.BackNotValidFlag = 0x00;
            pheader1.arrMode = E_arrMode.eMULTILINE;
            pheader1.fontSize = 12;
            pheader1.color = (uint)0x01;
            pheader1.fontBold = 0;
            pheader1.fontItalic = 0;
            pheader1.tdirection = E_txtDirection.pNORMAL;
            pheader1.txtSpace = 0;
            pheader1.Valign = 0;
            pheader1.Halign = 0;
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(1, strAreaTxtContent, Font, ref pheader1);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);

            //添加语音,该功能仅部分控制卡支持，一个节目只能在一个图文区添加语音播报
            if (false)
            {
                byte[] soundstr = Encoding.GetEncoding("gb2312").GetBytes("请张三到1号窗口取药");
                EQPicAreaSoundHeader_G6 psoundheader;
                psoundheader.SoundPerson = 3;
                psoundheader.SoundVolum = 5;
                psoundheader.SoundSpeed = 5;
                psoundheader.SoundDataMode = 0;
                psoundheader.SoundReplayTimes = 0;
                psoundheader.SoundReplayDelay = 1000;
                psoundheader.SoundReservedParaLen = 3;
                psoundheader.Soundnumdeal = 1;
                psoundheader.Soundlanguages = 1;
                psoundheader.Soundwordstyle = 1;
                err = bxdualsdk.BxDual_program_pictureAreaEnableSound_G6(0, psoundheader, soundstr);
                Console.WriteLine("program_pictureAreaEnableSound_G6:" + err);
            }

            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            byte[] strAreaTxtContent1 = Encoding.GetEncoding("GBK").GetBytes("123sdd是的\0");
            IntPtr str1 = Marshal.AllocHGlobal(strAreaTxtContent1.Length);
            Marshal.Copy(strAreaTxtContent1, 0, str1, strAreaTxtContent1.Length);
            EQpageHeader_G6 pheader2;
            pheader2.PageStyle = 0x00;
            pheader2.DisplayMode = 0x02;//移动模式
            pheader2.ClearMode = 0x01;
            pheader2.Speed = 10;//速度
            pheader2.StayTime = 0;//停留时间
            pheader2.RepeatTime = 1;
            pheader2.ValidLen = 0;
            pheader2.CartoonFrameRate = 0x00;
            pheader2.BackNotValidFlag = 0x00;
            pheader2.arrMode = E_arrMode.eSINGLELINE;
            pheader2.fontSize = 12;
            pheader2.color = (uint)0x01;
            pheader2.fontBold = 0;
            pheader2.fontItalic = 0;
            pheader2.tdirection = E_txtDirection.pNORMAL;
            pheader2.txtSpace = 0;
            pheader2.Valign = 2;
            pheader2.Halign = 2;
            bxdualsdk.BxDual_program_picturesAreaChangeTxt_G6(0, str1, ref pheader2);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);

            program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);
            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
        /// <summary>
        /// BX-5代控制卡发送节目文本
        /// </summary>
        public static void Send_program_txt_5()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = 0;
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);
            }
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x05;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x04;
            header.ProgramLifeSpan_ed = 0x12;
            err = bxdualsdk.BxDual_program_addProgram(ref header);
            Console.WriteLine("bxDual_program_addProgram:" + err);
            //节目添加边框属性
            if (false)
            {
                EQscreenframeHeader sfheader;
                sfheader.FrameDispFlag = 0x01;
                sfheader.FrameDispStyle = 0x01;
                sfheader.FrameDispSpeed = 0x10;
                sfheader.FrameMoveStep = 0x01;
                sfheader.FrameWidth = 2;
                sfheader.FrameBackup = 0;
                byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
                bxdualsdk.BxDual_program_addFrame(ref sfheader, img);
            }
            //节目添加播放时段,目前仅支持一组时间，多组不支持，Time有效，Time1无效
            if (false)
            {
                EQprogrampTime_G56 Time;
                Time.StartHour = 0x13;
                Time.StartMinute = 0x25;
                Time.StartSecond = 0x00;
                Time.EndHour = 0x13;
                Time.EndMinute = 0x26;
                Time.EndSecond = 0x00;
                EQprogrampTime_G56 Time1;
                Time1.StartHour = 0x13;
                Time1.StartMinute = 0x27;
                Time1.StartSecond = 0x00;
                Time1.EndHour = 0x13;
                Time1.EndMinute = 0x28;
                Time1.EndSecond = 0x00;

                EQprogramppGrp_G56 headerGrp;
                headerGrp.playTimeGrpNum = 2;
                headerGrp.timeGrp0 = Time;
                headerGrp.timeGrp1 = Time1;
                headerGrp.timeGrp2 = Time;
                headerGrp.timeGrp3 = Time;
                headerGrp.timeGrp4 = Time;
                headerGrp.timeGrp5 = Time;
                headerGrp.timeGrp6 = Time;
                headerGrp.timeGrp7 = Time;
                err = bxdualsdk.BxDual_program_addPlayPeriodGrp(ref headerGrp);
                Console.WriteLine("program_addPlayPeriodGrp:" + err);
            }

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);
            //区域添加边框
            if (false)
            {
                EQareaframeHeader afheader;
                afheader.AreaFFlag = 0x01;
                afheader.AreaFDispStyle = 0x01;
                afheader.AreaFDispSpeed = 0x08;
                afheader.AreaFMoveStep = 0x01;
                afheader.AreaFWidth = 3;
                afheader.AreaFBackup = 0;
                byte[] img = Encoding.Default.GetBytes("黄10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame(0, ref afheader, img);
            }

            //第四步，添加显示内容，此处为图文分区0添加字符串
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("12测试");
            byte[] font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.arrMode = E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt(0, str, font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt:" + err);

            //第五步，发送节目到显示屏
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {

                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsEndFileTransf:" + err);
            }

            err = bxdualsdk.BxDual_program_freeBuffer(ref program);
            Console.WriteLine("bxDual_program_freeBuffer:" + err);
        }

        /// <summary>
        /// BX-6代控制卡发送节目多区域
        /// </summary>
        public static void Send_program_areas_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            var cmb_ping_Color = LedBxDualSdk.GetEScreenColor(data.Color);

            //设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56(cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //创建节目，设置节目属性
            EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);

            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 16;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            stSoundData.SoundData = IntPtr.Zero;

            aheader.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //添加显示内容，此处为图文分区0添加字符串
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            IntPtr font = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, font, Font.Length);
            byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            IntPtr str = Marshal.AllocHGlobal(strAreaTxtContent.Length);
            Marshal.Copy(strAreaTxtContent, 0, str, strAreaTxtContent.Length);
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x04;//移动模式
            pheader.ClearMode = 0x01;
            pheader.Speed = 60;//速度
            pheader.StayTime = 0;//停留时间
            pheader.RepeatTime = 1;
            pheader.ValidLen = 10;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eSINGLELINE;
            pheader.fontSize = 10;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 0;
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(0, strAreaTxtContent, Font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);

            //创建显示分区，设置区域显示位置，示例创建一个区域编号为1，区域大小64 * 32的时间分区，Y轴64，区域之间不可重叠
            EQareaHeader_G6 aheader1;
            aheader1.AreaType = 2;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            aheader1.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(1, ref aheader1);
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //添加时间区域显示内容
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eMULTILINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "simsun";
            timeData2.fontSize = 10;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 1;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 0;
            timeData2.datestyle = E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 1;
            timeData2.timestyle = E_TimeStyle.eHH_MM_COLON;
            timeData2.week_enable = 0;
            timeData2.weekstyle = E_WeekStyle.eMonday;
            err = bxdualsdk.BxDual_program_timeAreaAddContent_G6(1, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent_G6:" + err);

            //发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
        internal static void TestMain(string[] args)
        {
            //初始化动态库
            int err = bxdualsdk.BxDual_InitSdk();
            int a = 0;
            //bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            //    err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, Program.com);

            //Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            //    Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            //    Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            //    Console.WriteLine("\r\n");
            //common_56.Net_Bright(2);
            //bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            //err = bxdualsdk.BxDual_cmd_tcpPing(Program.ip, Program.port, ref data);

            //Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            //Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            //Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            //Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            //Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            //Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            //Console.WriteLine("\r\n");
            //common_56.sendConfigFile();
            //Console.Write("请输入串口：");
            //com = Encoding.GetEncoding("GBK").GetBytes(Console.ReadLine());
            // err = bxdualsdk.BxDual_cmd_check_time(ip, port);
            //if (err == 0) { Console.WriteLine("校时成功"); } else { Console.WriteLine("校时失败"); }
            //BX-5代控制卡
            if (!isNetwork)
            {
                //Program_Send_Sensor 节目设置传感器区域调用示例代码
                //Program_Send_Sensor.Send_program_sensor_5();
                //Program_Send_clock文本调用示例代码
                //Program_Send_txt.Send_program_txt_5();

                //Program_Send_png图片调用示例代码
                // Dynamic_5.delete_dynamic();
                //Program_Send_png.Send_program_png_5();

                //Program_Send_time时间调用示例代码
                //Program_Send_time.Send_program_time_5();

                //Program_Send_clock表盘调用示例代码
                //Program_Send_clock.Send_program_clock_5();

                //Program_Send_Areas节目多个区域调用示例代码
                //Program_Send_Areas.Send_program_areas_5();

                //Send_program_sensor_5 节目设置传感器区域调用示例代码
                //Program_Send_Sensor.Send_program_sensor_5();

                //动态区调用示例，仅限BX-5E系列使用
                //Dynamic_5.updata_dynamic_pages();
                //Dynamic_5.updata_dynamic_txt();
                //删除动态区
                //Dynamic_5.delete_dynamic();
                //Random ra = new Random();
                //for(int i = 0; i < 10000; i++)
                //{
                //    string str = "ab" + ra.Next(1,4999);
                //    Dynamic_5.updata_tests(0,64,0,44,16, str);
                //     str = "是d" + ra.Next(4999,9999);
                //    Dynamic_5.updata_tests(1,64, 16, 64, 16, str);
                //     str = "gf" + ra.Next(1, 99);
                //    Dynamic_5.updata_tests(2, 108, 0, 20, 16, str);
                //    Thread.Sleep(2000);
                //}
            }
            //BX-6代控制卡
            if (isNetwork)
            {
                //Program_Send_Sensor 节目设置传感器区域调用示例代码
                Program_Send_Sensor.Send_program_sensor_6();

                //common_56.deleteprogram();

                //Program_Send_png图片调用示例代码
                Program_Send_png.Send_program_png_6();

                //Program_Send_time时间调用示例代码
                //Program_Send_time.Send_program_time_6();

                //Program_Send_clock表盘调用示例代码
                //Program_Send_clock.Send_program_clock_6();

                //Program_Send_Areas节目多个区域调用示例代码
                //Program_Send_Areas.Send_program_areas_6(); 


                //动态区调用示例，部分控制卡支持
                //Dynamic_6.dynamicArea_pages_1();
                Dynamic_6.dynamicArea_str_3();
                //Dynamic_6.dynamicArea_png_1();

                //删除动态区
                //Dynamic_6.delete_dynamic();
            }

            //服务器模式调用示例
            if (!isNetwork)
            {
                Server.Server_get();
            }

            //释放动态库
            //bxdualsdk.BxDual_ReleaseSdk();
            Console.ReadKey();
        }
    }
    public class common_56
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        public static int err = 0;
        /// <summary>
        /// 常规设置,非必要
        /// </summary>
        public static void Set()
        {
            //设置屏号，不做通讯
            err = bxdualsdk.BxDual_set_screenNum_G56(1);
            //设置控制各种通讯方式每一包最大长度
            err = bxdualsdk.BxDual_set_packetLen(1024);
        }
        /// <summary>
        /// 文件系统格式化,不建议使用
        /// </summary>
        public static void Format()
        {
            //串口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsFormat(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }
            //网口
            else
            {
                err = bxdualsdk.BxDual_cmd_ofsFormat(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
        }
        //广播搜索
        public static void Net_search()
        {
            Ping_data data = new Ping_data();
            //网口搜索
            err = bxdualsdk.BxDual_cmd_udpPing(ref data);
            //全搜索，udp-tcp-com
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_searchController(ref data);
            }
            //根据串口搜索
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("\r\n");
        }
        //删除节目
        public static void Deleteprogram()
        {
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //获取节目列表
                GetDirBlock_G56 driBlock = new GetDirBlock_G56();
                err = bxdualsdk.BxDual_cmd_ofsReedDirBlock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref driBlock);
                //获取节目详细信息
                for (int i = 0; i < driBlock.fileNumber; i++)
                {
                    FileAttribute_G56 fileAttr = new FileAttribute_G56();
                    err = bxdualsdk.BxDual_cmd_getFileAttr(ref driBlock, (ushort)i, ref fileAttr);
                    //删除指定节目
                    err = bxdualsdk.BxDual_cmd_ofsDeleteFormatFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, fileAttr.fileName);
                }
                err = bxdualsdk.BxDual_cmd_ofs_freeDirBlock(ref driBlock);
            }
            //串口
            else
            {
                //获取节目列表
                GetDirBlock_G56 driBlock = new GetDirBlock_G56();
                err = bxdualsdk.BxDual_cmd_uart_ofsReedDirBlock(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, ref driBlock);
                //获取节目详细信息
                for (int i = 0; i < driBlock.fileNumber; i++)
                {
                    FileAttribute_G56 fileAttr = new FileAttribute_G56();
                    err = bxdualsdk.BxDual_cmd_getFileAttr(ref driBlock, (ushort)i, ref fileAttr);
                    //删除指定节目
                    err = bxdualsdk.BxDual_cmd_uart_ofsDeleteFormatFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1, fileAttr.fileName);
                }
                err = bxdualsdk.BxDual_cmd_ofs_freeDirBlock(ref driBlock);
            }
        }
        //调整亮度
        public static void Net_Bright(byte num)
        {
            Brightness brightness;
            brightness.BrightnessMode = 0;
            brightness.HalfHourValue0 = num;
            brightness.HalfHourValue1 = num;
            brightness.HalfHourValue2 = num;
            brightness.HalfHourValue3 = num;
            brightness.HalfHourValue4 = num;
            brightness.HalfHourValue5 = num;
            brightness.HalfHourValue6 = num;
            brightness.HalfHourValue7 = num;
            brightness.HalfHourValue8 = num;
            brightness.HalfHourValue9 = num;
            brightness.HalfHourValue10 = num;
            brightness.HalfHourValue11 = num;
            brightness.HalfHourValue12 = num;
            brightness.HalfHourValue13 = num;
            brightness.HalfHourValue14 = num;
            brightness.HalfHourValue15 = num;
            brightness.HalfHourValue16 = num;
            brightness.HalfHourValue17 = num;
            brightness.HalfHourValue18 = num;
            brightness.HalfHourValue19 = num;
            brightness.HalfHourValue20 = num;
            brightness.HalfHourValue21 = num;
            brightness.HalfHourValue22 = num;
            brightness.HalfHourValue23 = num;
            brightness.HalfHourValue24 = num;
            brightness.HalfHourValue25 = num;
            brightness.HalfHourValue26 = num;
            brightness.HalfHourValue27 = num;
            brightness.HalfHourValue28 = num;
            brightness.HalfHourValue29 = num;
            brightness.HalfHourValue30 = num;
            brightness.HalfHourValue31 = num;
            brightness.HalfHourValue32 = num;
            brightness.HalfHourValue33 = num;
            brightness.HalfHourValue34 = num;
            brightness.HalfHourValue35 = num;
            brightness.HalfHourValue36 = num;
            brightness.HalfHourValue37 = num;
            brightness.HalfHourValue38 = num;
            brightness.HalfHourValue39 = num;
            brightness.HalfHourValue40 = num;
            brightness.HalfHourValue41 = num;
            brightness.HalfHourValue42 = num;
            brightness.HalfHourValue43 = num;
            brightness.HalfHourValue44 = num;
            brightness.HalfHourValue45 = num;
            brightness.HalfHourValue46 = num;
            brightness.HalfHourValue47 = num;

            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setBrightness(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref brightness);//网口
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_cmd_setBrightness_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, ref brightness);
            }
            Console.WriteLine("cmd_setBrightness:" + err);
        }
        /// <summary>
        /// 系统复位,不建议使用，调用后所有参数全部会丢失
        /// </summary>
        public static void Reset()
        {
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_sysReset(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
            //串口
            else
            {
                //Program.com, Program.baudRate
            }
            Console.WriteLine("bxDual_cmd_sysReset:" + err);
        }
        //强制开关机
        public static void CoerceOnOff()
        {
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_coerceOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0);//关机
                err = bxdualsdk.BxDual_cmd_coerceOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1);//开机
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_cmd_coerceOnOff_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 0);//关机
                err = bxdualsdk.BxDual_cmd_coerceOnOff_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1);//开机
            }
        }
        //定时开关机
        public static void timingOnOff()
        {
            TimingOnOff[] time = new TimingOnOff[1];
            time[0].onHour = 9;   // 开机小时
            time[0].onMinute = 46; // 开机分钟
            time[0].offHour = 20;  // 关机小时
            time[0].offMinute = 40; // 关机分钟
            byte[] Time = LedBxDualSdk.StructToBytes(time[0]);
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_timingOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, Time);
                //取消定时开关机
                err = bxdualsdk.BxDual_cmd_cancelTimingOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
            Console.WriteLine("bxDual_cmd_timingOnOff:" + err);
        }
        /// <summary>
        /// 屏幕锁定
        /// </summary>
        public static void ScreenLock()
        {
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_screenLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 1);//屏幕锁定
                err = bxdualsdk.BxDual_cmd_screenLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 0);//屏幕解锁
            }
            //串口
            else
            {
                //Program.com, Program.baudRate
            }
            Console.WriteLine("bxDual_cmd_screenLock:" + err);
        }
        //节目锁定
        public static void ProgramLock()
        {
            //节目名格式类型为P***，如P000，P001
            byte[] name = Encoding.GetEncoding("GBK").GetBytes("P000");
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_programLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 1, name, 0xffffffff);//锁定
                err = bxdualsdk.BxDual_cmd_programLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 0, name, 0xffffffff);//解锁
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_programLock(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1, 1, name, 0xffffffff);//锁定-串口
                err = bxdualsdk.BxDual_cmd_uart_programLock(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1, 0, name, 0xffffffff);//锁定-串口
            }
            Console.WriteLine("bxDual_cmd_programLock:" + err);
        }
        //获取控制空间大小和剩余空间
        public static void GetMemoryVolume(byte[] ipAdder)
        {
            int totalMemVolume = 0, availableMemVolume = 0;
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_ofsGetMemoryVolume(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref totalMemVolume, ref availableMemVolume);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsGetMemoryVolume(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, ref totalMemVolume, ref availableMemVolume);
            }
        }
        //网络搜索
        public static void Search_Net(byte[] ipAdder)
        {
            NetSearchCmdRet retData = new NetSearchCmdRet();
            byte[] uartPort = new byte[] { 0 };
            ushort nBaudRateType = 0;
            err = bxdualsdk.BxDual_cmd_uart_search_Net_6G(ref retData, uartPort, nBaudRateType);
            NetSearchCmdRet_Web data = new NetSearchCmdRet_Web();
            err = bxdualsdk.BxDual_cmd_uart_search_Net_6G_Web(ref data, uartPort, nBaudRateType);
        }
        /// <summary>
        /// 网络搜索-传感器,6代控制卡使用
        /// </summary>
        /// <param name="ipAdder"></param>
        public static void Btn_NetworkSearch_6_Click()
        {
            NetSearchCmdRet CmdRet = new NetSearchCmdRet();
            err = bxdualsdk.BxDual_cmd_udpNetworkSearch_6G(ref CmdRet);
            err = bxdualsdk.BxDual_cmd_tcpNetworkSearch_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref CmdRet);
            string str = "";
            if (err == 0)
            {
                //Mac 地址
                str = "Mac:" + CmdRet.Mac[0].ToString("X2") + CmdRet.Mac[1].ToString("X2") + CmdRet.Mac[2].ToString("X2") + CmdRet.Mac[3].ToString("X2") + CmdRet.Mac[4].ToString("X2") + CmdRet.Mac[5].ToString("X2") + System.Environment.NewLine;
                //控制器 IP 地址
                str += "IP:" + LedBxDualSdk.BytesToString(CmdRet.IP) + System.Environment.NewLine;
                //子网掩码
                str += "SubNetMask:" + LedBxDualSdk.BytesToString(CmdRet.SubNetMask) + System.Environment.NewLine;
                //网关
                str += "Gate:" + LedBxDualSdk.BytesToString(CmdRet.Gate) + System.Environment.NewLine;
                //端口
                str += "Port:" + CmdRet.Port + System.Environment.NewLine;
                //1 表示 DHCP 2 表示手动设置
                if (CmdRet.IPMode == 1)
                {
                    str += "IPMode:DHCP" + System.Environment.NewLine;
                }
                else
                {
                    str += "IPMode:表示手动设置" + System.Environment.NewLine;
                }
                //0 表示 IP 设置失败 1 表示 IP 设置成功
                if (CmdRet.IPMode == 0)
                {
                    str += "IPStatus:IP 设置失败" + System.Environment.NewLine;
                }
                else
                {
                    str += "IPStatus:IP 设置成功" + System.Environment.NewLine;
                }
                //0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
                if (CmdRet.ServerMode == 0)
                {
                    str += "ServerMode:服务器模式使能    普通模式" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 1)
                {
                    str += "ServerMode:服务器模式禁止    普通模式" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 2)
                {
                    str += "ServerMode:服务器模式禁止    web模式" + System.Environment.NewLine;
                }
                else
                {
                    str += "ServerMode:服务器模式使能    web模式" + System.Environment.NewLine;
                }
                //服务器 IP 地址
                str += "ServerIPAddress:" + LedBxDualSdk.BytesToString(CmdRet.ServerIPAddress) + System.Environment.NewLine;
                //服务器端口号
                str += "ServerPort:" + CmdRet.ServerPort + System.Environment.NewLine;
                //服务器访问密码
                str += "ServerAccessPassword:" + System.Text.Encoding.Default.GetString(CmdRet.ServerAccessPassword) + System.Environment.NewLine;
                //20S 心跳时间间隔（单位：秒）
                str += "HeartBeatInterval:" + CmdRet.HeartBeatInterval + System.Environment.NewLine;
                //用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
                str += "CustomID:" + System.Text.Encoding.Default.GetString(CmdRet.CustomID) + System.Environment.NewLine;
                //条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
                str += "BarCode:" + System.Text.Encoding.Default.GetString(CmdRet.BarCode) + System.Environment.NewLine;
                //其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
                str += "ControllerType:" + (CmdRet.ControllerType[1] * 256 + CmdRet.ControllerType[0]) / 10 + System.Environment.NewLine;
                //Firmware 版本号
                str += "FirmwareVersion:" + System.Text.Encoding.Default.GetString(CmdRet.FirmwareVersion) + System.Environment.NewLine;
                //控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
                if (CmdRet.ScreenParaStatus == 0)
                {
                    str += "ScreenParaStatus:控制器中没有参数配置文件，必须先加载屏参" + System.Environment.NewLine;
                }
                else
                {
                    str += "ScreenParaStatus:控制器中有参数配置文件" + System.Environment.NewLine;
                }
                //0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
                str += "Address:" + CmdRet.Address + System.Environment.NewLine;
                //0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
                if (CmdRet.Baudrate == 1)
                {
                    str += "Baudrate:9600" + System.Environment.NewLine;
                }
                else if (CmdRet.Baudrate == 2)
                {
                    str += "Baudrate:57600" + System.Environment.NewLine;
                }
                else
                {
                    str += "Baudrate:保持原有波特率不变" + System.Environment.NewLine;
                }
                //显示屏宽度
                str += "ScreenWidth:" + CmdRet.ScreenWidth + System.Environment.NewLine;
                //显示屏高度
                str += "ScreenHeight:" + CmdRet.ScreenHeight + System.Environment.NewLine;
                //0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
                if (CmdRet.Color == 1)
                {
                    str += "Color:单色" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 3)
                {
                    str += "Color:双色" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 7)
                {
                    str += "Color:三色" + System.Environment.NewLine;
                }
                else
                {
                    str += "Color:灰度全彩" + System.Environment.NewLine;
                }
                //调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
                if (CmdRet.BrightnessAdjMode == 0)
                {
                    str += "BrightnessAdjMode:手动调亮" + System.Environment.NewLine;
                }
                else if (CmdRet.BrightnessAdjMode == 1)
                {
                    str += "BrightnessAdjMode:定时调亮" + System.Environment.NewLine;
                }
                else
                {
                    str += "BrightnessAdjMode:自动调亮" + System.Environment.NewLine;
                }
                //当前亮度值
                str += "CurrentBrigtness:" + CmdRet.CurrentBrigtness + System.Environment.NewLine;
                //Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
                if (CmdRet.TimingOnOff == 0)
                {
                    str += "TimingOnOff:无定时开关机" + System.Environment.NewLine;
                }
                else
                {
                    str += "TimingOnOff:有定时开关机" + System.Environment.NewLine;
                }
                //开关机状态
                if (CmdRet.CurrentOnOffStatus == 0)
                {
                    str += "CurrentOnOffStatus:开机" + System.Environment.NewLine;
                }
                else
                {
                    str += "CurrentOnOffStatus:关机" + System.Environment.NewLine;
                }
                //扫描配置编号
                str += "ScanConfNumber:扫描配置编号 " + CmdRet.ScanConfNumber + System.Environment.NewLine;
                //一路数据带几行
                str += "RowsPerChanel:" + CmdRet.RowsPerChanel + System.Environment.NewLine;
                //对于无灰度系统，返回 0；对于有灰度系 1
                if (CmdRet.GrayFlag == 0)
                {
                    str += "GrayFlag:无灰度系统" + System.Environment.NewLine;
                }
                else
                {
                    str += "GrayFlag:有灰度系统" + System.Environment.NewLine;
                }
                //最小单元宽度
                str += "UnitWidth:最小单元宽度 " + CmdRet.UnitWidth + System.Environment.NewLine;
                //6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
                if (CmdRet.modeofdisp == 0)
                {
                    str += "modeofdisp:6Q 显示模式 888 " + System.Environment.NewLine;
                }
                else
                {
                    str += "modeofdisp:6Q 显示模式 565 " + System.Environment.NewLine;
                }
                //当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
                str += "NetTranMode:" + CmdRet.NetTranMode + System.Environment.NewLine;
                //包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
                if (CmdRet.PackageMode == 0)
                {
                    str += "PackageMode:小包模式，分包 600 byte" + System.Environment.NewLine;
                }
                else
                {
                    str += "PackageMode:大包模式，分包 16K byte" + System.Environment.NewLine;
                }
                //是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
                if (CmdRet.BarcodeFlag == 0)
                {
                    str += "BarcodeFlag:无条码" + System.Environment.NewLine;
                }
                else
                {
                    str += "BarcodeFlag:有条码" + System.Environment.NewLine;
                }
                //控制器上已有节目个数
                str += "ProgramNumber:控制器上已有节目个数 " + CmdRet.ProgramNumber + System.Environment.NewLine;
                //当前节目名
                str += "CurrentProgram:当前节目名 " + System.Text.Encoding.Default.GetString(CmdRet.CurrentProgram) + System.Environment.NewLine;
                //Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
                if (CmdRet.ScreenLockStatus == 0)
                {
                    str += "ScreenLockStatus:无屏幕锁定" + System.Environment.NewLine;
                }
                else
                {
                    str += "ScreenLockStatus:屏幕锁定" + System.Environment.NewLine;
                }
                //Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
                if (CmdRet.ProgramLockStatus == 0)
                {
                    str += "ProgramLockStatus:无节目锁定" + System.Environment.NewLine;
                }
                else
                {
                    str += "ProgramLockStatus:节目锁定" + System.Environment.NewLine;
                }
                //控制器运行模式
                str += "RunningMode:" + CmdRet.RunningMode + System.Environment.NewLine;
                //RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
                if (CmdRet.RTCStatus == 0)
                {
                    str += "RTCStatus:RTC 异常" + System.Environment.NewLine;
                }
                else
                {
                    str += "RTCStatus:RTC 正常" + System.Environment.NewLine;
                }
                //年
                str += "RTCYear:" + (LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCYear[1]) * 100 + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCYear[0])) + System.Environment.NewLine;
                //月
                str += "RTCMonth:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCMonth) + System.Environment.NewLine;
                //日
                str += "RTCDate:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCDate) + System.Environment.NewLine;
                //时
                str += "RTCHour:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCHour) + System.Environment.NewLine;
                //分
                str += "RTCMinute:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCMinute) + System.Environment.NewLine;
                //秒
                str += "RTCSecond:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCSecond) + System.Environment.NewLine;
                //星期，范围为 1~7，7 表示周日
                str += "RTCWeek:星期" + CmdRet.RTCWeek + System.Environment.NewLine;
                //温度传感器当前值 第一个字节0为正1为负 数值/10
                if ((CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) != 0xffff)
                {
                    if (CmdRet.Temperature1[0] == 0)
                    {
                        str += "Temperature1:+" + (CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) / 10 + System.Environment.NewLine;
                    }
                    else
                    {
                        str += "Temperature1:-" + (CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) / 10 + System.Environment.NewLine;
                    }
                }
                else
                {
                    str += "Temperature1:无温度传感器" + System.Environment.NewLine;
                }
                //温湿度传感器温度当前值 第一个字节0为正1为负 数值/10
                if ((CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) != 0xffff)
                {
                    if (CmdRet.Temperature2[0] == 0)
                    {
                        str += "Temperature2:+" + (CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) / 10 + System.Environment.NewLine;
                    }
                    else
                    {
                        str += "Temperature2:-" + (CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) / 10 + System.Environment.NewLine;
                    }
                }
                else
                {
                    str += "Temperature2:无温度传感器" + System.Environment.NewLine;
                }
                //湿度传感器当前值  数值/10
                if ((CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) != 0xffff)
                {
                    str += "Humidity:" + (CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "Humidity:无湿度传感器" + System.Environment.NewLine;
                }
                //噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
                if ((CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) != 0xffff)
                {
                    str += "Noise:" + (CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "Noise:无噪声传感器+" + System.Environment.NewLine;
                }
                //0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
                if (CmdRet.LogoFlag == 0)
                {
                    str += "LogoFlag:未设置 Logo 节目" + System.Environment.NewLine;
                }
                else
                {
                    str += "LogoFlag:设置了 Logo 节目" + System.Environment.NewLine;
                }
                //0：未设置开机延时 1：开机延时时长
                if (CmdRet.PowerOnDelay == 0)
                {
                    str += "PowerOnDelay:未设置开机延时" + System.Environment.NewLine;
                }
                else
                {
                    str += "PowerOnDelay:开机延时时长 " + CmdRet.PowerOnDelay + System.Environment.NewLine;
                }
                //风速(除以 10 为当前值) 0xfffff 时无效
                if ((CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) != 0xffff)
                {
                    str += "WindSpeed:" + (CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "WindSpeed:无风速传感器" + System.Environment.NewLine;
                }
                //风向(当前值) 0xfffff 时无效
                if ((CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) != 0xffff)
                {
                    str += "WindDirction:(0:0°北风 1:45°东北风 2:90°东风 3:135°东南风 4:180°南风 5:225°西南风 6:270°西风 7:315°西北风)" + (CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "WindDirction:无风向传感器" + System.Environment.NewLine;
                }
                //PM2.5 值(当前值)0xfffff 时无效
                if ((CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) != 0xffff)
                {
                    str += "PM2_5:" + (CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "PM2_5:无PM2_5传感器" + System.Environment.NewLine;
                }
                //PM10 值(当前值)0xfffff 时无效
                if ((CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) != 0xffff)
                {
                    str += "PM10:" + (CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "PM10:无PM10传感器" + System.Environment.NewLine;
                }
                //LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
                string ControllerName = "";
                for (int i = 0; i < CmdRet.ControllerName.Length; i++) { ControllerName += CmdRet.ControllerName[i].ToString("X2").ToUpper(); }
                str += "ControllerName:" + ControllerName + System.Environment.NewLine;
                //屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
                string ScreenLocation = "";
                for (int i = 0; i < CmdRet.ScreenLocation.Length; i++) { ScreenLocation += CmdRet.ScreenLocation[i].ToString("X2").ToUpper(); }
                str += "ScreenLocation:" + ScreenLocation + System.Environment.NewLine;
                //控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
                string NameLocalationCRC32 = "";
                for (int i = 0; i < CmdRet.NameLocalationCRC32.Length; i++) { NameLocalationCRC32 += CmdRet.NameLocalationCRC32[i].ToString("X2").ToUpper(); }
                str += "NameLocalationCRC32:" + NameLocalationCRC32 + System.Environment.NewLine;
            }
        }
        //IP设置
        public static void UdpSetIP()
        {
            byte mode = 2;
            byte[] ip1 = Encoding.GetEncoding("GBK").GetBytes("192.168.89.178");
            byte[] subnetMask = Encoding.GetEncoding("GBK").GetBytes("255.255.255.0");
            byte[] gateway = Encoding.GetEncoding("GBK").GetBytes("192.168.89.100");
            short port1 = 5005;
            byte serverMode = 0;
            byte[] serverIP = Encoding.GetEncoding("GBK").GetBytes("127.0.0.1");
            short serverPort = 5005;
            byte[] password = Encoding.GetEncoding("GBK").GetBytes("00000000");
            short heartbeat = 20;
            byte[] netID = Encoding.GetEncoding("GBK").GetBytes("BX-NET000001");

            err = bxdualsdk.BxDual_cmd_udpSetIP(mode, ip1, subnetMask, gateway, port1, serverMode, serverIP, serverPort, password, heartbeat, netID);
        }
        string strdual = "作用不明 bxDual_cmd_uart_confDeleteFormatFile";
        /// <summary>
        /// 设置WIFI密码
        /// </summary>
        public static void SetWifi_pwd()
        {
            byte[] ssid = Encoding.GetEncoding("GBK").GetBytes("bx-wifi_fantx");
            byte[] pwd = Encoding.GetEncoding("GBK").GetBytes("12345678");
            err = bxdualsdk.BxDual_cmd_AT_setWifiSsidPwd(ssid, pwd);
        }
        /// <summary>
        /// 取得WIFI密码
        /// </summary>
        public static void GetWifi_pwd()
        {
            byte[] ssid = new byte[16];
            byte[] pwd = new byte[16];
            for (int i = 0; i < 16; i++) { ssid[i] = 0; pwd[i] = 0; }
            err = bxdualsdk.BxDual_cmd_AT_getWifiSsidPwd(ssid, pwd);
        }
        /// <summary>
        /// 网络搜索-网络参数，5代卡使用
        /// </summary>
        public static void Btn_NetworkSearch_5_Click()
        {
            var CmdRet = new HeartbeatData();
            err = bxdualsdk.BxDual_cmd_udpNetworkSearch(ref CmdRet);
        }
        /// <summary>
        /// 广播设置MAC地址
        /// </summary>
        public static void Udp_setMAC()
        {
            byte[] mac = Encoding.GetEncoding("GBK").GetBytes("aa-bb-cc-12-a8-8a");
            err = bxdualsdk.BxDual_cmd_udpSetMac(mac);
        }
        /// <summary>
        /// 校时，同步控制卡时间
        /// </summary>
        public static void Checktime()
        {
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_check_time(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_cmd_check_time_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }
        }
        /// <summary>
        /// 读控制器ID
        /// </summary>
        public static void ReadControllerID()
        {
            byte[] ControllerID = new byte[8];
            for (int i = 0; i < 8; i++) { ControllerID[i] = 0; }
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_readControllerID(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ControllerID);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// 读控制器状态
        /// </summary>
        public static void ControllerStatus()
        {
            ControllerStatus_G56 Status = new ControllerStatus_G56();
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_check_controllerStatus(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref Status);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// 设置控制器密码
        /// </summary>
        public static void SetPassword()
        {
            byte[] oldpassword = Encoding.GetEncoding("GBK").GetBytes("123456");
            byte[] newpassword = Encoding.GetEncoding("GBK").GetBytes("456789");
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setPassword(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, oldpassword, newpassword);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// 删除当前控制器密码
        /// </summary>
        public static void DeletePassword()
        {
            byte[] password = Encoding.GetEncoding("GBK").GetBytes("123456");
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_deletePassword(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, password);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// 设置控制开机延时时间，单位秒
        /// </summary>
        public static void SetDelayTime()
        {
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setDelayTime(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 5);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// 设置控制测试按钮功能 按钮模式 0x00–测试按钮 0x01–沿触发切换节目 0x02–电平触发切换节目
        /// </summary>
        private static void setBtnFunc()
        {
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setBtnFunc(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// 设置控制重启重启时间
        /// </summary>
        private static void setTimingReset()
        {
            TimingReset time = new TimingReset();
            time.rstMode = 2;
            time.RstInterval = 1;
            time.rstHour1 = 8;
            time.rstMin1 = 8;
            time.rstHour2 = 8;
            time.rstMin2 = 8;
            time.rstHour3 = 8;
            time.rstMin3 = 8;
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setTimingReset(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref time);
            }
            //串口
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// 设置控制器的显示模式
        /// </summary>
        private static void setDispMode()
        {
            err = bxdualsdk.BxDual_cmd_setDispMode(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0);
        }
        /// <summary>
        /// 秒表控制并获取秒表时间
        /// </summary>
        private static void getStopwatch()
        {
            byte mode = 0; int timeValue = 0;
            err = bxdualsdk.BxDual_cmd_getStopwatch(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, mode, ref timeValue);
        }
        /// <summary>
        /// 获取亮度读传感器值
        /// </summary>
        private static void getSensorBrightnessValue()
        {
            int brightnessValue = 0;
            err = bxdualsdk.BxDual_cmd_getSensorBrightnessValue(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref brightnessValue);
        }
        /// <summary>
        /// 速度微调命令
        /// </summary>
        private static void setSpeedAdjust()
        {
            short speed = 0;
            err = bxdualsdk.BxDual_cmd_setSpeedAdjust(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, speed);
        }
        /// <summary>
        /// 设置屏幕号
        /// </summary>
        private static void setScreenAddress()
        {
            short address = 1;
            err = bxdualsdk.BxDual_cmd_setScreenAddress(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, address);
        }
        /// <summary>
        /// 开始读文件
        /// </summary>
        public static void ofsStartReedFile()
        {
            byte[] fileName = Encoding.GetEncoding("GBK").GetBytes("P000");
            uint fileSize = 0;
            uint fileCrc = 0;
            err = bxdualsdk.BxDual_cmd_ofsStartReedFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName, ref fileSize, ref fileCrc);

            byte[] data = new byte[1024 * 100];
            for (int i = 0; i < 1024; i++) { data[i] = 0; }
            err = bxdualsdk.BxDual_cmd_ofsReedFileBlock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName, data);
        }
        /// <summary>
        /// 开始读文件
        /// </summary>
        public static void confStartReedFile()
        {
            byte[] fileName = Encoding.GetEncoding("GBK").GetBytes("S000");//C000.S000
            uint fileSize = 0;
            uint fileCrc = 0;
            err = bxdualsdk.BxDual_cmd_confStartReedFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName, ref fileSize, ref fileCrc);

            byte[] data = new byte[fileSize];
            for (int i = 0; i < fileSize; i++) { data[i] = 0; }
            err = bxdualsdk.BxDual_cmd_confReedFileBlock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName, data);
            //5代
            if (false)
            {
                IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ConfigFile)));
                Marshal.Copy(data, Marshal.SizeOf(typeof(ConfigFile)), dec, Marshal.SizeOf(typeof(ConfigFile)));
                ConfigFile configData = (ConfigFile)Marshal.PtrToStructure(dec, typeof(ConfigFile));
                Marshal.FreeHGlobal(dec);
                err = bxdualsdk.BxDual_cmd_sendConfigFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref configData);
            }
            //6代
            else
            {
                //IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bxdualsdk.ConfigFile_G6)));
                //Marshal.Copy(data, Marshal.SizeOf(typeof(bxdualsdk.ConfigFile_G6)), dec, Marshal.SizeOf(typeof(bxdualsdk.ConfigFile_G6)));
                //bxdualsdk.ConfigFile_G6 configData = (bxdualsdk.ConfigFile_G6)Marshal.PtrToStructure(dec, typeof(bxdualsdk.ConfigFile_G6));
                //Marshal.FreeHGlobal(dec);
                ConfigFile_G6 configData = new ConfigFile_G6();
                err = bxdualsdk.BxDual_cmd_sendConfigFile_G6(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref configData);
            }
        }
        /// <summary>
        /// 读文件接口测试
        /// </summary>
        private static void cmd_ofsReedDirBlock()
        {
            byte[] fileName = Encoding.GetEncoding("GBK").GetBytes("F001");
            err = bxdualsdk.BxDual_cmd_firmwareActivate(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName);
        }


        /// <summary>
        /// 设置屏参
        /// </summary>
        public static void sendConfigFile()
        {
            uint fileLen = 0;
            uint fileCrc = 0;
            byte[] fileName = Encoding.GetEncoding("GBK").GetBytes("C000");
            err = bxdualsdk.BxDual_cmd_confStartReedFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName, ref fileLen, ref fileCrc);
            byte[] configData = new byte[1024];
            err = bxdualsdk.BxDual_cmd_confReedFileBlock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName, configData);

            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ConfigFile_G6)));
            Marshal.Copy(configData, 0, dec, Marshal.SizeOf(typeof(ConfigFile_G6)));
            ConfigFile_G6 data = (ConfigFile_G6)Marshal.PtrToStructure(dec, typeof(ConfigFile_G6));
            Marshal.FreeHGlobal(dec);

            err = bxdualsdk.BxDual_cmd_sendConfigFile_G6(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

        }

    }
    /// <summary>
    /// 动态区相关命令，仅支持BX-5E系列
    /// </summary>
    class Dynamic_5
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// 删除动态区，单个操作
        /// </summary>
        public static void delete_dynamic()
        {
            //第三个参数给动态区ID指定删除，给0xff删除所有动态区
            int err = 0;
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0xff);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_G5_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 0xff);
            }
            Console.WriteLine("dynamicArea_DelArea_5G = " + err);
        }

        /// <summary>
        /// 删除动态区，多区域操作
        /// </summary>
        public static void delete_dynamic_s()
        {
            byte[] id = new byte[] { 0, 1 };
            int err = 0;
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelAreaS_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            //串口
            else
            {
                id = new byte[] { 0 };
                err = bxdualsdk.BxDual_dynamicArea_DelAreaS_G5_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            Console.WriteLine("dynamicArea_DelArea_5G = " + err);
        }

        /// <summary>
        /// 动态区更新文本，单条文本
        /// </summary>
        public static void Updata_dynamic_txt()
        {
            byte uAreaId = 0;
            byte RunMode = 0;
            ushort Timeout = 10;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = null;
            byte ImmePlay = 1;
            ushort uAreaX = 0;
            ushort uAreaY = 0;
            ushort uWidth = 96;
            ushort uHeight = 32;
            EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;
            //PageStyle begin--------
            byte DisplayMode = 2;
            byte ClearMode = 0;
            byte Speed = 10;
            ushort StayTime = 100;
            byte RepeatTime = 0;
            //PageStyle End.
            //显示内容和字体格式 begin---------
            EQfontData oFont;
            oFont.arrMode = E_arrMode.eMULTILINE;
            oFont.fontSize = 12;
            oFont.color = 1;
            oFont.fontBold = 0;
            oFont.fontItalic = 0; oFont.tdirection = E_txtDirection.pNORMAL; oFont.txtSpace = 0; oFont.Halign = 1; oFont.Valign = 1;
            byte[] fontName = Encoding.Default.GetBytes("宋体\0");
            byte[] strAreaTxtContent = Encoding.Default.GetBytes("测试\n文本\0");
            int err = 0;
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
                //功能一样，只是结构体为指针参数
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_Point_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //ImmePlay, uAreaX, uAreaY, uWidth, uHeight,ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime,ref oFont, fontName, strAreaTxtContent);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_5G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
                //功能一样，只是结构体为指针参数
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //ImmePlay, uAreaX, uAreaY, uWidth, uHeight,ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime,ref oFont, fontName, strAreaTxtContent);
            }
            Console.WriteLine("dynamicArea_AddAreaWithTxt_5G = " + err);
        }

        /// <summary>
        /// 动态区更新图片，单张图片
        /// </summary>
        public static void Updata_dynamic_png()
        {
            byte uAreaId = 0;
            byte RunMode = 0;
            ushort Timeout = 10;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = null;
            byte ImmePlay = 1;
            ushort uAreaX = 0;
            ushort uAreaY = 0;
            ushort uWidth = 64;
            ushort uHeight = 32;
            EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;
            //PageStyle begin--------
            byte DisplayMode = 3;
            byte ClearMode = 0;
            byte Speed = 10;
            ushort StayTime = 10;
            byte RepeatTime = 0;
            //PageStyle End.
            //显示内容和字体格式 begin---------
            EQfontData oFont;
            oFont.arrMode = E_arrMode.eMULTILINE;
            oFont.fontSize = 10;
            oFont.color = 1;
            oFont.fontBold = 0;
            oFont.fontItalic = 0; oFont.tdirection = E_txtDirection.pNORMAL; oFont.txtSpace = 0; oFont.Halign = 1; oFont.Valign = 2;
            byte[] filePath = Encoding.Default.GetBytes("456.png");
            int err = 0;
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithPic_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithPic_5G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
            }
            Console.WriteLine("dynamicArea_AddAreaWithPic_5G = " + err);
        }

        /// <summary>
        /// 动态区更新多页数据
        /// </summary>
        public static void updata_dynamic_pages()
        {
            int err = 0;
            byte uAreaId = 0;
            byte RunMode = 0;
            ushort Timeout = 10;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = null;
            byte ImmePlay = 1;
            ushort uAreaX = 64;
            ushort uAreaY = 0;
            ushort uWidth = 64;
            ushort uHeight = 32;
            EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;
            DynamicAreaBaseInfo_5G pheader = new DynamicAreaBaseInfo_5G();
            pheader.nType = 0x02;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 100;
            pheader.RepeatTime = 0;
            pheader.oFont.arrMode = E_arrMode.eMULTILINE;
            pheader.oFont.fontSize = 10;
            pheader.oFont.color = 1;
            pheader.oFont.fontBold = 0;
            pheader.oFont.fontItalic = 0;
            pheader.oFont.tdirection = E_txtDirection.pNORMAL;
            pheader.oFont.txtSpace = 0;
            pheader.oFont.Halign = 1;
            pheader.oFont.Valign = 2;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader.fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            pheader.strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, pheader.strAreaTxtContent, str.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, pheader.filePath, img.Length);
            DynamicAreaBaseInfo_5G pheader1 = new DynamicAreaBaseInfo_5G();
            pheader1.nType = 0x01;
            pheader1.DisplayMode = 4;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 10;
            pheader1.StayTime = 100;
            pheader1.RepeatTime = 0;
            pheader1.oFont.arrMode = E_arrMode.eMULTILINE;
            pheader1.oFont.fontSize = 10;
            pheader1.oFont.color = 1;
            pheader1.oFont.fontBold = 0;
            pheader1.oFont.fontItalic = 0;
            pheader1.oFont.tdirection = E_txtDirection.pNORMAL;
            pheader1.oFont.txtSpace = 0;
            pheader1.oFont.Halign = 1;
            pheader1.oFont.Valign = 2;
            string nnn = "123";
            pheader1.fontName = LedBxDualSdk.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("宋体"));
            pheader1.strAreaTxtContent = LedBxDualSdk.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes(nnn + "\0"));
            pheader1.filePath = LedBxDualSdk.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("123.png\0"));
            DynamicAreaBaseInfo_5G[] Params = new DynamicAreaBaseInfo_5G[2];
            Params[0] = pheader;
            Params[1] = pheader1;

            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //该接口调用报错
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //                    ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);

                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_5G_Point(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);
            }
            //串口
            else
            {
                //该接口调用报错
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_5G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_5G_Point = " + err);
        }
        public static void updata_tests(int id, int x, int y, int w, int h, string text)
        {
            int err = 0;
            byte uAreaId = (byte)id;
            byte RunMode = 0;
            ushort Timeout = 10;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = null;
            byte ImmePlay = 1;
            ushort uAreaX = (ushort)x;
            ushort uAreaY = (ushort)y;
            ushort uWidth = (ushort)w;
            ushort uHeight = (ushort)h;
            EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;
            DynamicAreaBaseInfo_5G pheader = new DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 10;
            pheader.StayTime = 100;
            pheader.RepeatTime = 0;
            pheader.oFont.arrMode = E_arrMode.eMULTILINE;
            pheader.oFont.fontSize = 10;
            pheader.oFont.color = 1;
            pheader.oFont.fontBold = 0;
            pheader.oFont.fontItalic = 0;
            pheader.oFont.tdirection = E_txtDirection.pNORMAL;
            pheader.oFont.txtSpace = 0;
            pheader.oFont.Halign = 1;
            pheader.oFont.Valign = 2;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = LedBxDualSdk.BytesToIntptr(Font);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(text + "\0");
            pheader.strAreaTxtContent = LedBxDualSdk.BytesToIntptr(str);
            //byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            //pheader.filePath = Class1.BytesToIntptr(img);
            List<DynamicAreaBaseInfo_5G> Params = new List<DynamicAreaBaseInfo_5G>();
            Params.Add(pheader);
            DynamicAreaBaseInfo_5G[] Pas = new DynamicAreaBaseInfo_5G[1];
            Pas[0] = pheader;

            bxdualsdk.BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_5G_Point(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, 0, 10, 1, 0, RelateProSerial,
                0, uAreaX, uAreaY, uWidth, uHeight, oFrame, 1, Pas);

            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_5G_Point = " + err);
        }
    }
    /// <summary>
    /// 动态区相关命令，6E系列，6E1X，6E2X，6Q1，6Q2，6Q3，6QX-YD，6Q2L，6Q3L系列支持
    /// </summary>
    class Dynamic_6
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        public static int err = 0;
        public static Random ran = new Random();
        //5E系列支持 0-3，6E，6Q系列支持 0-31
        public static byte AreaId = 0;
        public static byte RunMode = 0;
        public static ushort Timeout = 10;
        public static byte RelateAllPro = 0;
        public static ushort RelateProNum = 0;
        public static ushort[] RelateProSerial = new ushort[] { 0 };
        public static byte ImmePlay = 1;
        //动态区域左上角在LED显示屏的位置/坐标；
        public static ushort AreaX = 0;
        public static ushort AreaY = 0;
        //动态区域的宽度，高度
        public static ushort Width = 64;
        public static ushort Height = 32;
        //字体名称，如"宋体";
        public static IntPtr fontName;
        //public static byte[] fontName = Encoding.GetEncoding("GBK").GetBytes("宋体");
        //字体大小
        public static byte FontSize = 12;
        //要显示的文本内容
        public static IntPtr strAreaTxtContent;
        //public static byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("12345565648");
        //要显示的图片 只支持png类型，图片像素大小和区域坐标1：1，一般黑底红字
        public static IntPtr img;
        //public static byte[] img = Encoding.GetEncoding("GBK").GetBytes("0.png");

        /// <summary>
        /// 删除动态区，单个操作
        /// </summary>
        public static void delete_dynamic()
        {
            //第三个参数给动态区ID指定删除，给0xff删除所有动态区
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0xff);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 0xff);
            }
            Console.WriteLine("dynamicArea_DelArea = " + err);
        }

        /// <summary>
        /// 删除动态区，多区域操作
        /// </summary>
        public static void delete_dynamic_s()
        {
            byte[] id = new byte[] { 0, 1 };
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelAreas_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            //串口
            else
            {
                id = new byte[] { 0 };
                err = bxdualsdk.BxDual_dynamicArea_DelAreas_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            Console.WriteLine("dynamicArea_DelArea = " + err);
        }

        /// <summary>
        /// 设置双色屏点阵类型,双色屏时，如果发送红色显示黄色，就是点阵类型参数不对，该接口5代，6代通用
        /// </summary>
        public static void dynamic_pixel()
        {
            bxdualsdk.BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
        }

        /// <summary>
        /// 单区域文本，不能设置特效
        /// </summary>
        public static void dynamicArea_str_1()
        {
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            err = bxdualsdk.BxDual_dynamicArea_AddAreaTxt_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                      Width, Height, fontName, FontSize, strAreaTxtContent);
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxt_6G:" + err);
        }
        /// <summary>
        /// 单区域文本，能设置特效
        /// </summary>
        public static void dynamicArea_str_2()
        {
            EQareaHeader_G6 aheader = new EQareaHeader_G6
            {
                AreaType = 0x10,
                AreaX = AreaX,
                AreaY = AreaY,
                AreaWidth = Width,
                AreaHeight = Height,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00
            };
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            EQSound_6G stSoundData = new EQSound_6G
            {
                SoundFlag = 0x00,
                SoundPerson = 0x01,
                SoundVolum = 6,
                SoundSpeed = 0x2,
                SoundDataMode = 0x00,
                SoundReplayTimes = 0x01,
                SoundReplayDelay = 200,
                SoundReservedParaLen = 0x03,
                Soundnumdeal = 0x00,
                Soundlanguages = 0x00,
                Soundwordstyle = 0x00,
                SoundDataLen = strSoundTxt.Length,
                SoundData = LedBxDualSdk.BytesToIntptr(strSoundTxt)
            };
            aheader.stSoundData = stSoundData;

            EQpageHeader_G6 pheader = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = 2,
                ClearMode = 0x00,
                Speed = 15,
                StayTime = 100,
                RepeatTime = 1,
                ValidLen = 0,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eMULTILINE,
                fontSize = 12,
                color = (uint)0x01,
                fontBold = 0,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 1,
                Halign = 1
            };
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            IntPtr fontName1 = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName1, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            IntPtr strAreaTxtContent1 = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent1, str.Length);
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId,
                    ref aheader, ref pheader, fontName1, strAreaTxtContent1);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                    AreaId, ref aheader, ref pheader, fontName, strAreaTxtContent);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }

        /// <summary>
        /// 单区域文本，能设置特效,可选择是否和节目内容一起播放【一起播放时动态区和节目区域不能有重叠】
        /// </summary>
        public static void dynamicArea_str_3()
        {
            Ping_data data = new Ping_data();
            int err = 0;
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);
            }
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            Console.WriteLine("\r\n");
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 16;
            aheader.AreaWidth = 96;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = LedBxDualSdk.BytesToIntptr(strSoundTxt);
            aheader.stSoundData = stSoundData;
            Random ran = new Random();
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 2;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 100;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)1;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 5;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体\0");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("现场:25人\n预约:68人\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //动态区优先播放，节目停止播放
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, 
                // ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //串口
            else
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
            Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
        }
        public static void dynamicArea_str_31()
        {
            Ping_data data = new Ping_data();
            int err = 0;
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);
            }
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            Console.WriteLine("\r\n");
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 16;
            aheader.AreaWidth = 80;
            aheader.AreaHeight = 16;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = LedBxDualSdk.BytesToIntptr(strSoundTxt);
            aheader.stSoundData = stSoundData;

            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 6;
            pheader.ClearMode = 0x01;
            pheader.Speed = 64;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eSINGLELINE;
            pheader.fontSize = 12;
            pheader.color = (uint)1;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体\0");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("WJ045等待【孙波】装卸料！WJ047等待【王世民】装卸料！WJ077等待【王学柱】装卸料！WJ044等待【孙波】装卸料！WJ041等待【贺亚荣】装卸料！WJ042等待【贺亚荣】装卸料！WJ036等待【贺亚荣】装卸料！WJ037等待【贺亚荣】装卸料！WJ034等待【贺亚荣】装卸料！WJ035等待【贺亚荣】装卸料！\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 1,
                   ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 22,
                // ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //串口
            else
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 单区域多文本，能设置特效,可选择是否和节目内容一起播放【一起播放时动态区和节目区域不能有重叠】
        /// </summary>
        public static void dynamicArea_str_4()
        {
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = AreaX;
            aheader.AreaY = AreaY;
            aheader.AreaWidth = Width;
            aheader.AreaHeight = Height;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = LedBxDualSdk.BytesToIntptr(strSoundTxt);
            aheader.stSoundData = stSoundData;

            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 15;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("测试\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_THREE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //串口
            else
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 单区域图片，能设置特效
        /// </summary>
        public static void dynamicArea_png_1()
        {
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 7;
            pheader.ClearMode = 0x00;
            pheader.Speed = 15;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eSINGLELINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("5.png\0");
            img = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, img, str.Length);
            Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                          64, 64, ref pheader, img);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                //                                          Width, Height, ref pheader, img, RelateProNum, RelateProSerial);

            }
            //串口
            else
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_6G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                          Width, Height, ref pheader, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, 
                //    AreaX, AreaY,Width, Height, ref pheader, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
            Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
        }
        /// <summary>
        /// 同时更新多个动态区文本
        /// </summary>
        public static void dynamicArea_str_5()
        {
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 80;
            aheader.AreaHeight = 16;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 80;
            aheader1.AreaHeight = 16;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = LedBxDualSdk.BytesToIntptr(strSoundTxt);

            aheader.stSoundData = stSoundData;
            aheader1.stSoundData = stSoundData;

            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 10;
            pheader.StayTime = 100;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eSINGLELINE;
            pheader.fontSize = 10;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x03;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 15;
            pheader1.StayTime = 500;
            pheader1.RepeatTime = 1;
            pheader1.ValidLen = 0;
            pheader1.CartoonFrameRate = 0x00;
            pheader1.BackNotValidFlag = 0x00;
            pheader1.arrMode = E_arrMode.eSINGLELINE;
            pheader1.fontSize = 10;
            pheader1.color = (uint)0x01;
            pheader1.fontBold = 0;
            pheader1.fontItalic = 0;
            pheader1.tdirection = E_txtDirection.pNORMAL;
            pheader1.txtSpace = 0;
            pheader1.Valign = 1;
            pheader1.Halign = 0;
            Random ran = new Random();
            DynamicAreaParams[] Params = new DynamicAreaParams[2];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体\0");
            Params[0].fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, Params[0].fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(ran.Next(99999) + "\0");
            Params[0].strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, Params[0].strAreaTxtContent, str.Length);
            Params[1].uAreaId = 1;
            Params[1].oAreaHeader_G6 = aheader1;
            Params[1].stPageHeader = pheader1;
            Params[1].fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, Params[1].fontName, Font.Length);
            byte[] str1 = Encoding.GetEncoding("GBK").GetBytes(ran.Next(99999) + "\0");
            Params[1].strAreaTxtContent = Marshal.AllocHGlobal(str1.Length);
            Marshal.Copy(str1, 0, Params[1].strAreaTxtContent, str1.Length);
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                //Console.WriteLine(DateTime.Now.ToString());
                //err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
                //Console.WriteLine(DateTime.Now.ToString());

            }
            //串口
            else
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 同时更新多个动态区图片
        /// </summary>
        public static void dynamicArea_png_2()
        {
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 64;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = LedBxDualSdk.BytesToIntptr(strSoundTxt);

            aheader.stSoundData = stSoundData;
            aheader1.stSoundData = stSoundData;

            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 2;
            pheader.ClearMode = 0x00;
            pheader.Speed = 5;
            pheader.StayTime = 100;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eMULTILINE;
            pheader.fontSize = 14;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x03;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 15;
            pheader1.StayTime = 500;
            pheader1.RepeatTime = 1;
            pheader1.ValidLen = 0;
            pheader1.CartoonFrameRate = 0x00;
            pheader1.BackNotValidFlag = 0x00;
            pheader1.arrMode = E_arrMode.eSINGLELINE;
            pheader1.fontSize = 18;
            pheader1.color = (uint)0x01;
            pheader1.fontBold = 0;
            pheader1.fontItalic = 0;
            pheader1.tdirection = E_txtDirection.pNORMAL;
            pheader1.txtSpace = 0;
            pheader1.Valign = 1;
            pheader1.Halign = 0;
            DynamicAreaParams[] Params = new DynamicAreaParams[1];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            Params[0].fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, Params[0].fontName, Font.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("5.png\0");
            Params[0].strAreaTxtContent = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, Params[0].strAreaTxtContent, img.Length);
            //Params[1].uAreaId = 1;
            //Params[1].oAreaHeader_G6 = aheader1;
            //Params[1].stPageHeader = pheader1;
            //Params[1].fontName = Marshal.AllocHGlobal(Font.Length);
            //Marshal.Copy(Font, 0, Params[1].fontName, Font.Length);
            //byte[] img1 = Encoding.GetEncoding("GBK").GetBytes("1.png\0");
            //Params[1].strAreaTxtContent = Marshal.AllocHGlobal(img1.Length);
            //Marshal.Copy(img1, 0, Params[1].strAreaTxtContent, img1.Length);
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);

            }
            //串口
            else
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_6G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                //err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 一次向一个动态区发送/更新多条信息（文字或图片）及语音
        /// 该接口有问题，不建议使用
        /// </summary>
        public static void dynamicArea_pages()
        {
            int err = 0;
            byte DisplayMode = 2;
            byte Speed = 1;
            ushort StayTime = 100;
            byte RepeatTime = 0;
            ushort ValidLen = 0;
            byte CartoonFrameRate = 0;
            E_arrMode arrMode = 0;
            ushort fontSize = 10;
            uint color = 1;
            byte fontBold = 0;
            byte fontItalic = 0;
            E_txtDirection tdirection = 0;
            ushort txtSpace = 0;
            byte Valign = 2;
            byte Halign = 2;
            EQSound_6G stSoundData = new EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundPerson = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            stSoundData.SoundData = IntPtr.Zero;

            EQareaframeHeader Frame = new EQareaframeHeader();
            Frame.AreaFFlag = 0;
            Frame.AreaFDispStyle = 0x03;
            Frame.AreaFDispSpeed = 0x10;
            Frame.AreaFMoveStep = 0x01;
            Frame.AreaFWidth = 2;
            Frame.AreaFBackup = 0;
            //Frame.pStrFramePathFile = Encoding.Default.GetBytes("F:\\黄10.png");// Class1.BytesToIntptr(Encoding.Default.GetBytes("F:\\黄10.png"));

            DynamicAreaBaseInfo_5G pheader = new DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.oFont.arrMode = arrMode;
            pheader.oFont.fontSize = fontSize;
            pheader.oFont.color = color;
            pheader.oFont.fontBold = fontBold;
            pheader.oFont.fontItalic = fontItalic;
            pheader.oFont.tdirection = tdirection;
            pheader.oFont.txtSpace = txtSpace;
            pheader.oFont.Valign = Valign;
            pheader.oFont.Halign = Halign;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader.fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            pheader.strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, pheader.strAreaTxtContent, str.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, pheader.filePath, img.Length);
            DynamicAreaBaseInfo_5G[] Params = new DynamicAreaBaseInfo_5G[1];
            Params[0] = pheader;
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, ref Params);
            }
            //串口
            else
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_G6_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, ref Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
        }
        /// <summary>
        /// 一次向一个动态区发送/更新多条信息（文字或图片）及语音
        /// </summary>
        public static void dynamicArea_pages_1()
        {
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
            stSoundData.SoundFlag = 0;
            stSoundData.SoundPerson = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            stSoundData.SoundData = IntPtr.Zero;

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
                pStrFramePathFile = Encoding.Default.GetBytes("F:\\黄10.png")//Class1.BytesToIntptr(Encoding.Default.GetBytes("F:\\黄10.png"));
            };
            DynamicAreaBaseInfo_5G pheader = new DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.oFont.arrMode = arrMode;
            pheader.oFont.fontSize = fontSize;
            pheader.oFont.color = color;
            pheader.oFont.fontBold = fontBold;
            pheader.oFont.fontItalic = fontItalic;
            pheader.oFont.tdirection = tdirection;
            pheader.oFont.txtSpace = txtSpace;
            pheader.oFont.Valign = Valign;
            pheader.oFont.Halign = Halign;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader.fontName, Font.Length);
            string s = "48" + ran.Next(9, 999) + "\0";
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("123456789");
            pheader.strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, pheader.strAreaTxtContent, str.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("20210429_152928_305.png\0");
            pheader.filePath = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, pheader.filePath, img.Length);
            DynamicAreaBaseInfo_5G pheader1 = new DynamicAreaBaseInfo_5G();
            pheader1.nType = 0x02;
            pheader1.DisplayMode = DisplayMode;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = Speed;
            pheader1.StayTime = 200;
            pheader1.RepeatTime = RepeatTime;
            pheader1.oFont.arrMode = arrMode;
            pheader1.oFont.fontSize = fontSize;
            pheader1.oFont.color = color;
            pheader1.oFont.fontBold = fontBold;
            pheader1.oFont.fontItalic = fontItalic;
            pheader1.oFont.tdirection = tdirection;
            pheader1.oFont.txtSpace = txtSpace;
            pheader1.oFont.Valign = Valign;
            pheader1.oFont.Halign = Halign;
            pheader1.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader1.fontName, Font.Length);
            byte[] str1 = Encoding.GetEncoding("GBK").GetBytes("3333\0");
            pheader1.strAreaTxtContent = Marshal.AllocHGlobal(str1.Length);
            Marshal.Copy(str1, 0, pheader1.strAreaTxtContent, str1.Length);
            byte[] img1 = Encoding.GetEncoding("GBK").GetBytes("6.png\0");
            pheader1.filePath = Marshal.AllocHGlobal(img1.Length);
            Marshal.Copy(img1, 0, pheader1.filePath, img1.Length);
            DynamicAreaBaseInfo_5G[] Params = new DynamicAreaBaseInfo_5G[1];
            Params[0] = pheader;
            //Params[1] = pheader1;
            bxdualsdk.BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            //网口
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_6G_V2(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_THREE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, Params, ref stSoundData);
            }
            //串口
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
        }
    }
    /// <summary>
    /// 向控制卡发送节目，多区域
    /// </summary>
    class Program_Send_Areas
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5代控制卡发送节目多区域
        /// </summary>
        public static void Send_program_areas_5()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //创建节目，设置节目属性
            EQprogramHeader header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x05;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x04;
            header.ProgramLifeSpan_ed = 0x12;
            err = bxdualsdk.BxDual_program_addProgram(ref header);
            Console.WriteLine("bxDual_program_addProgram:" + err);

            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 16;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //添加显示内容，此处为图文分区0添加字符串
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("显示数据");
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.arrMode = E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt(0, str, Font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt:" + err);

            //创建显示分区，设置区域显示位置，示例创建一个区域编号为1，区域大小64 * 32的时间分区，Y轴64，区域之间不可重叠
            EQareaHeader aheader1;
            aheader1.AreaType = 2;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            err = bxdualsdk.BxDual_program_AddArea(1, ref aheader1);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //添加时间区域显示内容
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eMULTILINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "宋体";
            timeData2.fontSize = 12;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 0;
            timeData2.datestyle = E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 1;
            timeData2.timestyle = E_TimeStyle.eHH_MM_AM;
            timeData2.week_enable = 0;
            timeData2.weekstyle = E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.BxDual_program_timeAreaAddContent(1, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent:" + err);

            //发送节目到显示屏
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {

                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsEndFileTransf:" + err);
            }

            err = bxdualsdk.BxDual_program_freeBuffer(ref program);
            Console.WriteLine("bxDual_program_freeBuffer:" + err);
        }
    }
    /// <summary>
    /// 向控制卡发送节目表盘调用示例
    /// </summary>
    class Program_Send_clock
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5代控制卡发送节目表盘
        /// </summary>
        public static void Send_program_clock_5()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x05;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x04;
            header.ProgramLifeSpan_ed = 0x12;
            err = bxdualsdk.BxDual_program_addProgram(ref header);
            Console.WriteLine("bxDual_program_addProgram:" + err);

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的时间分区
            EQareaHeader aheader;
            aheader.AreaType = 2;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //第四步，添加表盘区域显示内容
            EQAnalogClockHeader_G56 acheader;
            acheader.OrignPointX = 32;
            acheader.OrignPointY = 16;
            acheader.UnitMode = 0x00;
            acheader.HourHandWidth = 0x02;
            acheader.HourHandLen = 0x08;
            acheader.HourHandColor = 0x01;
            acheader.MinHandWidth = 0x02;
            acheader.MinHandLen = 0x0b;
            acheader.MinHandColor = 0x01;
            acheader.SecHandWidth = 0x02;
            acheader.SecHandLen = 0x0d;
            acheader.SecHandColor = 0x01;
            ClockColor_G56 ClockColor;
            ClockColor.Color369 = 0xff0000;
            ClockColor.ColorDot = 0xff0000;
            ClockColor.ColorBG = 0xff0000;
            err = bxdualsdk.BxDual_program_timeAreaAddAnalogClock(0, ref acheader, E_ClockStyle.eCIRCLE, ref ClockColor);
            Console.WriteLine("bxDual_program_timeAreaAddAnalogClock:" + err);

            //第五步，发送节目到显示屏
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsEndFileTransf:" + err);
            }

            err = bxdualsdk.BxDual_program_freeBuffer(ref program);
            Console.WriteLine("bxDual_program_freeBuffer:" + err);
        }
        /// <summary>
        /// BX-6代控制卡发送节目表盘
        /// </summary>
        public static void Send_program_clock_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的时间分区
            EQareaHeader_G6 aheader;
            aheader.AreaType = 2;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            byte[] t = new byte[1];
            t[0] = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //第四步，添加表盘显示内容
            EQAnalogClockHeader_G56 acheader;
            acheader.OrignPointX = 32;
            acheader.OrignPointY = 16;
            acheader.UnitMode = 0x00;
            acheader.HourHandWidth = 0x02;
            acheader.HourHandLen = 0x08;
            acheader.HourHandColor = 0x01;
            acheader.MinHandWidth = 0x02;
            acheader.MinHandLen = 0x0b;
            acheader.MinHandColor = 0x01;
            acheader.SecHandWidth = 0x02;
            acheader.SecHandLen = 0x0d;
            acheader.SecHandColor = 0x01;
            ClockColor_G56 ClockColor;
            ClockColor.Color369 = 0xff0000;
            ClockColor.ColorDot = 0xff0000;
            ClockColor.ColorBG = 0xff0000;
            err = bxdualsdk.BxDual_program_timeAreaAddAnalogClock_G6(0, ref acheader, E_ClockStyle.eCIRCLE, ref ClockColor);
            Console.WriteLine("bxDual_program_timeAreaAddAnalogClock_G6:" + err);
            byte[] img = Encoding.Default.GetBytes("time.png");
            //添加表盘图片
            //err = bxdualsdk.BxDual_program_timeAreaChangeDialPic_G6(areaID, img);
            //删除表盘图片
            //err = bxdualsdk.BxDual_program_timeAreaRemoveDialPic_G6(areaID);
            //修改表盘样式
            //err = bxdualsdk.BxDual_program_timeAreaChangeAnalogClock_G6(areaID, ref acheader, bxdualsdk.E_ClockStyle.eCIRCLE, ref ClockColor);

            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
    }
    /// <summary>
    /// 向控制卡发送节目图片调用示例，仅支持png格式
    /// </summary>
    class Program_Send_png
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5代控制卡发送节目图片
        /// </summary>
        public static void Send_program_png_5()
        {
            Console.WriteLine(DateTime.Now.ToString());
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x05;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x04;
            header.ProgramLifeSpan_ed = 0x12;
            err = bxdualsdk.BxDual_program_addProgram(ref header);
            Console.WriteLine("bxDual_program_addProgram:" + err);

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //第四步，添加显示内容，此处为图文分区0添加图片，该步骤可多次调用，添加多张图片，每张图片用不同的编号
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("0.png\0");
            EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 500;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.arrMode = E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            err = bxdualsdk.BxDual_program_pictureAreaAddPic(0, 0, ref pheader, img);
            Console.WriteLine("bxDual_program_pictureAreaAddPic:" + err);

            //第五步，发送节目到显示屏
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {

                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsEndFileTransf:" + err);
            }

            err = bxdualsdk.BxDual_program_freeBuffer(ref program);
            Console.WriteLine("bxDual_program_freeBuffer:" + err);
            Console.WriteLine(DateTime.Now.ToString());
        }

        /// <summary>
        /// BX-6代控制卡发送节目图片
        /// </summary>
        public static void Send_program_png_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            byte[] t = new byte[1];
            t[0] = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //第四步，添加显示内容，此处为图文分区0添加图片，该步骤可多次调用，添加多张图片，每张图片用不同的编号
            //byte[] img = Encoding.GetEncoding("GBK").GetBytes("1230.png");
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("326.png");
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;//移动模式
            pheader.ClearMode = 0x01;
            pheader.Speed = 15;//速度
            pheader.StayTime = 0;//停留时间
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = E_arrMode.eSINGLELINE;
            pheader.fontSize = 10;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            err = bxdualsdk.BxDual_program_pictureAreaAddPic_G6(0, 0, ref pheader, img);
            Console.WriteLine("bxDual_program_pictureAreaAddPic_G6:" + err);

            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
    }
    class Program_Send_Sensor
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5代控制卡发送节目文本
        /// </summary>
        public static void Send_program_sensor_5()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = 0;
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);
            }
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x05;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x04;
            header.ProgramLifeSpan_ed = 0x12;
            err = bxdualsdk.BxDual_program_addProgram(ref header);
            Console.WriteLine("bxDual_program_addProgram:" + err);
            //节目添加边框属性
            if (false)
            {
                EQscreenframeHeader sfheader;
                sfheader.FrameDispFlag = 0x01;
                sfheader.FrameDispStyle = 0x01;
                sfheader.FrameDispSpeed = 0x10;
                sfheader.FrameMoveStep = 0x01;
                sfheader.FrameWidth = 2;
                sfheader.FrameBackup = 0;
                byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
                bxdualsdk.BxDual_program_addFrame(ref sfheader, img);
            }
            //节目添加播放时段,目前仅支持一组时间，多组不支持，Time有效，Time1无效
            if (false)
            {
                EQprogrampTime_G56 Time;
                Time.StartHour = 0x13;
                Time.StartMinute = 0x25;
                Time.StartSecond = 0x00;
                Time.EndHour = 0x13;
                Time.EndMinute = 0x26;
                Time.EndSecond = 0x00;
                EQprogrampTime_G56 Time1;
                Time1.StartHour = 0x13;
                Time1.StartMinute = 0x27;
                Time1.StartSecond = 0x00;
                Time1.EndHour = 0x13;
                Time1.EndMinute = 0x28;
                Time1.EndSecond = 0x00;

                EQprogramppGrp_G56 headerGrp;
                headerGrp.playTimeGrpNum = 2;
                headerGrp.timeGrp0 = Time;
                headerGrp.timeGrp1 = Time1;
                headerGrp.timeGrp2 = Time;
                headerGrp.timeGrp3 = Time;
                headerGrp.timeGrp4 = Time;
                headerGrp.timeGrp5 = Time;
                headerGrp.timeGrp6 = Time;
                headerGrp.timeGrp7 = Time;
                err = bxdualsdk.BxDual_program_addPlayPeriodGrp(ref headerGrp);
                Console.WriteLine("program_addPlayPeriodGrp:" + err);
            }

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的温度分区
            /*温度区：0x03
             湿度区：0x04
            噪声区：0x05*/
            EQareaHeader aheader;
            aheader.AreaType = 0x03;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);
            //区域添加边框
            if (false)
            {
                EQareaframeHeader afheader;
                afheader.AreaFFlag = 0x01;
                afheader.AreaFDispStyle = 0x01;
                afheader.AreaFDispSpeed = 0x08;
                afheader.AreaFMoveStep = 0x01;
                afheader.AreaFWidth = 3;
                afheader.AreaFBackup = 0;
                byte[] img = Encoding.Default.GetBytes("黄10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame(0, ref afheader, img);
            }

            //第四步，添加显示内容，此处为温度分区添加内容属性
            byte nSensorType = 0x02;         //	1		0x00	传感器类型：//0x00 – DS18B20 //0x01 – SHT1XXX //0x02:S-RHT2
            byte nTemperatureUnit = 0;    //	1		0x00	温度单位：0x00–摄氏度; 0x01–华氏度
            byte nTermperatureMode = 0;   //	1		0x00	温度显示模式：0x00 –整数模式(25C); 0x01 –小数模式(25.5C);
            byte nTemperatureCorrectionPol = 0;// 1 	0x00	传感器修正值极性 注：0 –正， 1 –负
            byte nTemperatureCorrection = 0;  // 1 	0x00	传感器修正值（单位：摄氏度）注：此参数为符号整型，单位为0.1
            byte nTemperatureThreshPol = 2;   // 1 	0x00	温度阈值极性 注：Bit0 –极性，0 正， 1 负; Bit1 - 0表示小于此值触发事情，1表示大于此值触发条件
            byte nTemperatureThresh = 30;     // 1	0x00	温度阈值
            byte nTemperatureColor = 2;      // 1			正常温度颜色
            byte nTemperatureErrColor = 1;    // 1			温度超过阈值时显示的颜色
            byte[] pstrFixTxt = Encoding.GetEncoding("GBK").GetBytes("1hello\0");//Ouint8 StaticTextOption;//1	固定文本选项 0x00–无固定文本; 0x01–有	
            byte nFontSize = 12;
            byte[] pstrFontNameFile = Encoding.GetEncoding("GBK").GetBytes("E:/WorkGit/bx.dual.demo.cplus/allfonts/1.ttf\0");
            byte nUnitShowRation = 80;         // 显示的单位字体大小与正常显示文本的大小的比例；
            err = bxdualsdk.BxDual_program_SetSensorAreaTemperature_G5(0, nSensorType, nTemperatureUnit, nTermperatureMode,
                                    nTemperatureCorrectionPol, nTemperatureCorrection, nTemperatureThreshPol, nTemperatureThresh, nTemperatureColor,
                                    nTemperatureErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt:" + err);

            //湿度区域内容
            if (false) { }
            //噪声区域内容
            if (false) { }

            //第五步，发送节目到显示屏
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {

                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsEndFileTransf:" + err);
            }

            err = bxdualsdk.BxDual_program_freeBuffer(ref program);
            Console.WriteLine("bxDual_program_freeBuffer:" + err);
        }

        /// <summary>
        /// BX-6代控制卡发送节目文本
        /// </summary>
        public static void Send_program_sensor_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = 0;
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);
            }
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            Console.WriteLine("\r\n");

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);
            //节目添加播放时段,目前仅支持一组时间，多组不支持
            if (false)
            {
                EQprogrampTime_G56 Time;
                Time.StartHour = 0x17;
                Time.StartMinute = 0x29;
                Time.StartSecond = 0x00;
                Time.EndHour = 0x17;
                Time.EndMinute = 0x30;
                Time.EndSecond = 0x00;

                EQprogramppGrp_G56 headerGrp;
                headerGrp.playTimeGrpNum = 1;
                headerGrp.timeGrp0 = Time;
                headerGrp.timeGrp1 = Time;
                headerGrp.timeGrp2 = Time;
                headerGrp.timeGrp3 = Time;
                headerGrp.timeGrp4 = Time;
                headerGrp.timeGrp5 = Time;
                headerGrp.timeGrp6 = Time;
                headerGrp.timeGrp7 = Time;
                err = bxdualsdk.BxDual_program_addPlayPeriodGrp_G6(ref headerGrp);
                Console.WriteLine("program_addPlayPeriodGrp:" + err);
            }
            //节目添加边框
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
                bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, img);
            }

            //第三步，创建显示分区，设置区域显示位置，示例创建一个传感器分区
            EQareaHeader_G6 aheader;
            aheader.AreaType = 3;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();//该语音属性在节目无效
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            byte[] t = new byte[1];
            t[0] = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //区域添加边框
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长，单位为点，此参 数范围为 1~16 
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("E:\\黄10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }

            //第四步，添加传感器属性内容
            byte SensorModeDispType = 1;  // 1 0x00 显示模式;	0x00–整数模式
            byte SensorCorrectionPol = 1; // 1 0x00 传感器修正值极性 注： 0–正， 1–负
            ushort SensorCorrection = 1;   // 4 0x00 传感器修正值; 当小数模式无效或小数部分位数等于0或255时，以0.1为单位；
            byte nRatioValue = 90;      //单位显示比例：默认100
                                        //0：代表温度//1：代表湿度//2：代表噪声//3：代表 PM2.5（空气质量变送器）
                                        //4：代表 PM10（空气质量变送器）	//5： RS485 型风向变送器	//6： RS485 型风速变换器	//7：大气压力	//8：车速
                                        //9：光照	//10： 0x0A： 水位计	//11： 0x0B: 代表 TSP	//12： 0x0C : 负氧离子监测仪
                                        //0xff：万能传感器，该类型是 BX - 6XX - MODBUS系列专用类型，当传感器类型为该值时，下面的 SensorType、 SensorUnit、 DisplayUnitFlag均设置为 0，对于通用系列控制卡，该值为非0xff 的值
            byte nSensorMode = 1;
            byte nSensorType = 1;  //1:S-RHT2(3线）
            byte nSensorUnit = 0;    // 1 0x00 单位温度：0x00 –摄氏度 0x01 –华氏度;  水位计 0x00 –m, 0x01 –cm
            byte nDisplayUnitFlag = 1;//	是否显示单位 0：不显示; 1：显示; 默认 = 1;
            byte[] pFixedTxt = Encoding.GetEncoding("GBK").GetBytes("1\0");
            byte[] pFontName = Encoding.GetEncoding("GBK").GetBytes("E:/WorkGit/bx.dual.demo.cplus/allfonts/1.ttf\0");
            err = bxdualsdk.BxDual_program_SetSensorArea_G6(0,
                nSensorMode, nSensorType, nSensorUnit, pFixedTxt, pFontName, 16,
                0x02, 0x01, 60, 0x02,
                nDisplayUnitFlag, SensorModeDispType, SensorCorrectionPol, SensorCorrection, nRatioValue);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);

            //添加语音,该功能仅部分控制卡支持，一个节目只能在一个图文区添加语音播报
            if (false)
            {
                byte[] soundstr = Encoding.GetEncoding("gb2312").GetBytes("请张三到1号窗口取药");
                EQPicAreaSoundHeader_G6 psoundheader;
                psoundheader.SoundPerson = 3;
                psoundheader.SoundVolum = 5;
                psoundheader.SoundSpeed = 5;
                psoundheader.SoundDataMode = 0;
                psoundheader.SoundReplayTimes = 0;
                psoundheader.SoundReplayDelay = 1000;
                psoundheader.SoundReservedParaLen = 3;
                psoundheader.Soundnumdeal = 1;
                psoundheader.Soundlanguages = 1;
                psoundheader.Soundwordstyle = 1;
                err = bxdualsdk.BxDual_program_pictureAreaEnableSound_G6(0, psoundheader, soundstr);
                Console.WriteLine("program_pictureAreaEnableSound_G6:" + err);
            }

            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                if (err != 0) { return; }
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
    }
    /// <summary>
    /// 向控制卡发送节目时间调用示例
    /// </summary>
    class Program_Send_time
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5代控制卡发送节目时间
        /// </summary>
        public static void Send_program_time_5()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x05;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x04;
            header.ProgramLifeSpan_ed = 0x12;
            err = bxdualsdk.BxDual_program_addProgram(ref header);
            Console.WriteLine("bxDual_program_addProgram:" + err);

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的时间分区
            EQareaHeader aheader;
            aheader.AreaType = 2;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //第四步，添加时间区域显示内容
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eMULTILINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "宋体";
            timeData2.fontSize = 11;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 1;
            timeData2.datestyle = E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 0;
            timeData2.timestyle = E_TimeStyle.eHH_MM_AM;
            timeData2.week_enable = 0;
            timeData2.weekstyle = E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.BxDual_program_timeAreaAddContent(0, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent:" + err);
            EQtimeAreaData_G56 timeData1;
            timeData1.linestyle = E_arrMode.eMULTILINE;
            timeData1.color = (uint)E_Color_G56.eRED;
            timeData1.fontName = "SunSIM.ttf";
            timeData1.fontSize = 11;
            timeData1.fontBold = 0;
            timeData1.fontItalic = 0;
            timeData1.fontUnderline = 0;
            timeData1.fontAlign = 0;  //0--左对齐，1-居中，2-右对齐
            timeData1.date_enable = 1;
            timeData1.datestyle = E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData1.time_enable = 0;
            timeData1.timestyle = E_TimeStyle.eHH_MM_AM;
            timeData1.week_enable = 0;
            timeData1.weekstyle = E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.BxDual_program_fontPath_timeAreaAddContent(0, ref timeData1);
            Console.WriteLine("bxDual_program_timeAreaAddContent:" + err);

            //第五步，发送节目到显示屏
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {

                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsEndFileTransf:" + err);
            }

            err = bxdualsdk.BxDual_program_freeBuffer(ref program);
            Console.WriteLine("bxDual_program_freeBuffer:" + err);
        }

        /// <summary>
        /// BX-6代控制卡发送节目时间
        /// </summary>
        public static void Send_program_time_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的时间分区
            EQareaHeader_G6 aheader;
            aheader.AreaType = 2;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 96;
            aheader.AreaHeight = 16;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            byte[] t = new byte[1];
            t[0] = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //区域添加边框
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长，单位为点，此参 数范围为 1~16 
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("E:\\黄10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }
            //计时添加
            if (false)
            {
                BXG6_Time_Counter Battle = new BXG6_Time_Counter();
                Battle.UnitColor = 0x01;
                Battle.UnitMode = 0x02;
                Battle.DestYear = 0x2021;
                Battle.DestMonth = 0x2;
                Battle.DestDate = 0x18;
                Battle.DestHour = 0x12;
                Battle.DestMinute = 0x30;
                Battle.DestSecond = 0x00;
                Battle.TimerFormat = 204;
                Battle.DayLen = 0x00;
                Battle.HourLen = 0x00;
                Battle.MinuteLen = 0x00;
                Battle.SecondLen = 0x00;

                byte[] cUnitDay = Encoding.GetEncoding("GBK").GetBytes("天");
                byte[] cUnitHour = Encoding.GetEncoding("GBK").GetBytes("时");
                byte[] cUnitMinute = Encoding.GetEncoding("GBK").GetBytes("分");
                byte[] cUnitSec = Encoding.GetEncoding("GBK").GetBytes("秒");
                byte[] pFixedTxt = Encoding.GetEncoding("GBK").GetBytes("");
                err = bxdualsdk.BxDual_program_timeAreaAddCounterTimer_G6(0, ref Battle, cUnitDay, cUnitHour, cUnitMinute, cUnitSec, pFixedTxt);
            }
            //第四步，添加时间显示内容
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eSINGLELINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "宋体";
            timeData2.fontSize = 10;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 0;
            timeData2.datestyle = E_DateStyle.eYYYY_MM_DD_CHS;
            timeData2.time_enable = 1;
            timeData2.timestyle = E_TimeStyle.eHH_MM_SS_COLON;
            timeData2.week_enable = 0;
            timeData2.weekstyle = E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.BxDual_program_timeAreaAddContent_G6(0, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent_G6:" + err);

            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
        /// <summary>
        /// 战斗时间
        /// </summary>
        public static void Send_program_battieTime_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的时间分区
            EQareaHeader_G6 aheader;
            aheader.AreaType = 9;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            byte[] t = new byte[1];
            t[0] = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);
            Console.WriteLine("bxDual_program_addArea_G6:" + err);


            EQTimeAreaBattle_G6 timebattie = new EQTimeAreaBattle_G6();
            timebattie.BattleStartYear = 0x2020;     //起始年份（BCD格式，下同）
            timebattie.BattleStartMonth = 0x01;    //起始月份
            timebattie.BattleStartDate = 0x01;     //起始日期
            timebattie.BattleStartHour = 0x01;     //起始小时
            timebattie.BattleStartMinute = 0x01;   //起始分钟
            timebattie.BattleStartSecond = 0x01;   //起始秒钟
            timebattie.BattleStartWeek = 0x01;     //起始星期值
            timebattie.StartUpMode = 0;
            err = bxdualsdk.BxDual_program_timeAreaSetBattleTime_G6(0, ref timebattie);
            Console.WriteLine("bxDual_program_timeAreaSetBattleTime_G6:" + err);

            //第五步，发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//网口
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);

            BattleTime Battle = new BattleTime();
            Battle.BattleRTCYear = 0x2020;
            Battle.BattleRTCMonth = 0x03;
            Battle.BattleRTCDate = 0x05;
            Battle.BattleRTCHour = 0x10;
            Battle.BattleRTCMinute = 0x10;
            Battle.BattleRTCSecond = 0x10;
            Battle.BattleRTCWeek = 255;
            err = bxdualsdk.BxDual_cmd_battieTime(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0, ref Battle);
        }
    }
    class Server
    {
        static ILedBxServerSdkProxy bxduaisdkServer = LedBxDualSdk.CreateServer();
        public static List<Tuble<byte[], int>> server_list = new List<Tuble<byte[], int>>();
        public static void Server_get()
        {
            int err = 0;
            int ServerPort = 8134;
            int port = 5005;
            //启动服务器
            int pServer = bxduaisdkServer.BxDual_Start_Server(ServerPort);
            byte[] cards = new byte[2048];
            //控制卡上线个数
            int count = 0;
            Thread.Sleep(2000);
            count = 0;
            server_list.Clear();

            for (int i = 0; i < 2048; i++) { cards[i] = 0; }
            while (count == 0)
            {
                //获取控制卡数据与上线数量
                count = bxduaisdkServer.BxDual_Get_CardList(cards);
                Thread.Sleep(1000);
            }
            server_list.Clear();
            //一个控制卡数据20个长度
            for (int i = 0; i < count; i++)
            {
                //前16位数据是控制卡网络ID编号
                byte[] barcodevalue = cards.Skip(0 + i * 20).Take(16).ToArray();
                //根据网络ID获取通讯使用端口
                port = bxduaisdkServer.BxDual_Get_Port_Barcode(barcodevalue);
                var price = new Tuble<byte[], int>(barcodevalue, port);
                server_list.Add(price);
                string ssss = Encoding.Default.GetString(barcodevalue);
                Console.WriteLine("barcode:" + i + "：" + System.Text.Encoding.Default.GetString(barcodevalue) + "   port:" + port);
                //server_list.Add(price);
            }
            //启动线程，判断控制卡在线情况
            Thread thread = new Thread(t => Get());
            thread.Start();
            bool pl = false;
            while (pl)
            {
                //以第一张上线控制卡做通信示例
                //服务器IP
                byte[] server_ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.100");
                OnbonLedBxSdkUT.address = server_ip;
                var server_list1 = server_list;
                if (server_list1.Count == 1)
                {
                    for (int a = 0; a < server_list1.Count; a++)
                    {
                        int p = server_list1[a].Item2;
                        Thread thread1 = new Thread(t => SendTextMsg(p));
                        thread1.Start();
                    }
                }
                Thread.Sleep(1000); //pl = false;
            }
            //关闭服务器
            //err = bxduaisdkServer.bxDual_Stop_Server(pServer);
            //结束线程
            //thread.Abort();
            //while (thread.ThreadState != ThreadState.Aborted)
            //{
            //    Thread.Sleep(100);
            //}

            //bxduaisdkServer.bxDual_ReleaseSdk();
        }
        public static void Get()
        {
            while (true)
            {
                byte[] cards = new byte[2048];
                //控制卡上线个数
                int count = 0;
                //List<ServerList> server_list = new List<ServerList>();
                count = 0;
                server_list.Clear();
                for (int i = 0; i < 2048; i++) { cards[i] = 0; }
                while (count == 0)
                {
                    Thread.Sleep(2000);
                    //获取控制卡数据与上线数量
                    count = bxduaisdkServer.BxDual_Get_CardList(cards);
                    Console.WriteLine(DateTime.Now.ToString() + "    count：" + count);
                }
                if (server_list.Count != count)
                {
                    server_list.Clear();
                    //一个控制卡数据20个长度
                    for (int i = 0; i < count; i++)
                    {
                        //前16位数据是控制卡网络ID编号
                        byte[] barcodevalue = cards.Skip(0 + i * 20).Take(16).ToArray();
                        //根据网络ID获取通讯使用端口
                        int port = bxduaisdkServer.BxDual_Get_Port_Barcode(barcodevalue);
                        SendTextMsg(port);
                        var price = new Tuble<byte[], int>(barcodevalue, port);
                        server_list.Add(price);
                        Console.WriteLine("barcode:" + i + "：" + System.Text.Encoding.Default.GetString(barcodevalue) + "   port:" + port);
                        Thread.Sleep(2000);
                        //server_list.Add(price);
                    }
                }
            }
        }

        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="client"></param>
        private static void SendTextMsg(int port)
        {
            //while (true)
            //{
            try
            {
                EQpageHeader_G6 pheader;
                pheader.PageStyle = 0x00;
                pheader.DisplayMode = 4;
                pheader.ClearMode = 0x00;
                pheader.Speed = 15;
                pheader.StayTime = 0;
                pheader.RepeatTime = 1;
                pheader.ValidLen = 0;
                pheader.CartoonFrameRate = 0x00;
                pheader.BackNotValidFlag = 0x00;
                pheader.arrMode = E_arrMode.eSINGLELINE;
                pheader.fontSize = 12;
                pheader.color = (uint)0x01;
                pheader.fontBold = 0;
                pheader.fontItalic = 0;
                pheader.tdirection = E_txtDirection.pNORMAL;
                pheader.txtSpace = 0;
                pheader.Valign = 1;
                pheader.Halign = 1;
                byte[] str = Encoding.GetEncoding("GBK").GetBytes("1.png\0");
                IntPtr img = Marshal.AllocHGlobal(str.Length);
                Marshal.Copy(str, 0, img, str.Length);
                Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
                //网口
                //动态区优先播放，节目停止播放
                int err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, 0, 0,
                                                      320, 320, ref pheader, img);
                Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err + "=======" + port);
                Console.WriteLine("发送节目完成" + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //}
        }
    }

}
