using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MindLedger.Infrastructure.Persistence;

namespace MindLedger.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MindLedgerDbContext>
{
    /// <summary>
    /// Creates and configures a new instance of <see cref="MindLedgerDbContext"/>.
    /// </summary>
    /// <remarks>The method initializes a <see cref="DbContextOptionsBuilder{TContext}"/> with SQLite
    /// configuration pointing to a database file named "MindLedger.db". The returned <see cref="MindLedgerDbContext"/>
    /// is ready for use with this database.</remarks>
    /// <param name="args">An array of command-line arguments. This parameter is not used in the current implementation.</param>
    /// <returns>A new instance of <see cref="MindLedgerDbContext"/> configured to use a SQLite database.</returns>
    public MindLedgerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MindLedgerDbContext>();
        optionsBuilder.UseSqlite("Data Source=MindLedger.db");

        return new MindLedgerDbContext(optionsBuilder.Options);
    }
}