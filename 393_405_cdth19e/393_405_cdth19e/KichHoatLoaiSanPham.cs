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
    public partial class frmKichHoatLoaiSanPham : Form
    {
        public frmKichHoatLoaiSanPham()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void hienThiDuLieu(string sql, DataGridView d)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void XuLyTextBox(Boolean t)
        {
            txtMaLoai.ReadOnly = t;
            txtTenLoai.ReadOnly = t;
            cboTinhTrang.Enabled = !t;
        }
        void hienThiTextBox(int vt, DataSet ds)
        {
            txtMaLoai.Text = ds.Tables[0].Rows[vt]["MaLoaiSP"].ToString();
            txtTenLoai.Text = ds.Tables[0].Rows[vt]["TenLoaiSP"].ToString();
            if (ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
            {
                cboTinhTrang.SelectedIndex = 0;
            }
            else
            {
                cboTinhTrang.SelectedIndex = 1;
            }
        }

        private void KichHoatLoaiSanPham_Load(object sender, EventArgs e)
        {
            hienThiDuLieu("select * from LoaiSanPham where TrangThai = 0", dgvDanhSach);
            cboTinhTrang.Items.Add("Hoạt động");
            cboTinhTrang.Items.Add("Ngưng Hoạt động");
            XuLyTextBox(true);
        }

        private void KichHoatLoaiSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            hienThiTextBox(vt, ds);
        }

        private void btnKichHoat_Click_1(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "" || txtTenLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần kích hoạt", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XuLyTextBox(true);
            }
            else
            {
                DialogResult kq = MessageBox.Show("Bạn muốn kích hoạt loại sản phẩm ", "Thông báo kích hoạt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    string sql = "update LoaiSanPham set TrangThai = 1 where MaLoaiSP = '" + txtMaLoai.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Kích hoạt thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaLoai.Text = "";
                        txtTenLoai.Text = "";
                        dgvDanhSach.Enabled = true;
                        cboTinhTrang.SelectedIndex = -1;
                        XuLyTextBox(true);
                    }
                }
                else
                {
                    txtMaLoai.Text = "";
                    txtTenLoai.Text = "";
                    cboTinhTrang.SelectedIndex = -1;
                    dgvDanhSach.Enabled = true;
                    XuLyTextBox(true);
                }
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            hienThiDuLieu("select * from LoaiSanPham where TrangThai = 0", dgvDanhSach);
            XuLyTextBox(true);
        }
    }
}
