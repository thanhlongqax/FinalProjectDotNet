namespace Gimji.GUI.Login_Register
{
    partial class uc_Login
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pal_formLogin = new Guna.UI2.WinForms.Guna2Panel();
            btn_signIn = new Guna.UI2.WinForms.Guna2Button();
            check = new Guna.UI2.WinForms.Guna2CheckBox();
            lb_forgot = new Label();
            label2 = new Label();
            txt_password = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            txt_username = new Guna.UI2.WinForms.Guna2TextBox();
            pal_formLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pal_formLogin
            // 
            pal_formLogin.Controls.Add(btn_signIn);
            pal_formLogin.Controls.Add(check);
            pal_formLogin.Controls.Add(lb_forgot);
            pal_formLogin.Controls.Add(label2);
            pal_formLogin.Controls.Add(txt_password);
            pal_formLogin.Controls.Add(label1);
            pal_formLogin.Controls.Add(txt_username);
            pal_formLogin.CustomizableEdges = customizableEdges7;
            pal_formLogin.Location = new Point(0, 0);
            pal_formLogin.Name = "pal_formLogin";
            pal_formLogin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pal_formLogin.Size = new Size(444, 434);
            pal_formLogin.TabIndex = 2;
            // 
            // btn_signIn
            // 
            btn_signIn.BorderRadius = 20;
            btn_signIn.CustomizableEdges = customizableEdges1;
            btn_signIn.DisabledState.BorderColor = Color.DarkGray;
            btn_signIn.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_signIn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_signIn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_signIn.FillColor = Color.FromArgb(151, 118, 68);
            btn_signIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_signIn.ForeColor = Color.White;
            btn_signIn.Location = new Point(270, 301);
            btn_signIn.Name = "btn_signIn";
            btn_signIn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_signIn.Size = new Size(158, 50);
            btn_signIn.TabIndex = 6;
            btn_signIn.Text = "SIGN IN";
            btn_signIn.Click += btn_signIn_Click;
            // 
            // check
            // 
            check.AutoSize = true;
            check.CheckedState.BorderColor = Color.FromArgb(255, 180, 79);
            check.CheckedState.BorderRadius = 0;
            check.CheckedState.BorderThickness = 0;
            check.CheckedState.FillColor = Color.FromArgb(255, 180, 79);
            check.CheckMarkColor = Color.FromArgb(130, 0, 0);
            check.ForeColor = Color.FromArgb(233, 214, 147);
            check.Location = new Point(28, 225);
            check.Name = "check";
            check.Size = new Size(129, 24);
            check.TabIndex = 5;
            check.Text = "Remember me";
            check.UncheckedState.BorderColor = Color.White;
            check.UncheckedState.BorderRadius = 0;
            check.UncheckedState.BorderThickness = 0;
            check.UncheckedState.FillColor = Color.White;
            // 
            // lb_forgot
            // 
            lb_forgot.AutoSize = true;
            lb_forgot.ForeColor = Color.FromArgb(233, 214, 147);
            lb_forgot.Location = new Point(301, 225);
            lb_forgot.Name = "lb_forgot";
            lb_forgot.Size = new Size(127, 20);
            lb_forgot.TabIndex = 0;
            lb_forgot.Text = "Forgot password?";
            lb_forgot.Click += lb_forgot_Click;
            lb_forgot.MouseClick += lb_forgot_MouseClick;
            lb_forgot.MouseDoubleClick += lb_forgot_MouseDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(233, 214, 147);
            label2.Location = new Point(26, 125);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txt_password
            // 
            txt_password.BackColor = Color.Transparent;
            txt_password.BorderRadius = 22;
            txt_password.CustomizableEdges = customizableEdges3;
            txt_password.DefaultText = "";
            txt_password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_password.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_password.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_password.Location = new Point(21, 160);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '●';
            txt_password.PlaceholderForeColor = Color.Gray;
            txt_password.PlaceholderText = "Enter your password";
            txt_password.SelectedText = "";
            txt_password.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txt_password.Size = new Size(407, 49);
            txt_password.TabIndex = 2;
            txt_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(233, 214, 147);
            label1.Location = new Point(26, 23);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // txt_username
            // 
            txt_username.BackColor = Color.Transparent;
            txt_username.BorderRadius = 22;
            txt_username.CustomizableEdges = customizableEdges5;
            txt_username.DefaultText = "";
            txt_username.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_username.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_username.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_username.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_username.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_username.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_username.Location = new Point(21, 58);
            txt_username.Name = "txt_username";
            txt_username.PasswordChar = '\0';
            txt_username.PlaceholderForeColor = Color.Gray;
            txt_username.PlaceholderText = "Enter your username";
            txt_username.SelectedText = "";
            txt_username.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_username.Size = new Size(407, 49);
            txt_username.TabIndex = 0;
            // 
            // uc_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 0, 0);
            Controls.Add(pal_formLogin);
            Name = "uc_Login";
            Size = new Size(445, 434);
            pal_formLogin.ResumeLayout(false);
            pal_formLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pal_formLogin;
        private Guna.UI2.WinForms.Guna2Button btn_signIn;
        private Guna.UI2.WinForms.Guna2CheckBox check;
        private Label lb_forgot;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txt_password;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_username;
    }
}
