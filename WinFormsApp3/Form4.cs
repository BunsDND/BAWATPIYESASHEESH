using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Notice;
using Org.BouncyCastle.Asn1.X9;
using static System.Net.Mime.MediaTypeNames;

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

        private string c_name;
        private string c_id;
        private string c_rname;
        private byte[] c_pic;

        //c_name, c_id, c_rname, c_pic
        //u_name, u_id, name, position, u_image

        public Form4(string u_name, string u_id, string name, string pos, byte[] pic)
        {
            InitializeComponent();
            btnRimset.Click += (s, e) => LoadData("rimset");
            btnBolt.Click += (s, e) => LoadData("bolt");
            btnSwing.Click += (s, e) => LoadData("Swing Arm");
            btnHandle.Click += (s, e) => LoadData("Handle Bar");
            btnPipe.Click += (s, e) => LoadData("ORBR Pipe");
            btnSproket.Click += (s, e) => LoadData("sproket");
            btn_cash.Click += (s, e) => Lcashier("cash");
            btnAll.Click += (s, e) => LoadData("rimset", "Bolt", "swing arm", "handle bar", "orbr pipe", "sproket");





        }

        private Form5 form5Instance = null;
        private void LoadData(params string[] categories)
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing items

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT p_name, p_price, p_image, p_cat, p_stock FROM piyesa";
                    // string cash_user = "SELECT u_name, u_id, name, position, u_image FROM users";

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
                                int pStock = Convert.ToInt32(reader["p_stock"]);
                                byte[] imageBytes = reader["p_image"] as byte[]; // Assuming p_image is a binary field

                                var button = new Button
                                {
                                    Size = new Size(300, 400),
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
                                        pictureBox.Image = System.Drawing.Image.FromStream(ms);
                                    }
                                }


                                // Add the image to the button
                                button.Controls.Add(pictureBox);

                                var nameLabel = new System.Windows.Forms.Label
                                {
                                    Text = pName,
                                    Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                                    Dock = System.Windows.Forms.DockStyle.None,
                                    Location = new System.Drawing.Point(0, pictureBox.Bottom + 10),
                                    AutoSize = false,
                                    Size = new System.Drawing.Size(button.Width, 25),
                                    BackColor = System.Drawing.Color.Transparent
                                };
                                button.Controls.Add(nameLabel);


                                var priceLabel = new System.Windows.Forms.Label
                                {
                                    Text = $"P: {pPrice}",
                                    Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Regular),
                                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                                    Dock = System.Windows.Forms.DockStyle.None,
                                    Location = new System.Drawing.Point(0, nameLabel.Bottom + 10),
                                    AutoSize = false,
                                    Size = new System.Drawing.Size(button.Width, 25),
                                    BackColor = System.Drawing.Color.Transparent
                                };
                                button.Controls.Add(priceLabel);

                                var stockLabel = new System.Windows.Forms.Label
                                {
                                    Text = $"Stock: {pStock}",
                                    Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular),
                                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                                    Dock = System.Windows.Forms.DockStyle.None,
                                    Location = new System.Drawing.Point(0, priceLabel.Bottom + 10),
                                    AutoSize = false,
                                    Size = new System.Drawing.Size(button.Width, 25),
                                    BackColor = System.Drawing.Color.Transparent
                                };
                                button.Controls.Add(stockLabel);

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
        private void Lcashier(params string[] categories)
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing items

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //string  = "SELECT p_name, p_price, p_image, p_cat FROM piyesa";
                    string query = "SELECT u_name, u_id, name, position, u_image FROM users";

                    // If categories are specified, filter by them


                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string username = reader["u_name"].ToString();
                                string uid = reader["u_id"].ToString();
                                string realname = reader["name"].ToString();
                                string position = reader["position"].ToString();
                                byte[] uimg = reader["u_image"] as byte[];

                                var button = new Button
                                {
                                    Size = new Size(300, 400),
                                    Padding = new Padding(5),
                                    Margin = new Padding(5),
                                    //orderStyle = BorderStyle.FixedSingle
                                };
                                button.BackColor = ColorTranslator.FromHtml("#8576FF");
                                var pictureBox = new PictureBox
                                {
                                    Size = new Size(250, 250),
                                    Location = new Point((button.Width - 250) / 2, 10), // Center horizontally, 10px from the top
                                    SizeMode = PictureBoxSizeMode.StretchImage
                                };

                                // Load and resize the image
                                if (uimg != null && uimg.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(uimg))
                                    {
                                        pictureBox.Image = System.Drawing.Image.FromStream(ms);
                                    }
                                }
                                button.Controls.Add(pictureBox);


                                var realnameLabel = new System.Windows.Forms.Label
                                {
                                    Text = realname,
                                    Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                                    Dock = System.Windows.Forms.DockStyle.None,
                                    Location = new System.Drawing.Point(0, pictureBox.Bottom + 10),
                                    AutoSize = false,
                                    Size = new System.Drawing.Size(button.Width, 25),
                                    BackColor = System.Drawing.Color.Transparent
                                };
                                button.Controls.Add(realnameLabel);

                                var usernameLabel = new System.Windows.Forms.Label
                                {
                                    Text = $"{username} - Position: {position}",
                                    Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular),
                                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                                    Dock = System.Windows.Forms.DockStyle.None,
                                    Location = new System.Drawing.Point(0, realnameLabel.Bottom + 10),
                                    AutoSize = false,
                                    Size = new System.Drawing.Size(button.Width, 25),
                                    BackColor = System.Drawing.Color.Transparent
                                };
                                button.Controls.Add(usernameLabel);

                                var uidLabel = new System.Windows.Forms.Label
                                {
                                    Text = uid,
                                    Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular),
                                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                                    Dock = System.Windows.Forms.DockStyle.None,
                                    Location = new System.Drawing.Point(0, usernameLabel.Bottom + 10),
                                    AutoSize = false,
                                    Size = new System.Drawing.Size(button.Width, 25),
                                    BackColor = System.Drawing.Color.Transparent
                                };
                                button.Controls.Add(uidLabel);



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
            System.Windows.Forms.Application.Exit();
        }

        private void btnHandle_Click(object sender, EventArgs e)
        {

        }
    }
}
