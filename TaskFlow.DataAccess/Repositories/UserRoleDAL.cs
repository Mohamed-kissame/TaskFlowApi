using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repositories
{


    public class UserRoleDAL
    {
        private readonly TaskFlowDbContext _context;

        public UserRoleDAL(TaskFlowDbContext context)
        {
           _context = context;   
        }


        public async Task<List<UserRole>> GetAllUserRoleAsync()
        {

            List<UserRole> userroles;

            userroles = await _context.UserRoles.ToListAsync();

            return userroles;
        }

        public async Task<UserRole?> GetUserRoleByIdAsync(int UserID , int RoleID)
        {

            UserRole? userrole;

            userrole = await _context.UserRoles.FindAsync(UserID, RoleID);

            return userrole;
        }

    }

}