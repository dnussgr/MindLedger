using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MindLedger.Infrastructure.Persistence;

namespace MindLedger.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MindLedgerDbContext>
{
    public MindLedgerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MindLedgerDbContext>();
        optionsBuilder.UseSqlite("Data Source=MindLedger.db");

        return new MindLedgerDbContext(optionsBuilder.Options);
    }
}