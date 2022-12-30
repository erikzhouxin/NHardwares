using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NS7NetPlus
{
    /// <summary>
    /// NS7NetPlus调用
    /// </summary>
    public static class S7NetPlusSdk
    {
        /// <summary>
        /// Creates a PLC object with all the parameters needed for connections.
        /// For S7-1200 and S7-1500, the default is rack = 0 and slot = 0.
        /// You need slot > 0 if you are connecting to external ethernet card (CP).
        /// For S7-300 and S7-400 the default is rack = 0 and slot = 2.
        /// </summary>
        /// <param name="cpu">CpuType of the PLC (select from the enum)</param>
        /// <param name="ip">Ip address of the PLC</param>
        /// <param name="rack">rack of the PLC, usually it's 0, but check in the hardware configuration of Step7 or TIA portal</param>
        /// <param name="slot">slot of the CPU of the PLC, usually it's 2 for S7300-S7400, 0 for S7-1200 and S7-1500.
        ///  If you use an external ethernet card, this must be set accordingly.</param>
        public static IS7NetPlusPlc Create(this CpuType cpu, string ip, short rack, short slot)
        {
            return new S7NetPlusPlc(cpu, ip, rack, slot);
        }

        /// <summary>
        /// Creates a PLC object with all the parameters needed for connections.
        /// For S7-1200 and S7-1500, the default is rack = 0 and slot = 0.
        /// You need slot > 0 if you are connecting to external ethernet card (CP).
        /// For S7-300 and S7-400 the default is rack = 0 and slot = 2.
        /// </summary>
        /// <param name="cpu">CpuType of the PLC (select from the enum)</param>
        /// <param name="ip">Ip address of the PLC</param>
        /// <param name="port">Port number used for the connection, default 102.</param>
        /// <param name="rack">rack of the PLC, usually it's 0, but check in the hardware configuration of Step7 or TIA portal</param>
        /// <param name="slot">slot of the CPU of the PLC, usually it's 2 for S7300-S7400, 0 for S7-1200 and S7-1500.
        ///  If you use an external ethernet card, this must be set accordingly.</param>
        public static IS7NetPlusPlc Create(this CpuType cpu, string ip, int port, Int16 rack, Int16 slot)
        {
            return new S7NetPlusPlc(cpu, ip, port, rack, slot);
        }

        /// <summary>
        /// Creates a PLC object with all the parameters needed for connections.
        /// For S7-1200 and S7-1500, the default is rack = 0 and slot = 0.
        /// You need slot > 0 if you are connecting to external ethernet card (CP).
        /// For S7-300 and S7-400 the default is rack = 0 and slot = 2.
        /// </summary>
        /// <param name="ip">Ip address of the PLC</param>
        /// <param name="tsapPair">The TSAP addresses used for the connection request.</param>
        public static IS7NetPlusPlc Create(string ip, TsapPair tsapPair)
        {
            return new S7NetPlusPlc(ip, tsapPair);
        }
        /// <summary>
        /// Creates a PLC object with all the parameters needed for connections. Use this constructor
        /// if you want to manually override the TSAP addresses used during the connection request.
        /// </summary>
        /// <param name="ip">Ip address of the PLC</param>
        /// <param name="port">Port number used for the connection, default 102.</param>
        /// <param name="tsapPair">The TSAP addresses used for the connection request.</param>
        public static IS7NetPlusPlc Create(string ip, int port, TsapPair tsapPair)
        {
            return new S7NetPlusPlc(ip, port, tsapPair);
        }
    }
}
