namespace Gimji.GUI.Login_Register
{
    partial class uc_Forgot
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Forgot));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pal_header = new Guna.UI2.WinForms.Guna2Panel();
            lb_hello = new Label();
            lb_forgot = new Label();
            txt_gmail = new Guna.UI2.WinForms.Guna2TextBox();
            btn_submit = new Guna.UI2.WinForms.Guna2Button();
            btn_back = new Guna.UI2.WinForms.Guna2CircleButton();
            pal_header.SuspendLayout();
            SuspendLayout();
            // 
            // pal_header
            // 
            pal_header.BackColor = Color.Transparent;
            pal_header.Controls.Add(lb_hello);
            pal_header.Controls.Add(lb_forgot);
            pal_header.CustomizableEdges = customizableEdges1;
            pal_header.Location = new Point(3, 53);
            pal_header.Name = "pal_header";
            pal_header.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pal_header.Size = new Size(445, 141);
            pal_header.TabIndex = 2;
            // 
            // lb_hello
            // 
            lb_hello.AutoSize = true;
            lb_hello.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_hello.ForeColor = Color.FromArgb(233, 214, 147);
            lb_hello.Location = new Point(19, 57);
            lb_hello.Name = "lb_hello";
            lb_hello.Size = new Size(382, 46);
            lb_hello.TabIndex = 2;
            lb_hello.Text = "Don’t worry ! It happens. Please enter the \r\ngmail we will send the password in this gmail.";
            // 
            // lb_forgot
            // 
            lb_forgot.AutoSize = true;
            lb_forgot.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lb_forgot.ForeColor = Color.FromArgb(233, 214, 147);
            lb_forgot.Location = new Point(14, 14);
            lb_forgot.Name = "lb_forgot";
            lb_forgot.Size = new Size(274, 41);
            lb_forgot.TabIndex = 1;
            lb_forgot.Text = "Forgot Password ?";
            // 
            // txt_gmail
            // 
            txt_gmail.BackColor = Color.Transparent;
            txt_gmail.BorderColor = Color.FromArgb(246, 246, 246);
            txt_gmail.BorderRadius = 10;
            txt_gmail.CustomizableEdges = customizableEdges3;
            txt_gmail.DefaultText = "";
            txt_gmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_gmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_gmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_gmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_gmail.FillColor = Color.FromArgb(246, 246, 246);
            txt_gmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_gmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txt_gmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_gmail.Location = new Point(18, 212);
            txt_gmail.Margin = new Padding(4, 4, 4, 4);
            txt_gmail.Name = "txt_gmail";
            txt_gmail.PasswordChar = '\0';
            txt_gmail.PlaceholderForeColor = Color.Gray;
            txt_gmail.PlaceholderText = "Enter your gmail";
            txt_gmail.SelectedText = "";
            txt_gmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txt_gmail.Size = new Size(430, 56);
            txt_gmail.TabIndex = 3;
            // 
            // btn_submit
            // 
            btn_submit.BorderRadius = 20;
            btn_submit.CustomizableEdges = customizableEdges5;
            btn_submit.DisabledState.BorderColor = Color.DarkGray;
            btn_submit.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_submit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_submit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_submit.FillColor = Color.FromArgb(151, 118, 68);
            btn_submit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_submit.ForeColor = Color.White;
            btn_submit.Location = new Point(280, 326);
            btn_submit.Name = "btn_submit";
            btn_submit.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_submit.Size = new Size(168, 53);
            btn_submit.TabIndex = 7;
            btn_submit.Text = "SUBMIT";
            btn_submit.Click += btn_submit_Click;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.DisabledState.BorderColor = Color.DarkGray;
            btn_back.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_back.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_back.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_back.FillColor = Color.Goldenrod;
            btn_back.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_back.ForeColor = Color.White;
            btn_back.Image = (Image)resources.GetObject("btn_back.Image");
            btn_back.Location = new Point(23, 8);
            btn_back.Name = "btn_back";
            btn_back.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btn_back.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btn_back.Size = new Size(40, 39);
            btn_back.TabIndex = 8;
            btn_back.Click += btn_back_Click;
            // 
            // uc_Forgot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 0, 0);
            Controls.Add(btn_back);
            Controls.Add(btn_submit);
            Controls.Add(txt_gmail);
            Controls.Add(pal_header);
            Name = "uc_Forgot";
            Size = new Size(475, 670);
            pal_header.ResumeLayout(false);
            pal_header.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pal_header;
        private Label lb_forgot;
        private Label lb_hello;
        private Guna.UI2.WinForms.Guna2TextBox txt_gmail;
        private Guna.UI2.WinForms.Guna2Button btn_submit;
        private Guna.UI2.WinForms.Guna2CircleButton btn_back;
    }
}
