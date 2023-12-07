using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.BBOOKS_SECTION_ADMIN
{
    // Partial class for the BB_BOOKS_LIST_ADMIN form
    public partial class BB_BOOKS_LIST_ADMIN : Form
    {
        // Constructor for the BB_BOOKS_LIST_ADMIN form
        public BB_BOOKS_LIST_ADMIN()
        {
            InitializeComponent();
        }

        // Event handler for the "button7" click
        private void button7_Click(object sender, EventArgs e)
        {
            // Show the AdminInteracee form and close the current form
            AdminInteracee BB_BOOK_LIST_ADMIN = new AdminInteracee();
            BB_BOOK_LIST_ADMIN.Show();
            this.Close();
        }

        // Event handler for the "button1" click
        private void button1_Click(object sender, EventArgs e)
        {
            // Show the BB_CAS form and close the current form
            BB_CAS BB_BOOK_LIST_ADMIN = new BB_CAS();
            BB_BOOK_LIST_ADMIN.Show();
            this.Close();
        }

        // Event handler for the "button2" click
        private void button2_Click(object sender, EventArgs e)
        {
            // Show the BB_CABE form and close the current form
            BB_CABE BB_BOOK_LIST_ADMIN = new BB_CABE();
            BB_BOOK_LIST_ADMIN.Show();
            this.Close();
        }

        // Event handler for the "button3" click
        private void button3_Click(object sender, EventArgs e)
        {
            // Show the BB_CICS form and close the current form
            BB_CICS BB_BOOK_LIST_ADMIN = new BB_CICS();
            BB_BOOK_LIST_ADMIN.Show();
            this.Close();
        }

        // Event handler for the "button4" click
        private void button4_Click(object sender, EventArgs e)
        {
            // Show the BB_CIT form and close the current form
            BB_CIT BB_BOOK_LIST_ADMIN = new BB_CIT();
            BB_BOOK_LIST_ADMIN.Show();
            this.Close();
        }

        // Event handler for the "button5" click
        private void button5_Click(object sender, EventArgs e)
        {
            // Show the BB_CTE form and close the current form
            BB_CTE BB_BOOK_LIST_ADMIN = new BB_CTE();
            BB_BOOK_LIST_ADMIN.Show();
            this.Close();
        }

        // Event handler for the "button6" click
        private void button6_Click(object sender, EventArgs e)
        {
            // Show the BB_COE form and close the current form
            BB_COE BB_BOOK_LIST_ADMIN = new BB_COE();
            BB_BOOK_LIST_ADMIN.Show();
            this.Close();
        }

        // Event handler for the BB_BOOKS_LIST_ADMIN form load
        private void BB_BOOKS_LIST_ADMIN_Load(object sender, EventArgs e)
        {
            // You can add any additional logic or initialization here if needed
        }
    }
}

