
namespace _393_405_cdth19e
{
    partial class frmThongKeSoLuongDonHang
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
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpKeThuc = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKQ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.CustomFormat = "MM/dd/yyyy";
            this.dtpBatDau.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatDau.Location = new System.Drawing.Point(112, 32);
            this.dtpBatDau.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(218, 32);
            this.dtpBatDau.TabIndex = 31;
            this.dtpBatDau.Value = new System.DateTime(2021, 6, 2, 0, 0, 0, 0);
            this.dtpBatDau.ValueChanged += new System.EventHandler(this.dtpBatDau_ValueChanged);
            // 
            // dtpKeThuc
            // 
            this.dtpKeThuc.CustomFormat = "MM/dd/yyyy";
            this.dtpKeThuc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKeThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKeThuc.Location = new System.Drawing.Point(418, 32);
            this.dtpKeThuc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtpKeThuc.Name = "dtpKeThuc";
            this.dtpKeThuc.Size = new System.Drawing.Size(218, 32);
            this.dtpKeThuc.TabIndex = 31;
            this.dtpKeThuc.Value = new System.DateTime(2021, 6, 2, 0, 0, 0, 0);
            this.dtpKeThuc.ValueChanged += new System.EventHandler(this.dtpKeThuc_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(362, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 32;
            this.label2.Text = "Đến";
            // 
            // lblKQ
            // 
            this.lblKQ.BackColor = System.Drawing.Color.White;
            this.lblKQ.Location = new System.Drawing.Point(72, 107);
            this.lblKQ.Name = "lblKQ";
            this.lblKQ.Size = new System.Drawing.Size(564, 41);
            this.lblKQ.TabIndex = 33;
            this.lblKQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmThongKeSoLuongDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 178);
            this.Controls.Add(this.lblKQ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpKeThuc);
            this.Controls.Add(this.dtpBatDau);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmThongKeSoLuongDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê số lượng đơn hàng";
            this.Load += new System.EventHandler(this.frmThongKeSoLuongDonHang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.DateTimePicker dtpKeThuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKQ;
    }
}