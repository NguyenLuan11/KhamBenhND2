using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Model
{
    internal class BenhNhan
    {
        public string MaBN { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string DanToc { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoTheKCB { get; set; }
        public string DiaChi { get; set; }
        public string NoiSinh { get; set; }
        public float CanNang {  get; set; }
        public float ChieuCao { get; set; }
        public float NhietDo {  get; set; }
        public float BMI {  get; set; }

        public BenhNhan() { }

        public BenhNhan(string maBN, string hoTen, string gioiTinh, string danToc, DateTime ngaySinh, string soTheKCB, string diaChi, string noiSinh, float canNang, float chieuCao, float nhietDo, float BMI)
        {
            this.MaBN = maBN;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.DanToc = danToc;
            this.NgaySinh = ngaySinh;
            this.SoTheKCB = soTheKCB;
            this.DiaChi = diaChi;
            this.NoiSinh = noiSinh;
            this.CanNang = canNang;
            this.ChieuCao = chieuCao;
            this.NhietDo = nhietDo;
            this.BMI = BMI;
        }
    }
}
