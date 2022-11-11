namespace System.Data.YuShiITSSDK
{
    /**
    标识：IA_TRIGGER_TYPE_E
    类型：枚举
    目的：触发抓拍方式
    定义：
    */
    public enum IA_TRIGGER_TYPE_E
    {
        IA_TRIGGER_DEBUG = 0,                    /* 调试抓拍照片 */
        IA_TRIGGER_FORMAL = 1,                   /* 正式抓拍照片 */
        IA_TRIGGER_MANUAL_PROCESS = 2,           /* 平台触发手动抓拍 */
        IA_TRIGGER_LINKAGE_PROCESS = 3,          /* 平台触发联动抓拍 */
        IA_TRIGGER_COUNT
    }

}
