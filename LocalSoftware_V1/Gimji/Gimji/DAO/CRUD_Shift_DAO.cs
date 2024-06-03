using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Gimji.DAO
{
    internal class CRUD_Shift_DAO :DatabaseAccess
    {
        public List<Shift> GetAllShift_DAO()
        {
            List<Shift> listShift = new List<Shift>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "SELECT * FROM Ca_lam";
            SqlDataAdapter da = new SqlDataAdapter(sSQL, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Shift shift = new Shift
                    {
                        shiftID = row["id_ca"].ToString(),
                        shiftName = row["ca_lam"].ToString(),
                        dateTime = DateTime.TryParse(row["ngay_lam"].ToString(), out DateTime dateStart) ? dateStart : DateTime.MinValue,
                        staffName = GetStaffNameById(row["nhan_vien_id"].ToString()),
                        note = row["note"].ToString(),
                        staffID = row["nhan_vien_id"].ToString(),

                    };
                    listShift.Add(shift);
                }
            }

            return listShift;

        }
        public string GetStaffNameById(string staffId)
        {
            string staffName = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();
                    string query = "SELECT ten_nhan_vien FROM Nhan_vien WHERE id_nhan_vien = @StaffId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffId", staffId);

                        // Execute the query and get the staff name
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                staffName = reader["ten_nhan_vien"].ToString(); // Assuming "Ten_nhan_vien" is the column containing staff names
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or display messages if needed
                Console.WriteLine("Error: " + ex.Message);
            }

            return staffName;
        }

        public Shift GetShilftByInfor_DAO(String shift, String staffID, DateTime date)
        {
            Shift resultShift = null;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "SELECT id_ca,note, ca_lam, ngay_lam, nhan_vien_id FROM Ca_lam " +
                            "WHERE id_ca = @shift AND nhan_vien_id = @staffID AND ngay_lam = @date";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@shift", shift);
            cmd.Parameters.AddWithValue("@staffID", staffID);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Assuming your Shift class has a constructor that takes the necessary parameters
                resultShift = new Shift
                {
                    shiftID = reader["id_ca"].ToString(),
                    note = reader["note"].ToString(),
                    // Assign other properties accordingly
                    staffID = reader["nhan_vien_id"].ToString(),
                    dateTime = Convert.ToDateTime(reader["ngay_lam"])
                };
                

            reader.Close();
            }

            return resultShift;
            
        }
        public Shift GetShilftByID_DAO(String shiftID)
        {
            Shift resultShift = null;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = @"SELECT * FROM Ca_lam WHERE id_ca = @shift";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@shift", shiftID);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Assuming your Shift class has a constructor that takes the necessary parameters
                resultShift = new Shift
                {
                    shiftID = reader["id_ca"].ToString(),
                    note = reader["note"].ToString(),
                    // Assign other properties accordingly
                    staffID = reader["nhan_vien_id"].ToString(),
                    dateTime = Convert.ToDateTime(reader["ngay_lam"])
                };


                reader.Close();
            }

            return resultShift;

        }
        public void AddShift_DAO(Shift shift)
        {

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand("Insert_Ca_lam", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@p_ca_lam",shift.shiftName );
                    cmd.Parameters.AddWithValue("@p_note", shift.note);
                    cmd.Parameters.AddWithValue("@p_ngay_lam",shift.dateTime );
                    cmd.Parameters.AddWithValue("@p_nhan_vien_id",shift.staffID);
                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();
                }
                
                MessageBox.Show("Thêm Nhan Vien Vao Ca Làm Thành Công", "Thông báo", MessageBoxButtons.OK);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Replace 50000 with your actual error number
                {
                    // Handle the case where the trigger raised an error (staff ID does not exist)
                    MessageBox.Show("Nhân viên không tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 50002) // Replace 50000 with your actual error number
                {
                    // Handle the case where the trigger raised an error (staff ID does not exist)
                    MessageBox.Show("Nhân viên trong ca đã quá 3 người ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 50001) // Replace 50000 with your actual error number
                {
                    // Handle the case where the trigger raised an error (staff ID does not exist)
                    MessageBox.Show("Nhân viên đã đăng kí ca làm này ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Handle other SQL exceptions
                    //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                conn.Close();
            }


        }
        public void UpdateShift_DAO(Shift shift) 
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            //  UPDATE
            string updateSql = @"
                UPDATE Ca_lam
                SET note = @note,
                ca_lam = @ca_lam,
                ngay_lam = @ngay_lam,
                nhan_vien_id = @nhan_vien_id
                WHERE id_ca = @id_ca
            ";
            SqlCommand updateCmd = new SqlCommand(updateSql, conn);
            updateCmd.Parameters.AddWithValue("@note", shift.note);
            updateCmd.Parameters.AddWithValue("@ca_lam", shift.shiftName);
            updateCmd.Parameters.AddWithValue("@ngay_lam", shift.dateTime);
            updateCmd.Parameters.AddWithValue("@nhan_vien_id", shift.staffID);
            updateCmd.Parameters.AddWithValue("@id_ca", shift.shiftID);

            updateCmd.ExecuteNonQuery();

            MessageBox.Show("Cập nhật Ca Làm Thành Công", "Thông báo", MessageBoxButtons.OK);
           
            
            conn.Close();
        }
        public void DeleteShiftById_DAO(String idShift)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string deleteSql = "DELETE FROM Ca_lam WHERE id_ca = @idShift";
                SqlCommand deleteCmd = new SqlCommand(deleteSql, conn);
                deleteCmd.Parameters.AddWithValue("@idShift", idShift);
                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa ca làm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Xóa ca làm không thành công", "Thông báo", MessageBoxButtons.OK);
                }
             conn.Close();  
            }
            
        }


    }
}
