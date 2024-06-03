namespace Gimji.GUI.Management.StaffManagement
{
    partial class uc_staff
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_staff));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna_pal_staff = new Guna.UI2.WinForms.Guna2Panel();
            btn_remove = new Guna.UI2.WinForms.Guna2Button();
            btn_edit_Staff = new Guna.UI2.WinForms.Guna2Button();
            lb_position = new Label();
            lb_name = new Label();
            lb_id = new Label();
            lb_stt = new Label();
            guna_pal_staff.SuspendLayout();
            SuspendLayout();
            // 
            // guna_pal_staff
            // 
            guna_pal_staff.BackColor = Color.Transparent;
            guna_pal_staff.BorderColor = Color.FromArgb(224, 224, 224);
            guna_pal_staff.BorderRadius = 5;
            guna_pal_staff.BorderThickness = 1;
            guna_pal_staff.Controls.Add(btn_remove);
            guna_pal_staff.Controls.Add(btn_edit_Staff);
            guna_pal_staff.Controls.Add(lb_position);
            guna_pal_staff.Controls.Add(lb_name);
            guna_pal_staff.Controls.Add(lb_id);
            guna_pal_staff.Controls.Add(lb_stt);
            guna_pal_staff.CustomizableEdges = customizableEdges11;
            guna_pal_staff.Location = new Point(0, 0);
            guna_pal_staff.Name = "guna_pal_staff";
            guna_pal_staff.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna_pal_staff.Size = new Size(546, 37);
            guna_pal_staff.TabIndex = 2;
            guna_pal_staff.MouseEnter += guna_pal_staff_MouseEnter;
            guna_pal_staff.MouseLeave += guna_pal_staff_MouseLeave;
            // 
            // btn_remove
            // 
            btn_remove.BorderRadius = 5;
            btn_remove.CustomizableEdges = customizableEdges7;
            btn_remove.DisabledState.BorderColor = Color.DarkGray;
            btn_remove.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_remove.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_remove.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_remove.FillColor = Color.Transparent;
            btn_remove.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_remove.ForeColor = Color.White;
            btn_remove.Image = (Image)resources.GetObject("btn_remove.Image");
            btn_remove.ImageSize = new Size(25, 25);
            btn_remove.Location = new Point(508, 6);
            btn_remove.Name = "btn_remove";
            btn_remove.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_remove.Size = new Size(27, 27);
            btn_remove.TabIndex = 5;
            btn_remove.Click += guna_btn_remove_Click;
            // 
            // btn_edit_Staff
            // 
            btn_edit_Staff.BorderRadius = 5;
            btn_edit_Staff.CustomizableEdges = customizableEdges9;
            btn_edit_Staff.DisabledState.BorderColor = Color.DarkGray;
            btn_edit_Staff.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_edit_Staff.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_edit_Staff.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_edit_Staff.FillColor = Color.Transparent;
            btn_edit_Staff.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_edit_Staff.ForeColor = Color.White;
            btn_edit_Staff.HoverState.BorderColor = Color.White;
            btn_edit_Staff.Image = (Image)resources.GetObject("btn_edit_Staff.Image");
            btn_edit_Staff.ImageSize = new Size(25, 25);
            btn_edit_Staff.Location = new Point(475, 6);
            btn_edit_Staff.Name = "btn_edit_Staff";
            btn_edit_Staff.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btn_edit_Staff.Size = new Size(27, 27);
            btn_edit_Staff.TabIndex = 4;
            btn_edit_Staff.Click += guna_btn_edit_Click;
            // 
            // lb_position
            // 
            lb_position.AutoSize = true;
            lb_position.FlatStyle = FlatStyle.Flat;
            lb_position.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_position.ForeColor = SystemColors.ButtonHighlight;
            lb_position.Location = new Point(344, 4);
            lb_position.Name = "lb_position";
            lb_position.Size = new Size(49, 28);
            lb_position.TabIndex = 3;
            lb_position.Text = "CEO";
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.BackColor = Color.Transparent;
            lb_name.FlatStyle = FlatStyle.Flat;
            lb_name.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_name.ForeColor = SystemColors.ButtonHighlight;
            lb_name.Location = new Point(218, 4);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(96, 28);
            lb_name.TabIndex = 2;
            lb_name.Text = "Elelphant";
            // 
            // lb_id
            // 
            lb_id.AutoSize = true;
            lb_id.FlatStyle = FlatStyle.Flat;
            lb_id.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_id.ForeColor = SystemColors.ButtonHighlight;
            lb_id.Location = new Point(102, 4);
            lb_id.Name = "lb_id";
            lb_id.Size = new Size(62, 28);
            lb_id.TabIndex = 1;
            lb_id.Text = "#1001";
            // 
            // lb_stt
            // 
            lb_stt.AutoSize = true;
            lb_stt.FlatStyle = FlatStyle.Flat;
            lb_stt.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_stt.ForeColor = SystemColors.ButtonHighlight;
            lb_stt.Location = new Point(13, 4);
            lb_stt.Name = "lb_stt";
            lb_stt.Size = new Size(20, 28);
            lb_stt.TabIndex = 0;
            lb_stt.Text = "1";
            // 
            // uc_staff
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna_pal_staff);
            Name = "uc_staff";
            Size = new Size(546, 37);
            guna_pal_staff.ResumeLayout(false);
            guna_pal_staff.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna_pal_staff;
        private Guna.UI2.WinForms.Guna2Button btn_edit_Staff;
        private Label lb_position;
        private Label lb_name;
        private Label lb_id;
        private Label lb_stt;
        private Guna.UI2.WinForms.Guna2Button btn_remove;
    }
}
