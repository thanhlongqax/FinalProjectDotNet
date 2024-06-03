using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management.CustomerManagement
{
    public partial class uc_customer : UserControl
    {
        public event EventHandler BtnEditClick;
        public event EventHandler BtnRemoveClick;
        public uc_customer()
        {
            InitializeComponent();
        }

        #region Properties
        public string Name
        {
            get { return lb_name.Text; }
            set { lb_name.Text = value; }
        }

        public string ID
        {
            get { return lb_id.Text; }
            set { lb_id.Text = value; }
        }

        public int Stt
        {
            get { return Convert.ToInt32(lb_stt.Text); }
            set { lb_stt.Text = value.ToString(); }
        }

        public int Point
        {
            get { return Convert.ToInt32(lb_point.Text); }
            set { lb_point.Text = value.ToString(); }
        }

        #endregion

        public void btn_edit_Click(object sender, EventArgs e)
        {
            BtnEditClick?.Invoke(this, e);
        }

        public void btn_remove_Click(object sender, EventArgs e)
        {
            BtnRemoveClick?.Invoke(this, e);
        }
    }
}
