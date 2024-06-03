namespace Gimji.GUI.Management.OrderManagement
{
    partial class uc_listOrder
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_listOrder));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pal_order = new Guna.UI2.WinForms.Guna2Panel();
            label14 = new Label();
            lb_total = new Label();
            lb_date = new Label();
            lb_customer = new Label();
            btn_remove = new Guna.UI2.WinForms.Guna2Button();
            btn_edit_Staff = new Guna.UI2.WinForms.Guna2Button();
            lb_id = new Label();
            pal_order.SuspendLayout();
            SuspendLayout();
            // 
            // pal_order
            // 
            pal_order.BorderColor = Color.White;
            pal_order.BorderRadius = 5;
            pal_order.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pal_order.BorderThickness = 1;
            pal_order.Controls.Add(label14);
            pal_order.Controls.Add(lb_total);
            pal_order.Controls.Add(lb_date);
            pal_order.Controls.Add(lb_customer);
            pal_order.Controls.Add(btn_remove);
            pal_order.Controls.Add(btn_edit_Staff);
            pal_order.Controls.Add(lb_id);
            pal_order.CustomizableEdges = customizableEdges5;
            pal_order.Location = new Point(0, 0);
            pal_order.Name = "pal_order";
            pal_order.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pal_order.Size = new Size(890, 56);
            pal_order.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.FlatStyle = FlatStyle.Flat;
            label14.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.FromArgb(80, 209, 170);
            label14.Location = new Point(615, 15);
            label14.Name = "label14";
            label14.Size = new Size(94, 23);
            label14.TabIndex = 15;
            label14.Text = "Completed";
            // 
            // lb_total
            // 
            lb_total.AutoSize = true;
            lb_total.FlatStyle = FlatStyle.Flat;
            lb_total.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_total.ForeColor = SystemColors.ButtonHighlight;
            lb_total.Location = new Point(466, 15);
            lb_total.Name = "lb_total";
            lb_total.Size = new Size(66, 23);
            lb_total.TabIndex = 14;
            lb_total.Text = "125.000";
            // 
            // lb_date
            // 
            lb_date.AutoSize = true;
            lb_date.FlatStyle = FlatStyle.Flat;
            lb_date.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_date.ForeColor = SystemColors.ButtonHighlight;
            lb_date.Location = new Point(286, 15);
            lb_date.Name = "lb_date";
            lb_date.Size = new Size(83, 23);
            lb_date.TabIndex = 13;
            lb_date.Text = "11-2-2023";
            // 
            // lb_customer
            // 
            lb_customer.AutoSize = true;
            lb_customer.FlatStyle = FlatStyle.Flat;
            lb_customer.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_customer.ForeColor = SystemColors.ButtonHighlight;
            lb_customer.Location = new Point(134, 15);
            lb_customer.Name = "lb_customer";
            lb_customer.Size = new Size(95, 23);
            lb_customer.TabIndex = 12;
            lb_customer.Text = "Elephant67";
            // 
            // btn_remove
            // 
            btn_remove.BorderRadius = 5;
            btn_remove.CustomizableEdges = customizableEdges1;
            btn_remove.DisabledState.BorderColor = Color.DarkGray;
            btn_remove.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_remove.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_remove.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_remove.FillColor = Color.Transparent;
            btn_remove.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_remove.ForeColor = Color.White;
            btn_remove.Image = (Image)resources.GetObject("btn_remove.Image");
            btn_remove.ImageSize = new Size(25, 25);
            btn_remove.Location = new Point(804, 13);
            btn_remove.Name = "btn_remove";
            btn_remove.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_remove.Size = new Size(27, 27);
            btn_remove.TabIndex = 11;
            // 
            // btn_edit_Staff
            // 
            btn_edit_Staff.BorderRadius = 5;
            btn_edit_Staff.CustomizableEdges = customizableEdges3;
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
            btn_edit_Staff.Location = new Point(771, 13);
            btn_edit_Staff.Name = "btn_edit_Staff";
            btn_edit_Staff.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_edit_Staff.Size = new Size(27, 27);
            btn_edit_Staff.TabIndex = 10;
            // 
            // lb_id
            // 
            lb_id.AutoSize = true;
            lb_id.FlatStyle = FlatStyle.Flat;
            lb_id.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_id.ForeColor = SystemColors.ButtonHighlight;
            lb_id.Location = new Point(9, 15);
            lb_id.Name = "lb_id";
            lb_id.Size = new Size(55, 23);
            lb_id.TabIndex = 6;
            lb_id.Text = "#1234";
            // 
            // uc_listOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pal_order);
            Name = "uc_listOrder";
            Size = new Size(890, 68);
            pal_order.ResumeLayout(false);
            pal_order.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pal_order;
        private Label label14;
        private Label lb_total;
        private Label lb_date;
        private Label lb_customer;
        private Guna.UI2.WinForms.Guna2Button btn_remove;
        private Guna.UI2.WinForms.Guna2Button btn_edit_Staff;
        private Label lb_id;
    }
}
