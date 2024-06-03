using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimji.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("productID")]
        public string productID { get; set; }
        public string name { get; set; }
        public string image1 {  get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string nsn { get; set; } /*số lượng tồn kho */

        public CategoryCode category { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }


    }
}
