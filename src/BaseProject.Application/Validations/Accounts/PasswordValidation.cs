using BaseProject.Application.Models.DTOs.Accounts.Requests;
using FluentValidation;

namespace BaseProject.Application.Validations.Accounts
{
    public class PasswordValidation : AbstractValidator<ChangePasswordRequest>
    {
        public PasswordValidation()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(50).WithMessage("Password must be at most 50 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.");
        }
    }
}
