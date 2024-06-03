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
using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using DocumentFormat.OpenXml.Office.Word;
using Gimji.DTO;
using Gimji.DAO;
using Gimji.BLL;

namespace Gimji.GUI.Management.RevenueManagement
{
    public partial class uc_revenueManagement : UserControl
    {
        string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "Octorber", "November", "December" };
        string[] quarter = { "Q1", "Q2", "Q3", "Q4" };
        string[] selectedExport;
        List<int> exportData = new List<int>();
        public uc_revenueManagement()
        {
            InitializeComponent();
            //InitializeChart();
        }


        private void InitializeChart()
        {

            ////////
            revenueCombo();
            loadData();

        }
        private void ResetChartData()
        {
            // Reset chart data...
            chart_revenue.Datasets.Clear();
            chart_2.Datasets.Clear();
            loadData();
        }
        private void loadData()
        {
            ///Load data about customer,dishes
            GetDataCurrentMonth();
            ///load data in chart 
            chart_revenue.Datasets.Clear();
            chart_2.Datasets.Clear();
            chart_revenue.YAxes.GridLines.Display = false;
            chart_2.XAxes.Display = false;
            chart_2.YAxes.Display = false;
            ///clear data
            spline_chart.DataPoints.Clear();
            bar_chart.DataPoints.Clear();
            doughnot_chart.DataPoints.Clear();
            string selectedSort = combo_sort.Text;
            if (selectedSort.Equals("Month"))
            {
                selectedExport = month;
                GenerateLine("Month");
            }
            else
            {
                selectedExport = quarter;
                GenerateLine("Quarter");
            }
            ///add 


            chart_2.Datasets.Add(doughnot_chart);
            chart_2.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            chart_revenue.Datasets.Add(bar_chart);
            chart_revenue.Datasets.Add(spline_chart);
            chart_revenue.Update();
            chart_2.Update();
        }

        public void GenerateLine(string period)
        {
            CRUD_Revenue_BLL newBLL = new CRUD_Revenue_BLL();
            DataTable dataTable = newBLL.GetRevenueCurrent(period);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        var label = column.ColumnName; // Assuming this is your time label
                        var value = Convert.ToInt32(row[column]); // Get the value from the column

                        spline_chart.DataPoints.Add(new LPoint()
                        {
                            Label = label,
                            Y = value + Math.Round((double)(value / 5)),
                        });

                        bar_chart.DataPoints.Add(new LPoint()
                        {
                            Label = label,
                            Y = value,
                        });

                        doughnot_chart.DataPoints.Add(new LPoint()
                        {
                            Label = label,
                            Y = value,
                        });
                    }
                }
            }
            else
            {
                // Handle the case when dataTable is empty or null
            }

            //for (int i = 0; i < time.Length; i++)
            //{
            //    //// replace this code with data in sql : Y = data
            //    var random = new Random().Next(10, 100);
            //    exportData.Add(random);
            //    spline_chart.DataPoints.Add(new LPoint()
            //    {
            //        Label = time[i],
            //        Y = random + Math.Round((double)(random / 5)),
            //    });
            //    bar_chart.DataPoints.Add(new LPoint()
            //    {
            //        Label = time[i],
            //        Y = random,
            //    });

            //    doughnot_chart.DataPoints.Add(new LPoint()
            //    {
            //        Label = time[i],
            //        Y = random,
            //    });

            //}

        }
        public void GetDataCurrentMonth()
        {
            CRUD_Revenue_BLL newBLL = new CRUD_Revenue_BLL();
            Revenue revenue = newBLL.GetDataCurrentMonth();
            if(revenue != null)
            {
                lb_customers.Text = revenue.totalCustomers.ToString();
                lb_dishes.Text = revenue.totalDishes.ToString();
                lb_revenue.Text = revenue.revenue.ToString();
            }
            else
            {
                MessageBox.Show("Dữ liệu gặp vấn đề  " , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            if (combo_sort.SelectedIndex == 0)
            {
                ExportToExcel("Month");
            }
            else
            {
                ExportToExcel("Quarter");
            }

        }
        private void ExportToExcel(String period)
        {
            CRUD_Revenue_BLL newBLL = new CRUD_Revenue_BLL();
            DataTable dataTable = newBLL.GetRevenueByPeriod(period);
            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");
                    var headerRange = worksheet.Range("A3", GetExcelColumnLetter(dataTable.Columns.Count) + "3");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.Yellow;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    var titleCell = worksheet.Cell(1, 6);
                    if(period.Equals("Quarter"))
                    {
                        titleCell = worksheet.Cell(1, 3);
                    }
                    
                    titleCell.Value = "Revenue Statistics Report";
                    titleCell.Style.Font.FontSize = 16;
                    titleCell.Style.Font.Bold = true;
                    titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    // Set headers
                    int row = 3;
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        worksheet.Cell(row, col.Ordinal + 1).Value = col.ColumnName;
                    }

                    // Add data
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        row++;
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            object value = dr[i];
                            if (value != DBNull.Value)
                            {
                                worksheet.Cell(row, i + 1).Value = value.ToString(); // Convert value to string and assign to cell
                            }
                            else
                            {
                                worksheet.Cell(row, i + 1).Value = string.Empty; // Set empty string for DBNull values
                            }
                        }
                    }

                    // Save the workbook
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.Title = "Export to Excel";
                    saveFileDialog.FileName = "ExportedData.xlsx"; // Default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private string GetExcelColumnLetter(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private void revenueCombo()
        {
            combo_sort.Items.Add("Month");
            combo_sort.Items.Add("Quarter");
            combo_sort.SelectedIndex = 0;
            //combo_sort.SelectedItem = "Month";
        }

        private void combo_sort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D3)
            {
                // Set the selected index in the ComboBox based on the pressed key
                int index = (int)(e.KeyCode - Keys.D1);
                if (index < combo_sort.Items.Count)
                {
                    combo_sort.SelectedIndex = index;
                }
            }
        }

        private void uc_revenueManagement_Load(object sender, EventArgs e)
        {
            InitializeChart();
        }


        private void combo_sort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
