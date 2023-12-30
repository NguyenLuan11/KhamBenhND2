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
    internal class DoiTuongController
    {
        DoiTuong doiTuong;
        List<DoiTuong> doiTuongList;

        public DoiTuongController()
        {
            doiTuong = new DoiTuong();
            doiTuongList = new List<DoiTuong>();
        }

        public List<DoiTuong> loadAll()
        {
            doiTuongList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM DOITUONG", connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaDT = reader["MaDT"].ToString();
                            string TenDT = reader["TenDT"].ToString();

                            doiTuong = new DoiTuong(MaDT, TenDT);
                            doiTuongList.Add(doiTuong);
                        }
                    }
                }
                connect.Close();
            }

            return doiTuongList;
        }

        public DoiTuong getDTByTenDT(string tenDT)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM DOITUONG WHERE TenDT = N'" + tenDT + "'", connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaDT = reader["MaDT"].ToString();
                            string TenDT = reader["TenDT"].ToString();

                            doiTuong = new DoiTuong(MaDT, TenDT);
                        }
                    }
                }
                connect.Close();
            }

            return doiTuong;
        }

        public DoiTuong getDTByMaDT(string maDT)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM DOITUONG WHERE MaDT = '" + maDT + "'", connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaDT = reader["MaDT"].ToString();
                            string TenDT = reader["TenDT"].ToString();

                            doiTuong = new DoiTuong(MaDT, TenDT);
                        }
                    }
                }
                connect.Close();
            }

            return doiTuong;
        }
    }
}
