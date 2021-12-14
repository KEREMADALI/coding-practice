using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Models
{
	public partial class CameraMetadataDBContext : DbContext
	{
		public CameraMetadataDBContext(DbContextOptions<CameraMetadataDBContext> options) 
			: base(options)
		{ }

        public CameraMetadataDBContext()
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured == false)
        //    {
        //        //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        //    }
        //}

        public DbSet<CameraMetadata> CameraMetadata { get; set; }
	}
}