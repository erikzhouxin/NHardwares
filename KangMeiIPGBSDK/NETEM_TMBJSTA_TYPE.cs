using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 终端报警信号值
     * typedef enum __EM_TMBJSTA_TYPE 
     * {
     *   TMBJSTA_STA1=0,//呼叫报警(终端对讲呼叫)
     *   TMBJSTA_STA2,  //防拆警报
     *   TMBJSTA_STA3,  //输入短路报警
     *   TMBJSTA_STA4,
     *   TMBJSTA_STA5
     * }EM_TMBJSTA_TYPE ;
     **/
    public enum NETEM_TMBJSTA_TYPE
    {
        /// <summary>
        /// 
        /// </summary>
        TMBJSTA_STA5 = 4,
        /// <summary>
        /// 
        /// </summary>
        TMBJSTA_STA4 = 3,
        /// <summary>
        /// 输入短路报警
        /// </summary>
        TMBJSTA_STA3 = 2,
        /// <summary>
        /// 防拆警报
        /// </summary>
        TMBJSTA_STA2 = 1,
        /// <summary>
        /// 呼叫报警(终端对讲呼叫)
        /// </summary>
        TMBJSTA_STA1 = 0
    }
}
