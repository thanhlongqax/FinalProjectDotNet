using Gimji.Data;
using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gimji.Services
{
    public class ReservationService : ReservationRepository
    {
        private MyPostgresDbContext dbContext;
        private EmployeeRepository employeeRepository;
        public ReservationService(MyPostgresDbContext dbContext ,EmployeeRepository employeeRepository)
        {
            this.dbContext = dbContext;
            this.employeeRepository = employeeRepository;
        }
        public async Task AddReservation(ReservationDTO reservationDTO)
        {
            await dbContext.reservations.AddAsync(await MapDTO(reservationDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteReservation(int id)
        {
            dbContext.reservations.Remove(await dbContext.reservations.FindAsync(id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await dbContext.reservations.FindAsync(id) != null;
        }

        public async Task<IEnumerable<FoodEstablishmentReservation>> GetAllReservation()
        {
            return await dbContext.reservations.ToListAsync();
        }

        public async Task<FoodEstablishmentReservation> GetReservationById(int id)
        {
            return await dbContext.reservations.FirstOrDefaultAsync(item => item.reservationId == id);
        }

        public async Task<FoodEstablishmentReservation> GetReservationByStatus(string status)
        {
            return await dbContext.reservations.FirstOrDefaultAsync(item => item.reservationStatus == status);
        }

        public async Task UpdateReservation(int id, ReservationDTO reservationDTO)
        {
            var reservation_Update = await dbContext.reservations.FindAsync(id);
            if(reservation_Update != null)
            {
                reservation_Update = await MapDTO(reservationDTO);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Khong tim thay dat cho");
            }

        }
        public async Task<FoodEstablishmentReservation> MapDTO(ReservationDTO reservationDTO)
        {
            return new FoodEstablishmentReservation
            {
                reservationId = reservationDTO.reservationId,
                reservationStatus = reservationDTO.reservationStatus,
                bookingTime = reservationDTO.bookingTime,
                modifiedTime = reservationDTO.modifiedTime,
                underName = reservationDTO.underName,
                provider = await employeeRepository.GetEmployeeById(reservationDTO.employeeId),
                startTime = reservationDTO.startTime,
                endTime = reservationDTO.endTime,
                partySize = reservationDTO.partySize
            };
        }
    }
}
