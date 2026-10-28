namespace TaskFlow.Models
{

    public class User
    {
        public int UserId {get ; set;}

        public string FullName {get; set;} = string.Empty;

        public string Email {get; set;} = string.Empty;

        public string PasswordHash {get; set;} = string.Empty;

        public bool IsActive {get ; set;}

        public DateTime CreatedAt {get; set;}

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();

        public ICollection<ProjectTask> CreatedTasks { get; set; } = new List<ProjectTask>();

        public ICollection<ProjectTask> AssignedTasks { get; set; } = new List<ProjectTask>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
    
}