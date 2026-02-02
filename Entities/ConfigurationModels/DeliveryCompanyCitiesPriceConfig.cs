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
    public class DeliveryCompanyCitiesPriceConfig : IEntityTypeConfiguration<DeliveryCompanyCitiesPrice>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompanyCitiesPrice> builder)
        {
            builder.Property(P => P.AdditionalFees).HasDefaultValue(0m);
        }

    }
}
