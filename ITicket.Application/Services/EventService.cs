using ITicket.Application.DTOs;
using ITicket.Domain.Entities;
using ITicket.Domain.Repositories;

namespace ITicket.Application.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<EventDTO>> GetEventsAsync()
        {
            var events = await _eventRepository.GetEventsAsync();
            return MapEventListToEventDTOList(events);
        }

        public async Task<EventDTO> GetEventByIdAsync(int eventId)
        {
            var eventEntity = await _eventRepository.GetEventByIdAsync(eventId);
            return MapEventToEventDTO(eventEntity);
        }

        public async Task CreateEventAsync(EventDTO eventDTO)
        {
            var newEvent = MapEventDTOToEvent(eventDTO);
            await _eventRepository.CreateEventAsync(newEvent);
        }

        public async Task UpdateEventAsync(int eventId, EventDTO updatedEventDTO)
        {
            var existingEvent = await _eventRepository.GetEventByIdAsync(eventId) ?? throw new NotFoundException($"Evento com ID {eventId} não encontrado.");

            existingEvent.Name = updatedEventDTO.Name;
            existingEvent.Description = updatedEventDTO.Description;
            existingEvent.StartTime = updatedEventDTO.StartTime;
            existingEvent.EndTime = updatedEventDTO.EndTime;
            existingEvent.Location = updatedEventDTO.Location;
            existingEvent.TicketPrice = updatedEventDTO.TicketPrice;
            existingEvent.TotalTicketsAvailable = updatedEventDTO.TotalTicketsAvailable;
            existingEvent.TicketsReserved = updatedEventDTO.TicketsReserved;

            await _eventRepository.UpdateEventAsync(existingEvent);
        }

        public async Task DeleteEventAsync(int eventId)
        {
            await _eventRepository.DeleteEventAsync(eventId);
        }

        private List<EventDTO> MapEventListToEventDTOList(List<Event> events)
        {
            var eventDTOList = new List<EventDTO>();

            foreach (var eventEntity in events)
            {
                eventDTOList.Add(MapEventToEventDTO(eventEntity));
            }

            return eventDTOList;
        }

        private EventDTO MapEventToEventDTO(Event eventEntity)
        {
            return new EventDTO
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

        private Event MapEventDTOToEvent(EventDTO eventDTO)
        {
            return new Event
            {
                Name = eventDTO.Name,
                Description = eventDTO.Description,
                StartTime = eventDTO.StartTime,
                EndTime = eventDTO.EndTime,
                Location = eventDTO.Location,
                TicketPrice = eventDTO.TicketPrice,
                TotalTicketsAvailable = eventDTO.TotalTicketsAvailable,
                TicketsReserved = eventDTO.TicketsReserved
            };
        }
    }
}
