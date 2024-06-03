using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management.Inventory_Management
{
    public partial class uc_inventory : UserControl
    {
        public event EventHandler BtnEditClick;
        public event EventHandler BtnRemoveClick;
        public uc_inventory()
        {
            InitializeComponent();
        }
        #region Properties
        public String Type
        {
            get { return lb_type.Text; }
            set { lb_type.Text = value.ToString(); }
        }

        public string Available
        {
            get { return lb_available.Text; }
            set { lb_available.Text = value; }
        }
        public Image PictureBox
        {
            get { return pic_image.Image; }
            set { pic_image.Image = value; }
        }
        public string Sold
        {
            get { return lb_sold.Text; }
            set { lb_sold.Text = value; }
        }
        public string Name
        {
            get { return lb_name.Text; }
            set { lb_name.Text = value; }
        }

        public String Status
        {
            get { return lb_status.Text; }
            set { lb_status.Text = value; }
        }
        public String Price
        {
            get { return lb_price.Text; }
            set { lb_price.Text = value; }
        }


        #endregion

        private void btn_edit_Click(object sender, EventArgs e)
        {
            BtnEditClick?.Invoke(this, e);
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            BtnRemoveClick?.Invoke(this, e);
        }
    }
}
