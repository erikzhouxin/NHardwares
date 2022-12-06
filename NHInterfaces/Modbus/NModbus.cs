using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Data.NModbus
{
    /// <summary>
    /// Extension methods for the IModbusFactory interface.
    /// </summary>
    public static class FactoryExtensions
    {
        /// <summary>
        /// Creates an RTU master.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <returns></returns>
        public static IModbusSerialMaster CreateRtuMaster(this IModbusFactory factory, IStreamResource streamResource)
        {
            IModbusRtuTransport transport = factory.CreateRtuTransport(streamResource);

            return new ModbusSerialMaster(transport);
        }

        /// <summary>
        /// Creates an ASCII master.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <returns></returns>
        public static IModbusSerialMaster CreateAsciiMaster(this IModbusFactory factory, IStreamResource streamResource)
        {
            IModbusAsciiTransport transport = factory.CreateAsciiTransport(streamResource);

            return new ModbusSerialMaster(transport);
        }

        /// <summary>
        /// Creates an RTU slave network.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <returns></returns>
        public static IModbusSlaveNetwork CreateRtuSlaveNetwork(this IModbusFactory factory,
            IStreamResource streamResource)
        {
            IModbusRtuTransport transport = factory.CreateRtuTransport(streamResource);

            return factory.CreateSlaveNetwork(transport);
        }

        /// <summary>
        /// Creates an ASCII slave network.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <returns></returns>
        public static IModbusSlaveNetwork CreateAsciiSlaveNetwork(this IModbusFactory factory,
            IStreamResource streamResource)
        {
            IModbusAsciiTransport transport = factory.CreateAsciiTransport(streamResource);

            return factory.CreateSlaveNetwork(transport);
        }

    }
    /// <summary>
    ///     An exception that provides the exception code that will be sent in response to an invalid Modbus request.
    /// </summary>
#if NET45 || NET40
    [Serializable]
#endif
    public class InvalidModbusRequestException : Exception
    {
        private readonly byte _exceptionCode;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidModbusRequestException" /> class with a specified Modbus exception code.
        /// </summary>
        /// <param name="exceptionCode">The Modbus exception code to provide to the slave.</param>
        public InvalidModbusRequestException(byte exceptionCode)
            : this(GetMessage(exceptionCode), exceptionCode)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidModbusRequestException" /> class with a specified error message and Modbus exception code.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="exceptionCode">The Modbus exception code to provide to the slave.</param>
        public InvalidModbusRequestException(string message, byte exceptionCode)
            : this(message, exceptionCode, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidModbusRequestException" /> class with a specified Modbus exception code and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="exceptionCode">The Modbus exception code to provide to the slave.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public InvalidModbusRequestException(byte exceptionCode, Exception innerException)
            : this(GetMessage(exceptionCode), exceptionCode, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidModbusRequestException" /> class with a specified Modbus exception code and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="exceptionCode">The Modbus exception code to provide to the slave.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public InvalidModbusRequestException(string message, byte exceptionCode, Exception innerException)
            : base(message, innerException)
        {
            _exceptionCode = exceptionCode;
        }

#if NET45 || NET40
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidModbusRequestException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected InvalidModbusRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _exceptionCode = info.GetByte(nameof(ExceptionCode));
        }
#endif

        /// <summary>
        ///     Gets the Modbus exception code to provide to the slave.
        /// </summary>
        public byte ExceptionCode => _exceptionCode;

#if NET45 || NET40
        /// <summary>Sets the <see cref="SerializationInfo" /> object with the Modbus exception code and additional exception information.</summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ExceptionCode", this._exceptionCode, typeof(byte));
        }
#endif

        private static string GetMessage(byte exceptionCode)
        {
            return $"Modbus exception code {exceptionCode}.";
        }
    }
    /// <summary>
    ///     Defines constants related to the Modbus protocol.
    /// </summary>
    internal static class Modbus
    {
        public const int MaximumDiscreteRequestResponseSize = 2040;
        public const int MaximumRegisterRequestResponseSize = 127;

        // modbus slave exception offset that is added to the function code, to flag an exception
        public const byte ExceptionOffset = 128;

        // default setting for number of retries for IO operations
        public const int DefaultRetries = 3;

        // default number of milliseconds to wait after encountering an ACKNOWLEGE or SLAVE DEVIC BUSY slave exception response.
        public const int DefaultWaitToRetryMilliseconds = 250;

        // default setting for IO timeouts in milliseconds
        //public const int DefaultTimeout = 1000;


        public const ushort CoilOn = 0xFF00;
        public const ushort CoilOff = 0x0000;

        // IP slaves should be addressed by IP
        public const byte DefaultIpSlaveUnitId = 0;

        //// An existing connection was forcibly closed by the remote host
        //public const int ConnectionResetByPeer = 10054;

        // Existing socket connection is being closed
        //public const int WSACancelBlockingCall = 10004;

        // used by the ASCII tranport to indicate end of message
        public const string NewLine = "\r\n";
    }
    /// <summary>
    /// Modbus工厂
    /// </summary>
    public class ModbusFactory : IModbusFactory
    {
        /// <summary>
        /// The "built-in" message handlers.
        /// </summary>
        private static readonly IModbusFunctionService[] BuiltInFunctionServices =
        {
            new ReadCoilsService(),
            new ReadInputsService(),
            new ReadHoldingRegistersService(),
            new ReadInputRegistersService(),
            new DiagnosticsService(),
            new WriteSingleCoilService(),
            new WriteSingleRegisterService(),
            new WriteMultipleCoilsService(),
            new WriteMultipleRegistersService(),
            new WriteFileRecordService(),
            new ReadWriteMultipleRegistersService(),
        };

        private readonly IDictionary<byte, IModbusFunctionService> _functionServices;

        /// <summary>
        /// Create a factory which uses the built in standard slave function handlers.
        /// </summary>
        public ModbusFactory()
        {
            _functionServices = BuiltInFunctionServices.ToDictionary(s => s.FunctionCode, s => s);

            Logger = NullModbusLogger.Instance;
        }

        /// <summary>
        /// Create a factory which optionally uses the built in function services and allows custom services to be added.
        /// </summary>
        /// <param name="functionServices">User provided function services.</param>
        /// <param name="includeBuiltIn">If true, the built in function services are included. Otherwise, all function services will come from the functionService parameter.</param>
        /// <param name="logger">Logger</param>
        public ModbusFactory(
            IEnumerable<IModbusFunctionService> functionServices = null,
            bool includeBuiltIn = true,
            IModbusLogger logger = null)
        {
            Logger = logger ?? NullModbusLogger.Instance;

            //Determine if we're including the built in services
            if (includeBuiltIn)
            {
                //Make a dictionary out of the built in services
                _functionServices = BuiltInFunctionServices
                    .ToDictionary(s => s.FunctionCode, s => s);
            }
            else
            {
                //Create an empty dictionary
                _functionServices = new Dictionary<byte, IModbusFunctionService>();
            }

            if (functionServices != null)
            {
                //Add and replace the provided function services as necessary.
                foreach (IModbusFunctionService service in functionServices)
                {
                    //This will add or replace the service.
                    _functionServices[service.FunctionCode] = service;
                }
            }
        }

        public IModbusSlave CreateSlave(byte unitId, ISlaveDataStore dataStore = null)
        {
            if (dataStore == null)
                dataStore = new DefaultSlaveDataStore();

            return new ModbusSlave(unitId, dataStore, GetAllFunctionServices());
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(IModbusRtuTransport transport)
        {
            return new ModbusSerialSlaveNetwork(transport, this, Logger);
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(IModbusAsciiTransport transport)
        {
            return new ModbusSerialSlaveNetwork(transport, this, Logger);
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(TcpListener tcpListener)
        {
            return new ModbusTcpSlaveNetwork(tcpListener, this, Logger);
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(UdpClient client)
        {
            return new ModbusUdpSlaveNetwork(client, this, Logger);
        }

        public IModbusRtuTransport CreateRtuTransport(IStreamResource streamResource)
        {
            return new ModbusRtuTransport(streamResource, this, Logger);
        }

        public IModbusAsciiTransport CreateAsciiTransport(IStreamResource streamResource)
        {
            return new ModbusAsciiTransport(streamResource, this, Logger);
        }

        public IModbusLogger Logger { get; }

        public IModbusFunctionService[] GetAllFunctionServices()
        {
            return _functionServices
                .Values
                .ToArray();
        }

        public IModbusSerialMaster CreateMaster(IModbusSerialTransport transport)
        {
            return new ModbusSerialMaster(transport);
        }

        public IModbusMaster CreateMaster(UdpClient client)
        {
            var adapter = new UdpClientAdapter(client);

            var transport = new ModbusIpTransport(adapter, this, Logger);

            return new ModbusIpMaster(transport);
        }

        public IModbusMaster CreateMaster(TcpClient client)
        {
            var adapter = new TcpClientAdapter(client);

            var transport = new ModbusIpTransport(adapter, this, Logger);

            return new ModbusIpMaster(transport);
        }

        public IModbusMaster CreateMaster(Socket client)
        {
            var adapter = new SocketAdapter(client);

            var transport = new ModbusRtuTransport(adapter, this, Logger);

            return new ModbusSerialMaster(transport);
        }

        public IModbusFunctionService GetFunctionService(byte functionCode)
        {
            return _functionServices.GetValueOrDefault(functionCode);
        }
    }
    /// <summary>
    /// Supported function codes
    /// </summary>
    public static class ModbusFunctionCodes
    {
        public const byte ReadCoils = 1;

        public const byte ReadInputs = 2;

        public const byte ReadHoldingRegisters = 3;

        public const byte ReadInputRegisters = 4;

        public const byte WriteSingleCoil = 5;

        public const byte WriteSingleRegister = 6;

        public const byte Diagnostics = 8;

        public const ushort DiagnosticsReturnQueryData = 0;

        public const byte WriteMultipleCoils = 15;

        public const byte WriteMultipleRegisters = 16;

        public const byte WriteFileRecord = 21;

        public const byte ReadWriteMultipleRegisters = 23;
    }
    /// <summary>
    ///     Represents slave errors that occur during communication.
    /// </summary>
#if NET45 || NET40
    [Serializable]
#endif
    public class SlaveException : Exception
    {
        private const string SlaveAddressPropertyName = "SlaveAdress";
        private const string FunctionCodePropertyName = "FunctionCode";
        private const string SlaveExceptionCodePropertyName = "SlaveExceptionCode";

        private readonly SlaveExceptionResponse _slaveExceptionResponse;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SlaveException" /> class.
        /// </summary>
        public SlaveException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SlaveException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public SlaveException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SlaveException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public SlaveException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        internal SlaveException(SlaveExceptionResponse slaveExceptionResponse)
        {
            _slaveExceptionResponse = slaveExceptionResponse;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
        internal SlaveException(string message, SlaveExceptionResponse slaveExceptionResponse)
            : base(message)
        {
            _slaveExceptionResponse = slaveExceptionResponse;
        }

#if NET45 || NET40
        /// <summary>
        ///     Initializes a new instance of the <see cref="SlaveException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        ///     The class name is null or
        ///     <see cref="P:System.Exception.HResult"></see> is zero (0).
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
        protected SlaveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                _slaveExceptionResponse = new SlaveExceptionResponse(
                    info.GetByte(SlaveAddressPropertyName),
                    info.GetByte(FunctionCodePropertyName),
                    info.GetByte(SlaveExceptionCodePropertyName));
            }
        }
#endif

        /// <summary>
        ///     Gets a message that describes the current exception.
        /// </summary>
        /// <value>
        ///     The error message that explains the reason for the exception, or an empty string.
        /// </value>
        public override string Message
        {
            get
            {
                string responseString;
                responseString = _slaveExceptionResponse != null ? string.Concat(Environment.NewLine, _slaveExceptionResponse) : string.Empty;
                return string.Concat(base.Message, responseString);
            }
        }

        /// <summary>
        ///     Gets the response function code that caused the exception to occur, or 0.
        /// </summary>
        /// <value>The function code.</value>
        public byte FunctionCode => _slaveExceptionResponse != null ? _slaveExceptionResponse.FunctionCode : (byte)0;

        /// <summary>
        ///     Gets the slave exception code, or 0.
        /// </summary>
        /// <value>The slave exception code.</value>
        public byte SlaveExceptionCode => _slaveExceptionResponse != null ? _slaveExceptionResponse.SlaveExceptionCode : (byte)0;

        /// <summary>
        ///     Gets the slave address, or 0.
        /// </summary>
        /// <value>The slave address.</value>
        public byte SlaveAddress => _slaveExceptionResponse != null ? _slaveExceptionResponse.SlaveAddress : (byte)0;

#if NET46
        /// <summary>
        ///     When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see>
        ///     with information about the exception.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is a null reference (Nothing in Visual Basic). </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Argument info is validated, rule does not understand AND condition.")]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null && _slaveExceptionResponse != null)
            {
                info.AddValue(SlaveAddressPropertyName, _slaveExceptionResponse.SlaveAddress);
                info.AddValue(FunctionCodePropertyName, _slaveExceptionResponse.FunctionCode);
                info.AddValue(SlaveExceptionCodePropertyName, _slaveExceptionResponse.SlaveExceptionCode);
            }
        }
#endif
    }
    /// <summary>
    ///  Modbus slave exception codes
    /// </summary>
    public static class SlaveExceptionCodes
    {
        /// <summary>
        /// The function code received in the query is not an allowable action for the slave.  This may be because the function code is only applicable to newer devices, and was not implemented in the unit selected.  It could also indicate that the slave is in the wrong state to process a request of this type, for example because it is unconfigured and is being asked to return register values. If a Poll Program Complete command was issued, this code indicates that no program function preceded it.
        /// </summary>
        public const byte IllegalFunction = 1;

        /// <summary>
        /// The data address received in the query is not an allowable address for the slave. More specifically, the combination of reference number and transfer length is invalid. For a controller with 100 registers, a request with offset 96 and length 4 would succeed, a request with offset 96 and length 5 will generate exception 02.
        /// </summary>
        public const byte IllegalDataAddress = 2;

        /// <summary>
        /// A value contained in the query data field is not an allowable value for the slave.  This indicates a fault in the structure of remainder of a complex request, such as that the implied length is incorrect. It specifically does NOT mean that a data item submitted for storage in a register has a value outside the expectation of the application program, since the MODBUS protocol is unaware of the significance of any particular value of any particular register.
        /// </summary>
        public const byte IllegalDataValue = 3;

        /// <summary>
        /// An unrecoverable error occurred while the slave was attempting to perform the requested action.
        /// </summary>
        public const byte SlaveDeviceFailure = 4;

        /// <summary>
        /// Specialized use in conjunction with programming commands.
        /// 
        /// The slave has accepted the request and is processing it, but a long duration of time will be required to do so.T
        /// his response is returned to prevent a timeout error from occurring in the master.The master can next issue a 
        /// Poll Program Complete message to determine if processing is completed.
        /// </summary>
        public const byte Acknowledge = 5;

        /// <summary>
        /// Specialized use in conjunction with programming commands.
        /// The slave is engaged in processing a long-duration program command.The master should retransmit 
        /// the message later when the slave is free.
        /// </summary>
        public const byte SlaveDeviceBusy = 6;
    }
}
