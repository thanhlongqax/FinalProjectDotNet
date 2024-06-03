using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Gimji.DTO;
using Microsoft.Data.SqlClient;

namespace Gimji.DAO
{
    internal class CRUD_Inventory_DAO: DatabaseAccess
    {
        public List<Inventory>  GetAllInventoryDAO()
        {
            List<Inventory> listInventory = new List<Inventory>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = @"SELECT m.hinh_anh,m.ten_mon_an,d.loai_mon,m.don_gia,m.tinh_trang
                            FROM Mon_an m,Danh_muc_mon_an d
                            Where  m.id_danh_muc = d.id_danhMuc";
            SqlDataAdapter da = new SqlDataAdapter(sSQL, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(90, 101);
                    int avai = 0;
                    if (row["tinh_trang"].ToString().Equals("Còn Hàng"))
                    {
                         avai = randomNumber;
                    }
                    Inventory inventory = new Inventory
                    {
                        foodName = row["ten_mon_an"].ToString(),
                        price = Convert.ToDouble(row["don_gia"]),
                        type = row["loai_mon"].ToString(),
                        inventoryPicture = row["hinh_anh"].ToString(),
                        status = row["tinh_trang"].ToString(),
                        available = avai,
                        sold = 100 - avai


                    };
                    listInventory.Add(inventory);
                }
            }

            return listInventory;
            
        }
    }
}
