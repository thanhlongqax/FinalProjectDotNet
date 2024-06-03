using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Kitchen
{
    public partial class uc_listFood : UserControl
    {
        public uc_listFood()
        {
            InitializeComponent();
        }

        private void btn_check_MouseClick(object sender, MouseEventArgs e)
        {
            if (btn_check.Checked)
            {
                btn_check.Checked = false;
            }
            else
            {
                btn_check.Checked = true;
            }
        }
    }
}
