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

namespace LibraryManagementSystem.STBBOOKS_SECTION
{
    public partial class ST_CIT_BOOKS : Form
    {
        DATABASE.MYDB db = new DATABASE.MYDB(); // Database instance
        private MySqlConnection fromDatabase; // Database connection object
        private MySqlCommand command; // MySQL command object
        private MySqlDataAdapter adapter; // MySQL data adapter
        private DataTable dataTable; // Data table to store results

        public ST_CIT_BOOKS()
        {
            InitializeComponent();
            InitializeDatabaseConnection(); // Initialize database connection
        }

        // Method to initialize the database connection
        private void InitializeDatabaseConnection()
        {
            try
            {
                // Set up the connection string with MySQL configuration
                fromDatabase = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in database connection: " + ex.Message);
            }
        }

        // Button click event to navigate back to the main books form
        private void button1_Click(object sender, EventArgs e)
        {
            STBOOK ST_CIT_BOOKS = new STBOOK();
            ST_CIT_BOOKS.Show();
            this.Close();
        }

        private void ST_CIT_BOOKS_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            InitializeDatabaseConnection(); // Initialize database connection
            LoadDataGridView(); // Load data into DataGridView when the form loads
        }

        // Method to load data into DataGridView
        private void LoadDataGridView()
        {
            try
            {
                fromDatabase.Open();
                string selectQuery = "SELECT * FROM librarymanagementsystem.cit_book";
                command = new MySqlCommand(selectQuery, fromDatabase);
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true; // Set the DataGridView to read-only
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                fromDatabase.Close();
            }
        }

        // Method to load data (alternate method)
        private void loadData()
        {
            string selectQuery = "SELECT * FROM librarymanagementsystem.cit_book";
            try
            {
                fromDatabase.Open();
                command = new MySqlCommand(selectQuery, fromDatabase);
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                dataGridView1.ReadOnly = true; // Set the DataGridView to read-only
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                fromDatabase.Close();
            }
        }

        // Method to retrieve books list from the database
        private DataTable GetBooksList()
        {
            string query = "SELECT * FROM librarymanagementsystem.cit_book";
            DataTable table = db.GetData(query, null);
            Console.WriteLine("Number of rows retrieved: " + table.Rows.Count);
            return table;
        }

        // Method to search for books based on the entered text
        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                string query = "SELECT * FROM librarymanagementsystem.cit_book WHERE  CONCAT(`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) like '%" + valueToSearch + "%'";
                command = new MySqlCommand(query, fromDatabase);
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                fromDatabase.Close();
            }
        }

        // Method to search for a book (alternate method)
        public DataTable SearchBook(string searchQuery)
        {
            string selectQuery = $"SELECT * FROM cit_book WHERE Book_Name LIKE '%{searchQuery}%'";
            return db.GetData(selectQuery, null);
        }

        // Handle DataGridView cell content click event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            searchData(""); // Trigger search with an empty string to refresh data
        }

        private void searchtextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle text change event in the search text box
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // Get the search value from the textbox
            string valueToSearch = searchtextBox.Text.ToString();

            // Call the method to perform the search
            searchData(valueToSearch);
        }

        private void searchButton_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Simulate a click on the searchButton when Enter key is pressed
                searchButton.PerformClick();

                // Suppress the key press to prevent additional events
                e.SuppressKeyPress = true;
            }
        }

        private void searchtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Simulate a click on the searchButton when Enter key is pressed
                searchButton.PerformClick();

                // Suppress the key press to prevent additional events
                e.SuppressKeyPress = true;
            }
        }
    }
}

