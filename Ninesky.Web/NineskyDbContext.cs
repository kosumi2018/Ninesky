using Microsoft.EntityFrameworkCore;
using Ninesky.Base;

namespace Ninesky.Web
{
    public class NineskyDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public NineskyDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}