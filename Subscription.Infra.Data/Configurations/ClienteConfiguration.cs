using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id); 

            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();

            builder.OwnsOne(c => c.Email, e =>
            {
                e.Property(p => p.Endereco)
                    .HasColumnName("Email")
                    .HasMaxLength(150)
                    .IsRequired();

                e.HasIndex(p => p.Endereco)
                .IsUnique();
            });

            builder.Property(c => c.Status).HasConversion<string>();
        }
    }
}
