namespace TaskFlow.DataAccess.Repositories
{


    public class UserRoleDAL
    {
        private readonly TaskFlowDbContext _context;

        public UserRoleDAL(TaskFlowDbContext context)
        {
         _context = context;   
        }


    }

}