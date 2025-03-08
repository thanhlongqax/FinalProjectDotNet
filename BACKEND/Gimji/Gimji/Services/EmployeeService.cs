using Gimji.Data;
using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gimji.Services
{
    public class EmployeeService : EmployeeRepository
    {
        private MyPostgresDbContext dbContext;
        private RoleRepository roleRepository;
        public EmployeeService(MyPostgresDbContext dbContext , RoleRepository roleRepository)
        {
            this.dbContext = dbContext;
            this.roleRepository = roleRepository;
        }
        public async Task AddEmployee(EmployeeDTO employeeDTO)
        {
            await dbContext.employees.AddAsync(await MapDTO(employeeDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            dbContext.employees.Remove(await dbContext.employees.FindAsync(id));
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await dbContext.employees.FindAsync(id) != null;
        }

        public async Task<IEnumerable<employee>> GetAllEmmployee()
        {
            return await dbContext.employees.ToListAsync();
        }

        public async Task<employee> GetEmployeeById(int id)
        {
            return await dbContext.employees.FirstOrDefaultAsync(item => item.id == id);
        }
        public async Task<employee> GetEmployeeByUserName(string userName)
        {
            return await dbContext.employees
                .Include(e => e.Roles) // Bao gồm vai trò
                .FirstOrDefaultAsync(item => item.accountId == userName);
        }
        public async Task<employee> GetEmployeeByUserPassword(string password)
        {
            return await dbContext.employees
                .Include(e => e.Roles) // Bao gồm vai trò
                .FirstOrDefaultAsync(item => item.accountPassword == password);
        }

        public async Task<employee> GetEmployeeByName(string name)
        {
            return await dbContext.employees
                .Include(e => e.Roles) // Bao gồm vai trò
                .FirstOrDefaultAsync(item => item.givenName == name);
        }

        public async Task UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee_Update = await dbContext.employees.FindAsync(id);
            if (employee_Update != null)
            {
                employee_Update = await MapDTO(employeeDTO);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("khong tim thay nhan vien can cap nhat");
            }


        }
        public async Task<employee> MapDTO(EmployeeDTO employeeDTO)
        {
            employee employee_Update = new employee();
            employee_Update.givenName = employeeDTO.givenName;
            employee_Update.familyName = employeeDTO.familyName;
            employee_Update.gender = employeeDTO.gender;
            employee_Update.birthDate = employeeDTO.birthDate;
            employee_Update.email = employeeDTO.email;
            employee_Update.telephone = employeeDTO.telephone;
            employee_Update.jobTitle = employeeDTO.jobTitle;
            employee_Update.homeLocation = employeeDTO.homeLocation;
            employee_Update.hasCertification = employeeDTO.hasCertification;
            employee_Update.accountId = employeeDTO.accountId;
            employee_Update.accountPassword = employeeDTO.accountPassword;

            var role = await roleRepository.GetRoleById(employeeDTO.roleId);
            if(role != null)
            {
                if(employee_Update.Roles == null)
                {
                    employee_Update.Roles = new List<Role>();
                    
                }
                employee_Update.Roles.Add(role);
            }
            return employee_Update;
        }
    }
}
