using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CrmFacadeApi.Models;

namespace CrmFacadeApi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Customer>().ToQuery("Customers");
            builder.Entity<Customer>().HasKey(p => p.CustomerName);
            builder.Entity<Customer>().Property(p => p.CustomerEmail);
            builder.Entity<Customer>().Property(p => p.CustomerAddress);

        
        
        }




    }
}
