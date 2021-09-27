using logCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace logInfrastructure.Data
{
    public class MultitenantDbContext : DbContext
    {
        public string idTenant;

        public IConfiguration _configuration { get; }

        public MultitenantDbContext(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            if (accessor != null
                && accessor.HttpContext != null
                && accessor.HttpContext.Request != null
                && accessor.HttpContext.Request.Headers != null
                && !string.IsNullOrEmpty(accessor.HttpContext.Request.Headers["x-tenant-id"]))
            {
                idTenant = accessor.HttpContext.Request.Headers["x-tenant-id"].ToString();
            }
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(getConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        private string getConnectionString()
        {
            var connectionString = _configuration.GetConnectionString("AppTenantCS");

            var server = Environment.GetEnvironmentVariable("SERVER");
            var user = Environment.GetEnvironmentVariable("USER");
            var password = Environment.GetEnvironmentVariable("PASSWORD");

            connectionString = connectionString.Replace(@"{{SERVER}}", server).Replace(@"{{DATABASE}}", idTenant + "-log").Replace(@"{{USER}}", user).Replace(@"{{PASSWORD}}", password);

            return connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<LogChange> LogChanges { get; set; }
    }
}
