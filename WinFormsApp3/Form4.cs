using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp3
{
    public partial class Form4 : Form

    {
        private string userName; // To store the logged-in username
        private string userId;
        private string fname;
        private string position;
        private byte[] _pic;// To store the logged-in user ID
        private string connectionString = "server=localhost; database=bawat_piyesa; userid=root; password=''";

        public Form4(string u_name, string u_id, string name, string pos, byte[] pic)
        {
            InitializeComponent();
            btnRimset.Click += (s, e) => LoadData("rimset");
            btnBolt.Click += (s, e) => LoadData("bolt");
            btnSwing.Click += (s, e) => LoadData("Swing Arm");
            btnHandle.Click += (s, e) => LoadData("Handle Bar");
            btnPipe.Click += (s, e) => LoadData("ORBR Pipe");
            btnSproket.Click += (s, e) => LoadData("sproket");
            btnAll.Click += (s, e) => LoadData("rimset", "Bolt", "swing arm", "handle bar", "orbr pipe", "sproket");





        }


        private void LoadData(params string[] categories)
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing items

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT p_name, p_price, p_image, p_cat FROM piyesa";

                    // If categories are specified, filter by them
                    if (categories.Length > 0)
                    {
                        query += " WHERE p_cat IN (" + string.Join(",", categories.Select(c => $"'{c}'")) + ")";
                    }

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string pCat = reader["p_cat"].ToString();
                                string pName = reader["p_name"].ToString();
                                string pPrice = reader["p_price"].ToString();
                                byte[] imageBytes = reader["p_image"] as byte[]; // Assuming p_image is a binary field

                                var button = new Button
                                {
                                    Size = new Size(300, 350),
                                    Padding = new Padding(5),
                                    Margin = new Padding(5),
                                    //orderStyle = BorderStyle.FixedSingle
                                };

                                // Set panel background color based on the product name
                                switch (pCat)
                                {
                                    case "Swing Arm":
                                        button.BackColor = ColorTranslator.FromHtml("#f99a86");
                                        break;
                                    case "Handle Bar":
                                        button.BackColor = ColorTranslator.FromHtml("#f99886");
                                        break;
                                    case "ORBR Pipe":
                                        button.BackColor = ColorTranslator.FromHtml("#86f994");
                                        break;
                                    case "Sproket":
                                        button.BackColor = ColorTranslator.FromHtml("#86cff9");
                                        break;
                                    case "Rimset":
                                        button.BackColor = ColorTranslator.FromHtml("#8f86f9");
                                        break;
                                    case "Bolt":
                                        button.BackColor = ColorTranslator.FromHtml("#f986f9");
                                        break;
                                    default:
                                        button.BackColor = Color.White; // Default color if no match
                                        break;
                                }

                                // Create and configure the PictureBox for the image
                                var pictureBox = new PictureBox
                                {
                                    Size = new Size(250, 250),
                                    Location = new Point((button.Width - 250) / 2, 10), // Center horizontally, 10px from the top
                                    SizeMode = PictureBoxSizeMode.StretchImage
                                };

                                // Load and resize the image
                                if (imageBytes != null && imageBytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pictureBox.Image = Image.FromStream(ms);
                                    }
                                }

                                // Add the image to the button
                                button.Controls.Add(pictureBox);

                                // Create and configure the label for the product name
                                var nameLabel = new Label
                                {
                                    Text = pName,
                                    Font = new Font("Arial", 14, FontStyle.Bold),
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None,
                                    Location = new Point(0, pictureBox.Bottom + 10),
                                    AutoSize = false,
                                    Size = new Size(button.Width, 25)
                                };

                                // Add the name label to the button
                                button.Controls.Add(nameLabel);

                                // Create and configure the label for the product price
                                var priceLabel = new Label
                                {
                                    Text = $"P: {pPrice}",
                                    Font = new Font("Arial", 12, FontStyle.Regular),
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None,
                                    Location = new Point(0, nameLabel.Bottom + 5),
                                    AutoSize = false,
                                    Size = new Size(button.Width, 20)
                                };

                                // Add the price label to the button
                                button.Controls.Add(priceLabel);

                                // Add the button to the flow layout
                                flowLayoutPanel1.Controls.Add(button);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
