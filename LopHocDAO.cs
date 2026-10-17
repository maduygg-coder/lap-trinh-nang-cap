using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    public class LopHocDAO
    {
        private readonly DataHelper dataHelper = new DataHelper();

        public List<LopHoc> GetAllLopHoc()
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable(
                    "SELECT * FROM LopHoc");

                List<LopHoc> list = new List<LopHoc>();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LopHoc
                    {
                        MaLop = dr["MaLop"].ToString(),
                        TenLop = dr["TenLop"].ToString()
                    });
                }

                return list;
            }
            catch
            {
                throw;
            }
        }

        public void AddLopHoc(LopHoc lh)
        {
            try
            {
                string sql = @"
                    INSERT INTO LopHoc (MaLop, TenLop)
                    VALUES (@MaLop, @TenLop)";

                dataHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@MaLop", lh.MaLop),
                    new SqlParameter("@TenLop", lh.TenLop));
            }
            catch
            {
                throw;
            }
        }

        public void UpdateLopHoc(LopHoc lh)
        {
            try
            {
                string sql = @"
                    UPDATE LopHoc
                    SET TenLop = @TenLop
                    WHERE MaLop = @MaLop";

                int rows = dataHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@MaLop", lh.MaLop),
                    new SqlParameter("@TenLop", lh.TenLop));

                if (rows == 0)
                    throw new Exception(
                        "Không tìm thấy lớp học cần cập nhật.");
            }
            catch
            {
                throw;
            }
        }

        public void DeleteLopHoc(string maLop)
        {
            try
            {
                int rows = dataHelper.ExecuteNonQuery(
                    "DELETE FROM LopHoc WHERE MaLop = @MaLop",
                    new SqlParameter("@MaLop", maLop));

                if (rows == 0)
                    throw new Exception(
                        "Không tìm thấy lớp học cần xóa.");
            }
            catch
            {
                throw;
            }
        }
    }
}
