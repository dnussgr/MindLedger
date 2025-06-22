using Microsoft.EntityFrameworkCore;
using MindLedger.Domain;
using MindLedger.Domain.Interfaces;
using MindLedger.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindLedger.Infrastructure.Repositories
{
    public class SqliteCampaignRepository : ICampaignRepository
    {
        private readonly MindLedgerDbContext _context;

        public SqliteCampaignRepository(MindLedgerDbContext context)
        {
            _context = context;
        }


        public async Task<List<Campaign>> GetAllAsync()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<Campaign?> GetByIdAsync(Guid id)
        {
            return await _context.Campaigns.FindAsync(id);
        }

        public async Task<Campaign?> GetByTitleAsync(string title)
        {
            return await _context.Campaigns.FirstOrDefaultAsync(c => c.Title == title);
        }

        public async Task AddAsync(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Campaign campaign)
        {
            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NoteBase>> GetAllNotesByCampaignAsync(Guid campaignId)
        {
            var result = new List<NoteBase>();

            result.AddRange(await _context.Sessions.Where(s => s.CampaignId == campaignId).ToListAsync());
            result.AddRange(await _context.Charakters.Where(c => c.CampaignId == campaignId).ToListAsync());
            result.AddRange(await _context.Npcs.Where(n => n.CampaignId == campaignId).ToListAsync());
            result.AddRange(await _context.Locations.Where(l => l.CampaignId == campaignId).ToListAsync());
            result.AddRange(await _context.WorldNotes.Where(w => w.CampaignId == campaignId).ToListAsync());

            return result;
        }
    }
}
