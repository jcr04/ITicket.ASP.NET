using ITicket.Domain.Entities;
using ITicket.Domain.Repositories;
using ITicket.Infra.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITicket.Application.Services
{
    public class EventService : IEventRepository
    {
        private readonly IEventRepositoryFactory _repositoryFactory;

        public EventService(IEventRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            var repository = _repositoryFactory.CreateInstance();
            var events = await repository.GetEventsAsync();
            return MapEventListToEventList(events);
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            var repository = _repositoryFactory.CreateInstance();
            var eventEntity = await repository.GetEventByIdAsync(eventId);
            return MapEventToEvent(eventEntity);
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            var repository = _repositoryFactory.CreateInstance();
            await repository.CreateEventAsync(newEvent);
        }

        public async Task UpdateEventAsync(int id, Event updatedEvent)
        {
            var repository = _repositoryFactory.CreateInstance();
            var existingEvent = await repository.GetEventByIdAsync(id) ?? throw new NotFoundException($"Evento com ID {id} não encontrado.");

            MapUpdatedEventToEvent(existingEvent, updatedEvent);

            await repository.UpdateEventAsync(existingEvent);
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var repository = _repositoryFactory.CreateInstance();
            await repository.DeleteEventAsync(eventId);
        }

        private static List<Event> MapEventListToEventList(List<Event> events)
        {
            var eventList = new List<Event>();

            foreach (var eventEntity in events)
            {
                eventList.Add(MapEventToEvent(eventEntity));
            }

            return eventList;
        }

        private static Event MapEventToEvent(Event eventEntity)
        {
            return new Event
            {
                Id = eventEntity.Id,
                Name = eventEntity.Name,
                Description = eventEntity.Description,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Location = eventEntity.Location,
                TicketPrice = eventEntity.TicketPrice,
                TotalTicketsAvailable = eventEntity.TotalTicketsAvailable,
                TicketsReserved = eventEntity.TicketsReserved
            };
        }

        private static void MapUpdatedEventToEvent(Event existingEvent, Event updatedEvent)
        {
            existingEvent.Name = updatedEvent.Name;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.StartTime = updatedEvent.StartTime;
            existingEvent.EndTime = updatedEvent.EndTime;
            existingEvent.Location = updatedEvent.Location;
            existingEvent.TicketPrice = updatedEvent.TicketPrice;
            existingEvent.TotalTicketsAvailable = updatedEvent.TotalTicketsAvailable;
            existingEvent.TicketsReserved = updatedEvent.TicketsReserved;
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            var repository = _repositoryFactory.CreateInstance();
            await repository.UpdateEventAsync(updatedEvent);
        }
    }
}
