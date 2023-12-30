using KhamBenhND2.Model;
using KhamBenhND2.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Controller
{
    internal class GiaDinhBNController
    {
        GiaDinhBN gdBN;
        List<GiaDinhBN> giaDinhBNList;

        public GiaDinhBNController()
        {
            gdBN = new GiaDinhBN();
            giaDinhBNList = new List<GiaDinhBN>();
        }

        public List<GiaDinhBN> loadAll()
        {
            giaDinhBNList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM GIADINHBN", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string HoTenTN = reader["HoTenTN"].ToString();
                            string CM_CCCD = reader["CM_CCCD"].ToString();
                            string VaiTro = reader["VaiTro"].ToString();
                            string SoDT = reader["SoDT"].ToString();
                            string NgheNghiep = reader["NgheNghiep"].ToString();
                            DateTime NgaySinh = DateTime.Parse(reader["Ngaysinh"].ToString());
                            string DiaChi = reader["DiaChi"].ToString();

                            gdBN = new GiaDinhBN(MaBN, HoTenTN, CM_CCCD, VaiTro, SoDT, NgheNghiep, NgaySinh, DiaChi);
                            giaDinhBNList.Add(gdBN);
                        }
                    }
                }
                connect.Close();
            }

            return giaDinhBNList;
        }

        public List<GiaDinhBN> getGDBNByMaBN(string maBN)
        {
            giaDinhBNList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM GIADINHBN WHERE MaBN = '" + maBN + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string HoTenTN = reader["HoTenTN"].ToString();
                            string CM_CCCD = reader["CM_CCCD"].ToString();
                            string VaiTro = reader["VaiTro"].ToString();
                            string SoDT = reader["SoDT"].ToString();
                            string NgheNghiep = reader["NgheNghiep"].ToString();
                            DateTime NgaySinh = DateTime.Parse(reader["Ngaysinh"].ToString());
                            string DiaChi = reader["DiaChi"].ToString();

                            gdBN = new GiaDinhBN(MaBN, HoTenTN, CM_CCCD, VaiTro, SoDT, NgheNghiep, NgaySinh, DiaChi);
                            giaDinhBNList.Add(gdBN);
                        }
                    }
                }
                connect.Close();
            }

            return giaDinhBNList;
        }

        public GiaDinhBN getGDBNBySDT(string soDT)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM GIADINHBN WHERE SoDT = '" + soDT + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string HoTenTN = reader["HoTenTN"].ToString();
                            string CM_CCCD = reader["CM_CCCD"].ToString();
                            string VaiTro = reader["VaiTro"].ToString();
                            string SoDT = reader["SoDT"].ToString();
                            string NgheNghiep = reader["NgheNghiep"].ToString();
                            DateTime NgaySinh = DateTime.Parse(reader["Ngaysinh"].ToString());
                            string DiaChi = reader["DiaChi"].ToString();

                            gdBN = new GiaDinhBN(MaBN, HoTenTN, CM_CCCD, VaiTro, SoDT, NgheNghiep, NgaySinh, DiaChi);
                        }
                    }
                }
                connect.Close();
            }

            return gdBN;
        }

        public bool insert(GiaDinhBN gdBN)
        {
            string maBN = gdBN.MaBN;
            string hotenTN = gdBN.HoTenTN;
            string vaitro = gdBN.VaiTro;
            string sodt = gdBN.SoDT;
            string nghenghiep = gdBN.NgheNghiep;
            string diachi = gdBN.DiaChi;
            string cm_cccd = gdBN.CM_CCCD;
            DateTime ngaysinh = gdBN.NgaySinh;

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string insertQuery = "INSERT INTO GIADINHBN (MaBN, HoTenTN, VaiTro, SoDT, NgheNghiep, DiaChi, CM_CCCD, NgaySinh) " +
                    "VALUES (@MaBN, @HoTenTN, @VaiTro, @SoDT, @NgheNghiep, @DiaChi, @CM_CCCD, @NgaySinh)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@HoTenTN", hotenTN);
                    cmd.Parameters.AddWithValue("@VaiTro", vaitro);
                    cmd.Parameters.AddWithValue("@SoDT", sodt);
                    cmd.Parameters.AddWithValue("@NgheNghiep", nghenghiep);
                    cmd.Parameters.AddWithValue("@DiaChi", diachi);
                    cmd.Parameters.AddWithValue("@CM_CCCD", cm_cccd);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool update(GiaDinhBN gdBN)
        {
            string maBN = gdBN.MaBN;
            string hotenTN = gdBN.HoTenTN;
            string vaitro = gdBN.VaiTro;
            string sodt = gdBN.SoDT;
            string nghenghiep = gdBN.NgheNghiep;
            string diachi = gdBN.DiaChi;
            string cm_cccd = gdBN.CM_CCCD;
            DateTime ngaysinh = gdBN.NgaySinh;

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string updateQuery = "UPDATE GIADINHBN SET HoTenTN = @HoTenTN, VaiTro = @VaiTro, " +
                    "SoDT = @SoDT, NgheNghiep = @NgheNghiep, DiaChi = @DiaChi, CM_CCCD = @CM_CCCD, " +
                    "NgaySinh = @NgaySinh WHERE MaBN = @MaBN";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@HoTenTN", hotenTN);
                    cmd.Parameters.AddWithValue("@VaiTro", vaitro);
                    cmd.Parameters.AddWithValue("@SoDT", sodt);
                    cmd.Parameters.AddWithValue("@NgheNghiep", nghenghiep);
                    cmd.Parameters.AddWithValue("@DiaChi", diachi);
                    cmd.Parameters.AddWithValue("@CM_CCCD", cm_cccd);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool delete(string maBN)
        {
            try
            {
                using (SqlConnection connect = DatabaseHelper.getConnection())
                {
                    connect.Open();

                    string deleteQuery = "DELETE FROM GIADINHBN WHERE MaBN = @MaBN";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@MaBN", maBN);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool isExist(string maBN, string vaitroTN)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string query = "SELECT COUNT(*) FROM GIADINHBN WHERE MaBN = @MaBN AND VaiTro = @VaiTro";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@VaiTro", vaitroTN);

                    int rowCount = (int)cmd.ExecuteScalar();
                    return rowCount > 0;
                }
            }
        }
    }
}
