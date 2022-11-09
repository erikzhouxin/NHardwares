using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 行
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPR_WLIST_ROW
    {

        /// <summary>
        /// VZ_LPR_WLIST_CUSTOMER*/
        /// </summary>
        public System.IntPtr pCustomer;

        /// <summary>
        /// VZ_LPR_WLIST_VEHICLE*
        /// </summary>
        public System.IntPtr pVehicle;
    }
}
