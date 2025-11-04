using System;
using System.Globalization;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    /// <summary>
    /// Class chứa các hàm tiện ích dùng chung
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Format số tiền theo định dạng Việt Nam
        /// </summary>
        public static string FormatMoney(decimal amount)
        {
            return amount.ToString("N0", new CultureInfo("vi-VN")) + " đ";
        }

        /// <summary>
        /// Format số tiền từ int
        /// </summary>
        public static string FormatMoney(int amount)
        {
            return FormatMoney((decimal)amount);
        }

        /// <summary>
        /// Chuyển số tiền thành chữ
        /// </summary>
        public static string NumberToText(long number)
        {
            if (number == 0)
                return "Không đồng";

            string[] mangSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] mangDonVi = { "", "nghìn", "triệu", "tỷ" };

            string ketQua = "";
            int donVi = 0;

            while (number > 0)
            {
                int baSo = (int)(number % 1000);
                if (baSo > 0)
                {
                    string chuoiBaSo = DocBaSo(baSo, mangSo);
                    ketQua = chuoiBaSo + " " + mangDonVi[donVi] + " " + ketQua;
                }
                number /= 1000;
                donVi++;
            }

            ketQua = ketQua.Trim() + " đồng";
            // Viết hoa chữ cái đầu
            if (ketQua.Length > 0)
            {
                ketQua = char.ToUpper(ketQua[0]) + ketQua.Substring(1);
            }

            return ketQua;
        }

        private static string DocBaSo(int number, string[] mangSo)
        {
            int tram = number / 100;
            int chuc = (number % 100) / 10;
            int donVi = number % 10;

            string ketQua = "";

            if (tram > 0)
            {
                ketQua = mangSo[tram] + " trăm ";
                if ((chuc == 0) && (donVi > 0))
                    ketQua += "linh ";
            }

            if ((chuc > 1))
            {
                ketQua += mangSo[chuc] + " mươi ";
                if ((chuc > 0) && (donVi == 1))
                    ketQua += "mốt ";
            }
            else if (chuc == 1)
            {
                ketQua += "mười ";
                if (donVi == 1)
                    ketQua = ketQua.Replace("mười ", "mười một ");
            }

            if ((donVi > 1) || (donVi == 1 && chuc == 0))
                ketQua += mangSo[donVi] + " ";
            else if (donVi == 5 && chuc >= 1)
                ketQua += "lăm ";

            return ketQua.Trim();
        }

        /// <summary>
        /// Validate số tiền nhập vào
        /// </summary>
        public static bool ValidateMoney(string input, out int value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (!int.TryParse(input.Replace(",", "").Replace(".", ""), out value))
                return false;

            return value >= 0;
        }

        /// <summary>
        /// Validate điểm số
        /// </summary>
        public static bool ValidateDiem(string input, out double value, double min = 0, double max = 10)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(input))
                return true; // Cho phép để trống

            if (!double.TryParse(input, out value))
                return false;

            return value >= min && value <= max;
        }

        /// <summary>
        /// Hiển thị thông báo lỗi
        /// </summary>
        public static void ShowError(string message, string title = "Lỗi")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Hiển thị thông báo thông tin
        /// </summary>
        public static void ShowInfo(string message, string title = "Thông báo")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Hiển thị thông báo cảnh báo
        /// </summary>
        public static void ShowWarning(string message, string title = "Cảnh báo")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Hiển thị hộp thoại xác nhận
        /// </summary>
        public static bool Confirm(string message, string title = "Xác nhận")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Trim tất cả các khoảng trắng thừa trong chuỗi
        /// </summary>
        public static string TrimAll(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return input.Trim();
        }

        /// <summary>
        /// Format mã sinh viên, mã lớp, v.v. với padding
        /// </summary>
        public static string PadCode(string code, int length = 10)
        {
            if (string.IsNullOrEmpty(code))
                return new string(' ', length);

            return code.Length >= length ? code.Substring(0, length) : code.PadRight(length);
        }

        /// <summary>
        /// Kiểm tra email hợp lệ
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Format ngày tháng
        /// </summary>
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Format ngày giờ
        /// </summary>
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Tính điểm hết môn
        /// </summary>
        public static double? TinhDiemHetMon(int? diemCC, double? diemGK, double? diemCK)
        {
            if (!diemCC.HasValue || !diemGK.HasValue || !diemCK.HasValue)
                return null;

            return Math.Round(diemCC.Value * 0.1 + diemGK.Value * 0.3 + diemCK.Value * 0.6, 1);
        }

        /// <summary>
        /// Kiểm tra đậu/rớt
        /// </summary>
        public static string GetKetQuaHocTap(double? diemHetMon)
        {
            if (!diemHetMon.HasValue)
                return "Chưa có điểm";

            if (diemHetMon.Value >= 5.0)
                return "Đạt";
            else
                return "Không đạt";
        }

        /// <summary>
        /// Lấy xếp loại học tập
        /// </summary>
        public static string GetXepLoai(double? diemTB)
        {
            if (!diemTB.HasValue)
                return "Chưa xếp loại";

            if (diemTB >= 9.0)
                return "Xuất sắc";
            else if (diemTB >= 8.0)
                return "Giỏi";
            else if (diemTB >= 7.0)
                return "Khá";
            else if (diemTB >= 5.0)
                return "Trung bình";
            else
                return "Yếu";
        }

        /// <summary>
        /// Export DataGridView to CSV
        /// </summary>
        public static void ExportDataGridViewToCSV(DataGridView dgv, string fileName)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                // Headers
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible)
                    {
                        sb.Append(dgv.Columns[i].HeaderText);
                        if (i < dgv.Columns.Count - 1)
                            sb.Append(",");
                    }
                }
                sb.AppendLine();

                // Data
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (dgv.Columns[i].Visible)
                            {
                                sb.Append(row.Cells[i].Value?.ToString() ?? "");
                                if (i < dgv.Columns.Count - 1)
                                    sb.Append(",");
                            }
                        }
                        sb.AppendLine();
                    }
                }

                System.IO.File.WriteAllText(fileName, sb.ToString(), System.Text.Encoding.UTF8);
                ShowInfo("Xuất dữ liệu thành công!\nFile: " + fileName);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xuất dữ liệu: " + ex.Message);
            }
        }

        /// <summary>
        /// Setup DataGridView mặc định
        /// </summary>
        public static void SetupDataGridView(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = BorderStyle.Fixed3D;

            // Màu xen kẽ
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
        }
    }
}