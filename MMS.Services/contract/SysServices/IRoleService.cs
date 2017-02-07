using MMS.Infrastructure;
using MMS.Models;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// 角色管理服务接口
    /// </summary>
    public interface IRoleService: IDependency
    {
        /// <summary>
        /// 配置角色权限
        /// </summary>
        bool SetRolePermissions(object roleID, List<object> permissionIDs);

        /// <summary>
        /// 增加角色
        /// </summary>
        bool AddRole(Role role);

        /// <summary>
        /// 编辑角色
        /// </summary>
        bool EditRole(Role role);

        /// <summary>
        /// 通过角色ID删除角色
        /// </summary>
        bool DeleteRole(object roleID);

        /// <summary>
        /// 通过角色ID获得角色
        /// </summary>
        Role GetRoleByID(object roleID);

        /// <summary>
        /// 获取角色列表(分页，按id排序)
        /// </summary>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<Role> GetRolesByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过角色名获得角色列表(分页，按id排序)
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<Role> GetRolesByName(string roleName, bool isAsc, int pageSize, int pageIndex, out int totalCount);
    }
}
