using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; // Thư viện Excel

namespace Phuc
{
    public partial class Form3 : Form
    {
        // 1. CHUỖI KẾT NỐI
        string connStr = "Data Source=QUANGPHUC\\SQLEXPRESS;Database=DB_Customer;Trusted_Connection=True";

        public Form3()
        {
            InitializeComponent();

            // Gắn sự kiện
            this.Load += Form3_Load;
            dgvDiem.CellClick += dgvDiem_CellClick;
            btThem.Click += btThem_Click;
            btSua.Click += btSua_Click;
            btXoa.Click += btXoa_Click;
            btLamMoi.Click += btLamMoi_Click;
            if (btExport != null) btExport.Click += btExport_Click;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadCBOSinhVien();
            LoadCBOMonHoc();
            LoadData();
        }

        // --- CÁC HÀM LOAD DỮ LIỆU ---
        void LoadCBOSinhVien()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name FROM SinhVien2", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                cboSinhVien.DataSource = dt;
                cboSinhVien.DisplayMember = "Name"; cboSinhVien.ValueMember = "Id";
            }
        }

        void LoadCBOMonHoc()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaMon, TenMon FROM MonHoc", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                cboMonHoc.DataSource = dt;
                cboMonHoc.DisplayMember = "TenMon"; cboMonHoc.ValueMember = "MaMon";
            }
        }

        void LoadData()
        {
            dgvDiem.DataSource = null; dgvDiem.Columns.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT D.Id, D.MaSV, D.MaMon, S.Name, M.TenMon, D.DiemQT, D.DiemThi, D.DiemTK 
                               FROM Diem D 
                               JOIN SinhVien2 S ON D.MaSV = S.Id 
                               JOIN MonHoc M ON D.MaMon = M.MaMon";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                dgvDiem.DataSource = dt;

                ConfigGrid();
            }
        }

        // --- CẤU HÌNH HIỂN THỊ (Tiếng Việt + Làm tròn hiển thị) ---
        void ConfigGrid()
        {
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.ReadOnly = true;
            dgvDiem.AllowUserToAddRows = false;

            dgvDiem.Columns["Id"].Visible = false;
            dgvDiem.Columns["MaMon"].Visible = false;

            dgvDiem.Columns["MaSV"].Visible = true;
            dgvDiem.Columns["MaSV"].HeaderText = "Mã SV";
            dgvDiem.Columns["MaSV"].DisplayIndex = 0;
            dgvDiem.Columns["MaSV"].Width = 80;

            dgvDiem.Columns["Name"].HeaderText = "Họ và Tên";
            dgvDiem.Columns["TenMon"].HeaderText = "Môn Học";

            dgvDiem.Columns["DiemQT"].HeaderText = "Điểm Quá Trình";
            dgvDiem.Columns["DiemThi"].HeaderText = "Điểm Thi";
            dgvDiem.Columns["DiemTK"].HeaderText = "Tổng Kết";

            dgvDiem.Columns["DiemTK"].DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            // Format hiển thị số đẹp (8.5)
            dgvDiem.Columns["DiemQT"].DefaultCellStyle.Format = "N1";
            dgvDiem.Columns["DiemThi"].DefaultCellStyle.Format = "N1";
            dgvDiem.Columns["DiemTK"].DefaultCellStyle.Format = "N1";
        }

        // --- TÍNH TOÁN (Làm tròn 1 số) ---
        float TinhTong(float qt, float thi)
        {
            float ketQua = (float)(qt * 0.4 + thi * 0.6);
            return (float)Math.Round(ketQua, 1, MidpointRounding.AwayFromZero);
        }

        // --- NÚT THÊM (CÓ KIỂM TRA TRÙNG LẶP) ---
        private void btThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDiemQT.Text) || string.IsNullOrEmpty(tbDiemThi.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm!"); return;
            }
            try
            {
                // 1. Lấy thông tin từ giao diện
                int maSV = (int)cboSinhVien.SelectedValue;
                string maMon = cboMonHoc.SelectedValue.ToString();

                float qt = float.Parse(tbDiemQT.Text);
                float thi = float.Parse(tbDiemThi.Text);
                float tk = TinhTong(qt, thi);
                tbDiemTK.Text = tk.ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // --- BƯỚC QUAN TRỌNG: KIỂM TRA ĐÃ CÓ ĐIỂM CHƯA ---
                    string checkSql = "SELECT COUNT(*) FROM Diem WHERE MaSV = @sv AND MaMon = @mon";
                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@sv", maSV);
                    checkCmd.Parameters.AddWithValue("@mon", maMon);

                    int count = (int)checkCmd.ExecuteScalar(); // Đếm xem có dòng nào không

                    if (count > 0)
                    {
                        // Nếu tìm thấy (count > 0) nghĩa là đã có điểm rồi -> Báo lỗi và Dừng lại
                        MessageBox.Show("Sinh viên này ĐÃ CÓ ĐIỂM môn này rồi! Vui lòng chọn Sửa thay vì Thêm.", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // --------------------------------------------------

                    // Nếu chưa có thì mới thực hiện Thêm
                    string sql = "INSERT INTO Diem (MaSV, MaMon, DiemQT, DiemThi, DiemTK) VALUES (@sv, @mon, @qt, @thi, @tk)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sv", maSV);
                    cmd.Parameters.AddWithValue("@mon", maMon);
                    cmd.Parameters.AddWithValue("@qt", qt);
                    cmd.Parameters.AddWithValue("@thi", thi);
                    cmd.Parameters.AddWithValue("@tk", tk);

                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Đã thêm điểm thành công: " + tk);
                }
            }
            catch (Exception ex) { MessageBox.Show("Điểm phải là số: " + ex.Message); }
        }

        // --- NÚT SỬA ---
        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null) return;
            try
            {
                int idDiem = int.Parse(dgvDiem.CurrentRow.Cells["Id"].Value.ToString());

                // Khi sửa, mình cũng nên kiểm tra xem có sửa thành trùng với người khác không (Nâng cao)
                // Nhưng ở mức độ cơ bản, ta cho phép sửa chính dòng đó.

                float qt = float.Parse(tbDiemQT.Text);
                float thi = float.Parse(tbDiemThi.Text);
                float tk = TinhTong(qt, thi);
                tbDiemTK.Text = tk.ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "UPDATE Diem SET MaSV=@sv, MaMon=@mon, DiemQT=@qt, DiemThi=@thi, DiemTK=@tk WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idDiem);
                    cmd.Parameters.AddWithValue("@sv", cboSinhVien.SelectedValue);
                    cmd.Parameters.AddWithValue("@mon", cboMonHoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@qt", qt);
                    cmd.Parameters.AddWithValue("@thi", thi);
                    cmd.Parameters.AddWithValue("@tk", tk);
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Đã cập nhật điểm: " + tk);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- NÚT XÓA ---
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa điểm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Diem WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", dgvDiem.CurrentRow.Cells["Id"].Value);
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
            }
        }

        // --- CLICK LƯỚI ---
        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvDiem.Rows[e.RowIndex];
            cboSinhVien.SelectedValue = row.Cells["MaSV"].Value;
            cboMonHoc.SelectedValue = row.Cells["MaMon"].Value;

            // Format hiển thị lên TextBox
            if (row.Cells["DiemQT"].Value != null)
                tbDiemQT.Text = Convert.ToDouble(row.Cells["DiemQT"].Value).ToString("N1");

            if (row.Cells["DiemThi"].Value != null)
                tbDiemThi.Text = Convert.ToDouble(row.Cells["DiemThi"].Value).ToString("N1");

            if (row.Cells["DiemTK"].Value != null)
                tbDiemTK.Text = Convert.ToDouble(row.Cells["DiemTK"].Value).ToString("N1");
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            tbDiemQT.Text = ""; tbDiemThi.Text = ""; tbDiemTK.Text = "";
            if (cboSinhVien.Items.Count > 0) cboSinhVien.SelectedIndex = 0;
            if (cboMonHoc.Items.Count > 0) cboMonHoc.SelectedIndex = 0;
        }

        // --- XUẤT EXCEL ---
        private void btExport_Click(object sender, EventArgs e)
        {
            if (dgvDiem.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu!"); return; }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Files|*.xlsx;*.xls";
            save.FileName = "BangDiem_SV";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add();
                    Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;
                    ws.Name = "DiemSV";

                    int colIndex = 1;
                    for (int i = 0; i < dgvDiem.Columns.Count; i++)
                    {
                        if (dgvDiem.Columns[i].Visible)
                        {
                            ws.Cells[1, colIndex] = dgvDiem.Columns[i].HeaderText;
                            ws.Cells[1, colIndex].Font.Bold = true;
                            colIndex++;
                        }
                    }

                    for (int i = 0; i < dgvDiem.Rows.Count; i++)
                    {
                        colIndex = 1;
                        for (int j = 0; j < dgvDiem.Columns.Count; j++)
                        {
                            if (dgvDiem.Columns[j].Visible && dgvDiem.Rows[i].Cells[j].Value != null)
                            {
                                if (dgvDiem.Columns[j].Name == "DiemQT" || dgvDiem.Columns[j].Name == "DiemThi" || dgvDiem.Columns[j].Name == "DiemTK")
                                {
                                    double val = Convert.ToDouble(dgvDiem.Rows[i].Cells[j].Value);
                                    ws.Cells[i + 2, colIndex] = val.ToString("N1");
                                }
                                else
                                {
                                    ws.Cells[i + 2, colIndex] = dgvDiem.Rows[i].Cells[j].Value.ToString();
                                }
                                colIndex++;
                            }
                        }
                    }
                    ws.Columns.AutoFit();
                    wb.SaveAs(save.FileName);
                    wb.Close(); app.Quit();
                    MessageBox.Show("Xuất Excel thành công!");
                    System.Diagnostics.Process.Start(save.FileName);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xuất file: " + ex.Message); }
            }
        }
    }
}