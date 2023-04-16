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
        ///  网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
        ///  针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="retData">NetSearchCmdRet:参考结构体声明中的注释；</param>
        /// <param name="uartPort">串口号,如："COM3"</param>
        /// <param name="nBaudRateType">1：9600;   2：57600;</param>
        /// <returns></returns>
        int BxDual_cmd_uart_search_Net_6G(ref NetSearchCmdRet retData, byte[] uartPort, ushort nBaudRateType);
        /// <summary>
        /// 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
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
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsReedFileBlock（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName"></param>
        /// <param name="fileAddre"></param>
        /// <returns></returns>
        int BxDual_cmd_uart_ofsReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_confReedFileBlock(）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="fileName"></param>
        /// <param name="fileAddre"></param>
        /// <returns></returns>
        int BxDual_cmd_uart_confReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsReedDirBlock（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：下面两条命令搭配使用可以获取所有文件名
        * 注：
        * 下面两条命令用法比较复杂请配合协议使用不做嗷述
        ******************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="dirBlock"></param>
        /// <returns></returns>
        int BxDual_cmd_uart_ofsReedDirBlock(byte[] uartPort, byte baudRate, ref GetDirBlock_G56 dirBlock);
        /*! ***************************************************************
        * 函数名：  bxDual_cmd_ofs_freeDirBlock（）
        * 参数名：
        *	dirBlock: 上述两条命令所有使用的结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：释放cmd_ofsReedDirBlock所创建的节目列表dirBlock
        * 注：
        * dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
        ******************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirBlock"></param>
        /// <returns></returns>
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
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_sendConfigFile(）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        configData 请参考结构体ConfigFile
        * 返回值：0 成功， 其他值为错误号
        * 功 能：发送配置文件到控制器
        * 注：
        *
        ******************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="configData"></param>
        /// <returns></returns>
        int BxDual_cmd_uart_sendConfigFile(byte[] uartPort, byte baudRate, ref ConfigFile configData);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_programLock（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *         nonvolatile： 状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存
        *         lock：0x00 –解锁  0x01 –锁定
        *         name： 节目名称4（byte）个字节
        *         lockDuration: 节目锁定时间长度， 单位为 10 毫秒， 例
        *         如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目锁定
        * 注：
        * 具体使用方法参考协议
        ******************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uartPort">串口端口号</param>
        /// <param name="baudRate">波特率 1：9600;   2：57600;</param>
        /// <param name="nonvolatile"></param>
        /// <param name="locked"></param>
        /// <param name="name"></param>
        /// <param name="lockDuration"></param>
        /// <returns></returns>
        int BxDual_cmd_uart_programLock(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, uint lockDuration);
        int BxDual_cmd_uart_programLock_6G(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, int lockDuration);
        /*! ***************************************************************
        **  串口通讯命令 end **
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       cmd_AT_setWifiSsidPwd（）
        * 参数名：ssid：控制器WIFI ssid，pwd：控制WIFI密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置wifi卡的 ssid pwd
        * 注：
        * 通讯方式（UDP
        ******************************************************************/
        int BxDual_cmd_AT_setWifiSsidPwd(byte[] ssid, byte[] pwd);
        /*! ***************************************************************
        * 函数名：       cmd_AT_getWifiSsidPwd（）
        * 参数名：ssid：控制器WIFI ssid，pwd：控制WIFI密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取WIFI卡ssid pwd
        * 注：
        * 通讯方式（UDP）
        ******************************************************************/
        int BxDual_cmd_AT_getWifiSsidPwd(byte[] ssid, byte[] pwd);
        /*! ***************************************************************
        **  UDP通讯命令 **
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       cmd_udpNetworkSearch（）
        * 参数名：retData 请参考结构体heartbeatData 所有回读参数都会通过结构体回调
        * 返回值：0 成功， 其他值为错误号
        * 功 能：
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_udpNetworkSearch(ref HeartbeatData retData); //网络搜索
        /*! ********************************************************************************************************************
        * 函数名：cmd_udpNetworkSearch_6G（）
        * 参数名：retData : 存放网络搜索结果; 具体参考结构体:NetSearchCmdRet 声明中的注释；
        * 返回值：0 成功， 其他值为错误号;
        * 功  能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
        * 注：    针对 6代卡 的网络搜索命令
        ***********************************************************************************************************************/
        int BxDual_cmd_udpNetworkSearch_6G(ref NetSearchCmdRet retData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="retData"></param>
        /// <returns></returns>
        int BxDual_cmd_udpNetworkSearch_6G_Web(ref NetSearchCmdRet_Web retData);
        /*! ***************************************************************
        * 函数名：       cmd_udpPing（）
        * 参数名：retData 请参考结构体Ping_data 所有回读参数都会通过结构体回调
        * 返回值：0 成功， 其他值为错误号
        * 功 能：UDP ping 命令
        * 注：
        * 此命令用来搜索加屏使用
        ******************************************************************/
        int BxDual_cmd_udpPing(ref Ping_data retData); //UDP ping命令并返回IP地址
        /*! ***************************************************************
        * 函数名：       cmd_udpSetMac（）
        * 参数名：mac 传入的MAC地址
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置 MAC 地址命令
        * 注：
        * 需要修改MAC地址的时候调用
        ******************************************************************/
        int BxDual_cmd_udpSetMac(byte[] mac);
        /*! ***************************************************************
        * 函数名：       cmd_udpSetIP（）
        * 参数名
        byte mode; 控制器连接模式：
        0x00 –单机直连（PC 与控制器直接连
        接）
        0x01 –自动获取IP（DHCP）
        0x02 –手动设置IP（Static IP）
        0x03 –服务器模式（动态 IP）
        byte ip[] ； // 要设置的IP地址//设置IP
        byte subnetMask[] ; 子网掩码
        byte gateway[]; 默认网关
        short port; 端口号
        byte serverMode; 服务器模式
        byte serverIP[]; 服务IP
        short serverPort; 服务器端口号
        byte password[]; 服务器访问密码
        short heartbeat; 心跳间隔时间单位秒 默认值20
        byte netID[12]; 控制器网络ID
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置 IP 地址相关参数命令
        * 注：
        *  IP 地址 MAC地址都赋字符串 例：byte ip[] = "192.168.0.199"  具体使用细节请参考协议
        ******************************************************************/
        int BxDual_cmd_udpSetIP(byte mode, byte[] ip, byte[] subnetMask, byte[] gateway, short port, byte serverMode, byte[] serverIP, short serverPort, byte[] password, short heartbeat, byte[] netID);// 由于传入参数到内部都需要转换没有使用结构体
        /*! ***************************************************************
        /**UDP CMD END**/
        /*! ***************************************************************/
        /*! ***************************************************************
        /** TCP命令 控制器维护命令 **/
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       cmd_sysReset（）
        * 参数名：ip， 控制器IP， port 控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：让系统复位
        * 注：
        * 此命令调用后所有参数全部会丢失
        ******************************************************************/
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
        /*! ********************************************************************************************************************
        * 函数名：cmd_tcpNetworkSearch_6G（）
        * 参数名：ip：控制器IP， port：控制器端口;
        *		 命令结果放在了 retData 中；NetSearchCmdRet:参考结构体声明中的注释；
        * 返回值：0 成功， 其他值为错误号
        * 功 能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
        * 注：   针对 6代卡 的网络搜索命令
        ***********************************************************************************************************************/
        int BxDual_cmd_tcpNetworkSearch_6G(byte[] ip, ushort port, ref NetSearchCmdRet retData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="retData"></param>
        /// <returns></returns>
        int BxDual_cmd_tcpNetworkSearch_6G_Web(byte[] ip, ushort port, ref NetSearchCmdRet_Web retData);
        /*! ***************************************************************
        * 函数名：       cmd_coerceOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口，onOff：控制器状态：0x01 –开机 0x00 –关机
        * 返回值：0 成功， 其他值为错误号
        * 功 能：强制开挂机命令
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_coerceOnOff(byte[] ip, ushort port, byte onOff);
        /*!
         *  强制开关机（通过串口发送命令）
         *  sPortName : "\\\\.\\COM1";
         *  nBaudRateIndex: 1(表示波特率9600); 2(代表57600);
         */
        int BxDual_cmd_coerceOnOff_uart(byte[] sPortName, byte nBaudRateIndex, byte nOnOff);
        /*! ***************************************************************
        * 函数名：       cmd_timingOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口，groupNum：有几组定时开关机 data：TimingOnOff结构体的地址
        * 返回值：0 成功， 其他值为错误号
        * 功 能：定时开关机命令
        * 注：
        * groupNum值是n组情况,data大小 = n * TimingOnOff
        ******************************************************************/
        int BxDual_cmd_timingOnOff(byte[] ip, ushort port, byte groupNum, byte[] data);
        /*! ***************************************************************
        * 函数名：       cmd_cancelTimingOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：取消定时开关机
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_cancelTimingOnOff(byte[] ip, ushort port);
        /*! ***************************************************************
        * 函数名：       cmd_setBrightness（）
        * 参数名：ip：控制器IP， port：控制器端口， brightness：亮度度表
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置亮度和相关模式
        * 注：
        * 参考协议对应每一个表格，注意第一个字节模式的配置
        ******************************************************************/
        int BxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness);
        /*!
         *  通过串口调节亮度
         *  sPortName : "\\\\.\\COM1";
         *  nBaudRateIndex: 1(表示波特率9600); 2(代表57600);
         */
        int BxDual_cmd_setBrightness_uart(byte[] sPortName, byte nBaudRateIndex, ref Brightness brightness);
        /*! ***************************************************************
        * 函数名：       cmd_readControllerID（）
        * 参数名：ip：控制器IP， port：控制器端口， ControllerID：传回控制器ID
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读控制器ID
        * 注：
        * ControllerID是8个字节 请定义char data[8];
        ******************************************************************/
        int BxDual_cmd_readControllerID(byte[] ip, ushort port, byte[] ControllerID);
        /*! ***************************************************************
        * 函数名：       cmd_screenLock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *         nonvolatile：状态是否掉电保存 0x00 –掉电不保存 0x01 –掉电保存
        *         lock： 0x00 –解锁  0x01 –锁定
        * 返回值：0 成功， 其他值为错误号
        * 功 能：屏幕锁定
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_screenLock(byte[] ip, ushort port, byte nonvolatile, byte locked);
        /*! ***************************************************************
        * 函数名：       cmd_programLock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *         nonvolatile： 状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存
        *         lock：0x00 –解锁  0x01 –锁定
        *         name： 节目名称4（byte）个字节
        *         lockDuration: 节目锁定时间长度， 单位为 10 毫秒， 例
        *         如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目锁定
        * 注：
        * 具体使用方法参考协议
        ******************************************************************/
        int BxDual_cmd_programLock(byte[] ip, ushort port, byte nonvolatile, byte locked, byte[] name, uint lockDuration);
        /*! ***************************************************************
        * 函数名：       cmd_check_controllerStatus（）
        * 参数名：ip：控制器IP， port：控制器端口， controllerStatus：请参考结构体ControllerStatus_G56
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读控制器状态
        * 注：
        * ControllerStatus_G56和协议时对应的可以参考协议的具体用法
        ******************************************************************/
        int BxDual_cmd_check_controllerStatus(byte[] ip, ushort port, ref ControllerStatus_G56 controllerStatus);
        /*! ***************************************************************
        * 函数名：       cmd_setPassword（）
        * 参数名：ip：控制器IP， port：控制器端口， oldPassword：老密码， newPassword新密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制器密码
        * 注：
        * 设置后一定要记住，设置后就不在能明码通讯
        ******************************************************************/
        int BxDual_cmd_setPassword(byte[] ip, ushort port, byte[] oldPassword, byte[] newPassword);
        /*! ***************************************************************
        * 函数名：       cmd_deletePassword（）
        * 参数名：ip：控制器IP， port：控制器端口， password：输出当前控制密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除当前控制器密码
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_deletePassword(byte[] ip, ushort port, byte[] password);
        /*! ***************************************************************
        * 函数名：       cmd_setDelayTime（）
        * 参数名：ip：控制器IP， port：控制器端口， delayTime：开机延时单位秒
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制开机延时时间
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_setDelayTime(byte[] ip, ushort port, short delayTime);
        /*! ***************************************************************
        * 函数名：       cmd_setBtnFunc（）
        * 参数名：ip：控制器IP， port：控制器端口， btnMode：按钮模式 0x00–测试按钮 0x01 –沿触发切换节目 0x02 –电平触发切换节目
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制测试按钮功能
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_setBtnFunc(byte[] ip, ushort port, byte btnMode);
        /*! ***************************************************************
        * 函数名：       cmd_setTimingReset（）
        * 参数名：ip：控制器IP， port：控制器端口， cmdData：参考结构体TimingReset
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制重启重启时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_setTimingReset(byte[] ip, ushort port, ref TimingReset cmdData);
        /*! ***************************************************************
        * 函数名：       cmd_setDispMode（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		dispMode：控制器的显示模式（目前只针对 BX-5E系列控制器）
        *		Bit0 –串/并行， 0 表示并行， 1 表示并行
        *		Bit1–同步使能， 1 使能同步， 0 禁止同步
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制重启重启时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_setDispMode(byte[] ip, ushort port, byte dispMode);
        /*! ***************************************************************
        * 函数名：       cmd_battieTime（）
        * 参数名：ip：控制器IP， port：控制器端口，
        *	mode：战斗时间控制命令
        *		0x00:启动战斗时间
        *		0x01:暂停战斗时间
        *		0x02:复位战斗时间
        *	battieData： 命令回读参数请参考结构体BattleTime
        * 返回值：0 成功， 其他值为错误号
        * 功 能：战斗时间管理命令
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_battieTime(byte[] ip, ushort port, byte mode, ref BattleTime battieData);
        /*! ***************************************************************
        * 函数名：       cmd_getStopwatch（）
        * 参数名：ip：控制器IP， port：控制器端口，
        *	mode：秒表控制命令
        *		0x00:启动秒表
        *		0x01:暂停秒表
        *		0x02:复位秒表
        *	timeValue：回读回来的当前秒表时间单位毫秒
        * 返回值：0 成功， 其他值为错误号
        * 功 能：秒表控制并获取秒表时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_getStopwatch(byte[] ip, ushort port, byte mode, ref int timeValue);
        /*! ***************************************************************
        * 函数名：       cmd_getSensorBrightnessValue（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		brightnessValue：当前亮度传感器值
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取亮度读传感器值
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_getSensorBrightnessValue(byte[] ip, ushort port, ref int brightnessValue);
        /*! ***************************************************************
        * 函数名：       cmd_setSpeedAdjust（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		speed：速度微调参数值
        该值以 0.1 毫秒为单位， 共 256 级， 上
        位机下发时该值为 0-255， 这样刚好使
        用一个低位字节， 高位字节为 0， 留作
        以后扩展使用。 下位机根据该参数在每
        次循环中延时相应的时间， 以改善 LED
        屏幕的显示效果。 当该参数为 0 时， 下
        位机延时为 0， 该参数为 1 时， 下位机
        延时 0.1 毫秒， 以此类推
        * 返回值：0 成功， 其他值为错误号
        * 功 能：速度微调命令
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_setSpeedAdjust(byte[] ip, ushort port, short speed);
        /*! ***************************************************************
        * 函数名：       cmd_setScreenAddress（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		address：屏幕号
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置屏幕号
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        int BxDual_cmd_setScreenAddress(byte[] ip, ushort port, short address);
        /** TCP OFS_CMD**/
        /*! ***************************************************************
        * 函数名：       cmd_ofsFormat（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：文件系统格式化
        * 注：
        * 具体细节参考协议
        ******************************************************************/
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
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsDeleteFormatFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        int BxDual_cmd_ofsDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_confDeleteFormatFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        int BxDual_cmd_confDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsGetMemoryVolume（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	totalMemVolume：全部空间大小
        *	availableMemVolume：剩余空间大小
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取控制空间大小和剩余空间
        * 注：
        * 发节目前需要查询防止空间不够用
        ******************************************************************/
        int BxDual_cmd_ofsGetMemoryVolume(byte[] ip, ushort port, ref int totalMemVolume, ref int availableMemVolume);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsWriteFile（）
        * 参数名：ip：， port：
        *	fileName：
        *	fileType：
        *	fileLen：
        *	fileAddre：
        *	overwrite：
        * 返回值：
        * 功 能：
        * 
        * 
        ******************************************************************/
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
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsWriteFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        int BxDual_cmd_confWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsStartReedFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileSize：回读文件大小
        *	fileCrc：回读的文件CRC
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始读文件
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_ofsStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_confStartReedFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileSize：回读文件大小
        *	fileCrc：回读的文件CRC
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始读文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        *
        ******************************************************************/
        int BxDual_cmd_confStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsReedFileBlock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * fileAddre大小根据bxDual_cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        int BxDual_cmd_ofsReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_confReedFileBlock(）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * fileAddre大小根据bxDual_cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        int BxDual_cmd_confReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsReedDirBlock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	dirBlock: 读会的文件列表，具体的具体参考GetDirBlock_G56结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取文件列表
        * 注：
        * 下面几条命令用法比较复杂请配合协议使用不做嗷述
        ******************************************************************/
        int BxDual_cmd_ofsReedDirBlock(byte[] ip, ushort port, ref GetDirBlock_G56 dirBlock);
        /*! ***************************************************************
        * 函数名：  bxDual_cmd_getFileAttr（）
        * 参数名：
        *	dirBlock: 上一条命令的回传结构体
        *	number: 要获取的第几个文件的属性
        *	fileAttr： 获取到的文件属性存放位置参考结构体FileAttribute_G56；
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取指定文件的属性
        * 注：
        * number：此参数值小于fileAttr.fileName 从0开始
        ******************************************************************/
        int BxDual_cmd_getFileAttr(ref GetDirBlock_G56 dirBlock, ushort number, ref FileAttribute_G56 fileAttr);
        /*! ***************************************************************
        * 函数名：  bxDual_cmd_ofs_freeDirBlock（）
        * 参数名：
        *	dirBlock: 上述两条命令所有使用的结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：释放bxDual_cmd_ofsReedDirBlock所创建的节目列表dirBlock
        * 注：
        * dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
        ******************************************************************/
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
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_firmwareActivate（）
        * 参数名：ip：控制器IP， port：控制器端口，firmwareFileName要激活的固件名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：激活指定固件
        * 注：
        * firmwareFileName 缺省值为4个字节字符串“F001”
        ******************************************************************/
        int BxDual_cmd_firmwareActivate(byte[] ip, ushort port, byte[] firmwareFileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_sendConfigFile(）
        * 参数名：ip：控制器IP， port：控制器端口
        configData 请参考结构体ConfigFile
        * 返回值：0 成功， 其他值为错误号
        * 功 能：发送5代卡配置文件到控制器
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_sendConfigFile(byte[] ip, ushort port, ref ConfigFile configData);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_sendConfigFile_G6(）
        * 参数名：ip：控制器IP， port：控制器端口
        configData 请参考结构体ConfigFile
        * 返回值：0 成功， 其他值为错误号
        * 功 能：发送5代卡配置文件到控制器
        * 注：
        *
        ******************************************************************/
        int BxDual_cmd_sendConfigFile_G6(byte[] ip, ushort port, ref ConfigFile_G6 configData);
        /*! ***************************************************************
        /** TCP命令 END **/
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       get_crc16（）
        * 参数名：
        * 返回值：0 成功， 其他值为错误号
        * 功 能：用来计算CRC16值
        * 注：
        ******************************************************************/
        int BxDual_get_crc16(ref FileCRC16_G56 crc16);
        /*! ***************************************************************
        * 函数名：       get_crc32（）
        * 参数名：
        * 返回值：0 成功， 其他值为错误号
        * 功 能：用来计算CRC32值
        * 注：
        ******************************************************************/
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
        /// 
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
        int BxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor); //设置屏相关属性
        //int  BxDual_program_setScreenParams_G6(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addProgram（）
        *	programH：参考结构体EQprogramHeader
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目句柄
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_addProgram(ref EQprogramHeader programH);
        //添加节目句柄
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeProgramParams（）
        *	programH：参考结构体EQprogramHeader
        * 返回值：0 成功， 其他值为错误
        * 功 能：修改已添加节目的一些参数
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_changeProgramParams(ref EQprogramHeader programH);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addPlayPeriodGrp（）
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目播放时段
        * 注：
        *
        ******************************************************************/
        int BxDual_program_addPlayPeriodGrp(ref EQprogramppGrp_G56 header);
        /*! ***************************************************************
        * 函数名：       bxDual_program_AddArea（）
        * 参数名：
        *	areaID：区域的ID号
        *	aheader：参考结构体EQareaHeader
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加区域句柄
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_AddArea(ushort areaID, ref EQareaHeader aheader);//添加区域句柄
        /*! ***************************************************************
        * 函数名：       bxDual_program_deleteArea（）
        * 参数名：
        *	areaID：区域的ID号
        * 返回值：0 成功， 其他值为错误号
        * 功 能：用来删除编号为areaID的区域
        * 注：
        *
        ******************************************************************/
        int BxDual_program_deleteArea(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddTxt（）
        *	areaID：区域的ID号
        *	str：需要画的字符
        *	fontName：字体名称
        *	pheader：参考结构体EQpageHeader
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：画字符到图文区
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader pheader);//画字符到区域
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaChangeTxt（）
        *	areaID：区域的ID号
        *	str：需要画的字符
        *	pheader：参考结构体EQpageHeader
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改图文区域内容
        * 注：
        * 只可以修改文字内容和EQpageHeader结构体里面的参数，不可以修改字体，如需修改，需要删除区域后重新添加文本设置字体
        ******************************************************************/
        int BxDual_program_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaAddTxt（）
        *	areaID：区域的ID号
        *	str：需要画的字符
        *	fontPathName：字体绝对路径加字库文件名称
        *	pheader：参考结构体EQpageHeader
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区添加字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_fontPath_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaChangeTxt（）
        *	areaID：区域的ID号
        *	str：需要更换的字符串
        *	pheader：参考结构体EQpageHeader
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区修改字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_fontPath_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_IntegrateProgramFile（）
        * 参数名：
        *	program：参考结构体EQprogram
        * 返回值：0 成功， 其他值为错误号
        * 功 能：合成节目文件返回节目文件属性及地址
        * 注：
        * EQprogram 结构体是用来回调发送文件所需要参数
        ******************************************************************/
        int BxDual_program_IntegrateProgramFile(ref EQprogram program);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddFrame(）
        * 参数名：areaID：区域的ID号
        *	EQareaframeHeader：参考结构体EQareaframeHeader
        *   picPath: 边框图片文件的路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：区域添加边框
        * 注：
        *
        ******************************************************************/
        int BxDual_program_picturesAreaAddFrame(ushort areaID, ref EQareaframeHeader afHeader, byte[] picPath);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaID"></param>
        /// <param name="afHeader"></param>
        /// <param name="picPath"></param>
        /// <returns></returns>
        int BxDual_program_picturesAreaAddFrame_G6(ushort areaID, ref EQscreenframeHeader_G6 afHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaGetOnePage(）
        * 参数名：
        *	areaID：区域ID
        *   pageNum: 第几页，从0开始计算
        * 返回值：0 成功， 其他值为错误号
        * 功 能：返回区域第n张图片
        * 注：
        *
        ******************************************************************/
        int BxDual_program_pictureAreaGetOnePage(ushort areaID, int pageNum, ref GetPageData pageData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddPic（）
        *	areaID：区域的ID号
        *   picID：图片的ID号
        *	EQpageHeader：参考结构体EQpageHeader
        *	picPath：添加的图片路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到区域
        * 注：
        *
        ******************************************************************/
        int BxDual_program_pictureAreaAddPic(ushort areaID, ushort picID, ref EQpageHeader pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addFrame（）
        *	EQscreenframeHeader：参考结构体EQscreenframeHeader
        *	picPath：添加的边框图片路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目添加边框
        * 注：
        *
        ******************************************************************/
        int BxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeFrame（）
        *	EQscreenframeHeader：参考结构体EQscreenframeHeader
        *	picPath：边框图片路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目修改已添加边框的一些参数
        * 注：
        *
        ******************************************************************/
        int BxDual_program_changeFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_removeFrame（）
        *
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目去掉边框
        * 注：
        *
        ******************************************************************/
        int BxDual_program_removeFrame();
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaRemoveFrame（）
        *	areaID：区域的ID号
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：区域去掉边框
        * 注：
        *
        ******************************************************************/
        int BxDual_program_pictureAreaRemoveFrame(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_MoveArea()
        *	areaID：区域的ID号
        *   x:区域left坐标
        *   y:区域top坐标
        *   width:区域宽度
        *   height:区域高度
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：改变区域坐标大小
        * 注：
        *
        ******************************************************************/
        int BxDual_program_MoveArea(ushort areaID, int x, int y, int width, int height);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddContent()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_timeAreaAddContent()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容EQtimeAreaData::fontName == 字库名称
        * 注：ios下无法使用program_timeAreaAddContent请使用program_fontPath_timeAreaAddContent()
        *
        ******************************************************************/
        int BxDual_program_fontPath_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeContent()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区修改内容EQtimeAreaData::fontName == 字库的路径加字库文件名（字库地址）
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaChangeContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaGetOnePage(）
        * 参数名：
        *	areaID：区域ID
        *   pageNum: 第几页，从0开始计算
        * 返回值：0 成功， 其他值为错误号
        * 功 能：返回时间区域第n张图片
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaGetOnePage(ushort areaID, ref GetPageData pageData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddAnalogClock(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加模拟时钟
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaAddAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeAnalogClock(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区修改模拟时钟的一些设置参数
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaChangeAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeDialPic(）
        * 参数名：
        *	areaID： 区域ID
        *   picPath: 表盘图片位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区从外部添加表盘图片
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaChangeDialPic(ushort areaID, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeDialPicAdd_G56(）
        * 参数名：
        *	areaID： 区域ID
        *   picPath: 表盘图片位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区从外部添加表盘图片
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaChangeDialPicAdd_G56(ushort areaID, byte[] picAdd, int picLen);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaRemoveDialPic(）
        * 参数名：
        *	areaID：区域ID
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区移除外部添加的表盘图片
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaRemoveDialPic(ushort areaID);
        //6代控制卡动态区功能开始:=================================
        /*
        功能：设置动态区颜色像素类型：R+G 或 G+R
        */
        int BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56 ePixelRGorGR);
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        功能说明：6代更新动态区最基本功能：仅显示动态区：即不与节目一起显示，如果当前有节目显示，调用此函数后，LED屏幕上会清空原来的内容，显示此函数中 strAreaTxtContent 参数的内容；
                 如果要与屏幕上原来显示的节目一起显示，请调用下面的 动态区文本关联节目 函数；与节目一起显示时，要注意动态区域与原来的节目区域不能重叠！
        参数说明：
        pIP,nPort	  :（与控制卡直连时）控制卡IP; 端口号;
                       （通过服务端连时）服务端IP;服务端返回的控制卡对应的端口号;
        color		  :LED屏颜色类型，详见 E_ScreenColor_G56 声明；
        uAreaId		  :区域号; 如果控制卡只支持4个动态区，则uAreaId的取值范围：0-3；共4个；且只能是0-3之间的值；
        uAreaX,uAreaY :显示区域坐标，即动态区域左上角在LED显示屏的位置/坐标；如：（0，0）则是从LED显示屏幕的最左上角开始显示动态区域；
                       注意:不同控制卡的最小LED屏宽不同，如BX-6E2X最小屏宽为80个显示单位，所以连接的LED屏如果只有64宽度，则在坐标为（0，0）且是靠左显示的情况下，最左边的16个单元会显示不完整；
                       此时，可以考虑设置起始点X的坐标为16，即(16，0),此时宽高为(80-16,高);
        uWidth,uHeight:动态区域的宽度，高度;
        fontName	  :字体名称，如"宋体";  nFontSize:字体大小，如12;
        strAreaTxtContent:要显示的文本内容
        -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        int BxDual_dynamicArea_AddAreaTxt_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY,
            ushort uWidth, ushort uHeight, IntPtr fontName, byte nFontSize, IntPtr strAreaTxtContent);
        //6代更新动态区详细功能：仅显示动态区; 将要显示的一些特性/属性，封装在 EQareaHeader_G6 和 EQpageHeader_G6 结构体中；
        int BxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);
        /*
        功能说明	：6代更新动态区详细功能：仅显示动态区;
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        int BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);
        //动态区文本关联节目: 
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        int BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：动态区关联节目
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        int BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);
        //更新动态区图片：仅显示动态区;
        int BxDual_dynamicArea_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);
        /*
        功能说明：更新动态区图片：仅显示动态区;
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        int BxDual_dynamicArea_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);
        //动态区图片关联节目: 
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        int BxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：动态区图片关联节目:
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        RelateProNum			: RelateProNum == 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
                                  RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        */
        int BxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);
        //同时更新多个动态区:仅显示动态区，不显示节目
        int BxDual_dynamicAreaS_AddTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /*
        功能说明：同时更新多个动态区文本:仅显示动态区，不显示节目;
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        int BxDual_dynamicAreaS_AddTxtDetails_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        //同时更新多个动态区文本:并与节目关联，即与节目一起显示
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        int BxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：同时更新多个动态区文本:并与节目关联，即与节目一起显示
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        ushort RelateProNum	: = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
                                  > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        */
        int BxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        //同时更新多个动态区图片：仅显示动态区图片;不与节目关联/不与节目一起显示；
        int BxDual_dynamicAreaS_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /*
        功能说明：同时更新多个动态区图片;仅显示动态区图片/不与节目关联/不与节目一起显示；
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        int BxDual_dynamicAreaS_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        //同时更新多个动态区图片，并与节目关联，即与节目一起显示；
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        int BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：同时更新多个动态区图片，并与节目关联，即与节目一起显示；
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        ushort RelateProNum	: = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
                                  > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        */
        int BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：TCP
        参数	说明	：
                pIP		:控制卡IP地址，如"192.168.1.111";
                nPort	:控制卡默认TCP方式的端口号为:5005
        */
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
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
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
        /*
        功能说明：一次向一个动态区发送/更新多条信息（文字或图片）及语音
        参数说明：
                RunMode:			动态区运行模式 
                                    //0— 动态区数据循环显示。
                                    //1— 动态区数据显示完成后静止显示最后一页数据。
                                    //2— 动态区数据循环显示，超过设定时间后数据仍未更新时不再显示
                                    //3— 动态区数据循环显示，超过设定时间后数据仍未更新时显示Logo 信息, Logo 信息即为动态区域的最后一页信息4— 动态区数据顺序显示，显示完最后一页后就不再显示
                Timeout: 动态区数据超时时间，单位为秒;该动态区显示时长超过这个值的时间(s)，会自动删除，仅部分卡类型支持；未试过；
                RelateAllPro: 当该字节为 1 时，所有异步节目播放时都允许播放该动态区域；为 0 时，由接下来的规则来决定
                RelateProNum: 动态区域关联了多少个异步节目一旦关联了某个异步节目，则当该异步节目播放时允许播放该动态区域，否则，不允许播放该动态区域
                RelateProSerial:  动态区域关联的节目编号；
                pSoundData: 语音内容；默认为空不发送语音；
                *参数详细说明参考《6th 动态区域用户手册》
        返回值：0 成功；-1 失败；
        */
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
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
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
        /*
        功能：TCP方式删除动态区
        删除动态区：删除单个动态区：
        uAreaId = 0xff:删除所有区域
        */
        int BxDual_dynamicArea_DelArea_6G(byte[] pIP, int nPort, byte uAreaId);
        /*
        功能：TCP方式删除多个动态区：
        参数：
        pAreaID-存放要删除的动态区ID数组；
        uAreaCount-动态区ID数组中的个数；
        */
        int BxDual_dynamicArea_DelAreas_6G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);
        /*
        功能：串口方式删除动态区
        删除动态区：删除单个动态区：
        uAreaId = 0xff:删除所有区域
        */
        int BxDual_dynamicArea_DelArea_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);
        /*
        功能：串口方式删除多个动态区：
        参数：
        pAreaID-存放要删除的动态区ID数组；
        uAreaCount-动态区ID数组中的个数；
        */
        int BxDual_dynamicArea_DelAreas_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);
        /*
        功能：插入独立语音
        参数：
        byte VoiceFlg;		//1 1 语音属性 0：此条语音从头插入队列，且停止当前正在播放的语音 1：此条语音从头插入队列，不停止当前播报的语音 2：此条语音从尾插入队列
        byte StoreFlag;		//1 0 该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失该值为 0 表示需要存储到 RAM 中，掉电信息丢失
        */
        int BxDual_dynamicArea_InsertSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, byte VoiceFlg, byte StoreFlag);
        /*
        功能：5.4.3 更新独立语音命令
        stSoundData：指向存放EQSoundDepend_6G结构的一段内存首地址指针；
        nSoundDataCount:指示stSoundData指向内存地址空间中存放EQSoundDepend_6G个数；
        StoreFlag:该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失;该值为 0 表示需要存储到 RAM 中，掉电信息丢失
        */
        int BxDual_dynamicArea_UpdateSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, ushort nSoundDataCount, byte StoreFlag);
        //6代控制卡动态区功能结束.=======================
        //5代控制卡动态区功能开始:===============================
        /*
        功能说明：发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；其它参考信息参见 上面的 6代控制卡动态区功能 函数 bxDual_dynamicArea_AddAreaTxt_6G 上面的说明；
        参数说明：
        strAreaTxtContent - 动态区域内要显示的文本内容
        */
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
            //显示内容和字体格式 begin---------
            EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
        /*
        功能说明：发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
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
            //显示内容和字体格式 begin---------
            EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
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
            //显示内容和字体格式 begin---------
            ref EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
        /*
        功能说明：发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
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
            //显示内容和字体格式 begin---------
            ref EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
        /*
        功能说明：发送一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
        */
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
            //图片路径 begin---------
            byte[] filePath
        //end.
        );
        /*
        功能说明：发送一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
            pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
            nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        函数返回：
            0	：成功；
            -1	：失败；
        */
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
            //图片路径 begin---------
            byte[] filePath
        //end.
        );
        /*
        功能说明：发送多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        */
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
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        */
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
        /*
        功能说明：发送多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
            pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
            nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        函数返回：
            0	：成功；
            -1	：失败；
        */
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
        /*
        功能：删除单个动态区：
        参数：uAreaId = 0xff:删除所有区域
        */
        int BxDual_dynamicArea_DelArea_5G(byte[] pIP, int nPort, byte uAreaId);
        /*
        功能：删除多个动态区：
        */
        int BxDual_dynamicArea_DelAreaS_5G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);
        /*
        功能：串口方式删除动态区
        删除动态区：删除单个动态区：
        uAreaId = 0xff:删除所有区域
        */
        int BxDual_dynamicArea_DelArea_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);
        /*
        功能：串口方式删除多个动态区：
        参数：
        pAreaID-存放要删除的动态区ID数组；
        uAreaCount-动态区ID数组中的个数；
        */
        int BxDual_dynamicArea_DelAreaS_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);
        //5代控制卡动态区功能结束:===========================
        /*****************************以下为六代接口*******************************************/
        /// <summary>
        /// 添加节目
        /// </summary>
        /// <param name="programH">参考结构体<see cref="EQprogramHeader_G6"/></param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_addProgram_G6(ref EQprogramHeader_G6 programH);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addPlayPeriodGrp_G6（）
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目播放时段
        * 注：
        *
        ******************************************************************/
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
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeProgramParams_G6（）
        *	EQprogramHeader_G6：参考结构体EQprogramHeader_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改已添加节目的一些参数
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_changeProgramParams_G6(ref EQprogramHeader_G6 programH);
        /// <summary>
        /// 节目添加边框
        /// 注：节目添加边框后，区域的坐标随即发生变化，添加区域的时候需注意
        /// </summary>
        /// <param name="sfHeader">参考结构体<see cref="EQscreenframeHeader_G6"/></param>
        /// <param name="picPath">添加的边框图片路径</param>
        /// <returns>0 成功， -1 不成功</returns>
        int BxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeFrame_G6（）
        *	sfHeader：参考结构体EQscreenframeHeader_G6
        *	picPath：边框图片路径
        * 返回值：0 成功， -1 不成功
        * 功 能：节目修改已添加边框的一些参数
        * 注：
        *
        ******************************************************************/
        int BxDual_program_changeFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_removeFrame_G6（）
        * 返回值：0 成功
        * 功 能：节目去掉边框
        * 注：
        *
        ******************************************************************/
        int BxDual_program_removeFrame_G6();
        /*! ***************************************************************
        * 函数名：       bxDual_program_addArea_G6（）
        * 参数名：areaID：区域的ID号
        *	aheader：参考结构体EQareaHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目添加区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_addArea_G6(ushort areaID, ref EQareaHeader_G6 aheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_deleteArea_G6（）
        * 参数名：
        *   areaID：区域ID号
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目删除已添加的区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_deleteArea_G6(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_MoveArea_G6()
        *	areaID：区域的ID号
        *   x:区域left坐标
        *   y:区域top坐标
        *   width:区域宽度
        *   height:区域高度
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：改变区域坐标大小
        * 注：
        *
        ******************************************************************/
        int BxDual_program_MoveArea_G6(ushort areaID, int x, int y, int width, int height);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	fontName：字体名称
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：画文字到图文区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaChangeTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改图文区域已添加过的文字内容及EQpageHeader_G6结构体中的参数
        * 注：
        * 如需修改字体，需要将区域删除，重新添加区域和文字
        ******************************************************************/
        int BxDual_program_picturesAreaChangeTxt_G6(ushort areaID, IntPtr str, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaAddTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	fontPathName：字体绝对路径加字库文件名称
        *	pheader：参考结构体EQpageHeader_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区添加字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_fontPath_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaChangeTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区修改字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        int BxDual_program_fontPath_picturesAreaChangeTxt_G6(ushort areaID, byte[] str, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaAddPic_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	picPath：图片的绝对路径加图片名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到图文区域
        * 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        *
        ******************************************************************/
        int BxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_backGroundPic_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	picPath：图片的绝对路径加图片名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到图文区域
        * 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        *
        ******************************************************************/
        int BxDual_program_backGroundPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_backGroundColor_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	BGColor：区域背景颜色值（RGB888）
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到图文区域
        * 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        *
        ******************************************************************/
        int BxDual_program_backGroundColor_G6(ushort areaID, ref EQpageHeader_G6 pheader, int BGColor);
        /*! **************************************************************** 函数名：       bxDual_program_pictureAreaChangePic_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，传入需要修改的图片编号
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	picPath：图片的绝对路径加图片名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改当前picID对应的图片和一些参数
        * 注：
        *
        ******************************************************************/
        int BxDual_program_pictureAreaChangePic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaEnableSound_G6（）
        *	areaID：区域的ID号
        *	sheader：参考结构体EQPicAreaSoundHeader_G6
        *   soundData:语音数据
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：图文分区使能语音播放
        * 注：
        *
        ******************************************************************/
        int BxDual_program_pictureAreaEnableSound_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaChangeSoundSettings_G6（）
        *	areaID：区域的ID号
        *	sheader：参考结构体EQPicAreaSoundHeader_G6
        *   soundData:语音数据
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：图文分区修改语音播放的一些参数或数据
        * 注：
        *
        ******************************************************************/
        int BxDual_program_pictureAreaChangeSoundSettings_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaDisableSound_G6（）
        *	areaID：区域的ID号
        *
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：图文分区取消语音播放
        * 注：
        *
        ******************************************************************/
        int BxDual_program_pictureAreaDisableSound_G6(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaSetBattleTime_G6（）
        *	areaID：区域的ID号
        *   header：参考结构体EQTimeAreaBattle_G6
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区设置战斗时间和战斗时间的启动模式
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaSetBattleTime_G6(ushort areaID, ref EQTimeAreaBattle_G6 header);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaCancleBattleTime_G6（）
        *	areaID：区域的ID号
        *
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区取消战斗时间
        * 注：取消后的时间分区将作为普通时间
        *
        ******************************************************************/
        int BxDual_program_timeAreaCancleBattleTime_G6(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddContent_G6（）
        *	areaID：区域的ID号
        *   timeData：参考结构体EQtimeAreaData_G56
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区添加时间等内容，详情请参考结构体EQtimeAreaData_G56
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeContent_G6（）
        *	areaID：区域的ID号
        *   timeData：参考结构体EQtimeAreaData_G56
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区修改时间等内容，详情请参考结构体EQtimeAreaData_G56
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaChangeContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_timeAreaAddContent_G6()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容EQtimeAreaData::fontName == 字库名称
        * 注：ios下无法使用program_timeAreaAddContent_G6请使用program_fontPath_timeAreaAddContent_G6()
        *
        ******************************************************************/
        int BxDual_program_fontPath_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddAnalogClock_G6(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加模拟时钟
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeAnalogClock_G6(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区修改模拟时钟的一些设置参数
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaChangeAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeDialPic_G6(）
        * 参数名：
        *	areaID： 区域ID
        *   picPath: 表盘图片位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区从外部添加表盘图片
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaChangeDialPic_G6(ushort areaID, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaRemoveDialPic_G6(）
        * 参数名：
        *	areaID： 区域ID
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区移除添加的表盘图片
        * 注：
        *
        ******************************************************************/
        int BxDual_program_timeAreaRemoveDialPic_G6(ushort areaID);
        /// <summary>
        /// 合成节目文件返回节目文件属性及地址
        /// 注：EQprogram 结构体是用来回调发送文件所需要参数
        /// </summary>
        /// <param name="program">参考结构体EQprogram_G6</param>
        /// <returns>0 成功， 其他值为错误号</returns>
        int BxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program);
        /*!
        *  功能：配置传感器区域的参数
        *  
        *  SensorMode	1byte	默认=0；
        *						0：代表温度
                                1：代表湿度
                                2：代表噪声
                                3：代表PM2.5（空气质量变送器）
                                4：代表PM10（空气质量变送器）
                                5：RS485型风向变送器
                                6：RS485型风速变换器
                                7：大气压力
                                8：车速
                                9：光照
                                10：0x0A：水位计
                                11：0x0B: 代表TSP
                                12：0x0C: 负氧离子监测仪
                                0xff：万能传感器，该类型是BX-6XX-MODBUS系列专用类型，当传感器类型为该值时，下面的SensorType、SensorUnit、DisplayUnitFlag均设置为0，对于通用系列控制卡，该值为非0xff的值;
            SensorType	传感器类型;默认长度/值： 1 0x00 
                                温度：
                                    0x00 – DS18B20（温度传感器）
                                    0x01 – SHT11(6 代三基色和全彩不支持)（I 温湿度传感器(4 线)
                                    0X02 – DHT21（II 温湿度传感器(3 线)）
                                    0X03 – RS-BYH-M（气象组合传感器）（BX-QX）
                                湿度：
                                    0x00 – SHT11(6代三基色和全彩不支持)（I温湿度传感器(4线)
                                    0x01 –DHT21（II温湿度传感器(3线)）
                                    0X02 –RS-BYH-M（气象组合传感器 ）（BX-QX）
                                噪声：
                                    0x00 –AWA5636-3(6代三基色和全彩不支持)
                                    0x01 –HS5633T(6代三基色和全彩不支持)
                                    0x02–AZ8921(6代三基色和全彩不支持)
                                    0x03-BX-ZS
                                    0x04- RS-BYH-M（气象组合传感器）（BX-QX）
                                PM2.5：
                                    0x00：空气质量变送器(RS-PM-N10-2) PM2.5（BX-PM）
                                    0x01 :   气象组合传感器（RS-BYH-M）PM2.5（BX-QX）
                                PM10：
                                    0x00 – 空气质量变送器(RS-PM-N10-2) PM10(BX-PM)
                                    0x01 :   气象组合传感器（RS-BYH-M）PM10（BX-QX）
                                TSP：
                                    0x00 – 空气质量变送器(RS-PM-N10-2) TSP(BX-PM)
                                    0x01 :   气象组合传感器（RS-BYH-M）TSP（BX-QX）
                                风向变送器：
                                    0x00 – RS485型风向变送器(RS-FX-N01) (BX-FX)
                                风速变换器：
                                    0x00 – RS485型风速变换器(RS-FS-N01 )（BX-FS）
                                大气压力：
                                    0X00 –RS-BYH-M（气象组合传感器）（BX-QX）
                                车速：
                                    0X00 – TBR-300 (TBR-300)
                                光照：
                                    0X00 –RS-BYH-M（气象组合传感器）（BX-QX）
                                水位计：
                                    0X00 – YEH-Z(空高值,水位计LCD用L表示)
                                    0X01 – YEH-Z(液位值,水位计LCD用H表示)
                                    0X02 –WFX-40
                                    0X03 –WLZ(L)  空高值
                                    0X04 –WLZ(H)   液位值
                                负氧离子监测仪：
                                    0x00 --  AN-210
            nSensorColor		正常颜色；默认绿色=0x02；对于无灰度系统，均用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
            SensorAlarmColor	报警颜色/超过阀值的颜色；红色=0x01；
            nAlarmValue			报警值/阀值；默认60；
            nDisplayUnitFlag	是否显示单位 0：不显示; 1：显示; 默认=1;
            nSensorModeDispType	显示模式; 0x00–整数模式; 默认=0x00;
            SensorCorrectionPol 传感器修正值极性 注： 0–正， 1–负; 默认=0x00；
            SensorCorrection	传感器修正值；默认=0x00；
            nRatioValue			单位显示比例：默认100；
        *  本文档中提及的颜色属性:
        *  对于有灰度系统，均用4Byte来表示，其中Byte0表示红，Byte1表示绿，Byte2表示蓝，Byte3保留
        *  对于无灰度系统，均用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
         */
        int BxDual_program_SetSensorArea_G6(ushort nAreaID, byte nSensorMode, byte nSensorType,
            byte nSensorUnit,         // 1 0x00 单位温度：0x00 –摄氏度 0x01 –华氏度;  水位计 0x00 –m, 0x01 –cm
            byte[] pFixedTxt, byte[] pFontName, byte nFontSize,
            byte nSensorColor, byte SensorErrColor1, int nAlarmValue, byte nSensorThreshPol,
            byte nDisplayUnitFlag, byte nSensorModeDispType, byte nSensorCorrectionPol,
            int nSensorCorrection, byte nRatioValue);
        /*!
         *  设置5代卡温度区域属性
         */
        int BxDual_program_SetSensorAreaTemperature_G5(ushort nAreaID,
                                    byte nSensorType,         //	1		0x00	传感器类型：//0x00 – DS18B20 //0x01 – SHT1XXX //0x02:S-RHT2
                                    byte nTemperatureUnit,    //	1		0x00	温度单位：0x00–摄氏度; 0x01–华氏度
                                    byte nTermperatureMode,   //	1		0x00	温度显示模式：0x00 –整数模式(25C); 0x01 –小数模式(25.5C);
                                    byte nTemperatureCorrectionPol,// 1 	0x00	传感器修正值极性 注：0 –正， 1 –负
                                    byte nTemperatureCorrection,  // 1 	0x00	传感器修正值（单位：摄氏度）注：此参数为符号整型，单位为0.1
                                    byte nTemperatureThreshPol,   // 1 	0x00	温度阈值极性 注：Bit0 –极性，0 正， 1 负; Bit1 - 0表示小于此值触发事情，1表示大于此值触发条件
                                    byte nTemperatureThresh,      // 1	0x00	温度阈值
                                    byte nTemperatureColor,       // 1			正常温度颜色;用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
                                    byte nTemperatureErrColor,    // 1			温度超过阈值时显示的颜色
                                    byte[] pstrFixTxt,//Ouint8 StaticTextOption;//1	固定文本选项 0x00–无固定文本; 0x01–有	
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation          // 显示的单位字体大小与正常显示文本的大小的比例；
                                );
        /*!
         *  nHumidityThresh：如果当湿度>100时作为触发条件，则此值=0x100+100; 如果当湿度<100时作为触发条件，则此值=100;
         */
        int BxDual_program_SetSensorAreaHumidity_G5(ushort nAreaID,
                                    byte nSensorType,             // 1		传感器类型：0x00 –
                                    byte nHumidityMode,           // 1		显示模式：0x00 – % RH，整数型相对湿度; 0x01 –浮点型相对湿度;
                                    byte nHumidityCorrectionPol,  // 1		传感器修正值极性; 注：0 –正， 1 –负
                                    byte nHumidityCorrection,     // 1		传感器修正值; 注：单位为0.1								
                                    byte nHumidityThresh,         // 1		湿度阈值及触发条件; Bit0~Bit6 –湿度阈值; Bit7 – 0表示小于此值触发事情，1表示大于此值触发条件
                                    byte nHumidityColor,          // 1		正常湿度颜色:	*  本文档中提及的颜色属性:
                                                                  //*对于有灰度系统，均用4Byte来表示，其中Byte0表示红，Byte1表示绿，Byte2表示蓝，Byte3保留
                                                                  //*对于无灰度系统，均用1Byte来表示，其中 Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
                                    byte nHumidityErrColor,       // 1		湿度超过阈值时显示的颜色
                                    byte[] pstrFixTxt,//Ouint8 StaticTextOption;	// 1	固定文本选项 0x00–无固定文本; 0x01–有	
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation                      // 显示的单位字体大小与正常显示文本的大小的比例；
                                    );
        /*!
         *  设置5代卡噪声区域属性
         */
        int BxDual_program_SetSensorAreaNoise_G5(ushort nAreaID,
                                    byte nSensorType,         //		1				传感器类型：0x00 –嘉兴恒升; 0x01 –杭州爱华
                                    byte nNoiseMode,          //		1				显示模式：0x00 – 60.0dB; 0x01 – 60dB; 0x02–60.0; 0x03–60
                                    byte nNoiseCorrectionPol, //		1				传感器修正值极性; 注：0 –正， 1 –负
                                    byte nNoiseCorrection,    //		1				传感器修正值; 注：此参数为符号整型，单位为0.1
                                    byte nNoiseThresh,        //		1				噪声阈值及触发条件; Bit0~Bit6 –噪声阈值; Bit7 – 0表示小于此值触发事情，1表示大于此值触发条件
                                    byte nNoiseColor,         //		1				正常噪声颜色
                                    byte nNoiseErrColor,      //		1				噪声超过阈值时显示的颜色
                                                              //Ouint8 StaticTextOption,	//		1				固定文本选项; 0x00 –无固定文本; 0x01 – 有;
                                                              //Ouint8* FontData,			//		1				字模数据，具体的字模格式，请参考附录1; （固定文本应整体当做一个字来处理）; 字模个数为13，其顺序依次为：0, …, 9, ., dB，固定文本;
                                    byte[] pstrFixTxt,//Ouint8 StaticTextOption;	// 1	固定文本选项 0x00–无固定文本; 0x01–有	
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation                      // 显示的单位字体大小与正常显示文本的大小的比例；
                                );
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
    internal class LedBxDualSdkDller : ILedBxDualSdkProxy
    {
        /// <summary>
        /// 单例实例
        /// </summary>
        public static LedBxDualSdkDller Instance { get; } = new LedBxDualSdkDller();
        #region // 函数导入
        /// <summary>
        /// windows平台需要初始化SDK（默认如果没有初始化会自动初始化）
        /// </summary>
        /// <returns></returns>
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_InitSdk();
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern void bxDual_ReleaseSdk();
        /// <summary>
        /// 设置目标地址，即设置屏号/设置屏地址/设置控制器的屏号
        /// </summary>
        /// <param name="usDstAddr">2个字节长度，默认值0xfffe 为地址通配符</param>
        /// <returns></returns>
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_set_screenNum_G56(ushort usDstAddr);
        /// <summary>
        /// 用于设置控制各种通讯方式每一包最大长度
        /// 注：5E，6E，6Q系列最大数据长途64K（建议最大不要超过63*1024） 其他系列最大长度1K（1204）
        /// </summary>
        /// <param name="packetLen">数据包长度</param>
        /// <returns></returns>
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_set_packetLen(ushort packetLen);
        /// <summary>
        /// 搜索控制器命令
        /// </summary>
        /// <param name="retData">请参考结构体Ping_data 所有回读参数都会通过结构体回调</param>
        /// <returns></returns>
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_searchController(ref Ping_data retData);
        /// <summary>
        /// 搜索控制器命令-串口
        /// </summary>
        /// <param name="retData">请参考结构体Ping_data 所有回读参数都会通过结构体回调</param>
        /// <param name="uartPort">串口号</param>
        /// <returns></returns>
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_searchController(ref Ping_data retData, byte[] uartPort);
        /*! ***********************************************************************************************************************
        * 函数名：cmd_uart_search_Net_6G()
        * 参数名：
        *        uartPort 端口号,如："COM3"
        *		 nBaudRateType 1：9600;   2：57600;
        *		 命令结果放在了 retData 中；NetSearchCmdRet:参考结构体声明中的注释；
        * 返回值：0 成功， 其他值为错误号
        * 功  能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
        * 注：   针对 6代卡 的网络搜索命令
        ***************************************************************************************************************************/
        /// <summary>
        ///  网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
        ///   针对 6代卡 的网络搜索命令
        /// </summary>
        /// <param name="retData">NetSearchCmdRet:参考结构体声明中的注释；</param>
        /// <param name="uartPort">串口号,如："COM3"</param>
        /// <param name="nBaudRateType">1：9600;   2：57600;</param>
        /// <returns></returns>
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_search_Net_6G(ref NetSearchCmdRet retData, byte[] uartPort, ushort nBaudRateType);
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_search_Net_6G_Web(ref NetSearchCmdRet_Web retData, byte[] uartPort, ushort nBaudRateType);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsFormat（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        * 返回值：0 成功， 其他值为错误号
        * 功 能：文件系统格式化
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsFormat(byte[] uartPort, byte baudRate);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsStartFileTransf（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始批量写文件
        * 注：
        * 发送节目前调用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsStartFileTransf(byte[] uartPort, byte baudRate);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsEndFileTransf（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件结束
        * 注：
        * 发送节目后调用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsEndFileTransf(byte[] uartPort, byte baudRate);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsDeleteFormatFile（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_confDeleteFormatFile（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsGetMemoryVolume（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	totalMemVolume：全部空间大小
        *	availableMemVolume：剩余空间大小
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取控制空间大小和剩余空间
        * 注：
        * 发节目前需要查询防止空间不够用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsGetMemoryVolume(byte[] uartPort, byte baudRate, ref int totalMemVolume, ref int availableMemVolume);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsWriteFile（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_confWriteFile（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsStartReedFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileSize：回读文件大小
        *	fileCrc：回读的文件CRC
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始读文件
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_confStartReedFile（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：需要读取的文件名
        *	fileSize：回读文件大小
        *	fileCrc：回读的文件CRC
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始读文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsReedFileBlock（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_confReedFileBlock(）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_ofsReedDirBlock（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：下面两条命令搭配使用可以获取所有文件名
        * 注：
        * 下面两条命令用法比较复杂请配合协议使用不做嗷述
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsReedDirBlock(byte[] uartPort, byte baudRate, ref GetDirBlock_G56 dirBlock);
        /*! ***************************************************************
        * 函数名：  bxDual_cmd_ofs_freeDirBlock（）
        * 参数名：
        *	dirBlock: 上述两条命令所有使用的结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：释放cmd_ofsReedDirBlock所创建的节目列表dirBlock
        * 注：
        * dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsFreeDirBlock(ref GetDirBlock_G56 dirBlock);
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsGetTransStatus(byte[] uartPort, byte baudRate, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_sendConfigFile(）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        configData 请参考结构体ConfigFile
        * 返回值：0 成功， 其他值为错误号
        * 功 能：发送配置文件到控制器
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_sendConfigFile(byte[] uartPort, byte baudRate, ref ConfigFile configData);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_uart_programLock（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *         nonvolatile： 状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存
        *         lock：0x00 –解锁  0x01 –锁定
        *         name： 节目名称4（byte）个字节
        *         lockDuration: 节目锁定时间长度， 单位为 10 毫秒， 例
        *         如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目锁定
        * 注：
        * 具体使用方法参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_programLock(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, uint lockDuration);
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_programLock_6G(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, int lockDuration);
        /*! ***************************************************************
        **  串口通讯命令 end **
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       cmd_AT_setWifiSsidPwd（）
        * 参数名：ssid：控制器WIFI ssid，pwd：控制WIFI密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置wifi卡的 ssid pwd
        * 注：
        * 通讯方式（UDP
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_AT_setWifiSsidPwd(byte[] ssid, byte[] pwd);
        /*! ***************************************************************
        * 函数名：       cmd_AT_getWifiSsidPwd（）
        * 参数名：ssid：控制器WIFI ssid，pwd：控制WIFI密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取WIFI卡ssid pwd
        * 注：
        * 通讯方式（UDP）
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_AT_getWifiSsidPwd(byte[] ssid, byte[] pwd);
        /*! ***************************************************************
        **  UDP通讯命令 **
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       cmd_udpNetworkSearch（）
        * 参数名：retData 请参考结构体heartbeatData 所有回读参数都会通过结构体回调
        * 返回值：0 成功， 其他值为错误号
        * 功 能：
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpNetworkSearch(ref HeartbeatData retData); //网络搜索
        /*! ********************************************************************************************************************
        * 函数名：cmd_udpNetworkSearch_6G（）
        * 参数名：retData : 存放网络搜索结果; 具体参考结构体:NetSearchCmdRet 声明中的注释；
        * 返回值：0 成功， 其他值为错误号;
        * 功  能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
        * 注：    针对 6代卡 的网络搜索命令
        ***********************************************************************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpNetworkSearch_6G(ref NetSearchCmdRet retData);
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpNetworkSearch_6G_Web(ref NetSearchCmdRet_Web retData);
        /*! ***************************************************************
        * 函数名：       cmd_udpPing（）
        * 参数名：retData 请参考结构体Ping_data 所有回读参数都会通过结构体回调
        * 返回值：0 成功， 其他值为错误号
        * 功 能：UDP ping 命令
        * 注：
        * 此命令用来搜索加屏使用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpPing(ref Ping_data retData); //UDP ping命令并返回IP地址
        /*! ***************************************************************
        * 函数名：       cmd_udpSetMac（）
        * 参数名：mac 传入的MAC地址
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置 MAC 地址命令
        * 注：
        * 需要修改MAC地址的时候调用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpSetMac(byte[] mac);
        /*! ***************************************************************
        * 函数名：       cmd_udpSetIP（）
        * 参数名
        byte mode; 控制器连接模式：
        0x00 –单机直连（PC 与控制器直接连
        接）
        0x01 –自动获取IP（DHCP）
        0x02 –手动设置IP（Static IP）
        0x03 –服务器模式（动态 IP）
        byte ip[] ； // 要设置的IP地址//设置IP
        byte subnetMask[] ; 子网掩码
        byte gateway[]; 默认网关
        short port; 端口号
        byte serverMode; 服务器模式
        byte serverIP[]; 服务IP
        short serverPort; 服务器端口号
        byte password[]; 服务器访问密码
        short heartbeat; 心跳间隔时间单位秒 默认值20
        byte netID[12]; 控制器网络ID
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置 IP 地址相关参数命令
        * 注：
        *  IP 地址 MAC地址都赋字符串 例：byte ip[] = "192.168.0.199"  具体使用细节请参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpSetIP(byte mode, byte[] ip, byte[] subnetMask, byte[] gateway, short port, byte serverMode, byte[] serverIP, short serverPort, byte[] password, short heartbeat, byte[] netID);// 由于传入参数到内部都需要转换没有使用结构体
        /*! ***************************************************************
        /**UDP CMD END**/
        /*! ***************************************************************/
        /*! ***************************************************************
        /** TCP命令 控制器维护命令 **/
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       cmd_sysReset（）
        * 参数名：ip， 控制器IP， port 控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：让系统复位
        * 注：
        * 此命令调用后所有参数全部会丢失
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_sysReset(byte[] ip, ushort port);
        /*! ***************************************************************
        * 函数名：       cmd_tcpPing（）
        * 参数名：ip：控制器IP， port：控制器端口， retData：请参考结构体Ping_data
        * 返回值：0 成功， 其他值为错误号
        * 功 能：通过TCP方式获取到控制器相关属性和IP地址
        * 注：
        * 和UDP PING命令获取到的参数相同
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_tcpPing(byte[] ip, ushort port, ref Ping_data retData);
        /*! ***************************************************************
        * 函数名：       cmd_check_time（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：校时，让控制器和当前上位机所在系统时间一致
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_check_time(byte[] ip, ushort port);
        /*!
         *  串口校时
         *  sPortName : "\\\\.\\COM1";
         *  nBaudRateIndex: 1(表示波特率9600); 2(代表57600);
         */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_check_time_uart(byte[] uartPort, byte baudRate);
        /*! ********************************************************************************************************************
        * 函数名：cmd_tcpNetworkSearch_6G（）
        * 参数名：ip：控制器IP， port：控制器端口;
        *		 命令结果放在了 retData 中；NetSearchCmdRet:参考结构体声明中的注释；
        * 返回值：0 成功， 其他值为错误号
        * 功 能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
        * 注：   针对 6代卡 的网络搜索命令
        ***********************************************************************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_tcpNetworkSearch_6G(byte[] ip, ushort port, ref NetSearchCmdRet retData);
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_tcpNetworkSearch_6G_Web(byte[] ip, ushort port, ref NetSearchCmdRet_Web retData);
        /*! ***************************************************************
        * 函数名：       cmd_coerceOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口，onOff：控制器状态：0x01 –开机 0x00 –关机
        * 返回值：0 成功， 其他值为错误号
        * 功 能：强制开挂机命令
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_coerceOnOff(byte[] ip, ushort port, byte onOff);
        /*!
         *  强制开关机（通过串口发送命令）
         *  sPortName : "\\\\.\\COM1";
         *  nBaudRateIndex: 1(表示波特率9600); 2(代表57600);
         */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_coerceOnOff_uart(byte[] sPortName, byte nBaudRateIndex, byte nOnOff);
        /*! ***************************************************************
        * 函数名：       cmd_timingOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口，groupNum：有几组定时开关机 data：TimingOnOff结构体的地址
        * 返回值：0 成功， 其他值为错误号
        * 功 能：定时开关机命令
        * 注：
        * groupNum值是n组情况,data大小 = n * TimingOnOff
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_timingOnOff(byte[] ip, ushort port, byte groupNum, byte[] data);
        /*! ***************************************************************
        * 函数名：       cmd_cancelTimingOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：取消定时开关机
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_cancelTimingOnOff(byte[] ip, ushort port);
        /*! ***************************************************************
        * 函数名：       cmd_setBrightness（）
        * 参数名：ip：控制器IP， port：控制器端口， brightness：亮度度表
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置亮度和相关模式
        * 注：
        * 参考协议对应每一个表格，注意第一个字节模式的配置
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness);
        /*!
         *  通过串口调节亮度
         *  sPortName : "\\\\.\\COM1";
         *  nBaudRateIndex: 1(表示波特率9600); 2(代表57600);
         */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setBrightness_uart(byte[] sPortName, byte nBaudRateIndex, ref Brightness brightness);
        /*! ***************************************************************
        * 函数名：       cmd_readControllerID（）
        * 参数名：ip：控制器IP， port：控制器端口， ControllerID：传回控制器ID
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读控制器ID
        * 注：
        * ControllerID是8个字节 请定义char data[8];
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_readControllerID(byte[] ip, ushort port, byte[] ControllerID);
        /*! ***************************************************************
        * 函数名：       cmd_screenLock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *         nonvolatile：状态是否掉电保存 0x00 –掉电不保存 0x01 –掉电保存
        *         lock： 0x00 –解锁  0x01 –锁定
        * 返回值：0 成功， 其他值为错误号
        * 功 能：屏幕锁定
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_screenLock(byte[] ip, ushort port, byte nonvolatile, byte locked);
        /*! ***************************************************************
        * 函数名：       cmd_programLock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *         nonvolatile： 状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存
        *         lock：0x00 –解锁  0x01 –锁定
        *         name： 节目名称4（byte）个字节
        *         lockDuration: 节目锁定时间长度， 单位为 10 毫秒， 例
        *         如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目锁定
        * 注：
        * 具体使用方法参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_programLock(byte[] ip, ushort port, byte nonvolatile, byte locked, byte[] name, uint lockDuration);
        /*! ***************************************************************
        * 函数名：       cmd_check_controllerStatus（）
        * 参数名：ip：控制器IP， port：控制器端口， controllerStatus：请参考结构体ControllerStatus_G56
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读控制器状态
        * 注：
        * ControllerStatus_G56和协议时对应的可以参考协议的具体用法
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_check_controllerStatus(byte[] ip, ushort port, ref ControllerStatus_G56 controllerStatus);
        /*! ***************************************************************
        * 函数名：       cmd_setPassword（）
        * 参数名：ip：控制器IP， port：控制器端口， oldPassword：老密码， newPassword新密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制器密码
        * 注：
        * 设置后一定要记住，设置后就不在能明码通讯
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setPassword(byte[] ip, ushort port, byte[] oldPassword, byte[] newPassword);
        /*! ***************************************************************
        * 函数名：       cmd_deletePassword（）
        * 参数名：ip：控制器IP， port：控制器端口， password：输出当前控制密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除当前控制器密码
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_deletePassword(byte[] ip, ushort port, byte[] password);
        /*! ***************************************************************
        * 函数名：       cmd_setDelayTime（）
        * 参数名：ip：控制器IP， port：控制器端口， delayTime：开机延时单位秒
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制开机延时时间
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setDelayTime(byte[] ip, ushort port, short delayTime);
        /*! ***************************************************************
        * 函数名：       cmd_setBtnFunc（）
        * 参数名：ip：控制器IP， port：控制器端口， btnMode：按钮模式 0x00–测试按钮 0x01 –沿触发切换节目 0x02 –电平触发切换节目
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制测试按钮功能
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setBtnFunc(byte[] ip, ushort port, byte btnMode);
        /*! ***************************************************************
        * 函数名：       cmd_setTimingReset（）
        * 参数名：ip：控制器IP， port：控制器端口， cmdData：参考结构体TimingReset
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制重启重启时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setTimingReset(byte[] ip, ushort port, ref TimingReset cmdData);
        /*! ***************************************************************
        * 函数名：       cmd_setDispMode（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		dispMode：控制器的显示模式（目前只针对 BX-5E系列控制器）
        *		Bit0 –串/并行， 0 表示并行， 1 表示并行
        *		Bit1–同步使能， 1 使能同步， 0 禁止同步
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制重启重启时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setDispMode(byte[] ip, ushort port, byte dispMode);
        /*! ***************************************************************
        * 函数名：       cmd_battieTime（）
        * 参数名：ip：控制器IP， port：控制器端口，
        *	mode：战斗时间控制命令
        *		0x00:启动战斗时间
        *		0x01:暂停战斗时间
        *		0x02:复位战斗时间
        *	battieData： 命令回读参数请参考结构体BattleTime
        * 返回值：0 成功， 其他值为错误号
        * 功 能：战斗时间管理命令
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_battieTime(byte[] ip, ushort port, byte mode, ref BattleTime battieData);
        /*! ***************************************************************
        * 函数名：       cmd_getStopwatch（）
        * 参数名：ip：控制器IP， port：控制器端口，
        *	mode：秒表控制命令
        *		0x00:启动秒表
        *		0x01:暂停秒表
        *		0x02:复位秒表
        *	timeValue：回读回来的当前秒表时间单位毫秒
        * 返回值：0 成功， 其他值为错误号
        * 功 能：秒表控制并获取秒表时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_getStopwatch(byte[] ip, ushort port, byte mode, ref int timeValue);
        /*! ***************************************************************
        * 函数名：       cmd_getSensorBrightnessValue（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		brightnessValue：当前亮度传感器值
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取亮度读传感器值
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_getSensorBrightnessValue(byte[] ip, ushort port, ref int brightnessValue);
        /*! ***************************************************************
        * 函数名：       cmd_setSpeedAdjust（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		speed：速度微调参数值
        该值以 0.1 毫秒为单位， 共 256 级， 上
        位机下发时该值为 0-255， 这样刚好使
        用一个低位字节， 高位字节为 0， 留作
        以后扩展使用。 下位机根据该参数在每
        次循环中延时相应的时间， 以改善 LED
        屏幕的显示效果。 当该参数为 0 时， 下
        位机延时为 0， 该参数为 1 时， 下位机
        延时 0.1 毫秒， 以此类推
        * 返回值：0 成功， 其他值为错误号
        * 功 能：速度微调命令
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setSpeedAdjust(byte[] ip, ushort port, short speed);
        /*! ***************************************************************
        * 函数名：       cmd_setScreenAddress（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		address：屏幕号
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置屏幕号
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setScreenAddress(byte[] ip, ushort port, short address);
        /** TCP OFS_CMD**/
        /*! ***************************************************************
        * 函数名：       cmd_ofsFormat（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：文件系统格式化
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsFormat(byte[] ip, ushort port);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsStartFileTransf（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始批量写文件
        * 注：
        * 发送节目前调用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsStartFileTransf(byte[] ip, ushort port);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsEndFileTransf（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件结束
        * 注：
        * 发送节目后调用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsEndFileTransf(byte[] ip, ushort port);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsDeleteFormatFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_confDeleteFormatFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsGetMemoryVolume（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	totalMemVolume：全部空间大小
        *	availableMemVolume：剩余空间大小
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取控制空间大小和剩余空间
        * 注：
        * 发节目前需要查询防止空间不够用
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsGetMemoryVolume(byte[] ip, ushort port, ref int totalMemVolume, ref int availableMemVolume);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsWriteFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsWriteFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsStartReedFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileSize：回读文件大小
        *	fileCrc：回读的文件CRC
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始读文件
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_confStartReedFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileSize：回读文件大小
        *	fileCrc：回读的文件CRC
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始读文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsReedFileBlock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * fileAddre大小根据bxDual_cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_confReedFileBlock(）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：需要读取的文件名
        *	fileAddre：传入读文件写的位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读文件
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
        如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * fileAddre大小根据bxDual_cmd_ofsStartReedFile函数回调值确定
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_ofsReedDirBlock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	dirBlock: 读会的文件列表，具体的具体参考GetDirBlock_G56结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取文件列表
        * 注：
        * 下面几条命令用法比较复杂请配合协议使用不做嗷述
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsReedDirBlock(byte[] ip, ushort port, ref GetDirBlock_G56 dirBlock);
        /*! ***************************************************************
        * 函数名：  bxDual_cmd_getFileAttr（）
        * 参数名：
        *	dirBlock: 上一条命令的回传结构体
        *	number: 要获取的第几个文件的属性
        *	fileAttr： 获取到的文件属性存放位置参考结构体FileAttribute_G56；
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取指定文件的属性
        * 注：
        * number：此参数值小于fileAttr.fileName 从0开始
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_getFileAttr(ref GetDirBlock_G56 dirBlock, ushort number, ref FileAttribute_G56 fileAttr);
        /*! ***************************************************************
        * 函数名：  bxDual_cmd_ofs_freeDirBlock（）
        * 参数名：
        *	dirBlock: 上述两条命令所有使用的结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：释放bxDual_cmd_ofsReedDirBlock所创建的节目列表dirBlock
        * 注：
        * dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofs_freeDirBlock(ref GetDirBlock_G56 dirBlock);
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsGetTransStatus(byte[] ip, ushort port, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_firmwareActivate（）
        * 参数名：ip：控制器IP， port：控制器端口，firmwareFileName要激活的固件名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：激活指定固件
        * 注：
        * firmwareFileName 缺省值为4个字节字符串“F001”
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_firmwareActivate(byte[] ip, ushort port, byte[] firmwareFileName);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_sendConfigFile(）
        * 参数名：ip：控制器IP， port：控制器端口
        configData 请参考结构体ConfigFile
        * 返回值：0 成功， 其他值为错误号
        * 功 能：发送5代卡配置文件到控制器
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_sendConfigFile(byte[] ip, ushort port, ref ConfigFile configData);
        /*! ***************************************************************
        * 函数名：       bxDual_cmd_sendConfigFile_G6(）
        * 参数名：ip：控制器IP， port：控制器端口
        configData 请参考结构体ConfigFile
        * 返回值：0 成功， 其他值为错误号
        * 功 能：发送5代卡配置文件到控制器
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_sendConfigFile_G6(byte[] ip, ushort port, ref ConfigFile_G6 configData);
        /*! ***************************************************************
        /** TCP命令 END **/
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       get_crc16（）
        * 参数名：
        * 返回值：0 成功， 其他值为错误号
        * 功 能：用来计算CRC16值
        * 注：
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_get_crc16(ref FileCRC16_G56 crc16);
        /*! ***************************************************************
        * 函数名：       get_crc32（）
        * 参数名：
        * 返回值：0 成功， 其他值为错误号
        * 功 能：用来计算CRC32值
        * 注：
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_get_crc32(ref FileCRC32_G56 crc32);
        /*! ***************************************************************
        ***                  以下是节目相关函数
        *** 注意事项：
        ***
        ***
        /*! ***************************************************************/
        /*! ***************************************************************
        * 函数名：       bxDual_program_deleteProgram（）
        * 返回值：0 成功， 其他值为错误
        * 功 能：删除节目
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteProgram();
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_freeBuffer(ref EQprogram program);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureArea（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	programID：节目的ID号
        * 返回值：0 成功， 其他值为错误号
        * 功 能：只是用来测试图文区
        * 注：
        * 屏幕大小为1024X80 输出26个字母
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureArea(int programID, byte[] ip, ushort port);
        /*! ***************************************************************
        * 函数名：       bxDual_program_setScreenParams_G56（）
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置屏相关属性
        * 注：
        * 三个参数请参考各自枚举值
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor); //设置屏相关属性
        //[DllImport(BxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        //public static extern int  bxDual_program_setScreenParams_G6(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addProgram（）
        *	programH：参考结构体EQprogramHeader
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目句柄
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addProgram(ref EQprogramHeader programH);
        //添加节目句柄
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeProgramParams（）
        *	programH：参考结构体EQprogramHeader
        * 返回值：0 成功， 其他值为错误
        * 功 能：修改已添加节目的一些参数
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeProgramParams(ref EQprogramHeader programH);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addPlayPeriodGrp（）
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目播放时段
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addPlayPeriodGrp(ref EQprogramppGrp_G56 header);
        /*! ***************************************************************
        * 函数名：       bxDual_program_AddArea（）
        * 参数名：
        *	areaID：区域的ID号
        *	aheader：参考结构体EQareaHeader
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加区域句柄
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_AddArea(ushort areaID, ref EQareaHeader aheader);//添加区域句柄
        /*! ***************************************************************
        * 函数名：       bxDual_program_deleteArea（）
        * 参数名：
        *	areaID：区域的ID号
        * 返回值：0 成功， 其他值为错误号
        * 功 能：用来删除编号为areaID的区域
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteArea(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddTxt（）
        *	areaID：区域的ID号
        *	str：需要画的字符
        *	fontName：字体名称
        *	pheader：参考结构体EQpageHeader
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：画字符到图文区
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader pheader);//画字符到区域
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaChangeTxt（）
        *	areaID：区域的ID号
        *	str：需要画的字符
        *	pheader：参考结构体EQpageHeader
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改图文区域内容
        * 注：
        * 只可以修改文字内容和EQpageHeader结构体里面的参数，不可以修改字体，如需修改，需要删除区域后重新添加文本设置字体
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaAddTxt（）
        *	areaID：区域的ID号
        *	str：需要画的字符
        *	fontPathName：字体绝对路径加字库文件名称
        *	pheader：参考结构体EQpageHeader
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区添加字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaChangeTxt（）
        *	areaID：区域的ID号
        *	str：需要更换的字符串
        *	pheader：参考结构体EQpageHeader
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区修改字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_IntegrateProgramFile（）
        * 参数名：
        *	program：参考结构体EQprogram
        * 返回值：0 成功， 其他值为错误号
        * 功 能：合成节目文件返回节目文件属性及地址
        * 注：
        * EQprogram 结构体是用来回调发送文件所需要参数
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_IntegrateProgramFile(ref EQprogram program);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddFrame(）
        * 参数名：areaID：区域的ID号
        *	EQareaframeHeader：参考结构体EQareaframeHeader
        *   picPath: 边框图片文件的路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：区域添加边框
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddFrame(ushort areaID, ref EQareaframeHeader afHeader, byte[] picPath);
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddFrame_G6(ushort areaID, ref EQscreenframeHeader_G6 afHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaGetOnePage(）
        * 参数名：
        *	areaID：区域ID
        *   pageNum: 第几页，从0开始计算
        * 返回值：0 成功， 其他值为错误号
        * 功 能：返回区域第n张图片
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaGetOnePage(ushort areaID, int pageNum, ref GetPageData pageData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddPic（）
        *	areaID：区域的ID号
        *   picID：图片的ID号
        *	EQpageHeader：参考结构体EQpageHeader
        *	picPath：添加的图片路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到区域
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaAddPic(ushort areaID, ushort picID, ref EQpageHeader pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addFrame（）
        *	EQscreenframeHeader：参考结构体EQscreenframeHeader
        *	picPath：添加的边框图片路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目添加边框
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeFrame（）
        *	EQscreenframeHeader：参考结构体EQscreenframeHeader
        *	picPath：边框图片路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目修改已添加边框的一些参数
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_removeFrame（）
        *
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目去掉边框
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_removeFrame();
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaRemoveFrame（）
        *	areaID：区域的ID号
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：区域去掉边框
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaRemoveFrame(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_MoveArea()
        *	areaID：区域的ID号
        *   x:区域left坐标
        *   y:区域top坐标
        *   width:区域宽度
        *   height:区域高度
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：改变区域坐标大小
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_MoveArea(ushort areaID, int x, int y, int width, int height);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddContent()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_timeAreaAddContent()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容EQtimeAreaData::fontName == 字库名称
        * 注：ios下无法使用program_timeAreaAddContent请使用program_fontPath_timeAreaAddContent()
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeContent()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区修改内容EQtimeAreaData::fontName == 字库的路径加字库文件名（字库地址）
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeContent(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaGetOnePage(）
        * 参数名：
        *	areaID：区域ID
        *   pageNum: 第几页，从0开始计算
        * 返回值：0 成功， 其他值为错误号
        * 功 能：返回时间区域第n张图片
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaGetOnePage(ushort areaID, ref GetPageData pageData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddAnalogClock(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加模拟时钟
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeAnalogClock(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区修改模拟时钟的一些设置参数
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeDialPic(）
        * 参数名：
        *	areaID： 区域ID
        *   picPath: 表盘图片位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区从外部添加表盘图片
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeDialPic(ushort areaID, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeDialPicAdd_G56(）
        * 参数名：
        *	areaID： 区域ID
        *   picPath: 表盘图片位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区从外部添加表盘图片
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeDialPicAdd_G56(ushort areaID, byte[] picAdd, int picLen);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaRemoveDialPic(）
        * 参数名：
        *	areaID：区域ID
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区移除外部添加的表盘图片
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaRemoveDialPic(ushort areaID);
        //6代控制卡动态区功能开始:=================================
        /*
        功能：设置动态区颜色像素类型：R+G 或 G+R
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56 ePixelRGorGR);
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        功能说明：6代更新动态区最基本功能：仅显示动态区：即不与节目一起显示，如果当前有节目显示，调用此函数后，LED屏幕上会清空原来的内容，显示此函数中 strAreaTxtContent 参数的内容；
                 如果要与屏幕上原来显示的节目一起显示，请调用下面的 动态区文本关联节目 函数；与节目一起显示时，要注意动态区域与原来的节目区域不能重叠！
        参数说明：
        pIP,nPort	  :（与控制卡直连时）控制卡IP; 端口号;
                       （通过服务端连时）服务端IP;服务端返回的控制卡对应的端口号;
        color		  :LED屏颜色类型，详见 E_ScreenColor_G56 声明；
        uAreaId		  :区域号; 如果控制卡只支持4个动态区，则uAreaId的取值范围：0-3；共4个；且只能是0-3之间的值；
        uAreaX,uAreaY :显示区域坐标，即动态区域左上角在LED显示屏的位置/坐标；如：（0，0）则是从LED显示屏幕的最左上角开始显示动态区域；
                       注意:不同控制卡的最小LED屏宽不同，如BX-6E2X最小屏宽为80个显示单位，所以连接的LED屏如果只有64宽度，则在坐标为（0，0）且是靠左显示的情况下，最左边的16个单元会显示不完整；
                       此时，可以考虑设置起始点X的坐标为16，即(16，0),此时宽高为(80-16,高);
        uWidth,uHeight:动态区域的宽度，高度;
        fontName	  :字体名称，如"宋体";  nFontSize:字体大小，如12;
        strAreaTxtContent:要显示的文本内容
        -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxt_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY,
            ushort uWidth, ushort uHeight, IntPtr fontName, byte nFontSize, IntPtr strAreaTxtContent);
        //6代更新动态区详细功能：仅显示动态区; 将要显示的一些特性/属性，封装在 EQareaHeader_G6 和 EQpageHeader_G6 结构体中；
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);
        /*
        功能说明	：6代更新动态区详细功能：仅显示动态区;
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);
        //动态区文本关联节目: 
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：动态区关联节目
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6,
            ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);
        //更新动态区图片：仅显示动态区;
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);
        /*
        功能说明：更新动态区图片：仅显示动态区;
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);
        //动态区图片关联节目: 
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：动态区图片关联节目:
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        RelateProNum			: RelateProNum == 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
                                  RelateProNum > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
            ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);
        //同时更新多个动态区:仅显示动态区，不显示节目
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /*
        功能说明：同时更新多个动态区文本:仅显示动态区，不显示节目;
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddTxtDetails_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        //同时更新多个动态区文本:并与节目关联，即与节目一起显示
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：同时更新多个动态区文本:并与节目关联，即与节目一起显示
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        ushort RelateProNum	: = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
                                  > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        //同时更新多个动态区图片：仅显示动态区图片;不与节目关联/不与节目一起显示；
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        /*
        功能说明：同时更新多个动态区图片;仅显示动态区图片/不与节目关联/不与节目一起显示；
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);
        //同时更新多个动态区图片，并与节目关联，即与节目一起显示；
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：同时更新多个动态区图片，并与节目关联，即与节目一起显示；
        参数说明：
        byte[] pSerialName		: 串口名称,如"COM1"；
        int nBaudRateIndex	: 波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        ushort RelateProNum	: = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
                                  > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：TCP
        参数	说明	：
                pIP		:控制卡IP地址，如"192.168.1.111";
                nPort	:控制卡默认TCP方式的端口号为:5005
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
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
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_G6_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color,
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
        /*
        功能说明：一次向一个动态区发送/更新多条信息（文字或图片）及语音
        参数说明：
                RunMode:			动态区运行模式 
                                    //0— 动态区数据循环显示。
                                    //1— 动态区数据显示完成后静止显示最后一页数据。
                                    //2— 动态区数据循环显示，超过设定时间后数据仍未更新时不再显示
                                    //3— 动态区数据循环显示，超过设定时间后数据仍未更新时显示Logo 信息, Logo 信息即为动态区域的最后一页信息4— 动态区数据顺序显示，显示完最后一页后就不再显示
                Timeout: 动态区数据超时时间，单位为秒;该动态区显示时长超过这个值的时间(s)，会自动删除，仅部分卡类型支持；未试过；
                RelateAllPro: 当该字节为 1 时，所有异步节目播放时都允许播放该动态区域；为 0 时，由接下来的规则来决定
                RelateProNum: 动态区域关联了多少个异步节目一旦关联了某个异步节目，则当该异步节目播放时允许播放该动态区域，否则，不允许播放该动态区域
                RelateProSerial:  动态区域关联的节目编号；
                pSoundData: 语音内容；默认为空不发送语音；
                *参数详细说明参考《6th 动态区域用户手册》
        返回值：0 成功；-1 失败；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_6G_V2(byte[] pIP, int nPort, E_ScreenColor_G56 color,
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
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color,
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
        /*
        功能：TCP方式删除动态区
        删除动态区：删除单个动态区：
        uAreaId = 0xff:删除所有区域
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelArea_6G(byte[] pIP, int nPort, byte uAreaId);
        /*
        功能：TCP方式删除多个动态区：
        参数：
        pAreaID-存放要删除的动态区ID数组；
        uAreaCount-动态区ID数组中的个数；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelAreas_6G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);
        /*
        功能：串口方式删除动态区
        删除动态区：删除单个动态区：
        uAreaId = 0xff:删除所有区域
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelArea_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);
        /*
        功能：串口方式删除多个动态区：
        参数：
        pAreaID-存放要删除的动态区ID数组；
        uAreaCount-动态区ID数组中的个数；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelAreas_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);
        /*
        功能：插入独立语音
        参数：
        byte VoiceFlg;		//1 1 语音属性 0：此条语音从头插入队列，且停止当前正在播放的语音 1：此条语音从头插入队列，不停止当前播报的语音 2：此条语音从尾插入队列
        byte StoreFlag;		//1 0 该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失该值为 0 表示需要存储到 RAM 中，掉电信息丢失
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_InsertSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, byte VoiceFlg, byte StoreFlag);
        /*
        功能：5.4.3 更新独立语音命令
        stSoundData：指向存放EQSoundDepend_6G结构的一段内存首地址指针；
        nSoundDataCount:指示stSoundData指向内存地址空间中存放EQSoundDepend_6G个数；
        StoreFlag:该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失;该值为 0 表示需要存储到 RAM 中，掉电信息丢失
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_UpdateSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, ushort nSoundDataCount, byte StoreFlag);
        //6代控制卡动态区功能结束.=======================
        //5代控制卡动态区功能开始:===============================
        /*
        功能说明：发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；其它参考信息参见 上面的 6代控制卡动态区功能 函数 bxDual_dynamicArea_AddAreaTxt_6G 上面的说明；
        参数说明：
        strAreaTxtContent - 动态区域内要显示的文本内容
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithTxt_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
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
            //显示内容和字体格式 begin---------
            EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
        /*
        功能说明：发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithTxt_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color,
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
            //显示内容和字体格式 begin---------
            EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithTxt_Point_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
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
            //显示内容和字体格式 begin---------
            ref EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
        /*
        功能说明：发送一条文本信息到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
        pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
        nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(byte[] pSerialName, int nBaundRateIndex, E_ScreenColor_G56 color,
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
            //显示内容和字体格式 begin---------
            ref EQfontData oFont,
            byte[] fontName,
            byte[] strAreaTxtContent
        //end.
        );
        /*
        功能说明：发送一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithPic_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
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
            //图片路径 begin---------
            byte[] filePath
        //end.
        );
        /*
        功能说明：发送一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
            pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
            nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        函数返回：
            0	：成功；
            -1	：失败；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithPic_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color,
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
            //图片路径 begin---------
            byte[] filePath
        //end.
        );
        /*
        功能说明：发送多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color,
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
        /*
        功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_5G_Point(byte[] pIP, int nPort, E_ScreenColor_G56 color,
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
        /*
        功能说明：发送多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
        通讯方式	：使用串口发送；
        参数	说明	：
            pSerialName		:串口号字符串；如:byte pSerialName[] = "COM3";
            nBaudRateIndex	:波特率；取值为1时，代表波特率为9600; 取值为2时，代表波特率为57600;
        函数返回：
            0	：成功；
            -1	：失败；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color,
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
        /*
        功能：删除单个动态区：
        参数：uAreaId = 0xff:删除所有区域
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelArea_5G(byte[] pIP, int nPort, byte uAreaId);
        /*
        功能：删除多个动态区：
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelAreaS_5G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);
        /*
        功能：串口方式删除动态区
        删除动态区：删除单个动态区：
        uAreaId = 0xff:删除所有区域
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelArea_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);
        /*
        功能：串口方式删除多个动态区：
        参数：
        pAreaID-存放要删除的动态区ID数组；
        uAreaCount-动态区ID数组中的个数；
        */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelAreaS_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);
        //5代控制卡动态区功能结束:===========================
        /*****************************以下为六代接口*******************************************/
        /*! ***************************************************************
        * 函数名：       bxDual_program_addProgram_G6(）
        * 参数名：
        *	EQprogramHeader_G6：参考结构体EQprogramHeader_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加节目
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addProgram_G6(ref EQprogramHeader_G6 programH);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addPlayPeriodGrp_G6（）
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目播放时段
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addPlayPeriodGrp_G6(ref EQprogramppGrp_G56 header);
        /*! ***************************************************************
        * 函数名：       bxDual_program_deleteProgram_G6(）
        * 参数名：
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除节目
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteProgram_G6();
        /*! ***************************************************************
        * 函数名：       bxDual_program_freeBuffer_G6(）
        * 参数名：
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：释放生成节目文件的缓冲区
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_freeBuffer_G6(ref EQprogram_G6 program);
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeProgramParams_G6（）
        *	EQprogramHeader_G6：参考结构体EQprogramHeader_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改已添加节目的一些参数
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeProgramParams_G6(ref EQprogramHeader_G6 programH);
        /*! ***************************************************************
        * 函数名：       bxDual_program_addFrame_G6（）
        *	sfHeader：参考结构体EQscreenframeHeader_G6
        *	picPath：添加的边框图片路径
        * 返回值：0 成功， -1 不成功
        * 功 能：节目添加边框
        * 注：节目添加边框后，区域的坐标随即发生变化，添加区域的时候需注意
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_changeFrame_G6（）
        *	sfHeader：参考结构体EQscreenframeHeader_G6
        *	picPath：边框图片路径
        * 返回值：0 成功， -1 不成功
        * 功 能：节目修改已添加边框的一些参数
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_removeFrame_G6（）
        * 返回值：0 成功
        * 功 能：节目去掉边框
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_removeFrame_G6();
        /*! ***************************************************************
        * 函数名：       bxDual_program_addArea_G6（）
        * 参数名：areaID：区域的ID号
        *	aheader：参考结构体EQareaHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目添加区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addArea_G6(ushort areaID, ref EQareaHeader_G6 aheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_deleteArea_G6（）
        * 参数名：
        *   areaID：区域ID号
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目删除已添加的区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteArea_G6(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_MoveArea_G6()
        *	areaID：区域的ID号
        *   x:区域left坐标
        *   y:区域top坐标
        *   width:区域宽度
        *   height:区域高度
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：改变区域坐标大小
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_MoveArea_G6(ushort areaID, int x, int y, int width, int height);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaAddTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	fontName：字体名称
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：画文字到图文区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_picturesAreaChangeTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改图文区域已添加过的文字内容及EQpageHeader_G6结构体中的参数
        * 注：
        * 如需修改字体，需要将区域删除，重新添加区域和文字
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaChangeTxt_G6(ushort areaID, IntPtr str, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaAddTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	fontPathName：字体绝对路径加字库文件名称
        *	pheader：参考结构体EQpageHeader_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区添加字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_picturesAreaChangeTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：图文区修改字符串--使用字库
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaChangeTxt_G6(ushort areaID, byte[] str, ref EQpageHeader_G6 pheader);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaAddPic_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	picPath：图片的绝对路径加图片名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到图文区域
        * 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_backGroundPic_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	picPath：图片的绝对路径加图片名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到图文区域
        * 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_backGroundPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_backGroundColor_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	BGColor：区域背景颜色值（RGB888）
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到图文区域
        * 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_backGroundColor_G6(ushort areaID, ref EQpageHeader_G6 pheader, int BGColor);
        /*! **************************************************************** 函数名：       bxDual_program_pictureAreaChangePic_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，传入需要修改的图片编号
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	picPath：图片的绝对路径加图片名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：修改当前picID对应的图片和一些参数
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaChangePic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaEnableSound_G6（）
        *	areaID：区域的ID号
        *	sheader：参考结构体EQPicAreaSoundHeader_G6
        *   soundData:语音数据
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：图文分区使能语音播放
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaEnableSound_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaChangeSoundSettings_G6（）
        *	areaID：区域的ID号
        *	sheader：参考结构体EQPicAreaSoundHeader_G6
        *   soundData:语音数据
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：图文分区修改语音播放的一些参数或数据
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaChangeSoundSettings_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_pictureAreaDisableSound_G6（）
        *	areaID：区域的ID号
        *
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：图文分区取消语音播放
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaDisableSound_G6(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaSetBattleTime_G6（）
        *	areaID：区域的ID号
        *   header：参考结构体EQTimeAreaBattle_G6
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区设置战斗时间和战斗时间的启动模式
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaSetBattleTime_G6(ushort areaID, ref EQTimeAreaBattle_G6 header);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaCancleBattleTime_G6（）
        *	areaID：区域的ID号
        *
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区取消战斗时间
        * 注：取消后的时间分区将作为普通时间
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaCancleBattleTime_G6(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddContent_G6（）
        *	areaID：区域的ID号
        *   timeData：参考结构体EQtimeAreaData_G56
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区添加时间等内容，详情请参考结构体EQtimeAreaData_G56
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeContent_G6（）
        *	areaID：区域的ID号
        *   timeData：参考结构体EQtimeAreaData_G56
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区修改时间等内容，详情请参考结构体EQtimeAreaData_G56
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_fontPath_timeAreaAddContent_G6()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容EQtimeAreaData::fontName == 字库名称
        * 注：ios下无法使用program_timeAreaAddContent_G6请使用program_fontPath_timeAreaAddContent_G6()
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaAddAnalogClock_G6(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加模拟时钟
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeAnalogClock_G6(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区修改模拟时钟的一些设置参数
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaChangeDialPic_G6(）
        * 参数名：
        *	areaID： 区域ID
        *   picPath: 表盘图片位置
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区从外部添加表盘图片
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeDialPic_G6(ushort areaID, byte[] picPath);
        /*! ***************************************************************
        * 函数名：       bxDual_program_timeAreaRemoveDialPic_G6(）
        * 参数名：
        *	areaID： 区域ID
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区移除添加的表盘图片
        * 注：
        *
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaRemoveDialPic_G6(ushort areaID);
        /*! ***************************************************************
        * 函数名：       bxDual_program_IntegrateProgramFile_G6（）
        * 参数名：
        *	program：参考结构体EQprogram_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：合成节目文件返回节目文件属性及地址
        * 注：
        * EQprogram 结构体是用来回调发送文件所需要参数
        ******************************************************************/
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program);
        /*!
        *  功能：配置传感器区域的参数
        *  
        *  SensorMode	1byte	默认=0；
        *						0：代表温度
                                1：代表湿度
                                2：代表噪声
                                3：代表PM2.5（空气质量变送器）
                                4：代表PM10（空气质量变送器）
                                5：RS485型风向变送器
                                6：RS485型风速变换器
                                7：大气压力
                                8：车速
                                9：光照
                                10：0x0A：水位计
                                11：0x0B: 代表TSP
                                12：0x0C: 负氧离子监测仪
                                0xff：万能传感器，该类型是BX-6XX-MODBUS系列专用类型，当传感器类型为该值时，下面的SensorType、SensorUnit、DisplayUnitFlag均设置为0，对于通用系列控制卡，该值为非0xff的值;
            SensorType	传感器类型;默认长度/值： 1 0x00 
                                温度：
                                    0x00 – DS18B20（温度传感器）
                                    0x01 – SHT11(6 代三基色和全彩不支持)（I 温湿度传感器(4 线)
                                    0X02 – DHT21（II 温湿度传感器(3 线)）
                                    0X03 – RS-BYH-M（气象组合传感器）（BX-QX）
                                湿度：
                                    0x00 – SHT11(6代三基色和全彩不支持)（I温湿度传感器(4线)
                                    0x01 –DHT21（II温湿度传感器(3线)）
                                    0X02 –RS-BYH-M（气象组合传感器 ）（BX-QX）
                                噪声：
                                    0x00 –AWA5636-3(6代三基色和全彩不支持)
                                    0x01 –HS5633T(6代三基色和全彩不支持)
                                    0x02–AZ8921(6代三基色和全彩不支持)
                                    0x03-BX-ZS
                                    0x04- RS-BYH-M（气象组合传感器）（BX-QX）
                                PM2.5：
                                    0x00：空气质量变送器(RS-PM-N10-2) PM2.5（BX-PM）
                                    0x01 :   气象组合传感器（RS-BYH-M）PM2.5（BX-QX）
                                PM10：
                                    0x00 – 空气质量变送器(RS-PM-N10-2) PM10(BX-PM)
                                    0x01 :   气象组合传感器（RS-BYH-M）PM10（BX-QX）
                                TSP：
                                    0x00 – 空气质量变送器(RS-PM-N10-2) TSP(BX-PM)
                                    0x01 :   气象组合传感器（RS-BYH-M）TSP（BX-QX）
                                风向变送器：
                                    0x00 – RS485型风向变送器(RS-FX-N01) (BX-FX)
                                风速变换器：
                                    0x00 – RS485型风速变换器(RS-FS-N01 )（BX-FS）
                                大气压力：
                                    0X00 –RS-BYH-M（气象组合传感器）（BX-QX）
                                车速：
                                    0X00 – TBR-300 (TBR-300)
                                光照：
                                    0X00 –RS-BYH-M（气象组合传感器）（BX-QX）
                                水位计：
                                    0X00 – YEH-Z(空高值,水位计LCD用L表示)
                                    0X01 – YEH-Z(液位值,水位计LCD用H表示)
                                    0X02 –WFX-40
                                    0X03 –WLZ(L)  空高值
                                    0X04 –WLZ(H)   液位值
                                负氧离子监测仪：
                                    0x00 --  AN-210
            nSensorColor		正常颜色；默认绿色=0x02；对于无灰度系统，均用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
            SensorAlarmColor	报警颜色/超过阀值的颜色；红色=0x01；
            nAlarmValue			报警值/阀值；默认60；
            nDisplayUnitFlag	是否显示单位 0：不显示; 1：显示; 默认=1;
            nSensorModeDispType	显示模式; 0x00–整数模式; 默认=0x00;
            SensorCorrectionPol 传感器修正值极性 注： 0–正， 1–负; 默认=0x00；
            SensorCorrection	传感器修正值；默认=0x00；
            nRatioValue			单位显示比例：默认100；
        *  本文档中提及的颜色属性:
        *  对于有灰度系统，均用4Byte来表示，其中Byte0表示红，Byte1表示绿，Byte2表示蓝，Byte3保留
        *  对于无灰度系统，均用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
         */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_SetSensorArea_G6(ushort nAreaID, byte nSensorMode, byte nSensorType,
            byte nSensorUnit,         // 1 0x00 单位温度：0x00 –摄氏度 0x01 –华氏度;  水位计 0x00 –m, 0x01 –cm
            byte[] pFixedTxt, byte[] pFontName, byte nFontSize,
            byte nSensorColor, byte SensorErrColor1, int nAlarmValue, byte nSensorThreshPol,
            byte nDisplayUnitFlag, byte nSensorModeDispType, byte nSensorCorrectionPol,
            int nSensorCorrection, byte nRatioValue);
        /*!
         *  设置5代卡温度区域属性
         */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_SetSensorAreaTemperature_G5(ushort nAreaID,
                                    byte nSensorType,         //	1		0x00	传感器类型：//0x00 – DS18B20 //0x01 – SHT1XXX //0x02:S-RHT2
                                    byte nTemperatureUnit,    //	1		0x00	温度单位：0x00–摄氏度; 0x01–华氏度
                                    byte nTermperatureMode,   //	1		0x00	温度显示模式：0x00 –整数模式(25C); 0x01 –小数模式(25.5C);
                                    byte nTemperatureCorrectionPol,// 1 	0x00	传感器修正值极性 注：0 –正， 1 –负
                                    byte nTemperatureCorrection,  // 1 	0x00	传感器修正值（单位：摄氏度）注：此参数为符号整型，单位为0.1
                                    byte nTemperatureThreshPol,   // 1 	0x00	温度阈值极性 注：Bit0 –极性，0 正， 1 负; Bit1 - 0表示小于此值触发事情，1表示大于此值触发条件
                                    byte nTemperatureThresh,      // 1	0x00	温度阈值
                                    byte nTemperatureColor,       // 1			正常温度颜色;用1Byte来表示，其中，Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
                                    byte nTemperatureErrColor,    // 1			温度超过阈值时显示的颜色
                                    byte[] pstrFixTxt,//Ouint8 StaticTextOption;//1	固定文本选项 0x00–无固定文本; 0x01–有	
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation          // 显示的单位字体大小与正常显示文本的大小的比例；
                                );
        /*!
         *  nHumidityThresh：如果当湿度>100时作为触发条件，则此值=0x100+100; 如果当湿度<100时作为触发条件，则此值=100;
         */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_SetSensorAreaHumidity_G5(ushort nAreaID,
                                    byte nSensorType,             // 1		传感器类型：0x00 –
                                    byte nHumidityMode,           // 1		显示模式：0x00 – % RH，整数型相对湿度; 0x01 –浮点型相对湿度;
                                    byte nHumidityCorrectionPol,  // 1		传感器修正值极性; 注：0 –正， 1 –负
                                    byte nHumidityCorrection,     // 1		传感器修正值; 注：单位为0.1								
                                    byte nHumidityThresh,         // 1		湿度阈值及触发条件; Bit0~Bit6 –湿度阈值; Bit7 – 0表示小于此值触发事情，1表示大于此值触发条件
                                    byte nHumidityColor,          // 1		正常湿度颜色:	*  本文档中提及的颜色属性:
                                                                  //*对于有灰度系统，均用4Byte来表示，其中Byte0表示红，Byte1表示绿，Byte2表示蓝，Byte3保留
                                                                  //*对于无灰度系统，均用1Byte来表示，其中 Bit0表示红，bit1表示绿，bit2表示蓝，对于每一个Bit，0表示灭，1表示亮；
                                    byte nHumidityErrColor,       // 1		湿度超过阈值时显示的颜色
                                    byte[] pstrFixTxt,//Ouint8 StaticTextOption;	// 1	固定文本选项 0x00–无固定文本; 0x01–有	
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation                      // 显示的单位字体大小与正常显示文本的大小的比例；
                                    );
        /*!
         *  设置5代卡噪声区域属性
         */
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_SetSensorAreaNoise_G5(ushort nAreaID,
                                    byte nSensorType,         //		1				传感器类型：0x00 –嘉兴恒升; 0x01 –杭州爱华
                                    byte nNoiseMode,          //		1				显示模式：0x00 – 60.0dB; 0x01 – 60dB; 0x02–60.0; 0x03–60
                                    byte nNoiseCorrectionPol, //		1				传感器修正值极性; 注：0 –正， 1 –负
                                    byte nNoiseCorrection,    //		1				传感器修正值; 注：此参数为符号整型，单位为0.1
                                    byte nNoiseThresh,        //		1				噪声阈值及触发条件; Bit0~Bit6 –噪声阈值; Bit7 – 0表示小于此值触发事情，1表示大于此值触发条件
                                    byte nNoiseColor,         //		1				正常噪声颜色
                                    byte nNoiseErrColor,      //		1				噪声超过阈值时显示的颜色
                                                              //Ouint8 StaticTextOption,	//		1				固定文本选项; 0x00 –无固定文本; 0x01 – 有;
                                                              //Ouint8* FontData,			//		1				字模数据，具体的字模格式，请参考附录1; （固定文本应整体当做一个字来处理）; 字模个数为13，其顺序依次为：0, …, 9, ., dB，固定文本;
                                    byte[] pstrFixTxt,//Ouint8 StaticTextOption;	// 1	固定文本选项 0x00–无固定文本; 0x01–有	
                                    byte nFontSize,
                                    byte[] pstrFontNameFile,
                                    byte nUnitShowRation                      // 显示的单位字体大小与正常显示文本的大小的比例；
                                );
        [DllImport(LedBxDualSdk.DllFileName, CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddCounterTimer_G6(ushort areaID, ref BXG6_Time_Counter header, byte[] cUnitDay, byte[] cUnitHour, byte[] cUnitMinute, byte[] cUnitSec, byte[] pFixedTxt);
        #endregion 函数导入
        #region // 显示实现
        int ILedBxDualSdkProxy.BxDual_cmd_AT_getWifiSsidPwd(byte[] ssid, byte[] pwd) => bxDual_cmd_AT_getWifiSsidPwd(ssid, pwd);
        int ILedBxDualSdkProxy.BxDual_cmd_AT_setWifiSsidPwd(byte[] ssid, byte[] pwd) => bxDual_cmd_AT_setWifiSsidPwd(ssid, pwd);
        int ILedBxDualSdkProxy.BxDual_cmd_battieTime(byte[] ip, ushort port, byte mode, ref BattleTime battieData) => bxDual_cmd_battieTime(ip, port, mode, ref battieData);
        int ILedBxDualSdkProxy.BxDual_cmd_cancelTimingOnOff(byte[] ip, ushort port) => bxDual_cmd_cancelTimingOnOff(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_check_controllerStatus(byte[] ip, ushort port, ref ControllerStatus_G56 controllerStatus) => bxDual_cmd_check_controllerStatus(ip, port, ref controllerStatus);
        int ILedBxDualSdkProxy.BxDual_cmd_check_time(byte[] ip, ushort port) => bxDual_cmd_check_time(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_check_time_uart(byte[] uartPort, byte baudRate) => bxDual_cmd_check_time_uart(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_coerceOnOff(byte[] ip, ushort port, byte onOff) => bxDual_cmd_coerceOnOff(ip, port, onOff);
        int ILedBxDualSdkProxy.BxDual_cmd_coerceOnOff_uart(byte[] sPortName, byte nBaudRateIndex, byte nOnOff) => bxDual_cmd_coerceOnOff_uart(sPortName, nBaudRateIndex, nOnOff);
        int ILedBxDualSdkProxy.BxDual_cmd_confDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName) => bxDual_cmd_confDeleteFormatFile(ip, port, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_confReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre) => bxDual_cmd_confReedFileBlock(ip, port, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_confStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc) => bxDual_cmd_confStartReedFile(ip, port, fileName, ref fileSize, ref fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_confWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre) => bxDual_cmd_confWriteFile(ip, port, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_deletePassword(byte[] ip, ushort port, byte[] password) => bxDual_cmd_deletePassword(ip, port, password);
        int ILedBxDualSdkProxy.BxDual_cmd_firmwareActivate(byte[] ip, ushort port, byte[] firmwareFileName) => bxDual_cmd_firmwareActivate(ip, port, firmwareFileName);
        int ILedBxDualSdkProxy.BxDual_cmd_getFileAttr(ref GetDirBlock_G56 dirBlock, ushort number, ref FileAttribute_G56 fileAttr) => bxDual_cmd_getFileAttr(ref dirBlock, number, ref fileAttr);
        int ILedBxDualSdkProxy.BxDual_cmd_getSensorBrightnessValue(byte[] ip, ushort port, ref int brightnessValue) => bxDual_cmd_getSensorBrightnessValue(ip, port, ref brightnessValue);
        int ILedBxDualSdkProxy.BxDual_cmd_getStopwatch(byte[] ip, ushort port, byte mode, ref int timeValue) => bxDual_cmd_getStopwatch(ip, port, mode, ref timeValue);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName) => bxDual_cmd_ofsDeleteFormatFile(ip, port, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsEndFileTransf(byte[] ip, ushort port) => bxDual_cmd_ofsEndFileTransf(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsFormat(byte[] ip, ushort port) => bxDual_cmd_ofsFormat(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsGetMemoryVolume(byte[] ip, ushort port, ref int totalMemVolume, ref int availableMemVolume) => bxDual_cmd_ofsGetMemoryVolume(ip, port, ref totalMemVolume, ref availableMemVolume);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsGetTransStatus(byte[] ip, ushort port, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset) => bxDual_cmd_ofsGetTransStatus(ip, port, r_w, fileName, fileCrc, fileOffset);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsReedDirBlock(byte[] ip, ushort port, ref GetDirBlock_G56 dirBlock) => bxDual_cmd_ofsReedDirBlock(ip, port, ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre) => bxDual_cmd_ofsReedFileBlock(ip, port, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsStartFileTransf(byte[] ip, ushort port) => bxDual_cmd_ofsStartFileTransf(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc) => bxDual_cmd_ofsStartReedFile(ip, port, fileName, ref fileSize, ref fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre) => bxDual_cmd_ofsWriteFile(ip, port, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_ofs_freeDirBlock(ref GetDirBlock_G56 dirBlock) => bxDual_cmd_ofs_freeDirBlock(ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_programLock(byte[] ip, ushort port, byte nonvolatile, byte locked, byte[] name, uint lockDuration) => bxDual_cmd_programLock(ip, port, nonvolatile, locked, name, lockDuration);
        int ILedBxDualSdkProxy.BxDual_cmd_readControllerID(byte[] ip, ushort port, byte[] ControllerID) => bxDual_cmd_readControllerID(ip, port, ControllerID);
        int ILedBxDualSdkProxy.BxDual_cmd_screenLock(byte[] ip, ushort port, byte nonvolatile, byte locked) => bxDual_cmd_screenLock(ip, port, nonvolatile, locked);
        int ILedBxDualSdkProxy.BxDual_cmd_searchController(ref Ping_data retData) => bxDual_cmd_searchController(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_sendConfigFile(byte[] ip, ushort port, ref ConfigFile configData) => bxDual_cmd_sendConfigFile(ip, port, ref configData);
        int ILedBxDualSdkProxy.BxDual_cmd_sendConfigFile_G6(byte[] ip, ushort port, ref ConfigFile_G6 configData) => bxDual_cmd_sendConfigFile_G6(ip, port, ref configData);
        int ILedBxDualSdkProxy.BxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness) => bxDual_cmd_setBrightness(ip, port, ref brightness);
        int ILedBxDualSdkProxy.BxDual_cmd_setBrightness_uart(byte[] sPortName, byte nBaudRateIndex, ref Brightness brightness) => bxDual_cmd_setBrightness_uart(sPortName, nBaudRateIndex, ref brightness);
        int ILedBxDualSdkProxy.BxDual_cmd_setBtnFunc(byte[] ip, ushort port, byte btnMode) => bxDual_cmd_setBtnFunc(ip, port, btnMode);
        int ILedBxDualSdkProxy.BxDual_cmd_setDelayTime(byte[] ip, ushort port, short delayTime) => bxDual_cmd_setDelayTime(ip, port, delayTime);
        int ILedBxDualSdkProxy.BxDual_cmd_setDispMode(byte[] ip, ushort port, byte dispMode) => bxDual_cmd_setDispMode(ip, port, dispMode);
        int ILedBxDualSdkProxy.BxDual_cmd_setPassword(byte[] ip, ushort port, byte[] oldPassword, byte[] newPassword) => bxDual_cmd_setPassword(ip, port, oldPassword, newPassword);
        int ILedBxDualSdkProxy.BxDual_cmd_setScreenAddress(byte[] ip, ushort port, short address) => bxDual_cmd_setScreenAddress(ip, port, address);
        int ILedBxDualSdkProxy.BxDual_cmd_setSpeedAdjust(byte[] ip, ushort port, short speed) => bxDual_cmd_setSpeedAdjust(ip, port, speed);
        int ILedBxDualSdkProxy.BxDual_cmd_setTimingReset(byte[] ip, ushort port, ref TimingReset cmdData) => bxDual_cmd_setTimingReset(ip, port, ref cmdData);
        int ILedBxDualSdkProxy.BxDual_cmd_sysReset(byte[] ip, ushort port) => bxDual_cmd_sysReset(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_tcpNetworkSearch_6G(byte[] ip, ushort port, ref NetSearchCmdRet retData) => bxDual_cmd_tcpNetworkSearch_6G(ip, port, ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_tcpNetworkSearch_6G_Web(byte[] ip, ushort port, ref NetSearchCmdRet_Web retData) => bxDual_cmd_tcpNetworkSearch_6G_Web(ip, port, ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_tcpPing(byte[] ip, ushort port, ref Ping_data retData) => bxDual_cmd_tcpPing(ip, port, ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_timingOnOff(byte[] ip, ushort port, byte groupNum, byte[] data) => bxDual_cmd_timingOnOff(ip, port, groupNum, data);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName) => bxDual_cmd_uart_confDeleteFormatFile(uartPort, baudRate, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre) => bxDual_cmd_uart_confReedFileBlock(uartPort, baudRate, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc) => bxDual_cmd_uart_confStartReedFile(uartPort, baudRate, fileName, fileSize, fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre) => bxDual_cmd_uart_confWriteFile(uartPort, baudRate, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName) => bxDual_cmd_uart_ofsDeleteFormatFile(uartPort, baudRate, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsEndFileTransf(byte[] uartPort, byte baudRate) => bxDual_cmd_uart_ofsEndFileTransf(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsFormat(byte[] uartPort, byte baudRate) => bxDual_cmd_uart_ofsFormat(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsFreeDirBlock(ref GetDirBlock_G56 dirBlock) => bxDual_cmd_uart_ofsFreeDirBlock(ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsGetMemoryVolume(byte[] uartPort, byte baudRate, ref int totalMemVolume, ref int availableMemVolume) => bxDual_cmd_uart_ofsGetMemoryVolume(uartPort, baudRate, ref totalMemVolume, ref availableMemVolume);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsGetTransStatus(byte[] uartPort, byte baudRate, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset) => bxDual_cmd_uart_ofsGetTransStatus(uartPort, baudRate, r_w, fileName, fileCrc, fileOffset);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsReedDirBlock(byte[] uartPort, byte baudRate, ref GetDirBlock_G56 dirBlock) => bxDual_cmd_uart_ofsReedDirBlock(uartPort, baudRate, ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre) => bxDual_cmd_uart_ofsReedFileBlock(uartPort, baudRate, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsStartFileTransf(byte[] uartPort, byte baudRate) => bxDual_cmd_uart_ofsStartFileTransf(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc) => bxDual_cmd_uart_ofsStartReedFile(uartPort, baudRate, fileName, fileSize, fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre) => bxDual_cmd_uart_ofsWriteFile(uartPort, baudRate, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_programLock(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, uint lockDuration) => bxDual_cmd_uart_programLock(uartPort, baudRate, nonvolatile, locked, name, lockDuration);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_programLock_6G(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, int lockDuration) => bxDual_cmd_uart_programLock_6G(uartPort, baudRate, nonvolatile, locked, name, lockDuration);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_searchController(ref Ping_data retData, byte[] uartPort) => bxDual_cmd_uart_searchController(ref retData, uartPort);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_search_Net_6G(ref NetSearchCmdRet retData, byte[] uartPort, ushort nBaudRateType) => bxDual_cmd_uart_search_Net_6G(ref retData, uartPort, nBaudRateType);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_search_Net_6G_Web(ref NetSearchCmdRet_Web retData, byte[] uartPort, ushort nBaudRateType) => bxDual_cmd_uart_search_Net_6G_Web(ref retData, uartPort, nBaudRateType);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_sendConfigFile(byte[] uartPort, byte baudRate, ref ConfigFile configData) => bxDual_cmd_uart_sendConfigFile(uartPort, baudRate, ref configData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpNetworkSearch(ref HeartbeatData retData) => bxDual_cmd_udpNetworkSearch(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpNetworkSearch_6G(ref NetSearchCmdRet retData) => bxDual_cmd_udpNetworkSearch_6G(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpNetworkSearch_6G_Web(ref NetSearchCmdRet_Web retData) => bxDual_cmd_udpNetworkSearch_6G_Web(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpPing(ref Ping_data retData) => bxDual_cmd_udpPing(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpSetIP(byte mode, byte[] ip, byte[] subnetMask, byte[] gateway, short port, byte serverMode, byte[] serverIP, short serverPort, byte[] password, short heartbeat, byte[] netID) => bxDual_cmd_udpSetIP(mode, ip, subnetMask, gateway, port, serverMode, serverIP, serverPort, password, heartbeat, netID);
        int ILedBxDualSdkProxy.BxDual_cmd_udpSetMac(byte[] mac) => bxDual_cmd_udpSetMac(mac);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => bxDual_dynamicAreaS_AddAreaPic_6G(pIP, nPort, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => bxDual_dynamicAreaS_AddAreaPic_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(pIP, nPort, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => bxDual_dynamicAreaS_AddTxtDetails_6G(pIP, nPort, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => bxDual_dynamicAreaS_AddTxtDetails_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(pIP, nPort, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => bxDual_dynamicArea_AddAreaInfos_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_5G_Point(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => bxDual_dynamicArea_AddAreaInfos_5G_Point(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => bxDual_dynamicArea_AddAreaInfos_5G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, ref DynamicAreaBaseInfo_5G[] pInfo) => bxDual_dynamicArea_AddAreaInfos_6G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, ref pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_6G_V2(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, BxAreaFrmae_Dynamic_G6 oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo, ref EQSound_6G pSoundData) => bxDual_dynamicArea_AddAreaInfos_6G_V2(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo, ref pSoundData);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, BxAreaFrmae_Dynamic_G6 oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_G6_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, ref DynamicAreaBaseInfo_5G[] pInfo) => bxDual_dynamicArea_AddAreaInfos_G6_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, ref pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath) => bxDual_dynamicArea_AddAreaPic_6G(pIP, nPort, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath) => bxDual_dynamicArea_AddAreaPic_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicArea_AddAreaPic_WithProgram_6G(pIP, nPort, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(pSerialName, nBaudRateIndex, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent) => bxDual_dynamicArea_AddAreaTxtDetails_6G(pIP, nPort, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent) => bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(pIP, nPort, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial) => bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxt_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, IntPtr fontName, byte nFontSize, IntPtr strAreaTxtContent) => bxDual_dynamicArea_AddAreaTxt_6G(pIP, nPort, color, uAreaId, uAreaX, uAreaY, uWidth, uHeight, fontName, nFontSize, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithPic_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, byte[] filePath) => bxDual_dynamicArea_AddAreaWithPic_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithPic_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, byte[] filePath) => bxDual_dynamicArea_AddAreaWithPic_5G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => bxDual_dynamicArea_AddAreaWithTxt_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => bxDual_dynamicArea_AddAreaWithTxt_5G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_Point_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, ref EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, ref EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => bxDual_dynamicArea_AddAreaWithTxt_Point_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, ref oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(byte[] pSerialName, int nBaundRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, ref EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, ref EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(pSerialName, nBaundRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, ref oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreaS_5G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID) => bxDual_dynamicArea_DelAreaS_5G(pIP, nPort, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreas_6G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID) => bxDual_dynamicArea_DelAreas_6G(pIP, nPort, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreaS_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID) => bxDual_dynamicArea_DelAreaS_G5_Serial(pSerialName, nBaudRateIndex, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreas_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID) => bxDual_dynamicArea_DelAreas_6G_Serial(pSerialName, nBaudRateIndex, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_5G(byte[] pIP, int nPort, byte uAreaId) => bxDual_dynamicArea_DelArea_5G(pIP, nPort, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_6G(byte[] pIP, int nPort, byte uAreaId) => bxDual_dynamicArea_DelArea_6G(pIP, nPort, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId) => bxDual_dynamicArea_DelArea_G5_Serial(pSerialName, nBaudRateIndex, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId) => bxDual_dynamicArea_DelArea_6G_Serial(pSerialName, nBaudRateIndex, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_InsertSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, byte VoiceFlg, byte StoreFlag) => bxDual_dynamicArea_InsertSoundIndepend(pIP, nPort, ref stSoundData, VoiceFlg, StoreFlag);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56 ePixelRGorGR) => bxDual_dynamicArea_SetDualPixel(ePixelRGorGR);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_UpdateSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, ushort nSoundDataCount, byte StoreFlag) => bxDual_dynamicArea_UpdateSoundIndepend(pIP, nPort, ref stSoundData, nSoundDataCount, StoreFlag);
        int ILedBxDualSdkProxy.BxDual_get_crc16(ref FileCRC16_G56 crc16) => bxDual_get_crc16(ref crc16);
        int ILedBxDualSdkProxy.BxDual_get_crc32(ref FileCRC32_G56 crc32) => bxDual_get_crc32(ref crc32);
        int ILedBxDualSdkProxy.BxDual_InitSdk() => bxDual_InitSdk();
        int ILedBxDualSdkProxy.BxDual_program_AddArea(ushort areaID, ref EQareaHeader aheader) => bxDual_program_AddArea(areaID, ref aheader);
        int ILedBxDualSdkProxy.BxDual_program_addArea_G6(ushort areaID, ref EQareaHeader_G6 aheader) => bxDual_program_addArea_G6(areaID, ref aheader);
        int ILedBxDualSdkProxy.BxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath) => bxDual_program_addFrame(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath) => bxDual_program_addFrame_G6(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_addPlayPeriodGrp(ref EQprogramppGrp_G56 header) => bxDual_program_addPlayPeriodGrp(ref header);
        int ILedBxDualSdkProxy.BxDual_program_addPlayPeriodGrp_G6(ref EQprogramppGrp_G56 header) => bxDual_program_addPlayPeriodGrp_G6(ref header);
        int ILedBxDualSdkProxy.BxDual_program_addProgram(ref EQprogramHeader programH) => bxDual_program_addProgram(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_addProgram_G6(ref EQprogramHeader_G6 programH) => bxDual_program_addProgram_G6(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_backGroundColor_G6(ushort areaID, ref EQpageHeader_G6 pheader, int BGColor) => bxDual_program_backGroundColor_G6(areaID, ref pheader, BGColor);
        int ILedBxDualSdkProxy.BxDual_program_backGroundPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath) => bxDual_program_backGroundPic_G6(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_changeFrame(ref EQscreenframeHeader sfHeader, byte[] picPath) => bxDual_program_changeFrame(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_changeFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath) => bxDual_program_changeFrame_G6(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_changeProgramParams(ref EQprogramHeader programH) => bxDual_program_changeProgramParams(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_changeProgramParams_G6(ref EQprogramHeader_G6 programH) => bxDual_program_changeProgramParams_G6(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_deleteArea(ushort areaID) => bxDual_program_deleteArea(areaID);
        int ILedBxDualSdkProxy.BxDual_program_deleteArea_G6(ushort areaID) => bxDual_program_deleteArea_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_deleteProgram() => bxDual_program_deleteProgram();
        int ILedBxDualSdkProxy.BxDual_program_deleteProgram_G6() => bxDual_program_deleteProgram_G6();
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader pheader) => bxDual_program_fontPath_picturesAreaAddTxt(areaID, str, fontPathName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader_G6 pheader) => bxDual_program_fontPath_picturesAreaAddTxt_G6(areaID, str, fontPathName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader) => bxDual_program_fontPath_picturesAreaChangeTxt(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaChangeTxt_G6(ushort areaID, byte[] str, ref EQpageHeader_G6 pheader) => bxDual_program_fontPath_picturesAreaChangeTxt_G6(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData) => bxDual_program_fontPath_timeAreaAddContent(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData) => bxDual_program_fontPath_timeAreaAddContent_G6(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_freeBuffer(ref EQprogram program) => bxDual_program_freeBuffer(ref program);
        int ILedBxDualSdkProxy.BxDual_program_freeBuffer_G6(ref EQprogram_G6 program) => bxDual_program_freeBuffer_G6(ref program);
        int ILedBxDualSdkProxy.BxDual_program_IntegrateProgramFile(ref EQprogram program) => bxDual_program_IntegrateProgramFile(ref program);
        int ILedBxDualSdkProxy.BxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program) => bxDual_program_IntegrateProgramFile_G6(ref program);
        int ILedBxDualSdkProxy.BxDual_program_MoveArea(ushort areaID, int x, int y, int width, int height) => bxDual_program_MoveArea(areaID, x, y, width, height);
        int ILedBxDualSdkProxy.BxDual_program_MoveArea_G6(ushort areaID, int x, int y, int width, int height) => bxDual_program_MoveArea_G6(areaID, x, y, width, height);
        int ILedBxDualSdkProxy.BxDual_program_pictureArea(int programID, byte[] ip, ushort port) => bxDual_program_pictureArea(programID, ip, port);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaAddPic(ushort areaID, ushort picID, ref EQpageHeader pheader, byte[] picPath) => bxDual_program_pictureAreaAddPic(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath) => bxDual_program_pictureAreaAddPic_G6(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaChangePic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath) => bxDual_program_pictureAreaChangePic_G6(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaChangeSoundSettings_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData) => bxDual_program_pictureAreaChangeSoundSettings_G6(areaID, sheader, soundData);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaDisableSound_G6(ushort areaID) => bxDual_program_pictureAreaDisableSound_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaEnableSound_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData) => bxDual_program_pictureAreaEnableSound_G6(areaID, sheader, soundData);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaGetOnePage(ushort areaID, int pageNum, ref GetPageData pageData) => bxDual_program_pictureAreaGetOnePage(areaID, pageNum, ref pageData);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaRemoveFrame(ushort areaID) => bxDual_program_pictureAreaRemoveFrame(areaID);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddFrame(ushort areaID, ref EQareaframeHeader afHeader, byte[] picPath) => bxDual_program_picturesAreaAddFrame(areaID, ref afHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddFrame_G6(ushort areaID, ref EQscreenframeHeader_G6 afHeader, byte[] picPath) => bxDual_program_picturesAreaAddFrame_G6(areaID, ref afHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader pheader) => bxDual_program_picturesAreaAddTxt(areaID, str, fontName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader_G6 pheader) => bxDual_program_picturesAreaAddTxt_G6(areaID, str, fontName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader) => bxDual_program_picturesAreaChangeTxt(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaChangeTxt_G6(ushort areaID, IntPtr str, ref EQpageHeader_G6 pheader) => bxDual_program_picturesAreaChangeTxt_G6(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_removeFrame() => bxDual_program_removeFrame();
        int ILedBxDualSdkProxy.BxDual_program_removeFrame_G6() => bxDual_program_removeFrame_G6();
        int ILedBxDualSdkProxy.BxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor) => bxDual_program_setScreenParams_G56(color, ControllerType, doubleColor);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorAreaHumidity_G5(ushort nAreaID, byte nSensorType, byte nHumidityMode, byte nHumidityCorrectionPol, byte nHumidityCorrection, byte nHumidityThresh, byte nHumidityColor, byte nHumidityErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation) => bxDual_program_SetSensorAreaHumidity_G5(nAreaID, nSensorType, nHumidityMode, nHumidityCorrectionPol, nHumidityCorrection, nHumidityThresh, nHumidityColor, nHumidityErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorAreaNoise_G5(ushort nAreaID, byte nSensorType, byte nNoiseMode, byte nNoiseCorrectionPol, byte nNoiseCorrection, byte nNoiseThresh, byte nNoiseColor, byte nNoiseErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation) => bxDual_program_SetSensorAreaNoise_G5(nAreaID, nSensorType, nNoiseMode, nNoiseCorrectionPol, nNoiseCorrection, nNoiseThresh, nNoiseColor, nNoiseErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorAreaTemperature_G5(ushort nAreaID, byte nSensorType, byte nTemperatureUnit, byte nTermperatureMode, byte nTemperatureCorrectionPol, byte nTemperatureCorrection, byte nTemperatureThreshPol, byte nTemperatureThresh, byte nTemperatureColor, byte nTemperatureErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation) => bxDual_program_SetSensorAreaTemperature_G5(nAreaID, nSensorType, nTemperatureUnit, nTermperatureMode, nTemperatureCorrectionPol, nTemperatureCorrection, nTemperatureThreshPol, nTemperatureThresh, nTemperatureColor, nTemperatureErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorArea_G6(ushort nAreaID, byte nSensorMode, byte nSensorType, byte nSensorUnit, byte[] pFixedTxt, byte[] pFontName, byte nFontSize, byte nSensorColor, byte SensorErrColor1, int nAlarmValue, byte nSensorThreshPol, byte nDisplayUnitFlag, byte nSensorModeDispType, byte nSensorCorrectionPol, int nSensorCorrection, byte nRatioValue) => bxDual_program_SetSensorArea_G6(nAreaID, nSensorMode, nSensorType, nSensorUnit, pFixedTxt, pFontName, nFontSize, nSensorColor, SensorErrColor1, nAlarmValue, nSensorThreshPol, nDisplayUnitFlag, nSensorModeDispType, nSensorCorrectionPol, nSensorCorrection, nRatioValue);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => bxDual_program_timeAreaAddAnalogClock(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => bxDual_program_timeAreaAddAnalogClock_G6(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData) => bxDual_program_timeAreaAddContent(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData) => bxDual_program_timeAreaAddContent_G6(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddCounterTimer_G6(ushort areaID, ref BXG6_Time_Counter header, byte[] cUnitDay, byte[] cUnitHour, byte[] cUnitMinute, byte[] cUnitSec, byte[] pFixedTxt) => bxDual_program_timeAreaAddCounterTimer_G6(areaID, ref header, cUnitDay, cUnitHour, cUnitMinute, cUnitSec, pFixedTxt);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaCancleBattleTime_G6(ushort areaID) => bxDual_program_timeAreaCancleBattleTime_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => bxDual_program_timeAreaChangeAnalogClock(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => bxDual_program_timeAreaChangeAnalogClock_G6(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeContent(ushort areaID, ref EQtimeAreaData_G56 timeData) => bxDual_program_timeAreaChangeContent(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData) => bxDual_program_timeAreaChangeContent_G6(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeDialPic(ushort areaID, byte[] picPath) => bxDual_program_timeAreaChangeDialPic(areaID, picPath);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeDialPicAdd_G56(ushort areaID, byte[] picAdd, int picLen) => bxDual_program_timeAreaChangeDialPicAdd_G56(areaID, picAdd, picLen);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeDialPic_G6(ushort areaID, byte[] picPath) => bxDual_program_timeAreaChangeDialPic_G6(areaID, picPath);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaGetOnePage(ushort areaID, ref GetPageData pageData) => bxDual_program_timeAreaGetOnePage(areaID, ref pageData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaRemoveDialPic(ushort areaID) => bxDual_program_timeAreaRemoveDialPic(areaID);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaRemoveDialPic_G6(ushort areaID) => bxDual_program_timeAreaRemoveDialPic_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaSetBattleTime_G6(ushort areaID, ref EQTimeAreaBattle_G6 header) => bxDual_program_timeAreaSetBattleTime_G6(areaID, ref header);
        void ILedBxDualSdkProxy.BxDual_ReleaseSdk() => bxDual_ReleaseSdk();
        int ILedBxDualSdkProxy.BxDual_set_packetLen(ushort packetLen) => bxDual_set_packetLen(packetLen);
        int ILedBxDualSdkProxy.BxDual_set_screenNum_G56(ushort usDstAddr) => bxDual_set_screenNum_G56(usDstAddr);
        #endregion
    }
    internal class LedBxDualSdkLoader : ASdkDynamicLoader, ILedBxDualSdkProxy
    {
        #region // 委托定义
        private DCreater.bxDual_cmd_AT_getWifiSsidPwd _bxDual_cmd_AT_getWifiSsidPwd;
        private DCreater.bxDual_cmd_AT_setWifiSsidPwd _bxDual_cmd_AT_setWifiSsidPwd;
        private DCreater.bxDual_cmd_battieTime _bxDual_cmd_battieTime;
        private DCreater.bxDual_cmd_cancelTimingOnOff _bxDual_cmd_cancelTimingOnOff;
        private DCreater.bxDual_cmd_check_controllerStatus _bxDual_cmd_check_controllerStatus;
        private DCreater.bxDual_cmd_check_time _bxDual_cmd_check_time;
        private DCreater.bxDual_cmd_check_time_uart _bxDual_cmd_check_time_uart;
        private DCreater.bxDual_cmd_coerceOnOff _bxDual_cmd_coerceOnOff;
        private DCreater.bxDual_cmd_coerceOnOff_uart _bxDual_cmd_coerceOnOff_uart;
        private DCreater.bxDual_cmd_confDeleteFormatFile _bxDual_cmd_confDeleteFormatFile;
        private DCreater.bxDual_cmd_confReedFileBlock _bxDual_cmd_confReedFileBlock;
        private DCreater.bxDual_cmd_confStartReedFile _bxDual_cmd_confStartReedFile;
        private DCreater.bxDual_cmd_confWriteFile _bxDual_cmd_confWriteFile;
        private DCreater.bxDual_cmd_deletePassword _bxDual_cmd_deletePassword;
        private DCreater.bxDual_cmd_firmwareActivate _bxDual_cmd_firmwareActivate;
        private DCreater.bxDual_cmd_getFileAttr _bxDual_cmd_getFileAttr;
        private DCreater.bxDual_cmd_getSensorBrightnessValue _bxDual_cmd_getSensorBrightnessValue;
        private DCreater.bxDual_cmd_getStopwatch _bxDual_cmd_getStopwatch;
        private DCreater.bxDual_cmd_ofsDeleteFormatFile _bxDual_cmd_ofsDeleteFormatFile;
        private DCreater.bxDual_cmd_ofsEndFileTransf _bxDual_cmd_ofsEndFileTransf;
        private DCreater.bxDual_cmd_ofsFormat _bxDual_cmd_ofsFormat;
        private DCreater.bxDual_cmd_ofsGetMemoryVolume _bxDual_cmd_ofsGetMemoryVolume;
        private DCreater.bxDual_cmd_ofsGetTransStatus _bxDual_cmd_ofsGetTransStatus;
        private DCreater.bxDual_cmd_ofsReedDirBlock _bxDual_cmd_ofsReedDirBlock;
        private DCreater.bxDual_cmd_ofsReedFileBlock _bxDual_cmd_ofsReedFileBlock;
        private DCreater.bxDual_cmd_ofsStartFileTransf _bxDual_cmd_ofsStartFileTransf;
        private DCreater.bxDual_cmd_ofsStartReedFile _bxDual_cmd_ofsStartReedFile;
        private DCreater.bxDual_cmd_ofsWriteFile _bxDual_cmd_ofsWriteFile;
        private DCreater.bxDual_cmd_ofs_freeDirBlock _bxDual_cmd_ofs_freeDirBlock;
        private DCreater.bxDual_cmd_programLock _bxDual_cmd_programLock;
        private DCreater.bxDual_cmd_readControllerID _bxDual_cmd_readControllerID;
        private DCreater.bxDual_cmd_screenLock _bxDual_cmd_screenLock;
        private DCreater.bxDual_cmd_searchController _bxDual_cmd_searchController;
        private DCreater.bxDual_cmd_sendConfigFile _bxDual_cmd_sendConfigFile;
        private DCreater.bxDual_cmd_sendConfigFile_G6 _bxDual_cmd_sendConfigFile_G6;
        private DCreater.bxDual_cmd_setBrightness _bxDual_cmd_setBrightness;
        private DCreater.bxDual_cmd_setBrightness_uart _bxDual_cmd_setBrightness_uart;
        private DCreater.bxDual_cmd_setBtnFunc _bxDual_cmd_setBtnFunc;
        private DCreater.bxDual_cmd_setDelayTime _bxDual_cmd_setDelayTime;
        private DCreater.bxDual_cmd_setDispMode _bxDual_cmd_setDispMode;
        private DCreater.bxDual_cmd_setPassword _bxDual_cmd_setPassword;
        private DCreater.bxDual_cmd_setScreenAddress _bxDual_cmd_setScreenAddress;
        private DCreater.bxDual_cmd_setSpeedAdjust _bxDual_cmd_setSpeedAdjust;
        private DCreater.bxDual_cmd_setTimingReset _bxDual_cmd_setTimingReset;
        private DCreater.bxDual_cmd_sysReset _bxDual_cmd_sysReset;
        private DCreater.bxDual_cmd_tcpNetworkSearch_6G _bxDual_cmd_tcpNetworkSearch_6G;
        private DCreater.bxDual_cmd_tcpNetworkSearch_6G_Web _bxDual_cmd_tcpNetworkSearch_6G_Web;
        private DCreater.bxDual_cmd_tcpPing _bxDual_cmd_tcpPing;
        private DCreater.bxDual_cmd_timingOnOff _bxDual_cmd_timingOnOff;
        private DCreater.bxDual_cmd_uart_confDeleteFormatFile _bxDual_cmd_uart_confDeleteFormatFile;
        private DCreater.bxDual_cmd_uart_confReedFileBlock _bxDual_cmd_uart_confReedFileBlock;
        private DCreater.bxDual_cmd_uart_confStartReedFile _bxDual_cmd_uart_confStartReedFile;
        private DCreater.bxDual_cmd_uart_confWriteFile _bxDual_cmd_uart_confWriteFile;
        private DCreater.bxDual_cmd_uart_ofsDeleteFormatFile _bxDual_cmd_uart_ofsDeleteFormatFile;
        private DCreater.bxDual_cmd_uart_ofsEndFileTransf _bxDual_cmd_uart_ofsEndFileTransf;
        private DCreater.bxDual_cmd_uart_ofsFormat _bxDual_cmd_uart_ofsFormat;
        private DCreater.bxDual_cmd_uart_ofsFreeDirBlock _bxDual_cmd_uart_ofsFreeDirBlock;
        private DCreater.bxDual_cmd_uart_ofsGetMemoryVolume _bxDual_cmd_uart_ofsGetMemoryVolume;
        private DCreater.bxDual_cmd_uart_ofsGetTransStatus _bxDual_cmd_uart_ofsGetTransStatus;
        private DCreater.bxDual_cmd_uart_ofsReedDirBlock _bxDual_cmd_uart_ofsReedDirBlock;
        private DCreater.bxDual_cmd_uart_ofsReedFileBlock _bxDual_cmd_uart_ofsReedFileBlock;
        private DCreater.bxDual_cmd_uart_ofsStartFileTransf _bxDual_cmd_uart_ofsStartFileTransf;
        private DCreater.bxDual_cmd_uart_ofsStartReedFile _bxDual_cmd_uart_ofsStartReedFile;
        private DCreater.bxDual_cmd_uart_ofsWriteFile _bxDual_cmd_uart_ofsWriteFile;
        private DCreater.bxDual_cmd_uart_programLock _bxDual_cmd_uart_programLock;
        private DCreater.bxDual_cmd_uart_programLock_6G _bxDual_cmd_uart_programLock_6G;
        private DCreater.bxDual_cmd_uart_searchController _bxDual_cmd_uart_searchController;
        private DCreater.bxDual_cmd_uart_search_Net_6G _bxDual_cmd_uart_search_Net_6G;
        private DCreater.bxDual_cmd_uart_search_Net_6G_Web _bxDual_cmd_uart_search_Net_6G_Web;
        private DCreater.bxDual_cmd_uart_sendConfigFile _bxDual_cmd_uart_sendConfigFile;
        private DCreater.bxDual_cmd_udpNetworkSearch _bxDual_cmd_udpNetworkSearch;
        private DCreater.bxDual_cmd_udpNetworkSearch_6G _bxDual_cmd_udpNetworkSearch_6G;
        private DCreater.bxDual_cmd_udpNetworkSearch_6G_Web _bxDual_cmd_udpNetworkSearch_6G_Web;
        private DCreater.bxDual_cmd_udpPing _bxDual_cmd_udpPing;
        private DCreater.bxDual_cmd_udpSetIP _bxDual_cmd_udpSetIP;
        private DCreater.bxDual_cmd_udpSetMac _bxDual_cmd_udpSetMac;
        private DCreater.bxDual_dynamicAreaS_AddAreaPic_6G _bxDual_dynamicAreaS_AddAreaPic_6G;
        private DCreater.bxDual_dynamicAreaS_AddAreaPic_6G_Serial _bxDual_dynamicAreaS_AddAreaPic_6G_Serial;
        private DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G;
        private DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial;
        private DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G _bxDual_dynamicAreaS_AddTxtDetails_6G;
        private DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G_Serial _bxDual_dynamicAreaS_AddTxtDetails_6G_Serial;
        private DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G;
        private DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaInfos_5G _bxDual_dynamicArea_AddAreaInfos_5G;
        private DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Point _bxDual_dynamicArea_AddAreaInfos_5G_Point;
        private DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Serial _bxDual_dynamicArea_AddAreaInfos_5G_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaInfos_6G _bxDual_dynamicArea_AddAreaInfos_6G;
        private DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2 _bxDual_dynamicArea_AddAreaInfos_6G_V2;
        private DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial _bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaInfos_G6_Serial _bxDual_dynamicArea_AddAreaInfos_G6_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaPic_6G _bxDual_dynamicArea_AddAreaPic_6G;
        private DCreater.bxDual_dynamicArea_AddAreaPic_6G_Serial _bxDual_dynamicArea_AddAreaPic_6G_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_6G _bxDual_dynamicArea_AddAreaPic_WithProgram_6G;
        private DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial _bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G _bxDual_dynamicArea_AddAreaTxtDetails_6G;
        private DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial _bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G;
        private DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaTxt_6G _bxDual_dynamicArea_AddAreaTxt_6G;
        private DCreater.bxDual_dynamicArea_AddAreaWithPic_5G _bxDual_dynamicArea_AddAreaWithPic_5G;
        private DCreater.bxDual_dynamicArea_AddAreaWithPic_5G_Serial _bxDual_dynamicArea_AddAreaWithPic_5G_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G _bxDual_dynamicArea_AddAreaWithTxt_5G;
        private DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G_Serial _bxDual_dynamicArea_AddAreaWithTxt_5G_Serial;
        private DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G _bxDual_dynamicArea_AddAreaWithTxt_Point_5G;
        private DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial _bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial;
        private DCreater.bxDual_dynamicArea_DelAreaS_5G _bxDual_dynamicArea_DelAreaS_5G;
        private DCreater.bxDual_dynamicArea_DelAreas_6G _bxDual_dynamicArea_DelAreas_6G;
        private DCreater.bxDual_dynamicArea_DelAreaS_G5_Serial _bxDual_dynamicArea_DelAreaS_G5_Serial;
        private DCreater.bxDual_dynamicArea_DelAreas_6G_Serial _bxDual_dynamicArea_DelAreas_6G_Serial;
        private DCreater.bxDual_dynamicArea_DelArea_5G _bxDual_dynamicArea_DelArea_5G;
        private DCreater.bxDual_dynamicArea_DelArea_6G _bxDual_dynamicArea_DelArea_6G;
        private DCreater.bxDual_dynamicArea_DelArea_G5_Serial _bxDual_dynamicArea_DelArea_G5_Serial;
        private DCreater.bxDual_dynamicArea_DelArea_6G_Serial _bxDual_dynamicArea_DelArea_6G_Serial;
        private DCreater.bxDual_dynamicArea_InsertSoundIndepend _bxDual_dynamicArea_InsertSoundIndepend;
        private DCreater.bxDual_dynamicArea_SetDualPixel _bxDual_dynamicArea_SetDualPixel;
        private DCreater.bxDual_dynamicArea_UpdateSoundIndepend _bxDual_dynamicArea_UpdateSoundIndepend;
        private DCreater.bxDual_get_crc16 _bxDual_get_crc16;
        private DCreater.bxDual_get_crc32 _bxDual_get_crc32;
        private DCreater.bxDual_InitSdk _bxDual_InitSdk;
        private DCreater.bxDual_program_AddArea _bxDual_program_AddArea;
        private DCreater.bxDual_program_addArea_G6 _bxDual_program_addArea_G6;
        private DCreater.bxDual_program_addFrame _bxDual_program_addFrame;
        private DCreater.bxDual_program_addFrame_G6 _bxDual_program_addFrame_G6;
        private DCreater.bxDual_program_addPlayPeriodGrp _bxDual_program_addPlayPeriodGrp;
        private DCreater.bxDual_program_addPlayPeriodGrp_G6 _bxDual_program_addPlayPeriodGrp_G6;
        private DCreater.bxDual_program_addProgram _bxDual_program_addProgram;
        private DCreater.bxDual_program_addProgram_G6 _bxDual_program_addProgram_G6;
        private DCreater.bxDual_program_backGroundColor_G6 _bxDual_program_backGroundColor_G6;
        private DCreater.bxDual_program_backGroundPic_G6 _bxDual_program_backGroundPic_G6;
        private DCreater.bxDual_program_changeFrame _bxDual_program_changeFrame;
        private DCreater.bxDual_program_changeFrame_G6 _bxDual_program_changeFrame_G6;
        private DCreater.bxDual_program_changeProgramParams _bxDual_program_changeProgramParams;
        private DCreater.bxDual_program_changeProgramParams_G6 _bxDual_program_changeProgramParams_G6;
        private DCreater.bxDual_program_deleteArea _bxDual_program_deleteArea;
        private DCreater.bxDual_program_deleteArea_G6 _bxDual_program_deleteArea_G6;
        private DCreater.bxDual_program_deleteProgram _bxDual_program_deleteProgram;
        private DCreater.bxDual_program_deleteProgram_G6 _bxDual_program_deleteProgram_G6;
        private DCreater.bxDual_program_fontPath_picturesAreaAddTxt _bxDual_program_fontPath_picturesAreaAddTxt;
        private DCreater.bxDual_program_fontPath_picturesAreaAddTxt_G6 _bxDual_program_fontPath_picturesAreaAddTxt_G6;
        private DCreater.bxDual_program_fontPath_picturesAreaChangeTxt _bxDual_program_fontPath_picturesAreaChangeTxt;
        private DCreater.bxDual_program_fontPath_picturesAreaChangeTxt_G6 _bxDual_program_fontPath_picturesAreaChangeTxt_G6;
        private DCreater.bxDual_program_fontPath_timeAreaAddContent _bxDual_program_fontPath_timeAreaAddContent;
        private DCreater.bxDual_program_fontPath_timeAreaAddContent_G6 _bxDual_program_fontPath_timeAreaAddContent_G6;
        private DCreater.bxDual_program_freeBuffer _bxDual_program_freeBuffer;
        private DCreater.bxDual_program_freeBuffer_G6 _bxDual_program_freeBuffer_G6;
        private DCreater.bxDual_program_IntegrateProgramFile _bxDual_program_IntegrateProgramFile;
        private DCreater.bxDual_program_IntegrateProgramFile_G6 _bxDual_program_IntegrateProgramFile_G6;
        private DCreater.bxDual_program_MoveArea _bxDual_program_MoveArea;
        private DCreater.bxDual_program_MoveArea_G6 _bxDual_program_MoveArea_G6;
        private DCreater.bxDual_program_pictureArea _bxDual_program_pictureArea;
        private DCreater.bxDual_program_pictureAreaAddPic _bxDual_program_pictureAreaAddPic;
        private DCreater.bxDual_program_pictureAreaAddPic_G6 _bxDual_program_pictureAreaAddPic_G6;
        private DCreater.bxDual_program_pictureAreaChangePic_G6 _bxDual_program_pictureAreaChangePic_G6;
        private DCreater.bxDual_program_pictureAreaChangeSoundSettings_G6 _bxDual_program_pictureAreaChangeSoundSettings_G6;
        private DCreater.bxDual_program_pictureAreaDisableSound_G6 _bxDual_program_pictureAreaDisableSound_G6;
        private DCreater.bxDual_program_pictureAreaEnableSound_G6 _bxDual_program_pictureAreaEnableSound_G6;
        private DCreater.bxDual_program_pictureAreaGetOnePage _bxDual_program_pictureAreaGetOnePage;
        private DCreater.bxDual_program_pictureAreaRemoveFrame _bxDual_program_pictureAreaRemoveFrame;
        private DCreater.bxDual_program_picturesAreaAddFrame _bxDual_program_picturesAreaAddFrame;
        private DCreater.bxDual_program_picturesAreaAddFrame_G6 _bxDual_program_picturesAreaAddFrame_G6;
        private DCreater.bxDual_program_picturesAreaAddTxt _bxDual_program_picturesAreaAddTxt;
        private DCreater.bxDual_program_picturesAreaAddTxt_G6 _bxDual_program_picturesAreaAddTxt_G6;
        private DCreater.bxDual_program_picturesAreaChangeTxt _bxDual_program_picturesAreaChangeTxt;
        private DCreater.bxDual_program_picturesAreaChangeTxt_G6 _bxDual_program_picturesAreaChangeTxt_G6;
        private DCreater.bxDual_program_removeFrame _bxDual_program_removeFrame;
        private DCreater.bxDual_program_removeFrame_G6 _bxDual_program_removeFrame_G6;
        private DCreater.bxDual_program_setScreenParams_G56 _bxDual_program_setScreenParams_G56;
        private DCreater.bxDual_program_SetSensorAreaHumidity_G5 _bxDual_program_SetSensorAreaHumidity_G5;
        private DCreater.bxDual_program_SetSensorAreaNoise_G5 _bxDual_program_SetSensorAreaNoise_G5;
        private DCreater.bxDual_program_SetSensorAreaTemperature_G5 _bxDual_program_SetSensorAreaTemperature_G5;
        private DCreater.bxDual_program_SetSensorArea_G6 _bxDual_program_SetSensorArea_G6;
        private DCreater.bxDual_program_timeAreaAddAnalogClock _bxDual_program_timeAreaAddAnalogClock;
        private DCreater.bxDual_program_timeAreaAddAnalogClock_G6 _bxDual_program_timeAreaAddAnalogClock_G6;
        private DCreater.bxDual_program_timeAreaAddContent _bxDual_program_timeAreaAddContent;
        private DCreater.bxDual_program_timeAreaAddContent_G6 _bxDual_program_timeAreaAddContent_G6;
        private DCreater.bxDual_program_timeAreaAddCounterTimer_G6 _bxDual_program_timeAreaAddCounterTimer_G6;
        private DCreater.bxDual_program_timeAreaCancleBattleTime_G6 _bxDual_program_timeAreaCancleBattleTime_G6;
        private DCreater.bxDual_program_timeAreaChangeAnalogClock _bxDual_program_timeAreaChangeAnalogClock;
        private DCreater.bxDual_program_timeAreaChangeAnalogClock_G6 _bxDual_program_timeAreaChangeAnalogClock_G6;
        private DCreater.bxDual_program_timeAreaChangeContent _bxDual_program_timeAreaChangeContent;
        private DCreater.bxDual_program_timeAreaChangeContent_G6 _bxDual_program_timeAreaChangeContent_G6;
        private DCreater.bxDual_program_timeAreaChangeDialPic _bxDual_program_timeAreaChangeDialPic;
        private DCreater.bxDual_program_timeAreaChangeDialPicAdd_G56 _bxDual_program_timeAreaChangeDialPicAdd_G56;
        private DCreater.bxDual_program_timeAreaChangeDialPic_G6 _bxDual_program_timeAreaChangeDialPic_G6;
        private DCreater.bxDual_program_timeAreaGetOnePage _bxDual_program_timeAreaGetOnePage;
        private DCreater.bxDual_program_timeAreaRemoveDialPic _bxDual_program_timeAreaRemoveDialPic;
        private DCreater.bxDual_program_timeAreaRemoveDialPic_G6 _bxDual_program_timeAreaRemoveDialPic_G6;
        private DCreater.bxDual_program_timeAreaSetBattleTime_G6 _bxDual_program_timeAreaSetBattleTime_G6;
        private DCreater.bxDual_ReleaseSdk _bxDual_ReleaseSdk;
        private DCreater.bxDual_set_packetLen _bxDual_set_packetLen;
        private DCreater.bxDual_set_screenNum_G56 _bxDual_set_screenNum_G56;
        #endregion 委托定义
        public LedBxDualSdkLoader()
        {
            if (Environment.Is64BitProcess) { Initialize64(); } else { Initialize32(); }
        }
        public void Initialize32()
        {
            _bxDual_cmd_AT_getWifiSsidPwd = GetDelegate<DCreater.bxDual_cmd_AT_getWifiSsidPwd>(nameof(DCreater.bxDual_cmd_AT_getWifiSsidPwd));
            _bxDual_cmd_AT_setWifiSsidPwd = GetDelegate<DCreater.bxDual_cmd_AT_setWifiSsidPwd>(nameof(DCreater.bxDual_cmd_AT_setWifiSsidPwd));
            _bxDual_cmd_battieTime = GetDelegate<DCreater.bxDual_cmd_battieTime>(nameof(DCreater.bxDual_cmd_battieTime));
            _bxDual_cmd_cancelTimingOnOff = GetDelegate<DCreater.bxDual_cmd_cancelTimingOnOff>(nameof(DCreater.bxDual_cmd_cancelTimingOnOff));
            _bxDual_cmd_check_controllerStatus = GetDelegate<DCreater.bxDual_cmd_check_controllerStatus>(nameof(DCreater.bxDual_cmd_check_controllerStatus));
            _bxDual_cmd_check_time = GetDelegate<DCreater.bxDual_cmd_check_time>(nameof(DCreater.bxDual_cmd_check_time));
            _bxDual_cmd_check_time_uart = GetDelegate<DCreater.bxDual_cmd_check_time_uart>($"_{nameof(DCreater.bxDual_cmd_check_time_uart)}@8");
            _bxDual_cmd_coerceOnOff = GetDelegate<DCreater.bxDual_cmd_coerceOnOff>(nameof(DCreater.bxDual_cmd_coerceOnOff));
            _bxDual_cmd_coerceOnOff_uart = GetDelegate<DCreater.bxDual_cmd_coerceOnOff_uart>($"_{nameof(DCreater.bxDual_cmd_coerceOnOff_uart)}@12");
            _bxDual_cmd_confDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_confDeleteFormatFile>(nameof(DCreater.bxDual_cmd_confDeleteFormatFile));
            _bxDual_cmd_confReedFileBlock = GetDelegate<DCreater.bxDual_cmd_confReedFileBlock>(nameof(DCreater.bxDual_cmd_confReedFileBlock));
            _bxDual_cmd_confStartReedFile = GetDelegate<DCreater.bxDual_cmd_confStartReedFile>(nameof(DCreater.bxDual_cmd_confStartReedFile));
            _bxDual_cmd_confWriteFile = GetDelegate<DCreater.bxDual_cmd_confWriteFile>(nameof(DCreater.bxDual_cmd_confWriteFile));
            _bxDual_cmd_deletePassword = GetDelegate<DCreater.bxDual_cmd_deletePassword>(nameof(DCreater.bxDual_cmd_deletePassword));
            _bxDual_cmd_firmwareActivate = GetDelegate<DCreater.bxDual_cmd_firmwareActivate>(nameof(DCreater.bxDual_cmd_firmwareActivate));
            _bxDual_cmd_getFileAttr = GetDelegate<DCreater.bxDual_cmd_getFileAttr>(nameof(DCreater.bxDual_cmd_getFileAttr));
            _bxDual_cmd_getSensorBrightnessValue = GetDelegate<DCreater.bxDual_cmd_getSensorBrightnessValue>(nameof(DCreater.bxDual_cmd_getSensorBrightnessValue));
            _bxDual_cmd_getStopwatch = GetDelegate<DCreater.bxDual_cmd_getStopwatch>(nameof(DCreater.bxDual_cmd_getStopwatch));
            _bxDual_cmd_ofsDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_ofsDeleteFormatFile>(nameof(DCreater.bxDual_cmd_ofsDeleteFormatFile));
            _bxDual_cmd_ofsEndFileTransf = GetDelegate<DCreater.bxDual_cmd_ofsEndFileTransf>(nameof(DCreater.bxDual_cmd_ofsEndFileTransf));
            _bxDual_cmd_ofsFormat = GetDelegate<DCreater.bxDual_cmd_ofsFormat>(nameof(DCreater.bxDual_cmd_ofsFormat));
            _bxDual_cmd_ofsGetMemoryVolume = GetDelegate<DCreater.bxDual_cmd_ofsGetMemoryVolume>(nameof(DCreater.bxDual_cmd_ofsGetMemoryVolume));
            _bxDual_cmd_ofsGetTransStatus = GetDelegate<DCreater.bxDual_cmd_ofsGetTransStatus>(nameof(DCreater.bxDual_cmd_ofsGetTransStatus));
            _bxDual_cmd_ofsReedDirBlock = GetDelegate<DCreater.bxDual_cmd_ofsReedDirBlock>(nameof(DCreater.bxDual_cmd_ofsReedDirBlock));
            _bxDual_cmd_ofsReedFileBlock = GetDelegate<DCreater.bxDual_cmd_ofsReedFileBlock>(nameof(DCreater.bxDual_cmd_ofsReedFileBlock));
            _bxDual_cmd_ofsStartFileTransf = GetDelegate<DCreater.bxDual_cmd_ofsStartFileTransf>(nameof(DCreater.bxDual_cmd_ofsStartFileTransf));
            _bxDual_cmd_ofsStartReedFile = GetDelegate<DCreater.bxDual_cmd_ofsStartReedFile>(nameof(DCreater.bxDual_cmd_ofsStartReedFile));
            _bxDual_cmd_ofsWriteFile = GetDelegate<DCreater.bxDual_cmd_ofsWriteFile>(nameof(DCreater.bxDual_cmd_ofsWriteFile));
            _bxDual_cmd_ofs_freeDirBlock = GetDelegate<DCreater.bxDual_cmd_ofs_freeDirBlock>(nameof(DCreater.bxDual_cmd_ofs_freeDirBlock));
            _bxDual_cmd_programLock = GetDelegate<DCreater.bxDual_cmd_programLock>(nameof(DCreater.bxDual_cmd_programLock));
            _bxDual_cmd_readControllerID = GetDelegate<DCreater.bxDual_cmd_readControllerID>(nameof(DCreater.bxDual_cmd_readControllerID));
            _bxDual_cmd_screenLock = GetDelegate<DCreater.bxDual_cmd_screenLock>(nameof(DCreater.bxDual_cmd_screenLock));
            _bxDual_cmd_searchController = GetDelegate<DCreater.bxDual_cmd_searchController>(nameof(DCreater.bxDual_cmd_searchController));
            _bxDual_cmd_sendConfigFile = GetDelegate<DCreater.bxDual_cmd_sendConfigFile>(nameof(DCreater.bxDual_cmd_sendConfigFile));
            _bxDual_cmd_sendConfigFile_G6 = GetDelegate<DCreater.bxDual_cmd_sendConfigFile_G6>(nameof(DCreater.bxDual_cmd_sendConfigFile_G6));
            _bxDual_cmd_setBrightness = GetDelegate<DCreater.bxDual_cmd_setBrightness>(nameof(DCreater.bxDual_cmd_setBrightness));
            _bxDual_cmd_setBrightness_uart = GetDelegate<DCreater.bxDual_cmd_setBrightness_uart>($"_{nameof(DCreater.bxDual_cmd_setBrightness_uart)}@12");
            _bxDual_cmd_setBtnFunc = GetDelegate<DCreater.bxDual_cmd_setBtnFunc>(nameof(DCreater.bxDual_cmd_setBtnFunc));
            _bxDual_cmd_setDelayTime = GetDelegate<DCreater.bxDual_cmd_setDelayTime>(nameof(DCreater.bxDual_cmd_setDelayTime));
            _bxDual_cmd_setDispMode = GetDelegate<DCreater.bxDual_cmd_setDispMode>(nameof(DCreater.bxDual_cmd_setDispMode));
            _bxDual_cmd_setPassword = GetDelegate<DCreater.bxDual_cmd_setPassword>(nameof(DCreater.bxDual_cmd_setPassword));
            _bxDual_cmd_setScreenAddress = GetDelegate<DCreater.bxDual_cmd_setScreenAddress>(nameof(DCreater.bxDual_cmd_setScreenAddress));
            _bxDual_cmd_setSpeedAdjust = GetDelegate<DCreater.bxDual_cmd_setSpeedAdjust>(nameof(DCreater.bxDual_cmd_setSpeedAdjust));
            _bxDual_cmd_setTimingReset = GetDelegate<DCreater.bxDual_cmd_setTimingReset>(nameof(DCreater.bxDual_cmd_setTimingReset));
            _bxDual_cmd_sysReset = GetDelegate<DCreater.bxDual_cmd_sysReset>(nameof(DCreater.bxDual_cmd_sysReset));
            _bxDual_cmd_tcpNetworkSearch_6G = GetDelegate<DCreater.bxDual_cmd_tcpNetworkSearch_6G>(nameof(DCreater.bxDual_cmd_tcpNetworkSearch_6G));
            _bxDual_cmd_tcpNetworkSearch_6G_Web = GetDelegate<DCreater.bxDual_cmd_tcpNetworkSearch_6G_Web>(nameof(DCreater.bxDual_cmd_tcpNetworkSearch_6G_Web));
            _bxDual_cmd_tcpPing = GetDelegate<DCreater.bxDual_cmd_tcpPing>(nameof(DCreater.bxDual_cmd_tcpPing));
            _bxDual_cmd_timingOnOff = GetDelegate<DCreater.bxDual_cmd_timingOnOff>(nameof(DCreater.bxDual_cmd_timingOnOff));
            _bxDual_cmd_uart_confDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_uart_confDeleteFormatFile>(nameof(DCreater.bxDual_cmd_uart_confDeleteFormatFile));
            _bxDual_cmd_uart_confReedFileBlock = GetDelegate<DCreater.bxDual_cmd_uart_confReedFileBlock>(nameof(DCreater.bxDual_cmd_uart_confReedFileBlock));
            _bxDual_cmd_uart_confStartReedFile = GetDelegate<DCreater.bxDual_cmd_uart_confStartReedFile>(nameof(DCreater.bxDual_cmd_uart_confStartReedFile));
            _bxDual_cmd_uart_confWriteFile = GetDelegate<DCreater.bxDual_cmd_uart_confWriteFile>(nameof(DCreater.bxDual_cmd_uart_confWriteFile));
            _bxDual_cmd_uart_ofsDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_uart_ofsDeleteFormatFile>(nameof(DCreater.bxDual_cmd_uart_ofsDeleteFormatFile));
            _bxDual_cmd_uart_ofsEndFileTransf = GetDelegate<DCreater.bxDual_cmd_uart_ofsEndFileTransf>(nameof(DCreater.bxDual_cmd_uart_ofsEndFileTransf));
            _bxDual_cmd_uart_ofsFormat = GetDelegate<DCreater.bxDual_cmd_uart_ofsFormat>(nameof(DCreater.bxDual_cmd_uart_ofsFormat));
            _bxDual_cmd_uart_ofsFreeDirBlock = GetDelegate<DCreater.bxDual_cmd_uart_ofsFreeDirBlock>(nameof(DCreater.bxDual_cmd_uart_ofsFreeDirBlock));
            _bxDual_cmd_uart_ofsGetMemoryVolume = GetDelegate<DCreater.bxDual_cmd_uart_ofsGetMemoryVolume>(nameof(DCreater.bxDual_cmd_uart_ofsGetMemoryVolume));
            _bxDual_cmd_uart_ofsGetTransStatus = GetDelegate<DCreater.bxDual_cmd_uart_ofsGetTransStatus>(nameof(DCreater.bxDual_cmd_uart_ofsGetTransStatus));
            _bxDual_cmd_uart_ofsReedDirBlock = GetDelegate<DCreater.bxDual_cmd_uart_ofsReedDirBlock>(nameof(DCreater.bxDual_cmd_uart_ofsReedDirBlock));
            _bxDual_cmd_uart_ofsReedFileBlock = GetDelegate<DCreater.bxDual_cmd_uart_ofsReedFileBlock>(nameof(DCreater.bxDual_cmd_uart_ofsReedFileBlock));
            _bxDual_cmd_uart_ofsStartFileTransf = GetDelegate<DCreater.bxDual_cmd_uart_ofsStartFileTransf>(nameof(DCreater.bxDual_cmd_uart_ofsStartFileTransf));
            _bxDual_cmd_uart_ofsStartReedFile = GetDelegate<DCreater.bxDual_cmd_uart_ofsStartReedFile>(nameof(DCreater.bxDual_cmd_uart_ofsStartReedFile));
            _bxDual_cmd_uart_ofsWriteFile = GetDelegate<DCreater.bxDual_cmd_uart_ofsWriteFile>(nameof(DCreater.bxDual_cmd_uart_ofsWriteFile));
            _bxDual_cmd_uart_programLock = GetDelegate<DCreater.bxDual_cmd_uart_programLock>(nameof(DCreater.bxDual_cmd_uart_programLock));
            _bxDual_cmd_uart_programLock_6G = GetDelegate<DCreater.bxDual_cmd_uart_programLock_6G>(nameof(DCreater.bxDual_cmd_uart_programLock_6G));
            _bxDual_cmd_uart_searchController = GetDelegate<DCreater.bxDual_cmd_uart_searchController>(nameof(DCreater.bxDual_cmd_uart_searchController));
            _bxDual_cmd_uart_search_Net_6G = GetDelegate<DCreater.bxDual_cmd_uart_search_Net_6G>(nameof(DCreater.bxDual_cmd_uart_search_Net_6G));
            _bxDual_cmd_uart_search_Net_6G_Web = GetDelegate<DCreater.bxDual_cmd_uart_search_Net_6G_Web>(nameof(DCreater.bxDual_cmd_uart_search_Net_6G_Web));
            _bxDual_cmd_uart_sendConfigFile = GetDelegate<DCreater.bxDual_cmd_uart_sendConfigFile>(nameof(DCreater.bxDual_cmd_uart_sendConfigFile));
            _bxDual_cmd_udpNetworkSearch = GetDelegate<DCreater.bxDual_cmd_udpNetworkSearch>(nameof(DCreater.bxDual_cmd_udpNetworkSearch));
            _bxDual_cmd_udpNetworkSearch_6G = GetDelegate<DCreater.bxDual_cmd_udpNetworkSearch_6G>(nameof(DCreater.bxDual_cmd_udpNetworkSearch_6G));
            _bxDual_cmd_udpNetworkSearch_6G_Web = GetDelegate<DCreater.bxDual_cmd_udpNetworkSearch_6G_Web>(nameof(DCreater.bxDual_cmd_udpNetworkSearch_6G_Web));
            _bxDual_cmd_udpPing = GetDelegate<DCreater.bxDual_cmd_udpPing>(nameof(DCreater.bxDual_cmd_udpPing));
            _bxDual_cmd_udpSetIP = GetDelegate<DCreater.bxDual_cmd_udpSetIP>(nameof(DCreater.bxDual_cmd_udpSetIP));
            _bxDual_cmd_udpSetMac = GetDelegate<DCreater.bxDual_cmd_udpSetMac>(nameof(DCreater.bxDual_cmd_udpSetMac));
            _bxDual_dynamicAreaS_AddAreaPic_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_6G));
            _bxDual_dynamicAreaS_AddAreaPic_6G_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_6G_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_6G_Serial));
            _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G));
            _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial));
            _bxDual_dynamicAreaS_AddTxtDetails_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G));
            _bxDual_dynamicAreaS_AddTxtDetails_6G_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G_Serial));
            _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G));
            _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial));
            _bxDual_dynamicArea_AddAreaInfos_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_5G));
            _bxDual_dynamicArea_AddAreaInfos_5G_Point = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Point>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Point));
            _bxDual_dynamicArea_AddAreaInfos_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Serial));
            _bxDual_dynamicArea_AddAreaInfos_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_6G));
            _bxDual_dynamicArea_AddAreaInfos_6G_V2 = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2));
            _bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial));
            _bxDual_dynamicArea_AddAreaInfos_G6_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_G6_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_G6_Serial));
            _bxDual_dynamicArea_AddAreaPic_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_6G));
            _bxDual_dynamicArea_AddAreaPic_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_6G_Serial));
            _bxDual_dynamicArea_AddAreaPic_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_6G));
            _bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial));
            _bxDual_dynamicArea_AddAreaTxtDetails_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G));
            _bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial));
            _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G));
            _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial));
            _bxDual_dynamicArea_AddAreaTxt_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxt_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxt_6G));
            _bxDual_dynamicArea_AddAreaWithPic_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithPic_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithPic_5G));
            _bxDual_dynamicArea_AddAreaWithPic_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithPic_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithPic_5G_Serial));
            _bxDual_dynamicArea_AddAreaWithTxt_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G));
            _bxDual_dynamicArea_AddAreaWithTxt_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G_Serial));
            _bxDual_dynamicArea_AddAreaWithTxt_Point_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G));
            _bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial));
            _bxDual_dynamicArea_DelAreaS_5G = GetDelegate<DCreater.bxDual_dynamicArea_DelAreaS_5G>(nameof(DCreater.bxDual_dynamicArea_DelAreaS_5G));
            _bxDual_dynamicArea_DelAreas_6G = GetDelegate<DCreater.bxDual_dynamicArea_DelAreas_6G>(nameof(DCreater.bxDual_dynamicArea_DelAreas_6G));
            _bxDual_dynamicArea_DelAreaS_G5_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelAreaS_G5_Serial>(nameof(DCreater.bxDual_dynamicArea_DelAreaS_G5_Serial));
            _bxDual_dynamicArea_DelAreas_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelAreas_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_DelAreas_6G_Serial));
            _bxDual_dynamicArea_DelArea_5G = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_5G>(nameof(DCreater.bxDual_dynamicArea_DelArea_5G));
            _bxDual_dynamicArea_DelArea_6G = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_6G>(nameof(DCreater.bxDual_dynamicArea_DelArea_6G));
            _bxDual_dynamicArea_DelArea_G5_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_G5_Serial>(nameof(DCreater.bxDual_dynamicArea_DelArea_G5_Serial));
            _bxDual_dynamicArea_DelArea_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_DelArea_6G_Serial));
            _bxDual_dynamicArea_InsertSoundIndepend = GetDelegate<DCreater.bxDual_dynamicArea_InsertSoundIndepend>(nameof(DCreater.bxDual_dynamicArea_InsertSoundIndepend));
            _bxDual_dynamicArea_SetDualPixel = GetDelegate<DCreater.bxDual_dynamicArea_SetDualPixel>(nameof(DCreater.bxDual_dynamicArea_SetDualPixel));
            _bxDual_dynamicArea_UpdateSoundIndepend = GetDelegate<DCreater.bxDual_dynamicArea_UpdateSoundIndepend>(nameof(DCreater.bxDual_dynamicArea_UpdateSoundIndepend));
            _bxDual_get_crc16 = GetDelegate<DCreater.bxDual_get_crc16>(nameof(DCreater.bxDual_get_crc16));
            _bxDual_get_crc32 = GetDelegate<DCreater.bxDual_get_crc32>(nameof(DCreater.bxDual_get_crc32));
            _bxDual_InitSdk = GetDelegate<DCreater.bxDual_InitSdk>(nameof(DCreater.bxDual_InitSdk));
            _bxDual_program_AddArea = GetDelegate<DCreater.bxDual_program_AddArea>(nameof(DCreater.bxDual_program_AddArea));
            _bxDual_program_addArea_G6 = GetDelegate<DCreater.bxDual_program_addArea_G6>(nameof(DCreater.bxDual_program_addArea_G6));
            _bxDual_program_addFrame = GetDelegate<DCreater.bxDual_program_addFrame>(nameof(DCreater.bxDual_program_addFrame));
            _bxDual_program_addFrame_G6 = GetDelegate<DCreater.bxDual_program_addFrame_G6>(nameof(DCreater.bxDual_program_addFrame_G6));
            _bxDual_program_addPlayPeriodGrp = GetDelegate<DCreater.bxDual_program_addPlayPeriodGrp>(nameof(DCreater.bxDual_program_addPlayPeriodGrp));
            _bxDual_program_addPlayPeriodGrp_G6 = GetDelegate<DCreater.bxDual_program_addPlayPeriodGrp_G6>(nameof(DCreater.bxDual_program_addPlayPeriodGrp_G6));
            _bxDual_program_addProgram = GetDelegate<DCreater.bxDual_program_addProgram>(nameof(DCreater.bxDual_program_addProgram));
            _bxDual_program_addProgram_G6 = GetDelegate<DCreater.bxDual_program_addProgram_G6>(nameof(DCreater.bxDual_program_addProgram_G6));
            _bxDual_program_backGroundColor_G6 = GetDelegate<DCreater.bxDual_program_backGroundColor_G6>(nameof(DCreater.bxDual_program_backGroundColor_G6));
            _bxDual_program_backGroundPic_G6 = GetDelegate<DCreater.bxDual_program_backGroundPic_G6>(nameof(DCreater.bxDual_program_backGroundPic_G6));
            _bxDual_program_changeFrame = GetDelegate<DCreater.bxDual_program_changeFrame>(nameof(DCreater.bxDual_program_changeFrame));
            _bxDual_program_changeFrame_G6 = GetDelegate<DCreater.bxDual_program_changeFrame_G6>(nameof(DCreater.bxDual_program_changeFrame_G6));
            _bxDual_program_changeProgramParams = GetDelegate<DCreater.bxDual_program_changeProgramParams>(nameof(DCreater.bxDual_program_changeProgramParams));
            _bxDual_program_changeProgramParams_G6 = GetDelegate<DCreater.bxDual_program_changeProgramParams_G6>(nameof(DCreater.bxDual_program_changeProgramParams_G6));
            _bxDual_program_deleteArea = GetDelegate<DCreater.bxDual_program_deleteArea>(nameof(DCreater.bxDual_program_deleteArea));
            _bxDual_program_deleteArea_G6 = GetDelegate<DCreater.bxDual_program_deleteArea_G6>(nameof(DCreater.bxDual_program_deleteArea_G6));
            _bxDual_program_deleteProgram = GetDelegate<DCreater.bxDual_program_deleteProgram>(nameof(DCreater.bxDual_program_deleteProgram));
            _bxDual_program_deleteProgram_G6 = GetDelegate<DCreater.bxDual_program_deleteProgram_G6>(nameof(DCreater.bxDual_program_deleteProgram_G6));
            _bxDual_program_fontPath_picturesAreaAddTxt = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaAddTxt>(nameof(DCreater.bxDual_program_fontPath_picturesAreaAddTxt));
            _bxDual_program_fontPath_picturesAreaAddTxt_G6 = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaAddTxt_G6>(nameof(DCreater.bxDual_program_fontPath_picturesAreaAddTxt_G6));
            _bxDual_program_fontPath_picturesAreaChangeTxt = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaChangeTxt>(nameof(DCreater.bxDual_program_fontPath_picturesAreaChangeTxt));
            _bxDual_program_fontPath_picturesAreaChangeTxt_G6 = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaChangeTxt_G6>(nameof(DCreater.bxDual_program_fontPath_picturesAreaChangeTxt_G6));
            _bxDual_program_fontPath_timeAreaAddContent = GetDelegate<DCreater.bxDual_program_fontPath_timeAreaAddContent>(nameof(DCreater.bxDual_program_fontPath_timeAreaAddContent));
            _bxDual_program_fontPath_timeAreaAddContent_G6 = GetDelegate<DCreater.bxDual_program_fontPath_timeAreaAddContent_G6>(nameof(DCreater.bxDual_program_fontPath_timeAreaAddContent_G6));
            _bxDual_program_freeBuffer = GetDelegate<DCreater.bxDual_program_freeBuffer>(nameof(DCreater.bxDual_program_freeBuffer));
            _bxDual_program_freeBuffer_G6 = GetDelegate<DCreater.bxDual_program_freeBuffer_G6>(nameof(DCreater.bxDual_program_freeBuffer_G6));
            _bxDual_program_IntegrateProgramFile = GetDelegate<DCreater.bxDual_program_IntegrateProgramFile>(nameof(DCreater.bxDual_program_IntegrateProgramFile));
            _bxDual_program_IntegrateProgramFile_G6 = GetDelegate<DCreater.bxDual_program_IntegrateProgramFile_G6>(nameof(DCreater.bxDual_program_IntegrateProgramFile_G6));
            _bxDual_program_MoveArea = GetDelegate<DCreater.bxDual_program_MoveArea>(nameof(DCreater.bxDual_program_MoveArea));
            _bxDual_program_MoveArea_G6 = GetDelegate<DCreater.bxDual_program_MoveArea_G6>(nameof(DCreater.bxDual_program_MoveArea_G6));
            _bxDual_program_pictureArea = GetDelegate<DCreater.bxDual_program_pictureArea>(nameof(DCreater.bxDual_program_pictureArea));
            _bxDual_program_pictureAreaAddPic = GetDelegate<DCreater.bxDual_program_pictureAreaAddPic>(nameof(DCreater.bxDual_program_pictureAreaAddPic));
            _bxDual_program_pictureAreaAddPic_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaAddPic_G6>(nameof(DCreater.bxDual_program_pictureAreaAddPic_G6));
            _bxDual_program_pictureAreaChangePic_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaChangePic_G6>(nameof(DCreater.bxDual_program_pictureAreaChangePic_G6));
            _bxDual_program_pictureAreaChangeSoundSettings_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaChangeSoundSettings_G6>(nameof(DCreater.bxDual_program_pictureAreaChangeSoundSettings_G6));
            _bxDual_program_pictureAreaDisableSound_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaDisableSound_G6>(nameof(DCreater.bxDual_program_pictureAreaDisableSound_G6));
            _bxDual_program_pictureAreaEnableSound_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaEnableSound_G6>(nameof(DCreater.bxDual_program_pictureAreaEnableSound_G6));
            _bxDual_program_pictureAreaGetOnePage = GetDelegate<DCreater.bxDual_program_pictureAreaGetOnePage>(nameof(DCreater.bxDual_program_pictureAreaGetOnePage));
            _bxDual_program_pictureAreaRemoveFrame = GetDelegate<DCreater.bxDual_program_pictureAreaRemoveFrame>(nameof(DCreater.bxDual_program_pictureAreaRemoveFrame));
            _bxDual_program_picturesAreaAddFrame = GetDelegate<DCreater.bxDual_program_picturesAreaAddFrame>(nameof(DCreater.bxDual_program_picturesAreaAddFrame));
            _bxDual_program_picturesAreaAddFrame_G6 = GetDelegate<DCreater.bxDual_program_picturesAreaAddFrame_G6>(nameof(DCreater.bxDual_program_picturesAreaAddFrame_G6));
            _bxDual_program_picturesAreaAddTxt = GetDelegate<DCreater.bxDual_program_picturesAreaAddTxt>(nameof(DCreater.bxDual_program_picturesAreaAddTxt));
            _bxDual_program_picturesAreaAddTxt_G6 = GetDelegate<DCreater.bxDual_program_picturesAreaAddTxt_G6>(nameof(DCreater.bxDual_program_picturesAreaAddTxt_G6));
            _bxDual_program_picturesAreaChangeTxt = GetDelegate<DCreater.bxDual_program_picturesAreaChangeTxt>(nameof(DCreater.bxDual_program_picturesAreaChangeTxt));
            _bxDual_program_picturesAreaChangeTxt_G6 = GetDelegate<DCreater.bxDual_program_picturesAreaChangeTxt_G6>(nameof(DCreater.bxDual_program_picturesAreaChangeTxt_G6));
            _bxDual_program_removeFrame = GetDelegate<DCreater.bxDual_program_removeFrame>(nameof(DCreater.bxDual_program_removeFrame));
            _bxDual_program_removeFrame_G6 = GetDelegate<DCreater.bxDual_program_removeFrame_G6>(nameof(DCreater.bxDual_program_removeFrame_G6));
            _bxDual_program_setScreenParams_G56 = GetDelegate<DCreater.bxDual_program_setScreenParams_G56>(nameof(DCreater.bxDual_program_setScreenParams_G56));
            _bxDual_program_SetSensorAreaHumidity_G5 = GetDelegate<DCreater.bxDual_program_SetSensorAreaHumidity_G5>($"_{nameof(DCreater.bxDual_program_SetSensorAreaHumidity_G5)}@48");
            _bxDual_program_SetSensorAreaNoise_G5 = GetDelegate<DCreater.bxDual_program_SetSensorAreaNoise_G5>($"_{nameof(DCreater.bxDual_program_SetSensorAreaNoise_G5)}@48");
            _bxDual_program_SetSensorAreaTemperature_G5 = GetDelegate<DCreater.bxDual_program_SetSensorAreaTemperature_G5>($"_{nameof(DCreater.bxDual_program_SetSensorAreaTemperature_G5)}@56");
            _bxDual_program_SetSensorArea_G6 = GetDelegate<DCreater.bxDual_program_SetSensorArea_G6>($"_{nameof(DCreater.bxDual_program_SetSensorArea_G6)}@64");
            _bxDual_program_timeAreaAddAnalogClock = GetDelegate<DCreater.bxDual_program_timeAreaAddAnalogClock>(nameof(DCreater.bxDual_program_timeAreaAddAnalogClock));
            _bxDual_program_timeAreaAddAnalogClock_G6 = GetDelegate<DCreater.bxDual_program_timeAreaAddAnalogClock_G6>(nameof(DCreater.bxDual_program_timeAreaAddAnalogClock_G6));
            _bxDual_program_timeAreaAddContent = GetDelegate<DCreater.bxDual_program_timeAreaAddContent>(nameof(DCreater.bxDual_program_timeAreaAddContent));
            _bxDual_program_timeAreaAddContent_G6 = GetDelegate<DCreater.bxDual_program_timeAreaAddContent_G6>(nameof(DCreater.bxDual_program_timeAreaAddContent_G6));
            _bxDual_program_timeAreaAddCounterTimer_G6 = GetDelegate<DCreater.bxDual_program_timeAreaAddCounterTimer_G6>(nameof(DCreater.bxDual_program_timeAreaAddCounterTimer_G6));
            _bxDual_program_timeAreaCancleBattleTime_G6 = GetDelegate<DCreater.bxDual_program_timeAreaCancleBattleTime_G6>(nameof(DCreater.bxDual_program_timeAreaCancleBattleTime_G6));
            _bxDual_program_timeAreaChangeAnalogClock = GetDelegate<DCreater.bxDual_program_timeAreaChangeAnalogClock>(nameof(DCreater.bxDual_program_timeAreaChangeAnalogClock));
            _bxDual_program_timeAreaChangeAnalogClock_G6 = GetDelegate<DCreater.bxDual_program_timeAreaChangeAnalogClock_G6>(nameof(DCreater.bxDual_program_timeAreaChangeAnalogClock_G6));
            _bxDual_program_timeAreaChangeContent = GetDelegate<DCreater.bxDual_program_timeAreaChangeContent>(nameof(DCreater.bxDual_program_timeAreaChangeContent));
            _bxDual_program_timeAreaChangeContent_G6 = GetDelegate<DCreater.bxDual_program_timeAreaChangeContent_G6>(nameof(DCreater.bxDual_program_timeAreaChangeContent_G6));
            _bxDual_program_timeAreaChangeDialPic = GetDelegate<DCreater.bxDual_program_timeAreaChangeDialPic>(nameof(DCreater.bxDual_program_timeAreaChangeDialPic));
            _bxDual_program_timeAreaChangeDialPicAdd_G56 = GetDelegate<DCreater.bxDual_program_timeAreaChangeDialPicAdd_G56>(nameof(DCreater.bxDual_program_timeAreaChangeDialPicAdd_G56));
            _bxDual_program_timeAreaChangeDialPic_G6 = GetDelegate<DCreater.bxDual_program_timeAreaChangeDialPic_G6>(nameof(DCreater.bxDual_program_timeAreaChangeDialPic_G6));
            _bxDual_program_timeAreaGetOnePage = GetDelegate<DCreater.bxDual_program_timeAreaGetOnePage>(nameof(DCreater.bxDual_program_timeAreaGetOnePage));
            _bxDual_program_timeAreaRemoveDialPic = GetDelegate<DCreater.bxDual_program_timeAreaRemoveDialPic>(nameof(DCreater.bxDual_program_timeAreaRemoveDialPic));
            _bxDual_program_timeAreaRemoveDialPic_G6 = GetDelegate<DCreater.bxDual_program_timeAreaRemoveDialPic_G6>(nameof(DCreater.bxDual_program_timeAreaRemoveDialPic_G6));
            _bxDual_program_timeAreaSetBattleTime_G6 = GetDelegate<DCreater.bxDual_program_timeAreaSetBattleTime_G6>(nameof(DCreater.bxDual_program_timeAreaSetBattleTime_G6));
            _bxDual_ReleaseSdk = GetDelegate<DCreater.bxDual_ReleaseSdk>(nameof(DCreater.bxDual_ReleaseSdk));
            _bxDual_set_packetLen = GetDelegate<DCreater.bxDual_set_packetLen>(nameof(DCreater.bxDual_set_packetLen));
            _bxDual_set_screenNum_G56 = GetDelegate<DCreater.bxDual_set_screenNum_G56>(nameof(DCreater.bxDual_set_screenNum_G56));
        }
        public void Initialize64()
        {
            _bxDual_cmd_AT_getWifiSsidPwd = GetDelegate<DCreater.bxDual_cmd_AT_getWifiSsidPwd>(nameof(DCreater.bxDual_cmd_AT_getWifiSsidPwd));
            _bxDual_cmd_AT_setWifiSsidPwd = GetDelegate<DCreater.bxDual_cmd_AT_setWifiSsidPwd>(nameof(DCreater.bxDual_cmd_AT_setWifiSsidPwd));
            _bxDual_cmd_battieTime = GetDelegate<DCreater.bxDual_cmd_battieTime>(nameof(DCreater.bxDual_cmd_battieTime));
            _bxDual_cmd_cancelTimingOnOff = GetDelegate<DCreater.bxDual_cmd_cancelTimingOnOff>(nameof(DCreater.bxDual_cmd_cancelTimingOnOff));
            _bxDual_cmd_check_controllerStatus = GetDelegate<DCreater.bxDual_cmd_check_controllerStatus>(nameof(DCreater.bxDual_cmd_check_controllerStatus));
            _bxDual_cmd_check_time = GetDelegate<DCreater.bxDual_cmd_check_time>(nameof(DCreater.bxDual_cmd_check_time));
            _bxDual_cmd_check_time_uart = GetDelegate<DCreater.bxDual_cmd_check_time_uart>(nameof(DCreater.bxDual_cmd_check_time_uart));
            _bxDual_cmd_coerceOnOff = GetDelegate<DCreater.bxDual_cmd_coerceOnOff>(nameof(DCreater.bxDual_cmd_coerceOnOff));
            _bxDual_cmd_coerceOnOff_uart = GetDelegate<DCreater.bxDual_cmd_coerceOnOff_uart>(nameof(DCreater.bxDual_cmd_coerceOnOff_uart));
            _bxDual_cmd_confDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_confDeleteFormatFile>(nameof(DCreater.bxDual_cmd_confDeleteFormatFile));
            _bxDual_cmd_confReedFileBlock = GetDelegate<DCreater.bxDual_cmd_confReedFileBlock>(nameof(DCreater.bxDual_cmd_confReedFileBlock));
            _bxDual_cmd_confStartReedFile = GetDelegate<DCreater.bxDual_cmd_confStartReedFile>(nameof(DCreater.bxDual_cmd_confStartReedFile));
            _bxDual_cmd_confWriteFile = GetDelegate<DCreater.bxDual_cmd_confWriteFile>(nameof(DCreater.bxDual_cmd_confWriteFile));
            _bxDual_cmd_deletePassword = GetDelegate<DCreater.bxDual_cmd_deletePassword>(nameof(DCreater.bxDual_cmd_deletePassword));
            _bxDual_cmd_firmwareActivate = GetDelegate<DCreater.bxDual_cmd_firmwareActivate>(nameof(DCreater.bxDual_cmd_firmwareActivate));
            _bxDual_cmd_getFileAttr = GetDelegate<DCreater.bxDual_cmd_getFileAttr>(nameof(DCreater.bxDual_cmd_getFileAttr));
            _bxDual_cmd_getSensorBrightnessValue = GetDelegate<DCreater.bxDual_cmd_getSensorBrightnessValue>(nameof(DCreater.bxDual_cmd_getSensorBrightnessValue));
            _bxDual_cmd_getStopwatch = GetDelegate<DCreater.bxDual_cmd_getStopwatch>(nameof(DCreater.bxDual_cmd_getStopwatch));
            _bxDual_cmd_ofsDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_ofsDeleteFormatFile>(nameof(DCreater.bxDual_cmd_ofsDeleteFormatFile));
            _bxDual_cmd_ofsEndFileTransf = GetDelegate<DCreater.bxDual_cmd_ofsEndFileTransf>(nameof(DCreater.bxDual_cmd_ofsEndFileTransf));
            _bxDual_cmd_ofsFormat = GetDelegate<DCreater.bxDual_cmd_ofsFormat>(nameof(DCreater.bxDual_cmd_ofsFormat));
            _bxDual_cmd_ofsGetMemoryVolume = GetDelegate<DCreater.bxDual_cmd_ofsGetMemoryVolume>(nameof(DCreater.bxDual_cmd_ofsGetMemoryVolume));
            _bxDual_cmd_ofsGetTransStatus = GetDelegate<DCreater.bxDual_cmd_ofsGetTransStatus>(nameof(DCreater.bxDual_cmd_ofsGetTransStatus));
            _bxDual_cmd_ofsReedDirBlock = GetDelegate<DCreater.bxDual_cmd_ofsReedDirBlock>(nameof(DCreater.bxDual_cmd_ofsReedDirBlock));
            _bxDual_cmd_ofsReedFileBlock = GetDelegate<DCreater.bxDual_cmd_ofsReedFileBlock>(nameof(DCreater.bxDual_cmd_ofsReedFileBlock));
            _bxDual_cmd_ofsStartFileTransf = GetDelegate<DCreater.bxDual_cmd_ofsStartFileTransf>(nameof(DCreater.bxDual_cmd_ofsStartFileTransf));
            _bxDual_cmd_ofsStartReedFile = GetDelegate<DCreater.bxDual_cmd_ofsStartReedFile>(nameof(DCreater.bxDual_cmd_ofsStartReedFile));
            _bxDual_cmd_ofsWriteFile = GetDelegate<DCreater.bxDual_cmd_ofsWriteFile>(nameof(DCreater.bxDual_cmd_ofsWriteFile));
            _bxDual_cmd_ofs_freeDirBlock = GetDelegate<DCreater.bxDual_cmd_ofs_freeDirBlock>(nameof(DCreater.bxDual_cmd_ofs_freeDirBlock));
            _bxDual_cmd_programLock = GetDelegate<DCreater.bxDual_cmd_programLock>(nameof(DCreater.bxDual_cmd_programLock));
            _bxDual_cmd_readControllerID = GetDelegate<DCreater.bxDual_cmd_readControllerID>(nameof(DCreater.bxDual_cmd_readControllerID));
            _bxDual_cmd_screenLock = GetDelegate<DCreater.bxDual_cmd_screenLock>(nameof(DCreater.bxDual_cmd_screenLock));
            _bxDual_cmd_searchController = GetDelegate<DCreater.bxDual_cmd_searchController>(nameof(DCreater.bxDual_cmd_searchController));
            _bxDual_cmd_sendConfigFile = GetDelegate<DCreater.bxDual_cmd_sendConfigFile>(nameof(DCreater.bxDual_cmd_sendConfigFile));
            _bxDual_cmd_sendConfigFile_G6 = GetDelegate<DCreater.bxDual_cmd_sendConfigFile_G6>(nameof(DCreater.bxDual_cmd_sendConfigFile_G6));
            _bxDual_cmd_setBrightness = GetDelegate<DCreater.bxDual_cmd_setBrightness>(nameof(DCreater.bxDual_cmd_setBrightness));
            _bxDual_cmd_setBrightness_uart = GetDelegate<DCreater.bxDual_cmd_setBrightness_uart>(nameof(DCreater.bxDual_cmd_setBrightness_uart));
            _bxDual_cmd_setBtnFunc = GetDelegate<DCreater.bxDual_cmd_setBtnFunc>(nameof(DCreater.bxDual_cmd_setBtnFunc));
            _bxDual_cmd_setDelayTime = GetDelegate<DCreater.bxDual_cmd_setDelayTime>(nameof(DCreater.bxDual_cmd_setDelayTime));
            _bxDual_cmd_setDispMode = GetDelegate<DCreater.bxDual_cmd_setDispMode>(nameof(DCreater.bxDual_cmd_setDispMode));
            _bxDual_cmd_setPassword = GetDelegate<DCreater.bxDual_cmd_setPassword>(nameof(DCreater.bxDual_cmd_setPassword));
            _bxDual_cmd_setScreenAddress = GetDelegate<DCreater.bxDual_cmd_setScreenAddress>(nameof(DCreater.bxDual_cmd_setScreenAddress));
            _bxDual_cmd_setSpeedAdjust = GetDelegate<DCreater.bxDual_cmd_setSpeedAdjust>(nameof(DCreater.bxDual_cmd_setSpeedAdjust));
            _bxDual_cmd_setTimingReset = GetDelegate<DCreater.bxDual_cmd_setTimingReset>(nameof(DCreater.bxDual_cmd_setTimingReset));
            _bxDual_cmd_sysReset = GetDelegate<DCreater.bxDual_cmd_sysReset>(nameof(DCreater.bxDual_cmd_sysReset));
            _bxDual_cmd_tcpNetworkSearch_6G = GetDelegate<DCreater.bxDual_cmd_tcpNetworkSearch_6G>(nameof(DCreater.bxDual_cmd_tcpNetworkSearch_6G));
            _bxDual_cmd_tcpNetworkSearch_6G_Web = GetDelegate<DCreater.bxDual_cmd_tcpNetworkSearch_6G_Web>(nameof(DCreater.bxDual_cmd_tcpNetworkSearch_6G_Web));
            _bxDual_cmd_tcpPing = GetDelegate<DCreater.bxDual_cmd_tcpPing>(nameof(DCreater.bxDual_cmd_tcpPing));
            _bxDual_cmd_timingOnOff = GetDelegate<DCreater.bxDual_cmd_timingOnOff>(nameof(DCreater.bxDual_cmd_timingOnOff));
            _bxDual_cmd_uart_confDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_uart_confDeleteFormatFile>(nameof(DCreater.bxDual_cmd_uart_confDeleteFormatFile));
            _bxDual_cmd_uart_confReedFileBlock = GetDelegate<DCreater.bxDual_cmd_uart_confReedFileBlock>(nameof(DCreater.bxDual_cmd_uart_confReedFileBlock));
            _bxDual_cmd_uart_confStartReedFile = GetDelegate<DCreater.bxDual_cmd_uart_confStartReedFile>(nameof(DCreater.bxDual_cmd_uart_confStartReedFile));
            _bxDual_cmd_uart_confWriteFile = GetDelegate<DCreater.bxDual_cmd_uart_confWriteFile>(nameof(DCreater.bxDual_cmd_uart_confWriteFile));
            _bxDual_cmd_uart_ofsDeleteFormatFile = GetDelegate<DCreater.bxDual_cmd_uart_ofsDeleteFormatFile>(nameof(DCreater.bxDual_cmd_uart_ofsDeleteFormatFile));
            _bxDual_cmd_uart_ofsEndFileTransf = GetDelegate<DCreater.bxDual_cmd_uart_ofsEndFileTransf>(nameof(DCreater.bxDual_cmd_uart_ofsEndFileTransf));
            _bxDual_cmd_uart_ofsFormat = GetDelegate<DCreater.bxDual_cmd_uart_ofsFormat>(nameof(DCreater.bxDual_cmd_uart_ofsFormat));
            _bxDual_cmd_uart_ofsFreeDirBlock = GetDelegate<DCreater.bxDual_cmd_uart_ofsFreeDirBlock>(nameof(DCreater.bxDual_cmd_uart_ofsFreeDirBlock));
            _bxDual_cmd_uart_ofsGetMemoryVolume = GetDelegate<DCreater.bxDual_cmd_uart_ofsGetMemoryVolume>(nameof(DCreater.bxDual_cmd_uart_ofsGetMemoryVolume));
            _bxDual_cmd_uart_ofsGetTransStatus = GetDelegate<DCreater.bxDual_cmd_uart_ofsGetTransStatus>(nameof(DCreater.bxDual_cmd_uart_ofsGetTransStatus));
            _bxDual_cmd_uart_ofsReedDirBlock = GetDelegate<DCreater.bxDual_cmd_uart_ofsReedDirBlock>(nameof(DCreater.bxDual_cmd_uart_ofsReedDirBlock));
            _bxDual_cmd_uart_ofsReedFileBlock = GetDelegate<DCreater.bxDual_cmd_uart_ofsReedFileBlock>(nameof(DCreater.bxDual_cmd_uart_ofsReedFileBlock));
            _bxDual_cmd_uart_ofsStartFileTransf = GetDelegate<DCreater.bxDual_cmd_uart_ofsStartFileTransf>(nameof(DCreater.bxDual_cmd_uart_ofsStartFileTransf));
            _bxDual_cmd_uart_ofsStartReedFile = GetDelegate<DCreater.bxDual_cmd_uart_ofsStartReedFile>(nameof(DCreater.bxDual_cmd_uart_ofsStartReedFile));
            _bxDual_cmd_uart_ofsWriteFile = GetDelegate<DCreater.bxDual_cmd_uart_ofsWriteFile>(nameof(DCreater.bxDual_cmd_uart_ofsWriteFile));
            _bxDual_cmd_uart_programLock = GetDelegate<DCreater.bxDual_cmd_uart_programLock>(nameof(DCreater.bxDual_cmd_uart_programLock));
            _bxDual_cmd_uart_programLock_6G = GetDelegate<DCreater.bxDual_cmd_uart_programLock_6G>(nameof(DCreater.bxDual_cmd_uart_programLock_6G));
            _bxDual_cmd_uart_searchController = GetDelegate<DCreater.bxDual_cmd_uart_searchController>(nameof(DCreater.bxDual_cmd_uart_searchController));
            _bxDual_cmd_uart_search_Net_6G = GetDelegate<DCreater.bxDual_cmd_uart_search_Net_6G>(nameof(DCreater.bxDual_cmd_uart_search_Net_6G));
            _bxDual_cmd_uart_search_Net_6G_Web = GetDelegate<DCreater.bxDual_cmd_uart_search_Net_6G_Web>(nameof(DCreater.bxDual_cmd_uart_search_Net_6G_Web));
            _bxDual_cmd_uart_sendConfigFile = GetDelegate<DCreater.bxDual_cmd_uart_sendConfigFile>(nameof(DCreater.bxDual_cmd_uart_sendConfigFile));
            _bxDual_cmd_udpNetworkSearch = GetDelegate<DCreater.bxDual_cmd_udpNetworkSearch>(nameof(DCreater.bxDual_cmd_udpNetworkSearch));
            _bxDual_cmd_udpNetworkSearch_6G = GetDelegate<DCreater.bxDual_cmd_udpNetworkSearch_6G>(nameof(DCreater.bxDual_cmd_udpNetworkSearch_6G));
            _bxDual_cmd_udpNetworkSearch_6G_Web = GetDelegate<DCreater.bxDual_cmd_udpNetworkSearch_6G_Web>(nameof(DCreater.bxDual_cmd_udpNetworkSearch_6G_Web));
            _bxDual_cmd_udpPing = GetDelegate<DCreater.bxDual_cmd_udpPing>(nameof(DCreater.bxDual_cmd_udpPing));
            _bxDual_cmd_udpSetIP = GetDelegate<DCreater.bxDual_cmd_udpSetIP>(nameof(DCreater.bxDual_cmd_udpSetIP));
            _bxDual_cmd_udpSetMac = GetDelegate<DCreater.bxDual_cmd_udpSetMac>(nameof(DCreater.bxDual_cmd_udpSetMac));
            _bxDual_dynamicAreaS_AddAreaPic_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_6G));
            _bxDual_dynamicAreaS_AddAreaPic_6G_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_6G_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_6G_Serial));
            _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G));
            _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial));
            _bxDual_dynamicAreaS_AddTxtDetails_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G));
            _bxDual_dynamicAreaS_AddTxtDetails_6G_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_6G_Serial));
            _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G));
            _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial = GetDelegate<DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial>(nameof(DCreater.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial));
            _bxDual_dynamicArea_AddAreaInfos_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_5G));
            _bxDual_dynamicArea_AddAreaInfos_5G_Point = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Point>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Point));
            _bxDual_dynamicArea_AddAreaInfos_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_5G_Serial));
            _bxDual_dynamicArea_AddAreaInfos_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_6G));
            _bxDual_dynamicArea_AddAreaInfos_6G_V2 = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2));
            _bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial));
            _bxDual_dynamicArea_AddAreaInfos_G6_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaInfos_G6_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaInfos_G6_Serial));
            _bxDual_dynamicArea_AddAreaPic_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_6G));
            _bxDual_dynamicArea_AddAreaPic_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_6G_Serial));
            _bxDual_dynamicArea_AddAreaPic_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_6G));
            _bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial));
            _bxDual_dynamicArea_AddAreaTxtDetails_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G));
            _bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial));
            _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G));
            _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial));
            _bxDual_dynamicArea_AddAreaTxt_6G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaTxt_6G>(nameof(DCreater.bxDual_dynamicArea_AddAreaTxt_6G));
            _bxDual_dynamicArea_AddAreaWithPic_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithPic_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithPic_5G));
            _bxDual_dynamicArea_AddAreaWithPic_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithPic_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithPic_5G_Serial));
            _bxDual_dynamicArea_AddAreaWithTxt_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G));
            _bxDual_dynamicArea_AddAreaWithTxt_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_5G_Serial));
            _bxDual_dynamicArea_AddAreaWithTxt_Point_5G = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G));
            _bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial>(nameof(DCreater.bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial));
            _bxDual_dynamicArea_DelAreaS_5G = GetDelegate<DCreater.bxDual_dynamicArea_DelAreaS_5G>(nameof(DCreater.bxDual_dynamicArea_DelAreaS_5G));
            _bxDual_dynamicArea_DelAreas_6G = GetDelegate<DCreater.bxDual_dynamicArea_DelAreas_6G>(nameof(DCreater.bxDual_dynamicArea_DelAreas_6G));
            _bxDual_dynamicArea_DelAreaS_G5_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelAreaS_G5_Serial>(nameof(DCreater.bxDual_dynamicArea_DelAreaS_G5_Serial));
            _bxDual_dynamicArea_DelAreas_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelAreas_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_DelAreas_6G_Serial));
            _bxDual_dynamicArea_DelArea_5G = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_5G>(nameof(DCreater.bxDual_dynamicArea_DelArea_5G));
            _bxDual_dynamicArea_DelArea_6G = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_6G>(nameof(DCreater.bxDual_dynamicArea_DelArea_6G));
            _bxDual_dynamicArea_DelArea_G5_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_G5_Serial>(nameof(DCreater.bxDual_dynamicArea_DelArea_G5_Serial));
            _bxDual_dynamicArea_DelArea_6G_Serial = GetDelegate<DCreater.bxDual_dynamicArea_DelArea_6G_Serial>(nameof(DCreater.bxDual_dynamicArea_DelArea_6G_Serial));
            _bxDual_dynamicArea_InsertSoundIndepend = GetDelegate<DCreater.bxDual_dynamicArea_InsertSoundIndepend>(nameof(DCreater.bxDual_dynamicArea_InsertSoundIndepend));
            _bxDual_dynamicArea_SetDualPixel = GetDelegate<DCreater.bxDual_dynamicArea_SetDualPixel>(nameof(DCreater.bxDual_dynamicArea_SetDualPixel));
            _bxDual_dynamicArea_UpdateSoundIndepend = GetDelegate<DCreater.bxDual_dynamicArea_UpdateSoundIndepend>(nameof(DCreater.bxDual_dynamicArea_UpdateSoundIndepend));
            _bxDual_get_crc16 = GetDelegate<DCreater.bxDual_get_crc16>(nameof(DCreater.bxDual_get_crc16));
            _bxDual_get_crc32 = GetDelegate<DCreater.bxDual_get_crc32>(nameof(DCreater.bxDual_get_crc32));
            _bxDual_InitSdk = GetDelegate<DCreater.bxDual_InitSdk>(nameof(DCreater.bxDual_InitSdk));
            _bxDual_program_AddArea = GetDelegate<DCreater.bxDual_program_AddArea>(nameof(DCreater.bxDual_program_AddArea));
            _bxDual_program_addArea_G6 = GetDelegate<DCreater.bxDual_program_addArea_G6>(nameof(DCreater.bxDual_program_addArea_G6));
            _bxDual_program_addFrame = GetDelegate<DCreater.bxDual_program_addFrame>(nameof(DCreater.bxDual_program_addFrame));
            _bxDual_program_addFrame_G6 = GetDelegate<DCreater.bxDual_program_addFrame_G6>(nameof(DCreater.bxDual_program_addFrame_G6));
            _bxDual_program_addPlayPeriodGrp = GetDelegate<DCreater.bxDual_program_addPlayPeriodGrp>(nameof(DCreater.bxDual_program_addPlayPeriodGrp));
            _bxDual_program_addPlayPeriodGrp_G6 = GetDelegate<DCreater.bxDual_program_addPlayPeriodGrp_G6>(nameof(DCreater.bxDual_program_addPlayPeriodGrp_G6));
            _bxDual_program_addProgram = GetDelegate<DCreater.bxDual_program_addProgram>(nameof(DCreater.bxDual_program_addProgram));
            _bxDual_program_addProgram_G6 = GetDelegate<DCreater.bxDual_program_addProgram_G6>(nameof(DCreater.bxDual_program_addProgram_G6));
            _bxDual_program_backGroundColor_G6 = GetDelegate<DCreater.bxDual_program_backGroundColor_G6>(nameof(DCreater.bxDual_program_backGroundColor_G6));
            _bxDual_program_backGroundPic_G6 = GetDelegate<DCreater.bxDual_program_backGroundPic_G6>(nameof(DCreater.bxDual_program_backGroundPic_G6));
            _bxDual_program_changeFrame = GetDelegate<DCreater.bxDual_program_changeFrame>(nameof(DCreater.bxDual_program_changeFrame));
            _bxDual_program_changeFrame_G6 = GetDelegate<DCreater.bxDual_program_changeFrame_G6>(nameof(DCreater.bxDual_program_changeFrame_G6));
            _bxDual_program_changeProgramParams = GetDelegate<DCreater.bxDual_program_changeProgramParams>(nameof(DCreater.bxDual_program_changeProgramParams));
            _bxDual_program_changeProgramParams_G6 = GetDelegate<DCreater.bxDual_program_changeProgramParams_G6>(nameof(DCreater.bxDual_program_changeProgramParams_G6));
            _bxDual_program_deleteArea = GetDelegate<DCreater.bxDual_program_deleteArea>(nameof(DCreater.bxDual_program_deleteArea));
            _bxDual_program_deleteArea_G6 = GetDelegate<DCreater.bxDual_program_deleteArea_G6>(nameof(DCreater.bxDual_program_deleteArea_G6));
            _bxDual_program_deleteProgram = GetDelegate<DCreater.bxDual_program_deleteProgram>(nameof(DCreater.bxDual_program_deleteProgram));
            _bxDual_program_deleteProgram_G6 = GetDelegate<DCreater.bxDual_program_deleteProgram_G6>(nameof(DCreater.bxDual_program_deleteProgram_G6));
            _bxDual_program_fontPath_picturesAreaAddTxt = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaAddTxt>(nameof(DCreater.bxDual_program_fontPath_picturesAreaAddTxt));
            _bxDual_program_fontPath_picturesAreaAddTxt_G6 = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaAddTxt_G6>(nameof(DCreater.bxDual_program_fontPath_picturesAreaAddTxt_G6));
            _bxDual_program_fontPath_picturesAreaChangeTxt = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaChangeTxt>(nameof(DCreater.bxDual_program_fontPath_picturesAreaChangeTxt));
            _bxDual_program_fontPath_picturesAreaChangeTxt_G6 = GetDelegate<DCreater.bxDual_program_fontPath_picturesAreaChangeTxt_G6>(nameof(DCreater.bxDual_program_fontPath_picturesAreaChangeTxt_G6));
            _bxDual_program_fontPath_timeAreaAddContent = GetDelegate<DCreater.bxDual_program_fontPath_timeAreaAddContent>(nameof(DCreater.bxDual_program_fontPath_timeAreaAddContent));
            _bxDual_program_fontPath_timeAreaAddContent_G6 = GetDelegate<DCreater.bxDual_program_fontPath_timeAreaAddContent_G6>(nameof(DCreater.bxDual_program_fontPath_timeAreaAddContent_G6));
            _bxDual_program_freeBuffer = GetDelegate<DCreater.bxDual_program_freeBuffer>(nameof(DCreater.bxDual_program_freeBuffer));
            _bxDual_program_freeBuffer_G6 = GetDelegate<DCreater.bxDual_program_freeBuffer_G6>(nameof(DCreater.bxDual_program_freeBuffer_G6));
            _bxDual_program_IntegrateProgramFile = GetDelegate<DCreater.bxDual_program_IntegrateProgramFile>(nameof(DCreater.bxDual_program_IntegrateProgramFile));
            _bxDual_program_IntegrateProgramFile_G6 = GetDelegate<DCreater.bxDual_program_IntegrateProgramFile_G6>(nameof(DCreater.bxDual_program_IntegrateProgramFile_G6));
            _bxDual_program_MoveArea = GetDelegate<DCreater.bxDual_program_MoveArea>(nameof(DCreater.bxDual_program_MoveArea));
            _bxDual_program_MoveArea_G6 = GetDelegate<DCreater.bxDual_program_MoveArea_G6>(nameof(DCreater.bxDual_program_MoveArea_G6));
            _bxDual_program_pictureArea = GetDelegate<DCreater.bxDual_program_pictureArea>(nameof(DCreater.bxDual_program_pictureArea));
            _bxDual_program_pictureAreaAddPic = GetDelegate<DCreater.bxDual_program_pictureAreaAddPic>(nameof(DCreater.bxDual_program_pictureAreaAddPic));
            _bxDual_program_pictureAreaAddPic_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaAddPic_G6>(nameof(DCreater.bxDual_program_pictureAreaAddPic_G6));
            _bxDual_program_pictureAreaChangePic_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaChangePic_G6>(nameof(DCreater.bxDual_program_pictureAreaChangePic_G6));
            _bxDual_program_pictureAreaChangeSoundSettings_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaChangeSoundSettings_G6>(nameof(DCreater.bxDual_program_pictureAreaChangeSoundSettings_G6));
            _bxDual_program_pictureAreaDisableSound_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaDisableSound_G6>(nameof(DCreater.bxDual_program_pictureAreaDisableSound_G6));
            _bxDual_program_pictureAreaEnableSound_G6 = GetDelegate<DCreater.bxDual_program_pictureAreaEnableSound_G6>(nameof(DCreater.bxDual_program_pictureAreaEnableSound_G6));
            _bxDual_program_pictureAreaGetOnePage = GetDelegate<DCreater.bxDual_program_pictureAreaGetOnePage>(nameof(DCreater.bxDual_program_pictureAreaGetOnePage));
            _bxDual_program_pictureAreaRemoveFrame = GetDelegate<DCreater.bxDual_program_pictureAreaRemoveFrame>(nameof(DCreater.bxDual_program_pictureAreaRemoveFrame));
            _bxDual_program_picturesAreaAddFrame = GetDelegate<DCreater.bxDual_program_picturesAreaAddFrame>(nameof(DCreater.bxDual_program_picturesAreaAddFrame));
            _bxDual_program_picturesAreaAddFrame_G6 = GetDelegate<DCreater.bxDual_program_picturesAreaAddFrame_G6>(nameof(DCreater.bxDual_program_picturesAreaAddFrame_G6));
            _bxDual_program_picturesAreaAddTxt = GetDelegate<DCreater.bxDual_program_picturesAreaAddTxt>(nameof(DCreater.bxDual_program_picturesAreaAddTxt));
            _bxDual_program_picturesAreaAddTxt_G6 = GetDelegate<DCreater.bxDual_program_picturesAreaAddTxt_G6>(nameof(DCreater.bxDual_program_picturesAreaAddTxt_G6));
            _bxDual_program_picturesAreaChangeTxt = GetDelegate<DCreater.bxDual_program_picturesAreaChangeTxt>(nameof(DCreater.bxDual_program_picturesAreaChangeTxt));
            _bxDual_program_picturesAreaChangeTxt_G6 = GetDelegate<DCreater.bxDual_program_picturesAreaChangeTxt_G6>(nameof(DCreater.bxDual_program_picturesAreaChangeTxt_G6));
            _bxDual_program_removeFrame = GetDelegate<DCreater.bxDual_program_removeFrame>(nameof(DCreater.bxDual_program_removeFrame));
            _bxDual_program_removeFrame_G6 = GetDelegate<DCreater.bxDual_program_removeFrame_G6>(nameof(DCreater.bxDual_program_removeFrame_G6));
            _bxDual_program_setScreenParams_G56 = GetDelegate<DCreater.bxDual_program_setScreenParams_G56>(nameof(DCreater.bxDual_program_setScreenParams_G56));
            _bxDual_program_SetSensorAreaHumidity_G5 = GetDelegate<DCreater.bxDual_program_SetSensorAreaHumidity_G5>(nameof(DCreater.bxDual_program_SetSensorAreaHumidity_G5));
            _bxDual_program_SetSensorAreaNoise_G5 = GetDelegate<DCreater.bxDual_program_SetSensorAreaNoise_G5>(nameof(DCreater.bxDual_program_SetSensorAreaNoise_G5));
            _bxDual_program_SetSensorAreaTemperature_G5 = GetDelegate<DCreater.bxDual_program_SetSensorAreaTemperature_G5>(nameof(DCreater.bxDual_program_SetSensorAreaTemperature_G5));
            _bxDual_program_SetSensorArea_G6 = GetDelegate<DCreater.bxDual_program_SetSensorArea_G6>(nameof(DCreater.bxDual_program_SetSensorArea_G6));
            _bxDual_program_timeAreaAddAnalogClock = GetDelegate<DCreater.bxDual_program_timeAreaAddAnalogClock>(nameof(DCreater.bxDual_program_timeAreaAddAnalogClock));
            _bxDual_program_timeAreaAddAnalogClock_G6 = GetDelegate<DCreater.bxDual_program_timeAreaAddAnalogClock_G6>(nameof(DCreater.bxDual_program_timeAreaAddAnalogClock_G6));
            _bxDual_program_timeAreaAddContent = GetDelegate<DCreater.bxDual_program_timeAreaAddContent>(nameof(DCreater.bxDual_program_timeAreaAddContent));
            _bxDual_program_timeAreaAddContent_G6 = GetDelegate<DCreater.bxDual_program_timeAreaAddContent_G6>(nameof(DCreater.bxDual_program_timeAreaAddContent_G6));
            _bxDual_program_timeAreaAddCounterTimer_G6 = GetDelegate<DCreater.bxDual_program_timeAreaAddCounterTimer_G6>(nameof(DCreater.bxDual_program_timeAreaAddCounterTimer_G6));
            _bxDual_program_timeAreaCancleBattleTime_G6 = GetDelegate<DCreater.bxDual_program_timeAreaCancleBattleTime_G6>(nameof(DCreater.bxDual_program_timeAreaCancleBattleTime_G6));
            _bxDual_program_timeAreaChangeAnalogClock = GetDelegate<DCreater.bxDual_program_timeAreaChangeAnalogClock>(nameof(DCreater.bxDual_program_timeAreaChangeAnalogClock));
            _bxDual_program_timeAreaChangeAnalogClock_G6 = GetDelegate<DCreater.bxDual_program_timeAreaChangeAnalogClock_G6>(nameof(DCreater.bxDual_program_timeAreaChangeAnalogClock_G6));
            _bxDual_program_timeAreaChangeContent = GetDelegate<DCreater.bxDual_program_timeAreaChangeContent>(nameof(DCreater.bxDual_program_timeAreaChangeContent));
            _bxDual_program_timeAreaChangeContent_G6 = GetDelegate<DCreater.bxDual_program_timeAreaChangeContent_G6>(nameof(DCreater.bxDual_program_timeAreaChangeContent_G6));
            _bxDual_program_timeAreaChangeDialPic = GetDelegate<DCreater.bxDual_program_timeAreaChangeDialPic>(nameof(DCreater.bxDual_program_timeAreaChangeDialPic));
            _bxDual_program_timeAreaChangeDialPicAdd_G56 = GetDelegate<DCreater.bxDual_program_timeAreaChangeDialPicAdd_G56>(nameof(DCreater.bxDual_program_timeAreaChangeDialPicAdd_G56));
            _bxDual_program_timeAreaChangeDialPic_G6 = GetDelegate<DCreater.bxDual_program_timeAreaChangeDialPic_G6>(nameof(DCreater.bxDual_program_timeAreaChangeDialPic_G6));
            _bxDual_program_timeAreaGetOnePage = GetDelegate<DCreater.bxDual_program_timeAreaGetOnePage>(nameof(DCreater.bxDual_program_timeAreaGetOnePage));
            _bxDual_program_timeAreaRemoveDialPic = GetDelegate<DCreater.bxDual_program_timeAreaRemoveDialPic>(nameof(DCreater.bxDual_program_timeAreaRemoveDialPic));
            _bxDual_program_timeAreaRemoveDialPic_G6 = GetDelegate<DCreater.bxDual_program_timeAreaRemoveDialPic_G6>(nameof(DCreater.bxDual_program_timeAreaRemoveDialPic_G6));
            _bxDual_program_timeAreaSetBattleTime_G6 = GetDelegate<DCreater.bxDual_program_timeAreaSetBattleTime_G6>(nameof(DCreater.bxDual_program_timeAreaSetBattleTime_G6));
            _bxDual_ReleaseSdk = GetDelegate<DCreater.bxDual_ReleaseSdk>(nameof(DCreater.bxDual_ReleaseSdk));
            _bxDual_set_packetLen = GetDelegate<DCreater.bxDual_set_packetLen>(nameof(DCreater.bxDual_set_packetLen));
            _bxDual_set_screenNum_G56 = GetDelegate<DCreater.bxDual_set_screenNum_G56>(nameof(DCreater.bxDual_set_screenNum_G56));
        }
        public override string GetFileFullName()
        {
            return LedBxDualSdk.DllFullName;
        }
        #region // 显示实现
        int ILedBxDualSdkProxy.BxDual_cmd_AT_getWifiSsidPwd(byte[] ssid, byte[] pwd) => _bxDual_cmd_AT_getWifiSsidPwd(ssid, pwd);
        int ILedBxDualSdkProxy.BxDual_cmd_AT_setWifiSsidPwd(byte[] ssid, byte[] pwd) => _bxDual_cmd_AT_setWifiSsidPwd(ssid, pwd);
        int ILedBxDualSdkProxy.BxDual_cmd_battieTime(byte[] ip, ushort port, byte mode, ref BattleTime battieData) => _bxDual_cmd_battieTime(ip, port, mode, ref battieData);
        int ILedBxDualSdkProxy.BxDual_cmd_cancelTimingOnOff(byte[] ip, ushort port) => _bxDual_cmd_cancelTimingOnOff(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_check_controllerStatus(byte[] ip, ushort port, ref ControllerStatus_G56 controllerStatus) => _bxDual_cmd_check_controllerStatus(ip, port, ref controllerStatus);
        int ILedBxDualSdkProxy.BxDual_cmd_check_time(byte[] ip, ushort port) => _bxDual_cmd_check_time(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_check_time_uart(byte[] uartPort, byte baudRate) => _bxDual_cmd_check_time_uart(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_coerceOnOff(byte[] ip, ushort port, byte onOff) => _bxDual_cmd_coerceOnOff(ip, port, onOff);
        int ILedBxDualSdkProxy.BxDual_cmd_coerceOnOff_uart(byte[] sPortName, byte nBaudRateIndex, byte nOnOff) => _bxDual_cmd_coerceOnOff_uart(sPortName, nBaudRateIndex, nOnOff);
        int ILedBxDualSdkProxy.BxDual_cmd_confDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName) => _bxDual_cmd_confDeleteFormatFile(ip, port, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_confReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre) => _bxDual_cmd_confReedFileBlock(ip, port, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_confStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc) => _bxDual_cmd_confStartReedFile(ip, port, fileName, ref fileSize, ref fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_confWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre) => _bxDual_cmd_confWriteFile(ip, port, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_deletePassword(byte[] ip, ushort port, byte[] password) => _bxDual_cmd_deletePassword(ip, port, password);
        int ILedBxDualSdkProxy.BxDual_cmd_firmwareActivate(byte[] ip, ushort port, byte[] firmwareFileName) => _bxDual_cmd_firmwareActivate(ip, port, firmwareFileName);
        int ILedBxDualSdkProxy.BxDual_cmd_getFileAttr(ref GetDirBlock_G56 dirBlock, ushort number, ref FileAttribute_G56 fileAttr) => _bxDual_cmd_getFileAttr(ref dirBlock, number, ref fileAttr);
        int ILedBxDualSdkProxy.BxDual_cmd_getSensorBrightnessValue(byte[] ip, ushort port, ref int brightnessValue) => _bxDual_cmd_getSensorBrightnessValue(ip, port, ref brightnessValue);
        int ILedBxDualSdkProxy.BxDual_cmd_getStopwatch(byte[] ip, ushort port, byte mode, ref int timeValue) => _bxDual_cmd_getStopwatch(ip, port, mode, ref timeValue);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName) => _bxDual_cmd_ofsDeleteFormatFile(ip, port, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsEndFileTransf(byte[] ip, ushort port) => _bxDual_cmd_ofsEndFileTransf(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsFormat(byte[] ip, ushort port) => _bxDual_cmd_ofsFormat(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsGetMemoryVolume(byte[] ip, ushort port, ref int totalMemVolume, ref int availableMemVolume) => _bxDual_cmd_ofsGetMemoryVolume(ip, port, ref totalMemVolume, ref availableMemVolume);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsGetTransStatus(byte[] ip, ushort port, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset) => _bxDual_cmd_ofsGetTransStatus(ip, port, r_w, fileName, fileCrc, fileOffset);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsReedDirBlock(byte[] ip, ushort port, ref GetDirBlock_G56 dirBlock) => _bxDual_cmd_ofsReedDirBlock(ip, port, ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre) => _bxDual_cmd_ofsReedFileBlock(ip, port, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsStartFileTransf(byte[] ip, ushort port) => _bxDual_cmd_ofsStartFileTransf(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc) => _bxDual_cmd_ofsStartReedFile(ip, port, fileName, ref fileSize, ref fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_ofsWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre) => _bxDual_cmd_ofsWriteFile(ip, port, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_ofs_freeDirBlock(ref GetDirBlock_G56 dirBlock) => _bxDual_cmd_ofs_freeDirBlock(ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_programLock(byte[] ip, ushort port, byte nonvolatile, byte locked, byte[] name, uint lockDuration) => _bxDual_cmd_programLock(ip, port, nonvolatile, locked, name, lockDuration);
        int ILedBxDualSdkProxy.BxDual_cmd_readControllerID(byte[] ip, ushort port, byte[] ControllerID) => _bxDual_cmd_readControllerID(ip, port, ControllerID);
        int ILedBxDualSdkProxy.BxDual_cmd_screenLock(byte[] ip, ushort port, byte nonvolatile, byte locked) => _bxDual_cmd_screenLock(ip, port, nonvolatile, locked);
        int ILedBxDualSdkProxy.BxDual_cmd_searchController(ref Ping_data retData) => _bxDual_cmd_searchController(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_sendConfigFile(byte[] ip, ushort port, ref ConfigFile configData) => _bxDual_cmd_sendConfigFile(ip, port, ref configData);
        int ILedBxDualSdkProxy.BxDual_cmd_sendConfigFile_G6(byte[] ip, ushort port, ref ConfigFile_G6 configData) => _bxDual_cmd_sendConfigFile_G6(ip, port, ref configData);
        int ILedBxDualSdkProxy.BxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness) => _bxDual_cmd_setBrightness(ip, port, ref brightness);
        int ILedBxDualSdkProxy.BxDual_cmd_setBrightness_uart(byte[] sPortName, byte nBaudRateIndex, ref Brightness brightness) => _bxDual_cmd_setBrightness_uart(sPortName, nBaudRateIndex, ref brightness);
        int ILedBxDualSdkProxy.BxDual_cmd_setBtnFunc(byte[] ip, ushort port, byte btnMode) => _bxDual_cmd_setBtnFunc(ip, port, btnMode);
        int ILedBxDualSdkProxy.BxDual_cmd_setDelayTime(byte[] ip, ushort port, short delayTime) => _bxDual_cmd_setDelayTime(ip, port, delayTime);
        int ILedBxDualSdkProxy.BxDual_cmd_setDispMode(byte[] ip, ushort port, byte dispMode) => _bxDual_cmd_setDispMode(ip, port, dispMode);
        int ILedBxDualSdkProxy.BxDual_cmd_setPassword(byte[] ip, ushort port, byte[] oldPassword, byte[] newPassword) => _bxDual_cmd_setPassword(ip, port, oldPassword, newPassword);
        int ILedBxDualSdkProxy.BxDual_cmd_setScreenAddress(byte[] ip, ushort port, short address) => _bxDual_cmd_setScreenAddress(ip, port, address);
        int ILedBxDualSdkProxy.BxDual_cmd_setSpeedAdjust(byte[] ip, ushort port, short speed) => _bxDual_cmd_setSpeedAdjust(ip, port, speed);
        int ILedBxDualSdkProxy.BxDual_cmd_setTimingReset(byte[] ip, ushort port, ref TimingReset cmdData) => _bxDual_cmd_setTimingReset(ip, port, ref cmdData);
        int ILedBxDualSdkProxy.BxDual_cmd_sysReset(byte[] ip, ushort port) => _bxDual_cmd_sysReset(ip, port);
        int ILedBxDualSdkProxy.BxDual_cmd_tcpNetworkSearch_6G(byte[] ip, ushort port, ref NetSearchCmdRet retData) => _bxDual_cmd_tcpNetworkSearch_6G(ip, port, ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_tcpNetworkSearch_6G_Web(byte[] ip, ushort port, ref NetSearchCmdRet_Web retData) => _bxDual_cmd_tcpNetworkSearch_6G_Web(ip, port, ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_tcpPing(byte[] ip, ushort port, ref Ping_data retData) => _bxDual_cmd_tcpPing(ip, port, ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_timingOnOff(byte[] ip, ushort port, byte groupNum, byte[] data) => _bxDual_cmd_timingOnOff(ip, port, groupNum, data);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName) => _bxDual_cmd_uart_confDeleteFormatFile(uartPort, baudRate, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre) => _bxDual_cmd_uart_confReedFileBlock(uartPort, baudRate, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc) => _bxDual_cmd_uart_confStartReedFile(uartPort, baudRate, fileName, fileSize, fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_confWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre) => _bxDual_cmd_uart_confWriteFile(uartPort, baudRate, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName) => _bxDual_cmd_uart_ofsDeleteFormatFile(uartPort, baudRate, fileNub, fileName);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsEndFileTransf(byte[] uartPort, byte baudRate) => _bxDual_cmd_uart_ofsEndFileTransf(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsFormat(byte[] uartPort, byte baudRate) => _bxDual_cmd_uart_ofsFormat(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsFreeDirBlock(ref GetDirBlock_G56 dirBlock) => _bxDual_cmd_uart_ofsFreeDirBlock(ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsGetMemoryVolume(byte[] uartPort, byte baudRate, ref int totalMemVolume, ref int availableMemVolume) => _bxDual_cmd_uart_ofsGetMemoryVolume(uartPort, baudRate, ref totalMemVolume, ref availableMemVolume);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsGetTransStatus(byte[] uartPort, byte baudRate, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset) => _bxDual_cmd_uart_ofsGetTransStatus(uartPort, baudRate, r_w, fileName, fileCrc, fileOffset);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsReedDirBlock(byte[] uartPort, byte baudRate, ref GetDirBlock_G56 dirBlock) => _bxDual_cmd_uart_ofsReedDirBlock(uartPort, baudRate, ref dirBlock);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre) => _bxDual_cmd_uart_ofsReedFileBlock(uartPort, baudRate, fileName, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsStartFileTransf(byte[] uartPort, byte baudRate) => _bxDual_cmd_uart_ofsStartFileTransf(uartPort, baudRate);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc) => _bxDual_cmd_uart_ofsStartReedFile(uartPort, baudRate, fileName, fileSize, fileCrc);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_ofsWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre) => _bxDual_cmd_uart_ofsWriteFile(uartPort, baudRate, fileName, fileType, fileLen, overwrite, fileAddre);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_programLock(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, uint lockDuration) => _bxDual_cmd_uart_programLock(uartPort, baudRate, nonvolatile, locked, name, lockDuration);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_programLock_6G(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, int lockDuration) => _bxDual_cmd_uart_programLock_6G(uartPort, baudRate, nonvolatile, locked, name, lockDuration);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_searchController(ref Ping_data retData, byte[] uartPort) => _bxDual_cmd_uart_searchController(ref retData, uartPort);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_search_Net_6G(ref NetSearchCmdRet retData, byte[] uartPort, ushort nBaudRateType) => _bxDual_cmd_uart_search_Net_6G(ref retData, uartPort, nBaudRateType);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_search_Net_6G_Web(ref NetSearchCmdRet_Web retData, byte[] uartPort, ushort nBaudRateType) => _bxDual_cmd_uart_search_Net_6G_Web(ref retData, uartPort, nBaudRateType);
        int ILedBxDualSdkProxy.BxDual_cmd_uart_sendConfigFile(byte[] uartPort, byte baudRate, ref ConfigFile configData) => _bxDual_cmd_uart_sendConfigFile(uartPort, baudRate, ref configData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpNetworkSearch(ref HeartbeatData retData) => _bxDual_cmd_udpNetworkSearch(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpNetworkSearch_6G(ref NetSearchCmdRet retData) => _bxDual_cmd_udpNetworkSearch_6G(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpNetworkSearch_6G_Web(ref NetSearchCmdRet_Web retData) => _bxDual_cmd_udpNetworkSearch_6G_Web(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpPing(ref Ping_data retData) => _bxDual_cmd_udpPing(ref retData);
        int ILedBxDualSdkProxy.BxDual_cmd_udpSetIP(byte mode, byte[] ip, byte[] subnetMask, byte[] gateway, short port, byte serverMode, byte[] serverIP, short serverPort, byte[] password, short heartbeat, byte[] netID) => _bxDual_cmd_udpSetIP(mode, ip, subnetMask, gateway, port, serverMode, serverIP, serverPort, password, heartbeat, netID);
        int ILedBxDualSdkProxy.BxDual_cmd_udpSetMac(byte[] mac) => _bxDual_cmd_udpSetMac(mac);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => _bxDual_dynamicAreaS_AddAreaPic_6G(pIP, nPort, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => _bxDual_dynamicAreaS_AddAreaPic_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(pIP, nPort, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => _bxDual_dynamicAreaS_AddTxtDetails_6G(pIP, nPort, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams) => _bxDual_dynamicAreaS_AddTxtDetails_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(pIP, nPort, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(pSerialName, nBaudRateIndex, color, uAreaCount, pParams, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => _bxDual_dynamicArea_AddAreaInfos_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_5G_Point(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => _bxDual_dynamicArea_AddAreaInfos_5G_Point(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => _bxDual_dynamicArea_AddAreaInfos_5G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, ref DynamicAreaBaseInfo_5G[] pInfo) => _bxDual_dynamicArea_AddAreaInfos_6G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, ref pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_6G_V2(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, BxAreaFrmae_Dynamic_G6 oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo, ref EQSound_6G pSoundData) => _bxDual_dynamicArea_AddAreaInfos_6G_V2(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo, ref pSoundData);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, BxAreaFrmae_Dynamic_G6 oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo) => _bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaInfos_G6_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, ref DynamicAreaBaseInfo_5G[] pInfo) => _bxDual_dynamicArea_AddAreaInfos_G6_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, nInfoCount, ref pInfo);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath) => _bxDual_dynamicArea_AddAreaPic_6G(pIP, nPort, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath) => _bxDual_dynamicArea_AddAreaPic_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicArea_AddAreaPic_WithProgram_6G(pIP, nPort, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(pSerialName, nBaudRateIndex, color, uAreaId, AreaX, AreaY, AreaWidth, AreaHeight, ref pheader, picPath, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent) => _bxDual_dynamicArea_AddAreaTxtDetails_6G(pIP, nPort, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent) => _bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(pIP, nPort, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial) => _bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, ref oAreaHeader_G6, ref stPageHeader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaTxt_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, IntPtr fontName, byte nFontSize, IntPtr strAreaTxtContent) => _bxDual_dynamicArea_AddAreaTxt_6G(pIP, nPort, color, uAreaId, uAreaX, uAreaY, uWidth, uHeight, fontName, nFontSize, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithPic_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, byte[] filePath) => _bxDual_dynamicArea_AddAreaWithPic_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithPic_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, byte[] filePath) => _bxDual_dynamicArea_AddAreaWithPic_5G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => _bxDual_dynamicArea_AddAreaWithTxt_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => _bxDual_dynamicArea_AddAreaWithTxt_5G_Serial(pSerialName, nBaudRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_Point_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, ref EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, ref EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => _bxDual_dynamicArea_AddAreaWithTxt_Point_5G(pIP, nPort, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, ref oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(byte[] pSerialName, int nBaundRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, ref EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, ref EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent) => _bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(pSerialName, nBaundRateIndex, color, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, uAreaX, uAreaY, uWidth, uHeight, ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, ref oFont, fontName, strAreaTxtContent);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreaS_5G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID) => _bxDual_dynamicArea_DelAreaS_5G(pIP, nPort, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreas_6G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID) => _bxDual_dynamicArea_DelAreas_6G(pIP, nPort, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreaS_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID) => _bxDual_dynamicArea_DelAreaS_G5_Serial(pSerialName, nBaudRateIndex, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelAreas_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID) => _bxDual_dynamicArea_DelAreas_6G_Serial(pSerialName, nBaudRateIndex, uAreaCount, pAreaID);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_5G(byte[] pIP, int nPort, byte uAreaId) => _bxDual_dynamicArea_DelArea_5G(pIP, nPort, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_6G(byte[] pIP, int nPort, byte uAreaId) => _bxDual_dynamicArea_DelArea_6G(pIP, nPort, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId) => _bxDual_dynamicArea_DelArea_G5_Serial(pSerialName, nBaudRateIndex, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_DelArea_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId) => _bxDual_dynamicArea_DelArea_6G_Serial(pSerialName, nBaudRateIndex, uAreaId);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_InsertSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, byte VoiceFlg, byte StoreFlag) => _bxDual_dynamicArea_InsertSoundIndepend(pIP, nPort, ref stSoundData, VoiceFlg, StoreFlag);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56 ePixelRGorGR) => _bxDual_dynamicArea_SetDualPixel(ePixelRGorGR);
        int ILedBxDualSdkProxy.BxDual_dynamicArea_UpdateSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, ushort nSoundDataCount, byte StoreFlag) => _bxDual_dynamicArea_UpdateSoundIndepend(pIP, nPort, ref stSoundData, nSoundDataCount, StoreFlag);
        int ILedBxDualSdkProxy.BxDual_get_crc16(ref FileCRC16_G56 crc16) => _bxDual_get_crc16(ref crc16);
        int ILedBxDualSdkProxy.BxDual_get_crc32(ref FileCRC32_G56 crc32) => _bxDual_get_crc32(ref crc32);
        int ILedBxDualSdkProxy.BxDual_InitSdk() => _bxDual_InitSdk();
        int ILedBxDualSdkProxy.BxDual_program_AddArea(ushort areaID, ref EQareaHeader aheader) => _bxDual_program_AddArea(areaID, ref aheader);
        int ILedBxDualSdkProxy.BxDual_program_addArea_G6(ushort areaID, ref EQareaHeader_G6 aheader) => _bxDual_program_addArea_G6(areaID, ref aheader);
        int ILedBxDualSdkProxy.BxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath) => _bxDual_program_addFrame(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath) => _bxDual_program_addFrame_G6(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_addPlayPeriodGrp(ref EQprogramppGrp_G56 header) => _bxDual_program_addPlayPeriodGrp(ref header);
        int ILedBxDualSdkProxy.BxDual_program_addPlayPeriodGrp_G6(ref EQprogramppGrp_G56 header) => _bxDual_program_addPlayPeriodGrp_G6(ref header);
        int ILedBxDualSdkProxy.BxDual_program_addProgram(ref EQprogramHeader programH) => _bxDual_program_addProgram(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_addProgram_G6(ref EQprogramHeader_G6 programH) => _bxDual_program_addProgram_G6(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_backGroundColor_G6(ushort areaID, ref EQpageHeader_G6 pheader, int BGColor) => _bxDual_program_backGroundColor_G6(areaID, ref pheader, BGColor);
        int ILedBxDualSdkProxy.BxDual_program_backGroundPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath) => _bxDual_program_backGroundPic_G6(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_changeFrame(ref EQscreenframeHeader sfHeader, byte[] picPath) => _bxDual_program_changeFrame(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_changeFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath) => _bxDual_program_changeFrame_G6(ref sfHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_changeProgramParams(ref EQprogramHeader programH) => _bxDual_program_changeProgramParams(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_changeProgramParams_G6(ref EQprogramHeader_G6 programH) => _bxDual_program_changeProgramParams_G6(ref programH);
        int ILedBxDualSdkProxy.BxDual_program_deleteArea(ushort areaID) => _bxDual_program_deleteArea(areaID);
        int ILedBxDualSdkProxy.BxDual_program_deleteArea_G6(ushort areaID) => _bxDual_program_deleteArea_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_deleteProgram() => _bxDual_program_deleteProgram();
        int ILedBxDualSdkProxy.BxDual_program_deleteProgram_G6() => _bxDual_program_deleteProgram_G6();
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader pheader) => _bxDual_program_fontPath_picturesAreaAddTxt(areaID, str, fontPathName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader_G6 pheader) => _bxDual_program_fontPath_picturesAreaAddTxt_G6(areaID, str, fontPathName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader) => _bxDual_program_fontPath_picturesAreaChangeTxt(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_picturesAreaChangeTxt_G6(ushort areaID, byte[] str, ref EQpageHeader_G6 pheader) => _bxDual_program_fontPath_picturesAreaChangeTxt_G6(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData) => _bxDual_program_fontPath_timeAreaAddContent(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_fontPath_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData) => _bxDual_program_fontPath_timeAreaAddContent_G6(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_freeBuffer(ref EQprogram program) => _bxDual_program_freeBuffer(ref program);
        int ILedBxDualSdkProxy.BxDual_program_freeBuffer_G6(ref EQprogram_G6 program) => _bxDual_program_freeBuffer_G6(ref program);
        int ILedBxDualSdkProxy.BxDual_program_IntegrateProgramFile(ref EQprogram program) => _bxDual_program_IntegrateProgramFile(ref program);
        int ILedBxDualSdkProxy.BxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program) => _bxDual_program_IntegrateProgramFile_G6(ref program);
        int ILedBxDualSdkProxy.BxDual_program_MoveArea(ushort areaID, int x, int y, int width, int height) => _bxDual_program_MoveArea(areaID, x, y, width, height);
        int ILedBxDualSdkProxy.BxDual_program_MoveArea_G6(ushort areaID, int x, int y, int width, int height) => _bxDual_program_MoveArea_G6(areaID, x, y, width, height);
        int ILedBxDualSdkProxy.BxDual_program_pictureArea(int programID, byte[] ip, ushort port) => _bxDual_program_pictureArea(programID, ip, port);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaAddPic(ushort areaID, ushort picID, ref EQpageHeader pheader, byte[] picPath) => _bxDual_program_pictureAreaAddPic(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath) => _bxDual_program_pictureAreaAddPic_G6(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaChangePic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath) => _bxDual_program_pictureAreaChangePic_G6(areaID, picID, ref pheader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaChangeSoundSettings_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData) => _bxDual_program_pictureAreaChangeSoundSettings_G6(areaID, sheader, soundData);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaDisableSound_G6(ushort areaID) => _bxDual_program_pictureAreaDisableSound_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaEnableSound_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData) => _bxDual_program_pictureAreaEnableSound_G6(areaID, sheader, soundData);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaGetOnePage(ushort areaID, int pageNum, ref GetPageData pageData) => _bxDual_program_pictureAreaGetOnePage(areaID, pageNum, ref pageData);
        int ILedBxDualSdkProxy.BxDual_program_pictureAreaRemoveFrame(ushort areaID) => _bxDual_program_pictureAreaRemoveFrame(areaID);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddFrame(ushort areaID, ref EQareaframeHeader afHeader, byte[] picPath) => _bxDual_program_picturesAreaAddFrame(areaID, ref afHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddFrame_G6(ushort areaID, ref EQscreenframeHeader_G6 afHeader, byte[] picPath) => _bxDual_program_picturesAreaAddFrame_G6(areaID, ref afHeader, picPath);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader pheader) => _bxDual_program_picturesAreaAddTxt(areaID, str, fontName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader_G6 pheader) => _bxDual_program_picturesAreaAddTxt_G6(areaID, str, fontName, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader) => _bxDual_program_picturesAreaChangeTxt(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_picturesAreaChangeTxt_G6(ushort areaID, IntPtr str, ref EQpageHeader_G6 pheader) => _bxDual_program_picturesAreaChangeTxt_G6(areaID, str, ref pheader);
        int ILedBxDualSdkProxy.BxDual_program_removeFrame() => _bxDual_program_removeFrame();
        int ILedBxDualSdkProxy.BxDual_program_removeFrame_G6() => _bxDual_program_removeFrame_G6();
        int ILedBxDualSdkProxy.BxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor) => _bxDual_program_setScreenParams_G56(color, ControllerType, doubleColor);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorAreaHumidity_G5(ushort nAreaID, byte nSensorType, byte nHumidityMode, byte nHumidityCorrectionPol, byte nHumidityCorrection, byte nHumidityThresh, byte nHumidityColor, byte nHumidityErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation) => _bxDual_program_SetSensorAreaHumidity_G5(nAreaID, nSensorType, nHumidityMode, nHumidityCorrectionPol, nHumidityCorrection, nHumidityThresh, nHumidityColor, nHumidityErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorAreaNoise_G5(ushort nAreaID, byte nSensorType, byte nNoiseMode, byte nNoiseCorrectionPol, byte nNoiseCorrection, byte nNoiseThresh, byte nNoiseColor, byte nNoiseErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation) => _bxDual_program_SetSensorAreaNoise_G5(nAreaID, nSensorType, nNoiseMode, nNoiseCorrectionPol, nNoiseCorrection, nNoiseThresh, nNoiseColor, nNoiseErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorAreaTemperature_G5(ushort nAreaID, byte nSensorType, byte nTemperatureUnit, byte nTermperatureMode, byte nTemperatureCorrectionPol, byte nTemperatureCorrection, byte nTemperatureThreshPol, byte nTemperatureThresh, byte nTemperatureColor, byte nTemperatureErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation) => _bxDual_program_SetSensorAreaTemperature_G5(nAreaID, nSensorType, nTemperatureUnit, nTermperatureMode, nTemperatureCorrectionPol, nTemperatureCorrection, nTemperatureThreshPol, nTemperatureThresh, nTemperatureColor, nTemperatureErrColor, pstrFixTxt, nFontSize, pstrFontNameFile, nUnitShowRation);
        int ILedBxDualSdkProxy.BxDual_program_SetSensorArea_G6(ushort nAreaID, byte nSensorMode, byte nSensorType, byte nSensorUnit, byte[] pFixedTxt, byte[] pFontName, byte nFontSize, byte nSensorColor, byte SensorErrColor1, int nAlarmValue, byte nSensorThreshPol, byte nDisplayUnitFlag, byte nSensorModeDispType, byte nSensorCorrectionPol, int nSensorCorrection, byte nRatioValue) => _bxDual_program_SetSensorArea_G6(nAreaID, nSensorMode, nSensorType, nSensorUnit, pFixedTxt, pFontName, nFontSize, nSensorColor, SensorErrColor1, nAlarmValue, nSensorThreshPol, nDisplayUnitFlag, nSensorModeDispType, nSensorCorrectionPol, nSensorCorrection, nRatioValue);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => _bxDual_program_timeAreaAddAnalogClock(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => _bxDual_program_timeAreaAddAnalogClock_G6(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData) => _bxDual_program_timeAreaAddContent(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData) => _bxDual_program_timeAreaAddContent_G6(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaAddCounterTimer_G6(ushort areaID, ref BXG6_Time_Counter header, byte[] cUnitDay, byte[] cUnitHour, byte[] cUnitMinute, byte[] cUnitSec, byte[] pFixedTxt) => _bxDual_program_timeAreaAddCounterTimer_G6(areaID, ref header, cUnitDay, cUnitHour, cUnitMinute, cUnitSec, pFixedTxt);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaCancleBattleTime_G6(ushort areaID) => _bxDual_program_timeAreaCancleBattleTime_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => _bxDual_program_timeAreaChangeAnalogClock(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor) => _bxDual_program_timeAreaChangeAnalogClock_G6(areaID, ref header, cStyle, ref cColor);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeContent(ushort areaID, ref EQtimeAreaData_G56 timeData) => _bxDual_program_timeAreaChangeContent(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData) => _bxDual_program_timeAreaChangeContent_G6(areaID, ref timeData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeDialPic(ushort areaID, byte[] picPath) => _bxDual_program_timeAreaChangeDialPic(areaID, picPath);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeDialPicAdd_G56(ushort areaID, byte[] picAdd, int picLen) => _bxDual_program_timeAreaChangeDialPicAdd_G56(areaID, picAdd, picLen);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaChangeDialPic_G6(ushort areaID, byte[] picPath) => _bxDual_program_timeAreaChangeDialPic_G6(areaID, picPath);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaGetOnePage(ushort areaID, ref GetPageData pageData) => _bxDual_program_timeAreaGetOnePage(areaID, ref pageData);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaRemoveDialPic(ushort areaID) => _bxDual_program_timeAreaRemoveDialPic(areaID);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaRemoveDialPic_G6(ushort areaID) => _bxDual_program_timeAreaRemoveDialPic_G6(areaID);
        int ILedBxDualSdkProxy.BxDual_program_timeAreaSetBattleTime_G6(ushort areaID, ref EQTimeAreaBattle_G6 header) => _bxDual_program_timeAreaSetBattleTime_G6(areaID, ref header);
        void ILedBxDualSdkProxy.BxDual_ReleaseSdk() => _bxDual_ReleaseSdk();
        int ILedBxDualSdkProxy.BxDual_set_packetLen(ushort packetLen) => _bxDual_set_packetLen(packetLen);
        int ILedBxDualSdkProxy.BxDual_set_screenNum_G56(ushort usDstAddr) => _bxDual_set_screenNum_G56(usDstAddr);
        #endregion
    }
}
