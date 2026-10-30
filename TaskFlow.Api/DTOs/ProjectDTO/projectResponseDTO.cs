namespace TaskFlow.Api.DTOs.ProjectDTO
{
	public class ProjectResponseDTO
	{

		public int ProjectID { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; } 

		public int OwnerUserID { get; set; }

		public DateTime CreatedAt { get; set; }

		public bool IsArchived {  get; set; }
	}
}