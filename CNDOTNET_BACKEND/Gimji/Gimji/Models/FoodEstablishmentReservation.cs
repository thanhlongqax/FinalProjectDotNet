using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimji.Models
{
    [Table("reservation")]
    public class FoodEstablishmentReservation
    {
        [Key]
        [Column("reservationId")]
        [MaxLength(30, ErrorMessage = "id không dài quá 30 kí tự")]
        public int reservationId { get; set; }
        [Required]
        public string reservationStatus { get; set; }
        [Required]
        public DateTime bookingTime { get; set; }

        public DateTime? modifiedTime { get; set; }
        [Required]
        public string underName { get; set; }
        [Column("provider")]
        public employee provider { get; set; }
        [Required]
        public DateTime startTime { get; set; }
        [Required]
        public DateTime endTime { get; set; }
        [Required]
        public int partySize { get; set; }
        

    }
}
