using BaseProject.Application.Models.DTOs.Accounts.Requests;
using BaseProject.Application.Models.DTOs.Accounts.Responses;
using BaseProject.Application.Wrapers;

namespace BaseProject.Application.Interfaces.Services
{
    public interface IAccountServices
    {
        Task<Response<AuthenticationResponse>> LoginAsync(AuthenticationRequest request);

        Task<Response<string>> ChangePasswordAsync(ChangePasswordRequest request);
    }
}
