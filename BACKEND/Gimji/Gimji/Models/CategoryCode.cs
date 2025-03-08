using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimji.Models
{
    [Table("category")]
    public class CategoryCode
    {
        [Key]
        [Column("id")]
        public string CodeValue { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}
