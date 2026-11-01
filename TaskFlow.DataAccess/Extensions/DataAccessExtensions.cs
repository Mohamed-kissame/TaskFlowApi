using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.DataAccess.Repositories;

namespace TaskFlow.DataAccess.Extensions
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccess(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<TaskFlowDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<UserDAL>();
            services.AddScoped<ProjectDAL>();

            services.AddScoped<RoleDAL>();

            services.AddScoped<CommentsDAL>();

            services.AddScoped<ProjectTaskDAL>();

            return services;
        }
    }
}