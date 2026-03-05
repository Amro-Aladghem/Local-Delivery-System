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
    public class OrganizationActivityConfig : IEntityTypeConfiguration<OrganizationActivity>
    {
        public void Configure(EntityTypeBuilder<OrganizationActivity> builder)
        {
            builder.HasData(new OrganizationActivity()
            {
                Id = 1,
                Name = "Delivery Client Org"
            });
        }
    }
}
