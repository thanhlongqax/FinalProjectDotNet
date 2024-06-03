using Gimji.DAO;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class CRUD_Revenue_BLL
    {
        CRUD_Revenue_DAO newDAO =new CRUD_Revenue_DAO();
        public DataTable GetRevenueByPeriod(String period)
        {
            return newDAO.GetRevenueByPeiod(period);
        }
        public Revenue GetDataCurrentMonth()
        {
            return newDAO.GetDataCurrentMonth();
        }
        public DataTable GetRevenueCurrent(String period)
        {
            return newDAO.GetRevenueCurrent(period);
        }
    }
}
