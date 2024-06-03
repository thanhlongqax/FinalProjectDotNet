using Gimji.Data;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gimji.Services
{
    public class CustomerService : CustomerRepository
    {
        private MyPostgresDbContext dbContext;
        public CustomerService(MyPostgresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddCustomer(customer customer)
        {
            await dbContext.customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            dbContext.customers.Remove(await dbContext.customers.FindAsync(id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesItemExist(string id)
        {
           return await dbContext.customers.FindAsync(id) != null;
        }

        public async Task<IEnumerable<customer>> GetAllCustomer()
        {
            return await dbContext.customers.ToListAsync();
        }

        public Task<customer> GetCustomerById(int id)
        {
            return dbContext.customers
                .FirstOrDefaultAsync(item => item.id == id);
        }

        public Task<customer> GetCustomerByName(string name)
        {
            return dbContext.customers.FirstOrDefaultAsync(item => item.givenName == name);
        }

        public async Task UpdateCustomer(int id, customer customer)
        {
            var customer_Update = await dbContext.customers.FindAsync(id);
            if (customer_Update != null)
            {
                customer_Update.givenName = customer.givenName;
                customer_Update.familyName = customer.familyName;
                customer_Update.gender = customer.gender;
                customer_Update.birthDate = customer.birthDate;
                customer_Update.email = customer.email;
                customer_Update.telephone = customer.telephone;
                customer_Update.jobTitle = customer.jobTitle;
                customer_Update.homeLocation = customer.homeLocation;
                customer_Update.hasCertification = customer.hasCertification;
                customer_Update.accountId = customer.accountId;
                customer_Update.accountPassword = customer.accountPassword;

                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("khong tim thay khach hang can cap nhat");
            }

        }
    }
}
