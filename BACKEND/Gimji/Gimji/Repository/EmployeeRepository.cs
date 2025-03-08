using Gimji.DTO;
using Gimji.Models;
using System.Threading.Tasks;

namespace Gimji.Repository
{
    public interface EmployeeRepository
    {
        Task<bool> DoesItemExist(string id);
        Task<IEnumerable<employee>> GetAllEmmployee();
        Task<employee> GetEmployeeById(int id);
        Task<employee> GetEmployeeByUserName(string userName);
        Task<employee> GetEmployeeByUserPassword(string password);
        Task<employee> GetEmployeeByName(string name);
        Task AddEmployee(EmployeeDTO employeeDTO);
        Task UpdateEmployee(int id, EmployeeDTO employeeDTO);
        Task DeleteEmployee(int id);
    }
}
