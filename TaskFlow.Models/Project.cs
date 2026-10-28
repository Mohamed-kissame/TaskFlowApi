

namespace TaskFlow.Models
{
    
    public class Project
    {
        
        public int ProjectID {get ; set;}

        public string Name {get ; set;} = string.Empty;

        public string? Description {get ; set;} 

        public int OwnerUserID {get ; set;}

        public User? Owner { get; set; }

        public DateTime CreatedAt {get ; set;}

        public bool IsArchived {get ; set;}

        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}