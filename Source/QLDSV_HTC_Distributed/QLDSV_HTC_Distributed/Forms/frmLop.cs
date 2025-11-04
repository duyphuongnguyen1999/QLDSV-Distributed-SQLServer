using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmLop : Form
    {
        private DataTable dtLop;
        private bool isAdding = false;

        public frmLop()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtKhoaHoc = new System.Windows.Forms.TextBox();
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
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

            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblKhoa.Location = new System.Drawing.Point(300, 10);
            this.lblKhoa.Text = "KHOA: " + DatabaseConnection.CurrentKhoa;

            // textboxes
            this.txtMaLop.Location = new System.Drawing.Point(120, 27);
            this.txtMaLop.Size = new System.Drawing.Size(150, 22);
            this.txtMaLop.MaxLength = 10;

            this.txtTenLop.Location = new System.Drawing.Point(120, 67);
            this.txtTenLop.Size = new System.Drawing.Size(300, 22);
            this.txtTenLop.MaxLength = 50;

            this.txtKhoaHoc.Location = new System.Drawing.Point(120, 107);
            this.txtKhoaHoc.Size = new System.Drawing.Size(150, 22);
            this.txtKhoaHoc.MaxLength = 9;
            this.txtKhoaHoc.Text = "2021-2025";

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

            this.btnGhi.Location = new System.Drawing.Point(230, 150);
            this.btnGhi.Size = new System.Drawing.Size(80, 30);
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Enabled = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);

            this.btnPhucHoi.Location = new System.Drawing.Point(330, 150);
            this.btnPhucHoi.Size = new System.Drawing.Size(80, 30);
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);

            this.btnThoat.Location = new System.Drawing.Point(430, 150);
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmLop
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.btnGhi);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtKhoaHoc;
        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKhoa;

        private void LoadData()
        {
            string query = "SELECT MALOP, TENLOP, KHOAHOC FROM Lop WHERE MAKHOA = @MaKhoa ORDER BY MALOP";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };

            dtLop = DatabaseConnection.ExecuteQuery(query, parameters);
            dgvLop.DataSource = dtLop;

            if (dgvLop.Columns.Count > 0)
            {
                dgvLop.Columns["MALOP"].HeaderText = "Mã lớp";
                dgvLop.Columns["MALOP"].Width = 150;
                dgvLop.Columns["TENLOP"].HeaderText = "Tên lớp";
                dgvLop.Columns["TENLOP"].Width = 350;
                dgvLop.Columns["KHOAHOC"].HeaderText = "Khóa học";
                dgvLop.Columns["KHOAHOC"].Width = 150;
            }
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e)
        {
            if (!isAdding && dgvLop.CurrentRow != null)
            {
                txtMaLop.Text = dgvLop.CurrentRow.Cells["MALOP"].Value?.ToString().Trim();
                txtTenLop.Text = dgvLop.CurrentRow.Cells["TENLOP"].Value?.ToString();
                txtKhoaHoc.Text = dgvLop.CurrentRow.Cells["KHOAHOC"].Value?.ToString().Trim();

                txtMaLop.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtKhoaHoc.Text = "2021-2025";

            txtMaLop.Enabled = true;
            txtMaLop.Focus();
            btnGhi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maLop = txtMaLop.Text.Trim();
                string query = "DELETE FROM Lop WHERE MALOP = @MaLop";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaLop", maLop)
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
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp!", "Thông báo");
                txtMaLop.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo");
                txtTenLop.Focus();
                return;
            }

            string query;
            if (isAdding)
            {
                query = "INSERT INTO Lop (MALOP, TENLOP, KHOAHOC, MAKHOA) VALUES (@MaLop, @TenLop, @KhoaHoc, @MaKhoa)";
            }
            else
            {
                query = "UPDATE Lop SET TENLOP = @TenLop, KHOAHOC = @KhoaHoc WHERE MALOP = @MaLop";
            }

            SqlParameter[] parameters = {
                new SqlParameter("@MaLop", txtMaLop.Text.Trim()),
                new SqlParameter("@TenLop", txtTenLop.Text.Trim()),
                new SqlParameter("@KhoaHoc", txtKhoaHoc.Text.Trim()),
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
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

            if (dgvLop.Rows.Count > 0)
                dgvLop.Rows[0].Selected = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}