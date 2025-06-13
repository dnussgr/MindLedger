namespace MindLedger.Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<NoteBase>> GetAllAsync();
        Task AddAsync(NoteBase note);
        Task UpdateAsync(NoteBase note);
        Task DeleteAsync(Guid id);
    }
}
