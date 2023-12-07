using LibraryManagementSystem.ST_RETURNED_BOOKS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class StudentInterface : Form
    {
        // Constructor for the StudentInterface form
        public StudentInterface()
        {
            InitializeComponent();
        }

        // Button click event to navigate back to the Student1 form
        private void button4_Click(object sender, EventArgs e)
        {
            Student1 studentInterface = new Student1();
            studentInterface.Show();
            this.Close();
        }

        // Button click event to navigate to the STBOOK form
        private void button3_Click(object sender, EventArgs e)
        {
            STBOOK studentInterface = new STBOOK();
            studentInterface.Show();
            this.Close();
        }

        // Button click event to navigate to the BB_BOOKS_LIST form
        private void button2_Click(object sender, EventArgs e)
        {
            BB_BOOKS_LIST studentInterface = new BB_BOOKS_LIST();
            studentInterface.Show();
            this.Close();
        }

        // Button click event to navigate to the ST_RETURNED_BOOKS_LIST form
        private void button1_Click(object sender, EventArgs e)
        {
            ST_RETURNED_BOOKS_LIST studentInterface = new ST_RETURNED_BOOKS_LIST();
            studentInterface.Show();
            this.Close();
        }

        // Load event for the StudentInterface form
        private void StudentInterface_Load(object sender, EventArgs e)
        {
            // You can add any additional initialization code here if needed
        }
    }
}

