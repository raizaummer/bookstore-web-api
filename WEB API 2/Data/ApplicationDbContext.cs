using Microsoft.EntityFrameworkCore;
using WEB_API_2.Models;

namespace WEB_API_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<book> bookss { get; set; }
    }
}
