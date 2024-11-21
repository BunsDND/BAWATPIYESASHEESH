using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form3 : Form
    {
        private string userName; // To store the logged-in username
        private string userId;   // To store the logged-in user ID

        // Constructor to accept user data
        public Form3(string u_name, string u_id)
        {
            InitializeComponent();
            userName = u_name;
            userId = u_id;
            label16.Text = userName; // u_name
            label17.Text = userId;   // u_id
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Display user data on the labels

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {
            codeBox.Text += b1.Text;
        }
        private void b2_Click_1(object sender, EventArgs e)
        {
            codeBox.Text += b2.Text;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            codeBox.Text += b3.Text;
        }

        private void b4_Click(object sender, EventArgs e)
        {
            codeBox.Text += b4.Text;
        }

        private void b5_Click(object sender, EventArgs e)
        {
            codeBox.Text += b5.Text;
        }

        private void b6_Click(object sender, EventArgs e)
        {
            codeBox.Text += b6.Text;
        }

        private void b7_Click(object sender, EventArgs e)
        {
            codeBox.Text += b7.Text;
        }

        private void b8_Click(object sender, EventArgs e)
        {
            codeBox.Text += b8.Text;
        }

        private void b9_Click(object sender, EventArgs e)
        {
            codeBox.Text += b9.Text;
        }

        private void b0_Click(object sender, EventArgs e)
        {
            codeBox.Text += b0.Text;
        }

        private void b00_Click(object sender, EventArgs e)
        {
            codeBox.Text += b00.Text;
        }

        private void b000_Click(object sender, EventArgs e)
        {
            codeBox.Text += b000.Text;
        }

        private void bdel_Click(object sender, EventArgs e)
        {
            codeBox.Text = String.Empty;
        }
    }

}
