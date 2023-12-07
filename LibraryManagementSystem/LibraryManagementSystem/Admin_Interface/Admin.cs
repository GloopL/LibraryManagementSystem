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
        


        public Admin()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Choices form2 = new Choices();
            form2.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string Password = TextBox2.Text;

            DATABASE.MYDB db = new DATABASE.MYDB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlConnection connection = db.GetConnection();

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `librarian` WHERE `Librarian_UserName`=@usr AND `Password`=@pass", connection);

                command.Parameters.Add("@usr", MySqlDbType.VarChar).Value = Username;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                // checking if the user exists
                if (table.Rows.Count > 0) // IF EXISTS
                {
                    AdminInteracee admin = new AdminInteracee();
                    admin.Show();
                    this.Close();
                }
                else // if not
                {
                    // check if the username is empty
                    if (string.IsNullOrWhiteSpace(Username))
                    {
                        MessageBox.Show("Enter your username to Login", "Empty username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // check if the password is empty
                    else if (string.IsNullOrWhiteSpace(Password))
                    {
                        MessageBox.Show("Enter your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // check if the data doesn't exist
                    else
                    {
                        MessageBox.Show("Wrong username and Password", "Wrong Data Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

      
    }
}
