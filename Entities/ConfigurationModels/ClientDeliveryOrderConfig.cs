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
    public class ClientDeliveryOrderConfig : IEntityTypeConfiguration<ClientDeliveryOrder>
    {
        public void Configure(EntityTypeBuilder<ClientDeliveryOrder> builder)
        {
            builder.Property(P => P.ClientDeliveryOrderStatusId).HasDefaultValue(1);
        }
    }
}
