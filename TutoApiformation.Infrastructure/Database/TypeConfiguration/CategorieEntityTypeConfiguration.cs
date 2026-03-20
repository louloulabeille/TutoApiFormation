using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TutoApiFormation.Domain.Infrastructure;

namespace TutoApiformation.Infrastructure.Database.TypeConfiguration
{
    internal class CategorieEntityTypeConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.ToTable(nameof(Categorie));
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.Title).IsRequired();
        }
    }
}
