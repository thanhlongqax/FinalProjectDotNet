using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class CartItem
    {
        public int Id { get; set; }
        public int IdMonAn { get; set; }
        public int Catergory_Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string DishPicture { get; set; }
    }
}
