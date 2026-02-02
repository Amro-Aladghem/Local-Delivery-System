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
    public class ClientDeliveryOrderStatusConfig : IEntityTypeConfiguration<ClientDeliveryOrderStatus>
    {
        public void Configure(EntityTypeBuilder<ClientDeliveryOrderStatus> builder)
        {
            builder.HasData(new ClientDeliveryOrderStatus[]
            {
                new ClientDeliveryOrderStatus
                {
                    Id= 1,
                    Name="Pending",
                    NameAr="في الانتظار",
                    Description="The Order is waiting to accepted delivery from the company"
                },
                new ClientDeliveryOrderStatus
                {
                    Id= 2,
                    Name="Accepted",
                    NameAr="موافقة",
                    Description="The Delivery Company Accepted Your Delivery Request For This Order"
                },
                new ClientDeliveryOrderStatus
                {
                    Id= 3,
                    Name="Rejected",
                    NameAr="مرفوضة",
                    Description="The Delivery Company Rejected Your Delivery Request For This Order"
                }
            });

        }
    }
}
