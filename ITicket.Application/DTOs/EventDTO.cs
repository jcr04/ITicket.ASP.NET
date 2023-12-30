namespace ITicket.Application.DTOs;

public class EventDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string? Location { get; set; }

    public decimal TicketPrice { get; set; }

    public int TotalTicketsAvailable { get; set; }

    public int TicketsReserved { get; set; }

}
