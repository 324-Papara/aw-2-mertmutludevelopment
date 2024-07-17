using Microsoft.EntityFrameworkCore;
using Para.Data.Domain;

namespace Para.Data.Context
{
    public class ParaPostgreDbContext : DbContext
    {
        public ParaPostgreDbContext(DbContextOptions<ParaPostgreDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}