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

namespace Gimji.GUI.Management.ProductManagement
{
    public partial class uc_product : UserControl
    {
        private int idProduct;
        private int idCategory;
        public event EventHandler BtnEditClick;
        public event EventHandler BtnRemoveClick;
        public uc_product()
        {
            InitializeComponent();
        }

        #region Properties
        public int ID {
            get { return idProduct; }
            set { idProduct = value; }
        }
        public Image PictureBox
        {
            get { return pic_image.Image; }
            set { pic_image.Image = value; }
        }
        public string NameTxt
        {
            get { return txt_NameDish.Text; }
            set { txt_NameDish.Text = value.ToString(); }
        }
        public double PriceTxt
        {
            get { return Convert.ToDouble(txt_priceDish.Text); }
            set { txt_priceDish.Text = value.ToString(); }
        }
        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        #endregion

        public void btn_Edit_Click(object sender, EventArgs e)
        {
            BtnEditClick?.Invoke(this, e);
        }

        public void btn_Delete_Click(object sender, EventArgs e)
        {
            BtnRemoveClick?.Invoke(this, e);
        }
    }
}
