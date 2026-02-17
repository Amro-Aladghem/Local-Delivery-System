using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ReffreshTokenBadRequest :BadRequestException
    {
        public ReffreshTokenBadRequest(string message) : base(message) { }
    }
}
