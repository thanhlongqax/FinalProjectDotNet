using Gimji.BLL;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Login_Register
{
    public partial class uc_Login : UserControl
    {
        public event EventHandler btn_forgot;
        public uc_Login()
        {
            InitializeComponent();
        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            Customer tk = new Customer();
            tk.userName = txt_username.Text;
            tk.Password = txt_password.Text;
            LoginBLL tkBLL = new LoginBLL();

            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string id = tkBLL.checkLoginData_Login_BLL(tk);
                if (id != null)
                {
                    Stored_Login_Infor.StorageUser(id);
                    this.ParentForm.Hide();
                    mainForm mainForm = new mainForm();
                    mainForm.ShowDialog();
                    this.ParentForm.Show();
                }
            }

        }

        private void lb_forgot_Click(object sender, EventArgs e)
        {

            btn_forgot?.Invoke(this, EventArgs.Empty);

        }

        private void lb_forgot_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lb_forgot_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
