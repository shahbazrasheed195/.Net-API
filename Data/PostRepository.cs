using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            this._context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Post> GetPost(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;

        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(x => x.Posts).LastOrDefaultAsync(x => x.Id == id);
            return user;
        }
        // public async Task<IEnumerable<User>> GetUsers()
        // {
        //     var users = await _context.Users.Include(x => x.Posts).ToListAsync();
        //     return users;
        // }

        public async Task<Post> AddPost(Post post)
        {
            var response = await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

    }
}