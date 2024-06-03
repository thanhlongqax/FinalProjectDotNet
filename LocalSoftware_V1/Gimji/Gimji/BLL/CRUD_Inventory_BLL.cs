using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DAO;
using Gimji.DTO;

namespace Gimji.BLL
{
    internal class CRUD_Inventory_BLL
    {
        CRUD_Inventory_DAO newDAO = new CRUD_Inventory_DAO();
        public List<Inventory> GetAllInventoryDAO()
        {
            return newDAO.GetAllInventoryDAO();
        }
    }
}
