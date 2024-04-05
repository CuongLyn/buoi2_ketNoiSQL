using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace buoi2_ketNoiSQL
{
    internal class Program
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["QLSV_datSaoCxDuoc"].ConnectionString;

        static void Main(string[] args)
        {
            //buoi3
            //hienDSSV_NgatKetNoi(ConnectionString);


            /* bool kt = XoaSinhVienKhoiKetNoi(ConnectionString, "2");
             if(kt == true)
             {
                 Console.WriteLine("xoa thanh cong");
             }
             else
             {
                 Console.WriteLine("xoa that bai");
             }*/



            bool kt = ThemSinhVienKetNoi(ConnectionString, "1", "Nguyen Thanh Nam");
            if (kt == true)
            {
                Console.WriteLine("them thanh cong");
            }
            else
            {
                Console.WriteLine("them that bai");
            }

            // het buoi 3

            /* int choice;
             do
             {
                 Console.WriteLine("Menu:");
                 Console.WriteLine("1. Nhap sinh vien");
                 Console.WriteLine("2. Hien thi danh sach sinh vien");
                 Console.WriteLine("3. Xoa sinh vien theo ma");
                 Console.WriteLine("4. Thoat chuong trinh");
                 Console.Write("5. Sua ma, ten sinh vien ");
                 Console.Write("Nhap lua chon cua ban (1-3): ");

                 if (int.TryParse(Console.ReadLine(), out choice))
                 {
                     switch (choice)
                     {
                         case 1:
                             NhapSinhVien();
                             break;
                         case 2:
                             HienThiDanhSachSinhVien(ConnectionString);
                             break;
                         case 3:
                             XoaSinhVien(ConnectionString);
                             break;
                         case 4:
                             Console.WriteLine("Thoat chuong trinh. Hen gap lai!");
                             break;
                         case 5:
                             SuaSinhVien(ConnectionString);
                             break;

                         default:
                             Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                             break;
                     }
                 }
                 else
                 {
                     Console.WriteLine("Nhap khong hop le. Vui long nhap lai.");
                 }

             } while (choice != 3);*/
        }

        private static void NhapSinhVien()
        {
            string maSV;
            string hoTen, ngaySinh, diaChi, soDienThoai, gioiTinh;
            bool bGioiTinh;

            Console.WriteLine("Nhap ma Sinh Vien: ");
            maSV = (Console.ReadLine());

            Console.WriteLine("Nhap ho ten: ");
            hoTen = Console.ReadLine();

            Console.WriteLine("Nhap ngay sinh: ");
            DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
            ngaySinh = dateTime.ToString("yyyy/MM/dd");

            Console.WriteLine("Nhap dia chi: ");
            diaChi = Console.ReadLine();

            Console.WriteLine("Nhap so dien thoai: ");
            soDienThoai = Console.ReadLine();

            Console.WriteLine("Nhap gioi tinh: ");
            gioiTinh = Console.ReadLine();
            bGioiTinh = (gioiTinh.ToLower() == "nam") ? true : false;

            bool i = themSV(ConnectionString, maSV, hoTen, ngaySinh, diaChi, soDienThoai, bGioiTinh);

            if (i)
            {
                Console.WriteLine("Them Thanh Cong.");
            }
            else
            {
                Console.WriteLine("Them that bai.");
            }
        }

        private static bool themSV(string connectionString, string maSV, string sHoTen, string dNgaySinh, string diaChi, string soDienThoai, bool gioiTinh)
        {
            string insert_proc = "Insert_SinhVien";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = insert_proc;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iMaSV", maSV);
                    cmd.Parameters.AddWithValue("@sHoTen", sHoTen);
                    cmd.Parameters.AddWithValue("@dNgaySinh", dNgaySinh);
                    cmd.Parameters.AddWithValue("@sDiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@sSoDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@bGioiTinh", gioiTinh);

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    return (i > 0);
                }
            }
        }

        private static void HienThiDanhSachSinhVien(string connectString)
        {
            string query_tblSinhVien = "Select_tblSinhVien";
            using (SqlConnection con = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query_tblSinhVien;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}",
                                    reader["iMaSV"],
                                    reader["sHoTen"],
                                    reader["dNgaySinh"]);
                            }
                        }
                    }
                    con.Close();
                }
            }
        }

        private static void XoaSinhVien(string connectionString)
        {
            Console.WriteLine("Nhap ma Sinh Vien can xoa: ");
            string maSV = Console.ReadLine();

            bool success = xoaSV(connectionString, maSV);

            if (success)
            {
                Console.WriteLine("Xoa Thanh Cong.");
            }
            else
            {
                Console.WriteLine("Xoa that bai. Sinh vien khong ton tai.");
            }
        }

        private static bool xoaSV(string connectString, string maSV)
        {
           

            using (SqlConnection con = new SqlConnection(connectString))
            {
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Delete_tblSinhVien";
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSV", maSV);


                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close() ;
                    return (i > 0);
                }
            }
        }

        private static void SuaSinhVien(string connectionString)
        {
            Console.WriteLine("Nhap ma Sinh Vien can sua: ");
            string maSV = Console.ReadLine();

            Console.WriteLine("Nhap ma Sinh Vien moi: ");
            string maSVMoi = Console.ReadLine();

            Console.WriteLine("Nhap ho ten moi: ");
            string hoTenMoi = Console.ReadLine();

            bool success = suaSV(connectionString, maSV, maSVMoi, hoTenMoi);

            if (success)
            {
                Console.WriteLine("Sua Thanh Cong.");
            }
            else
            {
                Console.WriteLine("Sua that bai. Sinh vien khong ton tai.");
            }
        }

        private static bool suaSV(string connectString, string maSV, string maSVMoi, string hoTenMoi)
        {
            using (SqlConnection con = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Update_tblSinhVien";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSV", maSV);
                    cmd.Parameters.AddWithValue("@maSVMoi", maSVMoi);
                    cmd.Parameters.AddWithValue("@hoTenMoi", hoTenMoi);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return (i > 0);
                }
            }
        }
        // buoi 3 
        private static void hienDSSV_NgatKetNoi(string connectionString)
        {
            string select_proc = "Select_tblSinhVien";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = select_proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using(DataTable table = new DataTable())
                        {
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                // co du lieu thi hien thi ra man hinh chinh
                             /*   foreach(DataRow row in table.Rows)
                                {
                                    Console.WriteLine("{0}\t{1}",
                                        row["iMaSV"],
                                        row["sHoTen"]);
                                }*/
                                // hien thi du lieu co dieu kien
                                using (DataView dataV = table.DefaultView)
                                {
                                    // duyet du lieu thong qua data view con tren la thong qua table

                                    dataV.RowFilter = "bGioiTinh = true";
                                    dataV.Sort = "dNgaySinh ASC";
                                    foreach (DataRowView row in dataV)
                                    {
                                        Console.WriteLine("{0}\t{1}",
                                            row["iMaSV"],
                                            row["sHoTen"]);
                                    }
                                }
                            }
                            else
                            {

                                //console khong ton tai ban ghi nao
                                Console.WriteLine("Khong co ban ghi nao.");
                            }
                        }
                    }
                }
            }
        }

        private static bool XoaSinhVienKhoiKetNoi(string connString, string masv)
        {
            string delete_proc = "Delete_tblSinhVien";
            string select_proc = "Select_tblSinhVien";

            using(SqlConnection conn = new SqlConnection(connString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = select_proc;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using(DataTable tblSinhVien = new DataTable("tblSinhVien"))
                        {
                            adapter.Fill(tblSinhVien);
                            using(DataSet dataSet = new DataSet())
                            {
                                dataSet.Tables.Add(tblSinhVien);

                                // tim ma sv can xoa
                                tblSinhVien.PrimaryKey = new DataColumn[] { tblSinhVien.Columns["iMaSV"] };
                                DataRow row = tblSinhVien.Rows.Find(masv);
                                row.Delete();

                                //dong bo du lieu vao csdl su dung DeleteCommand

                                cmd.CommandText = delete_proc;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@maSV", masv);

                                adapter.DeleteCommand = cmd;

                                int i = adapter.Update(dataSet, "tblSinhVien");

                                return i > 0;
                            }
                        }
                    }

                }
            }
        }

        private static bool ThemSinhVienKetNoi(string connSring, string maSV, string hoTen, string dNgaySinh, string diaChi, string soDienThoai, bool gioiTinh)
        {
            string insert_proc = "Insert_SinhVien";
            using(SqlConnection conn = new SqlConnection(connSring))
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand("Select * from tblSinhVien", conn);
                    DataTable dtSinhVien = new DataTable("tblSinhVien");
                    adapter.Fill(dtSinhVien);


                    // khoi tao dataset va add tung datatable vao dataset
                    DataSet dataSet = new DataSet();
                    dataSet.Tables.Add(dtSinhVien);

                    // them ban ghi moi vao dataTable
                    DataRow row = dtSinhVien.NewRow();
                    row["iMaSV"] = maSV;
                    row["sHoTen"] = hoTen;
                    dtSinhVien.Rows.Add(row);

                    // dong bo du lieu

                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = insert_proc;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maSV", maSV);
                        cmd.Parameters.AddWithValue("@sHoTen", hoTen);
                        // khai bao day du parameters

                        adapter.InsertCommand = cmd;
                        int i = adapter.Update(dataSet, "tblSinhVien");
                        return 1 > 0;
                    }
                }
            }

            return true;
        }


    }
}
