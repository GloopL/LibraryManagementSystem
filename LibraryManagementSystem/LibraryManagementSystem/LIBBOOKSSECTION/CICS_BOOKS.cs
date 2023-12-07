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
    public partial class CICS_BOOKS : Form
    {
        // Database related objects
        DATABASE.MYDB db = new DATABASE.MYDB();
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public CICS_BOOKS()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

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

        private void CICS_BOOKS_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Load DataGridView when the form loads
            LoadDataGridView();
        }

        private void addBook_Click(object sender, EventArgs e)
        {
            // For adding new books
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
                MessageBox.Show("Failed to Add New Book. All fields must be filled.", "Add New Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddNewBook(string bookId, string bookName, string author, string publisher, string quantity)
        {
            // Implement your logic to update the database with new book details
            // Use a SQL query to insert the new book details into a 'Books' table
            try
            {
                fromDatabase.Open();

                string insertQuery = "INSERT INTO librarymanagementsystem.cics_book (`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) " +
                                    "VALUES (@bookId, @bookName, @author, @publisher, @quantity)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, fromDatabase))
                {
                    command.Parameters.AddWithValue("bookId", bookId);
                    command.Parameters.AddWithValue("bookName", bookName);
                    command.Parameters.AddWithValue("author", author);
                    command.Parameters.AddWithValue("publisher", publisher);
                    command.Parameters.AddWithValue("quantity", quantity);

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

        // For editing books
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
                    EditBook(bookId, bookName, author, publisher, quantity);
                }
                else
                {
                    MessageBox.Show("Failed to Add New Book. All fields must be filled.", "Add New Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Invalid ID");
            }
        }

        private bool EditBook(string bookId, string bookName, string author, string publisher, string quantity)
        {
            try
            {
                using (fromDatabase = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''; database=librarymanagementsystem"))
                {
                    fromDatabase.Open();

                    string updateQuery = "UPDATE `cics_book` SET `Book_Name`= @bookName, `Author`= @author, `Publisher`= @publisher, `Quantity`= @quantity WHERE `Book_ID`= @bookId";

                    using (command = new MySqlCommand(updateQuery, fromDatabase))
                    {
                        command.Parameters.AddWithValue("@bookId", bookId);
                        command.Parameters.AddWithValue("@bookName", bookName);
                        command.Parameters.AddWithValue("@author", author);
                        command.Parameters.AddWithValue("@publisher", publisher);
                        command.Parameters.AddWithValue("@quantity", quantity);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The book is already edited", "Edit book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh DataGridView after editing a book
                            LoadDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Failed to edit Book", "Book Editing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // For removing a certain book
        private void REMOVE_BUTTON_Click_1(object sender, EventArgs e)
        {
            try
            {
                string bookId = BOOKID.Text;

                if (RemoveStudent(bookId))
                {
                    MessageBox.Show("Book is removed", "Removed Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Book info not Deleted", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }

        public bool RemoveStudent(string bookId)
        {
            string query = "DELETE FROM `cics_book` WHERE `Book_ID`= @bookId";

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

        private void LoadDataGridView()
        {
            try
            {
                fromDatabase.Open();
                string selectQuery = "SELECT * FROM librarymanagementsystem.cics_book";
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

        private void loadData()
        {
            string selectQuery = "SELECT * FROM librarymanagementsystem.cics_book";
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

        private DataTable GetBooksList()
        {
            string query = "SELECT * FROM librarymanagementsystem.cics_book";
            DataTable table = db.GetData(query, null);
            Console.WriteLine("Number of rows retrieved: " + table.Rows.Count);
            return table;
        }

        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                string query = "SELECT * FROM librarymanagementsystem.cics_book WHERE  CONCAT(`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) like '%" + valueToSearch + "%'";
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

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            string valueToSearch = searchtextBox.Text.ToString();
            searchData(valueToSearch);
        }

        private void searchtextBox_KeyDown_1(object sender, KeyEventArgs e)
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
            string selectQuery = $"SELECT * FROM cics_book WHERE Book_Name LIKE '%{searchQuery}%'";
            return db.GetData(selectQuery, null);
        }

        private void searchButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Refresh DataGridView
            searchData("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open another form
            LIBBOOK CICS_BOOKS = new LIBBOOK();
            CICS_BOOKS.Show();
            this.Close();
        }

        private void searchtextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle text change in the search text box if needed
        }
    }
}



