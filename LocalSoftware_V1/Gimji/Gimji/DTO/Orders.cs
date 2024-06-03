using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Orders
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int Quantity { get; set; }
        public string IdNhanVien { get; set; }
        public String status {get; set; }
    }
}
