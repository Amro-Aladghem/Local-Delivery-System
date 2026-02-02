using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ConfigurationModels
{
    public class DeliveryCompanyDeliveryTypeConfig : IEntityTypeConfiguration<DeliveryCompanyDeliveryType>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompanyDeliveryType> builder)
        {
            builder.HasKey(D => new { D.DeliveryTypeId, D.DeliveryCompanyId });
        }
    }
}
