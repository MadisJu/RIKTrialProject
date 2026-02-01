using Microsoft.EntityFrameworkCore;
using RIKTrialServer.Domains.Models;
using RIKTrialServer.Infra.Persistance;
using RIKTrialServer.Repositories.Interfaces;

namespace RIKTrialServer.Repositories.Implementations
{
    public class ParticipantRepository(ServerDbContext dbc) : IParticipantRepository
    {
        private readonly ServerDbContext _dbc = dbc;

        public async Task<bool> AddParticipant(Participant p, CancellationToken ctoken)
        {
            await _dbc.AddAsync(p, ctoken);
            return 0 < await _dbc.SaveChangesAsync(ctoken);
        }

        public async Task<List<Participant>> GetEventParticipants(Guid eventId, CancellationToken ctoken)
        {
            return await _dbc.EventParticipants
                .Where(ep => ep.EventId == eventId)
                .Select(ep => ep.Participant)
                .ToListAsync(ctoken);
        }

        public async Task<Participant?> GetParticipant(Guid id, CancellationToken ctoken)
        {
            return await _dbc.Participants
                .Include(p => p.PaymentMethod)
                .FirstOrDefaultAsync(p => p.Id == id, ctoken);
        }

        public Task<List<Participant>> GetParticipants(CancellationToken ctoken)
        {
            return _dbc.Participants
                .Include(p => p.PaymentMethod)
                .ToListAsync(ctoken);
        }

        public async Task<bool> UpdateParticipant(Participant p, CancellationToken ctoken)
        {
            _dbc.Participants.Update(p);
            return 0 < await _dbc.SaveChangesAsync(ctoken);
        }
        public async Task<bool> RemoveAsync(Participant p, CancellationToken ctoken)
        {
            _dbc.Participants.Remove(p);
            return 0 < await _dbc.SaveChangesAsync(ctoken);
        }
    }
}
