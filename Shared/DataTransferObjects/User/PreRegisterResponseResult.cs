using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.User
{
    public record PreRegisterResponseResult
    {
        public UserPreRegisterResponse User { get;set; }
        public TokenDto Token { get;set; }
    }
}
