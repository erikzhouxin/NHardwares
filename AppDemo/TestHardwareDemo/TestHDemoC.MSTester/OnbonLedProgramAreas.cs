using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.OnbonLedBxSDK;
using System.Runtime.InteropServices;
using System.Text;

namespace TestHDemoC.MSTester
{
    /// <summary>
    /// 仰邦科技LED节目多区域
    /// </summary>
    [TestClass]
    public class OnbonLedProgramAreas
    {
        /// <summary>
        /// BX-6代控制卡发送节目多区域
        /// </summary>
        [TestMethod]
        public void Send_program_areas_6()
        {
            var config = OnbonLedSdkTestConfig.Get();
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
            Console.WriteLine("7.添加节目边框");
            //bxdualsdk.BxDual_program_removeFrame_G6();
            ushort areaId = 0;
            Console.WriteLine("8.添加节目区域");
            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            //EQareaHeader_G6 aheader = new EQareaHeader_G6
            //{
            //    AreaType = (byte)E_AreaType.PicTxt,
            //    AreaX = 0,
            //    AreaY = 0,
            //    AreaWidth = data.ScreenWidth,
            //    AreaHeight = 16,
            //    BackGroundFlag = 0x00,
            //    Transparency = 101,
            //    AreaEqual = 0x00,
            //    stSoundData = new EQSound_6G() { SoundData = IntPtr.Zero }
            //};
            //err = bxdualsdk.BxDual_program_addArea_G6(areaId, ref aheader);  //添加图文区域
            //EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
            //{
            //    FrameDispStype = 0x01,
            //    FrameDispSpeed = 0x10,    //边框显示速度
            //    FrameMoveStep = 0x01,     //边框移动步长，单位为点，此参 数范围为 1~16 
            //    FrameUnitLength = 2,   //边框组元长度
            //    FrameUnitWidth = 1,    //边框组元宽度
            //    FrameDirectDispBit = 0//上下左右边框显示标志位，目前只支持6QX-M卡 
            //};
            //bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(1, ref sfheader, OnbonLedSdkTestConfig.SideFrame);

            //areaId++;
            //创建显示分区，设置区域显示位置，示例创建一个区域编号为1，区域大小64 * 32的时间分区，Y轴64，区域之间不可重叠
            EQareaHeader_G6 aheader1 = new EQareaHeader_G6
            {
                AreaType = 2,
                AreaX = 20,
                AreaY = 20,
                AreaWidth = 64,
                AreaHeight = 16,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G { SoundData = IntPtr.Zero }
            };
            err = bxdualsdk.BxDual_program_addArea_G6(areaId, ref aheader1);
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //添加显示内容，此处为图文分区0添加字符串
            byte[] strAreaTxtContent1 = Encoding.GetEncoding("GBK").GetBytes("654321\0");
            EQpageHeader_G6 pheader1 = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = 0x04,//移动模式
                ClearMode = 0x00,
                Speed = 60,//速度
                StayTime = 10,//停留时间
                RepeatTime = 1,
                ValidLen = 15,
                CartoonFrameRate = 0x00,
                BackNotValidFlag = 0x00,
                arrMode = E_arrMode.eSINGLELINE,
                fontSize = 15,
                color = (uint)0x01,
                fontBold = 0,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 0,
                Halign = 0
            };
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(areaId, strAreaTxtContent1, OnbonLedSdkTestConfig.FontStyle, ref pheader1);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);
            //areaId++;
            ////创建显示分区，设置区域显示位置，示例创建一个区域编号为1，区域大小64 * 32的时间分区，Y轴64，区域之间不可重叠
            //EQareaHeader_G6 aheader1 = new EQareaHeader_G6
            //{
            //    AreaType = 2,
            //    AreaX = 20,
            //    AreaY = 20,
            //    AreaWidth = 64,
            //    AreaHeight = 16,
            //    BackGroundFlag = 0x00,
            //    Transparency = 101,
            //    AreaEqual = 0x00,
            //    stSoundData = new EQSound_6G { SoundData = IntPtr.Zero }
            //};
            //err = bxdualsdk.BxDual_program_addArea_G6(areaId, ref aheader1);
            //Console.WriteLine("bxDual_program_addArea_G6:" + err);

            ////添加时间区域显示内容
            //EQtimeAreaData_G56 timeData2 = new EQtimeAreaData_G56
            //{
            //    linestyle = E_arrMode.eMULTILINE,
            //    color = (uint)E_Color_G56.eRED,
            //    fontName = "simsun",
            //    fontSize = 10,
            //    fontBold = 0,
            //    fontItalic = 0,
            //    fontUnderline = 0,
            //    fontAlign = 1,  //0--左对齐，1-居中，2-右对齐
            //    date_enable = 0,
            //    datestyle = E_DateStyle.eYYYY_MM_DD_MINUS,
            //    time_enable = 1,
            //    timestyle = E_TimeStyle.eHH_MM_COLON,
            //    week_enable = 0,
            //    weekstyle = E_WeekStyle.eMonday
            //};
            //err = bxdualsdk.BxDual_program_timeAreaAddContent_G6(areaId, ref timeData2);
            //Console.WriteLine("bxDual_program_timeAreaAddContent_G6:" + err);

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
    }
}
