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
    internal class CaKhamController
    {
        CaKham caKham;
        List<CaKham> caKhamList;

        public CaKhamController()
        {
            caKham = new CaKham();
            caKhamList = new List<CaKham>();
        }

        public List<CaKham> loadAll()
        {
            caKhamList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CAKHAM", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaCaKham = reader["MaCaKham"].ToString();
                            string TenCaKham = reader["TenCaKham"].ToString();

                            caKham = new CaKham(MaCaKham, TenCaKham);
                            caKhamList.Add(caKham);
                        }
                    }
                }
                connect.Close();
            }

            return caKhamList;
        }

        public CaKham getCaKhamByMaCaKham(string macakham)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CAKHAM WHERE MaCaKham = '" + macakham + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaCaKham = reader["MaCaKham"].ToString();
                            string TenCaKham = reader["TenCaKham"].ToString();

                            caKham = new CaKham(MaCaKham, TenCaKham);
                        }
                    }
                }
                connect.Close();
            }

            return caKham;
        }

        public CaKham getCaKhamByTen(string tencakham)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CAKHAM WHERE TenCaKham = N'" + tencakham + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaCaKham = reader["MaCaKham"].ToString();
                            string TenCaKham = reader["TenCaKham"].ToString();

                            caKham = new CaKham(MaCaKham, TenCaKham);
                        }
                    }
                }
                connect.Close();
            }

            return caKham;
        }
    }
}
