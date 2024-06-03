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
    public partial class uc_Register : UserControl
    {
        public event EventHandler btn_registerClick;
        public uc_Register()
        {
            InitializeComponent();
        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_confirmPass.Text))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_password.Text != txt_confirmPass.Text)
            {
                MessageBox.Show("Mật Khẩu Không Trùng Khớp Vui Lòng Nhập Lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_password.Text.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 8 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Customer customer = new Customer();
                SignUp_BLL signUp_BLL = new SignUp_BLL();
                customer.userName = txt_username.Text;
                customer.Password = txt_password.Text;
                signUp_BLL.signUp_BLL(customer);
                OnRegistrationSuccess();
            }
        }
        private void OnRegistrationSuccess()
        {
            btn_registerClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
