using System;
using System.Collections.Generic;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Business
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAO dao = new SinhVienDAO();

        public List<SinhVien> GetAllSinhVien()
        {
            try
            {
                return dao.GetAllSinhVien();
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
                return dao.GetSinhVienByMaSV(maSV);
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
                dao.AddSinhVien(sv);
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
                dao.UpdateSinhVien(sv);
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
                dao.DeleteSinhVien(maSV);
            }
            catch
            {
                throw;
            }
        }
    }
}
