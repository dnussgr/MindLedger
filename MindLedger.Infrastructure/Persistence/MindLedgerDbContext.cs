using Microsoft.EntityFrameworkCore;
using MindLedger.Domain;

namespace MindLedger.Infrastructure.Persistence;

public class MindLedgerDbContext : DbContext
{
    public DbSet<NoteBase> Notes => Set<NoteBase>();

    public MindLedgerDbContext(DbContextOptions<MindLedgerDbContext> options)
        : base(options) { }

    // Zugrundeliegender Container für Notizen
    public DbSet<Campaign> Campaigns => Set<Campaign>();

    // Notizentypen
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Charakter> Charakters => Set<Charakter>();
    public DbSet<Npc> Npcs => Set<Npc>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<WorldNote> WorldNotes => Set<WorldNote>();

    // Tags
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Vererbung mit TPH -> Table-per-Hierarchy
        modelBuilder.Entity<NoteBase>()
            .HasDiscriminator<string>("NoteType")
            .HasValue<Session>("Session")
            .HasValue<Charakter>("Character")
            .HasValue<Npc>("Npc")
            .HasValue<Location>("Location")
            .HasValue<WorldNote>("WorldNote");

        // Kampagne -> Session (1:n)
        modelBuilder.Entity<Campaign>()
            .HasMany(c => c.Sessions)
            .WithOne(s => s.Campaign)
            .HasForeignKey(s => s.CampaignId);

        // Tags: (m:n) zu NoteBase
        modelBuilder.Entity<NoteBase>()
            .HasMany(n => n.Tags)
            .WithMany(t => t.Notes);

        base.OnModelCreating(modelBuilder);
    }
}
