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
    public class ClientOrganizationCompaniesDeliveryConfig : IEntityTypeConfiguration<ClientOrganizationCompaniesDelivery>
    {
        public void Configure(EntityTypeBuilder<ClientOrganizationCompaniesDelivery> builder)
        {
            builder.Property(P=>P.IsActive).HasDefaultValue(true);
        }
    }
}
