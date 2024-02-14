using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi
{
    public class BibliothequeContext : DbContext
    {
        public DbSet<Auteur> Auteurs  => Set<Auteur>();
        public DbSet<Lecteur> Lecteurs => Set<Lecteur>();
        public DbSet<Livre> Livres => Set<Livre>();
        public DbSet<Emprunt> Emprunts => Set<Emprunt>();
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Domaine> Domaines => Set<Domaine>();

        public BibliothequeContext(DbContextOptions<BibliothequeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auteur>()
            .Property(b => b.Nom)
            .IsRequired()
            .HasMaxLength(32);

            modelBuilder.Entity<Auteur>()
                .Property(b => b.Prenom)
                .IsRequired()
                .HasMaxLength(32);


            modelBuilder.Entity<Lecteur>()
                .Property(b => b.Nom)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Lecteur>()
                .HasMany(l => l.Emprunter);

            modelBuilder.Entity<Lecteur>()
                .Property(b => b.Prenom)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Lecteur>()
                .HasOne(l => l.Adresse);

            modelBuilder.Entity<Adresse>()
                .Property(a => a.Ville)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Adresse>()
                .Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Adresse>()
                .Property(a => a.Pays)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Adresse>()
                .HasMany(a => a.Lecteurs);

            modelBuilder.Entity<Domaine>()
                .Property(d => d.Nom)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Domaine>()
                .HasMany(d => d.Livres);

            modelBuilder.Entity<Livre>()
                .HasOne(l => l.Auteur);

            modelBuilder.Entity<Livre>()
                .HasMany(l => l.Emprunts);

            modelBuilder.Entity<Livre>()
                .HasOne(l => l.Domaine);

            modelBuilder.Entity<Livre>()
                .Property(l => l.Titre)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Emprunt>()
                .HasOne(e => e.Livre);

            modelBuilder.Entity<Emprunt>()
                .HasOne(e => e.Lecteur);



        }
    }
}
