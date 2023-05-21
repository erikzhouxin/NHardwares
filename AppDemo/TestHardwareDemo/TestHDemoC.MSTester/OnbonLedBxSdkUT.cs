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
        //���ƿ�IP
        public static byte[] address;
        //���ƿ��˿�
        public static ushort portRate;
        //ͨѶ��ʽ  true=����  false=����
        public static Boolean isNetwork;

        static OnbonLedBxSdkUT()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // ע������ʽ
            bxdualsdk = LedBxDualSdk.Create();
            isNetwork = true;
            if (isNetwork)
            {
                address = Encoding.GetEncoding("GBK").GetBytes("192.168.0.199");
                portRate = 5005;
            }
            else
            {
                //���ں� "COM1",����9���������⴦����"\\\\.\\COM17"
                address = Encoding.GetEncoding("GBK").GetBytes("COM3");
                //���ڲ����� 1��9600  2��57600
                portRate = 2;
            }
            int err = bxdualsdk.BxDual_InitSdk();
            if (err != 0) { throw new Exception($"LED��SDK��ʼ��ʧ��{err}"); }
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
        /// BX-6�����ƿ����ͽ�Ŀ�ı�
        /// </summary>
        [TestMethod]
        public void TestSendProgramTxt6()
        {
            //Send_program_txt_6(); // ���ͽ�Ŀ�ı�
            //Send_program_areas_6(); // �������ͽ�Ŀ�ı�
            Send_program_txt_6_1();
        }
        /// <summary>
        /// BX-6�����ƿ����ͽ�Ŀ�ı�
        /// </summary>
        public static void Send_program_txt_6()
        {
            Console.WriteLine("��ʼ�༭��Ŀ" + DateTime.Now.ToString());
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
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
            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56(cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);

            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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
            //��Ŀ��Ӳ���ʱ��,Ŀǰ��֧��һ��ʱ�䣬���鲻֧��
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
            //��Ŀ��ӱ߿�
            if (true)
            {
                EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
                {
                    FrameDispStype = 0x01,    //�߿���ʾ��ʽ
                    FrameDispSpeed = 0x3B,    //�߿���ʾ�ٶ�
                    FrameMoveStep = 0x01,     //�߿��ƶ�����
                    FrameUnitLength = 2,   //�߿���Ԫ����
                    FrameUnitWidth = 2,    //�߿���Ԫ���
                    FrameDirectDispBit = 0//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                };
                byte[] img = Encoding.Default.GetBytes("F:\\cenIdea.git\\drive-pc\\LED��ʾSDK\\BX_05_06_SDK_20221107\\bx.dual.C#\\lib\\��10.png\0");
                bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, img);
            }

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ͼ�ķ���
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
                stSoundData = new EQSound_6G { SoundData = IntPtr.Zero }, //�����������ڽ�Ŀ��Ч
            };
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //���ͼ������
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //������ӱ߿�
            if (false)
            {
                EQscreenframeHeader_G6 sfheader = new EQscreenframeHeader_G6
                {
                    FrameDispStype = 0x01,    //�߿���ʾ��ʽ0x00 �C��˸ 0x01 �C˳ʱ��ת�� 0x02 �C��ʱ��ת�� 0x03 �C��˸��˳ʱ��ת�� 0x04 �C��˸����ʱ��ת�� 0x05 �C���̽�����˸ 0x06 �C���̽���ת�� 0x07 �C��ֹ���
                    FrameDispSpeed = 0x10,    //�߿���ʾ�ٶ�
                    FrameMoveStep = 0x01,     //�߿��ƶ���������λΪ�㣬�˲� ����ΧΪ 1~16 
                    FrameUnitLength = 2,   //�߿���Ԫ����
                    FrameUnitWidth = 2,    //�߿���Ԫ���
                    FrameDirectDispBit = 0//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                };
                byte[] img = Encoding.Default.GetBytes("F:\\cenIdea.git\\drive-pc\\LED��ʾSDK\\BX_05_06_SDK_20221107\\bx.dual.C#\\lib\\��10.png\0");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }

            //���Ĳ��������ʾ���ݣ��˴�Ϊͼ�ķ���0����ַ���
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����\0");
            IntPtr font = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, font, Font.Length);
            byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("���Է���1\0");
            IntPtr str = Marshal.AllocHGlobal(strAreaTxtContent.Length);
            Marshal.Copy(strAreaTxtContent, 0, str, strAreaTxtContent.Length);
            EQpageHeader_G6 pheader = new EQpageHeader_G6
            {
                PageStyle = 0x00,
                DisplayMode = 0x4,//�ƶ�ģʽ
                ClearMode = 0x01,
                Speed = 60,//�ٶ�
                StayTime = 0,//ͣ��ʱ��
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

            //�������,�ù��ܽ����ֿ��ƿ�֧�֣�һ����Ŀֻ����һ��ͼ���������������
            if (false)
            {
                byte[] soundstr = Encoding.GetEncoding("gb2312").GetBytes("��������1�Ŵ���ȡҩ");
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

            Console.WriteLine("��ʼ���ͽ�Ŀ" + DateTime.Now.ToString());
            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            if (err != 0) { return; }
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            //err = bxdualsdk.BxDual_set_packetLen(20480);
            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
            Console.WriteLine("���ͽ�Ŀ���" + DateTime.Now.ToString());
        }
        /// <summary>
        /// BX-6�����ƿ����ͽ�Ŀ�ı�
        /// </summary>
        public static void Send_program_txt_6_1()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
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

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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
            //��Ŀ��Ӳ���ʱ��,Ŀǰ��֧��һ��ʱ�䣬���鲻֧��
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
            //��Ŀ��ӱ߿�
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //�߿���ʾ��ʽ
                sfheader.FrameDispSpeed = 0x10;    //�߿���ʾ�ٶ�
                sfheader.FrameMoveStep = 0x01;     //�߿��ƶ�����
                sfheader.FrameUnitLength = 2;   //�߿���Ԫ����
                sfheader.FrameUnitWidth = 2;    //�߿���Ԫ���
                sfheader.FrameDirectDispBit = 0;//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                byte[] img = Encoding.Default.GetBytes("F:\\��10.png");
                bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, img);
            }

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ͼ�ķ���
            EQareaHeader_G6 aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 32;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();//�����������ڽ�Ŀ��Ч
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
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //���ͼ������
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //������ӱ߿�
            if (true)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //�߿���ʾ��ʽ0x00 �C��˸ 0x01 �C˳ʱ��ת�� 0x02 �C��ʱ��ת�� 0x03 �C��˸��˳ʱ��ת�� 0x04 �C��˸����ʱ��ת�� 0x05 �C���̽�����˸ 0x06 �C���̽���ת�� 0x07 �C��ֹ���
                sfheader.FrameDispSpeed = 0x10;    //�߿���ʾ�ٶ�
                sfheader.FrameMoveStep = 0x01;     //�߿��ƶ���������λΪ�㣬�˲� ����ΧΪ 1~16 
                sfheader.FrameUnitLength = 2;   //�߿���Ԫ����
                sfheader.FrameUnitWidth = 2;    //�߿���Ԫ���
                sfheader.FrameDirectDispBit = 0;//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                byte[] img = Encoding.Default.GetBytes("E:\\��10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }

            //���Ĳ��������ʾ���ݣ��˴�Ϊͼ�ķ���0����ַ���
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
            IntPtr font = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, font, Font.Length);
            byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("123456\0");
            IntPtr str = Marshal.AllocHGlobal(strAreaTxtContent.Length);
            Marshal.Copy(strAreaTxtContent, 0, str, strAreaTxtContent.Length);
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;//�ƶ�ģʽ
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;//�ٶ�
            pheader.StayTime = 0;//ͣ��ʱ��
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
            err = bxdualsdk.BxDual_program_addArea_G6(1, ref aheader1);  //���ͼ������
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //������ӱ߿�
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //�߿���ʾ��ʽ0x00 �C��˸ 0x01 �C˳ʱ��ת�� 0x02 �C��ʱ��ת�� 0x03 �C��˸��˳ʱ��ת�� 0x04 �C��˸����ʱ��ת�� 0x05 �C���̽�����˸ 0x06 �C���̽���ת�� 0x07 �C��ֹ���
                sfheader.FrameDispSpeed = 0x10;    //�߿���ʾ�ٶ�
                sfheader.FrameMoveStep = 0x01;     //�߿��ƶ���������λΪ�㣬�˲� ����ΧΪ 1~16 
                sfheader.FrameUnitLength = 2;   //�߿���Ԫ����
                sfheader.FrameUnitWidth = 2;    //�߿���Ԫ���
                sfheader.FrameDirectDispBit = 0;//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                byte[] img = Encoding.Default.GetBytes("E:\\��10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(1, ref sfheader, img);
            }

            //���Ĳ��������ʾ���ݣ��˴�Ϊͼ�ķ���0����ַ���
            EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x02;//�ƶ�ģʽ
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 10;//�ٶ�
            pheader1.StayTime = 0;//ͣ��ʱ��
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

            //�������,�ù��ܽ����ֿ��ƿ�֧�֣�һ����Ŀֻ����һ��ͼ���������������
            if (false)
            {
                byte[] soundstr = Encoding.GetEncoding("gb2312").GetBytes("��������1�Ŵ���ȡҩ");
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

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsStartFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsWriteFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_uart_ofsEndFileTransf(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }

            byte[] strAreaTxtContent1 = Encoding.GetEncoding("GBK").GetBytes("123sdd�ǵ�\0");
            IntPtr str1 = Marshal.AllocHGlobal(strAreaTxtContent1.Length);
            Marshal.Copy(strAreaTxtContent1, 0, str1, strAreaTxtContent1.Length);
            EQpageHeader_G6 pheader2;
            pheader2.PageStyle = 0x00;
            pheader2.DisplayMode = 0x02;//�ƶ�ģʽ
            pheader2.ClearMode = 0x01;
            pheader2.Speed = 10;//�ٶ�
            pheader2.StayTime = 0;//ͣ��ʱ��
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

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
        /// BX-5�����ƿ����ͽ�Ŀ�ı�
        /// </summary>
        public static void Send_program_txt_5()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
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

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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
            //��Ŀ��ӱ߿�����
            if (false)
            {
                EQscreenframeHeader sfheader;
                sfheader.FrameDispFlag = 0x01;
                sfheader.FrameDispStyle = 0x01;
                sfheader.FrameDispSpeed = 0x10;
                sfheader.FrameMoveStep = 0x01;
                sfheader.FrameWidth = 2;
                sfheader.FrameBackup = 0;
                byte[] img = Encoding.Default.GetBytes("F:\\��10.png");
                bxdualsdk.BxDual_program_addFrame(ref sfheader, img);
            }
            //��Ŀ��Ӳ���ʱ��,Ŀǰ��֧��һ��ʱ�䣬���鲻֧�֣�Time��Ч��Time1��Ч
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ͼ�ķ���
            EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);
            //������ӱ߿�
            if (false)
            {
                EQareaframeHeader afheader;
                afheader.AreaFFlag = 0x01;
                afheader.AreaFDispStyle = 0x01;
                afheader.AreaFDispSpeed = 0x08;
                afheader.AreaFMoveStep = 0x01;
                afheader.AreaFWidth = 3;
                afheader.AreaFBackup = 0;
                byte[] img = Encoding.Default.GetBytes("��10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame(0, ref afheader, img);
            }

            //���Ĳ��������ʾ���ݣ��˴�Ϊͼ�ķ���0����ַ���
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("12����");
            byte[] font = Encoding.GetEncoding("GBK").GetBytes("����");
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

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//����
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
        /// BX-6�����ƿ����ͽ�Ŀ������
        /// </summary>
        public static void Send_program_areas_6()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            var cmb_ping_Color = LedBxDualSdk.GetEScreenColor(data.Color);

            //������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56(cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //������Ŀ�����ý�Ŀ����
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

            //������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ͼ�ķ���
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
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //���ͼ������
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //�����ʾ���ݣ��˴�Ϊͼ�ķ���0����ַ���
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
            IntPtr font = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, font, Font.Length);
            byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            IntPtr str = Marshal.AllocHGlobal(strAreaTxtContent.Length);
            Marshal.Copy(strAreaTxtContent, 0, str, strAreaTxtContent.Length);
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x04;//�ƶ�ģʽ
            pheader.ClearMode = 0x01;
            pheader.Speed = 60;//�ٶ�
            pheader.StayTime = 0;//ͣ��ʱ��
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

            //������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ1�������С64 * 32��ʱ�������Y��64������֮�䲻���ص�
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

            //���ʱ��������ʾ����
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eMULTILINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "simsun";
            timeData2.fontSize = 10;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 1;  //0--����룬1-���У�2-�Ҷ���
            timeData2.date_enable = 0;
            timeData2.datestyle = E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 1;
            timeData2.timestyle = E_TimeStyle.eHH_MM_COLON;
            timeData2.week_enable = 0;
            timeData2.weekstyle = E_WeekStyle.eMonday;
            err = bxdualsdk.BxDual_program_timeAreaAddContent_G6(1, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent_G6:" + err);

            //���ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
            //��ʼ����̬��
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
            //Console.Write("�����봮�ڣ�");
            //com = Encoding.GetEncoding("GBK").GetBytes(Console.ReadLine());
            // err = bxdualsdk.BxDual_cmd_check_time(ip, port);
            //if (err == 0) { Console.WriteLine("Уʱ�ɹ�"); } else { Console.WriteLine("Уʱʧ��"); }
            //BX-5�����ƿ�
            if (!isNetwork)
            {
                //Program_Send_Sensor ��Ŀ���ô������������ʾ������
                //Program_Send_Sensor.Send_program_sensor_5();
                //Program_Send_clock�ı�����ʾ������
                //Program_Send_txt.Send_program_txt_5();

                //Program_Send_pngͼƬ����ʾ������
                // Dynamic_5.delete_dynamic();
                //Program_Send_png.Send_program_png_5();

                //Program_Send_timeʱ�����ʾ������
                //Program_Send_time.Send_program_time_5();

                //Program_Send_clock���̵���ʾ������
                //Program_Send_clock.Send_program_clock_5();

                //Program_Send_Areas��Ŀ����������ʾ������
                //Program_Send_Areas.Send_program_areas_5();

                //Send_program_sensor_5 ��Ŀ���ô������������ʾ������
                //Program_Send_Sensor.Send_program_sensor_5();

                //��̬������ʾ��������BX-5Eϵ��ʹ��
                //Dynamic_5.updata_dynamic_pages();
                //Dynamic_5.updata_dynamic_txt();
                //ɾ����̬��
                //Dynamic_5.delete_dynamic();
                //Random ra = new Random();
                //for(int i = 0; i < 10000; i++)
                //{
                //    string str = "ab" + ra.Next(1,4999);
                //    Dynamic_5.updata_tests(0,64,0,44,16, str);
                //     str = "��d" + ra.Next(4999,9999);
                //    Dynamic_5.updata_tests(1,64, 16, 64, 16, str);
                //     str = "gf" + ra.Next(1, 99);
                //    Dynamic_5.updata_tests(2, 108, 0, 20, 16, str);
                //    Thread.Sleep(2000);
                //}
            }
            //BX-6�����ƿ�
            if (isNetwork)
            {
                //Program_Send_Sensor ��Ŀ���ô������������ʾ������
                Program_Send_Sensor.Send_program_sensor_6();

                //common_56.deleteprogram();

                //Program_Send_pngͼƬ����ʾ������
                Program_Send_png.Send_program_png_6();

                //Program_Send_timeʱ�����ʾ������
                //Program_Send_time.Send_program_time_6();

                //Program_Send_clock���̵���ʾ������
                //Program_Send_clock.Send_program_clock_6();

                //Program_Send_Areas��Ŀ����������ʾ������
                //Program_Send_Areas.Send_program_areas_6(); 


                //��̬������ʾ�������ֿ��ƿ�֧��
                //Dynamic_6.dynamicArea_pages_1();
                Dynamic_6.dynamicArea_str_3();
                //Dynamic_6.dynamicArea_png_1();

                //ɾ����̬��
                //Dynamic_6.delete_dynamic();
            }

            //������ģʽ����ʾ��
            if (!isNetwork)
            {
                Server.Server_get();
            }

            //�ͷŶ�̬��
            //bxdualsdk.BxDual_ReleaseSdk();
            Console.ReadKey();
        }
    }
    public class common_56
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        public static int err = 0;
        /// <summary>
        /// ��������,�Ǳ�Ҫ
        /// </summary>
        public static void Set()
        {
            //�������ţ�����ͨѶ
            err = bxdualsdk.BxDual_set_screenNum_G56(1);
            //���ÿ��Ƹ���ͨѶ��ʽÿһ����󳤶�
            err = bxdualsdk.BxDual_set_packetLen(1024);
        }
        /// <summary>
        /// �ļ�ϵͳ��ʽ��,������ʹ��
        /// </summary>
        public static void Format()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsFormat(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_cmd_ofsFormat(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
        }
        //�㲥����
        public static void Net_search()
        {
            Ping_data data = new Ping_data();
            //��������
            err = bxdualsdk.BxDual_cmd_udpPing(ref data);
            //ȫ������udp-tcp-com
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_searchController(ref data);
            }
            //���ݴ�������
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, OnbonLedBxSdkUT.address);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("\r\n");
        }
        //ɾ����Ŀ
        public static void Deleteprogram()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��ȡ��Ŀ�б�
                GetDirBlock_G56 driBlock = new GetDirBlock_G56();
                err = bxdualsdk.BxDual_cmd_ofsReedDirBlock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref driBlock);
                //��ȡ��Ŀ��ϸ��Ϣ
                for (int i = 0; i < driBlock.fileNumber; i++)
                {
                    FileAttribute_G56 fileAttr = new FileAttribute_G56();
                    err = bxdualsdk.BxDual_cmd_getFileAttr(ref driBlock, (ushort)i, ref fileAttr);
                    //ɾ��ָ����Ŀ
                    err = bxdualsdk.BxDual_cmd_ofsDeleteFormatFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, fileAttr.fileName);
                }
                err = bxdualsdk.BxDual_cmd_ofs_freeDirBlock(ref driBlock);
            }
            //����
            else
            {
                //��ȡ��Ŀ�б�
                GetDirBlock_G56 driBlock = new GetDirBlock_G56();
                err = bxdualsdk.BxDual_cmd_uart_ofsReedDirBlock(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, ref driBlock);
                //��ȡ��Ŀ��ϸ��Ϣ
                for (int i = 0; i < driBlock.fileNumber; i++)
                {
                    FileAttribute_G56 fileAttr = new FileAttribute_G56();
                    err = bxdualsdk.BxDual_cmd_getFileAttr(ref driBlock, (ushort)i, ref fileAttr);
                    //ɾ��ָ����Ŀ
                    err = bxdualsdk.BxDual_cmd_uart_ofsDeleteFormatFile(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1, fileAttr.fileName);
                }
                err = bxdualsdk.BxDual_cmd_ofs_freeDirBlock(ref driBlock);
            }
        }
        //��������
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
                err = bxdualsdk.BxDual_cmd_setBrightness(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref brightness);//����
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_cmd_setBrightness_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, ref brightness);
            }
            Console.WriteLine("cmd_setBrightness:" + err);
        }
        /// <summary>
        /// ϵͳ��λ,������ʹ�ã����ú����в���ȫ���ᶪʧ
        /// </summary>
        public static void Reset()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_sysReset(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
            //����
            else
            {
                //Program.com, Program.baudRate
            }
            Console.WriteLine("bxDual_cmd_sysReset:" + err);
        }
        //ǿ�ƿ��ػ�
        public static void CoerceOnOff()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_coerceOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0);//�ػ�
                err = bxdualsdk.BxDual_cmd_coerceOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1);//����
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_cmd_coerceOnOff_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 0);//�ػ�
                err = bxdualsdk.BxDual_cmd_coerceOnOff_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1);//����
            }
        }
        //��ʱ���ػ�
        public static void timingOnOff()
        {
            TimingOnOff[] time = new TimingOnOff[1];
            time[0].onHour = 9;   // ����Сʱ
            time[0].onMinute = 46; // ��������
            time[0].offHour = 20;  // �ػ�Сʱ
            time[0].offMinute = 40; // �ػ�����
            byte[] Time = LedBxDualSdk.StructToBytes(time[0]);
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_timingOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, Time);
                //ȡ����ʱ���ػ�
                err = bxdualsdk.BxDual_cmd_cancelTimingOnOff(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
            Console.WriteLine("bxDual_cmd_timingOnOff:" + err);
        }
        /// <summary>
        /// ��Ļ����
        /// </summary>
        public static void ScreenLock()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_screenLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 1);//��Ļ����
                err = bxdualsdk.BxDual_cmd_screenLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 0);//��Ļ����
            }
            //����
            else
            {
                //Program.com, Program.baudRate
            }
            Console.WriteLine("bxDual_cmd_screenLock:" + err);
        }
        //��Ŀ����
        public static void ProgramLock()
        {
            //��Ŀ����ʽ����ΪP***����P000��P001
            byte[] name = Encoding.GetEncoding("GBK").GetBytes("P000");
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_programLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 1, name, 0xffffffff);//����
                err = bxdualsdk.BxDual_cmd_programLock(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 1, 0, name, 0xffffffff);//����
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_programLock(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1, 1, name, 0xffffffff);//����-����
                err = bxdualsdk.BxDual_cmd_uart_programLock(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 1, 0, name, 0xffffffff);//����-����
            }
            Console.WriteLine("bxDual_cmd_programLock:" + err);
        }
        //��ȡ���ƿռ��С��ʣ��ռ�
        public static void GetMemoryVolume(byte[] ipAdder)
        {
            int totalMemVolume = 0, availableMemVolume = 0;
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_ofsGetMemoryVolume(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref totalMemVolume, ref availableMemVolume);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_cmd_uart_ofsGetMemoryVolume(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, ref totalMemVolume, ref availableMemVolume);
            }
        }
        //��������
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
        /// ��������-������,6�����ƿ�ʹ��
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
                //Mac ��ַ
                str = "Mac:" + CmdRet.Mac[0].ToString("X2") + CmdRet.Mac[1].ToString("X2") + CmdRet.Mac[2].ToString("X2") + CmdRet.Mac[3].ToString("X2") + CmdRet.Mac[4].ToString("X2") + CmdRet.Mac[5].ToString("X2") + System.Environment.NewLine;
                //������ IP ��ַ
                str += "IP:" + LedBxDualSdk.BytesToString(CmdRet.IP) + System.Environment.NewLine;
                //��������
                str += "SubNetMask:" + LedBxDualSdk.BytesToString(CmdRet.SubNetMask) + System.Environment.NewLine;
                //����
                str += "Gate:" + LedBxDualSdk.BytesToString(CmdRet.Gate) + System.Environment.NewLine;
                //�˿�
                str += "Port:" + CmdRet.Port + System.Environment.NewLine;
                //1 ��ʾ DHCP 2 ��ʾ�ֶ�����
                if (CmdRet.IPMode == 1)
                {
                    str += "IPMode:DHCP" + System.Environment.NewLine;
                }
                else
                {
                    str += "IPMode:��ʾ�ֶ�����" + System.Environment.NewLine;
                }
                //0 ��ʾ IP ����ʧ�� 1 ��ʾ IP ���óɹ�
                if (CmdRet.IPMode == 0)
                {
                    str += "IPStatus:IP ����ʧ��" + System.Environment.NewLine;
                }
                else
                {
                    str += "IPStatus:IP ���óɹ�" + System.Environment.NewLine;
                }
                //0 Bit[0]��ʾ������ģʽ�Ƿ�ʹ�ܣ�1 �Cʹ�ܣ�0 �C��ֹ Bit[1]��ʾ������ģʽ��1 �Cweb ģʽ��0 �C��ͨģʽ
                if (CmdRet.ServerMode == 0)
                {
                    str += "ServerMode:������ģʽʹ��    ��ͨģʽ" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 1)
                {
                    str += "ServerMode:������ģʽ��ֹ    ��ͨģʽ" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 2)
                {
                    str += "ServerMode:������ģʽ��ֹ    webģʽ" + System.Environment.NewLine;
                }
                else
                {
                    str += "ServerMode:������ģʽʹ��    webģʽ" + System.Environment.NewLine;
                }
                //������ IP ��ַ
                str += "ServerIPAddress:" + LedBxDualSdk.BytesToString(CmdRet.ServerIPAddress) + System.Environment.NewLine;
                //�������˿ں�
                str += "ServerPort:" + CmdRet.ServerPort + System.Environment.NewLine;
                //��������������
                str += "ServerAccessPassword:" + System.Text.Encoding.Default.GetString(CmdRet.ServerAccessPassword) + System.Environment.NewLine;
                //20S ����ʱ��������λ���룩
                str += "HeartBeatInterval:" + CmdRet.HeartBeatInterval + System.Environment.NewLine;
                //�û��Զ��� ID����Ϊ���� ID ��ǰ�벿�֣������û�ʶ������ƿ�
                str += "CustomID:" + System.Text.Encoding.Default.GetString(CmdRet.CustomID) + System.Environment.NewLine;
                //�����룬��Ϊ���� ID �ĺ�벿�֣�����ʵ������ ID ��Ψһ��
                str += "BarCode:" + System.Text.Encoding.Default.GetString(CmdRet.BarCode) + System.Environment.NewLine;
                //���е�λ�ֽڱ�ʾ�豸ϵ�У�����λ�ֽڱ�ʾ�豸��ţ����� BX - 6Q2 Ӧ��ʾΪ[0x66, 0x02]�������ͺ��������ơ�
                str += "ControllerType:" + (CmdRet.ControllerType[1] * 256 + CmdRet.ControllerType[0]) / 10 + System.Environment.NewLine;
                //Firmware �汾��
                str += "FirmwareVersion:" + System.Text.Encoding.Default.GetString(CmdRet.FirmwareVersion) + System.Environment.NewLine;
                //�����������ļ�״̬ 0x00 �C��������û�в��������ļ������·��ص��ǿ�������Ĭ�ϲ�������ʱ��PC���Ӧ��ʾ�û������ȼ������Ρ�0x01 �C���������в��������ļ�
                if (CmdRet.ScreenParaStatus == 0)
                {
                    str += "ScreenParaStatus:��������û�в��������ļ��������ȼ�������" + System.Environment.NewLine;
                }
                else
                {
                    str += "ScreenParaStatus:���������в��������ļ�" + System.Environment.NewLine;
                }
                //0x0001 ��������ַ����������Ĭ�ϵ�ַΪ 0x0001(0x0000 ��ַ������)���Ƴ��˶Է��͸������ַ�����ݰ����д����⣬����Թ㲥���ݰ����д���
                str += "Address:" + CmdRet.Address + System.Environment.NewLine;
                //0x00 ������ 0x00 �C����ԭ�в����ʲ��� 0x01 �Cǿ������Ϊ 9600 0x02 �Cǿ������Ϊ 57600
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
                    str += "Baudrate:����ԭ�в����ʲ���" + System.Environment.NewLine;
                }
                //��ʾ�����
                str += "ScreenWidth:" + CmdRet.ScreenWidth + System.Environment.NewLine;
                //��ʾ���߶�
                str += "ScreenHeight:" + CmdRet.ScreenHeight + System.Environment.NewLine;
                //0x01 �����޻Ҷ�ϵͳ����ɫʱ���� 1��˫ɫʱ���� 3����ɫʱ���� 7�������лҶ�ϵͳ������ 255
                if (CmdRet.Color == 1)
                {
                    str += "Color:��ɫ" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 3)
                {
                    str += "Color:˫ɫ" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 7)
                {
                    str += "Color:��ɫ" + System.Environment.NewLine;
                }
                else
                {
                    str += "Color:�Ҷ�ȫ��" + System.Environment.NewLine;
                }
                //����ģʽ 0x00 �C�ֶ����� 0x01 �C��ʱ���� 0x02 �C�Զ�����
                if (CmdRet.BrightnessAdjMode == 0)
                {
                    str += "BrightnessAdjMode:�ֶ�����" + System.Environment.NewLine;
                }
                else if (CmdRet.BrightnessAdjMode == 1)
                {
                    str += "BrightnessAdjMode:��ʱ����" + System.Environment.NewLine;
                }
                else
                {
                    str += "BrightnessAdjMode:�Զ�����" + System.Environment.NewLine;
                }
                //��ǰ����ֵ
                str += "CurrentBrigtness:" + CmdRet.CurrentBrigtness + System.Environment.NewLine;
                //Bit0 �C��ʱ���ػ�״̬��0 ��ʾ�޶�ʱ���ػ���1 ��ʾ�ж�ʱ���ػ�
                if (CmdRet.TimingOnOff == 0)
                {
                    str += "TimingOnOff:�޶�ʱ���ػ�" + System.Environment.NewLine;
                }
                else
                {
                    str += "TimingOnOff:�ж�ʱ���ػ�" + System.Environment.NewLine;
                }
                //���ػ�״̬
                if (CmdRet.CurrentOnOffStatus == 0)
                {
                    str += "CurrentOnOffStatus:����" + System.Environment.NewLine;
                }
                else
                {
                    str += "CurrentOnOffStatus:�ػ�" + System.Environment.NewLine;
                }
                //ɨ�����ñ��
                str += "ScanConfNumber:ɨ�����ñ�� " + CmdRet.ScanConfNumber + System.Environment.NewLine;
                //һ·���ݴ�����
                str += "RowsPerChanel:" + CmdRet.RowsPerChanel + System.Environment.NewLine;
                //�����޻Ҷ�ϵͳ������ 0�������лҶ�ϵ 1
                if (CmdRet.GrayFlag == 0)
                {
                    str += "GrayFlag:�޻Ҷ�ϵͳ" + System.Environment.NewLine;
                }
                else
                {
                    str += "GrayFlag:�лҶ�ϵͳ" + System.Environment.NewLine;
                }
                //��С��Ԫ���
                str += "UnitWidth:��С��Ԫ��� " + CmdRet.UnitWidth + System.Environment.NewLine;
                //6Q ��ʾģʽ : 0 Ϊ 888, 1 Ϊ 565�����࿨Ϊ 0
                if (CmdRet.modeofdisp == 0)
                {
                    str += "modeofdisp:6Q ��ʾģʽ 888 " + System.Environment.NewLine;
                }
                else
                {
                    str += "modeofdisp:6Q ��ʾģʽ 565 " + System.Environment.NewLine;
                }
                //�����ֽ�Ϊ 0 ʱ������ͨѶʹ���ϵ�ģʽ���� UDP �� TCP �����������PackageMode �ֽ�ȷ������������ UDPͨѶʱ���������ΪС����ÿ����һС����һ����ʱ�����ֽڲ�Ϊ 0 ʱ������ͨѶʹ���µ�ģʽ���� UDP �İ�������UDPPackageMode * 8KBYTE���Ҳ��ٷ�ΪС�������������ݶ���Э��ջTCP �İ������� PackageMode * 16KBYTE
                str += "NetTranMode:" + CmdRet.NetTranMode + System.Environment.NewLine;
                //��ģʽ��0 С��ģʽ���ְ� 600 byte��1 ���ģʽ���ְ� 16K byte��
                if (CmdRet.PackageMode == 0)
                {
                    str += "PackageMode:С��ģʽ���ְ� 600 byte" + System.Environment.NewLine;
                }
                else
                {
                    str += "PackageMode:���ģʽ���ְ� 16K byte" + System.Environment.NewLine;
                }
                //�Ƿ����������� ID��������ˣ����ֽڵ� 0 λΪ 1������Ϊ0
                if (CmdRet.BarcodeFlag == 0)
                {
                    str += "BarcodeFlag:������" + System.Environment.NewLine;
                }
                else
                {
                    str += "BarcodeFlag:������" + System.Environment.NewLine;
                }
                //�����������н�Ŀ����
                str += "ProgramNumber:�����������н�Ŀ���� " + CmdRet.ProgramNumber + System.Environment.NewLine;
                //��ǰ��Ŀ��
                str += "CurrentProgram:��ǰ��Ŀ�� " + System.Text.Encoding.Default.GetString(CmdRet.CurrentProgram) + System.Environment.NewLine;
                //Bit0 �C�Ƿ���Ļ������1b��0 �C����Ļ������1b��1 �C��Ļ����
                if (CmdRet.ScreenLockStatus == 0)
                {
                    str += "ScreenLockStatus:����Ļ����" + System.Environment.NewLine;
                }
                else
                {
                    str += "ScreenLockStatus:��Ļ����" + System.Environment.NewLine;
                }
                //Bit0 �C�Ƿ��Ŀ������1b��0 �C�޽�Ŀ������1��b1 �C��Ŀ����
                if (CmdRet.ProgramLockStatus == 0)
                {
                    str += "ProgramLockStatus:�޽�Ŀ����" + System.Environment.NewLine;
                }
                else
                {
                    str += "ProgramLockStatus:��Ŀ����" + System.Environment.NewLine;
                }
                //����������ģʽ
                str += "RunningMode:" + CmdRet.RunningMode + System.Environment.NewLine;
                //RTC ״̬ 0x00 �C RTC �쳣 0x01 �C RTC ����
                if (CmdRet.RTCStatus == 0)
                {
                    str += "RTCStatus:RTC �쳣" + System.Environment.NewLine;
                }
                else
                {
                    str += "RTCStatus:RTC ����" + System.Environment.NewLine;
                }
                //��
                str += "RTCYear:" + (LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCYear[1]) * 100 + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCYear[0])) + System.Environment.NewLine;
                //��
                str += "RTCMonth:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCMonth) + System.Environment.NewLine;
                //��
                str += "RTCDate:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCDate) + System.Environment.NewLine;
                //ʱ
                str += "RTCHour:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCHour) + System.Environment.NewLine;
                //��
                str += "RTCMinute:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCMinute) + System.Environment.NewLine;
                //��
                str += "RTCSecond:" + LedBxDualSdk.ConvertBCDToInt(CmdRet.RTCSecond) + System.Environment.NewLine;
                //���ڣ���ΧΪ 1~7��7 ��ʾ����
                str += "RTCWeek:����" + CmdRet.RTCWeek + System.Environment.NewLine;
                //�¶ȴ�������ǰֵ ��һ���ֽ�0Ϊ��1Ϊ�� ��ֵ/10
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
                    str += "Temperature1:���¶ȴ�����" + System.Environment.NewLine;
                }
                //��ʪ�ȴ������¶ȵ�ǰֵ ��һ���ֽ�0Ϊ��1Ϊ�� ��ֵ/10
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
                    str += "Temperature2:���¶ȴ�����" + System.Environment.NewLine;
                }
                //ʪ�ȴ�������ǰֵ  ��ֵ/10
                if ((CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) != 0xffff)
                {
                    str += "Humidity:" + (CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "Humidity:��ʪ�ȴ�����" + System.Environment.NewLine;
                }
                //������������ǰֵ(���� 10 Ϊ��ǰֵ)��� BX - ZS(485) 0xffff ʱ��Ч
                if ((CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) != 0xffff)
                {
                    str += "Noise:" + (CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "Noise:������������+" + System.Environment.NewLine;
                }
                //0����ʾδ���� Logo ��Ŀ 1����ʾ������ Logo ��Ŀ
                if (CmdRet.LogoFlag == 0)
                {
                    str += "LogoFlag:δ���� Logo ��Ŀ" + System.Environment.NewLine;
                }
                else
                {
                    str += "LogoFlag:������ Logo ��Ŀ" + System.Environment.NewLine;
                }
                //0��δ���ÿ�����ʱ 1��������ʱʱ��
                if (CmdRet.PowerOnDelay == 0)
                {
                    str += "PowerOnDelay:δ���ÿ�����ʱ" + System.Environment.NewLine;
                }
                else
                {
                    str += "PowerOnDelay:������ʱʱ�� " + CmdRet.PowerOnDelay + System.Environment.NewLine;
                }
                //����(���� 10 Ϊ��ǰֵ) 0xfffff ʱ��Ч
                if ((CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) != 0xffff)
                {
                    str += "WindSpeed:" + (CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "WindSpeed:�޷��ٴ�����" + System.Environment.NewLine;
                }
                //����(��ǰֵ) 0xfffff ʱ��Ч
                if ((CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) != 0xffff)
                {
                    str += "WindDirction:(0:0�㱱�� 1:45�㶫���� 2:90�㶫�� 3:135�㶫�Ϸ� 4:180���Ϸ� 5:225�����Ϸ� 6:270������ 7:315��������)" + (CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "WindDirction:�޷��򴫸���" + System.Environment.NewLine;
                }
                //PM2.5 ֵ(��ǰֵ)0xfffff ʱ��Ч
                if ((CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) != 0xffff)
                {
                    str += "PM2_5:" + (CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "PM2_5:��PM2_5������" + System.Environment.NewLine;
                }
                //PM10 ֵ(��ǰֵ)0xfffff ʱ��Ч
                if ((CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) != 0xffff)
                {
                    str += "PM10:" + (CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "PM10:��PM10������" + System.Environment.NewLine;
                }
                //LEDCON01 ��������������Ϊ 16 ���ֽڳ���(ȫ�� 0x00 ��ʾ���ζ�ʧ��������Ч����λ���հ���ʾ)
                string ControllerName = "";
                for (int i = 0; i < CmdRet.ControllerName.Length; i++) { ControllerName += CmdRet.ControllerName[i].ToString("X2").ToUpper(); }
                str += "ControllerName:" + ControllerName + System.Environment.NewLine;
                //��Ļ��װ��ַ����Ϊ 44 ���ֽڳ���(ȫ�� 0x00 ��ʾ���ζ�ʧ��������Ч����λ���հ���ʾ)
                string ScreenLocation = "";
                for (int i = 0; i < CmdRet.ScreenLocation.Length; i++) { ScreenLocation += CmdRet.ScreenLocation[i].ToString("X2").ToUpper(); }
                str += "ScreenLocation:" + ScreenLocation + System.Environment.NewLine;
                //����������Ļ��װ��ַ�� 60 ���ֽڵ�CRC32 У��ֵ����ֵ��Ϊ�˱�����λ�����ִ˴� 64 ���ֽ��Ǳ�ʾ���������ƻ���������ʾ���������ƺ���Ļ��װ��ַ��������ȡ��ͬ�Ĵ������Ϊ�˱��ּ��ݣ���λ�����Ը�ֵ������֤
                string NameLocalationCRC32 = "";
                for (int i = 0; i < CmdRet.NameLocalationCRC32.Length; i++) { NameLocalationCRC32 += CmdRet.NameLocalationCRC32[i].ToString("X2").ToUpper(); }
                str += "NameLocalationCRC32:" + NameLocalationCRC32 + System.Environment.NewLine;
            }
        }
        //IP����
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
        string strdual = "���ò��� bxDual_cmd_uart_confDeleteFormatFile";
        /// <summary>
        /// ����WIFI����
        /// </summary>
        public static void SetWifi_pwd()
        {
            byte[] ssid = Encoding.GetEncoding("GBK").GetBytes("bx-wifi_fantx");
            byte[] pwd = Encoding.GetEncoding("GBK").GetBytes("12345678");
            err = bxdualsdk.BxDual_cmd_AT_setWifiSsidPwd(ssid, pwd);
        }
        /// <summary>
        /// ȡ��WIFI����
        /// </summary>
        public static void GetWifi_pwd()
        {
            byte[] ssid = new byte[16];
            byte[] pwd = new byte[16];
            for (int i = 0; i < 16; i++) { ssid[i] = 0; pwd[i] = 0; }
            err = bxdualsdk.BxDual_cmd_AT_getWifiSsidPwd(ssid, pwd);
        }
        /// <summary>
        /// ��������-���������5����ʹ��
        /// </summary>
        public static void Btn_NetworkSearch_5_Click()
        {
            var CmdRet = new HeartbeatData();
            err = bxdualsdk.BxDual_cmd_udpNetworkSearch(ref CmdRet);
        }
        /// <summary>
        /// �㲥����MAC��ַ
        /// </summary>
        public static void Udp_setMAC()
        {
            byte[] mac = Encoding.GetEncoding("GBK").GetBytes("aa-bb-cc-12-a8-8a");
            err = bxdualsdk.BxDual_cmd_udpSetMac(mac);
        }
        /// <summary>
        /// Уʱ��ͬ�����ƿ�ʱ��
        /// </summary>
        public static void Checktime()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_check_time(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_cmd_check_time_uart(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate);
            }
        }
        /// <summary>
        /// ��������ID
        /// </summary>
        public static void ReadControllerID()
        {
            byte[] ControllerID = new byte[8];
            for (int i = 0; i < 8; i++) { ControllerID[i] = 0; }
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_readControllerID(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ControllerID);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// ��������״̬
        /// </summary>
        public static void ControllerStatus()
        {
            ControllerStatus_G56 Status = new ControllerStatus_G56();
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_check_controllerStatus(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref Status);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// ���ÿ���������
        /// </summary>
        public static void SetPassword()
        {
            byte[] oldpassword = Encoding.GetEncoding("GBK").GetBytes("123456");
            byte[] newpassword = Encoding.GetEncoding("GBK").GetBytes("456789");
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setPassword(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, oldpassword, newpassword);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// ɾ����ǰ����������
        /// </summary>
        public static void DeletePassword()
        {
            byte[] password = Encoding.GetEncoding("GBK").GetBytes("123456");
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_deletePassword(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, password);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// ���ÿ��ƿ�����ʱʱ�䣬��λ��
        /// </summary>
        public static void SetDelayTime()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setDelayTime(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 5);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// ���ÿ��Ʋ��԰�ť���� ��ťģʽ 0x00�C���԰�ť 0x01�C�ش����л���Ŀ 0x02�C��ƽ�����л���Ŀ
        /// </summary>
        private static void setBtnFunc()
        {
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setBtnFunc(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// ���ÿ�����������ʱ��
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
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_cmd_setTimingReset(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref time);
            }
            //����
            else
            {//Program.com, Program.baudRate
            }
        }
        /// <summary>
        /// ���ÿ���������ʾģʽ
        /// </summary>
        private static void setDispMode()
        {
            err = bxdualsdk.BxDual_cmd_setDispMode(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0);
        }
        /// <summary>
        /// �����Ʋ���ȡ���ʱ��
        /// </summary>
        private static void getStopwatch()
        {
            byte mode = 0; int timeValue = 0;
            err = bxdualsdk.BxDual_cmd_getStopwatch(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, mode, ref timeValue);
        }
        /// <summary>
        /// ��ȡ���ȶ�������ֵ
        /// </summary>
        private static void getSensorBrightnessValue()
        {
            int brightnessValue = 0;
            err = bxdualsdk.BxDual_cmd_getSensorBrightnessValue(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref brightnessValue);
        }
        /// <summary>
        /// �ٶ�΢������
        /// </summary>
        private static void setSpeedAdjust()
        {
            short speed = 0;
            err = bxdualsdk.BxDual_cmd_setSpeedAdjust(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, speed);
        }
        /// <summary>
        /// ������Ļ��
        /// </summary>
        private static void setScreenAddress()
        {
            short address = 1;
            err = bxdualsdk.BxDual_cmd_setScreenAddress(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, address);
        }
        /// <summary>
        /// ��ʼ���ļ�
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
        /// ��ʼ���ļ�
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
            //5��
            if (false)
            {
                IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ConfigFile)));
                Marshal.Copy(data, Marshal.SizeOf(typeof(ConfigFile)), dec, Marshal.SizeOf(typeof(ConfigFile)));
                ConfigFile configData = (ConfigFile)Marshal.PtrToStructure(dec, typeof(ConfigFile));
                Marshal.FreeHGlobal(dec);
                err = bxdualsdk.BxDual_cmd_sendConfigFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref configData);
            }
            //6��
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
        /// ���ļ��ӿڲ���
        /// </summary>
        private static void cmd_ofsReedDirBlock()
        {
            byte[] fileName = Encoding.GetEncoding("GBK").GetBytes("F001");
            err = bxdualsdk.BxDual_cmd_firmwareActivate(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, fileName);
        }


        /// <summary>
        /// ��������
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
    /// ��̬����������֧��BX-5Eϵ��
    /// </summary>
    class Dynamic_5
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// ɾ����̬������������
        /// </summary>
        public static void delete_dynamic()
        {
            //��������������̬��IDָ��ɾ������0xffɾ�����ж�̬��
            int err = 0;
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0xff);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_G5_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 0xff);
            }
            Console.WriteLine("dynamicArea_DelArea_5G = " + err);
        }

        /// <summary>
        /// ɾ����̬�������������
        /// </summary>
        public static void delete_dynamic_s()
        {
            byte[] id = new byte[] { 0, 1 };
            int err = 0;
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelAreaS_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            //����
            else
            {
                id = new byte[] { 0 };
                err = bxdualsdk.BxDual_dynamicArea_DelAreaS_G5_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            Console.WriteLine("dynamicArea_DelArea_5G = " + err);
        }

        /// <summary>
        /// ��̬�������ı��������ı�
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
            //��ʾ���ݺ������ʽ begin---------
            EQfontData oFont;
            oFont.arrMode = E_arrMode.eMULTILINE;
            oFont.fontSize = 12;
            oFont.color = 1;
            oFont.fontBold = 0;
            oFont.fontItalic = 0; oFont.tdirection = E_txtDirection.pNORMAL; oFont.txtSpace = 0; oFont.Halign = 1; oFont.Valign = 1;
            byte[] fontName = Encoding.Default.GetBytes("����\0");
            byte[] strAreaTxtContent = Encoding.Default.GetBytes("����\n�ı�\0");
            int err = 0;
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
                //����һ����ֻ�ǽṹ��Ϊָ�����
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_Point_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //ImmePlay, uAreaX, uAreaY, uWidth, uHeight,ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime,ref oFont, fontName, strAreaTxtContent);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_5G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
                //����һ����ֻ�ǽṹ��Ϊָ�����
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //ImmePlay, uAreaX, uAreaY, uWidth, uHeight,ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime,ref oFont, fontName, strAreaTxtContent);
            }
            Console.WriteLine("dynamicArea_AddAreaWithTxt_5G = " + err);
        }

        /// <summary>
        /// ��̬������ͼƬ������ͼƬ
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
            //��ʾ���ݺ������ʽ begin---------
            EQfontData oFont;
            oFont.arrMode = E_arrMode.eMULTILINE;
            oFont.fontSize = 10;
            oFont.color = 1;
            oFont.fontBold = 0;
            oFont.fontItalic = 0; oFont.tdirection = E_txtDirection.pNORMAL; oFont.txtSpace = 0; oFont.Halign = 1; oFont.Valign = 2;
            byte[] filePath = Encoding.Default.GetBytes("456.png");
            int err = 0;
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithPic_5G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaWithPic_5G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
            }
            Console.WriteLine("dynamicArea_AddAreaWithPic_5G = " + err);
        }

        /// <summary>
        /// ��̬�����¶�ҳ����
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
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
            pheader1.fontName = LedBxDualSdk.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("����"));
            pheader1.strAreaTxtContent = LedBxDualSdk.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes(nnn + "\0"));
            pheader1.filePath = LedBxDualSdk.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("123.png\0"));
            DynamicAreaBaseInfo_5G[] Params = new DynamicAreaBaseInfo_5G[2];
            Params[0] = pheader;
            Params[1] = pheader1;

            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //�ýӿڵ��ñ���
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //                    ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);

                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_5G_Point(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);
            }
            //����
            else
            {
                //�ýӿڵ��ñ���
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
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
    /// ��̬��������6Eϵ�У�6E1X��6E2X��6Q1��6Q2��6Q3��6QX-YD��6Q2L��6Q3Lϵ��֧��
    /// </summary>
    class Dynamic_6
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        public static int err = 0;
        public static Random ran = new Random();
        //5Eϵ��֧�� 0-3��6E��6Qϵ��֧�� 0-31
        public static byte AreaId = 0;
        public static byte RunMode = 0;
        public static ushort Timeout = 10;
        public static byte RelateAllPro = 0;
        public static ushort RelateProNum = 0;
        public static ushort[] RelateProSerial = new ushort[] { 0 };
        public static byte ImmePlay = 1;
        //��̬�������Ͻ���LED��ʾ����λ��/���ꣻ
        public static ushort AreaX = 0;
        public static ushort AreaY = 0;
        //��̬����Ŀ�ȣ��߶�
        public static ushort Width = 64;
        public static ushort Height = 32;
        //�������ƣ���"����";
        public static IntPtr fontName;
        //public static byte[] fontName = Encoding.GetEncoding("GBK").GetBytes("����");
        //�����С
        public static byte FontSize = 12;
        //Ҫ��ʾ���ı�����
        public static IntPtr strAreaTxtContent;
        //public static byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("12345565648");
        //Ҫ��ʾ��ͼƬ ֻ֧��png���ͣ�ͼƬ���ش�С����������1��1��һ��ڵ׺���
        public static IntPtr img;
        //public static byte[] img = Encoding.GetEncoding("GBK").GetBytes("0.png");

        /// <summary>
        /// ɾ����̬������������
        /// </summary>
        public static void delete_dynamic()
        {
            //��������������̬��IDָ��ɾ������0xffɾ�����ж�̬��
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, 0xff);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_DelArea_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, 0xff);
            }
            Console.WriteLine("dynamicArea_DelArea = " + err);
        }

        /// <summary>
        /// ɾ����̬�������������
        /// </summary>
        public static void delete_dynamic_s()
        {
            byte[] id = new byte[] { 0, 1 };
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_DelAreas_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            //����
            else
            {
                id = new byte[] { 0 };
                err = bxdualsdk.BxDual_dynamicArea_DelAreas_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, (byte)id.Length, id);
            }
            Console.WriteLine("dynamicArea_DelArea = " + err);
        }

        /// <summary>
        /// ����˫ɫ����������,˫ɫ��ʱ��������ͺ�ɫ��ʾ��ɫ�����ǵ������Ͳ������ԣ��ýӿ�5����6��ͨ��
        /// </summary>
        public static void dynamic_pixel()
        {
            bxdualsdk.BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
        }

        /// <summary>
        /// �������ı�������������Ч
        /// </summary>
        public static void dynamicArea_str_1()
        {
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
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
        /// �������ı�����������Ч
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
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("����ab34��������");
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
            IntPtr fontName1 = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName1, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            IntPtr strAreaTxtContent1 = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent1, str.Length);
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId,
                    ref aheader, ref pheader, fontName1, strAreaTxtContent1);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                    AreaId, ref aheader, ref pheader, fontName, strAreaTxtContent);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }

        /// <summary>
        /// �������ı�����������Ч,��ѡ���Ƿ�ͽ�Ŀ����һ�𲥷š�һ�𲥷�ʱ��̬���ͽ�Ŀ���������ص���
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
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("����ab34��������");
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����\0");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("�ֳ�:25��\nԤԼ:68��\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            Console.WriteLine("���ͽ�Ŀ���" + DateTime.Now.ToString());
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, 
                // ref aheader, ref pheader, fontName, strAreaTxtContent);
                //�Ƿ������Ŀ
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //����
            else
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
            Console.WriteLine("���ͽ�Ŀ���" + DateTime.Now.ToString());
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
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("����ab34��������");
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����\0");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("WJ045�ȴ����ﲨ��װж�ϣ�WJ047�ȴ���������װж�ϣ�WJ077�ȴ�����ѧ����װж�ϣ�WJ044�ȴ����ﲨ��װж�ϣ�WJ041�ȴ��������١�װж�ϣ�WJ042�ȴ��������١�װж�ϣ�WJ036�ȴ��������١�װж�ϣ�WJ037�ȴ��������١�װж�ϣ�WJ034�ȴ��������١�װж�ϣ�WJ035�ȴ��������١�װж�ϣ�\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 1,
                   ref aheader, ref pheader, fontName, strAreaTxtContent);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 22,
                // ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //����
            else
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// ��������ı�����������Ч,��ѡ���Ƿ�ͽ�Ŀ����һ�𲥷š�һ�𲥷�ʱ��̬���ͽ�Ŀ���������ص���
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
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("����ab34��������");
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("����\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_THREE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //����
            else
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// ������ͼƬ����������Ч
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
            Console.WriteLine("���ͽ�Ŀ���" + DateTime.Now.ToString());
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                          64, 64, ref pheader, img);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                //                                          Width, Height, ref pheader, img, RelateProNum, RelateProSerial);

            }
            //����
            else
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_6G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                          Width, Height, ref pheader, strAreaTxtContent);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, 
                //    AreaX, AreaY,Width, Height, ref pheader, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
            Console.WriteLine("���ͽ�Ŀ���" + DateTime.Now.ToString());
        }
        /// <summary>
        /// ͬʱ���¶����̬���ı�
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
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("����ab34��������");
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����\0");
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
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //�Ƿ������Ŀ
                //Console.WriteLine(DateTime.Now.ToString());
                //err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
                //Console.WriteLine(DateTime.Now.ToString());

            }
            //����
            else
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_6G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// ͬʱ���¶����̬��ͼƬ
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
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("����ab34��������");
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
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
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);

            }
            //����
            else
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_6G_Serial(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //�Ƿ������Ŀ
                //err = bxdualsdk.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// һ����һ����̬������/���¶�����Ϣ�����ֻ�ͼƬ��������
        /// �ýӿ������⣬������ʹ��
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
            //Frame.pStrFramePathFile = Encoding.Default.GetBytes("F:\\��10.png");// Class1.BytesToIntptr(Encoding.Default.GetBytes("F:\\��10.png"));

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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
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
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, ref Params);
            }
            //����
            else
            {
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_G6_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, ref Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
        }
        /// <summary>
        /// һ����һ����̬������/���¶�����Ϣ�����ֻ�ͼƬ��������
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
                FrameDispStype = 0x03,    //�߿���ʾ��ʽ0x00 �C��˸ 0x01 �C˳ʱ��ת�� 0x02 �C��ʱ��ת�� 0x03 �C��˸��˳ʱ��ת�� 0x04 �C��˸����ʱ��ת�� 0x05 �C���̽�����˸ 0x06 �C���̽���ת�� 0x07 �C��ֹ���
                FrameDispSpeed = 0x10,    //�߿���ʾ�ٶ�
                FrameMoveStep = 0x01,     //�߿��ƶ���������λΪ�㣬�˲� ����ΧΪ 1~16 
                FrameUnitLength = 2,   //�߿���Ԫ����
                FrameUnitWidth = 2,    //�߿���Ԫ���
                FrameDirectDispBit = 0//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
            };//��ʱ��֧��
            BxAreaFrmae_Dynamic_G6 Frame = new BxAreaFrmae_Dynamic_G6
            {
                AreaFFlag = 0,
                oAreaFrame = oFrame,
                pStrFramePathFile = Encoding.Default.GetBytes("F:\\��10.png")//Class1.BytesToIntptr(Encoding.Default.GetBytes("F:\\��10.png"));
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
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
            //����
            if (OnbonLedBxSdkUT.isNetwork)
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_6G_V2(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_THREE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, Params, ref stSoundData);
            }
            //����
            else
            {
                err = bxdualsdk.BxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(OnbonLedBxSdkUT.address, (byte)OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
        }
    }
    /// <summary>
    /// ����ƿ����ͽ�Ŀ��������
    /// </summary>
    class Program_Send_Areas
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5�����ƿ����ͽ�Ŀ������
        /// </summary>
        public static void Send_program_areas_5()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //������Ŀ�����ý�Ŀ����
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

            //������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ͼ�ķ���
            EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 16;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //�����ʾ���ݣ��˴�Ϊͼ�ķ���0����ַ���
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("��ʾ����");
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("����");
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

            //������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ1�������С64 * 32��ʱ�������Y��64������֮�䲻���ص�
            EQareaHeader aheader1;
            aheader1.AreaType = 2;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            err = bxdualsdk.BxDual_program_AddArea(1, ref aheader1);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //���ʱ��������ʾ����
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eMULTILINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "����";
            timeData2.fontSize = 12;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--����룬1-���У�2-�Ҷ���
            timeData2.date_enable = 0;
            timeData2.datestyle = E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 1;
            timeData2.timestyle = E_TimeStyle.eHH_MM_AM;
            timeData2.week_enable = 0;
            timeData2.weekstyle = E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.BxDual_program_timeAreaAddContent(1, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent:" + err);

            //���ͽ�Ŀ����ʾ��
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//����
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
    /// ����ƿ����ͽ�Ŀ���̵���ʾ��
    /// </summary>
    class Program_Send_clock
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5�����ƿ����ͽ�Ŀ����
        /// </summary>
        public static void Send_program_clock_5()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ʱ�����
            EQareaHeader aheader;
            aheader.AreaType = 2;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //���Ĳ�����ӱ���������ʾ����
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

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//����
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
        /// BX-6�����ƿ����ͽ�Ŀ����
        /// </summary>
        public static void Send_program_clock_6()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ʱ�����
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

            //���Ĳ�����ӱ�����ʾ����
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
            //��ӱ���ͼƬ
            //err = bxdualsdk.BxDual_program_timeAreaChangeDialPic_G6(areaID, img);
            //ɾ������ͼƬ
            //err = bxdualsdk.BxDual_program_timeAreaRemoveDialPic_G6(areaID);
            //�޸ı�����ʽ
            //err = bxdualsdk.BxDual_program_timeAreaChangeAnalogClock_G6(areaID, ref acheader, bxdualsdk.E_ClockStyle.eCIRCLE, ref ClockColor);

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
    /// ����ƿ����ͽ�ĿͼƬ����ʾ������֧��png��ʽ
    /// </summary>
    class Program_Send_png
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5�����ƿ����ͽ�ĿͼƬ
        /// </summary>
        public static void Send_program_png_5()
        {
            Console.WriteLine(DateTime.Now.ToString());
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ͼ�ķ���
            EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //���Ĳ��������ʾ���ݣ��˴�Ϊͼ�ķ���0���ͼƬ���ò���ɶ�ε��ã���Ӷ���ͼƬ��ÿ��ͼƬ�ò�ͬ�ı��
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

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//����
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
        /// BX-6�����ƿ����ͽ�ĿͼƬ
        /// </summary>
        public static void Send_program_png_6()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ͼ�ķ���
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

            //���Ĳ��������ʾ���ݣ��˴�Ϊͼ�ķ���0���ͼƬ���ò���ɶ�ε��ã���Ӷ���ͼƬ��ÿ��ͼƬ�ò�ͬ�ı��
            //byte[] img = Encoding.GetEncoding("GBK").GetBytes("1230.png");
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("326.png");
            EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;//�ƶ�ģʽ
            pheader.ClearMode = 0x01;
            pheader.Speed = 15;//�ٶ�
            pheader.StayTime = 0;//ͣ��ʱ��
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

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
        /// BX-5�����ƿ����ͽ�Ŀ�ı�
        /// </summary>
        public static void Send_program_sensor_5()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
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

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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
            //��Ŀ��ӱ߿�����
            if (false)
            {
                EQscreenframeHeader sfheader;
                sfheader.FrameDispFlag = 0x01;
                sfheader.FrameDispStyle = 0x01;
                sfheader.FrameDispSpeed = 0x10;
                sfheader.FrameMoveStep = 0x01;
                sfheader.FrameWidth = 2;
                sfheader.FrameBackup = 0;
                byte[] img = Encoding.Default.GetBytes("F:\\��10.png");
                bxdualsdk.BxDual_program_addFrame(ref sfheader, img);
            }
            //��Ŀ��Ӳ���ʱ��,Ŀǰ��֧��һ��ʱ�䣬���鲻֧�֣�Time��Ч��Time1��Ч
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32���¶ȷ���
            /*�¶�����0x03
             ʪ������0x04
            ��������0x05*/
            EQareaHeader aheader;
            aheader.AreaType = 0x03;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);
            //������ӱ߿�
            if (false)
            {
                EQareaframeHeader afheader;
                afheader.AreaFFlag = 0x01;
                afheader.AreaFDispStyle = 0x01;
                afheader.AreaFDispSpeed = 0x08;
                afheader.AreaFMoveStep = 0x01;
                afheader.AreaFWidth = 3;
                afheader.AreaFBackup = 0;
                byte[] img = Encoding.Default.GetBytes("��10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame(0, ref afheader, img);
            }

            //���Ĳ��������ʾ���ݣ��˴�Ϊ�¶ȷ��������������
            byte nSensorType = 0x02;         //	1		0x00	���������ͣ�//0x00 �C DS18B20 //0x01 �C SHT1XXX //0x02:S-RHT2
            byte nTemperatureUnit = 0;    //	1		0x00	�¶ȵ�λ��0x00�C���϶�; 0x01�C���϶�
            byte nTermperatureMode = 0;   //	1		0x00	�¶���ʾģʽ��0x00 �C����ģʽ(25C); 0x01 �CС��ģʽ(25.5C);
            byte nTemperatureCorrectionPol = 0;// 1 	0x00	����������ֵ���� ע��0 �C���� 1 �C��
            byte nTemperatureCorrection = 0;  // 1 	0x00	����������ֵ����λ�����϶ȣ�ע���˲���Ϊ�������ͣ���λΪ0.1
            byte nTemperatureThreshPol = 2;   // 1 	0x00	�¶���ֵ���� ע��Bit0 �C���ԣ�0 ���� 1 ��; Bit1 - 0��ʾС�ڴ�ֵ�������飬1��ʾ���ڴ�ֵ��������
            byte nTemperatureThresh = 30;     // 1	0x00	�¶���ֵ
            byte nTemperatureColor = 2;      // 1			�����¶���ɫ
            byte nTemperatureErrColor = 1;    // 1			�¶ȳ�����ֵʱ��ʾ����ɫ
            byte[] pstrFixTxt = Encoding.GetEncoding("GBK").GetBytes("1hello\0");//Ouint8 StaticTextOption;//1	�̶��ı�ѡ�� 0x00�C�޹̶��ı�; 0x01�C��	
            byte nFontSize = 12;
            byte[] pstrFontNameFile = Encoding.GetEncoding("GBK").GetBytes("E:/WorkGit/bx.dual.demo.cplus/allfonts/1.ttf\0");
            byte nUnitShowRation = 80;         // ��ʾ�ĵ�λ�����С��������ʾ�ı��Ĵ�С�ı�����
            err = bxdualsdk.BxDual_program_SetSensorAreaTemperature_G5(0, nSensorType, nTemperatureUnit, nTermperatureMode,
                                    nTemperatureCorrectionPol, nTemperatureCorrection, nTemperatureThreshPol, nTemperatureThresh, nTemperatureColor,
                                    nTemperatureErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt:" + err);

            //ʪ����������
            if (false) { }
            //������������
            if (false) { }

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//����
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
        /// BX-6�����ƿ����ͽ�Ŀ�ı�
        /// </summary>
        public static void Send_program_sensor_6()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
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

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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
            //��Ŀ��Ӳ���ʱ��,Ŀǰ��֧��һ��ʱ�䣬���鲻֧��
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
            //��Ŀ��ӱ߿�
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //�߿���ʾ��ʽ
                sfheader.FrameDispSpeed = 0x10;    //�߿���ʾ�ٶ�
                sfheader.FrameMoveStep = 0x01;     //�߿��ƶ�����
                sfheader.FrameUnitLength = 2;   //�߿���Ԫ����
                sfheader.FrameUnitWidth = 2;    //�߿���Ԫ���
                sfheader.FrameDirectDispBit = 0;//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                byte[] img = Encoding.Default.GetBytes("F:\\��10.png");
                bxdualsdk.BxDual_program_addFrame_G6(ref sfheader, img);
            }

            //��������������ʾ����������������ʾλ�ã�ʾ������һ������������
            EQareaHeader_G6 aheader;
            aheader.AreaType = 3;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            EQSound_6G stSoundData = new EQSound_6G();//�����������ڽ�Ŀ��Ч
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
            err = bxdualsdk.BxDual_program_addArea_G6(0, ref aheader);  //���ͼ������
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //������ӱ߿�
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //�߿���ʾ��ʽ0x00 �C��˸ 0x01 �C˳ʱ��ת�� 0x02 �C��ʱ��ת�� 0x03 �C��˸��˳ʱ��ת�� 0x04 �C��˸����ʱ��ת�� 0x05 �C���̽�����˸ 0x06 �C���̽���ת�� 0x07 �C��ֹ���
                sfheader.FrameDispSpeed = 0x10;    //�߿���ʾ�ٶ�
                sfheader.FrameMoveStep = 0x01;     //�߿��ƶ���������λΪ�㣬�˲� ����ΧΪ 1~16 
                sfheader.FrameUnitLength = 2;   //�߿���Ԫ����
                sfheader.FrameUnitWidth = 2;    //�߿���Ԫ���
                sfheader.FrameDirectDispBit = 0;//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                byte[] img = Encoding.Default.GetBytes("E:\\��10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }

            //���Ĳ�����Ӵ�������������
            byte SensorModeDispType = 1;  // 1 0x00 ��ʾģʽ;	0x00�C����ģʽ
            byte SensorCorrectionPol = 1; // 1 0x00 ����������ֵ���� ע�� 0�C���� 1�C��
            ushort SensorCorrection = 1;   // 4 0x00 ����������ֵ; ��С��ģʽ��Ч��С������λ������0��255ʱ����0.1Ϊ��λ��
            byte nRatioValue = 90;      //��λ��ʾ������Ĭ��100
                                        //0�������¶�//1������ʪ��//2����������//3������ PM2.5������������������
                                        //4������ PM10������������������	//5�� RS485 �ͷ��������	//6�� RS485 �ͷ��ٱ任��	//7������ѹ��	//8������
                                        //9������	//10�� 0x0A�� ˮλ��	//11�� 0x0B: ���� TSP	//12�� 0x0C : �������Ӽ����
                                        //0xff�����ܴ��������������� BX - 6XX - MODBUSϵ��ר�����ͣ�������������Ϊ��ֵʱ������� SensorType�� SensorUnit�� DisplayUnitFlag������Ϊ 0������ͨ��ϵ�п��ƿ�����ֵΪ��0xff ��ֵ
            byte nSensorMode = 1;
            byte nSensorType = 1;  //1:S-RHT2(3�ߣ�
            byte nSensorUnit = 0;    // 1 0x00 ��λ�¶ȣ�0x00 �C���϶� 0x01 �C���϶�;  ˮλ�� 0x00 �Cm, 0x01 �Ccm
            byte nDisplayUnitFlag = 1;//	�Ƿ���ʾ��λ 0������ʾ; 1����ʾ; Ĭ�� = 1;
            byte[] pFixedTxt = Encoding.GetEncoding("GBK").GetBytes("1\0");
            byte[] pFontName = Encoding.GetEncoding("GBK").GetBytes("E:/WorkGit/bx.dual.demo.cplus/allfonts/1.ttf\0");
            err = bxdualsdk.BxDual_program_SetSensorArea_G6(0,
                nSensorMode, nSensorType, nSensorUnit, pFixedTxt, pFontName, 16,
                0x02, 0x01, 60, 0x02,
                nDisplayUnitFlag, SensorModeDispType, SensorCorrectionPol, SensorCorrection, nRatioValue);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);

            //�������,�ù��ܽ����ֿ��ƿ�֧�֣�һ����Ŀֻ����һ��ͼ���������������
            if (false)
            {
                byte[] soundstr = Encoding.GetEncoding("gb2312").GetBytes("��������1�Ŵ���ȡҩ");
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

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
    /// ����ƿ����ͽ�Ŀʱ�����ʾ��
    /// </summary>
    class Program_Send_time
    {
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// BX-5�����ƿ����ͽ�Ŀʱ��
        /// </summary>
        public static void Send_program_time_5()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_2);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ʱ�����
            EQareaHeader aheader;
            aheader.AreaType = 2;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            err = bxdualsdk.BxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //���Ĳ������ʱ��������ʾ����
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eMULTILINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "����";
            timeData2.fontSize = 11;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--����룬1-���У�2-�Ҷ���
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
            timeData1.fontAlign = 0;  //0--����룬1-���У�2-�Ҷ���
            timeData1.date_enable = 1;
            timeData1.datestyle = E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData1.time_enable = 0;
            timeData1.timestyle = E_TimeStyle.eHH_MM_AM;
            timeData1.week_enable = 0;
            timeData1.weekstyle = E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.BxDual_program_fontPath_timeAreaAddContent(0, ref timeData1);
            Console.WriteLine("bxDual_program_timeAreaAddContent:" + err);

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram program = new EQprogram();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
            {
                err = bxdualsdk.BxDual_cmd_ofsStartFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.BxDual_cmd_ofsWriteFile(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.BxDual_cmd_ofsEndFileTransf(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//����
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
        /// BX-6�����ƿ����ͽ�Ŀʱ��
        /// </summary>
        public static void Send_program_time_6()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ʱ�����
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
            //������ӱ߿�
            if (false)
            {
                EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //�߿���ʾ��ʽ0x00 �C��˸ 0x01 �C˳ʱ��ת�� 0x02 �C��ʱ��ת�� 0x03 �C��˸��˳ʱ��ת�� 0x04 �C��˸����ʱ��ת�� 0x05 �C���̽�����˸ 0x06 �C���̽���ת�� 0x07 �C��ֹ���
                sfheader.FrameDispSpeed = 0x10;    //�߿���ʾ�ٶ�
                sfheader.FrameMoveStep = 0x01;     //�߿��ƶ���������λΪ�㣬�˲� ����ΧΪ 1~16 
                sfheader.FrameUnitLength = 2;   //�߿���Ԫ����
                sfheader.FrameUnitWidth = 2;    //�߿���Ԫ���
                sfheader.FrameDirectDispBit = 0;//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M�� 
                byte[] img = Encoding.Default.GetBytes("E:\\��10.png");
                bxdualsdk.BxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }
            //��ʱ���
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

                byte[] cUnitDay = Encoding.GetEncoding("GBK").GetBytes("��");
                byte[] cUnitHour = Encoding.GetEncoding("GBK").GetBytes("ʱ");
                byte[] cUnitMinute = Encoding.GetEncoding("GBK").GetBytes("��");
                byte[] cUnitSec = Encoding.GetEncoding("GBK").GetBytes("��");
                byte[] pFixedTxt = Encoding.GetEncoding("GBK").GetBytes("");
                err = bxdualsdk.BxDual_program_timeAreaAddCounterTimer_G6(0, ref Battle, cUnitDay, cUnitHour, cUnitMinute, cUnitSec, pFixedTxt);
            }
            //���Ĳ������ʱ����ʾ����
            EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = E_arrMode.eSINGLELINE;
            timeData2.color = (uint)E_Color_G56.eRED;
            timeData2.fontName = "����";
            timeData2.fontSize = 10;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--����룬1-���У�2-�Ҷ���
            timeData2.date_enable = 0;
            timeData2.datestyle = E_DateStyle.eYYYY_MM_DD_CHS;
            timeData2.time_enable = 1;
            timeData2.timestyle = E_TimeStyle.eHH_MM_SS_COLON;
            timeData2.week_enable = 0;
            timeData2.weekstyle = E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.BxDual_program_timeAreaAddContent_G6(0, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent_G6:" + err);

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
        /// ս��ʱ��
        /// </summary>
        public static void Send_program_battieTime_6()
        {
            //ָ��IP ping���ƿ���ȡ���ƿ����ݣ�������ز�����֪�������ʡ�Ըò���
            Ping_data data = new Ping_data();
            int err = bxdualsdk.BxDual_cmd_tcpPing(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, ref data);

            //��ʾ������ɫ
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //��һ��.������Ļ�������  ���ͽ�Ŀ��Ҫ�ӿڣ����Ͷ�̬���ɺ���
            err = bxdualsdk.BxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //�ڶ�����������Ŀ�����ý�Ŀ����
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

            //��������������ʾ����������������ʾλ�ã�ʾ������һ��������Ϊ0�������С64*32��ʱ�����
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
            timebattie.BattleStartYear = 0x2020;     //��ʼ��ݣ�BCD��ʽ����ͬ��
            timebattie.BattleStartMonth = 0x01;    //��ʼ�·�
            timebattie.BattleStartDate = 0x01;     //��ʼ����
            timebattie.BattleStartHour = 0x01;     //��ʼСʱ
            timebattie.BattleStartMinute = 0x01;   //��ʼ����
            timebattie.BattleStartSecond = 0x01;   //��ʼ����
            timebattie.BattleStartWeek = 0x01;     //��ʼ����ֵ
            timebattie.StartUpMode = 0;
            err = bxdualsdk.BxDual_program_timeAreaSetBattleTime_G6(0, ref timebattie);
            Console.WriteLine("bxDual_program_timeAreaSetBattleTime_G6:" + err);

            //���岽�����ͽ�Ŀ����ʾ��
            EQprogram_G6 program = new EQprogram_G6();
            err = bxdualsdk.BxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.BxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (OnbonLedBxSdkUT.isNetwork)//����
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
            else//����
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
            //����������
            int pServer = bxduaisdkServer.BxDual_Start_Server(ServerPort);
            byte[] cards = new byte[2048];
            //���ƿ����߸���
            int count = 0;
            Thread.Sleep(2000);
            count = 0;
            server_list.Clear();

            for (int i = 0; i < 2048; i++) { cards[i] = 0; }
            while (count == 0)
            {
                //��ȡ���ƿ���������������
                count = bxduaisdkServer.BxDual_Get_CardList(cards);
                Thread.Sleep(1000);
            }
            server_list.Clear();
            //һ�����ƿ�����20������
            for (int i = 0; i < count; i++)
            {
                //ǰ16λ�����ǿ��ƿ�����ID���
                byte[] barcodevalue = cards.Skip(0 + i * 20).Take(16).ToArray();
                //��������ID��ȡͨѶʹ�ö˿�
                port = bxduaisdkServer.BxDual_Get_Port_Barcode(barcodevalue);
                var price = new Tuble<byte[], int>(barcodevalue, port);
                server_list.Add(price);
                string ssss = Encoding.Default.GetString(barcodevalue);
                Console.WriteLine("barcode:" + i + "��" + System.Text.Encoding.Default.GetString(barcodevalue) + "   port:" + port);
                //server_list.Add(price);
            }
            //�����̣߳��жϿ��ƿ��������
            Thread thread = new Thread(t => Get());
            thread.Start();
            bool pl = false;
            while (pl)
            {
                //�Ե�һ�����߿��ƿ���ͨ��ʾ��
                //������IP
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
            //�رշ�����
            //err = bxduaisdkServer.bxDual_Stop_Server(pServer);
            //�����߳�
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
                //���ƿ����߸���
                int count = 0;
                //List<ServerList> server_list = new List<ServerList>();
                count = 0;
                server_list.Clear();
                for (int i = 0; i < 2048; i++) { cards[i] = 0; }
                while (count == 0)
                {
                    Thread.Sleep(2000);
                    //��ȡ���ƿ���������������
                    count = bxduaisdkServer.BxDual_Get_CardList(cards);
                    Console.WriteLine(DateTime.Now.ToString() + "    count��" + count);
                }
                if (server_list.Count != count)
                {
                    server_list.Clear();
                    //һ�����ƿ�����20������
                    for (int i = 0; i < count; i++)
                    {
                        //ǰ16λ�����ǿ��ƿ�����ID���
                        byte[] barcodevalue = cards.Skip(0 + i * 20).Take(16).ToArray();
                        //��������ID��ȡͨѶʹ�ö˿�
                        int port = bxduaisdkServer.BxDual_Get_Port_Barcode(barcodevalue);
                        SendTextMsg(port);
                        var price = new Tuble<byte[], int>(barcodevalue, port);
                        server_list.Add(price);
                        Console.WriteLine("barcode:" + i + "��" + System.Text.Encoding.Default.GetString(barcodevalue) + "   port:" + port);
                        Thread.Sleep(2000);
                        //server_list.Add(price);
                    }
                }
            }
        }

        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        /// <summary>
        /// ������Ϣ
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
                Console.WriteLine("���ͽ�Ŀ���" + DateTime.Now.ToString());
                //����
                //��̬�����Ȳ��ţ���Ŀֹͣ����
                int err = bxdualsdk.BxDual_dynamicArea_AddAreaPic_6G(OnbonLedBxSdkUT.address, OnbonLedBxSdkUT.portRate, E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, 0, 0,
                                                      320, 320, ref pheader, img);
                Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err + "=======" + port);
                Console.WriteLine("���ͽ�Ŀ���" + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //}
        }
    }

}
