using CarMonitor.Data.Entity;
using CarMonitor.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Data
{
    public class CMContext : DbContext
    {
        public CMContext() 
            : base("name=CarMonitorDBConnectionString")
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CMContext>(new MigrateDatabaseToLatestVersion<CMContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
