using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DGDbContext
{
    public class DgContext : DbContext
    {
        public DgContext(DbContextOptions<DgContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

}
//@"server=(localdb)\MSSQLLocalDB;Database=W-02;Trusted_connection=true;Integrated Security=true"