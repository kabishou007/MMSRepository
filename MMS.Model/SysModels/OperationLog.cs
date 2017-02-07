using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMS.Models
{
    /// <summary>
    /// 操作日志类，本类仅做查询，写入使用NLog框架
    /// </summary>
    public class OperationLog
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("日志创建时间"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }

        [DisplayName("执行的数据库操作SQL语句"),Required]
        public string OperateSQL { get; set; }

        [DisplayName("执行操作的用户")]
        public virtual User User { get; set; }
    }
}
