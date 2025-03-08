using Gimji.Models;

namespace Gimji.DTO
{
    public class ProductDTO
    {
        public string productID { get; set; }
        public string name { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string description { get; set; }
        public string nsn  { get; set; }
        public double price { get; set; }
        public string categoryId { get; set; }
    }
}
