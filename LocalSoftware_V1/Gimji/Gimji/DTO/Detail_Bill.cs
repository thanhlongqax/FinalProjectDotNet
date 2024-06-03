using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Detail_Bill
    {
        public int Detail_BillID { get; set; }
        public int Bill_ID { get; set;}

        public string foodID { get; set; }

        public int quanity { get; set; }
        public float total_Amount { get; set; }

        public int paymentID { get; set; }


    }
}
