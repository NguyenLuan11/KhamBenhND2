namespace KhamBenhND2.View
{
    partial class dsKhamBenh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode17 = new TreeNode("Tất cả bệnh nhân");
            TreeNode treeNode18 = new TreeNode("Ca khám");
            TreeNode treeNode19 = new TreeNode("Trẻ em dưới 6 tuổi");
            TreeNode treeNode20 = new TreeNode("Độ tuổi", new TreeNode[] { treeNode19 });
            TreeNode treeNode21 = new TreeNode("Nam");
            TreeNode treeNode22 = new TreeNode("Nữ");
            TreeNode treeNode23 = new TreeNode("Giới tính", new TreeNode[] { treeNode21, treeNode22 });
            TreeNode treeNode24 = new TreeNode("Đối tượng");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dsKhamBenh));
            treeView_phanloaiBN = new TreeView();
            dgv_dskhambenh = new DataGridView();
            NgayDonTiep = new DataGridViewTextBoxColumn();
            MaBN = new DataGridViewTextBoxColumn();
            TenBN = new DataGridViewTextBoxColumn();
            BHYT = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            NamSinh = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            PhongKham = new DataGridViewTextBoxColumn();
            Khoa = new DataGridViewTextBoxColumn();
            label_dateStart = new Label();
            dtp_dateStart = new DateTimePicker();
            label_dateEnd = new Label();
            dtp_dateEnd = new DateTimePicker();
            btn_search = new Button();
            btn_dontiep = new Button();
            cbb_phongkham = new ComboBox();
            btn_inDSkham = new Button();
            printDocumentDSkham = new System.Drawing.Printing.PrintDocument();
            printPreviewDialogDSkham = new PrintPreviewDialog();
            btn_goiSTT = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_dskhambenh).BeginInit();
            SuspendLayout();
            // 
            // treeView_phanloaiBN
            // 
            treeView_phanloaiBN.Cursor = Cursors.Hand;
            treeView_phanloaiBN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            treeView_phanloaiBN.Location = new Point(12, 100);
            treeView_phanloaiBN.Name = "treeView_phanloaiBN";
            treeNode17.Name = "AllPatient";
            treeNode17.Text = "Tất cả bệnh nhân";
            treeNode18.Name = "CaKham";
            treeNode18.Text = "Ca khám";
            treeNode19.Name = "duoi6t";
            treeNode19.Text = "Trẻ em dưới 6 tuổi";
            treeNode20.Name = "DoTuoi";
            treeNode20.Text = "Độ tuổi";
            treeNode21.Name = "nam";
            treeNode21.Text = "Nam";
            treeNode22.Name = "nu";
            treeNode22.Text = "Nữ";
            treeNode23.Name = "GioiTinh";
            treeNode23.Text = "Giới tính";
            treeNode24.Name = "DoiTuong";
            treeNode24.Text = "Đối tượng";
            treeView_phanloaiBN.Nodes.AddRange(new TreeNode[] { treeNode17, treeNode18, treeNode20, treeNode23, treeNode24 });
            treeView_phanloaiBN.Size = new Size(259, 592);
            treeView_phanloaiBN.TabIndex = 0;
            // 
            // dgv_dskhambenh
            // 
            dgv_dskhambenh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_dskhambenh.Columns.AddRange(new DataGridViewColumn[] { NgayDonTiep, MaBN, TenBN, BHYT, GioiTinh, NamSinh, DiaChi, PhongKham, Khoa });
            dgv_dskhambenh.Location = new Point(277, 71);
            dgv_dskhambenh.Name = "dgv_dskhambenh";
            dgv_dskhambenh.RowTemplate.Height = 25;
            dgv_dskhambenh.Size = new Size(1081, 621);
            dgv_dskhambenh.TabIndex = 1;
            // 
            // NgayDonTiep
            // 
            NgayDonTiep.HeaderText = "Ngày đón tiếp";
            NgayDonTiep.Name = "NgayDonTiep";
            NgayDonTiep.Width = 120;
            // 
            // MaBN
            // 
            MaBN.HeaderText = "Mã BN";
            MaBN.Name = "MaBN";
            // 
            // TenBN
            // 
            TenBN.HeaderText = "Tên Bệnh Nhân";
            TenBN.Name = "TenBN";
            TenBN.Width = 200;
            // 
            // BHYT
            // 
            BHYT.HeaderText = "Số BHYT";
            BHYT.Name = "BHYT";
            // 
            // GioiTinh
            // 
            GioiTinh.HeaderText = "Giới tính";
            GioiTinh.Name = "GioiTinh";
            // 
            // NamSinh
            // 
            NamSinh.HeaderText = "Năm sinh";
            NamSinh.Name = "NamSinh";
            // 
            // DiaChi
            // 
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.Name = "DiaChi";
            DiaChi.Width = 300;
            // 
            // PhongKham
            // 
            PhongKham.HeaderText = "Phòng khám";
            PhongKham.Name = "PhongKham";
            // 
            // Khoa
            // 
            Khoa.HeaderText = "Khoa";
            Khoa.Name = "Khoa";
            // 
            // label_dateStart
            // 
            label_dateStart.AutoSize = true;
            label_dateStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_dateStart.Location = new Point(946, 7);
            label_dateStart.Name = "label_dateStart";
            label_dateStart.Size = new Size(68, 21);
            label_dateStart.TabIndex = 2;
            label_dateStart.Text = "Từ ngày:";
            // 
            // dtp_dateStart
            // 
            dtp_dateStart.Location = new Point(1032, 7);
            dtp_dateStart.Name = "dtp_dateStart";
            dtp_dateStart.Size = new Size(200, 23);
            dtp_dateStart.TabIndex = 3;
            // 
            // label_dateEnd
            // 
            label_dateEnd.AutoSize = true;
            label_dateEnd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_dateEnd.Location = new Point(946, 37);
            label_dateEnd.Name = "label_dateEnd";
            label_dateEnd.Size = new Size(79, 21);
            label_dateEnd.TabIndex = 4;
            label_dateEnd.Text = "Đến ngày:";
            // 
            // dtp_dateEnd
            // 
            dtp_dateEnd.Location = new Point(1032, 37);
            dtp_dateEnd.Name = "dtp_dateEnd";
            dtp_dateEnd.Size = new Size(200, 23);
            dtp_dateEnd.TabIndex = 5;
            // 
            // btn_search
            // 
            btn_search.BackColor = SystemColors.InactiveCaption;
            btn_search.Cursor = Cursors.Hand;
            btn_search.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_search.Location = new Point(1238, 7);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(120, 53);
            btn_search.TabIndex = 6;
            btn_search.Text = "Tìm kiếm";
            btn_search.UseVisualStyleBackColor = false;
            btn_search.Click += btn_search_Click;
            // 
            // btn_dontiep
            // 
            btn_dontiep.BackColor = SystemColors.InactiveCaption;
            btn_dontiep.Cursor = Cursors.Hand;
            btn_dontiep.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_dontiep.Location = new Point(12, 5);
            btn_dontiep.Name = "btn_dontiep";
            btn_dontiep.Size = new Size(120, 53);
            btn_dontiep.TabIndex = 7;
            btn_dontiep.Text = "Đón tiếp";
            btn_dontiep.UseVisualStyleBackColor = false;
            btn_dontiep.Click += btn_dontiep_Click;
            // 
            // cbb_phongkham
            // 
            cbb_phongkham.Cursor = Cursors.Hand;
            cbb_phongkham.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbb_phongkham.FormattingEnabled = true;
            cbb_phongkham.Location = new Point(12, 71);
            cbb_phongkham.Name = "cbb_phongkham";
            cbb_phongkham.Size = new Size(259, 29);
            cbb_phongkham.TabIndex = 8;
            cbb_phongkham.Text = "Tất cả phòng khám";
            cbb_phongkham.SelectedValueChanged += cbb_phongkham_SelectedValueChanged;
            // 
            // btn_inDSkham
            // 
            btn_inDSkham.BackColor = SystemColors.InactiveCaption;
            btn_inDSkham.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_inDSkham.Location = new Point(151, 5);
            btn_inDSkham.Name = "btn_inDSkham";
            btn_inDSkham.Size = new Size(120, 53);
            btn_inDSkham.TabIndex = 9;
            btn_inDSkham.Text = "In danh sách";
            btn_inDSkham.UseVisualStyleBackColor = false;
            btn_inDSkham.Click += btn_inDSkham_Click;
            // 
            // printDocumentDSkham
            // 
            printDocumentDSkham.PrintPage += printDocumentDSkham_PrintPage;
            // 
            // printPreviewDialogDSkham
            // 
            printPreviewDialogDSkham.AutoScrollMargin = new Size(0, 0);
            printPreviewDialogDSkham.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialogDSkham.ClientSize = new Size(400, 300);
            printPreviewDialogDSkham.Enabled = true;
            printPreviewDialogDSkham.Icon = (Icon)resources.GetObject("printPreviewDialogDSkham.Icon");
            printPreviewDialogDSkham.Name = "printPreviewDialogDSkham";
            printPreviewDialogDSkham.Visible = false;
            // 
            // btn_goiSTT
            // 
            btn_goiSTT.BackColor = SystemColors.InactiveCaption;
            btn_goiSTT.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_goiSTT.Location = new Point(290, 5);
            btn_goiSTT.Name = "btn_goiSTT";
            btn_goiSTT.Size = new Size(120, 53);
            btn_goiSTT.TabIndex = 10;
            btn_goiSTT.Text = "Gọi số";
            btn_goiSTT.UseVisualStyleBackColor = false;
            btn_goiSTT.Click += btn_goiSTT_Click;
            // 
            // dsKhamBenh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 704);
            Controls.Add(btn_goiSTT);
            Controls.Add(btn_inDSkham);
            Controls.Add(cbb_phongkham);
            Controls.Add(btn_dontiep);
            Controls.Add(btn_search);
            Controls.Add(dtp_dateEnd);
            Controls.Add(label_dateEnd);
            Controls.Add(dtp_dateStart);
            Controls.Add(label_dateStart);
            Controls.Add(dgv_dskhambenh);
            Controls.Add(treeView_phanloaiBN);
            Name = "dsKhamBenh";
            Text = "Danh sách khám bệnh";
            WindowState = FormWindowState.Maximized;
            Load += dsKhamBenh_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_dskhambenh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView_phanloaiBN;
        private DataGridView dgv_dskhambenh;
        private Label label_dateStart;
        private DateTimePicker dtp_dateStart;
        private Label label_dateEnd;
        private DateTimePicker dtp_dateEnd;
        private Button btn_search;
        private Button btn_dontiep;
        private ComboBox cbb_phongkham;
        private DataGridViewTextBoxColumn NgayDonTiep;
        private DataGridViewTextBoxColumn MaBN;
        private DataGridViewTextBoxColumn TenBN;
        private DataGridViewTextBoxColumn BHYT;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn NamSinh;
        private DataGridViewTextBoxColumn DiaChi;
        private DataGridViewTextBoxColumn PhongKham;
        private DataGridViewTextBoxColumn Khoa;
        private Button btn_inDSkham;
        private System.Drawing.Printing.PrintDocument printDocumentDSkham;
        private PrintPreviewDialog printPreviewDialogDSkham;
        private Button btn_goiSTT;
    }
}