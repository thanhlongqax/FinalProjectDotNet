namespace Gimji.GUI.Management.ProductManagement
{
    partial class uc_product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_product));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pal_product = new Guna.UI2.WinForms.Guna2Panel();
            txt_priceDish = new TextBox();
            btn_Edit = new Guna.UI2.WinForms.Guna2Button();
            txt_NameDish = new TextBox();
            btn_Delete = new Guna.UI2.WinForms.Guna2CircleButton();
            pic_image = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            pal_product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_image).BeginInit();
            SuspendLayout();
            // 
            // pal_product
            // 
            pal_product.BackColor = Color.Transparent;
            pal_product.BorderRadius = 10;
            pal_product.Controls.Add(txt_priceDish);
            pal_product.Controls.Add(btn_Edit);
            pal_product.Controls.Add(txt_NameDish);
            pal_product.Controls.Add(btn_Delete);
            pal_product.Controls.Add(pic_image);
            pal_product.CustomizableEdges = customizableEdges5;
            pal_product.FillColor = Color.White;
            pal_product.Location = new Point(0, 0);
            pal_product.Margin = new Padding(3, 2, 3, 2);
            pal_product.Name = "pal_product";
            pal_product.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pal_product.Size = new Size(179, 165);
            pal_product.TabIndex = 0;
            // 
            // txt_priceDish
            // 
            txt_priceDish.BorderStyle = BorderStyle.None;
            txt_priceDish.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            txt_priceDish.ForeColor = Color.FromArgb(64, 0, 0);
            txt_priceDish.Location = new Point(38, 117);
            txt_priceDish.Margin = new Padding(3, 2, 3, 2);
            txt_priceDish.Name = "txt_priceDish";
            txt_priceDish.Size = new Size(87, 14);
            txt_priceDish.TabIndex = 2;
            txt_priceDish.Text = "50.000 Đ ";
            // 
            // btn_Edit
            // 
            btn_Edit.BorderRadius = 10;
            btn_Edit.CustomizableEdges = customizableEdges1;
            btn_Edit.DisabledState.BorderColor = Color.DarkGray;
            btn_Edit.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Edit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Edit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Edit.FillColor = Color.FromArgb(255, 224, 192);
            btn_Edit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Edit.ForeColor = Color.FromArgb(128, 64, 64);
            btn_Edit.HoverState.FillColor = Color.FromArgb(255, 192, 128);
            btn_Edit.Image = (Image)resources.GetObject("btn_Edit.Image");
            btn_Edit.ImageSize = new Size(18, 18);
            btn_Edit.Location = new Point(1, 139);
            btn_Edit.Margin = new Padding(3, 2, 3, 2);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.PressedColor = Color.Transparent;
            btn_Edit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Edit.Size = new Size(179, 26);
            btn_Edit.TabIndex = 8;
            btn_Edit.Text = "Edit dish";
            btn_Edit.Click += btn_Edit_Click;
            // 
            // txt_NameDish
            // 
            txt_NameDish.BorderStyle = BorderStyle.None;
            txt_NameDish.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txt_NameDish.ForeColor = Color.FromArgb(64, 0, 0);
            txt_NameDish.Location = new Point(38, 92);
            txt_NameDish.Margin = new Padding(3, 2, 3, 2);
            txt_NameDish.Name = "txt_NameDish";
            txt_NameDish.Size = new Size(117, 16);
            txt_NameDish.TabIndex = 1;
            txt_NameDish.Text = "Tokbokki Chicken";
            // 
            // btn_Delete
            // 
            btn_Delete.DisabledState.BorderColor = Color.DarkGray;
            btn_Delete.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Delete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Delete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Delete.FillColor = Color.Transparent;
            btn_Delete.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Delete.ForeColor = Color.White;
            btn_Delete.HoverState.BorderColor = Color.FromArgb(255, 128, 128);
            btn_Delete.Image = (Image)resources.GetObject("btn_Delete.Image");
            btn_Delete.ImageSize = new Size(25, 25);
            btn_Delete.Location = new Point(136, 112);
            btn_Delete.Margin = new Padding(3, 2, 3, 2);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btn_Delete.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btn_Delete.Size = new Size(22, 19);
            btn_Delete.TabIndex = 7;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // pic_image
            // 
            pic_image.ImageRotate = 0F;
            pic_image.Location = new Point(59, 28);
            pic_image.Margin = new Padding(3, 2, 3, 2);
            pic_image.Name = "pic_image";
            pic_image.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pic_image.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pic_image.Size = new Size(70, 60);
            pic_image.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_image.TabIndex = 4;
            pic_image.TabStop = false;
            // 
            // uc_product
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pal_product);
            Margin = new Padding(3, 2, 3, 2);
            Name = "uc_product";
            Size = new Size(203, 182);
            pal_product.ResumeLayout(false);
            pal_product.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_image).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pal_product;
        private Guna.UI2.WinForms.Guna2CircleButton btn_Delete;
        private Label lb_price;
        private Label lb_name;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_image;
        private Guna.UI2.WinForms.Guna2Button btn_Edit;
        private TextBox txt_NameDish;
        private TextBox txt_priceDish;
    }
}
