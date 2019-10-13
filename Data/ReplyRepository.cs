using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly DataContext _context;
        public ReplyRepository(DataContext context)
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

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> AddReply(Reply reply)
        {
            var replyFromDb = await _context.AddAsync(reply);
            return await SaveAll();
        }


    }

}