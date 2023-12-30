using KhamBenhND2.Controller;
using KhamBenhND2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Speech.Synthesis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Speech.Recognition;

namespace KhamBenhND2.View
{
    public partial class dsKhamBenh : Form
    {
        PhongKhamController phongKhamController;
        CaKhamController caKhamController;
        DoiTuongController doiTuongController;
        LichSuKhamController lichSuKhamController;
        BenhNhanController benhNhanController;
        BHYTController bHYTController;
        KhoaController khoaController;

        List<LichSuKham> lichSuKhamCurrent;

        public dsKhamBenh()
        {
            InitializeComponent();
            phongKhamController = new PhongKhamController();
            caKhamController = new CaKhamController();
            doiTuongController = new DoiTuongController();
            lichSuKhamController = new LichSuKhamController();
            benhNhanController = new BenhNhanController();
            bHYTController = new BHYTController();
            khoaController = new KhoaController();

            lichSuKhamCurrent = new List<LichSuKham>();
        }

        // BUTTON CLICK

        private void btn_goiSTT_Click(object sender, EventArgs e)
        {
            if (dgv_dskhambenh.SelectedRows.Count > 0)
            {
                string maBN = dgv_dskhambenh.SelectedRows[0].Cells[1].Value.ToString();

                foreach (LichSuKham lsk in lichSuKhamCurrent)
                {
                    if (lsk.MaBN == maBN)
                    {
                        int sttKham = lichSuKhamCurrent.IndexOf(lsk) + 1;

                        PromptBuilder promptBuilder = new PromptBuilder();
                        promptBuilder.AppendText("Please come in, patient number " + sttKham.ToString());

                        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                        speechSynthesizer.SpeakAsync(promptBuilder);
                    }
                }
            }
        }

