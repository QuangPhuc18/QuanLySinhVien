using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phuc
{
    public partial class Form2 : Form
    {
        // 1. CHUỖI KẾT NỐI
        string connStr = "Data Source=QUANGPHUC\\SQLEXPRESS;Database=DB_Customer;Trusted_Connection=True";

        public Form2()
        {
            InitializeComponent();

            // GẮN SỰ KIỆN
            this.Load += Form2_Load;
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
            btThem.Click += btThem_Click;
            btSua.Click += btSua_Click;
            btXoa.Click += btXoa_Click;

            // Gắn sự kiện chặn nhập chữ cho ô Số Tín Chỉ
            tbSoTinChi.KeyPress += tbSoTinChi_KeyPress;

            if (btLamMoi != null) btLamMoi.Click += btLamMoi_Click;
        }

        // --- SỰ KIỆN MỚI: CHỈ CHO NHẬP SỐ VÀO Ô TÍN CHỈ ---
        private void tbSoTinChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu ký tự gõ vào KHÔNG phải là số VÀ KHÔNG phải phím xóa (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn phím đó lại
            }
        }

        // --- LOAD FORM ---
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
            // Cấu hình bảng
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.AllowUserToAddRows = false;
        }

        // --- TẢI DỮ LIỆU ---
        void LoadData()
        {
            dgvMonHoc.DataSource = null;
            dgvMonHoc.Columns.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MonHoc", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMonHoc.DataSource = dt;

                    // Đặt tên cột tiếng Việt
                    dgvMonHoc.Columns[0].HeaderText = "Mã Môn";
                    dgvMonHoc.Columns[1].HeaderText = "Tên Môn";
                    dgvMonHoc.Columns[2].HeaderText = "Số Tín Chỉ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        // --- NÚT THÊM (CÓ KIỂM TRA SỐ) ---
        private void btThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(tbMaMon.Text) || string.IsNullOrEmpty(tbTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra Số Tín Chỉ phải là số (Yêu cầu của bạn)
            int tinChi = 0;
            if (!int.TryParse(tbSoTinChi.Text, out tinChi))
            {
                MessageBox.Show("Số tín chỉ phải là số! Vui lòng nhập lại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSoTinChi.Focus(); // Đưa con trỏ về ô nhập lại cho nhanh
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO MonHoc (MaMon, TenMon, SoTinChi) VALUES (@ma, @ten, @stc)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", tbMaMon.Text);
                    cmd.Parameters.AddWithValue("@ten", tbTenMon.Text);
                    cmd.Parameters.AddWithValue("@stc", tinChi);

                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Thêm môn học thành công!");
                    ResetForm(); // Thêm xong xóa trắng để nhập tiếp
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        MessageBox.Show("Mã môn này ĐÃ TỒN TẠI! Vui lòng nhập mã khác.");
                    else
                        MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
        }

        // --- NÚT SỬA ---
        private void btSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMaMon.Text)) return;

            // Kiểm tra số tín chỉ khi sửa luôn cho chắc
            int tinChi = 0;
            if (!int.TryParse(tbSoTinChi.Text, out tinChi))
            {
                MessageBox.Show("Số tín chỉ phải là số! Vui lòng nhập lại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE MonHoc SET TenMon=@ten, SoTinChi=@stc WHERE MaMon=@ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", tbMaMon.Text); // Mã cũ (đang bị khóa)
                    cmd.Parameters.AddWithValue("@ten", tbTenMon.Text);
                    cmd.Parameters.AddWithValue("@stc", tinChi);

                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Cập nhật thông tin môn học thành công!");
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        // --- NÚT XÓA ---
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.CurrentRow == null) return;
            string maXoa = dgvMonHoc.CurrentRow.Cells[0].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa môn {maXoa}?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM MonHoc WHERE MaMon=@ma", conn);
                        cmd.Parameters.AddWithValue("@ma", maXoa);

                        cmd.ExecuteNonQuery();
                        LoadData();
                        ResetForm();
                        MessageBox.Show("Đã xóa!");
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
                }
            }
        }

        // --- SỰ KIỆN CLICK VÀO LƯỚI ---
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMonHoc.Rows[e.RowIndex];
            tbMaMon.Text = row.Cells[0].Value.ToString();
            tbTenMon.Text = row.Cells[1].Value.ToString();
            tbSoTinChi.Text = row.Cells[2].Value.ToString();

            // Khóa Mã Môn khi đang chọn sửa/xóa
            tbMaMon.Enabled = false;
            btThem.Enabled = false;
        }

        // --- NÚT LÀM MỚI ---
        private void btLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        void ResetForm()
        {
            tbMaMon.Text = "";
            tbTenMon.Text = "";
            tbSoTinChi.Text = "";
            tbMaMon.Enabled = true;
            btThem.Enabled = true;
            tbMaMon.Focus();
        }
    }
}