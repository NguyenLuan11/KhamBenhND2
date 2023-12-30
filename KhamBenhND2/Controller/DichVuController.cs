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
    internal class DichVuController
    {
        DichVu dichVu;
        List<DichVu> dichVuList;

        public DichVuController()
        {
            dichVu = new DichVu();
            dichVuList = new List<DichVu>();
        }

        public List<DichVu> loadAll()
        {
            dichVuList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DICHVU", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaDV = Int32.Parse(reader["MaDV"].ToString());
                            string TenDV = reader["TenDV"].ToString();

                            dichVu = new DichVu(MaDV, TenDV);
                            dichVuList.Add(dichVu);
                        }
                    }
                }
                connect.Close();
            }

            return dichVuList;
        }

        public DichVu getDVByTenDV(string tendv)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DICHVU WHERE TenDV = N'" + tendv + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaDV = Int32.Parse(reader["MaDV"].ToString());
                            string TenDV = reader["TenDV"].ToString();

                            dichVu = new DichVu(MaDV, TenDV);
                        }
                    }
                }
                connect.Close();
            }

            return dichVu;
        }

        public DichVu getDVByMaDV(int madv)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DICHVU WHERE MaDV = " + madv.ToString(), connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaDV = Int32.Parse(reader["MaDV"].ToString());
                            string TenDV = reader["TenDV"].ToString();

                            dichVu = new DichVu(MaDV, TenDV);
                        }
                    }
                }
                connect.Close();
            }

            return dichVu;
        }
    }
}
