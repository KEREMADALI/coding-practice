using Core.DataAccess.EntityFramework.Contexts;
using DataAccess.Constants;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public partial class CameraMetadataDBContext : BaseDBContext
    {
        public CameraMetadataDBContext(IConfiguration configuration) : base(configuration)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                var userId = _configuration[EnvironmentVariables.AzureUserId];
                var password = _configuration[EnvironmentVariables.AzurePassword];

                optionsBuilder.UseSqlServer(
                    "Server=tcp:camerametadata.database.windows.net,1433;"
                    + "Initial Catalog=test-database;"
                    + "Persist Security Info=False;"
                    + $"User ID={userId};"
                    + $"Password={password};"
                    + "MultipleActiveResultSets=False;"
                    + "Encrypt=True;"
                    + "TrustServerCertificate=False;"
                    + "Connection Timeout=30;");
            }
        }

        public DbSet<CameraMetadata> CameraMetadata { get; set; }
    }
}
