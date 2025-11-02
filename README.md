# QLDSV-Distributed-SQLServer (MVP)

MVP WinForms (.NET Framework 4.8) + SQL Server cho bài **QLDSV phân tán**. Chỉ gồm **những phần tối thiểu** để chạy demo:
- Đăng ký lớp tín chỉ
- Nhập điểm
- Đóng học phí

---

## 📁 Cấu trúc thư mục (MVP)

```plaintext
QLDSV-Distributed-SQLServer/
│
├─ Source/
│  └─ QLDSV_HTC_Distributed/           # Solution + Project WinForms
│     ├─ Forms/                        # 3 form tối thiểu
│     │  ├─ FrmDangKy.cs
│     │  ├─ FrmNhapDiem.cs
│     │  └─ FrmDongHocPhi.cs
│     ├─ Repos/                        # Gọi SQL/PROC qua ADO.NET
│     │  ├─ DangKyRepo.cs
│     │  ├─ NhapDiemRepo.cs
│     │  └─ HocPhiRepo.cs
│     ├─ Utils/
│     │  └─ SqlHelper.cs               # ExecSqlDataTable/NonQuery tối thiểu
│     ├─ App.config                    # connectionString
│     └─ QLDSV_HTC_Distributed.sln
│
└─ SQLScripts/                         # Chỉ 4 scripts cần cho demo
   ├─ 01_VIEW_SelectLTC.sql            # v_LTC_Mo: lọc lớp đang mở
   ├─ 02_PROC_DangKy.sql               # sp_DangKy_LTC
   ├─ 03_PROC_NhapDiem.sql             # sp_NhapDiem
   └─ 04_PROC_DongHocPhi.sql           # sp_DongHocPhi
