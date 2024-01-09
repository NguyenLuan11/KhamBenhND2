using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using KhamBenhND2.Model;
using KhamBenhND2.Controller;
using TextBox = System.Windows.Forms.TextBox;
using KhamBenhND2.Utils;
using System.Drawing.Printing;

namespace KhamBenhND2.View
{
    public partial class dkKhamBenh : Form
    {
        DiaChiController diaChiController;
        DanTocController danTocController;
        CaKhamController caKhamController;
        DoiTuongController doiTuongController;
        PhongKhamController phongKhamController;
        DKKhamController dKKhamController;
        GiaDinhBNController giaDinhBNController;
        LichSuKhamController lichSuKhamController;
        DichVuController dichVuController;
        BHYTController bhytController;
        BenhNhanController benhNhanController;
        KhoaController khoaController;

        List<LichSuKham> lichSuKhamCurrent;
        string thoigiankham;

        public dkKhamBenh()
        {
            InitializeComponent();
            diaChiController = new DiaChiController();
            danTocController = new DanTocController();
            caKhamController = new CaKhamController();
            doiTuongController = new DoiTuongController();
            phongKhamController = new PhongKhamController();
            dKKhamController = new DKKhamController();
            giaDinhBNController = new GiaDinhBNController();
            lichSuKhamController = new LichSuKhamController();
            dichVuController = new DichVuController();
            bhytController = new BHYTController();
            benhNhanController = new BenhNhanController();
            khoaController = new KhoaController();

            lichSuKhamCurrent = new List<LichSuKham>();
            thoigiankham = "";
        }

        // LICHSUKHAM CURRENT

        private List<LichSuKham> getListLSKToday()
        {
            foreach (LichSuKham lsk in lichSuKhamController.loadAll())
            {
                if (lsk != null)
                {
                    string today = String.Format("{0:HH:mm dd/MM/yyyy}", DateTime.Now).Substring(6, 10);
                    string ngdkkham = String.Format("{0:HH:mm dd/MM/yyyy}", lsk.NgayDKKham).Substring(6, 10);
                    if (ngdkkham == today)
                    {
                        lichSuKhamCurrent.Add(lsk);
                    }
                }
            }
            return lichSuKhamCurrent;
        }

        // BUTTON CLICK

        private void btn_dsKham_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open DSKhamBenh
            dsKhamBenh dsKhamBenh = new dsKhamBenh();
            dsKhamBenh.Show();
        }

