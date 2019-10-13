using System.Collections.Generic;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            this._context = context;
        }

        public void SeedUser()
        {
            const string Path = "Data/UserSeedData.json";
            var userData = System.IO.File.ReadAllText(Path);
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] PasswordHash, PasswordSalt;
                CreatePasswordHash("password", out PasswordHash, out PasswordSalt);
                user.PasswordHash = PasswordHash;
                user.PasswordSalt = PasswordSalt;
                user.UserName = user.UserName.ToLower();
                _context.Users.Add(user);

            }
            _context.SaveChanges();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


    }
}