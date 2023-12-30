using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class LichSuKham
    {
        public int id { get; set; }
        public string MaBN { get; set; }
        public string LyDoKham { get; set; }
        public DateTime NgayDKKham { get; set; }
        public int MaDKKham { get; set; }
        public string MaDT { get; set; }
        public string MaCaKham { get; set; }
        public string MaPK { get; set; }
        public int MaDV { get; set; }

        public LichSuKham() { }

        public LichSuKham(string maBN, string lyDoKham, DateTime ngayDKKham, int maDKKham, string maDT, string maCaKham, string maPK, int maDV)
        {
            this.MaBN = maBN;
            this.LyDoKham = lyDoKham;
            this.NgayDKKham = ngayDKKham;
            this.MaDKKham = maDKKham;
            this.MaDT = maDT;
            this.MaCaKham = maCaKham;
            this.MaPK = maPK;
            this.MaDV = maDV;
        }
    }
}
