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
            lbl_brand.Text = productName;
            lbl_price.Text = productPrice;
            lbl_stock.Text = $"Stock: {stock}";

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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            pila = Convert.ToInt32(quant.Text);
            if (pila > p_stock)
            {

                var newForm = new Form5(name, price, _pic, p_stock, priceo, _form3); // Replace 'MainForm' with your form's name
                newForm.Show();


                

            }_form3.AddProductToPanel(name, price, pila);
                //string u_name, string u_id, string name, string pos, byte[] pic, int price

                // Close the current form

                this.Close();
        }

        private void Form5_Leave(object sender, EventArgs e)
        {
            
        }

        private void prod_pic_Click(object sender, EventArgs e)
        {

        }
    }
}
