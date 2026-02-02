using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ClientOrgWithCompanyNotFound :NotFoundException
    {
        public ClientOrgWithCompanyNotFound(Guid clientOrgId, Guid companyId)
            : base($"The Client Organization With Id: {clientOrgId} associated with Company Id: {companyId} was not found.") { }
    }
}
