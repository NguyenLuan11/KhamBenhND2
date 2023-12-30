using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class CaKham
    {
        public string MaCaKham {  get; set; }
        public string TenCaKham { get; set; }

        public CaKham() { }

        public CaKham(string maCaKham, string tenCaKham)
        {
            this.MaCaKham = maCaKham;
            this.TenCaKham = tenCaKham;
        }
    }
}
