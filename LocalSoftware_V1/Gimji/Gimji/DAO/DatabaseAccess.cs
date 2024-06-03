using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gimji.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
using System.Net;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace Gimji.DAO
{
    internal class DatabaseAccess
    {
        public static String  strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        //Code lay id tu ten truyen vao 
        public String getIdByUsername_DAO(String name)
        {
            String userID = "";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from Khach_Hang where ten_khach_hang = '" + name + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            foreach (DataRow row in dt.Rows)
            {
                userID = row["id_khach_hang"].ToString();
            }
            return userID;
        }


        //______________________________________

        //Code lay ra id tu truyen id vao 

        public DataTable getUserById_DA_DAO(String id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = @"
                SELECT * FROM Khach_hang
                UNION ALL
                SELECT * FROM Nhan_vien
                where id_tai_khoan = @id;
            ";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        /*public DataTable populateHistoryDetail_DA_DAL(string orderUserID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from HistoryUserDataDetail where orderUserID = '" + orderUserID + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable populateStoreAddress_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from StoreAddress";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public void payMoney(string userID, int totalCash, string storeName)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "exec PayMoney '" + userID + "', " + totalCash.ToString() + ", N'" + storeName + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable populateProvince_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from Province";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public string checkLoginData_DA_DAL(User tk)
        {
            string userName = null;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from LoginData where userName = @userName and userPassword = @userPassword";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@userName", tk.userName);
            cmd.Parameters.AddWithValue("@userPassword", tk.userPassword);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userName = reader.GetString(5);
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                reader.Close();
                conn.Close();
                return "Thông tin đăng nhập không chính xác!";
            }
            return userName;
        }
        public DataTable populateMenuData_DA_DAL(string type)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from MenuData where dishType = '" + type + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable populateInformationUser_DA_DAL(string userID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from LoginData where userID = '" + userID + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public void updateCartDataPromotion_DA_DAL(string promotionID, string promotionCash, string userID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                String sSQL = "update CartData set promotionID = '" + promotionID + "', promotionCash = " + promotionCash + " where userID = '" + userID + "'";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Áp dụng khuyến mãi không thành công");
            }
        }
        public DataTable getTotalQuantityOfDish_DA_DAL(string dishID, string userID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select totalQuantity from MenuData, CartData, LoginData where CartData.dishID = MenuData.dishID and CartData.userID = LoginData.userID and CartData.dishID = @dishID and CartData.userID = @userID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@dishID", dishID);
            cmd.Parameters.AddWithValue("@userID", userID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable populateCartData_DA_DAL(string userID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from CartData where userID = '" + userID + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public void insertIntoCartData_DA_DAL(string dishID, string dishPicture, string dishName, int dishPrice, int totalQuantity, string userID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                String sSQL = "insert into CartData(dishID, dishPicture, dishName, dishPrice, totalQuantity, userID) values (@dishID, @dishPicture, @dishName, @dishPrice, @totalQuantity, @userID)";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@dishID", dishID);
                cmd.Parameters.AddWithValue("@dishPicture", dishPicture);
                cmd.Parameters.AddWithValue("@dishName", dishName);
                cmd.Parameters.AddWithValue("@dishPrice", dishPrice);
                cmd.Parameters.AddWithValue("@totalQuantity", totalQuantity);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Đã thêm vào giỏ hàng");
            }
            catch
            {
                MessageBox.Show("Mặt hàng đã có trong giỏ hàng của bạn");
            }
        }
        public void updateCartData_DA_DAL(string dishID, int totalQuantity, string userID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                String sSQL = "update CartData set totalQuantity = @totalQuantity where dishID = @dishID and userID = @userID";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@dishID", dishID);
                cmd.Parameters.AddWithValue("@totalQuantity", totalQuantity);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật số lượng không thành công");
            }
        }
        public void deleteCartItem_DA_DAL(string id, string userID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "delete from CartData where dishID = '" + id + "'" + "and userID = '" + userID + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable populatePromotionData_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from PromotionData";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable populateStoreAddressData_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from StoreAddress";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        //Data admin page user
        public DataTable getAllUser_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from LoginData";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable searchUser_DA_BLL(String key, String cn)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            DataTable dt = new DataTable();
            if (cn.Equals("null") || key.Equals("null"))
            {
                String sSQL = "select * from LoginData";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            else
            {
                String sSQL = "select distinct LoginData.*,UserAddress.storeID from LoginData,UserAddress  Where (fullName like '%" + key + "%' or fullName like '" + key + "%') and UserAddress.storeID = '" + cn + "'and LoginData.userID= UserAddress.userID  ";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public void deleteUser_DA_BLL(String id)
        {
            MessageBox.Show("Delete id :" + id);
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "delete from LoginData where userID = @id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfuly");
        }
        public void updateUser_DA_BLL(User user)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "update LoginData set fullName=@name, emailAddress=@email, contactAddress=@contact, phoneNumber=@phone where userID=@id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@name", user.fullName);
            cmd.Parameters.AddWithValue("@email", user.emailAddress);
            cmd.Parameters.AddWithValue("@contact", user.contactAddress);
            cmd.Parameters.AddWithValue("@phone", user.phoneNumber);
            cmd.Parameters.AddWithValue("@id", user.userID);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfuly");
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai tỉnh thành");
            }
        }
        public void addUser_DA_BLL(User user, String cn)
        {
            MessageBox.Show("add user :" + user.fullName);
            SqlConnection conn = new SqlConnection(strConn);
            String sSQL = "exec @proc @name,@email,@contact,@phone,@username,@userpassword";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@name", user.fullName);
            cmd.Parameters.AddWithValue("@email", user.emailAddress);
            cmd.Parameters.AddWithValue("@contact", user.contactAddress);
            cmd.Parameters.AddWithValue("@phone", user.phoneNumber);
            cmd.Parameters.AddWithValue("@username", user.userName);
            cmd.Parameters.AddWithValue("@userpassword", user.userPassword);
            conn.Open();
            if (cn[0] == 'M')
            {
                cmd.Parameters.AddWithValue("@proc", "InsertStaffLoginData");
                try
                {
                    cmd.ExecuteNonQuery();
                    String sSQL2 = "insert into UserAddress values(@userID,(Select UserAddress.storeID from UserAddress where UserAddress.userID=@managerID))";
                    SqlCommand cmd2 = new SqlCommand(sSQL2, conn);
                    cmd2.Parameters.AddWithValue("@userID", getIdByUsername_DA_DAL(user.userName));
                    cmd2.Parameters.AddWithValue("@managerID", cn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công");
                }
                catch
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                }
            }
            else
            {
                String sSQL2 = "Insert into UserAddress values(@userID,@storeID)";
                SqlCommand cmd2 = new SqlCommand(sSQL2, conn);
                cmd2.Parameters.AddWithValue("@storeID", cn);
                try
                {
                    if (user.userRole.Equals("user"))
                    {
                        cmd.Parameters.AddWithValue("@proc", "InsertUserLoginData");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfuly");
                    }
                    else if (user.userRole.Equals("admin"))
                    {
                        cmd.Parameters.AddWithValue("@proc", "InsertAdminLoginData");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfuly");
                    }
                    else if (user.userRole.Equals("staff"))
                    {
                        cmd.Parameters.AddWithValue("@proc", "InsertStaffLoginData");
                        cmd.ExecuteNonQuery();
                        cmd2.Parameters.AddWithValue("@userID", getIdByUsername_DA_DAL(user.userName));
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Successfuly");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@proc", "InsertManagerLoginData");
                        cmd.ExecuteNonQuery();
                        cmd2.Parameters.AddWithValue("@userID", getIdByUsername_DA_DAL(user.userName));
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Successfuly");
                    }
                }
                catch
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                }
            }
            conn.Close();
        }


        public DataTable getAllUserOfStore_DA_DAL(String key)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select LoginData.* from LoginData, UserAddress where UserAddress.userID=LoginData.userID and UserAddress.storeId = (select storeID from UserAddress where UserAddress.userID=@key)";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@key", key);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        //StoreAddress
        public DataTable getAllStoreAdress()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from StoreAddress";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        // REVENUE
        public DataTable getAllRevenue_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from revenue";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable getAllRevenueById_DA_DAL(String key)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from revenue where storeID=@id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", key);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable getAllRevenueByIdManager_DA_DAL(String key)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select revenue.* from revenue, UserAddress where UserAddress.userID=@id and revenue.storeId = UserAddress.storeID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", key);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable getAllRevenueByTime_DA_DAL(String start, String end, String id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT * FROM revenue WHERE dateCreate >= @start AND dateCreate <= @end AND storeID=@id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        // NOTIFICATION
        public DataTable getAllNotification_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT * from NotificationData";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable getNotificationItem_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT * from NotificationDataDetail";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public void addNotification_DA_DAL(Notification item, String description, String focus)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "exec InsertNotificationData @pic, @name, @date, @pic,@des,@focus";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@pic", item.notificationPicture);
            cmd.Parameters.AddWithValue("@name", item.notificationName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@date", item.notificationDate);
            cmd.Parameters.AddWithValue("@des", description);
            cmd.Parameters.AddWithValue("@focus", focus);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thêm thành công");
        }
        public DataTable searchNotification_DA_DAL(String key)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            DataTable dt = new DataTable();
            if (key == null || key.Equals(""))
            {
                String sSQL = "select distinct * from NotificationData";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            else
            {
                String sSQL = "select distinct * from NotificationData Where notificationName like '%" + key + "%' or notificationName like '" + key + "%'";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@key", key);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public void deleteNotificationDataDetail(String id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "delete from NotificationDataDetail where notificationID = @id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteNotification_DA_DAL(String id)
        {
            deleteNotificationDataDetail(id);
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "delete from NotificationData where notificationID = @id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Xóa thành công");
        }
        //Province
        public DataTable getAllProvince_DA_DAL()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT * from Province";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        //Promotion
        public DataTable searchPromotion_DA_DAL(String key)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            DataTable dt = new DataTable();
            if (key == null || key.Equals("") || key.Equals("Search"))
            {
                String sSQL = "select * from PromotionData";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            else
            {
                String sSQL = "select distinct * from PromotionData Where promotionName like '%" + key + "%' or promotionName like '" + key + "%'";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@key", key);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public void addPromotion_DA_DAL(PromotionItem item)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "InsertPromotionData @poster, @name, @description, @percent";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@poster", item.promotionPicture);
            cmd.Parameters.AddWithValue("@name", item.promotionName);
            cmd.Parameters.AddWithValue("@description", item.promotionDescription);
            cmd.Parameters.AddWithValue("@percent", item.promotionPercent);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thêm thành công");
        }
        public void deletePromotion_DA_DAL(String id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "delete from PromotionData where promotionID = @id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Xóa thành công");
        }
        //HistoryUserData
        public DataTable getAllHistoryUserData_DA_DAL(String id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from HistoryUserData where userID=@id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        */
    }
}
