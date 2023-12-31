﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ITicket.Domain.Entities;

namespace ITicket.Domain.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetEventsAsync();

        Task<Event> GetEventByIdAsync(int eventId);

        Task CreateEventAsync(Event newEvent);

        Task UpdateEventAsync(Event updatedEvent);

        Task DeleteEventAsync(int eventId);
        Task UpdateEventAsync(int id, Event updatedEvent);
    }
}
