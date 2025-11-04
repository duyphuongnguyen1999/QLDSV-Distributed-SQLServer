using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmMonHoc : Form
    {
        private DataTable dtMonHoc;
        private bool isAdding = false;

        public frmMonHoc()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.txtSoTietLT = new System.Windows.Forms.TextBox();
            this.txtSoTietTH = new System.Windows.Forms.TextBox();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.SuspendLayout();

            // labels
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Text = "Mã môn học:";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Text = "Tên môn học:";

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Text = "Số tiết LT:";

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 110);
            this.label4.Text = "Số tiết TH:";

            // textboxes
            this.txtMaMH.Location = new System.Drawing.Point(130, 27);
            this.txtMaMH.Size = new System.Drawing.Size(150, 22);
            this.txtMaMH.MaxLength = 10;

            this.txtTenMH.Location = new System.Drawing.Point(130, 67);
            this.txtTenMH.Size = new System.Drawing.Size(400, 22);
            this.txtTenMH.MaxLength = 50;

            this.txtSoTietLT.Location = new System.Drawing.Point(130, 107);
            this.txtSoTietLT.Size = new System.Drawing.Size(100, 22);
            this.txtSoTietLT.Text = "0";

            this.txtSoTietTH.Location = new System.Drawing.Point(330, 107);
            this.txtSoTietTH.Size = new System.Drawing.Size(100, 22);
            this.txtSoTietTH.Text = "0";

            // datagridview
            this.dgvMonHoc.AllowUserToAddRows = false;
            this.dgvMonHoc.AllowUserToDeleteRows = false;
            this.dgvMonHoc.Location = new System.Drawing.Point(30, 200);
            this.dgvMonHoc.Size = new System.Drawing.Size(740, 300);
            this.dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonHoc.MultiSelect = false;
            this.dgvMonHoc.ReadOnly = true;
            this.dgvMonHoc.SelectionChanged += new System.EventHandler(this.dgvMonHoc_SelectionChanged);

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

            // frmMonHoc
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvMonHoc);
            this.Controls.Add(this.txtSoTietTH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoTietLT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaMH);
            this.Controls.Add(this.label1);
            this.Name = "frmMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý môn học";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.TextBox txtSoTietLT;
        private System.Windows.Forms.TextBox txtSoTietTH;
        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private void LoadData()
        {
            string query = "SELECT MAMH, TENMH, SOTIET_LT, SOTIET_TH FROM Monhoc ORDER BY TENMH";
            dtMonHoc = DatabaseConnection.ExecuteQuery(query);
            dgvMonHoc.DataSource = dtMonHoc;

            if (dgvMonHoc.Columns.Count > 0)
            {
                dgvMonHoc.Columns["MAMH"].HeaderText = "Mã môn học";
                dgvMonHoc.Columns["MAMH"].Width = 120;
                dgvMonHoc.Columns["TENMH"].HeaderText = "Tên môn học";
                dgvMonHoc.Columns["TENMH"].Width = 350;
                dgvMonHoc.Columns["SOTIET_LT"].HeaderText = "Số tiết LT";
                dgvMonHoc.Columns["SOTIET_LT"].Width = 100;
                dgvMonHoc.Columns["SOTIET_TH"].HeaderText = "Số tiết TH";
                dgvMonHoc.Columns["SOTIET_TH"].Width = 100;
            }
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (!isAdding && dgvMonHoc.CurrentRow != null)
            {
                txtMaMH.Text = dgvMonHoc.CurrentRow.Cells["MAMH"].Value?.ToString().Trim();
                txtTenMH.Text = dgvMonHoc.CurrentRow.Cells["TENMH"].Value?.ToString();
                txtSoTietLT.Text = dgvMonHoc.CurrentRow.Cells["SOTIET_LT"].Value?.ToString();
                txtSoTietTH.Text = dgvMonHoc.CurrentRow.Cells["SOTIET_TH"].Value?.ToString();

                txtMaMH.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtSoTietLT.Text = "0";
            txtSoTietTH.Text = "0";

            txtMaMH.Enabled = true;
            txtMaMH.Focus();
            btnGhi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa môn học này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maMH = txtMaMH.Text.Trim();
                string query = "DELETE FROM Monhoc WHERE MAMH = @MaMH";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaMH", maMH)
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
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã môn học!", "Thông báo");
                txtMaMH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo");
                txtTenMH.Focus();
                return;
            }

            int soTietLT, soTietTH;
            if (!int.TryParse(txtSoTietLT.Text, out soTietLT) || soTietLT < 0)
            {
                MessageBox.Show("Số tiết lý thuyết không hợp lệ!", "Thông báo");
                txtSoTietLT.Focus();
                return;
            }

            if (!int.TryParse(txtSoTietTH.Text, out soTietTH) || soTietTH < 0)
            {
                MessageBox.Show("Số tiết thực hành không hợp lệ!", "Thông báo");
                txtSoTietTH.Focus();
                return;
            }

            string query;
            if (isAdding)
            {
                query = "INSERT INTO Monhoc (MAMH, TENMH, SOTIET_LT, SOTIET_TH) VALUES (@MaMH, @TenMH, @SoTietLT, @SoTietTH)";
            }
            else
            {
                query = "UPDATE Monhoc SET TENMH = @TenMH, SOTIET_LT = @SoTietLT, SOTIET_TH = @SoTietTH WHERE MAMH = @MaMH";
            }

            SqlParameter[] parameters = {
                new SqlParameter("@MaMH", txtMaMH.Text.Trim()),
                new SqlParameter("@TenMH", txtTenMH.Text.Trim()),
                new SqlParameter("@SoTietLT", soTietLT),
                new SqlParameter("@SoTietTH", soTietTH)
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