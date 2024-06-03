using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Delivery
    {
        public int DeliveryId { get; set; }

        public DateTime DeliveryDateIn { get; set; }
        public int StatusDelivery { get; set; }
        public string Address_Delivery { get; set; }

        public string note_Delivery { get; set; }

        public float total_Amount { get; set; }
        public int userId { get; set; }



    }
}
