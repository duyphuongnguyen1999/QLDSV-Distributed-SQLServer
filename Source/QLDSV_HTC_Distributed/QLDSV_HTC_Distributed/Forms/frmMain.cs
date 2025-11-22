using System;
using System.Windows.Forms;

namespace QLDSV_HTC {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
            LoadMenuByRole();          // Ẩn menu theo quyền ban đầu
            UpdateStatusBar();
        }

        private void InitializeComponent() {
            #region Init Control objects

            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapLop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoLopTinChi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangKyLTC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDongHocPhi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInAn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSLopTinChi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSSVDangKy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSHocPhi = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbSite = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            #endregion // Init Control objects

            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
                    this.mnuHeThong,
                    this.mnuNhapLieu,
                    this.mnuInAn
                }
            );
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 1;
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
                    this.mnuDangXuat,
                    this.mnuThoat
                }
            );
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(85, 24);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(224, 26);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(224, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuNhapLieu
            // 
            this.mnuNhapLieu.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
                    this.mnuNhapLop,
                    this.mnuNhapSinhVien,
                    this.mnuNhapMonHoc,
                    this.mnuMoLopTinChi,
                    this.mnuDangKyLTC,
                    this.mnuNhapDiem,
                    this.mnuDongHocPhi
                }
            );
            this.mnuNhapLieu.Name = "mnuNhapLieu";
            this.mnuNhapLieu.Size = new System.Drawing.Size(87, 24);
            this.mnuNhapLieu.Text = "Nhập liệu";
            // 
            // mnuNhapLop
            // 
            this.mnuNhapLop.Name = "mnuNhapLop";
            this.mnuNhapLop.Size = new System.Drawing.Size(224, 26);
            this.mnuNhapLop.Text = "Nhập lớp";
            this.mnuNhapLop.Click += new System.EventHandler(this.mnuNhapLop_Click);
            // 
            // mnuNhapSinhVien
            // 
            this.mnuNhapSinhVien.Name = "mnuNhapSinhVien";
            this.mnuNhapSinhVien.Size = new System.Drawing.Size(224, 26);
            this.mnuNhapSinhVien.Text = "Nhập sinh viên";
            this.mnuNhapSinhVien.Click += new System.EventHandler(this.mnuNhapSinhVien_Click);
            // 
            // mnuNhapMonHoc
            // 
            this.mnuNhapMonHoc.Name = "mnuNhapMonHoc";
            this.mnuNhapMonHoc.Size = new System.Drawing.Size(224, 26);
            this.mnuNhapMonHoc.Text = "Nhập môn học";
            this.mnuNhapMonHoc.Click += new System.EventHandler(this.mnuNhapMonHoc_Click);
            // 
            // mnuMoLopTinChi
            // 
            this.mnuMoLopTinChi.Name = "mnuMoLopTinChi";
            this.mnuMoLopTinChi.Size = new System.Drawing.Size(224, 26);
            this.mnuMoLopTinChi.Text = "Mở lớp tín chỉ";
            this.mnuMoLopTinChi.Click += new System.EventHandler(this.mnuMoLopTinChi_Click);
            // 
            // mnuDangKyLTC
            // 
            this.mnuDangKyLTC.Name = "mnuDangKyLTC";
            this.mnuDangKyLTC.Size = new System.Drawing.Size(224, 26);
            this.mnuDangKyLTC.Text = "Đăng ký lớp tín chỉ";
            this.mnuDangKyLTC.Click += new System.EventHandler(this.mnuDangKyLTC_Click);
            // 
            // mnuNhapDiem
            // 
            this.mnuNhapDiem.Name = "mnuNhapDiem";
            this.mnuNhapDiem.Size = new System.Drawing.Size(224, 26);
            this.mnuNhapDiem.Text = "Nhập điểm";
            this.mnuNhapDiem.Click += new System.EventHandler(this.mnuNhapDiem_Click);
            // 
            // mnuDongHocPhi
            // 
            this.mnuDongHocPhi.Name = "mnuDongHocPhi";
            this.mnuDongHocPhi.Size = new System.Drawing.Size(224, 26);
            this.mnuDongHocPhi.Text = "Đóng học phí";
            this.mnuDongHocPhi.Click += new System.EventHandler(this.mnuDongHocPhi_Click);
            // 
            // mnuInAn
            // 
            this.mnuInAn.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
                    this.mnuDSLopTinChi,
                    this.mnuDSSVDangKy,
                    this.mnuBangDiem,
                    this.mnuPhieuDiem,
                    this.mnuDSHocPhi
                }
            );
            this.mnuInAn.Name = "mnuInAn";
            this.mnuInAn.Size = new System.Drawing.Size(55, 24);
            this.mnuInAn.Text = "In ấn";
            // 
            // mnuDSLopTinChi
            // 
            this.mnuDSLopTinChi.Name = "mnuDSLopTinChi";
            this.mnuDSLopTinChi.Size = new System.Drawing.Size(228, 26);
            this.mnuDSLopTinChi.Text = "DS lớp tín chỉ";
            this.mnuDSLopTinChi.Click += new System.EventHandler(this.mnuDSLopTinChi_Click);
            // 
            // mnuDSSVDangKy
            // 
            this.mnuDSSVDangKy.Name = "mnuDSSVDangKy";
            this.mnuDSSVDangKy.Size = new System.Drawing.Size(228, 26);
            this.mnuDSSVDangKy.Text = "DS sinh viên đăng ký";
            this.mnuDSSVDangKy.Click += new System.EventHandler(this.mnuDSSVDangKy_Click);
            // 
            // mnuBangDiem
            // 
            this.mnuBangDiem.Name = "mnuBangDiem";
            this.mnuBangDiem.Size = new System.Drawing.Size(228, 26);
            this.mnuBangDiem.Text = "Bảng điểm môn học";
            this.mnuBangDiem.Click += new System.EventHandler(this.mnuBangDiem_Click);

            // 
            // mnuPhieuDiem
            // 
            this.mnuPhieuDiem.Name = "mnuPhieuDiem";
            this.mnuPhieuDiem.Size = new System.Drawing.Size(228, 26);
            this.mnuPhieuDiem.Text = "Phiếu điểm";
            this.mnuPhieuDiem.Click += new System.EventHandler(this.mnuPhieuDiem_Click);

            // 
            // mnuDSHocPhi
            // 
            this.mnuDSHocPhi.Name = "mnuDSHocPhi";
            this.mnuDSHocPhi.Size = new System.Drawing.Size(228, 26);
            this.mnuDSHocPhi.Text = "DS đóng học phí";
            this.mnuDSHocPhi.Click += new System.EventHandler(this.mnuDSHocPhi_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(250, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(691, 29);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM SINH VIÊN THEO HỆ TÍN CHỈ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
                    this.sbRole,
                    this.sbSite
                }
            );
            this.statusStrip1.Location = new System.Drawing.Point(0, 778);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbRole
            // 
            this.sbRole.Name = "sbRole";
            this.sbRole.Size = new System.Drawing.Size(200, 16);
            // 
            // sbSite
            // 
            this.sbSite.Name = "sbSite";
            this.sbSite.Size = new System.Drawing.Size(200, 16);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý điểm sinh viên";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapLop;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuMoLopTinChi;
        private System.Windows.Forms.ToolStripMenuItem mnuDangKyLTC;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuDongHocPhi;
        private System.Windows.Forms.ToolStripMenuItem mnuInAn;
        private System.Windows.Forms.ToolStripMenuItem mnuDSLopTinChi;
        private System.Windows.Forms.ToolStripMenuItem mnuDSSVDangKy;
        private System.Windows.Forms.ToolStripMenuItem mnuBangDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuPhieuDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuDSHocPhi;
        private System.Windows.Forms.Label lblWelcome;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel sbRole;
        private ToolStripStatusLabel sbSite;

        #region Config MenuStrip

        #region Config MenuStrip Hệ thống
        private void mnuDangXuat_Click(object sender, EventArgs e) {
            this.Hide();
            // Reset login information
            DatabaseConnection.UserRole = "";
            DatabaseConnection.CurrentKhoa = "";
            // Open Login form
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            this.Close();

        }

        private void mnuThoat_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        #endregion

        #region Config MenuStrip Nhập liệu

        private void mnuDongHocPhi_Click(object sender, EventArgs e) {
            this.Hide();
            frmDongHocPhi frmDongHoc = new frmDongHocPhi();
            frmDongHoc.ShowDialog();
            this.Close();
        }

        private void mnuNhapDiem_Click(object sender, EventArgs e) {
            this.Hide();
            frmNhapDiem frmNhap = new frmNhapDiem();
            frmNhap.ShowDialog();
            this.Close();
        }

        private void mnuDangKyLTC_Click(object sender, EventArgs e) {
            this.Hide();
            frmDangKyLTC frmDangKy = new frmDangKyLTC();
            frmDangKy.ShowDialog();
            this.Close();
        }

        private void mnuMoLopTinChi_Click(object sender, EventArgs e) {
            this.Hide();
            frmLopTinChi frmLopTinChi = new frmLopTinChi();
            frmLopTinChi.ShowDialog();
            this.Close();
        }

        private void mnuNhapMonHoc_Click(object sender, EventArgs e) {
            this.Hide();
            frmMonHoc frmMonHoc = new frmMonHoc();
            frmMonHoc.ShowDialog();
            this.Close();
        }

        private void mnuNhapSinhVien_Click(object sender, EventArgs e) {
            this.Hide();
            frmSinhVien frmSinhVien = new frmSinhVien();
            frmSinhVien.ShowDialog();
            this.Close();
        }

        private void mnuNhapLop_Click(object sender, EventArgs e) {
            this.Hide();
            frmLop frm = new frmLop();
            frm.ShowDialog();
            this.Close();
        }

        #endregion // Config MenuStrip Nhập liêu

        #region Config MenuStrip In ấn

        private void mnuPhieuDiem_Click(object sender, EventArgs e) {
            this.Hide();
            frmPhieuDiem frm = new frmPhieuDiem();
            frm.ShowDialog();
            this.Close();
        }

        private void mnuDSHocPhi_Click(object sender, EventArgs e) {
            this.Hide();
            frmInDSDongHocPhi frm = new frmInDSDongHocPhi();
            frm.ShowDialog();
            this.Close();
        }

        private void mnuBangDiem_Click(object sender, EventArgs e) {
            this.Hide();
            frmInBangDiem frm = new frmInBangDiem();
            frm.ShowDialog();
            this.Close();
        }

        private void mnuDSSVDangKy_Click(object sender, EventArgs e) {
            this.Hide();
            frmInDSSVDangKy frm = new frmInDSSVDangKy();
            frm.ShowDialog();
            this.Close();
        }

        private void mnuDSLopTinChi_Click(object sender, EventArgs e) {
            this.Hide();
            frmInDanhSachLTC frm = new frmInDanhSachLTC();
            frm.ShowDialog();
            this.Close();
        }

        #endregion // Config MenuStrip In ấn

        #endregion // Config MainMenuStrip

        #region Logic + phân quyền

        public void LoadMenuByRole() {
            bool isLoggedIn = !string.IsNullOrEmpty(DatabaseConnection.UserRole);

            // Disable all ToolStripItem
            foreach (ToolStripMenuItem item in this.MainMenuStrip.Items) {
                foreach (ToolStripItem subItem in item.DropDownItems)
                    subItem.Enabled = false;
            }

            if (!isLoggedIn)
                return;

            // Enable specifies Menu and MenuItem
            string role = DatabaseConnection.UserRole;
            EnableMenu("Hệ thống");

            if (role == "PGV" || role == "KHOA") {
                EnableMenuSubItem(
                    mnuNhapLieu,
                    "Nhập lớp", "Nhập sinh viên", "Nhập môn học",
                    "Mở lớp tín chỉ", "Đăng ký lớp tín chỉ", "Nhập điểm"
                );
                EnableMenuSubItem(
                    mnuInAn,
                    "DS lớp tín chỉ", "DS sinh viên đăng ký",
                    "Bảng điểm môn học", "Phiếu điểm"
                );

            }
            if (role == "SV") {
                EnableMenuSubItem(mnuNhapLieu, "Đăng ký lớp tín chỉ");
                EnableMenuSubItem(mnuInAn, "Phiếu điểm");
            }
            if (role == "PKT") {
                EnableMenuSubItem(mnuNhapLieu, "Đóng học phí");
                EnableMenuSubItem(mnuInAn, "DS đóng học phí");
            }
        }

        private void EnableMenu(params string[] menuNames) {
            foreach (var name in menuNames) {
                foreach (ToolStripMenuItem item in this.menuStrip1.Items) {
                    if (item.Text == name)
                        foreach (ToolStripItem subItem in item.DropDownItems)
                            subItem.Enabled = true;
                }
            }
        }

        private void EnableMenuSubItem(ToolStripMenuItem item, params string[] itemName) {
            foreach (var name in itemName) {
                foreach (ToolStripMenuItem subItem in item.DropDownItems) {
                    if (subItem.Text == name) {
                        subItem.Enabled = true;
                    }
                }
            }
        }
        private void UpdateStatusBar() {
            sbRole.Text = "Vai trò: " + (string.IsNullOrEmpty(DatabaseConnection.UserRole) ? "-" : DatabaseConnection.UserRole);
            if (!DatabaseConnection.UserRole.StartsWith("KHOA"))
                sbSite.Text = "";
            else
                sbSite.Text = "Khoa: " + (string.IsNullOrEmpty(DatabaseConnection.CurrentKhoa) ? "-" : DatabaseConnection.CurrentKhoa);
        }

        #endregion
    }
}
