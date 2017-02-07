using MMS.Infrastructure;
using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// 权限管理服务接口
    /// </summary>
    public interface IPermissionService: IDependency
    {
        /// <summary>
        /// 增加权限
        /// </summary>
        bool AddPermission(Permission permission);

        /// <summary>
        /// 编辑权限
        /// </summary>
        bool EditPermission(Permission permission);

        /// <summary>
        /// 通过权限ID删除权限
        /// </summary>
        bool DeletePermission(object permissionID);

        /// <summary>
        /// 通过权限ID批量删除权限
        /// </summary>
        /// <param name="permissionIDs"></param>
        /// <returns></returns>
        bool DeletePermissions(List<object> permissionIDs);

        /// <summary>
        /// 通过权限ID获得权限
        /// </summary>
        Permission GetPermissionByID(object permissionID);

        /// <summary>
        /// 获取权限列表(分页，按id排序)
        /// </summary>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<Permission> GetPermissionsByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过权限ID获取其子权限列表
        /// </summary>
        /// <param name="parentPermissionID">权限ID</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<Permission> GetChildPermissions(object parentPermissionID, bool isAsc, int pageSize, int pageIndex, out int totalCount);
    }
}
