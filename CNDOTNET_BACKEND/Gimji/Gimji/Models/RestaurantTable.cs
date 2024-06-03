using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimji.Models
{
    [Table("RestaurantTable")]
    public class RestaurantTable
    {
        [Key]
        [Column("tableId")]
        public int TableNumber { get; set; } // Số bàn
        [Column("tableName")]
        [Required]
        public string TableName { get; set; }   
        [Required]
        public bool IsOccupied { get; set; } // Trạng thái: đang được sử dụng hay không
        [Required]
        public bool IsReserved { get; set; } // Trạng thái: đã được đặt trước hay không
        public virtual ICollection<FoodEstablishmentReservation> Reservations { get; set; }
    }
}
