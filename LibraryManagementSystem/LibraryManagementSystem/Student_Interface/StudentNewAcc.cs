using Google.Protobuf.WellKnownTypes;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystem
{
    public partial class StudentNewAcc : Form
    {
        private ST_ADINTERFACE st_adinterface;

        private MySqlConnection fromDatabase;
        private STNEWACC stNewAcc = new STNEWACC();//aling form to?
        private TextBox Srcode;
        private TextBox SNAME;
        private TextBox dept;
        private TextBox pnum;
        private TextBox pass;

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

        public StudentNewAcc()
        {
            InitializeComponent();
            InitializeDatabaseConnection();

            st_adinterface = new ST_ADINTERFACE();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student1 form3 = new Student1();
            form3.Show();
            this.Close();
        }

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
                }
                else
                {
                    MessageBox.Show("Student Not Added", "Add error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        { 
           
        }

        private void StudentNewAcc_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NAME1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
