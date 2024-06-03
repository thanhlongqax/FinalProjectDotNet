namespace Gimji.GUI.Management.ShiftManagement
{
    partial class uc_staffShift
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
            pal_staff = new Guna.UI2.WinForms.Guna2Panel();
            lb_name = new Label();
            pal_staff.SuspendLayout();
            SuspendLayout();
            // 
            // pal_staff
            // 
            pal_staff.BackColor = Color.Transparent;
            pal_staff.BorderColor = Color.White;
            pal_staff.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pal_staff.BorderThickness = 1;
            pal_staff.Controls.Add(lb_name);
            pal_staff.CustomizableEdges = customizableEdges1;
            pal_staff.FillColor = Color.DarkGoldenrod;
            pal_staff.Location = new Point(0, 0);
            pal_staff.Margin = new Padding(0);
            pal_staff.Name = "pal_staff";
            pal_staff.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pal_staff.Size = new Size(114, 36);
            pal_staff.TabIndex = 0;
            pal_staff.Click += pal_staff_Click;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            lb_name.ForeColor = Color.White;
            lb_name.Location = new Point(10, 8);
            lb_name.Margin = new Padding(0);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(101, 17);
            lb_name.TabIndex = 0;
            lb_name.Text = "Elephant ABCDE";
            lb_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uc_staffShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pal_staff);
            Margin = new Padding(0);
            Name = "uc_staffShift";
            Size = new Size(114, 36);
            pal_staff.ResumeLayout(false);
            pal_staff.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pal_staff;
        private Label lb_name;
    }
}
