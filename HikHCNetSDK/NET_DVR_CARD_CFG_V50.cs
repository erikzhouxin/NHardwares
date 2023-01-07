using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CARD_CFG_V50
    {
        public uint dwSize;
        public uint dwModifyParamType;
        // 需要修改的卡参数，设置卡参数时有效，按位表示，每位代表一种参数，1为需要修改，0为不修改
        // #define CARD_PARAM_CARD_VALID       0x00000001 //卡是否有效参数
        // #define CARD_PARAM_VALID            0x00000002  //有效期参数
        // #define CARD_PARAM_CARD_TYPE        0x00000004  //卡类型参数
        // #define CARD_PARAM_DOOR_RIGHT       0x00000008  //门权限参数
        // #define CARD_PARAM_LEADER_CARD      0x00000010  //首卡参数
        // #define CARD_PARAM_SWIPE_NUM        0x00000020  //最大刷卡次数参数
        // #define CARD_PARAM_GROUP            0x00000040  //所属群组参数
        // #define CARD_PARAM_PASSWORD         0x00000080  //卡密码参数
        // #define CARD_PARAM_RIGHT_PLAN       0x00000100  //卡权限计划参数
        // #define CARD_PARAM_SWIPED_NUM       0x00000200  //已刷卡次数
        // #define CARD_PARAM_EMPLOYEE_NO      0x00000400  //工号
        // #define CARD_PARAM_NAME             0x00000800  //姓名
        // #define CARD_PARAM_DEPARTMENT_NO    0x00001000  //部门编号
        // #define CARD_SCHEDULE_PLAN_NO       0x00002000  //排班计划编号
        // #define CARD_SCHEDULE_PLAN_TYPE     0x00004000  //排班计划类型
        // #define CARD_ROOM_NUMBER            0x00008000  //房间号
        // #define CARD_SIM_NO                 0x00010000  //SIM卡号（手机号）
        // #define CARD_FLOOR_NUMBER           0x00020000  //楼层号
        // #define CARD_USER_TYPE              0x00040000  //用户类型
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo; //卡号
        public byte byCardValid; //卡是否有效，0-无效，1-有效（用于删除卡，设置时置为0进行删除，获取时此字段始终为1）
        public byte byCardType; //卡类型，1-普通卡，3-禁止名单卡，4-巡更卡，5-胁迫卡，6-超级卡，7-来宾卡，8-解除卡，9-员工卡，10-应急卡，11-应急管理卡（用于授权临时卡权限，本身不能开门），默认普通卡
        public byte byLeaderCard; //是否为首卡，1-是，0-否
        public byte byUserType; // 0 – 普通用户1 - 管理员用户;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
        public byte[] byDoorRight; //门权限(楼层权限、锁权限)，按位表示，1为有权限，0为无权限，从低位到高位表示对门（锁）1-N是否有权限
        public NET_DVR_VALID_PERIOD_CFG struValid; //有效期参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_GROUP_NUM_128, ArraySubType = UnmanagedType.I1)]
        public byte[] byBelongGroup; //所属群组，按字节表示，1-属于，0-不属于
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CARD_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardPassword; //卡密码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOOR_NUM_256 * HikHCNetSdk.MAX_CARD_RIGHT_PLAN_NUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wCardRightPlan; //卡权限计划，取值为计划模板编号，同个门（锁）不同计划模板采用权限或的方式处理
        public uint dwMaxSwipeTime; //最大刷卡次数，0为无次数限制（开锁次数）
        public uint dwSwipeTime; //已刷卡次数
        public ushort wRoomNumber;  //房间号
        public ushort wFloorNumber;   //层号
        public uint dwEmployeeNo;   //工号（用户ID）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byName;   //姓名
        public ushort wDepartmentNo;   //部门编号
        public ushort wSchedulePlanNo;   //排班计划编号
        public byte bySchedulePlanType;  //排班计划类型：0-无意义、1-个人、2-部门
        public byte byRightType;  //下发权限类型：0-普通发卡权限、1-二维码权限、2-蓝牙权限（可视对讲设备二维码权限配置项：房间号、卡号（虚拟卡号）、最大刷卡次数（开锁次数）、有效期参数；蓝牙权限：卡号（萤石APP账号）、其他参数配置与普通发卡权限一致）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public uint dwLockID;  //锁ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LOCK_CODE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byLockCode;    //锁代码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOOR_CODE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRoomCode;  //房间代码
                                   //按位表示，0-无权限，1-有权限
                                   //第0位表示：弱电报警
                                   //第1位表示：开门提示音
                                   //第2位表示：限制客卡
                                   //第3位表示：通道
                                   //第4位表示：反锁开门
                                   //第5位表示：巡更功能
        public uint dwCardRight;      //卡权限
        public uint dwPlanTemplate;   //计划模板(每天)各时间段是否启用，按位表示，0--不启用，1-启用
        public uint dwCardUserId;    //持卡人ID
        public byte byCardModelType;  //0-空，1- MIFARE S50，2- MIFARE S70，3- FM1208 CPU卡，4- FM1216 CPU卡，5-国密CPU卡，6-身份证，7- NFC
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 51, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] bySIMNum; //SIM卡号（手机号）
    }
}
