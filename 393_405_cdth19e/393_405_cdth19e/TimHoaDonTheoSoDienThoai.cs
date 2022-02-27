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
    public partial class frmTimHoaDonTheoSoDienThoai : Form
    {
        public frmTimHoaDonTheoSoDienThoai()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            dgvDanhSachHoaDon.DataSource = c.LayDuLieuTheoThuTuc("TimKhachHangTheoSDT", "@SDT",txtSoDienThoai.Text);
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
    }
}
