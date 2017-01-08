//using MMS.Models.SysModels;
using MMS.Models.SysModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DisplayName("父级权限ID")]
        public int? ParentID { get; set; }

        /*
         * 权限类型:
         * 1.View：页面
         * 2.Menu：菜单
         * 3.Button：按钮
         */
        [DisplayName("权限类型"), Required]
        public string Type { get; set; }

        [DisplayName("目标Url")]
        public string TargetUrl { get; set; }

        [DisplayName("生成顺序编号")]
        public int SortCode { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }



        [DisplayName("父级权限"),ForeignKey("ParentID")]
        public virtual Permission ParentPermission { get; set; }

        [DisplayName("子权限")]
        public virtual ICollection<Permission> ChildPermissions { get; set; }

        [DisplayName("所属角色")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
