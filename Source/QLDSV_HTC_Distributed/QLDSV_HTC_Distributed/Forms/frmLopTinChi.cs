using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC {
    public partial class frmLopTinChi : Form {
        private DataTable dtLTC;
        private bool isAdding = false;
        private int selectedMALTC = -1;

        public frmLopTinChi() {
            InitializeComponent();
            LoadComboBoxes();
            LoadData();
        }

        private void InitializeComponent() {
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.txtHocKy = new System.Windows.Forms.TextBox();
            this.txtNhom = new System.Windows.Forms.TextBox();
            this.txtSoSVToiThieu = new System.Windows.Forms.TextBox();
            this.txtMonHoc = new System.Windows.Forms.TextBox();
            this.txtGiangVien = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.cboNienKhoa = new System.Windows.Forms.ComboBox();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.cboGiangVien = new System.Windows.Forms.ComboBox();
            this.dgvLopTinChi = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvLopTinChi).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(340, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 24);
            this.labelTitle.Text = "QUẢN LÝ LỚP TÍN CHỈ" + DatabaseConnection.CurrentKhoa.Trim();

            // groupBox1
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNienKhoa);
            this.groupBox1.Controls.Add(this.txtHocKy);
            this.groupBox1.Controls.Add(this.txtNhom);
            this.groupBox1.Controls.Add(this.txtMonHoc);
            this.groupBox1.Controls.Add(this.txtGiangVien);
            this.groupBox1.Controls.Add(this.txtSoSVToiThieu);
            this.groupBox1.Controls.Add(this.txtTrangThai);
            this.groupBox1.Location = new System.Drawing.Point(20, 50);
            this.groupBox1.Size = new System.Drawing.Size(545, 160);
            this.groupBox1.Text = "Thông tin lớp tín chỉ";

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Text = "Niên khóa:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 35);
            this.label2.Text = "Học kỳ:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Text = "Môn học:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 75);
            this.label4.Text = "Nhóm:";

            // label11
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(360, 35);
            this.label11.Text = "Trạng thái:";

            // txtTrangThai
            this.txtTrangThai.AutoSize = true;
            this.txtTrangThai.Location = new System.Drawing.Point(440, 32);
            this.txtTrangThai.Size = new System.Drawing.Size(90, 24);
            this.txtTrangThai.ReadOnly = true;

            // txtNienKhoa
            this.txtNienKhoa.Location = new System.Drawing.Point(100, 32);
            this.txtNienKhoa.MaxLength = 9;
            this.txtNienKhoa.Size = new System.Drawing.Size(80, 22);
            this.txtNienKhoa.ReadOnly = true;

            // txtHocKy
            this.txtHocKy.Location = new System.Drawing.Point(270, 32);
            this.txtHocKy.MaxLength = 1;
            this.txtHocKy.Size = new System.Drawing.Size(60, 22);
            this.txtHocKy.ReadOnly = true;

            // txtMonHoc
            this.txtMonHoc.Location = new System.Drawing.Point(100, 72);
            this.txtMonHoc.Size = new System.Drawing.Size(230, 22);
            this.txtMonHoc.ReadOnly = true;

            // txtNhom
            this.txtNhom.Location = new System.Drawing.Point(420, 72);
            this.txtNhom.MaxLength = 2;
            this.txtNhom.Size = new System.Drawing.Size(60, 22);
            this.txtNhom.ReadOnly = true;

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 115);
            this.label5.Text = "Giảng viên:";

            // txtGiangVien
            this.txtGiangVien.Location = new System.Drawing.Point(100, 112);
            this.txtGiangVien.Size = new System.Drawing.Size(230, 22);
            this.txtGiangVien.ReadOnly = true;

            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 115);
            this.label6.Text = "SV tối thiểu:";

            // txtSoSVToiThieu
            this.txtSoSVToiThieu.Location = new System.Drawing.Point(450, 112);
            this.txtSoSVToiThieu.MaxLength = 3;
            this.txtSoSVToiThieu.Size = new System.Drawing.Size(80, 22);
            this.txtSoSVToiThieu.ReadOnly = true;

            // GroupBox2
            this.groupBox2.Location = new System.Drawing.Point(574, 50);
            this.groupBox2.Size = new System.Drawing.Size(345, 160);
            this.groupBox2.Text = "Lọc danh sách lớp tín chỉ";
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboHocKy);
            this.groupBox2.Controls.Add(this.cboGiangVien);
            this.groupBox2.Controls.Add(this.cboMonHoc);
            this.groupBox2.Controls.Add(this.cboNienKhoa);

            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 35);
            this.label7.Text = "Niên khóa:";

            // label8
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 35);
            this.label8.Text = "Học kỳ:";

            // label9
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 75);
            this.label9.Text = "Môn học:";

            // label10
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 115);
            this.label10.Text = "Giảng viên:";

            // cboHocKy
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(270, 32);
            this.cboHocKy.Size = new System.Drawing.Size(60, 24);
            this.cboHocKy.SelectedIndex = -1;
            this.cboHocKy.Visible = true;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);

            // cboNienKhoa
            this.cboNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNienKhoa.FormattingEnabled = true;
            this.cboNienKhoa.Location = new System.Drawing.Point(100, 32);
            this.cboNienKhoa.Size = new System.Drawing.Size(100, 24);
            this.cboNienKhoa.SelectedIndex = -1;
            this.cboNienKhoa.Visible = true;
            this.cboNienKhoa.SelectedIndexChanged += new System.EventHandler(this.cboNienKhoa_SelectedIndexChanged);

            // cboMonHoc
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(100, 72);
            this.cboMonHoc.Size = new System.Drawing.Size(230, 24);
            this.cboMonHoc.Visible = true;
            this.cboMonHoc.SelectedIndexChanged += new System.EventHandler(this.cboMonHoc_SelectedIndexChanged);

            // cboGiangVien
            this.cboGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiangVien.FormattingEnabled = true;
            this.cboGiangVien.Location = new System.Drawing.Point(100, 112);
            this.cboGiangVien.Size = new System.Drawing.Size(230, 24);
            this.cboGiangVien.SelectedIndexChanged += new System.EventHandler(this.cboGiangVien_SelectedIndexChanged);

            // dgvLopTinChi
            this.dgvLopTinChi.AllowUserToAddRows = false;
            this.dgvLopTinChi.AllowUserToDeleteRows = false;
            this.dgvLopTinChi.Location = new System.Drawing.Point(20, 265);
            this.dgvLopTinChi.ReadOnly = true;
            this.dgvLopTinChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopTinChi.MultiSelect = false;
            this.dgvLopTinChi.Size = new System.Drawing.Size(900, 280);
            this.dgvLopTinChi.SelectionChanged += new System.EventHandler(this.dgvLopTinChi_SelectionChanged);

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(140, 220);
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(240, 220);
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(340, 220);
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnGhi
            this.btnGhi.Enabled = false;
            this.btnGhi.Location = new System.Drawing.Point(440, 220);
            this.btnGhi.Size = new System.Drawing.Size(80, 30);
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            this.btnGhi.Enabled = false;

            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(540, 220);
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnHuy.Enabled = false;

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(640, 220);
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmLopTinChi
            this.ClientSize = new System.Drawing.Size(940, 570);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvLopTinChi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLopTinChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý lớp tín chỉ";
            ((System.ComponentModel.ISupportInitialize)this.dgvLopTinChi).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void cboGiangVien_SelectedIndexChanged(object sender, EventArgs e) {
            if (isInitializing)
                return;
            string selectedMaGV = cboGiangVien.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedMaGV)) {
                dtLTC.DefaultView.RowFilter = ""; // Hiển thị tất cả
            } else {
                dtLTC.DefaultView.RowFilter = $"MAGV = '{selectedMaGV}'";
            }
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e) {
            if (isInitializing)
                return;
            string selectedHocKy = cboHocKy.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedHocKy)) {
                dtLTC.DefaultView.RowFilter = ""; // Hiển thị tất cả
            } else {
                dtLTC.DefaultView.RowFilter = $"HOCKY = {selectedHocKy}";
            }
        }

        private void cboNienKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            if (isInitializing)
                return;
            string selectedNienKhoa = cboNienKhoa.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedNienKhoa)) {
                dtLTC.DefaultView.RowFilter = ""; // Hiển thị tất cả
            } else {
                dtLTC.DefaultView.RowFilter = $"NIENKHOA = '{selectedNienKhoa}'";
            }
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e) {
            if (isInitializing)
                return;
            string selectedMaMH = cboMonHoc.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedMaMH)) {
                dtLTC.DefaultView.RowFilter = ""; // Hiển thị tất cả
            } else {
                dtLTC.DefaultView.RowFilter = $"MAMH = '{selectedMaMH}'";
            }
        }

        private System.Windows.Forms.TextBox txtNienKhoa;
        private System.Windows.Forms.TextBox txtHocKy;
        private System.Windows.Forms.TextBox txtNhom;
        private System.Windows.Forms.TextBox txtSoSVToiThieu;
        private System.Windows.Forms.TextBox txtMonHoc;
        private System.Windows.Forms.TextBox txtGiangVien;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.ComboBox cboNienKhoa;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.ComboBox cboGiangVien;
        private System.Windows.Forms.DataGridView dgvLopTinChi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelTitle;

        private bool isInitializing = true;
        private void LoadComboBoxes() {
            try {
                // Load niên khóa (danh sách niên khóa có trong LOPTINCHI)
                string queryNienKhoa = "SELECT DISTINCT " +
                                            "NIENKHOA " +
                                        "FROM LOPTINCHI " +
                                        "ORDER BY NIENKHOA " +
                                        "DESC";
                DataTable dtNienKhoa = DatabaseConnection.ExecuteQuery(queryNienKhoa);
                DataRow dr = dtNienKhoa.NewRow();
                dr["NIENKHOA"] = "";
                dtNienKhoa.Rows.InsertAt(dr, 0);
                cboNienKhoa.DataSource = dtNienKhoa;
                cboNienKhoa.DisplayMember = "NIENKHOA";
                cboNienKhoa.ValueMember = "NIENKHOA";

                // Load học kỳ 
                string queryHocKy = "SELECT DISTINCT " +
                                        "HOCKY " +
                                    "FROM LOPTINCHI " +
                                    "ORDER BY HOCKY";
                DataTable dtHocKy = DatabaseConnection.ExecuteQuery(queryHocKy);
                DataRow drHocKy = dtHocKy.NewRow();
                drHocKy["HOCKY"] = DBNull.Value;
                dtHocKy.Rows.InsertAt(drHocKy, 0);
                cboHocKy.DataSource = dtHocKy;
                cboHocKy.DisplayMember = "HOCKY";
                cboHocKy.ValueMember = "HOCKY";

                // Load môn học (tất cả môn học - dùng chung)
                string query = "SELECT " +
                                    "MAMH, " +
                                    "TENMH " +
                                "FROM MONHOC " +
                                "ORDER BY TENMH";
                DataTable dtMH = DatabaseConnection.ExecuteQuery(query);
                DataRow drMH = dtMH.NewRow();
                drMH["MAMH"] = "";
                drMH["TENMH"] = "";
                dtMH.Rows.InsertAt(drMH, 0);
                cboMonHoc.DataSource = dtMH;
                cboMonHoc.DisplayMember = "TENMH";
                cboMonHoc.ValueMember = "MAMH";

                // Load giảng viên (tất cả GV - vì GV có thể dạy cả 2 khoa)
                query = "SELECT " +
                            "MAGV, " +
                            "HO + ' ' + TEN AS HOTEN " +
                        "FROM GIANGVIEN " +
                        "ORDER BY TEN";
                DataTable dtGV = DatabaseConnection.ExecuteQuery(query);
                DataRow drGV = dtGV.NewRow();
                drGV["MAGV"] = "";
                drGV["HOTEN"] = "";
                dtGV.Rows.InsertAt(drGV, 0);
                cboGiangVien.DataSource = dtGV;
                cboGiangVien.DisplayMember = "HOTEN";
                cboGiangVien.ValueMember = "MAGV";
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isInitializing = false;
        }

        private void LoadData() {
            //string role = (DatabaseConnection.UserRole ?? "").Trim().ToUpperInvariant();

            try {
                string query =
                    "SELECT " +
                    "   ltc.MALTC, " +
                    "   ltc.NIENKHOA, " +
                    "   ltc.HOCKY, " +
                    "   mh.MAMH, " +
                    "   mh.TENMH, " +
                    "   ltc.NHOM, " +
                    "   gv.MAGV, " +
                    "   gv.HO + ' ' + gv.TEN AS HOTENGV, " +
                    "   k.MAKHOA, " +
                    "   ltc.SOSVTOITHIEU, " +
                    "   ltc.HUYLOP " +
                    "FROM LOPTINCHI ltc " +
                    "   JOIN MONHOC mh ON ltc.MAMH = mh.MAMH " +
                    "   JOIN GIANGVIEN gv ON ltc.MAGV = gv.MAGV " +
                    "   JOIN KHOA k ON ltc.MAKHOA = k.MAKHOA " +
                    //"{WHERE} " +
                    "ORDER BY ltc.NIENKHOA DESC, ltc.HOCKY, mh.TENMH, ltc.NHOM";

                object hocKyParam = string.IsNullOrWhiteSpace(txtHocKy.Text)
                    ? (object)DBNull.Value
                    : int.Parse(txtHocKy.Text.Trim());

                //SqlParameter[] parameters = {
                //    new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
                //};

                //if (role == "PGV") {
                //    // Xem tất cả các khoa
                //    query = query.Replace("{WHERE}", "");
                //    dtLTC = DatabaseConnection.ExecuteQuery(query, parameters);
                //} else {
                //    // Xem theo khoa hiện tại
                //    query = query.Replace("{WHERE}", "WHERE ltc.MAKHOA = @MaKhoa");
                //    dtLTC = DatabaseConnection.ExecuteQuery(query, parameters);
                //}

                dtLTC = DatabaseConnection.ExecuteQuery(query);
                dgvLopTinChi.DataSource = dtLTC;

                if (dgvLopTinChi.Columns.Count > 0) {
                    dgvLopTinChi.Columns["MALTC"].HeaderText = "Mã LTC";
                    dgvLopTinChi.Columns["MALTC"].Width = 60;
                    dgvLopTinChi.Columns["NIENKHOA"].HeaderText = "Niên khóa";
                    dgvLopTinChi.Columns["NIENKHOA"].Width = 90;
                    dgvLopTinChi.Columns["HOCKY"].HeaderText = "HK";
                    dgvLopTinChi.Columns["HOCKY"].Width = 40;
                    dgvLopTinChi.Columns["MAMH"].Visible = false;
                    dgvLopTinChi.Columns["TENMH"].HeaderText = "Môn học";
                    dgvLopTinChi.Columns["TENMH"].Width = 210;
                    dgvLopTinChi.Columns["NHOM"].HeaderText = "Nhóm";
                    dgvLopTinChi.Columns["NHOM"].Width = 60;
                    dgvLopTinChi.Columns["MAGV"].Visible = false;
                    dgvLopTinChi.Columns["HOTENGV"].HeaderText = "Giảng viên";
                    dgvLopTinChi.Columns["HOTENGV"].Width = 180;
                    dgvLopTinChi.Columns["MAKHOA"].HeaderText = "Khoa";
                    dgvLopTinChi.Columns["MAKHOA"].Width = 80;
                    dgvLopTinChi.Columns["SOSVTOITHIEU"].HeaderText = "SV tối thiểu";
                    dgvLopTinChi.Columns["SOSVTOITHIEU"].Width = 80;
                    dgvLopTinChi.Columns["HUYLOP"].HeaderText = "Đã hủy";
                    dgvLopTinChi.Columns["HUYLOP"].Width = 60;
                    dgvLopTinChi.Columns["HUYLOP"].Visible = false;
                    dtLTC.Columns.Add("TRANGTHAI", typeof(string), "IIF(HUYLOP = 1, 'Đã hủy', 'Chưa hủy')");
                    dgvLopTinChi.Columns["TRANGTHAI"].HeaderText = "Trạng thái";
                    dgvLopTinChi.Columns["TRANGTHAI"].Width = 80;
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLopTinChi_SelectionChanged(object sender, EventArgs e) {
            if (dgvLopTinChi.CurrentRow != null) {
                try {
                    selectedMALTC = Convert.ToInt32(dgvLopTinChi.CurrentRow.Cells["MALTC"].Value);
                    txtNienKhoa.Text = dgvLopTinChi.CurrentRow.Cells["NIENKHOA"].Value?.ToString().Trim();
                    txtHocKy.Text = dgvLopTinChi.CurrentRow.Cells["HOCKY"].Value?.ToString();
                    txtMonHoc.Text = dgvLopTinChi.CurrentRow.Cells["TENMH"].Value?.ToString().Trim();
                    txtNhom.Text = dgvLopTinChi.CurrentRow.Cells["NHOM"].Value?.ToString();
                    txtGiangVien.Text = dgvLopTinChi.CurrentRow.Cells["HOTENGV"].Value?.ToString().Trim();
                    txtSoSVToiThieu.Text = dgvLopTinChi.CurrentRow.Cells["SOSVTOITHIEU"].Value?.ToString();
                    txtTrangThai.Text = dgvLopTinChi.CurrentRow.Cells["TRANGTHAI"].Value?.ToString();

                    bool huyLop = dgvLopTinChi.CurrentRow.Cells["HUYLOP"].Value != DBNull.Value &&
                                  Convert.ToBoolean(dgvLopTinChi.CurrentRow.Cells["HUYLOP"].Value);
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e) {
            isAdding = true;
            selectedMALTC = -1;
            // Nien khoa
            txtNienKhoa.Clear();
            txtNienKhoa.ReadOnly = false;
            txtNienKhoa.Focus();
            // Hoc ki
            txtHocKy.Clear();
            txtHocKy.ReadOnly = false;
            // Trang thai
            txtTrangThai.Clear();
            txtTrangThai.ReadOnly = false;
            // Mon hoc
            txtMonHoc.Clear();
            txtMonHoc.ReadOnly = false;
            // Giang vien
            txtGiangVien.Clear();
            txtGiangVien.ReadOnly = false;
            // Nhom
            txtNhom.Clear();
            txtNhom.ReadOnly = false;
            // So SV toi thieu
            txtSoSVToiThieu.Clear();
            txtSoSVToiThieu.ReadOnly = false;
            btnHuy.Enabled = true;
            btnGhi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e) {
            if (dgvLopTinChi.CurrentRow == null) {
                MessageBox.Show("Vui lòng chọn lớp tín chỉ cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hủy lớp tín chỉ này?\n(Lớp sẽ được đánh dấu hủy, không xóa hẳn)",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                try {
                    int maLTC = Convert.ToInt32(dgvLopTinChi.CurrentRow.Cells["MALTC"].Value);
                    string query = "UPDATE LOPTINCHI " +
                                    "SET HUYLOP = 1 " +
                                    "WHERE MALTC = @MaLTC";
                    SqlParameter[] parameters = {
                        new SqlParameter("@MaLTC", maLTC)
                    };

                    if (DatabaseConnection.ExecuteNonQuery(query, parameters)) {
                        MessageBox.Show("Hủy lớp tín chỉ thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi khi hủy lớp: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e) {
            isAdding = false;
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
            if (dgvLopTinChi.CurrentRow == null) {
                MessageBox.Show("Vui lòng chọn lớp tín chỉ cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Nien khoa
            txtNienKhoa.ReadOnly = false;
            txtNienKhoa.Focus();
            // Hoc ki
            txtHocKy.ReadOnly = false;
            // Trang thai
            txtTrangThai.Enabled = true;
            // Mon hoc
            txtMonHoc.ReadOnly = false;
            // Giang vien
            txtGiangVien.ReadOnly = false;
            // Nhom
            txtNhom.ReadOnly = false;
            // So SV toi thieu
            txtSoSVToiThieu.ReadOnly = false;
        }

        private void btnGhi_Click(object sender, EventArgs e) {
            try {
                // Validate dữ liệu
                if (string.IsNullOrWhiteSpace(txtNienKhoa.Text)) {
                    MessageBox.Show("Vui lòng nhập niên khóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNienKhoa.Focus();
                    return;
                }

                int hocKy;
                if (!int.TryParse(txtHocKy.Text, out hocKy) || hocKy < 1 || hocKy > 4) {
                    MessageBox.Show("Học kỳ phải từ 1 đến 4!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHocKy.Focus();
                    return;
                }

                int nhom;
                if (!int.TryParse(txtNhom.Text, out nhom) || nhom < 1) {
                    MessageBox.Show("Nhóm phải >= 1!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNhom.Focus();
                    return;
                }

                int soSV;
                if (!int.TryParse(txtSoSVToiThieu.Text, out soSV) || soSV < 1) {
                    MessageBox.Show("Số sinh viên tối thiểu phải > 0!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoSVToiThieu.Focus();
                    return;
                }

                if (txtMonHoc.Text == null || txtGiangVien.Text == null) {
                    MessageBox.Show("Vui lòng nhập môn học và giảng viên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maMH = "";
                string queryMH = "SELECT MAMH FROM MONHOC WHERE TENMH = @TenMH";
                SqlParameter[] paramMH = {
                    new SqlParameter("@TenMH", txtMonHoc.Text.Trim())
                };
                DataTable dtMH = DatabaseConnection.ExecuteQuery(queryMH, paramMH);
                if (dtMH.Rows.Count == 0) {
                    MessageBox.Show("Môn học không tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonHoc.Focus();
                    return;
                }

                maMH = dtMH.Rows[0]["MAMH"].ToString().Trim();
                string maGV = "";
                string queryGV = "SELECT MAGV FROM GIANGVIEN WHERE HO + ' ' + TEN = @HoTen";
                SqlParameter[] paramGV = {
                    new SqlParameter("@HoTen", txtGiangVien.Text.Trim())
                };
                DataTable dtGV = DatabaseConnection.ExecuteQuery(queryGV, paramGV);
                if (dtGV.Rows.Count == 0) {
                    MessageBox.Show("Giảng viên không tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiangVien.Focus();
                    return;
                }
                maGV = dtGV.Rows[0]["MAGV"].ToString().Trim();

                string query;
                SqlParameter[] parameters;

                if (isAdding) {
                    // Thêm mới lớp tín chỉ
                    // LƯU Ý: MAKHOA tự động lấy từ DatabaseConnection.CurrentKhoa
                    query = @"INSERT INTO LOPTINCHI 
                                (NIENKHOA, HOCKY, MAMH, NHOM, MAGV, MAKHOA, SOSVTOITHIEU, HUYLOP)
                             VALUES 
                                (@NienKhoa, @HocKy, @MaMH, @Nhom, @MaGV, @MaKhoa, @SoSV, @HuyLop)";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@NienKhoa", txtNienKhoa.Text.Trim()),
                        new SqlParameter("@HocKy", hocKy),
                        new SqlParameter("@MaMH", maMH),
                        new SqlParameter("@Nhom", nhom),
                        new SqlParameter("@MaGV", maGV),
                        new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa), // KEY: Tự động lấy khoa hiện tại
                        new SqlParameter("@SoSV", soSV),
                        new SqlParameter("@HuyLop", 0) // Mặc định khi tạo mới là chưa hủy
                    };
                } else {
                    // Cập nhật lớp tín chỉ
                    query = @"UPDATE LOPTINCHI 
                             SET NIENKHOA = @NienKhoa, 
                                 HOCKY = @HocKy, 
                                 MAMH = @MaMH, 
                                 NHOM = @Nhom, 
                                 MAGV = @MaGV, 
                                 SOSVTOITHIEU = @SoSV, 
                             WHERE MALTC = @MaLTC";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@NienKhoa", txtNienKhoa.Text.Trim()),
                        new SqlParameter("@HocKy", hocKy),
                        new SqlParameter("@MaMH", maMH),
                        new SqlParameter("@Nhom", nhom),
                        new SqlParameter("@MaGV", maGV),
                        new SqlParameter("@SoSV", soSV),
                        new SqlParameter("@MaLTC", selectedMALTC),
                    };
                }

                if (DatabaseConnection.ExecuteNonQuery(query, parameters)) {
                    MessageBox.Show("Lưu lớp tín chỉ thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAdding = false;
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                    LoadData();
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) {
            isAdding = false;
            btnGhi.Enabled = false;
            LoadData();

            if (dgvLopTinChi.Rows.Count > 0)
                dgvLopTinChi.Rows[0].Selected = true;
        }

        private void btnThoat_Click(object sender, EventArgs e) {
            this.Hide();
            frmMain frm = new frmMain();
            frm.ShowDialog();
            this.Close();
        }
    }
}