using System.Collections;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.RoleDTO;
using TaskFlow.Business.Services;
using TaskFlow.Models;

namespace TaskFlow.Api.Controllers
{

    [Route("api/Roles")]
    [ApiController]

    public class RolesController : ControllerBase
    {


        private readonly RoleServices _roleServices;

        public RolesController(RoleServices roleServices)
        {
          _roleServices = roleServices;       
        }


        private static RoleResponseDTO MapToRoleResponseDTO(Role role)
        {

            return new RoleResponseDTO
            {

                RoleID = role.RoleID,
                RoleName = role.RoleName,
            };
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<RoleResponseDTO>>> GetAllRoleAsync()
        {

            try
            {

                List<Role> roles = await _roleServices.GetAllRoleAsync();

                var response = roles.Select(MapToRoleResponseDTO).ToList();

                return response;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }


        [HttpGet("{RoleID:int}")]
        [ProducesResponseType(typeof(RoleResponseDTO) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<RoleResponseDTO>> GetRoleByIdAsync(int RoleID) {


            try
            {

                if(RoleID <= 0)
                {
                    return BadRequest("the Role ID that u enter its invalid try an positive ID");
                }

                Role? role = await _roleServices.GetRoleByIdAsync(RoleID);

                if (role == null)
                {

                    return NotFound($"The role with Id {RoleID} Not Found");
                }


                return Ok(MapToRoleResponseDTO(role));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        
        }
    }

}