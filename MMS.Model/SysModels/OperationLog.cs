using System;
using System.ComponentModel;

namespace MMS.Models.SysModels
{
    /// <summary>
    /// 操作日志类，本类仅做查询，写入使用NLog框架
    /// </summary>
    public class OperationLog
    {
        public int ID { get; set; }
        [Description("当前日志创建时间")]
        public DateTime CreateTime { get; set; }
        [Description("日志等级")]
        public string LogLevel { get; set; }
        [Description("执行的数据库操作SQL语句")]
        public string OperateSQL { get; set; }

        public virtual User User { get; set; }
    }
}
