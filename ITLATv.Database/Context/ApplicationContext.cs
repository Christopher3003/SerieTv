using ITLATv.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Database.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option):base(option)
        {
            
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Producter> Producters { get; set; }
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            #region Tables
            model.Entity<Gender>().ToTable("Genero");
            model.Entity<Producter>().ToTable("Productora");
            model.Entity<Serie>().ToTable("Serie");
            #endregion

            #region Primary Keys
            model.Entity<Gender>().HasKey(g=>g.Id);
            model.Entity<Producter>().HasKey(p=>p.Id);
            model.Entity<Serie>().HasKey(s=>s.Id);
            #endregion

            #region Foreign Keys
            model.Entity<Gender>()
                .HasMany<Serie>(g=>g.Series)
                .WithOne(s=>s.PrimaryGender)
                .HasForeignKey(s=>s.PrimaryGenderId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Entity<Producter>()
                .HasMany<Serie>(g => g.Series)
                .WithOne(s => s.Producter)
                .HasForeignKey(s => s.ProducterId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Entity<Serie>()
                .HasOne<Gender>(s => s.SecondaryGender)
                .WithMany()
                .HasForeignKey(g=>g.SecondaryGenderId)
                .IsRequired(false);
            #endregion

            #region Properties

            #region Gender
            model.Entity<Gender>()
                .Property(g => g.Name)
                .IsRequired();
            #endregion

            #region Producter
            model.Entity<Producter>()
                .Property(p => p.Name)
                .IsRequired();
            #endregion

            #region Serie
            model.Entity<Serie>()
                .Property(s => s.Name)
                .IsRequired();

            model.Entity<Serie>()
                .Property(s=>s.ImageURL)
                .IsRequired();

            model.Entity<Serie>()
                .Property(s=>s.VideoURL)
                .IsRequired();
            #endregion
            #endregion
        }
    }
}
