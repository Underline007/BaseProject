using BaseProject.Application.Interfaces.Repositories;
using BaseProject.Domain.Entities;
using BaseProject.Infrastructure.Common.AssetManagement.Infrastructure.Common;
using BaseProject.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Repositories
{
    public class UserRepository : BaseRepositoryAsync<User>, IUserRepositoriesAsync
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _dbContext.Users
           .Where(u => u.Email.ToLower() == email.ToLower() && !u.IsDeleted)
           .FirstOrDefaultAsync();

            if (user != null && user.Email.Equals(email, StringComparison.Ordinal))
            {
                return user;
            }

            return null;
        }

        
    }
}