        private void btn_dontiep_Click(object sender, EventArgs e)
        {
            this.Hide();
            dkKhamBenh dkKhamBenh = new dkKhamBenh();
            dkKhamBenh.ShowDialog();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dtp_dateStart.Text) && !string.IsNullOrWhiteSpace(dtp_dateEnd.Text)
                && !string.IsNullOrWhiteSpace(cbb_phongkham.Text))
            {
                if (dtp_dateStart.Value <= dtp_dateEnd.Value)
                {
                    string datestart = String.Format("{0:HH:mm yyyy/dd/MM}", dtp_dateStart.Value).Substring(6, 10).Replace("/", "-");
                    string dateend = String.Format("{0:HH:mm yyyy/dd/MM}", dtp_dateEnd.Value).Substring(6, 10).Replace("/", "-");
                    string mapk = "";
                    if (!cbb_phongkham.Text.Contains("Tất cả phòng khám"))
                    {
                        string tenpk = cbb_phongkham.Text.Split(" - ")[0];
                        mapk = phongKhamController.getPKByTenPK(tenpk).MaPK;
                    }
                    else
                    {
                        mapk = null;
                    }

                    dgv_dskhambenh.Rows.Clear();

                    foreach (LichSuKham lsk in lichSuKhamController.getLSKhamByTime(datestart, dateend, mapk))
                    {
                        if (lsk != null)
                        {
                            string ngaydontiep = String.Format("{0:HH:mm dd/MM/yyyy}", lsk.NgayDKKham);
                            string mabn = lsk.MaBN;
                            BenhNhan bn = benhNhanController.getBNByMaBN(mabn);
                            string tenbn = bn.HoTen;
                            string sobhyt;
                            if (bHYTController.getBHYTByMaBN(mabn) != null && bHYTController.getBHYTByMaBN(mabn).MaBN == mabn)
                            {
                                sobhyt = bHYTController.getBHYTByMaBN(mabn).SoBHYT;
                            }
                            else
                            {
                                sobhyt = "";
                            }
                            string gioitinh = bn.GioiTinh;
                            string[] ngaysinh = bn.NgaySinh.ToString().Split("/");
                            int tuoi = DateTime.Now.Year - Int32.Parse(ngaysinh[2].Split(" ")[0]);
                            string namsinh = ngaysinh[2].Split(" ")[0] + " (" + tuoi.ToString() + " tuổi)";
                            string diachi = bn.DiaChi;
                            string phongkham = phongKhamController.getPKByMaPK(lsk.MaPK).TenPK;
                            int makhoa = phongKhamController.getPKByMaPK(lsk.MaPK).MaKhoa;
                            string khoa = khoaController.getKhoaByMaKhoa(makhoa).TenKhoa;

                            string[] row = { ngaydontiep, mabn, tenbn, sobhyt, gioitinh, namsinh, diachi, phongkham, khoa };
                            dgv_dskhambenh.Rows.Add(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc!");
                }
            }
        }

        private void cbb_phongkham_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void btn_inDSkham_Click(object sender, EventArgs e)
        {
            // Đặt hướng giấy thành nằm ngang
            printDocumentDSkham.DefaultPageSettings.Landscape = true;

            printPreviewDialogDSkham.Document = printDocumentDSkham;
            printPreviewDialogDSkham.ShowDialog();
        }

        // LOAD FORM

        private void dsKhamBenh_Load(object sender, EventArgs e)
        {
            cbb_phongkham.Items.Add("Tất cả phòng khám");
            foreach (PhongKham phongKham in phongKhamController.loadAll())
            {
                string khoa = khoaController.getKhoaByMaKhoa(phongKham.MaKhoa).TenKhoa;
                cbb_phongkham.Items.Add(phongKham.TenPK + " - " + khoa);
            }

            foreach (CaKham caKham in caKhamController.loadAll())
            {
                treeView_phanloaiBN.Nodes[1].Nodes.Add(caKham.TenCaKham);
            }

            foreach (DoiTuong doiTuong in doiTuongController.loadAll())
            {
                treeView_phanloaiBN.Nodes[4].Nodes.Add(doiTuong.TenDT);
            }

            foreach (LichSuKham lsk in lichSuKhamController.loadAll())
            {
                if (lsk != null)
                {
                    string today = String.Format("{0:HH:mm dd/MM/yyyy}", DateTime.Now).Substring(6, 10);
                    string ngdkkham = String.Format("{0:HH:mm dd/MM/yyyy}", lsk.NgayDKKham).Substring(6, 10);
                    if (ngdkkham == today)
                    {
                        lichSuKhamCurrent.Add(lsk);

                        string ngaydontiep = String.Format("{0:HH:mm dd/MM/yyyy}", lsk.NgayDKKham);
                        string mabn = lsk.MaBN;
                        BenhNhan bn = benhNhanController.getBNByMaBN(mabn);
                        string tenbn = bn.HoTen;
                        string sobhyt;
                        if (bHYTController.getBHYTByMaBN(mabn) != null && bHYTController.getBHYTByMaBN(mabn).MaBN == mabn)
                        {
                            sobhyt = bHYTController.getBHYTByMaBN(mabn).SoBHYT;
                        }
                        else
                        {
                            sobhyt = "";
                        }
                        string gioitinh = bn.GioiTinh;
                        string[] ngaysinh = bn.NgaySinh.ToString().Split("/");
                        int tuoi = DateTime.Now.Year - Int32.Parse(ngaysinh[2].Split(" ")[0]);
                        string namsinh = ngaysinh[2].Split(" ")[0] + " (" + tuoi.ToString() + " tuổi)";
                        string diachi = bn.DiaChi;
                        string phongkham = phongKhamController.getPKByMaPK(lsk.MaPK).TenPK;
                        int makhoa = phongKhamController.getPKByMaPK(lsk.MaPK).MaKhoa;
                        string khoa = khoaController.getKhoaByMaKhoa(makhoa).TenKhoa;

                        string[] row = { ngaydontiep, mabn, tenbn, sobhyt, gioitinh, namsinh, diachi, phongkham, khoa };
                        dgv_dskhambenh.Rows.Add(row);
                    }
                }
            }
        }

        // PRINT DOCUMENT

        private void printDocumentDSkham_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("BỆNH VIỆN NHI ĐỒNG 2 ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, 10));
            e.Graphics.DrawString("DANH SÁCH KHÁM BỆNH", new Font("Arial", 40, FontStyle.Bold), Brushes.Black, new Point(230, 80));

            string startDate = String.Format("{0:HH:mm dd/MM/yyyy}", dtp_dateStart.Value).Split(" ")[1];
            string endDate = String.Format("{0:HH:mm dd/MM/yyyy}", dtp_dateEnd.Value).Split(" ")[1];
            e.Graphics.DrawString("Từ ngày " + startDate + ", ", new Font("Arial", 20, FontStyle.Italic), Brushes.Black, new Point(20, 200));
            e.Graphics.DrawString("đến ngày " + endDate, new Font("Arial", 20, FontStyle.Italic), Brushes.Black, new Point(277, 200));


            PrintDataGridView(dgv_dskhambenh, e);
        }

        private void PrintDataGridView(DataGridView dataGridView, PrintPageEventArgs e)
        {
            // Xác định các thông số cần thiết
            int rowIndex = 0;
            float yPos = 300;
            int columnsCount = dataGridView.Columns.Count;
            int rowsCount = dataGridView.Rows.Count;
            float leftMargin = 0;
            float topMargin = e.MarginBounds.Top;
            bool firstPage = true;

            // Vẽ tiêu đề của DataGridView
            if (firstPage)
            {
                for (int i = 0; i < columnsCount; i++)
                {
                    e.Graphics.DrawString(dataGridView.Columns[i].HeaderText,
                        dataGridView.Font, Brushes.Black, leftMargin, yPos);
                    leftMargin += dataGridView.Columns[i].Width;
                }
                yPos += dataGridView.Rows[0].Height;
                firstPage = false;
            }

            // Vẽ từng dòng dữ liệu
            while (rowIndex < rowsCount)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                if (yPos + row.Height > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                leftMargin = 0;
                for (int i = 0; i < columnsCount; i++)
                {
                    e.Graphics.DrawString(row.Cells[i].Value?.ToString(),
                        dataGridView.Font, Brushes.Black, leftMargin, yPos);
                    leftMargin += dataGridView.Columns[i].Width;
                }
                yPos += row.Height;
                rowIndex++;
            }

            e.HasMorePages = false;
        }
    }
}
