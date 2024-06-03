namespace Gimji.GUI.Menu
{
    partial class uc_MonAnCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_MonAnCart));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txt_DishPrice = new Label();
            txt_DishName = new Label();
            txt_quanitity = new Label();
            btn_Minus = new Guna.UI2.WinForms.Guna2ImageButton();
            btn_Plus = new Guna.UI2.WinForms.Guna2ImageButton();
            txt_Quanity = new Label();
            btn_Remove = new Guna.UI2.WinForms.Guna2ImageButton();
            pic_DishPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            pal_foodcart = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pic_DishPicture).BeginInit();
            pal_foodcart.SuspendLayout();
            SuspendLayout();
            // 
            // txt_DishPrice
            // 
            txt_DishPrice.AutoSize = true;
            txt_DishPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txt_DishPrice.Location = new Point(121, 31);
            txt_DishPrice.Name = "txt_DishPrice";
            txt_DishPrice.Size = new Size(55, 23);
            txt_DishPrice.TabIndex = 7;
            txt_DishPrice.Text = "$5000";
            // 
            // txt_DishName
            // 
            txt_DishName.AutoSize = true;
            txt_DishName.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            txt_DishName.Location = new Point(120, 2);
            txt_DishName.Name = "txt_DishName";
            txt_DishName.Size = new Size(143, 25);
            txt_DishName.TabIndex = 8;
            txt_DishName.Text = "Tobokki chả cá";
            // 
            // txt_quanitity
            // 
            txt_quanitity.AutoSize = true;
            txt_quanitity.Location = new Point(219, 92);
            txt_quanitity.Name = "txt_quanitity";
            txt_quanitity.Size = new Size(0, 20);
            txt_quanitity.TabIndex = 9;
            // 
            // btn_Minus
            // 
            btn_Minus.CheckedState.ImageSize = new Size(64, 64);
            btn_Minus.HoverState.ImageSize = new Size(34, 24);
            btn_Minus.Image = (Image)resources.GetObject("btn_Minus.Image");
            btn_Minus.ImageOffset = new Point(0, 0);
            btn_Minus.ImageRotate = 0F;
            btn_Minus.ImageSize = new Size(34, 24);
            btn_Minus.Location = new Point(125, 66);
            btn_Minus.Name = "btn_Minus";
            btn_Minus.PressedState.ImageSize = new Size(35, 25);
            btn_Minus.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btn_Minus.Size = new Size(35, 25);
            btn_Minus.TabIndex = 10;
            btn_Minus.Click += btn_Minus_Click;
            // 
            // btn_Plus
            // 
            btn_Plus.CheckedState.ImageSize = new Size(64, 64);
            btn_Plus.HoverState.ImageSize = new Size(34, 24);
            btn_Plus.Image = (Image)resources.GetObject("btn_Plus.Image");
            btn_Plus.ImageOffset = new Point(0, 0);
            btn_Plus.ImageRotate = 0F;
            btn_Plus.ImageSize = new Size(34, 24);
            btn_Plus.Location = new Point(199, 66);
            btn_Plus.Name = "btn_Plus";
            btn_Plus.PressedState.ImageSize = new Size(35, 25);
            btn_Plus.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Plus.Size = new Size(35, 25);
            btn_Plus.TabIndex = 11;
            btn_Plus.Click += btn_Plus_Click;
            // 
            // txt_Quanity
            // 
            txt_Quanity.AutoSize = true;
            txt_Quanity.FlatStyle = FlatStyle.Flat;
            txt_Quanity.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Quanity.Location = new Point(170, 66);
            txt_Quanity.Name = "txt_Quanity";
            txt_Quanity.Size = new Size(19, 25);
            txt_Quanity.TabIndex = 12;
            txt_Quanity.Text = "1";
            // 
            // btn_Remove
            // 
            btn_Remove.CheckedState.ImageSize = new Size(64, 64);
            btn_Remove.HoverState.ImageSize = new Size(24, 24);
            btn_Remove.Image = (Image)resources.GetObject("btn_Remove.Image");
            btn_Remove.ImageOffset = new Point(0, 0);
            btn_Remove.ImageRotate = 0F;
            btn_Remove.ImageSize = new Size(24, 24);
            btn_Remove.Location = new Point(342, 66);
            btn_Remove.Name = "btn_Remove";
            btn_Remove.PressedState.ImageSize = new Size(25, 25);
            btn_Remove.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btn_Remove.Size = new Size(25, 25);
            btn_Remove.TabIndex = 13;
            btn_Remove.Click += btn_Remove_Click;
            // 
            // pic_DishPicture
            // 
            pic_DishPicture.BackColor = Color.Transparent;
            pic_DishPicture.BorderRadius = 10;
            pic_DishPicture.CustomizableEdges = customizableEdges4;
            pic_DishPicture.FillColor = Color.Transparent;
            pic_DishPicture.Image = (Image)resources.GetObject("pic_DishPicture.Image");
            pic_DishPicture.ImageRotate = 0F;
            pic_DishPicture.Location = new Point(0, 3);
            pic_DishPicture.Name = "pic_DishPicture";
            pic_DishPicture.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pic_DishPicture.Size = new Size(104, 94);
            pic_DishPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_DishPicture.TabIndex = 14;
            pic_DishPicture.TabStop = false;
            // 
            // pal_foodcart
            // 
            pal_foodcart.BackColor = Color.Transparent;
            pal_foodcart.Controls.Add(pic_DishPicture);
            pal_foodcart.Controls.Add(txt_DishName);
            pal_foodcart.Controls.Add(btn_Remove);
            pal_foodcart.Controls.Add(txt_DishPrice);
            pal_foodcart.Controls.Add(txt_Quanity);
            pal_foodcart.Controls.Add(btn_Minus);
            pal_foodcart.Controls.Add(btn_Plus);
            pal_foodcart.CustomizableEdges = customizableEdges6;
            pal_foodcart.Location = new Point(0, 0);
            pal_foodcart.Name = "pal_foodcart";
            pal_foodcart.ShadowDecoration.CustomizableEdges = customizableEdges7;
            pal_foodcart.Size = new Size(380, 100);
            pal_foodcart.TabIndex = 15;
            // 
            // uc_MonAnCart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pal_foodcart);
            Controls.Add(txt_quanitity);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_MonAnCart";
            Size = new Size(380, 129);
            Load += uc_MonAnCart_Load;
            ((System.ComponentModel.ISupportInitialize)pic_DishPicture).EndInit();
            pal_foodcart.ResumeLayout(false);
            pal_foodcart.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label txt_DishPrice;
        private Label txt_DishName;
        private Label txt_quanitity;
        private Guna.UI2.WinForms.Guna2ImageButton btn_Minus;
        private Guna.UI2.WinForms.Guna2ImageButton btn_Plus;
        private Label txt_Quanity;
        private Guna.UI2.WinForms.Guna2ImageButton btn_Remove;
        private Guna.UI2.WinForms.Guna2PictureBox pic_DishPicture;
        private Guna.UI2.WinForms.Guna2Panel pal_foodcart;
    }
}
