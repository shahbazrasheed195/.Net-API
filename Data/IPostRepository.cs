using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IPostRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);
        Task<User> GetUser(int id);
        //Task<IEnumerable<User>> GetUsers();

        Task<Post> AddPost(Post post);
    }
}