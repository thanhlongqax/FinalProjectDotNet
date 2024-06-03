using Gimji.BLL;
using Gimji.DTO;
using Gimji.GUI.Management.SaleManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gimji.GUI.Management.ShiftManagement
{
    public partial class uc_shiftManagement : UserControl
    {
        static DateTime currentDate = DateTime.Now;
        private List<Label> labelList = new List<Label>();
        private List<FlowLayoutPanel> panelChild = new List<FlowLayoutPanel>();
        //create matrix to storage calender with 3 shifts/every day
        FlowLayoutPanel[,] shiftsPerDay = new FlowLayoutPanel[7, 3];
        //selected shift
        uc_staffShift selectedShift;
        String shiftID;
        public uc_shiftManagement()
        {
            InitializeComponent();

        }

        private void UpdateDateTime()
        {
            // Calculate the start and end of the current week
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Format the date range
            string dateRange = startOfWeek.ToString("d MMMM yyyy") + " - " + endOfWeek.ToString("d MMMM yyyy");
            lb_time.Text = dateRange;
            DateTime day = startOfWeek;
            // get list of staffs in shifts
            List<Shift> listShifts = new List<Shift>();
            CRUD_Shift_BLL newBll = new CRUD_Shift_BLL();
            listShifts = newBll.getAllShift_BLL();


            //add update date into list label
            //// loop over 7 day
            for (int dayIndex = 0; dayIndex < 7; dayIndex++)
            {
                labelList[dayIndex].Text = day.ToString("dd / MM");
                //// get data from database
                foreach (Shift shift in listShifts)
                {
                    String[] partsName = shift.shiftName.Split(' ');
                    String date = shift.dateTime.ToString("dd / MM");
                    ////check data and add to controls
                    if (date.Equals(labelList[dayIndex].Text))
                    {
                        uc_staffShift uc_StaffShift = new uc_staffShift();
                        uc_StaffShift.Name = shift.staffName;
                        uc_StaffShift.PanelColor = Color.FromArgb(0, 64, 0);
                        shiftsPerDay[int.Parse(partsName[1]) - 1, dayIndex].Controls.Add(uc_StaffShift);
                        shiftOnClicK(uc_StaffShift, shift);
                    }
                }
                //set emty shift
                for (int i = 0; i < 3; i++)
                {
                    int currentShift = shiftsPerDay[i, dayIndex].Controls.Count;
                    for (; currentShift < 3; currentShift++)
                    {
                        uc_staffShift uc_StaffShift = new uc_staffShift();
                        uc_StaffShift.Name = "";
                        shiftsPerDay[i, dayIndex].Controls.Add(uc_StaffShift);
                        uc_StaffShift.btnClick += (s, eventArgs) => { };
                    }
                }

                day = day.AddDays(1);
            }

        }

        private void shiftOnClicK(uc_staffShift uc_shift, Shift shift)
        {

            uc_shift.btnClick += (s, eventArgs) =>
            {
                if (selectedShift != null)
                {
                    // If there's a previously selected uc_staffShift, deselect it
                    selectedShift.PanelColor = Color.FromArgb(0, 64, 0);
                }
                selectedShift = uc_shift;
                uc_shift.PanelColor = Color.FromArgb(158, 210, 190);
                changeInfor();
                txt_name.Text = shift.staffID;
                txt_note.Text = shift.note;
                combo_shift.Text = shift.shiftName;
                txt_time.Value = shift.dateTime;
                shiftID = shift.shiftID;
            };
        }
        private void uc_shiftManagement_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {

            //matrix contains shifts everyday
            FlowLayoutPanel[,] shiftsData = new FlowLayoutPanel[3, 7] {

                {Shilf1_1, Shilf1_2, Shilf1_3, Shilf1_4, Shilf1_5, Shilf1_6, Shilf1_7 },
                {Shilf2_1, Shilf2_2, Shilf2_3, Shilf2_4, Shilf2_5, Shilf2_6, Shilf2_7 },
                {Shilf3_1, Shilf3_2, Shilf3_3, Shilf3_4, Shilf3_5, Shilf3_6, Shilf3_7 }
                };
            ///reload panel 
            foreach (var shift in shiftsData)
            {
                shift.Controls.Clear();
            }
            shiftsPerDay = shiftsData;
            Label[] labels = { lb_sunday, lb_monday, lb_tuesday, lb_wednesday, lb_thursday, lb_friday, lb_saturday };
            //FlowLayoutPanel[] pane = { Shilf1_1, Shilf1_2, Shilf1_3, Shilf1_4, Shilf1_5, Shilf1_6, Shilf1_7, Shilf2_1, Shilf2_2, Shilf2_3, Shilf2_4, Shilf2_5, Shilf2_6, Shilf2_7, Shilf3_1, Shilf3_2, Shilf3_3, Shilf3_4, Shilf3_5, Shilf3_6, Shilf3_7 };
            labelList.AddRange(labels);
            //panelChild.AddRange(pane);
            ///load detail data and time
            UpdateDateTime();
            ////set empty for infor box
            addInfor();
            txt_name.Text = String.Empty;
            txt_note.Text = String.Empty;
            txt_time.Text = String.Empty;
            ShiftEvent();

        }



        private void ShiftEvent()
        {
            combo_shift.Items.Add("Shift 1");
            combo_shift.Items.Add("Shift 2");
            combo_shift.Items.Add("Shift 3");
            combo_shift.SelectedIndex = 0;
        }
        private void combo_shift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D3)
            {
                // Set the selected index in the ComboBox based on the pressed key
                int index = (int)(e.KeyCode - Keys.D1);
                if (index < combo_shift.Items.Count)
                {
                    combo_shift.SelectedIndex = index;
                }
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddDays(-7);
            LoadData();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddDays(7);
            LoadData();
        }



        private void btn_today_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Now;
            LoadData();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            //LoadData();
            Shift shift = new Shift();
            CRUD_Shift_BLL newBLL = new CRUD_Shift_BLL();
            shift.staffID = txt_name.Text;
            shift.note = txt_note.Text;
            shift.shiftName = combo_shift.Text;
            shift.dateTime = txt_time.Value;

            bool shiftExist = CheckShiftExist(shift.shiftName, shift.staffID, shift.dateTime);
            if (shiftExist)
            {
                MessageBox.Show("Ca làm đã tồn tại với nhân viên " + txt_name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                newBLL.addShift_DAO(shift);
                LoadData();
            }

        }

        private bool CheckShiftExist(String shiftName, String staffID, DateTime date)
        {
            CRUD_Shift_BLL newBLL = new CRUD_Shift_BLL();
            if (newBLL.GetShiftByInfor_BLL(shiftName, staffID, date) == null)
            {
                return false;
            }
            return true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_name.Text = String.Empty;
            txt_note.Text = String.Empty;
            txt_time.Text = String.Empty;
        }
        private void changeInfor()
        {
            btn_delete.Visible = true;
            btn_update.Visible = true;
            btn_cancel.Visible = false;
            btn_confirm.Visible = false;
            btn_Discard_Changes.Visible = true;
            btn_Save.Visible = true;
        }
        private void addInfor()
        {
            btn_delete.Visible = false;
            btn_update.Visible = false;
            btn_cancel.Visible = true;
            btn_confirm.Visible = true;
            btn_Discard_Changes.Visible = false;
            btn_Save.Visible = false;
        }

        private void btn_Discard_Changes_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedShift != null)
            {
                CRUD_Shift_BLL newBLL = new CRUD_Shift_BLL();
                newBLL.DeleteShiftById(shiftID);
                LoadData();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Shift shift = new Shift();
            CRUD_Shift_BLL newBLL = new CRUD_Shift_BLL();
            shift.shiftID = shiftID;
            shift.staffID = txt_name.Text;
            shift.note = txt_note.Text;
            shift.shiftName = combo_shift.Text;
            shift.dateTime = txt_time.Value;

            bool shiftExist = CheckShiftExist(shift.shiftName, shift.staffID, shift.dateTime);
            if (shiftExist)
            {
                MessageBox.Show("Ca làm đã tồn tại với nhân viên " + txt_name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                newBLL.updateShift_BLL(shift);
                LoadData();
            }


        }
    }
}
