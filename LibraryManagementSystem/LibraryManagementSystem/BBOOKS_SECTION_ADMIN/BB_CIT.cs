using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem.BBOOKS_SECTION_ADMIN
{
    // Partial class for the BB_CIT form
    public partial class BB_CIT : Form
    {
        // Database instance for handling connections
        DATABASE.MYDB db = new DATABASE.MYDB();
        // Database connection variables
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        // Constructor for the BB_CIT form
        public BB_CIT()
        {
            InitializeComponent();
            // Initialize the database connection
            InitializeDatabaseConnection();
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

        // Event handler when the BB_CIT form loads
        private void BB_CIT_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            InitializeDatabaseConnection(); // Reinitialize database connection
            // Load DataGridView when the form loads
            LoadDataGridView();
        }

        // Method to load data into the DataGridView
        private void LoadDataGridView()
        {
            try
            {
                fromDatabase.Open();
                // SQL query to select all data from the 'cit_borrowed_books' table
                string selectQuery = "SELECT * FROM librarymanagementsystem.cit_borrowed_books";
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

        // Method to load data into the DataGridView (overloaded)
        private void loadData()
        {
            string selectQuery = "SELECT * FROM librarymanagementsystem.cit_borrowed_books";
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

        // Method to get a list of books from the database
        private DataTable GetBooksList()
        {
            string query = "SELECT * FROM librarymanagementsystem.cit_borrowed_books";
            DataTable table = db.GetData(query, null);
            Console.WriteLine("Number of rows retrieved: " + table.Rows.Count);
            return table;
        }

        // Method to search for books based on a value
        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                // SQL query to search for books with a specific value in any of the columns
                string query = "SELECT * FROM librarymanagementsystem.cit_borrowed_books WHERE  CONCAT(Student_ID, Book_ID, Borrowed_Date) like '%" + valueToSearch + "%'";
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

        // Event handler for the "dataGridView1" cell content click
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Search for all books when a cell content is clicked
            searchData("");
        }

        // Event handler for the "button1" click
        private void button1_Click(object sender, EventArgs e)
        {
            // Show the BB_BOOKS_LIST_ADMIN form and close the current form
            BB_BOOKS_LIST_ADMIN BB_CIT = new BB_BOOKS_LIST_ADMIN();
            BB_CIT.Show();
            this.Close();
        }
    }
}
