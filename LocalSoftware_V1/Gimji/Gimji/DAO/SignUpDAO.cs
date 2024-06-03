using Gimji.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DTO;

namespace Gimji.DAO
{
    internal class SignUpDAO: DatabaseAccess
    {
        //code dang ki tu use
        public string signUp_DAO(Customer newUser)
        {
            try{
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                String sSQL = "select * from Khach_hang where ten_dang_nhap = @userName";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@userName", newUser.userName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    String anotherStringSQL = "exec InsertCusTomerLoginData @userName, @userPassword";
                    SqlCommand anotherCmd = new SqlCommand(anotherStringSQL, conn);
                    anotherCmd.Parameters.AddWithValue("@userName", newUser.userName);
                    anotherCmd.Parameters.AddWithValue("@userPassword", newUser.Password);
                    anotherCmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("    Đăng Ký Thành Công\nCHào Mừng Bạn Đến Gimji\n Mời Bạn Đăng Nhập", "Thông báo", MessageBoxButtons.OK);
                    return "Đăng ký tài khoản thành công";
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("Tài khoản đã được đăng ký trước đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Tài khoản đã được đăng ký trước đây";
                }
            }
            catch {
                MessageBox.Show("Không Đăng Ký Thành Công Vui Lòng Nhập Lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Đăng ký tài khoản Không Thành Công";
                
            }
            
        }
    }
}
