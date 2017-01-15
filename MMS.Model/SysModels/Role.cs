using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MMS.Models
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("角色名称"),StringLength(50), Required]
        public string Name { get; set; }

        [DisplayName("角色描述"),StringLength(200)]
        public string Description { get; set; }

        [DisplayName("包含用户")]
        public virtual ICollection<User> Users { get; set; }
        [DisplayName("包含权限")]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
