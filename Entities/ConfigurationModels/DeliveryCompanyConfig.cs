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
    public class DeliveryCompanyConfig : IEntityTypeConfiguration<DeliveryCompany>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompany> builder)
        {
            builder.Property(P => P.DeliveryFeesCalculationByType).HasConversion(
                P => P.ToString(),
                P => (DeliveryFeesCalculationByType)Enum.Parse(typeof(DeliveryFeesCalculationByType), P));

            builder.Property(P => P.DateOfRegister).HasDefaultValueSql("GETDATE()");
        }
    }
}
