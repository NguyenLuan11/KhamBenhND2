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
    internal class PhongKhamController
    {
        PhongKham phongKham;
        List<PhongKham> phongKhamList;

        public PhongKhamController()
        {
            phongKham = new PhongKham();
            phongKhamList = new List<PhongKham>();
        }

        public List<PhongKham> loadAll()
        {
            phongKhamList.Clear();

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM PHONGKHAM", connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maPK = reader["MaPK"].ToString();
                            string tenPK = reader["TenPk"].ToString();
                            int maKhoa = Int32.Parse(reader["MaKhoa"].ToString());

                            phongKham = new PhongKham(maPK, tenPK, maKhoa);
                            phongKhamList.Add(phongKham);
                        }
                    }
                }
                connect.Close();
            }

            return phongKhamList;
        }

        public PhongKham getPKByMaPK(string mapk)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM PHONGKHAM WHERE MaPK = '" + mapk + "'", connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maPK = reader["MaPK"].ToString();
                            string tenPK = reader["TenPk"].ToString();
                            int maKhoa = Int32.Parse(reader["MaKhoa"].ToString());

                            phongKham = new PhongKham(maPK, tenPK, maKhoa);
                        }
                    }
                }
                connect.Close();
            }

            return phongKham;
        }

        public PhongKham getPKByTenPK(string tenpk)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM PHONGKHAM WHERE TenPK = N'" + tenpk + "'", connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maPK = reader["MaPK"].ToString();
                            string tenPK = reader["TenPk"].ToString();
                            int maKhoa = Int32.Parse(reader["MaKhoa"].ToString());

                            phongKham = new PhongKham(maPK, tenPK, maKhoa);
                        }
                    }
                }
                connect.Close();
            }

            return phongKham;
        }
    }
}
