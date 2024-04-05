using System;
using System.Windows.Forms;

namespace BTTH2
{
    public partial class Form1 : Form
    {
        private ErrorProvider err = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;

            button2.Enabled = false;

            textBox2.Validated += TextBox_Validated;
            textBox3.Validated += TextBox_Validated;
            textBox4.Validated += TextBox_Validated;

            textBox1.TextChanged += TextBox_TextChanged;
            textBox2.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string[] muc = { "Khai pha dữ liệu và máy học", "đánh giá hiệu năng mạng máy tính", "phát triển ứng dụng vãn vật kết nối", "xử lý dữ liệu lớn", "phát triển ứng dụng vãn vật kết nối" };
            string[] lop = { "1710a01", "1810a1", "1910a01", "2010a01", "2110a01" };
            if (radioButton1.Checked)
            {
                cbb2017.Items.Clear();
                cbb2017.Items.AddRange(muc);

                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(lop);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string[] muc2 = { "tin học đại cương", "thiết kế đồ họa", "ứng dụng UML trong PTTK", "Kĩ thuật điện tử số", "lập trình hệ thống" };
            string[] lop2 = { "2210a01", "2310a01" };
            if (radioButton2.Checked)
            {
                cbb2017.Items.Clear();
                cbb2017.Items.AddRange(muc2);

                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(lop2);
            }
        }

        private void TextBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int value;
            if (!int.TryParse(textBox.Text, out value) || value < 0 || value > 10)
            {
                err.SetError(textBox, "Vui lòng nhập số từ 1 đến 10!");
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                err.SetError(textBox, null);
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }


        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFilled = !string.IsNullOrWhiteSpace(textBox2.Text) &&
                             !string.IsNullOrWhiteSpace(textBox3.Text) &&
                             !string.IsNullOrWhiteSpace(textBox4.Text) &&
                             !string.IsNullOrWhiteSpace(textBox1.Text);

            EnableButtonsIfAllFieldsValid();
        }

        private void cbb2017_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtonsIfAllFieldsValid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtonsIfAllFieldsValid();
        }

        private void EnableButtonsIfAllFieldsValid()
        {
            bool allFilled = !string.IsNullOrWhiteSpace(textBox2.Text) &&
                             !string.IsNullOrWhiteSpace(textBox3.Text) &&
                             !string.IsNullOrWhiteSpace(textBox4.Text) &&
                             !string.IsNullOrWhiteSpace(textBox1.Text) &&
                             cbb2017.SelectedIndex != -1 &&
                             comboBox2.SelectedIndex != -1;

            button1.Enabled = allFilled;
            button2.Enabled = allFilled;
        }

        public float tinhDiem (){

            float dau1 = float.Parse(textBox2.Text);
            float dau2 = float.Parse(textBox3.Text);
            float dau3 = float.Parse(textBox4.Text);

            return (dau1 + dau2 + dau3) / 3;
        }

     

        private void AddDataToListBox()
        {
            string tenSinhVien = textBox1.Text;
            string lopHanhChinh = comboBox2.SelectedItem.ToString();
            string monHoc = cbb2017.SelectedItem.ToString();
            float diem = tinhDiem();

            string data = $"Tên sinh viên: {tenSinhVien}" +
                $", Lớp hành chính: {lopHanhChinh}," +
                $" Môn học: {monHoc}," +
                $" Điểm: {diem}";

            listBox1.Items.Add(data);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddDataToListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
