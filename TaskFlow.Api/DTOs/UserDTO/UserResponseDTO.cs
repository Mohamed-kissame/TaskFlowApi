using System.ComponentModel.DataAnnotations;

namespace  TaskFlow.Api.DTOs.UserDTO
{
    public class UserResponseDto
    {
       public int UserId { get; set; }

        [Required]
       public string FullName { get; set; } = string.Empty;

        [EmailAddress]
        
       public  string Email { get; set; } = string.Empty;

       public  bool IsActive { get; set; }

       public DateTime CreatedAT {  get; set; }
        
    }
}