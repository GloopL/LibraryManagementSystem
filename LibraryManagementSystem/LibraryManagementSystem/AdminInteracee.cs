using LibraryManagementSystem.BBOOKS_SECTION_ADMIN;
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
    public partial class AdminInteracee : Form
    {
        // Constructor for the AdminInteracee form
        public AdminInteracee()
        {
            InitializeComponent();
        }

        // Event handler for the 'Back' button click
        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            Admin AdminInteracee = new Admin();
            // Show the Admin form
            AdminInteracee.Show();
            // Close the current AdminInteracee form
            this.Close();
        }

        // Event handler for the 'Show Students' button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the ST_ADINTERFACEE form (Assuming this form is for showing student accounts)
            ST_ADINTERFACEE AdminInteracee = new ST_ADINTERFACEE();
            // Show the ST_ADINTERFACEE form
            AdminInteracee.Show();
            // Close the current AdminInteracee form
            this.Close();
        }

        // Event handler for the form load event
        private void AdminInteracee_Load(object sender, EventArgs e)
        {
            // This method can be used for any additional setup when the form loads
            // Currently, it's empty
        }

        // Event handler for the 'Library Books' button click
        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the LIBBOOK form
            LIBBOOK AdminInteracee = new LIBBOOK();
            // Show the LIBBOOK form
            AdminInteracee.Show();
            // Close the current AdminInteracee form
            this.Close();
        }

        // Event handler for the 'Borrowed Books List' button click
        private void button4_Click(object sender, EventArgs e)
        {
            // Create an instance of the BB_BOOKS_LIST_ADMIN form
            BB_BOOKS_LIST_ADMIN AdminInterfacee = new BB_BOOKS_LIST_ADMIN();
            // Show the BB_BOOKS_LIST_ADMIN form
            AdminInterfacee.Show();
            // Close the current AdminInteracee form
            this.Close();
        }
    }
}
