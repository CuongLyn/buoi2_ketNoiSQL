using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace ThucHanh_25_03_hsk
{
    public partial class Form1 : Form

    {
       
        private string maBenhNhan;
        private ErrorProvider err = new ErrorProvider();
        private string connectionString =
            ConfigurationManager.ConnectionStrings["th4hsk"].ConnectionString;
        public ComboBox GetComboBoxMaBN()
        {
            return comboBox1_mabn_vvc;
        }
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadDataIntoComboBox_MaBN();
            LoadDataIntoComboBox_DichVu();
            btn_chon_vvc.Enabled = false;
            btn_lichsu_vvc.Enabled = false;
            btn_tieptuc_vvc.Enabled = false;
            dataGridView1.Hide();
        }
        private void LoadDataIntoComboBox_MaBN()
        {
            string query = "SELECT MaBN_VVC FROM tblBenhNhan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1_mabn_vvc.Items.Add(reader["MaBN_VVC"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lb_nam_vvc_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_mabn_vvc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMaBN = comboBox1_mabn_vvc.SelectedItem.ToString();
            string query = "SELECT TenBN_VVC FROM tblBenhNhan WHERE MaBN_VVC = @MaBN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", selectedMaBN);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        textBox_tenbn_vvc.Text = result.ToString();
                    }
                    else
                    {
                        textBox_tenbn_vvc.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (comboBox1_mabn_vvc.SelectedIndex != -1)
            {
                // Mã bệnh nhân đã được chọn, kích hoạt nút "Lịch sử"
                btn_lichsu_vvc.Enabled = true;
            }
            else
            {
                // Nếu không có mã bệnh nhân được chọn, vô hiệu hóa nút "Lịch sử"
                btn_lichsu_vvc.Enabled = false;
            }

        }
        
        private void comboBox1_sldv_vvc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDV = comboBox1_sldv_vvc.SelectedItem.ToString();

            // Tạo một danh sách các dịch vụ đã chọn
            List<string> selectedServices = new List<string>();

            // Thêm các dịch vụ đã chọn từ listBox_lstdv_vvc vào danh sách
            foreach (string item in listBox_lstdv_vvc.Items)
            {
                selectedServices.Add(item);
            }

            // Thêm dịch vụ mới vào danh sách
            selectedServices.Add(selectedDV);

            // Hiển thị danh sách dịch vụ đã chọn trong listBox_lstdv_vvc
            listBox_lstdv_vvc.Items.Clear();
            listBox_lstdv_vvc.Items.Add(string.Join(", ", selectedServices));
            ToggleChonButton();
            
        }

        private void textBox_tenbn_vvc_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ngay_vvc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_ngay_vvc.Text))
            {
                int ngay;
                if (!int.TryParse(textBox_ngay_vvc.Text, out ngay))
                {
                    textBox_ngay_vvc.Text = "";
                    MessageBox.Show("Ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int thang, nam;
                if (!int.TryParse(textBox_thang_vvc.Text, out thang) ||
                    !int.TryParse(textBox_nam_vvc.Text, out nam))
                {
                    // Nếu người dùng chưa nhập đủ tháng hoặc năm, không thực hiện kiểm tra
                    return;
                }

                int ngayTrongThang = DateTime.DaysInMonth(nam, thang);
                if (ngay > ngayTrongThang)
                {
                    // Nếu ngày vượt quá số ngày trong tháng, đặt lại ngày về giá trị lớn nhất và hiển thị thông báo lỗi
                    textBox_ngay_vvc.Text = ngayTrongThang.ToString();
                    MessageBox.Show("Ngày không hợp lệ. Đã sửa lại giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ToggleChonButton();
        }

        private void textBox_thang_vvc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_thang_vvc.Text))
            {
                int thang;
                if (!int.TryParse(textBox_thang_vvc.Text, out thang))
                {
                    // Nếu người dùng nhập không phải là số, đặt giá trị về rỗng và hiển thị thông báo lỗi
                    textBox_thang_vvc.Text = "";
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô tháng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (thang < 1)
                {
                    // Nếu tháng nhỏ hơn 1, đặt lại tháng về 1 và hiển thị thông báo lỗi
                    textBox_thang_vvc.Text = "1";
                    MessageBox.Show("Tháng không được nhỏ hơn 1. Đã sửa lại giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (thang > 12)
                {
                    // Nếu tháng lớn hơn 12, đặt lại tháng về 12 và hiển thị thông báo lỗi
                    textBox_thang_vvc.Text = "12";
                    MessageBox.Show("Tháng không được lớn hơn 12. Đã sửa lại giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ToggleChonButton();
        }

        private void textBox_nam_vvc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_nam_vvc.Text))
            {
                int nam;
                if (!int.TryParse(textBox_nam_vvc.Text, out nam))
                {
                    // Nếu người dùng nhập không phải là số, đặt giá trị về rỗng và hiển thị thông báo lỗi
                    textBox_nam_vvc.Text = "";
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô năm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int namHienTai = DateTime.Now.Year;
                if (nam > namHienTai)
                {
                    // Nếu năm vượt quá năm hiện tại, đặt lại năm về năm hiện tại và hiển thị thông báo lỗi
                    textBox_nam_vvc.Text = namHienTai.ToString();
                    MessageBox.Show("Năm không được lớn hơn năm hiện tại. Đã sửa lại giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ToggleChonButton();
        }
        private void LoadDataIntoComboBox_DichVu()
        {
            string query = "SELECT TenDV_VVC FROM tblDichVu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1_sldv_vvc.Items.Add(reader["TenDV_VVC"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void listBox_lstdv_vvc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ngay_vvc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ngay_vvc.Text))
            {
                err.SetError(textBox_ngay_vvc, "Không được để trống");
            }
            else
            {
                err.SetError(textBox_ngay_vvc, null);
            }
            
        }

        private void textBox_thang_vvc_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox_thang_vvc.Text))
            {
                err.SetError(textBox_thang_vvc, "Không được để trống");
            }
            else
            {
                err.SetError(textBox_thang_vvc, null);
            }
        }

        private void textBox_nam_vvc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_nam_vvc.Text))
            {
                err.SetError(textBox_nam_vvc, "Không được để trống");
            }
            else
            {
                err.SetError(textBox_nam_vvc, null);
            }
        }

        private void comboBox1_mabn_vvc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1_mabn_vvc.Text))
            {
                err.SetError(comboBox1_mabn_vvc, "Không được để trống");
            }
            else
            {
                err.SetError(comboBox1_mabn_vvc, null);
            }
        }

        private void textBox_tenbn_vvc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_tenbn_vvc.Text))
            {
                err.SetError(textBox_tenbn_vvc, "Không được để trống");
            }
            else
            {
                err.SetError(textBox_tenbn_vvc, null);
            }
        }

        private void comboBox1_sldv_vvc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1_sldv_vvc.Text))
            {
                err.SetError(comboBox1_sldv_vvc, "Không được để trống");
            }
            else
            {
                err.SetError(comboBox1_sldv_vvc, null);
            }
        }
        private void ToggleChonButton()
        {
            // Kiểm tra xem tất cả các ô nhập liệu và combobox đã được nhập đủ thông tin chưa
            bool isDataComplete = !string.IsNullOrEmpty(textBox_ngay_vvc.Text) &&
                                  !string.IsNullOrEmpty(textBox_thang_vvc.Text) &&
                                  !string.IsNullOrEmpty(textBox_nam_vvc.Text) &&
                                  !string.IsNullOrEmpty(comboBox1_mabn_vvc.Text) &&
                                  !string.IsNullOrEmpty(textBox_tenbn_vvc.Text) &&
                                  !string.IsNullOrEmpty(comboBox1_sldv_vvc.Text);

            // Kích hoạt hoặc vô hiệu hóa nút chọn dựa trên thông tin đã nhập
            btn_chon_vvc.Enabled = isDataComplete;
            btn_tieptuc_vvc.Enabled = isDataComplete;
        }

        private void btn_chon_vvc_Click(object sender, EventArgs e)
        {
            string ngay = textBox_ngay_vvc.Text;
            string thang = textBox_thang_vvc.Text;
            string nam = textBox_nam_vvc.Text;
            string maBN = comboBox1_mabn_vvc.Text;

            // Lấy danh sách dịch vụ từ listBox_lstdv_vvc
            List<string> selectedServices = new List<string>();
            foreach (string item in listBox_lstdv_vvc.Items)
            {
                selectedServices.Add(item);
            }
            string dsDV = string.Join(", ", selectedServices);

            // Kiểm tra xem đã tồn tại hợp đồng cho bệnh nhân vào ngày cụ thể chưa
            string queryCheckExistence = "SELECT COUNT(*) FROM tblChiTietHopDong WHERE Ngay = @Ngay AND MaBN_VVC = @MaBN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandCheckExistence = new SqlCommand(queryCheckExistence, connection);
                commandCheckExistence.Parameters.AddWithValue("@Ngay", nam + "/" + thang + "/" + ngay);
                commandCheckExistence.Parameters.AddWithValue("@MaBN", maBN);
                try
                {
                    connection.Open();
                    int count = (int)commandCheckExistence.ExecuteScalar();
                    if (count > 0)
                    {
                        // Hợp đồng đã tồn tại, thêm mới chỉ DSDV
                        string queryUpdateDSDV = "UPDATE tblChiTietHopDong SET DSDV_VVC = CONCAT(DSDV_VVC, ', ', @DSDV) WHERE Ngay = @Ngay AND MaBN_VVC = @MaBN";
                        SqlCommand commandUpdateDSDV = new SqlCommand(queryUpdateDSDV, connection);
                        commandUpdateDSDV.Parameters.AddWithValue("@Ngay", nam + "/" + thang + "/" + ngay);
                        commandUpdateDSDV.Parameters.AddWithValue("@MaBN", maBN);
                        commandUpdateDSDV.Parameters.AddWithValue("@DSDV", dsDV);

                        commandUpdateDSDV.ExecuteNonQuery();
                        MessageBox.Show("Đã cập nhật dịch vụ cho hợp đồng đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Hợp đồng chưa tồn tại, thêm mới
                        string queryInsertNew = "INSERT INTO tblChiTietHopDong (Ngay, MaBN_VVC, DSDV_VVC) VALUES (@Ngay, @MaBN, @DSDV)";
                        SqlCommand commandInsertNew = new SqlCommand(queryInsertNew, connection);
                        commandInsertNew.Parameters.AddWithValue("@Ngay", nam + "/" + thang + "/" + ngay);
                        commandInsertNew.Parameters.AddWithValue("@MaBN", maBN);
                        commandInsertNew.Parameters.AddWithValue("@DSDV", dsDV);

                        commandInsertNew.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm hợp đồng mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
      

        

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void btn_thoat_vvc_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btn_tieptuc_vvc_Click(object sender, EventArgs e)
    {
        textBox_ngay_vvc.Clear();
        textBox_thang_vvc.Clear();
        textBox_nam_vvc.Clear();
        comboBox1_mabn_vvc.SelectedIndex = -1;
        textBox_tenbn_vvc.Clear();
        comboBox1_sldv_vvc.SelectedIndex = -1;
        listBox_lstdv_vvc.Items.Clear();

        // Vô hiệu hóa nút "Tiếp tục" sau khi xóa dữ liệu
        btn_tieptuc_vvc.Enabled = false;
    }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            
            form2.ShowDialog();
            form2.ShowReport();
        }
    }
}
