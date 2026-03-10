using FluentValidation;
using Shared.DataTransferObjects.Driver;

namespace Shared.Validators
{
    public class AddDriverValidator : AbstractValidator<AddDriverRequest>
    {
        public AddDriverValidator()
        {
            Include(new UserForRegisterationValidator());

            RuleFor(P => P.Password).NotEmpty().WithMessage("The Password is required");
            RuleFor(P => P.DrivingLicenseImageUrl).NotEmpty().WithMessage("The Image is required");
            RuleFor(P => P.VechicalNumber).NotEmpty().WithMessage("The VechicalNumber is required");
            RuleFor(P => P.VechicalTypeId).NotEmpty().WithMessage("The VechicalType is required");
        }
    }
}
