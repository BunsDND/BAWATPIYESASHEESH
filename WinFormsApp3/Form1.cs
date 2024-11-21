using MySql.Data.MySqlClient;
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void enter_Click(object sender, EventArgs e)
        {
            Form2 dashboard = new Form2();
            dashboard.Show();
            this.Hide();
        }
    }
}
