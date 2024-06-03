namespace Gimji.GUI.Home
{
    partial class uc_Detail_Table
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Detail_Table));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pic_Status = new PictureBox();
            lb_Time = new Label();
            lb_NumGuest = new Label();
            lb_Name = new Label();
            btn_table = new Button();
            btn_Edit = new Button();
            btn_Remove = new Button();
            pal_pic = new PictureBox();
            lb_Status = new Label();
            pal_listTable = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pic_Status).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pal_pic).BeginInit();
            pal_listTable.SuspendLayout();
            SuspendLayout();
            // 
            // pic_Status
            // 
            pic_Status.BackColor = Color.Transparent;
            pic_Status.BackgroundImage = (Image)resources.GetObject("pic_Status.BackgroundImage");
            pic_Status.BackgroundImageLayout = ImageLayout.Stretch;
            pic_Status.Location = new Point(233, 20);
            pic_Status.Name = "pic_Status";
            pic_Status.Size = new Size(20, 20);
            pic_Status.TabIndex = 20;
            pic_Status.TabStop = false;
            // 
            // lb_Time
            // 
            lb_Time.AutoSize = true;
            lb_Time.FlatStyle = FlatStyle.Flat;
            lb_Time.Font = new Font("Segoe UI Black", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Time.Location = new Point(83, 59);
            lb_Time.Name = "lb_Time";
            lb_Time.Size = new Size(43, 19);
            lb_Time.TabIndex = 19;
            lb_Time.Text = "Time";
            // 
            // lb_NumGuest
            // 
            lb_NumGuest.AutoSize = true;
            lb_NumGuest.FlatStyle = FlatStyle.Flat;
            lb_NumGuest.Font = new Font("Segoe UI Black", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lb_NumGuest.Location = new Point(83, 40);
            lb_NumGuest.Name = "lb_NumGuest";
            lb_NumGuest.Size = new Size(127, 19);
            lb_NumGuest.TabIndex = 18;
            lb_NumGuest.Text = "Number of guest";
            // 
            // lb_Name
            // 
            lb_Name.AutoSize = true;
            lb_Name.FlatStyle = FlatStyle.Flat;
            lb_Name.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Name.Location = new Point(82, 13);
            lb_Name.Name = "lb_Name";
            lb_Name.Size = new Size(69, 28);
            lb_Name.TabIndex = 17;
            lb_Name.Text = "Name";
            // 
            // btn_table
            // 
            btn_table.BackColor = Color.DarkGray;
            btn_table.BackgroundImage = (Image)resources.GetObject("btn_table.BackgroundImage");
            btn_table.BackgroundImageLayout = ImageLayout.Stretch;
            btn_table.FlatAppearance.BorderSize = 0;
            btn_table.FlatStyle = FlatStyle.Flat;
            btn_table.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_table.ForeColor = SystemColors.ActiveCaptionText;
            btn_table.Location = new Point(19, 17);
            btn_table.Name = "btn_table";
            btn_table.Size = new Size(53, 47);
            btn_table.TabIndex = 16;
            btn_table.UseVisualStyleBackColor = false;
            // 
            // btn_Edit
            // 
            btn_Edit.BackColor = Color.Transparent;
            btn_Edit.BackgroundImage = (Image)resources.GetObject("btn_Edit.BackgroundImage");
            btn_Edit.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Edit.FlatAppearance.BorderSize = 0;
            btn_Edit.FlatStyle = FlatStyle.Flat;
            btn_Edit.Location = new Point(294, 57);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(20, 20);
            btn_Edit.TabIndex = 15;
            btn_Edit.UseVisualStyleBackColor = false;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // btn_Remove
            // 
            btn_Remove.BackColor = Color.Transparent;
            btn_Remove.BackgroundImage = (Image)resources.GetObject("btn_Remove.BackgroundImage");
            btn_Remove.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Remove.FlatAppearance.BorderSize = 0;
            btn_Remove.FlatStyle = FlatStyle.Flat;
            btn_Remove.Location = new Point(268, 57);
            btn_Remove.Name = "btn_Remove";
            btn_Remove.Size = new Size(20, 20);
            btn_Remove.TabIndex = 14;
            btn_Remove.UseVisualStyleBackColor = false;
            btn_Remove.Click += btn_Remove_Click;
            // 
            // pal_pic
            // 
            pal_pic.BackgroundImage = (Image)resources.GetObject("pal_pic.BackgroundImage");
            pal_pic.BackgroundImageLayout = ImageLayout.Stretch;
            pal_pic.Location = new Point(10, 6);
            pal_pic.Name = "pal_pic";
            pal_pic.Size = new Size(68, 68);
            pal_pic.TabIndex = 13;
            pal_pic.TabStop = false;
            // 
            // lb_Status
            // 
            lb_Status.AutoSize = true;
            lb_Status.BackColor = Color.Transparent;
            lb_Status.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Status.Location = new Point(255, 17);
            lb_Status.Name = "lb_Status";
            lb_Status.Size = new Size(82, 23);
            lb_Status.TabIndex = 21;
            lb_Status.Text = "Occupied";
            // 
            // pal_listTable
            // 
            pal_listTable.BorderRadius = 10;
            pal_listTable.Controls.Add(btn_table);
            pal_listTable.Controls.Add(lb_Status);
            pal_listTable.Controls.Add(pal_pic);
            pal_listTable.Controls.Add(pic_Status);
            pal_listTable.Controls.Add(btn_Remove);
            pal_listTable.Controls.Add(lb_Time);
            pal_listTable.Controls.Add(btn_Edit);
            pal_listTable.Controls.Add(lb_NumGuest);
            pal_listTable.Controls.Add(lb_Name);
            pal_listTable.CustomizableEdges = customizableEdges1;
            pal_listTable.FillColor = Color.White;
            pal_listTable.Location = new Point(0, 0);
            pal_listTable.Name = "pal_listTable";
            pal_listTable.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pal_listTable.Size = new Size(347, 85);
            pal_listTable.TabIndex = 22;
            // 
            // uc_Detail_Table
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pal_listTable);
            DoubleBuffered = true;
            Name = "uc_Detail_Table";
            Size = new Size(347, 93);
            ((System.ComponentModel.ISupportInitialize)pic_Status).EndInit();
            ((System.ComponentModel.ISupportInitialize)pal_pic).EndInit();
            pal_listTable.ResumeLayout(false);
            pal_listTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pic_Status;
        private Label lb_Time;
        private Label lb_NumGuest;
        private Label lb_Name;
        private Button btn_table;
        private Button btn_Edit;
        private Button btn_Remove;
        private PictureBox pal_pic;
        private Label lb_Status;
        private Guna.UI2.WinForms.Guna2Panel pal_listTable;
    }
}
