using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class UserNotFound : NotFoundException
    {
        public UserNotFound(string authString) : base($"User with authString=${authString} not found") { }
    }
}
