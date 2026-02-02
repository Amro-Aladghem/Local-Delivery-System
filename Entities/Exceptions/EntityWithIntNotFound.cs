using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EntityWithIntNotFound :NotFoundException
    {
        public EntityWithIntNotFound(int Id, string EntityName)
            : base($"The Entity With Type ${EntityName} With Id:${Id} Not Found") { }
    }
}
