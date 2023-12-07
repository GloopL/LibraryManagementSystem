using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManagementSystem
{
    public partial class ST_ADINTERFACEE : Form
    {
        // Instance of the ST_ADINTERFACE class
        private ST_ADINTERFACE st_adinterface = new ST_ADINTERFACE();

        // DataTable to store student data
        private DataTable studentData;

        // Controls
        private DataGridView dataGridView1_st_adinterfacee;
        private TextBox Srcode;
        private TextBox Sname;
        private TextBox dept;
        private TextBox pnum;
        private TextBox searchtextBox;
        private Button searchButton;

        // Database fields
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private System.Data.DataTable dataTable;

        // Constructor for the ST_ADINTERFACEE class
        public ST_ADINTERFACEE()
        {
            InitializeComponent();

            // Initialize DataGridView and other controls
            dataGridView1_st_adinterfacee = new DataGridView();
            dataGridView1_st_adinterfacee.Dock = DockStyle.Fill;
            Controls.Add(dataGridView1_st_adinterfacee);

            searchtextBox = new TextBox();
            searchtextBox.Location = new Point(10, 10);
            Controls.Add(searchtextBox);

            searchButton = new Button();
            searchButton.Text = "Search";
            searchButton.Location = new Point(150, 10);
            Controls.Add(searchButton);

            // Add event handler for CellContentClick
            dataGridView1_st_adinterfacee.CellContentClick += dataGridView1_CellContentClick;
        }

        // Initialize database connection
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

        // Button click event to go back to AdminInteracee form
        private void button4_Click(object sender, EventArgs e)
        {
            AdminInteracee ST_ADINTERFACEE = new AdminInteracee();
            ST_ADINTERFACEE.Show();
            this.Close();
        }

        // Button click event to add a new student
        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve data from textboxes
            string SRcode = SR_CODE.Text;
            string StudentName = S_NAME.Text;
            string dept = DEPARTMENT.Text;
            string pnum = PHNUM.Text;
            string add = ADD3.Text;
            string pass = PASS3.Text;

            // Check if SR code and last name are empty
            if (SRcode.Trim().Equals("") || StudentName.Trim().Equals(""))
            {
                MessageBox.Show("You need to enter the student's SR code and Student Name", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Add the new student
                if (st_adinterface.AddStudent(SRcode, StudentName, dept, pnum, add, pass))
                {
                    MessageBox.Show("New Student Added Successfully", "New Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh DataGridView after adding a student
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Student Not Added", "Add error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Button click event to edit an existing student
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ST_ID.Text);
                string SRcode = SR_CODE.Text;
                string StudentName = S_NAME.Text;
                string dept = DEPARTMENT.Text;
                string pnum = PHNUM.Text;
                string add = ADD3.Text;
                string pass = PASS3.Text;

                // Check if SR code and last name are empty
                if (SRcode.Trim().Equals("") || StudentName.Trim().Equals(""))
                {
                    MessageBox.Show("You need to enter the student's SR code and Student Name", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Edit the student
                    if (st_adinterface.EditStudent(id, SRcode, StudentName, dept, pnum, add, pass))
                    {
                        MessageBox.Show("Student Info Updated Successfully", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh DataGridView after editing a student
                        LoadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Student info not Updated", "Edit error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid id");
            }
        }

        // Button click event to remove an existing student
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ST_ID.Text);

                // Remove the student
                if (st_adinterface.RemoveStudent(id))
                {
                    MessageBox.Show("Student is removed", "Removed Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Student info not Deleted", "Deletion error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid id");
            }
        }

        // Form load event
        private void ST_ADINTERFACEE_Load(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();//--
            // Load DataGridView when the form loads
            LoadDataGridView();

            // Customize DataGridView header
            dataGridView1_st_adinterfacee.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1_st_adinterfacee.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            dataGridView1_st_adinterfacee.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Load data into the DataGridView
        private void LoadDataGridView()
        {
            // Assuming StudentList returns a DataTable with data
            dataGridView1_st_adinterfacee.DataSource = st_adinterface.StudentList();
            loadData(); //--
        }

        // Event handler for the CellContentClick event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }

        // Load data into the DataGridView
        private void loadData()
        {
            string selectQuery = "SELECT * FROM librarymanagementsystem.student";
            try
            {
                fromDatabase.Open();
                command = new MySqlCommand(selectQuery, fromDatabase);
                adapter = new MySqlDataAdapter(command);
                dataTable = new System.Data.DataTable();
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

        // Search data in the DataGridView
        private void searchData(string valueToSearch)
        {
            try
            {
                fromDatabase.Open();
                string query = "SELECT * FROM librarymanagementsystem.student WHERE  CONCAT(`StudentID`,`SrCode`,`StudentName`,`StudentPhoneNumber`,`Department`,`Address`,`Password`) like '%" + valueToSearch + "%'";
                command = new MySqlCommand(query, fromDatabase);
                adapter = new MySqlDataAdapter(command);
                dataTable = new System.Data.DataTable();
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

        // Search button click event
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string valueToSearch = searchTextBox.Text.ToString();
            searchData(valueToSearch);
        }

        // Handle key press in searchTextBox
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}

