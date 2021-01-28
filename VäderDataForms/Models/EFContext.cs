using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VäderDataForms.Models
{
    class EFContext : DbContext
    {
        private string connectionString;
        public EFContext() : base()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("sqlConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<IndoorTemperature> IndoorTemperatures { get; set; }
        public DbSet<OutdoorTemperature> OutdoorTemperatures { get; set; }
    }
}
