using System;
using System.Windows.Forms;

namespace QLDSV_HTC {
    public partial class frmLogin : Form {
        public frmLogin() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.Text = "Vai trò:";

            // cboRole
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] { "PGV", "KHOA", "SV", "PKT" });
            this.cboRole.Location = new System.Drawing.Point(150, 27);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(200, 24);
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label3";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.Text = "Khoa:";

            // cboKhoa
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Items.AddRange(new object[] { "CNTT - Công nghệ thông tin", "VT - Viễn thông" });
            this.cboKhoa.Location = new System.Drawing.Point(150, 67);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(200, 24);

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label2";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.Text = "Mật khẩu:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(150, 107);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(80, 170);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 35);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(220, 170);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // frmLogin
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e) {
            // Only "KHOA" and "SV" role could select, either couldn't
            if (cboRole.SelectedItem != null) {
                string role = cboRole.SelectedItem.ToString();
                cboKhoa.Enabled = role == "KHOA" || role == "SV";

                if (role == "PGV" || role == "PKT") {
                    cboKhoa.Enabled = false;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (cboRole.SelectedItem == null) {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRole.Focus();
                return;
            }

            string role = cboRole.SelectedItem.ToString();

            if ((role == "KHOA") && cboKhoa.SelectedItem == null) {
                MessageBox.Show("Vui lòng chọn khoa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }

            // Save login information
            DatabaseConnection.UserRole = role;

            if ((role == "KHOA") && cboKhoa.SelectedItem != null) {
                // Get khoaText and padding 10 character (similar to database)
                string khoaText = cboKhoa.SelectedItem.ToString();
                string maKhoa = khoaText.StartsWith("CNTT") ? "CNTT" : "VT";
                DatabaseConnection.CurrentKhoa = maKhoa.PadRight(10);
            }

            // Open Main form
            this.Hide();
            frmMain mainForm = new frmMain();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}