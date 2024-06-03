using Gimji.DAO;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class CRUD_Voucher_BLL
    {
        CRUD_Voucher_DAO newDAO = new CRUD_Voucher_DAO();
        public List<Voucher> getAllVoucher_DAO()
        {
            return newDAO.getAllVoucher_DAO();
        }
        public Voucher getVoucherrById_BLL(String voucherId)
        {
            return newDAO.getVoucherById_DAO(voucherId);
        }
        public void AddVoucher_BLL(Voucher voucher)
        {
            newDAO.AddVoucher_DAO(voucher);
        }
        public void UpdateVoucher_BLL(Voucher voucher)
        {
            newDAO.UpdateVoucher_DAO(voucher);
        }
        public void DeleteVoucher_BLL(String id)
        {
            newDAO.DeleteVoucher_DAO(id);
        }
    }
}
