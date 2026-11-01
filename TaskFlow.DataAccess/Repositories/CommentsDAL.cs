using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repositories
{

    public class CommentsDAL
    {

        private readonly TaskFlowDbContext _context;

        public CommentsDAL(TaskFlowDbContext context)
        {
            _context = context;
        }


        public async Task<List<Comment>> GetAllCommentsAsync()
        {

            List<Comment> Comments;

            Comments = await _context.Comments.ToListAsync();

            return Comments;
        }


        public async Task<Comment?> GetCommentByIdAsync(int CommentID)
        {

            Comment? comment;

            comment = await _context.Comments.FindAsync(CommentID);

            return comment;
        }

    }

}