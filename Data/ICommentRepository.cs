using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface ICommentRepository
    {
        void Add<T>(T entity) where T : class;
        // Task<User> GetUser(int id);
        Task<bool> SaveAll();
        Task<Post> GetPost(int id, int userId);
        Task<Comment> GetComment(int commentId, int id);

        void UpdateComment(Comment comment);
    }
}