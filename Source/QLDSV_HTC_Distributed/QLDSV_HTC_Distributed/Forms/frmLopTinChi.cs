// File: Forms/FrmLopTinChi.cs
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLDSV_HTC_Distributed.Forms
{
    public class frmLopTinChi : Form
    {
        // Top filter/action bar
        Panel pnlTop;
        Label lblNk, lblHk;
        ComboBox cboNienKhoa;
        NumericUpDown numHocKy;
        Button btnLoad, btnAdd, btnEdit, btnSave, btnCancel, btnToggleHuy;

        // Grid
        DataGridView grid;

        // Bottom edit panel
        Panel pnlEdit;
        TextBox txtMALTC, txtNienKhoa, txtMaMH, txtMaGV, txtMaKhoa;
        NumericUpDown numHocKy2, numNhom, numSosvTT;
        CheckBox chkHuyLop;
        Label lbStatus;

        DataTable _table;
        enum EditMode { None, Add, Edit }
        EditMode _mode = EditMode.None;

        string ConnStr
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["QLDSV"]
                      ?? ConfigurationManager.ConnectionStrings["QLDSV_TC"];
                return cs != null ? cs.ConnectionString : "";
            }
        }

        public frmLopTinChi()
        {
            // Form props
            Text = "Quản lý Lớp tín chỉ (MVP)";
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            ClientSize = new Size(980, 620);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            BuildUI();
            WireEvents();
            InitDefaults();
        }

        void BuildUI()
        {
            // ===== Top panel =====
            pnlTop = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.WhiteSmoke };
            lblNk = new Label { Text = "Niên khóa:", AutoSize = true, Left = 12, Top = 20 };
            cboNienKhoa = new ComboBox { Left = 80, Top = 16, Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };

            lblHk = new Label { Text = "Học kỳ:", AutoSize = true, Left = 215, Top = 20 };
            numHocKy = new NumericUpDown { Left = 265, Top = 16, Width = 60, Minimum = 1, Maximum = 4, Value = 1 };

            btnLoad = new Button { Text = "Load", Left = 335, Top = 14, Width = 70 };
            btnAdd = new Button { Text = "Thêm", Left = 415, Top = 14, Width = 70 };
            btnEdit = new Button { Text = "Sửa", Left = 495, Top = 14, Width = 70 };
            btnSave = new Button { Text = "Lưu", Left = 575, Top = 14, Width = 70 };
            btnCancel = new Button { Text = "Hủy thao tác", Left = 655, Top = 14, Width = 100 };
            btnToggleHuy = new Button { Text = "Đánh dấu HỦY/PHỤC HỒI", Left = 765, Top = 14, Width = 190 };

            pnlTop.Controls.AddRange(new Control[] {
                lblNk, cboNienKhoa, lblHk, numHocKy,
                btnLoad, btnAdd, btnEdit, btnSave, btnCancel, btnToggleHuy
            });

            // ===== Grid =====
            grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
            };

            // ===== Bottom edit panel =====
            pnlEdit = new Panel { Dock = DockStyle.Bottom, Height = 180, BorderStyle = BorderStyle.FixedSingle };

            int x = 12, y = 12, w = 90, gapX = 8, colW = 110, rowH = 28, lineGap = 36;

            // Row 1
            pnlEdit.Controls.Add(MakeLabel("MALTC", x, y));
            txtMALTC = MakeTextBox(x + w + gapX, y, 100); txtMALTC.ReadOnly = true;

            pnlEdit.Controls.Add(MakeLabel("Niên khóa", 250, y));
            txtNienKhoa = MakeTextBox(250 + w + gapX, y, 120);

            pnlEdit.Controls.Add(MakeLabel("Học kỳ", 430, y));
            numHocKy2 = MakeNumeric(430 + w + gapX, y, 60, 1, 4, 1);

            pnlEdit.Controls.Add(MakeLabel("MAMH", 520, y));
            txtMaMH = MakeTextBox(520 + w + gapX, y, colW);

            pnlEdit.Controls.Add(MakeLabel("Nhóm", 700, y));
            numNhom = MakeNumeric(700 + w + gapX, y, 70, 1, 99, 1);

            // Row 2
            y += lineGap;
            pnlEdit.Controls.Add(MakeLabel("MAGV", x, y));
            txtMaGV = MakeTextBox(x + w + gapX, y, colW);

            pnlEdit.Controls.Add(MakeLabel("MAKHOA", 250, y));
            txtMaKhoa = MakeTextBox(250 + w + gapX, y, colW);

            pnlEdit.Controls.Add(MakeLabel("Số SV tối thiểu", 430, y));
            numSosvTT = MakeNumeric(430 + w + gapX, y, 90, 0, 1000, 0);

            chkHuyLop = new CheckBox { Text = "Hủy lớp", Left = 700, Top = y + 3, AutoSize = true };
            pnlEdit.Controls.Add(chkHuyLop);

            // Status line
            lbStatus = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 22,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DimGray
            };
            pnlEdit.Controls.Add(lbStatus);

            // Add to Form
            Controls.Add(grid);
            Controls.Add(pnlEdit);
            Controls.Add(pnlTop);
        }

        Label MakeLabel(string text, int left, int top)
        {
            return new Label { Text = text + ":", AutoSize = true, Left = left, Top = top + 4 };
        }

        TextBox MakeTextBox(int left, int top, int width)
        {
            return new TextBox { Left = left, Top = top, Width = width, Height = 24 };
        }

        NumericUpDown MakeNumeric(int left, int top, int width, int min, int max, int val)
        {
            var n = new NumericUpDown { Left = left, Top = top, Width = width, Minimum = min, Maximum = max, Value = val };
            return n;
        }

        void WireEvents()
        {
            btnLoad.Click += btnLoad_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnToggleHuy.Click += btnToggleHuy_Click;

            grid.SelectionChanged += grid_SelectionChanged;

            cboNienKhoa.SelectedIndexChanged += cboNienKhoa_SelectedIndexChanged;
            numHocKy.ValueChanged += numHocKy_ValueChanged;
        }

        void InitDefaults()
        {
            // Năm học mẫu
            cboNienKhoa.Items.Add("2024-2025");
            cboNienKhoa.Items.Add("2025-2026");
            cboNienKhoa.SelectedIndex = 0;

            txtNienKhoa.Text = cboNienKhoa.Text;
            numHocKy2.Value = numHocKy.Value;

            ToggleEdit(false);
        }

        void ToggleEdit(bool on)
        {
            pnlEdit.Enabled = true; // vẫn cho nhập; ta khóa bằng nút
            txtNienKhoa.Enabled = on;
            numHocKy2.Enabled = on;
            txtMaMH.Enabled = on;
            numNhom.Enabled = on;
            txtMaGV.Enabled = on;
            txtMaKhoa.Enabled = on;
            numSosvTT.Enabled = on;
            chkHuyLop.Enabled = on;

            btnSave.Enabled = on;
            btnCancel.Enabled = on;

            btnAdd.Enabled = !on;
            btnEdit.Enabled = !on && grid.CurrentRow != null;
            btnLoad.Enabled = !on;
            btnToggleHuy.Enabled = !on && grid.CurrentRow != null;
        }

        // ======= Actions =======

        void btnLoad_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            string nk = cboNienKhoa.Text;
            int hk = (int)numHocKy.Value;

            string sql = @"
