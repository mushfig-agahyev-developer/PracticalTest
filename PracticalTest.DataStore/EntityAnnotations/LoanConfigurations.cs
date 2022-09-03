using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.EntityAnnotations
{
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.ID).IsRequired().UseIdentityColumn();

            builder.Property(t => t.Amount).HasColumnType("decimal(18,5)").IsRequired();
            builder.Property(t => t.InterestRate).HasColumnType("decimal(18,5)").IsRequired();


            builder.Property(x => x.LoanPeriod).HasMaxLength(24).IsRequired();
            builder.Property(x => x.PayoutDate).IsRequired();
            builder.HasOne(x => x.Client).WithMany(x => x.Loans);
            //builder.HasMany(x => x.Invoices).WithOne(x => x.Loan);
            builder.ToTable("Loans");
        }
    }
}