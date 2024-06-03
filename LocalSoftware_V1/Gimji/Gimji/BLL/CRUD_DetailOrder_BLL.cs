using Gimji.DAO;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class CRUD_DetailOrder_BLL
    {
        CRUD_DetailOrder_DAO newDAO = new CRUD_DetailOrder_DAO();
        public void Insert_DetailOrder(Detail_Order detail_Order)
        {
            newDAO.InsertChiTietHoaDon(detail_Order);
        }
    }
}
