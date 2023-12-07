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

namespace LibraryManagementSystem.ST_RETURNED_BOOKS
{
    public partial class ST_COE_RETURNED : Form
    {
        // Database connection and command objects
        DATABASE.MYDB db = new DATABASE.MYDB();
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        // Constructor for ST_COE_RETURNED
        public ST_COE_RETURNED()
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

        // Event handler for form load
        private void ST_COE_RETURNED_Load(object sender, EventArgs e)
        {
            // Customize DataGridView header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Initialize database connection
            InitializeDatabaseConnection();
            // Load DataGridView when the form loads
            LoadDataGridView();
        }

        // Method to load data into DataGridView
        private void LoadDataGridView()
        {
            try
            {
                fromDatabase.Open();
                string selectQuery = "SELECT * FROM librarymanagementsystem.coe_borrowed_books";
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

        // Event handler for returning a book
        private void ReturnedBook_Click(object sender, EventArgs e)
        {
            // Retrieve values from form fields
            string studentId = studentID.Text;
            string bookId = bookID.Text;
            string bookName = BookName.Text;

            // Check if necessary fields are filled
            if (!string.IsNullOrEmpty(studentId) &&
                !string.IsNullOrEmpty(bookId) && !string.IsNullOrEmpty(bookName))
            {
                // Return the book
                ReturnBook(studentId, bookId, bookName);
            }
            else
            {
                MessageBox.Show("Failed to Return Book. Student ID and Book ID and the rest must be filled.", "Return Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // Method to handle the book returning process
        private void ReturnBook(string studentId, string bookId, string bookName)
        {
            try
            {
                fromDatabase.Open();

                // Check if the book has been borrowed by the student
                string checkBorrowedQuery = "SELECT * FROM librarymanagementsystem.coe_borrowed_books WHERE Student_ID = @studentId AND Book_ID = @bookId";
                using (MySqlCommand checkBorrowedCommand = new MySqlCommand(checkBorrowedQuery, fromDatabase))
                {
                    checkBorrowedCommand.Parameters.AddWithValue("studentId", studentId);
                    checkBorrowedCommand.Parameters.AddWithValue("bookId", bookId);

                    using (MySqlDataReader reader = checkBorrowedCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Book is borrowed by the student, proceed with returning

                            // Close the DataReader before executing another command
                            reader.Close();

                            // Delete the record from the borrowed_books table
                            string deleteBorrowedBookQuery = "DELETE FROM librarymanagementsystem.coe_borrowed_books WHERE Student_ID = @studentId AND Book_ID = @bookId";
                            using (MySqlCommand deleteBorrowedBookCommand = new MySqlCommand(deleteBorrowedBookQuery, fromDatabase))
                            {
                                deleteBorrowedBookCommand.Parameters.AddWithValue("studentId", studentId);
                                deleteBorrowedBookCommand.Parameters.AddWithValue("bookId", bookId);

                                int rowsAffected = deleteBorrowedBookCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Increase the quantity of the returned book in the coe_book table
                                    string updateQuantityQuery = "UPDATE librarymanagementsystem.coe_book SET Quantity = Quantity + 1 WHERE Book_ID = @bookId";
                                    using (MySqlCommand updateQuantityCommand = new MySqlCommand(updateQuantityQuery, fromDatabase))
                                    {
                                        updateQuantityCommand.Parameters.AddWithValue("bookId", bookId);

                                        int updateRowsAffected = updateQuantityCommand.ExecuteNonQuery();

                                        if (updateRowsAffected > 0)
                                        {
                                            MessageBox.Show("Book Returned Successfully", "Return Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            // Update the displayed data
                                            LoadDataGridView();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Failed to Update Book Quantity", "Return Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Failed to Return Book", "Return Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("This book is not borrowed by the student.", "Return Book Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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

        // Method to search for books
        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                string query = "SELECT * FROM librarymanagementsystem.coe_borrowed_books WHERE  CONCAT(Student_ID, Book_ID, Borrowed_Date) like '%" + valueToSearch + "%'";
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

        // Event handler for cell content click in the DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }

        // Event handler for navigating to the returned books list form
        private void button1_Click(object sender, EventArgs e)
        {
            ST_RETURNED_BOOKS_LIST ST_COE_RETURNED = new ST_RETURNED_BOOKS_LIST();
            ST_COE_RETURNED.Show();
            this.Close();
        }
    }
}
