using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class DKKham
    {
        public int MaDKKham {  get; set; }
        public string TenDKKham { get; set; }

        public DKKham() { }

        public DKKham(int maDKKham, string tenDKKham)
        {
            this.MaDKKham = maDKKham;
            this.TenDKKham = tenDKKham;
        }
    }
}
