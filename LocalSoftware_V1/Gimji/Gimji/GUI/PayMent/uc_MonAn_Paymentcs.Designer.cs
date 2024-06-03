namespace Gimji.GUI.PayMent
{
    partial class uc_MonAn_Paymentcs
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_MonAn_Paymentcs));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pal_listFood = new Guna.UI2.WinForms.Guna2Panel();
            btn_remove = new Guna.UI2.WinForms.Guna2ImageButton();
            btn_minus = new Guna.UI2.WinForms.Guna2ImageButton();
            btn_plus = new Guna.UI2.WinForms.Guna2ImageButton();
            pictureBox6 = new PictureBox();
            lb_amount = new Label();
            lb_quantity = new Label();
            lb_price = new Label();
            lb_name = new Label();
            pic_image = new Guna.UI2.WinForms.Guna2PictureBox();
            pal_listFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_image).BeginInit();
            SuspendLayout();
            // 
            // pal_listFood
            // 
            pal_listFood.Controls.Add(btn_remove);
            pal_listFood.Controls.Add(btn_minus);
            pal_listFood.Controls.Add(btn_plus);
            pal_listFood.Controls.Add(pictureBox6);
            pal_listFood.Controls.Add(lb_amount);
            pal_listFood.Controls.Add(lb_quantity);
            pal_listFood.Controls.Add(lb_price);
            pal_listFood.Controls.Add(lb_name);
            pal_listFood.Controls.Add(pic_image);
            pal_listFood.CustomizableEdges = customizableEdges6;
            pal_listFood.Location = new Point(0, 0);
            pal_listFood.Name = "pal_listFood";
            pal_listFood.ShadowDecoration.CustomizableEdges = customizableEdges7;
            pal_listFood.Size = new Size(889, 75);
            pal_listFood.TabIndex = 3;
            // 
            // btn_remove
            // 
            btn_remove.CheckedState.ImageSize = new Size(64, 64);
            btn_remove.HoverState.ImageSize = new Size(24, 24);
            btn_remove.Image = (Image)resources.GetObject("btn_remove.Image");
            btn_remove.ImageOffset = new Point(0, 0);
            btn_remove.ImageRotate = 0F;
            btn_remove.ImageSize = new Size(24, 24);
            btn_remove.Location = new Point(807, 20);
            btn_remove.Name = "btn_remove";
            btn_remove.PressedState.ImageSize = new Size(25, 25);
            btn_remove.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btn_remove.Size = new Size(25, 25);
            btn_remove.TabIndex = 14;
            btn_remove.Click += btn_remove_Click;
            // 
            // btn_minus
            // 
            btn_minus.CheckedState.ImageSize = new Size(64, 64);
            btn_minus.HoverState.ImageSize = new Size(34, 24);
            btn_minus.Image = (Image)resources.GetObject("btn_minus.Image");
            btn_minus.ImageOffset = new Point(0, 0);
            btn_minus.ImageRotate = 0F;
            btn_minus.ImageSize = new Size(34, 24);
            btn_minus.Location = new Point(444, 20);
            btn_minus.Name = "btn_minus";
            btn_minus.PressedState.ImageSize = new Size(35, 25);
            btn_minus.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_minus.Size = new Size(35, 25);
            btn_minus.TabIndex = 12;
            btn_minus.Click += btn_minus_Click;
            // 
            // btn_plus
            // 
            btn_plus.CheckedState.ImageSize = new Size(64, 64);
            btn_plus.HoverState.ImageSize = new Size(34, 24);
            btn_plus.Image = (Image)resources.GetObject("btn_plus.Image");
            btn_plus.ImageOffset = new Point(0, 0);
            btn_plus.ImageRotate = 0F;
            btn_plus.ImageSize = new Size(34, 24);
            btn_plus.Location = new Point(518, 20);
            btn_plus.Name = "btn_plus";
            btn_plus.PressedState.ImageSize = new Size(35, 25);
            btn_plus.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btn_plus.Size = new Size(35, 25);
            btn_plus.TabIndex = 13;
            btn_plus.Click += btn_plus_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.AntiqueWhite;
            pictureBox6.Location = new Point(2, 69);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(907, 1);
            pictureBox6.TabIndex = 5;
            pictureBox6.TabStop = false;
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_amount.ForeColor = Color.FromArgb(255, 192, 128);
            lb_amount.Location = new Point(673, 20);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(64, 23);
            lb_amount.TabIndex = 4;
            lb_amount.Text = "118.000";
            // 
            // lb_quantity
            // 
            lb_quantity.AutoSize = true;
            lb_quantity.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_quantity.ForeColor = Color.FromArgb(255, 192, 128);
            lb_quantity.Location = new Point(493, 20);
            lb_quantity.Name = "lb_quantity";
            lb_quantity.Size = new Size(19, 23);
            lb_quantity.TabIndex = 3;
            lb_quantity.Text = "2";
            // 
            // lb_price
            // 
            lb_price.AutoSize = true;
            lb_price.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_price.ForeColor = Color.FromArgb(255, 192, 128);
            lb_price.Location = new Point(248, 20);
            lb_price.Name = "lb_price";
            lb_price.Size = new Size(59, 23);
            lb_price.TabIndex = 2;
            lb_price.Text = "59.000";
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_name.ForeColor = Color.FromArgb(255, 192, 128);
            lb_name.Location = new Point(91, 20);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(114, 23);
            lb_name.TabIndex = 1;
            lb_name.Text = "Chicken Pluss";
            // 
            // pic_image
            // 
            pic_image.BorderRadius = 5;
            pic_image.CustomizableEdges = customizableEdges4;
            pic_image.FillColor = Color.Transparent;
            pic_image.Image = (Image)resources.GetObject("pic_image.Image");
            pic_image.ImageRotate = 0F;
            pic_image.Location = new Point(23, 6);
            pic_image.Name = "pic_image";
            pic_image.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pic_image.Size = new Size(50, 50);
            pic_image.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_image.TabIndex = 0;
            pic_image.TabStop = false;
            // 
            // uc_MonAn_Paymentcs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pal_listFood);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_MonAn_Paymentcs";
            Size = new Size(889, 75);
            pal_listFood.ResumeLayout(false);
            pal_listFood.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_image).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pal_listFood;
        private Guna.UI2.WinForms.Guna2ImageButton btn_remove;
        private Guna.UI2.WinForms.Guna2ImageButton btn_minus;
        private Guna.UI2.WinForms.Guna2ImageButton btn_plus;
        private PictureBox pictureBox6;
        private Label lb_amount;
        private Label lb_quantity;
        private Label lb_price;
        private Label lb_name;
        private Guna.UI2.WinForms.Guna2PictureBox pic_image;
    }
}
