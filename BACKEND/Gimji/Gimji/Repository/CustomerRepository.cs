using Gimji.Models;

namespace Gimji.Repository
{
    public interface CustomerRepository
    {
        Task<bool> DoesItemExist(string id);
        Task<IEnumerable<customer>> GetAllCustomer();
        Task<customer> GetCustomerById(int id);
        Task<customer> GetCustomerByName(string name);
        Task AddCustomer(customer customer);
        Task UpdateCustomer(int id, customer customer);
        Task DeleteCustomer(int id);
    }
}
