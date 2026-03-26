using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TutoApiFormation.Domain;

namespace TutoApiformation.Infrastructure.Database.TypeConfiguration
{
    public class FormationEntityTypeConfiguration : IEntityTypeConfiguration<Formation>
    {
        public void Configure(EntityTypeBuilder<Formation> builder)
        {
            builder.ToTable(nameof(Formation));
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.Description).HasColumnType("text");

            builder.HasIndex(f => f.Tag).HasDatabaseName("TagIndexFormation");
            builder.HasIndex(f => f.Id).HasDatabaseName("IdIndexFormation");
        }
    }
}
