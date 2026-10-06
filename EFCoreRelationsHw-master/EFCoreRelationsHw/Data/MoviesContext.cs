using EFCoreRelationsHw.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationsHw.Data
{
    public class MoviesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) { }
    }
}
