namespace Gimji.DTO
{
    public class ReservationDTO
    {
        public int reservationId { get; set; }
        public string reservationStatus { get; set; }
        public DateTime bookingTime { get; set; }
        public DateTime? modifiedTime { get; set; }
        public string underName { get; set; }
        public int employeeId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int partySize { get; set; }
    }
}
