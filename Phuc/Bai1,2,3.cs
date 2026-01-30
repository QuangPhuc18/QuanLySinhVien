using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Phuc
{
    public partial class Form1 : Form
    {
        string connStr = "Data Source=QUANGPHUC\\SQLEXPRESS;Database=DB_Customer;Trusted_Connection=True";
        string duongDanAnh = "";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            picAvatar.Click += picAvatar_Click;

            // Chặn nhập chữ
            tbSDT.KeyPress += tbSDT_KeyPress;
        }

        private void tbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_KhuVuc.Items.AddRange(new string[] { "Bắc", "Trung", "Nam", "Tây Nguyên" }); btn_KhuVuc.SelectedIndex = 0;
            btn_GioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" }); btn_GioiTinh.SelectedIndex = 0;
            cboNganh.Items.AddRange(new string[] { "Công Nghệ Thông Tin", "Kinh Tế", "Du Lịch", "Ngôn Ngữ Anh", "Điện Tử" }); if (cboNganh.Items.Count > 0) cboNganh.SelectedIndex = 0;

            btn_date.Format = DateTimePickerFormat.Custom; btn_date.CustomFormat = "dd/MM/yyyy";

            dgvSinhVien.Columns.Clear(); dgvSinhVien.ColumnCount = 9;
            string[] headers = { "Mã", "Tên", "Khu Vực", "Ngày Sinh", "Giới Tính", "Ngành", "Lớp", "SĐT", "Ảnh" };
            for (int i = 0; i < 9; i++) { dgvSinhVien.Columns[i].HeaderText = headers[i]; }
            dgvSinhVien.Columns[8].Visible = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.AllowUserToAddRows = false; dgvSinhVien.ReadOnly = true;
        }

        private void LoadData()
        {
            dgvSinhVien.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlDataReader r = new SqlCommand("SELECT * FROM SinhVien2 ORDER BY Id ASC", conn).ExecuteReader();
                    while (r.Read()) dgvSinhVien.Rows.Add(r[0], r[1], r[2], Convert.ToDateTime(r[3]).ToString("dd/MM/yyyy"), r[4], r[5], r[6], r[7], r[8]);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void ResetHienThi()
        {
            tbId.Text = ""; tbName.Text = ""; tbLop.Text = ""; tbSDT.Text = "";
            btn_date.Value = DateTime.Now; picAvatar.Image = null; duongDanAnh = "";
            tbId.Focus();
        }

        private void btRead_Click(object sender, EventArgs e) { LoadData(); ResetHienThi(); }

        // --- NÚT THÊM (CHECK TRÙNG SĐT) ---
        private void btNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbId.Text) || string.IsNullOrEmpty(tbName.Text)) { MessageBox.Show("Nhập Mã và Tên!"); return; }

            // Validate Tuổi
            int tuoi = DateTime.Now.Year - btn_date.Value.Year;
            if (DateTime.Now < btn_date.Value.AddYears(tuoi)) tuoi--;
            if (tuoi < 18) { MessageBox.Show("Phải đủ 18 tuổi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // Validate SĐT 10 số
            if (tbSDT.Text.Length != 10) { MessageBox.Show("SĐT phải đúng 10 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbSDT.Focus(); return; }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // 1. Check Trùng Mã SV
                    SqlCommand checkID = new SqlCommand("SELECT COUNT(*) FROM SinhVien2 WHERE Id=@id", conn);
                    checkID.Parameters.AddWithValue("@id", int.Parse(tbId.Text));
                    if ((int)checkID.ExecuteScalar() > 0) { MessageBox.Show("Mã SV đã tồn tại!"); return; }

                    // 2. CHECK TRÙNG SĐT (MỚI THÊM)
                    SqlCommand checkSDT = new SqlCommand("SELECT COUNT(*) FROM SinhVien2 WHERE SDT=@sdt", conn);
                    checkSDT.Parameters.AddWithValue("@sdt", tbSDT.Text);
                    if ((int)checkSDT.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Số điện thoại này đã được sử dụng bởi sinh viên khác!", "Trùng SĐT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        tbSDT.Focus();
                        return;
                    }

                    // Thêm
                    string sql = "INSERT INTO SinhVien2 VALUES (@id, @name, @kv, @ns, @gt, @nganh, @lop, @sdt, @avt)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(tbId.Text));
                    cmd.Parameters.AddWithValue("@name", tbName.Text);
                    cmd.Parameters.AddWithValue("@kv", btn_KhuVuc.Text);
                    cmd.Parameters.AddWithValue("@ns", btn_date.Value);
                    cmd.Parameters.AddWithValue("@gt", btn_GioiTinh.Text);
                    cmd.Parameters.AddWithValue("@nganh", cboNganh.Text);
                    cmd.Parameters.AddWithValue("@lop", tbLop.Text);
                    cmd.Parameters.AddWithValue("@sdt", tbSDT.Text);
                    cmd.Parameters.AddWithValue("@avt", duongDanAnh);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    LoadData(); ResetHienThi();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- NÚT SỬA (CHECK TRÙNG SĐT) ---
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;

            // Validate Tuổi
            int tuoi = DateTime.Now.Year - btn_date.Value.Year;
            if (DateTime.Now < btn_date.Value.AddYears(tuoi)) tuoi--;
            if (tuoi < 18) { MessageBox.Show("Phải đủ 18 tuổi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // Validate SĐT 10 số
            if (tbSDT.Text.Length != 10) { MessageBox.Show("SĐT phải đúng 10 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbSDT.Focus(); return; }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    int idHienTai = int.Parse(dgvSinhVien.CurrentRow.Cells[0].Value.ToString());

                    // 1. CHECK TRÙNG SĐT (Trừ chính mình ra)
                    // Logic: Tìm xem có ai KHÁC (Id != IdHienTai) mà lại dùng chung số ĐT này không
                    string sqlCheck = "SELECT COUNT(*) FROM SinhVien2 WHERE SDT=@sdt AND Id != @id";
                    SqlCommand checkSDT = new SqlCommand(sqlCheck, conn);
                    checkSDT.Parameters.AddWithValue("@sdt", tbSDT.Text);
                    checkSDT.Parameters.AddWithValue("@id", idHienTai);

                    if ((int)checkSDT.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Số điện thoại này đang thuộc về sinh viên khác!", "Trùng SĐT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    // Sửa
                    string sql = "UPDATE SinhVien2 SET Name=@name, KhuVuc=@kv, NgaySinh=@ns, GioiTinh=@gt, Nganh=@nganh, Lop=@lop, SDT=@sdt, AvatarPath=@avt WHERE Id=@oldId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@oldId", idHienTai);
                    cmd.Parameters.AddWithValue("@name", tbName.Text);
                    cmd.Parameters.AddWithValue("@kv", btn_KhuVuc.Text);
                    cmd.Parameters.AddWithValue("@ns", btn_date.Value);
                    cmd.Parameters.AddWithValue("@gt", btn_GioiTinh.Text);
                    cmd.Parameters.AddWithValue("@nganh", cboNganh.Text);
                    cmd.Parameters.AddWithValue("@lop", tbLop.Text);
                    cmd.Parameters.AddWithValue("@sdt", tbSDT.Text);
                    cmd.Parameters.AddWithValue("@avt", duongDanAnh);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    LoadData(); ResetHienThi();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;
            if (MessageBox.Show("Xóa SV này?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    new SqlCommand("DELETE FROM SinhVien2 WHERE Id=" + dgvSinhVien.CurrentRow.Cells[0].Value, conn).ExecuteNonQuery();
                    LoadData(); ResetHienThi();
                }
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvSinhVien.Rows[e.RowIndex];
            tbId.Text = r.Cells[0].Value?.ToString();
            tbName.Text = r.Cells[1].Value?.ToString();
            btn_KhuVuc.Text = r.Cells[2].Value?.ToString();
            if (DateTime.TryParse(r.Cells[3].Value?.ToString(), out DateTime d)) btn_date.Value = d;
            btn_GioiTinh.Text = r.Cells[4].Value?.ToString();
            cboNganh.Text = r.Cells[5].Value?.ToString();
            tbLop.Text = r.Cells[6].Value?.ToString();
            tbSDT.Text = r.Cells[7].Value?.ToString();

            string path = r.Cells[8].Value?.ToString();
            if (File.Exists(path)) { picAvatar.Image = Image.FromFile(path); duongDanAnh = path; }
            else { picAvatar.Image = null; duongDanAnh = ""; }
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog(); o.Filter = "Image|*.jpg;*.png";
            if (o.ShowDialog() == DialogResult.OK) { picAvatar.Image = Image.FromFile(o.FileName); duongDanAnh = o.FileName; picAvatar.SizeMode = PictureBoxSizeMode.Zoom; }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.Rows.Count == 0) return;
            SaveFileDialog s = new SaveFileDialog(); s.Filter = "Excel|*.xlsx";
            if (s.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add();
                    Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;
                    for (int i = 0; i < dgvSinhVien.Columns.Count; i++) if (dgvSinhVien.Columns[i].Visible) ws.Cells[1, i + 1] = dgvSinhVien.Columns[i].HeaderText;
                    for (int i = 0; i < dgvSinhVien.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvSinhVien.Columns.Count; j++)
                        {
                            if (dgvSinhVien.Columns[j].Visible && dgvSinhVien.Rows[i].Cells[j].Value != null)
                                ws.Cells[i + 2, j + 1] = dgvSinhVien.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    wb.SaveAs(s.FileName); wb.Close(); app.Quit();
                    MessageBox.Show("Xuất Excel thành công!");
                    System.Diagnostics.Process.Start(s.FileName);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void quảnLýĐiểmToolStripMenuItem_Click(object sender, EventArgs e) { Form3 f = new Form3(); this.Hide(); f.ShowDialog(); this.Show(); }
        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e) { Form2 f = new Form2(); this.Hide(); f.ShowDialog(); this.Show(); }
    }
}