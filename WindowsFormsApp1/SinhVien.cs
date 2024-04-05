using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SinhVien
    {
        private string maSV;
        private string hoTen;
        private string ngaySinh;
        private string diaChi;
        private string sdt;
        private string gioiTinh;


        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }

        public SinhVien() { }
        public SinhVien(string mav, string hoten, string ngaysinh, string diachi, string sdt, string gioitinh)
        {
            this.maSV = mav;
            this.hoTen = hoten;
            this.ngaySinh = ngaysinh;
            this.diaChi = diachi;
            this.sdt = sdt;
            this.gioiTinh = gioitinh;
        }

        public SinhVien(DataRow row)
        {
            this.maSV = row["maSV"].ToString();
            this.hoTen = row["hoTen"].ToString();
            this.ngaySinh = row["ngaySinh"].ToString();
            this.diaChi = row["diaChi"].ToString();
            this.sdt = row["sdt"].ToString();
            this.gioiTinh = row["gioiTinh"].ToString();

        }
    }
}
