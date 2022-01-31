using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebAPICore.DbModels;

namespace WebAPICore.Services
{
    public class UserDataService
    {

        private readonly ILogger _logger;
        private APICoreDBContext _dbContext;
        public UserDataService(
            APICoreDBContext db,
            ILogger<UserDataService> logger)
        {
            _dbContext = db;
            _logger = logger;
        }

        public bool StoreUserTokenExpires(string userId, string refreshToken, DateTime tokenExpiresAt)
        {
            var token = new AspNetUserTokens
            {
                UserId = userId,
                LoginProvider = "WebAPICore",
                Name = refreshToken,
                Value = tokenExpiresAt.ToString()
            };

            _dbContext.AspNetUserTokens.Add(token);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateUserTokenExpiresAt(string userId, string refreshToken, DateTime tokenExpiresAt)
        {
            var token = await _dbContext.AspNetUserTokens
                .FirstOrDefaultAsync(ut => ut.UserId.Equals(userId)
                    && ut.Name.Equals(refreshToken));

            token.Value = tokenExpiresAt.ToString();

            _dbContext.AspNetUserTokens.Update(token);
            _dbContext.SaveChanges();

            return true;
        }
        public async Task StoreUserTokenExpiresAtAsync(string userId, string refreshToken, DateTime tokenExpiresAt)
        {
            var token = new AspNetUserTokens
            {
                UserId = userId,
                LoginProvider = "WebAPICore",
                Name = refreshToken,
                Value = tokenExpiresAt.ToString()
            };

            await _dbContext.AspNetUserTokens.AddAsync(token);
            _dbContext.SaveChanges();

        }

        public async Task UpdateUserTokenExpiresAtAsync(string userId, string refreshToken, DateTime tokenExpiresAt)
        {
            var token = await _dbContext.AspNetUserTokens
                .FirstOrDefaultAsync(ut => ut.UserId.Equals(userId)
                    && ut.Name.Equals(refreshToken));

            token.Value = tokenExpiresAt.ToString();

            _dbContext.AspNetUserTokens.Update(token);
            _dbContext.SaveChanges();
        }

        public async Task<DateTime> GetUserTokenExpiresAtAsync(string userId, string refreshToken)
        {
            var token = await _dbContext.AspNetUserTokens
                .FirstOrDefaultAsync(ut => ut.UserId.Equals(userId)
                    && ut.Name.Equals(refreshToken));

            var result = DateTime.Parse(token.Value);

            return result;
        }

        public async Task<bool> RemoveTokenAsync(string userId, string refreshToken)
        {
            
            var token = await _dbContext.AspNetUserTokens
            .FirstOrDefaultAsync(ut => ut.UserId.Equals(userId)
                && ut.Name.Equals(refreshToken));

            _dbContext.AspNetUserTokens.Remove(token);
            _dbContext.SaveChanges();

            return true;
            
        }
    }
}
