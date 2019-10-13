using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            this._context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }


        public async Task<bool> DeletePhoto(Photo photo)
        {
            _context.Remove(photo);
            return await SaveAll();
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);

            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(x => x.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(x => x.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // public async Task<bool> UpdatePhoto(int id, Photo photo)
        // {
        //     var responseFromDb = _context.Photos.Update(photo);
        //     await SaveAll();
        //     return await SaveAll(); ;
        // }


    }
}