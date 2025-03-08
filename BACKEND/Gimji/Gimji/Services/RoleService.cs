using Gimji.Data;
using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gimji.Services
{
    public class RoleService : RoleRepository
    {
        private MyPostgresDbContext dbContext;
        public RoleService(MyPostgresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddRole(RoleDTO roleDTO)
        {
            await dbContext.roles.AddAsync(mapDTO(roleDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRole(int id)
        {
            dbContext.roles.Remove(await dbContext.roles.FindAsync(id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await dbContext.roles.FindAsync(id) != null;
        }

        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await dbContext.roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await dbContext.roles.FirstOrDefaultAsync(item => item.numberedPosition == id);
        }

        public async Task<Role> GetRoleByName(string name)
        {
            return await dbContext.roles.FirstOrDefaultAsync(item => item.roleName == name);
        }

        public async Task UpdateRole(int id, RoleDTO roleDTO)
        {
            var Role_Update = await dbContext.roles.FindAsync(id);
            if (Role_Update != null)
            {
                Role_Update = mapDTO(roleDTO);
                await dbContext.SaveChangesAsync();
            }
            else 
            {
                throw new Exception("không cập nhật thành công");
            }

        }
        public Role mapDTO(RoleDTO roleDTO)
        {
            return new Role
            {
                roleName = roleDTO.roleName,
                startDate = roleDTO.startDate,
                endDate = roleDTO.endDate,
                salaryCurrency = roleDTO.salaryCurrency
            };
        }
    }
}
