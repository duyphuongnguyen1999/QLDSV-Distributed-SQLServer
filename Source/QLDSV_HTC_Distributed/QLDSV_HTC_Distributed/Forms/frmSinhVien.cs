using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC {
    public partial class frmSinhVien : Form {
        private DataTable dtSinhVien;
        private bool isAdding = false;

        public frmSinhVien() {
            InitializeComponent();
            LoadComboBox();
            LoadData();
        }

        private void InitializeComponent() {
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboPhai = new System.Windows.Forms.ComboBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvSinhVien).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // txtMaSV
            this.txtMaSV.Location = new System.Drawing.Point(120, 32);
            this.txtMaSV.MaxLength = 10;
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(180, 22);
            this.txtMaSV.TabIndex = 11;
            this.txtMaSV.ReadOnly = true;

            // txtHo
            this.txtHo.Location = new System.Drawing.Point(380, 32);
            this.txtHo.MaxLength = 50;
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(200, 22);
            this.txtHo.TabIndex = 9;
            this.txtHo.ReadOnly = true;

            // txtTen
            this.txtTen.Location = new System.Drawing.Point(650, 32);
            this.txtTen.MaxLength = 10;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(150, 22);
            this.txtTen.TabIndex = 7;
            this.txtTen.ReadOnly = true;

            // cboLop
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Location = new System.Drawing.Point(120, 72);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(180, 24);
            this.cboLop.TabIndex = 5;
            this.cboLop.Enabled = false;

            // cboPhai
            this.cboPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhai.FormattingEnabled = true;
            this.cboPhai.Location = new System.Drawing.Point(380, 72);
            this.cboPhai.Name = "cboPhai";
            this.cboPhai.Size = new System.Drawing.Size(80, 24);
            this.cboPhai.TabIndex = 3;
            this.cboPhai.Enabled = false;

            // dtpNgaySinh
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(560, 72);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(150, 22);
            this.dtpNgaySinh.TabIndex = 2;
            this.dtpNgaySinh.Enabled = false;

            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(120, 112);
            this.txtDiaChi.MaxLength = 100;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(500, 22);
            this.txtDiaChi.TabIndex = 0;
            this.txtDiaChi.ReadOnly = true;

            // dgvSinhVien
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AllowUserToDeleteRows = false;
            this.dgvSinhVien.ColumnHeadersHeight = 29;
            this.dgvSinhVien.Location = new System.Drawing.Point(20, 270);
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.RowHeadersWidth = 51;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(900, 280);
            this.dgvSinhVien.TabIndex = 5;
            this.dgvSinhVien.SelectionChanged += new System.EventHandler(this.dgvSinhVien_SelectionChanged);

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(140, 225);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(240, 225);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(340, 225);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnGhi
            this.btnGhi.Enabled = false;
            this.btnGhi.Location = new System.Drawing.Point(440, 225);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 30);
            this.btnGhi.TabIndex = 2;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);

            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(540, 225);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(640, 225);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // groupBox1
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpNgaySinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboPhai);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboLop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";

            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Phái:";

            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Địa chỉ:";

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngày sinh:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lớp:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(610, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tên:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Họ:";

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã sinh viên:";

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(350, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(87, 25);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "QUẢN LÝ SINH VIÊN";

            // frmSinhVien
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelTitle);
            this.Name = "frmSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý sinh viên";
            ((System.ComponentModel.ISupportInitialize)this.dgvSinhVien).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboPhai;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTitle;

        private void LoadComboBox() {
            string role = (DatabaseConnection.UserRole ?? "").Trim().ToUpperInvariant();

            // Load lớp vào combobox
            string query = "SELECT " +
                                "MALOP, TENLOP " +
                            "FROM LOP " +
                            "WHERE {KHOA} " +
                            "ORDER BY MALOP";
            SqlParameter[] parametersComboBox = {
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };
            if (role == "PGV") {
                // Xem tất cả các khoa
                query = query.Replace("{KHOA}", "1=1");
            } else {
                // Xem theo khoa hiện tại
                query = query.Replace("{KHOA}", "MAKHOA = @MaKhoa");
            }

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parametersComboBox);
            cboLop.DataSource = dt;
            cboLop.DisplayMember = "TENLOP";
            cboLop.ValueMember = "MALOP";

            // Load phái vào combobox
            cboPhai.Items.Clear();
            cboPhai.Items.Add(new { Text = "Nam", Value = 1 });
            cboPhai.Items.Add(new { Text = "Nữ", Value = 0 });
            cboPhai.DisplayMember = "Text";
            cboPhai.ValueMember = "Value";
        }

        private void LoadData() {
            string role = (DatabaseConnection.UserRole ?? "").Trim().ToUpperInvariant();

            string query = @"SELECT sv.MASV, sv.HO, sv.TEN, sv.MALOP, l.TENLOP, l.MAKHOA,
                                  sv.PHAI, sv.NGAYSINH, sv.DIACHI
                           FROM SINHVIEN sv
                           JOIN LOP l ON sv.MALOP = l.MALOP
                           WHERE {KHOA} AND sv.DANGHIHOC = 0
                           ORDER BY sv.MASV";

            SqlParameter[] parameters = {
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };
            if (role == "PGV") {
                // Xem tất cả các khoa
                query = query.Replace("{KHOA}", "1=1");
            } else {
                // Xem theo khoa hiện tại
                query = query.Replace("{KHOA}", "MAKHOA = @MaKhoa");
            }

            dtSinhVien = DatabaseConnection.ExecuteQuery(query, parameters);
            dgvSinhVien.DataSource = dtSinhVien;

            if (dgvSinhVien.Columns.Count > 0) {
                dgvSinhVien.Columns["MASV"].HeaderText = "Mã SV";
                dgvSinhVien.Columns["MASV"].Width = 100;
                dgvSinhVien.Columns["HO"].HeaderText = "Họ";
                dgvSinhVien.Columns["HO"].Width = 150;
                dgvSinhVien.Columns["TEN"].HeaderText = "Tên";
                dgvSinhVien.Columns["TEN"].Width = 80;
                dgvSinhVien.Columns["MALOP"].Visible = false;
                dgvSinhVien.Columns["TENLOP"].HeaderText = "Lớp";
                dgvSinhVien.Columns["TENLOP"].Width = 150;
                dgvSinhVien.Columns["MAKHOA"].Visible = false;
                dgvSinhVien.Columns["PHAI"].HeaderText = "Phái";
                dgvSinhVien.Columns["PHAI"].Width = 60;
                dgvSinhVien.Columns["PHAI"].Visible = false;
                if (!dtSinhVien.Columns.Contains("GIOITINH")) {
                    dtSinhVien.Columns.Add(
                        "GIOITINH",
                        typeof(string),
                        "IIF(PHAI = 1, 'Nam', 'Nữ')"
                    );
                }
                dgvSinhVien.Columns["GIOITINH"].HeaderText = "Giới tính";
                dgvSinhVien.Columns["GIOITINH"].Width = 80;
                dgvSinhVien.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
                dgvSinhVien.Columns["NGAYSINH"].Width = 100;
                dgvSinhVien.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgvSinhVien.Columns["DIACHI"].Width = 200;
            }
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e) {
            if (!isAdding && dgvSinhVien.CurrentRow != null) {
                txtMaSV.Text = dgvSinhVien.CurrentRow.Cells["MASV"].Value?.ToString().Trim();
                txtHo.Text = dgvSinhVien.CurrentRow.Cells["HO"].Value?.ToString();
                txtTen.Text = dgvSinhVien.CurrentRow.Cells["TEN"].Value?.ToString();
                cboLop.SelectedValue = dgvSinhVien.CurrentRow.Cells["MALOP"].Value?.ToString().Trim();
                cboPhai.SelectedIndex = Convert.ToBoolean(dgvSinhVien.CurrentRow.Cells["PHAI"].Value) ? 0 : 1;

                if (dgvSinhVien.CurrentRow.Cells["NGAYSINH"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(dgvSinhVien.CurrentRow.Cells["NGAYSINH"].Value);

                txtDiaChi.Text = dgvSinhVien.CurrentRow.Cells["DIACHI"].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e) {
            isAdding = true;
            txtMaSV.Clear();
            txtHo.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            cboPhai.SelectedIndex = -1;
            cboLop.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;

            txtMaSV.ReadOnly = false;
            txtMaSV.Focus();
            txtHo.ReadOnly = false;
            txtTen.ReadOnly = false;
            cboLop.Enabled = true;
            cboPhai.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.ReadOnly = false;

            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e) {
            if (dgvSinhVien.CurrentRow == null) {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string maSV = txtMaSV.Text.Trim();
                string query = "UPDATE SINHVIEN SET DANGHIHOC = 1 WHERE MASV = @MaSV";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaSV", maSV)
                };

                if (DatabaseConnection.ExecuteNonQuery(query, parameters)) {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e) {
            isAdding = false;
            if (dgvSinhVien.CurrentRow == null) {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo");
                return;
            }
            txtHo.ReadOnly = false;
            txtTen.ReadOnly = false;
            cboLop.Enabled = true;
            cboPhai.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.ReadOnly = false;
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnGhi_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text)) {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo");
                txtMaSV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHo.Text) || string.IsNullOrWhiteSpace(txtTen.Text)) {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!", "Thông báo");
                return;
            }

            if (cboLop.SelectedValue == null) {
                MessageBox.Show("Vui lòng chọn lớp!", "Thông báo");
                return;
            }

            string query;
            if (isAdding) {
                query = @"INSERT INTO SINHVIEN 
                            (MASV, HO, TEN, MALOP, PHAI, NGAYSINH, DIACHI, DANGHIHOC, PASSWORD)
                         VALUES 
                            (@MaSV, @Ho, @Ten, @MaLop, @Phai, @NgaySinh, @DiaChi, 0, '')";
            } else {
                query = @"UPDATE SINHVIEN
                         SET 
                            HO = @Ho, 
                            TEN = @Ten, 
                            MALOP = @MaLop, 
                            PHAI = @Phai, 
                            NGAYSINH = @NgaySinh, DIACHI = @DiaChi
                         WHERE MASV = @MaSV";
            }

            SqlParameter[] parameters = {
                new SqlParameter("@MaSV", txtMaSV.Text.Trim()),
                new SqlParameter("@Ho", txtHo.Text.Trim()),
                new SqlParameter("@Ten", txtTen.Text.Trim()),
                new SqlParameter("@MaLop", cboLop.SelectedValue.ToString()),
                new SqlParameter("@Phai", cboPhai.SelectedValue),
                new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                new SqlParameter("@DiaChi", txtDiaChi.Text.Trim())
            };

            if (DatabaseConnection.ExecuteNonQuery(query, parameters)) {
                MessageBox.Show("Lưu thành công!");
                isAdding = false;
                btnGhi.Enabled = false;
                btnHuy.Enabled = false;
                LoadData();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) {
            isAdding = false;
            txtMaSV.ReadOnly = true;
            txtHo.ReadOnly = true;
            txtTen.ReadOnly = true;
            cboLop.Enabled = false;
            cboPhai.Enabled = false;
            txtDiaChi.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e) {
            this.Hide();
            frmMain mainForm = new frmMain();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}