namespace System.Data.YuShiNetDevSDK
{
    public struct NETDEMO_PLATE_TYPE
    {
        public Int32 dwPlateType;
        public string strPlateType;

        public NETDEMO_PLATE_TYPE(int dwPlateTypeArg, string strPlateTypeArg)
        {
            dwPlateType = dwPlateTypeArg;
            strPlateType = strPlateTypeArg;
        }
    }
}
