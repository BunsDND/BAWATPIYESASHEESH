using System.Reflection.Metadata;
using MySql.Data.MySqlClient;


namespace WinFormsApp3
{
    public partial class Form2 : Form
    {


        private int priceo; 
        public Form2()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            // Database credentials
            string dbcred = "server=localhost; database=bawat_piyesa; userid=root; password=''";
            using (MySqlConnection conn = new MySqlConnection(dbcred))
            {
                try
                {
                    // Open connection
                    conn.Open();

                    // Query to check credentials and retrieve user data
                    string query = "SELECT u_id, u_name, name, position, u_image FROM users WHERE u_name=@username AND u_pass=@password LIMIT 1;";
                    MySqlCommand sql = new MySqlCommand(query, conn);

                    // Add parameters to prevent SQL injection
                    sql.Parameters.AddWithValue("@username", username.Text);
                    sql.Parameters.AddWithValue("@password", password.Text);

                    // Execute the query
                    MySqlDataReader reader = sql.ExecuteReader();

                    // Check if a record exists
                    if (reader.Read())
                    {
                        string u_id = reader["u_id"].ToString();
                        string u_name = reader["u_name"].ToString();
                        string name = reader["name"].ToString();
                        string pos = reader["position"].ToString(); // Get position
                        byte[] pic = (byte[])reader["u_image"];

                        // Check position and open the appropriate form
                        if (pos.ToLower() == "admin") // Case insensitive comparison for admin
                        {
                            Form4 adminForm = new Form4 (u_name, u_id, name, pos, pic);
                            adminForm.Show();
                        }
                        else if (pos.ToLower() == "cashier") // Case insensitive comparison for cashier
                        {
                            Form3 cashierForm = new Form3(u_name, u_id, name, pos, pic,priceo );
                            cashierForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Position", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        this.Hide(); // Hide the current form
                    }
                    else
                    {
                        // Display error message if no record is found
                        label5.Text = "Invalid Username or Password";
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    MessageBox.Show($"Error: {ex.Message}", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
