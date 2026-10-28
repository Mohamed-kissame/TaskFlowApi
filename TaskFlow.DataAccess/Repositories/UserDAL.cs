using Microsoft.EntityFrameworkCore;
using TaskFlow.DataAccess;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repositories
{

    public class UserDAL
    {

        private readonly TaskFlowDbContext _context;

        public UserDAL(TaskFlowDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync(bool ? isActive)
        {
            List<User> users;

            if (isActive != null)
            {
                return await _context.Users.Where(u => u.IsActive == isActive).ToListAsync();
            }

            users = await _context.Users.ToListAsync();

            return users;


        }

        public async Task<User?> GetUserByIDAsync(int UserID)
        {

            User? user = null;


            user = await _context.Users.FindAsync(UserID);

            return user;
        }

        public async Task<List<User>> FilterActiveUsersAsync(bool? IsActive)
        {

            return await _context.Users.Where(u => u.IsActive == IsActive).ToListAsync();
        }

    }

}