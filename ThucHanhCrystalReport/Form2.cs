using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhCrystalReport
{
    public partial class Form2 : Form
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["th4hsk"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
            ShowReport();
        }
        public void ShowReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select_BN";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                adapter.Fill(dt);

                                // Kiểm tra đường dẫn tới tệp BenhNhan.rpt
                                string path = Path.Combine(Application.StartupPath, "BenhNhan.rpt");

                                if (!File.Exists(path))
                                {
                                    MessageBox.Show("Không tìm thấy tệp báo cáo!");
                                    return;
                                }

                                ReportDocument report = new ReportDocument();
                                report.Load(path);

                                // Kiểm tra xem có bảng "select_BN" trong báo cáo không
                                

                                report.Database.Tables["select_BN"].SetDataSource(dt);
                                crystalReportViewer1.ReportSource = report;
                                crystalReportViewer1.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
