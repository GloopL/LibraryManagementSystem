using LibraryManagementSystem.ST_BORROWED_BOOKS;
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
    public partial class BB_BOOKS_LIST : Form
    {
        public BB_BOOKS_LIST()
        {
            InitializeComponent();
        }

        // Button click event to navigate to CAS books list
        private void button1_Click(object sender, EventArgs e)
        {
            BB_CAS_BOOKS BB_BOOKS_LIST = new BB_CAS_BOOKS();
            BB_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to CABE books list
        private void button2_Click(object sender, EventArgs e)
        {
            BB_CABE_BOOKScs BB_BOOKS_LIST = new BB_CABE_BOOKScs();
            BB_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to CICS books list
        private void button3_Click(object sender, EventArgs e)
        {
            BB_CICS_BOOKS BB_BOOK_LIST = new BB_CICS_BOOKS();
            BB_BOOK_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to CIT books list
        private void button4_Click(object sender, EventArgs e)
        {
            BB_CIT_BOOKS BB_BOOKS_LIST = new BB_CIT_BOOKS();
            BB_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to CTE books list
        private void button5_Click(object sender, EventArgs e)
        {
            BB_CTE_BOOKS BB_BOOKS_LIST = new BB_CTE_BOOKS();
            BB_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to COE books list
        private void button6_Click(object sender, EventArgs e)
        {
            BB_COE_BOOKS BB_BOOKS_LIST = new BB_COE_BOOKS();
            BB_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to student interface
        private void button7_Click(object sender, EventArgs e)
        {
            StudentInterface BB_BOOKS_LIST = new StudentInterface();
            BB_BOOKS_LIST.Show();
            this.Close();
        }

        private void BB_BOOKS_LIST_Load(object sender, EventArgs e)
        {

        }
    }
}

