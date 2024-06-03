using Gimji.DAO;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class CRUD_Order_BLL
    {
        CRUD_Order_DAO newDao = new CRUD_Order_DAO();
        public List<Orders> getAllOrder()
        {
            return newDao.GetAllOrder();
        }
        public void insertHoaDon(Orders order)
        {
            newDao.InsertHoaDon(order);
        }
        public void updateHoaDon(Orders order)
        {
            newDao.UpdateHoaDon(order);
        }
        public void deleteHoaDon(int orderId)
        {
            newDao.DeleteHoaDon(orderId);
        }

    }
}
