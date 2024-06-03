using Gimji.BLL;
using Gimji.DTO;
using Gimji.GUI.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ClosedXML.Excel;
using Gimji.GUI.Order;

namespace Gimji.GUI.PayMent
{
    public partial class uc_Payment : UserControl
    {
        int IdCategory = 0;
        String nameCustomer = uc_Order.nameCustomer;
        private uc_MonAn_Paymentcs selectedMonAn; // Biến toàn cục để lưu trữ uc_MonAn được chọn
        private List<CartItem> listCartItems;
        double total;
        double totalOrder;
        int quantity;
        int phuongThucThanhToan;
        public uc_Payment()
        {
            InitializeComponent();

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private void uc_Payment_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            flow_pal_listOrder_Clear();
            string currentUser = Stored_Login_Infor.GetCurrentUser();
            if (currentUser != null)
            {
                lbl_idOrder.Text = currentUser;
            }

            lb_time.Text = DateTime.Now.ToString();
            List<CartItem> cartItems = CartItemManager.GetCartItems();
            foreach (CartItem cartItem in cartItems)
            {
                uc_MonAn_Paymentcs MonAn_Paymentcs = new uc_MonAn_Paymentcs();
                MonAn_Paymentcs.ID = cartItem.Id;
                MonAn_Paymentcs.idMonAns = cartItem.IdMonAn;
                MonAn_Paymentcs.IdCategory = cartItem.Catergory_Id;
                MonAn_Paymentcs.Name = cartItem.Name;
                MonAn_Paymentcs.Price = cartItem.Price;
                MonAn_Paymentcs.Count = cartItem.Quantity;
                quantity = MonAn_Paymentcs.Count;
                total += cartItem.Price;

                try
                {
                    MonAn_Paymentcs.PictureBox = Image.FromFile(cartItem.DishPicture);
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi không thể tải hình ảnh.
                    // Ví dụ: Hiển thị hình ảnh mặc định hoặc thông báo lỗi.
                    MonAn_Paymentcs.PictureBox = Image.FromFile("Resources/AnhMonAn/Default.jpg");
                    // Thay "default_image.jpg" bằng hình ảnh mặc định của bạn.                                                                                                  // Hoặc hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi Đường Dẫn: " + ex.Message);
                }
                MonAn_Paymentcs.BtnDeleteClick += (s, eventArgs) =>
                {
                    selectedMonAn = (uc_MonAn_Paymentcs)s;
                    // btn_delete_Click(s, eventArgs);
                };
                MonAn_Paymentcs.BtnMinusClick += (s, eventArgs) =>
                {

                    MonAn_Paymentcs.Count--;
                    quantity = MonAn_Paymentcs.Count;

                };
                MonAn_Paymentcs.BtnPlusClick += (s, eventArgs) =>
                {
                    MonAn_Paymentcs.Count++;
                    quantity = MonAn_Paymentcs.Count;
                };
                flow_pal_listOrder.Controls.Add(MonAn_Paymentcs);

            }
            lb_subPrice.Text = total.ToString();
            double tax = 0.02 * total;
            double discount = 0.1 * total;
            lb_Tax.Text = tax.ToString();
            lb_priceDiscount.Text = discount.ToString();
            totalOrder = total - (tax + discount);
            lb_totalPrice.Text = totalOrder.ToString();

        }
        private void flow_pal_listOrder_Clear()
        {
            if (flow_pal_listOrder != null)
            {
                List<Control> controlsToRemove = new List<Control>();

                foreach (Control control in flow_pal_listOrder.Controls)
                {
                    if (control is uc_MonAn_Paymentcs)
                    {
                        // Thêm các uc_Product cần xóa vào danh sách tạm thời
                        controlsToRemove.Add(control);
                    }
                }
                // Xóa tất cả các uc_Product từ danh sách tạm thời
                foreach (Control controlToRemove in controlsToRemove)
                {
                    flow_pal_listOrder.Controls.Remove(controlToRemove);

                }
            }

        }

