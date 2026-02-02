using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace DeliveryManagmentSystem.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.Development.json")
                                                   .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>().
                UseSqlServer(config.GetSection("sqlconnection").Value, b => b.MigrationsAssembly("DeliveryManagmentSystem"));

            return new RepositoryContext(builder.Options);
        }
    }
}
