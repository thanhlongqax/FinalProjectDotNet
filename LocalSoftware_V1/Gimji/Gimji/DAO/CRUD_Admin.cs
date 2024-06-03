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
    internal class CRUD_Admin : DatabaseAccess
    {
        public void UpdateAdmin_DAO(Admin newAdmin)
        {


            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from Nhan_vien where ten_dang_nhap = @userName";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@userName", newAdmin.userName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("add Staff :" + newAdmin.fullName);
                String anotherSQL = "exec @proc @fullName,@emailAddress,@contactAddress,@userName,@userPassword ,@DateOfBirth , @phoneNumber";
                SqlCommand anotherCmd = new SqlCommand(anotherSQL, conn);
                anotherCmd.Parameters.AddWithValue("@fullName", newAdmin.fullName);
                anotherCmd.Parameters.AddWithValue("@emailAddress", newAdmin.Email);
                anotherCmd.Parameters.AddWithValue("@phoneNumber", newAdmin.phoneNumber);
                anotherCmd.Parameters.AddWithValue("@userName", newAdmin.userName);
                anotherCmd.Parameters.AddWithValue("@userPassword", newAdmin.userPassword);
                cmd.Parameters.AddWithValue("@proc", "InsertStaffLoginData");
                anotherCmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("    Thêm Tài Khoản Nhân Viên Thành Công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                conn.Close();
                MessageBox.Show("Tài khoản đã được đăng ký trước đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
