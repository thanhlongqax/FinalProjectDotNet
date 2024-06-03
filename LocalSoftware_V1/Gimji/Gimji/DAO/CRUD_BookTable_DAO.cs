using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DTO;
using System.Data;
using System.Drawing;

namespace Gimji.DAO
{
    internal class CRUD_BookTable_DAO : DatabaseAccess
    {
        // lay tat ca ban _____________________________________________________________________________________________
        public List<Table> getAllTable_DAO()
        {
            List<Table> listTable = new List<Table>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sSQL = "SELECT * FROM Ban";
                SqlCommand command = new SqlCommand(sSQL, conn);

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        Table table = new Table
                        {
                            TableId = Convert.ToInt32(row["id_ban"]),
                            TableName = row["ten_ban"].ToString(),
                            Floor = Convert.ToInt32(row["tang"])
                        };
                        listTable.Add(table);
                    }
                }
            }

            return listTable;
        }
        public List<Table_NV> getAllBan_NV_DAO()
        {
            List<Table_NV> listBan_NV = new List<Table_NV>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sSQL = "SELECT * FROM Ban_NV";
                SqlCommand command = new SqlCommand(sSQL, conn);

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        Table_NV ban_NV = new Table_NV
                        {
                            IdBan = Convert.ToInt32(row["id_ban"]),
                            TenKhachHang = row["ten_khach_hang"].ToString(),
                            SdtKhachHang = row["sdt_khach_hang"].ToString(),
                            GhiChu = row["ghi_chu"].ToString(),
                            NgayDatBan = Convert.ToDateTime(row["ngay_dat_ban"])
                        };
                        listBan_NV.Add(ban_NV);
                    }
                }
            }

            return listBan_NV;
        }

        //_______________________________________________________________________________________________________________
        // lay ban theo Floor _____________________________________________________________________________________________
        public List<Table> GetTableByFloor_DAO(int floor)
        {
            List<Table> TableFloor = new List<Table>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sSQL = "SELECT * FROM Ban WHERE tang = @Floor ;";
                SqlCommand command = new SqlCommand(sSQL, conn);
                command.Parameters.AddWithValue("@Floor", floor);

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Table table = new Table
                            {
                                TableId = Convert.ToInt32(row["id_ban"]),
                                TableName = row["ten_ban"].ToString(),
                                Floor = Convert.ToInt32(row["tang"])
                            };
                            TableFloor.Add(table);
                        }
                    }
                }
            }

            return TableFloor;
        }

        //_______________________________________________________________________________________________________________
        // lay ra ban da dat _____________________________________________________________________________________________
        /*public List<Table_NV> getBooKTableAll() {
            List<Table_NV> CookTable = new List<Table_NV>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sSQL = "SELECT * FROM Ban_NV ;";
                SqlCommand command = new SqlCommand(sSQL, conn);
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Table_NV cookTable = new Table_NV
                            {
                                StaffId = row["id_nhan_vien"].ToString(),
                                TableId = Convert.ToInt32(row["id_ban"]),
                                CustomerName = row["ten_khach_hang"].ToString(),
                                Date_Table_Set = row["ngay_dat_ban"] != DBNull.Value ? Convert.ToDateTime(row["ngay_dat_ban"]) : DateTime.MinValue, 
                                Note = row["ghi_chu"].ToString()
                            };
                            CookTable.Add(cookTable);
                        }
                    }
                }
            }
            return CookTable;
        }*/
        //_______________________________________________________________________________________________________________
        // Thêm Bàn MỚi _____________________________________________________________________________________________
        public void AddCookTable_DAO(Table_NV table_NV)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                // Sử dụng stored procedure để thêm bàn mới
                string insertTableProcedure = "InsertTable_NV";
                using (SqlCommand command = new SqlCommand(insertTableProcedure, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_ban", table_NV.IdBan);
                    command.Parameters.AddWithValue("@ngay_dat_ban",table_NV.NgayDatBan );
                    command.Parameters.AddWithValue("@ghi_chu", table_NV.GhiChu);
                    command.Parameters.AddWithValue("@sdt_khach_hang", "0817757012");
                    command.Parameters.AddWithValue("@ten_khach_hang", table_NV.TenKhachHang);
                    command.ExecuteNonQuery();
                }
            }
        }



        //_______________________________________________________________________________________________________________
        // Sửa 1 Bàn _____________________________________________________________________________________________
        public void UpdateTable_DAO(Table updatedTable)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sSQL = "UPDATE Ban SET ten_ban = @TenBan, tang = @Tang WHERE id_ban = @TableId";
                SqlCommand command = new SqlCommand(sSQL, conn);
                command.Parameters.AddWithValue("@TenBan", updatedTable.TableName);
                command.Parameters.AddWithValue("@Tang", updatedTable.Floor);
                command.Parameters.AddWithValue("@TableId", updatedTable.TableId);

                command.ExecuteNonQuery();
            }
        }

        //_______________________________________________________________________________________________________________
        // Xoa 1 ban _____________________________________________________________________________________________
        public void DeleteTable_DAO(int tableId)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sSQL = "DELETE FROM Ban WHERE id_ban = @TableId";
                SqlCommand command = new SqlCommand(sSQL, conn);
                command.Parameters.AddWithValue("@TableId", tableId);

                command.ExecuteNonQuery();
            }
        }

        //_______________________________________________________________________________________________________________

    }
}
