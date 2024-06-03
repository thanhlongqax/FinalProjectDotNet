using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management.ShiftManagement
{
    public partial class uc_staffShift : UserControl
    {
        public event EventHandler btnClick;
        public uc_staffShift()
        {
            InitializeComponent();
        }
        #region Properties
        public String Name
        {
            get { return lb_name.Text; }
            set { lb_name.Text = value; }
        }
        public Color PanelColor
        {
            get { return pal_staff.FillColor; }
            set { pal_staff.FillColor = value; }
        }

        #endregion

        private void pal_staff_Click(object sender, EventArgs e)
        {

            btnClick.Invoke(this, e);
            //pal_staff.FillColor =Color.FromArgb(158, 210, 190);
        }
    }
}
