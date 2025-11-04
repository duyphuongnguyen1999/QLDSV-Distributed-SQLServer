using QLDSV_HTC_Distributed.Forms;
using System;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SetupMenu();
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // menuStrip1
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuHeThong,
                this.mnuNhapLieu,
                this.mnuInAn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);

            // mnuHeThong
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuDangXuat,
                this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(69, 20);
            this.mnuHeThong.Text = "Hệ thống";

            // mnuDangXuat
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(180, 22);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);

            // mnuThoat
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(180, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);

            // mnuNhapLieu
            this.mnuNhapLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuNhapLop,
                this.mnuNhapSinhVien,
                this.mnuNhapMonHoc,
                this.mnuMoLopTinChi,
                this.mnuDangKyLTC,
                this.mnuNhapDiem,
                this.mnuDongHocPhi});
            this.mnuNhapLieu.Name = "mnuNhapLieu";
            this.mnuNhapLieu.Size = new System.Drawing.Size(73, 20);
            this.mnuNhapLieu.Text = "Nhập liệu";

            // mnuNhapLop
            this.mnuNhapLop.Name = "mnuNhapLop";
            this.mnuNhapLop.Size = new System.Drawing.Size(180, 22);
            this.mnuNhapLop.Text = "Nhập lớp";
            this.mnuNhapLop.Click += new System.EventHandler(this.mnuNhapLop_Click);

            // mnuNhapSinhVien
            this.mnuNhapSinhVien.Name = "mnuNhapSinhVien";
            this.mnuNhapSinhVien.Size = new System.Drawing.Size(180, 22);
            this.mnuNhapSinhVien.Text = "Nhập sinh viên";
            this.mnuNhapSinhVien.Click += new System.EventHandler(this.mnuNhapSinhVien_Click);

            // mnuNhapMonHoc
            this.mnuNhapMonHoc.Name = "mnuNhapMonHoc";
            this.mnuNhapMonHoc.Size = new System.Drawing.Size(180, 22);
            this.mnuNhapMonHoc.Text = "Nhập môn học";
            this.mnuNhapMonHoc.Click += new System.EventHandler(this.mnuNhapMonHoc_Click);

            // mnuMoLopTinChi
            this.mnuMoLopTinChi.Name = "mnuMoLopTinChi";
            this.mnuMoLopTinChi.Size = new System.Drawing.Size(180, 22);
            this.mnuMoLopTinChi.Text = "Mở lớp tín chỉ";
            this.mnuMoLopTinChi.Click += new System.EventHandler(this.mnuMoLopTinChi_Click);

            // mnuDangKyLTC
            this.mnuDangKyLTC.Name = "mnuDangKyLTC";
            this.mnuDangKyLTC.Size = new System.Drawing.Size(180, 22);
            this.mnuDangKyLTC.Text = "Đăng ký lớp tín chỉ";
            this.mnuDangKyLTC.Click += new System.EventHandler(this.mnuDangKyLTC_Click);

            // mnuNhapDiem
            this.mnuNhapDiem.Name = "mnuNhapDiem";
            this.mnuNhapDiem.Size = new System.Drawing.Size(180, 22);
            this.mnuNhapDiem.Text = "Nhập điểm";
            this.mnuNhapDiem.Click += new System.EventHandler(this.mnuNhapDiem_Click);

            // mnuDongHocPhi
            this.mnuDongHocPhi.Name = "mnuDongHocPhi";
            this.mnuDongHocPhi.Size = new System.Drawing.Size(180, 22);
            this.mnuDongHocPhi.Text = "Đóng học phí";
            this.mnuDongHocPhi.Click += new System.EventHandler(this.mnuDongHocPhi_Click);

            // mnuInAn
            this.mnuInAn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuDSLopTinChi,
                this.mnuDSSVDangKy,
                this.mnuBangDiem,
                this.mnuPhieuDiem,
                this.mnuDSHocPhi});
            this.mnuInAn.Name = "mnuInAn";
            this.mnuInAn.Size = new System.Drawing.Size(48, 20);
            this.mnuInAn.Text = "In ấn";

            // mnuDSLopTinChi
            this.mnuDSLopTinChi.Name = "mnuDSLopTinChi";
            this.mnuDSLopTinChi.Size = new System.Drawing.Size(220, 22);
            this.mnuDSLopTinChi.Text = "DS lớp tín chỉ";

            // mnuDSSVDangKy
            this.mnuDSSVDangKy.Name = "mnuDSSVDangKy";
            this.mnuDSSVDangKy.Size = new System.Drawing.Size(220, 22);
            this.mnuDSSVDangKy.Text = "DS sinh viên đăng ký";

            // mnuBangDiem
            this.mnuBangDiem.Name = "mnuBangDiem";
            this.mnuBangDiem.Size = new System.Drawing.Size(220, 22);
            this.mnuBangDiem.Text = "Bảng điểm môn học";

            // mnuPhieuDiem
            this.mnuPhieuDiem.Name = "mnuPhieuDiem";
            this.mnuPhieuDiem.Size = new System.Drawing.Size(220, 22);
            this.mnuPhieuDiem.Text = "Phiếu điểm";

            // mnuDSHocPhi
            this.mnuDSHocPhi.Name = "mnuDSHocPhi";
            this.mnuDSHocPhi.Size = new System.Drawing.Size(220, 22);
            this.mnuDSHocPhi.Text = "DS đóng học phí";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(250, 200);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(500, 24);
            this.lblWelcome.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM SINH VIÊN THEO HỆ TÍN CHỈ";

            // frmMain
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý điểm sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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

        private void SetupMenu()
        {
            string role = DatabaseConnection.UserRole;

            // Phân quyền menu
            if (role == "SV")
            {
                mnuNhapLieu.Visible = false;
                mnuInAn.Visible = false;

                // SV chỉ được đăng ký và xem điểm
                mnuNhapLieu.DropDownItems.Clear();
                mnuNhapLieu.DropDownItems.Add(mnuDangKyLTC);
                mnuNhapLieu.Visible = true;

                mnuInAn.DropDownItems.Clear();
                mnuInAn.DropDownItems.Add(mnuPhieuDiem);
                mnuInAn.Visible = true;
            }
            else if (role == "PKT")
            {
                mnuNhapLieu.DropDownItems.Clear();
                mnuNhapLieu.DropDownItems.Add(mnuDongHocPhi);

                mnuInAn.DropDownItems.Clear();
                mnuInAn.DropDownItems.Add(mnuDSHocPhi);
            }
        }

        private void mnuNhapLop_Click(object sender, EventArgs e)
        {
            frmLop frm = new frmLop();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuNhapSinhVien_Click(object sender, EventArgs e)
        {
            frmSinhVien frm = new frmSinhVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuNhapMonHoc_Click(object sender, EventArgs e)
        {
            frmMonHoc frm = new frmMonHoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuMoLopTinChi_Click(object sender, EventArgs e)
        {
            frmLopTinChi frm = new frmLopTinChi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDangKyLTC_Click(object sender, EventArgs e)
        {
            frmDangKyLTC frm = new frmDangKyLTC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuNhapDiem_Click(object sender, EventArgs e)
        {
            frmNhapDiem frm = new frmNhapDiem();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDongHocPhi_Click(object sender, EventArgs e)
        {
            frmDongHocPhi frm = new frmDongHocPhi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}