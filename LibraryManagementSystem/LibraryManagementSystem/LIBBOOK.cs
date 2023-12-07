using LibraryManagementSystem.LIBBOOKSSECTION;
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
    public partial class LIBBOOK : Form
    {
        // Constructor for the LIBBOOK class
        public LIBBOOK()
        {
            InitializeComponent();
        }

        // Event handler for the button6 click event
        private void button6_Click(object sender, EventArgs e)
        {
            // Create an instance of the COE_BOOKS form
            COE_BOOKS LIBBOOK = new COE_BOOKS();
            // Show the COE_BOOKS form
            LIBBOOK.Show();
            // Close the current LIBBOOK form
            this.Close();
        }

        // Event handler for the button7 click event
        private void button7_Click(object sender, EventArgs e)
        {
            // Create an instance of the AdminInteracee form
            AdminInteracee LIBBOOK = new AdminInteracee();
            // Show the AdminInteracee form
            LIBBOOK.Show();
            // Close the current LIBBOOK form
            this.Close();
        }

        // Event handler for the button1 click event
        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the CAS_BOOKS form
            CAS_BOOKS LIBBOOK = new CAS_BOOKS();
            // Show the CAS_BOOKS form
            LIBBOOK.Show();
            // Close the current LIBBOOK form
            this.Close();
        }

        // Event handler for the button2 click event
        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the CABE_BOOKS form
            CABE_BOOKS LIBBOOK = new CABE_BOOKS();
            // Show the CABE_BOOKS form
            LIBBOOK.Show();
            // Close the current LIBBOOK form
            this.Close();
        }

        // Event handler for the button3 click event
        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the CICS_BOOKS form
            CICS_BOOKS LIBBOOK = new CICS_BOOKS();
            // Show the CICS_BOOKS form
            LIBBOOK.Show();
            // Close the current LIBBOOK form
            this.Close();
        }

        // Event handler for the button5 click event
        private void button5_Click(object sender, EventArgs e)
        {
            // Create an instance of the CTE_BOOKS form
            CTE_BOOKS LIBBOOK = new CTE_BOOKS();
            // Show the CTE_BOOKS form
            LIBBOOK.Show();
            // Close the current LIBBOOK form
            this.Close();
        }

        // Event handler for the button4 click event
        private void button4_Click(object sender, EventArgs e)
        {
            // Create an instance of the CIT_BOOKS form
            CIT_BOOKS LIBBOOK = new CIT_BOOKS();
            // Show the CIT_BOOKS form
            LIBBOOK.Show();
            // Close the current LIBBOOK form
            this.Close();
        }

        // Event handler for the LIBBOOK form load event
        private void LIBBOOK_Load(object sender, EventArgs e)
        {

        }
    }
}
