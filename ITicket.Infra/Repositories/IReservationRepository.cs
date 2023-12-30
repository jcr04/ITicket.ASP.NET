using ITicket.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITicket.Infra.Repositories;

public interface IReservationRepository
{
    Task<List<Reservation>> GetReservationsAsync();

    Task<Reservation> GetReservationByIdAsync(int reservationId);

    Task CreateReservationAsync(Reservation newReservation);

    Task UpdateReservationAsync(Reservation updatedReservation);

    Task DeleteReservationAsync(int reservationId);
}
