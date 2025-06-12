using Microsoft.EntityFrameworkCore;
using MindLedger.Domain;

namespace MindLedger.Infrastructure.Persistence;

public class MindLedgerDbContext : DbContext
{
    public DbSet<Note> Notes => Set<Note>();

    public MindLedgerDbContext(DbContextOptions<MindLedgerDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasKey(n => n.Id);
    }
}
