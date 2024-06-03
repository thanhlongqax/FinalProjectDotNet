using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management.OrderManagement
{
    public partial class uc_OrderMangement : UserControl
    {
        public uc_OrderMangement()
        {
            InitializeComponent();
        }

        private void uc_OrderMangement_Load(object sender, EventArgs e)
        {
            pal_listReport.Controls.Clear();
            for (int i = 0; i < 15; i++)
            {
                pal_listReport.Controls.Add(new uc_listOrder());
            }

        }
    }
}
