using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class DoiTuong
    {
        public string MaDT {  get; set; }
        public string TenDT { get; set; }

        public DoiTuong() { }

        public DoiTuong(string maDT, string tenDT)
        {
            this.MaDT = maDT;
            this.TenDT = tenDT;
        }
    }
}
