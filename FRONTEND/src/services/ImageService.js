import axiosConfig from '../config/axiosConfig'


class ImageService {

    CreateImage (file) {
        const formData = new FormData();
        formData.append("ImageFile", file); // Sử dụng tên trường là "ImageFile"
        
        return axiosConfig.post("/api/images", formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            }
        });
    }
    GetImageById(id){
        return axiosConfig.get("/api/images/" +id);
    }
    
}
const imageService = new ImageService();
export default imageService; 