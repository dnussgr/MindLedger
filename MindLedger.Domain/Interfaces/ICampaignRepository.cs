using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindLedger.Domain.Interfaces
{
    public interface ICampaignRepository
    {
        Task<List<Campaign>> GetAllAsync();
        Task<Campaign?> GetByIdAsync(Guid id);
        Task<Campaign?> GetByTitleAsync(string title);
        Task AddAsync(Campaign campaign);
        Task UpdateAsync(Campaign campaign);
        Task DeleteAsync(Guid id);

        // Get all related notes
        Task<List<NoteBase>> GetAllNotesByCampaignAsync(Guid campaignId);
    }
}
