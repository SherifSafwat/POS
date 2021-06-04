using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BayMarch.Models;

namespace BayMarch.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser> 
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Models.Seller> Seller { get; set; }
        public DbSet<Models.Product> Product { get; set; }
        public DbSet<Models.Category> Category { get; set; }
        public DbSet<Models.Price> Price { get; set; }
        public DbSet<Models.Supplier> Supplier { get; set; }
        public DbSet<Models.WareHouse> WareHouse { get; set; }
        public DbSet<Models.InvoiceHead> InvoiceHead { get; set; }
        public DbSet<Models.InvoiceTail> InvoiceTail { get; set; }
        public DbSet<Models.OrderHead> OrderHead { get; set; }
        public DbSet<Models.OrderTail> OrderTail { get; set; }


    }
}
