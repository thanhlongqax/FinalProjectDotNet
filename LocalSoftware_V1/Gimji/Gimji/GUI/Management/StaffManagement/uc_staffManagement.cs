using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gimji.BLL;
using Gimji.DTO;
using Gimji.GUI.Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gimji.GUI.Management.StaffManagement
{
    public partial class uc_staffManagement : UserControl
    {
        uc_staff uc_Staff = null;
        private uc_staff selectedStaff; // Biến toàn cục để lưu trữ uc_Staff được chọn
        public uc_staffManagement()
        {
            InitializeComponent();
        }

        private void uc_staffManagement_Load(object sender, EventArgs e)
        {
            flow_pal_listStaff.Controls.Clear();
            LoadStaff();

        }
        private void LoadStaff()
        {
            flow_pal_listStaff.Controls.Clear();
            List<Staff> staffList = new List<Staff>();
            CRUD_Staff_BLL newBLL = new CRUD_Staff_BLL();
            staffList = newBLL.getAllStaff();
            int stt = 0;
            foreach (var staff in staffList)
            {
                uc_Staff = new uc_staff();
                uc_Staff.Stt = stt++;
                uc_Staff.StaffID = staff.Id;
                uc_Staff.StaffName = staff.fullName;
                uc_Staff.Position = staff.position;

                // Đăng ký sự kiện BtnEditClick cho mỗi uc_staff
                uc_Staff.BtnEditClick += (s, eventArgs) =>
                {
                    pal_Detail_Staff.Visible = true;
                    // Lưu trữ uc_Staff được chọn vào biến toàn cục
                    selectedStaff = (uc_staff)s;
                    HandleBtnEditClick((uc_staff)s, staff);
                };
                uc_Staff.BtnRemoveClick += (s, eventArgs) =>
                {
                    pal_Detail_Staff.Visible = true;
                    // Lưu trữ uc_Staff được chọn vào biến toàn cục
                    selectedStaff = (uc_staff)s;
                    btn_delete_Click(s, eventArgs);

                };
                flow_pal_listStaff.Controls.Add(uc_Staff);
            }
        }
        private void HandleBtnEditClick(uc_staff uc_Staff, Staff staff)
        {
            selectedStaff = uc_Staff;
            txt_IdStaff.Text = staff.Id;
            txt_email.Text = staff.Email;
            txt_FullName.Text = staff.fullName;
            txt_Address.Text = staff.contactAddress;
            txt_phoneNumber.Text = staff.phoneNumber;
            txt_username.Text = staff.userName;
            txt_password.Text = staff.userPassword;
            txt_Gender.Text = staff.Gender;
            txt_birthday.Text = staff.DateOfBirth;
            txt_dateStart.Text = staff.dateStart;
            txt_Position.Text = staff.position;
            txt_salary.Text = staff.Salary;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedStaff != null)
            {
                // Lấy thông tin nhân viên từ selectedStaff
                string staffId = selectedStaff.StaffID;
                // Thực hiện xóa nhân viên dựa trên staffId
                if (!string.IsNullOrEmpty(staffId))
                {
                    CRUD_Staff_BLL newBLL = new CRUD_Staff_BLL();
                    newBLL.deletebyId(staffId);
                    // Sau khi xóa, bạn có thể làm gì đó, ví dụ: cập nhật giao diện
                    LoadStaff();
                }
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            pal_Detail_Staff.Visible = true;
            txt_IdStaff.Text = string.Empty;
            txt_username.Text = string.Empty;
            txt_password.Text = string.Empty;
            txt_FullName.Text = string.Empty;
            txt_birthday.Text = string.Empty;
            txt_Address.Text = string.Empty;
            txt_phoneNumber.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_dateStart.Text = string.Empty;
            txt_salary.Text = string.Empty;
            txt_Position.Text = string.Empty;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Staff newStaff = new Staff();
                CRUD_Staff_BLL newBLL = new CRUD_Staff_BLL();
                newStaff.Id = txt_IdStaff.Text;
                newStaff.userName = txt_username.Text;
                newStaff.userPassword = txt_password.Text;
                newStaff.fullName = txt_FullName.Text;
                newStaff.DateOfBirth = txt_birthday.Text;
                newStaff.Gender = txt_Gender.Text;
                newStaff.contactAddress = txt_Address.Text;
                newStaff.phoneNumber = txt_phoneNumber.Text;
                newStaff.Email = txt_email.Text;
                newStaff.dateStart = txt_dateStart.Text;
                newStaff.Salary = txt_salary.Text;
                newStaff.position = txt_Position.Text;
                bool customerExists = CheckCustomerExists(newStaff.Id);

                if (customerExists)
                {
                    newBLL.updateStaff(newStaff);
                }
                else
                {
                    newBLL.AddStaff_BLL(newStaff);
                }


                LoadStaff();
            }
        }
        private bool CheckCustomerExists(string staffId)
        {
            CRUD_Staff_BLL newBLL = new CRUD_Staff_BLL();
            if (newBLL.getStaffbyId(staffId) == null)
            {
                return false;
            }
            return true;
        }
        private bool ValidateInput()
        {
            // Kiểm tra các trường dữ liệu đầu vào
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrWhiteSpace(txt_email.Text) || !Regex.IsMatch(txt_email.Text, emailPattern))
            {
                MessageBox.Show("Vui lòng nhập một địa chỉ email hợp lệ và không chứa dấu cách.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_FullName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đầy đủ.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Address.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ liên hệ.");
                return false;
            }
            string phonePattern = @"^0[0-9]{9}$";

            if (string.IsNullOrWhiteSpace(txt_phoneNumber.Text) || !Regex.IsMatch(txt_phoneNumber.Text, phonePattern))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (10 số và bắt đầu bằng số 0).");
                return false;
            }
            string passwordPattern = @"^(?=.*[0-9])(?=.*[a-zA-Z]).{8,16}$";

            if (string.IsNullOrWhiteSpace(txt_password.Text) || !Regex.IsMatch(txt_password.Text, passwordPattern))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hợp lệ (8-16 ký tự, chứa ít nhất một số và một chữ cái).");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_username.Text) || txt_username.Text.Contains(" ") || txt_username.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên người dùng hợp lệ (không có khoảng cách).");
                return false;
            }

            // Kiểm tra xem giới tính có phải là "Nam" hoặc "Nữ" (không phân biệt hoa thường)
            if (string.IsNullOrWhiteSpace(txt_Gender.Text.Trim()) ||
                !Regex.IsMatch(txt_Gender.Text.Trim(), @"^(nam|nữ)$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Vui lòng nhập giới tính hợp lệ (Nam hoặc Nữ).");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_birthday.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.");
                return false;
            }
            if (!Regex.IsMatch(txt_birthday.Text.Trim(), @"^\d{2}-\d{2}-\d{4}$"))
            {
                MessageBox.Show($"Vui lòng nhập theo định dạng ngày-tháng-năm (dd-MM-YYYY).");
                return false;
            }
            if (!Regex.IsMatch(txt_dateStart.Text.Trim(), @"^\d{2}-\d{2}-\d{4}$"))
            {
                MessageBox.Show($"Vui lòng nhập theo định dạng ngày-tháng-năm (dd-MM-YYYY).");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_dateStart.Text))
            {
                MessageBox.Show("Vui lòng nhập ngày bắt đầu làm việc.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Position.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí công việc.");
                return false;
            }
            List<string> validPositions = new List<string> { "Nhân viên", "Đầu Bếp", "Thu ngân" };

            if (!validPositions.Any(p => string.Equals(p, txt_Position.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Vui lòng nhập vị trí công việc là 'Nhân viên', 'Đầu Bếp' hoặc 'Thu ngân'.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_salary.Text))
            {
                MessageBox.Show("Vui lòng nhập lương.");
                return false;
            }
            if (!ContainsOnlyDigits(txt_salary.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập một số làm lương.");
                return false;
            }

            // Nếu tất cả thông tin đều hợp lệ, trả về true
            return true;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pal_Detail_Staff.Visible = false;
        }
        private bool ContainsOnlyDigits(string input)
        {
            foreach (char character in input)
            {
                if (character < '0' || character > '9')
                {
                    return false; // Nếu có ký tự nào không thuộc từ '0' đến '9' thì trả về false
                }
            }

            return true; // Nếu tất cả các ký tự đều thuộc từ '0' đến '9', trả về true
        }

        private void btn_SearchStaff_Click(object sender, EventArgs e)
        {
            Staff newStaff = new Staff();
            CRUD_Staff_BLL newBLL = new CRUD_Staff_BLL();

            try
            {
                newStaff = newBLL.getStaffbyId(txt_Input_Search.Text);

                if (newStaff != null && !string.IsNullOrEmpty(newStaff.Id))
                {
                    flow_pal_listStaff.Controls.Clear();
                    uc_Staff = new uc_staff();
                    uc_Staff.Stt = 0;
                    uc_Staff.StaffID = newStaff.Id;
                    uc_Staff.StaffName = newStaff.fullName;
                    uc_Staff.Position = newStaff.position;
                    uc_Staff.BtnEditClick += (s, eventArgs) =>
                    {
                        pal_Detail_Staff.Visible = true;
                        // Lưu trữ uc_Staff được chọn vào biến toàn cục
                        selectedStaff = (uc_staff)s;
                        HandleBtnEditClick((uc_staff)s, newStaff);
                    };
                    uc_Staff.BtnRemoveClick += (s, eventArgs) =>
                    {
                        pal_Detail_Staff.Visible = true;
                        // Lưu trữ uc_Staff được chọn vào biến toàn cục
                        selectedStaff = (uc_staff)s;
                        btn_delete_Click(s, eventArgs);
                    };
                    flow_pal_listStaff.Controls.Add(uc_Staff);
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

    }
}
