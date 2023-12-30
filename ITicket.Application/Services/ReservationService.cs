using ITicket.Application.DTOs;
using ITicket.Domain.Entities;
using ITicket.Domain.Repositories;

namespace ITicket.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<ReservationDTO>> GetReservationsAsync()
        {
            var reservations = await _reservationRepository.GetReservationsAsync();
            return MapReservationListToReservationDTOList(reservations);
        }

        public async Task<ReservationDTO> GetReservationByIdAsync(int reservationId)
        {
            var reservationEntity = await _reservationRepository.GetReservationByIdAsync(reservationId);
            return MapReservationToReservationDTO(reservationEntity);
        }

        public async Task CreateReservationAsync(ReservationDTO reservationDTO)
        {
            var newReservation = MapReservationDTOToReservation(reservationDTO);
            await _reservationRepository.CreateReservationAsync(newReservation);
        }

        public async Task UpdateReservationAsync(int reservationId, ReservationDTO updatedReservationDTO)
        {
            var existingReservation = await _reservationRepository.GetReservationByIdAsync(reservationId);

            if (existingReservation == null)
            {
                // Reserva não encontrada - lançar uma exceção
                throw new NotFoundException($"Reserva com ID {reservationId} não encontrada.");
            }

            // Atualize os campos da reserva existente com base nos dados do DTO
            existingReservation.EventId = updatedReservationDTO.EventId;
            existingReservation.ReservationCode = updatedReservationDTO.ReservationCode;
            existingReservation.ReservedBy = updatedReservationDTO.ReservedBy;
            existingReservation.NumberOfTickets = updatedReservationDTO.NumberOfTickets;
            existingReservation.ReservationTime = updatedReservationDTO.ReservationTime;

            await _reservationRepository.UpdateReservationAsync(existingReservation);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            await _reservationRepository.DeleteReservationAsync(reservationId);
        }

        private List<ReservationDTO> MapReservationListToReservationDTOList(List<Reservation> reservations)
        {
            var reservationDTOList = new List<ReservationDTO>();

            foreach (var reservationEntity in reservations)
            {
                reservationDTOList.Add(MapReservationToReservationDTO(reservationEntity));
            }

            return reservationDTOList;
        }

        private ReservationDTO MapReservationToReservationDTO(Reservation reservationEntity)
        {
            return new ReservationDTO
            {
                Id = reservationEntity.Id,
                EventId = reservationEntity.EventId,
                ReservationCode = reservationEntity.ReservationCode,
                ReservedBy = reservationEntity.ReservedBy,
                NumberOfTickets = reservationEntity.NumberOfTickets,
                ReservationTime = reservationEntity.ReservationTime
            };
        }

        private Reservation MapReservationDTOToReservation(ReservationDTO reservationDTO)
        {
            return new Reservation
            {
                EventId = reservationDTO.EventId,
                ReservationCode = reservationDTO.ReservationCode,
                ReservedBy = reservationDTO.ReservedBy,
                NumberOfTickets = reservationDTO.NumberOfTickets,
                ReservationTime = reservationDTO.ReservationTime
            };
        }
    }
}
