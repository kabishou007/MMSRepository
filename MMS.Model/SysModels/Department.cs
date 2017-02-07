using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMS.Models
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

        [DisplayName("部门主管"), StringLength(50)]
        public string Director { get; set; }

        [DisplayName("部门描述"), StringLength(200)]
        public string Description { get; set; }

        [DisplayName("上级部门ID")]
        public int? ParentID { get; set; }


        [DisplayName("上级部门"),ForeignKey("ParentID")]
        public virtual Department ParentDepartment { get; set; }

        [DisplayName("子部门")]
        public virtual ICollection<Department> ChildDepartments { get; set; }

        [DisplayName("部门员工")]
        public virtual ICollection<User> Users { get; set; }
    }
}