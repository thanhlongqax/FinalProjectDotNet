//using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Gimji.DTO;

namespace Gimji.DAO
{
    internal class CRUD_Revenue_DAO : DatabaseAccess
    {
        public DataTable GetRevenueByPeiod(String period)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand("GetRevenueDataByPeriod", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Period", period);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public Revenue GetDataCurrentMonth()
        {
            Revenue revenue = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sSQL = @"SELECT SUM(total_Customers) AS TotalCustomer, 
                               SUM(revenue) AS Revenue,
                               SUM(dishes_Ordered) AS Dish
                        FROM Doanh_Thu 
                        WHERE MONTH(dayTime) = MONTH(GETDATE()) 
                        AND YEAR(dayTime) = YEAR(GETDATE())";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        revenue = new Revenue
                        {
                            totalCustomers = row["TotalCustomer"].ToString(),
                            totalDishes = row["Dish"].ToString(),
                            revenue = row["Revenue"].ToString(),
                        };
                    }
                }
            }
            return revenue;
        }

        public DataTable GetRevenueCurrent(String period)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand("GetRevenueCurrent", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Period", period);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable ;
        }
    }
}
