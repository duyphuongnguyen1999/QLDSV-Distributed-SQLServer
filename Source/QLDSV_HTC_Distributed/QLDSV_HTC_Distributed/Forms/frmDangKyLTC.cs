using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC {
    public partial class frmDangKyLTC : Form {
        public frmDangKyLTC() {
            InitializeComponent();
            LoadComboBox();
        }

        private void InitializeComponent() {
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.cboNienKhoa = new System.Windows.Forms.ComboBox();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.dgvLopTinChi = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvLopTinChi).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();

            // groupBox1
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtMaLop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Size = new System.Drawing.Size(900, 120);
            this.groupBox1.Text = "Thông tin sinh viên";

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Text = "Mã sinh viên:";

            // txtMaSV
            this.txtMaSV.Location = new System.Drawing.Point(120, 32);
            this.txtMaSV.Size = new System.Drawing.Size(150, 22);
            this.txtMaSV.MaxLength = 10;

            // btnTimKiem
            this.btnTimKiem.Location = new System.Drawing.Point(290, 30);
            this.btnTimKiem.Size = new System.Drawing.Size(100, 26);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Text = "Họ tên:";

            // txtHoTen
            this.txtHoTen.Location = new System.Drawing.Point(120, 67);
            this.txtHoTen.Size = new System.Drawing.Size(300, 22);
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.BackColor = System.Drawing.SystemColors.Control;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 70);
            this.label3.Text = "Mã lớp:";

            // txtMaLop
            this.txtMaLop.Location = new System.Drawing.Point(520, 67);
            this.txtMaLop.Size = new System.Drawing.Size(150, 22);
            this.txtMaLop.ReadOnly = true;
            this.txtMaLop.BackColor = System.Drawing.SystemColors.Control;

            // groupBox2
            this.groupBox2.Controls.Add(this.dgvLopTinChi);
            this.groupBox2.Controls.Add(this.cboHocKy);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboNienKhoa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(20, 160);
            this.groupBox2.Size = new System.Drawing.Size(900, 380);
            this.groupBox2.Text = "Danh sách lớp tín chỉ";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 35);
            this.label4.Text = "Niên khóa:";

            // cboNienKhoa
            this.cboNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNienKhoa.FormattingEnabled = true;
            this.cboNienKhoa.Location = new System.Drawing.Point(100, 32);
            this.cboNienKhoa.Size = new System.Drawing.Size(100, 22);
            this.cboNienKhoa.SelectedIndex = -1;
            this.cboNienKhoa.SelectedIndexChanged += new System.EventHandler(this.cboNienKhoa_SelectedIndexChanged);

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 35);
            this.label5.Text = "Học kỳ:";

            // cboHocKy
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(290, 32);
            this.cboHocKy.Size = new System.Drawing.Size(60, 22);
            this.cboHocKy.SelectedIndex = -1;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);

            // dgvLopTinChi
            this.dgvLopTinChi.AllowUserToAddRows = false;
            this.dgvLopTinChi.AllowUserToDeleteRows = false;
            this.dgvLopTinChi.Location = new System.Drawing.Point(20, 70);
            this.dgvLopTinChi.Size = new System.Drawing.Size(860, 290);
            this.dgvLopTinChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopTinChi.MultiSelect = false;
            this.dgvLopTinChi.ReadOnly = true;

            // btnDangKy
            this.btnDangKy.Location = new System.Drawing.Point(350, 560);
            this.btnDangKy.Size = new System.Drawing.Size(100, 35);
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(470, 560);
            this.btnThoat.Size = new System.Drawing.Size(100, 35);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmDangKyLTC
            this.ClientSize = new System.Drawing.Size(940, 620);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDangKyLTC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký lớp tín chỉ";
            ((System.ComponentModel.ISupportInitialize)this.dgvLopTinChi).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e) {
            string selectedHocKy = cboHocKy.SelectedItem?.ToString();
            string selectedNienKhoa = cboNienKhoa.SelectedItem?.ToString();
            if (dtLopTinChi == null)
                return;
            dtLopTinChi.DefaultView.RowFilter = "1=1 ";

            if (!string.IsNullOrEmpty(selectedHocKy)) {
                dtLopTinChi.DefaultView.RowFilter += $" AND HOCKY = '{selectedHocKy}'";
            }
            if (!string.IsNullOrEmpty(selectedNienKhoa)) {
                dtLopTinChi.DefaultView.RowFilter += $" AND NIENKHOA = '{selectedNienKhoa}'";
            }
        }

        private void cboNienKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            string selectedHocKy = cboHocKy.SelectedItem?.ToString();
            string selectedNienKhoa = cboNienKhoa.SelectedItem?.ToString();
            if (dtLopTinChi == null)
                return;
            dtLopTinChi.DefaultView.RowFilter = "1=1 ";

            if (!string.IsNullOrEmpty(selectedHocKy)) {
                dtLopTinChi.DefaultView.RowFilter += $" AND HOCKY = '{selectedHocKy}'";
            }
            if (!string.IsNullOrEmpty(selectedNienKhoa)) {
                dtLopTinChi.DefaultView.RowFilter += $" AND NIENKHOA = '{selectedNienKhoa}'";
            }
        }

        private void LoadComboBox() {
            // Load Niên khóa
            cboNienKhoa.Items.Clear();
            for (int year = 2015; year <= DateTime.Now.Year + 1; year++) {
                cboNienKhoa.Items.Add($"{year}-{year + 1}");
            }
            cboNienKhoa.SelectedIndex = -1;
            // Load Học kỳ
            cboHocKy.Items.Clear();
            cboHocKy.Items.Add("1");
            cboHocKy.Items.Add("2");
            cboHocKy.Items.Add("3");
            cboHocKy.Items.Add("4");
            cboHocKy.SelectedIndex = -1;
        }

        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.ComboBox cboNienKhoa;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.DataGridView dgvLopTinChi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private void btnTimKiem_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text)) {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo");
                return;
            }

            string query = @"SELECT 
                                sv.MASV, 
                                sv.HO + ' ' + sv.TEN AS HOTEN, 
                                sv.MALOP, 
                                l.MAKHOA
                            FROM SINHVIEN sv
                            JOIN 
                                LOP l ON sv.MALOP = l.MALOP
                            WHERE 
                                sv.MASV = @MaSV AND sv.DANGHIHOC = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@MaSV", txtMaSV.Text.Trim())
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0) {
                txtHoTen.Text = dt.Rows[0]["HOTEN"].ToString();
                txtMaLop.Text = dt.Rows[0]["MALOP"].ToString().Trim();
                LoadLopTinChi();
            } else {
                MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo");
                txtHoTen.Clear();
                txtMaLop.Clear();
            }
        }

        private DataTable dtLopTinChi;

        private void LoadLopTinChi() {
            try {
                string query =
                    "SELECT " +
                    "    ltc.MALTC, " +
                    "    ltc.MAMH, " +
                    "    ltc.NIENKHOA, " +
                    "    ltc.HOCKY, " +
                    "    ltc.NHOM, " +
                    "    mh.TENMH, " +
                    "    gv.HO + ' ' + gv.TEN AS HOTENGV, " +
                    "    ltc.SOSVTOITHIEU, " +
                    "    ISNULL(dk.SOSV_DADANGKY, 0) AS SOSV_DADANGKY " +
                    "FROM LOPTINCHI ltc " +
                    "JOIN MONHOC   mh ON ltc.MAMH = mh.MAMH " +
                    "JOIN GIANGVIEN gv ON ltc.MAGV = gv.MAGV " +
                    // Đếm số SV ĐÃ ĐĂNG KÝ (không bị HUYDANGKY)
                    "LEFT JOIN ( " +
                    "    SELECT MALTC, COUNT(*) AS SOSV_DADANGKY " +
                    "    FROM DANGKY " +
                    "    WHERE HUYDANGKY = 0 " +
                    "    GROUP BY MALTC " +
                    ") dk ON dk.MALTC = ltc.MALTC " +
                    "WHERE " +
                    //"   {KHOA} " +
                    //"   AND " +
                    "   ltc.HUYLOP = 0 " +
                    "ORDER BY ltc.NIENKHOA DESC, ltc.HOCKY, mh.TENMH, ltc.NHOM;";

                //SqlParameter[] parameters = {
                //    new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
                //};
                //string role = (DatabaseConnection.UserRole ?? "").Trim().ToUpperInvariant();
                //if (role == "PGV") {
                //    // PGV xem tất cả khoa
                //    query = query.Replace("{KHOA}", "1 = 1");
                //    dtLopTinChi = DatabaseConnection.ExecuteQuery(query);
                //} else {
                //    // Cán bộ khoa chỉ xem theo khoa hiện tại
                //    query = query.Replace("{KHOA}", "ltc.MAKHOA = @MaKhoa");
                //    dtLopTinChi = DatabaseConnection.ExecuteQuery(query, parameters);
                //}

                dtLopTinChi = DatabaseConnection.ExecuteQuery(query);
                dgvLopTinChi.DataSource = dtLopTinChi;

                if (dgvLopTinChi.Columns.Count > 0) {
                    dgvLopTinChi.Columns["MALTC"].HeaderText = "Mã LTC";
                    dgvLopTinChi.Columns["MALTC"].Width = 60;

                    dgvLopTinChi.Columns["MAMH"].HeaderText = "Mã MH";
                    dgvLopTinChi.Columns["MAMH"].Width = 60;
                    dgvLopTinChi.Columns["MAMH"].Visible = false;

                    dgvLopTinChi.Columns["TENMH"].HeaderText = "Tên môn học";
                    dgvLopTinChi.Columns["TENMH"].Width = 240;

                    dgvLopTinChi.Columns["NHOM"].HeaderText = "Nhóm";
                    dgvLopTinChi.Columns["NHOM"].Width = 60;

                    dgvLopTinChi.Columns["HOTENGV"].HeaderText = "Giảng viên";
                    dgvLopTinChi.Columns["HOTENGV"].Width = 150;

                    dgvLopTinChi.Columns["SOSVTOITHIEU"].HeaderText = "SV tối thiểu";
                    dgvLopTinChi.Columns["SOSVTOITHIEU"].Width = 80;

                    dgvLopTinChi.Columns["SOSV_DADANGKY"].HeaderText = "SV đã đăng ký";
                    dgvLopTinChi.Columns["SOSV_DADANGKY"].Width = 90;

                    dgvLopTinChi.Columns["NIENKHOA"].HeaderText = "Niên khóa";
                    dgvLopTinChi.Columns["NIENKHOA"].Width = 80;
                    //dgvLopTinChi.Columns["NIENKHOA"].Visible = false;

                    dgvLopTinChi.Columns["HOCKY"].HeaderText = "Học kỳ";
                    dgvLopTinChi.Columns["HOCKY"].Width = 60;
                    //dgvLopTinChi.Columns["HOCKY"].Visible = false;
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi load lớp tín chỉ: " + ex.Message,
                                "DB Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text)) {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo");
                return;
            }

            if (dgvLopTinChi.CurrentRow == null) {
                MessageBox.Show("Vui lòng chọn lớp tín chỉ cần đăng ký!", "Thông báo");
                return;
            }

            int maLTC = Convert.ToInt32(dgvLopTinChi.CurrentRow.Cells["MALTC"].Value);
            string maSV = txtMaSV.Text.Trim();

            SqlParameter[] parameters =
            {
                new SqlParameter("@MALTC", maLTC),
                new SqlParameter("@MASV", maSV)
            };

            string sql = @"
                -- Kiểm tra lớp tín chỉ còn tồn tại và chưa bị hủy
                IF NOT EXISTS (
                    SELECT 1 
                    FROM LOPTINCHI 
                    WHERE MALTC = @MALTC AND HUYLOP = 0
                )
                BEGIN
                    SELECT CAST(0 AS INT) AS Result, 
                           N'Lớp tín chỉ không tồn tại hoặc đã bị hủy!' AS Message;
                    RETURN;
                END

                -- Đã đăng ký và chưa hủy
                IF EXISTS (
                    SELECT 1 
                    FROM DANGKY 
                    WHERE MALTC = @MALTC AND MASV = @MASV AND HUYDANGKY = 0
                )
                BEGIN
                    SELECT CAST(0 AS INT) AS Result, 
                           N'Sinh viên đã đăng ký lớp tín chỉ này rồi!' AS Message;
                END
                ELSE
                BEGIN
                    -- Từng đăng ký nhưng đã hủy -> mở lại
                    IF EXISTS (
                        SELECT 1 
                        FROM DANGKY 
                        WHERE MALTC = @MALTC AND MASV = @MASV AND HUYDANGKY = 1
                    )
                    BEGIN
                        UPDATE DANGKY
                        SET HUYDANGKY = 0
                        WHERE MALTC = @MALTC AND MASV = @MASV;

                        SELECT CAST(1 AS INT) AS Result, 
                               N'Đăng ký lại lớp tín chỉ thành công!' AS Message;
                    END
                    ELSE
                    BEGIN
                        -- Chưa đăng ký lần nào -> thêm mới
                        INSERT INTO DANGKY (MALTC, MASV, DIEM_CC, DIEM_GK, DIEM_CK, HUYDANGKY)
                        VALUES (@MALTC, @MASV, 0, NULL, NULL, 0);

                        SELECT CAST(1 AS INT) AS Result, 
                               N'Đăng ký lớp tín chỉ thành công!' AS Message;
                    END
                END
            ";

            DataTable result = DatabaseConnection.ExecuteQuery(sql, parameters);

            if (result.Rows.Count > 0) {
                int resultCode = Convert.ToInt32(result.Rows[0]["Result"]);
                string message = result.Rows[0]["Message"].ToString();

                if (resultCode == 1) {
                    MessageBox.Show(message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopTinChi(); // refresh lại danh sách
                } else {
                    MessageBox.Show(message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnThoat_Click(object sender, EventArgs e) {
            this.Hide();
            frmMain mainForm = new frmMain();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}