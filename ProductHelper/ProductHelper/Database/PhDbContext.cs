using System;
using System.Data.Entity;
using DataModels.Database;

namespace ProductHelper.Database
{
    public class PhDbContext : DbContext
    {
        public PhDbContext() : base("PhContext")
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_PhContext");
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                this.Database.Connection.ConnectionString = connectionString;
            }

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ailment> Ailments { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}