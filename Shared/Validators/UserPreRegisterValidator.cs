using FluentValidation;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Validators
{
    public class UserPreRegisterValidator:AbstractValidator<UserPreRegisterRequest>
    {
        public UserPreRegisterValidator()
        {
            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("You must send a Password")
               .MinimumLength(8).WithMessage("The Password length must be more or equale to 8")
               .MaximumLength(80).WithMessage("The Max Password length must be less than 80");

            RuleFor(P => P)
                .Must(p => !string.IsNullOrEmpty(p.Email) || !string.IsNullOrEmpty(p.PhoneNumber))
                .WithMessage("You must enter your email or phone");

            When(p => !string.IsNullOrEmpty(p.Email), () =>
            {
                RuleFor(p => p.Email).EmailAddress().WithMessage("The Email is invalid");
            });
        }
    }
}
