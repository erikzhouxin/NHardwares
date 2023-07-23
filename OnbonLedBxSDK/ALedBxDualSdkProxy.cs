using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// BX-5/BX-6系列SDK代理
    /// </summary>
    public interface ILedBxDualSdkProxy
    {
        /// <summary>
        /// windows平台需要初始化SDK（默认如果没有初始化会自动初始化）
        /// </summary>
        /// <returns></returns>
        int BxDual_InitSdk();
        /// <summary>
        /// 释放SDK
        /// </summary>
        void BxDual_ReleaseSdk();
        /// <summary>
        /// 设置目标地址，即设置屏号/设置屏地址/设置控制器的屏号
        /// </summary>
        /// <param name="usDstAddr">2个字节长度，默认值0xfffe 为地址通配符</param>
        /// <returns></returns>
        int BxDual_set_screenNum_G56(ushort usDstAddr);
        /// <summary>
        /// 用于设置控制各种通讯方式每一包最大长度
        /// 注：5E，6E，6Q系列最大数据长途64K（建议最大不要超过63*1024） 其他系列最大长度1K（1204）
        /// </summary>
        /// <param name="packetLen">数据包长度</param>
        /// <returns></returns>
        int BxDual_set_packetLen(ushort packetLen);
        /// <summary>
        /// 搜索控制器命令
        /// </summary>
        /// <param name="retData">请参考结构体Ping_data 所有回读参数都会通过结构体回调</param>
        /// <returns></returns>
        int BxDual_cmd_searchController(ref Ping_data retData);
        /// <summary>
        /// 搜索控制器命令-串口
        /// </summary>
        /// <param name="retData">请参考结构体Ping_data 所有回读参数都会通过结构体回调</param>
        /// <param name="uartPort">串口号</param>
        /// <returns></returns>
        int BxDual_cmd_uart_searchController(ref Ping_data retData, byte[] uartPort);
        /// <summary>
        ///  网络搜索命令，返回：温度传感器，空气，PM2.5等信息，
        ///  详见 NetSearchCmdRet:参考结构体声明中的注释；
        ///  针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="retData">NetSearchCmdRet:参考结构体声明中的注释；</param>
        /// <param name="uartPort">串口号,如："COM3"</param>
        /// <param name="nBaudRateType">1：9600;   2：57600;</param>
        /// <returns></returns>
        int BxDual_cmd_uart_search_Net_6G(ref NetSearchCmdRet retData, byte[] uartPort, ushort nBaudRateType);
        /// <summary>
        /// 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，
        /// 详见 NetSearchCmdRet:参考结构体声明中的注释；
        /// 针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="retData">NetSearchCmdRet:参考结构体声明中的注释</param>
        /// <param name="uartPort">串口号,如："COM3"</param>
        /// <param name="nBaudRateType">1：9600;   2：57600;</param>
        /// <returns></returns>
        int BxDual_cmd_uart_search_Net_6G_Web(ref NetSearchCmdRet_Web retData, byte[] uartPort, ushort nBaudRateType);
        /// <summary>
        /// 文件系统格式化
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsFormat(byte[] uartPort, byte baudRate);
        /// <summary>
        /// 开始批量写文件
        /// 发送节目前调用
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsStartFileTransf(byte[] uartPort, byte baudRate);
        /// <summary>
        /// 写文件结束
        /// 发送节目后调用
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsEndFileTransf(byte[] uartPort, byte baudRate);
        /// <summary>
        /// 删除文件
        /// fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileNub">要删除的文件个数</param>
        /// <param name="fileName">要删除的文件名</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName);
        /// <summary>
        /// 删除文件
        /// 注：此函数用于对存储在固定位置的文件进行处理， 例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileNub">要删除的文件个数</param>
        /// <param name="fileName">要删除的文件名</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_confDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName);
        /// <summary>
        /// 获取控制空间大小和剩余空间
        /// 发节目前需要查询防止空间不够用
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="totalMemVolume">全部空间大小</param>
        /// <param name="availableMemVolume">剩余空间大小</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsGetMemoryVolume(byte[] uartPort, byte baudRate, ref int totalMemVolume, ref int availableMemVolume);
        /// <summary>
        /// 写文件到控制
        /// 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        /// 内部包含多条命令注意返回状态方便查找问题
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="fileLen">文件长度</param>
        /// <param name="overwrite">是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1</param>
        /// <param name="fileAddre">文件所在的缓存地址</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);
        /// <summary>
        /// 写文件到控制
        /// 此函数用于对存储在固定位置的文件进行处理， 
        /// 例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// 内部包含多条命令注意返回状态方便查找问题
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="fileLen">文件长度</param>
        /// <param name="overwrite">是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1</param>
        /// <param name="fileAddre">文件所在的缓存地址</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_confWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre);
        /// <summary>
        /// 开始读文件
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileSize">回读文件大小</param>
        /// <param name="fileCrc">回读的文件CRC</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc);
        /// <summary>
        /// 开始读文件
        ///  注：此函数用于对存储在固定位置的文件进行处理， 
        ///  例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileSize">回读文件大小</param>
        /// <param name="fileCrc">回读的文件CRC</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_confStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc);
        /// <summary>
        /// 读文件
        /// 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        /// fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileAddre">传入读文件写的位置</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);
        /// <summary>
        /// 读文件
        /// 此函数用于对存储在固定位置的文件进行处理， 
        /// 例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileAddre">传入读文件写的位置</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_confReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);
        /// <summary>
        /// 下面两条命令搭配使用可以获取所有文件名
        /// 下面两条命令用法比较复杂请配合协议使用不做嗷述
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="dirBlock"></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsReedDirBlock(byte[] uartPort, byte baudRate, ref GetDirBlock_G56 dirBlock);
        /// <summary>
        /// 释放cmd_ofsReedDirBlock所创建的节目列表dirBlock
        /// dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
        /// </summary>
        /// <param name="dirBlock">上述两条命令所有使用的结构体</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_ofsFreeDirBlock(ref GetDirBlock_G56 dirBlock);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="r_w"></param>
        /// <param name="fileName"></param>
        /// <param name="fileCrc"></param>
        /// <param name="fileOffset"></param>
        /// <returns></returns>
        int BxDual_cmd_uart_ofsGetTransStatus(byte[] uartPort, byte baudRate, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset);
        /// <summary>
        /// 发送配置文件到控制器
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="configData">请参考结构体ConfigFile</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_sendConfigFile(byte[] uartPort, byte baudRate, ref ConfigFile configData);
        /// <summary>
        /// 节目锁定
        /// 具体使用方法参考协议
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="nonvolatile">状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存</param>
        /// <param name="locked">0x00 –解锁  0x01 –锁定</param>
        /// <param name="name">节目名称4（byte）个字节</param>
        /// <param name="lockDuration">节目锁定时间长度， 单位为 10 毫秒， 例如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_programLock(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, uint lockDuration);
        /// <summary>
        /// 节目锁定
        /// 具体使用方法参考协议
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="nonvolatile">状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存</param>
        /// <param name="locked">0x00 –解锁  0x01 –锁定</param>
        /// <param name="name">节目名称4（byte）个字节</param>
        /// <param name="lockDuration">节目锁定时间长度， 单位为 10 毫秒， 例如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_uart_programLock_6G(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, int lockDuration);
        /*! ***************************************************************
        **  串口通讯命令 end **
        /*! ***************************************************************/
        /// <summary>
        /// 设置wifi卡的 ssid pwd
        /// 通讯方式（UDP
        /// </summary>
        /// <param name="ssid">控制器WIFI ssid</param>
        /// <param name="pwd">控制WIFI密码</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_AT_setWifiSsidPwd(byte[] ssid, byte[] pwd);
        /// <summary>
        /// 获取WIFI卡ssid pwd
        /// 通讯方式（UDP）
        /// </summary>
        /// <param name="ssid">控制器WIFI ssid</param>
        /// <param name="pwd">控制WIFI密码</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_AT_getWifiSsidPwd(byte[] ssid, byte[] pwd);
        /*! ***************************************************************
        **  UDP通讯命令 **
        /*! ***************************************************************/
        /// <summary>
        /// 网络搜索
        /// </summary>
        /// <param name="retData">请参考结构体heartbeatData 所有回读参数都会通过结构体回调</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_udpNetworkSearch(ref HeartbeatData retData);
        /// <summary>
        /// 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，
        /// 详见 NetSearchCmdRet:参考结构体声明中的注释；
        /// 针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="retData">存放网络搜索结果; 具体参考结构体:NetSearchCmdRet 声明中的注释；</param>
        /// <returns>0 成功， 其他值为错误号;</returns>
        int BxDual_cmd_udpNetworkSearch_6G(ref NetSearchCmdRet retData);
        /// <summary>
        /// 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，
        /// 详见 NetSearchCmdRet_Web:参考结构体声明中的注释；
        /// 针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="retData">存放网络搜索结果; 具体参考结构体:NetSearchCmdRet_Web 声明中的注释；</param>
        /// <returns>0 成功， 其他值为错误号;</returns>
        int BxDual_cmd_udpNetworkSearch_6G_Web(ref NetSearchCmdRet_Web retData);
        /// <summary>
        /// UDP ping命令并返回IP地址
        /// 此命令用来搜索加屏使用
        /// </summary>
        /// <param name="retData">请参考结构体Ping_data 所有回读参数都会通过结构体回调</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_udpPing(ref Ping_data retData);
        /// <summary>
        /// 设置 MAC 地址命令
        /// 需要修改MAC地址的时候调用
        /// </summary>
        /// <param name="mac">传入的MAC地址</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_udpSetMac(byte[] mac);
        /// <summary>
        /// 设置 IP 地址相关参数命令
        /// IP 地址 MAC地址都赋字符串 例：byte ip[] = "192.168.0.199"  具体使用细节请参考协议
        /// </summary>
        /// <param name="mode">
        /// 控制器连接模式：
        /// 0x00 –单机直连（PC 与控制器直接连接）
        /// 0x01 –自动获取IP（DHCP）
        /// 0x02 –手动设置IP（Static IP）
        /// 0x03 –服务器模式（动态 IP）
        /// </param>
        /// <param name="ip">要设置的IP地址//设置IP</param>
        /// <param name="subnetMask">子网掩码</param>
        /// <param name="gateway">默认网关</param>
        /// <param name="port">端口号</param>
        /// <param name="serverMode">服务器模式</param>
        /// <param name="serverIP">服务IP</param>
        /// <param name="serverPort">服务器端口号</param>
        /// <param name="password">服务器访问密码</param>
        /// <param name="heartbeat">心跳间隔时间单位秒 默认值20</param>
        /// <param name="netID">控制器网络ID</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_udpSetIP(byte mode, byte[] ip, byte[] subnetMask, byte[] gateway, short port, byte serverMode, byte[] serverIP, short serverPort, byte[] password, short heartbeat, byte[] netID);// 由于传入参数到内部都需要转换没有使用结构体
        /*! ***************************************************************
        /**UDP CMD END**/
        /*! ***************************************************************/
        /*! ***************************************************************
        /** TCP命令 控制器维护命令 **/
        /*! ***************************************************************/
        /// <summary>
        /// 让系统复位
        /// 此命令调用后所有参数全部会丢失
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_sysReset(byte[] ip, ushort port);
        /// <summary>
        /// 通过TCP方式获取到控制器相关属性和IP地址
        /// 注:和UDP PING命令获取到的参数相同
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="retData">请参考结构体Ping_data <see cref="Ping_data"/></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_tcpPing(byte[] ip, ushort port, ref Ping_data retData);
        /// <summary>
        /// 校时，让控制器和当前上位机所在系统时间一致
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_check_time(byte[] ip, ushort port);
        /// <summary>
        /// 串口校时
        /// </summary>
        /// <param name="uartPort">"\\\\.\\COM1";</param>
        /// <param name="baudRate">1(表示波特率9600); 2(代表57600);</param>
        /// <returns></returns>
        int BxDual_cmd_check_time_uart(byte[] uartPort, byte baudRate);
        /// <summary>
        /// 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，
        /// 详见 NetSearchCmdRet:参考结构体声明中的注释；
        /// 针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="retData">命令结果放在了 retData 中；NetSearchCmdRet:参考结构体声明中的注释；</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_tcpNetworkSearch_6G(byte[] ip, ushort port, ref NetSearchCmdRet retData);
        /// <summary>
        /// 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，
        /// 详见 NetSearchCmdRet_Web:参考结构体声明中的注释；
        /// 针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="retData">命令结果放在了 retData 中；NetSearchCmdRet_Web:参考结构体声明中的注释；</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_tcpNetworkSearch_6G_Web(byte[] ip, ushort port, ref NetSearchCmdRet_Web retData);
        /// <summary>
        /// 强制开挂机命令
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="onOff">控制器状态：0x01 –开机 0x00 –关机</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_coerceOnOff(byte[] ip, ushort port, byte onOff);
        /// <summary>
        /// 强制开关机（通过串口发送命令）
        /// </summary>
        /// <param name="sPortName">"\\\\.\\COM1</param>
        /// <param name="nBaudRateIndex"> 1(表示波特率9600); 2(代表57600)</param>
        /// <param name="nOnOff"></param>
        /// <returns></returns>
        int BxDual_cmd_coerceOnOff_uart(byte[] sPortName, byte nBaudRateIndex, byte nOnOff);
        /// <summary>
        /// 定时开关机命令
        /// groupNum值是n组情况,data大小 = n * TimingOnOff
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="groupNum">有几组定时开关机</param>
        /// <param name="data">TimingOnOff结构体的地址</param>
        /// <returns></returns>
        int BxDual_cmd_timingOnOff(byte[] ip, ushort port, byte groupNum, byte[] data);
        /// <summary>
        /// 取消定时开关机
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_cancelTimingOnOff(byte[] ip, ushort port);
        /// <summary>
        /// 设置亮度和相关模式
        /// 参考协议对应每一个表格，注意第一个字节模式的配置
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="brightness">亮度度表</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness);
        /// <summary>
        /// 通过串口调节亮度
        /// </summary>
        /// <param name="sPortName">\\\\.\\COM1</param>
        /// <param name="nBaudRateIndex">1(表示波特率9600); 2(代表57600)</param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        int BxDual_cmd_setBrightness_uart(byte[] sPortName, byte nBaudRateIndex, ref Brightness brightness);
        /// <summary>
        /// 读控制器ID
        /// ControllerID是8个字节 请定义char data[8];
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="ControllerID">传回控制器ID</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_readControllerID(byte[] ip, ushort port, byte[] ControllerID);
        /// <summary>
        /// 屏幕锁定
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="nonvolatile">状态是否掉电保存 0x00 –掉电不保存 0x01 –掉电保存</param>
        /// <param name="locked">0x00 –解锁  0x01 –锁定</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_screenLock(byte[] ip, ushort port, byte nonvolatile, byte locked);
        /// <summary>
        /// 节目锁定
        /// 具体使用方法参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="nonvolatile">状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存</param>
        /// <param name="locked">0x00 –解锁  0x01 –锁定</param>
        /// <param name="name">节目名称4（byte）个字节</param>
        /// <param name="lockDuration">
        /// 节目锁定时间长度， 单位为 10 毫秒， 
        /// 例如当该值为 100 时表示锁定节目 1 秒.
        /// 注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制
        /// </param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_programLock(byte[] ip, ushort port, byte nonvolatile, byte locked, byte[] name, uint lockDuration);
        /// <summary>
        /// 读控制器状态
        /// ControllerStatus_G56和协议时对应的可以参考协议的具体用法
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="controllerStatus">请参考结构体ControllerStatus_G56</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_check_controllerStatus(byte[] ip, ushort port, ref ControllerStatus_G56 controllerStatus);
        /// <summary>
        /// 设置控制器密码
        /// 设置后一定要记住，设置后就不在能明码通讯
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="oldPassword">老密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setPassword(byte[] ip, ushort port, byte[] oldPassword, byte[] newPassword);
        /// <summary>
        /// 删除当前控制器密码
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="password">输出当前控制密码</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_deletePassword(byte[] ip, ushort port, byte[] password);
        /// <summary>
        /// 设置控制开机延时时间
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="delayTime">开机延时单位秒</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setDelayTime(byte[] ip, ushort port, short delayTime);
        /// <summary>
        /// 设置控制测试按钮功能
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="btnMode">按钮模式 0x00–测试按钮 0x01 –沿触发切换节目 0x02 –电平触发切换节目</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setBtnFunc(byte[] ip, ushort port, byte btnMode);
        /// <summary>
        /// 设置控制重启重启时间
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="cmdData">参考结构体TimingReset</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setTimingReset(byte[] ip, ushort port, ref TimingReset cmdData);
        /// <summary>
        /// 设置控制重启重启时间
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="dispMode">
        /// 控制器的显示模式（目前只针对 BX-5E系列控制器）
        /// Bit0 –串/并行， 0 表示并行， 1 表示并行
        /// Bit1–同步使能， 1 使能同步， 0 禁止同步
        /// </param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setDispMode(byte[] ip, ushort port, byte dispMode);
        /// <summary>
        /// 战斗时间管理命令
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="mode">
        /// 战斗时间控制命令
        /// 0x00:启动战斗时间
        /// 0x01:暂停战斗时间
        /// 0x02:复位战斗时间
        /// </param>
        /// <param name="battieData">命令回读参数请参考结构体BattleTime</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_battieTime(byte[] ip, ushort port, byte mode, ref BattleTime battieData);
        /// <summary>
        /// 秒表控制并获取秒表时间
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="mode">
        /// 秒表控制命令
        /// 0x00:启动秒表
        /// 0x01:暂停秒表
        /// 0x02:复位秒表
        /// </param>
        /// <param name="timeValue">回读回来的当前秒表时间单位毫秒</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_getStopwatch(byte[] ip, ushort port, byte mode, ref int timeValue);
        /// <summary>
        /// 获取亮度读传感器值
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="brightnessValue">当前亮度传感器值</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_getSensorBrightnessValue(byte[] ip, ushort port, ref int brightnessValue);
        /// <summary>
        /// 速度微调命令
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="speed">
        /// 速度微调参数值
        /// 该值以 0.1 毫秒为单位， 共 256 级， 上位机下发时该值为 0-255，
        /// 这样刚好使用一个低位字节， 高位字节为 0， 留作以后扩展使用。 
        /// 下位机根据该参数在每次循环中延时相应的时间， 以改善 LED屏幕的显示效果。
        /// 当该参数为 0 时， 下位机延时为 0， 该参数为 1 时， 下位机延时 0.1 毫秒， 以此类推
        /// </param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setSpeedAdjust(byte[] ip, ushort port, short speed);
        /// <summary>
        /// 设置屏幕号
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="address">屏幕号</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_setScreenAddress(byte[] ip, ushort port, short address);
        /** TCP OFS_CMD**/
        /// <summary>
        /// 文件系统格式化
        /// 具体细节参考协议
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsFormat(byte[] ip, ushort port);
        /// <summary>
        /// 开始批量写文件
        /// 注：发送节目前调用
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsStartFileTransf(byte[] ip, ushort port);
        /// <summary>
        /// 写文件结束
        /// 注：发送节目后调用
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsEndFileTransf(byte[] ip, ushort port);
        /// <summary>
        /// 删除文件
        /// fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileNub">要删除的文件个数</param>
        /// <param name="fileName">要删除的文件名</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);
        /// <summary>
        /// 删除文件
        /// 此函数用于对存储在固定位置的文件进行处理， 
        /// 例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileNub">要删除的文件个数</param>
        /// <param name="fileName">要删除的文件名</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_confDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);
        /// <summary>
        /// 获取控制空间大小和剩余空间
        /// 发节目前需要查询防止空间不够用
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="totalMemVolume">全部空间大小</param>
        /// <param name="availableMemVolume">剩余空间大小</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsGetMemoryVolume(byte[] ip, ushort port, ref int totalMemVolume, ref int availableMemVolume);
        /// <summary>
        /// 写文件到控制
        /// 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        /// 内部包含多条命令注意返回状态方便查找问题
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="fileLen">文件长度</param>
        /// <param name="overwrite">是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1</param>
        /// <param name="fileAddre">文件所在的缓存地址</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);
        /// <summary>
        /// 写文件到控制
        /// 此函数用于对存储在固定位置的文件进行处理， 
        /// 例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// 内部包含多条命令注意返回状态方便查找问题
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="fileLen">文件长度</param>
        /// <param name="overwrite">是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1</param>
        /// <param name="fileAddre">文件所在的缓存地址</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_confWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre);
        /// <summary>
        /// 开始读文件
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileSize">回读文件大小</param>
        /// <param name="fileCrc">回读的文件CRC</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);
        /// <summary>
        /// 开始读文件
        /// 此函数用于对存储在固定位置的文件进行处理，
        /// 例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileSize">回读文件大小</param>
        /// <param name="fileCrc">回读的文件CRC</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_confStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);
        /// <summary>
        /// 读文件
        /// 用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        /// fileAddre大小根据bxDual_cmd_ofsStartReedFile函数回调值确定
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileAddre">传入读文件写的位置</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);
        /// <summary>
        /// 读文件
        /// 此函数用于对存储在固定位置的文件进行处理， 
        /// 例如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="fileName">需要读取的文件名</param>
        /// <param name="fileAddre">传入读文件写的位置</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_confReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);
        /// <summary>
        /// 获取文件列表
        /// 下面几条命令用法比较复杂请配合协议使用不做嗷述
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="dirBlock">读会的文件列表，具体的具体参考GetDirBlock_G56结构体</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofsReedDirBlock(byte[] ip, ushort port, ref GetDirBlock_G56 dirBlock);
        /// <summary>
        /// 获取指定文件的属性
        /// number：此参数值小于fileAttr.fileName 从0开始
        /// </summary>
        /// <param name="dirBlock">上一条命令的回传结构体</param>
        /// <param name="number">要获取的第几个文件的属性</param>
        /// <param name="fileAttr">获取到的文件属性存放位置参考结构体FileAttribute_G56；</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_getFileAttr(ref GetDirBlock_G56 dirBlock, ushort number, ref FileAttribute_G56 fileAttr);
        /// <summary>
        /// 释放bxDual_cmd_ofsReedDirBlock所创建的节目列表dirBlock
        /// dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
        /// </summary>
        /// <param name="dirBlock">上述两条命令所有使用的结构体</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_ofs_freeDirBlock(ref GetDirBlock_G56 dirBlock);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="r_w"></param>
        /// <param name="fileName"></param>
        /// <param name="fileCrc"></param>
        /// <param name="fileOffset"></param>
        /// <returns></returns>
        int BxDual_cmd_ofsGetTransStatus(byte[] ip, ushort port, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset);
        /// <summary>
        /// 激活指定固件
        /// firmwareFileName 缺省值为4个字节字符串“F001”
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="firmwareFileName">要激活的固件名称</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_firmwareActivate(byte[] ip, ushort port, byte[] firmwareFileName);
        /// <summary>
        /// 发送5代卡配置文件到控制器
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="configData">请参考结构体ConfigFile</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_sendConfigFile(byte[] ip, ushort port, ref ConfigFile configData);
        /// <summary>
        /// 发送5代卡配置文件到控制器
        /// </summary>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <param name="configData">请参考结构体ConfigFile</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_cmd_sendConfigFile_G6(byte[] ip, ushort port, ref ConfigFile_G6 configData);
        /*! ***************************************************************
        /** TCP命令 END **/
        /*! ***************************************************************/
        /// <summary>
        /// 用来计算CRC16值
        /// </summary>
        /// <param name="crc16"></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_get_crc16(ref FileCRC16_G56 crc16);
        /// <summary>
        /// 用来计算CRC32值
        /// </summary>
        /// <param name="crc32"></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_get_crc32(ref FileCRC32_G56 crc32);
        /*! ***************************************************************
        ***                  以下是节目相关函数
        *** 注意事项：
        ***
        ***
        /*! ***************************************************************/
        /// <summary>
        /// 删除节目
        /// </summary>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_deleteProgram();
        /// <summary>
        /// 释放缓存
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        int BxDual_program_freeBuffer(ref EQprogram program);
        /// <summary>
        /// 只是用来测试图文区
        /// 注： 屏幕大小为1024X80 输出26个字母
        /// </summary>
        /// <param name="programID">节目的ID号</param>
        /// <param name="ip">控制器IP</param>
        /// <param name="port">控制器端口</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_pictureArea(int programID, byte[] ip, ushort port);
        /// <summary>
        /// 设置屏相关属性
        /// </summary>
        /// <param name="color">显示颜色</param>
        /// <param name="ControllerType">其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。</param>
        /// <param name="doubleColor"></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor);
        // int BxDual_program_setScreenParams_G6(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor);
        /// <summary>
        /// 添加节目句柄
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="programH">参考结构体EQprogramHeader</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_addProgram(ref EQprogramHeader programH);
        /// <summary>
        /// 修改已添加节目的一些参数
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="programH">参考结构体EQprogramHeader</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_changeProgramParams(ref EQprogramHeader programH);
        /// <summary>
        /// 添加节目播放时段
        /// </summary>
        /// <param name="header"></param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_addPlayPeriodGrp(ref EQprogramppGrp_G56 header);
        /// <summary>
        /// 添加区域句柄
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="aheader">参考结构体EQareaHeader</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_AddArea(ushort areaID, ref EQareaHeader aheader);
        /// <summary>
        /// 用来删除编号为areaID的区域
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_deleteArea(ushort areaID);
        /// <summary>
        /// 画字符到图文区
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要画的字符</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="pheader">参考结构体EQpageHeader</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader pheader);
        /// <summary>
        /// 修改图文区域内容
        /// 只可以修改文字内容和EQpageHeader结构体里面的参数，不可以修改字体，
        /// 如需修改，需要删除区域后重新添加文本设置字体
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要画的字符</param>
        /// <param name="pheader">参考结构体EQpageHeader</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);
        /// <summary>
        /// 图文区添加字符串--使用字库
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要画的字符</param>
        /// <param name="fontPathName">字体绝对路径加字库文件名称</param>
        /// <param name="pheader">参考结构体EQpageHeader</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_fontPath_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader pheader);
        /// <summary>
        /// 图文区修改字符串--使用字库
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要更换的字符串</param>
        /// <param name="pheader">参考结构体EQpageHeader</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_fontPath_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);
        /// <summary>
        /// 合成节目文件返回节目文件属性及地址
        /// EQprogram 结构体是用来回调发送文件所需要参数
        /// </summary>
        /// <param name="program">参考结构体EQprogram</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_IntegrateProgramFile(ref EQprogram program);
        /// <summary>
        /// 区域添加边框
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="afHeader">参考结构体EQareaframeHeader</param>
        /// <param name="picPath">边框图片文件的路径</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_picturesAreaAddFrame(ushort areaID, ref EQareaframeHeader afHeader, byte[] picPath);
        /// <summary>
        /// 区域添加边框
        /// </summary>
        /// <param name="areaID"></param>
        /// <param name="afHeader"></param>
        /// <param name="picPath"></param>
        /// <returns></returns>
        int BxDual_program_picturesAreaAddFrame_G6(ushort areaID, ref EQscreenframeHeader_G6 afHeader, byte[] picPath);
        /// <summary>
        /// 返回区域第n张图片
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="pageNum">第几页，从0开始计算</param>
        /// <param name="pageData"></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_pictureAreaGetOnePage(ushort areaID, int pageNum, ref GetPageData pageData);
        /// <summary>
        /// 添加图片到区域
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="picID">图片的ID号</param>
        /// <param name="pheader">参考结构体EQpageHeader</param>
        /// <param name="picPath">添加的图片路径</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_pictureAreaAddPic(ushort areaID, ushort picID, ref EQpageHeader pheader, byte[] picPath);
        /// <summary>
        /// 节目添加边框
        /// </summary>
        /// <param name="sfHeader">参考结构体EQscreenframeHeader</param>
        /// <param name="picPath">添加的边框图片路径</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);
        /// <summary>
        /// 节目修改已添加边框的一些参数
        /// </summary>
        /// <param name="sfHeader">参考结构体EQscreenframeHeader</param>
        /// <param name="picPath">边框图片路径</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_changeFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);
        /// <summary>
        /// 节目去掉边框
        /// </summary>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_removeFrame();
        /// <summary>
        /// 区域去掉边框
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_pictureAreaRemoveFrame(ushort areaID);
        /// <summary>
        /// 改变区域坐标大小
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="x">区域left坐标</param>
        /// <param name="y">区域top坐标</param>
        /// <param name="width">区域宽度</param>
        /// <param name="height">区域高度</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_MoveArea(ushort areaID, int x, int y, int width, int height);
        /// <summary>
        /// 时间分区添加内容
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="timeData">详情请见时间区数据格式结构体EQtimeAreaData_G56</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /// <summary>
        /// 时间分区添加内容EQtimeAreaData::fontName == 字库名称
        /// ios下无法使用program_timeAreaAddContent请使用program_fontPath_timeAreaAddContent()
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="timeData">详情请见时间区数据格式结构体EQtimeAreaData_G56</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_fontPath_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /// <summary>
        /// 时间分区修改内容EQtimeAreaData::fontName == 字库的路径加字库文件名（字库地址）
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="timeData">详情请见时间区数据格式结构体EQtimeAreaData_G56</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaChangeContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /// <summary>
        /// 返回时间区域第n张图片
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="pageData">第几页，从0开始计算</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaGetOnePage(ushort areaID, ref GetPageData pageData);
        /// <summary>
        /// 时间分区添加模拟时钟
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="header">详情见EQAnalogClockHeader_G56结构体</param>
        /// <param name="cStyle">表盘样式，详情见E_ClockStyle</param>
        /// <param name="cColor">表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaAddAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /// <summary>
        /// 时间分区修改模拟时钟的一些设置参数
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="header">详情见EQAnalogClockHeader_G56结构体</param>
        /// <param name="cStyle">表盘样式，详情见E_ClockStyle</param>
        /// <param name="cColor">表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaChangeAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /// <summary>
        /// 时间分区从外部添加表盘图片
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="picPath">表盘图片位置</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaChangeDialPic(ushort areaID, byte[] picPath);
        /// <summary>
        /// 时间分区从外部添加表盘图片
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="picAdd">表盘图片位置</param>
        /// <param name="picLen"></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaChangeDialPicAdd_G56(ushort areaID, byte[] picAdd, int picLen);
        /// <summary>
        /// 时间分区移除外部添加的表盘图片
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaRemoveDialPic(ushort areaID);
        //6代控制卡动态区功能开始:=================================
        /// <summary>
        /// 设置动态区颜色像素类型：R+G 或 G+R
        /// </summary>
        /// <param name="ePixelRGorGR"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56 ePixelRGorGR);
        /// <summary>
        /// 6代更新动态区最基本功能：仅显示动态区：即不与节目一起显示，如果当前有节目显示，调用此函数后，LED屏幕上会清空原来的内容，显示此函数中 strAreaTxtContent 参数的内容；
        /// 如果要与屏幕上原来显示的节目一起显示，请调用下面的 动态区文本关联节目 函数；与节目一起显示时，要注意动态区域与原来的节目区域不能重叠！
        /// </summary>
        /// <param name="pIP">（与控制卡直连时）控制卡IP;（通过服务端连时）服务端IP</param>
        /// <param name="nPort">端口号;服务端返回的控制卡对应的端口号;</param>
        /// <param name="color">LED屏颜色类型，详见 E_ScreenColor_G56 声明；</param>
        /// <param name="uAreaId">区域号; 如果控制卡只支持4个动态区，则uAreaId的取值范围：0-3；共4个；且只能是0-3之间的值；</param>
        /// <param name="uAreaX">
        /// 显示区域坐标，即动态区域左上角在LED显示屏的位置/坐标；如：（0，0）则是从LED显示屏幕的最左上角开始显示动态区域；
        /// 注意:不同控制卡的最小LED屏宽不同，如BX-6E2X最小屏宽为80个显示单位，所以连接的LED屏如果只有64宽度，则在坐标为（0，0）且是靠左显示的情况下，最左边的16个单元会显示不完整；
        /// 此时，可以考虑设置起始点X的坐标为16，即(16，0),此时宽高为(80-16,高);
        /// </param>
        /// <param name="uAreaY">
        /// 显示区域坐标，即动态区域左上角在LED显示屏的位置/坐标；如：（0，0）则是从LED显示屏幕的最左上角开始显示动态区域；
        /// 注意:不同控制卡的最小LED屏宽不同，如BX-6E2X最小屏宽为80个显示单位，所以连接的LED屏如果只有64宽度，则在坐标为（0，0）且是靠左显示的情况下，最左边的16个单元会显示不完整；
        /// 此时，可以考虑设置起始点X的坐标为16，即(16，0),此时宽高为(80-16,高);
        /// </param>
        /// <param name="uWidth">动态区域的宽度;</param>
        /// <param name="uHeight">动态区域的高度;</param>
        /// <param name="fontName">字体名称，如"宋体"</param>
        /// <param name="nFontSize">字体大小，如12</param>
        /// <param name="strAreaTxtContent">要显示的文本内容</param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaTxt_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY,
            ushort uWidth, ushort uHeight, IntPtr fontName, byte nFontSize, IntPtr strAreaTxtContent);
        /// <summary>
        /// 6代更新动态区详细功能：仅显示动态区; 将要显示的一些特性/属性，封装在 EQareaHeader_G6 和 EQpageHeader_G6 结构体中；
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="oAreaHeader_G6"></param>
        /// <param name="stPageHeader"></param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);
        /// <summary>
        /// 6代更新动态区详细功能：仅显示动态区;
        /// 使用串口发送；
        /// </summary>
        /// <param name="pSerialName">串口号字符串；如:byte pSerialName[] = "COM3"</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="oAreaHeader_G6"></param>
        /// <param name="stPageHeader"></param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);
        /// <summary>
        /// 动态区文本关联节目: 
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="oAreaHeader_G6"></param>
        /// <param name="stPageHeader"></param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent"></param>
        /// <param name="RelateProNum">
        /// RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        /// RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        /// </param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 动态区关联节目
        /// </summary>
        /// <param name="pSerialName">串口名称,如"COM1"；</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="oAreaHeader_G6"></param>
        /// <param name="stPageHeader"></param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 更新动态区图片：仅显示动态区;
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="AreaX"></param>
        /// <param name="AreaY"></param>
        /// <param name="AreaWidth"></param>
        /// <param name="AreaHeight"></param>
        /// <param name="pheader"></param>
        /// <param name="picPath"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);
        /// <summary>
        /// 更新动态区图片：仅显示动态区;
        /// </summary>
        /// <param name="pSerialName">串口名称,如"COM1"；</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="AreaX"></param>
        /// <param name="AreaY"></param>
        /// <param name="AreaWidth"></param>
        /// <param name="AreaHeight"></param>
        /// <param name="pheader"></param>
        /// <param name="picPath"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);
        /// <summary>
        /// 动态区图片关联节目: 
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="AreaX"></param>
        /// <param name="AreaY"></param>
        /// <param name="AreaWidth"></param>
        /// <param name="AreaHeight"></param>
        /// <param name="pheader"></param>
        /// <param name="picPath"></param>
        /// <param name="RelateProNum">
        /// RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        /// RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        /// </param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 动态区图片关联节目
        /// </summary>
        /// <param name="pSerialName">串口名称,如"COM1"；</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="AreaX"></param>
        /// <param name="AreaY"></param>
        /// <param name="AreaWidth"></param>
        /// <param name="AreaHeight"></param>
        /// <param name="pheader"></param>
        /// <param name="picPath"></param>
        /// <param name="RelateProNum">
        /// RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        /// RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        /// </param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 同时更新多个动态区:仅显示动态区，不显示节目
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /// <summary>
        /// 同时更新多个动态区文本:仅显示动态区，不显示节目
        /// </summary>
        /// <param name="pSerialName">串口名称,如"COM1"；</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddTxtDetails_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /// <summary>
        /// 同时更新多个动态区文本:并与节目关联，即与节目一起显示
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <param name="RelateProNum">
        /// RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区
        /// RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        /// </param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 同时更新多个动态区文本:并与节目关联，即与节目一起显示
        /// </summary>
        /// <param name="pSerialName">串口名称,如"COM1"；</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <param name="RelateProNum">
        /// RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区
        /// RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        /// </param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 同时更新多个动态区图片：仅显示动态区图片;不与节目关联/不与节目一起显示；
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /// <summary>
        /// 同时更新多个动态区图片;仅显示动态区图片/不与节目关联/不与节目一起显示；
        /// </summary>
        /// <param name="pSerialName">串口名称,如"COM1"；</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /// <summary>
        /// 同时更新多个动态区图片，并与节目关联，即与节目一起显示；
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <param name="RelateProNum">
        /// RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        /// RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中
        /// </param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 同时更新多个动态区图片，并与节目关联，即与节目一起显示；
        /// </summary>
        /// <param name="pSerialName">串口名称,如"COM1"；</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pParams"></param>
        /// <param name="RelateProNum">
        /// RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        /// RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        /// </param>
        /// <param name="RelateProSerial"></param>
        /// <returns></returns>
        int BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /// <summary>
        /// 增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        /// TCP
        /// </summary>
        /// <param name="pIP">控制卡IP地址，如"192.168.1.111";</param>
        /// <param name="nPort">控制卡默认TCP方式的端口号为:5005</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="nInfoCount"></param>
        /// <param name="pInfo"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaInfos_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            byte nInfoCount,
            ref DynamicAreaBaseInfo_5G[] pInfo
        );
        /// <summary>
        /// 增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        /// 使用串口发送；
        /// </summary>
        /// <param name="pSerialName">串口号字符串；如:byte pSerialName[] = "COM3";</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="nInfoCount"></param>
        /// <param name="pInfo"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaInfos_G6_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            byte nInfoCount,
            ref DynamicAreaBaseInfo_5G[] pInfo
        );
        /// <summary>
        /// 一次向一个动态区发送/更新多条信息（文字或图片）及语音
        /// 参数详细说明参考《6th 动态区域用户手册》
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode">
        /// 动态区运行模式 
        /// 0 — 动态区数据循环显示。
        /// 1 — 动态区数据显示完成后静止显示最后一页数据。
        /// 2 — 动态区数据循环显示，超过设定时间后数据仍未更新时不再显示
        /// 3 — 动态区数据循环显示，超过设定时间后数据仍未更新时显示Logo 信息, Logo 信息即为动态区域的最后一页信息
        /// 4 — 动态区数据顺序显示，显示完最后一页后就不再显示
        /// </param>
        /// <param name="Timeout">动态区数据超时时间，单位为秒;该动态区显示时长超过这个值的时间(s)，会自动删除，仅部分卡类型支持；未试过；</param>
        /// <param name="RelateAllPro">当该字节为 1 时，所有异步节目播放时都允许播放该动态区域；为 0 时，由接下来的规则来决定</param>
        /// <param name="RelateProNum">动态区域关联了多少个异步节目一旦关联了某个异步节目，则当该异步节目播放时允许播放该动态区域，否则，不允许播放该动态区域</param>
        /// <param name="RelateProSerial"> 动态区域关联的节目编号；</param>
        /// <param name="ImmePlay">
        /// 是否覆盖该字节为 0 时，该动态区域与异步节目一起播放，
        /// 注意：异步节目和动态区不能重叠，重叠情况下，某些特技组合会导致花屏。所以，要保证区域没有重叠。
        /// 该字节为 1 时，异步节目停止播放，仅播放该动态区域
        /// 注意：当该字节为 0 时，RelateAllPro 到RelateProSerialN-1 的参数才有效，否则无效
        /// 当该参数为 1 时，由于不与异步节目同时播放，为控制该动态区域能及时结束，
        /// 可选择 RunMode参数为 2 或 4，当然也可通过删除该区域来实现
        /// </param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="nInfoCount"></param>
        /// <param name="pInfo"></param>
        /// <param name="pSoundData">语音内容；默认为空不发送语音；</param>
        /// <returns>0 成功；-1 失败；</returns>
        int BxDual_dynamicArea_AddAreaInfos_6G_V2(byte[] pIP, int nPort, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            BxAreaFrmae_Dynamic_G6 oFrame,
            byte nInfoCount,
            DynamicAreaBaseInfo_5G[] pInfo,
            ref EQSound_6G pSoundData
        );
        /// <summary>
        /// 增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        /// 使用串口发送；
        /// </summary>
        /// <param name="pSerialName">串口号字符串；如:byte pSerialName[] = "COM3";</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="nInfoCount"></param>
        /// <param name="pInfo"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            BxAreaFrmae_Dynamic_G6 oFrame,
            byte nInfoCount,
            DynamicAreaBaseInfo_5G[] pInfo
        );
        /// <summary>
        /// TCP方式删除动态区
        /// 删除单个动态区：
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="uAreaId">0xff:删除所有区域</param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelArea_6G(byte[] pIP, int nPort, byte uAreaId);
        /// <summary>
        /// TCP方式删除多个动态区：
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="uAreaCount">动态区ID数组中的个数；</param>
        /// <param name="pAreaID">存放要删除的动态区ID数组；</param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelAreas_6G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);
        /// <summary>
        /// 串口方式删除动态区
        /// 删除单个动态区：
        /// </summary>
        /// <param name="pSerialName"></param>
        /// <param name="nBaudRateIndex"></param>
        /// <param name="uAreaId">0xff:删除所有区域</param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelArea_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);
        /// <summary>
        /// 串口方式删除多个动态区
        /// </summary>
        /// <param name="pSerialName"></param>
        /// <param name="nBaudRateIndex"></param>
        /// <param name="uAreaCount">动态区ID数组中的个数</param>
        /// <param name="pAreaID">存放要删除的动态区ID数组；</param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelAreas_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);
        /// <summary>
        /// 插入独立语音
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="stSoundData"></param>
        /// <param name="VoiceFlg">1 1 语音属性 0：此条语音从头插入队列，且停止当前正在播放的语音 1：此条语音从头插入队列，不停止当前播报的语音 2：此条语音从尾插入队列</param>
        /// <param name="StoreFlag">1 0 该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失该值为 0 表示需要存储到 RAM 中，掉电信息丢失</param>
        /// <returns></returns>
        int BxDual_dynamicArea_InsertSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, byte VoiceFlg, byte StoreFlag);
        /// <summary>
        /// 5.4.3 更新独立语音命令
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="stSoundData">指向存放EQSoundDepend_6G结构的一段内存首地址指针；</param>
        /// <param name="nSoundDataCount">指示stSoundData指向内存地址空间中存放EQSoundDepend_6G个数；</param>
        /// <param name="StoreFlag">该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失;该值为 0 表示需要存储到 RAM 中，掉电信息丢失</param>
        /// <returns></returns>
        int BxDual_dynamicArea_UpdateSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, ushort nSoundDataCount, byte StoreFlag);
        //6代控制卡动态区功能结束.=======================
        //5代控制卡动态区功能开始:===============================
        /// <summary>
        /// 发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；其它参考信息参见 上面的 6代控制卡动态区功能 函数 bxDual_dynamicArea_AddAreaTxt_6G 上面的说明；
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="DisplayMode"></param>
        /// <param name="ClearMode"></param>
        /// <param name="Speed"></param>
        /// <param name="StayTime"></param>
        /// <param name="RepeatTime"></param>
        /// <param name="oFont">显示内容和字体格式</param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent">动态区域内要显示的文本内容</param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaWithTxt_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            //PageStyle begin--------
            byte DisplayMode,
            byte ClearMode,
            byte Speed,
            ushort StayTime,
            byte RepeatTime,
            //PageStyle End.
            EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        );
        /// <summary>
        /// 发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；
        /// 使用串口发送；
        /// </summary>
        /// <param name="pSerialName">串口号字符串；如:byte pSerialName[] = "COM3";</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="DisplayMode"></param>
        /// <param name="ClearMode"></param>
        /// <param name="Speed"></param>
        /// <param name="StayTime"></param>
        /// <param name="RepeatTime"></param>
        /// <param name="oFont">显示内容和字体格式</param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaWithTxt_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            //PageStyle begin--------
            byte DisplayMode,
            byte ClearMode,
            byte Speed,
            ushort StayTime,
            byte RepeatTime,
            //PageStyle End.
            EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="DisplayMode"></param>
        /// <param name="ClearMode"></param>
        /// <param name="Speed"></param>
        /// <param name="StayTime"></param>
        /// <param name="RepeatTime"></param>
        /// <param name="oFont">显示内容和字体格式</param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaWithTxt_Point_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            ref EQareaframeHeader oFrame,
            //PageStyle begin--------
            byte DisplayMode,
            byte ClearMode,
            byte Speed,
            ushort StayTime,
            byte RepeatTime,
            //PageStyle End.
            ref EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        );
        /// <summary>
        /// 发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；
        /// 使用串口发送
        /// </summary>
        /// <param name="pSerialName">串口号字符串；如:byte pSerialName[] = "COM3";</param>
        /// <param name="nBaundRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="DisplayMode"></param>
        /// <param name="ClearMode"></param>
        /// <param name="Speed"></param>
        /// <param name="StayTime"></param>
        /// <param name="RepeatTime"></param>
        /// <param name="oFont">显示内容和字体格式</param>
        /// <param name="fontName"></param>
        /// <param name="strAreaTxtContent"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(byte[] pSerialName, int nBaundRateIndex, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            ref EQareaframeHeader oFrame,
            //PageStyle begin--------
            byte DisplayMode,
            byte ClearMode,
            byte Speed,
            ushort StayTime,
            byte RepeatTime,
            //PageStyle End.
            ref EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        );
        /// <summary>
        /// 发送一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="DisplayMode"></param>
        /// <param name="ClearMode"></param>
        /// <param name="Speed"></param>
        /// <param name="StayTime"></param>
        /// <param name="RepeatTime"></param>
        /// <param name="filePath">图片路径</param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaWithPic_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            //PageStyle begin--------
            byte DisplayMode,
            byte ClearMode,
            byte Speed,
            ushort StayTime,
            byte RepeatTime,
            //PageStyle End.
            byte[] filePath
        );
        /// <summary>
        /// 发送一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
        /// 使用串口发送；
        /// </summary>
        /// <param name="pSerialName">串口号字符串；如:byte pSerialName[] = "COM3";</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="DisplayMode"></param>
        /// <param name="ClearMode"></param>
        /// <param name="Speed"></param>
        /// <param name="StayTime"></param>
        /// <param name="RepeatTime"></param>
        /// <param name="filePath">图片路径</param>
        /// <returns>0	：成功； -1	：失败；</returns>
        int BxDual_dynamicArea_AddAreaWithPic_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            //PageStyle begin--------
            byte DisplayMode,
            byte ClearMode,
            byte Speed,
            ushort StayTime,
            byte RepeatTime,
            //PageStyle End.
            byte[] filePath
        );
        /// <summary>
        /// 发送多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="nInfoCount"></param>
        /// <param name="pInfo"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaInfos_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            byte nInfoCount,
            [In, Out] DynamicAreaBaseInfo_5G[] pInfo
        );
        /// <summary>
        /// 增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="nInfoCount"></param>
        /// <param name="pInfo"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_AddAreaInfos_5G_Point(byte[] pIP, int nPort, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            byte nInfoCount,
            DynamicAreaBaseInfo_5G[] pInfo
        );
        /// <summary>
        /// 发送多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        /// 使用串口发送；
        /// </summary>
        /// <param name="pSerialName">串口号字符串；如:byte pSerialName[] = "COM3";</param>
        /// <param name="nBaudRateIndex">波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;</param>
        /// <param name="color"></param>
        /// <param name="uAreaId"></param>
        /// <param name="RunMode"></param>
        /// <param name="Timeout"></param>
        /// <param name="RelateAllPro"></param>
        /// <param name="RelateProNum"></param>
        /// <param name="RelateProSerial"></param>
        /// <param name="ImmePlay"></param>
        /// <param name="uAreaX"></param>
        /// <param name="uAreaY"></param>
        /// <param name="uWidth"></param>
        /// <param name="uHeight"></param>
        /// <param name="oFrame"></param>
        /// <param name="nInfoCount"></param>
        /// <param name="pInfo"></param>
        /// <returns>0	：成功； -1	：失败；</returns>
        int BxDual_dynamicArea_AddAreaInfos_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color,
            byte uAreaId,
            byte RunMode,
            ushort Timeout,
            byte RelateAllPro,
            ushort RelateProNum,
            ushort[] RelateProSerial,
            byte ImmePlay,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,
            byte nInfoCount,
            DynamicAreaBaseInfo_5G[] pInfo
        );
        //删除动态区：
        /// <summary>
        /// 删除单个动态区：
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="uAreaId">0xff:删除所有区域</param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelArea_5G(byte[] pIP, int nPort, byte uAreaId);
        /// <summary>
        /// 删除多个动态区：
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="nPort"></param>
        /// <param name="uAreaCount"></param>
        /// <param name="pAreaID"></param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelAreaS_5G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);
        /// <summary>
        /// 串口方式删除动态区
        /// 删除单个动态区：
        /// </summary>
        /// <param name="pSerialName"></param>
        /// <param name="nBaudRateIndex"></param>
        /// <param name="uAreaId"> 0xff:删除所有区域</param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelArea_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);
        /// <summary>
        /// 串口方式删除多个动态区
        /// </summary>
        /// <param name="pSerialName"></param>
        /// <param name="nBaudRateIndex"></param>
        /// <param name="uAreaCount">动态区ID数组中的个数</param>
        /// <param name="pAreaID">存放要删除的动态区ID数组；</param>
        /// <returns></returns>
        int BxDual_dynamicArea_DelAreaS_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);
        //5代控制卡动态区功能结束:===========================
        /*****************************以下为六代接口*******************************************/
        /// <summary>
        /// 添加节目
        /// </summary>
        /// <param name="programH">参考结构体<see cref="EQprogramHeader_G6"/></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_addProgram_G6(ref EQprogramHeader_G6 programH);
        /// <summary>
        /// 添加节目播放时段
        /// </summary>
        /// <param name="header"></param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_addPlayPeriodGrp_G6(ref EQprogramppGrp_G56 header);
        /// <summary>
        /// 删除节目
        /// </summary>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_deleteProgram_G6();
        /// <summary>
        /// 释放生成节目文件的缓冲区
        /// </summary>
        /// <param name="program"></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_freeBuffer_G6(ref EQprogram_G6 program);
        /// <summary>
        /// 修改已添加节目的一些参数
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="programH">参考结构体EQprogramHeader_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_changeProgramParams_G6(ref EQprogramHeader_G6 programH);
        /// <summary>
        /// 节目添加边框
        /// 注：节目添加边框后，区域的坐标随即发生变化，添加区域的时候需注意
        /// </summary>
        /// <param name="sfHeader">参考结构体<see cref="EQscreenframeHeader_G6"/></param>
        /// <param name="picPath">添加的边框图片路径</param>
        /// <returns>0 成功， -1 不成功</returns>
        int BxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);
        /// <summary>
        /// 节目修改已添加边框的一些参数
        /// </summary>
        /// <param name="sfHeader">参考结构体EQscreenframeHeader_G6</param>
        /// <param name="picPath">边框图片路径</param>
        /// <returns>0 成功， -1 不成功</returns>
        int BxDual_program_changeFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);
        /// <summary>
        /// 节目去掉边框
        /// </summary>
        /// <returns>0 成功</returns>
        int BxDual_program_removeFrame_G6();
        /// <summary>
        /// 节目添加区域
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="aheader">参考结构体EQareaHeader_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_addArea_G6(ushort areaID, ref EQareaHeader_G6 aheader);
        /// <summary>
        /// 节目删除已添加的区域
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域ID号</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_deleteArea_G6(ushort areaID);
        /// <summary>
        /// 改变区域坐标大小
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="x">区域left坐标</param>
        /// <param name="y">区域top坐标</param>
        /// <param name="width">区域宽度</param>
        /// <param name="height">区域高度</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_MoveArea_G6(ushort areaID, int x, int y, int width, int height);
        /// <summary>
        /// 画文字到图文区域
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要画的文字</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader_G6 pheader);
        /// <summary>
        /// 修改图文区域已添加过的文字内容及EQpageHeader_G6结构体中的参数
        /// 如需修改字体，需要将区域删除，重新添加区域和文字
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要画的文字</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_picturesAreaChangeTxt_G6(ushort areaID, IntPtr str, ref EQpageHeader_G6 pheader);
        /// <summary>
        /// 图文区添加字符串--使用字库
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要画的文字</param>
        /// <param name="fontPathName">字体绝对路径加字库文件名称</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_fontPath_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader_G6 pheader);
        /// <summary>
        /// 图文区修改字符串--使用字库
        /// 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="str">需要画的文字</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_fontPath_picturesAreaChangeTxt_G6(ushort areaID, byte[] str, ref EQpageHeader_G6 pheader);
        /// <summary>
        /// 添加图片到图文区域
        /// 下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="picID">图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <param name="picPath">图片的绝对路径加图片名称</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /// <summary>
        /// 添加图片到图文区域
        /// 下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="picID">图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <param name="picPath">图片的绝对路径加图片名称</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_backGroundPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /// <summary>
        /// 添加图片到图文区域
        /// 下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <param name="BGColor">区域背景颜色值（RGB888）</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        ///// <param name="picID">图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片</param>
        int BxDual_program_backGroundColor_G6(ushort areaID, ref EQpageHeader_G6 pheader, int BGColor);
        /// <summary>
        /// 修改当前picID对应的图片和一些参数
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="picID">图片编号，传入需要修改的图片编号</param>
        /// <param name="pheader">参考结构体EQpageHeader_G6</param>
        /// <param name="picPath">图片的绝对路径加图片名称</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_pictureAreaChangePic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /// <summary>
        /// 图文分区使能语音播放
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="sheader">参考结构体EQPicAreaSoundHeader_G6</param>
        /// <param name="soundData">语音数据</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_pictureAreaEnableSound_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);
        /// <summary>
        /// 图文分区修改语音播放的一些参数或数据
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="sheader">参考结构体EQPicAreaSoundHeader_G6</param>
        /// <param name="soundData">语音数据</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_pictureAreaChangeSoundSettings_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);
        /// <summary>
        /// 图文分区取消语音播放
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_pictureAreaDisableSound_G6(ushort areaID);
        /// <summary>
        /// 时间分区设置战斗时间和战斗时间的启动模式
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="header">参考结构体EQTimeAreaBattle_G6</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_timeAreaSetBattleTime_G6(ushort areaID, ref EQTimeAreaBattle_G6 header);
        /// <summary>
        /// 时间分区取消战斗时间
        /// 取消后的时间分区将作为普通时间
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_timeAreaCancleBattleTime_G6(ushort areaID);
        /// <summary>
        /// 时间分区添加时间等内容，详情请参考结构体EQtimeAreaData_G56
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="timeData">参考结构体EQtimeAreaData_G56</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /// <summary>
        /// 时间分区修改时间等内容，详情请参考结构体EQtimeAreaData_G56
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="timeData">参考结构体EQtimeAreaData_G56</param>
        /// <returns>0 成功， 其他值为错误</returns>
        int BxDual_program_timeAreaChangeContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /// <summary>
        /// 时间分区添加内容EQtimeAreaData::fontName == 字库名称
        /// ios下无法使用program_timeAreaAddContent_G6请使用program_fontPath_timeAreaAddContent_G6()
        /// </summary>
        /// <param name="areaID">区域的ID号</param>
        /// <param name="timeData">详情请见时间区数据格式结构体EQtimeAreaData_G56</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_fontPath_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /// <summary>
        /// 时间分区添加模拟时钟
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="header">详情见EQAnalogClockHeader_G56结构体</param>
        /// <param name="cStyle">表盘样式，详情见E_ClockStyle</param>
        /// <param name="cColor">表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /// <summary>
        /// 时间分区修改模拟时钟的一些设置参数
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="header">详情见EQAnalogClockHeader_G56结构体</param>
        /// <param name="cStyle">表盘样式，详情见E_ClockStyle</param>
        /// <param name="cColor">表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaChangeAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /// <summary>
        /// 时间分区从外部添加表盘图片
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <param name="picPath">表盘图片位置</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaChangeDialPic_G6(ushort areaID, byte[] picPath);
        /// <summary>
        /// 时间分区移除添加的表盘图片
        /// </summary>
        /// <param name="areaID">区域ID</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_timeAreaRemoveDialPic_G6(ushort areaID);
        /// <summary>
        /// 合成节目文件返回节目文件属性及地址
        /// 注：EQprogram 结构体是用来回调发送文件所需要参数
        /// </summary>
        /// <param name="program">参考结构体EQprogram_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program);
        /// <summary>
        /// 配置传感器区域的参数
        /// 本文档中提及的颜色属性:
        /// 对于有灰度系统，均用4Byte来表示，其中，Byte0表示红，Byte1表示绿，Byte2表示蓝，Byte3保留
        /// 对于无灰度系统，均用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
        /// </summary>
        /// <param name="nAreaID"></param>
        /// <param name="nSensorMode">
        /// 1byte	默认=0；
        /// 0：代表温度
        /// 1：代表湿度
        /// 2：代表噪声
        /// 3：代表PM2.5（空气质量变送器）
        /// 4：代表PM10（空气质量变送器）
        /// 5：RS485型风向变送器
        /// 6：RS485型风速变换器
        /// 7：大气压力
        /// 8：车速
        /// 9：光照
        /// 10：0x0A：水位计
        /// 11：0x0B: 代表TSP
        /// 12：0x0C: 负氧离子监测仪
        /// 0xff：万能传感器，该类型是BX-6XX-MODBUS系列专用类型，当传感器类型为该值时，下面的SensorType、SensorUnit、DisplayUnitFlag均设置为0，对于通用系列控制卡，该值为非0xff的值;
        /// </param>
        /// <param name="nSensorType">
        /// 传感器类型;默认长度/值： 1 0x00 
        /// 温度：
        ///     0x00 – DS18B20（温度传感器）
        ///     0x01 – SHT11(6 代三基色和全彩不支持)（I 温湿度传感器(4 线)
        ///     0X02 – DHT21（II 温湿度传感器(3 线)）
        ///     0X03 – RS-BYH-M（气象组合传感器）（BX-QX）
        /// 湿度：
        ///     0x00 – SHT11(6代三基色和全彩不支持)（I温湿度传感器(4线)
        ///     0x01 –DHT21（II温湿度传感器(3线)）
        ///     0X02 –RS-BYH-M（气象组合传感器 ）（BX-QX）
        /// 噪声：
        ///     0x00 –AWA5636-3(6代三基色和全彩不支持)
        ///     0x01 –HS5633T(6代三基色和全彩不支持)
        ///     0x02–AZ8921(6代三基色和全彩不支持)
        ///     0x03-BX-ZS
        ///     0x04- RS-BYH-M（气象组合传感器）（BX-QX）
        /// PM2.5：
        ///     0x00：空气质量变送器(RS-PM-N10-2) PM2.5（BX-PM）
        ///     0x01 :   气象组合传感器（RS-BYH-M）PM2.5（BX-QX）
        /// PM10：
        ///     0x00 – 空气质量变送器(RS-PM-N10-2) PM10(BX-PM)
        ///     0x01 :   气象组合传感器（RS-BYH-M）PM10（BX-QX）
        /// TSP：
        ///     0x00 – 空气质量变送器(RS-PM-N10-2) TSP(BX-PM)
        ///     0x01 :   气象组合传感器（RS-BYH-M）TSP（BX-QX）
        /// 风向变送器：
        ///     0x00 – RS485型风向变送器(RS-FX-N01) (BX-FX)
        /// 风速变换器：
        ///     0x00 – RS485型风速变换器(RS-FS-N01 )（BX-FS）
        /// 大气压力：
        ///     0X00 –RS-BYH-M（气象组合传感器）（BX-QX）
        /// 车速：
        ///     0X00 – TBR-300 (TBR-300)
        /// 光照：
        ///     0X00 –RS-BYH-M（气象组合传感器）（BX-QX）
        /// 水位计：
        ///     0X00 – YEH-Z(空高值,水位计LCD用L表示)
        ///     0X01 – YEH-Z(液位值,水位计LCD用H表示)
        ///     0X02 –WFX-40
        ///     0X03 –WLZ(L)  空高值
        ///     0X04 –WLZ(H)   液位值
        /// 负氧离子监测仪：
        ///     0x00 --  AN-210	
        /// </param>
        /// <param name="nSensorUnit">1 0x00 单位温度：0x00 –摄氏度 0x01 –华氏度;  水位计 0x00 –m, 0x01 –cm</param>
        /// <param name="pFixedTxt"></param>
        /// <param name="pFontName"></param>
        /// <param name="nFontSize"></param>
        /// <param name="nSensorColor">正常颜色；默认绿色=0x02；对于无灰度系统，均用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；</param>
        /// <param name="SensorErrColor1">报警颜色/超过阀值的颜色；红色=0x01；</param>
        /// <param name="nAlarmValue">报警值/阀值；默认60；</param>
        /// <param name="nSensorThreshPol"></param>
        /// <param name="nDisplayUnitFlag">是否显示单位 0：不显示; 1：显示; 默认=1;</param>
        /// <param name="nSensorModeDispType">显示模式; 0x00–整数模式; 默认=0x00;</param>
        /// <param name="nSensorCorrectionPol">传感器修正值极性 注： 0–正， 1–负; 默认=0x00；</param>
        /// <param name="nSensorCorrection">传感器修正值；默认=0x00；</param>
        /// <param name="nRatioValue">
        /// 单位显示比例：默认100；
        /// </param>
        /// <returns></returns>
        int BxDual_program_SetSensorArea_G6(ushort nAreaID, byte nSensorMode, byte nSensorType,
            byte nSensorUnit,
            byte[] pFixedTxt, byte[] pFontName, byte nFontSize,
            byte nSensorColor, byte SensorErrColor1, int nAlarmValue, byte nSensorThreshPol,
            byte nDisplayUnitFlag, byte nSensorModeDispType, byte nSensorCorrectionPol,
            int nSensorCorrection, byte nRatioValue);
        /// <summary>
        /// 设置5代卡温度区域属性
        /// </summary>
        /// <param name="nAreaID"></param>
        /// <param name="nSensorType">1		0x00	传感器类型：//0x00 – DS18B20 //0x01 – SHT1XXX //0x02:S-RHT2</param>
        /// <param name="nTemperatureUnit">1		0x00	温度单位：0x00–摄氏度; 0x01–华氏度</param>
        /// <param name="nTermperatureMode">1		0x00	温度显示模式：0x00 –整数模式(25C); 0x01 –小数模式(25.5C);</param>
        /// <param name="nTemperatureCorrectionPol">1 	0x00	传感器修正值极性 注：0 –正， 1 –负</param>
        /// <param name="nTemperatureCorrection">1 	0x00	传感器修正值（单位：摄氏度）注：此参数为符号整型，单位为0.1</param>
        /// <param name="nTemperatureThreshPol">1 	0x00	温度阈值极性 注：Bit0 –极性，0 正， 1 负; Bit1 - 0表示小于此值触发事情，1表示大于此值触发条件</param>
        /// <param name="nTemperatureThresh">1	0x00	温度阈值</param>
        /// <param name="nTemperatureColor">1			正常温度颜色;用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；</param>
        /// <param name="nTemperatureErrColor">1			温度超过阈值时显示的颜色</param>
        /// <param name="pstrFixTxt">1	固定文本选项 0x00–无固定文本; 0x01–有	</param>
        /// <param name="nFontSize"></param>
        /// <param name="pstrFontNameFile"></param>
        /// <param name="nUnitShowRation">显示的单位字体大小与正常显示文本的大小的比例；</param>
        /// <returns></returns>
        int BxDual_program_SetSensorAreaTemperature_G5(ushort nAreaID,
                                    byte nSensorType,
                                    byte nTemperatureUnit,
                                    byte nTermperatureMode,
                                    byte nTemperatureCorrectionPol,
                                    byte nTemperatureCorrection,
                                    byte nTemperatureThreshPol,
                                    byte nTemperatureThresh,
                                    byte nTemperatureColor,
                                    byte nTemperatureErrColor,
                                    byte[] pstrFixTxt,
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation
                                );
        /// <summary>
        /// nHumidityThresh：如果当湿度>100时作为触发条件，则此值=0x100+100; 如果当湿度小于100时作为触发条件，则此值=100;
        /// </summary>
        /// <param name="nAreaID"></param>
        /// <param name="nSensorType">1		传感器类型：0x00 –</param>
        /// <param name="nHumidityMode">1		显示模式：0x00 – % RH，整数型相对湿度; 0x01 –浮点型相对湿度;</param>
        /// <param name="nHumidityCorrectionPol">1		传感器修正值极性; 注：0 –正， 1 –负</param>
        /// <param name="nHumidityCorrection">1		传感器修正值; 注：单位为0.1	</param>
        /// <param name="nHumidityThresh">1		湿度阈值及触发条件; Bit0~Bit6 –湿度阈值; Bit7 – 0表示小于此值触发事情，1表示大于此值触发条件</param>
        /// <param name="nHumidityColor">
        /// 1		正常湿度颜色:	*  本文档中提及的颜色属性:
        /// 对于有灰度系统，均用4Byte来表示，其中Byte0表示红，Byte1表示绿，Byte2表示蓝，Byte3保留
        /// 对于无灰度系统，均用1Byte来表示，其中 Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
        /// </param>
        /// <param name="nHumidityErrColor">1		湿度超过阈值时显示的颜色</param>
        /// <param name="pstrFixTxt">1	固定文本选项 0x00–无固定文本; 0x01–有	</param>
        /// <param name="nFontSize"></param>
        /// <param name="pstrFontNameFile">显示的单位字体大小与正常显示文本的大小的比例；</param>
        /// <param name="nUnitShowRation"></param>
        /// <returns></returns>
        int BxDual_program_SetSensorAreaHumidity_G5(ushort nAreaID,
                                    byte nSensorType,
                                    byte nHumidityMode,
                                    byte nHumidityCorrectionPol,
                                    byte nHumidityCorrection,
                                    byte nHumidityThresh,
                                    byte nHumidityColor,
                                    byte nHumidityErrColor,
                                    byte[] pstrFixTxt,
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation
                                    );
        /// <summary>
        /// 设置5代卡噪声区域属性	
        /// </summary>
        /// <param name="nAreaID"></param>
        /// <param name="nSensorType">1				传感器类型：0x00 –嘉兴恒升; 0x01 –杭州爱华</param>
        /// <param name="nNoiseMode">1				显示模式：0x00 – 60.0dB; 0x01 – 60dB; 0x02–60.0; 0x03–60</param>
        /// <param name="nNoiseCorrectionPol">1				传感器修正值极性; 注：0 –正， 1 –负</param>
        /// <param name="nNoiseCorrection">1				传感器修正值; 注：此参数为符号整型，单位为0.1</param>
        /// <param name="nNoiseThresh">1				噪声阈值及触发条件; Bit0~Bit6 –噪声阈值; Bit7 – 0表示小于此值触发事情，1表示大于此值触发条件</param>
        /// <param name="nNoiseColor">1				正常噪声颜色</param>
        /// <param name="nNoiseErrColor">1				噪声超过阈值时显示的颜色</param>
        /// <param name="pstrFixTxt">1	固定文本选项 0x00–无固定文本; 0x01–有	</param>
        /// <param name="nFontSize"></param>
        /// <param name="pstrFontNameFile"></param>
        /// <param name="nUnitShowRation"> 显示的单位字体大小与正常显示文本的大小的比例；</param>
        /// <returns></returns>
        ///// <param name="FontData">字模数据，具体的字模格式，请参考附录1; （固定文本应整体当做一个字来处理）; 字模个数为13，其顺序依次为：0, …, 9, ., dB，固定文本;</param>
        int BxDual_program_SetSensorAreaNoise_G5(ushort nAreaID, byte nSensorType, byte nNoiseMode, byte nNoiseCorrectionPol, byte nNoiseCorrection, byte nNoiseThresh, byte nNoiseColor, byte nNoiseErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaID"></param>
        /// <param name="header"></param>
        /// <param name="cUnitDay"></param>
        /// <param name="cUnitHour"></param>
        /// <param name="cUnitMinute"></param>
        /// <param name="cUnitSec"></param>
        /// <param name="pFixedTxt"></param>
        /// <returns></returns>
        int BxDual_program_timeAreaAddCounterTimer_G6(ushort areaID, ref BXG6_Time_Counter header, byte[] cUnitDay, byte[] cUnitHour, byte[] cUnitMinute, byte[] cUnitSec, byte[] pFixedTxt);
    }
}
