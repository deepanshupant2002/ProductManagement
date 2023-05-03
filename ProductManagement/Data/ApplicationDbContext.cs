
using ProductManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Cart> Cart { get; set; }


    }
}
