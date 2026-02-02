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
    public class DeliveryCompanyUserConfig : IEntityTypeConfiguration<DeliveryCompanyUser>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompanyUser> builder)
        {
            builder.Property(P => P.DeliveryCompanyUserRole).HasConversion(
                P => P.ToString(),
                P=>(DeliveryCompanyUserRole)Enum.Parse(typeof(DeliveryCompanyUserRole), P));

            builder.Property(P => P.LastLoggedInDateTime).HasDefaultValueSql("GETDATE()");
        }
    }
}
