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
    public partial class frmTimSanPhamTheoLoaiSP : Form
    {
        public frmTimSanPhamTheoLoaiSP()
        {
            InitializeComponent();
        }
        DataSet dsLoaiSP = new DataSet();
        DataSet ds = new DataSet();
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        void hienThiDuLieu(string sql, DataGridView d)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void frmTimSanPhamTheoLoaiSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        bool flag = false;
        private void frmTimSanPhamTheoLoaiSP_Load(object sender, EventArgs e)
        {
            string sql = "select MaLoaiSP, TenLoaiSP from LoaiSanPham";
            dsLoaiSP = c.layDuLieu(sql);
            cboDS.DataSource = dsLoaiSP.Tables[0];
            cboDS.DisplayMember = "TenLoaiSP";
            cboDS.ValueMember = "MaLoaiSP";
            flag = true;
            cboDS.SelectedIndex = -1;
        }

        private void cboDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cboDS.SelectedIndex != -1)
                {
                    string sql = "select * from SanPham where MaLoaiSP = '" + cboDS.SelectedValue.ToString() + "'";
                    hienThiDuLieu(sql, dgvDanhSach);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
