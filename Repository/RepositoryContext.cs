using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties(typeof(string)).HaveMaxLength(500);
            configurationBuilder.Properties(typeof(decimal)).HavePrecision(18, 2);
            configurationBuilder.Properties(typeof(DateTime)).HaveColumnType("datetime2(0)");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefference).Assembly);

            foreach (var foreignKey in builder.Model
                                           .GetEntityTypes()
                                           .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

      
        public DbSet<City> Cities { get; set; }
        public DbSet<ClientDeliveryOrder> ClientDeliveryOrders { get; set; }
        public DbSet<ClientDeliveryOrderStatus> ClientDeliveryOrderStatuses { get; set; }
        public DbSet<ClientOrganizationCompaniesDelivery> ClientOrganizationCompaniesDeliveries { get; set; }
        public DbSet<ClientRequestsToDevlieryCompanies> ClientRequestsToDevlieryCompanies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DeliveryClientOrganization> DeliveryClientOrganizations { get; set; }
        public DbSet<DeliveryClientOrgProduct> DeliveryClientOrgProducts { get; set; }
        public DbSet<DeliveryClientUser> DeliveryClientUsers { get; set; }
        public DbSet<DeliveryCompany> DeliveryCompanies { get; set; }
        public DbSet<DeliveryCompanyCitiesPrice> DeliveryCompanyCitiesPrices { get; set; }
        public DbSet<DeliveryCompanyDeliveryType> DeliveryCompanyDeliveryTypes { get; set; }
        public DbSet<DeliveryCompanyDistancePrice> DeliveryCompanyDistancePrices { get; set; }
        public DbSet<DeliveryCompanyUser> DeliveryCompanyUsers { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<DeliveryOrderAddress> DeliveryOrderAddresses { get; set; }
        public DbSet<DeliveryOrderStatus> DeliveryOrderStatuses { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverAssignment> DriverAssignments { get; set; }
        public DbSet<OrganizationActivity> OrganizationActivities { get; set; }
        public DbSet<VechicalType> VechicalTypes { get; set; }
    }
}
