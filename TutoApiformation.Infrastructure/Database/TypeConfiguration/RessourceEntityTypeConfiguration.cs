using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TutoApiFormation.Domain;

namespace TutoApiformation.Infrastructure.Database.TypeConfiguration
{
    public class RessourceEntityTypeConfiguration : IEntityTypeConfiguration<Ressource>
    {
        public void Configure(EntityTypeBuilder<Ressource> builder)
        {
            builder.ToTable(nameof(Ressource));
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.HasOne(r => r.Formation).WithOne(r => r.Ressource);

            builder.Property(f => f.Lien).IsRequired();
        }
    }
}
