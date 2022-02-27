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
    public partial class frmGiaoDienChinh : Form
    {
        public frmGiaoDienChinh()
        {
            InitializeComponent();
        }


        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang x = new frmKhachHang();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon x = new frmHoaDon();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham x = new frmSanPham();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap x = new frmNhaCungCap();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuLoaiSanPham_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham x = new frmLoaiSanPham();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuMauSac_Click(object sender, EventArgs e)
        {
            frmMauSac x = new frmMauSac();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuKichThuoc_Click(object sender, EventArgs e)
        {
            frmKichThuoc x = new frmKichThuoc();
            x.MdiParent = this;
            x.Show();
        }


        private void mnuTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            frmTimKiemKhachHang x = new frmTimKiemKhachHang();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTImSanPhamTheoGia_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoGia x = new frmTimSanPhamTheoGia();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTImSanPhamTheoLoaiSP_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoLoaiSP x = new frmTimSanPhamTheoLoaiSP();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTImSanPhamTheoMa_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoMa x = new frmTimSanPhamTheoMa();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTImSanPhamTheoMau_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoMau x = new frmTimSanPhamTheoMau();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTImSanPhamTheoNhaCC_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoNhaCungCap x = new frmTimSanPhamTheoNhaCungCap();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTImSanPhamTheoKichThuoc_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoSize x = new frmTimSanPhamTheoSize();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTImSanPhamTheoTen_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoTen x = new frmTimSanPhamTheoTen();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuThongKeTheoNgayHienTai_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThuTheoNgay x = new frmThongKeDoanhThuTheoNgay();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuThongKeTheoThangVaNam_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThuTheoTungThangTrongNam x = new frmThongKeDoanhThuTheoTungThangTrongNam();
            x.MdiParent = this;
            x.Show();
        }

        private void tìmThôngTinChiTiếtCủa1HóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimThongTinChiTietCua1HoaDon x = new frmTimThongTinChiTietCua1HoaDon();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTimsanPhamTheoTinhTrang_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoTinhTrang x = new frmTimSanPhamTheoTinhTrang();
            x.MdiParent = this;
            x.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKichHoatSanPham x = new frmKichHoatSanPham();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            frmTimKiemHoaDon x = new frmTimKiemHoaDon();
            x.MdiParent = this;
            x.Show();
        }

        public int taikhoan;


        private void mnuDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau x = new frmDoiMatKhau();
            x.taikhoan = taikhoan;
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTKSPDaBan_Click(object sender, EventArgs e)
        {
            frmThongKeSanPhamDaBan x = new frmThongKeSanPhamDaBan();
            x.MdiParent = this;
            x.Show();
        }

        bool flag = true;

        private void GiaoDien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    flag = false;
                    Application.Exit();
                }
            }
        }

        private void frmGiaoDienChinh_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void mnuKHNhaCungCap_Click(object sender, EventArgs e)
        {
            frmKichHoatNhaCungCap x = new frmKichHoatNhaCungCap();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuKHSanLoaiPham_Click(object sender, EventArgs e)
        {
            frmKichHoatLoaiSanPham x = new frmKichHoatLoaiSanPham();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuKHMau_Click(object sender, EventArgs e)
        {
            frmKichHoatMau x = new frmKichHoatMau();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuKHSize_Click(object sender, EventArgs e)
        {
            frmKichHoatSize x = new frmKichHoatSize();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTongSoLuong_Click(object sender, EventArgs e)
        {
            frmThongKeTongSoLuongBan x = new frmThongKeTongSoLuongBan();
            x.MdiParent = this;
            x.Show();
        }

        private void mnu5SanPhamBanChay_Click(object sender, EventArgs e)
        {
            frmThongKe5SanPhamBanChay x = new frmThongKe5SanPhamBanChay();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuSanPhamBanChayNhat_Click(object sender, EventArgs e)
        {
            frmThongKeSanPhamBanChayNhat x = new frmThongKeSanPhamBanChayNhat();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuSanPhamBanTrongNgayHienTai_Click(object sender, EventArgs e)
        {
            frmThongKeSanPhamBanTrongNgayHienTai x = new frmThongKeSanPhamBanTrongNgayHienTai();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuSLDonHang_Click(object sender, EventArgs e)
        {
            frmThongKeSoLuongDonHang x = new frmThongKeSoLuongDonHang();
            x.MdiParent = this;
            x.Show();
        }
    }
}