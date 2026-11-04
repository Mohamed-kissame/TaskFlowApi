using TaskFlow.DataAccess.Repositories;

namespace TaskFlow.Business.Services
{

    public class UserRoleServices
    {
        private readonly UserRoleDAL _userroleDAL;

        public UserRoleServices(UserRoleDAL userroleDAL)
        {
            _userroleDAL = userroleDAL;
        }

    }

}