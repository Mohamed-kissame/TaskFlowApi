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

    }

}