        private void btn_newpatient_Click(object sender, EventArgs e)
        {
            // Clear contents of Search's textBox
            tb_searchBN_theKCB.Clear();
            tb_searchBN_SDT.Clear();

            // Clear contents of Patient Infomation's textBox
            cb_BNuutien.Checked = false;
            tb_hoten.Clear();
            tb_sotheKCB.Clear();
            tb_SN_thon_pho.Clear();
            tb_day.Clear();
            tb_month.Clear();
            tb_year.Clear();
            BMI.Text = null;
            cbb_doituong.Items.Clear();
            cbb_gioitinh.Items.Clear();
            cbb_quoctich.Items.Clear();
            cbb_quoctich.Text = "Chọn Quốc tịch";
            cbb_tinh_tp.Items.Clear();
            cbb_tinh_tp.Text = null;
            cbb_quan_huyen.Items.Clear();
            cbb_quan_huyen.Text = null;
            cbb_xa_phuong.Items.Clear();
            cbb_xa_phuong.Text = null;
            cbb_dantoc.Items.Clear();
            cbb_dantoc.Text = "Chọn Dân tộc";
            cbb_cakham.Items.Clear();
            cbb_cakham.Text = "Chọn ca khám";
            cbb_dichvu.Items.Clear();
            cbb_dichvu.Text = "Chọn dịch vụ khám";
            cbb_dkkham.Items.Clear();
            cbb_phongkham.Items.Clear();
            cbb_phongkham.Text = "Chọn phòng khám";
            tb_noisinh.Clear();
            tb_cannang.Text = "0.00";
            tb_chieucao.Text = "0.00";
            tb_nhietdo.Text = "0.00";
            tb_lydokham.Clear();

            // Clear contents of BHYT's textBox
            tb_sotheKCB.Clear();
            tb_bhyt_madoituong.Clear();
            tb_bhyt_muchuong.Clear();
            tb_bhyt_matinh.Clear();
            tb_bhyt_mabhxh.Clear();
            rTB_diachithe.Clear();
            tb_noiDKKCBBD.Clear();
            tb_tuyenKCB.Clear();
            tb_hanthe_day.Clear();
            tb_hanthe_month.Clear();
            tb_hanthe_year.Clear();
            tb_ngdu5n_day.Clear();
            tb_ngdu5n_month.Clear();
            tb_ngdu5n_year.Clear();
            muchuong.Text = "0%";

            // Clear contents of Family Infomation's textBox
            tb_hotencha.Clear();
            tb_cm_cc_cha.Clear();
            tb_sdt_cha.Clear();
            tb_nghenghiepcha.Clear();
            rTB_diachicha.Clear();
            tb_date_cha.Clear();
            tb_month_cha.Clear();
            tb_year_cha.Clear();

            tb_hotenme.Clear();
            tb_cm_cc_me.Clear();
            tb_sdt_me.Clear();
            tb_nghenghiepme.Clear();
            rTB_diachime.Clear();
            tb_date_me.Clear();
            tb_month_me.Clear();
            tb_year_me.Clear();

            tb_hotenngGH.Clear();
            tb_cm_cc_ngGH.Clear();
            tb_sdt_ngGH.Clear();
            tb_nghenghiepngGH.Clear();
            rTB_diachi_ngGH.Clear();
            tb_date_ngGH.Clear();
            tb_month_ngGH.Clear();
            tb_year_ngGH.Clear();

            // Clear DataGridView lsKham
            dgv_lskham.Rows.Clear();

            // Load form again
            dkKhamBenh_Load(sender, e);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            // Insert BenhNhan
            if (!string.IsNullOrWhiteSpace(tb_hoten.Text) && !string.IsNullOrWhiteSpace(tb_sotheKCB.Text)
                && !string.IsNullOrWhiteSpace(cbb_gioitinh.Text) && !string.IsNullOrWhiteSpace(tb_noisinh.Text)
                && !string.IsNullOrWhiteSpace(cbb_dantoc.Text) && !string.IsNullOrWhiteSpace(tb_cannang.Text)
                && !string.IsNullOrWhiteSpace(tb_chieucao.Text) && !string.IsNullOrWhiteSpace(BMI.Text)
                && !string.IsNullOrWhiteSpace(tb_nhietdo.Text) && !string.IsNullOrWhiteSpace(tb_day.Text)
                && !string.IsNullOrWhiteSpace(tb_month.Text) && !string.IsNullOrWhiteSpace(tb_year.Text))
            {
                string maBN = tb_maBN.Text;
                string hoten = tb_hoten.Text;
                string sotheKCB = tb_sotheKCB.Text;
                string gioitinh = cbb_gioitinh.Text;
                string diachi = getDiaChiBN();
                string noisinh = tb_noisinh.Text;
                string dantoc = cbb_dantoc.Text.Split(" - ")[1];
                float cannang = float.Parse(tb_cannang.Text);
                float chieucao = float.Parse(tb_chieucao.Text);
                float bmi = float.Parse(BMI.Text);
                float nhietdo = float.Parse(tb_nhietdo.Text);
                DateTime ngaysinh = DateTime.Parse(tb_year.Text + "-" + tb_month.Text + "-" + tb_day.Text);

                BenhNhan bn = new BenhNhan(maBN, hoten, gioitinh, dantoc, ngaysinh, sotheKCB,
                    diachi, noisinh, cannang, chieucao, nhietdo, bmi);
                // Check existion
                if (benhNhanController.isExist(maBN))
                {
                    benhNhanController.update(bn);
                    MessageBox.Show("Cập nhật đăng ký khám bệnh thành công!");
                }
                else
                {
                    benhNhanController.insert(bn);
                }

                // Insert LichSuKham
                if (!string.IsNullOrWhiteSpace(cbb_doituong.Text) && !string.IsNullOrWhiteSpace(cbb_dkkham.Text)
                    && !string.IsNullOrWhiteSpace(cbb_cakham.Text) && !string.IsNullOrWhiteSpace(cbb_dichvu.Text)
                    && !string.IsNullOrWhiteSpace(cbb_phongkham.Text) && !string.IsNullOrWhiteSpace(tb_lydokham.Text))
                {
                    string doituong = cbb_doituong.Text;
                    string maDT = doiTuongController.getDTByTenDT(doituong).MaDT;
                    int madkkham = dKKhamController.getDKKhamByTen(cbb_dkkham.Text).MaDKKham;
                    string macakham = caKhamController.getCaKhamByTen(cbb_cakham.Text).MaCaKham;
                    int maDV = dichVuController.getDVByTenDV(cbb_dichvu.Text).MaDV;

                    string tenPK = cbb_phongkham.Text.Split(" - ")[0];
                    string maPK = phongKhamController.getPKByTenPK(tenPK).MaPK;

                    string lydokham = tb_lydokham.Text;

                    DateTime ngaydkkham = DateTime.Parse(thoigiankham);

                    LichSuKham lskham = new LichSuKham(maBN, lydokham, ngaydkkham, madkkham, maDT, macakham, maPK, maDV);
                    if (lichSuKhamController.insert(lskham))
                    {
                        MessageBox.Show("Đăng ký khám bệnh thành công!");

                        // Show
                        dgv_lskham.Rows.Clear();
                        foreach (LichSuKham lsk in lichSuKhamController.getLSKhamByMaBN(bn.MaBN))
                        {
                            if (lsk != null)
                            {
                                string ngdkkham = String.Format("{0:HH:mm MM/dd/yyyy}", lsk.NgayDKKham);
                                string dt = doiTuongController.getDTByMaDT(lsk.MaDT).TenDT;
                                foreach (string DT in cbb_doituong.Items)
                                {
                                    if (DT.Contains(dt))
                                    {
                                        cbb_doituong.SelectedItem = DT;
                                    }
                                }
                                string phongkham = phongKhamController.getPKByMaPK(lsk.MaPK).TenPK;
                                int makhoa = phongKhamController.getPKByMaPK(lsk.MaPK).MaKhoa;
                                string khoa = khoaController.getKhoaByMaKhoa(makhoa).TenKhoa;
                                string dichvu = dichVuController.getDVByMaDV(lsk.MaDV).TenDV;
                                string hinhthucvao = dKKhamController.getDKKhamByMa(lsk.MaDKKham).TenDKKham;

                                string[] row = { ngdkkham, dt, hinhthucvao, khoa, phongkham, lsk.LyDoKham, dichvu };

                                dgv_lskham.Rows.Add(row);
                            }
                        }
                    }

                    // Insert BHYT
                    if (doituong.Contains("BHYT"))
                    {
                        if (!string.IsNullOrWhiteSpace(tb_bhyt_madoituong.Text) && !string.IsNullOrWhiteSpace(tb_bhyt_muchuong.Text)
                            && !string.IsNullOrWhiteSpace(tb_bhyt_matinh.Text) && !string.IsNullOrWhiteSpace(tb_bhyt_mabhxh.Text)
                            && !string.IsNullOrWhiteSpace(rTB_diachithe.Text) && !string.IsNullOrWhiteSpace(tb_noiDKKCBBD.Text)
                            && !string.IsNullOrWhiteSpace(tb_tuyenKCB.Text) && !string.IsNullOrWhiteSpace(tb_hanthe_day.Text)
                            && !string.IsNullOrWhiteSpace(tb_hanthe_month.Text) && !string.IsNullOrWhiteSpace(tb_hanthe_year.Text)
                            && !string.IsNullOrWhiteSpace(tb_ngdu5n_day.Text) && !string.IsNullOrWhiteSpace(tb_ngdu5n_month.Text)
                            && !string.IsNullOrWhiteSpace(tb_ngdu5n_year.Text))
                        {
                            string soBHYT = tb_bhyt_madoituong.Text + tb_bhyt_muchuong.Text
                                + tb_bhyt_matinh.Text + tb_bhyt_mabhxh.Text;
                            string diachithe = rTB_diachithe.Text;
                            string noiDKKCBBD = tb_noiDKKCBBD.Text;
                            string tuyenKCB = tb_tuyenKCB.Text;
                            DateTime hanthe = DateTime.Parse(tb_hanthe_year.Text + "-" + tb_hanthe_month.Text + "-" + tb_hanthe_day.Text);
                            DateTime ngaydu5nam = DateTime.Parse(tb_ngdu5n_year.Text + "-" + tb_ngdu5n_month.Text + "-" + tb_ngdu5n_day.Text);

                            BHYT bhyt = new BHYT(maBN, soBHYT, noiDKKCBBD, hanthe, ngaydu5nam, diachithe, tuyenKCB);
                            // Check existion
                            if (bhytController.isExist(maBN, soBHYT))
                            {
                                bhytController.update(bhyt);
                            }
                            else
                            {
                                bhytController.insert(bhyt);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hãy điền đầy đủ thông tin BHYT của bệnh nhân!");
                        }
                    }
                }
                /*else
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin bệnh nhân!");
                }*/

                // Insert GiaDinhBN
                // Cha
                if (!string.IsNullOrWhiteSpace(tb_hotencha.Text) && !string.IsNullOrWhiteSpace(tb_nghenghiepcha.Text)
                    && !string.IsNullOrWhiteSpace(tb_sdt_cha.Text) && !string.IsNullOrWhiteSpace(tb_cm_cc_cha.Text)
                    && !string.IsNullOrWhiteSpace(rTB_diachicha.Text) && !string.IsNullOrWhiteSpace(tb_date_cha.Text)
                    && !string.IsNullOrWhiteSpace(tb_month_cha.Text) && !string.IsNullOrWhiteSpace(tb_year_cha.Text))
                {
                    string hotencha = tb_hotencha.Text;
                    string cm_cccd_cha = tb_cm_cc_cha.Text;
                    string nghenghiepcha = tb_nghenghiepcha.Text;
                    string diachicha = rTB_diachicha.Text;
                    string sdtcha = tb_sdt_cha.Text;
                    string vaitro = "Cha";
                    DateTime ngaysinhcha = DateTime.Parse(tb_year_cha.Text + "-" + tb_month_cha.Text + "-" + tb_date_cha.Text);

                    GiaDinhBN cha = new GiaDinhBN(maBN, hotencha, cm_cccd_cha, vaitro, sdtcha, nghenghiepcha, ngaysinhcha, diachicha);
                    if (giaDinhBNController.isExist(maBN, vaitro))
                    {
                        giaDinhBNController.update(cha);
                    }
                    else
                    {
                        giaDinhBNController.insert(cha);
                    }
                }
                // Me
                if (!string.IsNullOrWhiteSpace(tb_hotenme.Text) && !string.IsNullOrWhiteSpace(tb_nghenghiepme.Text)
                    && !string.IsNullOrWhiteSpace(tb_sdt_me.Text) && !string.IsNullOrWhiteSpace(tb_cm_cc_me.Text)
                    && !string.IsNullOrWhiteSpace(rTB_diachime.Text) && !string.IsNullOrWhiteSpace(tb_date_me.Text)
                    && !string.IsNullOrWhiteSpace(tb_month_me.Text) && !string.IsNullOrWhiteSpace(tb_year_me.Text))
                {
                    string hotenme = tb_hotenme.Text;
                    string cm_cccd_me = tb_cm_cc_me.Text;
                    string nghenghiepme = tb_nghenghiepme.Text;
                    string diachime = rTB_diachime.Text;
                    string sdtme = tb_sdt_me.Text;
                    string vaitro = "Mẹ";
                    DateTime ngaysinhme = DateTime.Parse(tb_year_me.Text + "-" + tb_month_me.Text + "-" + tb_date_me.Text);

                    GiaDinhBN me = new GiaDinhBN(maBN, hotenme, cm_cccd_me, vaitro, sdtme, nghenghiepme, ngaysinhme, diachime);
                    if (giaDinhBNController.isExist(maBN, vaitro))
                    {
                        giaDinhBNController.update(me);
                    }
                    else
                    {
                        giaDinhBNController.insert(me);
                    }
                }
                // NguoiGiamHo
                if (!string.IsNullOrWhiteSpace(tb_hotenngGH.Text) && !string.IsNullOrWhiteSpace(tb_nghenghiepngGH.Text)
                    && !string.IsNullOrWhiteSpace(tb_sdt_ngGH.Text) && !string.IsNullOrWhiteSpace(tb_cm_cc_ngGH.Text)
                    && !string.IsNullOrWhiteSpace(rTB_diachi_ngGH.Text) && !string.IsNullOrWhiteSpace(tb_date_ngGH.Text)
                    && !string.IsNullOrWhiteSpace(tb_month_ngGH.Text) && !string.IsNullOrWhiteSpace(tb_year_ngGH.Text))
                {
                    string hotenngGH = tb_hotenngGH.Text;
                    string cm_cccd_ngGH = tb_cm_cc_ngGH.Text;
                    string nghenghiepngGH = tb_nghenghiepngGH.Text;
                    string diachingGH = rTB_diachi_ngGH.Text;
                    string sdtngGH = tb_sdt_ngGH.Text;
                    string vaitro = "Người giám hộ";
                    DateTime ngaysinhngGH = DateTime.Parse(tb_year_ngGH.Text + "-" + tb_month_ngGH.Text + "-" + tb_date_ngGH.Text);

                    GiaDinhBN ngGH = new GiaDinhBN(maBN, hotenngGH, cm_cccd_ngGH, vaitro, sdtngGH, nghenghiepngGH, ngaysinhngGH, diachingGH);
                    if (giaDinhBNController.isExist(maBN, vaitro))
                    {
                        giaDinhBNController.update(ngGH);
                    }
                    else
                    {
                        giaDinhBNController.insert(ngGH);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin bệnh nhân!");
            }
        }

        private void btn_save_print_Click(object sender, EventArgs e)
        {
            // Save
            btn_save_Click(sender, e);

            // Print
            PageSettings pageSettings = new PageSettings();
            pageSettings.PaperSize = new PaperSize("A5", 584, 827);
            printDocumentSTTKham.DefaultPageSettings = pageSettings;

            printPreviewDialogSTTKham.Document = printDocumentSTTKham;
            printPreviewDialogSTTKham.ShowDialog();
        }

        // FORM LOAD

        private void dkKhamBenh_Load(object sender, EventArgs e)
        {
            muchuong.Text = "0%";
            // Set ThoiGianKham
            DateTime timeNow = DateTime.Now;
            thoigiankham = String.Format("{0:HH:mm MM/dd/yyyy}", timeNow);
            ThoiGianKham.Text = String.Format("{0:HH:mm dd/MM/yyyy}", timeNow);

            // Set MaBN Automation
            tb_maBN.Text = Automation.MaBN();
            tb_maBN.Enabled = false;

            // Set items for GioiTinh Combobox
            cbb_gioitinh.Items.Add("Nam");
            cbb_gioitinh.Items.Add("Nữ");
            cbb_gioitinh.SelectedIndex = 0;

            // Set items for DanToc Combobox
            foreach (string tenDanToc in danTocController.getDSDanToc())
            {
                cbb_dantoc.Items.Add(tenDanToc);
                if (tenDanToc.Contains("Kinh"))
                {
                    cbb_dantoc.SelectedItem = tenDanToc;
                }
            }

            // Set items for QuocTich Combobox
            foreach (string tenQG in diaChiController.getDSQuocGia())
            {
                cbb_quoctich.Items.Add(tenQG);
            }

            // Set items for CaKham Combobox
            foreach (CaKham caKham in caKhamController.loadAll())
            {
                cbb_cakham.Items.Add(caKham.TenCaKham);
            }

            // Set items for DoiTuong Combobox
            foreach (DoiTuong doiTuong in doiTuongController.loadAll())
            {
                cbb_doituong.Items.Add(doiTuong.TenDT);
            }
            cbb_doituong.SelectedIndex = 0;

            // Set items for PhongKham Combobox
            foreach (PhongKham phongKham in phongKhamController.loadAll())
            {
                string khoa = khoaController.getKhoaByMaKhoa(phongKham.MaKhoa).TenKhoa;
                cbb_phongkham.Items.Add(phongKham.TenPK + " - " + khoa);
            }

            // Set items for DKKham Combobox
            foreach (DKKham dKKham in dKKhamController.loadAll())
            {
                cbb_dkkham.Items.Add(dKKham.TenDKKham);
            }
            cbb_dkkham.SelectedIndex = 0;

            // Set items for DichVu Combobox
            foreach (DichVu dv in dichVuController.loadAll())
            {
                cbb_dichvu.Items.Add(dv.TenDV);
            }
        }

        // COMBOBOX SELECTED VALUE CHANGED

        private void cbb_quoctich_SelectedValueChanged(object sender, EventArgs e)
        {
            // Get QuocTich's id from QuocTich combobox
            string[] infoQuocTich = cbb_quoctich.Text.Split(" - ");
            string maQuocTich = infoQuocTich[0];

            // Clear items of combobox
            cbb_tinh_tp.Items.Clear();
            cbb_tinh_tp.Text = null;

            cbb_quan_huyen.Items.Clear();
            cbb_quan_huyen.Text = null;

            cbb_xa_phuong.Items.Clear();
            cbb_xa_phuong.Text = null;

            // Set items for Tinh_Tp combobox
            foreach (string tenTinhTP in diaChiController.getDSTinhTP(maQuocTich))
            {
                cbb_tinh_tp.Items.Add(tenTinhTP);
                cbb_tinh_tp.SelectedIndex = 0;
            }
        }

        private void cbb_tinh_tp_SelectedValueChanged(object sender, EventArgs e)
        {
            // Get TinhTP's id from QuocTich combobox
            string[] infoTinhTP = cbb_tinh_tp.Text.Split(" - ");
            string maTinhTP = infoTinhTP[0];

            // Clear items of combobox
            cbb_quan_huyen.Items.Clear();
            cbb_quan_huyen.Text = null;

            // Set items for QuanHuyen combobox
            foreach (string tenQuanHuyen in diaChiController.getDSQuanHuyen(maTinhTP))
            {
                cbb_quan_huyen.Items.Add(tenQuanHuyen);
                cbb_quan_huyen.SelectedIndex = 0;
            }
        }

        private void cbb_quan_huyen_SelectedValueChanged(object sender, EventArgs e)
        {
            // Get QuanHuyen's id from QuocTich combobox
            string[] infoQuanHuyen = cbb_quan_huyen.Text.Split(" - ");
            string maQuanHuyen = infoQuanHuyen[0];

            // Clear items of combobox
            cbb_xa_phuong.Items.Clear();
            cbb_xa_phuong.Text = null;

            // Set items for XaPhuong combobox
            foreach (string tenXaPhuong in diaChiController.getDSXaPhuong(maQuanHuyen))
            {
                cbb_xa_phuong.Items.Add(tenXaPhuong);
                cbb_xa_phuong.SelectedIndex = 0;
            }
        }

        private void cbb_doituong_SelectedValueChanged(object sender, EventArgs e)
        {
            string doituong = cbb_doituong.Text;
            if (!doituong.Contains("BHYT"))
            {
                groupBox_BHYT.Enabled = false;
            }
            else
            {
                groupBox_BHYT.Enabled = true;
            }
        }

        // BMI RESULT AND CHECKED NUMBER INPUT

        private void tb_cannang_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_cannang.Text) && !string.IsNullOrWhiteSpace(tb_chieucao.Text))
            {
                string cannang = tb_cannang.Text;
                string chieucao = tb_chieucao.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (!Checked.IsNumber(cannang))
                {
                    MessageBox.Show("Cân nặng phải là số!");
                    tb_cannang.Text = "0.00";
                }
                else
                {
                    float weight = float.Parse(cannang);
                    float height = float.Parse(chieucao);
                    if (weight > 0.00 && height > 0.00)
                    {
                        float kqBMI = weight / (height * height);
                        BMI.Text = Math.Round(kqBMI, 3).ToString();
                    }
                }
            }
        }