SELECT L.MALTC, L.NIENKHOA, L.HOCKY, L.MAMH, L.NHOM, L.MAGV, L.MAKHOA, L.SOSVTOITHIEU, L.HUYLOP
FROM dbo.LOPTINCHI L
WHERE L.NIENKHOA = @nk AND L.HOCKY = @hk
ORDER BY L.MAMH, L.NHOM;";

            try
            {
                using (var con = new SqlConnection(ConnStr))
                using (var da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@nk", nk);
                    da.SelectCommand.Parameters.AddWithValue("@hk", hk);

                    _table = new DataTable();
                    da.Fill(_table);
                    grid.DataSource = _table;
                }
                lbStatus.Text = "Đã tải " + (_table != null ? _table.Rows.Count : 0) + " lớp tín chỉ.";
                _mode = EditMode.None;
                ToggleEdit(false);
                grid_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải: " + ex.Message);
            }
        }

        void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode != EditMode.None || grid.CurrentRow == null) return;
            var r = grid.CurrentRow.DataBoundItem as DataRowView;
            if (r == null) return;

            txtMALTC.Text = SafeStr(r["MALTC"]);
            txtNienKhoa.Text = SafeStr(r["NIENKHOA"]);
            numHocKy2.Value = SafeInt(r["HOCKY"], 1);
            txtMaMH.Text = SafeStr(r["MAMH"]);
            numNhom.Value = SafeInt(r["NHOM"], 1);
            txtMaGV.Text = SafeStr(r["MAGV"]);
            txtMaKhoa.Text = SafeStr(r["MAKHOA"]);
            numSosvTT.Value = SafeInt(r["SOSVTOITHIEU"], 0);
            chkHuyLop.Checked = SafeBool(r["HUYLOP"]);
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            _mode = EditMode.Add;
            ClearEdit();
            txtNienKhoa.Text = cboNienKhoa.Text;
            numHocKy2.Value = numHocKy.Value;
            ToggleEdit(true);
            txtMaMH.Focus();
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;
            _mode = EditMode.Edit;
            ToggleEdit(true);
            txtMaMH.Focus();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateEdit()) return;

            try
            {
                using (var con = new SqlConnection(ConnStr))
                {
                    con.Open();

                    if (_mode == EditMode.Add)
                    {
                        bool hasMaltc = !string.IsNullOrWhiteSpace(txtMALTC.Text);

                        string sql = hasMaltc
                            ? @"INSERT INTO dbo.LOPTINCHI(MALTC, NIENKHOA, HOCKY, MAMH, NHOM, MAGV, MAKHOA, SOSVTOITHIEU, HUYLOP)
                                VALUES (@MALTC,@NIENKHOA,@HOCKY,@MAMH,@NHOM,@MAGV,@MAKHOA,@SOSVTT,@HUYLOP);"
                            : @"INSERT INTO dbo.LOPTINCHI(NIENKHOA, HOCKY, MAMH, NHOM, MAGV, MAKHOA, SOSVTOITHIEU, HUYLOP)
                                VALUES (@NIENKHOA,@HOCKY,@MAMH,@NHOM,@MAGV,@MAKHOA,@SOSVTT,@HUYLOP);
                                SELECT SCOPE_IDENTITY();";

                        using (var cmd = new SqlCommand(sql, con))
                        {
                            if (hasMaltc)
                                cmd.Parameters.AddWithValue("@MALTC", Convert.ToInt32(txtMALTC.Text));

                            FillParams(cmd);

                            if (hasMaltc)
                            {
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                object newId = cmd.ExecuteScalar();
                                if (newId != null && newId != DBNull.Value)
                                    txtMALTC.Text = Convert.ToInt32(newId).ToString();
                            }
                        }
                        lbStatus.Text = "Đã thêm lớp tín chỉ.";
                    }
                    else if (_mode == EditMode.Edit)
                    {
                        string sql = @"
UPDATE dbo.LOPTINCHI
   SET NIENKHOA=@NIENKHOA, HOCKY=@HOCKY, MAMH=@MAMH, NHOM=@NHOM,
       MAGV=@MAGV, MAKHOA=@MAKHOA, SOSVTOITHIEU=@SOSVTT, HUYLOP=@HUYLOP
 WHERE MALTC=@MALTC;";

                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@MALTC", Convert.ToInt32(txtMALTC.Text));
                            FillParams(cmd);
                            cmd.ExecuteNonQuery();
                        }
                        lbStatus.Text = "Đã cập nhật lớp tín chỉ.";
                    }
                }

                _mode = EditMode.None;
                ToggleEdit(false);
                btnLoad.PerformClick(); // reload
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            _mode = EditMode.None;
            ToggleEdit(false);
            grid_SelectionChanged(null, null);
            lbStatus.Text = "Đã hủy thao tác.";
        }

        void btnToggleHuy_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;
            var r = grid.CurrentRow.DataBoundItem as DataRowView;
            if (r == null) return;

            int maltc = SafeInt(r["MALTC"], 0);
            int newFlag = SafeBool(r["HUYLOP"]) ? 0 : 1;

            try
            {
                using (var con = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("UPDATE dbo.LOPTINCHI SET HUYLOP=@f WHERE MALTC=@id;", con))
                {
                    cmd.Parameters.AddWithValue("@f", newFlag);
                    cmd.Parameters.AddWithValue("@id", maltc);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                lbStatus.Text = newFlag == 1 ? "Đã đánh dấu HỦY lớp." : "Đã PHỤC HỒI lớp.";
                btnLoad.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message);
            }
        }

        void cboNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mode == EditMode.Add) txtNienKhoa.Text = cboNienKhoa.Text;
        }

        void numHocKy_ValueChanged(object sender, EventArgs e)
        {
            if (_mode == EditMode.Add) numHocKy2.Value = numHocKy.Value;
        }

        // ===== Helpers =====
        void ClearEdit()
        {
            txtMALTC.Text = "";
            txtNienKhoa.Text = "";
            numHocKy2.Value = 1;
            txtMaMH.Text = "";
            numNhom.Value = 1;
            txtMaGV.Text = "";
            txtMaKhoa.Text = "";
            numSosvTT.Value = 0;
            chkHuyLop.Checked = false;
        }

        void FillParams(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@NIENKHOA", txtNienKhoa.Text.Trim());
            cmd.Parameters.AddWithValue("@HOCKY", (int)numHocKy2.Value);
            cmd.Parameters.AddWithValue("@MAMH", txtMaMH.Text.Trim());
            cmd.Parameters.AddWithValue("@NHOM", (int)numNhom.Value);
            cmd.Parameters.AddWithValue("@MAGV", txtMaGV.Text.Trim());
            cmd.Parameters.AddWithValue("@MAKHOA", txtMaKhoa.Text.Trim());
            cmd.Parameters.AddWithValue("@SOSVTT", (int)numSosvTT.Value);
            cmd.Parameters.AddWithValue("@HUYLOP", chkHuyLop.Checked ? 1 : 0);
        }

        bool ValidateEdit()
        {
            if (string.IsNullOrWhiteSpace(txtNienKhoa.Text)) { MessageBox.Show("Niên khóa không được trống."); return false; }
            if (string.IsNullOrWhiteSpace(txtMaMH.Text)) { MessageBox.Show("Mã môn học không được trống."); return false; }
            if (string.IsNullOrWhiteSpace(txtMaGV.Text)) { MessageBox.Show("Mã giảng viên không được trống."); return false; }
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text)) { MessageBox.Show("Mã khoa không được trống."); return false; }
            return true;
        }

        string SafeStr(object v) { return v == null || v == DBNull.Value ? "" : v.ToString(); }
        int SafeInt(object v, int def) { try { return v == null || v == DBNull.Value ? def : Convert.ToInt32(v); } catch { return def; } }
        bool SafeBool(object v) { try { return v != null && v != DBNull.Value && Convert.ToBoolean(v); } catch { return false; } }
    }
}
