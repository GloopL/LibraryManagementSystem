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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class Admin : Form
    {
        // Constructor for the Admin form
        public Admin()
        {
            InitializeComponent();
        }

        // Event handler for the 'Back' button click
        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the Choices form
            Choices form2 = new Choices();
            // Show the Choices form
            form2.Show();
            // Close the current Admin form
            this.Close();
        }

        // Event handler for the text changed in the username textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This method can be used for handling text changes in the username textbox if needed
            // Currently, it's empty
        }

        // Event handler for the 'Login' button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the username and password from the respective textboxes
            string Username = textBox1.Text;
            string Password = TextBox2.Text;

            // Create an instance of the database connection class
            DATABASE.MYDB db = new DATABASE.MYDB();

            // DataTable to store the results of the database query
            DataTable table = new DataTable();
            // Adapter to fill the DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            // MySqlConnection instance
            MySqlConnection connection = db.GetConnection();

            try
            {
                // Open the database connection
                connection.Open();

                // SQL command to check if the user exists in the 'librarian' table
                MySqlCommand command = new MySqlCommand("SELECT * FROM `librarian` WHERE `Librarian_UserName`=@usr AND `Password`=@pass", connection);

                // Add parameters to the SQL command
                command.Parameters.Add("@usr", MySqlDbType.VarChar).Value = Username;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;

                // Set the adapter's SelectCommand
                adapter.SelectCommand = command;
                // Fill the DataTable with the results of the query
                adapter.Fill(table);

                // Check if the user exists
                if (table.Rows.Count > 0) // IF EXISTS
                {
                    // If the user exists, create an instance of the AdminInteracee form
                    AdminInteracee admin = new AdminInteracee();
                    // Show the AdminInteracee form
                    admin.Show();
                    // Close the current Admin form
                    this.Close();
                }
                else // If the user doesn't exist
                {
                    // Check if the username is empty
                    if (string.IsNullOrWhiteSpace(Username))
                    {
                        MessageBox.Show("Enter your username to Login", "Empty username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Check if the password is empty
                    else if (string.IsNullOrWhiteSpace(Password))
                    {
                        MessageBox.Show("Enter your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // If the data doesn't exist
                    else
                    {
                        MessageBox.Show("Wrong username and Password", "Wrong Data Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the database connection in the 'finally' block
                connection.Close();
            }
        }

        // Event handler for the form load event
        private void Admin_Load(object sender, EventArgs e)
        {
            // This method can be used for any additional setup when the form loads
            // Currently, it's empty
        }
    }
}
