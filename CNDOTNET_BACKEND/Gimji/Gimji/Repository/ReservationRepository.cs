using Gimji.DTO;
using Gimji.Models;

namespace Gimji.Repository
{
    public interface ReservationRepository
    {
        Task<bool> DoesItemExist(string id);
        Task<IEnumerable<FoodEstablishmentReservation>> GetAllReservation();
        Task<FoodEstablishmentReservation> GetReservationById(int id);
        Task<FoodEstablishmentReservation> GetReservationByStatus(string status);
        Task AddReservation(ReservationDTO reservationDTO);
        Task UpdateReservation(int id, ReservationDTO reservationDTO);
        Task DeleteReservation(int id);
    }
}
