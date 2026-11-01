using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.CommentDTO;
using TaskFlow.Models;
using TaskFlow.Business.Services;



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
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        
        
        
        }


        [HttpGet("{commentId:int}")]
        [ProducesResponseType(typeof(CommentResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CommentResponseDTO>> GetCommentByIdAsync(int commentId)
        {

            try
            {

                if (commentId <= 0)
                {

                    return BadRequest("Invalid Input try to enter a valid positive integer graeter than ZERO");

                }

                Comment? comment = await _commentServices.GetCommentByIdAsync(commentId);

                if(comment == null)
                {
                    return NotFound($"The Comment with Id {commentId} Not Found");
                }


                return Ok(MapToCommentResponseDTO(comment));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }



    }



}