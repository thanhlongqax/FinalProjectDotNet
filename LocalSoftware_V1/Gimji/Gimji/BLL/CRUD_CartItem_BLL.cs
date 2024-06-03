using Gimji.DAO;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class CRUD_CartItem_BLL
    {
        CRUD_CartItem_DAO CRUD_CartItem_DAO = new CRUD_CartItem_DAO();
        public List<CartItem> getAllCartItemById_BLL(string IdTaiKhoan)
        {
            return CRUD_CartItem_DAO.getAllCartItemById_DAO(IdTaiKhoan);
        }
        public void InsertCartItem(CartItem cartItem)
        {
            CRUD_CartItem_DAO.InsertCartItem(cartItem);
        }
        public void deleteCartItemById(int id)
        {
            CRUD_CartItem_DAO.DeleteCartItemById(id);
        }
    }
}
