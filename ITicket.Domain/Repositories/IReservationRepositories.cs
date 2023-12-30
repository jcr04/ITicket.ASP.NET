using ITicket.Domain.Entities;

namespace ITicket.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsAsync();

        Task<Reservation> GetReservationByIdAsync(int reservationId);

        Task CreateReservationAsync(Reservation newReservation);

        Task UpdateReservationAsync(Reservation updatedReservation);

        Task DeleteReservationAsync(int reservationId);

    }
}
