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

namespace LibraryManagementSystem.ST_BORROWED_BOOKS
{
    public partial class BB_CAS_BOOKS : Form
    {
        DATABASE.MYDB db = new DATABASE.MYDB();
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public BB_CAS_BOOKS()
        {
            InitializeComponent();
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

        // Event handler for the form load event
        private void BB_CAS_BOOKS_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            InitializeDatabaseConnection();//--
                                           // Load DataGridView when the form loads
            LoadDataGridView();
        }

        // Method to load data into the DataGridView
        private void LoadDataGridView()
        {
            try
            {
                fromDatabase.Open();
                string selectQuery = "SELECT * FROM librarymanagementsystem.cas_borrowed_books";
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

        // Method to reload data into the DataGridView
        private void loadData()
        {
            string selectQuery = "SELECT * FROM librarymanagementsystem.cas_borrowed_books";
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

        // Method to get the list of books
        private DataTable GetBooksList()
        {
            string query = "SELECT * FROM librarymanagementsystem.cas_borrowed_books";
            DataTable table = db.GetData(query, null);
            Console.WriteLine("Number of rows retrieved: " + table.Rows.Count);
            return table;
        }

        // Method to search for data in the DataGridView
        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                string query = "SELECT * FROM librarymanagementsystem.cas_borrowed_books WHERE  CONCAT(Student_ID, Book_ID, Borrowed_Date) like '%" + valueToSearch + "%'";
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

        // Event handler for the "Borrow Book" button click
        private void addBook_Click(object sender, EventArgs e)
        {
            string srcode = SRCODE.Text;
            string bookId = bookID.Text;
            string bookName = BookName.Text;

            if (!string.IsNullOrEmpty(srcode) &&
                !string.IsNullOrEmpty(bookId) && !string.IsNullOrEmpty(bookName))
            {
                BorrowBookFromLibrary(srcode, bookId, bookName);
            }
            else
            {
                MessageBox.Show("Failed to Borrow Book. Student ID and Book ID and the rest must be filled.", "Borrow Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Method to handle the process of borrowing a book from the library
        private void BorrowBookFromLibrary(string srcode, string bookId, string bookName)
        {
            try
            {
                fromDatabase.Open();

                // Check if the book is available for borrowing
                string checkAvailabilityQuery = "SELECT Quantity FROM librarymanagementsystem.cas_book WHERE Book_ID = @bookId";
                using (MySqlCommand checkAvailabilityCommand = new MySqlCommand(checkAvailabilityQuery, fromDatabase))
                {
                    checkAvailabilityCommand.Parameters.AddWithValue("bookId", bookId);
                    object result = checkAvailabilityCommand.ExecuteScalar();

                    if (result != null && Convert.ToInt32(result) > 0)
                    {
                        // Update the quantity of the book in the cas_book table
                        string updateQuantityQuery = "UPDATE librarymanagementsystem.cas_book SET Quantity = Quantity - 1 WHERE Book_ID = @bookId";
                        using (MySqlCommand updateQuantityCommand = new MySqlCommand(updateQuantityQuery, fromDatabase))
                        {
                            updateQuantityCommand.Parameters.AddWithValue("bookId", bookId);
                            int rowsAffected = updateQuantityCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Insert a record into the borrowed_books table
                                string insertBorrowedBookQuery = "INSERT INTO librarymanagementsystem.cas_borrowed_books (Student_ID, Book_ID, Book_Name, Borrowed_Date) " +
                                                                 "VALUES (@studentId, @bookId, @bookName, NOW())";
                                using (MySqlCommand insertBorrowedBookCommand = new MySqlCommand(insertBorrowedBookQuery, fromDatabase))
                                {
                                    insertBorrowedBookCommand.Parameters.AddWithValue("studentId", srcode);
                                    insertBorrowedBookCommand.Parameters.AddWithValue("bookId", bookId);
                                    insertBorrowedBookCommand.Parameters.AddWithValue("bookName", bookName);

                                    int borrowedRowsAffected = insertBorrowedBookCommand.ExecuteNonQuery();

                                    if (borrowedRowsAffected > 0)
                                    {
                                        MessageBox.Show("Book Borrowed Successfully", "Borrow Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        // Check if the student has borrowed 3 or more books
                                        int numberOfBorrowedBooks = GetNumberOfBorrowedBooks(srcode);

                                        if (numberOfBorrowedBooks >= 3)
                                        {
                                            // Retrieve the student's name
                                            string studentName = GetStudentName(srcode);

                                            // Implement your reward logic here
                                            MessageBox.Show($"Congratulations, {studentName}!  Your commitment to reading is truly inspiring! You've borrowed 3 or more books consistently. As a token of appreciation, we're giving you a free stationary paper and a ballpen. Please claim it at the main desk of the library. Thank you.", "Reward", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to Borrow Book", "Borrow Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to Borrow Book. Quantity not updated", "Borrow Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Book is not available for borrowing. Quantity is zero.", "Borrow Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Method to get the number of books borrowed by a student
        private int GetNumberOfBorrowedBooks(string studentId)
        {
            // Query to get the number of books borrowed by a student
            string query = "SELECT COUNT(*) FROM librarymanagementsystem.cas_borrowed_books WHERE Student_ID = @studentId";
            using (MySqlCommand command = new MySqlCommand(query, fromDatabase))
            {
                command.Parameters.AddWithValue("studentId", studentId);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        // Method to get the student's name
        private string GetStudentName(string srcode)
        {
            // Query to get the student's name
            string query = "SELECT StudentName FROM librarymanagementsystem.student WHERE SRCode= @src";
            using (MySqlCommand command = new MySqlCommand(query, fromDatabase))
            {
                command.Parameters.AddWithValue("src", srcode);
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : "";
            }
        }

        // Event handler for the "Search" button click
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }

        // Event handler for the "Back" button click
        private void button1_Click(object sender, EventArgs e)
        {
            BB_BOOKS_LIST BB_CAS_BOOKS = new BB_BOOKS_LIST();
            BB_CAS_BOOKS.Show();
            this.Close();
        }
    }
}
