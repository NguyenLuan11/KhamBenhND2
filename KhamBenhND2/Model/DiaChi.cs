using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class QuocGia
    {
        public int id { get; set; }
        public string name_vi { get; set; }
        public string name_en { get; set; }
    }

    internal class Tinh_TP
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parrent { get; set; }
    }

    internal class Quan_Huyen
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parrent { get; set; }
    }

    internal class Xa_Phuong
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int parrent { get; set; }
    }
}
