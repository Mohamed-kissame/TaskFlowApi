namespace TaskFlow.Models
{
    public class ProjectTask
    {
        public int TaskID { get; set; }

        public int ProjectID {get ; set;}

        public string Title {get ; set ;} = string.Empty;

        public string? Description {get ; set;}

        public string Status {get ; set ; } = string.Empty;

        public string Priority {get ; set;} = string.Empty;

        public int CreatedByUserID {get ; set ;}

        public int? AssignedToUserID {get ; set ;}

        public DateTime CreatedAt {get ; set ;}

        public DateTime? UpdatedAt {get ; set;}

        public DateTime? DueDate {get ; set ;}

        public Project Project { get; set; } = null!;

        public User CreatedByUser { get; set; } = null!;

        public User? AssignedToUser { get; set; } 

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}