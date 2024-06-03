using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Gimji.DTO;

namespace Gimji.DAO
{
    internal class LoginDAO :DatabaseAccess
    {
        public Dictionary<string, string> checkLoginData_Database(Customer tk)
        {

            Dictionary<string, string> idtaiKhoan_userName = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(strConn);
            Boolean Check_tk = false;
            conn.Open();

            string sSQL = @"
                SELECT id_admin, ten_dang_nhap, mat_khau FROM Admin
                UNION ALL
                SELECT id_khach_hang, ten_dang_nhap, mat_khau FROM Khach_hang
                UNION ALL
                SELECT id_nhan_vien, ten_dang_nhap, mat_khau FROM Nhan_vien;
            ";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    string id_tai_khoan = reader.GetString(0);
                    String ten_dang_nhap = reader.GetString(1);
                    string matKhau = reader.GetString(2);
                    if (tk.userName == ten_dang_nhap && tk.Password == matKhau)
                    {
                        Check_tk = true;
                        idtaiKhoan_userName.Add(id_tai_khoan, ten_dang_nhap);
                    }
                }
                // Kiểm tra thông tin đăng nhập
            }

            reader.Close();
            conn.Close();

            if (Check_tk == false)
            {
                return new Dictionary<string, string>();
            }
            return idtaiKhoan_userName;
        }

        public  string LoginDAO_checkLoginData(Customer tk)
        {
            Dictionary<string, string> result = checkLoginData_Database(tk);
            String id = null;
            if (result.Count == 0)
            {
                MessageBox.Show("Mật khẩu không chính xác hoặc tài khoản không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Trả về giá trị null hoặc giá trị phù hợp tùy vào logic của bạn.
            }
            // Xử lý các trường hợp khác ở đây.
            foreach (KeyValuePair<string, string> item in result)
            {
                  id = item.Key;
            }
            return id;
        }

        /*public DataTable populateInformationUser_Login_DAL(string userID)
        {
            if (populateInformationUser_DA_DAL(userID) == null)
            {
                return null;
            }
            else
            {
                return populateInformationUser_DA_DAL(userID);
            }
        }
        public DataTable populateProvince_Login_DAL()
        {
            if (populateProvince_DA_DAL() == null)
            {
                return null;
            }
            else
            {
                return populateProvince_DA_DAL();
            }
        }*/
    }
}
