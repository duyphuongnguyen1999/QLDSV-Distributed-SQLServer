using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_HTC {
    /// <summary>
    /// Lớp tiện ích kết nối cho mô hình phân tán 4 site: PGV / CNTT / VT / HOCPHI.
    /// - Đọc connection string từ App.config: PGV, CNTT, VT, HOCPHI.
    /// - Route theo CurrentKhoa hoặc tham số site truyền vào.
    /// </summary>
    public static class DatabaseConnection {
        // ========= Thông tin phiên đăng nhập (để frmMain/frmLogin dùng) =========
        public static string UserRole = "";     // Assign after login
        public static string CurrentKhoa = "";  // Assign after login

        // ========= Cấu hình mặc định =========
        public static int CommandTimeoutSeconds = 30;

        // ========= Lấy chuỗi kết nối theo site =========
        private static string GetCsByName(string name) {
            var cs = ConfigurationManager.ConnectionStrings[name];
            return cs != null ? cs.ConnectionString : "";
        }

        /// <summary>
        /// Trả về connection string theo site.
        /// Ưu tiên tham số maKhoa; nếu null -> CurrentKhoa.
        /// </summary>
        public static string GetConnectionString(string maKhoa = null) {
            var site = (maKhoa ?? CurrentKhoa ?? "").Trim().ToUpperInvariant();
            var role = UserRole.Trim().ToUpperInvariant();
            switch (role) {
                case "PGV":
                    return GetCsByName("PGV");
                case "PKT":
                    return GetCsByName("HOCPHI");
            }

            switch (site) {
                case "CNTT":
                    return GetCsByName("CNTT");
                case "VT":
                    return GetCsByName("VT");
                default:
                    MessageBox.Show(
                        "Không thể lấy ConnectionString",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return "";
            }
        }

        // ========= Helpers ADO.NET thường dùng =========

        /// <summary>
        /// SELECT trả về DataTable. Route theo maKhoa/CurrentKhoa.
        /// </summary>
        public static DataTable ExecuteQuery(string sql, SqlParameter[] parameters = null, string maKhoa = null) {
            var dt = new DataTable();
            var cs = GetConnectionString(maKhoa);

            try {
                using (var conn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sql, conn))
                using (var da = new SqlDataAdapter(cmd)) {
                    cmd.CommandTimeout = CommandTimeoutSeconds;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    da.Fill(dt);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi ExecuteQuery: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// INSERT/UPDATE/DELETE (không trả dữ liệu). Route theo maKhoa/CurrentKhoa.
        /// </summary>
        public static bool ExecuteNonQuery(string sql, SqlParameter[] parameters = null, string maKhoa = null) {
            var cs = GetConnectionString(maKhoa);

            try {
                using (var conn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sql, conn)) {
                    cmd.CommandTimeout = CommandTimeoutSeconds;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi ExecuteNonQuery: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Gọi Stored Procedure, trả về DataTable. Route theo maKhoa/CurrentKhoa.
        /// </summary>
        public static DataTable ExecuteStoredProcedure(string spName, SqlParameter[] parameters = null, string maKhoa = null) {
            var dt = new DataTable();
            var cs = GetConnectionString(maKhoa);

            try {
                using (var conn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(spName, conn))
                using (var da = new SqlDataAdapter(cmd)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = CommandTimeoutSeconds;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    da.Fill(dt);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi ExecuteStoredProcedure: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Gọi SP về site Học phí (bỏ qua CurrentKhoa).
        /// Dùng cho chức năng học phí – luôn đi server3.
        /// </summary>
        public static DataTable ExecuteStoredProcedureHocPhi(string spName, SqlParameter[] parameters = null) {
            var dt = new DataTable();
            var cs = GetConnectionString("HOCPHI");

            try {
                using (var conn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(spName, conn))
                using (var da = new SqlDataAdapter(cmd)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = CommandTimeoutSeconds;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    da.Fill(dt);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi ExecuteStoredProcedureHocPhi: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // ========= Kiểm tra kết nối =========

        public static bool TestConnection(string connStr) {
            try {
                using (var conn = new SqlConnection(connStr)) {
                    conn.Open();
                    return true;
                }
            } catch { return false; }
        }

        /// <summary>
        /// Test cả 3 site: trả về (CNTT_OK, VT_OK, HOCPHI_OK)
        /// </summary>
        public static Tuple<bool, bool, bool> TestAllSites() {
            bool okCntt = TestConnection(GetConnectionString("CNTT"));
            bool okVt = TestConnection(GetConnectionString("VT"));
            bool okHp = TestConnection(GetConnectionString("HOCPHI"));
            return Tuple.Create(okCntt, okVt, okHp);
        }

        // ========= (Tuỳ chọn) Helper Transaction cho lệnh nhiều bước tại 1 site =========
        public static bool ExecuteInTransaction(Func<SqlConnection, SqlTransaction, bool> work, string maKhoa = null) {
            var cs = GetConnectionString(maKhoa);
            try {
                using (var conn = new SqlConnection(cs)) {
                    conn.Open();
                    using (var tran = conn.BeginTransaction()) {
                        bool ok = work(conn, tran);
                        if (ok) { tran.Commit(); return true; }
                        tran.Rollback();
                        return false;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi ExecuteInTransaction: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh trả về 1 giá trị (SELECT COUNT(*), MAX, MIN, ...).
        /// Route theo maKhoa hoặc CurrentKhoa.
        /// </summary>
        public static object ExecuteScalar(string sql, SqlParameter[] parameters = null, string maKhoa = null) {
            var cs = GetConnectionString(maKhoa);

            try {
                using (var conn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sql, conn)) {
                    cmd.CommandTimeout = CommandTimeoutSeconds;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();   // luôn trả về object (có thể null)
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi ExecuteScalar: " + ex.Message, "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Kiểm tra sự tồn tại của 1 giá trị trong database
        /// </summary>
        public static bool CheckForExistence(string tableName, string columnName, string value, string maKhoa = null) {
            string query = "SELECT " +
                            "CASE" +
                                "WHEN EXISTS " +
                                    "(SELECT 1 " +
                                    "FROM {tableName} " +
                                    "WHERE {columnName} = @Value)" +
                                "THEN 1 " +
                                "ELSE 0" +
                            "END";
            var cs = GetConnectionString(maKhoa);

            using (var conn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(query, conn)) {
                cmd.CommandTimeout = CommandTimeoutSeconds;
                cmd.Parameters.AddWithValue("@Value", value);

                conn.Open();

                int result = (int)cmd.ExecuteScalar();
                return result == 1;
            }
        }
    }
}
