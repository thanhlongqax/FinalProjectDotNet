namespace Gimji.GUI.Management.ShiftManagement
{
    partial class uc_shift
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
            flow_pal_shilf = new FlowLayoutPanel();
            pal_border = new Guna.UI2.WinForms.Guna2Panel();
            pal_border.SuspendLayout();
            SuspendLayout();
            // 
            // flow_pal_shilf
            // 
            flow_pal_shilf.BackColor = Color.Transparent;
            flow_pal_shilf.Location = new Point(2, 1);
            flow_pal_shilf.Margin = new Padding(0);
            flow_pal_shilf.Name = "flow_pal_shilf";
            flow_pal_shilf.Size = new Size(111, 109);
            flow_pal_shilf.TabIndex = 10;
            flow_pal_shilf.Paint += flow_pal_shilf_Paint;
            // 
            // pal_border
            // 
            pal_border.BorderColor = Color.White;
            pal_border.BorderThickness = 1;
            pal_border.Controls.Add(flow_pal_shilf);
            pal_border.CustomizableEdges = customizableEdges3;
            pal_border.Location = new Point(0, 0);
            pal_border.Margin = new Padding(0);
            pal_border.Name = "pal_border";
            pal_border.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pal_border.Size = new Size(115, 110);
            pal_border.TabIndex = 11;
            // 
            // uc_shift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pal_border);
            Margin = new Padding(0);
            Name = "uc_shift";
            Size = new Size(115, 110);
            Load += uc_shift_Load;
            pal_border.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flow_pal_shilf;
        private Guna.UI2.WinForms.Guna2Panel pal_border;
    }
}
