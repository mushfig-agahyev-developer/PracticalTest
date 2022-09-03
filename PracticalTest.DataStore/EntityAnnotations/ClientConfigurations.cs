using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.EntityAnnotations
{
    public class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(t => t.ClientUniqueId);

            builder.Property(t => t.ClientUniqueId).IsRequired();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(200);
            builder.Property(r => r.Surname).IsRequired().HasMaxLength(200);
            builder.Property(r => r.TelephoneNr).IsRequired().HasMaxLength(24).IsFixedLength();
            builder.ToTable("Clients");
        }
    }
}
