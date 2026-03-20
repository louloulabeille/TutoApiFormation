using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiformation.Infrastructure.Database
{
    internal class TutoApiDbContextFactory : IDesignTimeDbContextFactory<TutoApiDbContext>
    {
        public TutoApiDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<TutoApiDbContext>();
            optionBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=Selfie-Dev;User Id=api_log;Password=ieupn486;");

            return new TutoApiDbContext(optionBuilder.Options);
        }
    }
}
