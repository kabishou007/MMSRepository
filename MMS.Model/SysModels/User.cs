using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMS.Models.SysModels
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("姓名"),StringLength(50),Required]
        public string Name { get; set; }

        [DisplayName("登录名"), StringLength(50), Required]
        public string LoginName { get; set; }

        [DisplayName("工号"), StringLength(50),Required]
        public string WorkNumber { get; set; }

        [DisplayName("密码"), StringLength(200), Required]
        public string Password { get; set; }

        [DisplayName("邮箱"), RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        [DisplayName("性别")]
        public bool Gender { get; set; }

        [DisplayName("分机号")]
        public string Telephone { get; set; }

        [DisplayName("注册时间"),  DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

        [Description("逻辑删除"),Required]
        public bool IsDelete { get; set; }

        [DisplayName("所属部门")]
        public virtual Department Department { get; set; }
        [DisplayName("所属角色")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
