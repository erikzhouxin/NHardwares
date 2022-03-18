using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 读信息描述模型
    /// </summary>
    public class ReadDescriptionModel
    {
        /// <summary>
        /// 读标签命令cmd_read
        /// </summary>
        /// <param name="head">头:0xA0</param>
        /// <param name="len">长度:0x0A</param>
        /// <param name="address"></param>
        /// <param name="cmd">命令值:0x81<see cref="ReadCmdType"/></param>
        /// <param name="memBank">标签存储区域<see cref="ReadAreaType"/></param>
        /// <param name="wordAdd">读取数据首地址,取值范围请参考标签规格</param>
        /// <param name="wordCnt">读取数据长度,字长，WORD(16 bits)长度</param>
        /// <param name="passWord">标签访问密码，4 字节</param>
        /// <param name="check">校验位</param>
        /// <returns>
        /// 操作成功:
        /// Head 0xA0
        /// Len 长度
        /// Address 地址
        /// Cmd 命令
        /// TagCount 标签计数(2字节=16 bits)成功操作的标签总数
        /// DataLen 所操作标签的有效数据长度,PC+CRC+EPC+读取的标签数据
        /// Data 所操作标签的有效数据,PC (2 字节) + EPC (根据标签规格) + CRC (2 字节) + 读取的数据,PC(2 字节) + EPC + CRC(2 字节) 即 EPC 存储区域中的全部内容
        /// ReadLen Read 操作的数据长度。单位是字节
        /// AntID 高 6 位是第一次读取的频点参数，低 2 位是天线号
        /// ReadCount 该标签被成功操作的次数
        /// Check 校验位
        /// 注:相同 EPC 的标签，若读取的数据不相同，则被视为不同的标签
        /// 操作失败:
        /// Head 
        /// Len 
        /// Address 
        /// Cmd 
        /// ErrorCode 错误代码
        /// Check
        /// </returns>
        public static byte[] GetCmdRead(byte head, byte len, byte address, byte cmd, byte memBank, byte wordAdd, byte wordCnt, byte[] passWord, byte check)
        {
            return new byte[]
            {
                head,
                len,
                address,
                cmd,
                memBank,
                wordAdd,
                wordCnt,
                passWord[0],
                passWord[1],
                passWord[2],
                passWord[3],
                check,
            };
        }
        /// <summary>
        /// 盘点标签
        /// </summary>
        /// <param name="head">头,0xA0</param>
        /// <param name="len">长度,0x04</param>
        /// <param name="address"></param>
        /// <param name="cmd">0x80</param>
        /// <param name="repeat">
        /// 盘存过程重复的次数,Repeat = 0xFF 则此轮盘存时间为最短时 间。如果射频区域内只有一张标签，则此轮 的盘存约耗时为 30-50mS。一般在四通道 机器上快速轮询多个天线时使用此参数值。
        /// 将参数设置成 255（0xFF）时，将启动专为读少量标签设计的算法。对于少量标的应 用来说，效率更高，反应更灵敏，但此参数不适合同时读取大量标签的应用。
        /// </param>
        /// <param name="check"></param>
        /// <returns>
        /// 操作成功:
        /// Head 0xA0
        /// Len 0x0C
        /// Address 
        /// Cmd 0x80
        /// AntID 此次盘存使用的天线号
        /// TagCount 2 Bytes,识别标签的总数量，根据 EPC 号来区分标签，相同 EPC 号的标签将被视为同一张标签。若未清空缓存，标签数量 为多次盘存操作的数量累加
        /// ReadRate 2Bytes此次执行命令的标签识别速度(成功读取标签的次数/秒)。 不区分是否多次读取同一张标签。
        /// TotalRead 此次执行命令的标签的总读取标签次数，不区分是否多次 读取同一张标签。
        /// Check
        /// 操作失败:
        /// Head 
        /// Len 
        /// Address 
        /// Cmd 
        /// ErrorCode 
        /// Check
        /// </returns>
        public static byte[] GetCmdInventory(byte head,byte len,byte address,byte cmd,byte repeat,byte check)
        {
            return new byte[]
            {
                head,
                len,
                address,
                cmd,
                repeat,
                check,
            };
        }
    }
}
