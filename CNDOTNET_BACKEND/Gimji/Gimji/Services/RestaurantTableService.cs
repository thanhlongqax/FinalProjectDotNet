using Gimji.Data;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gimji.Services
{
    public class RestaurantTableService : RestaurantTableRepository
    {
        private MyPostgresDbContext dbContext;
        public RestaurantTableService(MyPostgresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddRestaurantTable(RestaurantTable restaurantTable)
        {
            await dbContext.restaurantTables.AddAsync(restaurantTable);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRestaurantTable(int id)
        {
            dbContext.restaurantTables.Remove(await dbContext.restaurantTables.FindAsync(id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await dbContext.restaurantTables.FindAsync(id) != null;
        }

        public async Task<IEnumerable<RestaurantTable>> GetAllRestaurantTable()
        {
            return await dbContext.restaurantTables.ToListAsync();
        }

        public async Task<RestaurantTable> GetRestaurantTableById(int id)
        {
            return await dbContext.restaurantTables.FirstOrDefaultAsync(item => item.TableNumber == id);
        }

        public async Task<RestaurantTable> GetRestaurantTableByName(string name)
        {
            return await dbContext.restaurantTables.FirstOrDefaultAsync(item => item.TableName == name);
        }

        public async Task UpdateRestaurantTable(int id, RestaurantTable restaurantTable)
        {
            var Table_Update = await dbContext.restaurantTables.FindAsync(id);
            if (Table_Update != null)
            {
                Table_Update.TableName = restaurantTable.TableName;
                Table_Update.IsReserved = restaurantTable.IsReserved;
                Table_Update.IsOccupied = restaurantTable.IsOccupied;
                Table_Update.Reservations = restaurantTable.Reservations;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Không tìm thấy bàn để cập nhật");
            }    


        }
    }
}
