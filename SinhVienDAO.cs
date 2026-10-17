using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    public class SinhVienDAO
    {
        private readonly DataHelper dataHelper = new DataHelper();

        public List<SinhVien> GetAllSinhVien()
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable(
                    "SELECT * FROM SinhVien");

                List<SinhVien> list = new List<SinhVien>();

                foreach (DataRow dr in dt.Rows)
                {
                    SinhVien sv = new SinhVien
                    {
                        MaSV = dr["MaSV"].ToString(),
                        HoTen = dr["HoTen"].ToString(),
                        GioiTinh = dr["GioiTinh"].ToString(),
                        NgaySinh = dr["NgaySinh"].ToString(),
                        SoDienThoai = dr["SoDienThoai"].ToString(),
                        MaLop = dr["MaLop"].ToString(),
                        Diem = dr["Diem"] == DBNull.Value
                            ? 0 : Convert.ToDouble(dr["Diem"]),
                        Email = dr["Email"].ToString()
                    };

                    list.Add(sv);
                }

                return list;
            }
            catch
            {
                throw;
            }
        }

        public SinhVien GetSinhVienByMaSV(string maSV)
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable(
                    "SELECT * FROM SinhVien WHERE MaSV = @MaSV",
                    new SqlParameter("@MaSV", maSV));

                if (dt.Rows.Count == 0)
                    return null;

                DataRow dr = dt.Rows[0];

                return new SinhVien
                {
                    MaSV = dr["MaSV"].ToString(),
                    HoTen = dr["HoTen"].ToString(),
                    GioiTinh = dr["GioiTinh"].ToString(),
                    NgaySinh = dr["NgaySinh"].ToString(),
                    SoDienThoai = dr["SoDienThoai"].ToString(),
                    MaLop = dr["MaLop"].ToString(),
                    Diem = dr["Diem"] == DBNull.Value
                        ? 0 : Convert.ToDouble(dr["Diem"]),
                    Email = dr["Email"].ToString()
                };
            }
            catch
            {
                throw;
            }
        }

        public List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable(
                    "SELECT * FROM SinhVien WHERE MaLop = @MaLop",
                    new SqlParameter("@MaLop", maLop));

                List<SinhVien> list = new List<SinhVien>();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new SinhVien
                    {
                        MaSV = dr["MaSV"].ToString(),
                        HoTen = dr["HoTen"].ToString(),
                        GioiTinh = dr["GioiTinh"].ToString(),
                        NgaySinh = dr["NgaySinh"].ToString(),
                        SoDienThoai = dr["SoDienThoai"].ToString(),
                        MaLop = dr["MaLop"].ToString(),
                        Diem = dr["Diem"] == DBNull.Value
                            ? 0 : Convert.ToDouble(dr["Diem"]),
                        Email = dr["Email"].ToString()
                    });
                }

                return list;
            }
            catch
            {
                throw;
            }
        }

        public void AddSinhVien(SinhVien sv)
        {
            try
            {
                string sql = @"
                    INSERT INTO SinhVien
                    (MaSV, MaLop, HoTen, GioiTinh,
                     NgaySinh, Diem, SoDienThoai, Email)
                    VALUES
                    (@MaSV, @MaLop, @HoTen, @GioiTinh,
                     @NgaySinh, @Diem, @SoDienThoai, @Email)";

                dataHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@MaSV", sv.MaSV),
                    new SqlParameter("@MaLop", sv.MaLop),
                    new SqlParameter("@HoTen", sv.HoTen),
                    new SqlParameter("@GioiTinh", sv.GioiTinh),
                    new SqlParameter("@NgaySinh", sv.NgaySinh),
                    new SqlParameter("@Diem", sv.Diem),
                    new SqlParameter("@SoDienThoai", sv.SoDienThoai),
                    new SqlParameter("@Email", sv.Email));
            }
            catch
            {
                throw;
            }
        }

        public void UpdateSinhVien(SinhVien sv)
        {
            try
            {
                string sql = @"
                    UPDATE SinhVien
                    SET MaLop = @MaLop,
                        HoTen = @HoTen,
                        GioiTinh = @GioiTinh,
                        NgaySinh = @NgaySinh,
                        Diem = @Diem,
                        SoDienThoai = @SoDienThoai,
                        Email = @Email
                    WHERE MaSV = @MaSV";

                int rows = dataHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@MaSV", sv.MaSV),
                    new SqlParameter("@MaLop", sv.MaLop),
                    new SqlParameter("@HoTen", sv.HoTen),
                    new SqlParameter("@GioiTinh", sv.GioiTinh),
                    new SqlParameter("@NgaySinh", sv.NgaySinh),
                    new SqlParameter("@Diem", sv.Diem),
                    new SqlParameter("@SoDienThoai", sv.SoDienThoai),
                    new SqlParameter("@Email", sv.Email));

                if (rows == 0)
                    throw new Exception(
                        "Không tìm thấy sinh viên cần cập nhật.");
            }
            catch
            {
                throw;
            }
        }

        public void DeleteSinhVien(string maSV)
        {
            try
            {
                int rows = dataHelper.ExecuteNonQuery(
                    "DELETE FROM SinhVien WHERE MaSV = @MaSV",
                    new SqlParameter("@MaSV", maSV));

                if (rows == 0)
                    throw new Exception(
                        "Không tìm thấy sinh viên cần xóa.");
            }
            catch
            {
                throw;
            }
        }
    }
}
