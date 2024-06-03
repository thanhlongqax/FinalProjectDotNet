using DocumentFormat.OpenXml.Presentation;
using Guna.UI2.WinForms;
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
    public partial class uc_orderList : UserControl
    {
        public event EventHandler BtnDeleteClick;
        public event EventHandler BtEditClick;
        public Guna2TextBox txt_customerNameDaNhap;
        public Guna2HtmlLabel lbl_NameDaNhap;
        int quantity;
        private int idProduct;
        private int idCategory;
        public uc_orderList()
        {
            InitializeComponent();
            lbl_NameDaNhap = lbl_customerName;
            txt_customerNameDaNhap = txt_customer_input;
            lbl_customerName = lbl_NameDaNhap;
            lbl_customerName.Visible = false;
            txt_customer_input = txt_customerNameDaNhap;

        }

        private void btn_edit_Staff_Click(object sender, EventArgs e)
        {
            BtEditClick?.Invoke(this, e);
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            BtnDeleteClick?.Invoke(this, e);
        }
        #region Properties
        public int IdProduct
        {
            get { return idProduct; }
            set { idProduct = value; }
        }
        public string IdStaff
        {
            get { return lb_id.Text; }
            set { lb_id.Text = value; }
        }
        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }
        public String nameCustomers
        {
            get
            {
                return lbl_customerName.Text;

            }
            set
            {
                txt_customer_input.Text = nameCustomer;
            }
        }
        public String nameCustomer
        {
            get { return txt_customer_input.Text; }
            set
            {
                txt_customer_input.Text = value;
            }
        }
        public String startDate
        {
            get { return lb_date.Text; }
            set { lb_date.Text = value; }
        }
        public double Price
        {
            get { return Convert.ToDouble(lb_total.Text); }
            set { lb_total.Text = value.ToString(); }
        }

        public String Status
        {
            get { return lb_Status.Text; }
            set
            {
                lb_Status.Text = value;
            }
        }
        #endregion
    }
}
