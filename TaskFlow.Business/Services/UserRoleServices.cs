using TaskFlow.DataAccess.Repositories;
using TaskFlow.Models;

namespace TaskFlow.Business.Services
{

    public class UserRoleServices
    {
        private readonly UserRoleDAL _userroleDAL;

        public UserRoleServices(UserRoleDAL userroleDAL)
        {
            _userroleDAL = userroleDAL;
        }


        public async Task<List<UserRole>> GetAllUserRoleAsync()
        {


            List<UserRole> userRoles = await _userroleDAL.GetAllUserRoleAsync();

            return userRoles;

        }
    }

}