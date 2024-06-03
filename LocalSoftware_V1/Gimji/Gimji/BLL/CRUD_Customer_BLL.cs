using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DTO;
using Gimji.DAO;
namespace Gimji.BLL
{
    internal class CRUD_Customer_BLL
    {
        CRUD_Customer_DAO newDAO = new CRUD_Customer_DAO();
        public List<Customer> getAllCustomer() { 
            return newDAO.getAllCustomer_DAO();
        }
        public Customer getCustomerById_BLL(String customerId) {
            return newDAO.getStaffById_DAO(customerId);
        }
        public void AddCustomer_BLL(Customer customer)
        {
            newDAO.AddCustomer_DAO(customer);
        }
        public void UpdateCustomer_BLL(Customer customer)
        {
            newDAO.UpdateCustomer_DAO(customer);
        }
        public void deleteCustomer_BLL(String id) { 
            newDAO.deleteCustomer_DAO(id);
        }
    }
}
