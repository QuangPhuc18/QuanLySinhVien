using System;
using System.Data;
using System.Data.SqlClient; // Thư viện kết nối SQL
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien // Đổi theo tên namespace project của bạn
{
    public partial class frmLogin : Form
    {
        string strConnect = @"Data Source=.\SQLEXPRESS;Initial Catalog=DB_Customer;Integrated Security=True";

        public frmLogin()
        {
           
            InitializeComponent(); 
            SetPlaceholder(txtUser, "Username or Email");

            SetPlaceholderPassword(txtPass, "Password");
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    conn.Open();

                    string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE Email = @acc AND Password = @pass";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@acc", txtUser.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                        int count = (int)cmd.ExecuteScalar(); // Trả về số lượng tìm thấy

                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Hide();

                            Phuc.Form1 mainForm = new Phuc.Form1();
                            mainForm.ShowDialog();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_MouseEnter(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.CornflowerBlue; 
        }

        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.FromArgb(60, 169, 226); 
        }
        private void SetPlaceholder(TextBox txt, string placeholderText)
        {
            txt.Text = placeholderText;
            txt.ForeColor = System.Drawing.Color.Gray;

            txt.Enter += (s, e) =>
            {
                if (txt.Text == placeholderText)
                {
                    txt.Text = "";
                    txt.ForeColor = System.Drawing.Color.Black; 
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholderText;
                    txt.ForeColor = System.Drawing.Color.Gray; 
                }
            };
        }

        private void SetPlaceholderPassword(TextBox txt, string placeholderText)
        {
            txt.Text = placeholderText;
            txt.ForeColor = System.Drawing.Color.Gray;
            txt.UseSystemPasswordChar = false;

            txt.Enter += (s, e) =>
            {
                if (txt.Text == placeholderText)
                {
                    txt.Text = "";
                    txt.ForeColor = System.Drawing.Color.Black;
                    txt.UseSystemPasswordChar = true;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholderText;
                    txt.ForeColor = System.Drawing.Color.Gray;
                    txt.UseSystemPasswordChar = false; // Tắt chế độ mật khẩu để hiện chữ hướng dẫn
                }
            };
        }
    }
}