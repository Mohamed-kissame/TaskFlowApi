using TaskFlow.DataAccess.Repositories;
using TaskFlow.Models;

namespace TaskFlow.Business.Services
{

    public class CommentServices
    {

        private readonly CommentsDAL _commentDAL;

        public CommentServices(CommentsDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }


        public async Task<List<Comment>> GetAllCommentsAsync()
        {

            var comments = await _commentDAL.GetAllCommentsAsync();

            return comments;
        }

        public async Task<Comment?> GetCommentByIdAsync(int commentid)
        {

            Comment? comment;

            comment = await _commentDAL.GetCommentByIdAsync(commentid);

            return comment;
        }



    }

}