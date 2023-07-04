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
        [TestMethod]
        public void TestPicture()
        {
            var config = OnbonLedSdkTestConfig.Get();
            var err = config.Item1;
            if (err != 0) { return; }
            var address = config.Item2;
            var portRate = config.Item3;
            var bxdualsdk = config.Item4;
            var data = config.Item5;
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
                ProgramLifeSpan_em = 0x03,
                ProgramLifeSpan_ed = 0x14,
                PlayPeriodGrpNum = 0,
            };
            err = bxdualsdk.BxDual_program_addProgram_G6(ref header);
            if (err != 0) { return; }
            Console.WriteLine("7.添加节目边框");
            EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
            {
                FrameDispStype = (byte)E_FrameDisplayMode.Clockwise,    //边框显示方式
                FrameDispSpeed = 0x10,    //边框显示速度
                FrameMoveStep = 0x01,     //边框移动步长
                FrameUnitLength = 1,   //边框组元长度
                FrameUnitWidth = 1,    //边框组元宽度
                FrameDirectDispBit = 0, //上下左右边框显示标志位，目前只支持6QX-M卡 
            };
            err = bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, OnbonLedSdkTestConfig.SideFrame);
            if (err != 0) { return; }
            Console.WriteLine("8.添加节目区域");
            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            EQareaHeader_G6 aheader = new EQareaHeader_G6
            {
                AreaType = 0x00,
                AreaX = 1,
                AreaY = 1,
                AreaWidth = (ushort)(data.ScreenWidth - 2),
                AreaHeight = 16,
                BackGroundFlag = 0x00,
                Transparency = 101,
                AreaEqual = 0x00,
                stSoundData = new EQSound_6G { SoundData = IntPtr.Zero }, //该语音属性在节目无效
            };
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
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
                fontBold = 0,
                fontItalic = 0,
                tdirection = E_txtDirection.pNORMAL,
                txtSpace = 0,
                Valign = 2,
                Halign = 2,
            };
            var txtBytes = Encoding.GetEncoding("GB2312").GetBytes("654321\0");
            err = bxdualsdk.BxDual_program_picturesAreaAddTxt_G6(0, txtBytes, OnbonLedSdkTestConfig.FontStyle, ref pheader);
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
    }
}
