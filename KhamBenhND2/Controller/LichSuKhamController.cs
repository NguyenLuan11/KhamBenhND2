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
    internal class LichSuKhamController
    {
        LichSuKham lsKham;
        List<LichSuKham> lsKhamList;

        public LichSuKhamController()
        {
            lsKham = new LichSuKham();
            lsKhamList = new List<LichSuKham>();
        }

        public List<LichSuKham> loadAll()
        {
            lsKhamList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LICHSUKHAM", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string LyDoKham = reader["LyDoKham"].ToString();
                            DateTime NgayDKKham = DateTime.Parse(reader["NgayDKKham"].ToString());
                            int MaDKKham = Int32.Parse(reader["MaDKKham"].ToString());
                            string MaDT = reader["MaDT"].ToString();
                            string MaCaKham = reader["MaCaKham"].ToString();
                            string MaPK = reader["MaPK"].ToString();
                            int MaDV = Int32.Parse(reader["MaDV"].ToString());

                            lsKham = new LichSuKham(MaBN, LyDoKham, NgayDKKham, MaDKKham, MaDT, MaCaKham, MaPK, MaDV);
                            lsKhamList.Add(lsKham);
                        }
                    }
                }
                connect.Close();
            }

            return lsKhamList;
        }

        public List<LichSuKham> getLSKhamByMaBN(string maBN)
        {
            lsKhamList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LICHSUKHAM WHERE MaBN = '" + maBN + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string LyDoKham = reader["LyDoKham"].ToString();
                            DateTime NgayDKKham = DateTime.Parse(reader["NgayDKKham"].ToString());
                            int MaDKKham = Int32.Parse(reader["MaDKKham"].ToString());
                            string MaDT = reader["MaDT"].ToString();
                            string MaCaKham = reader["MaCaKham"].ToString();
                            string MaPK = reader["MaPK"].ToString();
                            int MaDV = Int32.Parse(reader["MaDV"].ToString());

                            lsKham = new LichSuKham(MaBN, LyDoKham, NgayDKKham, MaDKKham, MaDT, MaCaKham, MaPK, MaDV);
                            lsKhamList.Add(lsKham);
                        }
                    }
                }
                connect.Close();
            }

            return lsKhamList;
        }

        public List<LichSuKham> getLSKhamByTime(string dateStart, string dateEnd, string maPK)
        {
            lsKhamList.Clear();
            string query = "";
            if (maPK == null)
            {
                query = "SELECT * FROM LICHSUKHAM WHERE FORMAT(NgayDKKham, 'yyyy-dd-MM') BETWEEN '" + dateStart + "' AND '" + dateEnd + "'";
            }
            else
            {
                query = "SELECT * FROM LICHSUKHAM WHERE MaPK = '" + maPK + "' AND FORMAT(NgayDKKham, 'yyyy-dd-MM') BETWEEN '" + dateStart + "' AND '" + dateEnd + "'";
            }

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string LyDoKham = reader["LyDoKham"].ToString();
                            DateTime NgayDKKham = DateTime.Parse(reader["NgayDKKham"].ToString());
                            int MaDKKham = Int32.Parse(reader["MaDKKham"].ToString());
                            string MaDT = reader["MaDT"].ToString();
                            string MaCaKham = reader["MaCaKham"].ToString();
                            string MaPK = reader["MaPK"].ToString();
                            int MaDV = Int32.Parse(reader["MaDV"].ToString());

                            lsKham = new LichSuKham(MaBN, LyDoKham, NgayDKKham, MaDKKham, MaDT, MaCaKham, MaPK, MaDV);
                            lsKhamList.Add(lsKham);
                        }
                    }
                }
                connect.Close();
            }

            return lsKhamList;
        }

        public bool insert(LichSuKham lsKham)
        {
            string maBN = lsKham.MaBN;
            string lydokham = lsKham.LyDoKham;
            DateTime ngaydkkham = lsKham.NgayDKKham;
            int madkkham = lsKham.MaDKKham;
            string madt = lsKham.MaDT;
            string macakham = lsKham.MaCaKham;
            string mapk = lsKham.MaPK;
            int madv = lsKham.MaDV;

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string insertQuery = "INSERT INTO LICHSUKHAM (MaBN, LyDoKham, NgayDKKham, MaDKKham, MaDT, MaCaKham, MaPK, MaDV) " +
                    "VALUES (@MaBN, @LyDoKham, @NgayDKKham, @MaDKKham, @MaDT, @MaCaKham, @MaPK, @MaDV)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@LyDoKham", lydokham);
                    cmd.Parameters.AddWithValue("@NgayDKKham", ngaydkkham);
                    cmd.Parameters.AddWithValue("@MaDKKham", madkkham);
                    cmd.Parameters.AddWithValue("@MaDT", madt);
                    cmd.Parameters.AddWithValue("@MaCaKham", macakham);
                    cmd.Parameters.AddWithValue("@MaPK", mapk);
                    cmd.Parameters.AddWithValue("@MaDV", madv);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
