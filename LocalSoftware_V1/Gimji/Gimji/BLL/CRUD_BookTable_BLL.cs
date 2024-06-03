using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DAO;
using Gimji.DTO;

namespace Gimji.BLL
{
    internal class CRUD_BookTable_BLL
    {
        CRUD_BookTable_DAO newDAo = new CRUD_BookTable_DAO();
        public List<Table> getAllTable_BLL() {
            return newDAo.getAllTable_DAO();
        }
        public List<Table> GetTableByFloor_BLL(int tableId) {
            return newDAo.GetTableByFloor_DAO(tableId);
        }
        public void AddCookTable_BLL(Table_NV newTable)
        {
            newDAo.AddCookTable_DAO(newTable);
        }
        public void UpdateTable_BLL(Table updatedTable) { 
            newDAo.UpdateTable_DAO(updatedTable);
        }

        public void DeleteTable_BLL(int tableId) { 
            newDAo.DeleteTable_DAO(tableId);    
        }
        public List<Table_NV> getAllBan_NV_DAO()
        {
            return newDAo.getAllBan_NV_DAO();
        }
    }
}
