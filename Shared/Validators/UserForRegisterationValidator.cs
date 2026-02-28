using FluentValidation;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared.Validators
{
    public class UserForRegisterationValidator : AbstractValidator<UserForRegisterationRequest>
    {
        public UserForRegisterationValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("The FirstName is Empty");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("The LastName is Empty");
            RuleFor(p => p)
                .Must(p => p.CountryId > 0)
                .WithMessage("The Country Id is not valid");

            RuleFor(P => P)
                .Must(p => !string.IsNullOrEmpty(p.Email) || !string.IsNullOrEmpty(p.PhoneNumber))
                .WithMessage("You must send your email or phone");

            When(p => !string.IsNullOrEmpty(p.PhoneNumber), () =>
            {
                RuleFor(p => p.PhoneNumber)
                 .NotEmpty().WithMessage("The Phone is Empty")
                 .Must(ValidatePhoneNumber).WithMessage("The Phone is not valid");
            });

            When(p => !string.IsNullOrEmpty(p.Email), () =>
            {
                RuleFor(p => p.Email).EmailAddress().WithMessage("The Email is invalid");
            });
        }


        private bool ValidatePhoneNumber(string phoneNumber)
        {
            string regix = @"^07[789]\d{7}$";
            return Regex.IsMatch(phoneNumber, regix);
        }
    }
}
