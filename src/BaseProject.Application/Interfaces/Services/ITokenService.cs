using BaseProject.Domain.Entities;

namespace BaseProject.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user, Role role);

        int? ValidateToken(string token);
    }
}
