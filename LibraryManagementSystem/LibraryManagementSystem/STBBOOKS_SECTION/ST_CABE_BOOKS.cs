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
    public partial class ST_CABE_BOOKS : Form
    {
        DATABASE.MYDB db = new DATABASE.MYDB();
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public ST_CABE_BOOKS()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        // Initialize the database connection
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

        // Button click event to go back to the main book form
        private void button1_Click(object sender, EventArgs e)
        {
            STBOOK ST_CABE_BOOKS = new STBOOK();
            ST_CABE_BOOKS.Show();
            this.Close();
        }

        // Load event when the form is loaded
        private void ST_CABE_BOOKS_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            InitializeDatabaseConnection();//--
                                           // Load DataGridView when the form loads
            LoadDataGridView();
        }

        // Load data into DataGridView
        private void LoadDataGridView()
        {
            try
            {
                fromDatabase.Open();
                string selectQuery = "SELECT * FROM librarymanagementsystem.cabe_book";
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

        // Load data (another version)
        private void loadData()
        {
            string selectQuery = "SELECT * FROM librarymanagementsystem.cabe_book";
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

        // Get the list of books from the database
        private DataTable GetBooksList()
        {
            string query = "SELECT * FROM librarymanagementsystem.cabe_book";
            DataTable table = db.GetData(query, null);
            Console.WriteLine("Number of rows retrieved: " + table.Rows.Count);
            return table;
        }

        // Search for data based on the given value
        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                string query = "SELECT * FROM librarymanagementsystem.cabe_book WHERE  CONCAT(`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) like '%" + valueToSearch + "%'";
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

        // Button click event to perform a search
        private void searchButton_Click(object sender, EventArgs e)
        {
            string valueToSearch = searchtextBox.Text.ToString();
            searchData(valueToSearch);
        }

        // Key down event for the search button
        private void searchButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        // Key down event for the search textbox
        private void searchtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        // Function to search for a book
        public DataTable SearchBook(string searchQuery)
        {
            string selectQuery = $"SELECT * FROM cabe_book WHERE Book_Name LIKE '%{searchQuery}%'";
            return db.GetData(selectQuery, null);
        }

        // DataGridView cell content click event to perform a search
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }
    }
}


