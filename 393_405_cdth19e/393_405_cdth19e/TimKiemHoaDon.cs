using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _393_405_cdth19e
{
    public partial class frmTimKiemHoaDon : Form
    {
        public frmTimKiemHoaDon()
        {
            InitializeComponent();
        }

        private void cboNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmTimHoaDonTheoNgay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (kq == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        DateTime aDateTime = DateTime.Now;
        int ngay = 31;
        int thang = 1;
        int soThang = 12;
        int soNam;

        private void frmTimHoaDonTheoNgay_Load(object sender, EventArgs e)
        {
            cboSearch.Items.Add("Mã Hóa Đơn");
            cboSearch.Items.Add("Số Điện Thoại");
            cboSearch.Items.Add("Tên Khách Hàng");
            cboSearch.SelectedIndex = 0;

            cboNgay.Items.Add("None");
            cboThang.Items.Add("None");
            cboNam.Items.Add("None");
            for (int i = 1; i <= 31; i++)
            {
                cboNgay.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }
            soNam = aDateTime.Year;
            for (int i = 1900; i <= soNam; i++)
            {
                cboNam.Items.Add(i);
            }
            cboNgay.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
        }

        bool kiemTraNamNhuan()
        {
            int nam = int.Parse(cboNam.Text);
            if (nam % 4 == 0 && (nam % 100 != 0 || nam % 400 == 0))
            {
                return true;
            }
            return false;
        }

        int soNgayTrongThang(int thang)
        {
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (kiemTraNamNhuan())
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
            }
            return 0;
        }
        
        void ThemNgay(ref int soNgayTruoc, ref int soNgaySau)
        {
            for (int i = soNgayTruoc + 1; i <= soNgaySau; i++)
            {
                cboNgay.Items.Add(i);
            }
        }

        void XoaNgay(ref int soNgayTruoc, ref int soNgaySau)
        {
            for (int i = soNgayTruoc + 1; i <= soNgaySau; i++)
            {
                cboNgay.Items.RemoveAt(i);
                soNgaySau--;
                i--;
            }
        }

        void ThemThang(ref int soThangTruoc, ref int soThangSau)
        {
            for (int i = soThangTruoc + 1; i <= soThangSau; i++)
            {
                cboThang.Items.Add(i);
            }
        }

        void XoaThang(ref int soThangTruoc, ref int soThangSau)
        {
            for (int i = soThangTruoc + 1; i <= soThangSau; i++)
            {
                cboThang.Items.RemoveAt(i);
                soThangSau--;
                i--;
            }
        }

        private void cboNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboThang.Text == "None" && cboNgay.Text != "None")
            {
                int chonNam = soNam - 1900 + 1;
                int n = soThang;
                soThang = aDateTime.Month;
                XoaThang(ref soThang, ref n);
                if (int.Parse(cboNgay.Text) <= aDateTime.Day)
                {
                    cboThang.SelectedIndex = aDateTime.Month;
                    n = ngay;
                    ngay = aDateTime.Day;
                    XoaNgay(ref ngay, ref n);
                }
                else
                {
                    int t = aDateTime.Month - 1;
                    while(true)
                    {
                        if (t == 0)
                        {
                            chonNam--;
                            n = soThang;
                            soThang = 12;
                            t = soThang;
                            ThemThang(ref n, ref soThang);
                        }
                        int songay = soNgayTrongThang(t);
                        if (int.Parse(cboNgay.Text) <= songay)
                        {
                            if(ngay > songay)
                            {
                                n = ngay;
                                ngay = songay;
                                XoaNgay(ref ngay, ref n);
                            }
                            cboThang.SelectedIndex = t;
                            break;
                        }
                        t--;
                    }    
                    
                }
                cboNam.SelectedIndex = chonNam;
            }    
            HienThiHD();
            HienThiCTHD("");
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cboThang.Text == "None")
            {
                cboNgay.SelectedIndex = 0;
                if (ngay < 31)
                {
                    int n = ngay;
                    ngay = 31;
                    ThemNgay(ref n, ref ngay);
                }
            }
            else
            {
                if (cboNam.Text == "None")
                {
                    if (int.Parse(cboThang.Text) <= aDateTime.Month)
                    {
                        cboNam.SelectedIndex = soNam - 1900 + 1;
                    }
                    else
                    {
                        cboNam.SelectedIndex = soNam - 1900;
                    }
                }
                if (cboNam.Text == aDateTime.Year.ToString() && cboThang.Text == aDateTime.Month.ToString())
                {
                    int songayht = aDateTime.Day;
                    if (songayht < ngay)
                    {
                        int n = ngay;
                        ngay = songayht;
                        if (cboNgay.Text != "None")
                        {
                            if (int.Parse(cboNgay.Text) > ngay)
                            {
                                cboNgay.SelectedIndex = ngay;
                            }
                        }
                        XoaNgay(ref ngay, ref n);
                    }
                    else
                    {
                        int n = ngay;
                        ngay = songayht;
                        ThemNgay(ref n, ref ngay);
                    }
                }
                else
                {
                    if (cboNgay.Text == "None")
                    {
                        thang = int.Parse(cboThang.Text);
                        if (ngay > soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            XoaNgay(ref ngay, ref n);
                        }
                        else if (ngay < soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            ThemNgay(ref n, ref ngay);
                        }
                    }
                    else
                    {
                        int ngayChon = int.Parse(cboNgay.Text);
                        thang = int.Parse(cboThang.Text);
                        if (ngay > soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            if (ngayChon > ngay)
                            {
                                cboNgay.SelectedIndex = ngay;
                            }
                            XoaNgay(ref ngay, ref n);
                        }
                        else if (ngay < soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            ThemNgay(ref n, ref ngay);
                        }
                    }
                }
            }  
            HienThiHD();
            HienThiCTHD("");
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.Text == "None")
            {
                cboNgay.SelectedIndex = 0;
                cboThang.SelectedIndex = 0;
                if (ngay < 31)
                {
                    int n = ngay;
                    ngay = 31;
                    ThemNgay(ref n, ref ngay);
                }
                if (soThang < 12)
                {
                    int n = soThang;
                    soThang = 12;
                    ThemThang(ref n, ref soThang);
                }
            }
            else
            {
                if (cboNam.Text == aDateTime.Year.ToString())
                {
                    if (soThang > aDateTime.Month)
                    {
                        int n = soThang;
                        soThang = aDateTime.Month;
                        if (cboThang.SelectedIndex > soThang && cboThang.SelectedIndex != 0)
                        {
                            cboThang.SelectedIndex = soThang;
                        }
                        XoaThang(ref soThang, ref n);
                    }
                }
                else
                {
                    if (soThang < 12)
                    {
                        int n = soThang;
                        soThang = 12;
                        ThemThang(ref n, ref soThang);
                    }
                }
                if(cboNam.Text == aDateTime.Year.ToString() && cboThang.Text == aDateTime.Month.ToString())
                {
                    int songay = aDateTime.Day;
                    if (songay < ngay)
                    {
                        int n = ngay;
                        ngay = songay;
                        if (cboNgay.Text != "None")
                        {
                            if (int.Parse(cboNgay.Text) > ngay)
                            {
                                cboNgay.SelectedIndex = ngay;
                            }
                        }
                        XoaNgay(ref ngay, ref n);
                    }
                    else
                    {
                        int n = ngay;
                        ngay = songay;
                        ThemNgay(ref n, ref ngay);
                    }
                }    
                else if(cboThang.Text != "None" && cboNgay.Text != "None")
                {
                    thang = int.Parse(cboThang.Text);
                    if (ngay > soNgayTrongThang(thang))
                    {
                        int ngayChon = int.Parse(cboNgay.Text);
                        int n = ngay;
                        ngay = soNgayTrongThang(thang);
                        if (ngayChon > ngay)
                        {
                            cboNgay.SelectedIndex = ngay;
                        }
                        XoaNgay(ref ngay, ref n);
                    }
                    else if (ngay < soNgayTrongThang(thang))
                    {
                        int n = ngay;
                        ngay = soNgayTrongThang(thang);
                        ThemNgay(ref n, ref ngay);
                    }
                }    
            }
            HienThiHD();
            HienThiCTHD("");
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet dsHD = new DataSet();
        DataSet dsCTHD = new DataSet();
        void hienThiDuLieu(string sql, DataGridView dgv)
        {
            dsHD = c.layDuLieu(sql);
            dgv.DataSource = dsHD.Tables[0];
        }

        void HienThiHD()
        {
            string sql = "select HoaDon.MaHD as 'Mã HD', KhachHang.TenKh as 'Tên KH', KhachHang.Phone as 'Số điện thoại', HoaDon.NgayLapHD as 'Ngày lập', HoaDon.TongTien as 'Tổng tiền', HoaDon.LoaiHD as 'Loại HD', HoaDon.TrangThai as 'Trạng thái' from KhachHang, HoaDon where KhachHang.MaKh = HoaDon.MaKh ";
            
            if (txtSearch.Text != "")
            {
                if (cboSearch.SelectedIndex == 0)
                {
                    sql += "and HoaDon.MaHD like '%" + txtSearch.Text + "%' ";
                }
                else if (cboSearch.SelectedIndex == 1)
                {
                    sql += "and KhachHang.Phone like '%" + txtSearch.Text + "%' ";
                }
                else
                {
                    sql += "and KhachHang.TenKH like N'%" + txtSearch.Text + "%' ";
                }
            }

            if (cboNgay.Text == "None" && cboThang.Text == "None" && cboNam.Text != "None")
            {
                sql += "and year(NgayLapHD) = '" + cboNam.Text + "'";
            }
            else if (cboNgay.Text == "None" && cboThang.Text != "None" && cboNam.Text != "None")
            {
                sql += "and month(NgayLapHD) = '" + cboThang.Text + "' and year(NgayLapHD) = '" + cboNam.Text + "'";
            }
            else if (cboNgay.Text != "None" && cboThang.Text != "None" && cboNam.Text != "None")
            {
                sql += "and day(NgayLapHD) = '" + cboNgay.Text + "' and month(NgayLapHD) = '" + cboThang.Text + "' and year(NgayLapHD) = '" + cboNam.Text + "'";
            }
            else
            {
                sql += "";
            }

                hienThiDuLieu(sql, dgvDanhSachSanPham);
        }

        void HienThiCTHD(string MaHD)
        {
            string sql = "select CT_HoaDon.MaSp,CT_HoaDon.SoLuong,CT_HoaDon.DonGia,CT_HoaDon.ChietKhau, CT_HoaDon.SoLuong* CT_HoaDon.DonGia as TongTien from HoaDon, CT_HoaDon where HoaDon.MaHD = CT_HoaDon.MaHD and HoaDon.MaHD = '" + MaHD + "'";
            dsCTHD = c.layDuLieu(sql);
            dgvDanhSachChiTietHoaDon.DataSource = dsCTHD.Tables[0];
        }
        private void cboSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboSearch.SelectedIndex == 1)
            {
                if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                {
                    e.Handled = true;
                }
            }
            else if (cboSearch.SelectedIndex == 2)
            {
                if (char.IsNumber(e.KeyChar) == true)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboNgay.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
            HienThiHD();
            HienThiCTHD("");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            HienThiHD();
            HienThiCTHD("");
        }

        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiCTHD(dsHD.Tables[0].Rows[vt][0].ToString());
        }
    }
}