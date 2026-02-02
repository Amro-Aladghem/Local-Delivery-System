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
    public class DeliveryOrderStatusConfig : IEntityTypeConfiguration<DeliveryOrderStatus>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrderStatus> builder)
        {
                builder.HasData(
                new DeliveryOrderStatus
                {
                    Id = 1,
                    Name = "PendingPickup",
                    NameAr = "بانتظار يوم التسليم",
                    Description = "الطلب تم استلامه من العميل ويجب استلامه من السائق"
                },
                new DeliveryOrderStatus
                {
                    Id = 2,
                    Name = "OnRoute",
                    NameAr = "في الطريق",
                    Description = "الطلب مع السائق في الطريق إلى العميل"
                },
                new DeliveryOrderStatus
                {
                    Id = 3,
                    Name = "Delivered",
                    NameAr = "تم التسليم",
                    Description = "الطلب تم تسليمه للعميل بنجاح"
                },
                new DeliveryOrderStatus
                {
                    Id = 4,
                    Name = "Canceled",
                    NameAr = "ملغي",
                    Description = "الطلب تم إلغاؤه قبل التسليم"
                },
                new DeliveryOrderStatus
                {
                    Id = 5,
                    Name = "Deferred",
                    NameAr = "مؤجل",
                    Description = "الطلب تم تأجيله من قبل شركة التوصيل"
                },
                new DeliveryOrderStatus
                {
                    Id = 6,
                    Name = "DeferredByClient",
                    NameAr = "مؤجل من العميل",
                    Description = "الطلب تم تأجيله من قبل العميل"
                }
                );

        }
    }
}
