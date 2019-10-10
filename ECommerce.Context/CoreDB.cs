using Microsoft.EntityFrameworkCore;
using System;
using ECommerce.Model;

namespace ECommerce.Context
{
    public class CoreDB: DbContext
    {
        public CoreDB(
            DbContextOptions<CoreDB> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<ProductModel> Product { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
                .HasKey(x => x.ProductCode);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
