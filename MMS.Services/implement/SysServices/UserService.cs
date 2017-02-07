using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMS.Data;

namespace Services
{
    internal class UserService :IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ActivateUserOrNot(object userID)
        {
            User user=_unitOfWork.GetRepository<User>().Get(userID);
            user.IsActive = !user.IsActive;
            _unitOfWork.GetRepository<User>().Edit(user, new string[] { "IsActive" });
            return _unitOfWork.Commit();
        }

        public bool EditUserInfo(User user)
        {
            _unitOfWork.GetRepository<User>().Edit(user);
            return _unitOfWork.Commit();
        }

        public User GetUserByWorkNumber(string workNumber)
        {
            return _unitOfWork.GetRepository<User>().Get(u => u.WorkNumber == workNumber);
        }

        public List<User> GetUsersByDeptName(string deptName, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<User>().GetPageList<int>(u => u.Department.Name == deptName, u=>u.ID,isAsc, pageSize, pageIndex,out totalCount).ToList();
        }

        public List<User> GetUsersByName(string name, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<User>().GetPageList<int>(u => u.Name == name, u => u.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<User> GetUsersByPage(bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<User>().GetPageList<int>(u => u.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<User> GetUsersByRoleName(string roleName, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            Role role = _unitOfWork.GetRepository<Role>().Get(r => r.Name == roleName);
            return _unitOfWork.GetRepository<User>().GetPageList<int>(u => u.Roles.Contains(role), u => u.ID, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public bool ResetPassword(object userID)
        {
            User user = _unitOfWork.GetRepository<User>().Get(userID);
            user.Password = "123456";
            _unitOfWork.GetRepository<User>().Edit(user, new string[] { "Password" });
            return _unitOfWork.Commit();
        }

        public bool SetUserRoles(object userID, List<object> roleIDs)
        {
            User user = _unitOfWork.GetRepository<User>().Get(userID);
            foreach (object roleID in roleIDs)
            {
                Role role = _unitOfWork.GetRepository<Role>().Get(roleID);
                user.Roles.Add(role);
            }
            return _unitOfWork.Commit();
        }
    }
}
