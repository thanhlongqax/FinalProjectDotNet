using DocumentFormat.OpenXml.Vml;
using Gimji.DTO;
using Gimji.GUI.PayMent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Order
{
    public partial class uc_Order : UserControl
    {
        int id;
        public static string nameCustomer;
        double total;
        DateTime startDate = DateTime.Now;

        public uc_Order()
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

        private void uc_Order_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            flow_pal_Order_Clear();
            List<CartItem> cartItems = CartItemManager.GetCartItems();
            foreach (CartItem cartItem in cartItems)
            {
                id = cartItem.Id;
                Name = cartItem.Name;
                total += cartItem.Price;

            };
            uc_orderList uc_OrderList = new uc_orderList();
            uc_OrderList.Name = Name;
            uc_OrderList.IdProduct = id;
            uc_OrderList.IdStaff = Stored_Login_Infor.GetCurrentUser();
            uc_OrderList.Price = total;
            uc_OrderList.startDate = startDate.ToString("HH:mm dd/MM");
            uc_OrderList.BtEditClick += (s, eventArgs) =>
            {
                nameCustomer = uc_OrderList.nameCustomer;
                uc_OrderList.lbl_NameDaNhap.Text = nameCustomer;
                uc_OrderList.txt_customerNameDaNhap.Visible = false;
                uc_OrderList.lbl_NameDaNhap.Visible =true;

            };
            pal_listOrder.Controls.Add(uc_OrderList);
        }
        private void flow_pal_Order_Clear()
        {
            if (pal_listOrder != null)
            {
                List<Control> controlsToRemove = new List<Control>();

                foreach (Control control in pal_listOrder.Controls)
                {
                    if (control is uc_orderList)
                    {
                        // Thêm các uc_Product cần xóa vào danh sách tạm thời
                        controlsToRemove.Add(control);
                    }
                }
                // Xóa tất cả các uc_Product từ danh sách tạm thời
                foreach (Control controlToRemove in controlsToRemove)
                {
                    pal_listOrder.Controls.Remove(controlToRemove);

                }
            }

        }
    }

}
