using Microsoft.EntityFrameworkCore;
using MindLedger.Domain;
using MindLedger.Domain.Interfaces;
using MindLedger.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MindLedger.Infrastructure.Repositories;

public class SqliteNoteRepository : INoteRepository
{
    private readonly MindLedgerDbContext _db;

    public SqliteNoteRepository(MindLedgerDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<NoteBase>> GetAllAsync()
    {
        return await _db.Notes
            .OrderByDescending(n => n.UpdatedAt)
            .ToListAsync();
    }

    public async Task AddAsync(NoteBase note)
    {
        _db.Notes.Add(note);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(NoteBase note)
    {
        _db.Notes.Update(note);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var note = await _db.Notes.FindAsync(id);
        if (note is not null)
        {
            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();
        }
    }
}
