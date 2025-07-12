using FluentValidation;
using ManagerApi.DTOs;

namespace ManagerApi.Validators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName is required")
                .MinimumLength(2).WithMessage("FullName must be at least 2 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Date of birth cannot be in the future");
        }
    }
}
