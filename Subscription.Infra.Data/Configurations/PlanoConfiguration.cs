using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Data.Configurations
{
    public class PlanoConfiguration : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.HasKey(p => p.Id); 

            builder.Property(p => p.Nome).HasMaxLength(150).IsRequired();

            builder.Property(p => p.ValorMensal).HasPrecision(10, 2);

            builder.Property(p => p.Periodicidade).HasConversion<string>();
        }
    }
}
