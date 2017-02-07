using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMS.Data;

namespace Services
{
    internal class PermissionService :  IPermissionService
    {
        private IUnitOfWork _unitOfWork;
        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddPermission(Permission permission)
        {
            _unitOfWork.GetRepository<Permission>().Add(permission);
            return _unitOfWork.Commit();
        }

        public bool DeletePermission(object permissionID)
        {
            _unitOfWork.GetRepository<Permission>().Delete(permissionID);
            return _unitOfWork.Commit();
        }

        public bool DeletePermissions(List<object> permissionIDs)
        {
            foreach (object permissionID in permissionIDs)
            {
                _unitOfWork.GetRepository<Permission>().Delete(permissionID);
            }
            return _unitOfWork.Commit();
        }

        public bool EditPermission(Permission permission)
        {
            _unitOfWork.GetRepository<Permission>().Edit(permission);
            return _unitOfWork.Commit();
        }

        public Permission GetPermissionByID(object permissionID)
        {
            return _unitOfWork.GetRepository<Permission>().Get(permissionID);
        }

        public List<Permission> GetPermissionsByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Permission>().GetPageList<int>(p => p.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Permission> GetChildPermissions(object parentPermissionID, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Permission>().GetPageList<int>(p => p.ParentID == (int?)parentPermissionID, p => p.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }
    }
}
