using System;

namespace ITicket.Application.DTOs;

public class ReservationDTO
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public string? ReservationCode { get; set; }

    public string? ReservedBy { get; set; }

    public int NumberOfTickets { get; set; }

    public DateTime ReservationTime { get; set; }

}
