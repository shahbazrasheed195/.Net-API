using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;

        // void Update<T>(T entity) where T : class;
        Task<bool> DeletePhoto(Photo photo);

        Task<bool> SaveAll();

        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);

        Task<Photo> GetPhoto(int id);

        //  Task<bool> UpdatePhoto(int id, Photo photo);

    }
}