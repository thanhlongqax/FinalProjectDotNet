using Gimji.Models;
using System.Threading.Tasks;

namespace Gimji.Repository
{
    public interface CategoryRepository
    {
        Task<bool> DoesItemExist(string id);
        Task<IEnumerable<CategoryCode>> GetAllCategory();
        Task<CategoryCode> GetCategoryById(string id);
        Task<CategoryCode> GetCategoryByName( string name);
        Task AddCateogory(CategoryCode categoryCode);
        Task UpdateCategory(int CodeValue,CategoryCode categoryCode);
        Task DeleteCategory(int id);
    }
}
