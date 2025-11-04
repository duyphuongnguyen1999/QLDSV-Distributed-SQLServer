using System;
using System.Data;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            LoadComboKhoa();
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.Text = "Tên đăng nhập:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(150, 27);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 22);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.Text = "Mật khẩu:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(150, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.UseSystemPasswordChar = true;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.Text = "Vai trò:";

            // cboRole
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] { "PGV", "KHOA", "SV", "PKT" });
            this.cboRole.Location = new System.Drawing.Point(150, 107);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(200, 24);
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.Text = "Khoa:";

            // cboKhoa
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(150, 147);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(200, 24);

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(80, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 35);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(220, 200);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // frmLogin
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private void LoadComboKhoa()
        {
            cboKhoa.Items.Add("CNTT - Công nghệ thông tin");
            cboKhoa.Items.Add("VT - Viễn thông");
            cboKhoa.SelectedIndex = 0;
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // PGV có thể chọn khoa, các role khác không
            if (cboRole.SelectedItem != null)
            {
                string role = cboRole.SelectedItem.ToString();
                cboKhoa.Enabled = (role == "PGV" || role == "KHOA");

                if (role == "PKT" || role == "SV")
                {
                    cboKhoa.Enabled = false;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Đơn giản hóa: không kiểm tra username/password thực tế
            // Chỉ kiểm tra các trường đã điền đầy đủ

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (cboRole.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRole.Focus();
                return;
            }

            string role = cboRole.SelectedItem.ToString();

            if ((role == "PGV" || role == "KHOA") && cboKhoa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khoa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }

            // Lưu thông tin đăng nhập
            DatabaseConnection.UserRole = role;

            if ((role == "PGV" || role == "KHOA") && cboKhoa.SelectedItem != null)
            {
                string khoaText = cboKhoa.SelectedItem.ToString();
                // Lấy mã khoa và pad với space để = 10 ký tự (giống database)
                string maKhoa = khoaText.StartsWith("CNTT") ? "CNTT" : "VT";
                DatabaseConnection.UserMaKhoa = maKhoa.PadRight(10);
                DatabaseConnection.CurrentKhoa = DatabaseConnection.UserMaKhoa;
            }
            else
            {
                // Mặc định là CNTT cho SV và PKT
                DatabaseConnection.UserMaKhoa = "CNTT      ";
                DatabaseConnection.CurrentKhoa = "CNTT      ";
            }

            // Mở form chính
            this.Hide();
            frmMain mainForm = new frmMain();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}