using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NMQTT
{
    /// <summary>
    /// 
    /// </summary>
    public enum MqttTopicFilterCompareResult
    {
        /// <summary>
        /// 
        /// </summary>
        NoMatch,
        /// <summary>
        /// 
        /// </summary>
        IsMatch,
        /// <summary>
        /// 
        /// </summary>
        FilterInvalid,
        /// <summary>
        /// 
        /// </summary>
        TopicInvalid
    }
}
