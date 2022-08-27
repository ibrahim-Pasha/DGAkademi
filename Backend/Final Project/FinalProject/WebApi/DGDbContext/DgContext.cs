using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DGDbContext
{
    public class DgContext : DbContext
    {
        public DgContext(DbContextOptions<DgContext> options) : base(options)
        {
        }
    
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
