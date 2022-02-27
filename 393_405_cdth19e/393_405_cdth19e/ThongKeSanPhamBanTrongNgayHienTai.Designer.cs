
namespace _393_405_cdth19e
{
    partial class frmThongKeSanPhamBanTrongNgayHienTai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTongSoLuong = new System.Windows.Forms.DataGridView();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTongSoLuong);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(683, 272);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Số lượng bán của sản phẩm trong ngày hiện tại  ";
            // 
            // dgvTongSoLuong
            // 
            this.dgvTongSoLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongSoLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenSanPham,
            this.TongSoLuong});
            this.dgvTongSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTongSoLuong.Location = new System.Drawing.Point(3, 17);
            this.dgvTongSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTongSoLuong.Name = "dgvTongSoLuong";
            this.dgvTongSoLuong.RowHeadersWidth = 56;
            this.dgvTongSoLuong.RowTemplate.Height = 24;
            this.dgvTongSoLuong.Size = new System.Drawing.Size(677, 253);
            this.dgvTongSoLuong.TabIndex = 0;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSp";
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.MinimumWidth = 6;
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 150;
            // 
            // TongSoLuong
            // 
            this.TongSoLuong.DataPropertyName = "TONGSOLUONG";
            this.TongSoLuong.HeaderText = "Số lượng bán";
            this.TongSoLuong.MinimumWidth = 6;
            this.TongSoLuong.Name = "TongSoLuong";
            this.TongSoLuong.Width = 150;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(713, 64);
            this.label1.TabIndex = 44;
            this.label1.Text = "Thống kê số lượng bán của từng sản phẩm trong ngày hiện tại";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmThongKeSanPhamBanTrongNgayHienTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThongKeSanPhamBanTrongNgayHienTai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThongKeSanPhamBanTrongNgayHienTai";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThongKeSanPhamBanTrongNgayHienTai_FormClosing);
            this.Load += new System.EventHandler(this.ThongKeSanPhamBanTrongNgayHienTai_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTongSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoLuong;
    }
}