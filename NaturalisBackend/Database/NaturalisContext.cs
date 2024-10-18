using Microsoft.EntityFrameworkCore;
using NaturalisBackend.Models;

namespace NaturalisBackend.Database
{
    public class NaturalisContext : DbContext
    {
        public NaturalisContext(DbContextOptions<NaturalisContext> options) : base(options) { }

        public DbSet<Test> Test { get; set; }

    }
}
