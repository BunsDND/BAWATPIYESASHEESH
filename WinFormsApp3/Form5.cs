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
using K4os.Compression.LZ4.Encoders;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3
{
    public partial class Form5 : Form
    {
        private int p_stock;
        private int pila;
        private string name;
        private string price;
        private byte[] _pic;
        private int priceo;
        private Form3 _form3;



        public Form5(string pname, string pprice, byte[] pic, int pstock, int priceo, Form3 form3)
        {
            InitializeComponent();
            p_stock = pstock;
            name = pname;
            price = pprice;
            _pic = pic;
            _form3 = form3; 




            lbl_brand.Text = pname;
            lbl_price.Text = pprice;
            lbl_stock.Text = p_stock.ToString();
            if (pic != null && pic.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(pic))
                {
                    prod_pic.Image = Image.FromStream(ms);

                    // Set the SizeMode to StretchImage or Zoom to fit the image within the PictureBox
                    prod_pic.SizeMode = PictureBoxSizeMode.StretchImage; // Stretch the image to fit
                                                                         // or
                                                                         // pictureBox10.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio while fitting
                }
            }
            else
            {
                // Optionally handle the case where the picture is null or empty
                prod_pic.Image = null; // Or set a default image
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void ReloadData(string productName, string productPrice, byte[] imageBytes, int stock, int price)
        {
            // Reload or refresh product details
            UpdateProductDetails(productName, productPrice, imageBytes, stock, priceo);
        }

        private void UpdateProductDetails(string productName, string productPrice, byte[] imageBytes, int stock, int priceo)
        {
            if (!decimal.TryParse(productPrice, out decimal priceDecimal))
            {
                MessageBox.Show("Invalid price format.");
                return;
            }

            lbl_brand.Text = productName;
            lbl_price.Text = $"{priceDecimal:C}";
            lbl_stock.Text = $"{stock}";

            // Load image if available
            if (imageBytes != null && imageBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    prod_pic.Image = Image.FromStream(ms);
                }
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void quant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void UpdateStockInDatabase(string productName, int newStock)
        {
            string connectionString = "server=localhost; database=bawat_piyesa; userid=root; password=''";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE piyesa SET p_stock = @newStock WHERE p_name = @productName";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newStock", newStock);
                        command.Parameters.AddWithValue("@productName", productName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stock updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update stock. Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating stock: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Attempt to parse the quantity entered by the user
            if (int.TryParse(quant.Text, out pila))
            {
                // Check if the quantity exceeds the available stock
                if (pila > p_stock)
                {
                    // Reload the current form to show that the quantity exceeds stock
                    ReloadData(name, price, _pic, p_stock, priceo);
                    MessageBox.Show("Quantity exceeds available stock.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // If the quantity is valid, proceed to add the product
                    _form3.AddProductToPanel(name, price, pila);

                    // Update the stock in the database
                    UpdateStockInDatabase(name, p_stock - pila);

                    // Call the reload method in Form3
                    _form3.ReloadData();

                    // Close the current form
                    this.Close();
                }
            }
            else
            {
                // Handle the case where the quantity is not a valid number
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form5_Leave(object sender, EventArgs e)
        {
            
        }

        private void prod_pic_Click(object sender, EventArgs e)
        {

        }
    }
}
