using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TutoApiformation.Infrastructure.Database.TypeConfiguration;
using TutoApiFormation.Domain.Infrastructure;

namespace TutoApiformation.Infrastructure.Database
{
    public class TutoApiDbContext :DbContext
    {
        #region Construc 
        public TutoApiDbContext(): base(){}

        public TutoApiDbContext(DbContextOptions<TutoApiDbContext> options ) : base(options) { }
        #endregion

        #region public properties
        public DbSet<Categorie> Categories { get; set; }
        #endregion

        #region protected ovveride
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -- Apply model table
            modelBuilder.ApplyConfiguration(new CategorieEntityTypeConfiguration());


            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
