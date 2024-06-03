using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Bill
    {
        public int BillID { get; set; }
        public DateTime billDateIn { get; set;}

        public float billAmount { get; set; }
        public int staffId { get; set; }

        public int userId { get; set; }
    }
}
