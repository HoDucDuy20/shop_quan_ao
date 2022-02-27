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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();

        void LayDuLieu(string sql)
        {
            ds = c.layDuLieu(sql);
        }

        void XoaTextBox()
        {
            txtMKcu.Text = "";
            txtMKmoi1.Text = "";
            txtMKmoi2.Text = "";
        }

        bool KiemTraBoTrong()
        {
            if(txtMKcu.Text == "" || txtMKmoi1.Text == "" || txtMKmoi2.Text == "")
            {
                return true;
            }
            return false;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            LayDuLieu("select * from TaiKhoan");
            txtMKcu.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            txtMKmoi1.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            txtMKmoi2.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi.Checked)
            {
                txtMKcu.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
                txtMKmoi1.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
                txtMKmoi2.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
            else
            {
                txtMKcu.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
                txtMKmoi1.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
                txtMKmoi2.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
        }

        public int taikhoan;
        private void frmDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if(KiemTraBoTrong())
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else if (txtMKcu.Text != ds.Tables[0].Rows[taikhoan]["MatKhau"].ToString())
            {
                MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XoaTextBox();
            }
            else if (txtMKmoi1.Text != txtMKmoi2.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XoaTextBox();
            }
            else if (txtMKcu.Text == txtMKmoi1.Text && txtMKmoi1.Text == txtMKmoi2.Text)
            {
                MessageBox.Show("Mật khẩu đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XoaTextBox();
            }
            else
            {
                string sql = "update TaiKhoan set MatKhau = '" + txtMKmoi1.Text + "' where TenTK = '" + ds.Tables[0].Rows[taikhoan]["TenTK"].ToString() + "'";
                c.CapNhatDuLieu(sql);
                MessageBox.Show("Mật khẩu đã được đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaTextBox();
                LayDuLieu("select * from TaiKhoan");
            }
        }
    }
}
