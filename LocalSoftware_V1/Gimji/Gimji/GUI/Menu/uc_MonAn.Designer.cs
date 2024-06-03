namespace Gimji.GUI.Menu
{
    partial class uc_MonAn
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_MonAn));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna_pal_food = new Guna.UI2.WinForms.Guna2Panel();
            btn_Buy = new Guna.UI2.WinForms.Guna2CircleButton();
            txt_DishPrice = new Label();
            txt_DishName = new Label();
            pic_DishPicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna_pal_food.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_DishPicture).BeginInit();
            SuspendLayout();
            // 
            // guna_pal_food
            // 
            guna_pal_food.BorderRadius = 15;
            guna_pal_food.Controls.Add(btn_Buy);
            guna_pal_food.Controls.Add(txt_DishPrice);
            guna_pal_food.Controls.Add(txt_DishName);
            guna_pal_food.Controls.Add(pic_DishPicture);
            guna_pal_food.CustomizableEdges = customizableEdges3;
            guna_pal_food.FillColor = Color.White;
            guna_pal_food.Location = new Point(0, 22);
            guna_pal_food.Name = "guna_pal_food";
            guna_pal_food.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna_pal_food.Size = new Size(270, 310);
            guna_pal_food.TabIndex = 0;
            // 
            // btn_Buy
            // 
            btn_Buy.DisabledState.BorderColor = Color.DarkGray;
            btn_Buy.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Buy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Buy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Buy.FillColor = Color.Transparent;
            btn_Buy.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Buy.ForeColor = Color.White;
            btn_Buy.HoverState.BorderColor = Color.FromArgb(255, 128, 128);
            btn_Buy.Image = (Image)resources.GetObject("btn_Buy.Image");
            btn_Buy.ImageSize = new Size(39, 39);
            btn_Buy.Location = new Point(197, 218);
            btn_Buy.Name = "btn_Buy";
            btn_Buy.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btn_Buy.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btn_Buy.Size = new Size(40, 40);
            btn_Buy.TabIndex = 3;
            btn_Buy.Click += btn_Buy_Click;
            // 
            // txt_DishPrice
            // 
            txt_DishPrice.AutoSize = true;
            txt_DishPrice.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            txt_DishPrice.ForeColor = Color.FromArgb(64, 0, 0);
            txt_DishPrice.Location = new Point(35, 234);
            txt_DishPrice.Name = "txt_DishPrice";
            txt_DishPrice.Size = new Size(76, 23);
            txt_DishPrice.TabIndex = 2;
            txt_DishPrice.Text = "50.000 Đ";
            // 
            // txt_DishName
            // 
            txt_DishName.AutoSize = true;
            txt_DishName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            txt_DishName.ForeColor = Color.FromArgb(64, 0, 0);
            txt_DishName.Location = new Point(35, 202);
            txt_DishName.Name = "txt_DishName";
            txt_DishName.Size = new Size(152, 23);
            txt_DishName.TabIndex = 1;
            txt_DishName.Text = "Tokbokki Chicken";
            // 
            // pic_DishPicture
            // 
            pic_DishPicture.Image = (Image)resources.GetObject("pic_DishPicture.Image");
            pic_DishPicture.ImageRotate = 0F;
            pic_DishPicture.Location = new Point(68, 50);
            pic_DishPicture.Name = "pic_DishPicture";
            pic_DishPicture.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pic_DishPicture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pic_DishPicture.Size = new Size(130, 130);
            pic_DishPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_DishPicture.TabIndex = 0;
            pic_DishPicture.TabStop = false;
            // 
            // uc_MonAn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna_pal_food);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_MonAn";
            Size = new Size(294, 361);
            guna_pal_food.ResumeLayout(false);
            guna_pal_food.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_DishPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna_pal_food;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_DishPicture;
        private Label txt_DishPrice;
        private Label txt_DishName;
        private Guna.UI2.WinForms.Guna2CircleButton btn_Buy;
    }
}
