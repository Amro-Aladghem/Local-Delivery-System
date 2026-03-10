using FluentValidation;
using Shared.DataTransferObjects.DeliveryClientUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Validators
{
    public class AddDeliveryClientAdminValidator : AbstractValidator<AddDeliveryClientAdminRequest>
    {
        public AddDeliveryClientAdminValidator()
        {
            Include(new UserForRegisterationValidator());
            RuleFor(P => P.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
