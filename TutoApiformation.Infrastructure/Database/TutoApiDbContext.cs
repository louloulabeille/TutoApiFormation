using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TutoApiformation.Infrastructure.Database.TypeConfiguration;
using TutoApiFormation.Domain;

namespace TutoApiformation.Infrastructure.Database
{
    public class TutoApiDbContext : IdentityDbContext
    {
        #region Construc 
        public TutoApiDbContext(): base(){}

        public TutoApiDbContext(DbContextOptions<TutoApiDbContext> options ) : base(options) { }
        #endregion

        #region public properties
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Formation> Formations { get; set; }
        #endregion

        #region protected ovveride
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // -- Apply model table
            modelBuilder.ApplyConfiguration(new CategorieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FormationEntityTypeConfiguration());

        }
        #endregion
    }
}
