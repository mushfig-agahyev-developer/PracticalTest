using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.EntityAnnotations
{
    public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.ID).IsRequired().UseIdentityColumn();
            builder.Property(t => t.Amount).HasColumnType("decimal(18,5)").IsRequired();
            builder.Property(x => x.DueDate).IsRequired();
            builder.Property(x => x.OrderNr).IsRequired();
            //builder.HasOne(x => x.Loan).WithMany(x => x.Invoices);
            builder.ToTable("Invoices");
        }
    }
}
