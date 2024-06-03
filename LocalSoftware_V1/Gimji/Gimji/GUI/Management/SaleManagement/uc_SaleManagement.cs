using Gimji.BLL;
using Gimji.DAO;
using Gimji.DTO;
using Gimji.GUI.Home;
using Gimji.GUI.Management.CustomerManagement;
using Gimji.GUI.Management.SaleManagement;
using Gimji.GUI.Management.StaffManagement;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management
{
    public partial class uc_SaleManagement : UserControl
    {
        private uc_sale selectedSale;
        public uc_SaleManagement()
        {
            InitializeComponent();
        }

        private void uc_SaleManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            flow_pal_sale.Controls.Clear();
            List<Voucher> voucherList = new List<Voucher>();
            CRUD_Voucher_DAO cRUD_Voucher_DAO = new CRUD_Voucher_DAO();
            voucherList = cRUD_Voucher_DAO.getAllVoucher_DAO();
            int i = 1;
            foreach (var voucher in voucherList)
            {
                uc_sale uc_Sale = new uc_sale();
                uc_Sale.Stt = i++;
                uc_Sale.Id = voucher.voucherId;
                uc_Sale.Name = voucher.voucherName;
                uc_Sale.Status = voucher.voucherStatus;


                // btn edit event
                uc_Sale.BtnEditClick += (s, eventArgs) =>
                {
                    flow_pal_sale.Visible = true;
                    // storaage slelected sale
                    selectedSale = (uc_sale)s;
                    btn_edit_Click((uc_sale)s, voucher);
                };
                uc_Sale.BtnRemoveClick += (s, eventArgs) =>
                {
                    flow_pal_sale.Visible = true;

                    selectedSale = (uc_sale)s;
                    btn_delete_Click(s, eventArgs);

                };
                flow_pal_sale.Controls.Add(uc_Sale);
            }
        }
        private void btn_edit_Click(uc_sale uc_Sale, Voucher voucher)
        {
            selectedSale = uc_Sale;
            NameTxt.Text = voucher.voucherName;
            Idtxt.Text = voucher.voucherId;
            StatusTxt.Text = voucher.voucherStatus;
            DescriptionTxt.Text = voucher.voucherDescription;
            ConditionTxt.Text = voucher.voucherCondition;
            DateStartTxt.Value = voucher.voucherDateTimeIn;
            DateEndTxt.Value = voucher.voucherDateTimeOut;

        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedSale != null)
            {
                string voucherId = selectedSale.Id;
                if (!string.IsNullOrEmpty(voucherId))
                {
                    CRUD_Voucher_BLL cRUD_Voucher_BLL = new CRUD_Voucher_BLL();
                    cRUD_Voucher_BLL.DeleteVoucher_BLL(voucherId);
                    LoadData();
                }
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher();
            CRUD_Voucher_BLL newBLL = new CRUD_Voucher_BLL();

            voucher.voucherId = NameTxt.Text;
            voucher.voucherStatus = StatusTxt.Text;
            voucher.voucherName = NameTxt.Text;
            voucher.voucherCondition = ConditionTxt.Text;
            voucher.voucherDescription = DescriptionTxt.Text;
            voucher.voucherDateTimeIn = DateStartTxt.Value;
            voucher.voucherDateTimeOut = DateEndTxt.Value;

            bool voucherExist = CheckVoucher(voucher.voucherId);

            if (voucherExist)
            {
                newBLL.UpdateVoucher_BLL(voucher);
            }
            else
            {
                newBLL.AddVoucher_BLL(voucher);
            }

            LoadData();
        }

        private bool CheckVoucher(string id)
        {
            CRUD_Voucher_BLL newBLL = new CRUD_Voucher_BLL();
            if (newBLL.getVoucherrById_BLL(id) == null)
            {
                return false;
            }
            return true;
        }

        private void txt_Search_IconLeftClick(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher();
            CRUD_Voucher_BLL newBLL = new CRUD_Voucher_BLL();

            try
            {
                voucher = newBLL.getVoucherrById_BLL(txt_Search.Text);

                if (voucher != null && !string.IsNullOrEmpty(voucher.voucherId))
                {
                    flow_pal_sale.Controls.Clear();
                    uc_sale uc_Sale = new uc_sale();
                    uc_Sale.Stt = 1;
                    uc_Sale.Id = voucher.voucherId;
                    uc_Sale.Name = voucher.voucherName;
                    uc_Sale.Status = voucher.voucherStatus;
                    uc_Sale.BtnEditClick += (s, eventArgs) =>
                    {
                        flow_pal_sale.Visible = true;
                        // storaage slelected sale
                        selectedSale = (uc_sale)s;
                        btn_edit_Click((uc_sale)s, voucher);
                    };
                    uc_Sale.BtnRemoveClick += (s, eventArgs) =>
                    {
                        flow_pal_sale.Visible = true;

                        selectedSale = (uc_sale)s;
                        btn_delete_Click(s, eventArgs);

                    };
                    flow_pal_sale.Controls.Add(uc_Sale);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên với ID đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Không Tìm Thấy Khách Hàng Cần Tìm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            flow_pal_sale.Visible = true;
            NameTxt.Text = String.Empty;
            Idtxt.Text = String.Empty;
            StatusTxt.Text = String.Empty;
            DescriptionTxt.Text = String.Empty;
            ConditionTxt.Text = String.Empty;
            DateStartTxt.Text = String.Empty;
            DateEndTxt.Text = String.Empty;
        }



        #region Properties

        public Guna2TextBox SearchTxt
        {
            get { return txt_Search; }
            set { txt_Search = value; }
        }
        public Guna2TextBox NameTxt
        {
            get { return txt_name; }
            set { txt_name = value; }
        }
        public Guna2TextBox Idtxt
        {
            get { return txt_idSale; }
            set { txt_idSale = value; }
        }
        public Guna2TextBox StatusTxt
        {
            get { return txt_status; }
            set { txt_status = value; }
        }
        public Guna2TextBox ConditionTxt
        {
            get { return txt_condittion; }
            set { txt_condittion = value; }
        }
        public Guna2TextBox DescriptionTxt
        {
            get { return txt_description; }
            set { txt_description = value; }
        }
        public Guna2DateTimePicker DateStartTxt
        {
            get { return txt_dateStart; }
            set { txt_dateStart = value; }
        }
        public Guna2DateTimePicker DateEndTxt
        {
            get { return txt_dateEnd; }
            set { txt_dateEnd = value; }
        }


        #endregion
    }
}
