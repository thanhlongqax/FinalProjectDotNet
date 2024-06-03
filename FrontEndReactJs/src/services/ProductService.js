import axiosConfig from '../config/axiosConfig'
class ProductService {
    getProductAll(paramsString){
        return axiosConfig.get(`/api/product?${paramsString}`);
    }
    getProductById (productId) {
       return axiosConfig.get("/api/product/" + productId );
    }
    getProductByCategory (categoryCode , paramsString) {
        return axiosConfig.get("/api/product/category/" + categoryCode + "?" + paramsString);    
     }
    createProduct(payload){
        return axiosConfig.post("/api/product",payload);
    }
    updateProduct(productId ,payload){
        return axiosConfig.put("/api/product/" + productId ,payload );
    }
    deleteProduct(productId){
        return axiosConfig.delete("/api/product/" + productId);
    }
}

const productService = new ProductService();
export default productService;