using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TaskFlow.Api.DTOs.UserDTO;
using TaskFlow.Api.DTOs.UserRoleDTO;
using TaskFlow.Business.Services;
using TaskFlow.Models;

namespace TaskFlow.Api.Controllers
{

    [Route("api/userRoles")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {

        private readonly UserRoleServices _userroleServices;

        public UserRoleController(UserRoleServices userroleServices)
        {

            _userroleServices = userroleServices;
        }
        
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

                List<UserRole> userroles = await _userroleServices.GetAllUserRoleAsync();

                var response = userroles.Select(MapToUserRoleResponseDTO).ToList();

                return Ok(response);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }


        [HttpGet("{userid:int}/{roleid:int}")]
        [ProducesResponseType(typeof(UserRoleResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<UserRoleResponseDTO>> GetUserRoleByIdAsync(int userid, int roleid)
        {

            try
            {
                if (userid <= 0 || roleid <= 0)
                {
                    return BadRequest("Invalid User ID or roleid , User Id and Role id must be a positive integer");
                }

                UserRole? userrole = await _userroleServices.GetUserRoleByIdAsync(userid,roleid);

                if (userrole == null)
                {
                    return NotFound($"UserRole with ID {userid} , {roleid}  not Found ");
                }

                return Ok(MapToUserRoleResponseDTO(userrole));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }

    }
}