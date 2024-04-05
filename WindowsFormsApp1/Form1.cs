using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        // tạo đối tượng err
        private ErrorProvider err = new ErrorProvider();

        private void Form1_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
        }

        // validate mã sinh viên
        private void textBoxMaSV_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxMaSV.Text))
            {
                err.SetError(textBoxMaSV, "Mã sinh viên không được để trống");
            }
            else
            {
                btnThem.Enabled=true;
                err.SetError(textBoxMaSV, null);
            }
        }


        // validate họ tên
        private void textBoxHoTen_Validating(object sender, CancelEventArgs e)
        {

                if (string.IsNullOrEmpty(textBoxHoTen.Text))
                {
                    err.SetError(textBoxHoTen, "Họ tên sinh viên không được để trống");
                }
                else
                {
                    btnThem.Enabled = true;
                    err.SetError(textBoxHoTen, null);
                }
            
        }

        // validate số điện thoại
        private void textBoxSDT_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatePhoneNumber(textBoxSDT.Text) == false){
                err.SetError(textBoxSDT, "Số điện thoại phải là số");
            }
            else
            {
                err.SetError(textBoxSDT, null);
            }
        }
        // phương thức validate số điện thoại
        static bool ValidatePhoneNumber(string phoneNumber)
        {
            
            Regex regex = new Regex(@"^\d{4}$|^\d{8}$");
            return regex.IsMatch(phoneNumber);
        }
        

        // validate gioi tính
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                err.SetError(radioButton1, null);
            }
            else
            {
                err.SetError(radioButton1, "Giới tính phải được chọn");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }



        /*  private void radioButton2_CheckedChanged(object sender, EventArgs e)
          {
              if(radioButton2.Checked == false)
              {
                  err.SetError(radioButton2, "Gioi tinh phai duoc chon");
              }
              else
              {
                  err.SetError(radioButton2, null);
              }
          }*/
    }
}
