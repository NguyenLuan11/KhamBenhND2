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
    internal class DKKhamController
    {
        DKKham dkKham;
        List<DKKham> dkKhamList;

        public DKKhamController()
        {
            dkKham = new DKKham();
            dkKhamList = new List<DKKham>();
        }

        public List<DKKham> loadAll()
        {
            dkKhamList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DKKHAM", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaDKKham = Int32.Parse(reader["MaDKKham"].ToString());
                            string TenDKKham = reader["TenDKKham"].ToString();

                            dkKham = new DKKham(MaDKKham, TenDKKham);
                            dkKhamList.Add(dkKham);
                        }
                    }
                }
                connect.Close();
            }

            return dkKhamList;
        }

        public DKKham getDKKhamByTen(string tendkkham)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DKKHAM WHERE TenDKKham = N'" + tendkkham + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaDKKham = Int32.Parse(reader["MaDKKham"].ToString());
                            string TenDKKham = reader["TenDKKham"].ToString();

                            dkKham = new DKKham(MaDKKham, TenDKKham);
                        }
                    }
                }
                connect.Close();
            }

            return dkKham;
        }

        public DKKham getDKKhamByMa(int madkkham)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DKKHAM WHERE MaDKKham = " + madkkham.ToString(), connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaDKKham = Int32.Parse(reader["MaDKKham"].ToString());
                            string TenDKKham = reader["TenDKKham"].ToString();

                            dkKham = new DKKham(MaDKKham, TenDKKham);
                        }
                    }
                }
                connect.Close();
            }

            return dkKham;
        }
    }
}
