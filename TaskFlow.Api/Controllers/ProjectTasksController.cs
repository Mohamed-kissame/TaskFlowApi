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
    }

}