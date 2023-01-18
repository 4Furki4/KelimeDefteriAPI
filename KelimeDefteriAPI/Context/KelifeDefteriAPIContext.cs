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
            modelBuilder.Entity<Record>().HasIndex(x => x.Created, "CreatedIndex");
            modelBuilder.Entity<Record>().HasData(new Record { Created = DateTime.Now, Id = -1 });
            modelBuilder.Entity<Definition>().HasData(
                new Definition { WordId = -1, Id = -1, Description = "test1description", DescriptionType = "test1descriptionType" },
                new Definition { WordId = -1, Id = -2, Description = "test1description", DescriptionType = "test1descriptionType" },
                new Definition { WordId = -2, Id = -3, Description = "test2description", DescriptionType = "test2descriptionType" },
                new Definition { WordId = -2, Id = -4, Description = "test2description", DescriptionType = "test2descriptionType" },
                new Definition { WordId = -3, Id = -5, Description = "test3description", DescriptionType = "test3descriptionType" },
                new Definition { WordId = -3, Id = -6, Description = "test3description", DescriptionType = "test3descriptionType" },
                new Definition { WordId = -4, Id = -7, Description = "test4description", DescriptionType = "test4descriptionType" },
                new Definition { WordId = -4, Id = -8, Description = "test4description", DescriptionType = "test4descriptionType" }
            );
            modelBuilder.Entity<Word>().HasData(
                new Word() { Id = -1, Name = "TEST1", RecordId = -1 },
                new Word() { Id = -2, Name = "TEST2", RecordId = -1 },
                new Word() { Id = -3, Name = "TEST3", RecordId = -1 },
                new Word() { Id = -4, Name = "TEST4", RecordId = -1 }
            );
        }
    }
}
