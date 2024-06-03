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
    internal class CRUD_Order_DAO:DatabaseAccess
    {
        public List<Orders> GetAllOrder()
        {
            List<Orders> orders = new List<Orders>();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("getAllHoaDon", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders order = new Orders
                            {
                                Id = Convert.ToInt32(reader["id_hoa_don"]),
                                StartDate = Convert.ToDateTime(reader["ngay_lap"]),
                                Quantity = Convert.ToInt32(reader["so_luong"]),
                                IdNhanVien = reader["id_nhan_vien"].ToString(),
                            };

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

        public void InsertHoaDon(Orders order)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("insertHoaDon", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ngay_lap", order.StartDate);
                    command.Parameters.AddWithValue("@so_luong", order.Quantity);
                    command.Parameters.AddWithValue("@id_nhan_vien", order.IdNhanVien);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateHoaDon(Orders order)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("updateHoaDon", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_hoa_don", order.Id);
                    command.Parameters.AddWithValue("@ngay_lap", order.StartDate);
                    command.Parameters.AddWithValue("@so_luong", order.Quantity );
                    command.Parameters.AddWithValue("@id_nhan_vien", order.IdNhanVien);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteHoaDon(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("deleteHoaDon", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_hoa_don", orderId);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
