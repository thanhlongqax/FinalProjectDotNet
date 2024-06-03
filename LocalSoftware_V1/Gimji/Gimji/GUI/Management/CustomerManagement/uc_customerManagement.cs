using Gimji.BLL;
using Gimji.DTO;
using Gimji.GUI.Management.StaffManagement;
using Guna.UI2.WinForms;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Management.CustomerManagement
{
    public partial class uc_customerManagement : UserControl
    {
        private uc_customer selectedCustomer; // Biến toàn cục để lưu trữ uc_Staff được chọn
        uc_customer uc_Customer = null;
        public uc_customerManagement()
        {
            InitializeComponent();
        }

        private void uc_customerManagement_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        public void LoadData()
        {
            fl_pal_listCustomer.Controls.Clear();
            //Customer newCustomer = new Customer();
            List<Customer> listCustomer = new List<Customer>();
            CRUD_Customer_BLL newBLL = new CRUD_Customer_BLL();
            listCustomer = newBLL.getAllCustomer();
            int stt = 0;
            foreach (var customer in listCustomer)
            {
                uc_customer new_uc_Customer = new uc_customer();
                new_uc_Customer.Stt = stt++;
                new_uc_Customer.ID = customer.Id;
                new_uc_Customer.Name = customer.fullName;
                new_uc_Customer.Point = customer.Point;




                // Đăng ký sự kiện BtnEditClick cho mỗi uc_staff
                new_uc_Customer.BtnEditClick += (s, eventArgs) =>
                {
                    fl_pal_listCustomer.Visible = true;
                    // Lưu trữ uc_Customer được chọn vào biến toàn cục
                    selectedCustomer = (uc_customer)s;
                    HandleBtnEditClick((uc_customer)s, customer);
                };
                new_uc_Customer.BtnRemoveClick += (s, eventArgs) =>
                {
                    fl_pal_listCustomer.Visible = true;
                    // Lưu trữ uc_Customer được chọn vào biến toàn cục
                    selectedCustomer = (uc_customer)s;
                    btn_delete_Click(s, eventArgs);

                };
                fl_pal_listCustomer.Controls.Add(new_uc_Customer);
            }
        }
        private void HandleBtnEditClick(uc_customer uc_Customer, Customer customer)
        {
            selectedCustomer = uc_Customer;
            txt_idCustomer.Text = customer.Id;
            txt_email.Text = customer.Email;
            txt_Fullname.Text = customer.fullName;
            txt_address.Text = customer.contactAddress;
            txt_phoneNumber.Text = customer.phoneNumber;
            txt_gender.Text = customer.Gender;
            txt_DateOfBirth.Value = customer.DateOfBirth;
            txt_point.Text = customer.Point.ToString();
            txt_Type.Text = customer.Type;
            txt_UserName.Text = customer.userName;
            txt_PassWord.Text = customer.Password;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedCustomer != null)
            {
                // Lấy thông tin nhân viên từ selectedStaff
                string customerId = selectedCustomer.ID;
                // Thực hiện xóa nhân viên dựa trên staffId
                if (!string.IsNullOrEmpty(customerId))
                {
                    CRUD_Customer_BLL newBLL = new CRUD_Customer_BLL();
                    newBLL.deleteCustomer_BLL(customerId);
                    // Sau khi xóa, bạn có thể làm gì đó, ví dụ: cập nhật giao diện
                    LoadData();
                }
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            fl_pal_listCustomer.Visible = true;
            txt_Fullname.Text = string.Empty;
            txt_idCustomer.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_address.Text = string.Empty;
            txt_phoneNumber.Text = string.Empty;
            txt_gender.Text = string.Empty;
            txt_DateOfBirth.Text = string.Empty;
            txt_gender.Text = string.Empty;
            txt_point.Text = string.Empty;
            txt_Type.Text = string.Empty;
            txt_UserName.Text = string.Empty;
            txt_PassWord.Text = string.Empty;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer();
            CRUD_Customer_BLL newBLL = new CRUD_Customer_BLL();
            newCustomer.Id = txt_idCustomer.Text;
            newCustomer.fullName = txt_Fullname.Text;
            newCustomer.Email = txt_email.Text;
            newCustomer.contactAddress = txt_address.Text;
            newCustomer.phoneNumber = txt_phoneNumber.Text;
            newCustomer.Gender = txt_gender.Text;
            newCustomer.DateOfBirth = txt_DateOfBirth.Value;
            newCustomer.userName = txt_UserName.Text;
            newCustomer.Password = txt_PassWord.Text;
            newCustomer.Type = txt_Type.Text;
            // Correctly convert the text value from Guna2TextBox to an integer
            if (int.TryParse(txt_point.Text, out int point))
            {
                newCustomer.Point = point;
            }

            bool customerExists = CheckCustomerExists(newCustomer.Id);

            if (customerExists)
            {
                newBLL.UpdateCustomer_BLL(newCustomer);
            }
            else
            {
                newBLL.AddCustomer_BLL(newCustomer);
            }

            LoadData();
        }
        private bool CheckCustomerExists(string customerId)
        {
            CRUD_Customer_BLL newBLL = new CRUD_Customer_BLL();
            if (newBLL.getCustomerById_BLL(customerId) == null)
            {
                return false;
            }
            return true;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            CRUD_Customer_BLL newBLL = new CRUD_Customer_BLL();

            try
            {
                customer = newBLL.getCustomerById_BLL(txt_Input_Search.Text);

                if (customer != null && !string.IsNullOrEmpty(customer.Id))
                {
                    fl_pal_listCustomer.Controls.Clear();
                    uc_customer uc_Customer = new uc_customer();
                    uc_Customer.Stt = 1;
                    uc_Customer.ID = customer.Id;
                    uc_Customer.Name = customer.fullName;
                    uc_Customer.Point = customer.Point;
                    uc_Customer.BtnEditClick += (s, eventArgs) =>
                    {
                        fl_pal_listCustomer.Visible = true;
                        // Lưu trữ uc_Customer được chọn vào biến toàn cục
                        selectedCustomer = (uc_customer)s;
                        HandleBtnEditClick((uc_customer)s, customer);
                    };
                    uc_Customer.BtnRemoveClick += (s, eventArgs) =>
                    {
                        fl_pal_listCustomer.Visible = true;
                        // Lưu trữ uc_Customer được chọn vào biến toàn cục
                        selectedCustomer = (uc_customer)s;
                        btn_delete_Click(s, eventArgs);

                    };
                    fl_pal_listCustomer.Controls.Add(uc_Customer);
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

        #region Properties

        public Guna2TextBox SearchTxt
        {
            get { return txt_Input_Search; }
            set { txt_Input_Search = value; }
        }
        public Guna2TextBox NameTxt
        {
            get { return txt_Fullname; }
            set { txt_Fullname = value; }
        }
        public Guna2TextBox EmailTxt
        {
            get { return txt_email; }
            set { txt_email = value; }
        }
        public Guna2TextBox AddressTxt
        {
            get { return txt_address; }
            set { txt_address = value; }
        }
        public Guna2TextBox IdTxt
        {
            get { return txt_idCustomer; }
            set { txt_idCustomer = value; }
        }
        public Guna2TextBox PhoneTxt
        {
            get { return txt_phoneNumber; }
            set { txt_phoneNumber = value; }
        }
        public Guna2DateTimePicker DateTxt
        {
            get { return txt_DateOfBirth; }
            set { txt_DateOfBirth = value; }
        }
        public Guna2TextBox GenderTxt
        {
            get { return txt_gender; }
            set { txt_gender = value; }
        }
        public Guna2TextBox PointTxt
        {
            get { return txt_point; }
            set { txt_point = value; }
        }

        #endregion
    }
}
