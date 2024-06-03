using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management.SaleManagement
{
    public partial class uc_sale : UserControl
    {
        public event EventHandler BtnEditClick;
        public event EventHandler BtnRemoveClick;
        public uc_sale()
        {
            InitializeComponent();
        }

        private void pal_sale_MouseEnter(object sender, EventArgs e)
        {
            pal_sale.FillColor = Color.FromArgb(119, 24, 24);
        }

        private void pal_sale_MouseLeave(object sender, EventArgs e)
        {
            pal_sale.FillColor = Color.Transparent;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            BtnEditClick?.Invoke(this, e);
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            BtnRemoveClick?.Invoke(this, e);
        }

        #region Properties
        public int Stt
        {
            get { return Convert.ToInt32(lb_stt.Text); }
            set { lb_stt.Text = value.ToString(); }
        }

        public string Id
        {
            get { return lb_id.Text; }
            set { lb_id.Text = value; }
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


        #endregion
    }
}
