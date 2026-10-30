using TaskFlow.DataAccess.Repositories;
using TaskFlow.Models;

namespace TaskFlow.Business.Services
{

    public class RoleServices {



        private readonly RoleDAL _roleDAL;

        public RoleServices(RoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }


        public async Task<List<Role>> GetAllRoleAsync()
        {

            var users = await _roleDAL.GetAllRolesAsync();

            return users;
        }


        public async Task<Role?> GetRoleByIdAsync(int RoleID)
        {

            Role? role;

            role = await _roleDAL.GetRoleByIdAsync(RoleID);

            return role;
        }
    }




}