using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.ProjectDTO;
using TaskFlow.Api.DTOs.ProjectTaskDTO;
using TaskFlow.Business.Services;
using TaskFlow.Models;

namespace TaskFlow.Api.Controllers
{

    [Route("api/ProjectTasks")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {

        private readonly ProjectTaskServices _projectTaskServices;

        public ProjectTasksController(ProjectTaskServices projectTaskServices)
        {
            _projectTaskServices = projectTaskServices;
        }


        private static ProjectTaskResponseDTO MapToProjectTaskDTO(ProjectTask projectTask)
        {

            return new ProjectTaskResponseDTO
            {

                TaskID = projectTask.TaskID,
                ProjectID = projectTask.ProjectID,
                Title = projectTask.Title,
                Description = projectTask.Description ?? "",
                Status = projectTask.Status,
                Priority = projectTask.Priority,
                CreatedByUserID = projectTask.CreatedByUserID,
                AssignedToUserID = projectTask.AssignedToUserID ?? null,
                CreatedAt = projectTask.CreatedAt,
                UpdatedAt = projectTask.UpdatedAt ?? null,
                DueDate = projectTask.DueDate ?? null


            };
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectTaskResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ProjectTaskResponseDTO>>> GetALLProjectTasksAsync()
        {

            try
            {

                List<ProjectTask> projectTasks = await _projectTaskServices.GetAllProjectTasksAsync();

                var response = projectTasks.Select(MapToProjectTaskDTO).ToList();

                return Ok(response);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later."); return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }

        }


        [HttpGet("{projectTaskId:int}")]
        [ProducesResponseType(typeof(ProjectTaskResponseDTO) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectTaskResponseDTO>> GetProjectTaskByIDAsync(int projectTaskId)
        {

            try
            {

                if(projectTaskId <= 0)
                {
                    return BadRequest("Invalid Input Enter a valid positive integer graeter than ZERO");
                }


                ProjectTask? projectTask = await _projectTaskServices.GetProjectTaskByIdAsync(projectTaskId);

                if(projectTask == null)
                {

                    return NotFound($"the Task with Id {projectTaskId} Not Founs");
                }


                return Ok(MapToProjectTaskDTO(projectTask));


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later."); return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }

        }

    }
}