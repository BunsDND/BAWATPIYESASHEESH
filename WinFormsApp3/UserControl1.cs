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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private Image _icon;
        private string _name; 
        private string _price;


        [Category("Custom Props")]
        public Image Icon
        {
            get { 
                return _icon; 
            }
            set{
                _icon = value; pictureBox1.Image = value;
            }
        }
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value; label_name.Text = value;
            }
        }
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value; label_price.Text = value;
            }
        }





    }
}
