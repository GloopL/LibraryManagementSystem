using LibraryManagementSystem.ST_BORROWED_BOOKS;
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

namespace LibraryManagementSystem.LIBBOOKSSECTION
{
    // Partial class for managing CIT books within the library system
    public partial class CIT_BOOKS : Form
    {
        // Instance variables for managing database connectivity
        DATABASE.MYDB db = new DATABASE.MYDB();
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        // Constructor for CIT_BOOKS form
        public CIT_BOOKS()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        // Method to set up the initial database connection
        private void InitializeDatabaseConnection()
        {
            try
            {
                // Set up the connection string with MySQL configuration
                fromDatabase = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");
            }
            catch (Exception ex)
            {
                // Display an error message if there is an issue with the database connection
                MessageBox.Show("Error in database connection: " + ex.Message);
            }
        }

        // Load event handler for the CIT_BOOKS form
        private void CIT_BOOKS_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Load DataGridView when the form loads
            LoadDataGridView();
        }

        // Click event handler for the "Add Book" button
        private void addBook_Click(object sender, EventArgs e)
        {
            // Get input values like book ID, book name, author, publisher, quantity
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
                // Display a warning if any field is empty
                MessageBox.Show("Failed to Add New Book. All fields must be filled.", "Add New Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Method to add a new book to the database
        private void AddNewBook(string bookId, string bookName, string author, string publisher, string quantity)
        {
            try
            {
                fromDatabase.Open();

                // SQL query to insert new book details into the 'cit_book' table
                string insertQuery = "INSERT INTO librarymanagementsystem.cit_book (`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) " +
                                    "VALUES (@bookId, @bookName, @author, @publisher, @quantity)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, fromDatabase))
                {
                    // Set parameters for the SQL query
                    command.Parameters.AddWithValue("bookId", bookId);
                    command.Parameters.AddWithValue("bookName", bookName);
                    command.Parameters.AddWithValue("author", author);
                    command.Parameters.AddWithValue("publisher", publisher);
                    command.Parameters.AddWithValue("quantity", quantity);

                    // Execute the SQL query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Display a success message and refresh DataGridView after adding a new book
                        MessageBox.Show("New Book Added Successfully", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                    }
                    else
                    {
                        // Display a warning if the addition fails
                        MessageBox.Show("Failed to Add New Book", "Add New Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the database connection
                fromDatabase.Close();
            }
        }

        // Click event handler for the "Edit" button
        private void EDIT_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values like book ID, book name, author, publisher, quantity
                string bookId = BOOKID.Text;
                string bookName = BNAME.Text;
                string author = AUTHOR.Text;
                string publisher = PUB.Text;
                string quantity = QTY.Text;

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
                    // Display a warning if any field is empty
                    MessageBox.Show("Failed to Edit Book. All fields must be filled.", "Edit Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("Error: " + ex.Message, "Invalid ID");
            }
        }

        // Method to edit book details in the database
        private bool EditBook(string bookId, string bookName, string author, string publisher, string quantity)
        {
            try
            {
                using (fromDatabase = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''; database=librarymanagementsystem"))
                {
                    fromDatabase.Open();

                    // SQL query to update book details in the 'cit_book' table
                    string updateQuery = "UPDATE `cit_book` SET `Book_Name`= @bookName, `Author`= @author, `Publisher`= @publisher, `Quantity`= @quantity WHERE `Book_ID`= @bookId";

                    using (command = new MySqlCommand(updateQuery, fromDatabase))
                    {
                        // Set parameters for the SQL query
                        command.Parameters.AddWithValue("@bookId", bookId);
                        command.Parameters.AddWithValue("@bookName", bookName);
                        command.Parameters.AddWithValue("@author", author);
                        command.Parameters.AddWithValue("@publisher", publisher);
                        command.Parameters.AddWithValue("@quantity", quantity);

                        // Execute the SQL query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Display a success message and refresh DataGridView after editing a book
                            MessageBox.Show("Book Edited Successfully", "Edit Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataGridView();
                        }
                        else
                        {
                            // Display a warning if the editing fails
                            MessageBox.Show("Failed to Edit Book", "Edit Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                // Close the database connection outside the using block
                fromDatabase.Close();

                return true;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Click event handler for the "Remove" button
        private void REMOVE_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                string bookId = BOOKID.Text;

                if (RemoveStudent(bookId))
                {
                    // Display a success message if the book is removed
                    MessageBox.Show("Book Removed Successfully", "Removed Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Display a warning if the removal fails
                    MessageBox.Show("Failed to Remove Book", "Removal Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }

        // Method to remove a book from the database
        public bool RemoveStudent(string bookId)
        {
            // SQL query to delete a book from the 'cit_book' table
            string query = "DELETE FROM `cit_book` WHERE `Book_ID`= @bookId";

            using (MySqlConnection connection = db.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
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
                // SQL query to select all records from the 'cit_book' table
                string selectQuery = "SELECT * FROM librarymanagementsystem.cit_book";
                command = new MySqlCommand(selectQuery, fromDatabase);
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Set the DataGridView data source and make it read-only
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs while loading data
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                fromDatabase.Close();
            }
        }

        // Method to search for a book based on user input
        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                // SQL query to search for a book in the 'cit_book' table
                string query = "SELECT * FROM librarymanagementsystem.cit_book WHERE  CONCAT(`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) like '%" + valueToSearch + "%'";
                command = new MySqlCommand(query, fromDatabase);
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Set the DataGridView data source with the search results
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs during the search
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                fromDatabase.Close();
            }
        }

        // Click event handler for the "Search" button
        private void searchButton_Click(object sender, EventArgs e)
        {
            string valueToSearch = searchtextBox.Text.ToString();
            // Call the method to search for a book
            searchData(valueToSearch);
        }

        // KeyDown event handler for the "Search" button
        private void searchButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Perform a click on the "Search" button when the Enter key is pressed
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        // KeyDown event handler for the searchTextBox
        private void searchtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Perform a click on the "Search" button when the Enter key is pressed
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        // Event handler for button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Open the book list form
            BB_BOOKS_LIST BB_CIT_BOOKS = new BB_BOOKS_LIST();
            BB_CIT_BOOKS.Show();
            this.Close();
        }
    }
}


