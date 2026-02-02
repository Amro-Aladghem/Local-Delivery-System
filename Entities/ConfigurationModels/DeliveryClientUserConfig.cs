using Entities.Models;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ConfigurationModels
{
    public class DeliveryClientUserConfig : IEntityTypeConfiguration<DeliveryClientUser>
    {
        public void Configure(EntityTypeBuilder<DeliveryClientUser> builder)
        {
            builder.Property(P=>P.DeliveryClientOrgUserRole).HasConversion(
                P=>P.ToString(),
                P=>(DeliveryClientOrgUserRole)Enum.Parse(typeof(DeliveryClientOrgUserRole), P)
            );

            builder.Property(P => P.LastLoggedInDateTime).HasDefaultValueSql("GETDATE()");
        }
    }
}
