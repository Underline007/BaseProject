using BaseProject.Application.Interfaces.Repositories;
using BaseProject.Application.Interfaces.Services;
using BaseProject.Application.Models.DTOs.Accounts.Requests;
using BaseProject.Application.Models.DTOs.Accounts.Responses;
using BaseProject.Application.Wrapers;
using BaseProject.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BaseProject.Application.Services
{
    public class AccountService : IAccountServices
    {
        private readonly IUserRepositoriesAsync _userRepositoriesAsync;
        private readonly ITokenService _tokenService;
        private readonly IValidator<ChangePasswordRequest> _changePasswordValidator;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public AccountService(ITokenService tokenService, IValidator<ChangePasswordRequest> changePasswordValidator, IUserRepositoriesAsync userRepositoriesAsync)
        {
            _changePasswordValidator = changePasswordValidator;
            _tokenService = tokenService;
            _userRepositoriesAsync = userRepositoriesAsync;
        }

        public Task<Response<string>> ChangePasswordAsync(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<AuthenticationResponse>> LoginAsync(AuthenticationRequest request)
        {
            var user = await _userRepositoriesAsync.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new Response<AuthenticationResponse> { Succeeded = false, Message = "Invalid Email or Password" };
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (verificationResult != PasswordVerificationResult.Success)
            {
                return new Response<AuthenticationResponse> { Succeeded = false, Message = "Invalid Email or Password" };
            }
            //var role = await _userRepositoriesAsync.GetRoleAsync(user.Id);
            //var token = _tokenService.GenerateJwtToken(user, role);
            //var response = new AuthenticationResponse
            //{
            //    Email = user.Email,
            //    Role = role.ToString(),
            //    Token = token
            //};

            //return new Response<AuthenticationResponse>
            //{
            //    Succeeded = true,
            //    Data = response
            //};
            return null;
        }
    }
}
