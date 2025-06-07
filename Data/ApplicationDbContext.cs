using Microsoft.EntityFrameworkCore;

namespace Práctica4_JeanEstrada.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets aquí...
    }
}