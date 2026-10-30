
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.ProjectDTO;
using TaskFlow.Business.Services;
using TaskFlow.Models;

namespace TaskFlow.Api.Controllers
{


    [Route("api/Projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {


        private readonly ProjectServices _projectServices;

        public ProjectsController(ProjectServices projectServices)
        {

            _projectServices = projectServices;

        }


        private static ProjectResponseDTO MapToProjectResponseDTO(Project project)
        {
            return new ProjectResponseDTO
            {

                ProjectID = project.ProjectID,
                Name = project.Name,
                Description = project.Description ?? "",
                OwnerUserID = project.OwnerUserID,
                CreatedAt = project.CreatedAt,
                IsArchived = project.IsArchived
            };
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ProjectResponseDTO>>> GetAllProjectAsync()
        {

            try
            {

                List<Project> projects = await _projectServices.GetAllProjectsAsync();

                var response = projects.Select(MapToProjectResponseDTO).ToList();

                return Ok(response);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }


        [HttpGet("{projectid:int}")]
        [ProducesResponseType(typeof(ProjectResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProjectResponseDTO>> GetProjectByIdAsync(int projectid)
        {
            try
            {
                if (projectid <= 0)
                {
                    return BadRequest("Enter a valid projectID it should Be greater than Zero");
                }

                Project? project = await _projectServices.GetProjectByIdAsync(projectid);

                if (project == null)
                {

                    return NotFound($"The project with Id {projectid} Not Found");
                }


                return Ok(MapToProjectResponseDTO(project));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }



    }
}