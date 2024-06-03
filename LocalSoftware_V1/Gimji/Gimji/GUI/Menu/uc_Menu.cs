using Gimji.DTO;
using Gimji.BLL;
using Gimji.GUI.Management.ProductManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Menu
{
    public partial class uc_Menu : UserControl
    {
        int IdCategory = 0;
        private uc_MonAn selectedMonAn; // Biến toàn cục để lưu trữ uc_MonAn được chọn
        private uc_MonAnCart selectedMonAnCart;
        private List<CartItem> listCartItems;

        public uc_Menu()
        {
            InitializeComponent();
        }

        private void uc_Menu_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void btn_Tokbokki_Click(object sender, EventArgs e)
        {
            IdCategory = 1;
            LoadDataByCategoryId(IdCategory);
        }
        private void btn_Meat_Click(object sender, EventArgs e)
        {
            IdCategory = 2;
            LoadDataByCategoryId(IdCategory);
        }

        private void btn_Salad_Click(object sender, EventArgs e)
        {
            IdCategory = 3;
            LoadDataByCategoryId(IdCategory);
        }
        private void btn_Kimbak_Click(object sender, EventArgs e)
        {
            IdCategory = 4;
            LoadDataByCategoryId(IdCategory);
        }
        private void btn_Rice_Click(object sender, EventArgs e)
        {
            IdCategory = 5;
            LoadDataByCategoryId(IdCategory);
        }

        public void loadData()
        {
            flow_pal_listProduct_Clear();
            List<Dish> listDish = new List<Dish>();
            CRUD_Dish_BLL newBLL = new CRUD_Dish_BLL();
            String DishID = null;
            listDish = newBLL.getAllDish_BLL();
            foreach (var Dish in listDish)
            {
                uc_MonAn uc_MonAn = new uc_MonAn();
                try
                {
                    uc_MonAn.PictureBox = Image.FromFile(Dish.DishPicture);
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi không thể tải hình ảnh.
                    // Ví dụ: Hiển thị hình ảnh mặc định hoặc thông báo lỗi.
                    uc_MonAn.PictureBox = Image.FromFile("Resources/AnhMonAn/Default.jpg");
                    // Thay "default_image.jpg" bằng hình ảnh mặc định của bạn.                                                                                                  // Hoặc hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi Đường Dẫn: " + ex.Message);
                }
                uc_MonAn.ID = Dish.DishId;
                uc_MonAn.Name = Dish.DishName;
                uc_MonAn.Price = Dish.DishPrice;
                uc_MonAn.IdCategory = Dish.Catergory_Id;
                uc_MonAn.BtnBuyClick += (s, eventArgs) =>
                {
                    // Lưu trữ uc_product được chọn vào biến toàn cục
                    selectedMonAn = (uc_MonAn)s;
                    HandleBtnBuyClick((uc_MonAn)s, Dish);

                };
                fl_Panel_Thuc_Don.Controls.Add(uc_MonAn);
            }
        }
        private void HandleBtnBuyClick(uc_MonAn uc_MonAn, Dish dish)
        {
            selectedMonAn = uc_MonAn;
            CRUD_CartItem_BLL newBLL = new CRUD_CartItem_BLL();
            CRUD_Dish_BLL cRUD_Dish_BLL = new CRUD_Dish_BLL();
            Dish newDish = new Dish();
            newDish = cRUD_Dish_BLL.GetDishById_BLL(selectedMonAn.ID);
            CartItem cartItem = new CartItem();
            cartItem.IdMonAn = uc_MonAn.ID;
            cartItem.Name = uc_MonAn.Name;
            cartItem.Price = uc_MonAn.Price;
            cartItem.DishPicture = newDish.DishPicture;
            cartItem.Catergory_Id = uc_MonAn.IdCategory;
            newBLL.InsertCartItem(cartItem);
            loadDataMonAnCart();

        }
        private void loadDataMonAnCart()
        {
            flow_pal_listMonAnCart_Clear();
            CRUD_CartItem_BLL newBLL = new CRUD_CartItem_BLL();
            String idTaiKhoan = Stored_Login_Infor.GetCurrentUser();
            listCartItems = newBLL.getAllCartItemById_BLL(idTaiKhoan);
            foreach (var cartItem in listCartItems)
            {
                uc_MonAnCart uc_MonAnCart = new uc_MonAnCart();
                uc_MonAnCart.ID = cartItem.Id;
                uc_MonAnCart.idMonAns = cartItem.IdMonAn;
                uc_MonAnCart.IdCategory = cartItem.Catergory_Id;
                uc_MonAnCart.Name = cartItem.Name;
                uc_MonAnCart.Price = cartItem.Price;
                uc_MonAnCart.Count = 1;
                cartItem.Quantity = uc_MonAnCart.Count;

                try
                {
                    uc_MonAnCart.PictureBox = Image.FromFile(cartItem.DishPicture);
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi không thể tải hình ảnh.
                    // Ví dụ: Hiển thị hình ảnh mặc định hoặc thông báo lỗi.
                    uc_MonAnCart.PictureBox = Image.FromFile("Resources/AnhMonAn/Default.jpg");
                    // Thay "default_image.jpg" bằng hình ảnh mặc định của bạn.                                                                                                  // Hoặc hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi Đường Dẫn: " + ex.Message);
                }
                uc_MonAnCart.BtnDeleteClick += (s, eventArgs) =>
                {
                    selectedMonAnCart = (uc_MonAnCart)s;
                    btn_delete_Click(s, eventArgs);
                    loadDataMonAnCart();
                };
                uc_MonAnCart.BtnMinusClick += (s, eventArgs) =>
                {
 
                    uc_MonAnCart.Count--;
                    cartItem.Quantity = uc_MonAnCart.Count;

                };
                uc_MonAnCart.BtnPlusClick += (s, eventArgs) =>
                {

                    uc_MonAnCart.Count++;
                    cartItem.Quantity = uc_MonAnCart.Count;
                };
                flow_pal_List.Controls.Add(uc_MonAnCart);
            }

        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            CRUD_CartItem_BLL newBLL = new CRUD_CartItem_BLL();
            newBLL.deleteCartItemById(selectedMonAnCart.ID);
        }
        private void flow_pal_listProduct_Clear()
        {
            List<Control> controlsToRemove = new List<Control>();

            foreach (Control control in fl_Panel_Thuc_Don.Controls)
            {
                if (control is uc_MonAn)
                {
                    // Thêm các uc_Product cần xóa vào danh sách tạm thời
                    controlsToRemove.Add(control);
                }
            }
            // Xóa tất cả các uc_Product từ danh sách tạm thời
            foreach (Control controlToRemove in controlsToRemove)
            {
                fl_Panel_Thuc_Don.Controls.Remove(controlToRemove);

            }
        }
        private void flow_pal_listMonAnCart_Clear()
        {
            List<Control> controlsToRemove = new List<Control>();

            foreach (Control control in flow_pal_List.Controls)
            {
                if (control is uc_MonAnCart)
                {
                    // Thêm các uc_Product cần xóa vào danh sách tạm thời
                    controlsToRemove.Add(control);
                }
            }
            // Xóa tất cả các uc_Product từ danh sách tạm thời
            foreach (Control controlToRemove in controlsToRemove)
            {
                flow_pal_List.Controls.Remove(controlToRemove);

            }
        }
        private void flow_pal_listProductById_Clear(int monAnIdToDelete)
        {
            List<Control> controlsToRemove = new List<Control>();

            foreach (Control control in flow_pal_List.Controls)
            {
                if (control is uc_MonAn && ((uc_MonAn)control).ID == monAnIdToDelete)
                {
                    // Kiểm tra ID của uc_MonAn và thêm vào danh sách tạm thời nếu khớp
                    controlsToRemove.Add(control);
                }
            }

            // Xóa tất cả các uc_Product từ danh sách tạm thời
            foreach (Control controlToRemove in controlsToRemove)
            {
                flow_pal_List.Controls.Remove(controlToRemove);
            }
        }

        private void LoadDataByCategoryId(int IdCategory)
        {
            flow_pal_listProduct_Clear();
            List<Dish> listDish = new List<Dish>();
            CRUD_Dish_BLL newBLL = new CRUD_Dish_BLL();
            String DishID = null;
            listDish = newBLL.GetDishesByCategoryId_BLL(IdCategory);
            foreach (var Dish in listDish)
            {
                uc_MonAn uc_MonAn = new uc_MonAn();
                try
                {
                    uc_MonAn.PictureBox = Image.FromFile(Dish.DishPicture);
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi không thể tải hình ảnh.
                    // Ví dụ: Hiển thị hình ảnh mặc định hoặc thông báo lỗi.
                    uc_MonAn.PictureBox = Image.FromFile("Resources/AnhMonAn/Default.jpg"); // Thay "default_image.jpg" bằng hình ảnh mặc định của bạn.
                                                                                            // Hoặc hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi Đường Dẫn: " + ex.Message);
                }
                uc_MonAn.ID = Dish.DishId;
                uc_MonAn.Name = Dish.DishName;
                uc_MonAn.Price = Dish.DishPrice;
                uc_MonAn.IdCategory = Dish.Catergory_Id;
                // Đăng ký sự kiện BtnEditClick cho mỗi uc_staff
                uc_MonAn.BtnBuyClick += (s, eventArgs) =>
                {
                    // Lưu trữ uc_product được chọn vào biến toàn cục
                    selectedMonAn = (uc_MonAn)s;
                    HandleBtnBuyClick((uc_MonAn)s, Dish);
                    loadDataMonAnCart();

                };
                fl_Panel_Thuc_Don.Controls.Add(uc_MonAn);
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            CRUD_CartItem_BLL newBLL = new CRUD_CartItem_BLL();
            CartItemManager.SaveCartItems(listCartItems);

            List<CartItem> cartItems = CartItemManager.GetCartItems();

            StringBuilder message = new StringBuilder();

            foreach (CartItem item in cartItems)
            {
                message.AppendLine($"IdMonAn: {item.IdMonAn}, Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                // Add more properties as needed
            }

            MessageBox.Show(message.ToString(), "Cart Items Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (var cartItem in listCartItems)
            {
                newBLL.deleteCartItemById(cartItem.Id);

            }
            loadDataMonAnCart();
        }
    }
}
