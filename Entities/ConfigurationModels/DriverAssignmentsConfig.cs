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
    public class DriverAssignmentsConfig : IEntityTypeConfiguration<DriverAssignment>
    {
        public void Configure(EntityTypeBuilder<DriverAssignment> builder)
        {
            builder.HasOne(P => P.DeliveryCompanyUser)
                   .WithMany(P => P.DriverAssignments)
                   .HasForeignKey(P => P.AssignedBy)
                   .IsRequired(false);

            builder.Property(P=>P.AcceptedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(P => P.AssignedAt).HasDefaultValueSql("GETDATE()");

        }
    }
}
