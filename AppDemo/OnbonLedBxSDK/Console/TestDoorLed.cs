using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.OnbonLedBxSDK;
using System.Runtime.InteropServices;
using System.Text;

namespace OnbonLedBxSDK.Cls
{
    internal class TestDoorLed
    {
        static TestDoorLed()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // 注册编码格式
        }

        public static byte[] FontStyle => ExtterCaller.GB2312Encoding.GetBytes("宋体\0");
        public static Tuble<int, byte[], ushort, ILedBxDualSdkProxy, Ping_data> Get()
        {
            Console.WriteLine("0.开始");
            var bxdualsdk = LedBxDualSdk.Create();
            bxdualsdk.BxDual_InitSdk();
            var address = Encoding.GetEncoding("GBK").GetBytes("192.168.1.250");
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
            err += sendConfigFile(bxdualsdk, address, portRate);
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

        /// <summary>
        /// 设置屏参
        /// </summary>
        public static int sendConfigFile(ILedBxDualSdkProxy bxdualsdk, byte[] address, ushort portRate)
        {
            uint fileLen = 0;
            uint fileCrc = 0;
            byte[] fileName = Encoding.GetEncoding("GBK").GetBytes("C000");
            var err = bxdualsdk.BxDual_cmd_confStartReedFile(address, portRate, fileName, ref fileLen, ref fileCrc);
            byte[] configData = new byte[1024];
            err += bxdualsdk.BxDual_cmd_confReedFileBlock(address, portRate, fileName, configData);

            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ConfigFile_G6)));
            Marshal.Copy(configData, 0, dec, Marshal.SizeOf(typeof(ConfigFile_G6)));
            ConfigFile_G6 data = (ConfigFile_G6)Marshal.PtrToStructure(dec, typeof(ConfigFile_G6));
            Marshal.FreeHGlobal(dec);

            err += bxdualsdk.BxDual_cmd_sendConfigFile_G6(address, portRate, ref data);
            Console.WriteLine(data.GetJsonFormatString());
            return err;
        }
        private static Tuble<int, byte[], ushort, ILedBxDualSdkProxy, Ping_data> Get(int res, byte[] address, ushort portRate, ILedBxDualSdkProxy bxdualsdk, Ping_data data)
        {
            return new Tuble<int, byte[], ushort, ILedBxDualSdkProxy, Ping_data>(res, address, portRate, bxdualsdk, data);
        }

        public static void Send_program_areas_6()
        {
            var config = Get();
            var err = config.Item1;
            if (err != 0) { return; }
            var address = config.Item2;
            var portRate = config.Item3;
            var bxdualsdk = config.Item4;
            var data = config.Item5;

            Console.WriteLine("6.添加节目");
            //创建节目，设置节目属性
            EQprogramHeader_G6 header = new EQprogramHeader_G6
            {
                FileType = 0x00,
                ProgramID = 0,
                ProgramStyle = 0x00,
                ProgramPriority = 0x00,
                ProgramPlayTimes = 1,
                ProgramTimeSpan = 0,
                SpecialFlag = 1,
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

            Console.WriteLine("7.添加节目边框");
            //EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
            //{
            //    FrameDispStype = (byte)E_FrameDisplayMode.Clockwise,
            //    FrameDispSpeed = 0x10,    //边框显示速度
            //    FrameMoveStep = 0x01,     //边框移动步长，单位为点，此参 数范围为 1~16 
            //    FrameUnitLength = 1,   //边框组元长度
            //    FrameUnitWidth = 1,    //边框组元宽度
            //    FrameDirectDispBit = 0//上下左右边框显示标志位，目前只支持6QX-M卡 
            //};
            //bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, SideFrame);
            //bxdualsdk.BxDual_program_removeFrame_G6();
            ushort areaId = 0;
            Console.WriteLine("8.添加节目区域");

            #region // 第一段
            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader = new EQareaHeader_G6
            {
                AreaType = (byte)E_AreaType.PicTxt,
                AreaX = 1,
                AreaY = 1,
                AreaWidth = (ushort)(data.ScreenWidth - 2),
                AreaHeight = 23,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G() { SoundData = IntPtr.Zero }
            };
            err = bxdualsdk.BxDual_program_addArea_G6(areaId, ref aheader);  //添加图文区域

            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //添加显示内容，此处为图文分区0添加字符串
            byte[] strAreaTxtContent = GetBytes("1#精煤仓\0");
            EQpageHeader_G6 pheader = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = (byte)E_DisplayMode.Static,//移动模式
                ClearMode = 0x00,
                Speed = 60,//速度
                StayTime = 10,//停留时间
                RepeatTime = 1,
                ValidLen = 17,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eSINGLELINE,
                fontSize = 17,
                color = (uint)E_Color_G56.eRED,
                fontBold = 1,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 0,
                Halign = 0
            };
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(areaId, strAreaTxtContent, GetBytes("宋体\0"), ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);
            #endregion 第一段
            areaId++;
            #region // 第二段
            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader1 = new EQareaHeader_G6
            {
                AreaType = (byte)E_AreaType.PicTxt,
                AreaX = 1,
                AreaY = 24,
                AreaWidth = (ushort)(data.ScreenWidth - 2),
                AreaHeight = 23,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G() { SoundData = IntPtr.Zero }
            };
            err = bxdualsdk.BxDual_program_addArea_G6(areaId, ref aheader1);  //添加图文区域

            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //添加显示内容，此处为图文分区0添加字符串
            byte[] strAreaTxtContent1 = GetBytes("精煤 1/3焦煤\0");
            EQpageHeader_G6 pheader1 = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = 0x04,//移动模式
                ClearMode = 0x00,
                Speed = 60,//速度
                StayTime = 10,//停留时间
                RepeatTime = 1,
                ValidLen = 10,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eSINGLELINE,
                fontSize = 16,
                color = (uint)0x01,
                fontBold = 1,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 0,
                Halign = 0
            };
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(areaId, strAreaTxtContent1, GetBytes("宋体\0"), ref pheader1);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);
            #endregion 第二段
            areaId++;
            #region // 第三段
            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader2 = new EQareaHeader_G6
            {
                AreaType = (byte)E_AreaType.PicTxt,
                AreaX = 1,
                AreaY = 47,
                AreaWidth = (ushort)(data.ScreenWidth - 2),
                AreaHeight = 20,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G() { SoundData = IntPtr.Zero }
            };
            err = bxdualsdk.BxDual_program_addArea_G6(areaId, ref aheader2);  //添加图文区域
            //添加显示内容，此处为图文分区0添加字符串
            byte[] strAreaTxtContent2 = GetBytes("1#精煤仓1车道\n宁A88888\n煤种不符不允许进入筒仓装煤\0");
            EQpageHeader_G6 pheader2 = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = (byte)E_DisplayMode.MoveUps,//移动模式
                ClearMode = 0x00,
                Speed = 60,//速度
                StayTime = 10,//停留时间
                RepeatTime = 1,
                ValidLen = 10,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eMULTILINE,
                fontSize = 16,
                color = (uint)0x01,
                fontBold = 0,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 0,
                Halign = 0
            };
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(areaId, strAreaTxtContent2, GetBytes("宋体\0"), ref pheader2);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);
            #endregion 第三段
            areaId++;
            #region // 第四段
            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader3 = new EQareaHeader_G6
            {
                AreaType = (byte)E_AreaType.PicTxt,
                AreaX = 1,
                AreaY = 67,
                AreaWidth = (ushort)(data.ScreenWidth - 2),
                AreaHeight = 25,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G() { SoundData = IntPtr.Zero }
            };
            err = bxdualsdk.BxDual_program_addArea_G6(areaId, ref aheader3);  //添加图文区域

            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //添加显示内容，此处为图文分区0添加字符串
            byte[] strAreaTxtContent3 = GetBytes("1#精煤仓2车道\n鲁A88888\n允许进入\0");
            EQpageHeader_G6 pheader3 = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = (byte)E_DisplayMode.MoveUps,//移动模式
                ClearMode = 0x00,
                Speed = 60,//速度
                StayTime = 10,//停留时间
                RepeatTime = 1,
                ValidLen = 10,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eMULTILINE,
                fontSize = 16,
                color = (uint)0x01,
                fontBold = 0,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 0,
                Halign = 0
            };
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(areaId, strAreaTxtContent3, GetBytes("宋体\0"), ref pheader3);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);
            #endregion 第四段

            //发送节目到显示屏
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            //err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(address, portRate);
            Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

            err = bxdualsdk.BxDual_cmd_ofsWriteFile(address, portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
            Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
            err = bxdualsdk.BxDual_cmd_ofsWriteFile(address, portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
            err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(address, portRate);
            Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);

            err = bxdualsdk.BxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
        public static byte[] GetBytes(string file)
        {
            return ExtterCaller.GB2312Encoding.GetBytes(file);
        }
    }
}
