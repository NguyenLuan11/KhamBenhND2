using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class Khoa
    {
        public int MaKhoa { get; set; }
        public string TenKhoa { get; set;}

        public Khoa() { }

        public Khoa(int maKhoa, string tenKhoa)
        {
            this.MaKhoa = maKhoa;
            this.TenKhoa = tenKhoa;
        }
    }
}
