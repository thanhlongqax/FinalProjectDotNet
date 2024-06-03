using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DAO;
using Gimji.DTO;

namespace Gimji.BLL
{
    internal class CRUD_Dish_BLL
    {
        CRUD_Dish_DAO newDao = new CRUD_Dish_DAO();
        public List<Dish> getAllDish_BLL() {
            return newDao.GetAllDish_DAO();
        }
        public Dish GetDishById_BLL(int dishId) {
            return newDao.GetDishById_DAO(dishId);
        }
        public List<Dish> GetDishesByCategoryId_BLL(int categoryId) {
            return newDao.GetDishesByCategoryId_DAO(categoryId);
        }
        public void addDish_DAO(Dish addDish) { 
            newDao.addDish_DAO(addDish);
        }
        public void updateDish_BLL(Dish updatedDish){
            newDao.updateDish_DAO(updatedDish);
        }
        public void DeleteDishById(int DishId) { 
            newDao.DeleteDishById_DAO(DishId);  
        }
    }
}
