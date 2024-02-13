using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi
{
    public class UserContext : DbContext
    {
        public DbSet<Admin> Admins => Set<Admin>();

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                 .HasIndex(a => a.UserName)
                 .IsUnique();

            modelBuilder.Entity<Admin>()
                .Property(a => a.MotDePasse)
                .IsRequired();
        }

    }
}
