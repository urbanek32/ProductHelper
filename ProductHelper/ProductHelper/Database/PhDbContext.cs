using System.Data.Entity;
using DataModels.Database;

namespace ProductHelper.Database
{
    public class PhDbContext : DbContext
    {
        public PhDbContext() : base("PhContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ailment> Ailments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}