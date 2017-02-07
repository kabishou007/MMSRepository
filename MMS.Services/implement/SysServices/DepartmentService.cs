using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMS.Models;
using MMS.Data;

namespace Services
{
    internal class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddDepartment(Department department)
        {
            _unitOfWork.GetRepository<Department>().Add(department);
            return _unitOfWork.Commit();
        }

        public bool DeleteDepartment(object departmentID)
        {
            _unitOfWork.GetRepository<Department>().Delete(departmentID);
            return _unitOfWork.Commit();
        }

        public bool EditDepartmentInfo(Department department)
        {
            _unitOfWork.GetRepository<Department>().Edit(department);
            return _unitOfWork.Commit();
        }

        public List<Department> GetChildDepartments(object parentDeptID, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Department>().GetPageList<int>(d => d.ParentID == (int?)parentDeptID, d => d.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public Department GetDepartmentByID(object departmentID)
        {
            return _unitOfWork.GetRepository<Department>().Get(departmentID);
        }

        public List<Department> GetDepartmentsByName(string name, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Department>().GetPageList<int>(d => d.Name == name, d => d.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Department> GetDepartmentsByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Department>().GetPageList<int>(d => d.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }
    }
}
