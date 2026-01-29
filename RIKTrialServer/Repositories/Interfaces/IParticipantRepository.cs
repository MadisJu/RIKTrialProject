using RIKTrialServer.Domains.Models;

namespace RIKTrialServer.Repositories.Interfaces
{
    public interface IParticipantRepository
    {
        public Task<Participant?> GetParticipant(Guid id, CancellationToken ctoken);
        public Task<List<Participant>> GetParticipants(CancellationToken ctoken);

        public Task<List<Participant>> GetEventParticipants(Guid eventId,  CancellationToken ctoken);
        public Task<bool> AddParticipant(Participant p,  CancellationToken ctoken);
        public Task<bool> UpdateParticipant(Participant p, CancellationToken ctoken);
        public Task<bool> RemoveAsync(Participant p, CancellationToken ctoken);
    }
}
