using ITicket.Domain.Entities;
using ITicket.Domain.Repositories;

namespace ITicket.Infra.Repositories
{
    public interface IEventEfRepository : IEventRepository
    {
        new Task<List<Event>> GetEventsAsync();
        new Task<Event> GetEventByIdAsync(int eventId);
        new Task CreateEventAsync(Event newEvent);
        new Task UpdateEventAsync(Event updatedEvent);
        new Task DeleteEventAsync(int eventId);
    }
}
