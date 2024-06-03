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
    internal class CRUD_Voucher_DAO : DatabaseAccess
    {
        /// get all vouchers 
        public List<Voucher> getAllVoucher_DAO()
        {
            List<Voucher> voucherList = new List<Voucher>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sSQL = "SELECT * FROM Uu_Dai";
                using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Voucher voucher = new Voucher
                            {
                                voucherId = row["id_UuDai"].ToString(),
                                voucherName = row["ten_UuDai"].ToString(),
                                voucherStatus = row["statu"].ToString(),
                                voucherDescription = row["mo_ta"].ToString(),
                                voucherCondition = row["dieu_kien"].ToString(),
                                voucherDateTimeIn = DateTime.TryParse(row["timeBatDau"].ToString(), out DateTime dateStart) ? dateStart : DateTime.MinValue,
                                voucherDateTimeOut  = DateTime.TryParse(row["timeKetThuc"].ToString(), out DateTime dateEnd) ? dateEnd : DateTime.MinValue,     
                            };
                            voucherList.Add(voucher);
                        };
                    }
                }
            }

            return voucherList;
        }
        public Voucher getVoucherById_DAO(String voucherId)
        {
            Voucher voucher = null;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "SELECT * FROM Uu_Dai WHERE id_UuDai = @voucherId";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@voucherId", voucherId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                voucher = new Voucher
                {
                    voucherId = row["id_UuDai"].ToString(),
                    voucherName = row["ten_UuDai"].ToString(),
                    voucherStatus = row["statu"].ToString(),
                    voucherDescription = row["mo_ta"].ToString(),
                    voucherCondition = row["dieu_kien"].ToString(),
                    voucherDateTimeIn = DateTime.TryParse(row["timeBatDau"].ToString(), out DateTime dateStart) ? dateStart : DateTime.MinValue,
                    voucherDateTimeOut = DateTime.TryParse(row["timeKetThuc"].ToString(), out DateTime dateEnd) ? dateEnd : DateTime.MinValue,
                };
            }
            else if (dt.Rows.Count == 0)
            {
                return null;
            }

            return voucher;
        }

        public void AddVoucher_DAO(Voucher voucher)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            // Check if the voucher already exists
            string checkSaleSQL = "SELECT COUNT(*) FROM Uu_Dai WHERE ten_UuDai = @voucherName";
            SqlCommand checkSaleCmd = new SqlCommand(checkSaleSQL, conn);
            checkSaleCmd.Parameters.AddWithValue("@voucherName", voucher.voucherName);
            int voucherExist = (int)checkSaleCmd.ExecuteScalar();

            if (voucherExist == 0)
            {
                // The voucher does not exist, so you can proceed with the insertion
                using (SqlCommand cmd = new SqlCommand("InsertVoucher", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@nameVoucher", voucher.voucherName);
                    cmd.Parameters.AddWithValue("@status", voucher.voucherStatus);
                    cmd.Parameters.AddWithValue("@description", voucher.voucherDescription);
                    cmd.Parameters.AddWithValue("@conditions", voucher.voucherCondition);
                    cmd.Parameters.AddWithValue("@dateStart", voucher.voucherDateTimeIn);
                    cmd.Parameters.AddWithValue("@dateEnd", voucher.voucherDateTimeOut);
                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Thêm  Voucher Thành Công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                conn.Close();
                MessageBox.Show("Voucher đã tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateVoucher_DAO(Voucher voucher)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateVoucherById", conn); // Assuming you have a stored procedure named "UpdateVoucherById"
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idVoucer", voucher.voucherId);
            cmd.Parameters.AddWithValue("@nameVoucher", voucher.voucherName);
            cmd.Parameters.AddWithValue("@status", voucher.voucherStatus);
            cmd.Parameters.AddWithValue("@description", voucher.voucherDescription);
            cmd.Parameters.AddWithValue("@conditions", voucher.voucherCondition);
            cmd.Parameters.AddWithValue("@dateStart", voucher.voucherDateTimeIn);
            cmd.Parameters.AddWithValue("@dateEnd", voucher.voucherDateTimeOut);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Cập Nhật Thông Tin Voucher Thành Công", "Thông báo", MessageBoxButtons.OK);
        }

        public void DeleteVoucher_DAO(String id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sSQL = "DELETE FROM Uu_Dai WHERE id_UuDai = @id";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
