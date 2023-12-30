using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class PhongKham
    {
        public string MaPK {  get; set; }
        public string TenPK { get; set; }
        public int MaKhoa { get; set; }

        public PhongKham() { }

        public PhongKham(string maPK, string tenPK, int maKhoa)
        {
            this.MaPK = maPK;
            this.TenPK = tenPK;
            this.MaKhoa = maKhoa;
        }
    }
}
