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
    public class DeliveryCompanyDistancePriceConfig : IEntityTypeConfiguration<DeliveryCompanyDistancePrice>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompanyDistancePrice> builder)
        {
            builder.Property(P => P.AdditionalFees).HasDefaultValue(0m);
            builder.Property(P=>P.MinDistanceKm).HasDefaultValue(0m);
        }
    }
}
