using KelimeDefteriAPI.Context.EntityConcretes;
using Microsoft.EntityFrameworkCore;

namespace KelimeDefteriAPI.Context
{
    public class KelifeDefteriAPIContext : DbContext
    {
        public KelifeDefteriAPIContext(DbContextOptions<KelifeDefteriAPIContext> options ) : base(options) {}

        public DbSet<Record> Records => Set<Record>();
        public DbSet<Word> Words => Set<Word>();
        public DbSet<Definition> Definitions => Set<Definition>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
