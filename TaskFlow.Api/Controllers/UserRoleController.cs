using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.UserRoleDTO;
using TaskFlow.Models;

namespace TaskFlow.Api.Controllers
{

    [Route("api/userRoles")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {


        private static UserRoleResponseDTO MapToUserRoleResponseDTO(UserRole userrole)
        {

            return new UserRoleResponseDTO
            {

                UserId = userrole.UserID,
                RoleId = userrole.RoleID
            };
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserRoleResponseDTO>), StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<UserRoleResponseDTO>>> GetAllUserRoleAsync()
        {

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}