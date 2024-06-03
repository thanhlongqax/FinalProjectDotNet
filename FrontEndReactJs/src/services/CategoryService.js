import axiosConfig from '../config/axiosConfig'

class CategoryService {

    getCategoryById (categoryId) {
       return axiosConfig.get("/api/category/" + categoryId );
    }
    getCategoryAll(){
        return axiosConfig.get("/api/category");
    }
    createCategory(payload){
        return axiosConfig.post("/api/category",payload);
    }
    updateCategory(categoryId ,payload){
        return axiosConfig.put("/api/category/" + categoryId , payload);
    }
    deleteCategory(categoryId){
        return axiosConfig.delete("/api/category/" + categoryId);
    }
}

const categoryService = new CategoryService();
export default categoryService;