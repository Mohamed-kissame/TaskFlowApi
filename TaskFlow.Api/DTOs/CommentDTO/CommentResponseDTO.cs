namespace TaskFlow.Api.DTOs.CommentDTO
{

    public class CommentResponseDTO
    {

        public int CommentID { get; set; }

        public int TaskID { get; set; }

        public int UserID { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}