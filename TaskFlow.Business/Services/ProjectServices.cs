using TaskFlow.DataAccess.Repositories;
using TaskFlow.Models;

namespace TaskFlow.Business.Services
{
    public class ProjectServices {


        private readonly ProjectDAL _projectDAL;

        public ProjectServices(ProjectDAL projectDAL)
        {

            _projectDAL = projectDAL;
            
        }


        public async Task<List<Project>> GetAllProjectsAsync()
        {

            var projects = await _projectDAL.GetAllProjectsAsync();

            return projects;

        }

        public async Task<Project?> GetProjectByIdAsync(int ProjectId)
        {

            var project = await _projectDAL.GetProjectByIdAsync(ProjectId);

            return project;
        }

    }

}