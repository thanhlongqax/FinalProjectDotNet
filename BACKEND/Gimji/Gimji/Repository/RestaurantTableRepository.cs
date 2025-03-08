using Gimji.DTO;
using Gimji.Models;

namespace Gimji.Repository
{
    public interface RestaurantTableRepository
    {
        Task<bool> DoesItemExist(string id);

        Task<IEnumerable<RestaurantTable>> GetAllRestaurantTable();
        Task<RestaurantTable> GetRestaurantTableById(int id);
        Task<RestaurantTable> GetRestaurantTableByName(string name);
        Task AddRestaurantTable(RestaurantTable restaurantTable);
        Task UpdateRestaurantTable(int id, RestaurantTable restaurantTable);
        Task DeleteRestaurantTable(int id);
    }
}
