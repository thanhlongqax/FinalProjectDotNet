using Gimji.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DAO
{
    internal class CRUD_DetailOrder_DAO:DatabaseAccess
    {
        public void InsertChiTietHoaDon(Detail_Order detail_Order)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("insertChiTietHoaDon", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_mon_an", detail_Order.MonAnId);
                    command.Parameters.AddWithValue("@so_luong", detail_Order.SoLuong);
                    command.Parameters.AddWithValue("@don_gia", detail_Order.DonGia);
                    if(detail_Order.PhuongThucThanhToanId != 1 && detail_Order.PhuongThucThanhToanId != 2 && detail_Order.PhuongThucThanhToanId != 3)
                    {
                        detail_Order.PhuongThucThanhToanId = 1;
                    }
                    command.Parameters.AddWithValue("@id_phuong_thuc", detail_Order.PhuongThucThanhToanId);
                    command.Parameters.AddWithValue("@id_nhan_vien", Stored_Login_Infor.GetCurrentUser());
                    command.Parameters.AddWithValue("@trang_thai", detail_Order.trangThai);
                    command.Parameters.AddWithValue("@ten_khach_hang", detail_Order.customerName);
                    command.Parameters.AddWithValue("@ngay_lap", detail_Order.ngayLap);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
