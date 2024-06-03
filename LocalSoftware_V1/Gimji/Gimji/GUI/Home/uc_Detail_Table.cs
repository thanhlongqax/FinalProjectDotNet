using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Home
{
    public partial class uc_Detail_Table : UserControl
    {
        public uc_Detail_Table()
        {
            InitializeComponent();
        }

        #region Properties
        [Category("Custom Props")]
        public string Name
        {
            get { return lb_Name.Text; }
            set { lb_Name.Text = value; }
        }

        [Category("Custom Props")]
        public string Time
        {
            get { return lb_Time.Text; }
            set { lb_Time.Text = value; }
        }
        [Category("Custom Props")]
        public string Num_Guest
        {
            get { return lb_NumGuest.Text; }
            set { lb_NumGuest.Text = value; }
        }

        #endregion


        private void btn_Remove_Click(object sender, EventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
