namespace Phuc
{
    partial class Form3
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
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.colMSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSinhvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiemQT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTongKet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbSv = new System.Windows.Forms.Label();
            this.tbMH = new System.Windows.Forms.Label();
            this.lbDiem = new System.Windows.Forms.Label();
            this.cboSinhVien = new System.Windows.Forms.ComboBox();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.lbDiemThi = new System.Windows.Forms.Label();
            this.tbDiemQT = new System.Windows.Forms.TextBox();
            this.tbDiemThi = new System.Windows.Forms.TextBox();
            this.lbTongKet = new System.Windows.Forms.Label();
            this.tbDiemTK = new System.Windows.Forms.TextBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btLamMoi = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiem
            // 
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMSV,
            this.colSinhvien,
            this.ColTenMon,
            this.ColDiemQT,
            this.ColDiemThi,
            this.ColTongKet});
            this.dgvDiem.Location = new System.Drawing.Point(-6, 323);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.RowHeadersWidth = 62;
            this.dgvDiem.RowTemplate.Height = 28;
            this.dgvDiem.Size = new System.Drawing.Size(873, 170);
            this.dgvDiem.TabIndex = 0;
            // 
            // colMSV
            // 
            this.colMSV.HeaderText = "MSV";
            this.colMSV.MinimumWidth = 8;
            this.colMSV.Name = "colMSV";
            this.colMSV.Width = 150;
            // 
            // colSinhvien
            // 
            this.colSinhvien.HeaderText = "Sinh Viên";
            this.colSinhvien.MinimumWidth = 8;
            this.colSinhvien.Name = "colSinhvien";
            this.colSinhvien.Width = 150;
            // 
            // ColTenMon
            // 
            this.ColTenMon.HeaderText = "Môn Học";
            this.ColTenMon.MinimumWidth = 8;
            this.ColTenMon.Name = "ColTenMon";
            this.ColTenMon.Width = 150;
            // 
            // ColDiemQT
            // 
            this.ColDiemQT.HeaderText = "ĐiểmQT";
            this.ColDiemQT.MinimumWidth = 8;
            this.ColDiemQT.Name = "ColDiemQT";
            this.ColDiemQT.Width = 150;
            // 
            // ColDiemThi
            // 
            this.ColDiemThi.HeaderText = "Điểm Thi";
            this.ColDiemThi.MinimumWidth = 8;
            this.ColDiemThi.Name = "ColDiemThi";
            this.ColDiemThi.Width = 130;
            // 
            // ColTongKet
            // 
            this.ColTongKet.HeaderText = "Tổng Kết";
            this.ColTongKet.MinimumWidth = 8;
            this.ColTongKet.Name = "ColTongKet";
            this.ColTongKet.Width = 150;
            // 
            // lbSv
            // 
            this.lbSv.AutoSize = true;
            this.lbSv.Location = new System.Drawing.Point(60, 40);
            this.lbSv.Name = "lbSv";
            this.lbSv.Size = new System.Drawing.Size(81, 20);
            this.lbSv.TabIndex = 1;
            this.lbSv.Text = "Sinh Viên:";
            // 
            // tbMH
            // 
            this.tbMH.AutoSize = true;
            this.tbMH.Location = new System.Drawing.Point(60, 85);
            this.tbMH.Name = "tbMH";
            this.tbMH.Size = new System.Drawing.Size(77, 20);
            this.tbMH.TabIndex = 2;
            this.tbMH.Text = "Môn Học:";
            // 
            // lbDiem
            // 
            this.lbDiem.AutoSize = true;
            this.lbDiem.Location = new System.Drawing.Point(60, 130);
            this.lbDiem.Name = "lbDiem";
            this.lbDiem.Size = new System.Drawing.Size(71, 20);
            this.lbDiem.TabIndex = 3;
            this.lbDiem.Text = "ĐiểmQT:";
            // 
            // cboSinhVien
            // 
            this.cboSinhVien.FormattingEnabled = true;
            this.cboSinhVien.Location = new System.Drawing.Point(203, 40);
            this.cboSinhVien.Name = "cboSinhVien";
            this.cboSinhVien.Size = new System.Drawing.Size(183, 28);
            this.cboSinhVien.TabIndex = 4;
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(203, 85);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(183, 28);
            this.cboMonHoc.TabIndex = 5;
            // 
            // lbDiemThi
            // 
            this.lbDiemThi.AutoSize = true;
            this.lbDiemThi.Location = new System.Drawing.Point(60, 181);
            this.lbDiemThi.Name = "lbDiemThi";
            this.lbDiemThi.Size = new System.Drawing.Size(75, 20);
            this.lbDiemThi.TabIndex = 7;
            this.lbDiemThi.Text = "Điểm Thi:";
            // 
            // tbDiemQT
            // 
            this.tbDiemQT.Location = new System.Drawing.Point(203, 130);
            this.tbDiemQT.Name = "tbDiemQT";
            this.tbDiemQT.Size = new System.Drawing.Size(183, 26);
            this.tbDiemQT.TabIndex = 8;
            // 
            // tbDiemThi
            // 
            this.tbDiemThi.Location = new System.Drawing.Point(203, 181);
            this.tbDiemThi.Name = "tbDiemThi";
            this.tbDiemThi.Size = new System.Drawing.Size(183, 26);
            this.tbDiemThi.TabIndex = 9;
            // 
            // lbTongKet
            // 
            this.lbTongKet.AutoSize = true;
            this.lbTongKet.Location = new System.Drawing.Point(488, 47);
            this.lbTongKet.Name = "lbTongKet";
            this.lbTongKet.Size = new System.Drawing.Size(75, 20);
            this.lbTongKet.TabIndex = 10;
            this.lbTongKet.Text = "Tổng kết:";
            // 
            // tbDiemTK
            // 
            this.tbDiemTK.Location = new System.Drawing.Point(606, 47);
            this.tbDiemTK.Name = "tbDiemTK";
            this.tbDiemTK.Size = new System.Drawing.Size(168, 26);
            this.tbDiemTK.TabIndex = 11;
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(296, 249);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(90, 38);
            this.btThem.TabIndex = 12;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(412, 249);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(87, 38);
            this.btSua.TabIndex = 13;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(523, 249);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(84, 38);
            this.btXoa.TabIndex = 14;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            // 
            // btLamMoi
            // 
            this.btLamMoi.Location = new System.Drawing.Point(634, 249);
            this.btLamMoi.Name = "btLamMoi";
            this.btLamMoi.Size = new System.Drawing.Size(84, 38);
            this.btLamMoi.TabIndex = 15;
            this.btLamMoi.Text = "Làm Mới";
            this.btLamMoi.UseVisualStyleBackColor = true;
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(736, 249);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(86, 38);
            this.btExport.TabIndex = 16;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 494);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btLamMoi);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.tbDiemTK);
            this.Controls.Add(this.lbTongKet);
            this.Controls.Add(this.tbDiemThi);
            this.Controls.Add(this.tbDiemQT);
            this.Controls.Add(this.lbDiemThi);
            this.Controls.Add(this.cboMonHoc);
            this.Controls.Add(this.cboSinhVien);
            this.Controls.Add(this.lbDiem);
            this.Controls.Add(this.tbMH);
            this.Controls.Add(this.lbSv);
            this.Controls.Add(this.dgvDiem);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSinhvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiemQT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTongKet;
        private System.Windows.Forms.Label lbSv;
        private System.Windows.Forms.Label tbMH;
        private System.Windows.Forms.Label lbDiem;
        private System.Windows.Forms.ComboBox cboSinhVien;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label lbDiemThi;
        private System.Windows.Forms.TextBox tbDiemQT;
        private System.Windows.Forms.TextBox tbDiemThi;
        private System.Windows.Forms.Label lbTongKet;
        private System.Windows.Forms.TextBox tbDiemTK;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btLamMoi;
        private System.Windows.Forms.Button btExport;
    }
}