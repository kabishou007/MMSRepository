using System.Collections.Generic;

namespace MMS.Infrastructure
{
    public class CurrentUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户拥有的角色
        /// </summary>
        //public List<object> RoleIDs { get; set; }
        
        /// <summary>
        /// 用户角色拥有的权限
        /// </summary>
        public List<object> PermissionIDs { get; set; }
    }
}
