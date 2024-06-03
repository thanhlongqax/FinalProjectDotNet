using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Detail_Order
    {
        public int Id { get; set; }
        public int MonAnId { get; set; }
        public int SoLuong { get; set; }
        public int Catergory_Id { get; set; }
        public double DonGia { get; set; }
        public int PhuongThucThanhToanId { get; set; }
        public string NhanVienId {  get; set; }
        public string customerName { get; set; }
        public string trangThai { get; set; }
        public DateTime ngayLap { get; set; }

    }
}
