using KhamBenhND2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Controller
{
    internal class DanTocController
    {
        public List<String> getDSDanToc()
        {
            List<String> dsDanToc = new List<String>();

            // Tạo đối tượng HttpClient
            HttpClient client = new HttpClient();

            // Thiết lập thời gian chờ tối đa là 30 giây
            client.Timeout = TimeSpan.FromSeconds(30);

            // Gọi phương thức GetAsync() để lấy danh sách các dân tộc
            HttpResponseMessage response = client.GetAsync("https://api.nosomovo.xyz/ethnic/getalllist?_gl=1*56eapd*_ga*ODgyODkyMDgyLjE3MDAxMjc0OTQ.*_ga_XW6CMNCYH8*MTcwMDE0ODAzMS4zLjAuMTcwMDE0ODAzMS4wLjAuMA..").Result;

            // Xử lý phản hồi
            if (response.IsSuccessStatusCode)
            {
                // Lấy dữ liệu JSON từ phản hồi
                string json = response.Content.ReadAsStringAsync().Result;

                // Tạo đối tượng JSON
                List<DanToc> dantocs = JsonConvert.DeserializeObject<List<DanToc>>(json);

                // Lấy danh sách tên các dân tộc
                foreach (DanToc dantoc in dantocs)
                {
                    dsDanToc.Add(dantoc.id + " - " + dantoc.name);
                }
            }
            return dsDanToc;
        }
    }
}
