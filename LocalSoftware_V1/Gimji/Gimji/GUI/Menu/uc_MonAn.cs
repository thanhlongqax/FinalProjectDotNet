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

namespace Gimji.GUI.Menu
{
    public partial class uc_MonAn : UserControl
    {
        private int idProduct;
        private int idCategory;
        public event EventHandler BtnBuyClick;
        public uc_MonAn()
        {
            InitializeComponent();
        }

        #region Properties
        public int ID
        {
            get { return idProduct; }
            set { idProduct = value; }
        }
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
        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }
        #endregion


        private void btn_Buy_Click(object sender, EventArgs e)
        {
            BtnBuyClick?.Invoke(this, e);
        }
    }
}
