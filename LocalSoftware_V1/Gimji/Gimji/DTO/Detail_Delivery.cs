using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Detail_Delivery
    {
        public int Detail_DeliveryId { get; set; }

        public int DeliveryId { get; set; }
        public string foodID { get; set; }
        public int quanity { get; set; }
        public string DeliveryName { get; set; }

    }
}
