using BaseProject.Application.Common;
using BaseProject.Domain.Entities;

namespace BaseProject.Application.Interfaces.Repositories
{
    public interface IUserRepositoriesAsync : IBaseRepositoryAsync<User>
    {
        Task<User> FindByEmailAsync(string email);
        //Task<User> UpdateUserAysnc(User user);

    }
}
