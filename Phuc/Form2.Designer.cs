namespace Phuc
{
    partial class Form2
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
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.colMamon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinchi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_MaMon = new System.Windows.Forms.Label();
            this.lb_MonHoc = new System.Windows.Forms.Label();
            this.lb_TinChi = new System.Windows.Forms.Label();
            this.tbMaMon = new System.Windows.Forms.TextBox();
            this.tbTenMon = new System.Windows.Forms.TextBox();
            this.tbSoTinChi = new System.Windows.Forms.TextBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMamon,
            this.colMonHoc,
            this.colTinchi});
            this.dgvMonHoc.Location = new System.Drawing.Point(-8, 283);
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersWidth = 62;
            this.dgvMonHoc.RowTemplate.Height = 28;
            this.dgvMonHoc.Size = new System.Drawing.Size(941, 211);
            this.dgvMonHoc.TabIndex = 0;
            // 
            // colMamon
            // 
            this.colMamon.HeaderText = "Mã môn";
            this.colMamon.MinimumWidth = 8;
            this.colMamon.Name = "colMamon";
            this.colMamon.Width = 150;
            // 
            // colMonHoc
            // 
            this.colMonHoc.HeaderText = "Môn Học";
            this.colMonHoc.MinimumWidth = 8;
            this.colMonHoc.Name = "colMonHoc";
            this.colMonHoc.Width = 150;
            // 
            // colTinchi
            // 
            this.colTinchi.HeaderText = "Số Tín Chỉ";
            this.colTinchi.MinimumWidth = 8;
            this.colTinchi.Name = "colTinchi";
            this.colTinchi.Width = 150;
            // 
            // lb_MaMon
            // 
            this.lb_MaMon.AutoSize = true;
            this.lb_MaMon.Location = new System.Drawing.Point(64, 30);
            this.lb_MaMon.Name = "lb_MaMon";
            this.lb_MaMon.Size = new System.Drawing.Size(70, 20);
            this.lb_MaMon.TabIndex = 1;
            this.lb_MaMon.Text = "Mã Môn:";
            // 
            // lb_MonHoc
            // 
            this.lb_MonHoc.AutoSize = true;
            this.lb_MonHoc.Location = new System.Drawing.Point(64, 76);
            this.lb_MonHoc.Name = "lb_MonHoc";
            this.lb_MonHoc.Size = new System.Drawing.Size(77, 20);
            this.lb_MonHoc.TabIndex = 2;
            this.lb_MonHoc.Text = "Môn Học:";
            // 
            // lb_TinChi
            // 
            this.lb_TinChi.AutoSize = true;
            this.lb_TinChi.Location = new System.Drawing.Point(64, 119);
            this.lb_TinChi.Name = "lb_TinChi";
            this.lb_TinChi.Size = new System.Drawing.Size(61, 20);
            this.lb_TinChi.TabIndex = 3;
            this.lb_TinChi.Text = "Tín Chỉ:";
            // 
            // tbMaMon
            // 
            this.tbMaMon.Location = new System.Drawing.Point(188, 23);
            this.tbMaMon.Name = "tbMaMon";
            this.tbMaMon.Size = new System.Drawing.Size(199, 26);
            this.tbMaMon.TabIndex = 4;
            // 
            // tbTenMon
            // 
            this.tbTenMon.Location = new System.Drawing.Point(188, 76);
            this.tbTenMon.Name = "tbTenMon";
            this.tbTenMon.Size = new System.Drawing.Size(199, 26);
            this.tbTenMon.TabIndex = 5;
            // 
            // tbSoTinChi
            // 
            this.tbSoTinChi.Location = new System.Drawing.Point(188, 119);
            this.tbSoTinChi.Name = "tbSoTinChi";
            this.tbSoTinChi.Size = new System.Drawing.Size(199, 26);
            this.tbSoTinChi.TabIndex = 6;
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(373, 196);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(102, 43);
            this.btThem.TabIndex = 7;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(496, 196);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(93, 43);
            this.btXoa.TabIndex = 8;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(612, 196);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(102, 43);
            this.btSua.TabIndex = 9;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            // 
            // btLamMoi
            // 
            this.btLamMoi.Location = new System.Drawing.Point(734, 196);
            this.btLamMoi.Name = "btLamMoi";
            this.btLamMoi.Size = new System.Drawing.Size(109, 43);
            this.btLamMoi.TabIndex = 10;
            this.btLamMoi.Text = "Làm Mới";
            this.btLamMoi.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 487);
            this.Controls.Add(this.btLamMoi);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.tbSoTinChi);
            this.Controls.Add(this.tbTenMon);
            this.Controls.Add(this.tbMaMon);
            this.Controls.Add(this.lb_TinChi);
            this.Controls.Add(this.lb_MonHoc);
            this.Controls.Add(this.lb_MaMon);
            this.Controls.Add(this.dgvMonHoc);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMamon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinchi;
        private System.Windows.Forms.Label lb_MaMon;
        private System.Windows.Forms.Label lb_MonHoc;
        private System.Windows.Forms.Label lb_TinChi;
        private System.Windows.Forms.TextBox tbMaMon;
        private System.Windows.Forms.TextBox tbTenMon;
        private System.Windows.Forms.TextBox tbSoTinChi;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btLamMoi;
    }
}