using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MMS.Models.SysModels
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("部门名称"), StringLength(50), Required]
        public string Name { get; set; }

        [DisplayName("部门描述"), StringLength(200)]
        public string Description { get; set; }

        [DisplayName("部门员工")]
        public virtual ICollection<User> Users { get; set; }
    }
}