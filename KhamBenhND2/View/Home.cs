using KhamBenhND2.View;

namespace KhamBenhND2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void dkKhamBenhTool_Click(object sender, EventArgs e)
        {
            dkKhamBenh dkkb = new dkKhamBenh();
            dkkb.Show();
        }

        private void dsKhamBenhTool_Click(object sender, EventArgs e)
        {
            dsKhamBenh dskb = new dsKhamBenh();
            dskb.Show();
        }
    }
}