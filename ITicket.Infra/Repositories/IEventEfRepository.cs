using ITicket.Domain.Entities;

namespace ITicket.Infra.Repositories
{
    public interface IEventEfRepository
    {
        Task<List<Event>> GetEventsAsync();

        Task<Event> GetEventByIdAsync(int eventId);

        Task CreateEventAsync(Event newEvent);

        Task UpdateEventAsync(Event updatedEvent);

        Task DeleteEventAsync(int eventId);
    }
}
