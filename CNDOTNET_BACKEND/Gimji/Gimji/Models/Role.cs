using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimji.Models
{
    [Table("role")]
    public class Role
    {

        [Key]
        [Column("id")]
        public int numberedPosition {  get; set; }
        [Required]
        public string roleName {  get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public float salaryCurrency { get; set; }
        public virtual ICollection<employee> Employees { get; set; }
    }
}
