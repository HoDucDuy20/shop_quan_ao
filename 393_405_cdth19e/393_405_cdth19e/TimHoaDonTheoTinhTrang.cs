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
    public partial class frmTimHoaDonTheoTinhTrang : Form
    {
        public frmTimHoaDonTheoTinhTrang()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        void LayDuLieu(string sql,DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimHoaDonTheoTinhTrang_Load(object sender, EventArgs e)
        {
            cmbTrangThai.Items.Add("Mới");
            cmbTrangThai.Items.Add("Đang giao");
            cmbTrangThai.Items.Add("Đã giao");
            cmbTrangThai.Items.Add("Đã hủy");
        }
        int KiemTraTinhTrang()
        {
            if (cmbTrangThai.Text == "Mới") 
            {
                return 1;
            }
            if (cmbTrangThai.Text == "Đang giao")
            {
                return 2;
            }
            if (cmbTrangThai.Text == "Đã giao")
            {
                return 3;
            }
            return 0;
        }
        private void frmTimHoaDonTheoTinhTrang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrangThai.SelectedIndex!=-1)
            {
                string sql = "select * from HoaDon where TrangThai = " + KiemTraTinhTrang();
                LayDuLieu(sql,dgvDanhSachHoaDon);
            }
        }
    }
}
