using Gimji.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.DAO
{
    internal class CRUD_Customer_DAO : DatabaseAccess
    {
        // lay tat ca nhan vien _____________________________________________________________________________________________
        public List<Customer> getAllCustomer_DAO()
        {
            List<Customer> customerList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sSQL = "SELECT * FROM Khach_hang";
                using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Customer customer = new Customer
                            {
                                Id = row["id_khach_hang"].ToString(),
                                userName = row["ten_dang_nhap"].ToString(),
                                Password = row["mat_khau"].ToString(),
                                fullName = row["ten_khach_hang"].ToString(),
                                DateOfBirth = DateTime.TryParse(row["ngay_sinh"].ToString(), out DateTime dateOfBirth) ? dateOfBirth : DateTime.MinValue,
                                Gender = row["gioi_tinh"].ToString(),
                                phoneNumber = row["so_dien_thoai"].ToString(),
                                contactAddress = row["dia_chi"].ToString(),
                                Email = row["email"].ToString(),
                                Point = row.Field<int>("diem_thuong"),
                                Type = row["loai_tai_khoan"].ToString()
                            };
                            customerList.Add(customer);
                        }
                    }
                }
            }
            return customerList;
        }

        // _____________________________________________________________________________________________
        // lay tat ca nhan vien _____________________________________________________________________________________________
        public Customer getStaffById_DAO(String customerId)
        {
            Customer customer = null; // Khởi tạo staff là null.
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "SELECT * FROM Khach_hang WHERE id_khach_hang = @customerId";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                customer = new Customer
                {
                    Id = row["id_khach_hang"].ToString(),
                    userName = row["ten_dang_nhap"].ToString(),
                    Password = row["mat_khau"].ToString(),
                    fullName = row["ten_khach_hang"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["ngay_sinh"]),
                    Gender = row["gioi_tinh"].ToString(),
                    phoneNumber = row["so_dien_thoai"].ToString(),
                    contactAddress = row["dia_chi"].ToString(),
                    Email = row["email"].ToString(),
                    Point = Convert.ToInt32(row["diem_thuong"]),
                    Type = row["loai_tai_khoan"].ToString()
                };
            }
            else if (dt.Rows.Count == 0) {
                return null;
            }

            return customer;
        }
        // _____________________________________________________________________________________________

        //Thêm 1 user _____________________________________________________________________________________________

        public void AddCustomer_DAO(Customer newCustomer)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            // Check if the username already exists
            string checkUsernameSQL = "SELECT COUNT(*) FROM Khach_hang WHERE ten_dang_nhap = @userName";
            SqlCommand checkUsernameCmd = new SqlCommand(checkUsernameSQL, conn);
            checkUsernameCmd.Parameters.AddWithValue("@userName", newCustomer.userName);
            int usernameExists = (int)checkUsernameCmd.ExecuteScalar();

            if (usernameExists == 0)
            {
                // The username does not exist, so you can proceed with the insertion
                using (SqlCommand cmd = new SqlCommand("InsertCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@ten_dang_nhap", newCustomer.userName);
                    cmd.Parameters.AddWithValue("@mat_khau", newCustomer.Password);
                    cmd.Parameters.AddWithValue("@ten_khach_hang", newCustomer.fullName);
                    cmd.Parameters.AddWithValue("@ngay_sinh", newCustomer.DateOfBirth);
                    cmd.Parameters.AddWithValue("@gioi_tinh", newCustomer.Gender);
                    cmd.Parameters.AddWithValue("@so_dien_thoai", newCustomer.phoneNumber);
                    cmd.Parameters.AddWithValue("@dia_chi", newCustomer.contactAddress);
                    cmd.Parameters.AddWithValue("@email", newCustomer.Email);
                    cmd.Parameters.AddWithValue("@diem_thuong", newCustomer.Point);
                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Thêm Tài Khoản Khách Hàng Thành Công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                conn.Close();
                MessageBox.Show("Tài khoản đã được đăng ký trước đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //________________________________________________________________________________________________________________

        //Cập Nhật user _____________________________________________________________________________________________
        public void UpdateCustomer_DAO(Customer customer)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateCustomerById", conn); // Assuming you have a stored procedure named "UpdateCustomerById"
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_khach_hang", customer.Id);
            cmd.Parameters.AddWithValue("@ten_dang_nhap", customer.userName);
            cmd.Parameters.AddWithValue("@mat_khau", customer.Password);
            cmd.Parameters.AddWithValue("@ten_khach_hang", customer.fullName);
            cmd.Parameters.AddWithValue("@ngay_sinh", customer.DateOfBirth);
            cmd.Parameters.AddWithValue("@gioi_tinh", customer.Gender);
            cmd.Parameters.AddWithValue("@so_dien_thoai", customer.phoneNumber);
            cmd.Parameters.AddWithValue("@dia_chi", customer.contactAddress);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@diem_thuong", customer.Point);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Cập Nhật Thông Tin Khách Hàng Thành Công", "Thông báo", MessageBoxButtons.OK);
        }

        //________________________________________________________________________________________________________________


        //Xóa 1 user _______________________________________________________________________________________________

        public void deleteCustomer_DAO(String id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "DELETE FROM Khach_hang WHERE id_khach_hang = @id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        //________________________________________________________________________________________________________________
    }
}
