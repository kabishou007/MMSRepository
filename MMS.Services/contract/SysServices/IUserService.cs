using MMS.Infrastructure;
using MMS.Models;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// 后台用户管理服务接口
    /// </summary>
    public interface IUserService:IDependency
    {
        /// <summary>
        /// 配置用户角色
        /// </summary>
        bool SetUserRoles(object userID, List<object> roleIDs);

        /// <summary>
        /// 激活或冻结用户
        /// </summary>
        bool ActivateUserOrNot(object userID);

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        bool EditUserInfo(User user);

        /// <summary>
        /// 重置用户密码（默认密码123456）
        /// </summary>
        bool ResetPassword(object userID);

        /// <summary>
        /// 获取用户列表(分页，按id排序)
        /// </summary>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<User> GetUsersByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过姓名关键字获取用户列表(分页，按id排序)
        /// </summary>
        /// <param name="name">姓名关键字</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<User> GetUsersByName(string name, bool isAsc, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过工号获取单个用户
        /// </summary>
        User GetUserByWorkNumber(string workNumber);

        /// <summary>
        /// 通过角色名获取用户列表(分页，按id排序)
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<User> GetUsersByRoleName(string roleName, bool isAsc, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过部门名称获取用户列表(分页，按id排序)
        /// </summary>
        /// <param name="deptName">部门名称</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<User> GetUsersByDeptName(string deptName, bool isAsc, int pageSize, int pageIndex, out int totalCount);
    }
}
