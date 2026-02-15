using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.User
{
    public record UserForAuthenticationResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string? ImageUrl { get; set; }
        public int CountryId { get; set;  }
        public string SystemRole { get; set; }

        UserCompanyInfo? UserCompanyInfo { get; set; }
    }

    public   record UserCompanyInfo
    {
        public Guid CompanyId { get;set;  }
        public string CompanyName { get; set; }
        public string CompanyImageUrl { get; set; }
        public string CompanyRole { get; set; }
    }
}
