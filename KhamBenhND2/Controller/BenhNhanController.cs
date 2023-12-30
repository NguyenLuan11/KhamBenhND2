using KhamBenhND2.Model;
using KhamBenhND2.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Controller
{
    internal class BenhNhanController
    {
        BenhNhan BN;
        List<BenhNhan> dsBN;

        public BenhNhanController()
        {
            BN = new BenhNhan();
            dsBN = new List<BenhNhan>();
        }

        public List<BenhNhan> loadAll()
        {
            dsBN.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BENHNHAN", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string HoTen = reader["HoTen"].ToString();
                            string GioiTinh = reader["GioiTinh"].ToString();
                            string DanToc = reader["DanToc"].ToString();
                            DateTime NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                            string SoTheKCB = reader["SoTheKCB"].ToString();
                            string DiaChi = reader["DiaChi"].ToString();
                            string NoiSinh = reader["NoiSinh"].ToString();
                            float CanNang = float.Parse(reader["CanNang"].ToString());
                            float ChieuCao = float.Parse(reader["ChieuCao"].ToString());
                            float NhietDo = float.Parse(reader["NhietDo"].ToString());
                            float BMI = float.Parse(reader["BMI"].ToString());

                            BN = new BenhNhan(MaBN, HoTen, GioiTinh, DanToc, NgaySinh, SoTheKCB, 
                                DiaChi, NoiSinh, CanNang, ChieuCao, NhietDo, BMI);
                            dsBN.Add(BN);
                        }
                    }
                }
                connect.Close();
            }

            return dsBN;
        }

        public BenhNhan getBNByMaBN(string maBN)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BENHNHAN WHERE MaBN = '" + maBN + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string HoTen = reader["HoTen"].ToString();
                            string GioiTinh = reader["GioiTinh"].ToString();
                            string DanToc = reader["DanToc"].ToString();
                            DateTime NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                            string SoTheKCB = reader["SoTheKCB"].ToString();
                            string DiaChi = reader["DiaChi"].ToString();
                            string NoiSinh = reader["NoiSinh"].ToString();
                            float CanNang = float.Parse(reader["CanNang"].ToString());
                            float ChieuCao = float.Parse(reader["ChieuCao"].ToString());
                            float NhietDo = float.Parse(reader["NhietDo"].ToString());
                            float BMI = float.Parse(reader["BMI"].ToString());

                            BN = new BenhNhan(MaBN, HoTen, GioiTinh, DanToc, NgaySinh, SoTheKCB,
                                DiaChi, NoiSinh, CanNang, ChieuCao, NhietDo, BMI);
                        }
                    }
                }
                connect.Close();
            }

            return BN;
        }

        public BenhNhan getBNBySoTheKCB(string soTheKCB)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BENHNHAN WHERE SoTheKCB = '" + soTheKCB + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string HoTen = reader["HoTen"].ToString();
                            string GioiTinh = reader["GioiTinh"].ToString();
                            string DanToc = reader["DanToc"].ToString();
                            DateTime NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                            string SoTheKCB = reader["SoTheKCB"].ToString();
                            string DiaChi = reader["DiaChi"].ToString();
                            string NoiSinh = reader["NoiSinh"].ToString();
                            float CanNang = float.Parse(reader["CanNang"].ToString());
                            float ChieuCao = float.Parse(reader["ChieuCao"].ToString());
                            float NhietDo = float.Parse(reader["NhietDo"].ToString());
                            float BMI = float.Parse(reader["BMI"].ToString());

                            BN = new BenhNhan(MaBN, HoTen, GioiTinh, DanToc, NgaySinh, SoTheKCB,
                                DiaChi, NoiSinh, CanNang, ChieuCao, NhietDo, BMI);
                        }
                    }
                }
                connect.Close();
            }

            return BN;
        }

        public bool insert(BenhNhan BN)
        {
            string maBN = BN.MaBN;
            string hoten = BN.HoTen;
            string gioitinh = BN.GioiTinh;
            string dantoc = BN.DanToc;
            DateTime ngaysinh = BN.NgaySinh;
            string sotheKCB = BN.SoTheKCB;
            string diachi = BN.DiaChi;
            string noisinh = BN.NoiSinh;
            float cannang = BN.CanNang;
            float chieucao = BN.ChieuCao;
            float nhietdo = BN.NhietDo;
            float bmi = BN.BMI;

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string insertQuery = "INSERT INTO BENHNHAN (MaBN, HoTen, GioiTinh, DanToc, " +
                    "NgaySinh, SoTheKCB, DiaChi, NoiSinh, CanNang, ChieuCao, NhietDo, BMI) " +
                    "VALUES (@MaBN, @HoTen, @GioiTinh, @DanToc, @NgaySinh, @SoTheKCB, @DiaChi, " +
                    "@NoiSinh, @CanNang, @ChieuCao, @NhietDo, @BMI)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@HoTen", hoten);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                    cmd.Parameters.AddWithValue("@DanToc", dantoc);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                    cmd.Parameters.AddWithValue("@SoTheKCB", sotheKCB);
                    cmd.Parameters.AddWithValue("@DiaChi", diachi);
                    cmd.Parameters.AddWithValue("@NoiSinh", noisinh);
                    cmd.Parameters.AddWithValue("@CanNang", cannang);
                    cmd.Parameters.AddWithValue("@ChieuCao", chieucao);
                    cmd.Parameters.AddWithValue("@NhietDo", nhietdo);
                    cmd.Parameters.AddWithValue("@BMI", bmi);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool update(BenhNhan BN)
        {
            string maBN = BN.MaBN;
            string hoten = BN.HoTen;
            string gioitinh = BN.GioiTinh;
            string dantoc = BN.DanToc;
            DateTime ngaysinh = BN.NgaySinh;
            string sotheKCB = BN.SoTheKCB;
            string diachi = BN.DiaChi;
            string noisinh = BN.NoiSinh;
            float cannang = BN.CanNang;
            float chieucao = BN.ChieuCao;
            float nhietdo = BN.NhietDo;
            float bmi = BN.BMI;

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string updateQuery = "UPDATE BENHNHAN SET HoTen = @HoTen, GioiTinh = @GioiTinh, " +
                    "DanToc = @DanToc, NgaySinh = @NgaySinh, SoTheKCB = @SoTheKCB, DiaChi = @DiaChi, " +
                    "NoiSinh = @NoiSinh, CanNang = @CanNang, ChieuCao = @ChieuCao, NhietDo = @NhietDo, " +
                    "BMI = @BMI WHERE MaBN = @MaBN";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@HoTen", hoten);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                    cmd.Parameters.AddWithValue("@DanToc", dantoc);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                    cmd.Parameters.AddWithValue("@SoTheKCB", sotheKCB);
                    cmd.Parameters.AddWithValue("@DiaChi", diachi);
                    cmd.Parameters.AddWithValue("@NoiSinh", noisinh);
                    cmd.Parameters.AddWithValue("@CanNang", cannang);
                    cmd.Parameters.AddWithValue("@ChieuCao", chieucao);
                    cmd.Parameters.AddWithValue("@NhietDo", nhietdo);
                    cmd.Parameters.AddWithValue("@BMI", bmi);

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

                    string deleteQuery = "DELETE FROM BENHNHAN WHERE MaBN = @MaBN";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@MaBN", maBN);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch(SqlException)
            {
                return false;
            }
        }

        public bool isExist(string maBN)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string query = "SELECT COUNT(*) FROM BENHNHAN WHERE MaBN = @MaBN";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);

                    int rowCount = (int)cmd.ExecuteScalar();
                    return rowCount > 0;
                }
            }
        }
    }
}
