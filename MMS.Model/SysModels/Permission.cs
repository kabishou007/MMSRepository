using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MMS.Model.SysModels
{
    public class Permission
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("权限名称"),Required]
        public string Name { get; set; }

        [DisplayName("权限标题"), Required]
        public string Title { get; set; }

        [DisplayName("图标")]
        public string Icon { get; set; }

        [DisplayName("权限类型"), Required]
        public string Type { get; set; }

        [DisplayName("父级权限")]
        public Permission ParentPermission { get; set; }

        [DisplayName("目标Url")]
        public string TargetUrl { get; set; }

        [DisplayName("生成顺序编号")]
        public int SortCode { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }

        //[DisplayName("拥有子权限")]
        //public virtual ICollection<Permission> ChildPermissions { get; set; }

        [DisplayName("所属角色")]
        public virtual ICollection<Role> Roles { get; set; }

    }
}
