using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repositories
{

    public class RoleDAL
    {
        private readonly TaskFlowDbContext _context;
        public RoleDAL(TaskFlowDbContext context)
        {
                _context = context;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {

            List<Role> roles;

            roles = await _context.Roles.ToListAsync();

            return roles;
        }


        public async Task<Role?> GetRoleByIdAsync(int RoleId)
        {

            Role? role;

            role = await _context.Roles.FindAsync(RoleId);

            return role;
        }
    }

}