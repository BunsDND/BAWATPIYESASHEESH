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
using System.Xml.Linq;

namespace WinFormsApp3
{
    public partial class Form3 : Form
    {
        private int price; 
        private string userName; // To store the logged-in username
        private string userId;
        private string fname;
        private string position;
        private int priceo;
        private byte[] _pic;// To store the logged-in user ID
        private string connectionString = "server=localhost; database=bawat_piyesa; userid=root; password=''";

        // Constructor to accept user data
        public Form3(string u_name, string u_id, string name, string pos, byte[] pic, int price)
        {
            InitializeComponent();
            btnRimset.Click += (s, e) => LoadData("rimset");
            btnBolt.Click += (s, e) => LoadData("bolt");
            btnSwing.Click += (s, e) => LoadData("Swing Arm");
            btnHandle.Click += (s, e) => LoadData("Handle Bar");
            btnPipe.Click += (s, e) => LoadData("ORBR Pipe");
            btnSproket.Click += (s, e) => LoadData("sproket");
            btnAll.Click += (s, e) => LoadData("rimset", "Bolt", "swing arm", "handle bar", "orbr pipe", "sproket");


            userName = u_name;
            userId = u_id;
            fname = name;
            position = pos;
            _pic = pic;

            if (_pic != null && _pic.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(_pic))
                {
                    pictureBox10.Image = Image.FromStream(ms);

                    // Set the SizeMode to StretchImage or Zoom to fit the image within the PictureBox
                    pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage; // Stretch the image to fit
                                                                             // or
                                                                             // pictureBox10.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio while fitting
                }
            }
            else
            {
                // Optionally handle the case where the picture is null or empty
                pictureBox10.Image = null; // Or set a default image
            }

            label16.Text = fname; // u_name
            label17.Text = userId;
            label18.Text = position;// u_id
            label16.Anchor = AnchorStyles.None;
            label16.Location = new Point((panel3.Width - label16.Width) / 2, (panel3.Height - label16.Height) / 2);
            label17.Anchor = AnchorStyles.None;
            label17.Location = new Point((panel3.Width - label17.Width) / 2, (panel3.Height - label17.Height) / 2 + 30); // Adjust Y to add spacing
            label18.Anchor = AnchorStyles.None;
            label18.Location = new Point((panel3.Width - label18.Width) / 2, (panel3.Height - label18.Height) / 2 + 60); // Adjust Y to add spacing

        }
        // Declare a Form5 instance variable at the class level
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
                                    Size = new Size(300, 350),
                                    Padding = new Padding(5),
                                    Margin = new Padding(5),
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
                                        button.BackColor = ColorTranslator.FromHtml("#f9a6f9");
                                        break;
                                    default:
                                        button.BackColor = Color.White;
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
                                    Location = new Point(5, pictureBox.Bottom + 10),
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
                                    Location = new Point(5, nameLabel.Bottom + 5),
                                    AutoSize = false,
                                    Size = new Size(button.Width, 20)
                                };

                                // Add the price label to the button
                                button.Controls.Add(priceLabel);

                                // Add click event to open Form5 with product details
                                button.Click += (s, e) =>
                                {
                                    // If Form5 is already open, just refresh it
                                    if (form5Instance != null && !form5Instance.IsDisposed)
                                    {
                                        form5Instance.ReloadData(pName, pPrice, imageBytes, pStock, priceo);
                                        form5Instance.Activate();
                                    }
                                    else
                                    {
                                        form5Instance = new Form5(pName, pPrice, imageBytes, pStock, priceo, this);
                                        form5Instance.Show();
                                    }
                                };

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


        public void AddProductToPanel(string productName, string productPrice, int quantity)
        {
            // Create a new TableLayoutPanel for the product entry
            TableLayoutPanel productPanel = new TableLayoutPanel
            {
                AutoSize = true,

                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 3, // Three columns for product name, quantity, and price
                Dock = DockStyle.Top, // Align to the top of the parent panel
                Margin = new Padding(0, 0, 0, 5) // Optional: Add space below each product panel
            };
            productPanel.BackColor = ColorTranslator.FromHtml("#E5E3D4");

            // Set the column styles to allow space distribution
            productPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // Product Name
            productPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Quantity
            productPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Price

            // Create labels for product name, quantity, and price
            Label nameLabel = new Label
            {
                Text = productName,
                Size = new Size(133, 50),
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter// Space between labels
            };

            Label quantityLabel = new Label
            {
                Text = $"{quantity}",
                Size = new Size(133, 50),
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter// Space between labels
            };

            Label priceLabel = new Label
            {
                Text = productPrice,
                Size = new Size(133, 50),
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter // Space between labels
            };

            // Add labels to the TableLayoutPanel
            productPanel.Controls.Add(nameLabel, 0, 0); // Column 0
            productPanel.Controls.Add(quantityLabel, 1, 0); // Column 1
            productPanel.Controls.Add(priceLabel, 2, 0); // Column 2

            //nameLabel.BackColor = ColorTranslator.FromHtml("#8886f9");
            //quantityLabel.BackColor = ColorTranslator.FromHtml("#8f86b9");
            //priceLabel.BackColor = ColorTranslator.FromHtml("#8f86a9");



            // Add the TableLayoutPanel to the parent panel
            flowLayoutPanel2.Controls.Add(productPanel);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadData("rimset", "Bolt", "Swing Arm", "Handle Bar", "ORBR Pipe", "Sproket"); // All categories
        }


        private static Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void codeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }


        private void showpanel()
        {
            panel1.Visible = true;
        }
        private void hidepanel()
        {
            panel1.Visible = false;
        }

        private void calenter_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }


}
