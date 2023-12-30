using KhamBenhND2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Controller
{
    internal class DiaChiController
    {
        public List<String> getDSQuocGia()
        {
            List<String> dsQuocGia = new List<String>();

            // Tạo đối tượng HttpClient
            HttpClient client = new HttpClient();

            // Thiết lập thời gian chờ tối đa là 30 giây
            client.Timeout = TimeSpan.FromSeconds(30);

            // Gọi phương thức GetAsync() để lấy danh sách các quoc gia
            HttpResponseMessage response = client.GetAsync("https://api.nosomovo.xyz/country/getalllist?_gl=1*wjlga4*_ga*ODgyODkyMDgyLjE3MDAxMjc0OTQ.*_ga_XW6CMNCYH8*MTcwMDEyNzQ5My4xLjEuMTcwMDEyNzUxMi4wLjAuMA..").Result;

            // Xử lý phản hồi
            if (response.IsSuccessStatusCode)
            {
                // Lấy dữ liệu JSON từ phản hồi
                string json = response.Content.ReadAsStringAsync().Result;

                // Tạo đối tượng JSON
                List<QuocGia> quocgias = JsonConvert.DeserializeObject<List<QuocGia>>(json);

                // Lấy danh sách tên các quoc gia
                foreach (QuocGia quocgia in quocgias)
                {
                    dsQuocGia.Add(quocgia.id + " - " + quocgia.name_vi);
                }
            }
            return dsQuocGia;
        }

        public List<String> getDSTinhTP(string maQuocGia)
        {
            List<String> dsTinhTP = new List<String>();

            // Tạo đối tượng HttpClient
            HttpClient client = new HttpClient();

            // Thiết lập thời gian chờ tối đa là 30 giây
            client.Timeout = TimeSpan.FromSeconds(30);

            // Gọi phương thức GetAsync() để lấy danh sách các tỉnh - tp
            HttpResponseMessage response = client.GetAsync("https://api.nosomovo.xyz/province/getalllist/" + maQuocGia + "?_gl=1*12of9x1*_ga*ODgyODkyMDgyLjE3MDAxMjc0OTQ.*_ga_XW6CMNCYH8*MTcwMDEyNzQ5My4xLjEuMTcwMDEyNzUxMi4wLjAuMA..").Result;

            // Xử lý phản hồi
            if (response.IsSuccessStatusCode)
            {
                // Lấy dữ liệu JSON từ phản hồi
                string json = response.Content.ReadAsStringAsync().Result;

                // Tạo đối tượng JSON
                List<Tinh_TP> tinh_tps = JsonConvert.DeserializeObject<List<Tinh_TP>>(json);

                // Lấy danh sách tên các tỉnh - tp
                if( tinh_tps != null)
                {
                    foreach (Tinh_TP tinh_tp in tinh_tps)
                    {
                        dsTinhTP.Add(tinh_tp.id + " - " + tinh_tp.name);
                    }
                }
            }
            return dsTinhTP;
        }

        public List<String> getDSQuanHuyen(string maTinhTP)
        {
            List<String> dsQuanHuyen = new List<String>();

            // Tạo đối tượng HttpClient
            HttpClient client = new HttpClient();

            // Thiết lập thời gian chờ tối đa là 30 giây
            client.Timeout = TimeSpan.FromSeconds(30);

            // Gọi phương thức GetAsync() để lấy danh sách các quan_huyen
            HttpResponseMessage response = client.GetAsync("https://api.nosomovo.xyz/district/getalllist/" + maTinhTP + "?_gl=1*1v3e4uy*_ga*ODgyODkyMDgyLjE3MDAxMjc0OTQ.*_ga_XW6CMNCYH8*MTcwMDE0ODAzMS4zLjAuMTcwMDE0ODAzMS4wLjAuMA..").Result;

            // Xử lý phản hồi
            if (response.IsSuccessStatusCode)
            {
                // Lấy dữ liệu JSON từ phản hồi
                string json = response.Content.ReadAsStringAsync().Result;

                // Tạo đối tượng JSON
                List<Quan_Huyen> quan_huyens = JsonConvert.DeserializeObject<List<Quan_Huyen>>(json);

                // Lấy danh sách tên các quan_huyen
                if (quan_huyens != null)
                {
                    foreach (Quan_Huyen quan_huyen in quan_huyens)
                    {
                        dsQuanHuyen.Add(quan_huyen.id + " - " + quan_huyen.name);
                    }
                }
            }
            return dsQuanHuyen;
        }

        public List<String> getDSXaPhuong(string maQuanHuyen)
        {
            List<String> dsXaPhuong = new List<String>();

            // Tạo đối tượng HttpClient
            HttpClient client = new HttpClient();

            // Thiết lập thời gian chờ tối đa là 30 giây
            client.Timeout = TimeSpan.FromSeconds(30);

            // Gọi phương thức GetAsync() để lấy danh sách các XaPhuong
            HttpResponseMessage response = client.GetAsync("https://api.nosomovo.xyz/commune/getalllist/" + maQuanHuyen + "?_gl=1*5mbynf*_ga*ODgyODkyMDgyLjE3MDAxMjc0OTQ.*_ga_XW6CMNCYH8*MTcwMDE0ODAzMS4zLjAuMTcwMDE0ODAzMS4wLjAuMA..").Result;

            // Xử lý phản hồi
            if (response.IsSuccessStatusCode)
            {
                // Lấy dữ liệu JSON từ phản hồi
                string json = response.Content.ReadAsStringAsync().Result;

                // Tạo đối tượng JSON
                List<Xa_Phuong> xa_phuongs = JsonConvert.DeserializeObject<List<Xa_Phuong>>(json);

                // Lấy danh sách tên các XaPhuong
                if (xa_phuongs != null)
                {
                    foreach (Xa_Phuong xa_phuong in xa_phuongs)
                    {
                        dsXaPhuong.Add(xa_phuong.id + " - " + xa_phuong.name);
                    }
                }
            }
            return dsXaPhuong;
        }
    }
}
