using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repositories
{

    public class ProjectTaskDAL
    {

        private readonly TaskFlowDbContext _context;

        public ProjectTaskDAL(TaskFlowDbContext context)
        {
            _context = context;
        }


        public async Task<List<ProjectTask>> GetAllProjectTaskAsync()
        {

            List<ProjectTask> projectTasks;

            projectTasks = await _context.ProjectTasks.ToListAsync();

            return projectTasks;
        }

        public async Task<ProjectTask?> GetProjectByIdAsync(int projectId)
        {

            ProjectTask? projectTask;

            projectTask = await _context.ProjectTasks.FindAsync(projectId);


            return projectTask;
        }


    }
}