using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMS.Data;

namespace Services
{
    internal class RoleService :IRoleService
    {
        private IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Add(role);
            return _unitOfWork.Commit();
        }

        public bool DeleteRole(object roleID)
        {
            _unitOfWork.GetRepository<Role>().Delete(roleID);
            return _unitOfWork.Commit();
        }

        public bool EditRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Edit(role);
            return _unitOfWork.Commit();
        }

        public Role GetRoleByID(object roleID)
        {
           return _unitOfWork.GetRepository<Role>().Get(roleID);
        }

        public List<Role> GetRolesByName(string roleName, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Role>().GetPageList<int>(r => r.Name == roleName, r => r.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Role> GetRolesByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Role>().GetPageList<int>(r => r.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public bool SetRolePermissions(object roleID, List<object> permissionIDs)
        {
            Role role = _unitOfWork.GetRepository<Role>().Get(roleID);
            foreach (object permissionID in permissionIDs)
            {
                Permission permission = _unitOfWork.GetRepository<Permission>().Get(permissionID);
                role.Permissions.Add(permission);
            }
            return _unitOfWork.Commit();
        }
    }
}
