using Gimji.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DAO
{
    internal class CRUD_CartItem_DAO:DatabaseAccess
    {
        public List<CartItem> getAllCartItemById_DAO(string IdTaiKhoan)
        {
            List<CartItem> listCartItem = new List<CartItem>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("GetCartItemsByIdTaiKhoan", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdTaiKhoan", IdTaiKhoan);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            CartItem cartItem = new CartItem
                            {
                                Id = Convert.ToInt32(row["Id"]),
                                IdMonAn = Convert.ToInt32(row["id_mon_an"]),
                                Name = row["Name"].ToString(),
                                Price = Convert.ToDouble(row["Price"]),
                                Quantity = Convert.ToInt32(row["Quantity"]),
                                DishPicture = row["hinh_anh"].ToString()
                            };
                            listCartItem.Add(cartItem);
                        }
                    }
                }
            }

            return listCartItem;
        }
        public void InsertCartItem(CartItem cartItem)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("InsertCartItem", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdTaiKhoan", Stored_Login_Infor.GetCurrentUser());
                    command.Parameters.AddWithValue("@IdMonAn", cartItem.IdMonAn);
                    command.Parameters.AddWithValue("@Name", cartItem.Name);
                    command.Parameters.AddWithValue("@Price", cartItem.Price);
                    command.Parameters.AddWithValue("@hinh_anh", cartItem.DishPicture); // Assuming DishPicture is the property name for hinh_anh
                    command.Parameters.AddWithValue("@Quantity", cartItem.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteCartItemById(int cartItemId)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("DeleteCartItemById", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", cartItemId);

                    command.ExecuteNonQuery();
                }
            }
        }




    }
}
