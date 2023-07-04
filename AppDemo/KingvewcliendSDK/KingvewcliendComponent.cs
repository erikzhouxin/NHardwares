using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CenIdea.Qualimetry.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class KingvewcliendComponent
    {
        static KingvewcliendComponent()
        {
       
        }
        ///   <summary>
        ///  与组态王建立连接
        ///  每次应用程序启动时，必须用该函数与组态王建立连接
        ///  @"D:\env\SDK\kingvewcliend.dll"
        ///   </summary>
        ///   <param name="node"> node为节点(IP)，如果是本机，其值为空 </param>
        ///   <returns> 返回错误码，见附录。 </returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int StartCliend(string node);

        ///   <summary>  
        ///  得到组态王SDK中列出的项目（包括变量及其域）总数 
        ///   </summary>  
        [DllImport("kingvewcliend.dll")]
        public static extern int ReadItemNo();

        ///   <summary>  
        ///  得到某个项目的名称 
        ///   <param name="sName"> 将返回组态王的项目的名称 </param>  
        ///   <param name="wItemId"> 为用户写入的其要取的变量的索引号，其为ReadItemNo返回的范围内的某个数 </param>  
        ///   <returns> 返回错误码，见附录 </returns>  
        ///   </summary>  
        [DllImport("kingvewcliend.dll")]
        // [SecurityPermission(SecurityAction.Assert, Unrestricted = true)]

        public static extern int GetItemNames(StringBuilder sName, int wItemId);

        ///   <summary>  
        ///  将某个项目添加到采集列中 
        ///   <param name="sRegName"> 是要加入采集的项目名 </param>  
        ///   <param name="TagId"> TagId项目采集的标识号 </param>  
        ///   <param name="TagDataType"> 项目的数据类型 </param>
        ///   <returns> 返回错误码，见附录 </returns>  
        ///   </summary>  
        [DllImport("kingvewcliend.dll")]
        public static extern int AddTag(string sRegName, ref int TagId, ref int TagDataType);

        ///   <summary>
        ///  向某个项目中有应用程序向组态王方向写数据
        ///   </summary>
        ///   <param name="TagId"> 为要采集项目的标识号 </param>
        ///   <param name="bVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <param name="lVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <param name="fVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <param name="sVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <returns> 返回错误码,见附录 </returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int WriteTag(ushort TagId, bool bVal, long lVal, float fVal, char[] sVal);

        ///   <summary>
        ///  从组态王中读某个项目的数据
        ///   </summary>
        ///   <param name="TagId"> 要采集的变量的表示号 </param>
        ///   <param name="bVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <param name="lVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <param name="fVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <param name="sVal"> bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值 </param>
        ///   <returns> 返回错误码,见附录 </returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int ReadTag(int TagId, ref bool bVal, ref long lVal, ref Single fVal, StringBuilder sVal);

        ///   <summary>
        ///  断开与组态王OPC的连接
        ///   </summary>
        ///   <returns> 返回错误码,见附录 </returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int StopCliend();
    }

    /// <summary>
    /// 组态王变量对象
    /// </summary>
    public class KingviewItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string ItemName { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public int ItemTagId { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public int ItemTagType { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public bool ItemValueBool { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public long ItemValueLong { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public float ItemValueFloat { get; set; } = 0.0f;
        /// <summary>
        /// 
        /// </summary>
        public string ItemValueString { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"变量：ItemName:【{ItemName}】 ItemTagId:【{ItemTagId}】 ItemTagType:【{ItemTagType}】 ItemValueBool:{ItemValueBool} ItemValueLong:{ItemValueLong} ItemValueFloat:{ItemValueFloat} ItemValueString:{ItemValueString}";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ReadValue()
        {
            bool bVal = false;
            long lVal = 0;
            float fVal = 0.0f;
            StringBuilder sVal = new StringBuilder(255);
            var r = KingvewcliendComponent.ReadTag(ItemTagId, ref bVal, ref lVal, ref fVal, sVal);
            ItemValueBool = bVal;
            ItemValueLong = lVal;
            ItemValueFloat = fVal;
            ItemValueString = sVal.ToString();
            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="lVal"></param>
        /// <param name="fVal"></param>
        /// <param name="sVal"></param>
        /// <returns></returns>
        public int WriteValue(bool bVal, long lVal, float fVal, char[] sVal)
        {
            return KingvewcliendComponent.WriteTag((ushort)ItemTagId, bVal, lVal, fVal, sVal);
        }
    }
    
    /// <summary>
    /// 获取流量组件
    /// </summary>
    public class KingvewReaderComponent
    {
        private string node;

        private List<KingviewItem> items;

        private bool isStart = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="names"></param>
        public KingvewReaderComponent(string node, string[] names) 
        {
            if (names == null || names.Length == 0) 
            {
                throw new ArgumentException("监控项目不能为空");
            }
            this.node = node;
            this.items = new List<KingviewItem>(names.Length);
            for (var i = 0; i < names.Length; i++)
            {
                items.Add(new KingviewItem() { ItemName = names[i] });
            }
        }
        /// <summary>
        /// 开始
        /// </summary>
        /// <returns></returns>
        public AlertMsg Start() 
        {
            if (isStart) 
            {
                return new AlertMsg(true, "已开始");
            }
            int code = KingvewcliendComponent.StartCliend(this.node);
            if (code == 0) 
            {
                isStart = true;
                return new AlertMsg(true, "开始成功");
            }
            return new AlertMsg(false, "开始失败") { Code = code };
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <returns></returns>
        public AlertMsg Stop()
        {
            if (!isStart)
            {
                return new AlertMsg(true, "已停止");
            }
            int code = KingvewcliendComponent.StopCliend();
            if (code == 0)
            {
                isStart = false;
                return new AlertMsg(true, "停止成功");
            }
            return new AlertMsg(false, "停止失败") { Code = code };
        }
        /// <summary>
        /// 添加监控项目
        /// </summary>
        /// <returns></returns>
        public AlertMsg AddTags() 
        {
            if (!isStart) 
            {
                return new AlertMsg(false, "未开始");
            }
            int tagId = 0;
            int tagType = 0;
            foreach (var item in this.items) 
            {
                int code = KingvewcliendComponent.AddTag(item.ItemName.ToString(), ref tagId, ref tagType);
                if (code == 0)
                {
                    item.ItemTagId = tagId;
                    item.ItemTagType = tagType;
                }
                else 
                {
                    return new AlertMsg(false, "添加监控失败") { Code = code};
                }
            }
            return new AlertMsg(true, "添加监控成功");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AlertMsg ReadValue(string name) 
        {
            if (!isStart) 
            {
                return new AlertMsg(false, "未开始");
            }
            var item = this.items.GetDefault(t => t.ItemName.Equals(name));
            if (item == null) 
            {
                return new AlertMsg(false, "项目名不存在");
            }
            var code = item.ReadValue();
            if (code != 0) 
            {
                return new AlertMsg(false, "数据读取失败") { Code = code };
            }
            return new AlertMsg(true, "数据读取成功") { Data = item };
        }
    }
}
