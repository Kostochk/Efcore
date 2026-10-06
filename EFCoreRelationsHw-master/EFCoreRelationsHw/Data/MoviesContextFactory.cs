using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationsHw.Data
{
    public class MoviesContextFactory : IDesignTimeDbContextFactory<MoviesContext>
    {
        public MoviesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=MoviesDb;Trusted_Connection=True;TrustServerCertificate=True;");
            return new MoviesContext(optionsBuilder.Options);
        }
    }
}
