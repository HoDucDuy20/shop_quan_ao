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
    public partial class frmTimSanPhamTheoTinhTrang : Form
    {
        public frmTimSanPhamTheoTinhTrang()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet dsNCC = new DataSet();
        DataSet ds = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimSanPhamTheoTinhTrang_Load(object sender, EventArgs e)
        {
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng hoạt động");
            cmbTrangThai.SelectedIndex = -1;
        }
        int KiemTraTinhTrang()
        {
            if (cmbTrangThai.Text == "Hoạt động")
            {
                return 1;
            }
            return 0;
        }
        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrangThai.SelectedIndex != -1)
            {
                string sql = "select * from SanPham where TrangThai =" + KiemTraTinhTrang();
                LayDuLieu(sql, dgvDanhSachSanPham);
            }
        }

        private void frmTimSanPhamTheoTinhTrang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
