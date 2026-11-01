using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.CommentDTO;
using TaskFlow.Models;
using TaskFlow.Business.Services;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using System.Collections;

namespace TaskFlow.Api.Controllers
{
    [Route("api/Comments")]
    [ApiController]

    public class CommentsController : ControllerBase {


        private readonly CommentServices _commentServices;

        public CommentsController(CommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        private static CommentResponseDTO MapToCommentResponseDTO(Comment comment)
        {

            return new CommentResponseDTO
            {

                CommentID = comment.CommentID,
                TaskID = comment.TaskID,
                UserID = comment.UserID,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            };
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CommentResponseDTO>) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<CommentResponseDTO>>> GetAllCommentsAsync(){


            try
            {

                List<Comment> comments;

                comments = await _commentServices.GetAllCommentsAsync();

                var response = comments.Select(MapToCommentResponseDTO).ToList();

                return Ok(response);

            }
            catch (Exception)
            {

                throw;
            }
        
        
        
        }





    }



}