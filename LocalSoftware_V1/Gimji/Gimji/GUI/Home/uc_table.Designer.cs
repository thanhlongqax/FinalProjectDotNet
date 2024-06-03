namespace Gimji.GUI.Home
{
    partial class uc_Table
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Table));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btn_Table = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // btn_Table
            // 
            btn_Table.CustomizableEdges = customizableEdges1;
            btn_Table.DisabledState.BorderColor = Color.DarkGray;
            btn_Table.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Table.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Table.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Table.FillColor = Color.Transparent;
            btn_Table.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Table.ForeColor = Color.FromArgb(128, 64, 0);
            btn_Table.HoverState.FillColor = Color.Transparent;
            btn_Table.HoverState.Image = (Image)resources.GetObject("resource.Image");
            btn_Table.Image = (Image)resources.GetObject("btn_Table.Image");
            btn_Table.ImageSize = new Size(180, 180);
            btn_Table.Location = new Point(50, 53);
            btn_Table.Name = "btn_Table";
            btn_Table.PressedColor = Color.Transparent;
            btn_Table.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Table.Size = new Size(180, 180);
            btn_Table.TabIndex = 0;
            btn_Table.Text = "2";
            btn_Table.TextAlign = HorizontalAlignment.Left;
            btn_Table.TextOffset = new Point(68, 0);
            btn_Table.Click += btn_Table_Click;
            // 
            // uc_Table
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btn_Table);
            Name = "uc_Table";
            Size = new Size(280, 280);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_Table;
    }
}
