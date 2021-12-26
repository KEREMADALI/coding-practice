using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public partial class CameraMetadataDBContext : DbContext
    {
        public CameraMetadataDBContext(DbContextOptions<CameraMetadataDBContext> options)
            : base(options)
        { }

        public CameraMetadataDBContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost\\SQLEXPRESS;" +
                    "Database=master;" +
                    "Trusted_Connection=True;");
            }
        }

        public DbSet<CameraMetadata> CameraMetadata { get; set; }
    }
}
