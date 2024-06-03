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
    public partial class uc_Kitchen : UserControl
    {
        public uc_Kitchen()
        {
            InitializeComponent();
        }

        private void uc_Kitchen_Load(object sender, EventArgs e)
        {
            pal_listReport.Controls.Clear();
            flow_pal_list.Controls.Clear();
            for (int i = 0; i < 10; i++)
            {
                pal_listReport.Controls.Add(new uc_orderConfirm());
                flow_pal_list.Controls.Add(new uc_listFood());
            }

        }
    }
}
