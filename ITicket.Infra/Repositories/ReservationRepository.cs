using ITicket.Domain.Entities;
using ITicket.Domain.Repositories;
using ITicket.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITicket.Infra.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly YourDbContext _dbContext;

        public ReservationRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            return await _dbContext.Reservations.FindAsync(reservationId);
        }

        public async Task CreateReservationAsync(Reservation newReservation)
        {
            _dbContext.Reservations.Add(newReservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservation updatedReservation)
        {
            _dbContext.Entry(updatedReservation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservationToDelete = await _dbContext.Reservations.FindAsync(reservationId);

            if (reservationToDelete != null)
            {
                _dbContext.Reservations.Remove(reservationToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
