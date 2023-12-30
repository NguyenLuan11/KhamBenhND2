using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class DichVu
    {
        public int MaDV { get; set; }
        public string TenDV { get; set; }

        public DichVu() { }

        public DichVu(int maDV, string tenDV)
        {
            this.MaDV = maDV;
            this.TenDV = tenDV;
        }
    }
}
