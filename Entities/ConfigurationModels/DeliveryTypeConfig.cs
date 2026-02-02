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
    public class DeliveryTypeConfig : IEntityTypeConfiguration<DeliveryType>
    {
        public void Configure(EntityTypeBuilder<DeliveryType> builder)
        {
            builder.HasData(new DeliveryType[]
            {
                new DeliveryType
                {
                    Id=1,
                    Name="Regular Delivery",
                    NameAr="التوصيل الطبيعي",
                    Description="The Regular Delivery"
                },
                new DeliveryType
                {
                    Id=2,
                    Name="Fast Delivery",
                    NameAr="التوصيل السريع",
                    Description="The Fast Delivery,In The Same Day Or Shorter Time Than Regular"
                }
            });
        }
    }
}
