using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gimji.GUI.Management.StaffManagement;
using Gimji.GUI.Management.CustomerManagement;
using Gimji.GUI.Management.ProductManagement;
using Gimji.GUI.Management.ShiftManagement;
using Gimji.GUI.Management.OrderManagement;
using Gimji.GUI.Management.RevenueManagement;
using Gimji.GUI.Management.Inventory_Management;

namespace Gimji.GUI.Management
{
    public partial class uc_Management : UserControl
    {
        private List<Panel> panelList = new List<Panel>();
        public uc_Management()
        {
            InitializeComponent();
        }


        /// stop flickering white effect in screen form when loaded
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }



        private void pal_staff_MouseClick(object sender, MouseEventArgs e)
        {
            pal_right.Controls.Clear();
            uc_staffManagement staffManagement = new uc_staffManagement();
            pal_right.Controls.Add(staffManagement);
        }

        private void uc_Management_Load(object sender, EventArgs e)
        {
            ///default UI
            pal_right.Controls.Clear();
            pal_right.Controls.Add(new uc_revenueManagement());
            ////
            panelList.Add(pal_customer);
            panelList.Add(pal_product);
            panelList.Add(pal_shift);
            panelList.Add(pal_orer);
            panelList.Add(pal_sale);
            panelList.Add(pal_staff);
            panelList.Add(pal_revenue);
            panelList.Add(pal_inventory);

            foreach (Panel panel in panelList)
            {
                panel.MouseEnter += Panel_MouseEnter;
                panel.MouseLeave += Panel_MouseLeave;
            }
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            // Change the background color or apply the hover effect when the mouse enters the panel
            if (sender is Panel)
            {
                Panel panel = (Panel)sender;
                panel.BackColor = Color.FromArgb(103, 33, 33);
                // You can customize the hover effect as needed
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            // Revert the background color to the original color when the mouse leaves the panel
            if (sender is Panel)
            {
                Panel panel = (Panel)sender;
                panel.BackColor = Color.FromArgb(136, 21, 57); // Set it back to the original color
                                                               // You can customize the revert effect as needed
            }
        }

        private void pal_customer_MouseClick(object sender, MouseEventArgs e)
        {
            pal_right.Controls.Clear();
            uc_customerManagement uc_CustomerManagement = new uc_customerManagement();
            pal_right.Controls.Add(uc_CustomerManagement);
        }

        private void pal_product_MouseClick(object sender, MouseEventArgs e)
        {

            pal_right.Controls.Clear();
            uc_productManagement productManagement = new uc_productManagement();
            pal_right.Controls.Add(productManagement);
        }

        private void pal_shift_MouseClick(object sender, MouseEventArgs e)
        {
            pal_right.Controls.Clear();
            uc_shiftManagement uc_ShiftManagement = new uc_shiftManagement();
            pal_right.Controls.Add(uc_ShiftManagement);
        }

        private void pal_sale_MouseClick(object sender, MouseEventArgs e)
        {
            pal_right.Controls.Clear();
            pal_right.Controls.Add(new uc_SaleManagement());
        }

        private void pal_orer_MouseClick(object sender, MouseEventArgs e)
        {
            pal_right.Controls.Clear();
            pal_right.Controls.Add(new uc_OrderMangement());
        }

        private void pal_inventory_MouseClick(object sender, MouseEventArgs e)
        {
            pal_right.Controls.Clear();
            pal_right.Controls.Add(new uc_inventoryManagement());
        }

        private void pal_revenue_MouseClick(object sender, MouseEventArgs e)
        {
            pal_right.Controls.Clear();
            pal_right.Controls.Add(new uc_revenueManagement());
        }
    }
}
