using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;
        public CommentRepository(DataContext context)
        {
            this._context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Post> GetPost(int id, int userId)
        {
            var post = await _context.Posts.Where(x => x.UserId == userId).FirstOrDefaultAsync(y => y.Id == id);
            return post;

        }

        public async Task<Comment> GetComment(int commentId, int id)
        {
            var comment = await _context.Comments.Where(x => x.PostId == id).FirstOrDefaultAsync(y => y.Id == commentId);
            return comment;
        }

        public void UpdateComment(Comment comment)
        {
            var e = _context.Comments.Where(x => x.PostId == comment.PostId).First(y => y.Id == comment.Id);

            _context.Entry(e).CurrentValues.SetValues(comment);
        }
    }
}