using Gimji.BLL;
using Gimji.DTO;
using Gimji.GUI.Management.CustomerManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Home
{
    public partial class uc_Home : UserControl
    {
        private uc_Table selectedTable; // Biến toàn cục để lưu trữ uc_Staff được chọn
        public uc_Home()
        {
            InitializeComponent();

        }
        private void uc_Home_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            CRUD_BookTable_BLL newBLL = new CRUD_BookTable_BLL();
            foreach (Table newTable in newBLL.getAllTable_BLL())
            {
                uc_Table uc_Table = new uc_Table();
                uc_Table.ID = newTable.TableId;

                // Đăng ký sự kiện BtnBookTableClick cho mỗi uc_Home
                uc_Table.BtnBookTableClick += (s, eventArgs) =>
                {
                    // Lưu trữ uc_Table được chọn vào biến toàn cục
                    selectedTable = (uc_Table)s;
                    HandleBtnBookTableClick((uc_Table)s, newTable);
                };

                flow_pal_Table.Controls.Add(uc_Table);
            }
            List<Table_NV> tables_NV = newBLL.getAllBan_NV_DAO();
            foreach (Table_NV table_NV in tables_NV)
            {
                uc_Detail_Table uc_Detail_Table = new uc_Detail_Table();
                Table_NV newTale = new Table_NV();
                uc_Detail_Table.Name = table_NV.TenKhachHang;
                uc_Detail_Table.Time = table_NV.NgayDatBan.ToString("HH:mm dd-MM-yyyy");
                uc_Detail_Table.Num_Guest = table_NV.GhiChu;
                flow_pal_BookTable.Controls.Add(uc_Detail_Table);
            }
        }
        private void HandleBtnBookTableClick(uc_Table uc_Table, Table table)
        {
            txt_TableId.Text = uc_Table.ID.ToString();
        }
        private void btn_FirstF_Click(object sender, EventArgs e)
        {
            int floor = 1;
            LoadDataByFloor(floor);
        }

        private void btn_SecondF_Click(object sender, EventArgs e)
        {
            int floor = 2;
            LoadDataByFloor(floor);
        }
        private void LoadDataByFloor(int floor)
        {
            flow_pal_Table.Controls.Clear();
            CRUD_BookTable_BLL newBLL = new CRUD_BookTable_BLL();
            foreach (Table table in newBLL.GetTableByFloor_BLL(floor))
            {
                uc_Table uc_Table = new uc_Table();
                uc_Table.ID = table.TableId;

                flow_pal_Table.Controls.Add(uc_Table);
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(txt_CustomerName.Text))
            {
                MessageBox.Show("Mời Bạn Nhập Tên Khách Hàng.");
            }
            else if (datetime_CheckIn.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("Chọn Ngày Khách Hàng Đặt Bàn.");
            }
            else if (string.Equals(txt_TableId, "0"))
            {
                MessageBox.Show("Mời Khách Hàng Chọn Bàn.");
            }
            else if (string.IsNullOrEmpty(txt_Num_Guest.Text))
            {
                MessageBox.Show("Mời Khách Hàng Nhập Số Guest dự kiến.");
            }

            else if (string.IsNullOrEmpty(txt_Num_Guest.Text) && !(int.TryParse(txt_Num_Guest.Text, out int numGuest)))
            {
                MessageBox.Show("Mời Khách Hàng Nhập Số Guest dự kiến.");
            }
            LoadData_Detail_Table();
            txt_CustomerName.Text = string.Empty;
            txt_Num_Guest.Text = string.Empty;
            txt_TableId.Text = string.Empty;
            datetime_CheckIn.Value = DateTime.Now;
        }
        private void LoadData_Detail_Table()
        {
            uc_Detail_Table detail = new uc_Detail_Table();
            Table_NV newTale = new Table_NV();
            CRUD_BookTable_BLL newBLL = new CRUD_BookTable_BLL();
            detail.Name = txt_CustomerName.Text;
            detail.Time = datetime_CheckIn.Value.ToString("HH:mm:ss dd-MM-yyyy");
            detail.Num_Guest = txt_Num_Guest.Text;

            newTale.TenKhachHang = txt_CustomerName.Text;
            newTale.NgayDatBan = datetime_CheckIn.Value;
            newTale.GhiChu = txt_Num_Guest.Text;
            newTale.IdBan = Convert.ToInt32(txt_TableId.Text);

            newBLL.AddCookTable_BLL(newTale);


            flow_pal_BookTable.Controls.Add(detail);
        }
    }
}
