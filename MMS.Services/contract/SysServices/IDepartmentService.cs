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
    /// 部门管理服务接口
    /// </summary>
    public interface IDepartmentService: IDependency
    {
        /// <summary>
        /// 增加部门
        /// </summary>
        bool AddDepartment(Department department);

        /// <summary>
        /// 编辑部门
        /// </summary>
        bool EditDepartmentInfo(Department department);

        /// <summary>
        /// 通过部门ID删除部门
        /// </summary>
        bool DeleteDepartment(object departmentID);

        /// <summary>
        /// 获取部门列表(分页，按id排序)
        /// </summary>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<Department> GetDepartmentsByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过部门名称关键字获取部门列表(分页，按id排序)
        /// </summary>
        /// <param name="name">部门名称关键字</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<Department> GetDepartmentsByName(string name, bool isAsc, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过权限ID获得权限
        /// </summary>
        Department GetDepartmentByID(object departmentID);

        /// <summary>
        /// 通过部门ID获取其子部门列表
        /// </summary>
        /// <param name="parentDeptID">部门ID</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总条数</param>
        List<Department> GetChildDepartments(object parentDeptID, bool isAsc, int pageSize, int pageIndex, out int totalCount);
    }
}
