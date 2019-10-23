using System;
using System.Text;
using System.Threading.Tasks;
using DatingWebsiteBackend.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> Login(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if(user == null)
            return null;

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

            return user;
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

        public async Task<bool> UserExsist(string username)
        {
            if(await context.Users.AnyAsync(x => x.UserName == username))
                return true;

            return false;
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
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
           using(var hmac =  new System.Security.Cryptography.HMACSHA512(passwordSalt)) 
            {
                var  computedHash =  hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    return false;
                }
                return true;
            }
        }

        #endregion
    }
}