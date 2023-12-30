using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class BHYT
    {
        public string MaBN { get; set; }
        public string SoBHYT { get; set; }
        public string DKKCBBD { get; set; }
        public DateTime HanThe {  get; set; }
        public DateTime NgayDu5Nam { get; set; }
        public string DiaChiThe { get; set; }
        public string TuyenKCB {  get; set; }

        public BHYT() { }

        public BHYT(string maBN, string soBHYT, string dKKCBBD, DateTime hanThe, DateTime ngayDu5Nam, string diaChiThe, string tuyenKCB)
        {
            MaBN = maBN;
            SoBHYT = soBHYT;
            DKKCBBD = dKKCBBD;
            HanThe = hanThe;
            NgayDu5Nam = ngayDu5Nam;
            DiaChiThe = diaChiThe;
            TuyenKCB = tuyenKCB;
        }
    }
}
