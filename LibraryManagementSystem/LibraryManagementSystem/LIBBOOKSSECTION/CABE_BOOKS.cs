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

// Namespace for the books section of the library management system
namespace LibraryManagementSystem.LIBBOOKSSECTION
{
    // Partial class for the CABE_BOOKS form
    public partial class CABE_BOOKS : Form
    {
        // Database instance for handling connections
        DATABASE.MYDB db = new DATABASE.MYDB();
        // Database connection variables
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        // Constructor for the CABE_BOOKS form
        public CABE_BOOKS()
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

        // Event handler when the CABE_BOOKS form loads
        private void CABE_BOOKS_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            InitializeDatabaseConnection(); // Reinitialize database connection
            // Load DataGridView when the form loads
            LoadDataGridView();
        }

        // Event handler for the "addBook" button click
        private void addBook_Click(object sender, EventArgs e)
        {
            // Get input values for adding new books
            string bookId = BOOKID.Text;
            string bookName = BNAME.Text;
            string author = AUTHOR.Text;
            string publisher = PUB.Text;
            string quantity = QTY.Text;

            // Call a method to handle the addition of new books
            if (!string.IsNullOrEmpty(bookId) &&
                !string.IsNullOrEmpty(bookName) &&
                !string.IsNullOrEmpty(author) &&
                !string.IsNullOrEmpty(publisher) &&
                !string.IsNullOrEmpty(quantity))
            {
                AddNewBook(bookId, bookName, author, publisher, quantity);
            }
            else
            {
                MessageBox.Show("Failed to Add New Book. All fields must be filled.", "Add New Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Method to add a new book to the database
        private void AddNewBook(string bookId, string bookName, string author, string publisher, string quantity)
        {
            // Implement logic to update the database with new book details
            // Use a SQL query to insert the new book details into a 'Books' table
            try
            {
                fromDatabase.Open();

                // SQL query for inserting new book details
                string insertQuery = "INSERT INTO librarymanagementsystem.cabe_book (`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) " +
                                    "VALUES (@bookId, @bookName, @author, @publisher, @quantity)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, fromDatabase))
                {
                    // Set parameters for the SQL query
                    command.Parameters.AddWithValue("bookId", bookId);
                    command.Parameters.AddWithValue("bookName", bookName);
                    command.Parameters.AddWithValue("author", author);
                    command.Parameters.AddWithValue("publisher", publisher);
                    command.Parameters.AddWithValue("quantity", quantity);

                    // Execute the query and check the number of affected rows
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New Book Added Successfully", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh DataGridView after adding a new book
                        LoadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Add New Book", "Add New Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fromDatabase.Close();
            }
        }

        // Event handler for the "EDIT_BUTTON" click
        private void EDIT_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values for editing a book
                string bookId = BOOKID.Text;
                string bookName = BNAME.Text;
                string author = AUTHOR.Text;
                string publisher = PUB.Text;
                string quantity = QTY.Text;

                // Check if input values are not empty
                if (!string.IsNullOrEmpty(bookId) &&
                    !string.IsNullOrEmpty(bookName) &&
                    !string.IsNullOrEmpty(author) &&
                    !string.IsNullOrEmpty(publisher) &&
                    !string.IsNullOrEmpty(quantity))
                {
                    // Call method to edit the book
                    EditBook(bookId, bookName, author, publisher, quantity);
                }
                else
                {
                    MessageBox.Show("Failed to Edit Book. All fields must be filled.", "Edit Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Invalid id");
            }
        }

        // Method to edit a book in the database
        private bool EditBook(string bookId, string bookName, string author, string publisher, string quantity)
        {
            try
            {
                // Reinitialize database connection
                using (fromDatabase = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''; database=librarymanagementsystem"))
                {
                    fromDatabase.Open();

                    // SQL query for updating book details
                    string updateQuery = "UPDATE `cabe_book` SET `Book_Name`= @bookName, `Author`= @author, `Publisher`= @publisher, `Quantity`= @quantity WHERE `Book_ID`= @bookId";

                    using (command = new MySqlCommand(updateQuery, fromDatabase))
                    {
                        // Set parameters for the SQL query
                        command.Parameters.AddWithValue("@bookId", bookId);
                        command.Parameters.AddWithValue("@bookName", bookName);
                        command.Parameters.AddWithValue("@author", author);
                        command.Parameters.AddWithValue("@publisher", publisher);
                        command.Parameters.AddWithValue("@quantity", quantity);

                        // Execute the query and check the number of affected rows
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The book is already edited", "Edit book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh DataGridView after editing a book
                            LoadDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Failed to edit Book", "Book editing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                // Close the database connection outside the using block
                fromDatabase.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Event handler for the "REMOVE_BUTTON" click
        private void REMOVE_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                // Get book ID for removal
                string bookId = BOOKID.Text;

                // Check if book is successfully removed
                if (RemoveStudent(bookId))
                {
                    MessageBox.Show("Book is removed", "Removed Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Book info not Deleted", "Deletion error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid id");
            }
        }

        // Method to remove a book from the database
        public bool RemoveStudent(string bookId)
        {
            string query = "DELETE FROM `cabe_book` WHERE `Book_ID`= @bookId";

            using (MySqlConnection connection = db.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Set parameter for the SQL query
                    command.Parameters.AddWithValue("@bookId", bookId);

                    // Execute the command directly since it's a DELETE operation
                    int rowsAffected = db.SetData(command);

                    return rowsAffected == 1;
                }
            }
        }

        // Method to load data into the DataGridView
        private void LoadDataGridView()
        {
            try
            {
                fromDatabase.Open();
                // SQL query to select all data from the 'cabe_book' table
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

        // Method to load data into the DataGridView (overloaded)
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

        // Method to get a list of books from the database
        private DataTable GetBooksList()
        {
            string query = "SELECT * FROM librarymanagementsystem.cabe_book";
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

        // Event handler for the "searchButton" click
        private void searchButton_Click(object sender, EventArgs e)
        {
            string valueToSearch = searchtextBox.Text.ToString();
            searchData(valueToSearch);
        }

        // Event handler for the "searchtextBox" key down
        private void searchtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Perform search when Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        // Function to search for a book in the database
        public DataTable SearchBook(string searchQuery)
        {
            // SQL query to search for books with a specific value in the book name column
            string selectQuery = $"SELECT * FROM cabe_book WHERE Book_Name LIKE '%{searchQuery}%'";
            return db.GetData(selectQuery, null);
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
            // Show the LIBBOOK form and close the current form
            LIBBOOK CABE_BOOK = new LIBBOOK();
            CABE_BOOK.Show();
            this.Close();
        }
    }
}
