using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _393_405_cdth19e
{
    public partial class frmKichHoatSanPham : Form
    {
        public frmKichHoatSanPham()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        DataSet dsMau = new DataSet();
        DataSet dsKichThuoc = new DataSet();
        DataSet dsNCC = new DataSet();
        DataSet dsLoaiSP = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        void XuLyTextBox(Boolean t)
        {
            txtMaSanPham.ReadOnly = t;
            txtTenSanPham.ReadOnly = t;
            txtDonGia.ReadOnly = t;
            cmbKichThuoc.Enabled = !t;
            cmbTenNhaCungCap.Enabled = !t;
            cmbTenLoaiSanPham.Enabled = !t;
            nudSoLuong.Enabled = !t;
            cmbMauSac.Enabled = !t;
            cmbTrangThai.Enabled = !t;
            txtTenHinh.ReadOnly = t;
        }
        void HienThiTextBox(int vt, DataSet ds)
        {
            flpHinhAnh.Controls.Clear();
            txtMaSanPham.Text = ds.Tables[0].Rows[vt]["MaSp"].ToString();
            txtTenSanPham.Text = ds.Tables[0].Rows[vt]["TenSp"].ToString();
            txtDonGia.Text = ds.Tables[0].Rows[vt]["GiaBan"].ToString();
            nudSoLuong.Text = ds.Tables[0].Rows[vt]["SoLuong"].ToString();
            txtTenHinh.Text = ds.Tables[0].Rows[vt]["HinhAnh"].ToString();

            string sql1 = "select TenNcc from NhaCungCap where MaNCC = '" + ds.Tables[0].Rows[vt]["MaNcc"].ToString() + "'";
            dsNCC = c.layDuLieu(sql1);
            cmbTenNhaCungCap.DataSource = dsNCC.Tables[0];
            cmbTenNhaCungCap.DisplayMember = "TenNcc";

            string sql2 = "select TenLoaiSP from LoaiSanPham where MaLoaiSP = '" + ds.Tables[0].Rows[vt]["MaLoaiSP"].ToString() + "'";
            dsLoaiSP = c.layDuLieu(sql2);
            cmbTenLoaiSanPham.DataSource = dsLoaiSP.Tables[0];
            cmbTenLoaiSanPham.DisplayMember = "TenLoaiSP";

            string sql3 = "select TenMau from MauSac where MaMau = '" + ds.Tables[0].Rows[vt]["Color"].ToString() + "'";
            dsMau = c.layDuLieu(sql3);
            cmbMauSac.DataSource = dsMau.Tables[0];
            cmbMauSac.DisplayMember = "TenMau";

            string sql4 = "select TenKichThuoc from KichThuoc where MaKichThuoc = '" + ds.Tables[0].Rows[vt]["Size"].ToString() + "'";
            dsKichThuoc = c.layDuLieu(sql4);
            cmbKichThuoc.DataSource = dsKichThuoc.Tables[0];
            cmbKichThuoc.DisplayMember = "TenKichThuoc";

            if (ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
            {
                cmbTrangThai.Text = "Hoạt động";
            }
            else
            {
                cmbTrangThai.Text = "Ngưng hoạt động";
            }

            string TextHinh = txtTenHinh.Text;
            string[] HinhAnh = TextHinh.Split(';');
            flpHinhAnh.Controls.Clear();
            for (int i = 0; i < HinhAnh.Count(); i++)
            {
                string TenFile = Path.GetFullPath("hinh") + @"\";
                if (HinhAnh[i] != "")
                {
                    TenFile = TenFile + HinhAnh[i];
                }
                else
                {
                    break;
                }
                Bitmap a = new Bitmap(TenFile);
                PictureBox p = new PictureBox();
                p.Image = a;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Size = new Size(250, 250);
                flpHinhAnh.Controls.Add(p);
            }
        }
        private void frmKichHoatSanPham_Load(object sender, EventArgs e)
        {
            LayDuLieu("select *from SanPham where TrangThai = 0", dgvSanPham);
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng Hoạt động");
            XuLyTextBox(true);
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox(vt, ds);
        }
        bool KiemTraBoTrong()
        {
            if (txtMaSanPham.Text == "" || txtTenSanPham.Text == "" || txtDonGia.Text == "" || nudSoLuong.Text == "" || cmbTenLoaiSanPham.SelectedIndex == -1 || cmbTenNhaCungCap.SelectedIndex == -1 || cmbMauSac.SelectedIndex == -1 || cmbKichThuoc.SelectedIndex == -1 || txtTenHinh.Text == "")
            {
                return false;
            }
            return true;
        }
        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong() == false)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần kích hoạt", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                string sql2 = "update SanPham set TrangThai = 1 where MaSp = '" + txtMaSanPham.Text + "'";
                DialogResult kq = MessageBox.Show("Bạn có muốn kích hoạt sản phẩm này", "Thông báo kích hoạt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    if (c.CapNhatDuLieu(sql2) != 0)
                    {
                        MessageBox.Show("Kích hoạt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaSanPham.Text = "";
                        txtTenSanPham.Text = "";
                        txtDonGia.Text = "";
                        nudSoLuong.Text = "";
                        cmbTenLoaiSanPham.Text = "";
                        cmbTenNhaCungCap.Text = "";
                        cmbMauSac.Text = "";
                        cmbKichThuoc.Text = "";
                        txtTenHinh.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lưu trữ", "Không thễ lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    flpHinhAnh.Controls.Clear();
                    txtMaSanPham.Text = "";
                    txtTenSanPham.Text = "";
                    txtDonGia.Text = "";
                    nudSoLuong.Text = "";
                    cmbTenLoaiSanPham.Text = "";
                    cmbTenNhaCungCap.Text = "";
                    cmbMauSac.Text = "";
                    cmbKichThuoc.Text = "";
                    txtTenHinh.Text = "";
                    dgvSanPham.Enabled = true;
                    cmbTrangThai.SelectedIndex = -1;
                    XuLyTextBox(true);
                }
            }
            
        }

        private void frmKichHoatSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LayDuLieu("select *from SanPham where TrangThai = 0", dgvSanPham);
            XuLyTextBox(true);
        }
    }
}
