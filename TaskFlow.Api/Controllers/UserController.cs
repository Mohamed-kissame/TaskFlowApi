using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.UserDTO;
using TaskFlow.Business.Services;
using TaskFlow.Models;

namespace TaskFlow.Api.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserBLL _userBLL;

        public UserController(UserBLL userBLL)
        {
            _userBLL = userBLL;
        }


        private static UserResponseDto MapToUserResponseDTO(User user)
        {

            return new UserResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                IsActive = user.IsActive,
                CreatedAT = user.CreatedAt
                

            };


        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponseDto>) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsersAsync([FromQuery] bool? isActive)
        {

            try
            {

                List<User> users = await _userBLL.GetAllUsersAsync(isActive);

                var response = users.Select(MapToUserResponseDTO).ToList();

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }


        [HttpGet("{userId:int}")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<UserResponseDto>> GetUserByIdAsync(int userId)
        {

            try
            {
                if (userId <= 0)
                {
                    return BadRequest("Invalid User ID , User Id must be a positive integer");
                }

                User? user = await _userBLL.GetUserByIDAsync(userId);

                if(user == null)
                {
                    return NotFound($"User with ID {userId} not Found ");
                }

                return Ok(MapToUserResponseDTO(user));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}