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
        private ST_ADINTERFACE st_adinterface = new ST_ADINTERFACE();
        private DataTable studentData;


        private DataGridView dataGridView1_st_adinterfacee;
        private TextBox Srcode;
        private TextBox Sname;
        private TextBox dept;
        private TextBox pnum;
        private TextBox searchtextBox;
        private Button searchButton;



        //fields --
        private MySqlConnection fromDatabase;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private System.Data.DataTable dataTable;


        public ST_ADINTERFACEE()
        {
            InitializeComponent(); // --

            // Initialize DataGridView
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
        private void InitializeDatabaseConnection() // --
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

        private void button4_Click(object sender, EventArgs e)
        {
            AdminInteracee ST_ADINTERFACEE = new AdminInteracee();
            ST_ADINTERFACEE.Show();
            this.Close();
        }

        // ADD NEW STUDENT
        private void button1_Click(object sender, EventArgs e)
        {
            string SRcode = SR_CODE.Text;
            string StudentName = S_NAME.Text;
            string dept = DEPARTMENT.Text;
            string pnum = PHNUM.Text;
            string add = ADD3.Text;
            string pass = PASS3.Text;

            // CHECK if the sr code and last name are empty
            if (SRcode.Trim().Equals("") || StudentName.Trim().Equals(""))
            {
                MessageBox.Show("You need to enter the student's SR code and Student Name", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
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

        //for editing
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


                if (SRcode.Trim().Equals("") || StudentName.Trim().Equals(""))
                {
                    MessageBox.Show("You need to enter the student's SR code and Student Name", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (st_adinterface.EditStudent(id, SRcode, StudentName, dept, pnum, add, pass))
                    {
                        MessageBox.Show("Student Info Updated Successfully", "edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh DataGridView after adding a student
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

        // for removingg 
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ST_ID.Text);

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

        private void LoadDataGridView()
        {
            // Assuming StudentList returns a DataTable with data
            dataGridView1_st_adinterfacee.DataSource = st_adinterface.StudentList();
            loadData(); //--

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }

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


        private void SearchButton_Click(object sender, EventArgs e)
        {
            string valueToSearch = searchTextBox.Text.ToString();
            searchData(valueToSearch);
        }

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
                