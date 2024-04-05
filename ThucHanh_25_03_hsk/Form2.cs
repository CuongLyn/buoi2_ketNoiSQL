using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanh_25_03_hsk
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
                string maBN_VVC = ((Form1)Application.OpenForms["Form1"]).GetComboBoxMaBN().SelectedItem.ToString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("proc_BN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaBN_VVC", maBN_VVC);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);

                            ReportDocument report = new ReportDocument();

                            string path = string.Format("{0}\\{1}", Application.StartupPath, "BenhNhan.rpt");
                            report.Load(path);
                            // Đảm bảo tên của table trong Crystal Report là "proc_BN"
                            report.Database.Tables["proc_BN"].SetDataSource(dt);
                            report.SetParameterValue("sNguoiLapBieu", "Cuong HD");
                            crystalReportViewer1.ReportSource = report;
                            crystalReportViewer1.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
