namespace KhamBenhND2
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            menuStrip1 = new MenuStrip();
            homeTool = new ToolStripMenuItem();
            dontiepTool = new ToolStripMenuItem();
            dkKhamBenhTool = new ToolStripMenuItem();
            dsKhamBenhTool = new ToolStripMenuItem();
            pictureBox_home = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_home).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeTool, dontiepTool });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1370, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeTool
            // 
            homeTool.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            homeTool.Name = "homeTool";
            homeTool.Size = new Size(81, 21);
            homeTool.Text = "Trang chủ";
            // 
            // dontiepTool
            // 
            dontiepTool.DropDownItems.AddRange(new ToolStripItem[] { dkKhamBenhTool, dsKhamBenhTool });
            dontiepTool.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dontiepTool.Name = "dontiepTool";
            dontiepTool.Size = new Size(74, 21);
            dontiepTool.Text = "Đón tiếp";
            // 
            // dkKhamBenhTool
            // 
            dkKhamBenhTool.Name = "dkKhamBenhTool";
            dkKhamBenhTool.Size = new Size(213, 22);
            dkKhamBenhTool.Text = "Đăng ký khám bệnh";
            dkKhamBenhTool.Click += dkKhamBenhTool_Click;
            // 
            // dsKhamBenhTool
            // 
            dsKhamBenhTool.Name = "dsKhamBenhTool";
            dsKhamBenhTool.Size = new Size(213, 22);
            dsKhamBenhTool.Text = "Danh sách khám bệnh";
            dsKhamBenhTool.Click += dsKhamBenhTool_Click;
            // 
            // pictureBox_home
            // 
            pictureBox_home.Image = (Image)resources.GetObject("pictureBox_home.Image");
            pictureBox_home.Location = new Point(12, 44);
            pictureBox_home.Name = "pictureBox_home";
            pictureBox_home.Size = new Size(1346, 693);
            pictureBox_home.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_home.TabIndex = 1;
            pictureBox_home.TabStop = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1370, 749);
            Controls.Add(pictureBox_home);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "BỆNH VIỆN NHI ĐỒNG 2";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_home).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeTool;
        private ToolStripMenuItem dontiepTool;
        private ToolStripMenuItem dkKhamBenhTool;
        private ToolStripMenuItem dsKhamBenhTool;
        private PictureBox pictureBox_home;
    }
}