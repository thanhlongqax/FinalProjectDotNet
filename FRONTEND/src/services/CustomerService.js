import axiosConfig from '../config/axiosConfig'


class CustomerService {

    getCustomerById (customerId) {
       return axiosConfig.get("/api/customer/" ,customerId );
    }
    getCustomerAll(){
        return axiosConfig.get("/api/customer");
    }
    createCustomer(payload){
        return axiosConfig.post("/api/customer",payload);
    }
    updateCustomer(customerId,payload){
        return axiosConfig.put("/api/customer/" + customerId ,payload);
    }
    deleteCustomer(customerId){
        return axiosConfig.delete("/api/customer/" + customerId);
    }
    
}
const customerService = new CustomerService();
export default customerService;