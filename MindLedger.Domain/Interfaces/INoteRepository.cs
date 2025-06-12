namespace MindLedger.Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllAsync();
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Guid id);
    }
}
