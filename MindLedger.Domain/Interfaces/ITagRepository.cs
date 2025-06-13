using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindLedger.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(Guid id);
        Task<Tag?> GetByNameAsync(string name);
        Task AddAsync(Tag tag);
        Task DeleteAsync(Guid id);

        Task<IEnumerable<NoteBase>> GetNotesByTagAsync(Guid tagId);
    }
}
