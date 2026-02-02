using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ConfigurationModels
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = "e1f3c9a4-7d5b-4b2d-a2f7-9a1b2c3d4e5f",
                     Name = "DeliveryClient",
                     NormalizedName = "DELIVERYCLIENT"
                 },
                 new IdentityRole
                 {
                     Id = "f2d4b1c7-8e6a-4f3c-b5a8-7d9e0f1a2b3c",
                     Name = "DeliveryCompanyUser",
                     NormalizedName = "DELIVERYCOMPANYUSER"
                 },
                 new IdentityRole
                 {
                     Id = "a3c7e9f1-6b2d-4c5a-b8f7-1d2e3c4b5a6f",
                     Name = "Driver",
                     NormalizedName = "DRIVER"
                 }
            );
        }
    }
}
