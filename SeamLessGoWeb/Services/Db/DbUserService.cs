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
                    .FirstOrDefaultAsync(x => x.UserName == username &&  x.IsActive);
                if (user == null)
                    return null;
            //    Validate password + salt
            bool isPasswordValid = VerifyPassword(password, user.Password);
            if (!isPasswordValid)
                return null;

                return new UserSession
                {
                    UserID = user.UserID,
                    DisplayName = user.DisplayName,
                    UserName = user.UserName,
                    UserRoleID = user.UserRoleID,
                };
           
        
            }

        public static string HashPassword(string password)
        {
            // Generate a 16-byte random salt
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            // Derive a 32-byte key with PBKDF2
            byte[] key = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: 100_000,
                HashAlgorithmName.SHA256,
                outputLength: 32);

            // Store salt + key as base64
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(key);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] expectedKey = Convert.FromBase64String(parts[1]);

            byte[] actualKey = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: 100_000,
                HashAlgorithmName.SHA256,
                outputLength: 32);

            return CryptographicOperations.FixedTimeEquals(actualKey, expectedKey);
        }
    }
}
