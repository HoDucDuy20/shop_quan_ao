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
    public partial class frmTimKiemKhachHangTheoDT : Form
    {
        public frmTimKiemKhachHangTheoDT()
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
        private void frmTimKiemKhachHangTheoDT_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where Phone like '%" + txtSoDienThoai.Text + "%'";
            hienThiDuLieu(sql, dgvDanhSach);
        }

        private void frmTimKiemKhachHangTheoDT_Load(object sender, EventArgs e)
        {

        }
    }
}
