using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmSinhVien : Form
    {
        private DataTable dtSinhVien;
        private bool isAdding = false;

        public frmSinhVien()
        {
            InitializeComponent();
            LoadLop();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.chkPhai = new System.Windows.Forms.CheckBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // groupBox1
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpNgaySinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkPhai);
            this.groupBox1.Controls.Add(this.cboLop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 50);
            this.groupBox1.Size = new System.Drawing.Size(900, 160);
            this.groupBox1.Text = "Thông tin sinh viên";

            // lblKhoa
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblKhoa.Location = new System.Drawing.Point(400, 15);
            this.lblKhoa.Text = "KHOA: " + DatabaseConnection.CurrentKhoa;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Text = "Mã sinh viên:";

            // txtMaSV
            this.txtMaSV.Location = new System.Drawing.Point(120, 32);
            this.txtMaSV.Size = new System.Drawing.Size(150, 22);
            this.txtMaSV.MaxLength = 10;

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 35);
            this.label2.Text = "Họ:";

            // txtHo
            this.txtHo.Location = new System.Drawing.Point(350, 32);
            this.txtHo.Size = new System.Drawing.Size(200, 22);
            this.txtHo.MaxLength = 50;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 35);
            this.label3.Text = "Tên:";

            // txtTen
            this.txtTen.Location = new System.Drawing.Point(620, 32);
            this.txtTen.Size = new System.Drawing.Size(150, 22);
            this.txtTen.MaxLength = 10;

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 75);
            this.label4.Text = "Lớp:";

            // cboLop
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Location = new System.Drawing.Point(120, 72);
            this.cboLop.Size = new System.Drawing.Size(200, 24);

            // chkPhai
            this.chkPhai.AutoSize = true;
            this.chkPhai.Location = new System.Drawing.Point(350, 74);
            this.chkPhai.Text = "Nữ";

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 75);
            this.label5.Text = "Ngày sinh:";

            // dtpNgaySinh
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(530, 72);
            this.dtpNgaySinh.Size = new System.Drawing.Size(150, 22);

            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 115);
            this.label6.Text = "Địa chỉ:";

            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(120, 112);
            this.txtDiaChi.Size = new System.Drawing.Size(500, 22);
            this.txtDiaChi.MaxLength = 100;

            // dgvSinhVien
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AllowUserToDeleteRows = false;
            this.dgvSinhVien.Location = new System.Drawing.Point(20, 270);
            this.dgvSinhVien.Size = new System.Drawing.Size(900, 280);
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.SelectionChanged += new System.EventHandler(this.dgvSinhVien_SelectionChanged);

            // buttons
            this.btnThem.Location = new System.Drawing.Point(140, 225);
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnXoa.Location = new System.Drawing.Point(240, 225);
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnGhi.Location = new System.Drawing.Point(340, 225);
            this.btnGhi.Size = new System.Drawing.Size(80, 30);
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Enabled = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);

            this.btnPhucHoi.Location = new System.Drawing.Point(440, 225);
            this.btnPhucHoi.Size = new System.Drawing.Size(80, 30);
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);

            this.btnThoat.Location = new System.Drawing.Point(540, 225);
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmSinhVien
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblKhoa);
            this.Name = "frmSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý sinh viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.CheckBox chkPhai;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblKhoa;

        private void LoadLop()
        {
            string query = "SELECT MALOP, TENLOP FROM Lop WHERE MAKHOA = @MaKhoa ORDER BY MALOP";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            cboLop.DataSource = dt;
            cboLop.DisplayMember = "TENLOP";
            cboLop.ValueMember = "MALOP";
        }

        private void LoadData()
        {
            string query = @"SELECT sv.MASV, sv.HO, sv.TEN, sv.MALOP, l.TENLOP, 
                                  sv.PHAI, sv.NGAYSINH, sv.DIACHI
                           FROM Sinhvien sv
                           JOIN Lop l ON sv.MALOP = l.MALOP
                           WHERE l.MAKHOA = @MaKhoa AND sv.DANGHIHOC = 0
                           ORDER BY sv.MASV";

            SqlParameter[] parameters = {
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };

            dtSinhVien = DatabaseConnection.ExecuteQuery(query, parameters);
            dgvSinhVien.DataSource = dtSinhVien;

            if (dgvSinhVien.Columns.Count > 0)
            {
                dgvSinhVien.Columns["MASV"].HeaderText = "Mã SV";
                dgvSinhVien.Columns["MASV"].Width = 100;
                dgvSinhVien.Columns["HO"].HeaderText = "Họ";
                dgvSinhVien.Columns["HO"].Width = 150;
                dgvSinhVien.Columns["TEN"].HeaderText = "Tên";
                dgvSinhVien.Columns["TEN"].Width = 100;
                dgvSinhVien.Columns["MALOP"].Visible = false;
                dgvSinhVien.Columns["TENLOP"].HeaderText = "Lớp";
                dgvSinhVien.Columns["TENLOP"].Width = 150;
                dgvSinhVien.Columns["PHAI"].HeaderText = "Phái";
                dgvSinhVien.Columns["PHAI"].Width = 60;
                dgvSinhVien.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
                dgvSinhVien.Columns["NGAYSINH"].Width = 100;
                dgvSinhVien.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgvSinhVien.Columns["DIACHI"].Width = 200;
            }
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (!isAdding && dgvSinhVien.CurrentRow != null)
            {
                txtMaSV.Text = dgvSinhVien.CurrentRow.Cells["MASV"].Value?.ToString().Trim();
                txtHo.Text = dgvSinhVien.CurrentRow.Cells["HO"].Value?.ToString();
                txtTen.Text = dgvSinhVien.CurrentRow.Cells["TEN"].Value?.ToString();
                cboLop.SelectedValue = dgvSinhVien.CurrentRow.Cells["MALOP"].Value?.ToString().Trim();

                bool phai = dgvSinhVien.CurrentRow.Cells["PHAI"].Value != DBNull.Value &&
                           Convert.ToBoolean(dgvSinhVien.CurrentRow.Cells["PHAI"].Value);
                chkPhai.Checked = phai;

                if (dgvSinhVien.CurrentRow.Cells["NGAYSINH"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(dgvSinhVien.CurrentRow.Cells["NGAYSINH"].Value);

                txtDiaChi.Text = dgvSinhVien.CurrentRow.Cells["DIACHI"].Value?.ToString();

                txtMaSV.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtMaSV.Clear();
            txtHo.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            chkPhai.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;

            txtMaSV.Enabled = true;
            txtMaSV.Focus();
            btnGhi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maSV = txtMaSV.Text.Trim();
                string query = "UPDATE Sinhvien SET DANGHIHOC = 1 WHERE MASV = @MaSV";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaSV", maSV)
                };

                if (DatabaseConnection.ExecuteNonQuery(query, parameters))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo");
                txtMaSV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHo.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!", "Thông báo");
                return;
            }

            if (cboLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Thông báo");
                return;
            }

            string query;
            if (isAdding)
            {
                query = @"INSERT INTO Sinhvien (MASV, HO, TEN, MALOP, PHAI, NGAYSINH, DIACHI, DANGHIHOC, PASSWORD)
                         VALUES (@MaSV, @Ho, @Ten, @MaLop, @Phai, @NgaySinh, @DiaChi, 0, '123456')";
            }
            else
            {
                query = @"UPDATE Sinhvien 
                         SET HO = @Ho, TEN = @Ten, MALOP = @MaLop, PHAI = @Phai, 
                             NGAYSINH = @NgaySinh, DIACHI = @DiaChi
                         WHERE MASV = @MaSV";
            }

            SqlParameter[] parameters = {
                new SqlParameter("@MaSV", txtMaSV.Text.Trim()),
                new SqlParameter("@Ho", txtHo.Text.Trim()),
                new SqlParameter("@Ten", txtTen.Text.Trim()),
                new SqlParameter("@MaLop", cboLop.SelectedValue.ToString()),
                new SqlParameter("@Phai", chkPhai.Checked),
                new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                new SqlParameter("@DiaChi", txtDiaChi.Text.Trim())
            };

            if (DatabaseConnection.ExecuteNonQuery(query, parameters))
            {
                MessageBox.Show("Lưu thành công!");
                isAdding = false;
                btnGhi.Enabled = false;
                LoadData();
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            isAdding = false;
            btnGhi.Enabled = false;
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}