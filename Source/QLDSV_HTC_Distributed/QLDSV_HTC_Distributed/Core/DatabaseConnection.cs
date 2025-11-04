using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC
{
    public class DatabaseConnection
    {
        // ==========================================
        // CẤU HÌNH CONNECTION STRING
        // ==========================================
        // Đối với 1 SQL Server: Chỉ khác Initial Catalog
        // Đối với nhiều SQL Server: Thay Data Source khác nhau

        // Cấu hình cho 1 SQL Server (khuyến nghị cho học tập)
        public static string ConnStr_CNTT = @"Data Source=localhost;Initial Catalog=QLDSV_HTC_CNTT;Integrated Security=True";
        public static string ConnStr_VT = @"Data Source=localhost;Initial Catalog=QLDSV_HTC_VT;Integrated Security=True";
        public static string ConnStr_HocPhi = @"Data Source=localhost;Initial Catalog=QLDSV_HTC_HOCPHI;Integrated Security=True";

        // Nếu dùng SQL Authentication, dùng format này:
        // public static string ConnStr_CNTT = @"Data Source=localhost;Initial Catalog=QLDSV_HTC_CNTT;User ID=sa;Password=123456";

        // Nếu có 3 SQL Server khác nhau:
        // public static string ConnStr_CNTT = @"Data Source=192.168.1.100;Initial Catalog=QLDSV_HTC_CNTT;User ID=sa;Password=123456";
        // public static string ConnStr_VT = @"Data Source=192.168.1.101;Initial Catalog=QLDSV_HTC_VT;User ID=sa;Password=123456";
        // public static string ConnStr_HocPhi = @"Data Source=192.168.1.102;Initial Catalog=QLDSV_HTC_HOCPHI;User ID=sa;Password=123456";

        public static string CurrentKhoa = "CNTT      "; // Mặc định - Chú ý: Padded với space để = 10 ký tự
        public static string UserRole = ""; // PGV, KHOA, SV, PKT
        public static string UserMaKhoa = "";

        // Lấy connection string theo khoa
        public static string GetConnectionString(string maKhoa = null)
        {
            string khoa = maKhoa ?? CurrentKhoa;
            if (khoa == "CNTT")
                return ConnStr_CNTT;
            else if (khoa == "VT")
                return ConnStr_VT;
            else
                return ConnStr_CNTT;
        }

        // Thực thi query trả về DataTable
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null, string maKhoa = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString(maKhoa)))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Thực thi query không trả về kết quả (INSERT, UPDATE, DELETE)
        public static bool ExecuteNonQuery(string query, SqlParameter[] parameters = null, string maKhoa = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString(maKhoa)))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Thực thi stored procedure
        public static DataTable ExecuteStoredProcedure(string spName, SqlParameter[] parameters = null, string maKhoa = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString(maKhoa)))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Thực thi stored procedure cho học phí
        public static DataTable ExecuteStoredProcedureHocPhi(string spName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr_HocPhi))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Kiểm tra kết nối
        public static bool TestConnection(string connStr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}