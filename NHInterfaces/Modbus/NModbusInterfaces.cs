using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NModbus
{
    public interface IConcurrentModbusMaster : IDisposable
    {
        Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints, ushort blockSize = 125, CancellationToken cancellationToken = default(CancellationToken));

        Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints, ushort blockSize = 125, CancellationToken cancellationToken = default(CancellationToken));

        Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data, ushort blockSize = 121, CancellationToken cancellationToken = default(CancellationToken));

        Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort number, CancellationToken cancellationToken = default(CancellationToken));

        Task<bool[]> ReadDiscretesAsync(byte slaveAddress, ushort startAddress, ushort number, CancellationToken cancellationToken = default(CancellationToken));

        Task WriteCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data, CancellationToken cancellationToken = default(CancellationToken));

        Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value, CancellationToken cancellationToken = default(CancellationToken));

        Task WriteSingleRegisterAsync(byte slaveAddress, ushort address, ushort value, CancellationToken cancellationToken = default(CancellationToken));
    }
    public interface IModbusAsciiTransport : IModbusSerialTransport
    {

    }
    /// <summary>
    /// Container for modbus function services.
    /// </summary>
    public interface IModbusFactory
    {
        /// <summary>
        /// Get the service for a given function code.
        /// </summary>
        /// <param name="functionCode"></param>
        /// <returns></returns>
        IModbusFunctionService GetFunctionService(byte functionCode);

        /// <summary>
        /// Gets all of the services.
        /// </summary>
        /// <returns></returns>
        IModbusFunctionService[] GetAllFunctionServices();

        #region Master

        /// <summary>
        /// Create an rtu master.
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        IModbusSerialMaster CreateMaster(IModbusSerialTransport transport);

        /// <summary>
        /// Create a TCP master.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        IModbusMaster CreateMaster(UdpClient client);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        IModbusMaster CreateMaster(TcpClient client);

        #endregion

        #region Slave

        /// <summary>
        /// Creates a Modbus Slave.
        /// </summary>
        /// <param name="unitId">The address of this slave on the Modbus network.</param>
        /// <param name="dataStore">Optionally specify a custom data store for the created slave.</param>
        /// <returns></returns>
        IModbusSlave CreateSlave(byte unitId, ISlaveDataStore dataStore = null);

        #endregion

        #region Slave Networks

        /// <summary>
        /// Creates a slave network based on the RTU transport.
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        IModbusSlaveNetwork CreateSlaveNetwork(IModbusRtuTransport transport);

        /// <summary>
        /// Creates an ascii slave network.
        /// </summary>
        /// <param name="transport">The ascii transport to base this on.</param>
        /// <returns></returns>
        IModbusSlaveNetwork CreateSlaveNetwork(IModbusAsciiTransport transport);

        /// <summary>
        /// Create a slave network based on TCP.
        /// </summary>
        /// <param name="tcpListener"></param>
        /// <returns></returns>
        IModbusSlaveNetwork CreateSlaveNetwork(TcpListener tcpListener);

        /// <summary>
        /// Creates a UDP modbus slave network.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        IModbusSlaveNetwork CreateSlaveNetwork(UdpClient client);

        #endregion

        #region Transport

        /// <summary>
        /// Creates an RTU transpoort. 
        /// </summary>
        /// <param name="streamResource"></param>
        /// <returns></returns>
        IModbusRtuTransport CreateRtuTransport(IStreamResource streamResource);

        /// <summary>
        /// Creates an Ascii Transport.
        /// </summary>
        /// <param name="streamResource"></param>
        /// <returns></returns>
        IModbusAsciiTransport CreateAsciiTransport(IStreamResource streamResource);

        #endregion

        IModbusLogger Logger { get; }
    }
    /// <summary>
    /// A Modbus slave message handler.
    /// </summary>
    public interface IModbusFunctionService
    {
        /// <summary>
        /// The function code that this handles
        /// </summary>
        byte FunctionCode { get; }

        /// <summary>
        /// Creates a message that wrapps the request frame.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        IModbusMessage CreateRequest(byte[] frame);

        /// <summary>
        /// Handle a slave request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="dataStore"></param>
        /// <returns></returns>
        IModbusMessage HandleSlaveRequest(IModbusMessage request, ISlaveDataStore dataStore);

        /// <summary>
        /// Gets the number of bytes to read for a request
        /// </summary>
        /// <param name="frameStart"></param>
        /// <returns></returns>
        int GetRtuRequestBytesToRead(byte[] frameStart);

        /// <summary>
        /// Gets the number of bytes to read for a response.
        /// </summary>
        /// <param name="frameStart"></param>
        /// <returns></returns>
        int GetRtuResponseBytesToRead(byte[] frameStart);
    }
    /// <summary>
    /// Simple logging target. Designed to be easily integrated into other logging frameworks.
    /// </summary>
    public interface IModbusLogger
    {
        /// <summary>
        /// Conditionally log a message
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        void Log(LoggingLevel level, string message);

        /// <summary>
        /// True if this level should be logged, false otherwise.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool ShouldLog(LoggingLevel level);
    }
    /// <summary>
    ///     Modbus master device.
    /// </summary>
    public interface IModbusMaster : IDisposable
    {
        /// <summary>
        ///     Transport used by this master.
        /// </summary>
        IModbusTransport Transport { get; }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <returns>Coils status.</returns>
        bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <returns>Discrete inputs status.</returns>
        bool[] ReadInputs(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<bool[]> ReadInputsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Reads contiguous block of holding registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Holding registers status.</returns>
        ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Reads contiguous block of input registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Input registers status.</returns>
        ushort[] ReadInputRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Writes a single coil value.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value);

        /// <summary>
        ///    Asynchronously writes a single coil value.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value);

        /// <summary>
        ///    Writes a single holding register.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value);

        /// <summary>
        ///    Asynchronously writes a single holding register.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteSingleRegisterAsync(byte slaveAddress, ushort registerAddress, ushort value);

        /// <summary>
        ///    Writes a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data);

        /// <summary>
        ///    Asynchronously writes a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data);

        /// <summary>
        ///    Writes a sequence of coils.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data);

        /// <summary>
        ///    Asynchronously writes a sequence of coils.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteMultipleCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data);

        /// <summary>
        ///    Performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    The write operation is performed before the read.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        ushort[] ReadWriteMultipleRegisters(
            byte slaveAddress,
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData);

        /// <summary>
        ///    Asynchronously performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    The write operation is performed before the read.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<ushort[]> ReadWriteMultipleRegistersAsync(
            byte slaveAddress,
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData);

        /// <summary>
        /// Write a file record to the device.
        /// </summary>
        /// <param name="slaveAdress">Address of device to write values to</param>
        /// <param name="fileNumber">The Extended Memory file number</param>
        /// <param name="startingAddress">The starting register address within the file</param>
        /// <param name="data">The data to be written</param>
        void WriteFileRecord(byte slaveAdress, ushort fileNumber, ushort startingAddress, byte[] data);

        /// <summary>
        ///    Executes the custom message.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request.</param>
        TResponse ExecuteCustomMessage<TResponse>(IModbusMessage request)
            where TResponse : IModbusMessage, new();
    }
    /// <summary>
    ///     A message built by the master (client) that initiates a Modbus transaction.
    /// </summary>
    public interface IModbusMessage
    {
        /// <summary>
        ///     The function code tells the server what kind of action to perform.
        /// </summary>
        byte FunctionCode { get; set; }

        /// <summary>
        ///     Address of the slave (server).
        /// </summary>
        byte SlaveAddress { get; set; }

        /// <summary>
        ///     Composition of the slave address and protocol data unit.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        byte[] MessageFrame { get; }

        /// <summary>
        ///     Composition of the function code and message data.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        byte[] ProtocolDataUnit { get; }

        /// <summary>
        ///     A unique identifier assigned to a message when using the IP protocol.
        /// </summary>
        ushort TransactionId { get; set; }

        /// <summary>
        ///     Initializes a modbus message from the specified message frame.
        /// </summary>
        /// <param name="frame">Bytes of Modbus frame.</param>
        void Initialize(byte[] frame);
    }
    public interface IModbusRtuTransport : IModbusSerialTransport
    {

    }
    /// <summary>
    ///     Modbus Serial Master device.
    /// </summary>
    public interface IModbusSerialMaster : IModbusMaster
    {
        /// <summary>
        ///     Transport for used by this master.
        /// </summary>
        new IModbusSerialTransport Transport { get; }

        /// <summary>
        ///     Serial Line only.
        ///     Diagnostic function which loops back the original data.
        ///     NModbus only supports looping back one ushort value, this is a
        ///     limitation of the "Best Effort" implementation of the RTU protocol.
        /// </summary>
        /// <param name="slaveAddress">Address of device to test.</param>
        /// <param name="data">Data to return.</param>
        /// <returns>Return true if slave device echoed data.</returns>
        bool ReturnQueryData(byte slaveAddress, ushort data);
    }
    public interface IModbusSerialTransport : IModbusTransport
    {
        void DiscardInBuffer();

        bool CheckFrame { get; set; }

        bool ChecksumsMatch(IModbusMessage message, byte[] messageFrame);

        void IgnoreResponse();
    }
    /// <summary>
    /// A modbus slave.
    /// </summary>
    public interface IModbusSlave
    {
        /// <summary>
        /// Gets the unit id of this slave.
        /// </summary>
        byte UnitId { get; }

        /// <summary>
        /// Gets the data store for this slave.
        /// </summary>
        ISlaveDataStore DataStore { get; }

        /// <summary>
        /// Applies the request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IModbusMessage ApplyRequest(IModbusMessage request);
    }
    /// <summary>
    /// A network of slave devices on a single transport.
    /// </summary>
    public interface IModbusSlaveNetwork : IDisposable
    {
        /// <summary>
        /// Listen for incoming requests.
        /// </summary>
        /// <returns></returns>
        Task ListenAsync(CancellationToken cancellationToken = new CancellationToken());

        /// <summary>
        /// Add a slave to the network.
        /// </summary>
        /// <param name="slave"></param>
        void AddSlave(IModbusSlave slave);

        /// <summary>
        /// Get a slave from the network.
        /// </summary>
        /// <param name="unitId">The slave address</param>
        /// <returns>The specified slave, or null if one can't be found.</returns>
        IModbusSlave GetSlave(byte unitId);

        /// <summary>
        /// Removes a slave from the network.
        /// </summary>
        /// <param name="unitId"></param>
        void RemoveSlave(byte unitId);
    }
    public interface IModbusTransport : IDisposable
    {
        int Retries { get; set; }

        uint RetryOnOldResponseThreshold { get; set; }

        bool SlaveBusyUsesRetryCount { get; set; }

        int WaitToRetryMilliseconds { get; set; }

        int ReadTimeout { get; set; }

        int WriteTimeout { get; set; }

        T UnicastMessage<T>(IModbusMessage message) where T : IModbusMessage, new();

        byte[] ReadRequest();

        byte[] BuildMessageFrame(IModbusMessage message);

        void Write(IModbusMessage message);

        IStreamResource StreamResource { get; }
    }
    /// <summary>
    /// Represents a memory map.
    /// </summary>
    /// <typeparam name="TPoint"></typeparam>
    public interface IPointSource<TPoint>
    {
        /// <summary>
        /// Read a series of points.
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="numberOfPoints"></param>
        /// <returns></returns>
        TPoint[] ReadPoints(ushort startAddress, ushort numberOfPoints);

        /// <summary>
        /// Write a series of points.
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="points"></param>
        void WritePoints(ushort startAddress, TPoint[] points);
    }
    /// <summary>
    /// Object simulation of a device memory map.
    /// </summary>
    public interface ISlaveDataStore
    {
        /// <summary>
        /// Gets the descrete coils.
        /// </summary>
        IPointSource<bool> CoilDiscretes { get; }

        /// <summary>
        /// Gets the discrete inputs.
        /// </summary>
        IPointSource<bool> CoilInputs { get; }

        /// <summary>
        /// Gets the holding registers.
        /// </summary>
        IPointSource<ushort> HoldingRegisters { get; }

        /// <summary>
        /// Gets the input registers.
        /// </summary>
        IPointSource<ushort> InputRegisters { get; }
    }
    public interface ISlaveHandlerContext
    {
        IModbusFunctionService GetHandler(byte functionCode);
    }
    /// <summary>
    /// Following the guidelines from https://github.com/aspnet/Logging/wiki/Guidelines.
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// The most detailed log messages, may contain sensitive application data. These messages should be disabled by default and should never be enabled in a production environment.
        /// </summary>
        Trace = 0,

        /// <summary>
        /// Logs that are used for interactive investigation during development should use the Debug level. These logs should primarily contain information useful for debugging and have no long-term value. 
        /// This is the default most verbose level of logging.
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Track the general flow of the application using logs at the Information level. These logs should have value in the long term.
        /// </summary>
        Information = 2,

        /// <summary>
        /// Warnings should highlight an abnormal or unexpected event in the application flow. This event does not cause the application execution to stop, but can signify sub-optimal performance or a potential problem for the future. A common place to log a warning is from handled exceptions. 
        /// </summary>
        Warning = 3,

        /// <summary>
        /// An error should be logged when the current flow of execution is stopped due to a failure. These should indicate a failure in the current activity, not an application-wide failure. These will mainly be unhandled exceptions and recoverable failures. 
        /// </summary>
        Error = 4,

        /// <summary>
        /// A critical log should describe an unrecoverable application or system crash, or a catastrophic failure that requires immediate attention. 
        /// </summary>
        Critical = 5
    }
}
