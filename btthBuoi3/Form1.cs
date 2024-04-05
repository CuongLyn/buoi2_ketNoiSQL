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

namespace btthBuoi3
{
    public partial class Form1 : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        private string connectionString = 
            ConfigurationManager.ConnectionStrings["th3_hsk"].ConnectionString;


        public Form1()
        {
            InitializeComponent();
            LoadDataToComboBox();
            LoadDataToComboBox_DichVu();
            btn_TiepTuc.Enabled = false;
            txt_Ten.TextChanged += Input_TextChanged;
            txt_Thang.TextChanged += Input_TextChanged;
            txt_Ngay.TextChanged += Input_TextChanged;
            txt_Nam.TextChanged += Input_TextChanged;
            cbBox_DichVu.SelectedIndexChanged += Input_TextChanged;

        }
        private void LoadDataToComboBox_DichVu()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn để lấy dữ liệu từ cơ sở dữ liệu
                    string query = "SELECT TenDV FROM tblDichVu"; // Thay TenBangDichVu bằng tên bảng hoặc view chứa dữ liệu về các dịch vụ

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Xóa tất cả các mục trong ComboBox trước khi thêm mới
                            cbBox_DichVu.Items.Clear();

                            // Đọc dữ liệu từ SqlDataReader và thêm vào ComboBox
                            while (reader.Read())
                            {
                                cbBox_DichVu.Items.Add(reader["TenDV"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadDataToComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn để lấy dữ liệu từ cơ sở dữ liệu
                    string query = "SELECT MaBN FROM tblBenhNhan";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Xóa tất cả các mục trong ComboBox trước khi thêm mới
                            cbb_mabn.Items.Clear();

                            // Đọc dữ liệu từ SqlDataReader và thêm vào ComboBox
                            while (reader.Read())
                            {
                                cbb_mabn.Items.Add(reader["MaBN"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        
        private void Input_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có ít nhất một điều khiển nhập liệu không trống
            btn_TiepTuc.Enabled = IsAnyInputNotEmpty();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private List<string> mangChon = new List<string>(); // Khai báo mảng chọn ở ngoài phương thức để nó không bị xóa sau mỗi lần phương thức được gọi

   
        private void cbBox_DichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn hay không
            if (cbBox_DichVu.SelectedItem != null)
            {
                string textDuocChon = cbBox_DichVu.SelectedItem.ToString(); // Lấy giá trị của mục được chọn

                if (!mangChon.Contains(textDuocChon)) // Kiểm tra xem mục đã được chọn trước đó chưa để tránh trùng lặp
                {
                  
                    mangChon.Add(textDuocChon); // Thêm mục đã chọn vào mảng

                    // Xóa tất cả các mục hiện có trong listBox để cập nhật lại
                    listBox_DsDichVu.Items.Clear();

                    // Thêm tất cả các mục trong mảng vào listBox
                    foreach (string item in mangChon)
                    {
                        listBox_DsDichVu.Items.Add(item);
                    }
                }
            }
        }



        private bool KiemTraTextBoxes()
        {
            // Kiểm tra TextBox Tên không được để trống
            if (string.IsNullOrEmpty(txt_Ten.Text))
            {
                MessageBox.Show("Vui lòng nhập tên.");
                return false; // Trả về false nếu TextBox Tên không hợp lệ
            }

            // Kiểm tra TextBox Tháng, Ngày, Năm hợp lệ
            int thang, ngay, nam;
            if (!int.TryParse(txt_Thang.Text, out thang) || thang < 1 || thang > 12)
            {
                MessageBox.Show("Tháng không hợp lệ.");
                return false; // Trả về false nếu TextBox Tháng không hợp lệ
            }

            if (!int.TryParse(txt_Ngay.Text, out ngay) || ngay < 1 || ngay > 31)
            {
                MessageBox.Show("Ngày không hợp lệ.");
                return false; // Trả về false nếu TextBox Ngày không hợp lệ
            }

            if (!int.TryParse(txt_Nam.Text, out nam) || nam < 1900 || nam > DateTime.Now.Year)
            {
                MessageBox.Show("Năm không hợp lệ.");
                return false; // Trả về false nếu TextBox Năm không hợp lệ
            }

            // Trả về true nếu tất cả các TextBox hợp lệ
            return true;
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            // Kiểm tra các TextBox trước khi thêm vào listBox
            if (KiemTraTextBoxes())
            {
                // Lấy thông tin từ các TextBox
                string ten = txt_Ten.Text;
                string ngayKham = $"{txt_Ngay.Text}/{txt_Thang.Text}/{txt_Nam.Text}"; // Định dạng ngày tháng năm
                string dichVuKham = string.Join(", ", mangChon); // Đưa các mục đã chọn thành một chuỗi phân cách bởi dấu phẩy

                // Hiển thị thông tin trên listBox
                listKetQua.Items.Add($"Tên bệnh nhân: {ten}");
                listKetQua.Items.Add($"Ngày khám: {ngayKham}");
                listKetQua.Items.Add($"Dịch vụ khám: {dichVuKham}");
                listKetQua.Items.Add(""); // Thêm một dòng trống giữa các thông tin để phân biệt giữa các bệnh nhân
            }

        }

        
        private void btn_TiepTuc_Click(object sender, EventArgs e)
        {
            // Xóa nội dung của các ô nhập liệu danh sách dịch vụ và kết quả
            cbBox_DichVu.SelectedIndex = -1; // Xóa lựa chọn trong ComboBox
            cbb_mabn.SelectedIndex = -1;
            txt_Ten.Clear();
            txt_Thang.Clear();
            txt_Ngay.Clear();
            txt_Nam.Clear();
            listBox_DsDichVu.Items.Clear();
            listKetQua.Items.Clear();
           
           
        }

        // Phương thức kiểm tra xem có ít nhất một điều khiển nhập liệu không trống hay không
        private bool IsAnyInputNotEmpty()
        {
            return !string.IsNullOrEmpty(txt_Ten.Text) || !string.IsNullOrEmpty(txt_Thang.Text) ||
                   !string.IsNullOrEmpty(txt_Ngay.Text) || !string.IsNullOrEmpty(txt_Nam.Text);
                  
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            // Đóng ứng dụng
            Application.Exit();
        }

        private void cbb_mabn_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn
            if (cbb_mabn.SelectedItem != null)
            {
                string maBN = cbb_mabn.SelectedItem.ToString(); // Lấy mã bệnh nhân được chọn

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Truy vấn cơ sở dữ liệu để lấy tên bệnh nhân dựa trên mã bệnh nhân
                        string query = "SELECT TenBN FROM tblBenhNhan WHERE MaBN = @MaBN";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaBN", maBN);

                        // Thực thi truy vấn và lấy kết quả
                        string tenBN = command.ExecuteScalar()?.ToString();

                        // Hiển thị tên bệnh nhân lên TextBox hoặc Label tương ứng
                        txt_Ten.Text = tenBN;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