        private void tb_chieucao_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_cannang.Text) && !string.IsNullOrWhiteSpace(tb_chieucao.Text))
            {
                string cannang = tb_cannang.Text;
                string chieucao = tb_chieucao.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (!Checked.IsNumber(chieucao))
                {
                    MessageBox.Show("Chiều cao phải là số!");
                    tb_chieucao.Text = "0.00";
                }
                else
                {
                    float weight = float.Parse(cannang);
                    float height = float.Parse(chieucao);
                    if (weight > 0.00 && height > 0.00)
                    {
                        float kqBMI = weight / (height * height);
                        BMI.Text = Math.Round(kqBMI, 3).ToString();
                    }
                }
            }
        }

        private void tb_nhietdo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_nhietdo.Text))
            {
                string nhietdo = tb_nhietdo.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (!Checked.IsNumber(nhietdo))
                {
                    MessageBox.Show("Nhiệt độ phải là số!");
                    tb_nhietdo.Text = "0.00";
                }
            }
        }

        // TEXT UPDATE - SEARCH IN COMBOBOX

        private void cbb_quoctich_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbb_quoctich.Text))
            {
                // Get text input from QuocTich combobox
                string quoctich = cbb_quoctich.Text;
                // Thiết lập cho con trỏ nhảy ra sau text vừa nhập
                cbb_quoctich.SelectionStart = quoctich.Length;
                // Clear items of combobox
                if (!quoctich.Contains(" - "))
                {
                    cbb_tinh_tp.Items.Clear();
                    cbb_tinh_tp.Text = null;

                    cbb_quan_huyen.Items.Clear();
                    cbb_quan_huyen.Text = null;

                    cbb_xa_phuong.Items.Clear();
                    cbb_xa_phuong.Text = null;
                }
                cbb_quoctich.Items.Clear();

                // Set items for QuocTich combobox which are contains text input
                foreach (string tenQG in diaChiController.getDSQuocGia())
                {
                    if (tenQG.ToLower().Contains(quoctich) || tenQG.Contains(quoctich))
                    {
                        cbb_quoctich.Items.Add(tenQG);
                    }
                }
                cbb_quoctich.DroppedDown = true;
            }
            else
            {
                // Clear items of combobox
                cbb_quoctich.Items.Clear();

                cbb_tinh_tp.Items.Clear();
                cbb_tinh_tp.Text = null;

                cbb_quan_huyen.Items.Clear();
                cbb_quan_huyen.Text = null;

                cbb_xa_phuong.Items.Clear();
                cbb_xa_phuong.Text = null;

                // Set all QuocTich's items for QuocTich combobox
                foreach (string tenQG in diaChiController.getDSQuocGia())
                {
                    cbb_quoctich.Items.Add(tenQG);
                }
                cbb_quoctich.DroppedDown = true;
            }
        }

        private void cbb_tinh_tp_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbb_tinh_tp.Text))
            {
                // Get text input from TinhTP combobox
                string tinh_tp = cbb_tinh_tp.Text;
                // Clear items of combobox
                if (!tinh_tp.Contains(" - "))
                {
                    cbb_quan_huyen.Items.Clear();
                    cbb_quan_huyen.Text = null;

                    cbb_xa_phuong.Items.Clear();
                    cbb_xa_phuong.Text = null;
                }
                cbb_tinh_tp.Items.Clear();

                // Get QuocTich's id
                string[] infoQuocTich = cbb_quoctich.Text.Split(" - ");
                string maQuocTich = infoQuocTich[0];

                // Set items for TinhTP combobox which are contains text input
                foreach (string tenTinhTP in diaChiController.getDSTinhTP(maQuocTich))
                {
                    if (tenTinhTP.ToLower().Contains(tinh_tp) || tenTinhTP.Contains(tinh_tp))
                    {
                        cbb_tinh_tp.Items.Add(tenTinhTP);
                    }
                }
                cbb_tinh_tp.DroppedDown = true;
            }
            else
            {
                // Clear items of combobox
                cbb_tinh_tp.Items.Clear();

                cbb_quan_huyen.Items.Clear();
                cbb_quan_huyen.Text = null;

                cbb_xa_phuong.Items.Clear();
                cbb_xa_phuong.Text = null;

                // Get QuocTich's id
                string[] infoQuocTich = cbb_quoctich.Text.Split(" - ");
                string maQuocTich = infoQuocTich[0];

                // Set all QuocTich's items for QuocTich combobox
                foreach (string tenTinhTP in diaChiController.getDSTinhTP(maQuocTich))
                {
                    cbb_tinh_tp.Items.Add(tenTinhTP);
                }
                cbb_tinh_tp.DroppedDown = true;
            }
        }

        private void cbb_quan_huyen_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbb_quan_huyen.Text))
            {
                // Get text input from QuanHuyen combobox
                string quan_huyen = cbb_quan_huyen.Text;
                // Clear items of combobox
                if (!quan_huyen.Contains(" - "))
                {
                    cbb_xa_phuong.Items.Clear();
                    cbb_xa_phuong.Text = null;
                }
                cbb_quan_huyen.Items.Clear();

                // Get TinhTP's id
                string[] infoTinhTP = cbb_tinh_tp.Text.Split(" - ");
                string maTinhTP = infoTinhTP[0];

                // Set items for QuanHuyen combobox which are contains text input
                foreach (string tenQuanHuyen in diaChiController.getDSQuanHuyen(maTinhTP))
                {
                    if (tenQuanHuyen.ToLower().Contains(quan_huyen) || tenQuanHuyen.Contains(quan_huyen))
                    {
                        cbb_quan_huyen.Items.Add(tenQuanHuyen);
                    }
                }
                cbb_quan_huyen.DroppedDown = true;
            }
            else
            {
                // Clear items of combobox
                cbb_quan_huyen.Items.Clear();

                cbb_xa_phuong.Items.Clear();
                cbb_xa_phuong.Text = null;

                // Get TinhTP's id
                string[] infoTinhTP = cbb_tinh_tp.Text.Split(" - ");
                string maTinhTP = infoTinhTP[0];

                // Set all QuanHuyen's items for QuocTich combobox
                foreach (string tenQuanHuyen in diaChiController.getDSQuanHuyen(maTinhTP))
                {
                    cbb_quan_huyen.Items.Add(tenQuanHuyen);
                }
                cbb_quan_huyen.DroppedDown = true;
            }
        }

        private void cbb_xa_phuong_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbb_xa_phuong.Text))
            {
                // Get text input from XaPhuong combobox
                string xa_phuong = cbb_xa_phuong.Text;
                // Clear items of combobox
                cbb_xa_phuong.Items.Clear();

                // Get QuanHuyen's id
                string[] infoQuanHuyen = cbb_quan_huyen.Text.Split(" - ");
                string maQuanHuyen = infoQuanHuyen[0];

                // Set items for XaPhuong combobox which are contains text input
                foreach (string tenXaPhuong in diaChiController.getDSXaPhuong(maQuanHuyen))
                {
                    if (tenXaPhuong.ToLower().Contains(xa_phuong) || tenXaPhuong.Contains(xa_phuong))
                    {
                        cbb_xa_phuong.Items.Add(tenXaPhuong);
                    }
                }
                cbb_xa_phuong.DroppedDown = true;
            }
            else
            {
                // Clear items of combobox
                cbb_xa_phuong.Items.Clear();

                // Get QuanHuyen's id
                string[] infoQuanHuyen = cbb_quan_huyen.Text.Split(" - ");
                string maQuanHuyen = infoQuanHuyen[0];

                // Set all XaPhuong's items for QuocTich combobox
                foreach (string tenXaPhuong in diaChiController.getDSXaPhuong(maQuanHuyen))
                {
                    cbb_xa_phuong.Items.Add(tenXaPhuong);
                }
                cbb_xa_phuong.DroppedDown = true;
            }
        }

        private void cbb_dantoc_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbb_dantoc.Text))
            {
                string dantoc = cbb_dantoc.Text;

                cbb_dantoc.Items.Clear();

                foreach (string tenDanToc in danTocController.getDSDanToc())
                {
                    if (tenDanToc.ToLower().Contains(dantoc) || tenDanToc.Contains(dantoc))
                    {
                        cbb_dantoc.Items.Add(tenDanToc);
                    }
                }
                cbb_dantoc.DroppedDown = true;
            }
            else
            {
                cbb_dantoc.Items.Clear();

                foreach (string tenDanToc in danTocController.getDSDanToc())
                {
                    cbb_dantoc.Items.Add(tenDanToc);
                }
                cbb_dantoc.DroppedDown = true;
            }
        }

        // CHECKED SOBHYT

        private void tb_bhyt_madoituong_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_bhyt_madoituong.Text))
            {
                string madoituong = tb_bhyt_madoituong.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (Checked.IsNumber(madoituong))
                {
                    MessageBox.Show("Mã đối tượng BHYT phải là chữ!");
                    tb_bhyt_madoituong.Clear();
                }
                else
                {
                    if (madoituong.Length > 2)
                    {
                        MessageBox.Show("Mã đối tượng BHYT phải có 2 kí tự!");
                        tb_bhyt_madoituong.Clear();
                    }
                }
            }
        }

        private void tb_bhyt_muchuong_TextChanged(object sender, EventArgs e)
        {
            tb_bhyt_madoituong.Text = tb_bhyt_madoituong.Text.ToUpper();

            if (!string.IsNullOrWhiteSpace(tb_bhyt_muchuong.Text))
            {
                string muchuongStr = tb_bhyt_muchuong.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (Checked.IsNumber(muchuongStr))
                {
                    int muchuong_bhyt = Int32.Parse(muchuongStr);
                    if (muchuong_bhyt == 1)
                    {
                        muchuong.Text = "100%";
                    }
                    else if (muchuong_bhyt == 2)
                    {
                        muchuong.Text = "100%";
                    }
                    else if (muchuong_bhyt == 3)
                    {
                        muchuong.Text = "95%";
                    }
                    else if (muchuong_bhyt == 4)
                    {
                        muchuong.Text = "80%";
                    }
                    else if (muchuong_bhyt == 5)
                    {
                        muchuong.Text = "100%";
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mức hưởng BHYT từ 1 đến 5!");
                        tb_bhyt_muchuong.Clear();
                        muchuong.Text = "0%";
                    }
                }
                else
                {
                    MessageBox.Show("Mức hưởng BHYT phải là số!");
                    tb_bhyt_muchuong.Clear();
                }
            }
            else
            {
                muchuong.Text = "0%";
            }
        }

        private void tb_bhyt_matinh_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_bhyt_matinh.Text))
            {
                string matinh = tb_bhyt_matinh.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (!Checked.IsNumber(matinh))
                {
                    MessageBox.Show("Mã tỉnh phải là số!");
                    tb_bhyt_matinh.Clear();
                }
                /*else
                {
                    if (matinh.Length > 2)
                    {

                    }
                }*/
            }
        }

        private void tb_bhyt_mabhxh_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_bhyt_mabhxh.Text))
            {
                string mabhxh = tb_bhyt_mabhxh.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (!Checked.IsNumber(mabhxh))
                {
                    MessageBox.Show("Mã BHXH cá nhân phải là số!");
                    tb_bhyt_mabhxh.Clear();
                }
                else
                {
                    if (mabhxh.Length > 10)
                    {
                        MessageBox.Show("Mã BHXH cá nhân phải có 10 số!");
                        tb_bhyt_mabhxh.Clear();
                    }
                }
            }
        }

        // CHECKED PHONE INPUT

        private void checkedSDTInput(TextBox tb_sdt)
        {
            if (!string.IsNullOrWhiteSpace(tb_sdt.Text))
            {
                string sdt = tb_sdt.Text;
                // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
                if (!Checked.IsNumber(sdt))
                {
                    MessageBox.Show("Số điện thoại thân nhân phải là số!");
                    tb_sdt.Clear();
                }
                else
                {
                    if (sdt.Length > 10)
                    {
                        MessageBox.Show("Số điện thoại phải có 10 số!");
                        tb_sdt.Clear();
                    }
                }
            }
        }

        private void tb_searchBN_SDT_TextChanged(object sender, EventArgs e)
        {
            checkedSDTInput(tb_searchBN_SDT);
        }

        private void tb_sdt_cha_TextChanged(object sender, EventArgs e)
        {
            checkedSDTInput(tb_sdt_cha);
        }

        private void tb_sdt_me_TextChanged(object sender, EventArgs e)
        {
            checkedSDTInput(tb_sdt_me);
        }

        private void tb_sdt_ngGH_TextChanged(object sender, EventArgs e)
        {
            checkedSDTInput(tb_sdt_ngGH);
        }

        // CHECKED DAY INPUT

        private void checkedDayInput(TextBox tb_day, TextBox tb_month)
        {
            if (!string.IsNullOrWhiteSpace(tb_day.Text))
            {
                string day = tb_day.Text;
                if (!Checked.CheckedDate(day))
                {
                    MessageBox.Show("Ngày phải là số và một tháng có tối đa 31 ngày!");
                    tb_day.Clear();
                }
                if (!string.IsNullOrWhiteSpace(tb_month.Text))
                {
                    checkedMonthInput(tb_month, tb_day);
                }
            }
        }

        private void tb_day_TextChanged(object sender, EventArgs e)
        {
            checkedDayInput(tb_day, tb_month);
        }

        private void tb_hanthe_day_TextChanged(object sender, EventArgs e)
        {
            checkedDayInput(tb_hanthe_day, tb_hanthe_month);
        }

        private void tb_ngdu5n_day_TextChanged(object sender, EventArgs e)
        {
            checkedDayInput(tb_ngdu5n_day, tb_ngdu5n_month);
        }

        private void tb_date_cha_TextChanged(object sender, EventArgs e)
        {
            checkedDayInput(tb_date_cha, tb_month_cha);
        }

        private void tb_date_me_TextChanged(object sender, EventArgs e)
        {
            checkedDayInput(tb_date_me, tb_month_me);
        }

        private void tb_date_ngGH_TextChanged(object sender, EventArgs e)
        {
            checkedDayInput(tb_date_ngGH, tb_month_ngGH);
        }

        // CHECKED MONTH INPUT

        private void checkedMonthInput(TextBox tb_month, TextBox tb_day)
        {
            if (!string.IsNullOrWhiteSpace(tb_month.Text) && !string.IsNullOrWhiteSpace(tb_day.Text))
            {
                string month = tb_month.Text;
                string day = tb_day.Text;
                if (!Checked.CheckedMonth(month))
                {
                    MessageBox.Show("Tháng phải là số và một năm có tối đa 12 tháng!");
                    tb_month.Clear();
                }
                else
                {
                    int mm = Int32.Parse(month);
                    int dd = Int32.Parse(day);

                    if (mm == 2)
                    {
                        if (dd > 29)
                        {
                            MessageBox.Show("Tháng 2 có tối đa 29 ngày!");
                            tb_day.Clear();
                        }
                    }
                    if (mm == 1 || mm == 3 || mm == 5 || mm == 7 || mm == 8 || mm == 10 || mm == 12)
                    {
                        if (dd > 31)
                        {
                            MessageBox.Show("Tháng này có tối đa 31 ngày!");
                            tb_day.Clear();
                        }
                    }
                    if (mm == 4 || mm == 6 || mm == 9 || mm == 11)
                    {
                        if (dd > 30)
                        {
                            MessageBox.Show("Tháng này có tối đa 30 ngày!");
                            tb_day.Clear();
                        }
                    }
                }
            }
        }

        private void tb_month_TextChanged(object sender, EventArgs e)
        {
            checkedMonthInput(tb_month, tb_day);
        }

        private void tb_hanthe_month_TextChanged(object sender, EventArgs e)
        {
            checkedMonthInput(tb_hanthe_month, tb_hanthe_day);
        }

        private void tb_ngdu5n_month_TextChanged(object sender, EventArgs e)
        {
            checkedMonthInput(tb_ngdu5n_month, tb_ngdu5n_day);
        }

        private void tb_month_cha_TextChanged(object sender, EventArgs e)
        {
            checkedMonthInput(tb_month_cha, tb_date_cha);
        }

        private void tb_month_me_TextChanged(object sender, EventArgs e)
        {
            checkedMonthInput(tb_month_me, tb_date_me);
        }

        private void tb_month_ngGH_TextChanged(object sender, EventArgs e)
        {
            checkedMonthInput(tb_month_ngGH, tb_date_ngGH);
        }

        // CHECKED YEAR INPUT

        private void checkedYearInput(TextBox tb_year)
        {
            if (!string.IsNullOrWhiteSpace(tb_year.Text))
            {
                string year = tb_year.Text;
                if (!Checked.IsNumber(year))
                {
                    MessageBox.Show("Năm phải là số!");
                    tb_year.Clear();
                }
            }
        }

        private void tb_year_TextChanged(object sender, EventArgs e)
        {
            checkedYearInput(tb_year);
        }

        private void tb_year_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_year.Text))
            {
                string year = tb_year.Text;
                int tuoi = DateTime.Now.Year - Int32.Parse(year);
                if (tuoi >= 17)
                {
                    MessageBox.Show("Bệnh nhân vượt quá tuổi quy định (0 - 16 tuổi)!");
                    tb_year.Clear();
                }
            }
        }

        private void tb_hanthe_year_TextChanged(object sender, EventArgs e)
        {
            checkedYearInput(tb_hanthe_year);
        }

        private void tb_ngdu5n_year_TextChanged(object sender, EventArgs e)
        {
            checkedYearInput(tb_ngdu5n_year);
        }

        private void tb_year_cha_TextChanged(object sender, EventArgs e)
        {
            checkedYearInput(tb_year_cha);
        }

        private void tb_year_me_TextChanged(object sender, EventArgs e)
        {
            checkedYearInput(tb_year_me);
        }

        private void tb_year_ngGH_TextChanged(object sender, EventArgs e)
        {
            checkedYearInput(tb_year_ngGH);
        }

        // BUTTON CUNGDIACHIBN

        private string getDiaChiBN()
        {
            string diachi = "";

            if (!string.IsNullOrWhiteSpace(cbb_quoctich.Text) && !string.IsNullOrWhiteSpace(tb_SN_thon_pho.Text))
            {
                string[] infoQuocTich = cbb_quoctich.Text.Split(" - ");
                string quoctich = infoQuocTich[1];
                string sn_thonpho = tb_SN_thon_pho.Text;

                if (!string.IsNullOrWhiteSpace(cbb_tinh_tp.Text))
                {
                    string[] infoTinhtp = cbb_tinh_tp.Text.Split(" - ");
                    string tinhtp = infoTinhtp[1];

                    if (!string.IsNullOrWhiteSpace(cbb_quan_huyen.Text))
                    {
                        string[] infoQuanhuyen = cbb_quan_huyen.Text.Split(" - ");
                        string quanhuyen = infoQuanhuyen[1];

                        if (!string.IsNullOrWhiteSpace(cbb_xa_phuong.Text))
                        {
                            string[] infoXaphuong = cbb_xa_phuong.Text.Split(" - ");
                            string xaphuong = infoXaphuong[1];

                            diachi = sn_thonpho + ", " + xaphuong + ", " + quanhuyen + ", " + tinhtp + ", " + quoctich;
                        }
                        else
                            diachi = sn_thonpho + ", " + quanhuyen + ", " + tinhtp + ", " + quoctich;
                    }
                    else
                        diachi = sn_thonpho + ", " + tinhtp + ", " + quoctich;
                }
                else
                    diachi = sn_thonpho + ", " + quoctich;
            }
            else
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin số nhà/thôn/phố và Quốc tịch của bệnh nhân!");
            }

            return diachi;
        }

        private void btn_cungdiachiBN1_Click(object sender, EventArgs e)
        {
            rTB_diachicha.Text = getDiaChiBN();
        }

        private void btn_cungdiachiBN2_Click(object sender, EventArgs e)
        {
            rTB_diachime.Text = getDiaChiBN();
        }

        private void btn_cungdiachiBN3_Click(object sender, EventArgs e)
        {
            rTB_diachi_ngGH.Text = getDiaChiBN();
        }

        // SEARCH BN

        private void tb_searchBN_theKCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn âm thanh mặc định khi nhấn Enter

                if (!string.IsNullOrWhiteSpace(tb_searchBN_theKCB.Text))
                {
                    string search = tb_searchBN_theKCB.Text;

                    // BenhNhan
                    BenhNhan bn = benhNhanController.getBNBySoTheKCB(search);
                    if (bn != null && bn.SoTheKCB == search)
                    {
                        tb_maBN.Text = bn.MaBN;
                        tb_hoten.Text = bn.HoTen;
                        tb_sotheKCB.Text = bn.SoTheKCB;
                        string[] ngaysinh = bn.NgaySinh.ToString().Split("/");
                        tb_day.Text = ngaysinh[1];
                        tb_month.Text = ngaysinh[0];
                        tb_year.Text = ngaysinh[2].Split(" ")[0];
                        string[] diachi = bn.DiaChi.Split(",");
                        tb_SN_thon_pho.Text = diachi[0];
                        cbb_dantoc.Text = null;
                        foreach (string dantoc in cbb_dantoc.Items)
                        {
                            if (dantoc.Contains(bn.DanToc))
                            {
                                cbb_dantoc.SelectedItem = dantoc;
                            }
                        }
                        cbb_quoctich.Text = null;
                        cbb_tinh_tp.Text = null;
                        cbb_quan_huyen.Text = null;
                        cbb_xa_phuong.Text = null;
                        foreach (string quoctich in cbb_quoctich.Items)
                        {
                            if (quoctich.Contains(diachi[diachi.Length - 1]))
                            {
                                cbb_quoctich.SelectedItem = quoctich;
                            }
                        }
                        if (diachi.Length == 5)
                        {
                            foreach (string tinhtp in cbb_tinh_tp.Items)
                            {
                                if (tinhtp.Contains(diachi[3]))
                                {
                                    cbb_tinh_tp.SelectedItem = tinhtp;
                                }
                            }
                            foreach (string quanhuyen in cbb_quan_huyen.Items)
                            {
                                if (quanhuyen.Contains(diachi[2]))
                                {
                                    cbb_quan_huyen.SelectedItem = quanhuyen;
                                }
                            }
                            foreach (string xaphuong in cbb_xa_phuong.Items)
                            {
                                if (xaphuong.Contains(diachi[1]))
                                {
                                    cbb_xa_phuong.SelectedItem = xaphuong;
                                }
                            }
                        }
                        if (diachi.Length == 4)
                        {
                            foreach (string tinhtp in cbb_tinh_tp.Items)
                            {
                                if (tinhtp.Contains(diachi[2]))
                                {
                                    cbb_tinh_tp.SelectedItem = tinhtp;
                                }
                            }
                            foreach (string quanhuyen in cbb_quan_huyen.Items)
                            {
                                if (quanhuyen.Contains(diachi[1]))
                                {
                                    cbb_quan_huyen.SelectedItem = quanhuyen;
                                }
                            }
                        }
                        tb_noisinh.Text = bn.NoiSinh;
                        cbb_gioitinh.SelectedItem = bn.GioiTinh;
                        tb_cannang.Text = bn.CanNang.ToString();
                        tb_chieucao.Text = bn.ChieuCao.ToString();
                        tb_nhietdo.Text = bn.NhietDo.ToString();

                        // LichSuKham
                        dgv_lskham.Rows.Clear();

                        foreach (LichSuKham lskham in lichSuKhamController.getLSKhamByMaBN(bn.MaBN))
                        {
                            if (lskham != null)
                            {
                                string ngaydkkham = String.Format("{0:HH:mm dd/MM/yyyy}", lskham.NgayDKKham);
                                string doituong = doiTuongController.getDTByMaDT(lskham.MaDT).TenDT;
                                foreach (string DT in cbb_doituong.Items)
                                {
                                    if (DT.Contains(doituong))
                                    {
                                        cbb_doituong.SelectedItem = DT;
                                    }
                                }
                                string phongkham = phongKhamController.getPKByMaPK(lskham.MaPK).TenPK;
                                int makhoa = phongKhamController.getPKByMaPK(lskham.MaPK).MaKhoa;
                                string khoa = khoaController.getKhoaByMaKhoa(makhoa).TenKhoa;
                                string dichvu = dichVuController.getDVByMaDV(lskham.MaDV).TenDV;
                                string hinhthucvao = dKKhamController.getDKKhamByMa(lskham.MaDKKham).TenDKKham;

                                string[] row = { ngaydkkham, doituong, hinhthucvao, khoa, phongkham, lskham.LyDoKham, dichvu };

                                dgv_lskham.Rows.Add(row);

                                // BHYT
                                // Clear contents of BHYT's textBox
                                tb_sotheKCB.Clear();
                                tb_bhyt_madoituong.Clear();
                                tb_bhyt_muchuong.Clear();
                                tb_bhyt_matinh.Clear();
                                tb_bhyt_mabhxh.Clear();
                                rTB_diachithe.Clear();
                                tb_noiDKKCBBD.Clear();
                                tb_tuyenKCB.Clear();
                                tb_hanthe_day.Clear();
                                tb_hanthe_month.Clear();
                                tb_hanthe_year.Clear();
                                tb_ngdu5n_day.Clear();
                                tb_ngdu5n_month.Clear();
                                tb_ngdu5n_year.Clear();
                                muchuong.Text = "0%";

                                if (doituong.Contains("BHYT"))
                                {
                                    BHYT bhyt = bhytController.getBHYTByMaBN(bn.MaBN);
                                    if (bhyt != null && bhyt.MaBN == bn.MaBN)
                                    {
                                        char[] chars = bhyt.SoBHYT.ToCharArray();
                                        tb_bhyt_madoituong.Text = new string(chars, 0, 2);
                                        tb_bhyt_muchuong.Text = new string(chars, 2, 1);
                                        tb_bhyt_matinh.Text = new string(chars, 3, 2);
                                        tb_bhyt_mabhxh.Text = new string(chars, 5, 10);
                                        tb_noiDKKCBBD.Text = bhyt.DKKCBBD;
                                        rTB_diachithe.Text = bhyt.DiaChiThe;
                                        tb_tuyenKCB.Text = bhyt.TuyenKCB;
                                        string[] hanthe = bhyt.HanThe.ToString().Split("/");
                                        tb_hanthe_day.Text = hanthe[1];
                                        tb_hanthe_month.Text = hanthe[0];
                                        tb_hanthe_year.Text = hanthe[2].Split(" ")[0];
                                        string[] ngdu5nam = bhyt.NgayDu5Nam.ToString().Split("/");
                                        tb_ngdu5n_day.Text = ngdu5nam[1];
                                        tb_ngdu5n_month.Text = ngdu5nam[0];
                                        tb_ngdu5n_year.Text = ngdu5nam[2].Split(" ")[0];
                                    }
                                }
                            }
                        }

                        // GiaDinhBN
                        // Clear contents of Family Infomation's textBox
                        tb_hotencha.Clear();
                        tb_cm_cc_cha.Clear();
                        tb_sdt_cha.Clear();
                        tb_nghenghiepcha.Clear();
                        rTB_diachicha.Clear();
                        tb_date_cha.Clear();
                        tb_month_cha.Clear();
                        tb_year_cha.Clear();

                        tb_hotenme.Clear();
                        tb_cm_cc_me.Clear();
                        tb_sdt_me.Clear();
                        tb_nghenghiepme.Clear();
                        rTB_diachime.Clear();
                        tb_date_me.Clear();
                        tb_month_me.Clear();
                        tb_year_me.Clear();

                        tb_hotenngGH.Clear();
                        tb_cm_cc_ngGH.Clear();
                        tb_sdt_ngGH.Clear();
                        tb_nghenghiepngGH.Clear();
                        rTB_diachi_ngGH.Clear();
                        tb_date_ngGH.Clear();
                        tb_month_ngGH.Clear();
                        tb_year_ngGH.Clear();

                        foreach (GiaDinhBN gdBN in giaDinhBNController.getGDBNByMaBN(bn.MaBN))
                        {
                            if (gdBN != null)
                            {
                                if (gdBN.VaiTro == "Cha")
                                {
                                    tb_hotencha.Text = gdBN.HoTenTN;
                                    tb_cm_cc_cha.Text = gdBN.CM_CCCD;
                                    tb_nghenghiepcha.Text = gdBN.NgheNghiep;
                                    rTB_diachicha.Text = gdBN.DiaChi;
                                    tb_sdt_cha.Text = gdBN.SoDT;
                                    string[] ngaysinhTN = gdBN.NgaySinh.ToString().Split("/");
                                    tb_date_cha.Text = ngaysinhTN[1];
                                    tb_month_cha.Text = ngaysinhTN[0];
                                    tb_year_cha.Text = ngaysinhTN[2].Split(" ")[0];
                                }
                                else if (gdBN.VaiTro == "Mẹ")
                                {
                                    tb_hotenme.Text = gdBN.HoTenTN;
                                    tb_cm_cc_me.Text = gdBN.CM_CCCD;
                                    tb_nghenghiepme.Text = gdBN.NgheNghiep;
                                    rTB_diachime.Text = gdBN.DiaChi;
                                    tb_sdt_me.Text = gdBN.SoDT;
                                    string[] ngaysinhTN = gdBN.NgaySinh.ToString().Split("/");
                                    tb_date_me.Text = ngaysinhTN[1];
                                    tb_month_me.Text = ngaysinhTN[0];
                                    tb_year_me.Text = ngaysinhTN[2].Split(" ")[0];
                                }
                                else if (gdBN.VaiTro == "Người giám hộ")
                                {
                                    tb_hotenngGH.Text = gdBN.HoTenTN;
                                    tb_cm_cc_ngGH.Text = gdBN.CM_CCCD;
                                    tb_nghenghiepngGH.Text = gdBN.NgheNghiep;
                                    rTB_diachi_ngGH.Text = gdBN.DiaChi;
                                    tb_sdt_ngGH.Text = gdBN.SoDT;
                                    string[] ngaysinhTN = gdBN.NgaySinh.ToString().Split("/");
                                    tb_date_ngGH.Text = ngaysinhTN[1];
                                    tb_month_ngGH.Text = ngaysinhTN[0];
                                    tb_year_ngGH.Text = ngaysinhTN[2].Split(" ")[0];
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bệnh nhân có số thẻ " + search);
                    }
                }
            }
        }

        private void tb_searchBN_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn âm thanh mặc định khi nhấn Enter

                if (!string.IsNullOrWhiteSpace(tb_searchBN_SDT.Text))
                {
                    string search = tb_searchBN_SDT.Text;

                    GiaDinhBN giaDinhBN = giaDinhBNController.getGDBNBySDT(search);
                    BenhNhan bn = benhNhanController.getBNByMaBN(giaDinhBN.MaBN);
                    if (bn != null && giaDinhBN.SoDT == search)
                    {
                        tb_maBN.Text = bn.MaBN;
                        tb_hoten.Text = bn.HoTen;
                        tb_sotheKCB.Text = bn.SoTheKCB;
                        string[] ngaysinh = bn.NgaySinh.ToString().Split("/");
                        tb_day.Text = ngaysinh[1];
                        tb_month.Text = ngaysinh[0];
                        tb_year.Text = ngaysinh[2].Split(" ")[0];
                        string[] diachi = bn.DiaChi.Split(",");
                        tb_SN_thon_pho.Text = diachi[0];
                        cbb_dantoc.Text = null;
                        foreach (string dantoc in cbb_dantoc.Items)
                        {
                            if (dantoc.Contains(bn.DanToc))
                            {
                                cbb_dantoc.SelectedItem = dantoc;
                            }
                        }
                        cbb_quoctich.Text = null;
                        cbb_tinh_tp.Text = null;
                        cbb_quan_huyen.Text = null;
                        cbb_xa_phuong.Text = null;
                        foreach (string quoctich in cbb_quoctich.Items)
                        {
                            if (quoctich.Contains(diachi[diachi.Length - 1]))
                            {
                                cbb_quoctich.SelectedItem = quoctich;
                            }
                        }
                        if (diachi.Length == 5)
                        {
                            foreach (string tinhtp in cbb_tinh_tp.Items)
                            {
                                if (tinhtp.Contains(diachi[3]))
                                {
                                    cbb_tinh_tp.SelectedItem = tinhtp;
                                }
                            }
                            foreach (string quanhuyen in cbb_quan_huyen.Items)
                            {
                                if (quanhuyen.Contains(diachi[2]))
                                {
                                    cbb_quan_huyen.SelectedItem = quanhuyen;
                                }
                            }
                            foreach (string xaphuong in cbb_xa_phuong.Items)
                            {
                                if (xaphuong.Contains(diachi[1]))
                                {
                                    cbb_xa_phuong.SelectedItem = xaphuong;
                                }
                            }
                        }
                        if (diachi.Length == 4)
                        {
                            foreach (string tinhtp in cbb_tinh_tp.Items)
                            {
                                if (tinhtp.Contains(diachi[2]))
                                {
                                    cbb_tinh_tp.SelectedItem = tinhtp;
                                }
                            }
                            foreach (string quanhuyen in cbb_quan_huyen.Items)
                            {
                                if (quanhuyen.Contains(diachi[1]))
                                {
                                    cbb_quan_huyen.SelectedItem = quanhuyen;
                                }
                            }
                        }
                        tb_noisinh.Text = bn.NoiSinh;
                        cbb_gioitinh.SelectedItem = bn.GioiTinh;
                        tb_cannang.Text = bn.CanNang.ToString();
                        tb_chieucao.Text = bn.ChieuCao.ToString();
                        tb_nhietdo.Text = bn.NhietDo.ToString();

                        // LichSuKham
                        dgv_lskham.Rows.Clear();

                        foreach (LichSuKham lskham in lichSuKhamController.getLSKhamByMaBN(bn.MaBN))
                        {
                            if (lskham != null)
                            {
                                string ngaydkkham = String.Format("{0:HH:mm dd/MM/yyyy}", lskham.NgayDKKham);
                                string doituong = doiTuongController.getDTByMaDT(lskham.MaDT).TenDT;
                                foreach (string DT in cbb_doituong.Items)
                                {
                                    if (DT.Contains(doituong))
                                    {
                                        cbb_doituong.SelectedItem = DT;
                                    }
                                }
                                string phongkham = phongKhamController.getPKByMaPK(lskham.MaPK).TenPK;
                                int makhoa = phongKhamController.getPKByMaPK(lskham.MaPK).MaKhoa;
                                string khoa = khoaController.getKhoaByMaKhoa(makhoa).TenKhoa;
                                string dichvu = dichVuController.getDVByMaDV(lskham.MaDV).TenDV;
                                string hinhthucvao = dKKhamController.getDKKhamByMa(lskham.MaDKKham).TenDKKham;

                                string[] row = { ngaydkkham, doituong, hinhthucvao, khoa, phongkham, lskham.LyDoKham, dichvu };

                                dgv_lskham.Rows.Add(row);

                                // BHYT
                                // Clear contents of BHYT's textBox
                                tb_sotheKCB.Clear();
                                tb_bhyt_madoituong.Clear();
                                tb_bhyt_muchuong.Clear();
                                tb_bhyt_matinh.Clear();
                                tb_bhyt_mabhxh.Clear();
                                rTB_diachithe.Clear();
                                tb_noiDKKCBBD.Clear();
                                tb_tuyenKCB.Clear();
                                tb_hanthe_day.Clear();
                                tb_hanthe_month.Clear();
                                tb_hanthe_year.Clear();
                                tb_ngdu5n_day.Clear();
                                tb_ngdu5n_month.Clear();
                                tb_ngdu5n_year.Clear();
                                muchuong.Text = "0%";

                                if (doituong.Contains("BHYT"))
                                {
                                    BHYT bhyt = bhytController.getBHYTByMaBN(bn.MaBN);
                                    if (bhyt != null && bhyt.MaBN == bn.MaBN)
                                    {
                                        char[] chars = bhyt.SoBHYT.ToCharArray();
                                        tb_bhyt_madoituong.Text = new string(chars, 0, 2);
                                        tb_bhyt_muchuong.Text = new string(chars, 2, 1);
                                        tb_bhyt_matinh.Text = new string(chars, 3, 2);
                                        tb_bhyt_mabhxh.Text = new string(chars, 5, 10);
                                        tb_noiDKKCBBD.Text = bhyt.DKKCBBD;
                                        rTB_diachithe.Text = bhyt.DiaChiThe;
                                        tb_tuyenKCB.Text = bhyt.TuyenKCB;
                                        string[] hanthe = bhyt.HanThe.ToString().Split("/");
                                        tb_hanthe_day.Text = hanthe[1];
                                        tb_hanthe_month.Text = hanthe[0];
                                        tb_hanthe_year.Text = hanthe[2].Split(" ")[0];
                                        string[] ngdu5nam = bhyt.NgayDu5Nam.ToString().Split("/");
                                        tb_ngdu5n_day.Text = ngdu5nam[1];
                                        tb_ngdu5n_month.Text = ngdu5nam[0];
                                        tb_ngdu5n_year.Text = ngdu5nam[2].Split(" ")[0];
                                    }
                                }
                            }
                        }

                        // GiaDinhBN
                        // Clear contents of Family Infomation's textBox
                        tb_hotencha.Clear();
                        tb_cm_cc_cha.Clear();
                        tb_sdt_cha.Clear();
                        tb_nghenghiepcha.Clear();
                        rTB_diachicha.Clear();
                        tb_date_cha.Clear();
                        tb_month_cha.Clear();
                        tb_year_cha.Clear();

                        tb_hotenme.Clear();
                        tb_cm_cc_me.Clear();
                        tb_sdt_me.Clear();
                        tb_nghenghiepme.Clear();
                        rTB_diachime.Clear();
                        tb_date_me.Clear();
                        tb_month_me.Clear();
                        tb_year_me.Clear();

                        tb_hotenngGH.Clear();
                        tb_cm_cc_ngGH.Clear();
                        tb_sdt_ngGH.Clear();
                        tb_nghenghiepngGH.Clear();
                        rTB_diachi_ngGH.Clear();
                        tb_date_ngGH.Clear();
                        tb_month_ngGH.Clear();
                        tb_year_ngGH.Clear();

                        foreach (GiaDinhBN gdBN in giaDinhBNController.getGDBNByMaBN(bn.MaBN))
                        {
                            if (gdBN != null)
                            {
                                if (gdBN.VaiTro == "Cha")
                                {
                                    tb_hotencha.Text = gdBN.HoTenTN;
                                    tb_cm_cc_cha.Text = gdBN.CM_CCCD;
                                    tb_nghenghiepcha.Text = gdBN.NgheNghiep;
                                    rTB_diachicha.Text = gdBN.DiaChi;
                                    tb_sdt_cha.Text = gdBN.SoDT;
                                    string[] ngaysinhTN = gdBN.NgaySinh.ToString().Split("/");
                                    tb_date_cha.Text = ngaysinhTN[1];
                                    tb_month_cha.Text = ngaysinhTN[0];
                                    tb_year_cha.Text = ngaysinhTN[2].Split(" ")[0];
                                }
                                else if (gdBN.VaiTro == "Mẹ")
                                {
                                    tb_hotenme.Text = gdBN.HoTenTN;
                                    tb_cm_cc_me.Text = gdBN.CM_CCCD;
                                    tb_nghenghiepme.Text = gdBN.NgheNghiep;
                                    rTB_diachime.Text = gdBN.DiaChi;
                                    tb_sdt_me.Text = gdBN.SoDT;
                                    string[] ngaysinhTN = gdBN.NgaySinh.ToString().Split("/");
                                    tb_date_me.Text = ngaysinhTN[1];
                                    tb_month_me.Text = ngaysinhTN[0];
                                    tb_year_me.Text = ngaysinhTN[2].Split(" ")[0];
                                }
                                else if (gdBN.VaiTro == "Người giám hộ")
                                {
                                    tb_hotenngGH.Text = gdBN.HoTenTN;
                                    tb_cm_cc_ngGH.Text = gdBN.CM_CCCD;
                                    tb_nghenghiepngGH.Text = gdBN.NgheNghiep;
                                    rTB_diachi_ngGH.Text = gdBN.DiaChi;
                                    tb_sdt_ngGH.Text = gdBN.SoDT;
                                    string[] ngaysinhTN = gdBN.NgaySinh.ToString().Split("/");
                                    tb_date_ngGH.Text = ngaysinhTN[1];
                                    tb_month_ngGH.Text = ngaysinhTN[0];
                                    tb_year_ngGH.Text = ngaysinhTN[2].Split(" ")[0];
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bệnh nhân!");
                    }
                }
            }
        }

        // PRINT DOCUMENT

        private void printDocumentSTTKham_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("BỆNH VIỆN NHI ĐỒNG 2 ", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(10, 10));
            e.Graphics.DrawString("STT", new Font("Arial", 50, FontStyle.Bold), Brushes.Black, new Point(210, 40));

            if (cb_BNuutien.Checked)
            {
                e.Graphics.DrawString("001", new Font("Arial", 150, FontStyle.Bold), Brushes.Black, new Point(80, 100));
                e.Graphics.DrawString("BỆNH NHÂN ƯU TIÊN", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(80, 320));
            }
            else
            {
                lichSuKhamCurrent.Clear();
                lichSuKhamCurrent = getListLSKToday();
                foreach (LichSuKham lsk in lichSuKhamCurrent)
                {
                    if (lsk.MaBN == tb_maBN.Text)
                    {
                        int sttKham = lichSuKhamCurrent.IndexOf(lsk) + 1;
                        e.Graphics.DrawString("0" + sttKham.ToString(), new Font("Arial", 150, FontStyle.Bold), Brushes.Black, new Point(120, 100));
                    }
                }
            }

            e.Graphics.DrawString("----------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(160, 360));
            e.Graphics.DrawString("Bệnh nhân: " + tb_hoten.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, 400));
            e.Graphics.DrawString("Ngày sinh: " + tb_day.Text + "/" + tb_month.Text + "/" + tb_year.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, 460));
            e.Graphics.DrawString("Mã: " + tb_maBN.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, 520));
            e.Graphics.DrawString("Ngày giờ: " + ThoiGianKham.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, 580));
            e.Graphics.DrawString("Phòng khám: " + cbb_phongkham.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, 640));
            e.Graphics.DrawString("Đăng ký khám: " + cbb_dkkham.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, 700));

            e.Graphics.DrawString("Bệnh nhân vui lòng chờ gọi đến số thứ tự!", new Font("Arial", 15, FontStyle.Italic), Brushes.Black, new Point(100, 800));
        }

    }
}
