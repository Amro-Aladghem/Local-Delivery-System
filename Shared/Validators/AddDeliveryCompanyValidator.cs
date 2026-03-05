using FluentValidation;
using Shared.DataTransferObjects.DeliveryCompany;

namespace Shared.Validators
{
    public class AddDeliveryCompanyValidator : AbstractValidator<AddDeliveryCompanyRequest>
    {
        public AddDeliveryCompanyValidator()
        {
            RuleFor(p => p.Address).NotEmpty().MaximumLength(500).WithMessage("The Address Max length is 500 char!");
            RuleFor(p => p.description).MaximumLength(500).WithMessage("The Address Max length is 500 char!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p => p.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(p => p.CityId).NotEmpty().WithMessage("City is required");
            RuleFor(p => p.CountryId).NotEmpty().WithMessage("Country is required");
        }
    }
}
