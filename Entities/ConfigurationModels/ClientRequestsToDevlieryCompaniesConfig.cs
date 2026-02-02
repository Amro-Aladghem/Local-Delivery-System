using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ConfigurationModels
{
    public class ClientRequestsToDevlieryCompaniesConfig : IEntityTypeConfiguration<ClientRequestsToDevlieryCompanies>
    {
        public void Configure(EntityTypeBuilder<ClientRequestsToDevlieryCompanies> builder)
        {
            builder.Property(P => P.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(P => P.HasAcceptedYet).HasDefaultValue(false);
        }
    }
}
