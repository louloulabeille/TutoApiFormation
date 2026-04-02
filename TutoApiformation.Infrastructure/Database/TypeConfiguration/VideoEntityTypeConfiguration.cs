using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TutoApiFormation.Domain;

namespace TutoApiformation.Infrastructure.Database.TypeConfiguration
{
    public class VideoEntityTypeConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable(nameof(Video));
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
