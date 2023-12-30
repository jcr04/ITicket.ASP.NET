using ITicket.Domain.Entities;
using ITicket.Domain.Repositories;
using ITicket.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITicket.Infra.Repositories
{
    public class EventEfRepository : IEventEfRepository
    {
        private readonly YourDbContext _dbContext;

        public EventEfRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            Event? @event = await _dbContext.Events.FindAsync(eventId);
            return @event;
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            _dbContext.Events.Add(newEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            _dbContext.Entry(updatedEvent).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var eventToDelete = await _dbContext.Events.FindAsync(eventId);

            if (eventToDelete != null)
            {
                _dbContext.Events.Remove(eventToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
