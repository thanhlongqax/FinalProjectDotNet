using DocumentFormat.OpenXml.Office2010.Excel;
using Gimji.BLL;
using Gimji.DTO;
using Gimji.GUI.Management.ProductManagement;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management.Inventory_Management
{
    public partial class uc_inventoryManagement : UserControl
    {
        uc_inventory selectedInventory;
        public uc_inventoryManagement()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void lb_stt_Click(object sender, EventArgs e)
        {

        }

        private void uc_inventoryManagement_Load(object sender, EventArgs e)
        {
            loadData();

        }
        private void loadData()
        {
            pal_inforInventory.Visible = false;
            pal_listInventory.Controls.Clear();
            List<Inventory> listInventory = new List<Inventory>();
            CRUD_Inventory_BLL newBLL = new CRUD_Inventory_BLL();
            listInventory = newBLL.GetAllInventoryDAO();
            foreach (var inventory in listInventory)
            {
                uc_inventory uc_Inventory = new uc_inventory();
                try
                {
                    uc_Inventory.PictureBox = Image.FromFile(inventory.inventoryPicture);
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi không thể tải hình ảnh.
                    // Ví dụ: Hiển thị hình ảnh mặc định hoặc thông báo lỗi.
                    uc_Inventory.PictureBox = Image.FromFile("Resources/AnhMonAn/Default.jpg");
                    // Thay "default_image.jpg" bằng hình ảnh mặc định của bạn.                                                                                                  // Hoặc hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi Đường Dẫn: " + ex.Message);
                }

                uc_Inventory.Name = inventory.foodName;
                uc_Inventory.Type = inventory.type;
                uc_Inventory.Available = inventory.available.ToString();
                uc_Inventory.Sold = inventory.sold.ToString();
                uc_Inventory.Status = inventory.status;
                uc_Inventory.Price = inventory.price.ToString();

                // Đăng ký sự kiện BtnEditClick cho mỗi uc_staff
                uc_Inventory.BtnEditClick += (s, eventArgs) =>
                {
                    // Lưu trữ uc_product được chọn vào biến toàn cục
                    selectedInventory = (uc_inventory)s;
                    HandleBtnEditClick((uc_inventory)s, inventory);

                };
                uc_Inventory.BtnRemoveClick += (s, eventArgs) =>
                {
                    // Lưu trữ uc_product được chọn vào biến toàn cục
                    //selectedProduct = (uc_product)s;
                    //btn_delete_Click(s, eventArgs);

                };
                pal_listInventory.Controls.Add(uc_Inventory);
            }

        }

        private void InitializeChart()
        {
            inventory_chart.XAxes.GridLines.Display = false;
            inventory_chart.YAxes.Display = false;
            inventory_chart.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;

            string[] type = { "Kimbak", "Tokbokki", "ABC", "D", "E", "G", "F" };
            long[] value = { 0, 0, 0 };
            GenerateLine(type, value);
            inventory_chart.Datasets.Add(bar_chart);
        }
        private void GenerateLine(string[] type, long[] value)
        {
            for (int i = 0; i < type.Length; i++)
            {

                ////replace label = type and Y value = value in array or list input
                var random = new Random().Next(10, 100);
                bar_chart.DataPoints.Add(new LPoint()
                {
                    Label = type[i],
                    Y = random,
                });

            }

        }
        private void HandleBtnEditClick(uc_inventory uc_Inventory, Inventory inventory)
        {
            pal_inforInventory.Visible = true;
            selectedInventory = uc_Inventory;
            txt_name.Text = inventory.foodName;
            txt_price.Text = inventory.price.ToString();
            txt_quantity.Text = inventory.available.ToString();

        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pal_inforInventory.Visible = false;
        }
    }
}
