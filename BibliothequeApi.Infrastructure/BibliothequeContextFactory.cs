using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi
{
    public class BibliothequeContextFactory : IDesignTimeDbContextFactory<BibliothequeContext>
    {
        public BibliothequeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BibliothequeContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Bibliotheque;Trusted_Connection = True;MultipleActiveResultSets=true;");

            return new BibliothequeContext(optionsBuilder.Options);
        }
    }
    
}
