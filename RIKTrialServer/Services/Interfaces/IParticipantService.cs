using RIKTrialServer.Domains.Models;
using RIKTrialSharedModels.Domain.Creation;

namespace RIKTrialServer.Services.Interfaces
{
    public interface IParticipantService
    {
        public Task<Participant?> GetParticipant(Guid id, CancellationToken ctoken);
        public Task<List<Participant>> GetParticipants(CancellationToken ctoken);

        public Task<bool> CreateParticipant(ParticipantCreationDTO data,  CancellationToken ctoken);

        public Task<bool> UpdateParticipant(ParticipantCreationDTO data, Guid id, CancellationToken ctoken);

        public Task<bool> DeleteParticipant(Guid id, CancellationToken ctoken);

    }
}
