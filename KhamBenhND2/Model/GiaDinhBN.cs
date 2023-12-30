using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class GiaDinhBN
    {
        public int id {  get; set; }
        public string MaBN { get; set; }
        public string HoTenTN { get; set; }
        public string CM_CCCD { get; set; }
        public string VaiTro {  get; set; }
        public string SoDT { get; set; }
        public string NgheNghiep { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }

        public GiaDinhBN() { }

        public GiaDinhBN(string maBN, string hoTenTN, string CM_CCCD, string vaiTro, string soDT, string ngheNghiep, DateTime ngaysinh, string diaChi)
        {
            this.MaBN = maBN;
            this.HoTenTN = hoTenTN;
            this.CM_CCCD = CM_CCCD;
            this.VaiTro = vaiTro;
            this.SoDT = soDT;
            this.NgheNghiep = ngheNghiep;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diaChi;
        }
    }
}
