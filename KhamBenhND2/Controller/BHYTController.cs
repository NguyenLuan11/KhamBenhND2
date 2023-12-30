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
    internal class BHYTController
    {
        BHYT bhyt;
        List<BHYT> bhytList;

        public BHYTController()
        {
            bhyt = new BHYT();
            bhytList = new List<BHYT>();
        }

        public List<BHYT> loadAll()
        {
            bhytList.Clear();
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BHYT", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string SoBHYT = reader["SoBHYT"].ToString();
                            string DKKCBBD = reader["DKKCBBD"].ToString();
                            DateTime HanThe = DateTime.Parse(reader["HanThe"].ToString());
                            DateTime NgayDu5Nam = DateTime.Parse(reader["NgayDu5Nam"].ToString());
                            string DiaChiThe = reader["DiaChiThe"].ToString();
                            string TuyenKCB = reader["TuyenKCB"].ToString();

                            bhyt = new BHYT(MaBN, SoBHYT, DKKCBBD, HanThe, NgayDu5Nam, DiaChiThe, TuyenKCB);
                            bhytList.Add(bhyt);
                        }
                    }
                }
                connect.Close();
            }

            return bhytList;
        }

        public BHYT getBHYTByMaBN(string maBN)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BHYT WHERE MaBN = '" + maBN + "'", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string MaBN = reader["MaBN"].ToString();
                            string SoBHYT = reader["SoBHYT"].ToString();
                            string DKKCBBD = reader["DKKCBBD"].ToString();
                            DateTime HanThe = DateTime.Parse(reader["HanThe"].ToString());
                            DateTime NgayDu5Nam = DateTime.Parse(reader["NgayDu5Nam"].ToString());
                            string DiaChiThe = reader["DiaChiThe"].ToString();
                            string TuyenKCB = reader["TuyenKCB"].ToString();

                            bhyt = new BHYT(MaBN, SoBHYT, DKKCBBD, HanThe, NgayDu5Nam, DiaChiThe, TuyenKCB);
                        }
                    }
                }
                connect.Close();
            }

            return bhyt;
        }

        public bool insert(BHYT bhyt)
        {
            string maBN = bhyt.MaBN;
            string sobhyt = bhyt.SoBHYT;
            string dkkcbbd = bhyt.DKKCBBD;
            DateTime hanthe = bhyt.HanThe;
            DateTime ngaydu5nam = bhyt.NgayDu5Nam;
            string diachithe = bhyt.DiaChiThe;
            string tuyenkcb = bhyt.TuyenKCB;

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string insertQuery = "INSERT INTO BHYT (MaBN, SoBHYT, DKKCBBD, HanThe, NgayDu5Nam, DiaChiThe, TuyenKCB) " +
                    "VALUES (@MaBN, @SoBHYT, @DKKCBBD, @HanThe, @NgayDu5Nam, @DiaChiThe, @TuyenKCB)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@SoBHYT", sobhyt);
                    cmd.Parameters.AddWithValue("@DKKCBBD", dkkcbbd);
                    cmd.Parameters.AddWithValue("@HanThe", hanthe);
                    cmd.Parameters.AddWithValue("@NgayDu5Nam", ngaydu5nam);
                    cmd.Parameters.AddWithValue("@DiaChiThe", diachithe);
                    cmd.Parameters.AddWithValue("@TuyenKCB", tuyenkcb);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool update(BHYT bhyt)
        {
            string maBN = bhyt.MaBN;
            string sobhyt = bhyt.SoBHYT;
            string dkkcbbd = bhyt.DKKCBBD;
            DateTime hanthe = bhyt.HanThe;
            DateTime ngaydu5nam = bhyt.NgayDu5Nam;
            string diachithe = bhyt.DiaChiThe;
            string tuyenkcb = bhyt.TuyenKCB;

            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string updateQuery = "UPDATE BHYT SET SoBHYT = @SoBHYT, DKKCBBD = @DKKCBBD, " +
                    "HanThe = @HanThe, NgayDu5Nam = @NgayDu5Nam, DiaChiThe = @DiaChiThe, " +
                    "TuyenKCB = @TuyenKCB WHERE MaBN = @MaBN";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@SoBHYT", sobhyt);
                    cmd.Parameters.AddWithValue("@DKKCBBD", dkkcbbd);
                    cmd.Parameters.AddWithValue("@HanThe", hanthe);
                    cmd.Parameters.AddWithValue("@NgayDu5Nam", ngaydu5nam);
                    cmd.Parameters.AddWithValue("@DiaChiThe", diachithe);
                    cmd.Parameters.AddWithValue("@TuyenKCB", tuyenkcb);

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

                    string deleteQuery = "DELETE FROM BHYT WHERE MaBN = @MaBN";
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

        public bool isExist(string maBN, string sobhyt)
        {
            using (SqlConnection connect = DatabaseHelper.getConnection())
            {
                connect.Open();

                string query = "SELECT COUNT(*) FROM BHYT WHERE MaBN = @MaBN OR SoBHYT = @SoBHYT";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@SoBHYT", sobhyt);

                    int rowCount = (int)cmd.ExecuteScalar();
                    return rowCount > 0;
                }
            }
        }
    }
}
