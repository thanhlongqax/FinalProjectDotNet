import axiosConfig from '../config/axiosConfig'

class RoleService {

    getRoleById (roleId) {
       return axiosConfig.get("/api/role/" + roleId );
    }
    getRoleAll(){
        return axiosConfig.get("/api/role");
    }
    createRole(payload){
        return axiosConfig.post("/api/role",payload);
    }
    updateRole(roleId){
        return axiosConfig.put("/api/role/" + roleId ,payload);
    }
    deleteRole(roleId){
        return axiosConfig.delete("/api/role/" + roleId);
    }
}

const roleService = new RoleService();
export default roleService;