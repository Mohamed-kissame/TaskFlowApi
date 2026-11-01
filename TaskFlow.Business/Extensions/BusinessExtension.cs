using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Business.Services;
using TaskFlow.DataAccess.Extensions;

namespace TaskFlow.Business.Extensions
{
    public static class BusinessExtensions
    {
        public static IServiceCollection AddBusinessLayer(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDataAccess(connectionString);

            services.AddScoped<UesrServices>();

            services.AddScoped<ProjectServices>();

            services.AddScoped<RoleServices>();

            services.AddScoped<CommentServices>();

            services.AddScoped<ProjectTaskServices>();

            return services;
        }
    }
}