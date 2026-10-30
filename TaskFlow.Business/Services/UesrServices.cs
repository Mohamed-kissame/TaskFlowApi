using Microsoft.Identity.Client;
using TaskFlow.DataAccess.Repositories;
using TaskFlow.Models;

namespace TaskFlow.Business.Services
{

    public class UesrServices
    {
        private readonly UserDAL _userDAL;

        public UesrServices(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }
    

        public async Task<List<User>> GetAllUsersAsync(bool ? IsActive)
        {

            var users = await _userDAL.GetAllUsersAsync(IsActive);

            return users;


        }

        public async Task<User?> GetUserByIDAsync(int userID)
        {

           return await _userDAL.GetUserByIDAsync(userID);
        }
    }
}