        private void btn_qrCode_Click(object sender, EventArgs e)
        {
            pal_payment.Controls.Clear();
            pal_payment.Controls.Add(new uc_qrCode());
            phuongThucThanhToan = 3;
        }

        private void btn_cash_Click(object sender, EventArgs e)
        {
            pal_payment.Controls.Clear();
            phuongThucThanhToan = 1;

        }

        private void btn_creditCard_Click(object sender, EventArgs e)
        {
            pal_payment.Controls.Clear();
            pal_payment.Controls.Add(new uc_credirCard());
            phuongThucThanhToan =2;        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            CRUD_DetailOrder_BLL newBLL_DetailOrder = new CRUD_DetailOrder_BLL();
            List<CartItem> cartItems = CartItemManager.GetCartItems();

            // Chuyển đổi từ List<CartItem> sang List<Detail_Order>
            List<Detail_Order> orders = ConvertCartItemsToDetailOrders(cartItems);

            if (btn_print.Checked)
            {
                string filePath = "E:\\HoaDon.xlsx";

                CreateExcelFile(orders, filePath);

            }
            foreach(Detail_Order item in orders)
            {
                newBLL_DetailOrder.Insert_DetailOrder(item);
            }
            flow_pal_listOrder_Clear();
            CartItemManager.ClearCartItems();
            
        }
        private List<Detail_Order> ConvertCartItemsToDetailOrders(List<CartItem> cartItems)
        {
            return cartItems.Select(cartItem => new Detail_Order
            {
                MonAnId = cartItem.IdMonAn,
                customerName = nameCustomer,
                SoLuong = cartItem.Quantity,
                DonGia = (float)cartItem.Price,
                Catergory_Id = cartItem.Catergory_Id,
                PhuongThucThanhToanId = phuongThucThanhToan,
                NhanVienId = Stored_Login_Infor.GetCurrentUser(),
                trangThai = "đã thanh toán",
                ngayLap = DateTime.Now
                // Các giá trị khác của Detail_Order bạn có thể cần chuyển đổi
            }).ToList();
        }
        private void CreateExcelFile(List<Detail_Order> orders, string filePath)
        {
            // Tạo một tệp Excel mới
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("HoaDon");

                // Tiêu đề cột
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Món Ăn ID";
                worksheet.Cell(1, 3).Value = "Tên Khách Hàng";
                worksheet.Cell(1, 4).Value = "Số Lượng";
                worksheet.Cell(1, 5).Value = "Đơn Giá";
                worksheet.Cell(1, 6).Value = "Phương Thức Thanh Toán ID";
                worksheet.Cell(1, 7).Value = "Nhân Viên ID";
                worksheet.Cell(1, 8).Value = "Trạng Thái";
                worksheet.Cell(1, 9).Value = "Ngày Lập";

                // Dữ liệu
                for (int i = 0; i < orders.Count; i++)
                {
                    var order = orders[i];
                    int row = i + 2;

                    worksheet.Cell(row, 1).Value = order.Id;
                    worksheet.Cell(row, 2).Value = order.MonAnId;
                    worksheet.Cell(row, 3).Value = order.customerName;
                    worksheet.Cell(row, 4).Value = order.SoLuong;
                    worksheet.Cell(row, 5).Value = order.DonGia;
                    worksheet.Cell(row, 6).Value = order.PhuongThucThanhToanId;
                    worksheet.Cell(row, 7).Value = order.NhanVienId;
                    worksheet.Cell(row, 8).Value = order.trangThai;
                    worksheet.Cell(row, 9).Value = order.ngayLap;
                }

                // Auto-fit columns for better readability
                worksheet.Columns().AdjustToContents();

                // Format header row
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

                // Lưu tệp Excel
                workbook.SaveAs(filePath);
            }
        }


    }
}
