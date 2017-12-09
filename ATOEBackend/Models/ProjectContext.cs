using System.Data.Entity;

namespace ATOEBackend.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceUsage> ResourceUsages { get; set; }
    }
}