using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    internal class LedBxServerSdkDllerX64 : ILedBxServerSdkProxy
    {
        public static LedBxServerSdkDllerX64 Instance { get; } = new LedBxServerSdkDllerX64();
        #region // 函数导入
        [DllImport(LedBxDualSdk.ServerFileNameX64, CharSet = CharSet.Unicode)]
        public static extern int bxDual_InitSdk();
        [DllImport(LedBxDualSdk.ServerFileNameX64, CharSet = CharSet.Unicode)]
        public static extern void bxDual_ReleaseSdk();
        [DllImport(LedBxDualSdk.ServerFileNameX64, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Start_Server(int port);

        [DllImport(LedBxDualSdk.ServerFileNameX64, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Stop_Server(int pServer);

        [DllImport(LedBxDualSdk.ServerFileNameX64, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Get_Port_Barcode(byte[] barcode);

        [DllImport(LedBxDualSdk.ServerFileNameX64, CharSet = CharSet.Unicode)]
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
    internal class LedBxServerSdkDllerX86 : ILedBxServerSdkProxy
    {
        public static LedBxServerSdkDllerX86 Instance { get; } = new LedBxServerSdkDllerX86();
        #region // 函数导入
        [DllImport(LedBxDualSdk.ServerFileNameX86, CharSet = CharSet.Unicode)]
        public static extern int bxDual_InitSdk();
        [DllImport(LedBxDualSdk.ServerFileNameX86, CharSet = CharSet.Unicode)]
        public static extern void bxDual_ReleaseSdk();
        [DllImport(LedBxDualSdk.ServerFileNameX86, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Start_Server(int port);

        [DllImport(LedBxDualSdk.ServerFileNameX86, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Stop_Server(int pServer);

        [DllImport(LedBxDualSdk.ServerFileNameX86, CharSet = CharSet.Unicode)]
        public static extern int bxDual_Get_Port_Barcode(byte[] barcode);

        [DllImport(LedBxDualSdk.ServerFileNameX86, CharSet = CharSet.Unicode)]
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
}
