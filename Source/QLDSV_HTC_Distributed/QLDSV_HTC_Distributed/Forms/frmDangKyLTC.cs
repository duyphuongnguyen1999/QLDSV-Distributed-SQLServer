using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmDangKyLTC : Form
    {
        public frmDangKyLTC()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.txtHocKy = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).BeginInit();
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
            this.groupBox2.Controls.Add(this.txtHocKy);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNienKhoa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(20, 160);
            this.groupBox2.Size = new System.Drawing.Size(900, 380);
            this.groupBox2.Text = "Danh sách lớp tín chỉ";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 35);
            this.label4.Text = "Niên khóa:";

            // txtNienKhoa
            this.txtNienKhoa.Location = new System.Drawing.Point(100, 32);
            this.txtNienKhoa.Size = new System.Drawing.Size(100, 22);
            this.txtNienKhoa.MaxLength = 9;
            this.txtNienKhoa.Text = "2024-2025";
            this.txtNienKhoa.TextChanged += new System.EventHandler(this.txtNienKhoa_TextChanged);

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 35);
            this.label5.Text = "Học kỳ:";

            // txtHocKy
            this.txtHocKy.Location = new System.Drawing.Point(290, 32);
            this.txtHocKy.Size = new System.Drawing.Size(60, 22);
            this.txtHocKy.MaxLength = 1;
            this.txtHocKy.Text = "1";
            this.txtHocKy.TextChanged += new System.EventHandler(this.txtHocKy_TextChanged);

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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtNienKhoa;
        private System.Windows.Forms.TextBox txtHocKy;
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo");
                return;
            }

            string query = @"SELECT sv.MASV, sv.HO + ' ' + sv.TEN AS HOTEN, sv.MALOP, l.MAKHOA
                           FROM Sinhvien sv
                           JOIN Lop l ON sv.MALOP = l.MALOP
                           WHERE sv.MASV = @MaSV AND sv.DANGHIHOC = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@MaSV", txtMaSV.Text.Trim())
            };

            // Tìm trong cả 2 server
            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters, "CNTT");
            if (dt.Rows.Count == 0)
            {
                dt = DatabaseConnection.ExecuteQuery(query, parameters, "VT");
            }

            if (dt.Rows.Count > 0)
            {
                txtHoTen.Text = dt.Rows[0]["HOTEN"].ToString();
                txtMaLop.Text = dt.Rows[0]["MALOP"].ToString().Trim();
                DatabaseConnection.CurrentKhoa = dt.Rows[0]["MAKHOA"].ToString().Trim();

                LoadLopTinChi();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo");
                txtHoTen.Clear();
                txtMaLop.Clear();
            }
        }

        private void txtNienKhoa_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMaSV.Text) && !string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                LoadLopTinChi();
            }
        }

        private void txtHocKy_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMaSV.Text) && !string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                LoadLopTinChi();
            }
        }

        private void LoadLopTinChi()
        {
            if (string.IsNullOrWhiteSpace(txtNienKhoa.Text) || string.IsNullOrWhiteSpace(txtHocKy.Text))
                return;

            SqlParameter[] parameters = {
                new SqlParameter("@NienKhoa", txtNienKhoa.Text.Trim()),
                new SqlParameter("@HocKy", int.Parse(txtHocKy.Text)),
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };

            DataTable dt = DatabaseConnection.ExecuteStoredProcedure("sp_LayDanhSachLopTinChi", parameters);
            dgvLopTinChi.DataSource = dt;

            if (dgvLopTinChi.Columns.Count > 0)
            {
                dgvLopTinChi.Columns["MALTC"].HeaderText = "Mã LTC";
                dgvLopTinChi.Columns["MALTC"].Width = 70;
                dgvLopTinChi.Columns["MAMH"].HeaderText = "Mã MH";
                dgvLopTinChi.Columns["MAMH"].Width = 80;
                dgvLopTinChi.Columns["TENMH"].HeaderText = "Tên môn học";
                dgvLopTinChi.Columns["TENMH"].Width = 250;
                dgvLopTinChi.Columns["NHOM"].HeaderText = "Nhóm";
                dgvLopTinChi.Columns["NHOM"].Width = 60;
                dgvLopTinChi.Columns["HOTENGV"].HeaderText = "Giảng viên";
                dgvLopTinChi.Columns["HOTENGV"].Width = 180;
                dgvLopTinChi.Columns["SOSVTOITHIEU"].HeaderText = "SV tối thiểu";
                dgvLopTinChi.Columns["SOSVTOITHIEU"].Width = 100;
                dgvLopTinChi.Columns["SOSV_DADANGKY"].HeaderText = "SV đã đăng ký";
                dgvLopTinChi.Columns["SOSV_DADANGKY"].Width = 110;

                dgvLopTinChi.Columns["NIENKHOA"].Visible = false;
                dgvLopTinChi.Columns["HOCKY"].Visible = false;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo");
                return;
            }

            if (dgvLopTinChi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn lớp tín chỉ cần đăng ký!", "Thông báo");
                return;
            }

            int maLTC = Convert.ToInt32(dgvLopTinChi.CurrentRow.Cells["MALTC"].Value);

            SqlParameter[] parameters = {
                new SqlParameter("@MALTC", maLTC),
                new SqlParameter("@MASV", txtMaSV.Text.Trim())
            };

            DataTable result = DatabaseConnection.ExecuteStoredProcedure("sp_DangKyLopTinChi", parameters);

            if (result.Rows.Count > 0)
            {
                int resultCode = Convert.ToInt32(result.Rows[0]["Result"]);
                string message = result.Rows[0]["Message"].ToString();

                if (resultCode == 1)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopTinChi();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}