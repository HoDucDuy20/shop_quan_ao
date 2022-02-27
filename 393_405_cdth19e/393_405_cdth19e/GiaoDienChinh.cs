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
        private int childFormNumber = 0;

        public frmGiaoDienChinh()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
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

        private void GiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình?","Thông báo thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(kq==DialogResult.No)
            {
                e.Cancel = true;
            }
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

        private void mnuTimHoaDonTheoKhachHang_Click_1(object sender, EventArgs e)
        {
            frmTimHoaDonTheoKhachHang x = new frmTimHoaDonTheoKhachHang();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTimHoaDonTheoNgay_Click(object sender, EventArgs e)
        {
            frmTimHoaDonTheoNgay x = new frmTimHoaDonTheoNgay();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTimKiemKhachHangTheoDT_Click(object sender, EventArgs e)
        {
            frmTimKiemKhachHangTheoDT x = new frmTimKiemKhachHangTheoDT();
            x.MdiParent = this;
            x.Show();
        }

        private void TimKiemKhachHangTheoTen_Click(object sender, EventArgs e)
        {
            frmTimKiemKhachHangTheoTen x = new frmTimKiemKhachHangTheoTen();
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
            frmThongKeDoanhThuTheoNgayHienTai x = new frmThongKeDoanhThuTheoNgayHienTai();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuThongKeTheoThangVaNam_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThuTheoThangVaNam x = new frmThongKeDoanhThuTheoThangVaNam();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuThongKeTheoNam_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThuTheoNam x = new frmThongKeDoanhThuTheoNam();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuThongKeTheoTưngThangTrongNam_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThuTheoTungThangTrongNam x = new frmThongKeDoanhThuTheoTungThangTrongNam();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuTimKhachHangTheoDiaChi_Click(object sender, EventArgs e)
        {
            frmTimKhachHangTheoDiaChi x = new frmTimKhachHangTheoDiaChi();
            x.MdiParent = this;
            x.Show();
        }


        private void mnuTimsanPhamTheoTinhTrang_Click(object sender, EventArgs e)
        {
            frmTimSanPhamTheoTinhTrang x = new frmTimSanPhamTheoTinhTrang();
            x.MdiParent = this;
            x.Show();
        }

        private void mnuKichHoatSanPham_Click(object sender, EventArgs e)
        {
            
        }

        private void frmGiaoDienChinh_Load(object sender, EventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKichHoatSanPham x = new frmKichHoatSanPham();
            x.MdiParent = this;
            x.Show();
        }
    }
}
