using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct struAbility
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = UnmanagedType.I1)]
        //  [FieldOffsetAttribute(0)]
        public byte[] byRes;
    }
}
