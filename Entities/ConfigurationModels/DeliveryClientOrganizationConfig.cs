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
    public class DeliveryClientOrganizationConfig : IEntityTypeConfiguration<DeliveryClientOrganization>
    {
        public void Configure(EntityTypeBuilder<DeliveryClientOrganization> builder)
        {
            builder.Property(P => P.DeliveryClientOrgType)
                   .HasConversion(
                        P => P.ToString(),
                        P => (DeliveryClientOrgType)Enum.Parse(typeof(DeliveryClientOrgType), P)
                   );

            builder.Property(P => P.SerialNumber).ValueGeneratedOnAdd();
            builder.HasIndex(P=>P.SerialNumber).IsUnique();
            builder.Property(P => P.DateOfRegister).HasDefaultValueSql("GETDATE()");
        }
    }
}
