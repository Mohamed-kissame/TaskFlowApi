namespace TaskFlow.Models
{
    
    public class Comment
    {
        public int CommentID { get; set; }

        public int TaskID {get ; set;}

        public int UserID {get ; set ;}

        public string Content {get ; set ;} = string.Empty;

        public DateTime CreatedAt {get ; set ; }

        public ProjectTask Task { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}