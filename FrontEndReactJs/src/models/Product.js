class Product {
    // Constructor của lớp Product, chấp nhận các tham số để khởi tạo đối tượng
    constructor(id, name, image1, image2, image3, description, nsn, category) {
        this.id = id; // Mã sản phẩm
        this.name = name; // Tên sản phẩm
        this.image1 = image1; // Đường dẫn hình ảnh 1
        this.image2 = image2; // Đường dẫn hình ảnh 2
        this.image3 = image3; // Đường dẫn hình ảnh 3
        this.description = description; // Mô tả sản phẩm
        this.nsn = nsn; // Số lượng tồn kho
        this.category = category; // Loại sản phẩm
    }
}
const product = new Product();
export default product;