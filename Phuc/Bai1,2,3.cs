using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phuc
{
    public partial class Form1 : Form
    {
        string connStr = "Data Source=QUANGPHUC\\SQLEXPRESS;Database=DB_Customer;Trusted_Connection=True";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            dgvSinhVien.RowEnter += dgvSinhVien_RowEnter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            btn_KhuVuc.Items.Clear();
            btn_KhuVuc.Items.Add("Bắc");
            btn_KhuVuc.Items.Add("Trung");
            btn_KhuVuc.Items.Add("Nam");
            btn_KhuVuc.Items.Add("Tây Nguyên");
            btn_GioiTinh.Items.Add("Nam");
            btn_GioiTinh.Items.Add("Nữ");
            btn_GioiTinh.SelectedIndex = 0;
            btn_KhuVuc.SelectedIndex = 0;

            btn_date.Format = DateTimePickerFormat.Custom;
            btn_date.CustomFormat = "dd/MM/yyyy";

            dgvSinhVien.Rows.Clear();
        }

        private void LoadData()
        {
            dgvSinhVien.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SinhVien2", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string khuVuc = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    string ngaySinh = reader.IsDBNull(3) ? "" : reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    string gioiTinh = reader.IsDBNull(4) ? "" : reader.GetString(4);

                    dgvSinhVien.Rows.Add(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        khuVuc,
                        ngaySinh,
                        gioiTinh

                    );
                }
            }
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO SinhVien2 VALUES (@id,@name,@khuvuc,@ngaysinh,@gioitinh)", conn);

                cmd.Parameters.AddWithValue("@id", int.Parse(tbId.Text));
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@khuvuc", btn_KhuVuc.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", btn_date.Value);
                cmd.Parameters.AddWithValue("@gioitinh", btn_GioiTinh.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM SinhVien2 WHERE Id = @newId AND Id <> @oldId", conn);

                int oldId = int.Parse(dgvSinhVien.CurrentRow.Cells[0].Value.ToString());
                int newId = int.Parse(tbId.Text);

                checkCmd.Parameters.AddWithValue("@newId", newId);
                checkCmd.Parameters.AddWithValue("@oldId", oldId);

                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("ID đã tồn tại, không được trùng!");
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    "UPDATE SinhVien2 SET Id=@newId, Name=@name, KhuVuc=@khuvuc, NgaySinh=@ngaysinh, GioiTinh=@gioitinh WHERE Id=@oldId", conn);

                cmd.Parameters.AddWithValue("@newId", newId);
                cmd.Parameters.AddWithValue("@oldId", oldId);
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@khuvuc", btn_KhuVuc.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", btn_date.Value);
                cmd.Parameters.AddWithValue("@gioitinh", btn_GioiTinh.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM SinhVien2 WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(tbId.Text));
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        private void dgvSinhVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || dgvSinhVien.Rows.Count == 0) return;

            tbId.Text = dgvSinhVien.Rows[e.RowIndex].Cells[0].Value?.ToString();
            tbName.Text = dgvSinhVien.Rows[e.RowIndex].Cells[1].Value?.ToString();
            btn_KhuVuc.Text = dgvSinhVien.Rows[e.RowIndex].Cells[2].Value?.ToString();

            if (DateTime.TryParse(dgvSinhVien.Rows[e.RowIndex].Cells[3].Value?.ToString(), out DateTime d))
                btn_date.Value = d;
        }
    }
}
