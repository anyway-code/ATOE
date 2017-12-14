using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ATOEBackend.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceUsage> ResourceUsages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectContext, Configuration>());
        }
    }

    //internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //        //AutomaticMigrationDataLossAllowed = true;
    //        //ContextKey = "OctoMVC.Models.ApplicationDbContext";
    //    }
    //}
}