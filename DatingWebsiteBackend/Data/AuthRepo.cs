using System;
using System.Text;
using System.Threading.Tasks;
using DatingWebsiteBackend.Models;

namespace DatingWebsiteBackend.Data
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DataContext context;

        #region method public
        public AuthRepo(DataContext context)
        {
            this.context = context;

        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHAshSalt(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public Task<bool> UserExsist(string username)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region method private 
        private void CreatePasswordHAshSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac =  new System.Security.Cryptography.HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion
    }
}