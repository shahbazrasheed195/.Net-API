using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { set; get; }

        public DbSet<Post> Posts { set; get; }
        public DbSet<Photo> Photos { set; get; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reply> Replies { get; set; }
    }
}