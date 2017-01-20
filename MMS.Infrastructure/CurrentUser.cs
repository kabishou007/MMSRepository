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
        public List<int> RoleIDs { get; set; }
        /// <summary>
        /// 用户角色拥有的操作资源
        /// </summary>
        public List<int> ResourceIDs { get; set; }
    }
}
