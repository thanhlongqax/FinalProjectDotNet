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
    internal class CRUD_Dish_DAO : DatabaseAccess
    {

        // Lấy Tất Cả Các Món Ăn ra________________________________________________________________________
        public List<Dish> GetAllDish_DAO()
        {
            List<Dish> listDish = new List<Dish>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "SELECT * FROM Mon_an;";
            SqlDataAdapter da = new SqlDataAdapter(sSQL, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Dish dish = new Dish
                    {
                        DishId = Convert.ToInt32(row["id_mon_an"]),
                        DishName = row["ten_mon_an"].ToString(),
                        DishPrice = Convert.ToDouble(row["don_gia"]),
                        DishPicture = row["hinh_anh"].ToString(),
                        Dish_Availible = row["tinh_trang"].ToString(),
                        Catergory_Id = Convert.ToInt32(row["id_danh_muc"])
                    };
                    listDish.Add(dish);
                }
            }

            return listDish;
        }

        // _______________________________________________________________________________________________________

        // Lấy ra Món Ăn theo ID________________________________________________________________________
        public Dish GetDishById_DAO(int dishId)
        {
            Dish dish = null;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "SELECT * FROM Mon_an WHERE id_mon_an = @DishId;";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@DishId", dishId);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                dish = new Dish
                {
                    DishId = Convert.ToInt32(row["id_mon_an"]),
                    DishName = row["ten_mon_an"].ToString(),
                    DishPrice = Convert.ToDouble(row["don_gia"]),
                    DishPicture = row["hinh_anh"].ToString(),
                    Dish_Availible = row["tinh_trang"].ToString(),
                    Catergory_Id = Convert.ToInt32(row["id_danh_muc"])

                };
                conn.Close();
            }
            else {
                conn.Close();
            }            
            return dish;
        }

        // _______________________________________________________________________________________________________

        // Lấy ra Món Ăn theo ID________________________________________________________________________
        public List<Dish> GetDishesByCategoryId_DAO(int categoryId)
        {
            List<Dish> listDish = new List<Dish>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "SELECT * FROM Mon_an WHERE id_danh_muc = @CategoryId;";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Dish dish = new Dish
                {
                    DishId = Convert.ToInt32(row["id_mon_an"]),
                    DishName = row["ten_mon_an"].ToString(),
                    DishPrice = Convert.ToDouble(row["don_gia"]),
                    DishPicture = row["hinh_anh"].ToString(),
                    Dish_Availible = row["tinh_trang"].ToString(),
                    Catergory_Id = Convert.ToInt32(row["id_danh_muc"])
                };
                listDish.Add(dish);
            }

            conn.Close();
            return listDish;
        }

        // _______________________________________________________________________________________________________
        // Thêm 1 Món Ăn________________________________________________________________________
        public void addDish_DAO(Dish newDish)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            // Kiểm tra xem món ăn đã tồn tại dựa trên tên món ăn
            string checkIfExistsSQL = "SELECT COUNT(*) FROM Mon_an WHERE ten_mon_an = @TenMonAn";
            SqlCommand checkCmd = new SqlCommand(checkIfExistsSQL, conn);
            checkCmd.Parameters.AddWithValue("@TenMonAn", newDish.DishName);

            int existingDishCount = (int)checkCmd.ExecuteScalar();

            if (existingDishCount == 0)
            {
                string insertSql = @"
                    INSERT INTO Mon_an (ten_mon_an, don_gia, hinh_anh, tinh_trang, id_danh_muc)
                    VALUES (@TenMonAn, @DonGia, @HinhAnh, @TinhTrang, @IdDanhMuc)
                ";
                SqlCommand cmd = new SqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@TenMonAn", newDish.DishName);
                cmd.Parameters.AddWithValue("@DonGia", newDish.DishPrice);
                if (newDish.DishPicture == null) {
                    newDish.DishPicture = "Resources/AnhMonAn/Default.jpg";
                }
                cmd.Parameters.AddWithValue("@HinhAnh", newDish.DishPicture);
                cmd.Parameters.AddWithValue("@TinhTrang", newDish.Dish_Availible);
                cmd.Parameters.AddWithValue("@IdDanhMuc", newDish.Catergory_Id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm Món Ăn Thành Công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Món Ăn đã tồn tại, không thể thêm", "Thông báo", MessageBoxButtons.OK);
            }

            conn.Close();
        }

        // _______________________________________________________________________________________________________

        // Chỉnh Sửa Các Món Ăn ra________________________________________________________________________
        public void updateDish_DAO(Dish updatedDish)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            // Kiểm tra xem món ăn có tồn tại trong cơ sở dữ liệu hay không
            string selectSql = @"SELECT id_mon_an FROM Mon_an WHERE id_mon_an = @DishId ";
            SqlCommand selectCmd = new SqlCommand(selectSql, conn);
            selectCmd.Parameters.AddWithValue("@DishId", updatedDish.DishId);
            object result = selectCmd.ExecuteScalar();
            if (result != null)
            {
                // Món ăn tồn tại, thực hiện truy vấn UPDATE
                string updateSql = @"
                    UPDATE Mon_an
                    SET ten_mon_an = @TenMonAn,
                    don_gia = @DonGia,
                    hinh_anh = @HinhAnh,
                    tinh_trang = @TinhTrang,
                    id_danh_muc = @IdDanhMuc
                    WHERE id_mon_an = @DishId
                ";
                SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@DishId", updatedDish.DishId);
                updateCmd.Parameters.AddWithValue("@TenMonAn", updatedDish.DishName);
                updateCmd.Parameters.AddWithValue("@DonGia", updatedDish.DishPrice);
                if (updatedDish.DishPicture == null)
                {
                    updatedDish.DishPicture = "Resources/AnhMonAn/Default.jpg";
                }
                updateCmd.Parameters.AddWithValue("@HinhAnh", updatedDish.DishPicture);
                updateCmd.Parameters.AddWithValue("@TinhTrang", updatedDish.Dish_Availible);
                updateCmd.Parameters.AddWithValue("@IdDanhMuc", updatedDish.Catergory_Id);

                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật Thực Đơn Thành Công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Món ăn không tồn tại, không thể cập nhật", "Thông báo", MessageBoxButtons.OK);
            }

            conn.Close();
        }
        // _______________________________________________________________________________________________________
        // Xóa Món Ăn ra________________________________________________________________________
        public void DeleteDishById_DAO(int dishId)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                // Kiểm tra xem món ăn tồn tại trong cơ sở dữ liệu dựa trên ID
                string checkSql = "SELECT COUNT(*) FROM Mon_an WHERE id_mon_an = @DishId";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@DishId", dishId);

                int dishCount = (int)checkCmd.ExecuteScalar();

                if (dishCount > 0)
                {
                    // Món ăn tồn tại, thực hiện xóa
                    string deleteSql = "DELETE FROM Mon_an WHERE id_mon_an = @DishId";
                    SqlCommand deleteCmd = new SqlCommand(deleteSql, conn);
                    deleteCmd.Parameters.AddWithValue("@DishId", dishId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa món ăn thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Xóa món ăn không thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy món ăn có ID " + dishId, "Thông báo", MessageBoxButtons.OK);
                }
            }
        }
        // _______________________________________________________________________________________________________

    }

}
