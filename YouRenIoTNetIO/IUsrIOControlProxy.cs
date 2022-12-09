using System;
using System.Collections.Generic;
using System.Data.HardwareInterfaces;
using System.Data.NModbus;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace System.Data.YouRenIoTNetIO
{
    /// <summary>
    /// IO控制器代理
    /// </summary>
    public interface IUsrIOControlProxy : IDisposable
    {
        /// <summary>
        /// 控制器类型
        /// </summary>
        IOControlType ControlType { get; }
        /// <summary>
        /// 地址
        /// </summary>
        String Address { get; }
        /// <summary>
        /// 端口号
        /// </summary>
        Int32 PortRate { get; }
        /// <summary>
        /// 设置寄存器地址
        /// </summary>
        /// <param name="address"></param>
        void SetSlave(byte address);
        /// <summary>
        /// 重新连接
        /// </summary>
        /// <returns></returns>
        IAlertMsg Reconnect();
        /// <summary>
        /// 获取连接状态
        /// </summary>
        /// <returns></returns>
        IAlertMsg GetConnectStatus();
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        IAlertMsg Disconnect();
        /// <summary>
        /// 连接并设置
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        IAlertMsg Connect(IPAddress address, int port);
        /// <summary>
        /// 获取序号状态
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        IAlertMsg<bool> GetDOStatus(int num);
        /// <summary>
        /// 设置序号状态
        /// </summary>
        /// <param name="num"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAlertMsg<bool> SetDOStatus(int num, bool value);
        /// <summary>
        /// 获取序号状态
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        IAlertMsg<bool> GetDIStatus(int num);
    }
    /// <summary>
    /// IO控制器代理实现类
    /// </summary>
    internal class UsrIOControlProxy : IUsrIOControlProxy
    {
        IUsrIOControlProxy _proxy;
        public IOControlType ControlType { get; }
        public string Address => _proxy?.Address;
        public int PortRate => _proxy?.PortRate ?? 0;
        public UsrIOControlProxy(IOControlType type)
        {
            switch (ControlType = type)
            {
                case IOControlType.USR_IO808_EWR: _proxy = new UsrIO808Device(); break;
                default: throw new NotSupportedException("不支持的设备类型");
            }
        }
        public IAlertMsg Reconnect()
        {
            return _proxy.Reconnect();
        }

        public IAlertMsg Connect(IPAddress address, int port)
        {
            return _proxy.Connect(address, port);
        }
        public void Dispose()
        {
            _proxy?.Dispose();
        }
        public IAlertMsg<bool> GetDOStatus(int num)
        {
            return _proxy.GetDOStatus(num);
        }
        public IAlertMsg<bool> SetDOStatus(int num, bool value)
        {
            return _proxy.SetDOStatus(num, value);
        }
        public IAlertMsg<bool> GetDIStatus(int num)
        {
            return _proxy.GetDIStatus(num);
        }
        public void SetSlave(byte address)
        {
            _proxy.SetSlave(address);
        }

        public IAlertMsg GetConnectStatus()
        {
            return _proxy.GetConnectStatus();
        }

        public IAlertMsg Disconnect()
        {
            return _proxy.Disconnect();
        }
    }
    internal class UsrIO808Device : IUsrIOControlProxy
    {
        private IModbusMaster _modbus;
        private Socket _socket;
        private IPAddress _address;
        private Int32 _portRate;
        private byte _slaveId = 0x11;
        public IOControlType ControlType => IOControlType.USR_IO808_EWR;
        public string Address => _address.ToString();
        public int PortRate => _portRate;
        public UsrIO808Device()
        {
            _address = IPAddress.Loopback;
            _portRate = 80;
        }
        public IAlertMsg Reconnect()
        {
            Disconnect();
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Connect(new IPEndPoint(_address, _portRate));
                _modbus = new ModbusFactory().CreateMaster(_socket);
                return new AlertMsg(true, "连接成功");
            }
            catch (Exception ex)
            {
                return new AlertException(ex);
            }
        }
        public IAlertMsg Connect(IPAddress address, int port)
        {
            if (_address == address && port == _portRate)
            {
                var status = GetConnectStatus();
                if (status.IsSuccess)
                {
                    return status;
                }
            }
            _address = address;
            _portRate = port;
            return Reconnect();
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            Disconnect();
        }
        public IAlertMsg<bool> GetDOStatus(int num)
        {
            if (_modbus == null)
            {
                return new AlertMsg<bool>(false, $"未连接到【{_address}:{_portRate}】");
            }
            var res = _modbus.ReadCoils(_slaveId, (ushort)num, 1);
            if (res == null || res.Length != 1)
            {
                return new AlertMsg<bool>(false, $"未查询到{_slaveId}主从机的第{num + 1}路输出信号的状态");
            }
            return new AlertMsg<bool>(true, $"查询到{_slaveId}主从机的第{num + 1}路输出信号的状态为【{(res[0] ? "开" : "关")}】") { Data = res[0] };
        }
        public IAlertMsg<bool> SetDOStatus(int num, bool value)
        {
            if (_modbus == null)
            {
                return new AlertMsg<bool>(false, $"未连接到【{_address}:{_portRate}】");
            }
            _modbus.WriteSingleCoil(_slaveId, (ushort)num, value);
            return GetDOStatus(num);
        }
        public IAlertMsg<bool> GetDIStatus(int num)
        {
            if (_modbus == null)
            {
                return new AlertMsg<bool>(false, $"未连接到【{_address}:{_portRate}】");
            }
            var res = _modbus.ReadInputs(_slaveId, (ushort)(num + 0x20), 1);
            if (res == null || res.Length != 1)
            {
                return new AlertMsg<bool>(false, $"未查询到{_slaveId}主从机的第{num + 1}路输入信号的状态");
            }
            return new AlertMsg<bool>(true, $"查询到{_slaveId}主从机的第{num + 1}路输入信号的状态为【{(res[0] ? "开" : "关")}】") { Data = res[0] };
        }
        public void SetSlave(byte address)
        {
            _slaveId = address;
        }

        public IAlertMsg GetConnectStatus()
        {
            if (_socket == null)
            {
                return new AlertMsg(false, $"已释放【{_address}:{_portRate}】的连接");
            }
            var isConnect = _socket.Connected && (_socket.Available != 0 || !_socket.Poll(1000, SelectMode.SelectRead));
            return isConnect ? new AlertMsg(true, $"已打开【{_address}:{_portRate}】的连接") : (IAlertMsg)new AlertMsg(false, $"已关闭【{_address}:{_portRate}】的连接");
        }

        public IAlertMsg Disconnect()
        {
            try
            {
                _socket?.Disconnect(false);
            }
            catch { }
            try
            {
                _socket?.Dispose();
            }
            finally
            {
                _socket = null;
            }
            try
            {
                _modbus?.Dispose();
            }
            finally
            {
                _modbus = null;
            }
            return new AlertMsg(true, $"已关闭【{_address}:{_portRate}】的连接");
        }
    }

}
