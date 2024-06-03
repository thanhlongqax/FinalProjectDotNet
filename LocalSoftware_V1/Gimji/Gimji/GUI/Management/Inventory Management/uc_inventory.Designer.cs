namespace Gimji.GUI.Management.Inventory_Management
{
    partial class uc_inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_inventory));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pal_sale = new Guna.UI2.WinForms.Guna2Panel();
            pic_image = new Guna.UI2.WinForms.Guna2PictureBox();
            lb_status = new Label();
            lb_price = new Label();
            btn_remove = new Guna.UI2.WinForms.Guna2Button();
            btn_edit = new Guna.UI2.WinForms.Guna2Button();
            lb_sold = new Label();
            lb_available = new Label();
            lb_name = new Label();
            lb_type = new Label();
            pal_sale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_image).BeginInit();
            SuspendLayout();
            // 
            // pal_sale
            // 
            pal_sale.BackColor = Color.Transparent;
            pal_sale.BorderColor = Color.FromArgb(224, 224, 224);
            pal_sale.BorderRadius = 5;
            pal_sale.BorderThickness = 1;
            pal_sale.Controls.Add(pic_image);
            pal_sale.Controls.Add(lb_status);
            pal_sale.Controls.Add(lb_price);
            pal_sale.Controls.Add(btn_remove);
            pal_sale.Controls.Add(btn_edit);
            pal_sale.Controls.Add(lb_sold);
            pal_sale.Controls.Add(lb_available);
            pal_sale.Controls.Add(lb_name);
            pal_sale.Controls.Add(lb_type);
            pal_sale.CustomizableEdges = customizableEdges7;
            pal_sale.Location = new Point(0, 0);
            pal_sale.Name = "pal_sale";
            pal_sale.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pal_sale.Size = new Size(929, 48);
            pal_sale.TabIndex = 5;
            // 
            // pic_image
            // 
            pic_image.CustomizableEdges = customizableEdges1;
            pic_image.Image = (Image)resources.GetObject("pic_image.Image");
            pic_image.ImageRotate = 0F;
            pic_image.Location = new Point(14, 7);
            pic_image.Name = "pic_image";
            pic_image.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pic_image.Size = new Size(31, 30);
            pic_image.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_image.TabIndex = 8;
            pic_image.TabStop = false;
            // 
            // lb_status
            // 
            lb_status.AutoSize = true;
            lb_status.FlatStyle = FlatStyle.Flat;
            lb_status.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_status.ForeColor = Color.PaleGreen;
            lb_status.Location = new Point(705, 11);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(72, 23);
            lb_status.TabIndex = 7;
            lb_status.Text = "In Stock";
            // 
            // lb_price
            // 
            lb_price.AutoSize = true;
            lb_price.FlatStyle = FlatStyle.Flat;
            lb_price.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_price.ForeColor = SystemColors.ButtonHighlight;
            lb_price.Location = new Point(589, 11);
            lb_price.Name = "lb_price";
            lb_price.Size = new Size(76, 23);
            lb_price.TabIndex = 6;
            lb_price.Text = "30.000 D";
            // 
            // btn_remove
            // 
            btn_remove.BorderRadius = 5;
            btn_remove.CustomizableEdges = customizableEdges3;
            btn_remove.DisabledState.BorderColor = Color.DarkGray;
            btn_remove.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_remove.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_remove.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_remove.FillColor = Color.Transparent;
            btn_remove.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_remove.ForeColor = Color.White;
            btn_remove.Image = (Image)resources.GetObject("btn_remove.Image");
            btn_remove.ImageSize = new Size(25, 25);
            btn_remove.Location = new Point(875, 10);
            btn_remove.Name = "btn_remove";
            btn_remove.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_remove.Size = new Size(27, 27);
            btn_remove.TabIndex = 5;
            btn_remove.Click += btn_remove_Click;
            // 
            // btn_edit
            // 
            btn_edit.BorderRadius = 5;
            btn_edit.CustomizableEdges = customizableEdges5;
            btn_edit.DisabledState.BorderColor = Color.DarkGray;
            btn_edit.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_edit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_edit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_edit.FillColor = Color.Transparent;
            btn_edit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_edit.ForeColor = Color.White;
            btn_edit.HoverState.BorderColor = Color.White;
            btn_edit.Image = (Image)resources.GetObject("btn_edit.Image");
            btn_edit.ImageSize = new Size(25, 25);
            btn_edit.Location = new Point(845, 10);
            btn_edit.Name = "btn_edit";
            btn_edit.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_edit.Size = new Size(27, 27);
            btn_edit.TabIndex = 4;
            btn_edit.Click += btn_edit_Click;
            // 
            // lb_sold
            // 
            lb_sold.AutoSize = true;
            lb_sold.FlatStyle = FlatStyle.Flat;
            lb_sold.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_sold.ForeColor = SystemColors.ButtonHighlight;
            lb_sold.Location = new Point(487, 11);
            lb_sold.Name = "lb_sold";
            lb_sold.Size = new Size(28, 23);
            lb_sold.TabIndex = 3;
            lb_sold.Text = "30";
            // 
            // lb_available
            // 
            lb_available.AutoSize = true;
            lb_available.BackColor = Color.Transparent;
            lb_available.FlatStyle = FlatStyle.Flat;
            lb_available.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_available.ForeColor = SystemColors.ButtonHighlight;
            lb_available.Location = new Point(345, 11);
            lb_available.Name = "lb_available";
            lb_available.Size = new Size(35, 23);
            lb_available.TabIndex = 2;
            lb_available.Text = "120";
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.FlatStyle = FlatStyle.Flat;
            lb_name.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_name.ForeColor = SystemColors.ButtonHighlight;
            lb_name.Location = new Point(52, 11);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(71, 23);
            lb_name.TabIndex = 1;
            lb_name.Text = "Chicken";
            // 
            // lb_type
            // 
            lb_type.AutoSize = true;
            lb_type.FlatStyle = FlatStyle.Flat;
            lb_type.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_type.ForeColor = SystemColors.ButtonHighlight;
            lb_type.Location = new Point(201, 11);
            lb_type.Name = "lb_type";
            lb_type.Size = new Size(67, 23);
            lb_type.TabIndex = 0;
            lb_type.Text = "Kimbak";
            // 
            // uc_inventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pal_sale);
            Name = "uc_inventory";
            Size = new Size(931, 68);
            pal_sale.ResumeLayout(false);
            pal_sale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_image).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pal_sale;
        private Guna.UI2.WinForms.Guna2PictureBox pic_image;
        private Label lb_status;
        private Label lb_price;
        private Guna.UI2.WinForms.Guna2Button btn_remove;
        private Guna.UI2.WinForms.Guna2Button btn_edit;
        private Label lb_sold;
        private Label lb_available;
        private Label lb_name;
        private Label lb_type;
    }
}
