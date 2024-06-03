using Gimji.DTO;
using Gimji.Models;

namespace Gimji.Repository
{
    public interface RoleRepository
    {
        Task<bool> DoesItemExist(string id);
        Task<IEnumerable<Role>> GetAllRole();
        Task<Role> GetRoleById(int id);
        Task<Role> GetRoleByName(string name);
        Task AddRole(RoleDTO roleDTO);
        Task UpdateRole(int id, RoleDTO roleDTO);
        Task DeleteRole(int id);
    }
}
