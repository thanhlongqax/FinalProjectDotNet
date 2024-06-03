using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Gimji.DTO;
using System.Data;
using System.Net.Mail;

namespace Gimji.DAO
{
    internal class ForgotPasswordDAO : DatabaseAccess
    {
        public String checkGmail_Database(String gmail)
        {

            String userName_Password ="";
            SqlConnection conn = new SqlConnection(strConn);
            bool checkGmail = false;

            conn.Open();

            string sSQL = @"
                SELECT id_admin, ten_dang_nhap, mat_khau FROM Admin WHERE email = @email
                UNION ALL
                SELECT id_khach_hang, ten_dang_nhap, mat_khau FROM Khach_hang WHERE email = @email
                UNION ALL
                SELECT id_nhan_vien, ten_dang_nhap, mat_khau FROM Nhan_vien WHERE email = @email;
            ";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@email", gmail);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string id_tai_khoan = reader.GetString(0);
                    string ten_dang_nhap = reader.GetString(1);
                    string matKhau = reader.GetString(2);
                    checkGmail = true;
                    userName_Password = ten_dang_nhap + "_" +matKhau;
                }
            }

            reader.Close();
            conn.Close();

            if (!checkGmail)
            {
                MessageBox.Show("Gmail khong chinh xac", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Gmail address not found in the database
                return null;
            }

            return userName_Password;
        }
    }
}
