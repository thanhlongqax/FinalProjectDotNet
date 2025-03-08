import axiosConfig from '../config/axiosConfig'

class LoginService {
    // Post request
    Login (payload) {
       return axiosConfig.post("/api/login",payload);
    }
}

const loginService = new LoginService();
export default loginService;