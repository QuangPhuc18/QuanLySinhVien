namespace Phuc
{
    partial class Form1
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btn_KhuVuc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.Mã = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_GioiTinh = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btExport = new System.Windows.Forms.Button();
            this.img = new System.Windows.Forms.Label();
            this.sdt = new System.Windows.Forms.Label();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.nganh = new System.Windows.Forms.Label();
            this.lop = new System.Windows.Forms.Label();
            this.tbLop = new System.Windows.Forms.TextBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(446, 343);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 41);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Thêm";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(579, 343);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 41);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(716, 343);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(100, 41);
            this.btEdit.TabIndex = 3;
            this.btEdit.Text = "Sửa";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(288, 343);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(136, 41);
            this.btRead.TabIndex = 4;
            this.btRead.Text = "Đọc dữ liệu";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(129, 22);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(206, 26);
            this.tbId.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(129, 70);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(429, 26);
            this.tbName.TabIndex = 8;
            // 
            // btn_KhuVuc
            // 
            this.btn_KhuVuc.FormattingEnabled = true;
            this.btn_KhuVuc.Location = new System.Drawing.Point(129, 122);
            this.btn_KhuVuc.Name = "btn_KhuVuc";
            this.btn_KhuVuc.Size = new System.Drawing.Size(200, 28);
            this.btn_KhuVuc.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Khu vực";
            // 
            // btn_date
            // 
            this.btn_date.Location = new System.Drawing.Point(129, 175);
            this.btn_date.Name = "btn_date";
            this.btn_date.Size = new System.Drawing.Size(200, 26);
            this.btn_date.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ngày sinh";
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mã,
            this.Column2,
            this.colKhuVuc,
            this.colNgaySinh,
            this.colGioiTinh,
            this.ColNganh,
            this.collop});
            this.dgvSinhVien.Location = new System.Drawing.Point(-3, 446);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersWidth = 62;
            this.dgvSinhVien.RowTemplate.Height = 28;
            this.dgvSinhVien.Size = new System.Drawing.Size(1050, 293);
            this.dgvSinhVien.TabIndex = 2;
            // 
            // Mã
            // 
            this.Mã.DataPropertyName = "id";
            this.Mã.HeaderText = "Mã";
            this.Mã.MinimumWidth = 8;
            this.Mã.Name = "Mã";
            this.Mã.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name";
            this.Column2.HeaderText = "Tên";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 160;
            // 
            // colKhuVuc
            // 
            this.colKhuVuc.HeaderText = "Khu Vực";
            this.colKhuVuc.MinimumWidth = 8;
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.Width = 80;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.HeaderText = "Ngày Sinh";
            this.colNgaySinh.MinimumWidth = 8;
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Width = 150;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.MinimumWidth = 8;
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Width = 150;
            // 
            // ColNganh
            // 
            this.ColNganh.HeaderText = "Ngành";
            this.ColNganh.MinimumWidth = 8;
            this.ColNganh.Name = "ColNganh";
            this.ColNganh.Width = 150;
            // 
            // collop
            // 
            this.collop.HeaderText = "Lớp";
            this.collop.MinimumWidth = 8;
            this.collop.Name = "collop";
            this.collop.Width = 150;
            // 
            // btn_GioiTinh
            // 
            this.btn_GioiTinh.FormattingEnabled = true;
            this.btn_GioiTinh.Location = new System.Drawing.Point(481, 130);
            this.btn_GioiTinh.Name = "btn_GioiTinh";
            this.btn_GioiTinh.Size = new System.Drawing.Size(121, 28);
            this.btn_GioiTinh.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Giới tính:";
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(838, 343);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(100, 41);
            this.btExport.TabIndex = 16;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // img
            // 
            this.img.AutoSize = true;
            this.img.Location = new System.Drawing.Point(807, 239);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(73, 20);
            this.img.TabIndex = 17;
            this.img.Text = "Hình ảnh";
            // 
            // sdt
            // 
            this.sdt.AutoSize = true;
            this.sdt.Location = new System.Drawing.Point(373, 190);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(106, 20);
            this.sdt.TabIndex = 18;
            this.sdt.Text = "Số điện thoại:";
            // 
            // tbSDT
            // 
            this.tbSDT.Location = new System.Drawing.Point(481, 184);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(172, 26);
            this.tbSDT.TabIndex = 19;
            // 
            // cboNganh
            // 
            this.cboNganh.FormattingEnabled = true;
            this.cboNganh.Location = new System.Drawing.Point(129, 231);
            this.cboNganh.Name = "cboNganh";
            this.cboNganh.Size = new System.Drawing.Size(200, 28);
            this.cboNganh.TabIndex = 20;
            // 
            // nganh
            // 
            this.nganh.AutoSize = true;
            this.nganh.Location = new System.Drawing.Point(29, 231);
            this.nganh.Name = "nganh";
            this.nganh.Size = new System.Drawing.Size(60, 20);
            this.nganh.TabIndex = 22;
            this.nganh.Text = "Ngành:";
            // 
            // lop
            // 
            this.lop.AutoSize = true;
            this.lop.Location = new System.Drawing.Point(377, 238);
            this.lop.Name = "lop";
            this.lop.Size = new System.Drawing.Size(40, 20);
            this.lop.TabIndex = 23;
            this.lop.Text = "Lớp:";
            // 
            // tbLop
            // 
            this.tbLop.Location = new System.Drawing.Point(481, 231);
            this.tbLop.Name = "tbLop";
            this.tbLop.Size = new System.Drawing.Size(172, 26);
            this.tbLop.TabIndex = 24;
            // 
            // picAvatar
            // 
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Location = new System.Drawing.Point(788, 96);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(110, 140);
            this.picAvatar.TabIndex = 25;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(988, 13);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(202, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(629, 17);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(297, 33);
            this.menuStrip2.TabIndex = 27;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýĐiểmToolStripMenuItem,
            this.quảnLýMônHọcToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // quảnLýĐiểmToolStripMenuItem
            // 
            this.quảnLýĐiểmToolStripMenuItem.Name = "quảnLýĐiểmToolStripMenuItem";
            this.quảnLýĐiểmToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.quảnLýĐiểmToolStripMenuItem.Text = "Quản lý điểm";
            this.quảnLýĐiểmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐiểmToolStripMenuItem_Click);
            // 
            // quảnLýMônHọcToolStripMenuItem
            // 
            this.quảnLýMônHọcToolStripMenuItem.Name = "quảnLýMônHọcToolStripMenuItem";
            this.quảnLýMônHọcToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.quảnLýMônHọcToolStripMenuItem.Text = "Quản lý môn học";
            this.quảnLýMônHọcToolStripMenuItem.Click += new System.EventHandler(this.quảnLýMônHọcToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1044, 648);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.tbLop);
            this.Controls.Add(this.lop);
            this.Controls.Add(this.nganh);
            this.Controls.Add(this.cboNganh);
            this.Controls.Add(this.tbSDT);
            this.Controls.Add(this.sdt);
            this.Controls.Add(this.img);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_GioiTinh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_KhuVuc);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox btn_KhuVuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker btn_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.ComboBox btn_GioiTinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picAvata;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Label img;
        private System.Windows.Forms.Label sdt;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.Label nganh;
        private System.Windows.Forms.Label lop;
        private System.Windows.Forms.TextBox tbLop;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mã;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhuVuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn collop;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýMônHọcToolStripMenuItem;
    }
}

