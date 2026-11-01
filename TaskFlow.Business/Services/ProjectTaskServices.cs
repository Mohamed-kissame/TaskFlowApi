using TaskFlow.DataAccess.Repositories;
using TaskFlow.Models;

namespace TaskFlow.Business.Services
{


    public class ProjectTaskServices
    {

        private readonly ProjectTaskDAL _projectTaskDAL;

        public ProjectTaskServices(ProjectTaskDAL projectDAL)
        {
            _projectTaskDAL = projectDAL;
        }


        public async Task<List<ProjectTask>> GetAllProjectTasksAsync()
        {

            List<ProjectTask> projectTasks;

            projectTasks = await _projectTaskDAL.GetAllProjectTaskAsync();

            return projectTasks;

        }

        public async Task<ProjectTask?> GetProjectTaskByIdAsync(int projectId)
        {

            ProjectTask? projectTask;

            projectTask = await _projectTaskDAL.GetProjectTaskByIdAsync(projectId);

            return projectTask;


        }



    }
}