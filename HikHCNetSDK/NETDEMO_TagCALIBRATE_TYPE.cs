using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    //SDK_V35  2009-10-26

    // 标定配置类型
    public enum tagCALIBRATE_TYPE
    {
        PDC_CALIBRATE = 0x01,  // PDC 标定
        BEHAVIOR_OUT_CALIBRATE = 0x02, //行为室外场景标定  
        BEHAVIOR_IN_CALIBRATE = 0x03,    // 行为室内场景标定 
        ITS_CALBIRETE = 0x04      //  交通事件标定
    }
}
