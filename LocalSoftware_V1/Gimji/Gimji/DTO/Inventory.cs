using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Inventory
    {
        public string foodName { get; set; }
        public string type { get; set; }
        public double available { get; set; }
        public double sold { get; set; }
        public string status { get; set; }
        public double price { get; set; }
        public string inventoryPicture { get; set; }
    }
}
