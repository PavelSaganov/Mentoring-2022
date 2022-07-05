using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.EFRepository
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Categories> Categories { get; set; }
    }
}
