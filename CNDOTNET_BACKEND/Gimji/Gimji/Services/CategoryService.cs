using Gimji.Data;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gimji.Services
{
    public class CategoryService : CategoryRepository
    {
        private MyPostgresDbContext dbContext;
        public CategoryService(MyPostgresDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task AddCateogory(CategoryCode categoryCode)
        {
            await dbContext.categoryCodes.AddAsync(categoryCode);

            await dbContext.SaveChangesAsync();
           
        }

        public async Task DeleteCategory(int id)
        {
            dbContext.categoryCodes.Remove(await dbContext.categoryCodes.FindAsync(id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await dbContext.categoryCodes.FindAsync(id) != null;
        }

        public async Task<IEnumerable<CategoryCode>> GetAllCategory()
        {
            return await dbContext.categoryCodes.ToListAsync();
        }

        public async Task<CategoryCode> GetCategoryById(string id)
        {
            return await dbContext.categoryCodes.SingleOrDefaultAsync<CategoryCode>(item => item.CodeValue == id);
        }

        public async Task<CategoryCode> GetCategoryByName(string name)
        {
            return await dbContext.categoryCodes.SingleOrDefaultAsync<CategoryCode>(item => item.Name == name);
        }

        public async Task UpdateCategory(int CodeValue,CategoryCode categoryCode)
        {
            var category_Update = await dbContext.categoryCodes.FindAsync(CodeValue);
            if(category_Update != null)
            {
                category_Update.Name = categoryCode.Name;
                category_Update.Image = categoryCode.Image;
                category_Update.Description = categoryCode.Description;

                await dbContext.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
            }
            else
            {
                throw new Exception("khong tim danh muc can cap nhat");
            }


        }
            
    }
}
