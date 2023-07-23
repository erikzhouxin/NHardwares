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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int BxDual_InitSdk();
        /// <summary>
        /// 
        /// </summary>
        void BxDual_ReleaseSdk();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        int BxDual_Start_Server(int port);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServer"></param>
        /// <returns></returns>
        int BxDual_Stop_Server(int pServer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        int BxDual_Get_Port_Barcode(byte[] barcode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        int BxDual_Get_CardList(byte[] cards);
    }
}
