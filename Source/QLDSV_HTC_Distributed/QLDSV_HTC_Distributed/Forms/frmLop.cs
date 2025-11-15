using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC {
    public partial class frmLop : Form {
        private DataTable dtLop;
        private bool isAdding = false;

        public frmLop() {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent() {
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtKhoaHoc = new System.Windows.Forms.TextBox();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.cboKhoaFilter = new System.Windows.Forms.ComboBox();
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvLop).BeginInit();
            this.SuspendLayout();

            // labels
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Text = "Mã lớp:";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Text = "Tên lớp:";

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Text = "Khóa học:";

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 30);
            this.label4.Text = "Khoa: " + DatabaseConnection.CurrentKhoa;

            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 110);
            this.label5.Text = "Lọc theo Khoa: ";
            this.label5.Visible = false;

            // textboxes
            this.txtMaLop.Location = new System.Drawing.Point(120, 27);
            this.txtMaLop.Size = new System.Drawing.Size(150, 22);
            this.txtMaLop.MaxLength = 10;
            this.txtMaLop.ReadOnly = true;

            this.txtTenLop.Location = new System.Drawing.Point(120, 67);
            this.txtTenLop.Size = new System.Drawing.Size(300, 22);
            this.txtTenLop.MaxLength = 50;
            this.txtTenLop.ReadOnly = true;

            this.txtKhoaHoc.Location = new System.Drawing.Point(120, 107);
            this.txtKhoaHoc.Size = new System.Drawing.Size(150, 22);
            this.txtKhoaHoc.MaxLength = 9;
            this.txtKhoaHoc.ReadOnly = true;

            this.txtKhoa.Location = new System.Drawing.Point(390, 27);
            this.txtKhoa.Size = new System.Drawing.Size(150, 22);
            this.txtKhoa.MaxLength = 9;
            this.txtKhoa.ReadOnly = true;

            // combobox
            this.cboKhoaFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaFilter.FormattingEnabled = true;
            this.cboKhoaFilter.Items.AddRange(new object[] { "CNTT", "VT", "Tất cả" });
            this.cboKhoaFilter.Location = new System.Drawing.Point(450, 107);
            this.cboKhoaFilter.Size = new System.Drawing.Size(150, 22);
            this.cboKhoaFilter.MaxLength = 9;
            this.cboKhoaFilter.Enabled = false;
            this.cboKhoaFilter.SelectedIndexChanged += new System.EventHandler(this.cboKhoaFilter_SelectedIndexChanged);
            this.cboKhoaFilter.SelectedIndex = -1;
            this.cboKhoaFilter.Visible = false;

            // datagridview
            this.dgvLop.AllowUserToAddRows = false;
            this.dgvLop.AllowUserToDeleteRows = false;
            this.dgvLop.Location = new System.Drawing.Point(30, 200);
            this.dgvLop.Size = new System.Drawing.Size(740, 300);
            this.dgvLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLop.MultiSelect = false;
            this.dgvLop.ReadOnly = true;
            this.dgvLop.SelectionChanged += new System.EventHandler(this.dgvLop_SelectionChanged);

            // buttons
            this.btnThem.Location = new System.Drawing.Point(30, 150);
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnXoa.Location = new System.Drawing.Point(130, 150);
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnSua.Location = new System.Drawing.Point(230, 150);
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnHuy.Location = new System.Drawing.Point(330, 150);
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnHuy.Enabled = false;

            this.btnGhi.Location = new System.Drawing.Point(430, 150);
            this.btnGhi.Size = new System.Drawing.Size(80, 30);
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Enabled = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);

            this.btnThoat.Location = new System.Drawing.Point(530, 150);
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmLop
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.cboKhoaFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKhoa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvLop);
            this.Controls.Add(this.txtKhoaHoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.label1);


            this.Name = "frmLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý lớp";
            ((System.ComponentModel.ISupportInitialize)this.dgvLop).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtKhoaHoc;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.ComboBox cboKhoaFilter;
        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private bool _suppressLoad = false;

        private void LoadData() {
            if (_suppressLoad) { return; }

            string role = (DatabaseConnection.UserRole ?? "").Trim().ToUpperInvariant();
            string currMaKhoa = (DatabaseConnection.CurrentKhoa ?? "").Trim().ToUpperInvariant();

            string maKhoaCbo = "";
            if (cboKhoaFilter.SelectedItem is string str)
                maKhoaCbo = str.Trim().ToUpperInvariant();
            else
                maKhoaCbo = (cboKhoaFilter.Text ?? "").Trim().ToUpperInvariant();

            // Enable cboKhoaFilter if role = "PGV"
            label5.Visible = role == "PGV";
            cboKhoaFilter.Visible = role == "PGV";
            cboKhoaFilter.Enabled = role == "PGV";

            string sqlBase = @"
                SELECT 
                    RTRIM(MALOP)   AS MALOP, 
                    TENLOP, 
                    RTRIM(KHOAHOC) AS KHOAHOC,
                    RTRIM(MAKHOA)  AS MAKHOA
                FROM dbo.LOP
                {WHERE}
                ORDER BY MALOP;";

            DataTable result;

            if (role == "PGV") {
                if (string.IsNullOrEmpty(maKhoaCbo) || maKhoaCbo == "TẤT CẢ") {
                    // Get data from both size ("CNTT" + "VT")
                    string sqlAll = sqlBase.Replace("{WHERE}", "");
                    result = DatabaseConnection.ExecuteQuery(sqlAll);

                } else {
                    // PGV + đã chọn CNTT/VT -> lọc theo khoa, route đúng site
                    string sqlOne = sqlBase.Replace("{WHERE}", "WHERE RTRIM(MAKHOA) = @MaKhoa");
                    var p = new SqlParameter("@MaKhoa", SqlDbType.NVarChar, 10) { Value = maKhoaCbo };
                    result = DatabaseConnection.ExecuteQuery(sqlOne, new[] { p }, maKhoaCbo);
                }
            } else {
                // Role khoa (KHÁC PGV): bỏ qua combo, dùng CurrentKhoa
                if (string.IsNullOrEmpty(currMaKhoa)) {
                    MessageBox.Show("Chưa xác định khoa cho tài khoản hiện tại.", "Thông báo");
                    dgvLop.DataSource = null;
                    this.Text = "Quản lý lớp - (0 dòng)";
                    return;
                }

                string sqlOne = sqlBase.Replace("{WHERE}", "WHERE RTRIM(MAKHOA) = @MaKhoa");
                var p = new SqlParameter("@MaKhoa", SqlDbType.NVarChar, 10) { Value = currMaKhoa };
                result = DatabaseConnection.ExecuteQuery(sqlOne, new[] { p }, currMaKhoa);
            }

            dtLop = result ?? new DataTable();

            dgvLop.AutoGenerateColumns = true;
            dgvLop.DataSource = dtLop;
            dgvLop.Refresh();

            if (dgvLop.Columns.Contains("MALOP")) { dgvLop.Columns["MALOP"].HeaderText = "Mã lớp"; dgvLop.Columns["MALOP"].Width = 150; }
            if (dgvLop.Columns.Contains("TENLOP")) { dgvLop.Columns["TENLOP"].HeaderText = "Tên lớp"; dgvLop.Columns["TENLOP"].Width = 280; }
            if (dgvLop.Columns.Contains("KHOAHOC")) { dgvLop.Columns["KHOAHOC"].HeaderText = "Khóa học"; dgvLop.Columns["KHOAHOC"].Width = 150; }
            if (dgvLop.Columns.Contains("MAKHOA")) { dgvLop.Columns["MAKHOA"].HeaderText = "Khoa"; dgvLop.Columns["MAKHOA"].Width = 90; }

            if (dgvLop.Rows.Count > 0)
                dgvLop.Rows[0].Selected = true;
        }


        private void cboKhoaFilter_SelectedIndexChanged(object sender, EventArgs e) {
            if (DatabaseConnection.UserRole.Trim().ToUpperInvariant() == "PGV")
                LoadData();
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e) {
            if (!isAdding && dgvLop.CurrentRow != null) {
                txtMaLop.Text = dgvLop.CurrentRow.Cells["MALOP"].Value?.ToString().Trim();
                txtTenLop.Text = dgvLop.CurrentRow.Cells["TENLOP"].Value?.ToString();
                txtKhoaHoc.Text = dgvLop.CurrentRow.Cells["KHOAHOC"].Value?.ToString().Trim();
                txtKhoa.Text = dgvLop.CurrentRow.Cells["MAKHOA"].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e) {
            isAdding = true;
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtKhoaHoc.Clear();

            txtMaLop.ReadOnly = false;
            txtTenLop.ReadOnly = false;
            txtKhoaHoc.ReadOnly = false;

            if (DatabaseConnection.UserRole == "PGV") {
                cboKhoaFilter.Enabled = true;
            } else { // UserRole = "KHOA"
                cboKhoaFilter.Text = DatabaseConnection.CurrentKhoa;
            }

            txtMaLop.Focus();
            btnHuy.Enabled = true;
            btnGhi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e) {
            if (dgvLop.CurrentRow == null) {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string maLop = txtMaLop.Text.Trim();
                string query = @"DELETE FROM dbo.LOP 
                                 WHERE MALOP = @MaLop";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaLop", maLop)
                };

                if (DatabaseConnection.ExecuteNonQuery(query, parameters)) {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e) {
            txtTenLop.ReadOnly = false;
            txtKhoaHoc.ReadOnly = false;
            txtTenLop.Focus();

            isAdding = false;
            btnHuy.Enabled = true;
            btnGhi.Enabled = true;
        }

        private void btnGhi_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text)) {
                MessageBox.Show("Vui lòng nhập mã lớp!", "Thông báo");
                txtMaLop.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text)) {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo");
                txtTenLop.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKhoaHoc.Text)) {
                MessageBox.Show("Vui lòng nhập khóa học!", "Thông báo");
                txtKhoaHoc.Focus();
                return;
            }

            if (isAdding) {
                // Kiểm tra trùng mã lớp
                try {
                    bool exists = DatabaseConnection.CheckForExistence("LOP", "MALOP", txtMaLop.Text.Trim());
                    if (exists) {
                        MessageBox.Show("Mã lớp đã tồn tại. Vui lòng nhập mã lớp khác.", "Thông báo");
                        txtMaLop.Focus();
                        return;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kiểm tra dữ liệu: " + ex.Message, "Thông báo");
                    return;
                }

            }

            string query;
            if (isAdding) {
                query = "INSERT INTO dbo.LOP " +
                            "(MALOP, TENLOP, KHOAHOC, MAKHOA) " +
                        "VALUES " +
                            "(@MaLop, @TenLop, @KhoaHoc, @MaKhoa)";
            } else {
                query = "UPDATE dbo.LOP " +
                        "SET " +
                            "TENLOP = @TenLop, " +
                            "KHOAHOC = @KhoaHoc " +
                        "WHERE MALOP = @MaLop";
            }

            SqlParameter[] parameters = {
                new SqlParameter("@MaLop", txtMaLop.Text.Trim()),
                new SqlParameter("@TenLop", txtTenLop.Text.Trim()),
                new SqlParameter("@KhoaHoc", txtKhoaHoc.Text.Trim()),
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };

            if (DatabaseConnection.ExecuteNonQuery(query, parameters)) {
                MessageBox.Show("Lưu thành công!");
                isAdding = false;
                btnGhi.Enabled = false;
                LoadData();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) {
            isAdding = false;
            btnHuy.Enabled = false;
            btnGhi.Enabled = false;
            LoadData();

            if (dgvLop.Rows.Count > 0)
                dgvLop.Rows[0].Selected = true;
        }

        private void btnThoat_Click(object sender, EventArgs e) {
            this.Hide();
            frmMain frm = new frmMain();
            frm.ShowDialog();
            this.Close();
        }
    }
}