namespace System.Data.HikHCNetSDK
{
    public struct PLAYM4_SYSTEM_TIME
    {
        public int dwYear;

        public int dwMon;

        public int dwDay;

        public int dwHour;

        public int dwMin;

        public int dwSec;

        public int dwMs;

        public DateTime ToDateTime()
        {
            return new DateTime(dwYear, dwMon, dwDay, dwHour, dwMin, dwSec, dwMs);
        }
    }

}
