using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace System.Data.NS7NetPlus
{
    /// <summary>
    /// Creates an instance of S7.Net driver
    /// </summary>
    public partial class Plc : IDisposable
    {
        #region // RegularContent
        /// <summary>
        /// The default port for the S7 protocol.
        /// </summary>
        public const int DefaultPort = 102;

        /// <summary>
        /// The default timeout (in milliseconds) used for <see cref="P:ReadTimeout"/> and <see cref="P:WriteTimeout"/>.
        /// </summary>
        public const int DefaultTimeout = 10_000;

        private readonly TaskQueue queue = new TaskQueue();

        //TCP connection to device
        private TcpClient? tcpClient;
        private NetworkStream? _stream;

        private int readTimeout = DefaultTimeout; // default no timeout
        private int writeTimeout = DefaultTimeout; // default no timeout

        /// <summary>
        /// IP address of the PLC
        /// </summary>
        public string IP { get; }

        /// <summary>
        /// PORT Number of the PLC, default is 102
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// The TSAP addresses used during the connection request.
        /// </summary>
        public TsapPair TsapPair { get; set; }

        /// <summary>
        /// CPU type of the PLC
        /// </summary>
        public CpuType CPU { get; }

        /// <summary>
        /// Rack of the PLC
        /// </summary>
        public Int16 Rack { get; }

        /// <summary>
        /// Slot of the CPU of the PLC
        /// </summary>
        public Int16 Slot { get; }

        /// <summary>
        /// Max PDU size this cpu supports
        /// </summary>
        public int MaxPDUSize { get; private set; }

        /// <summary>Gets or sets the amount of time that a read operation blocks waiting for data from PLC.</summary>
        /// <returns>A <see cref="T:System.Int32" /> that specifies the amount of time, in milliseconds, that will elapse before a read operation fails. The default value, <see cref="F:System.Threading.Timeout.Infinite" />, specifies that the read operation does not time out.</returns>
        public int ReadTimeout
        {
            get => readTimeout;
            set
            {
                readTimeout = value;
                if (tcpClient != null) tcpClient.ReceiveTimeout = readTimeout;
            }
        }

        /// <summary>Gets or sets the amount of time that a write operation blocks waiting for data to PLC. </summary>
        /// <returns>A <see cref="T:System.Int32" /> that specifies the amount of time, in milliseconds, that will elapse before a write operation fails. The default value, <see cref="F:System.Threading.Timeout.Infinite" />, specifies that the write operation does not time out.</returns>
        public int WriteTimeout
        {
            get => writeTimeout;
            set
            {
                writeTimeout = value;
                if (tcpClient != null) tcpClient.SendTimeout = writeTimeout;
            }
        }

        /// <summary>
        /// Gets a value indicating whether a connection to the PLC has been established.
        /// </summary>
        /// <remarks>
        /// The <see cref="IsConnected"/> property gets the connection state of the Client socket as
        /// of the last I/O operation. When it returns <c>false</c>, the Client socket was either
        /// never  connected, or is no longer connected.
        ///
        /// <para>
        /// Because the <see cref="IsConnected"/> property only reflects the state of the connection
        /// as of the most recent operation, you should attempt to send or receive a message to
        /// determine the current state. After the message send fails, this property no longer
        /// returns <c>true</c>. Note that this behavior is by design. You cannot reliably test the
        /// state of the connection because, in the time between the test and a send/receive, the
        /// connection could have been lost. Your code should assume the socket is connected, and
        /// gracefully handle failed transmissions.
        /// </para>
        /// </remarks>
        public bool IsConnected => tcpClient?.Connected ?? false;

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
        public Plc(CpuType cpu, string ip, Int16 rack, Int16 slot)
            : this(cpu, ip, DefaultPort, rack, slot)
        {
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
        public Plc(CpuType cpu, string ip, int port, Int16 rack, Int16 slot)
            : this(ip, port, TsapPair.GetDefaultTsapPair(cpu, rack, slot))
        {
            if (!Enum.IsDefined(typeof(CpuType), cpu))
                throw new ArgumentException(
                    $"The value of argument '{nameof(cpu)}' ({cpu}) is invalid for Enum type '{typeof(CpuType).Name}'.",
                    nameof(cpu));

            CPU = cpu;
            Rack = rack;
            Slot = slot;
        }

        /// <summary>
        /// Creates a PLC object with all the parameters needed for connections.
        /// For S7-1200 and S7-1500, the default is rack = 0 and slot = 0.
        /// You need slot > 0 if you are connecting to external ethernet card (CP).
        /// For S7-300 and S7-400 the default is rack = 0 and slot = 2.
        /// </summary>
        /// <param name="ip">Ip address of the PLC</param>
        /// <param name="tsapPair">The TSAP addresses used for the connection request.</param>
        public Plc(string ip, TsapPair tsapPair) : this(ip, DefaultPort, tsapPair)
        {
        }

        /// <summary>
        /// Creates a PLC object with all the parameters needed for connections. Use this constructor
        /// if you want to manually override the TSAP addresses used during the connection request.
        /// </summary>
        /// <param name="ip">Ip address of the PLC</param>
        /// <param name="port">Port number used for the connection, default 102.</param>
        /// <param name="tsapPair">The TSAP addresses used for the connection request.</param>
        public Plc(string ip, int port, TsapPair tsapPair)
        {
            if (string.IsNullOrEmpty(ip))
                throw new ArgumentException("IP address must valid.", nameof(ip));

            IP = ip;
            Port = port;
            MaxPDUSize = 240;
            TsapPair = tsapPair;
        }

        /// <summary>
        /// Close connection to PLC
        /// </summary>
        public void Close()
        {
            if (tcpClient != null)
            {
                if (tcpClient.Connected) tcpClient.Close();
                tcpClient = null; // Can not reuse TcpClient once connection gets closed.
            }
        }

        private void AssertPduSizeForRead(ICollection<DataItem> dataItems)
        {
            // send request limit: 19 bytes of header data, 12 bytes of parameter data for each dataItem
            var requiredRequestSize = 19 + dataItems.Count * 12;
            if (requiredRequestSize > MaxPDUSize) throw new Exception($"Too many vars requested for read. Request size ({requiredRequestSize}) is larger than protocol limit ({MaxPDUSize}).");

            // response limit: 14 bytes of header data, 4 bytes of result data for each dataItem and the actual data
            var requiredResponseSize = GetDataLength(dataItems) + dataItems.Count * 4 + 14;
            if (requiredResponseSize > MaxPDUSize) throw new Exception($"Too much data requested for read. Response size ({requiredResponseSize}) is larger than protocol limit ({MaxPDUSize}).");
        }

        private void AssertPduSizeForWrite(ICollection<DataItem> dataItems)
        {
            // 12 bytes of header data, 18 bytes of parameter data for each dataItem
            if (dataItems.Count * 18 + 12 > MaxPDUSize) throw new Exception("Too many vars supplied for write");

            // 12 bytes of header data, 16 bytes of data for each dataItem and the actual data
            if (GetDataLength(dataItems) + dataItems.Count * 16 + 12 > MaxPDUSize)
                throw new Exception("Too much data supplied for write");
        }

        private void ConfigureConnection()
        {
            if (tcpClient == null)
            {
                return;
            }

            tcpClient.ReceiveTimeout = ReadTimeout;
            tcpClient.SendTimeout = WriteTimeout;
        }

        private int GetDataLength(IEnumerable<DataItem> dataItems)
        {
            // Odd length variables are 0-padded
            return dataItems.Select(di => VarTypeToByteLength(di.VarType, di.Count))
                .Sum(len => (len & 1) == 1 ? len + 1 : len);
        }

        private static void AssertReadResponse(byte[] s7Data, int dataLength)
        {
            var expectedLength = dataLength + 18;

            PlcException NotEnoughBytes() =>
                new PlcException(ErrorCode.WrongNumberReceivedBytes,
                    $"Received {s7Data.Length} bytes: '{BitConverter.ToString(s7Data)}', expected {expectedLength} bytes.")
            ;

            if (s7Data == null)
                throw new PlcException(ErrorCode.WrongNumberReceivedBytes, "No s7Data received.");

            if (s7Data.Length < 15) throw NotEnoughBytes();

            ValidateResponseCode((ReadWriteErrorCode)s7Data[14]);

            if (s7Data.Length < expectedLength) throw NotEnoughBytes();
        }

        internal static void ValidateResponseCode(ReadWriteErrorCode statusCode)
        {
            switch (statusCode)
            {
                case ReadWriteErrorCode.ObjectDoesNotExist:
                    throw new Exception("Received error from PLC: Object does not exist.");
                case ReadWriteErrorCode.DataTypeInconsistent:
                    throw new Exception("Received error from PLC: Data type inconsistent.");
                case ReadWriteErrorCode.DataTypeNotSupported:
                    throw new Exception("Received error from PLC: Data type not supported.");
                case ReadWriteErrorCode.AccessingObjectNotAllowed:
                    throw new Exception("Received error from PLC: Accessing object not allowed.");
                case ReadWriteErrorCode.AddressOutOfRange:
                    throw new Exception("Received error from PLC: Address out of range.");
                case ReadWriteErrorCode.HardwareFault:
                    throw new Exception("Received error from PLC: Hardware fault.");
                case ReadWriteErrorCode.Success:
                    break;
                default:
                    throw new Exception($"Invalid response from PLC: statusCode={(byte)statusCode}.");
            }
        }

        private Stream GetStreamIfAvailable()
        {
            if (_stream == null)
            {
                throw new PlcException(ErrorCode.ConnectionError, "Plc is not connected");
            }

            return _stream;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Dispose Plc Object
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Plc() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        #endregion RegularContent
        #region // PlcAsynchronous
        /// <summary>
        /// Connects to the PLC and performs a COTP ConnectionRequest and S7 CommunicationSetup.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that the cancellation will not affect opening the socket in any way and only affects data transfers for configuring the connection after the socket connection is successfully established.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous open operation.</returns>
        public async Task OpenAsync(CancellationToken cancellationToken = default)
        {
            var stream = await ConnectAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await queue.Enqueue(async () =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await EstablishConnection(stream, cancellationToken).ConfigureAwait(false);
                    _stream = stream;

                    return default(object);
                }).ConfigureAwait(false);
            }
            catch (Exception)
            {
                stream.Dispose();
                throw;
            }
        }

        private async Task<NetworkStream> ConnectAsync(CancellationToken cancellationToken)
        {
            tcpClient = new TcpClient();
            ConfigureConnection();

#if NET5_0_OR_GREATER
            await tcpClient.ConnectAsync(IP, Port, cancellationToken).ConfigureAwait(false);
#else
            await tcpClient.ConnectAsync(IP, Port).ConfigureAwait(false);
#endif
            return tcpClient.GetStream();
        }

        private async Task EstablishConnection(Stream stream, CancellationToken cancellationToken)
        {
            await RequestConnection(stream, cancellationToken).ConfigureAwait(false);
            await SetupConnection(stream, cancellationToken).ConfigureAwait(false);
        }

        private async Task RequestConnection(Stream stream, CancellationToken cancellationToken)
        {
            var requestData = S7NetPlusCaller.GetCOTPConnectionRequest(TsapPair);
            var response = await NoLockRequestTpduAsync(stream, requestData, cancellationToken).ConfigureAwait(false);

            if (response.PDUType != COTP.PduType.ConnectionConfirmed)
            {
                throw new InvalidDataException("Connection request was denied", response.TPkt.Data, 1, 0x0d);
            }
        }

        private async Task SetupConnection(Stream stream, CancellationToken cancellationToken)
        {
            var setupData = GetS7ConnectionSetup();

            var s7data = await NoLockRequestTsduAsync(stream, setupData, 0, setupData.Length, cancellationToken)
                .ConfigureAwait(false);

            if (s7data.Length < 2)
                throw new WrongNumberOfBytesException("Not enough data received in response to Communication Setup");

            //Check for S7 Ack Data
            if (s7data[1] != 0x03)
                throw new InvalidDataException("Error reading Communication Setup response", s7data, 1, 0x03);

            if (s7data.Length < 20)
                throw new WrongNumberOfBytesException("Not enough data received in response to Communication Setup");

            // TODO: check if this should not rather be UInt16.
            MaxPDUSize = s7data[18] * 256 + s7data[19];
        }

        /// <summary>
        /// Reads a number of bytes from a DB starting from a specified index. This handles more than 200 bytes with multiple requests.
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="count">Byte count, if you want to read 120 bytes, set this to 120.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>Returns the bytes in an array</returns>
        public async Task<byte[]> ReadBytesAsync(DataType dataType, int db, int startByteAdr, int count, CancellationToken cancellationToken = default)
        {
            var resultBytes = new byte[count];
            int index = 0;
            while (count > 0)
            {
                //This works up to MaxPDUSize-1 on SNAP7. But not MaxPDUSize-0.
                var maxToRead = Math.Min(count, MaxPDUSize - 18);
                await ReadBytesWithSingleRequestAsync(dataType, db, startByteAdr + index, resultBytes, index, maxToRead, cancellationToken).ConfigureAwait(false);
                count -= maxToRead;
                index += maxToRead;
            }
            return resultBytes;
        }

        /// <summary>
        /// Read and decode a certain number of bytes of the "VarType" provided.
        /// This can be used to read multiple consecutive variables of the same type (Word, DWord, Int, etc).
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="varType">Type of the variable/s that you are reading</param>
        /// <param name="bitAdr">Address of bit. If you want to read DB1.DBX200.6, set 6 to this parameter.</param>
        /// <param name="varCount"></param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        public async Task<object?> ReadAsync(DataType dataType, int db, int startByteAdr, VarType varType, int varCount, byte bitAdr = 0, CancellationToken cancellationToken = default)
        {
            int cntBytes = VarTypeToByteLength(varType, varCount);
            byte[] bytes = await ReadBytesAsync(dataType, db, startByteAdr, cntBytes, cancellationToken).ConfigureAwait(false);
            return ParseBytes(varType, bytes, varCount, bitAdr);
        }

        /// <summary>
        /// Reads a single variable from the PLC, takes in input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="variable">Input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>Returns an object that contains the value. This object must be cast accordingly.</returns>
        public async Task<object?> ReadAsync(string variable, CancellationToken cancellationToken = default)
        {
            var adr = new PLCAddress(variable);
            return await ReadAsync(adr.DataType, adr.DbNumber, adr.StartByte, adr.VarType, 1, (byte)adr.BitNumber, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads all the bytes needed to fill a struct in C#, starting from a certain address, and return an object that can be casted to the struct.
        /// </summary>
        /// <param name="structType">Type of the struct to be readed (es.: TypeOf(MyStruct)).</param>
        /// <param name="db">Address of the DB.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>Returns a struct that must be cast.</returns>
        public async Task<object?> ReadStructAsync(Type structType, int db, int startByteAdr = 0, CancellationToken cancellationToken = default)
        {
            int numBytes = System.Data.NS7NetPlus.Struct.GetStructSize(structType);
            // now read the package
            var resultBytes = await ReadBytesAsync(DataType.DataBlock, db, startByteAdr, numBytes, cancellationToken).ConfigureAwait(false);

            // and decode it
            return System.Data.NS7NetPlus.Struct.FromBytes(structType, resultBytes);
        }

        /// <summary>
        /// Reads all the bytes needed to fill a struct in C#, starting from a certain address, and returns the struct or null if nothing was read.
        /// </summary>
        /// <typeparam name="T">The struct type</typeparam>
        /// <param name="db">Address of the DB.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>Returns a nulable struct. If nothing was read null will be returned.</returns>
        public async Task<T?> ReadStructAsync<T>(int db, int startByteAdr = 0, CancellationToken cancellationToken = default) where T : struct
        {
            return await ReadStructAsync(typeof(T), db, startByteAdr, cancellationToken).ConfigureAwait(false) as T?;
        }

        /// <summary>
        /// Reads all the bytes needed to fill a class in C#, starting from a certain address, and set all the properties values to the value that are read from the PLC.
        /// This reads only properties, it doesn't read private variable or public variable without {get;set;} specified.
        /// </summary>
        /// <param name="sourceClass">Instance of the class that will store the values</param>
        /// <param name="db">Index of the DB; es.: 1 is for DB1</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>The number of read bytes</returns>
        public async Task<Tuple<int, object>> ReadClassAsync(object sourceClass, int db, int startByteAdr = 0, CancellationToken cancellationToken = default)
        {
            int numBytes = (int)Class.GetClassSize(sourceClass);
            if (numBytes <= 0)
            {
                throw new Exception("The size of the class is less than 1 byte and therefore cannot be read");
            }

            // now read the package
            var resultBytes = await ReadBytesAsync(DataType.DataBlock, db, startByteAdr, numBytes, cancellationToken).ConfigureAwait(false);
            // and decode it
            Class.FromBytes(sourceClass, resultBytes);

            return new Tuple<int, object>(resultBytes.Length, sourceClass);
        }

        /// <summary>
        /// Reads all the bytes needed to fill a class in C#, starting from a certain address, and set all the properties values to the value that are read from the PLC.
        /// This reads only properties, it doesn't read private variable or public variable without {get;set;} specified. To instantiate the class defined by the generic
        /// type, the class needs a default constructor.
        /// </summary>
        /// <typeparam name="T">The class that will be instantiated. Requires a default constructor</typeparam>
        /// <param name="db">Index of the DB; es.: 1 is for DB1</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>An instance of the class with the values read from the PLC. If no data has been read, null will be returned</returns>
        public async Task<T?> ReadClassAsync<T>(int db, int startByteAdr = 0, CancellationToken cancellationToken = default) where T : class
        {
            return await ReadClassAsync(() => Activator.CreateInstance<T>(), db, startByteAdr, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads all the bytes needed to fill a class in C#, starting from a certain address, and set all the properties values to the value that are read from the PLC.
        /// This reads only properties, it doesn't read private variable or public variable without {get;set;} specified.
        /// </summary>
        /// <typeparam name="T">The class that will be instantiated</typeparam>
        /// <param name="classFactory">Function to instantiate the class</param>
        /// <param name="db">Index of the DB; es.: 1 is for DB1</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>An instance of the class with the values read from the PLC. If no data has been read, null will be returned</returns>
        public async Task<T?> ReadClassAsync<T>(Func<T> classFactory, int db, int startByteAdr = 0, CancellationToken cancellationToken = default) where T : class
        {
            var instance = classFactory();
            var res = await ReadClassAsync(instance, db, startByteAdr, cancellationToken).ConfigureAwait(false);
            int readBytes = res.Item1;
            if (readBytes <= 0)
            {
                return null;
            }

            return (T)res.Item2;
        }

        /// <summary>
        /// Reads multiple vars in a single request.
        /// You have to create and pass a list of DataItems and you obtain in response the same list with the values.
        /// Values are stored in the property "Value" of the dataItem and are already converted.
        /// If you don't want the conversion, just create a dataItem of bytes.
        /// The number of DataItems as well as the total size of the requested data can not exceed a certain limit (protocol restriction).
        /// </summary>
        /// <param name="dataItems">List of dataitems that contains the list of variables that must be read.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        public async Task<List<DataItem>> ReadMultipleVarsAsync(List<DataItem> dataItems, CancellationToken cancellationToken = default)
        {
            //Snap7 seems to choke on PDU sizes above 256 even if snap7
            //replies with bigger PDU size in connection setup.
            AssertPduSizeForRead(dataItems);

            try
            {
                var dataToSend = BuildReadRequestPackage(dataItems.Select(d => DataItem.GetDataItemAddress(d)).ToList());
                var s7data = await RequestTsduAsync(dataToSend, cancellationToken);

                ValidateResponseCode((ReadWriteErrorCode)s7data[14]);

                ParseDataIntoDataItems(s7data, dataItems);
            }
            catch (SocketException socketException)
            {
                throw new PlcException(ErrorCode.ReadData, socketException);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.ReadData, exc);
            }
            return dataItems;
        }


        /// <summary>
        /// Write a number of bytes from a DB starting from a specified index. This handles more than 200 bytes with multiple requests.
        /// If the write was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to write DB1.DBW200, this is 200.</param>
        /// <param name="value">Bytes to write. If more than 200, multiple requests will be made.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteBytesAsync(DataType dataType, int db, int startByteAdr, byte[] value, CancellationToken cancellationToken = default)
        {
            int localIndex = 0;
            int count = value.Length;
            while (count > 0)
            {
                var maxToWrite = (int)Math.Min(count, MaxPDUSize - 35);
                await WriteBytesWithASingleRequestAsync(dataType, db, startByteAdr + localIndex, value, localIndex, maxToWrite, cancellationToken).ConfigureAwait(false);
                count -= maxToWrite;
                localIndex += maxToWrite;
            }
        }

        /// <summary>
        /// Write a single bit from a DB with the specified index.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to write DB1.DBW200, this is 200.</param>
        /// <param name="bitAdr">The address of the bit. (0-7)</param>
        /// <param name="value">Bytes to write. If more than 200, multiple requests will be made.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteBitAsync(DataType dataType, int db, int startByteAdr, int bitAdr, bool value, CancellationToken cancellationToken = default)
        {
            if (bitAdr < 0 || bitAdr > 7)
                throw new InvalidAddressException(string.Format("Addressing Error: You can only reference bitwise locations 0-7. Address {0} is invalid", bitAdr));

            await WriteBitWithASingleRequestAsync(dataType, db, startByteAdr, bitAdr, value, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Write a single bit from a DB with the specified index.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to write DB1.DBW200, this is 200.</param>
        /// <param name="bitAdr">The address of the bit. (0-7)</param>
        /// <param name="value">Bytes to write. If more than 200, multiple requests will be made.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteBitAsync(DataType dataType, int db, int startByteAdr, int bitAdr, int value, CancellationToken cancellationToken = default)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException("Value must be 0 or 1", nameof(value));

            await WriteBitAsync(dataType, db, startByteAdr, bitAdr, value == 1, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Takes in input an object and tries to parse it to an array of values. This can be used to write many data, all of the same type.
        /// You must specify the memory area type, memory are address, byte start address and bytes count.
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="value">Bytes to write. The lenght of this parameter can't be higher than 200. If you need more, use recursion.</param>
        /// <param name="bitAdr">The address of the bit. (0-7)</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteAsync(DataType dataType, int db, int startByteAdr, object value, int bitAdr = -1, CancellationToken cancellationToken = default)
        {
            if (bitAdr != -1)
            {
                //Must be writing a bit value as bitAdr is specified
                if (value is bool boolean)
                {
                    await WriteBitAsync(dataType, db, startByteAdr, bitAdr, boolean, cancellationToken).ConfigureAwait(false);
                }
                else if (value is int intValue)
                {
                    if (intValue < 0 || intValue > 7)
                        throw new ArgumentOutOfRangeException(
                            string.Format(
                                "Addressing Error: You can only reference bitwise locations 0-7. Address {0} is invalid",
                                bitAdr), nameof(bitAdr));

                    await WriteBitAsync(dataType, db, startByteAdr, bitAdr, intValue == 1, cancellationToken).ConfigureAwait(false);
                }
                else throw new ArgumentException("Value must be a bool or an int to write a bit", nameof(value));
            }
            else await WriteBytesAsync(dataType, db, startByteAdr, S7NetPlusCaller.SerializeValue(value), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Writes a single variable from the PLC, takes in input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.
        /// If the write was not successful, check <see cref="LastErrorCode"/> or <see cref="LastErrorString"/>.
        /// </summary>
        /// <param name="variable">Input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.</param>
        /// <param name="value">Value to be written to the PLC</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteAsync(string variable, object value, CancellationToken cancellationToken = default)
        {
            var adr = new PLCAddress(variable);
            await WriteAsync(adr.DataType, adr.DbNumber, adr.StartByte, value, adr.BitNumber, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Writes a C# struct to a DB in the PLC
        /// </summary>
        /// <param name="structValue">The struct to be written</param>
        /// <param name="db">Db address</param>
        /// <param name="startByteAdr">Start bytes on the PLC</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteStructAsync(object structValue, int db, int startByteAdr = 0, CancellationToken cancellationToken = default)
        {
            var bytes = Struct.ToBytes(structValue).ToList();
            await WriteBytesAsync(DataType.DataBlock, db, startByteAdr, bytes.ToArray(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Writes a C# class to a DB in the PLC
        /// </summary>
        /// <param name="classValue">The class to be written</param>
        /// <param name="db">Db address</param>
        /// <param name="startByteAdr">Start bytes on the PLC</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.
        /// Please note that cancellation is advisory/cooperative and will not lead to immediate cancellation in all cases.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteClassAsync(object classValue, int db, int startByteAdr = 0, CancellationToken cancellationToken = default)
        {
            byte[] bytes = new byte[(int)Class.GetClassSize(classValue)];
            System.Data.NS7NetPlus.Class.ToBytes(classValue, bytes);
            await WriteBytesAsync(DataType.DataBlock, db, startByteAdr, bytes, cancellationToken).ConfigureAwait(false);
        }

        private async Task ReadBytesWithSingleRequestAsync(DataType dataType, int db, int startByteAdr, byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var dataToSend = BuildReadRequestPackage(new[] { new DataItemAddress(dataType, db, startByteAdr, count) });

            var s7data = await RequestTsduAsync(dataToSend, cancellationToken);
            AssertReadResponse(s7data, count);

            Array.Copy(s7data, 18, buffer, offset, count);
        }

        /// <summary>
        /// Write DataItem(s) to the PLC. Throws an exception if the response is invalid
        /// or when the PLC reports errors for item(s) written.
        /// </summary>
        /// <param name="dataItems">The DataItem(s) to write to the PLC.</param>
        /// <returns>Task that completes when response from PLC is parsed.</returns>
        public async Task WriteAsync(params DataItem[] dataItems)
        {
            AssertPduSizeForWrite(dataItems);

            var message = new ByteArray();
            var length = S7NetPlusCaller.CreateRequest(message, dataItems);

            var response = await RequestTsduAsync(message.Array, 0, length).ConfigureAwait(false);

            S7NetPlusCaller.ParseResponse(response, response.Length, dataItems);
        }

        /// <summary>
        /// Writes up to 200 bytes to the PLC. You must specify the memory area type, memory are address, byte start address and bytes count.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="value">Bytes to write. The lenght of this parameter can't be higher than 200. If you need more, use recursion.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        private async Task WriteBytesWithASingleRequestAsync(DataType dataType, int db, int startByteAdr, byte[] value, int dataOffset, int count, CancellationToken cancellationToken)
        {
            try
            {
                var dataToSend = BuildWriteBytesPackage(dataType, db, startByteAdr, value, dataOffset, count);
                var s7data = await RequestTsduAsync(dataToSend, cancellationToken).ConfigureAwait(false);

                ValidateResponseCode((ReadWriteErrorCode)s7data[14]);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.WriteData, exc);
            }
        }

        private async Task WriteBitWithASingleRequestAsync(DataType dataType, int db, int startByteAdr, int bitAdr, bool bitValue, CancellationToken cancellationToken)
        {
            try
            {
                var dataToSend = BuildWriteBitPackage(dataType, db, startByteAdr, bitValue, bitAdr);
                var s7data = await RequestTsduAsync(dataToSend, cancellationToken).ConfigureAwait(false);

                ValidateResponseCode((ReadWriteErrorCode)s7data[14]);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.WriteData, exc);
            }
        }

        private Task<byte[]> RequestTsduAsync(byte[] requestData, CancellationToken cancellationToken = default) =>
            RequestTsduAsync(requestData, 0, requestData.Length, cancellationToken);

        private Task<byte[]> RequestTsduAsync(byte[] requestData, int offset, int length, CancellationToken cancellationToken = default)
        {
            var stream = GetStreamIfAvailable();

            return queue.Enqueue(() =>
                NoLockRequestTsduAsync(stream, requestData, offset, length, cancellationToken));
        }

        private async Task<COTP.TPDU> NoLockRequestTpduAsync(Stream stream, byte[] requestData,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                using var closeOnCancellation = cancellationToken.Register(Close);
                await stream.WriteAsync(requestData, 0, requestData.Length, cancellationToken).ConfigureAwait(false);
                return await COTP.TPDU.ReadAsync(stream, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exc)
            {
                if (exc is TPDUInvalidException || exc is TPKTInvalidException)
                {
                    Close();
                }

                throw;
            }
        }

        private async Task<byte[]> NoLockRequestTsduAsync(Stream stream, byte[] requestData, int offset, int length,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                using var closeOnCancellation = cancellationToken.Register(Close);
                await stream.WriteAsync(requestData, offset, length, cancellationToken).ConfigureAwait(false);
                return await COTP.TSDU.ReadAsync(stream, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exc)
            {
                if (exc is TPDUInvalidException || exc is TPKTInvalidException)
                {
                    Close();
                }

                throw;
            }
        }
        #endregion PlcAsynchronous
        #region // PlcSynchronous
        /// <summary>
        /// Connects to the PLC and performs a COTP ConnectionRequest and S7 CommunicationSetup.
        /// </summary>
        public void Open()
        {
            try
            {
                OpenAsync().GetAwaiter().GetResult();
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.ConnectionError,
                    $"Couldn't establish the connection to {IP}.\nMessage: {exc.Message}", exc);
            }
        }


        /// <summary>
        /// Reads a number of bytes from a DB starting from a specified index. This handles more than 200 bytes with multiple requests.
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="count">Byte count, if you want to read 120 bytes, set this to 120.</param>
        /// <returns>Returns the bytes in an array</returns>
        public byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count)
        {
            var result = new byte[count];
            int index = 0;
            while (count > 0)
            {
                //This works up to MaxPDUSize-1 on SNAP7. But not MaxPDUSize-0.
                var maxToRead = Math.Min(count, MaxPDUSize - 18);
                ReadBytesWithSingleRequest(dataType, db, startByteAdr + index, result, index, maxToRead);
                count -= maxToRead;
                index += maxToRead;
            }
            return result;
        }

        /// <summary>
        /// Read and decode a certain number of bytes of the "VarType" provided.
        /// This can be used to read multiple consecutive variables of the same type (Word, DWord, Int, etc).
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="varType">Type of the variable/s that you are reading</param>
        /// <param name="bitAdr">Address of bit. If you want to read DB1.DBX200.6, set 6 to this parameter.</param>
        /// <param name="varCount"></param>
        public object? Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount, byte bitAdr = 0)
        {
            int cntBytes = VarTypeToByteLength(varType, varCount);
            byte[] bytes = ReadBytes(dataType, db, startByteAdr, cntBytes);

            return ParseBytes(varType, bytes, varCount, bitAdr);
        }

        /// <summary>
        /// Reads a single variable from the PLC, takes in input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="variable">Input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.</param>
        /// <returns>Returns an object that contains the value. This object must be cast accordingly. If no data has been read, null will be returned</returns>
        public object? Read(string variable)
        {
            var adr = new PLCAddress(variable);
            return Read(adr.DataType, adr.DbNumber, adr.StartByte, adr.VarType, 1, (byte)adr.BitNumber);
        }

        /// <summary>
        /// Reads all the bytes needed to fill a struct in C#, starting from a certain address, and return an object that can be casted to the struct.
        /// </summary>
        /// <param name="structType">Type of the struct to be readed (es.: TypeOf(MyStruct)).</param>
        /// <param name="db">Address of the DB.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <returns>Returns a struct that must be cast. If no data has been read, null will be returned</returns>
        public object? ReadStruct(Type structType, int db, int startByteAdr = 0)
        {
            int numBytes = Struct.GetStructSize(structType);
            // now read the package
            var resultBytes = ReadBytes(DataType.DataBlock, db, startByteAdr, numBytes);

            // and decode it
            return Struct.FromBytes(structType, resultBytes);
        }

        /// <summary>
        /// Reads all the bytes needed to fill a struct in C#, starting from a certain address, and returns the struct or null if nothing was read.
        /// </summary>
        /// <typeparam name="T">The struct type</typeparam>
        /// <param name="db">Address of the DB.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <returns>Returns a nullable struct. If nothing was read null will be returned.</returns>
        public T? ReadStruct<T>(int db, int startByteAdr = 0) where T : struct
        {
            return ReadStruct(typeof(T), db, startByteAdr) as T?;
        }


        /// <summary>
        /// Reads all the bytes needed to fill a class in C#, starting from a certain address, and set all the properties values to the value that are read from the PLC.
        /// This reads only properties, it doesn't read private variable or public variable without {get;set;} specified.
        /// </summary>
        /// <param name="sourceClass">Instance of the class that will store the values</param>
        /// <param name="db">Index of the DB; es.: 1 is for DB1</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <returns>The number of read bytes</returns>
        public int ReadClass(object sourceClass, int db, int startByteAdr = 0)
        {
            int numBytes = (int)Class.GetClassSize(sourceClass);
            if (numBytes <= 0)
            {
                throw new Exception("The size of the class is less than 1 byte and therefore cannot be read");
            }

            // now read the package
            var resultBytes = ReadBytes(DataType.DataBlock, db, startByteAdr, numBytes);
            // and decode it
            Class.FromBytes(sourceClass, resultBytes);
            return resultBytes.Length;
        }

        /// <summary>
        /// Reads all the bytes needed to fill a class in C#, starting from a certain address, and set all the properties values to the value that are read from the PLC.
        /// This reads only properties, it doesn't read private variable or public variable without {get;set;} specified. To instantiate the class defined by the generic
        /// type, the class needs a default constructor.
        /// </summary>
        /// <typeparam name="T">The class that will be instantiated. Requires a default constructor</typeparam>
        /// <param name="db">Index of the DB; es.: 1 is for DB1</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <returns>An instance of the class with the values read from the PLC. If no data has been read, null will be returned</returns>
        public T? ReadClass<T>(int db, int startByteAdr = 0) where T : class
        {
            return ReadClass(() => Activator.CreateInstance<T>(), db, startByteAdr);
        }

        /// <summary>
        /// Reads all the bytes needed to fill a class in C#, starting from a certain address, and set all the properties values to the value that are read from the PLC.
        /// This reads only properties, it doesn't read private variable or public variable without {get;set;} specified.
        /// </summary>
        /// <typeparam name="T">The class that will be instantiated</typeparam>
        /// <param name="classFactory">Function to instantiate the class</param>
        /// <param name="db">Index of the DB; es.: 1 is for DB1</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <returns>An instance of the class with the values read from the PLC. If no data has been read, null will be returned</returns>
        public T? ReadClass<T>(Func<T> classFactory, int db, int startByteAdr = 0) where T : class
        {
            var instance = classFactory();
            int readBytes = ReadClass(instance, db, startByteAdr);
            if (readBytes <= 0)
            {
                return null;
            }
            return instance;
        }

        /// <summary>
        /// Write a number of bytes from a DB starting from a specified index. This handles more than 200 bytes with multiple requests.
        /// If the write was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to write DB1.DBW200, this is 200.</param>
        /// <param name="value">Bytes to write. If more than 200, multiple requests will be made.</param>
        public void WriteBytes(DataType dataType, int db, int startByteAdr, byte[] value)
        {
            int localIndex = 0;
            int count = value.Length;
            while (count > 0)
            {
                //TODO: Figure out how to use MaxPDUSize here
                //Snap7 seems to choke on PDU sizes above 256 even if snap7
                //replies with bigger PDU size in connection setup.
                var maxToWrite = Math.Min(count, MaxPDUSize - 28);//TODO tested only when the MaxPDUSize is 480
                WriteBytesWithASingleRequest(dataType, db, startByteAdr + localIndex, value, localIndex, maxToWrite);
                count -= maxToWrite;
                localIndex += maxToWrite;
            }
        }

        /// <summary>
        /// Write a single bit from a DB with the specified index.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to write DB1.DBW200, this is 200.</param>
        /// <param name="bitAdr">The address of the bit. (0-7)</param>
        /// <param name="value">Bytes to write. If more than 200, multiple requests will be made.</param>
        public void WriteBit(DataType dataType, int db, int startByteAdr, int bitAdr, bool value)
        {
            if (bitAdr < 0 || bitAdr > 7)
                throw new InvalidAddressException(string.Format("Addressing Error: You can only reference bitwise locations 0-7. Address {0} is invalid", bitAdr));

            WriteBitWithASingleRequest(dataType, db, startByteAdr, bitAdr, value);
        }

        /// <summary>
        /// Write a single bit to a DB with the specified index.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to write DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to write DB1.DBW200, this is 200.</param>
        /// <param name="bitAdr">The address of the bit. (0-7)</param>
        /// <param name="value">Value to write (0 or 1).</param>
        public void WriteBit(DataType dataType, int db, int startByteAdr, int bitAdr, int value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException("Value must be 0 or 1", nameof(value));

            WriteBit(dataType, db, startByteAdr, bitAdr, value == 1);
        }

        /// <summary>
        /// Takes in input an object and tries to parse it to an array of values. This can be used to write many data, all of the same type.
        /// You must specify the memory area type, memory are address, byte start address and bytes count.
        /// If the read was not successful, check LastErrorCode or LastErrorString.
        /// </summary>
        /// <param name="dataType">Data type of the memory area, can be DB, Timer, Counter, Merker(Memory), Input, Output.</param>
        /// <param name="db">Address of the memory area (if you want to read DB1, this is set to 1). This must be set also for other memory area types: counters, timers,etc.</param>
        /// <param name="startByteAdr">Start byte address. If you want to read DB1.DBW200, this is 200.</param>
        /// <param name="value">Bytes to write. The lenght of this parameter can't be higher than 200. If you need more, use recursion.</param>
        /// <param name="bitAdr">The address of the bit. (0-7)</param>
        public void Write(DataType dataType, int db, int startByteAdr, object value, int bitAdr = -1)
        {
            if (bitAdr != -1)
            {
                //Must be writing a bit value as bitAdr is specified
                if (value is bool boolean)
                {
                    WriteBit(dataType, db, startByteAdr, bitAdr, boolean);
                }
                else if (value is int intValue)
                {
                    if (intValue < 0 || intValue > 7)
                        throw new ArgumentOutOfRangeException(
                            string.Format(
                                "Addressing Error: You can only reference bitwise locations 0-7. Address {0} is invalid",
                                bitAdr), nameof(bitAdr));

                    WriteBit(dataType, db, startByteAdr, bitAdr, intValue == 1);
                }
                else
                    throw new ArgumentException("Value must be a bool or an int to write a bit", nameof(value));
            }
            else WriteBytes(dataType, db, startByteAdr, S7NetPlusCaller.SerializeValue(value));
        }

        /// <summary>
        /// Writes a single variable from the PLC, takes in input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.
        /// If the write was not successful, check <see cref="LastErrorCode"/> or <see cref="LastErrorString"/>.
        /// </summary>
        /// <param name="variable">Input strings like "DB1.DBX0.0", "DB20.DBD200", "MB20", "T45", etc.</param>
        /// <param name="value">Value to be written to the PLC</param>
        public void Write(string variable, object value)
        {
            var adr = new PLCAddress(variable);
            Write(adr.DataType, adr.DbNumber, adr.StartByte, value, adr.BitNumber);
        }

        /// <summary>
        /// Writes a C# struct to a DB in the PLC
        /// </summary>
        /// <param name="structValue">The struct to be written</param>
        /// <param name="db">Db address</param>
        /// <param name="startByteAdr">Start bytes on the PLC</param>
        public void WriteStruct(object structValue, int db, int startByteAdr = 0)
        {
            WriteStructAsync(structValue, db, startByteAdr).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Writes a C# class to a DB in the PLC
        /// </summary>
        /// <param name="classValue">The class to be written</param>
        /// <param name="db">Db address</param>
        /// <param name="startByteAdr">Start bytes on the PLC</param>
        public void WriteClass(object classValue, int db, int startByteAdr = 0)
        {
            WriteClassAsync(classValue, db, startByteAdr).GetAwaiter().GetResult();
        }

        private void ReadBytesWithSingleRequest(DataType dataType, int db, int startByteAdr, byte[] buffer, int offset, int count)
        {
            try
            {
                // first create the header
                int packageSize = 19 + 12; // 19 header + 12 for 1 request
                var package = new System.IO.MemoryStream(packageSize);
                BuildHeaderPackage(package);
                // package.Add(0x02);  // datenart
                BuildReadDataRequestPackage(package, dataType, db, startByteAdr, count);

                var dataToSend = package.ToArray();
                var s7data = RequestTsdu(dataToSend);
                AssertReadResponse(s7data, count);

                Array.Copy(s7data, 18, buffer, offset, count);
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.ReadData, exc);
            }
        }

        /// <summary>
        /// Write DataItem(s) to the PLC. Throws an exception if the response is invalid
        /// or when the PLC reports errors for item(s) written.
        /// </summary>
        /// <param name="dataItems">The DataItem(s) to write to the PLC.</param>
        public void Write(params DataItem[] dataItems)
        {
            AssertPduSizeForWrite(dataItems);


            var message = new ByteArray();
            var length = S7NetPlusCaller.CreateRequest(message, dataItems);
            var response = RequestTsdu(message.Array, 0, length);

            S7NetPlusCaller.ParseResponse(response, response.Length, dataItems);
        }

        private void WriteBytesWithASingleRequest(DataType dataType, int db, int startByteAdr, byte[] value, int dataOffset, int count)
        {
            try
            {
                var dataToSend = BuildWriteBytesPackage(dataType, db, startByteAdr, value, dataOffset, count);
                var s7data = RequestTsdu(dataToSend);

                ValidateResponseCode((ReadWriteErrorCode)s7data[14]);
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.WriteData, exc);
            }
        }

        private byte[] BuildWriteBytesPackage(DataType dataType, int db, int startByteAdr, byte[] value, int dataOffset, int count)
        {
            int varCount = count;
            // first create the header
            int packageSize = 35 + varCount;
            var package = new MemoryStream(new byte[packageSize]);

            package.WriteByte(3);
            package.WriteByte(0);
            //complete package size
            package.WriteByteArray(Int.ToByteArray((short)packageSize));
            package.WriteByteArray(new byte[] { 2, 0xf0, 0x80, 0x32, 1, 0, 0 });
            package.WriteByteArray(Word.ToByteArray((ushort)(varCount - 1)));
            package.WriteByteArray(new byte[] { 0, 0x0e });
            package.WriteByteArray(Word.ToByteArray((ushort)(varCount + 4)));
            package.WriteByteArray(new byte[] { 0x05, 0x01, 0x12, 0x0a, 0x10, 0x02 });
            package.WriteByteArray(Word.ToByteArray((ushort)varCount));
            package.WriteByteArray(Word.ToByteArray((ushort)(db)));
            package.WriteByte((byte)dataType);
            var overflow = (int)(startByteAdr * 8 / 0xffffU); // handles words with address bigger than 8191
            package.WriteByte((byte)overflow);
            package.WriteByteArray(Word.ToByteArray((ushort)(startByteAdr * 8)));
            package.WriteByteArray(new byte[] { 0, 4 });
            package.WriteByteArray(Word.ToByteArray((ushort)(varCount * 8)));

            // now join the header and the data
            package.Write(value, dataOffset, count);

            return package.ToArray();
        }

        private byte[] BuildWriteBitPackage(DataType dataType, int db, int startByteAdr, bool bitValue, int bitAdr)
        {
            var value = new[] { bitValue ? (byte)1 : (byte)0 };
            int varCount = 1;
            // first create the header
            int packageSize = 35 + varCount;
            var package = new MemoryStream(new byte[packageSize]);

            package.WriteByte(3);
            package.WriteByte(0);
            //complete package size
            package.WriteByteArray(Int.ToByteArray((short)packageSize));
            package.WriteByteArray(new byte[] { 2, 0xf0, 0x80, 0x32, 1, 0, 0 });
            package.WriteByteArray(Word.ToByteArray((ushort)(varCount - 1)));
            package.WriteByteArray(new byte[] { 0, 0x0e });
            package.WriteByteArray(Word.ToByteArray((ushort)(varCount + 4)));
            package.WriteByteArray(new byte[] { 0x05, 0x01, 0x12, 0x0a, 0x10, 0x01 }); //ending 0x01 is used for writing a sinlge bit
            package.WriteByteArray(Word.ToByteArray((ushort)varCount));
            package.WriteByteArray(Word.ToByteArray((ushort)(db)));
            package.WriteByte((byte)dataType);
            var overflow = (int)(startByteAdr * 8 / 0xffffU); // handles words with address bigger than 8191
            package.WriteByte((byte)overflow);
            package.WriteByteArray(Word.ToByteArray((ushort)(startByteAdr * 8 + bitAdr)));
            package.WriteByteArray(new byte[] { 0, 0x03 }); //ending 0x03 is used for writing a sinlge bit
            package.WriteByteArray(Word.ToByteArray((ushort)(varCount)));

            // now join the header and the data
            package.WriteByteArray(value);

            return package.ToArray();
        }


        private void WriteBitWithASingleRequest(DataType dataType, int db, int startByteAdr, int bitAdr, bool bitValue)
        {
            try
            {
                var dataToSend = BuildWriteBitPackage(dataType, db, startByteAdr, bitValue, bitAdr);
                var s7data = RequestTsdu(dataToSend);

                ValidateResponseCode((ReadWriteErrorCode)s7data[14]);
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.WriteData, exc);
            }
        }

        /// <summary>
        /// Reads multiple vars in a single request.
        /// You have to create and pass a list of DataItems and you obtain in response the same list with the values.
        /// Values are stored in the property "Value" of the dataItem and are already converted.
        /// If you don't want the conversion, just create a dataItem of bytes.
        /// The number of DataItems as well as the total size of the requested data can not exceed a certain limit (protocol restriction).
        /// </summary>
        /// <param name="dataItems">List of dataitems that contains the list of variables that must be read.</param>
        public void ReadMultipleVars(List<DataItem> dataItems)
        {
            AssertPduSizeForRead(dataItems);

            try
            {
                // first create the header
                int packageSize = 19 + (dataItems.Count * 12);
                var package = new System.IO.MemoryStream(packageSize);
                BuildHeaderPackage(package, dataItems.Count);
                // package.Add(0x02);  // datenart
                foreach (var dataItem in dataItems)
                {
                    BuildReadDataRequestPackage(package, dataItem.DataType, dataItem.DB, dataItem.StartByteAdr, VarTypeToByteLength(dataItem.VarType, dataItem.Count));
                }

                var dataToSend = package.ToArray();
                var s7data = RequestTsdu(dataToSend);

                ValidateResponseCode((ReadWriteErrorCode)s7data[14]);

                ParseDataIntoDataItems(s7data, dataItems);
            }
            catch (Exception exc)
            {
                throw new PlcException(ErrorCode.ReadData, exc);
            }
        }

        private byte[] RequestTsdu(byte[] requestData) => RequestTsdu(requestData, 0, requestData.Length);

        private byte[] RequestTsdu(byte[] requestData, int offset, int length)
        {
            return RequestTsduAsync(requestData, offset, length).GetAwaiter().GetResult();
        }
        #endregion PlcSynchronous
        #region // PLCHelpers 帮助内容
        /// <summary>
        /// Creates the header to read bytes from the PLC
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static void BuildHeaderPackage(System.IO.MemoryStream stream, int amount = 1)
        {
            //header size = 19 bytes
            stream.WriteByteArray(new byte[] { 0x03, 0x00 });
            //complete package size
            stream.WriteByteArray(System.Data.NS7NetPlus.Int.ToByteArray((short)(19 + (12 * amount))));
            stream.WriteByteArray(new byte[] { 0x02, 0xf0, 0x80, 0x32, 0x01, 0x00, 0x00, 0x00, 0x00 });
            //data part size
            stream.WriteByteArray(System.Data.NS7NetPlus.Word.ToByteArray((ushort)(2 + (amount * 12))));
            stream.WriteByteArray(new byte[] { 0x00, 0x00, 0x04 });
            //amount of requests
            stream.WriteByte((byte)amount);
        }

        /// <summary>
        /// Create the bytes-package to request data from the PLC. You have to specify the memory type (dataType),
        /// the address of the memory, the address of the byte and the bytes count.
        /// </summary>
        /// <param name="dataType">MemoryType (DB, Timer, Counter, etc.)</param>
        /// <param name="db">Address of the memory to be read</param>
        /// <param name="startByteAdr">Start address of the byte</param>
        /// <param name="count">Number of bytes to be read</param>
        /// <returns></returns>
        private static void BuildReadDataRequestPackage(System.IO.MemoryStream stream, DataType dataType, int db, int startByteAdr, int count = 1)
        {
            //single data req = 12
            stream.WriteByteArray(new byte[] { 0x12, 0x0a, 0x10 });
            switch (dataType)
            {
                case DataType.Timer:
                case DataType.Counter:
                    stream.WriteByte((byte)dataType);
                    break;
                default:
                    stream.WriteByte(0x02);
                    break;
            }

            stream.WriteByteArray(Word.ToByteArray((ushort)(count)));
            stream.WriteByteArray(Word.ToByteArray((ushort)(db)));
            stream.WriteByte((byte)dataType);
            var overflow = (int)(startByteAdr * 8 / 0xffffU); // handles words with address bigger than 8191
            stream.WriteByte((byte)overflow);
            switch (dataType)
            {
                case DataType.Timer:
                case DataType.Counter:
                    stream.WriteByteArray(System.Data.NS7NetPlus.Word.ToByteArray((ushort)(startByteAdr)));
                    break;
                default:
                    stream.WriteByteArray(System.Data.NS7NetPlus.Word.ToByteArray((ushort)((startByteAdr) * 8)));
                    break;
            }
        }

        /// <summary>
        /// Given a S7 variable type (Bool, Word, DWord, etc.), it converts the bytes in the appropriate C# format.
        /// </summary>
        /// <param name="varType"></param>
        /// <param name="bytes"></param>
        /// <param name="varCount"></param>
        /// <param name="bitAdr"></param>
        /// <returns></returns>
        private object? ParseBytes(VarType varType, byte[] bytes, int varCount, byte bitAdr = 0)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            switch (varType)
            {
                case VarType.Byte:
                    if (varCount == 1)
                        return bytes[0];
                    else
                        return bytes;
                case VarType.Word:
                    if (varCount == 1)
                        return Word.FromByteArray(bytes);
                    else
                        return Word.ToArray(bytes);
                case VarType.Int:
                    if (varCount == 1)
                        return Int.FromByteArray(bytes);
                    else
                        return Int.ToArray(bytes);
                case VarType.DWord:
                    if (varCount == 1)
                        return DWord.FromByteArray(bytes);
                    else
                        return DWord.ToArray(bytes);
                case VarType.DInt:
                    if (varCount == 1)
                        return DInt.FromByteArray(bytes);
                    else
                        return DInt.ToArray(bytes);
                case VarType.Real:
                    if (varCount == 1)
                        return System.Data.NS7NetPlus.Real.FromByteArray(bytes);
                    else
                        return System.Data.NS7NetPlus.Real.ToArray(bytes);
                case VarType.LReal:
                    if (varCount == 1)
                        return System.Data.NS7NetPlus.LReal.FromByteArray(bytes);
                    else
                        return System.Data.NS7NetPlus.LReal.ToArray(bytes);

                case VarType.String:
                    return System.Data.NS7NetPlus.String.FromByteArray(bytes);
                case VarType.S7String:
                    return S7String.FromByteArray(bytes);
                case VarType.S7WString:
                    return S7WString.FromByteArray(bytes);

                case VarType.Timer:
                    if (varCount == 1)
                        return Timer.FromByteArray(bytes);
                    else
                        return Timer.ToArray(bytes);
                case VarType.Counter:
                    if (varCount == 1)
                        return Counter.FromByteArray(bytes);
                    else
                        return Counter.ToArray(bytes);
                case VarType.Bit:
                    if (varCount == 1)
                    {
                        if (bitAdr > 7)
                            return null;
                        else
                            return Bit.FromByte(bytes[0], bitAdr);
                    }
                    else
                    {
                        return Bit.ToBitArray(bytes, varCount);
                    }
                case VarType.DateTime:
                    if (varCount == 1)
                    {
                        return DateTime.FromByteArray(bytes);
                    }
                    else
                    {
                        return DateTime.ToArray(bytes);
                    }
                case VarType.DateTimeLong:
                    if (varCount == 1)
                    {
                        return DateTimeLong.FromByteArray(bytes);
                    }
                    else
                    {
                        return DateTimeLong.ToArray(bytes);
                    }
                default:
                    return null;
            }
        }

        /// <summary>
        /// Given a S7 <see cref="VarType"/> (Bool, Word, DWord, etc.), it returns how many bytes to read.
        /// </summary>
        /// <param name="varType"></param>
        /// <param name="varCount"></param>
        /// <returns>Byte lenght of variable</returns>
        internal static int VarTypeToByteLength(VarType varType, int varCount = 1)
        {
            switch (varType)
            {
                case VarType.Bit:
                    return (varCount + 7) / 8;
                case VarType.Byte:
                    return (varCount < 1) ? 1 : varCount;
                case VarType.String:
                    return varCount;
                case VarType.S7String:
                    return ((varCount + 2) & 1) == 1 ? (varCount + 3) : (varCount + 2);
                case VarType.S7WString:
                    return (varCount * 2) + 4;
                case VarType.Word:
                case VarType.Timer:
                case VarType.Int:
                case VarType.Counter:
                    return varCount * 2;
                case VarType.DWord:
                case VarType.DInt:
                case VarType.Real:
                    return varCount * 4;
                case VarType.LReal:
                case VarType.DateTime:
                    return varCount * 8;
                case VarType.DateTimeLong:
                    return varCount * 12;
                default:
                    return 0;
            }
        }

        private byte[] GetS7ConnectionSetup()
        {
            return new byte[] {  3, 0, 0, 25, 2, 240, 128, 50, 1, 0, 0, 255, 255, 0, 8, 0, 0, 240, 0, 0, 3, 0, 3,
                    3, 192 // Use 960 PDU size
            };
        }

        private void ParseDataIntoDataItems(byte[] s7data, List<DataItem> dataItems)
        {
            int offset = 14;
            foreach (var dataItem in dataItems)
            {
                // check for Return Code = Success
                if (s7data[offset] != 0xff)
                    throw new PlcException(ErrorCode.WrongNumberReceivedBytes);

                // to Data bytes
                offset += 4;

                int byteCnt = VarTypeToByteLength(dataItem.VarType, dataItem.Count);
                dataItem.Value = ParseBytes(
                    dataItem.VarType,
                    s7data.Skip(offset).Take(byteCnt).ToArray(),
                    dataItem.Count,
                    dataItem.BitAdr
                );

                // next Item
                offset += byteCnt;

                // Always align to even offset
                if (offset % 2 != 0)
                    offset++;
            }
        }

        private static byte[] BuildReadRequestPackage(IList<DataItemAddress> dataItems)
        {
            int packageSize = 19 + (dataItems.Count * 12);
            var package = new System.IO.MemoryStream(packageSize);

            BuildHeaderPackage(package, dataItems.Count);

            foreach (var dataItem in dataItems)
            {
                BuildReadDataRequestPackage(package, dataItem.DataType, dataItem.DB, dataItem.StartByteAddress, dataItem.ByteLength);
            }

            return package.ToArray();
        }
        #endregion
    }
}
