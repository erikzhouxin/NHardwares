using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// LED服务SDK代理
    /// </summary>
    public interface ILedBxServerSdkProxy
    {
        int BxDual_InitSdk();

        void BxDual_ReleaseSdk();

        int BxDual_Start_Server(int port);

        int BxDual_Stop_Server(int pServer);

        int BxDual_Get_Port_Barcode(byte[] barcode);

        int BxDual_Get_CardList(byte[] cards);
    }
    internal class LedBxServerSdkDller : ILedBxServerSdkProxy
    {
        public static LedBxServerSdkDller Instance { get; } = new LedBxServerSdkDller();
        #region // 函数导入
        [DllImport(LedBxDualSdk.ServerFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_InitSdk();
        [DllImport(LedBxDualSdk.ServerFileName, CharSet = CharSet.Unicode)]
        public static extern void bxDual_ReleaseSdk();
        [DllImport(LedBxDualSdk.ServerFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Start_Server(int port);

        [DllImport(LedBxDualSdk.ServerFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Stop_Server(int pServer);

        [DllImport(LedBxDualSdk.ServerFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Get_Port_Barcode(byte[] barcode);

        [DllImport(LedBxDualSdk.ServerFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Get_CardList(byte[] cards);
        #endregion 函数导入
        #region // 显示实现
        int ILedBxServerSdkProxy.BxDual_Get_CardList(byte[] cards) => bxDual_Get_CardList(cards);
        int ILedBxServerSdkProxy.BxDual_Get_Port_Barcode(byte[] barcode) => bxDual_Get_Port_Barcode(barcode);
        int ILedBxServerSdkProxy.BxDual_InitSdk() => bxDual_InitSdk();
        void ILedBxServerSdkProxy.BxDual_ReleaseSdk() => bxDual_ReleaseSdk();
        int ILedBxServerSdkProxy.BxDual_Start_Server(int port) => bxDual_Start_Server(port);
        int ILedBxServerSdkProxy.BxDual_Stop_Server(int pServer) => bxDual_Stop_Server(pServer);
        #endregion 显示实现
    }
    internal class LedBxServerSdkLoader : ASdkDynamicLoader, ILedBxServerSdkProxy
    {
        #region // 委托定义
        private DSCreater.bxDual_Get_CardList _bxDual_Get_CardList;
        private DSCreater.bxDual_Get_Port_Barcode _bxDual_Get_Port_Barcode;
        private DSCreater.bxDual_InitSdk _bxDual_InitSdk;
        private DSCreater.bxDual_ReleaseSdk _bxDual_ReleaseSdk;
        private DSCreater.bxDual_Start_Server _bxDual_Start_Server;
        private DSCreater.bxDual_Stop_Server _bxDual_Stop_Server;
        #endregion 委托定义
        public LedBxServerSdkLoader()
        {
            if (Environment.Is64BitProcess) { Initialize64(); } else { Initialize32(); }
        }

        private void Initialize64()
        {
            _bxDual_Get_CardList = GetDelegate<DSCreater.bxDual_Get_CardList>(nameof(DSCreater.bxDual_Get_CardList));
            _bxDual_Get_Port_Barcode = GetDelegate<DSCreater.bxDual_Get_Port_Barcode>(nameof(DSCreater.bxDual_Get_Port_Barcode));
            _bxDual_InitSdk = GetDelegate<DSCreater.bxDual_InitSdk>(nameof(DSCreater.bxDual_InitSdk));
            _bxDual_ReleaseSdk = GetDelegate<DSCreater.bxDual_ReleaseSdk>(nameof(DSCreater.bxDual_ReleaseSdk));
            _bxDual_Start_Server = GetDelegate<DSCreater.bxDual_Start_Server>(nameof(DSCreater.bxDual_Start_Server));
            _bxDual_Stop_Server = GetDelegate<DSCreater.bxDual_Stop_Server>(nameof(DSCreater.bxDual_Stop_Server));
        }

        private void Initialize32()
        {
            _bxDual_Get_CardList = GetDelegate<DSCreater.bxDual_Get_CardList>($"_{nameof(DSCreater.bxDual_Get_CardList)}@4");
            _bxDual_Get_Port_Barcode = GetDelegate<DSCreater.bxDual_Get_Port_Barcode>($"_{nameof(DSCreater.bxDual_Get_Port_Barcode)}@4");
            _bxDual_InitSdk = GetDelegate<DSCreater.bxDual_InitSdk>(nameof(DSCreater.bxDual_InitSdk));
            _bxDual_ReleaseSdk = GetDelegate<DSCreater.bxDual_ReleaseSdk>(nameof(DSCreater.bxDual_ReleaseSdk));
            _bxDual_Start_Server = GetDelegate<DSCreater.bxDual_Start_Server>($"_{nameof(DSCreater.bxDual_Start_Server)}@4");
            _bxDual_Stop_Server = GetDelegate<DSCreater.bxDual_Stop_Server>($"_{nameof(DSCreater.bxDual_Stop_Server)}@4");
        }

        public override string GetFileFullName()
        {
            return LedBxDualSdk.ServerFullName;
        }
        #region // 显示实现
        int ILedBxServerSdkProxy.BxDual_Get_CardList(byte[] cards) => _bxDual_Get_CardList(cards);
        int ILedBxServerSdkProxy.BxDual_Get_Port_Barcode(byte[] barcode) => _bxDual_Get_Port_Barcode(barcode);
        int ILedBxServerSdkProxy.BxDual_InitSdk() => _bxDual_InitSdk();
        void ILedBxServerSdkProxy.BxDual_ReleaseSdk() => _bxDual_ReleaseSdk();
        int ILedBxServerSdkProxy.BxDual_Start_Server(int port) => _bxDual_Start_Server(port);
        int ILedBxServerSdkProxy.BxDual_Stop_Server(int pServer) => _bxDual_Stop_Server(pServer);
        #endregion 显示实现
    }
}
