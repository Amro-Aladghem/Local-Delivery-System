using FluentValidation;
using Shared.DataTransferObjects.DeliveryClientOrganization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Validators
{
    public class AddDeliveryClientOrganizationValidator : AbstractValidator<AddDeliveryClientOrganizationRequest>
    {
        public AddDeliveryClientOrganizationValidator()
        {
            RuleFor(p => p.Address).NotEmpty().MaximumLength(500).WithMessage("The Address Max length is 500 char!");
            RuleFor(p => p.Description).MaximumLength(500).WithMessage("The Address Max length is 500 char!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p => p.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(p => p.CityId).NotEmpty().WithMessage("City is required");
            RuleFor(p => p.CountryId).NotEmpty().WithMessage("Country is required");
            RuleFor(p => p.AvgDailyOrders).NotEmpty().WithMessage("AvgDailyOrders is required");
            RuleFor(p => p.AvgMonthlyOrders).NotEmpty().WithMessage("AvgMonthlyOrders is required");

            RuleFor(p => p.DeliveryClientOrgType).IsInEnum().WithMessage("DeliveryClientOrgType type is not valid");
        }
    }
}
