using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Data.Configurations
{
    public class AssinaturaConfiguration : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Valor).HasPrecision(10, 2);

            builder.Property(a => a.Status).HasConversion<string>();

            builder.HasOne(a => a.Cliente) 
                .WithMany(c => c.Assinaturas) 
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(a => a.Plano) 
                .WithMany(p => p.Assinaturas) 
                .HasForeignKey(a => a.PlanoId) 
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
