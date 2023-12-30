using System;

namespace ITicket.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string? ReservationCode { get; set; }

        public string? ReservedBy { get; set; }

        public int NumberOfTickets { get; set; }

        public DateTime ReservationTime { get; set; }

        // Relacionamento com o evento
        public Event? Event { get; set; }
    }
}
