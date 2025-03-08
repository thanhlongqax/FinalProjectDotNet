import axiosConfig from '../config/axiosConfig'


class EmployeeService {

    getEmployeeById (employeeId) {
       return axiosConfig.get("/api/employee/" ,employeeId );
    }
    getEmployeeAll(){
        return axiosConfig.get("/api/employee");
    }
    createEmployee(payload){
        return axiosConfig.post("/api/employee",payload);
    }
    updateEmployee(employeeId ,payload){
        return axiosConfig.put("/api/employee/" + employeeId ,payload);
    }
    deleteEmployee(employeeId){
        return axiosConfig.delete("/api/employee/" + employeeId);
    }
    
}
const employeeService = new EmployeeService();
export default employeeService;