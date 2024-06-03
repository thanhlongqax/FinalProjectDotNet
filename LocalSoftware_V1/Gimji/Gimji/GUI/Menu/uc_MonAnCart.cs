using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Menu
{
    public partial class uc_MonAnCart : UserControl
    {
        int quantity;
        private int idProduct;
        private int idMonAn;
        private int idCategory;
        public event EventHandler BtnDeleteClick;
        public event EventHandler BtnMinusClick;
        public event EventHandler BtnPlusClick;
        public uc_MonAnCart()
        {
            InitializeComponent();
        }

        private void uc_MonAnCart_Load(object sender, EventArgs e)
        {

        }

        private void btn_Plus_Click(object sender, EventArgs e)
        {
            BtnPlusClick?.Invoke(this, e);
            /*quantity++;
            ;*/
            
        }

        private void btn_Minus_Click(object sender, EventArgs e)
        {
            
            if (quantity > 0)
            {
                BtnMinusClick?.Invoke(this, e);
                //quantity--;
                // Cập nhật hiển thị số lượng trên Label hoặc TextBox

            }
            
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            BtnDeleteClick?.Invoke(this, e);
        }


        #region Properties

        public Image PictureBox
        {
            get { return pic_DishPicture.Image; }
            set { pic_DishPicture.Image = value; }
        }

        public String Name
        {
            get { return txt_DishName.Text; }
            set { txt_DishName.Text = value; }
        }
        public double Price
        {
            get { return Convert.ToDouble(txt_DishPrice.Text); }
            set { txt_DishPrice.Text = value.ToString(); }
        }

        public int Count
        {
            get { return quantity; }
            set { 
                quantity = value; 
                txt_Quanity.Text = quantity.ToString();
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
