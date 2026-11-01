namespace TaskFlow.Api.DTOs.ProjectTaskDTO
{
    public class ProjectTaskResponseDTO
    {

        public int TaskID { get; set; }

        public int ProjectID { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Priority {  get; set; } = string.Empty;

        public int CreatedByUserID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DueDate { get; set; }



    }
}