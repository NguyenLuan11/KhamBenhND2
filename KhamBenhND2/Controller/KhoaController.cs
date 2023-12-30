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
    internal class KhoaController
    {
        Khoa khoa;
        List<Khoa> khoaList;

        public KhoaController()
        {
            khoa = new Khoa();
            khoaList = new List<Khoa>();
        }

        public List<Khoa> loadAll()
        {
            khoaList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KHOA", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaKhoa = Int32.Parse(reader["MaKhoa"].ToString());
                            string TenKhoa = reader["TenKhoa"].ToString();

                            khoa = new Khoa(MaKhoa, TenKhoa);
                            khoaList.Add(khoa);
                        }
                    }
                }
                connect.Close();
            }

            return khoaList;
        }

        public Khoa getKhoaByMaKhoa(int maKhoa)
        {
            khoaList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KHOA WHERE MaKhoa = " + maKhoa.ToString(), connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int MaKhoa = Int32.Parse(reader["MaKhoa"].ToString());
                            string TenKhoa = reader["TenKhoa"].ToString();

                            khoa = new Khoa(MaKhoa, TenKhoa);
                        }
                    }
                }
                connect.Close();
            }

            return khoa;
        }
    }
}
