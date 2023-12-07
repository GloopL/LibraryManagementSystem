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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystem
{
    public partial class Student1 : Form
    {
        public Student1()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          Choices student1 = new Choices();
            student1.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentNewAcc form6 = new StudentNewAcc();
            form6.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SrCode = textBox1.Text;
            string Password = textBox2.Text;

            DATABASE.MYDB db = new DATABASE.MYDB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlConnection connection = db.GetConnection();

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `student` WHERE `SRCode`=@src AND `Password`=@pass", connection);

                command.Parameters.Add("@src", MySqlDbType.VarChar).Value = SrCode;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                // checking if the user exists
                if (table.Rows.Count > 0) // IF EXISTS
                {
                    StudentInterface student1 = new StudentInterface();
                    student1.Show();
                    this.Close();
                }
                else // if not
                {
                    // check if the username is empty
                    if (SrCode.Trim().Equals(""))
                    {
                        MessageBox.Show("Enter your username to Login", "Empty username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // check if the password is empty
                    else if (Password.Trim().Equals(""))
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
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
