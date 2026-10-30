using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repositories
{


	public class ProjectDAL
	{

		private readonly TaskFlowDbContext _context;

        public ProjectDAL(TaskFlowDbContext context)
        {

            _context = context;
                
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {

            List<Project> projects;
            
            projects = await _context.Projects.ToListAsync();

            return projects;
        }


        public async Task<Project?> GetProjectByIdAsync(int ProjectID)
        {
            Project? project;

            project = await _context.Projects.FindAsync(ProjectID);

            return project;


        }
    }

}