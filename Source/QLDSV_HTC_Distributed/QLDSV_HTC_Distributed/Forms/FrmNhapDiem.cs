using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmNhapDiem : Form
    {
        private DataTable dtDiem;
        private bool isModified = false;

        public frmNhapDiem()
        {
            InitializeComponent();
            LoadMonHoc();
        }

        private void InitializeComponent()
        {
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.txtHocKy = new System.Windows.Forms.TextBox();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.txtNhom = new System.Windows.Forms.TextBox();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnGhiDiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // groupBox1
            this.groupBox1.Controls.Add(this.btnBatDau);
            this.groupBox1.Controls.Add(this.txtNhom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboMonHoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHocKy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNienKhoa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 50);
            this.groupBox1.Size = new System.Drawing.Size(900, 120);
            this.groupBox1.Text = "Thông tin lớp tín chỉ";

            // lblKhoa
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblKhoa.Location = new System.Drawing.Point(400, 15);
            this.lblKhoa.Text = "KHOA: " + DatabaseConnection.CurrentKhoa;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Text = "Niên khóa:";

            // txtNienKhoa
            this.txtNienKhoa.Location = new System.Drawing.Point(100, 32);
            this.txtNienKhoa.Size = new System.Drawing.Size(100, 22);
            this.txtNienKhoa.MaxLength = 9;
            this.txtNienKhoa.Text = "2024-2025";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 35);
            this.label2.Text = "Học kỳ:";

            // txtHocKy
            this.txtHocKy.Location = new System.Drawing.Point(290, 32);
            this.txtHocKy.Size = new System.Drawing.Size(60, 22);
            this.txtHocKy.MaxLength = 1;
            this.txtHocKy.Text = "1";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Text = "Môn học:";

            // cboMonHoc
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.Location = new System.Drawing.Point(100, 72);
            this.cboMonHoc.Size = new System.Drawing.Size(350, 24);

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 75);
            this.label4.Text = "Nhóm:";

            // txtNhom
            this.txtNhom.Location = new System.Drawing.Point(530, 72);
            this.txtNhom.Size = new System.Drawing.Size(60, 22);
            this.txtNhom.MaxLength = 2;
            this.txtNhom.Text = "1";

            // btnBatDau
            this.btnBatDau.Location = new System.Drawing.Point(620, 70);
            this.btnBatDau.Size = new System.Drawing.Size(100, 26);
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);

            // dgvDiem
            this.dgvDiem.Location = new System.Drawing.Point(20, 190);
            this.dgvDiem.Size = new System.Drawing.Size(900, 330);
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDiem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellValueChanged);

            // btnGhiDiem
            this.btnGhiDiem.Location = new System.Drawing.Point(350, 540);
            this.btnGhiDiem.Size = new System.Drawing.Size(100, 35);
            this.btnGhiDiem.Text = "Ghi điểm";
            this.btnGhiDiem.Enabled = false;
            this.btnGhiDiem.Click += new System.EventHandler(this.btnGhiDiem_Click);

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(470, 540);
            this.btnThoat.Size = new System.Drawing.Size(100, 35);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmNhapDiem
            this.ClientSize = new System.Drawing.Size(940, 600);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnGhiDiem);
            this.Controls.Add(this.dgvDiem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblKhoa);
            this.Name = "frmNhapDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập điểm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNienKhoa;
        private System.Windows.Forms.TextBox txtHocKy;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.TextBox txtNhom;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnGhiDiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKhoa;

        private void LoadMonHoc()
        {
            string query = "SELECT MAMH, TENMH FROM Monhoc ORDER BY TENMH";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cboMonHoc.DataSource = dt;
            cboMonHoc.DisplayMember = "TENMH";
            cboMonHoc.ValueMember = "MAMH";
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Thông báo");
                return;
            }

            // Lấy mã lớp tín chỉ
            string query = @"SELECT MALTC FROM Loptinchi 
                           WHERE NIENKHOA = @NienKhoa 
                           AND HOCKY = @HocKy 
                           AND MAMH = @MaMH 
                           AND NHOM = @Nhom
                           AND MAKHOA = @MaKhoa
                           AND HUYLOP = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@NienKhoa", txtNienKhoa.Text.Trim()),
                new SqlParameter("@HocKy", int.Parse(txtHocKy.Text)),
                new SqlParameter("@MaMH", cboMonHoc.SelectedValue.ToString()),
                new SqlParameter("@Nhom", int.Parse(txtNhom.Text)),
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };

            DataTable dtLTC = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dtLTC.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lớp tín chỉ!", "Thông báo");
                return;
            }

            int maLTC = Convert.ToInt32(dtLTC.Rows[0]["MALTC"]);

            // Lấy danh sách sinh viên đăng ký
            query = @"SELECT 
                        sv.MASV,
                        sv.HO + ' ' + sv.TEN AS HOTEN,
                        dk.DIEM_CC,
                        dk.DIEM_GK,
                        dk.DIEM_CK,
                        CASE 
                            WHEN dk.DIEM_CC IS NOT NULL AND dk.DIEM_GK IS NOT NULL AND dk.DIEM_CK IS NOT NULL
                            THEN ROUND(dk.DIEM_CC * 0.1 + dk.DIEM_GK * 0.3 + dk.DIEM_CK * 0.6, 1)
                            ELSE NULL
                        END AS DIEM_HETMON
                      FROM Dangky dk
                      JOIN Sinhvien sv ON dk.MASV = sv.MASV
                      WHERE dk.MALTC = @MaLTC AND dk.HUYDANGKY = 0
                      ORDER BY sv.TEN, sv.HO";

            SqlParameter[] params2 = {
                new SqlParameter("@MaLTC", maLTC)
            };

            dtDiem = DatabaseConnection.ExecuteQuery(query, params2);
            dgvDiem.DataSource = dtDiem;

            if (dgvDiem.Columns.Count > 0)
            {
                dgvDiem.Columns["MASV"].HeaderText = "Mã SV";
                dgvDiem.Columns["MASV"].Width = 100;
                dgvDiem.Columns["MASV"].ReadOnly = true;

                dgvDiem.Columns["HOTEN"].HeaderText = "Họ tên SV";
                dgvDiem.Columns["HOTEN"].Width = 250;
                dgvDiem.Columns["HOTEN"].ReadOnly = true;

                dgvDiem.Columns["DIEM_CC"].HeaderText = "Điểm chuyên cần";
                dgvDiem.Columns["DIEM_CC"].Width = 120;

                dgvDiem.Columns["DIEM_GK"].HeaderText = "Điểm giữa kỳ";
                dgvDiem.Columns["DIEM_GK"].Width = 120;

                dgvDiem.Columns["DIEM_CK"].HeaderText = "Điểm cuối kỳ";
                dgvDiem.Columns["DIEM_CK"].Width = 120;

                dgvDiem.Columns["DIEM_HETMON"].HeaderText = "Điểm hết môn";
                dgvDiem.Columns["DIEM_HETMON"].Width = 120;
                dgvDiem.Columns["DIEM_HETMON"].ReadOnly = true;
                dgvDiem.Columns["DIEM_HETMON"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            }

            btnGhiDiem.Enabled = true;
            isModified = false;
        }

        private void dgvDiem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            isModified = true;

            // Tự động tính điểm hết môn
            DataGridViewRow row = dgvDiem.Rows[e.RowIndex];

            object cc = row.Cells["DIEM_CC"].Value;
            object gk = row.Cells["DIEM_GK"].Value;
            object ck = row.Cells["DIEM_CK"].Value;

            if (cc != DBNull.Value && gk != DBNull.Value && ck != DBNull.Value)
            {
                try
                {
                    double diemCC = Convert.ToDouble(cc);
                    double diemGK = Convert.ToDouble(gk);
                    double diemCK = Convert.ToDouble(ck);

                    double diemHetMon = Math.Round(diemCC * 0.1 + diemGK * 0.3 + diemCK * 0.6, 1);
                    row.Cells["DIEM_HETMON"].Value = diemHetMon;
                }
                catch { }
            }
        }

        private void btnGhiDiem_Click(object sender, EventArgs e)
        {
            if (!isModified)
            {
                MessageBox.Show("Không có thay đổi nào để lưu!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn lưu điểm?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Lấy mã lớp tín chỉ
            string query = @"SELECT MALTC FROM Loptinchi 
                           WHERE NIENKHOA = @NienKhoa 
                           AND HOCKY = @HocKy 
                           AND MAMH = @MaMH 
                           AND NHOM = @Nhom
                           AND MAKHOA = @MaKhoa";

            SqlParameter[] parameters = {
                new SqlParameter("@NienKhoa", txtNienKhoa.Text.Trim()),
                new SqlParameter("@HocKy", int.Parse(txtHocKy.Text)),
                new SqlParameter("@MaMH", cboMonHoc.SelectedValue.ToString()),
                new SqlParameter("@Nhom", int.Parse(txtNhom.Text)),
                new SqlParameter("@MaKhoa", DatabaseConnection.CurrentKhoa)
            };

            DataTable dtLTC = DatabaseConnection.ExecuteQuery(query, parameters);
            int maLTC = Convert.ToInt32(dtLTC.Rows[0]["MALTC"]);

            // Cập nhật điểm cho từng sinh viên
            int count = 0;
            foreach (DataGridViewRow row in dgvDiem.Rows)
            {
                string maSV = row.Cells["MASV"].Value.ToString().Trim();

                object cc = row.Cells["DIEM_CC"].Value;
                object gk = row.Cells["DIEM_GK"].Value;
                object ck = row.Cells["DIEM_CK"].Value;

                string updateQuery = @"UPDATE Dangky 
                                     SET DIEM_CC = @DiemCC, 
                                         DIEM_GK = @DiemGK, 
                                         DIEM_CK = @DiemCK
                                     WHERE MALTC = @MaLTC AND MASV = @MaSV";

                SqlParameter[] updateParams = {
                    new SqlParameter("@DiemCC", cc == DBNull.Value ? (object)DBNull.Value : cc),
                    new SqlParameter("@DiemGK", gk == DBNull.Value ? (object)DBNull.Value : gk),
                    new SqlParameter("@DiemCK", ck == DBNull.Value ? (object)DBNull.Value : ck),
                    new SqlParameter("@MaLTC", maLTC),
                    new SqlParameter("@MaSV", maSV)
                };

                if (DatabaseConnection.ExecuteNonQuery(updateQuery, updateParams))
                    count++;
            }

            MessageBox.Show($"Đã lưu điểm cho {count} sinh viên!", "Thành công");
            isModified = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (isModified)
            {
                if (MessageBox.Show("Có thay đổi chưa được lưu. Bạn có muốn thoát?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            this.Close();
        }
    }
}