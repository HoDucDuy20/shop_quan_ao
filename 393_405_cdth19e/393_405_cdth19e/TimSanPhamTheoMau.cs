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
    public partial class frmTimSanPhamTheoMau : Form
    {
        public frmTimSanPhamTheoMau()
        {
            InitializeComponent();
        }

        private void frmTimSanPhamTheoMau_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        DataSet dsMau = new DataSet();
        void LayDuLieu(string sql,DataGridView dg)
        {
            ds = c.layDuLieu(sql);
            dg.DataSource = ds.Tables[0];
        }
        private void cmbMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flag==true)
            {
                if(cmbMau.SelectedIndex!=-1)
                {
                    string sql= "select SanPham.MaSp,SanPham.TenSp,SanPham.SoLuong, SanPham.GiaBan from SanPham where Color = '"+cmbMau.SelectedValue.ToString()+"'";
                    LayDuLieu(sql, dgvDanhSachSanPham);
                }
            }
        }
        bool flag = false;
        private void frmTimSanPhamTheoMau_Load(object sender, EventArgs e)
        {
            string sql= "select MaMau,TenMau from MauSac";
            dsMau = c.layDuLieu(sql);
            cmbMau.DataSource = dsMau.Tables[0];
            cmbMau.DisplayMember = "TenMau";
            cmbMau.ValueMember = "MaMau";
            cmbMau.SelectedIndex = -1;
            flag = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
