using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EfCodeFirst {
    
    public class AppDbContext : DbContext {

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderline> Orderlines { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
        public AppDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            
            if(!options.IsConfigured) {
                options.UseSqlServer("server=localhost\\sqlexpress;database=CustOrdDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<Customer>(e => {
                e.HasIndex(x => x.Code).IsUnique();
            });

            builder.Entity<Order>(e => {
                e.Property(x => x.Description).IsRequired().HasMaxLength(50);
            });
        }
    }
}
