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
    public partial class ST_RETURNED_BOOKS_LIST : Form
    {
        public ST_RETURNED_BOOKS_LIST()
        {
            InitializeComponent();
        }

        // Button click event to navigate to the returned books list for CAS
        private void button1_Click(object sender, EventArgs e)
        {
            ST_CAS_RETURNED ST_RETURNED_BOOKS_LIST = new ST_CAS_RETURNED();
            ST_RETURNED_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to the returned books list for CABE
        private void button2_Click(object sender, EventArgs e)
        {
            ST_CABE_RETURNED ST_RETURNED_BOOKS_LIST = new ST_CABE_RETURNED();
            ST_RETURNED_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to the returned books list for CICS
        private void button3_Click(object sender, EventArgs e)
        {
            ST_CICS_RETURNED ST_RETURNED_BOOKS_LIST = new ST_CICS_RETURNED();
            ST_RETURNED_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to the returned books list for CIT
        private void button4_Click(object sender, EventArgs e)
        {
            ST_CIT_RETURNED ST_RETURNED_BOOKS_LIST = new ST_CIT_RETURNED();
            ST_RETURNED_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to the returned books list for CTE
        private void button5_Click(object sender, EventArgs e)
        {
            ST_CTE_RETURNED ST_RETURNED_BOOKS_LIST = new ST_CTE_RETURNED();
            ST_RETURNED_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to the returned books list for COE
        private void button6_Click(object sender, EventArgs e)
        {
            ST_COE_RETURNED ST_RETURNED_BOOKS_LIST = new ST_COE_RETURNED();
            ST_RETURNED_BOOKS_LIST.Show();
            this.Close();
        }

        // Button click event to navigate to the student interface
        private void button7_Click(object sender, EventArgs e)
        {
            StudentInterface ST_RETURNED_BOOKS_LIST = new StudentInterface();
            ST_RETURNED_BOOKS_LIST.Show();
            this.Close();
        }

        // Load event when the form is loaded
        private void ST_RETURNED_BOOKS_LIST_Load(object sender, EventArgs e)
        {
            // Add any additional initialization code here
        }
    }
}

