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
    public class DeliveryOrderConfig : IEntityTypeConfiguration<DeliveryOrder>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrder> builder)
        {
            builder.Property(P => P.AcceptedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(P => P.AdditionalFees).HasDefaultValue(0m);
            builder.Property(P => P.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(P => P.OrderSerialNumber).ValueGeneratedOnAdd();
            builder.HasIndex(P=>P.OrderSerialNumber).IsUnique();

            builder.HasOne(P => P.DeliveryCompanyUser)
                   .WithMany(D => D.DeliveryOrders)
                   .HasForeignKey(P => P.AcceptedFromUserId)
                   .IsRequired(false);
        }
    }
}
