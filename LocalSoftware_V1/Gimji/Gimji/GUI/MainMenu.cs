using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Gimji.DAO;
using Gimji.DTO;
using Gimji.GUI.Home;
using Gimji.GUI.Menu;
using Gimji.GUI.PayMent;
using Gimji.GUI.Management;
using Gimji.GUI.Order;
using Gimji.GUI.Kitchen;
using Gimji.GUI.Login_Register;
using Gimji.BLL;

namespace Gimji
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();
            date_time.Text = DateTime.Now.ToLongDateString();
            guna_btn_Management.Enabled = true;
            guna_btn_Management.Visible = true;
            CRUD_Staff_BLL newBLL = new CRUD_Staff_BLL();
            List<String> idNhanVien = newBLL.getAllStaffIds();
            string currentUser = Stored_Login_Infor.GetCurrentUser();
            if (currentUser != null && idNhanVien.Contains(currentUser))
            {
                guna_btn_Management.Enabled = false;
                guna_btn_Management.Visible = false;
                lbl_Management.Visible = false;
            }
            uc_Home home = new uc_Home();
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(home);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            uc_Menu uc_Menu = new uc_Menu();
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(uc_Menu);
        }

        private void guna_btn_Payment_Click(object sender, EventArgs e)
        {
            uc_Payment payment = new uc_Payment();
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(payment);
        }



        private void guna_btn_Home_Click(object sender, EventArgs e)
        {
            uc_Home home = new uc_Home();
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(home);
        }

        private void guna_btn_Menu_Click_1(object sender, EventArgs e)
        {

            //fl_Panel_Thuc_Don.Controls.Add(new uc_MonAn());
            //panel_Order.Controls.Add(new uc_Order());
            uc_Menu uc_Menu = new uc_Menu();
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(uc_Menu);
        }



        private void guna_btn_Order_Click(object sender, EventArgs e)
        {
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(new Gimji.GUI.Order.uc_Order());

            //panel_Menu.Controls.Add(new uc_Kitchen());

        }

        private void guna_btn_Management_Click(object sender, EventArgs e)
        {
            topPanel.BackColor = Color.FromArgb(127, 21, 21);
            uc_Management management = new uc_Management();
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(management);
        }

        private void guna_btn_exit_Click(object sender, EventArgs e)
        {
            Main_Login_Register loginF = new Main_Login_Register();
            Stored_Login_Infor.Logout();
            this.Hide();
            loginF.ShowDialog();
            Application.Exit();
        }

        private void btn_logo_Click(object sender, EventArgs e)
        {
            uc_Home home = new uc_Home();
            panel_Menu.Controls.Clear();
            panel_Menu.Controls.Add(home);
        }
    }
}