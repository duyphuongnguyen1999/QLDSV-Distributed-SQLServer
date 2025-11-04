using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmDongHocPhi : Form
    {
        public frmDongHocPhi()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.dgvHocPhi = new System.Windows.Forms.DataGridView();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.txtHocKy = new System.Windows.Forms.TextBox();
            this.txtHocPhi = new System.Windows.Forms.TextBox();
            this.txtSoTienDong = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThemHocPhi = new System.Windows.Forms.Button();
            this.btnDongHocPhi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(900, 100);
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
            this.groupBox2.Controls.Add(this.dgvHocPhi);
            this.groupBox2.Location = new System.Drawing.Point(20, 140);
            this.groupBox2.Size = new System.Drawing.Size(900, 200);
            this.groupBox2.Text = "Thông tin học phí";

            // dgvHocPhi
            this.dgvHocPhi.AllowUserToAddRows = false;
            this.dgvHocPhi.AllowUserToDeleteRows = false;
            this.dgvHocPhi.Location = new System.Drawing.Point(20, 25);
            this.dgvHocPhi.Size = new System.Drawing.Size(860, 160);
            this.dgvHocPhi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocPhi.MultiSelect = false;
            this.dgvHocPhi.ReadOnly = true;
            this.dgvHocPhi.SelectionChanged += new System.EventHandler(this.dgvHocPhi_SelectionChanged);

            // groupBox3
            this.groupBox3.Controls.Add(this.btnDongHocPhi);
            this.groupBox3.Controls.Add(this.txtSoTienDong);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnThemHocPhi);
            this.groupBox3.Controls.Add(this.txtHocPhi);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtHocKy);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtNienKhoa);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dgvChiTiet);
            this.groupBox3.Location = new System.Drawing.Point(20, 360);
            this.groupBox3.Size = new System.Drawing.Size(900, 270);
            this.groupBox3.Text = "Chi tiết đóng học phí";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Text = "Niên khóa:";

            // txtNienKhoa
            this.txtNienKhoa.Location = new System.Drawing.Point(100, 27);
            this.txtNienKhoa.Size = new System.Drawing.Size(100, 22);
            this.txtNienKhoa.MaxLength = 9;
            this.txtNienKhoa.Text = "2024-2025";

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 30);
            this.label5.Text = "Học kỳ:";

            // txtHocKy
            this.txtHocKy.Location = new System.Drawing.Point(290, 27);
            this.txtHocKy.Size = new System.Drawing.Size(60, 22);
            this.txtHocKy.MaxLength = 1;
            this.txtHocKy.Text = "1";

            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 30);
            this.label6.Text = "Học phí:";

            // txtHocPhi
            this.txtHocPhi.Location = new System.Drawing.Point(440, 27);
            this.txtHocPhi.Size = new System.Drawing.Size(120, 22);
            this.txtHocPhi.Text = "0";

            // btnThemHocPhi
            this.btnThemHocPhi.Location = new System.Drawing.Point(580, 25);
            this.btnThemHocPhi.Size = new System.Drawing.Size(100, 26);
            this.btnThemHocPhi.Text = "Thêm học phí";
            this.btnThemHocPhi.Click += new System.EventHandler(this.btnThemHocPhi_Click);

            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 65);
            this.label7.Text = "Số tiền đóng:";

            // txtSoTienDong
            this.txtSoTienDong.Location = new System.Drawing.Point(120, 62);
            this.txtSoTienDong.Size = new System.Drawing.Size(150, 22);
            this.txtSoTienDong.Text = "0";

            // btnDongHocPhi
            this.btnDongHocPhi.Location = new System.Drawing.Point(290, 60);
            this.btnDongHocPhi.Size = new System.Drawing.Size(100, 26);
            this.btnDongHocPhi.Text = "Đóng học phí";
            this.btnDongHocPhi.Click += new System.EventHandler(this.btnDongHocPhi_Click);

            // dgvChiTiet
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Location = new System.Drawing.Point(20, 100);
            this.dgvChiTiet.Size = new System.Drawing.Size(860, 150);
            this.dgvChiTiet.ReadOnly = true;

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(420, 650);
            this.btnThoat.Size = new System.Drawing.Size(100, 35);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmDongHocPhi
            this.ClientSize = new System.Drawing.Size(940, 710);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDongHocPhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý học phí";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.DataGridView dgvHocPhi;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.TextBox txtNienKhoa;
        private System.Windows.Forms.TextBox txtHocKy;
        private System.Windows.Forms.TextBox txtHocPhi;
        private System.Windows.Forms.TextBox txtSoTienDong;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThemHocPhi;
        private System.Windows.Forms.Button btnDongHocPhi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo");
                return;
            }

            // Tìm sinh viên trong cả 2 server
            string query = @"SELECT sv.MASV, sv.HO + ' ' + sv.TEN AS HOTEN, sv.MALOP
                           FROM Sinhvien sv
                           WHERE sv.MASV = @MaSV AND sv.DANGHIHOC = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@MaSV", txtMaSV.Text.Trim())
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters, "CNTT");
            if (dt.Rows.Count == 0)
            {
                dt = DatabaseConnection.ExecuteQuery(query, parameters, "VT");
            }

            if (dt.Rows.Count > 0)
            {
                txtHoTen.Text = dt.Rows[0]["HOTEN"].ToString();
                txtMaLop.Text = dt.Rows[0]["MALOP"].ToString().Trim();

                LoadHocPhi();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo");
                txtHoTen.Clear();
                txtMaLop.Clear();
                dgvHocPhi.DataSource = null;
                dgvChiTiet.DataSource = null;
            }
        }

        private void LoadHocPhi()
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MASV", txtMaSV.Text.Trim())
            };

            DataTable dt = DatabaseConnection.ExecuteStoredProcedureHocPhi("sp_LayThongTinHocPhi", parameters);
            dgvHocPhi.DataSource = dt;

            if (dgvHocPhi.Columns.Count > 0)
            {
                dgvHocPhi.Columns["MASV"].Visible = false;
                dgvHocPhi.Columns["NIENKHOA"].HeaderText = "Niên khóa";
                dgvHocPhi.Columns["NIENKHOA"].Width = 100;
                dgvHocPhi.Columns["HOCKY"].HeaderText = "Học kỳ";
                dgvHocPhi.Columns["HOCKY"].Width = 70;
                dgvHocPhi.Columns["HOCPHI"].HeaderText = "Học phí";
                dgvHocPhi.Columns["HOCPHI"].Width = 120;
                dgvHocPhi.Columns["HOCPHI"].DefaultCellStyle.Format = "N0";
                dgvHocPhi.Columns["SOTIENDADONG"].HeaderText = "Số tiền đã đóng";
                dgvHocPhi.Columns["SOTIENDADONG"].Width = 150;
                dgvHocPhi.Columns["SOTIENDADONG"].DefaultCellStyle.Format = "N0";
                dgvHocPhi.Columns["SOTIENCANDONG"].HeaderText = "Số tiền cần đóng";
                dgvHocPhi.Columns["SOTIENCANDONG"].Width = 150;
                dgvHocPhi.Columns["SOTIENCANDONG"].DefaultCellStyle.Format = "N0";
            }
        }

        private void dgvHocPhi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocPhi.CurrentRow != null)
            {
                string nienKhoa = dgvHocPhi.CurrentRow.Cells["NIENKHOA"].Value?.ToString().Trim();
                int hocKy = Convert.ToInt32(dgvHocPhi.CurrentRow.Cells["HOCKY"].Value);

                txtNienKhoa.Text = nienKhoa;
                txtHocKy.Text = hocKy.ToString();

                LoadChiTietDongHocPhi(nienKhoa, hocKy);
            }
        }

        private void LoadChiTietDongHocPhi(string nienKhoa, int hocKy)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MASV", txtMaSV.Text.Trim()),
                new SqlParameter("@NienKhoa", nienKhoa),
                new SqlParameter("@HocKy", hocKy)
            };

            DataTable dt = DatabaseConnection.ExecuteStoredProcedureHocPhi("sp_LayChiTietDongHocPhi", parameters);
            dgvChiTiet.DataSource = dt;

            if (dgvChiTiet.Columns.Count > 0)
            {
                dgvChiTiet.Columns["NGAYDONG"].HeaderText = "Ngày đóng";
                dgvChiTiet.Columns["NGAYDONG"].Width = 150;
                dgvChiTiet.Columns["NGAYDONG"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvChiTiet.Columns["SOTIENDONG"].HeaderText = "Số tiền đóng";
                dgvChiTiet.Columns["SOTIENDONG"].Width = 150;
                dgvChiTiet.Columns["SOTIENDONG"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnThemHocPhi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng tìm sinh viên trước!", "Thông báo");
                return;
            }

            int hocPhi;
            if (!int.TryParse(txtHocPhi.Text, out hocPhi) || hocPhi <= 0)
            {
                MessageBox.Show("Học phí không hợp lệ!", "Thông báo");
                return;
            }

            int hocKy;
            if (!int.TryParse(txtHocKy.Text, out hocKy) || hocKy < 1 || hocKy > 4)
            {
                MessageBox.Show("Học kỳ phải từ 1 đến 4!", "Thông báo");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@MASV", txtMaSV.Text.Trim()),
                new SqlParameter("@NienKhoa", txtNienKhoa.Text.Trim()),
                new SqlParameter("@HocKy", hocKy),
                new SqlParameter("@HocPhi", hocPhi)
            };

            DataTable result = DatabaseConnection.ExecuteStoredProcedureHocPhi("sp_ThemHocPhi", parameters);

            if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0]["Result"]) == 1)
            {
                MessageBox.Show(result.Rows[0]["Message"].ToString(), "Thành công");
                LoadHocPhi();
            }
        }

        private void btnDongHocPhi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng tìm sinh viên trước!", "Thông báo");
                return;
            }

            int soTien;
            if (!int.TryParse(txtSoTienDong.Text, out soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền đóng không hợp lệ!", "Thông báo");
                return;
            }

            int hocKy;
            if (!int.TryParse(txtHocKy.Text, out hocKy))
            {
                MessageBox.Show("Vui lòng chọn niên khóa và học kỳ!", "Thông báo");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@MASV", txtMaSV.Text.Trim()),
                new SqlParameter("@NienKhoa", txtNienKhoa.Text.Trim()),
                new SqlParameter("@HocKy", hocKy),
                new SqlParameter("@SoTienDong", soTien)
            };

            DataTable result = DatabaseConnection.ExecuteStoredProcedureHocPhi("sp_DongHocPhi", parameters);

            if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0]["Result"]) == 1)
            {
                MessageBox.Show(result.Rows[0]["Message"].ToString(), "Thành công");
                LoadHocPhi();

                if (dgvHocPhi.CurrentRow != null)
                {
                    string nienKhoa = dgvHocPhi.CurrentRow.Cells["NIENKHOA"].Value?.ToString().Trim();
                    LoadChiTietDongHocPhi(nienKhoa, hocKy);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}