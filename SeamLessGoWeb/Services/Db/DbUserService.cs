using Microsoft.EntityFrameworkCore;
using SeamLessGoWeb.Data;
using SeamLessGoWeb.Models;
using SeamLessGoWeb.Data.Entities;
using System.Security.Cryptography;
using System.Text;
using SeamLessGoWeb.Services.Interfaces;

namespace SeamLessGoWeb.Services.DbUserService
{
    public class DbUserService : IUserService
    {
        private readonly AppDbContext _ctx;
        public DbUserService(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<UserSession?> LoginAsync(string username, string password)
        {
            
                var user = await _ctx.Users
                    .FirstOrDefaultAsync(x => x.UserName == username && x.Password== password && x.IsActive);

                if (user == null)
                    return null;

                // Validate password + salt
               // var hashed = HashPassword(password, user.PasswordSalt);

            //if (hashed != user.Password)
            //        return null;

                return new UserSession
                {
                    UserID = user.UserID,
                    DisplayName = user.DisplayName,
                    UserName = user.UserName,
                    UserRoleID = user.UserRoleID,
                    ClientID = user.ClientID
                };
           
        
            }

        private string HashPassword(string password, string salt)
        {
            using var sha = SHA256.Create();
            var combined = Encoding.UTF8.GetBytes(password + salt);
            return Convert.ToBase64String(sha.ComputeHash(combined));
        }
    }
}
