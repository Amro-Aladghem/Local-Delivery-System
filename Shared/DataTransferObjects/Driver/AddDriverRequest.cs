using Shared.DataTransferObjects.User;

namespace Shared.DataTransferObjects.Driver
{
    public record AddDriverRequest : UserForRegisterationRequest
    {
        public string Password { get; set; }
        public string DrivingLicenseImageUrl { get; set; }
        public string VechicalNumber { get; set; }
        public int VechicalTypeId { get; set; }
    }
}
