using Microsoft.EntityFrameworkCore;
using PracticalTest.DataStore.EntityAnnotations;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.DAL
{
    public class AppStore : DbContext
    {
        public AppStore(DbContextOptions<AppStore> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); econom resources
            builder.ApplyConfiguration(new ClientConfigurations());
            builder.ApplyConfiguration(new LoanConfigurations());
            builder.ApplyConfiguration(new InvoiceConfigurations());

            builder.Entity<Loan>().HasOne(j => j.Client)
                  .WithMany(u => u.Loans).HasForeignKey(u => u.ClientID);

            builder.Entity<Invoice>().HasOne(r => r.Loan)
             .WithMany(c => c.Invoices).HasForeignKey(f => f.LoanID);

            base.OnModelCreating(builder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}