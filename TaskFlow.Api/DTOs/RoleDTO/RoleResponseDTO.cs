using Microsoft.Identity.Client;

namespace TaskFlow.Api.DTOs.RoleDTO
{
    public class RoleResponseDTO
    {

        public int RoleID { get; set; }

        public string RoleName { get; set; } = string.Empty;
    }
}