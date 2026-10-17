using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVien.Data.DAL
{
    public class DataHelper
    {
        private readonly string connectionString =
            @"Server=LAPTOP-6SN65NCS\HUECTMDB;Database=QLSV;Integrated Security=True;TrustServerCertificate=True";

        public DataTable GetDataTable(
            string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }

        public int ExecuteNonQuery(
            string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
