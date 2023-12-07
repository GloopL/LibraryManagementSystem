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
    public partial class CTE_BOOKS : Form
    {
        DATABASE.MYDB db = new DATABASE.MYDB();
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public CTE_BOOKS()
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

        private void CTE_BOOKS_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            InitializeDatabaseConnection();//--
                                           // Load DataGridView when the form loads
            LoadDataGridView();
        }

        private void addBook_Click(object sender, EventArgs e)
        {
            //  for adding new books
            // Get input values like book name, author, publisher, quantity
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
            //  Use a SQL query to insert the new book details into a 'Books' table
            try
            {
                fromDatabase.Open();

                string insertQuery = "INSERT INTO librarymanagementsystem.cte_book (`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) " +
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
                    MessageBox.Show("Failed to Edit Book. All fields must be filled.", "Edit Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string updateQuery = "UPDATE `cte_book` SET `Book_Name`= @bookName, `Author`= @author, `Publisher`= @publisher, `Quantity`= @quantity WHERE `Book_ID`= @bookId";

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
                            MessageBox.Show("Book Edited Successfully", "Edit Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh DataGridView after editing a book
                            LoadDataGridView();
                        }
                        else
                        {
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
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void REMOVE_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                string bookId = BOOKID.Text;

                if (RemoveBook(bookId))
                {
                    MessageBox.Show("Book Removed Successfully", "Remove Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to Remove Book", "Remove Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }

        public bool RemoveBook(string bookId)
        {
            string query = "DELETE FROM `cte_book` WHERE `Book_ID`= @bookId";

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
                string selectQuery = "SELECT * FROM librarymanagementsystem.cte_book";
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
            string selectQuery = "SELECT * FROM librarymanagementsystem.cte_book";
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
            string query = "SELECT * FROM librarymanagementsystem.cte_book";
            DataTable table = db.GetData(query, null);
            Console.WriteLine("Number of rows retrieved: " + table.Rows.Count);
            return table;
        }

        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                string query = "SELECT * FROM librarymanagementsystem.cte_book WHERE  CONCAT(`Book_ID`,`Book_Name`, `Author`, `Publisher`, `Quantity`) like '%" + valueToSearch + "%'";
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            string valueToSearch = searchtextBox.Text.ToString();
            searchData(valueToSearch);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LIBBOOK CTE_BOOKS = new LIBBOOK();
            CTE_BOOKS.Show();
            this.Close();
        }
    }
}

