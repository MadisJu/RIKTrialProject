using RIKTrialServer.Domains.Models;
using RIKTrialSharedModels.Domains.Filters;

namespace RIKTrialServer.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<Event?> GetEventByID(Guid id, CancellationToken ctoken);
        Task<List<Event>> GetEvents(EventFilters filters, CancellationToken ctoken);
        Task<bool> AddEvent(Event e, CancellationToken ctoken);
        Task<bool> UpdateEvent(Event e, CancellationToken ctoken);
        Task<bool> RemoveEvent(Event e, CancellationToken ctoken);
    }
}
