using Gimji.GUI.Management.SaleManagement;
using Guna.UI2.WinForms;
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
    public partial class Main_Login_Register : Form
    {
        private uc_Login loginControl;
        private uc_Register registerControl;
        private uc_Forgot forgotControl;
        private bool registeredSuccessfully = false;
        private bool forgotSuccessfully = false;
        public Main_Login_Register()
        {
            InitializeComponent();
            //loginControl = new uc_Login();
            //registerControl = new uc_Register();
            //forgotControl = new uc_Forgot();

            //Đăng ký xử lý sự kiện
            //registerControl.btn_registerClick += (sender, e) => RegisteredSuccessfully();
            //loginControl.btn_forgot += (sender, e) => ForgotClick();
            //forgotControl.btn_forgotClick += (sender, e) => ForgotSuccessfully();
            //forgotControl.btn_forgotBack += (sender, e) => ForgotBackClick();

        }
        private void Main_Login_Register_Load(object sender, EventArgs e)
        {
            ShowLoginScreen();
        }
        private void ShowLoginScreen()
        {
            loginControl = new uc_Login();
            registerControl = new uc_Register();
            forgotControl = new uc_Forgot();

            registerControl.btn_registerClick += (sender, e) => RegisteredSuccessfully();
            loginControl.btn_forgot += (sender, e) => ForgotClick();
            forgotControl.btn_forgotClick += (sender, e) => ForgotSuccessfully();
            forgotControl.btn_forgotBack += (sender, e) => ForgotBackClick();

            setColorButton(btn_Login, btn_Register);
            pal_form.Controls.Clear();
            pal_form.Controls.Add(loginControl);

            if (registeredSuccessfully)
            {
                // Thực hiện các xử lý sau khi đăng ký thành công (nếu cần)
                registeredSuccessfully = false; // Đặt lại cờ
            }
            if(forgotSuccessfully)
            {
                forgotSuccessfully = false;
            }
        }
        private void ForgotClick()
        {

            pal_header.Visible = false;
            pal_form.Visible = false;
            //pal_forgot.Controls.Clear();
            forgotControl.Visible = true;
            pal_forgot.Controls.Add(forgotControl);
        }
        private void ForgotBackClick()
        {

            //pal_forgot.Controls.Clear();
            forgotControl.Visible = false;
            pal_header.Visible=true;
            pal_form.Visible=true;
            

            //pal_header.Visible = true;
            //pal_form.Visible = true;
        }
        private void ForgotSuccessfully()
        {
            forgotControl.Visible = false;
            pal_header.Visible = true;
            pal_form.Visible = true;
            forgotSuccessfully = true;
            //ShowLoginScreen();
        }
        private void RegisteredSuccessfully()
        {
            registeredSuccessfully = true;
            ShowLoginScreen();
        }
        

        private void btn_Login_Click(object sender, EventArgs e)
        {
            setColorButton(btn_Login, btn_Register);
            pal_form.Controls.Clear();
            pal_form.Controls.Add(loginControl);
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            setColorButton(btn_Register, btn_Login);
            pal_form.Controls.Clear();
            pal_form.Controls.Add(registerControl);
        }

        private void setColorButton(Guna2Button btnStart, Guna2Button btnEnd)
        {
            btnStart.FillColor = Color.FromArgb(151, 118, 68);
            btnStart.ForeColor = Color.White;
            btnEnd.FillColor = Color.Transparent;
            btnEnd.ForeColor = Color.FromArgb(143, 125, 97);
        }

        
    }
}
