using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.PayMent
{
    public partial class uc_MonAn_Paymentcs : UserControl
    {
        int quantity;
        private int idProduct;
        private int idMonAn;
        private int idCategory;
        public event EventHandler BtnDeleteClick;
        public event EventHandler BtnMinusClick;
        public event EventHandler BtnPlusClick;
        public uc_MonAn_Paymentcs()
        {
            InitializeComponent();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            BtnDeleteClick?.Invoke(this, e);
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            
            BtnPlusClick?.Invoke(this, e);
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            
            // Cập nhật hiển thị số lượng trên Label hoặc TextBox

            if (quantity > 0)
            {
                BtnMinusClick?.Invoke(this, e);

            }
        }

        #region Properties

        public Image PictureBox
        {
            get { return pic_image.Image; }
            set {pic_image.Image = value; }
        }

        public String Name
        {
            get { return lb_name.Text; }
            set { lb_name.Text = value; }
        }
        public double Price
        {
            get { return Convert.ToDouble(lb_price.Text); }
            set { lb_price.Text = value.ToString(); }
        }

        public int Count
        {
            get { return quantity; }
            set { quantity = value;
                lb_quantity.Text = quantity.ToString();
            }
        }
        public int ID
        {
            get { return idProduct; }
            set { idProduct = value; }
        }
        public int idMonAns
        {
            get { return idMonAn; }
            set { idMonAn = value; }
        }
        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }
        #endregion
    }
}
