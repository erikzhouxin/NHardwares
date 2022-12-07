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
            ControlType = type;
        }
        public IAlertMsg Reconnect()
        {
            return _proxy.Reconnect();
        }

        public IAlertMsg Connect(IPAddress address, int port)
        {
            switch (ControlType)
            {
                case IOControlType.USR_IO808_EWR: return (_proxy ??= new UsrIO808EWRDevice()).Connect(address, port);
                default: return new AlertMsg(false, "不支持的设备类型");
            }
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
    }
    internal class UsrIO808EWRDevice : IUsrIOControlProxy
    {
        private IModbusMaster _modbus;
        private Socket _socket;
        private string _address;
        private Int32 _portRate;
        private byte _slaveId = 0x11;
        public IOControlType ControlType => IOControlType.USR_IO808_EWR;
        public string Address => _address;
        public int PortRate => _portRate;
        public UsrIO808EWRDevice()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _modbus = new ModbusFactory().CreateMaster(_socket);
        }
        public IAlertMsg Reconnect()
        {
            try
            {
                _socket.Disconnect(true);
            }
            catch { }
            try
            {
                _socket.Connect(new IPEndPoint(GetIPAddress(), _portRate));
                return new AlertMsg(true, "连接成功");
            }
            catch (Exception ex)
            {
                return new AlertException(ex);
            }
        }
        private IPAddress GetIPAddress()
        {
            if (IPAddress.TryParse(_address, out var ipAddress))
            {
                return ipAddress;
            }
            return IPAddress.Loopback;
        }
        public IAlertMsg Connect(IPAddress address, int port)
        {
            _address = address?.ToString();
            _portRate = port;
            return Reconnect();
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            _socket.Dispose();
            _socket = null;
            _modbus.Dispose();
            _modbus = null;
        }
        public IAlertMsg<bool> GetDOStatus(int num)
        {
            var res = _modbus.ReadCoils(_slaveId, (ushort)num, 1);
            if (res == null || res.Length != 1)
            {
                return new AlertMsg<bool>(false, $"未查询到{_slaveId}主从机的第{num + 1}路输出信号的状态");
            }
            return new AlertMsg<bool>(true, $"查询到{_slaveId}主从机的第{num + 1}路输出信号的状态为【{(res[0] ? "开" : "关")}】") { Data = res[0] };
        }
        public IAlertMsg<bool> SetDOStatus(int num, bool value)
        {
            _modbus.WriteSingleCoil(_slaveId, (ushort)num, value);
            return GetDOStatus(num);
        }
        public IAlertMsg<bool> GetDIStatus(int num)
        {
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
    }

}
