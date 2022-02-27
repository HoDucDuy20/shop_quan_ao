
namespace _393_405_cdth19e
{
    partial class frmThongKeTongSoLuongBan
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
            this.btnThongKe = new System.Windows.Forms.Button();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTongSoLuong);
            this.groupBox1.Location = new System.Drawing.Point(24, 212);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(512, 226);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng số lượng bán của từng sản phẩm trong ";
            // 
            // dgvTongSoLuong
            // 
            this.dgvTongSoLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongSoLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenSanPham,
            this.TongSoLuong});
            this.dgvTongSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTongSoLuong.Location = new System.Drawing.Point(2, 15);
            this.dgvTongSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTongSoLuong.Name = "dgvTongSoLuong";
            this.dgvTongSoLuong.RowHeadersWidth = 56;
            this.dgvTongSoLuong.RowTemplate.Height = 24;
            this.dgvTongSoLuong.Size = new System.Drawing.Size(508, 209);
            this.dgvTongSoLuong.TabIndex = 0;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSp";
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 150;
            // 
            // TongSoLuong
            // 
            this.TongSoLuong.DataPropertyName = "TONGSOLUONG";
            this.TongSoLuong.HeaderText = "Tổng số lượng";
            this.TongSoLuong.Name = "TongSoLuong";
            this.TongSoLuong.Width = 150;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(195, 166);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(94, 32);
            this.btnThongKe.TabIndex = 45;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(234, 65);
            this.txtThang.Margin = new System.Windows.Forms.Padding(2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(165, 26);
            this.txtThang.TabIndex = 44;
            this.txtThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThang_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Nhập tháng";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 52);
            this.label1.TabIndex = 41;
            this.label1.Text = "Thống kê số lượng bán của từng sản phẩm trong tháng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(234, 116);
            this.txtNam.Margin = new System.Windows.Forms.Padding(2);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(165, 26);
            this.txtNam.TabIndex = 47;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Nhập năm";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(293, 166);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 32);
            this.btnThoat.TabIndex = 48;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmThongKeTongSoLuongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 456);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "frmThongKeTongSoLuongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThongKeTongSoLuongBan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThongKeTongSoLuongBan_FormClosing);
            this.Load += new System.EventHandler(this.frmThongKeTongSoLuongBan_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTongSoLuong;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoLuong;
    }
}