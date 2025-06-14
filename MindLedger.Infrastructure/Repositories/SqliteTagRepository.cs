using Microsoft.EntityFrameworkCore;
using MindLedger.Domain;
using MindLedger.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindLedger.Infrastructure.Repositories
{
    public class SqliteTagRepository
    {
        private readonly MindLedgerDbContext _db;

        public SqliteTagRepository(MindLedgerDbContext db)
        {
            _db = db;
        }


        /// <summary>
        /// Asynchronously retrieves all tags from the database, including their associated notes,  ordered by tag name.
        /// </summary>
        /// <remarks>This method queries the database to fetch all tags, including their related notes, 
        /// and orders the results by the tag name in ascending order.</remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains an  <see
        /// cref="IEnumerable{Tag}"/> of tags, each with their associated notes.</returns>
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _db.Tags
                .Include(t  => t.Notes)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }


        /// <summary>
        /// Retrieves a tag by its unique identifier.
        /// </summary>
        /// <remarks>This method performs a database query to locate the tag with the specified
        /// identifier. The returned tag includes its associated notes.</remarks>
        /// <param name="id">The unique identifier of the tag to retrieve.</param>
        /// <returns>A <see cref="Tag"/> object representing the tag with the specified identifier,  or <see langword="null"/> if
        /// no matching tag is found.</returns>
        public async Task<Tag?> GetByIdAsync(Guid id)
        {
            return await _db.Tags
                .Include(t => t.Notes)
                .FirstOrDefaultAsync(t => t.Id == id);
        }


        /// <summary>
        /// Asynchronously retrieves a tag by its name.
        /// </summary>
        /// <remarks>This method performs a case-insensitive search for the tag name and includes related
        /// notes in the result.</remarks>
        /// <param name="name">The name of the tag to retrieve. This parameter is case-insensitive.</param>
        /// <returns>A <see cref="Tag"/> object representing the tag with the specified name, or <see langword="null"/> if no
        /// matching tag is found.</returns>
        public async Task<Tag?> GetByNameAsync(string name)
        {
            return await _db.Tags
                .Include(t => t.Notes)
                .FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());
        }


        /// <summary>
        /// Asynchronously adds a new tag to the database.
        /// </summary>
        /// <remarks>This method adds the specified <paramref name="tag"/> to the database and saves the
        /// changes. Ensure that the <paramref name="tag"/> object is properly initialized before calling this
        /// method.</remarks>
        /// <param name="tag">The tag to add. Cannot be <see langword="null"/>.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddAsync(Tag tag)
        {
            _db.Tags.Add(tag);
            await _db.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes the tag with the specified identifier asynchronously.
        /// </summary>
        /// <remarks>If the tag with the specified identifier does not exist, no action is
        /// performed.</remarks>
        /// <param name="id">The unique identifier of the tag to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            var tag = await _db.Tags.FindAsync(id);
            if (tag is not null)
            {
                _db.Tags.Remove(tag);
                await _db.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Retrieves a collection of notes associated with the specified tag.
        /// </summary>
        /// <remarks>This method queries the database for notes that are linked to the specified tag.  The
        /// results are sorted by the most recently updated notes first.</remarks>
        /// <param name="tagId">The unique identifier of the tag to filter notes by.  This parameter cannot be an empty <see cref="Guid"/>.</param>
        /// <returns>A task that represents the asynchronous operation.  The task result contains an <see cref="IEnumerable{T}"/>
        /// of <see cref="NoteBase"/> objects  that are associated with the specified tag, ordered by their last update
        /// time in descending order.</returns>
        public async Task<IEnumerable<NoteBase>> GetNoteByTagAsync(Guid tagId)
        {
            return await _db.Notes
                .Where(n => n.Tags.Any(t =>  t.Id == tagId))
                .OrderByDescending(n => n.UpdatedAt)
                .ToListAsync();
        }
    }
}
