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
    public partial class frmTimSanPhamTheoGia : Form
    {
        public frmTimSanPhamTheoGia()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (nupGiaBatdau.Value == 0 || nupGiaKetThuc.Value == 0)
            {
                MessageBox.Show("Không được bỏ trống giá", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = "select * from SanPham where GiaBan between " + nupGiaBatdau.Value + " and " + nupGiaKetThuc.Value;
                LayDuLieu(sql, dgvDanhSachSanPham);
            }
            nupGiaBatdau.Value = 0;
            nupGiaKetThuc.Value = 0;
        }

        private void frmTimSanPhamTheoGia_Load(object sender, EventArgs e)
        {
            nupGiaBatdau.Maximum = 1000000;
            nupGiaKetThuc.Maximum = 1000000;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimSanPhamTheoGia_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
